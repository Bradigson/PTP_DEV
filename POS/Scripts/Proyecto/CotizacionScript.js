$(document).ready(function () {
    var numFactura = `${"LN-"}` + Math.random().toString(36).substring(7).toUpperCase();
    $('#numFactura').val(numFactura);
    $('#tbListProd').DataTable();

    $('#btnProductosModal').click(function () {
        $.ajax({
            url: "/Facturacion/ListaProductos",
            type: "GET",
            dataType: 'html',
            success: function (data) {
                $('#mbodyProd').html(data);
                $('#modal-Productos').modal();

            },
            error: function () {
                alert("hay un fallo.");
            }
        });

    });


    $('#btnModalClientes').click(function () {
        $.ajax({
            url: "/Facturacion/ListaClientes",
            type: "GET",
            dataType: 'html',
            success: function (data) {
                $('#mbody').html(data);
                $('#modal-clientes').modal();

            },
            error: function () {
                swal({
                    title: "Error",
                    text: "Error Cargando La Lista de Clientes",
                    icon: "warning",
                    button: "Aceptar",
                });
            }
        });

    });
});


function addProduct(id) {

    $.get('/Facturacion/AddSingleProduct',
        { idProducto: id },
        function (data) {
            var dt = $('#tbListProd').DataTable();
            dt.row.add([
             
                data.Id,
                data.CodProducto.toString(),
                data.Producto.toString(),
                data.Precio.toString(),
                data.Cantidad,
                data.ITBIS.toString(),
                data.Descuento,
                data.Subtotal.toString(),
                data.Checkbox.toString()
              
            ]).draw(false);


        });
}


$('#codBarra').unbind("keypress").on("keypress", function (e) {
    if (e.which == 13) {
        var cbarra = $(this).val();

        $.get('/Facturacion/GetSingleProductByCB',
            { cb: cbarra },
            function (data) {
                var dt = $('#tbListProd').DataTable();

                dt.row.add([
                   
                    data.Id,
                    data.CodProducto.toString(),
                    data.Producto.toString(),
                    data.Precio.toString(),
                    data.Cantidad,
                    data.ITBIS.toString(),
                    data.Descuento,
                    data.Subtotal.toString(),
                    data.Checkbox.toString()
                   
                ]).draw(false);

            });

    }
});

function CallProduct(id) {
    var precioBase = 0;

    $.ajax({
        url: '/Facturacion/AddSingleProduct',
        data: { idProducto:id},
        async: false,
        success: function(data) {
            precioBase = data.Precio;
            return precioBase;
        }
    });
    return precioBase;
}

$('#tbListProd tbody').on('change', 'input', function () {
 
    var self = $(this);
    var cantidad = $(this).val();
    var id = self.attr('id');
    if (id.includes("d")) {
        id = id.substr(1);
        var precioBase = 0;
        var desc = $(this).val();
        cantidad = $('#' + id.toString()).val();
        
       precioBase= CallProduct(id);
        if (precioBase < desc) {
            swal({
                title: "Advertencia",
                text: "El descuento no puede ser superior al precio del producto",
                icon: "warning",
                button: "Aceptar",
                timer:2500
            });
            return;
        }

        CalcularSubTotalDesc(cantidad, precioBase, id, desc);
        CalcularTotal();
        return;
    }

    $.get('/Facturacion/AddSingleProduct',
        { idProducto: parseInt(id) },
        function (data) {
            
            var subtotal = parseFloat(cantidad * data.Precio).toFixed(2);
            var idSubt = "#t" + data.Id;
            var idItbis = "#i" + data.Id;
            idSubt.toString();
            idItbis.toString();
            $(idSubt).val('');
            $(idItbis).val('');
            $('#totalGral').val(0);
            $(idSubt).val(subtotal.toString());
            $(idItbis).val(parseFloat(subtotal * 0.18).toFixed(2).toString());
            CalcularTotal();

        });

});



$('#tbListProd tbody').unbind("click").on('click', 'button', function () {
    var table = $('#tbListProd').DataTable();
    swal({
        title: "Eliminar Producto",
        text: "Esta seguro(a) de eliminar este producto?",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                table
                    .row($(this).parents('tr'))
                    .remove()
                    .draw();
                swal("El producto fué eliminado!", {
                    icon: "success",
                });
                CalcularTotal();
            } else {
                swal("Canceló la eliminacion.!");
            }
        });


    CalcularTotal();


});

$('#idTipoPago').change(function () {
    if ($(this).val() == 1) {
        $('#FechaLimite').removeAttr('readonly');
    } else {
        $('#FechaLimite').attr('readonly');
        return;
    }

});


function CalcularDevueltas() {
    var montoPagado = parseFloat($('#montoPagado').val()).toFixed(2);
    var total = parseFloat($('#total').val()).toFixed(2);
    if ($('#tipoTransaccionId').val() == 1) {
        var dev = (montoPagado - total);
        $('#devuelta').val(dev);

    } else {
        return;
    }

}

