$(document).ready(function () {
    let formStepsNum = 0;
    const progress = document.getElementById("progress");
    const formSteps = document.querySelectorAll(".form-step");
    const progressSteps = document.querySelectorAll(".progress-step");
    const prevBtns = document.querySelectorAll(".btn-prev");
    $("#validacionRuc").hide();
    $("#validacion001").hide();
    $("#validacionEmail").hide();
    $("#validacionEstablecimiento").hide();
    $("#validacionSucursal").hide();

    $("#btn-next").click(function (e) {
        if (!validate_form()) {
            return false;
        } else if (!validate_Ruc()) {
            $("#validacionRuc").show();
            return false;
            
        } else if (!validate_001()) {
            $("#validacion001").show();
            return false;
        } else if (!validate_Email()) {
            $("#validacionEmail").show()
            return false;
            
        }
        else {
            $("#validacion001").hide();
            $("#validacionRuc").hide();
            $("#validacionEmail").hide();
            formStepsNum++;
            updateFormSteps();
            updateProgressbar();
        }
    });

    $("#btn-next1").click(function (e) {
        if (!validate_form()) {
            return false;
        } else if (!validate_ContribuyenteEspecial()) {
            $("#validacionEspecial").show()
            return false;
        }
        else {
            $("#validacionEspecial").hide();
        formStepsNum++;
        updateFormSteps();
        updateProgressbar();
        }
    });

    $("#btn-next2").click(function (e) {
        if (!validate_form()) {
            return false;
        } else if (!validateEstablecimiento()) {
            $("#validacionEstablecimiento").show()
            return false;
        }
        else if (!validateSucursal()) {
            $("#validacionSucursal").show()
            return false;
        }
        else {
            $("#validacionEstablecimiento").hide();
            $("#validacionSucursal").hide();
            formStepsNum++;
            updateFormSteps();
            updateProgressbar();
        }
    });

    $("#FrmRegistro").submit(function (e) {
        e.preventDefault();

        if (!validate_form()) {
            return false;
        }
        else if (!validarUsuario()) {
            $("#validacionNikname").show()
            return false;
        }
        else if (!validarCaracteres()) {
            $("#validacionCaracteres").show()
            return false;
        }
        else if (!validate_Contrasenia()) {
            $("#validacionContracenia").show()
            return false;
        } 
        else {
            $("#validacionNikname").hide();
            $("#validacionCaracteres").hide();
            event.target.submit();
        }
        prevBtns.forEach((btn) => {
            btn.addEventListener("click", () => {
                formStepsNum--;
                updateFormSteps();
                updateProgressbar();
            });
        });
        
    });
    prevBtns.forEach((btn) => {
        btn.addEventListener("click", () => {
            formStepsNum--;
            updateFormSteps();
            updateProgressbar();
        });
    });

    function updateFormSteps() {
        formSteps.forEach((formStep) => {
            formStep.classList.contains("form-step-active") &&
                formStep.classList.remove("form-step-active");
        });

        formSteps[formStepsNum].classList.add("form-step-active");
    }

    function updateProgressbar() {
        progressSteps.forEach((progressStep, idx) => {
            if (idx < formStepsNum + 1) {
                progressStep.classList.add("progress-step-active");
            } else {
                progressStep.classList.remove("progress-step-active");
            }
        });

        const progressActive = document.querySelectorAll(".progress-step-active");

        progress.style.width =
            ((progressActive.length - 1) / (progressSteps.length - 1)) * 100 + "%";
    }





    function validate_Ruc() {
        var validate = true;
        var valor = document.getElementById("ruc").value;
        if (valor.length == 13) {

            validate = true;
        } else {

            validate = false;
        }
        return validate;
    }

    function validate_001() {
        var number = document.getElementById('ruc').value;
        var dto = number.length;
        var valor;
        var acu = 0;
        var validate = true;
       
            for (var i = 0; i < dto; i++) {
                valor = number.substring(i, i + 1);
                if (valor == 0 || valor == 1 || valor == 2 || valor == 3 || valor == 4 || valor == 5 || valor == 6 || valor == 7 || valor == 8 || valor == 9) {
                    acu = acu + 1;
                }
            }
            if (acu == dto) {
                while (number.substring(10, 13) != 001) {
                    validate = false;
                    return;
                    
                }

               validate = true;
            }
        return validate;
           
    }

    function validate_form() {

        var validate = true;
        var inputs = document.querySelectorAll(".form-step.form-step-active input");
        inputs.forEach(function (inpt) {
            inpt.classList.remove('warning');
            if (inpt.hasAttribute("require")) {
                if (inpt.value.length == 0) {
                    validate = false;
                    inpt.classList.add('warning');
                }
            }

        });
        return validate;
    }

    function validate_Email() {
        var validate = true;
        let valCorreo = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/
        var valorEmail = document.getElementById("Email").value;
        if (valCorreo.test(valorEmail)) {

            validate = true;
        } else {

            validate = false;
        }
        return validate;
    }

    function validate_ContribuyenteEspecial() {
        var validate = true;

        var valorContribuyenteEspecial = document.getElementById("ContribuyenteEspecial").value;
        if (isNaN(valorContribuyenteEspecial) == true) {

            validate = false;
        } else {

            validate = true;
        }
        return validate;
    }

    function validate_Contrasenia() {
        var validate = true;

        var valorconfirmPassword = document.getElementById("confirmPassword").value;
        var valorpassword = document.getElementById("password").value;
        if (valorconfirmPassword == valorpassword) {

            validate = true;
        } else {

            validate = false;
        }
        return validate;
    }
    function validateEstablecimiento() {
        var validate = true;

        var valorEstablecimiento = document.getElementById("CodigoEstablecimiento").value;
        if (isNaN(valorEstablecimiento) == true) {

            validate = false;
        } else {

            validate = true;
        }
        return validate;
    }

    function validateSucursal() {
        var validate = true;

        var valorSucursal = document.getElementById("CodigoSucursal").value;
        if (isNaN(valorSucursal) == true) {

            validate = false;
        } else {

            validate = true;
        }
        return validate;
    }
    function validarUsuario() {
        var validate = true;
        var patron = /^[A-Z0-9]+$/;
        var valorUsuario = document.getElementById("Nikname").value;
        if (valorUsuario.length <= 8) {
           
            if (patron.test(valorUsuario)) {
                validate = true;
            } else {
                validate = false;

}
        } else {
            validate = false;
        }
            
        
        return validate;
    }

    function validarCaracteres() {
        var validate = true;
        var patron = /^[a-zA-Z0-9]+$/;
        var valorContrasenia = document.getElementById("password").value;

            if (valorContrasenia.length >= 8) {
                
                if (patron.test(valorContrasenia)) {
                    validate = true;
                } else {
                    validate = false;
                }
            }
            else {
                validate = false;
            }
        return validate;
    }


    ////Empieza Validacion Del Login


    $("#validacionUsuario").hide();
    $("#validacionContracenia").hide();

    $("#FrmLogin").submit(function (e) {
        e.preventDefault();

        var UsuarioLleno = ValidarUsuario();
        if (UsuarioLleno == true) {
            $("#validacionUsuario").hide();
        } else {
            $("#validacionUsuario").show();
        }

        var ContraseniaLleno = ValidarContrasenia();
        if (ContraseniaLleno == true) {
            $("#validacionContrasenia").hide();
        } else {
            $("#validacionContrasenia").show();
        }
        if (UsuarioLleno == true && ContraseniaLleno == true) {

            event.target.submit();
        }

    });

    function ValidarUsuario() {
        var Usuario = $("#validationUsuario").val();
        if (Usuario == "") {
            return false;
        } else {
            return true;
        }
    }
    function ValidarContrasenia() {

        var Contrasenia = $("#validationContrasenia").val();
        if (Contrasenia == "") {

            return false;
        } else {
            return true;
        }
    }
});
//////para que salga el modal del login
var myModal = new bootstrap.Modal(document.getElementById("exampleModal"), {});
myModal.hide();
document.onreadystatechange = function () {

    myModal.show();

};

//var myModal2 = new bootstrap.Modal(document.getElementById("modalErrorRegistro"), {});
//document.onreadystatechange = function () {

//    myModal2.show();

//};