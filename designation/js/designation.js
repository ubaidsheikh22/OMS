/// <reference path="GenericAjax.js" />


$(document).ready(function () {



    BindDropDown('getAllUsers');

    //add details
    $('#bttnAddDesignation').click(function () {


        saveData('addDesignation');

    });


    //input validations start
    $("#txtdesignationDesc").keypress(function (e) {
        var keyCode = e.which;
        /*
          8 - (backspace)
          32 - (space)
          48-57 - (0-9)Numbers
          97-122 - (a-z)Small Alphabets
          65-90 - (A-Z)Capital Alphabets
        */

        if ((keyCode != 8 || keyCode == 32) && (keyCode < 97 || keyCode > 122) && (keyCode < 65 || keyCode > 90)) {
            return false;
        }
    });

    //input validations ends


    //dataTable Start


    $("#designationList").DataTable({
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "ajax": {
            "url": "gridView",
            "type": "POST",
            "datatype": "json"
            //"dataSrc": ""
        },
        "columns": [
                { "data": "Designation_ID", "name": "Designation_ID", "autoWidth": true },
                { "data": "DesigantionDesc", "name": "DesigantionDesc", "autoWidth": true },
                { "data": "User_ID", "name": "User_ID", "autoWidth": true },
                //{ "data": "creationdate", "name": "creation date", "autowidth": true },
                //{ "data": "user_id", "name": "user id", "autowidth": true },
                //{ "data": "product_id", "name": "product id", "autowidth": true }
                //{
                //    //mRender: function (data, type, row) {
                //    //    return "<button type='button' ID='EditButton1' class='btn btn-round zmdi zmdi-edit EditButton' onclick='EditRoles(" + row.ID + ")' data-toggle='modal' data-target='#addevent'></button>"
                //    //}
                //}
        ]
    });


    //dataTable Ends



});


function BindDropDown(url) {
    Common.Ajax('GET', url, {}, 'json', BindDropDownHandler);
}

function saveData(url) {


    var dataToPost = '{"designationDesc":"' + $("#txtdesignationDesc").val() + '","userId":"' + $("#dropDownUser").val() + '"}';

    Common.Ajax('POST', url, dataToPost, 'json', successUserCreateHandler);
}

function successUserCreateHandler(response) {

    if (response == '1') {

        $('#successAlert').show('fade');
        $('#designationList').DataTable().ajax.reload();
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
    //if (response == '-2') {
    //    alert('Designation Updated.');
    //}
    //if (response == '2') {
    //    alert('Designation already added.');
    //}
}

function BindDropDownHandler(response) {
    var s = '<option value="-1">Please Select a user</option>';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].User_ID + '">' + response[i].UserFirstName + '</option>';
    }
    $("#dropDownUser").html(s);
}