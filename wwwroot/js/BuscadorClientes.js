
    $(document).ready(function() {
        $("#FrmBuscar").submit(function (e) {
            e.preventDefault();

            var NombreBuscarLleno = ValidarNombreBuscar();


            if (NombreBuscarLleno == true) {
                
                event.target.submit();
                $("#validacionNombreBuscar").hide();
            } else {

                $("#validacionNombreBuscar").show();

            }

            var ApellidoBuscarLleno = ValidarApellidoBuscar();


            if (ApellidoBuscarLleno == true) {
                
                event.target.submit();
                $("#validacionApellidoBuscar").hide();
            } else {

                $("#validacionApellidoBuscar").show();

            }

            var IdentificacionBuscarLleno = ValidarIdentificacionBuscar();


            if (IdentificacionBuscarLleno == true) {
                
                event.target.submit();
                $("#validacionIdentificacionBuscar").hide();
            } else {

                $("#validacionIdentificacionBuscar").show();

            }

        });
    function ValidarNombreBuscar() {

            var nombres = $("#validationNombreBuscar").val();
    if (nombres == "") {

                return false;
            } else {
        
                return true;
            }
        }

    function ValidarApellidoBuscar() {

            var apellidos = $("#validationApellido").val();
    if (apellidos == "") {

                return false;
            } else {
                return true;
            }
        }

    function ValidarIdentificacionBuscar() {

        var identificacion = $("#validationIdentificacionBuscar").val();
        if (identificacion.length => 10) {

                return false;
            } else {
                return true;
            }
        }
    });