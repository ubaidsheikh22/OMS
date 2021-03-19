var jsonData = null;
$(document).ready(function () {

    const monthNames = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];

    const d = new Date();
    monthNames[d.getMonth()];

    $('#lb').text(monthNames[d.getMonth()]);

    Date.prototype.getWeek = function () {
        var onejan = new Date(this.getFullYear(), 0, 1);
        var today = new Date(this.getFullYear(), this.getMonth(), this.getDate());
        var dayOfYear = ((today - onejan + 1) / 86400000);
        return Math.ceil(dayOfYear / 7)
    };

    jQuery(function () {
        var today = new Date();
        var weekno = today.getWeek();
        $("#lb2").html(weekno);
    });

    $('#bttnInsertOrder').click(function () {
        saveData('Insert');
        var list = $('#list').DataTable().clear().draw();


    });

    $('#bttnRejectOrder').click(function () {
        saveRejectedData('Insert');
    });

    $('#redirect').click(function () {
        window.location.href = "/dashboard/dashboard";
    });
    var table = $("#list").DataTable({
        "ajax": {
            "url": "gridView",
            "type": "POST",
            "datatype": "json",
            "processing": true, // for show progress bar
            "serverSide": false, // for process server side
            "filter": true, // this is for disable filter (search box)
            "orderMulti": true, // for disable multiple column at once
            "dataSrc": function (json) {
                //Make your callback here.
                jsonData = json;
                return json;
            },
            beforeSend: function () {
                setTimeout(function () {
                    $("#divLoader").show();
                }, 1);
            },
            complete: function (data) {

                $("#divLoader").hide();
            },
        },

        "columns": [
            { "data": "OrderRefrenceNumber", "class": "OrderRefrenceNumber", "name": "OrderRefrenceNumber", "autoWidth": true },
            { "data": "CALDAY", "class": "CALDAY", "name": "CALDAY", "autoWidth": true, "visible": false },
            { "data": "Material", "class": "Material", "name": "Material", "autoWidth": true },
            { "data": "Description", "class": "Description", "name": "Description", "autoWidth": true },
            { "data": "WeeklyQuantity", "class": "WeeklyQuantity", "name": "WeeklyQuantity", "autoWidth": true },
            { "defaultContent": "<input type='text' id='txtOverallUplift' name='OverallUplift' class='form-control' placeholder='Enter %' maxlength='3' onkeypress='return checkUplift(event);' onblur='return checkIfEmpty(e);'>" },
            { "data": "FirmOrder", "class": "FirmOrder", "name": "FirmOrder", "autoWidth": true },
            { "data": "Monday", "class": "Monday", "name": "Monday", "autoWidth": true },
            { "data": "MondayValue", "class": "MondayValue", "name": "MondayValue", "autoWidth": true },
            { "data": "Tuesday", "class": "Tuesday", "name": "Tuesday", "autoWidth": true },
            { "data": "TuesdayValue", "class": "TuesdayValue", "name": "TuesdayValue", "autoWidth": true },
            { "data": "Wednesday", "class": "Wednesday", "name": "Wednesday", "autoWidth": true },
            { "data": "WednesdayValue", "class": "WednesdayValue", "name": "WednesdayValue", "autoWidth": true },
            { "data": "Thursday", "class": "Thursday", "name": "Thursday", "autoWidth": true },
            { "data": "ThursdayValue", "class": "ThursdayValue", "name": "ThursdayValue", "autoWidth": true },
            { "data": "Friday", "class": "Friday", "name": "Friday", "autoWidth": true },
            { "data": "FridayValue", "class": "FridayValue", "name": "FridayValue", "autoWidth": true },
            { "data": "Saturday", "class": "Saturday", "name": "Saturday", "autoWidth": true },
            { "data": "SaturdayValue", "class": "SaturdayValue", "name": "SaturdayValue", "autoWidth": true },
            { "data": "Sunday", "class": "Sunday", "name": "Sunday", "autoWidth": true },
            { "data": "SundayValue", "class": "SundayValue", "name": "SundayValue", "autoWidth": true },
            { "data": "UnitPrice", "class": "UnitPrice", "name": "UnitPrice", "autoWidth": true },
            { "data": "TotalValue", "class": "TotalValue", "name": "TotalValue", "autoWidth": true },
            { "data": "SalesOrganization", "class": "SalesOrganization", "name": "SalesOrganization", "autoWidth": false, "visible": false },
            { "data": "DistributionChannel", "class": "DistributionChannel", "name": "DistributionChannel", "autoWidth": false, "visible": false },
            { "data": "Division", "class": "Division", "name": "Division", "autoWidth": false, "visible": false },
        ],
        footerCallback: CalculateFooter,
    });

    $('#list').on('change', 'input', function (e) {
        var row = $(this).closest('tr');
        Material = row.find("TD").eq(1).html();
        if (Material != 0) {
            res = $.grep(jsonData, function (n, i) {
                return n.Material == Material;
            });

            var temp = res[0];
            Monday = temp.Monday;
            Tuesday = temp.Tuesday;
            Wednesday = temp.Wednesday;
            Thursday = temp.Thursday;
            Friday = temp.Friday;
            Saturday = temp.Saturday;
            Sunday = temp.Sunday;
            FirmOrder = temp.FirmOrder;
            if ($(this).val() == '-') {
                if (res.length > 0) {
                    $('.Monday', row).text(Math.round(Monday));
                    $('.Tuesday', row).text(Math.round(Tuesday));
                    $('.Wednesday', row).text(Math.round(Wednesday));
                    $('.Thursday', row).text(Math.round(Thursday));
                    $('.Friday', row).text(Math.round(Friday));
                    $('.Saturday', row).text(Math.round(Saturday));
                    $('.Sunday', row).text(Math.round(Sunday));
                    $('.FirmOrder', row).text(Math.round(FirmOrder));
                }
                return;
            }

            var FirmOrder = 0;

            $('input', row).each(function () {
                var WeeklyOrder = row.find("TD").eq(3).html();
                Uplift = Number($(this).val());
                f7total = Math.round(WeeklyOrder * Uplift) / 100;
                FirmOrder = parseFloat(f7total) + parseFloat(WeeklyOrder);
            });

            var table = $("#list").DataTable();

            MondayQty = Math.round((Monday / temp.FirmOrder) * (FirmOrder));
            TuesdayQty = Math.round((Tuesday / temp.FirmOrder) * (FirmOrder));
            WednesdayQty = Math.round((Wednesday / temp.FirmOrder) * (FirmOrder));
            ThursdayQty = Math.round((Thursday / temp.FirmOrder) * (FirmOrder));
            FridayQty = Math.round((Friday / temp.FirmOrder) * (FirmOrder));
            SaturdayQty = Math.round((Saturday / temp.FirmOrder) * (FirmOrder));
            SundayQty = Math.round((Sunday / temp.FirmOrder) * (FirmOrder));
            Remainder = Math.round(FirmOrder) - (MondayQty + TuesdayQty + WednesdayQty + ThursdayQty + FridayQty + SaturdayQty + SundayQty)

            if (Remainder != 0) {
                if (MondayQty > 0 && MondayQty + Remainder >= 0)
                    MondayQty = MondayQty + Remainder;

                else if (TuesdayQty > 0 && MondayQty + Remainder < 0)
                    TuesdayQty = MondayQty + TuesdayQty + Remainder;

                else if (WednesdayQty > 0 && MondayQty + TuesdayQty + Remainder < 0)
                    WednesdayQty = MondayQty + TuesdayQty + WednesdayQty + Remainder;

                else if (ThursdayQty > 0 && MondayQty + TuesdayQty + WednesdayQty + Remainder < 0)
                    ThursdayQty = MondayQty + TuesdayQty + WednesdayQty + ThursdayQty + Remainder;

                else if (FridayQty > 0 && MondayQty + TuesdayQty + WednesdayQty + ThursdayQty + Remainder < 0)
                    FridayQty = MondayQty + TuesdayQty + WednesdayQty + ThursdayQty + FridayQty + Remainder;

                else if (SaturdayQty > 0 && MondayQty + TuesdayQty + WednesdayQty + ThursdayQty + FridayQty < 0)
                    SaturdayQty = MondayQty + TuesdayQty + WednesdayQty + ThursdayQty + FridayQty + SaturdayQty + Remainder;

                else if (SundayQty > 0 && MondayQty + TuesdayQty + WednesdayQty + ThursdayQty + FridayQty + SaturdayQty < 0)
                    SundayQty = MondayQty + TuesdayQty + WednesdayQty + ThursdayQty + FridayQty + SaturdayQty + SundayQty + Remainder;
            }

            RowIndex = table.row(row).index();

            table.cell(RowIndex, 7).data(MondayQty);
            table.cell(RowIndex, 8).data(MondayQty * table.cell(RowIndex, 21).data());
            Monday = Monday / Uplift;

            table.cell(RowIndex, 9).data(TuesdayQty);
            table.cell(RowIndex, 10).data(TuesdayQty * table.cell(RowIndex, 21).data());
            Tuesday = Tuesday / Uplift;

            table.cell(RowIndex, 11).data(WednesdayQty);
            table.cell(RowIndex, 12).data(WednesdayQty * table.cell(RowIndex, 21).data());
            Wednesday = Wednesday / Uplift;

            table.cell(RowIndex, 13).data(ThursdayQty);
            table.cell(RowIndex, 14).data(ThursdayQty * table.cell(RowIndex, 21).data());
            Thursday = Thursday / Uplift;

            table.cell(RowIndex, 15).data(FridayQty);
            table.cell(RowIndex, 16).data(FridayQty * table.cell(RowIndex, 21).data());
            Friday = Friday / Uplift;

            table.cell(RowIndex, 17).data(SaturdayQty);
            table.cell(RowIndex, 18).data(SaturdayQty * table.cell(RowIndex, 21).data());
            Saturday = Saturday / Uplift;

            table.cell(RowIndex, 19).data(SundayQty);
            table.cell(RowIndex, 20).data(SundayQty * table.cell(RowIndex, 21).data());
            Sunday = Sunday / Uplift;

            table.cell(RowIndex, 6).data(Math.round(FirmOrder));
            var rowprice = table.cell(RowIndex, 21).data();

            var totalpriceval = (rowprice * (MondayQty + TuesdayQty + WednesdayQty + ThursdayQty + FridayQty + SaturdayQty + SundayQty));
            table.cell(RowIndex, 22).data(totalpriceval);

            table.draw();
            e.preventDefault();
        }
    });

    $("#list").on('input', '#OverallUplift', function () {
        //alert('yeah!');
        $("#list").dataTable().fnDestroy();
        var calculated_total_sum = 0;

        $("#list #OverallUplift").each(function () {
            
            var get_textbox_value = $(this).val();
            if ($.isNumeric(get_textbox_value)) {
                calculated_total_sum += parseFloat(get_textbox_value);
            }
        });
        $("#total_sum_value").html(calculated_total_sum);

    });

});

