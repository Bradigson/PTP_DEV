
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


function showProductsModel() {
	$.ajax({
		type: 'GET',
		url: '/Productos/GetProductoSelector',
		success: function (result) {

			$("#productosModalBody").html(result);
			$("#modal-Productos").modal("show");
		}

	});

};

function Producto(name, envase, codigo, stock) {
	this.nombre = nombre;
	this.envase = envase;
	this.codigo = codigo;
	this.stock = stock;
}

function GetPedidosItems(dataTable) {
	var productsIdList = [];

	var data = dataTable.rows().data();
	for (var i = 0; i < data.length; i++) {
	    productsIdList.push(data[i].Id);
	}
	return productsIdList;
}

function SavePedido(dataTable) {
	var idSuplidor = document.getElementById("PriceBase").value;

	if (idSuplidor <= 0) {
		alert("Ingrese Precios");
		return;
	}

	var detalleList = GetPedidosItems(dataTable);
	if (detalleList.length <= 0) {
		alert("Agregue productos a la lista");
		return;
	}

	var dataObject = {
		"PriceBase": idSuplidor,
		"ProductsIdList": detalleList
	}

	$.ajax({
		type: 'POST',
		url: '/Precios/SetAllPrecios/',
		data: dataObject,
		success: function () {
			window.location = "/Precios";
		}

	});
}