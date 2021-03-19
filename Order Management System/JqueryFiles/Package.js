/// <reference path="GenericAjax.js" />
$(document).ready(function () {

        var table = $("#packageList").DataTable({
            //// "processing" : true,
            //"serverSide": true,
            //"filter": true,
            //"orderMulti": false,

            //"ajax": {
            //    "url": "GetAllPackeges",
            //    "type": "POST",
            //    "datatype": "json"
            //},


            "ajax": {
                "url": "GetAllPackeges",
                "type": "POST",
                "datatype": "json",

                "processing": false, // for show progress bar
                "serverSide": false, // for process server side
                "filter": true, // this is for disable filter (search box)
                "orderMulti": true, // for disable multiple column at once
                "dataSrc": "",

            },


            "columns": [
                { "data": "Package_ID", "class": "Package_ID", "name": "Package_ID", "autoWidth": true },
                { "data": "PackageName", "class": "PackageName", "name": "PackageName", "autoWidth": true },
                { "data": "UserName", "class": "UserName", "name": "UserName", "autoWidth": true },
                {
                    "defaultContent": "<button id='update' class='btn btn-primary m-t-6 waves-effect'>Update</button>"
                }
            ]

        });
        $('#BtnPackage').click(function () {
            SavePackage('AddPackage');
        });
        $("#bttnUpdatePackage").click(function () {
            UpdatepPackage('/package/updatePackage');
        });

        $("#packageList tbody").on('click', 'button', function () {
            var data = table.row($(this).parents("tr")).data();
            var UpdatePackageID = $(this).closest("tr").find(".Package_ID").text();
            var UpdatePackageName = $(this).closest("tr").find(".PackageName").text();


            $("#largeModal").modal();
            $("#uptxtPackageID").val(UpdatePackageID);
            $("#uptxtPackageName").val(UpdatePackageName);
        });


        $("#txtPackageName").keypress(function (e) {
            var keyCode = e.which;
            if ((keyCode != 8 || keyCode == 32) && (keyCode < 97 || keyCode > 122)) {
                return false;
            }
        });
        $("#uptxtPackageName").keypress(function (e) {
            var keyCode = e.which;
            if ((keyCode != 8 || keyCode == 32) && (keyCode < 97 || keyCode > 122)) {
                return false;
            }
        });

    $('#redirect').click(function () {

        window.location.href = "/dashboard/dashboard";
    });
});

function SavePackage(url)
{
    var Data =new Object();
    Data.PackageName=$("#txtPackageName").val();
    var SavePackage = JSON.stringify(Data);
    Common.Ajax('POST', url, SavePackage, 'json', successSavePackageHandler);
}
function UpdatepPackage(url) {
    var dataToPost = '{"Package_ID":"' + $("#uptxtPackageID").val() + '","PackageName":"' + $("#uptxtPackageName").val() + '"}';

    //var Data = new Object();
    //Data.Package_ID = $("uptxtPackageID").val();
    //Data.PackageName = $("uptxtPackageName").val();

    //var UpPackage = JSON.stringify(Data);
    Common.Ajax("POST", url, dataToPost, 'json', successUpdatePackageHandler);
}

function successSavePackageHandler(response)
{
    if (response == '1')
    {
        $('#txtPackageName').val('');
        $('#successAlert').show('fade');
        setTimeout(function () {
            $('#successAlert').hide('fade');
        }, 5000);
        $('#packageList').DataTable().ajax.reload();
    }
    if (response == '-1')
    {
        $('#warningAlert').show('fade');
        setTimeout(function () {
            $('#warningAlert').hide('fade');
        },5000);
    }
}

function successUpdatePackageHandler(response)
{
    if (response == '2') {
        $('#packageList').DataTable().ajax.reload();
        $('#uptxtPackageName ').val('');
        $('#successAlertup').show('fade');

        setTimeout(function () {
            $('#successAlertup').hide('fade');
        }, 5000);
    }
    if (response == '-2') {

        $('#warningAlertup').show('fade');

        setTimeout(function () {
            $('#warningAlertup').hide('fade');
        }, 5000);
    }
}
