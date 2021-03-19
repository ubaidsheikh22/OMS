/// <reference path="GenericAjax.js" />

$(document).ready(function () {
    BindDropDownPackage('GetAllPackages');

    $("#Package_ID").change(function () {
        if ($(this).data('options') === undefined) {
            /*Taking an array of all options-2 and kind of embedding it on the select1*/
            $(this).data('options', $('#RoleId option').clone());
        }
        var id = $(this).val();
        var options = $(this).data('options').filter('[value=' + id + ']');
        $('#RoleId').html(options);
    });


    $('#redirect').click(function () {

        window.location.href = "/dashboard/dashboard";
    });

    $('[id$="search-box1"]').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "GetAllCusRecord",
                type: "POST",
                dataType: "json",
                data: { Customer_Code: request.term}, //, Customer_Code: request.term 
                success: function (data) {
                    response($.map(data, function (item) {
                        console.log(item.Customer_Code);
                        return { label: item.Customer_Code, value: item.Customer_Code }; //, label: item.Customer_Code, value: item.Customer_Code 
                    }))

                }
            })
        },
        messages: {
            noResults: "", results: ""
        }
    });

    $('[id$="search-box2"]').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "GetAllCusRecord",
                type: "POST",
                dataType: "json",
                //  data: { Customer_Name: request.term, filter, locale: 'en-US', Customer_Code: request.term },
                data: { Customer_Name: request.term, Customer_Code: request.term }, //, Customer_Code: request.term 
                success: function (data) {
                    response($.map(data, function (item) {
                        console.log(item.Customer_Name);
                        return { label: item.Customer_Name, value: item.Customer_Name }; //, label: item.Customer_Code, value: item.Customer_Code 
                    }))

                }
            })
        },
        messages: {
            noResults: "", results: ""
        }
    });

    $('[id$="search-box3"]').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "GetAllCusRecord",
                type: "POST",
                dataType: "json",
                //  data: { Customer_Name: request.term, filter, locale: 'en-US', Customer_Code: request.term },
                data: { Region: request.term }, //, Customer_Code: request.term 
                success: function (data) {
                    response($.map(data, function (item) {
                        console.log(item.Region);
                        return { label: item.Region, value: item.Region }; //, label: item.Customer_Code, value: item.Customer_Code 
                    }))

                }
            })
        },
        messages: {
            noResults: "", results: ""
        }
    });

    $("#CustomerList").DataTable({
        //"processing": false, // for show progress bar
        //"serverSide": true, // for process server side
        //"filter": true, // this is for disable filter (search box)
        //"orderMulti": false, // for disable multiple column at once

        //"ajax": {
        //    "url": "GetAllCustomerRecords",
        //    "type": "POST",
        //    "datatype": "json"
        //},


        "ajax": {
            "url": "GetAllCustomerRecords",
            "type": "POST",
            "datatype": "json",

            "processing": false, // for show progress bar
            "serverSide": false, // for process server side
            "filter": true, // this is for disable filter (search box)
            "orderMulti": true, // for disable multiple column at once
            "dataSrc": "",

        },



        columnDefs: [
                  { targets: 0, sortable: false },
                  { targets: 1, sortable: false },
                  { targets: 2, sortable: false },
                  { targets: 3, sortable: false },
                ],
                order: [[1, "asc"]],
        "columns": [
             { "defaultContent": "<input type='checkbox' id='idd' class='checkbox' class='filled-in form-control'></input>" },
            { "data": "Customer_Code", "name": "Customer_Code", "class": "Customer_Code", "autoWidth": true },
                { "data": "Customer_Name", "class": "Customer_Name", "name": "Customer_Name", "autoWidth": true },
                  { "data": "Region", "class": "Region", "name": "Region", "autoWidth": true },
                   
        ]
    });


    $("#select_all").change(function () {  //"select all" change 
        var status = this.checked; // "select all" checked status
        $('.checkbox').each(function () { //iterate all listed checkbox items
            this.checked = status; //change ".checkbox" checked status
        });
    });

    $('.checkbox').change(function () { //".checkbox" change 
        //uncheck "select all", if one of the listed checkbox item is unchecked
        if (this.checked == false) { //if this item is unchecked
            $("#select_all")[0].checked = false; //change "select all" checked status to false
        }

        //check "select all" if all checkbox items are checked
        if ($('.checkbox:checked').length == $('.checkbox').length) {
            $("#select_all")[0].checked = true; //change "select all" checked status to true
        }
    });

    $('#bttnCus').click(function () {
        saveData('AddFrequecnycRecord');
    });



});
function saveData(url) {
    var customers = new Array();
    var package_ID = $('#txtPackageID').val();
    var Frequency_ID = $('#txtDayFrequencyID').val();
    $("#CustomerList TBODY TR input[type=checkbox]:checked").each(function () {
        //var chk = $('#idd').attr('checked') ? 1 : 0;
        //if (chk == 1)
        //{
            var row = $(this);
            var customer = {};
            customer.Customer_Code = row.closest("tr").find(".Customer_Code").text();

        //}
        
            customers.push(package_ID , customer);
    });
    console.log(customers);
    var dataToPost = customers;
    //var Data = JSON.stringify(dataToPost);
   // console.log(dataToPost);

    var record = JSON.stringify(dataToPost);
    Common.Ajax('POST', url, record, 'json', successCustomerFrequencyCreateHandler);

}


