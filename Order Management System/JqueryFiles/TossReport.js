$(document).ready(function () {

    $('#btnRetrieve').click(function () {
        var drpCustomer = $('#drpCustomer :selected').val();
        var drpRegion = $('#drpRegion :selected').val();
        var drpBrand = $('#drpBrand :selected').val();
        var drpSKU = $('#drpSKU :selected').val();

        $('#divLoader').fadeIn();

        $("#DayWiseShipmentReport").DataTable().destroy();
        var table = $("#DayWiseShipmentReport").DataTable({

            "ajax": {
                "url": "TossReport",
                "type": "GET",
                "data": { Customer: drpCustomer, Region: drpRegion, Material: drpBrand, SKU: drpSKU },
                "datatype": "application/json",
                "processing": true, // for show progress bar
                "serverSide": true, // for process server side
                "filter": true, // this is for disable filter (search box)
                "orderMulti": true, // for disable multiple column at once
                "dataSrc": "",
            },
            "columns": [
                { "data": "OrderRefrenceNumber", "class": "OrderRefrenceNumber", "name": "OrderRefrenceNumber", "autoWidth": true },
                { "data": "Material", "class": "Material", "name": "Material", "autoWidth": true },
                { "data": "Description", "class": "Description", "name": "Description", "autoWidth": true },
                { "data": "customer", "class": "customer", "name": "customer", "autowidth": true },
                { "data": "SalesOrganization", "class": "SalesOrganization", "name": "SalesOrganization", "autoWidth": true },
                { "data": "RegionDescription", "class": "RegionDescription", "name": "RegionDescription", "autoWidth": true },
                { "data": "Division", "class": "Division", "name": "Division", "autoWidth": true },
                { "data": "SKUMapping", "class": "SKUMapping", "name": "SKUMapping", "autoWidth": true },
                { "data": "FirmOrder", "class": "FirmOrder", "name": "FirmOrder", "autowidth": true },
                { "data": "Monday", "class": "Monday", "name": "Monday", "autowidth": true },
                { "data": "Tuesday", "class": "Tuesday", "name": "Tuesday", "autowidth": true },
                { "data": "Wednesday", "class": "Wednesday", "name": "Wednesday", "autoWidth": true },
                { "data": "Thursday", "class": "Thursday", "name": "Thursday", "autoWidth": true },
                { "data": "Friday", "class": "Friday", "name": "Friday", "autoWidth": true },
                { "data": "Saturday", "class": "Saturday", "name": "Saturday", "autowidth": true },
                { "data": "Sunday", "class": "Sunday", "name": "Sunday", "autowidth": true },

            ]

        });
        $('#divLoader').fadeOut();
    });
});
