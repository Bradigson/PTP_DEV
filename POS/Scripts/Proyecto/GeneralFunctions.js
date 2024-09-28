function isNumber(evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57) && (charCode > 96 || charCode < 105)) {
        return false;
    }
    return true;
}

function isLetter(evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
	if (!(charCode >= 65 && charCode <= 120) && (charCode != 32 && charCode != 0)) {
        return false;
    }
    return true;
}