function CalculateFooter() {
    var api = $("#list").DataTable();

    $(api.column(4).footer()).html('Total Proposed Order = ' +
        api.column(4).data().reduce(function (a, b) {
            return a + b;
        }, 0)

    );
    $(api.column(6).footer()).html('Total Firm Order = ' +
        api.column(6).data().reduce(function (a, b) {
            return a + b;
        }, 0)
    );

    $(api.column(7).footer()).html('Total Monday = ' +
        api.column(7).data().reduce(function (a, b) {
            return a + b;
        }, 0)
    );
    $(api.column(8).footer()).html('Total Value = ' +
        api.column(8).data().reduce(function (a, b) {
            return a + b;
        }, 0)
    );
    $(api.column(9).footer()).html('Total Tuesday = ' +
        api.column(9).data().reduce(function (a, b) {
            return a + b;
        }, 0)
    );
    $(api.column(10).footer()).html('Total Value = ' +
        api.column(10).data().reduce(function (a, b) {
            return a + b;
        }, 0)
    );
    $(api.column(11).footer()).html('Total Wednesday = ' +
        api.column(11).data().reduce(function (a, b) {
            return a + b;
        }, 0)
    );
    $(api.column(12).footer()).html('Total Value = ' +
        api.column(12).data().reduce(function (a, b) {
            return a + b;
        }, 0)
    );
    $(api.column(13).footer()).html('Total Thursday = ' +
        api.column(13).data().reduce(function (a, b) {
            return a + b;
        }, 0)
    );
    $(api.column(14).footer()).html('Total Value = ' +
        api.column(14).data().reduce(function (a, b) {
            return a + b;
        }, 0)
    );
    $(api.column(15).footer()).html('Total Friday = ' +
        api.column(15).data().reduce(function (a, b) {
            return a + b;
        }, 0)
    );
    $(api.column(16).footer()).html('Total Value = ' +
        api.column(16).data().reduce(function (a, b) {
            return a + b;
        }, 0)
    );
    $(api.column(17).footer()).html('Total Saturday = ' +
        api.column(17).data().reduce(function (a, b) {
            return a + b;
        }, 0)
    );
    $(api.column(18).footer()).html('Total Value = ' +
        api.column(18).data().reduce(function (a, b) {
            return a + b;
        }, 0)
    );
    $(api.column(19).footer()).html('Total Sunday = ' +
        api.column(19).data().reduce(function (a, b) {
            return a + b;
        }, 0)
    );
    $(api.column(20).footer()).html('Total Value = ' +
        api.column(20).data().reduce(function (a, b) {
            return a + b;
        }, 0)
    );
    $(api.column(22).footer()).html('Total Price Rs = ' +
        api.column(22).data().reduce(function (a, b) {
            return a + b;
        }, 0)
    );

}



