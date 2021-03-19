/// <reference path="GenericAjax.js" />
$(document).ready(function () {
    //add details
    $('#bttnAddDesignation').click(function () {

        if ($("#txtdesignationDesc").val().length <= 0) {
            alert("All Fields Required");
            $("#checkEmpty").empty();
            $("#checkEmpty").append("Designation and Postion must be defind");
        }
        else {
           
            saveData('addDesignation');
        }
    });

    $('#redirect').click(function () {

        window.location.href = "/dashboard/dashboard";
    });
    $('#bttnDesignationUpdate').click(function () {
        if ($("#txtDesignationDescUpdate").val().length <= 0) {
            alert("Fields Required");
            $("#updatecheckempty").empty();
            $("#updatecheckempty").append("Designation must be defind");
        }
        else {
            update('updateDesignation');
        }
    });


    //input validations start
    $("#txtdesignationDesc").keypress(function (e) {
        var keyCode = e.which;
        if ((keyCode != 8 || keyCode == 32) && (keyCode < 97 || keyCode > 122) && (keyCode < 65 || keyCode > 90)) {
            return false;
        }
    });

    var table = $("#designationList").DataTable({
        //"processing": true, // for show progress bar
        //"serverSide": true, // for process server side
        //"filter": true, // this is for disable filter (search box)
        //"orderMulti": false, // for disable multiple column at once
        //"ajax": {
        //    "url": "gridView",
        //    "type": "POST",
        //    "datatype": "json"
        //    //"dataSrc": ""
        //},

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
                { "data": "Designation_ID", "name": "Designation_ID", "class": "Designation_ID", "autoWidth": true },
                { "data": "DesigantionDesc", "name": "DesigantionDesc", "class": "DesignationDesc", "autoWidth": true },
                { "data": "User_ID", "name": "User_ID", "autoWidth": true, "visible": false },
                {
                    //"defaultContent": "<button id='click' class='btn btn-primary m-t-6 waves-effect'>Edit!</button>"
                    
                data: null, render: function (data, type, row) {
                    //return "<a href='#' class='btn btn-danger' onclick=DeleteData('" + row.CustomerID + "'); >Delete</a>";
                        return "<button id='click' class='btn btn-primary m-t-6 waves-effect'>Edit</button> | <a href='#'  onclick=DeleteById('" + row.Designation_ID + "'); class='btn btn-danger'>Delete</a>";
                }
            



                }
        ],
        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'excel',
                autoFilter: true,
                exportOptions: {
                    columns: [0, 1]
                }
            },


            {
                extend: 'csv',
                autoFilter: true,
                exportOptions: {
                    columns: [0, 1]
                }
            },
            {
                extend: 'pdf',
                autoFilter: true,
                exportOptions: {
                    columns: [0, 1]
                }
            },
            {
                extend: 'print',
                autoFilter: true,
                exportOptions: {
                    columns: [0, 1]
                }
            },
            {
                extend: 'copy',
                autoFilter: true,
                exportOptions: {
                    columns: [0, 1]
                }
            },

        ]
    });



    $('#designationList tbody').on('click', 'button', function () {


        var data = table.row($(this).parents("tr")).data();
        var updateDesignationID = $(this).closest("tr").find(".Designation_ID").text();
        var updateDesignationDecs = $(this).closest("tr").find(".DesignationDesc").text();




        $("#addevent").modal();
        //$("#txtDesignationIDUpdate").val(updateDesignationID);
        $("#txtDesignationDescUpdate").val(updateDesignationDecs);
        $("#txtDesignationIDupdate").val(updateDesignationID);

    });
   // BindDropDown('getAllUsers');
});


//function BindDropDown(url) {
//    Common.Ajax('GET', url, {}, 'json', BindDropDownHandler);
//}


function update(url) {
    var dataToPost = '{"Designation_ID":"' + $("#txtDesignationIDupdate").val() + '","Designation_Desc":"' + $("#txtDesignationDescUpdate").val() + '"}';

    Common.Ajax("POST", url, dataToPost, 'json', successDesigUpdateHandler);
}


function DeleteById(id) {

    console.log(id);
    var dataToPost = '{"designation_id":"' + id + '"}';

    Common.Ajax('DELETE', "DeleteDesignation", dataToPost, 'json', successUserCreateHandler);

}


function saveData(url) {


    var dataToPost = '{"designationDesc":"' + $("#txtdesignationDesc").val() + '","Position":"' + $("#txtPosition").val() + '"}';

    Common.Ajax('POST', url, dataToPost, 'json', successUserCreateHandler);
}

