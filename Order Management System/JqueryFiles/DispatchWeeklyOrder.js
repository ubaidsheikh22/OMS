/// <reference path="GenericAjax.js" />

$(document).ready(function () {
    BindDropDown('getAllPackages');
    BindDropDownPackageEdit('getAllPackages');
    BindDropDownCustomer('getAllCustomers');
    BindDropDownCustomerEdit('getAllCustomers');

    $('#redirect').click(function () {

        window.location.href = "/dashboard/dashboard";
    });
    $('#bttnUpdatePackageFrequency').click(function () {

        var frequencyMondayUp = $('#txtMondayFrequencyUpdate').val();
        var frequencyTuesdayUp = $('#txtTuesdayFrequencyUpdate').val();
        var frequencyWednesdayUp = $('#txtWednesdayFrequencyUpdate').val();
        var frequencyThursdayUp = $('#txtThursdayFrequencyUpdate').val();
        var frequencyFridayUp = $('#txtFridayFrequencyUpdate').val();
        var frequencySaturdayUp = $('#txtSaturdayFrequencyUpdate').val();
        var frequencySundayUp = $('#txtSundayFrequencyUpdate').val();
        var totalfrequencyUp = parseInt(frequencyMondayUp) + parseInt(frequencyTuesdayUp) + parseInt(frequencyWednesdayUp) + parseInt(frequencyThursdayUp) + parseInt(frequencyFridayUp) + parseInt(frequencySaturdayUp) + parseInt(frequencySundayUp);
        if (totalfrequencyUp == 100) {
            $('#successAlertUpdate').hide('fade');
            $('#warningAlertUpdate').hide('fade');
            $('#frequencySumAlertUpdate').hide('fade');
            UpdatePackageFrequency('UpdatePackageFrequency');
        }
        else {
            $('#frequencySumAlertUpdate').show('fade');
            setTimeout(function () {
                $('#frequencySumAlertUpdate').hide('fade');
            }, 5000);
        }
    });


    $('#bttnAddPackageFrequency').click(function () {

        var frequencyMonday = $('#txtMondayFrequency').val();
        var frequencyTuesday = $('#txtTuesdayFrequency').val();
        var frequencyWednesday = $('#txtWednesdayFrequency').val();
        var frequencyThursday = $('#txtThursdayFrequency').val();
        var frequencyFriday = $('#txtFridayFrequency').val();
        var frequencySaturday = $('#txtSaturdayFrequency').val();
        var frequencySunday = $('#txtSundayFrequency').val();
        var totalfrequency = parseInt(frequencyMonday) + parseInt(frequencyTuesday) + parseInt(frequencyWednesday) + parseInt(frequencyThursday) + parseInt(frequencyFriday) + parseInt(frequencySaturday) + parseInt(frequencySunday);
        console.log(totalfrequency);
        if (totalfrequency == 100) {
            $('#successAlert').hide('fade');
            $('#warningAlert').hide('fade');
            $('#frequencySumAlert').hide('fade');
            saveData('addpackageFrequency');
        }
        else {
            $('#frequencySumAlert').show('fade');
            setTimeout(function () {
                $('#frequencySumAlert').hide('fade');
            }, 5000);
        }


    });


    var table = $("#packageFrequencyList").DataTable({
        //"processing": true, // for show progress bar
        //"serverSide": true, // for process server side
        //"filter": true, // this is for disable filter (search box)
        //"orderMulti": false, // for disable multiple column at once
        //"ajax": {
        //    "url": "gridView",
        //    "type": "POST",
        //    "datatype": "json",
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
            { "data": "Day_frequency_ID", "class": "Day_frequency_ID", "name": "Day_frequency_ID", "autoWidth": true, "visible": false },
            { "data": "Customer_Code", "name": "Customer_Code ID", "class": "Customer_Code", "autoWidth": true, "visible": false },

            { "data": "Name1", "name": "Name1", "class": "Name1", "autoWidth": true },
            { "data": "Package_ID", "name": "Package ID", "class": "PackageID", "autoWidth": true, "visible": false },
            { "data": "PackageName", "name": "PackageName", "class": "PackageName", "autoWidth": true },

            { "data": "Monday", "name": "Monday", "class": "Monday", "autoWidth": true },
            { "data": "Tuesday", "name": "Tuesday", "class": "Tuesday", "autoWidth": true },
            { "data": "Wednesday", "name": "Wednesday", "class": "Wednesday", "autoWidth": true },
            { "data": "Thursday", "name": "Thursday", "class": "Thursday", "autoWidth": true },
            { "data": "Friday", "name": "Friday", "class": "Friday", "autoWidth": true },
            { "data": "Saturday", "name": "Saturday", "class": "Saturday", "autoWidth": true },
            { "data": "Sunday", "name": "Sunday", "class": "Sunday", "autoWidth": true },
            {
                "defaultContent": "<button id='click' class='btn btn-primary m-t-6 waves-effect'>Update!</button>"
            }
        ]
    });
    $('#packageFrequencyList tbody').on('click', 'button', function () {

        var currentRow = $(this).closest("tr");

        var data = $('#packageFrequencyList').DataTable().row(currentRow).data();

        var updateDay_frequency_ID = (data['Day_frequency_ID']);

        //  var data = table.row($(this).parents("tr")).data();
        var updateCustomerCode = (data['Customer_Code']);
        var updatePackageID = (data['PackageID']);
        var updateMondayFrequency = $(this).closest("tr").find(".Monday").text();
        var updateTuesdayFrequency = $(this).closest("tr").find(".Tuesday").text();
        var updateWednesdayFrequency = $(this).closest("tr").find(".Wednesday").text();
        var updateThursdayFrequency = $(this).closest("tr").find(".Thursday").text();
        var updateFridayFrequency = $(this).closest("tr").find(".Friday").text();
        var updateSaturdayFrequency = $(this).closest("tr").find(".Saturday").text();
        var updateSundayFrequency = $(this).closest("tr").find(".Sunday").text();



        $('#largeModal').modal();
        //$("#largeModal").modal();
        if (parseInt(updateMondayFrequency) != 0) {
            $('#dvMondayFrequencyUpdate').show('fade');
            $('#chkMondayUpdate').prop('checked', true);
        }
        if (parseInt(updateTuesdayFrequency) != 0) {
            $('#dvTuesdayFrequencyUpdate').show('fade');
            $('#chkTuesdayUpdate').prop('checked', true);
        }
        if (parseInt(updateWednesdayFrequency) != 0) {
            $('#dvWednesdayFrequencyUpdate').show('fade');
            $('#chkWednesdayUpdate').prop('checked', true);
        }
        if (parseInt(updateThursdayFrequency) != 0) {
            $('#dvThursdayFrequencyUpdate').show('fade');
            $('#chkThursdayUpdate').prop('checked', true);
        }
        if (parseInt(updateFridayFrequency) != 0) {
            $('#dvFridayFrequencyUpdate').show('fade');
            $('#chkFridayUpdate').prop('checked', true);
        }
        if (parseInt(updateSaturdayFrequency) != 0) {
            $('#dvSaturdayFrequencyUpdate').show('fade');
            $('#chkSaturdayUpdate').prop('checked', true);
        }
        if (parseInt(updateSundayFrequency) != 0) {
            $('#dvSundayFrequencyUpdate').show('fade');
            $('#chkSundayUpdate').prop('checked', true);
        }

        $("#IMcode").val(updateCustomerCode);


        $("#txtDayfrequencyIDUpdate").val(updateDay_frequency_ID);
        $("#dropDownCustomerUpdate").val(updateCustomerCode);
        $("#dropDownPackageUpdate").val(updatePackageID);
        $("#txtMondayFrequencyUpdate").val(updateMondayFrequency);
        $("#txtTuesdayFrequencyUpdate").val(updateTuesdayFrequency);
        $("#txtWednesdayFrequencyUpdate").val(updateWednesdayFrequency);
        $("#txtThursdayFrequencyUpdate").val(updateThursdayFrequency);
        $("#txtFridayFrequencyUpdate").val(updateFridayFrequency);
        $("#txtSaturdayFrequencyUpdate").val(updateSaturdayFrequency);
        $("#txtSundayFrequencyUpdate").val(updateSundayFrequency);
    });


    $('#chkMonday').click(function () {
        $('#dvMondayFrequency')[this.checked ? "show" : "hide"]('fade');
    });
    $('#chkTuesday').click(function () {
        $('#dvTuesdayFrequency')[this.checked ? "show" : "hide"]('fade');
    });
    $('#chkWednesday').click(function () {
        $('#dvWednesdayFrequency')[this.checked ? "show" : "hide"]('fade');
    });
    $('#chkThursday').click(function () {
        $('#dvThursdayFrequency')[this.checked ? "show" : "hide"]('fade');
    });
    $('#chkFriday').click(function () {
        $('#dvFridayFrequency')[this.checked ? "show" : "hide"]('fade');
    });
    $('#chkSaturday').click(function () {
        $('#dvSaturdayFrequency')[this.checked ? "show" : "hide"]('fade');
    });
    $('#chkSunday').click(function () {
        $('#dvSundayFrequency')[this.checked ? "show" : "hide"]('fade');
    });


    //update Modal Code


    $('#chkMondayUpdate').click(function () {
        $('#dvMondayFrequencyUpdate')[this.checked ? "show" : "hide"]('fade');
    });
    $('#chkTuesdayUpdate').click(function () {
        $('#dvTuesdayFrequencyUpdate')[this.checked ? "show" : "hide"]('fade');
    });
    $('#chkWednesdayUpdate').click(function () {
        $('#dvWednesdayFrequencyUpdate')[this.checked ? "show" : "hide"]('fade');
    });
    $('#chkThursdayUpdate').click(function () {
        $('#dvThursdayFrequencyUpdate')[this.checked ? "show" : "hide"]('fade');
    });
    $('#chkFridayUpdate').click(function () {
        $('#dvFridayFrequencyUpdate')[this.checked ? "show" : "hide"]('fade');
    });
    $('#chkSaturdayUpdate').click(function () {
        $('#dvSaturdayFrequencyUpdate')[this.checked ? "show" : "hide"]('fade');
    });
    $('#chkSundayUpdate').click(function () {
        $('#dvSundayFrequencyUpdate')[this.checked ? "show" : "hide"]('fade');
    });



    //multiselect searchable dropdown starts


    $(".js-select2").select2({
        closeOnSelect: false,
        placeholder: "Placeholder",
        allowHtml: true,
        allowClear: true,
        tags: true // создает новые опции на лету
    });



    function matchCustom(params, data) {
        // If there are no search terms, return all of the data
        if ($.trim(params.term) === '') {
            return data;
        }

        // Do not display the item if there is no 'text' property
        if (typeof data.text === 'undefined') {
            return null;
        }

        // `params.term` should be the term that is used for searching
        // `data.text` is the text that is displayed for the data object
        if (data.text.indexOf(params.term) > -1) {
            var modifiedData = $.extend({}, data, true);
            modifiedData.text += ' (matched)';

            // You can return modified objects from here
            // This includes matching the `children` how you want in nested data sets
            return modifiedData;
        }

        // Return `null` if the term should not be displayed
        return null;
    }

    $(".js-select2").select2({
        matcher: matchCustom
    });

    //multiselect searchable dropdown ends



});