function saveData(url) {
    $('#list').dataTable().fnDestroy();
    var AcceptedOrderList = new Array();
    $("#list TBODY TR").each(function () {
        var row = $(this);
        var OrderModel = {};

        OrderModel.OrderRefrenceNumber = row.find("TD").eq(0).html();
        OrderModel.CALDAY = row.find("TD").eq(1).html();
        OrderModel.Material = row.find("TD").eq(2).html();
        OrderModel.Description = row.find("TD").eq(3).html();
        OrderModel.Quantity = row.find("TD").eq(4).html();
        OrderModel.WeeklyQuantity = row.find("TD").eq(4).html();
        OrderModel.FirmOrder = row.find("TD").eq(6).html();
        OrderModel.Monday = row.find("TD").eq(7).html();
        OrderModel.Tuesday = row.find("TD").eq(9).html();
        OrderModel.Wednesday = row.find("TD").eq(11).html();
        OrderModel.Thursday = row.find("TD").eq(13).html();
        OrderModel.Friday = row.find("TD").eq(15).html();
        OrderModel.Saturday = row.find("TD").eq(17).html();
        OrderModel.Sunday = row.find("TD").eq(19).html();
        OrderModel.UnitPrice = row.find("TD").eq(21).html();

        OrderModel.IsAccepted = 1;
        OrderModel.SalesOrganization = row.find("TD").eq(23).html();
        OrderModel.DistributionChannel = row.find("TD").eq(24).html();
        OrderModel.Division = row.find("TD").eq(25).html();
        AcceptedOrderList.push(OrderModel);

    });

    var dataToPost = JSON.stringify(AcceptedOrderList);
    console.log(dataToPost);
    Common.Ajax('POST', url, dataToPost, 'json', successWeeklyUpliftCreateHandler);
    $('#list').dataTable();


}

