$(document).ready(function () {
    $("#FrmBuscarProducto").submit(function (e) {
        
        e.preventDefault();

        var Nemonico = NemonicoBuscar();


        if (Nemonico == true) {

            event.target.submit();
            $("#BuscarNemonico").hide();
        } else {

            $("#BuscarNemonico").show();

        }

        var Descripcion= DescripcionBuscar();


        if (Descripcion == true) {

            event.target.submit();
            $("#BuscarDescripcion").hide();
        } else {

            $("#BuscarDescripcion").show();

        }

        

    });
    

    function NemonicoBuscar() {

        var Nemonico = $("#buscarNemonico").val();
        if (Nemonico == "") {

            return false;
        } else {
            return true;
        }
    }

    function DescripcionBuscar() {

        var Descripcion = $("#buscarDescripcion").val();
        if (Descripcion == "") {

            return false;
        } else {
            return true;
        }
    }
});