$(document).ready(function(){
            $('#pagoCompleto').click(function(){
                CheckFullPayment();

             });

            $('#btnAbono').click(function(){
                PostAbonoOrFullPay();
            });

        });


function CheckFullPayment(){
var isChecked = document.getElementById('pagoCompleto').checked;
               if(isChecked){
var montoDeuda=$('#montoDeuda').val();
                    $('#montoAbono').val(montoDeuda);
                    $('#montoAbono').attr('readonly','readonly');

        }
    else{
      $('#montoAbono').val('');
                    $('#montoAbono').removeAttr('readonly');
    }

}


function PostAbonoOrFullPay(){
    var monto = $('#montoAbono').val();   
    var id = $('#idCta').val();
   
    $.post('HacerPagosaCuenta', { Monto: monto, idCta: id}, function(){ });

    swal({
        title: "Completado",
        text: "Pago aplicado correctamente",
        icon: "success",
        timer: 3500
    });
    location.reload();
}