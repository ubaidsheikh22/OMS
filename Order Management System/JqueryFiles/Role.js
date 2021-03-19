/// <reference path="GenericAjax.js" />

$(document).ready(function () {

    $('#bttnRole').click(function () {
        if ($("#txtReleDesc").val().length <= 0) {
            alert("Please enter Reason");
        }
        else {
            saveData('addRole');
        }
    });

    $('#redirect').click(function () {

        window.location.href = "/dashboard/dashboard";
    });

    $('#bttnUpdateRole').click(function () {

        if ($("#txtRoleDecsUpdate").val().length <= 0) {
            alert("Field must not be null");
            $("#Updatecheckempty").empty();
            $("#Updatecheckempty").append("Role Description must be Defined");
        }
        else {
            update('updateRole');
        }
    });


    var table = $("#RoleList").DataTable({
        "ajax": {
            "url": "gridView",
            "type": "POST",
            "datatype": "json",

            "processing": false, // for show progress bar
            "serverSide": false, // for process server side
            "filter": true, // this is for disable filter (search box)
            "orderMulti": true, // for disable multiple column at once
            "dataSrc": "",
        },

        "columns": [
            { "data": "Role_ID", "class": "Role_ID", "name": "Role_ID", "autoWidth": true },
            { "data": "Rele_Desc", "class": "Rele_Desc", "name": "Rele_Desc", "autoWidth": true },
            { "data": "UserName", "class": "UserName", "name": "UserName", "autoWidth": true },
            {
                data: null, render: function (data, type, row) {
                    return "<button id='click' class='btn btn-primary m-t-6 waves-effect'>Edit</button> | <a href='#'  onclick=DeleteById('" + row.Login_ID + "'); class='btn btn-danger'>Delete</a>";
                }
            }
        ],
        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'excel',
                autoFilter: true,

                exportOptions: {
                    columns: [0, 1, 2],

                }
            },


            {
                extend: 'csv',
                autoFilter: true,
                exportOptions: {
                    columns: [0, 1, 2]
                }
            },
            {
                extend: 'pdf',
                autoFilter: true,
                exportOptions: {
                    columns: [0, 1, 2]
                }
            },
            {
                extend: 'print',
                autoFilter: true,
                exportOptions: {
                    columns: [0, 1, 2]
                }
            },
            {
                extend: 'copy',
                autoFilter: true,
                exportOptions: {
                    columns: [0, 1, 2]
                }
            },

        ]
    });       //"orderMulti": false, // for disable multiple column at once

    $('#RoleList tbody').on('click', 'button', function () {

        var data = table.row($(this).parents("tr")).data();
        var updateRoleID = $(this).closest("tr").find(".Role_ID").text();
        var updateRoleDecs = $(this).closest("tr").find(".Rele_Desc").text();
        $("#largeModal").modal();
        $("#txtRoleDecsUpdate").val(updateRoleDecs);
        $("#txtRoleIDUpdate").val(updateRoleID);
    });

    $("#txtRoleDecs").keypress(function (e) {
        var keyCode = e.which;
        /*
          8 - (backspace)
          32 - (space)
          48-57 - (0-9)Numbers
          97-122 - (a-z)Small Alphabets
          65-90 - (A-Z)Capital Alphabets
        */

        if ((keyCode != 8 || keyCode == 32) && (keyCode < 97 || keyCode > 122)) {
            return false;
        }
    });
});

function saveData(url) {
    var dataToPost = '{Rele_Desc: "' + $("#txtReleDesc").val() + '" }';
    Common.Ajax('POST', url, dataToPost, 'json', successRoleCreateHandler);
}

function update(url) {
    var dataToPost = '{"Rele_Desc":"' + $("#txtRoleDecsUpdate").val() + '","Role_ID":"' + $("#txtRoleIDUpdate").val() + '"}';
    Common.Ajax('POST', url, dataToPost, 'json', successRoleUpdateHandler);
}
function successRoleCreateHandler(response) {

    if (response == '1') {
        $('#RoleList').DataTable().ajax.reload();
        $('#txtReleDesc').val('');
        $('#successAlert').show('fade');

        setTimeout(function () {
            $('#successAlert').hide('fade');
        }, 5000);
    }
    if (response == '-1') {
        $('#warningAlert').show('fade');

        setTimeout(function () {
            $('#warningAlert').hide('fade');
        }, 5000);
    }


}
function successRoleUpdateHandler(response) {
    if (response == '2') {
        $('#RoleList').DataTable().ajax.reload();
        $('#txtRoleDecsup ').val('');
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

function EditRoles(RoleID) {
    var url = "";
    $("#largeModal").modal();
}