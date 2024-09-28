$(document).ready(function () {

 

    var numFactura = `${"LN-"}` + Math.random().toString(36).substring(7).toUpperCase();
    $('#numFactura').val(numFactura);
    $('#tbListProd').DataTable();

    $('#btnProductosModal').click(function () {
        $.ajax({
            url: "ListaProductos",
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
            url: "ListaClientes",
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

    $.get('AddSingleProduct',
        { idProducto: id },
        function (data) {
           
            var dt = $('#tbListProd').DataTable();
            var validarExistencia = false;
            if (dt.data().count() != 0) {

                dt.data().each(function (value, index) {
                    var valor = value[1];
                    if (valor == data.Id) {
                        validarExistencia = true;
                    }
                });



                if (validarExistencia) {
                    var valorCantidadNuevo = (parseFloat($("#" + data.Id).val()) + 1);
                    $("#" + data.Id).val(valorCantidadNuevo);

                } else {
                    dt.row.add([
                        data.Checkbox.toString(),
                        data.Id,
                        data.CodProducto.toString(),
                        data.Cantidad,
                        data.Producto.toString(),
                        data.Descuento,
                        data.Precio.toString(),
                        data.ITBIS.toString(),
                        data.Subtotal.toString()
                    ]).draw(false);
                }
            } else {
                dt.row.add([
                    data.Checkbox.toString(),
                    data.Id,
                    data.CodProducto.toString(),
                    data.Cantidad,
                    data.Producto.toString(),
                    data.Descuento,
                    data.Precio.toString(),
                    data.ITBIS.toString(),
                    data.Subtotal.toString()
                ]).draw(false);

            }
            $('#' + data.Id).trigger('change');

        });
}


$('#codBarra').unbind("keypress").on("keypress", function (e) {
    if (e.which == 13) {
        var cbarra = $(this).val();

        $.get('GetSingleProductByCB',
            { cb: cbarra },
            function (data) {
                
                if (data == 0) {
                    swal({
                        title: "Advertencia",
                        text: cbarra+" : Producto no encontrado",
                        icon: "warning",
                        button: "Aceptar",
                        timer: 3500
                    });
                    $('#codBarra').val("");
                    $('#codBarra').select();
                    return ;

                }
                var dt = $('#tbListProd').DataTable();               
                var validarExistencia = false;
                if (dt.data().count() != 0) {

                    dt.data().each(function (value, index) {
                        var valor = value[1];
                        if (valor == data.Id) {
                            validarExistencia = true;
                        }
                    });
                   
                  

                    if (validarExistencia) {
                        var valorCantidadNuevo = (parseFloat($("#" + data.Id).val()) + 1);
                        $("#" + data.Id).val(valorCantidadNuevo);

                    } else {
                        dt.row.add([
                            data.Checkbox.toString(),
                            data.Id,
                            data.CodProducto.toString(),
                            data.Cantidad,
                            data.Producto.toString(),
                            data.Descuento,
                            data.Precio.toString(),
                            data.ITBIS.toString(),
                            data.Subtotal.toString()
                        ]).draw(false);
                    }
                } else {
                    dt.row.add([
                        data.Checkbox.toString(),
                        data.Id,
                        data.CodProducto.toString(),
                        data.Cantidad,
                        data.Producto.toString(),
                        data.Descuento,
                        data.Precio.toString(),
                        data.ITBIS.toString(),
                        data.Subtotal.toString()
                    ]).draw(false);

                }
                $('#' + data.Id).trigger('change');
            });

    }
});

function CallProduct(id) {
    var precioBase = 0;

    $.ajax({
        url: 'AddSingleProduct',
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

    $.get('AddSingleProduct',
        { idProducto: parseInt(id) },
        function (data) {
        
            var subtotal = 0;
            var decuentoProducto = $("#d"+data.Id).val();
            //if (decuentoProducto != 0) {
            //    subtotal = parseFloat((cantidad * data.Precio) - (cantidad * decuentoProducto)).toFixed(2);
            //} else { }
                subtotal = parseFloat(cantidad * data.Precio).toFixed(2);

            
             
            var idSubt = "#t" + data.Id;
            var idItbis = "#i" + data.Id;
            var itbis = data.ValorImpu;
            idSubt.toString();
            idItbis.toString();
            $(idSubt).val('');
            $(idItbis).val('');
            $('#totalGral').val(0);
            $(idSubt).val(subtotal.toString());            
            $(idItbis).val(parseFloat(((subtotal * itbis)/100) ).toFixed(2).toString());
            CalcularTotal();
            $('#codBarra').val("");
            $('#codBarra').select();

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



    CalcularTotal()


});

$('#idTipoPago').change(function () {
    if ($(this).val() == 1) {
        $('#FechaLimite').removeAttr('readonly');
    } else {
        $('#FechaLimite').attr('readonly');
        return;
    }

});

$('#montoPagado').change(function () {
    if (ValidacionMontos()) {
        CalcularDevueltas();
    }
    $('#montoPagado').unbind('keypress').on('keypress',
        function (e) {
            if (e.wich == 13) {
                if (ValidacionMontos()) {
                    CalcularDevueltas();
                }
                
            } else {
                return;
            }
        });
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

function CalcularSubTotalDesc(cantidad, precio, idsubt, descUnidad) {
    debugger;
    var subtotal = cantidad * (precio - descUnidad);
    var idSubt = "#t" + idsubt;

    idSubt.toString();
    $(idSubt).val('');
    $('#totalGral').val(0);
    $(idSubt).val(subtotal.toString());
}


function SelectCliente(id) {
    $.get('GetClienteById',
        { id: id },
        function (data) {
            if (data != null) {

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
        var valuen = parseFloat($('#t' + table[x][1]).val());
        var itbis = parseFloat($('#i' + table[x][1]).val());
        var desc = parseFloat($('#d' + table[x][1]).val());
       i += itbis;

        s += valuen;
        d += desc;
    }
    totGral = s;
    $('#total').val(totGral.toString());
    document.getElementById("total2").innerHTML = totGral.toString();
    $("montoPagado").val("0.00");
    $('#ValorEfectivo').val(totGral.toString());
    $('#totalItbis').val(i.toString());
    $('#descTotal').val(d.toString());
}


function Facturar() {
    var productsArray = [];
    var cantidadProd = 0;

    var montoPagado = parseFloat($('#montoPagado').val()).toFixed(2);
    var limite = null;
    var inicial = 0;
   
    var obj2 = $('#tbListProd').DataTable().rows().data();
    var DetalleFacturacions = {

        ProductoId: '',
        Cantidad: 0,
        Precio: 0,
        Itbis: 0,
        SubTotal: 0,
        Descuento: 0
    }
    for (i = 0; i < obj2.length; i++) {

        DetalleFacturacions = {
            //IdProducto: obj2[i][0],
            //Cantidad: $('#' + obj2[i][0].toString()).val()    
            ProductoId: obj2[i][1],
            Cantidad: $('#' + obj2[i][1].toString()).val(),
            Precio: obj2[i][6],
            Itbis: parseFloat($('#i' + obj2[i][1].toString()).val()).toFixed(2),
            SubTotal: parseFloat($('#t' + obj2[i][1].toString()).val()).toFixed(2),
            Descuento: parseFloat($('#d' + obj2[i][1].toString()).val()).toFixed(2)
        }
        cantidadProd += parseInt($('#' + obj2[i][1].toString()).val());
        productsArray.push(DetalleFacturacions);
        DetalleFacturacions = {

            IdProducto: '',
            Cantidad: 0
        }


    }

   
    var Facturacion =
    {
        NoFactura: $('#numFactura').val(),
        Ncf: $('#ncf').val(),
        SecuenciaId: $('#tipoNcf').val(),
        ClienteId: $('#idCliente').val(),
        TipoPagoId: tipopagoDbCr,
        TipoTransaccionId: $('#tipoTransaccionId').val(),
        MontoTotal: $('#total').val(),
        TotalDescuento: $('#descTotal').val(),
        TotalItbis: $('#totalItbis').val(),
        CantidadProductos: cantidadProd,
        ValorEfectivo: $('#ValorEfectivo').val(),
        ValorTarjeta: $('#ValorTarjeta').val(),
        VTnoAuth: $('#VTnoAuth').val(),
        VT4digit: $('#VT4digit').val(),
        TipoTarjeta: TipoDeTarjeta ,
        EstaDespachada: FacturaDespachada,
        CantidadImpresion: 1,
        Devuelta:$('#devuelta').val()
    };

    var ViewModel = {
        Facturacion: Facturacion,
        DetalleFacturacions: productsArray,
        FechaLimite: limite,
        MontoInicial: montoPagado
    }
    
    $.ajax({
        url: 'Facturar',
        type: 'POST',        
        dataType:'json',
        data: ViewModel,
        success: function (data) {
            if (data == 1) {
                swal({
                    title: "Completado",
                    text: "Su Venta ha sido completada",
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
                text: "Su Venta no ha sido completada",
                icon: "error",
                button: "Aceptar",
                timer: 2500
            });
            return;
        }
    });
}


