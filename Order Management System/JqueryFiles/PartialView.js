/// <reference path="GenericAjax.js" />
$(document).ready(function () {

    //var role = sessionStorage.getItem("sessionn");
    //var user = sessionStorage.getItem("sessionName");
    var urll = "Login/login";
    if (sessionStorage.getItem("sessionn") != null) {
        $("leftsidebar").show();
    }
    else {
        window.location = "login/Logout";
    }

});