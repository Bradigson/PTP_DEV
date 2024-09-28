$(document).ready(function () {
    var table = $("#productosTbl").DataTable({
        "columnDefs": [
            {
                "targets": [0],
                "visible": false,
                "searchable": false
            }
        ],
        columns: [
            { data: "Id" },
            { data: "Nombre" },
            { data: "Cantidad" },
            { data: "Boton" }
        ]
    });

    $("#btnBuscarProductos").click(function () {
        showProductsModel();
    });


    $('#productosTbl tbody').on('click', 'button.btnBorrarShit', function () {
        table
            .row($(this).parents('tr'))
            .remove()
            .draw(false);
    });

    $("#buttonSave").click(function () {
        SavePedido(table);
    });
});

function SavePedido(dataTable) {
    var idSuplidor = document.getElementById("IdSuplidor").value;
    
    if (idSuplidor <= 0) {
        alert("Seleccione Suplidor");
        return;
    }

	var detalleList = GetPedidosItems(dataTable);
    if (detalleList.length <= 0) {
        alert("Agregue prductos a la lista");
        return;
    }

	var pedido = {
		"Id": document.getElementById("Id").value,
        "IdSuplidor": idSuplidor,
		"Detalle": detalleList,
		"Solicitado": document.getElementById("Solicitado").value
    }
	
    $.ajax({
        type: 'POST',
        url: '/Pedidos/Edit/',
        data: pedido,
        success: function (result) {
            window.location = "/Pedidos";
        }

    });
}

function GetPedidosItems(dataTable) {
    var pedidos = [];

    var data = dataTable.rows().data();
    for (var i = 0; i < data.length; i++) {
        var item = {
            "IdProducto": data[i].Id,
            "Cantidad": data[i].Cantidad
        }
        pedidos.push(item);
    }
    return pedidos;
}

function Producto(name, envase, codigo, stock) {
    this.nombre = nombre;
    this.envase = envase;
    this.codigo = codigo;
    this.stock = stock;
}

function showProductsModel() {
	$.ajax({
        type: 'GET',
        url: '/Productos/GetProductosBySuplidor',
        success: function (result) {

            $("#productosModalBody").html(result);
            $("#modal-Productos").modal("show");
        }

    });

};