$(document).ready(function () {
	setCheckBoxProperties();

	$(document.getElementById("MarcaId")).change(function () {
		getVersiones(this);
	});
	
});

function getVersiones(marcaDdl) {
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

function enableDisableLoteCount(isLote) {
	var cantidadLote = document.getElementById("CantidadLote");
	cantidadLote.readOnly = !isLote;
	cantidadLote.value = "0";
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

	//$('#HabilitaVenta').css("position: absolute; opacity: 0;");

	//$('#HabilitaVenta').iCheck({
	//	checkboxClass: 'icheckbox_minimal-blue'

	//});

	//$('#HabilitaVenta').on("ifChanged", function () {
	//	enableDisableLoteCount($(this).is(":checked")

	//	);
	//});

	//$('#AdmiteDescuento').css("position: absolute; opacity: 0;");

	//$('#AdmiteDescuento').iCheck({
	//	checkboxClass: 'icheckbox_minimal-blue'

	//});

	//$('#AdmiteDescuento').on("ifChanged", function () {
	//	enableDisableLoteCount($(this).is(":checked"));
	//});

}

