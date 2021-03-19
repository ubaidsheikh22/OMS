$(document).ready(function () {

    BindDropDown('GetProduct');

    $('#bttnProduct').click(function () {
        saveData('insertBindingProducts');
    });

    $('#redirect').click(function () {

        window.location.href = "/dashboard/dashboard";
    });

    $("#List").DataTable({

        //"processing": true, // for show progress bar
        //"serverSide": true, // for process server side
        //"filter": true, // this is for disable filter (search box)
        //"orderMulti": false, // for disable multiple column at once
       // "data": data,
       // "dataSrc": "",
       


        //"processing": false, // for show progress bar
        //"serverSide": false, // for process server side
        //"filter": false, // this is for disable filter (search box)
        //"orderMulti": false, // for disable multiple column at once

        //"ajax": {
        //    "url": "GetProductForList",
        //    "type": "POST",
        //    "datatype": "json",
        //    "DataSrc": "",
        //    "deferRender": true,
        //},


        "ajax": {
            "url": "GetProductForList",
            "type": "POST",
            "datatype": "json",

            "processing": false, // for show progress bar
            "serverSide": false, // for process server side
            "filter": true, // this is for disable filter (search box)
            "orderMulti": true, // for disable multiple column at once
            "dataSrc": "",

        },
        "columns": [
                { "data": "Material", "name": "Material", "class": "Material", "autoWidth": true },               
                { "data": "Description", "class": "Description", "name": "Description", "autoWidth": true },
                { "data": "Material1", "name": "Material1", "class": "Material1", "autoWidth": true },
                { "data": "Description1", "class": "Description1", "name": "Description1", "autoWidth": true },
                        
              
        ]
       

    });       //"orderMulti": false, // for disable multiple column at once




});


function saveData(url) {
    var dataToPost = '{"ProductCode1":"' + $("#ProductID1").val() + '","ProductCode2":"' + $("#ProductID2").val() + '"}';
    Common.Ajax('POST', url, dataToPost, 'json', successRoleCreateHandler);
}


function BindDropDown(url) {
    Common.Ajax('GET', url, {}, 'json', BindDropDownHandler);
}


function BindDropDownHandler(response) {
    var s = '<option value="-1">Please Select a Material</option>';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].Material + '">' + response[i].Description + ' (' + response[i].Material + ') </option>';
    }
    $("#ProductID1 , #ProductID2").html(s);
}

function successRoleCreateHandler(response) {
   
    if (response == '1') {
        $('#ProductID1').val(-1);
        $('#ProductID2').val(-1);
        $('#List').DataTable().ajax.reload();
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
