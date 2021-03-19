/// <reference path="GenericAjax.js" />
$(document).ready(function () {
    $('#bttnUpdatePass').click(function () {
        if ($("#txtOldPass").val().length <= 0) {
            alert("Field must not be null");
            $("#txtNewPass").val() == "";
            $("#txtNewPass").append("New Password Should Not Be Empty");
        }
        else if (!Validate()) {
            $("#paswrdmatch").fadeIn();

            setTimeout(function () { $("#paswrdmatch").fadeOut(); }, 3000);
        }
        else {
            UpdatePass('PasswordUpdate');
        }

    });

});
function Validate() {
    var password = document.getElementById("txtNewPass").value;
    var confirmPassword = document.getElementById("txtreNewPass").value;
    if (password != confirmPassword) {
        return false;
    }
    return true;
}
function UpdatePass(url) {

    var dataToPost = '{"txtOldPass":"' + $("#txtOldPass").val() + '","txtNewPass":"' + $("#txtNewPass").val() + '"}';
    Common.Ajax("POST", url, dataToPost, 'json', successUpdatePasswordHandler);
}
function successUpdatePasswordHandler(response) {
    if (response == 0) {
        //show error
        $('#warningAlert').text('Current Password does not match')
        $('#warningAlert').fadeIn();
        setTimeout(function () { $("#warningAlert").fadeOut(); }, 3000);
     
    }

    else if (response == 1) {
        //show success
        $('#successAlert').text('Password Updated Successfully')
        $('#successAlert').show('fade');
        setTimeout(function () { $("#successAlert").fadeOut(); location.href = "/dashboard/dashboard"; }, 3000);
        
    }

}