function ValidacionMontos() {
    var isCorrect = false;
    var montoPagado = parseInt($('#montoPagado').val());
    var total = parseInt($('#total').val());
    if ($('#idTipoPago').val() == 2) {
        if (montoPagado < total) {

            swal({
                title: "Advertencia",
                text: "El Monto del pago no puede ser inferior al total",
                icon: "warning",
                button: "Aceptar",
                timer: 3000
            });
            isCorrect = false;
            return isCorrect;
        } else {
            isCorrect = true;
            return isCorrect;
        }
    }
    return isCorrect;
}

function CalcularSubTotal(cantidad, precio, idsubt) {

    var subtotal = cantidad * precio;
    var idSubt = "#t" + idsubt;

    idSubt.toString();
    $(idSubt).val('');
    $('#totalGral').val(0);
    $(idSubt).val(subtotal.toString());
}

function CalcularSubTotalDesc(cantidad, precio, idsubt,descUnidad) {

    var subtotal = cantidad * (precio - descUnidad);
    var idSubt = "#t" + idsubt;

    idSubt.toString();
    $(idSubt).val('');
    $('#totalGral').val(0);
    $(idSubt).val(subtotal.toString());
}


function SelectCliente(id) {
    $.get('/Facturacion/GetClienteById',
        { id: id },
        function (data) {
            if (data !== null) {

                $('#nCliente').val(data.Nombre);
                $('#idCliente').val(data.Id);
                $('#modal-clientes').modal('hide');
            } else {
                swal({
                    title: "Error",
                    text: "Error Cargando el Cliente",
                    icon: "warning",
                    button: "Aceptar",
                });
            }
        });
}

function CalcularTotal() {
    var table = $('#tbListProd').DataTable().rows().data();

    var s = 0;
    var i = 0;
    var d = 0;
    for (x = 0; x < table.length; x++) {
        var valuen = parseFloat($('#t' + table[x][0]).val());
        var itbis = parseFloat($('#i' + table[x][0]).val());
        var desc = parseFloat($('#d' + table[x][0]).val());
       i += itbis;

        s += valuen;
        d += desc;
    }
    totGral = s;
    $('#total').val(totGral.toString());
    $('#totalItbis').val(i.toString());
    $('#descTotal').val(d.toString());
}


function Cotizar() {
    var productsArray = [];
    var cantidadProd = 0;

    var montoPagado = parseFloat($('#montoPagado').val()).toFixed(2);
    var limite = $('#FechaLimite').val();
    var inicial = $('#MontoInicial').val();

    var obj2 = $('#tbListProd').DataTable().rows().data();
    var DetalleCotizacion = {

        ProductoId: '',
        Cantidad: 0,
        Precio: 0,
        Itbis: 0,
        SubTotal: 0,
        Descuento: 0
    }
    for (i = 0; i < obj2.length; i++) {

        DetalleCotizacion = {
            //IdProducto: obj2[i][0],
            //Cantidad: $('#' + obj2[i][0].toString()).val()    
            ProductoId: obj2[i][0],
            Cantidad: $('#' + obj2[i][0].toString()).val(),
            Precio: obj2[i][3],
            Itbis: parseFloat($('#i' + obj2[i][0].toString()).val()).toFixed(2),
            SubTotal: parseFloat($('#t' + obj2[i][0].toString()).val()).toFixed(2),
            Descuento: parseFloat($('#d' + obj2[i][0].toString()).val()).toFixed(2)
        }
        cantidadProd += parseInt($('#' + obj2[i][0].toString()).val());
        productsArray.push(DetalleCotizacion);
        DetalleCotizacion = {

            IdProducto: '',
            Cantidad: 0
        }


    }

    var Cotizacion =
    {
        NoFactura: $('#numFactura').val(),
        Ncf: $('#ncf').val(),
        SecuenciaId: $('#tipoNcf').val(),
        ClienteId: $('#idCliente').val(),
        TipoPagoId: $('#idTipoPago').val(),
        TipoTransaccionId: $('#tipoTransaccionId').val(),
        MontoTotal: $('#total').val(),
        TotalDescuento: $('#descTotal').val(),
        TotalItbis: $('#totalItbis').val(),
        CantidadProductos: cantidadProd
    };

    var ViewModel = {
        Cotizacion: Cotizacion,
        DetalleCotizacion: productsArray
       
    }

    $.ajax({
        url: 'Cotizar',
        type: 'POST',
        dataType:'json',
        data: ViewModel,
        success: function (data) {
            if (data === 1) {
                swal({
                    title: "Completado",
                    text: "Su Cotizacion ha sido completada",
                    icon: "success",
                    button: "Aceptar",
                    timer: 2500
                });
                
                setTimeout(function() {
                        location.href = "Index";
                    },
                    3000);
                return;
            }
            swal({
                title: "Error",
                text: "Su Cotizacion no ha sido completada",
                icon: "error",
                button: "Aceptar",
                timer: 2500
            });
            return;
        }
    });
}


