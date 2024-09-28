$(document).ready(function() {

    $('#ddRegion').change(function () {
       
        $('#ddProvincia').empty();
        $.get('GetProvinciasByRegionId',
            { regionId: $('#ddRegion').val() },
            function (data) {
                $('#ddProvincia').append('<option selected disabled>Seleccione Provincia</option>');
                $.each(data,
                    function(i, data) {
                        $('#ddProvincia').append('<option value=' + data.Id + '>' + data.Nombre + '</option>');
                    });


            });
    });

    $('#ddProvincia').change(function () {
        $('#ddMunicipio').empty();
        $.get('GetMunicipiosByProvinciaId',
            { provinciaId: $('#ddProvincia').val() },
            function(data) {
                $.each(data,
                    function(i, data) {
                        $('#ddMunicipio').append('<option value=' + data.Id + '>' + data.Nombre + '</option>');
                    });


            });
    });


});