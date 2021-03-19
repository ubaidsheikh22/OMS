var val = $('#drpRegion').val() == "-1" || null ? "" : $('#drpRegion').val();
$(document).ready(function () {

    getRegions();

    $('#bttnUplift').click(function () {
        if (($('#drpRegion').val() == '-1') || ($('#drpRegion').val() == null) || ($('#drpRegion').val() == '') || ($('#drpRegion').val() == "null")){
            alert("Kindly Select the Region First");
            return false;
        }
        else {
            saveData('AddWeeklyUplift');
        }
    });

    $('#redirect').click(function () {

        window.location.href = "/dashboard/dashboard";
    });

    $("#drpRegion").change(function () {
        var rol = $('#drpRegion').val();
        $.ajax({
            type: "POST",
            url: "getAllCustomers",
            data: { regionCode: rol },
            datatype: "json",
            traditional: true,
            beforeSend: function () {
                setTimeout(function () {
                    $("#divLoader").show();
                }, 1);
            },
            complete: function (data) {
                $("#divLoader").hide();
            },

            success: function (data) {
                var s1 = '<option value=""></option>';
                for (var i = 0; i < data.length; i++) {

                    var CustomerName = isNaN(parseInt(data[i].Customer)) ? data[i].Name1 : data[i].Name1 + ' (' + parseInt(data[i].Customer) + ')';
                    s1 += '<option value="' + data[i].Customer + '">' + CustomerName + '</option>';
                }
                $("#dropDownCustomer").html(s1);
            }

        });
    });

    $("#MaterialList").DataTable({
        "ajax": {
            "url": "GetGrid",
            "type": "POST",
            "datatype": "json",

            "processing": true, // for show progress bar

            "serverSide": false, // for process server side
            "filter": true, // this is for disable filter (search box)
            "orderMulti": true, // for disable multiple column at once
            "dataSrc": "",

        },

        "columns": [
            { "data": "Material", "name": "Material", "class": "Material", "autoWidth": true },
            { "data": "Description", "class": "Description", "name": "Description", "autoWidth": true },
            { "defaultContent": "<input type='text' id='txtUpliftPercentage' class='form-control' placeholder='Enter Uplift Percentage' min='0' onkeypress='return checkUplift(event);'>" }
        ]
    });

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

function getRegions() {
    Common.Ajax('GET', '/customer/GetRegion',
        //{ name, salesorg, div, category, region, area, territory, town, plant },
        null,
        'json', getRegionHandler);
}

function getRegionHandler(response) {
    outputArray = [];
    var s = '<option value="-2">National</option>';//<option value="-1">Region</option>';
    for (var i = 0; i < response.length; i++) {

        if ((jQuery.inArray(response[i], outputArray)) == -1) {
            s += '<option value="' + response[i].RegionCode + '">' + response[i].RegionDescription + '</option>';
        }
    }

    $("#drpRegion").html(s);
    $("#drpRegion").select2();
}

function saveData(url) {

    var customers = $('#dropDownCustomer').val();
    var UpliftListModal = new Array();

    if (customers !== null) {

        $.each(customers, function (index, value) {

            $("#MaterialList TBODY TR").each(function () {
                var row = $(this);
                var UpliftModel = {};
                UpliftModel.Customer = value;
                UpliftModel.Region = $('#drpRegion').val();
                UpliftModel.Material = row.find("TD").eq(0).html();
                UpliftModel.Percentage = row.find('#txtUpliftPercentage').val();

                if (UpliftModel.Percentage !== "") {
                    UpliftListModal.push(UpliftModel);
                }

            });
        });
    }
    else {
        $("#MaterialList TBODY TR").each(function () {
            var row = $(this);
            var UpliftModel = {};
            UpliftModel.Customer = "";
            UpliftModel.Region = $('#drpRegion').val();
            UpliftModel.Material = row.find("TD").eq(0).html();
            UpliftModel.Percentage = row.find('#txtUpliftPercentage').val();
            if (UpliftModel.Percentage !== "") {
                UpliftListModal.push(UpliftModel);
            }

        });
    }
    var dataToPost = JSON.stringify(UpliftListModal);
    Common.Ajax('POST', url, dataToPost, 'json', successWeeklyUpliftCreateHandler);
 //window.location.reload();
}

function successWeeklyUpliftCreateHandler(response) {

    if (response == '1') {

        $('#drpRegion').val('-1');
        $('#dropDownCustomer').val('');
        //$('.form-control').val('');
        $('#successAlert').show('fade');

        setTimeout(function () {
            $('#successAlert').hide('fade');
            
        }, 6000);
        $('#MaterialList').DataTable().ajax.refresh();
       

    }
    
    if (response == '-1') {
        $('#warningAlert').show('fade');

        setTimeout(function () {
            $('#warningAlert').hide('fade');
        }, 6000);
        $('#MaterialList').DataTable.ajax.reload();
    }

  
}


function checkUplift(e) {
    /*
      8 - (backspace)
      32 - (space)
      48-57 - (0-9)Numbers
      97-122 - (a-z)Small Alphabets
      65-90 - (A-Z)Capital Alphabets
    */
    var KeyID = (window.event) ? event.keyCode : e.keyCode;

    if ((KeyID == 8) || (KeyID == 9) || (KeyID == 13) || (KeyID >= 48 && KeyID <= 57)) {

        var newChar = String.fromCharCode(e.keyCode);
        var oldVal = $(e.target).val();
        var total = parseInt(oldVal + newChar)
        if (isNaN(oldVal + newChar) && oldVal != '')
            return false;
        else if (total < 0 || total > 100)
            return false;

        return true;
    }
    else {
        return false;
    }
}