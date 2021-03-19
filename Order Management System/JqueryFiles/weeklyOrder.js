/// <reference path="GenericAjax.js" />

$(document).ready(function () {

    $('#redirect').click(function () {

        window.location.href = "/dashboard/dashboard";
    });

    $("#listMonday1").DataTable({
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once

        "ajax": {
            "url": "C:\Users\muham\Desktop\file.json.docx",
            "type": "POST",
            "datatype": "json"
            //"dataSrc": ""

        },
        "columns": [
              { "data": "materialCode", "class": "materialCode", "name": "materialCode", "autoWidth": true },
              { "data": "materialDescription", "class": "materialDescription", "name": "materialDescription", "autoWidth": true },
              { "data": "unitPrice", "class": "unitPrice", "name": "unitPrice", "autoWidth": true },
              { "data": "totalWeeklyOrder", "class": "totalWeeklyOrder", "name": "totalWeeklyOrder", "autoWidth": true },
              { "data": "orderQuantity", "class": "orderQuantity", "name": "orderQuantity", "autoWidth": true },
              { "defaultContent": " <input type='number' id='txtPlus' name='txtPlus'  class='form-control' placeholder='Enter uplift number'>" },
              { "defaultContent": " <input type='number' id='txtMinus' name='txtPlus'  class='form-control' placeholder='Enter uplift number'>" },
              { "data": "firmOrder", "class": "firmOrder", "name": "firmOrder", "autoWidth": true },
              { "data": "comment", "class": "comment", "name": "comment", "autoWidth": true },
              { "data": "recievedQuantity", "class": "recievedQuantity", "name": "recievedQuantity", "autoWidth": true },
              { "data": "datetime", "class": "datetime", "name": "datetime", "autoWidth": true }
        ]
    });       //"orderMulti": false, // for disable multiple column at once


    $("#listTuesday1").DataTable({
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once

        "ajax": {
            "url": "gridViewTuesday",
            "type": "POST",
            "datatype": "json"
            //"dataSrc": ""

        },
        "columns": [
              { "data": "materialCode", "class": "materialCode", "name": "materialCode", "autoWidth": true },
              { "data": "materialDescription", "class": "materialDescription", "name": "materialDescription", "autoWidth": true },
              { "data": "unitPrice", "class": "unitPrice", "name": "unitPrice", "autoWidth": true },
              { "data": "totalWeeklyOrder", "class": "totalWeeklyOrder", "name": "totalWeeklyOrder", "autoWidth": true },
              { "data": "orderQuantity", "class": "orderQuantity", "name": "orderQuantity", "autoWidth": true },
              { "defaultContent": " <input type='number' id='txtPlus' name='txtPlus'  class='form-control' placeholder='Enter uplift number'>" },
              { "defaultContent": " <input type='number' id='txtMinus' name='txtPlus'  class='form-control' placeholder='Enter uplift number'>" },
              { "data": "firmOrder", "class": "firmOrder", "name": "firmOrder", "autoWidth": true },
              { "data": "comment", "class": "comment", "name": "comment", "autoWidth": true },
              { "data": "recievedQuantity", "class": "recievedQuantity", "name": "recievedQuantity", "autoWidth": true },
              { "data": "datetime", "class": "datetime", "name": "datetime", "autoWidth": true }

        ]
    });       //"orderMulti": false, // for disable multiple column at once

    $("#listWednesday1").DataTable({
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once

        "ajax": {
            "url": "gridViewWednesday",
            "type": "POST",
            "datatype": "json"
            //"dataSrc": ""

        },
        "columns": [
              { "data": "materialCode", "class": "materialCode", "name": "materialCode", "autoWidth": true },
              { "data": "materialDescription", "class": "materialDescription", "name": "materialDescription", "autoWidth": true },
              { "data": "unitPrice", "class": "unitPrice", "name": "unitPrice", "autoWidth": true },
              { "data": "totalWeeklyOrder", "class": "totalWeeklyOrder", "name": "totalWeeklyOrder", "autoWidth": true },
              { "data": "orderQuantity", "class": "orderQuantity", "name": "orderQuantity", "autoWidth": true },
              { "defaultContent": " <input type='number' id='txtPlus' name='txtPlus'  class='form-control' placeholder='Enter uplift number'>" },
              { "defaultContent": " <input type='number' id='txtMinus' name='txtPlus'  class='form-control' placeholder='Enter uplift number'>" },
              { "data": "firmOrder", "class": "firmOrder", "name": "firmOrder", "autoWidth": true },
              { "data": "comment", "class": "comment", "name": "comment", "autoWidth": true },
              { "data": "recievedQuantity", "class": "recievedQuantity", "name": "recievedQuantity", "autoWidth": true },
              { "data": "datetime", "class": "datetime", "name": "datetime", "autoWidth": true }

        ]
    });       //"orderMulti": false, // for disable multiple column at once

    $("#listThursday1").DataTable({
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once

        "ajax": {
            "url": "gridViewThursday",
            "type": "POST",
            "datatype": "json"
            //"dataSrc": ""

        },
        "columns": [
              { "data": "materialCode", "class": "materialCode", "name": "materialCode", "autoWidth": true },
              { "data": "materialDescription", "class": "materialDescription", "name": "materialDescription", "autoWidth": true },
              { "data": "unitPrice", "class": "unitPrice", "name": "unitPrice", "autoWidth": true },
              { "data": "totalWeeklyOrder", "class": "totalWeeklyOrder", "name": "totalWeeklyOrder", "autoWidth": true },
              { "data": "orderQuantity", "class": "orderQuantity", "name": "orderQuantity", "autoWidth": true },
              { "defaultContent": " <input type='number' id='txtPlus' name='txtPlus'  class='form-control' placeholder='Enter uplift number'>" },
              { "defaultContent": " <input type='number' id='txtMinus' name='txtPlus'  class='form-control' placeholder='Enter uplift number'>" },
              { "data": "firmOrder", "class": "firmOrder", "name": "firmOrder", "autoWidth": true },
              { "data": "comment", "class": "comment", "name": "comment", "autoWidth": true },
              { "data": "recievedQuantity", "class": "recievedQuantity", "name": "recievedQuantity", "autoWidth": true },
              { "data": "datetime", "class": "datetime", "name": "datetime", "autoWidth": true }

        ]




    });       //"orderMulti": false, // for disable multiple column at once


    $("#listFriday1").DataTable({
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once

        "ajax": {
            "url": "gridViewFriday",
            "type": "POST",
            "datatype": "json"
            //"dataSrc": ""

        },
        "columns": [
              { "data": "materialCode", "class": "materialCode", "name": "materialCode", "autoWidth": true },
              { "data": "materialDescription", "class": "materialDescription", "name": "materialDescription", "autoWidth": true },
              { "data": "unitPrice", "class": "unitPrice", "name": "unitPrice", "autoWidth": true },
              { "data": "totalWeeklyOrder", "class": "totalWeeklyOrder", "name": "totalWeeklyOrder", "autoWidth": true },
              { "data": "orderQuantity", "class": "orderQuantity", "name": "orderQuantity", "autoWidth": true },
              { "defaultContent": " <input type='number' id='txtPlus' name='txtPlus'  class='form-control' placeholder='Enter uplift number'>" },
              { "defaultContent": " <input type='number' id='txtMinus' name='txtPlus'  class='form-control' placeholder='Enter uplift number'>" },
              { "data": "firmOrder", "class": "firmOrder", "name": "firmOrder", "autoWidth": true },
              { "data": "comment", "class": "comment", "name": "comment", "autoWidth": true },
              { "data": "recievedQuantity", "class": "recievedQuantity", "name": "recievedQuantity", "autoWidth": true },
              { "data": "datetime", "class": "datetime", "name": "datetime", "autoWidth": true }

        ]
    });       //"orderMulti": false, // for disable multiple column at once


    $("#listSaturday1").DataTable({
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once

        "ajax": {
            "url": "gridViewSaturday",
            "type": "POST",
            "datatype": "json"
            //"dataSrc": ""

        },
        "columns": [
              { "data": "materialCode", "class": "materialCode", "name": "materialCode", "autoWidth": true },
              { "data": "materialDescription", "class": "materialDescription", "name": "materialDescription", "autoWidth": true },
              { "data": "unitPrice", "class": "unitPrice", "name": "unitPrice", "autoWidth": true },
              { "data": "totalWeeklyOrder", "class": "totalWeeklyOrder", "name": "totalWeeklyOrder", "autoWidth": true },
              { "data": "orderQuantity", "class": "orderQuantity", "name": "orderQuantity", "autoWidth": true },
              { "defaultContent": " <input type='number' id='txtPlus' name='txtPlus'  class='form-control' placeholder='Enter uplift number'>" },
              { "defaultContent": " <input type='number' id='txtMinus' name='txtPlus'  class='form-control' placeholder='Enter uplift number'>" },
              { "data": "firmOrder", "class": "firmOrder", "name": "firmOrder", "autoWidth": true },
              { "data": "comment", "class": "comment", "name": "comment", "autoWidth": true },
              { "data": "recievedQuantity", "class": "recievedQuantity", "name": "recievedQuantity", "autoWidth": true },
              { "data": "datetime", "class": "datetime", "name": "datetime", "autoWidth": true }

        ]
    });       //"orderMulti": false, // for disable multiple column at once


    $("#listSunday1").DataTable({
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once

        "ajax": {
            "url": "gridViewSunday",
            "type": "POST",
            "datatype": "json"
            //"dataSrc": ""

        },
        "columns": [
              { "data": "materialCode", "class": "materialCode", "name": "materialCode", "autoWidth": true },
              { "data": "materialDescription", "class": "materialDescription", "name": "materialDescription", "autoWidth": true },
              { "data": "unitPrice", "class": "unitPrice", "name": "unitPrice", "autoWidth": true },
              { "data": "totalWeeklyOrder", "class": "totalWeeklyOrder", "name": "totalWeeklyOrder", "autoWidth": true },
              { "data": "orderQuantity", "class": "orderQuantity", "name": "orderQuantity", "autoWidth": true },
              { "defaultContent": " <input type='number' id='txtPlus' name='txtPlus'  class='form-control' placeholder='Enter uplift number'>" },
              { "defaultContent": " <input type='number' id='txtMinus' name='txtPlus'  class='form-control' placeholder='Enter uplift number'>" },
              { "data": "firmOrder", "class": "firmOrder", "name": "firmOrder", "autoWidth": true },
              { "data": "comment", "class": "comment", "name": "comment", "autoWidth": true },
              { "data": "recievedQuantity", "class": "recievedQuantity", "name": "recievedQuantity", "autoWidth": true },
              { "data": "datetime", "class": "datetime", "name": "datetime", "autoWidth": true }

        ]
    });       //"orderMulti": false, // for disable multiple column at once
});