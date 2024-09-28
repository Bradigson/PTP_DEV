$(document).ready(function () {

    $('#Cod_Pais').change(function () {

        $('#Cod_Region').empty();
        $('#Cod_Provincia').empty();
        $('#IdMunicipio').empty();
        $.get('/Location/GetRegionByPaisId',
            { Id: $('#Cod_Pais').val() },
            function (data) {
                $('#Cod_Region').append('<option selected disabled>SELECCIONAR REGION</option>');
                $.each(data,
                    function (i, data) {
                        $('#Cod_Region').append('<option value=' + data.CODIGO_REG + '>' + data.NOMBRE_REG + '</option>');
                    });


            });
    });

    $('#Cod_Region').change(function () {

        $('#Cod_Provincia').empty();
        $('#IdMunicipio').empty();
        $.get('/Location/GetProvinciasByRegionId',
            { Id: $('#Cod_Region').val() },
            function (data) {
                $('#Cod_Provincia').append('<option selected disabled>SELECCIONAR PROVINCIA</option>');
                $.each(data,
                    function (i, data) {
                        $('#Cod_Provincia').append('<option value=' + data.CODIGO_PROV + '>' + data.NOMBRE_PROV + '</option>');
                    });


            });
    });

    $('#Cod_Provincia').change(function () {
        $('#IdMunicipio').empty();
        $.get('/Location/GetMunicipiosByProvinciaId',
            { Id: $('#Cod_Provincia').val() },
            function (data) {
                $('#IdMunicipio').append('<option selected disabled>SELECCIONAR MUNICIPIO</option>');
                $.each(data,
                    function (i, data) {
                        $('#IdMunicipio').append('<option value=' + data.CODIGO_MUNIC + '>' + data.NOMBRE_MUNIC + '</option>');
                    });


            });
    });

    


});