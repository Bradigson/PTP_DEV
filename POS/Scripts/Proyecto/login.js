function validarusuario() {

    $.get('/Login/login',
        {
            Usuario: $('#Usuario').val(),
            PasswordUS: $('#PasswordUS').val()
        },
        function (data) {
            //Initialize Select2 Elements
            
            $('#imgLoginID').attr('hidden', 'hidden');
            $('#formIDLogin').attr('hidden', 'hidden');
            $('#formIDLogin2').removeAttr('hidden');
            $('#IdSucursal').append('<option selected disabled>Seleccionar sucursal</option>');
            $('#idCompanyImagen').attr('src', data.imagenCompany);
            $('#nombreLB').text('Hola ' + data.NombreUser);
            $('#idUserimg').attr('src', data.imagenUser);
            $('#Usuario2').val($('#Usuario').val());
            $('#PasswordUS2').val($('#PasswordUS').val());

            $.each(data.listaSuculsar,
                function (i, data) {


                    $('#IdSucursal').append('<option value=' + data.CODIGO_SUC + '>' + data.NOMBRE_SUC + '</option>');

                });
        });
}