function UpdatePackageFrequency(url) {

    Mondayup = $('#txtMondayFrequencyUpdate').val();
    Tuesdayup = $('#txtTuesdayFrequencyUpdate').val();
    Wednesdayup = $('#txtWednesdayFrequencyUpdate').val();
    Thursdayup = $('#txtThursdayFrequencyUpdate').val();
    Fridayup = $('#txtFridayFrequencyUpdate').val();
    Saturdayup = $('#txtSaturdayFrequencyUpdate').val();
    Sundayup = $('#txtSundayFrequencyUpdate').val();

    var dataToPost = '{"PackageFrequencyID":"' + $("#txtDayfrequencyIDUpdate").val() + '","packageID":"' + $("#dropDownPackageUpdate").val() + '","customerCode":"' + $("#dropDownCustomerUpdate").val() + '" , "monday":"' + Mondayup + '", "tuesday":"' + Tuesdayup + '", "wednesday":"' + Wednesdayup + '", "thursday":"' + Thursdayup + '", "friday":"' + Fridayup + '", "saturday":"' + Saturdayup + '", "sunday":"' + Sundayup + '"}';
    console.log(dataToPost);
    Common.Ajax('POST', url, dataToPost, 'json', successPackageFrequencyUpdateCreateHandler);
}

//function EditRoles(ID, de) {
//    var id = $(this).closest("tr").find(".Order_Desc").text();

