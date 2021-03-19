/// <reference path="GenericAjax.js" />


$(document).ready(function () {
    
    //var Monday = $("#CheckMonday").attr('checked') ? 1 : 0;
    ////console.log(Monday);	
    //var Tuesday = $("#CheckTuesday").attr('checked') ? 1 : 0;

    //$('#txtMonday').prop("disabled", true);
    //$('#pas').change(function () {
    //    var st = this.checked;
    //    if (st) {
    //        $('#txtMonday').prop("disabled", false);
    //    }
    //    else {
    //        $('#txtMonday').prop("disabled", true);
    //    }

    //});




    var table = $("#CustomerList").DataTable({
        //"processing": true, // for show progress bar
        //"serverSide": true, // for process server side
        //"filter": true, // this is for disable filter (search box)
        //"orderMulti": false, // for disable multiple column at once

        //"ajax": {
        //    "url": "GetAllCustomerRecords",
        //    "type": "POST",
        //    "datatype": "json"
        //    //"dataSrc": ""
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
        ],
        order: [[1, "asc"]],
        "columns":
            [
                { "defaultContent": "<input type='checkbox' class='checkbox'></input>" },
               { "data": "Customer_Code", "name": "Customer_Code", "autoWidth": true },
                { "data": "Customer_Name", "class": "Customer_Name", "name": "Customer_Name", "autoWidth": true },
                { "data": "Customer_PostalAddress", "class": "Customer_PostalAddress", "name": "Customer_PostalAddress", "autoWidth": true },
                { "data": "Region", "class": "Region", "name": "Region", "autoWidth": true },
                { "data": "City", "class": "City", "name": "City", "autoWidth": true },
                { "data": "Customer_category", "class": "Customer_category", "name": "Customer_category", "autoWidth": true },
                { "data": "Contact_PersonCell", "class": "Contact_PersonCell", "name": "Contact_PersonCell", "autoWidth": true },
                  {
                      "defaultContent": "<div id='opwp_woo_tickets'>Mon <input type='checkbox' id='CheckMonday' class='maxtickets_enable_cb'>Teus<input type='checkbox' class='maxtickets_enable_cb' id='CheckTuesday'>Wed<input type='checkbox' id='CheckWednesday'>Thur<input type='checkbox' id='CheckThursday'>Frida<input type='checkbox' id='CheckFriday'>Satu<input type='checkbox' id='CheckSaturday'>Sun<input type='checkbox' id='CheckSunday'></br><div class='max_tickets'><input type='text' style='width:42px' id='txtMonday' ><input type='text' style='width:42px' id='txtTuesday'><input type='text' style='width:42px' id='txtWednesday'><input type='text' style='width:42px' id='txtThursday'><input type='text' style='width:42px' id='txtFriday'><input type='text' style='width:42px' id='txtSaturday'><input type='text' style='width:42px' id='txtSunday'></div>",
                      // "defaultContent": "<div id='pas'>Mon <input type='checkbox' id='pas'>Teus<input type='checkbox' class='maxtickets_enable_cb'>Wed<input type='checkbox' id='Checkbox' name='chk'>Thur<input type='checkbox' id='Checkbox' name='chk'>Frida<input type='checkbox' id='Checkbox5' name='chk' >Satu<input type='checkbox' id='Checkbox' name='chk'>Sun<input type='checkbox' id='Checkbox' name='chk'></br><div class='max_tickets'><input type='text' style='width:42px' id='txtPassportNumber'><input type='text' style='width:42px'><input type='text' style='width:42px'><input type='text' style='width:42px'><input type='text' style='width:42px'><input type='text' style='width:42px'><input type='text' style='width:42px'></div>",
                  }
            ]
    });

    $('#bttnRec').click(function () {
        saveData('FrequencyOrder/FrequencyOrder');
        });
     

    $('#redirect').click(function () {

        window.location.href = "/dashboard/dashboard";
    });
    //$('.checkbox').change(function () {
    //    if ($('.checkbox:checked').length == $('.checkbox').length) {
    //        $('#checkall').prop('checked', true);
    //    }
    //    else {
    //        $('#select_all').prop('checked', false);
    //    }
    //});

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

    $('#pas').change(function () {


        if ($('#chkIsTeamLead').is(':checked') == true) {
            $('#txtPassportNumber').val('160').prop('disabled', true);
            console.log('checked');
        } else {
            $('#txtPassportNumber').val('').prop('disabled', false);
            console.log('unchecked');
        }

    });

    //$("#pas").click(function () {
    //        if ($(this).is(":checked")) {
    //            $("#txtPassportNumber").removeAttr("disabled");
    //            $("#txtPassportNumber").focus();
    //        } else {
    //            $("#txtPassportNumber").attr("disabled", "disabled");
    //        }
    //    });



    // checkbox on click show field working
    //$('input.maxtickets_enable_cb').change(function () {
    //    if ($(this).is(':checked')) $(this).next('div.max_tickets').show();
    //    else $('div.max_tickets').hide();
    //}).change();


});
function saveData(url) {
    var customers = new Array();
    $("#CustomerList TBODY TR").each(function () {
        var row = $(this);
        var customer = {};
        customer.Customer_Code = row.find("TD").eq(1).html();
     //   customer.Name = row.find("TD").eq(3).html();
      //  customer.PostalAddress = row.find("TD").eq(4).html();
     //   customer.Region = row.find("TD").eq(5).html();
     //   customer.City = row.find("TD").eq(6).html();
     //   customer.CellNumber = row.find("TD").eq(7).html();
        customer.Monday = row.find('#txtMonday').val();
        customer.Tuesday = row.find('#txtTuesday').val();
        customer.Wednesday = row.find('#txtWednesday').val();
        customer.Thursday = row.find('#txtThursday').val();
        customer.Friday = row.find('#txtFriday').val();
        customer.Saturday = row.find('#txtSaturday').val();
        customer.Sunday = row.find('#txtSunday').val();
     // customer.CheckMonday = row.find("#CheckMonday").prop('checked') ? 1 : 0;
     // customer.CheckTuesday = row.find("#CheckTuesday").prop('checked') ? 1 : 0;
     // customer.CheckWednesday = row.find("#CheckWednesday").prop('checked') ? 1 : 0;
     // customer.CheckThursday = row.find("#CheckThursday").prop('checked') ? 1 : 0;
     // customer.CheckFriday = row.find("#CheckFriday").prop('checked') ? 1 : 0;
     // customer.CheckSaturday = row.find("#CheckSaturday").prop('checked') ? 1 : 0;
     // customer.CheckSunday = row.find("#CheckSunday").prop('checked') ? 1 : 0;

        customers.push(customer);
    });
    var dataToPost = customers;
    //var Data = JSON.stringify(dataToPost);
    console.log(dataToPost);

    var name = JSON.stringify(dataToPost);
    Common.Ajax('POST', url, name, 'json', successOrderFrequencyCreateHandler);

}



function successOrderFrequencyCreateHandler(response) {

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



