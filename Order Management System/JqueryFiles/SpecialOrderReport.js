$(document).ready(function () {

    $('#btnRetrieve').click(function () {
        var drpCustomer = $('#drpCustomer :selected').val();
        var drpRegion = $('#drpRegion :selected').val();
        var drpBrand = $('#drpBrand :selected').val();
        var drpSKU = $('#drpSKU :selected').val();


        var drpSalesOrg = $('#drpSalesOrg :selected').val();
        var drpArea = $('#drpArea :selected').val();
        var drpTown = $('#drpTown :selected').val();
        var drpTerritory = $('#drpTerritory :selected').val();

        var drpPlant = $('#drpPlant :selected').val();
        var drpMatGrp1 = $('#drpMatGrp1 :selected').val();
        var drpMatGrp2 = $('#drpMatGrp2 :selected').val();
        var drpMatGrp3 = $('#drpMatGrp3 :selected').val();
        var drpMatGrp4 = $('#drpMatGrp4 :selected').val();



        if ($('#StartDate').val() != "") {
            StartDate = $('#StartDate').val();
        }
        else {
            StartDate = "";
        }
        if ($('#EndDate').val() != "") {
            EndDate = $('#EndDate').val();
        }
        else {
            EndDate = "";
        }

        $('#divLoader').fadeIn();

        $("#SpecialOrderReport").DataTable().destroy();
        var table = $("#SpecialOrderReport").DataTable({

            "ajax": {
                "url": "GetSpecialOrderReport",
                "type": "GET",
                "data": { Customer: drpCustomer, Region: drpRegion, Brand: drpBrand, SKU: drpSKU, SalesOrg: drpSalesOrg,
                    Area: drpArea, Town: drpTown, Territory: drpTerritory, Plant: drpPlant, MatGrp1: drpMatGrp1,
                    MatGrp2: drpMatGrp2, MatGrp3: drpMatGrp3, MatGrp4: drpMatGrp4, StartDate: StartDate, EndDate: EndDate  },
                "datatype": "application/json",
                "processing": true, // for show progress bar
                "serverSide": true, // for process server side
                "filter": true, // this is for disable filter (search box)
                "orderMulti": true, // for disable multiple column at once
                "dataSrc": "",
            },
            "columns": [
                { "data": "SP_Order_ID", "class": "SP_Order_ID", "name": "SP_Order_ID", "autoWidth": true },
                { "data": "Customer", "class": "Customer", "name": "Customer", "autoWidth": true },
                { "data": "Material", "class": "Material", "name": "Material", "autoWidth": true },
                { "data": "Description", "class": "Description", "name": "Description", "autoWidth": true },
                { "data": "SalesOrganization", "class": "SalesOrganization", "name": "SalesOrganization", "autoWidth": true },
                { "data": "Division", "class": "Division", "name": "Division", "autowidth": true },
                { "data": "RegionDescription", "class": "RegionDescription", "name": "RegionDescription", "autoWidth": true },
                { "data": "Quantity", "class": "Quantity", "name": "Quantity", "autowidth": true },

            ]

        });
        $('#divLoader').fadeOut();
    });
});
