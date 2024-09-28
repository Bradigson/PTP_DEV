
$(document).ready(function() {
	$(".btnAgregar").click(function () {
	    var clickedBtn = $(this);
	    var btnId = clickedBtn.attr('id').replace("btnAgregar", "");

	    var cantidad = $("#cantidadInput" + btnId).val();
	    if (cantidad <= 0) {
	        alert("Cantidad Invalida");
	        return;
	    }

	    var table = $("#productosTbl").DataTable();
	    if ($("#tablaProductosPedido tr").find("#borrarFila" + btnId).length > 0) {
	        alert("Producto En Lista");
	        return;
	    }

	    var trId = "infoTr" + btnId;
	    var row = $("#" + trId + " td");


	    table.row.add({
	        "Id": btnId,
	        "Nombre": row[0].innerHTML,
	        "Cantidad": cantidad,
	        "Boton": GetButtonHtml(btnId)
	    }).draw(false);


	    $("#modal-Productos").modal('hide');
	});
});


function GetButtonHtml(id) {
    return '<button type="button" class="btn btn-danger btn-xs select-row btnBorrarShit" id=borrarFila' + id + '><span class="glyphicon glyphicon-trash"></span></button>';
}