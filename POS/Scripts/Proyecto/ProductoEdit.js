$(document).ready(function () {
    setCheckBoxProperties();

	//$(document.getElementById("submitButton")).click(function (e) {
	//	e.preventDefault();
 //       editProduct();
	//});

	$(document.getElementById("btnDelete")).click(function (e) {
        e.preventDefault();
        editProduct();
    });

    $(document.getElementById("MarcaId")).change(function () {
        GetVersiones(this);
    });

    //$(document.getElementById("EsLote")).change(function () {
    //    EnableDisableLoteCount($(this).is(":checked"));
    //});

    $(document.getElementById("Codigo")).focusout(function () {

        CheckExistingCode($(this).val());
		
	});


});

function editProduct() {
	$.ajax({
		type: 'POST',
		url: '/Productos/Edit',
		data: { 'producto': generateProducto() },
		success: function (result) {
			window.location = "/Productos";
		}

	});
}

function deleteProduct() {
    var producto = {
        Id: document.getElementById("Id").value,
	};

	$.ajax({
		type: 'POST',
		url: '/Productos/Delete',
		data: { 'producto': producto },
		success: function (result) {
			window.location = "/Productos";
		}

	});
}

function generateProducto() {
	var producto = {
		Codigo: document.getElementById("Codigo").value,
		IdVersion: $(document.getElementById("VersionId")).val(),
		IdEnvase: $(document.getElementById("EnvaseId")).val(),
		Descripcion: document.getElementById("Descripcion").value,
		Activo: document.getElementById("Activo").checked,
		EsLote: document.getElementById("EsLote").checked,
		CantidadLote: document.getElementById("CantidadLote").value,
		SuplidorId: $(document.getElementById("SuplidorId")).val(),
		Id: document.getElementById("Id").value,
		PrecioBase: document.getElementById("PrecioBase").value,
		CantidadMinima: document.getElementById("CantidadMinima").value
	};

    return producto;
}

function GetVersiones(marcaDdl) {
    const versionesDdl = document.getElementById("VersionId");
    versionesDdl.readOnly = true;
    $.ajax({
        type: 'POST',
        url: '/Version/GetVersionesByMarca',
        data: { 'id': $(marcaDdl).val() },
        success: function (result) {
            const versionesCb = document.getElementById("VersionId");
            $(versionesCb).empty();
            $(versionesCb).append('<option value="">' + 'Versiones' + '</option>');
            $.each(result,
                function (index, item) {
                    $(versionesCb).append('<option value =' + item.ID + '>' + item.Text + '</option>');
                });
        }

    });
    versionesDdl.readOnly = false;
}

function EnableDisableLoteCount(isLote) {
	var cantidadLote = document.getElementById("CantidadLote");
    cantidadLote.readOnly = !isLote;
    cantidadLote.value = "";
}

function CheckExistingCode(productCode) {
    const errorLabel = document.getElementById("existingCodeLabel");

    $.ajax({
        type: 'POST',
        url: '/Productos/CheckCodeExist',
        data: { 'code': productCode },
        success: function (result) {
            if (result) {
                errorLabel.removeAttribute("hidden");
            } else {
                errorLabel.setAttribute("hidden", true);
            }
        }

    });


}

function aplicaImpuesto(valor) {

    if (valor == 'S') {
        $('#ValorImpuesto').removeAttr('disabled');
        $('#ValorImpuesto').val(0);
        $('#ValorImpuesto').focus();
    } else if (valor == 'N') {
        $('#ValorImpuesto').attr('disabled', 'disabled');
        $('#ValorImpuesto').val(0);
    }

}

function setCheckBoxProperties() {
    $('.select2').select2();

    $('#EsLote').css("position: absolute; opacity: 0;");

    $('#EsLote').iCheck({
        checkboxClass: 'icheckbox_minimal-blue'

    });

    $('#EsLote').on("ifChanged", function () {
        enableDisableLoteCount($(this).is(":checked"));
    });
}