
(function ($) {
    "use strict";

var bandera;

//var login = location.origin + "/index.html"
//if( location.href != login ){
//    if(localStorage.getItem("user") == undefined || localStorage.getItem("user") == ''){
//        let url = "index.html";
//        $(location).attr('href',url);
//    }
//}
    /*==================================================================
    [ Focus input ]*/
    $('.input100').each(function(){
        $(this).on('blur', function(){
            if($(this).val().trim() != "") {
                $(this).addClass('has-val');
            }
            else {
                $(this).removeClass('has-val');
            }
        })    
    })
  
  
    /*==================================================================
    [ Validate ]*/
    var input = $('.validate-input .input100');

    //$('.validate-form').on('submit',function(){
        
    //});

    

    $('.validate-form .input100').each(function(){
        $(this).focus(function(){
           hideValidate(this);
        });
    });

    function validate (input) {
        if($(input).attr('type') == 'email' || $(input).attr('name') == 'email') {
            if($(input).val().trim().match(/^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{1,5}|[0-9]{1,3})(\]?)$/) == null) {
                bandera = 1;
                return false;
            }
        }
        else {
            if($(input).val().trim() == ''){
                bandera = 2;
                return false;
            }
        }
    }

    function showValidate(input) {
        if(bandera == 1){
            $("#Error").html("Email no tiene formato valido");
        }else{
            $("#Error").html("Favor ingrese usuario/contraseña");
        }
        
    }

    function hideValidate(input) {
        $("#Error").html("");
    }
    
    /*==================================================================
    [ Show pass ]*/
    var showPass = 0;
    $('.btn-show-pass').on('click', function(){
        if(showPass == 0) {
            $(this).next('input').attr('type','text');
            $(this).find('i').removeClass('zmdi-eye');
            $(this).find('i').addClass('zmdi-eye-off');
            showPass = 1;
        }
        else {
            $(this).next('input').attr('type','password');
            $(this).find('i').addClass('zmdi-eye');
            $(this).find('i').removeClass('zmdi-eye-off');
            showPass = 0;
        }
        
    });

    var estado = document.getElementById('<%= Usuario.ClientID %>').value;
    localStorage.setItem("User", estado);
})(jQuery);