//}





function BindDropDown(url) {
    Common.Ajax('GET', url, {}, 'json', BindDropDownHandler);
}
function BindDropDownPackageEdit(url) {
    Common.Ajax('GET', url, {}, 'json', BindDropDownPackageEditHandler);
}

function BindDropDownCustomer(url) {
    Common.Ajax('GET', url, {}, 'json', BindDropDownHandlerCustomer);
}
function BindDropDownCustomerEdit(url) {
    Common.Ajax('GET', url, {}, 'json', BindDropDownHandlerCustomerEdit);
}
function saveData(url) {


    //var mon = $('#chkMonday').prop('checked') ? 1 : 0;
    //var tue = $('#chkTuesday').prop('checked') ? 1 : 0;
    //var wed = $('#chkWednesday').prop('checked') ? 1 : 0;
    //var thu = $('#chkThursday').prop('checked') ? 1 : 0;
    //var fri = $('#chkFriday').prop('checked') ? 1 : 0;
    //var sat = $('#chkSaturday').prop('checked') ? 1 : 0;
    //var sun = $('#chkSunday').prop('checked') ? 1 : 0;
    Monday = $('#txtMondayFrequency').val();
    Tuesday = $('#txtTuesdayFrequency').val();
    Wednesday = $('#txtWednesdayFrequency').val();
    Thursday = $('#txtThursdayFrequency').val();
    Friday = $('#txtFridayFrequency').val();
    Saturday = $('#txtSaturdayFrequency').val();
    Sunday = $('#txtSundayFrequency').val();
    //var arrayMonday = [mon, Monday];
    //var arrayTuesday = [tue, Tuesday];
    //var arrayWednesday = [wed, Wednesday];
    //var arrayThursday = [thu, Thursday];
    //var arrayFriday = [fri, Friday];
    //var arraySaturday = [sat, Saturday];
    //var arraySunday = [sun, Sunday];

    //var array = new array();

    ////$("#dropDownCustomer").each(function () {
    //    //var chk = $('#idd').attr('checked') ? 1 : 0;
    //    //if (chk == 1)
    //    //{
    //    //var row = $(this);
    //    //var customer = {};
    //    //customer.Customer_Code = row.closest("tr").find(".Customer_Code").text();

    //    //}

    //    customers.push(package_ID, customer);
    //});

    var dataToPost = '{"packageID":"' + $("#dropDownPackage").val() + '","customerCode":"' + $("#dropDownCustomer").val() + '" , "monday":"' + Monday + '", "tuesday":"' + Tuesday + '", "wednesday":"' + Wednesday + '", "thursday":"' + Thursday + '", "friday":"' + Friday + '", "saturday":"' + Saturday + '", "sunday":"' + Sunday + '"}';
    console.log(dataToPost);
    Common.Ajax('POST', url, dataToPost, 'json', successUserCreateHandler);

}

