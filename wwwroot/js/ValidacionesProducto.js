$(document).ready(function () {
    $("#validacionNemonico").hide();
    $("#validacionDescripcion").hide();
    $("#validacionPrecioUnitario").hide();
    $("#validacionPorcentajeDescuento").hide();
    /* Validaciones de Modal Nuevo Producto*/
    $("#frmValidacionProducto").submit(function (e) {
        e.preventDefault();

        var DescripcionLLeno = ValidarDescripcion();
        if (DescripcionLLeno == true) {
            $("#validacionDescripcion").hide();
            
        } else {
            $("#validacionDescripcion").show();
        }

        var PrecioUnitarioLleno = ValidarPrecioUnitario();
        if (PrecioUnitarioLleno == true) {
            $("#validacionPrecioUnitario").hide();
        } else {
            $("#validacionPrecioUnitario").show();
        }

      
       
        if (DescripcionLLeno == true && PrecioUnitarioLleno == true ) {

            event.target.submit();
        }
      
        
    });

    
    function ValidarDescripcion() {

        var Descripcion = $("#validationDescripcion").val();
        if (Descripcion == "") {

            return false;
        } else {
            return true;
        }
    }

    function ValidarPrecioUnitario() {
        var validate = true;

        var PrecioUnitario = document.getElementById("PrecioUnitario").value;
        if (isNaN(PrecioUnitario) == true) {

            validate = false;
        } else {

            validate = true;
        }
        return validate;
    }

    

    
});