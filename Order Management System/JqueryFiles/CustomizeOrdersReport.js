
$(document).ready(function () {
    var StartDate = "";
    var EndDate = "";
    $('#redirect').click(function () {
        window.location.href = "/dashboard/dashboard";
    });

    $('#btnRetrieve').click(function () {
        getConfirmedOrderData();
    });

});

function getConfirmedOrderData() {

    var drpCustomer = $('#drpCustomer :selected').val();
    var drpRegion = $('#drpRegion :selected').val();
    var drpBrand = $('#drpBrand :selected').val();
    //var drpSKU = $('#drpSKU :selected').val();


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





    $.ajax({
        type: "GET",
        url: "/ViewReports/GetCustomizeOrdersReport",
        data: {
            Customer: drpCustomer, Region: drpRegion, Brand: drpBrand, SalesOrg: drpSalesOrg,
            Area: drpArea, Town: drpTown, Territory: drpTerritory, Plant: drpPlant, MatGrp1: drpMatGrp1,
            MatGrp2: drpMatGrp2, MatGrp3: drpMatGrp3, MatGrp4: drpMatGrp4, StartDate: StartDate, EndDate: EndDate
        },
        datatype: "json",
        success: function (data) {

            $('#CustomizeOrdersTable').DataTable({
                "destroy": true,
                "processing": true,
                "serverSide": false,
                "filter": true,
                "orderMulti": false,
                "data": data,
                "dataSrc": "",
                beforesend: function () {
                    settimeout(function () {
                        $("#divloader").show();
                    }, 1);
                },
                complete: function (data) {
                    $("#divloader").hide();
                },

                "columns": [
                    { "data": "Order_Ref", "class": "Order_Ref", "name": "Order_Ref", "autoWidth": true },
                    { "data": "CUSTOMER", "class": "CUSTOMER", "name": "CUSTOMER", "autoWidth": true },
                    { "data": "customerName", "class": "customerName", "name": "customerName", "autoWidth": true },
                    { "data": "MATERIAL", "class": "MATERIAL", "name": "MATERIAL", "autoWidth": true },
                    { "data": "Description", "class": "Description", "name": "Description", "autoWidth": true },
                    { "data": "MatPricingGrpDescription", "class": "MatPricingGrpDescription", "name": "MatPricingGrpDescription", "autoWidth": true },
                    { "data": "MaterialGroup1_Description", "class": "MaterialGroup1_Description", "name": "MaterialGroup1_Description", "autoWidth": true },
                    { "data": "MaterialGroup2_Description", "class": "MaterialGroup2_Description", "name": "MaterialGroup2_Description", "autoWidth": true },
                    { "data": "MaterialGroup3_Description", "class": "MaterialGroup3_Description", "name": "MaterialGroup3_Description", "autoWidth": true },
                    { "data": "MaterialGroup4_Description", "class": "MaterialGroup4_Description", "name": "MaterialGroup4_Description", "autoWidth": true },
                    { "data": "SALESORG", "class": "SALESORG", "name": "SALESORG", "autoWidth": true },
                    { "data": "AreaDescription", "class": "AreaDescription", "name": "AreaDescription", "autoWidth": true },
                    { "data": "RegionDescription", "class": "RegionDescription", "name": "RegionDescription", "autoWidth": true },
                    { "data": "TerritoryDescription", "class": "TerritoryDescription", "name": "TerritoryDescription", "autoWidth": true },
                    { "data": "DISTR_CHAN", "class": "DISTR_CHAN", "name": "DISTR_CHAN", "autoWidth": true },
                    { "data": "AcceptedOrder", "class": "AcceptedOrder", "name": "AcceptedOrder", "autoWidth": true },
                    { "data": "SpecialOrder", "class": "SpecialOrder", "name": "SpecialOrder", "autoWidth": true },
                    { "data": "TotalOrders", "class": "TotalOrders", "name": "TotalOrders", "autoWidth": true },
                    { "data": "InTransitOrder", "class": "InTransitOrder", "name": "InTransitOrder", "autoWidth": true },
                    { "data": "Monday", "class": "Monday", "name": "Monday", "autoWidth": true },
                    { "data": "Tuesday", "class": "Tuesday", "name": "Tuesday", "autoWidth": true },
                    { "data": "Wednesday", "class": "Wednesday", "name": "Wednesday", "autoWidth": true },
                    { "data": "Thursday", "class": "Thursday", "name": "Thursday", "autoWidth": true },
                    { "data": "Friday", "class": "Friday", "name": "Friday", "autoWidth": true },
                    { "data": "Saturday", "class": "Saturday", "name": "Saturday", "autoWidth": true },
                    { "data": "Sunday", "class": "Sunday", "name": "Sunday", "autoWidth": true },
                    { "data": "custDATEReport", "class": "custDATEReport", "name": "custDATEReport", "autoWidth": true },

                ]
            });
        }
    });
}