function successUserCreateHandler(response) {
    $('#dropDownPackage').val(-1);
    $('#txtCustomerCode ').val('');
    $('#dropDownCustomer').val(-1);

    // $("#dropDownCustomer").trigger("reset");

    $('#chkMonday').prop('checked', false);
    $('#chkTuesday').prop('checked', false);
    $('#chkWednesday').prop('checked', false);
    $('#chkThursday').prop('checked', false);
    $('#chkFriday').prop('checked', false);
    $('#chkSaturday').prop('checked', false);
    $('#chkSunday').prop('checked', false);
    $('#txtMondayFrequency ').val('');
    $('#txtTuesdayFrequency ').val('');
    $('#txtWednesdayFrequency ').val('');
    $('#txtThursdayFrequency ').val('');
    $('#txtFridayFrequency ').val('');
    $('#txtSaturdayFrequency ').val('');
    $('#txtSundayFrequency ').val('');
    $('#dvMondayFrequency ').hide('fade');
    $('#dvTuesdayFrequency ').hide('fade');
    $('#dvWednesdayFrequency ').hide('fade');
    $('#dvThursdayFrequency ').hide('fade');
    $('#dvFridayFrequency ').hide('fade');
    $('#dvSaturdayFrequency ').hide('fade');
    $('#dvSundayFrequency ').hide('fade');
    $('#packageFrequencyList').DataTable().ajax.reload();

    if (response == '1') {


        $('#packageFrequencyList').DataTable().ajax.reload();
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

function successPackageFrequencyUpdateCreateHandler(response) {
    $('#dropDownPackage').val(-1);
    $('#txtCustomerCode ').val('');
    $('#chkMonday').prop('checked', false);
    $('#chkTuesday').prop('checked', false);
    $('#chkWednesday').prop('checked', false);
    $('#chkThursday').prop('checked', false);
    $('#chkFriday').prop('checked', false);
    $('#chkSaturday').prop('checked', false);
    $('#chkSunday').prop('checked', false);
    $('#txtMondayFrequency ').val('');
    $('#txtTuesdayFrequency ').val('');
    $('#txtWednesdayFrequency ').val('');
    $('#txtThursdayFrequency ').val('');
    $('#txtFridayFrequency ').val('');
    $('#txtSaturdayFrequency ').val('');
    $('#txtSundayFrequency ').val('');
    $('#dvMondayFrequency ').hide('fade');
    $('#dvTuesdayFrequency ').hide('fade');
    $('#dvWednesdayFrequency ').hide('fade');
    $('#dvThursdayFrequency ').hide('fade');
    $('#dvFridayFrequency ').hide('fade');
    $('#dvSaturdayFrequency ').hide('fade');
    $('#dvSundayFrequency ').hide('fade');
    $('#packageFrequencyList').DataTable().ajax.reload();

    if (response == '2') {

        $('#packageFrequencyList').DataTable().ajax.reload();
        $('#successAlertUpdate').show('fade');

        setTimeout(function () {
            $('#successAlertUpdate').hide('fade');
        }, 5000);
    }
    if (response == '-2') {

        $('#warningAlertUpdate').show('fade');

        setTimeout(function () {
            $('#warningAlertUpdate').hide('fade');
        }, 5000);
    }
}

function BindDropDownHandler(response) {
    var s = '<option value="-1">Please Select a Package</option>';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].Package_ID + '">' + response[i].PackageName + '</option>';
    }
    $("#dropDownPackage").html(s);
}
function BindDropDownPackageEditHandler(response) {
    var s = '<option value="-1"></option>';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].Package_ID + '">' + response[i].PackageName + '</option>';
    }
    $("#dropDownPackageUpdate").html(s);
}

function BindDropDownHandlerCustomer(response) {
    var s = '<option value="-1"></option>';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].Customer + '">' + response[i].Name1 + '</option>';
    }
    $("#dropDownCustomer").html(s);
}
function BindDropDownHandlerCustomerEdit(response) {
    var s = '<option value="-1"></option>';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].Customer + '">' + response[i].Name1 + '</option>';
    }
    $("#dropDownCustomerUpdate").html(s);
}

function EditRoles(RoleID) {
    var url = "";
    $("#largeModal").modal();
}






