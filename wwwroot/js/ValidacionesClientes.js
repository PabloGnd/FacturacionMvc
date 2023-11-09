$(document).ready(function () {
    $("#validacionNombre").hide();
    $("#validacionApellido").hide();
    $("#validacionIdentificacion").hide();
    $("#validacionCorreo").hide();
    $("#validacionTelefono").hide();
   /* Validaciones de Modal Nuevo Cliente*/
    $("#FrmNuevo").submit(function (e) {
        e.preventDefault();

        var NombreLleno = ValidarNombre();
        if (NombreLleno == true) {
            $("#validacionNombre").hide();
        } else {    
            $("#validacionNombre").show();   
        }

        var ApellidoLLeno = ValidarApellido();
        if (ApellidoLLeno == true) {
            $("#validacionApellido").hide();
        } else {
            $("#validacionApellido").show();
        }

        var DiezDigitos = ValidarIdentificacion();
        if (DiezDigitos == true) {
            $("#validacionIdentificacion").hide();
        } else {
            $("#validacionIdentificacion").show();
        }

        var CorreoLleno = ValidarCorreo();
        if (CorreoLleno == true) {
            $("#validacionCorreo").hide();
        } else {
            $("#validacionCorreo").show();
        }

        var TelefonoLLeno = ValidarTelefono();
        if (TelefonoLLeno == true) {
            $("#validacionTelefono").hide();
        } else {
            $("#validacionTelefono").show();
        }

        if (NombreLleno == true && DiezDigitos == true && CorreoLleno == true && ApellidoLLeno == true && TelefonoLLeno == true) {
           
            event.target.submit();
        }

    });

    function ValidarApellido() {
        var Apellido = $("#validationApellido").val();
        if (Apellido == "") {
            return false;
        } else {
            return true;
        }
    }
    function ValidarNombre() {
        
        var nombres = $("#validationNombre").val();
        if (nombres == "") {
            
            return false;
        } else {
            return true;
        }
    }

    function ValidarIdentificacion() {

        var Identificacion = $("#validationIdentificacion").val();
        if (Identificacion.length == 10) {
            
            return true;
        } else {
            return false;
        }
    }

    function ValidarCorreo() {
        
        let valCorreo = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/
        var Correo = $("#validationCorreo").val();
        if (valCorreo.test(Correo)) {
            return true;
        } else {
            return false;
        }
    }

    function ValidarTelefono() {
        var validate = true;

        var ValidarTelefono = document.getElementById("Telefono").value;
        if (isNaN(ValidarTelefono) == true) {

            validate = false;
        } else {

            validate = true;
        }
        return validate;
    }
    
////    $("#ValidarNombreBuscar").hide();
////    $("#ValidarApellidoBuscar").hide();
////    $("#ValidarIdentificacionBuscar").hide();
/////*Validaciones modal buscar*/

////    $("#FrmBuscar").submit(function (e) {
////        e.preventDefault();

////        var NombreBuscarLleno = ValidarNombreBuscar();


////        if (NombreBuscarLleno == true) {
            
////            event.target.submit();
////            $("#validacionNombreBuscar").hide();
////        } else {
            
////            $("#validacionNombreBuscar").show();

////        }

////        var ApellidoBuscarLleno = ValidarApellidoBuscar();


////        if (ApellidoBuscarLleno == true) {
            
////            event.target.submit();
////            $("#validacionApellidoBuscar").hide();
////        } else {
           
////            $("#validacionApellidoBuscar").show();

////        }

////        var IdentificacionBuscarLleno = ValidarIdentificacionBuscar();


////        if (IdentificacionBuscarLleno == true) {
            
////            event.target.submit();
////            $("#validacionIdentificacionBuscar").hide();
////        } else {
            
////            $("#validacionIdentificacionBuscar").show();

////        }

        

////    });
////    function ValidarNombreBuscar() {

////        var nombres = $("#validationNombreBuscar").val();
////        if (nombres == "") {

////            return false;
////        } else {
////            alert("campolleno")
////            return true;
////        }
////    }

////    function ValidarApellidoBuscar() {

////        var apellidos = $("#validationApellido").val();
////        if (apellidos == "") {

////            return false;
////        } else {
////            return true;
////        }
////    }

////    function ValidarIdentificacionBuscar() {

////        var apellidos = $("#validationApellidoBuscar").val();
////        if (apellidos == "") {

////            return false;
////        } else {
////            return true;
////        }
////    }

    
});