function BindDropDownPackage(url) {
    Common.Ajax('GET', url, {}, 'json', BindDropDownPackageHandler);
}
function BindDropDownPackageHandler(response) {
    var s = '<option value="-1">Please Select a Package</option>';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].Package_ID + '">' + response[i].PackageName + '</option>';
    }
    $("#txtPackageID").html(s);
}
function successCustomerFrequencyCreateHandler(response) {

    if (response == '1') {
        //bootbox.alert('Category added successfully.');

        $('#successAlert').show('fade');

        setTimeout(function () {
            $('#successAlert').hide('fade');
        }, 5000);
    }
    if (response == '-1') {
        //bootbox.alert('Category already exists.');
        $('#warningAlert').show('fade');

        setTimeout(function () {
            $('#warningAlert').hide('fade');
        }, 5000);
    }
}



function successUserCreateHandler(response) {

    if (response == '1') {
        //bootbox.alert('Category added successfully.');

        $('#successAlert').show('fade');

        setTimeout(function () {
            $('#successAlert').hide('fade');
        }, 5000);
    }
    if (response == '-1') {
        //bootbox.alert('Category already exists.');
        $('#warningAlert').show('fade');

        setTimeout(function () {
            $('#warningAlert').hide('fade');
        }, 5000);
    }
}




//$(document).ready(function () {

//    //$.get("Role/GetAllRoleRecord", null, DataBind);
//    $("#CustomerList").DataTable({
//        //"processing": false, // for show progress bar
//        "serverSide": true, // for process server side
//        //"filter": false, // this is for disable filter (search box)
//        //"orderMulti": false, // for disable multiple column at once

//        "ajax": {
//            "url": "GetAllCustomerRecords",
//            "type": "POST",
//            "datatype": "json"
//        },
//        //columnDefs: [
//        //  { targets: 0, sortable: false },
//        //  { targets: 1, sortable: false },
//        //  { targets: 2, sortable: false },
//        //],
//        //order: [[1, "asc"]],
//        "columns":
//            [
//             { "defaultContent": "<input type='checkbox' class='checkbox' class='filled-in form-control'></input>" },
//            { "data": "Customer_Code", "name": "Customer_Code", "autoWidth": true },
//                { "data": "Customer_Name", "class": "Customer_Name", "name": "Customer_Name", "autoWidth": true },
//                  { "data": "Region", "class": "Region", "name": "Region", "autoWidth": true },
                   
//                {
//                    mRender: function (data, type, row) {

//                        return "<input type='button' ID='EditButton1' class='btn btn-round zmdi zmdi-edit EditButton' onclick='EditRoles(" + row.Customer_Code + ")' data-toggle='modal' data-target='#addevent'/>"
//                    }
//                }
//        ]
//        //buttons: [
//        //    { extend: "edit", editor: editor }
//        //]

//    });       //"orderMulti": false, // for disable multiple column at once

//});

//function successUserCreateHandler(response) {

//    if (response == '1') {
//        //bootbox.alert('Category added successfully.');

//        $('#successAlert').show('fade');

//        setTimeout(function () {
//            $('#successAlert').hide('fade');
//        }, 5000);
//    }
//    if (response == '-1') {
//        //bootbox.alert('Category already exists.');
//        $('#warningAlert').show('fade');

//        setTimeout(function () {
//            $('#warningAlert').hide('fade');
//        }, 5000);
//    }
//}







