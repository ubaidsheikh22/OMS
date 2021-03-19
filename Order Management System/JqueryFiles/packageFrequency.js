/// <reference path="GenericAjax.js" />

$(document).ready(function () {
    BindDropDownRegion('getRegions');
    //BindDropDown('getAllPackages');
    BindDropDownPackageEdit('getAllPackages');
    //BindDropDownCustomer('getAllCustomers');
    BindDropDownCustomerEdit('getAllCustomers');

    $('#bttnUpdatePackageFrequency').click(function () {

        var frequencyMondayUp = $('#dvMondayFrequencyUpdate').is(':visible') ? $('#txtMondayFrequencyUpdate').val() : 0;
        var frequencyTuesdayUp = $('#dvTuesdayFrequencyUpdate').is(':visible') ? $('#txtTuesdayFrequencyUpdate').val() : 0;
        var frequencyWednesdayUp = $('#dvWednesdayFrequencyUpdate').is(':visible') ? $('#txtWednesdayFrequencyUpdate').val() : 0;
        var frequencyThursdayUp = $('#dvThursdayFrequencyUpdate').is(':visible') ? $('#txtThursdayFrequencyUpdate').val() : 0;
        var frequencyFridayUp = $('#dvFridayFrequencyUpdate').is(':visible') ? $('#txtFridayFrequencyUpdate').val() : 0;
        var frequencySaturdayUp = $('#dvSaturdayFrequencyUpdate').is(':visible') ? $('#txtSaturdayFrequencyUpdate').val() : 0;
        var frequencySundayUp = $('#dvSundayFrequencyUpdate').is(':visible') ? $('#txtSundayFrequencyUpdate').val() : 0;
        var totalfrequencyUp = parseInt(frequencyMondayUp) + parseInt(frequencyTuesdayUp) + parseInt(frequencyWednesdayUp) + parseInt(frequencyThursdayUp) + parseInt(frequencyFridayUp) + parseInt(frequencySaturdayUp) + parseInt(frequencySundayUp);
        if (totalfrequencyUp == 100) {
            $('#successAlertUpdate').hide('fade');
            $('#warningAlertUpdate').hide('fade');
            $('#frequencySumAlertUpdate').hide('fade');
            UpdatePackageFrequency('UpdatePackageFrequency');
        }
        else {
            $('#frequencySumAlertUpdate').show('fade');
            $('#frequencySumAlertUpdate').focus();
            setTimeout(function () {
                $('#frequencySumAlertUpdate').hide('fade');
            }, 5000);
        }
    });

    $('#redirect').click(function () {

        window.location.href = "/dashboard/dashboard";
    });

    $('#bttnAddPackageFrequency').click(function () {

        var frequencyMonday = $('#dvMondayFrequency').is(':visible') ? $('#txtMondayFrequency').val() : 0;
        var frequencyTuesday = $('#dvTuesdayFrequency').is(':visible') ? $('#txtTuesdayFrequency').val() : 0;
        var frequencyWednesday = $('#dvWednesdayFrequency').is(':visible') ? $('#txtWednesdayFrequency').val() : 0;
        var frequencyThursday = $('#dvThursdayFrequency').is(':visible') ? $('#txtThursdayFrequency').val() : 0;
        var frequencyFriday = $('#dvFridayFrequency').is(':visible') ? $('#txtFridayFrequency').val() : 0;
        var frequencySaturday = $('#dvSaturdayFrequency').is(':visible') ? $('#txtSaturdayFrequency').val() : 0;
        var frequencySunday = $('#dvSundayFrequency').is(':visible') ? $('#txtSundayFrequency').val() : 0;
        var totalfrequency = parseInt(frequencyMonday) + parseInt(frequencyTuesday) + parseInt(frequencyWednesday) + parseInt(frequencyThursday) + parseInt(frequencyFriday) + parseInt(frequencySaturday) + parseInt(frequencySunday);
        console.log(totalfrequency);
        if ($("#drpRegions").val() == "-1") {
            alert("Region must be defined");
        } else if ($("#drpArea").val() == "-1") {
            alert("Area must be defined");
        }
        else if ($("#drpTerritory").val() == "-1") {
            alert("Territory must be defined");
        }
        else if ($("#drpTown").val() == "-1") {
            alert("Town must be defined");
        }
        else if ($("#dropDownCustomer").val() == "-1") {
            alert("Customer must be defined");
        }
        else if (totalfrequency == 100) {
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

        "ajax": {
            "url": "gridView",
            "type": "POST",
            "datatype": "json",
            "processing": true, // for show progress bar
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
                //"defaultContent": "<button id='click' class='btn btn-primary m-t-6 waves-effect'>Update!</button>"
                data: null, render: function (data, type, row) {
                    //return "<a href='#' class='btn btn-danger' onclick=DeleteData('" + row.CustomerID + "'); >Delete</a>";
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
                    columns: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                }
            },


            {
                extend: 'csv',
                autoFilter: true,
                exportOptions: {
                    columns: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                }
            },
            {
                extend: 'pdf',
                autoFilter: true,
                exportOptions: {
                    columns: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                }
            },
            {
                extend: 'print',
                autoFilter: true,
                exportOptions: {
                    columns: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                }
            },
            {
                extend: 'copy',
                autoFilter: true,
                exportOptions: {
                    columns: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                }
            },

        ],

    });
    $('#packageFrequencyList tbody').on('click', 'button', function () {

        var currentRow = $(this).closest("tr");

        var data = $('#packageFrequencyList').DataTable().row(currentRow).data();

        var updateDay_frequency_ID = (data['Day_frequency_ID']);

        var updateCustomerCode = (data['Customer_Code']);
        var CustomerName = (data['Name1']);
        var updatePackageID = (data['PackageName']);
        var updateMondayFrequency = $(this).closest("tr").find(".Monday").text();
        var updateTuesdayFrequency = $(this).closest("tr").find(".Tuesday").text();
        var updateWednesdayFrequency = $(this).closest("tr").find(".Wednesday").text();
        var updateThursdayFrequency = $(this).closest("tr").find(".Thursday").text();
        var updateFridayFrequency = $(this).closest("tr").find(".Friday").text();
        var updateSaturdayFrequency = $(this).closest("tr").find(".Saturday").text();
        var updateSundayFrequency = $(this).closest("tr").find(".Sunday").text();

        $('#largeModal').modal();
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


        $("#txtDayfrequencyIDUpdate").val(updateDay_frequency_ID);
        $("#CustomerUpdate").val(updateCustomerCode);
        $("#largeModalLabel").html("Dispatch Frequency - " + CustomerName);
        //alert(CustomerName);

        $("#PackageUP").val(updatePackageID);
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

    $("#drpRegions").change(function () {
        var rol = $('#drpRegions').val();
        //console.log(rol);
        // $('#txtDistributorID').html('');
        $.ajax({
            type: "POST",
            url: "getAllArea?regionCode=" + rol,
            data: { regionCode: rol },
            datatype: "json",
            traditional: true,
            success: function (data) {
                var s1 = '<option value="-1">Select Area</option>';
                for (var i = 0; i < data.length; i++) {
                    s1 += '<option value="' + data[i].AreaCode + '">' + data[i].AreaDesc + '</option>';
                }
                $("#drpArea").html(s1);
            }
        });
    });


    $("#drpArea").change(function () {
        var rol = $('#drpArea').val();
        $.ajax({
            type: "POST",
            url: "getAllTerritory?AreaCode=" + rol,
            data: { AreaCode: rol },
            datatype: "json",
            traditional: true,
            success: function (data) {
                var s1 = '<option value="-1">Select Territory</option>';
                for (var i = 0; i < data.length; i++) {
                    s1 += '<option value="' + data[i].TerritoryCode + '">' + data[i].TerritoryDesc + '</option>';
                }
                $("#drpTerritory").html(s1);
            }

        });
    });

    $("#drpTerritory").change(function () {
        var rol = $('#drpTerritory').val();
        $.ajax({
            type: "POST",
            url: "getAllTown?TerritoryCode=" + rol,
            data: { TerritoryCode: rol },
            datatype: "json",
            traditional: true,
            success: function (data) {
                var s1 = '<option value="-1">Select Town</option>';
                for (var i = 0; i < data.length; i++) {
                    s1 += '<option value="' + data[i].TownCode + '">' + data[i].TownDesc + '</option>';
                }
                $("#drpTown").html(s1);
            }

        });
    });

    $('#drpTown').change(function () {
        var Region = $('#drpRegions').val();
        var Area = $('#drpArea').val();
        var Territory = $('#drpTerritory').val();
        var Town = $('#drpTown').val();
        $('#dropDownCustomer').html('');
        $.ajax({
            type: "post",
            url: "/Login/GetDistrict",
            data: {
                Region: Region,
                Area: Area,
                Territory: Territory,
                Town: Town
            },
            datatype: "json",
            traditional: true,
            success: function (data) {
                var s1;
                for (var i = 0; i < data.length; i++) {
                    var CustomerName = isNaN(parseInt(data[i].Distributor_ID)) ? data[i].Distributor_Name : data[i].Distributor_Name + ' (' + parseInt(data[i].Distributor_ID) + ')';
                    s1 += '<option value="' + data[i].Distributor_ID + '">' + CustomerName + '</option>';
                }
                $("#dropDownCustomer").html(s1);
            }
        });
    });

    $('#dropDownCustomer').change(function () {
        var customerCode = $('#dropDownCustomer').val();

        $.ajax({
            type: "post",
            url: "GetPackage",
            data: {
                Customer: customerCode,
            },
            datatype: "json",
            traditional: true,
            success: function (data) {
                $('#Package').val(data[0].PackageName);
            }
        });
    });
});


function UpdatePackageFrequency(url) {
    packageName = $("#PackageUP").val();
    Mondayup = $('#dvMondayFrequencyUpdate').is(':visible') ? $('#txtMondayFrequencyUpdate').val() : 0;
    Tuesdayup = $('#dvTuesdayFrequencyUpdate').is(':visible') ? $('#txtTuesdayFrequencyUpdate').val() : 0;
    Wednesdayup = $('#dvWednesdayFrequencyUpdate').is(':visible') ? $('#txtWednesdayFrequencyUpdate').val() : 0;
    Thursdayup = $('#dvThursdayFrequencyUpdate').is(':visible') ? $('#txtThursdayFrequencyUpdate').val() : 0;
    Fridayup = $('#dvFridayFrequencyUpdate').is(':visible') ? $('#txtFridayFrequencyUpdate').val() : 0;
    Saturdayup = $('#dvSaturdayFrequencyUpdate').is(':visible') ? $('#txtSaturdayFrequencyUpdate').val() : 0;
    Sundayup = $('#dvSundayFrequencyUpdate').is(':visible') ? $('#txtSundayFrequencyUpdate').val() : 0;

    var dataToPost = '{"PackageFrequencyID":"' + $("#txtDayfrequencyIDUpdate").val() + '","packageName":"' + packageName + '","customerCode":"' + $("#CustomerUpdate").val() + '" , "monday":"' + Mondayup + '", "tuesday":"' + Tuesdayup + '", "wednesday":"' + Wednesdayup + '", "thursday":"' + Thursdayup + '", "friday":"' + Fridayup + '", "saturday":"' + Saturdayup + '", "sunday":"' + Sundayup + '"}';
    console.log(dataToPost);
    Common.Ajax('POST', url, dataToPost, 'json', successPackageFrequencyUpdateCreateHandler);
}

function BindDropDownRegion(url) {
    Common.Ajax('GET', url, {}, 'json', BindDropDownRegionHandler);
}
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

    Monday = $('#dvMondayFrequency').is(':visible') ? $('#txtMondayFrequency').val() : 0;
    Tuesday = $('#dvTuesdayFrequency').is(':visible') ? $('#txtTuesdayFrequency').val() : 0;
    Wednesday = $('#dvWednesdayFrequency').is(':visible') ? $('#txtWednesdayFrequency').val() : 0;
    Thursday = $('#dvThursdayFrequency').is(':visible') ? $('#txtThursdayFrequency').val() : 0;
    Friday = $('#dvFridayFrequency').is(':visible') ? $('#txtFridayFrequency').val() : 0;
    Saturday = $('#dvSaturdayFrequency').is(':visible') ? $('#txtSaturdayFrequency').val() : 0;
    Sunday = $('#dvSundayFrequency').is(':visible') ? $('#txtSundayFrequency').val() : 0;

    var dataToPost = '{"packageName":"' + $("#Package").val() + '","customerCode":"' + $("#dropDownCustomer").val() + '" , "monday":"' + Monday + '", "tuesday":"' + Tuesday + '", "wednesday":"' + Wednesday + '", "thursday":"' + Thursday + '", "friday":"' + Friday + '", "saturday":"' + Saturday + '", "sunday":"' + Sunday + '"}';
    console.log(dataToPost);
    Common.Ajax('POST', url, dataToPost, 'json', successUserCreateHandler);
}

function successUserCreateHandler(response) {
    $('#dropDownPackage').val(-1);
    $('#dropDownCustomer').html('');
    $('#Package').val('');
    $('#txtCustomerCode ').val(1);
    $('#dropDownCustomer').val(-1);

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

    if (response == '1') {

        $('#packageFrequencyList').DataTable().ajax.reload();
        $('#successAlertUpdate').show('fade');

        setTimeout(function () {
            $('#successAlertUpdate').hide('fade');
        }, 5000);
    }
    if (response == '-1') {

        $('#warningAlertUpdate').show('fade');

        setTimeout(function () {
            $('#warningAlertUpdate').hide('fade');
        }, 5000);
    }
}

function BindDropDownRegionHandler(response) {
    var s = '<option value="-1">Please Select a region</option>';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].RegionCode + '">' + response[i].RegionDesc + '</option>';
    }
    $("#drpRegions").html(s);
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