function saveRejectedData(url) {

    $('#list').dataTable().fnDestroy();
    var AcceptedOrderList = new Array();
    $("#list TBODY TR").each(function () {
        var row = $(this);
        var OrderModel = {};
        OrderModel.OrderRefrenceNumber = row.find("TD").eq(0).html();
        OrderModel.CALDAY = row.find("TD").eq(0).html();
        OrderModel.Material = row.find("TD").eq(1).html();
        OrderModel.Description = row.find("TD").eq(2).html();
        OrderModel.UnitPrice = row.find("TD").eq(3).html();
        OrderModel.Quantity = row.find("TD").eq(4).html();
        OrderModel.WeeklyQuantity = row.find("TD").eq(5).html();
        OrderModel.FirmOrder = row.find("TD").eq(7).html();
        OrderModel.Monday = row.find("TD").eq(8).html();
        OrderModel.Tuesday = row.find("TD").eq(9).html();
        OrderModel.Wednesday = row.find("TD").eq(10).html();
        OrderModel.Thursday = row.find("TD").eq(11).html();
        OrderModel.Friday = row.find("TD").eq(12).html();
        OrderModel.Saturday = row.find("TD").eq(13).html();
        OrderModel.Sunday = row.find("TD").eq(14).html();
        OrderModel.IsAccepted = 0;
        AcceptedOrderList.push(OrderModel);

    });

    var dataToPost = JSON.stringify(AcceptedOrderList);
    console.log(dataToPost);

    Common.Ajax('POST', url, dataToPost, 'json', successWeeklyUpliftCreateHandler1);
    $('#list').dataTable();
}

function successWeeklyUpliftCreateHandler(response) {

    if (response == '1') {
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


function checkUplift(e) {

    var KeyID = (window.event) ? event.keyCode : e.keyCode;

    if ((KeyID == 8) || (KeyID == 9) || (KeyID == 13) || (KeyID == 45) || (KeyID >= 48 && KeyID <= 57)) {

        var newChar = String.fromCharCode(e.keyCode);
        var oldVal = $(e.target).val();
        var total = parseInt(oldVal + newChar)
        if (isNaN(oldVal + newChar) && oldVal != '')
            return false;
        else if (total < -10 || total > 10)
            return false;

        return true;
    }
    else {
        return false;
    }

}
