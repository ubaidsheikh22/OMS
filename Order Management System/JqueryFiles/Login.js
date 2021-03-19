/// <reference path="GenericAjax.js" />

$(document).ready(function () {
    //var username = $("#txtUserName").val();
    //var pass = $("#txtPass").val();
    $('#bttnlogin').click(function () {
        Login('Login/UserLogin');
    });

    $(document).on('keypress', function (e) {
        if (e.which == 13) {
            Login('Login/UserLogin');
        }
    });

});

function Login(url) {

    if ($('#txtUserName').val() == "" || $('#txtPass').val() == "") {
        alert('Please enter your credentials!');
        return;
    }

    if (url == 'UserLogin') {
        var ConvertUrll = "Login/UserLogin";
        var dataToPost = '{"UserName":"' + $("#txtUserName").val() + '","Pass":"' + $("#txtPass").val() + '"}';
        Common.Ajax('POST', ConvertUrll, dataToPost, 'json', successUserLoginHandler);
    }
    else if (url == 'Login/Login/UserLogin') {
        var ConvertUrll = "Login/UserLogin";
        var dataToPost = '{"UserName":"' + $("#txtUserName").val() + '","Pass":"' + $("#txtPass").val() + '"}';
        Common.Ajax('POST', ConvertUrll, dataToPost, 'json', successUserLoginHandler);
    }

    else {
        var dataToPost = '{"UserName":"' + $("#txtUserName").val() + '","Pass":"' + $("#txtPass").val() + '"}';
        Common.Ajax('POST', url, dataToPost, 'json', successUserLoginHandler);
    }
}

function successUserLoginHandler(reponse) {
    var rolee = reponse.Role_ID;
    var username = reponse.UserName;
    var Regionn = reponse.RegionCode;
    var Areaa = reponse.AreaCode;
    var Teritoryy = reponse.TeritoryCode;
    var Townn = reponse.TownCode;
    var LoginError = reponse.LoginError;

    sessionStorage.setItem("sessionn", rolee);
    sessionStorage.setItem("sessionName", username);
    sessionStorage.setItem("Region", Regionn);
    sessionStorage.setItem("Area", Areaa);
    sessionStorage.setItem("Teritory", Teritoryy);
    sessionStorage.setItem("Town", Townn);

    if (reponse.isRedirect && LoginError.includes('Success')) {
        $('#successAlert').text('Login successful! Redirecting to dashboard...')
        $('#successAlert').show('fade');
        setTimeout(function () {
            $('#successAlert').hide('fade');
        }, 5000);
        window.location.href = reponse.redirectUrl;
        return;
    }

    if (!LoginError.includes('Success')) {
        $('#warningAlert').show('fade');
        $('#warningAlert').text(LoginError);

        setTimeout(function () {
            $('#warningAlert').hide('fade');
        }, 5000);
    }
}