//function BindDropDownHandler(response) {
//    var s = '<option value="-1">Please Select a user</option>';
//    for (var i = 0; i < response.length; i++) {
//        s += '<option value="' + response[i].User_ID + '">' + response[i].UserFirstName + '</option>';
//    }
//    $("#dropDownUser").html(s);
//}


function successUserCreateHandler(response) {

    if (response == '1') {
        $('#txtdesignationDesc').val('');
        $('#txtPosition').val('');
        $('#dropDownUser').val(-1);

        $('#designationList').DataTable().ajax.reload();
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

function successDesigUpdateHandler(response) {

    if (response == '2') {
        $('#txtDesignationDescUpdate').val('');
        $('#dropDownUser').val(-1);
        $('#designationList').DataTable().ajax.reload();
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
    //if (response == '-2') {
    //    alert('Designation Updated.');
    //}
    //if (response == '2') {
    //    alert('Designation already added.');
    //}
}
//function EditRoles(RoleID) {
//    var url = "";
//    $("#addevent").modal();
//}



//$(document).ready(function () {
//    //add details
//    $('#bttnAddDesignation').click(function () {


//        saveData('addDesignation');

//    });

//    $('#bttnDesignationUpdate').click(function () {
//        update('updateDesignation');
//    });

//    //input validations start
//    $("#txtdesignationDesc").keypress(function (e) {
//        var keyCode = e.which;
//        /*
//          8 - (backspace)
//          32 - (space)
//          48-57 - (0-9)Numbers
//          97-122 - (a-z)Small Alphabets
//          65-90 - (A-Z)Capital Alphabets
//        */

//        if ((keyCode != 8 || keyCode == 32) && (keyCode < 97 || keyCode > 122) && (keyCode < 65 || keyCode > 90)) {
//            return false;
//        }
//    });

//    //input validations ends


//    //dataTable Start


//    $("#designationList").DataTable({
//        "processing": true, // for show progress bar
//        "serverSide": true, // for process server side
//        "filter": true, // this is for disable filter (search box)
//        "orderMulti": false, // for disable multiple column at once
//        "ajax": {
//            "url": "gridView",
//            "type": "POST",
//            "datatype": "json"
//            //"dataSrc": ""
//        },
//        "columns": [
//                { "data": "Designation_ID", "name": "Designation_ID", "autoWidth": true },
//                { "data": "DesigantionDesc", "name": "DesigantionDesc", "autoWidth": true },
//                { "data": "User_ID", "name": "User_ID", "autoWidth": true },
//                {
//                    "defaultContent": "<button id='click'>Update!</button>"


//                }
//        ]
//    });

//    $('#designationList tbody').on('click', 'button', function () {


//        var data = table.row($(this).parents("tr")).data();
//        var updateDesignationID = $(this).closest("tr").find(".Designation_ID").text();
//        var updateDesignationDecs = $(this).closest("tr").find(".DesignationDesc").text();




//        $("#addevent").modal();
//        //$("#txtDesignationIDUpdate").val(updateDesignationID);
//        $("#txtDesignationDescUpdate").val(updateDesignationDecs);
//    });



//    //dataTable Ends
//    BindDropDown('getAllUsers');

//    //$('.popbox').popbox();
//    //$('.popbox').popbox({
//    //    'open': '.open',
//    //    'box': '.box',
//    //    'arrow': '.arrow',
//    //    'arrow-border': '.arrow-border',
//    //    'close': '.close'
//    //});
//});


//function BindDropDown(url) {
//    Common.Ajax('GET', url, {}, 'json', BindDropDownHandler);
//}

//function saveData(url) {


//    var dataToPost = '{"designationDesc":"' + $("#txtdesignationDesc").val() + '","userId":"' + $("#dropDownUser").val() + '"}';

//    Common.Ajax('POST', url, dataToPost, 'json', successUserCreateHandler);
//}

//function BindDropDownHandler(response) {
//    var s = '<option value="-1">Please Select a user</option>';
//    for (var i = 0; i < response.length; i++) {
//        s += '<option value="' + response[i].User_ID + '">' + response[i].UserFirstName + '</option>';
//    }
//    $("#dropDownUser").html(s);
//}


//function successUserCreateHandler(response) {

//    if (response == '1') {
//        $('#txtdesignationDesc').val('');
//        $('#dropDownUser').val(-1);

//        $('#designationList').DataTable().ajax.reload();
//        setTimeout(function () {
//            $('#successAlert').hide('fade');
//        }, 5000);
//    }
//    if (response == '-1') {
//        $('#warningAlert').show('fade');

//        setTimeout(function () {
//            $('#warningAlert').hide('fade');
//        }, 5000);
//    }
//    //if (response == '-2') {
//    //    alert('Designation Updated.');
//    //}
//    //if (response == '2') {
//    //    alert('Designation already added.');
//    //}
//}