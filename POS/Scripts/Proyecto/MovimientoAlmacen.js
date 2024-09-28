

$(document).ready(function () {

    $('#btnProductosModal').click(function () {
        $.ajax({
            url: "ListaProductos",
            type: "GET",
            dataType: 'html',
            success: function (data) {
                $('#mbodyProd').html(data);
                $('#modal-Productos').modal();
                $('#tblistProd').DataTable();
            },
            error: function () {
                alert("hay un fallo.");
            }
        });

    });

    $('#btnClientes').click(function () {
        $.ajax({
            url: "ListaClientes",
            type: "GET",
            dataType: 'html',
            success: function (data) {
                $('#mbodyClientes').html(data);
                $('#modal-Clientes').modal();
                $('#tblistClientes').DataTable();
            },
            error: function () {
                alert("hay un fallo.");
            }
        });

    });
    $('#FechaLimite').attr('readonly', 'readonly');

});


function addProduct(id) {

    $.get('AddSingleProduct',
        { idProducto: id },
        function (data) {


            // addProdBehind(0, id);
            var dt = $('#tblistProdMovimiento').DataTable();
            dt.row.add([
                data.Checkbox.toString(),
                data.Id,
                data.CodProducto.toString(),
                data.Producto.toString(),
                data.Envase.toString(),
                data.Existencia.toString(),
                data.Precio.toString(),
                data.Cantidad.toString(),
                data.Subtotal.toString()
                
            ]).draw(false);


        });
}

//Metodo para Eliminar un Producto de la lista
//var fromSession = JSON.parse(sessionStorage.getItem("lista"));
$('#codBarra').unbind("keypress").on("keypress", function (e) {
    if (e.which == 13) {
        var cbarra = $(this).val();

        $.get('GetSingleProductByCB',
            { cb: cbarra },
            function (data) {
                var dt = $('#tblistProdMovimiento').DataTable();

                dt.row.add([
                    data.Checkbox.toString(),
                    data.Id,
                    data.CodProducto.toString(),
                    data.Producto.toString(),
                    data.Envase.toString(),
                    data.Existencia.toString(),                    
                    data.Precio.toString(),
                    data.Cantidad.toString(),
                    data.Subtotal.toString()
                   
                ]).draw(false);

            });
    }
    $('#codBarra').select();
    $('#codBarra').text();
    $('#codBarra').focus();
});

$('#tblistProdMovimiento tbody').unbind("click").on('click', 'button', function () {



    swal({
        title: "Quitar Producto",
        text: "Seguro que desea quitar este producto de la lista?",
        icon: "warning",
        buttons: {
            cancel: "Cancelar",
            Ok: true
        }
    }).then((willDelete) => {
        if (willDelete) {
            var table = $('#tblistProdMovimiento').DataTable();
            table
                .row($(this).parents('tr'))
                .remove()
                .draw();
            CalcularTotal()
        } else {
            return;
        }
    });


});

//$('#ddtipoMov').change(function () {
    
//    if ($(this).val() ==3) {
//        $('#motivoDevolucion').removeAttr('readonly');

//    } else {
//        $('#motivoDevolucion').attr('readonly', 'readonly');
//        $('#motivoDevolucion').val("");
//    }
//})

$('#ddTipoPago').change(function () {
    var tipo = $(this).val();

    if (tipo == 1) {
        $('#FechaLimite').removeAttr('readonly');
        $('#MontoInicial').removeAttr('readonly');
    }
    else {
        $('#FechaLimite').attr('readonly', 'readonly');
        $('#MontoInicial').attr('readonly', 'readonly');
    }

})



//Calcular el Subtotal

var totGral = 0;


$('#tblistProdMovimiento tbody').on('change', 'input',
    function () {
       
        var self = $(this);
        var cantidad = $(this).val();
        
        var id = self.attr('id');
        $.get('AddSingleProduct',
           { idProducto: parseInt(id) },
           function (data) {
               
               var subtotal = cantidad * $(data.Precio).val();
              var idSubt = "#t" + data.Id;

             idSubt.toString();
               $(idSubt).val('');
                $('#totalGral').val(0);
              $(idSubt).val(subtotal.toString());
              CalcularTotal();

           });


    });



function CalcularSubTotal(cantidad, precio, idsubt) {

    var subtotal = cantidad * precio;
    var idSubt = "#t" + idsubt;

    idSubt.toString();
    $(idSubt).val('');
    $('#totalGral').val(0);
    $(idSubt).val(subtotal.toString());
}

function CalcularTotal() {
    var table = $('#tblistProdMovimiento').DataTable().rows().data();
  
    var s = 0;

   

    for (x = 0; x < table.length; x++) {
        var valuen = parseFloat($('#t' + table[x][1]).val());
     
        s += valuen;
       
    }
    totGral = s;
    $('#totalGral').val(totGral.toString());
    

  
}

function cargar() {
    var productsArray = [];
    var obj =
        {
            IdSuplidor: $('#ddSuplidor').val(),
            IdTipoMovimiento: $('#ddtipoMov').val(),
            NoFactura: $('#noFactura').val(),
            Ncf: $('#ncf').val(),
            TotalFacturado: $('#totalGral').val(),
            IdAlmacen: $('#ddAlmacen').val(),
            IdTipoPago: $('#ddTipoPago').val(),
            Motivo: $('#motivoDevolucion').val(),
            IdCliente: 0

        };
    var limite = $('#FechaLimite').val();
    var inicial = $('#MontoInicial').val();
    var obj2 = $('#tblistProdMovimiento').DataTable().rows().data();
    var obj3 = {

        IdProducto: '',
        Cantidad: 0
    }
    for (i = 0; i < obj2.length; i++) {

        obj3 = {
            IdProducto: obj2[i][1],
            Cantidad: $('#' + obj2[i][1].toString()).val()
        }
        productsArray.push(obj3);
        obj3 = {

            IdProducto: '',
            Cantidad: 0
        }

        // console.log(productsArray);
    }





    $.post('ProcesarMovimiento', { vm: obj, dma: productsArray, fechaLimite: limite, montoInicial: inicial }, function () {
        swal({
            title: "Guardado",
            text: "Procesado con exito",
            icon: "success",

        });

        location.href = "Index";
    });

}


function GetElementsFromPedidoId() {
    var idPedido = $('#idPedido').val();
    var dt = $('#tblistProdMovimiento').DataTable();
    dt.clear().draw();
    $.get('GetDesgloseByPedidoId', { pedidoId: idPedido }, function (data) {

        $('#ddSuplidor').val(data.MovimientoAlmacen.IdSuplidor);
        for (x = 0; x < data.ProductosFromPedidos.length; x++) {
            dt.row.add([
                data.ProductosFromPedidos[x].Eliminar.toString(),
                data.ProductosFromPedidos[x].IdProducto.toString(),
                data.ProductosFromPedidos[x].CodProducto.toString(),
                data.ProductosFromPedidos[x].Producto.toString(),
                data.ProductosFromPedidos[x].Envase.toString(),
                data.ProductosFromPedidos[x].Existencia.toString(),
                data.ProductosFromPedidos[x].Precio.toString(),
                data.ProductosFromPedidos[x].Cantidad.toString(),
                data.ProductosFromPedidos[x].Subtotal.toString()
               
            ]).draw(false);
            var qtyInputId = $('#' + data.ProductosFromPedidos[x].IdProducto.toString()).val();
            var price = data.ProductosFromPedidos[x].Precio;
            var subTotalId = data.ProductosFromPedidos[x].IdProducto.toString();
            CalcularSubTotal(qtyInputId, price, subTotalId);
        }

        CalcularTotal();

    })
}

