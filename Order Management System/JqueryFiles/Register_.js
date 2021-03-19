/// <reference path="GenericAjax.js" />


$(document).ready(function () {

    $('#bttnUpdateRegister').click(function () {
        UpdateRegiser('UpdateRegister');
    });

    //$('#txtRoleIDUpdate').bind('load change', function () {
    //    var status = $('#txtRoleIDUpdate option:selected').text();
    //    if (status == "Distributor") {
    //        $("#txtDesignationIDedit").prop("disabled", true);
    //    }
    //    else {
    //        $("#txtDesignationIDedit").prop("disabled", false);
    //    }
    //    $('#txtRoleIDUpdate').trigger('change');

    //});

    $("#RegisterLists").DataTable({



        initComplete: function () {
            this.api().columns().every(function () {
                var column = this;
                var select = $('<select><option value="">Select All</option></select>')
                    .appendTo($(column.header()).empty())
                    .on('change', function () {
                        var val = $.fn.dataTable.util.escapeRegex(
                            $(this).val()
                        );

                        column
                            .search(val ? '^' + val + '$' : '', true, false)
                            .draw();
                    });

                column.data().unique().sort().each(function (d, j) {
                    select.append('<option value="' + d + '">' + d + '</option>')
                });
            });
        },


        "ajax": {
            "url": "GetAllRegistraitonRecord",
            "type": "POST",
            "datatype": "json",

            "processing": false, // for show progress bar
            "serverSide": false, // for process server side
            "filter": true, // this is for disable filter (search box)
            "orderMulti": true, // for disable multiple column at once
            "dataSrc": "",
            //beforeSend: function () {
            //    setTimeout(function () {
            //        $("#divLoader").show();
            //    }, 1);
            //},
            //complete: function (datatype) {
            //    $("#divLoader").hide();
            //},

        },
        //columndefs: [
        //          {
        //              targets: 4, visible :false

        //          },

        //],
        //order: [[1, "asc"]],


        columnDefs: [
 {
     targets: 0,
     sortable: false
 },
        ],
        columnDefs: [
    {
        targets: 1,
        sortable: false
    },
        ],
        order: [[1, 2, 3, 4, 5, 6, 7, 8, 9, "asc"]],

        "columnDefs": [
  { "orderable": false, "targets": "_all" }
        ],

        "columns": [
            { "data": "Login_ID", "class": "Login_ID", "name": "Login_ID", "autoWidth": true, "visible": false },
            { "data": "UserFirstName", "class": "UserFirstName", "name": "UserFirstName", "autoWidth": true },
              { "data": "UserLastName", "class": "UserLastName", "name": "UserLastName", "autoWidth": true },
            //{ "data": "UserLastName", "class": "UserLastName", "name": "UserLastName", "autoWidth": true},
            { "data": "UserName", "class": "UserName", "name": "UserName", "autoWidth": true },
            //{ "data": "Pass", "class": "Pass", "name": "Pass", "autoWidth": true, "visible" :false },
             { "data": "Designation_ID", "class": "Designation_ID", "name": "Designation_ID", "autoWidth": true },
           // { "data": "DesigantionDesc", "class": "DesigantionDesc", "name": "DesigantionDesc", "autoWidth": true },
            { "data": "Rele_Desc", "class": "Rele_Desc", "name": "Rele_Desc", "autoWidth": true },
           //{ "data": "Role_ID", "class": "Role_ID", "name": "Role_ID", "autoWidth": true, "visible": false },
              //{ "data": "User_ID", "class": "User_ID", "name": "User_ID", "autoWidth": true, "visible": false },
             { "data": "Distributor_ID", "class": "Distributor_ID", "name": "Distributor_ID", "autoWidth": true },
            // { "data": "Distribution_Desc", "class": "Distribution_Desc", "name": "Distribution_Desc", "autoWidth": true },


       { "data": "RegionCode", "class": "RegionCode", "name": "RegionCode", "autoWidth": true, },
            { "data": "TerritoryCode", "class": "TerritoryCode", "name": "TerritoryCode", "autoWidth": true },
              { "data": "TownCode", "class": "TownCode", "name": "TownCode", "autoWidth": true, },
             { "data": "AreaCode", "class": "AreaCode", "name": "AreaCode", "autoWidth": true },

            {
                "defaultContent": "<button id='click' class='btn btn-primary m-t-6 waves-effect'>Edit</button>"
            }
        ],

    });




    BindDropDownRegion('/Login/getRegions');
    BindDropDownRole('/Role/GetAllRoles');
    BindDropDownRoleEdit('/Role/GetAllRoles');
    BindDropDownDesignation('/designation/GetAllDesignation');
    BindDropDownDesignationEdit('/designation/GetAllDesignation');


    $('#RoleId').change(function () {
        var status = $('#RoleId option:selected').text();
        if (status == "Distributor") {
            $("#txtDesignationID").prop("disabled", true);
        }
        else {
            $("#txtDesignationID").prop("disabled", false);
        }

    });


    $('#txtRoleIDUpdate').change(function () {
        var status = $('#txtRoleIDUpdate option:selected').text();
        if (status == "Distributor") {
            $("#txtDesignationIDedit").prop("disabled", true);
        }
        else {
            $("#txtDesignationIDedit").prop("disabled", false);
        }

    });


    $('#bttnReg').click(function () {
        alert("_");
        register('RegisterAdd');
    });
    $('#bttnUpdate').click(function () {
        update('RegisterUpdate');
    });

    $('#RegisterLists tbody').on('click', 'button', function () {

        //  var data = table.row($(this).parents("tr")).data();

        var currentRow = $(this).closest("tr");

        var data = $('#RegisterLists').DataTable().row(currentRow).data();

        var updateLogin_ID = (data['Login_ID']);
        // var updateLogin_ID = $(this).closest("tr").find(".Login_ID").text();
        var updateUserFirstName = $(this).closest("tr").find(".UserFirstName").text();
        var updateLastName = $(this).closest("tr").find(".UserLastName").text();
        //var updateLastName = (data['UserLastName']).text();
        var updateUserName = $(this).closest("tr").find(".UserName").text();
        var updatePass = (data['Pass']);
        var updateDesigantionDesc = $(this).closest("tr").find(".DesigantionDesc").text();
        var updateRele_Desc = $(this).closest("tr").find(".Rele_Desc").text();
        var updateRole_ID = (data['Role_ID']);
        var updateDesignation_ID = (data['Designation_ID']);
        var updateDistributorID = (data['Distributor_ID']);
        var UpdateUserID = (data['User_ID']);
        var updateRegionCode = (data['RegionCode']);
        var updateTerritoryCode = (data['TerritoryCode']);
        var updateTownCode = (data['TownCode']);
        var updateAreaCode = (data['AreaCode']);

        console.log(UpdateUserID);



        $("#largeModal").modal();
        $("#txtLogin_IDUpdate").val(updateLogin_ID);
        $("#txtUserFirstNameup").val(updateUserFirstName);
        $("#txtUserLastNameup").val(updateLastName);
        $("#txtUserNameup").val(updateUserName);
        $("#txtPassup").val(updatePass);
        //    $("#txtDesignationIDedit").val(updateDesigantionDesc);
        $("#txtRoleDecsUpdate").val(updateRele_Desc);
        $("#txtDesignationIDedit").val(updateDesignation_ID);
        $("#txtRoleIDUpdate").val(updateRole_ID);
        $("#txtDistributorIDUpdate").val(updateDistributorID);
        $("#UserIDUpdate").val(UpdateUserID);

        $("#txtRegionCode1").val(updateRegionCode);
        $("#txtTownCode1").val(updateTownCode);
        $("#txtAreaCode1").val(updateAreaCode);
        $("#txtTerritoryCode1").val(updateTerritoryCode);

        var status = $('#txtRoleIDUpdate option:selected').text();
        if (status == "Distributor") {
            $("#txtDesignationIDedit").prop("disabled", true);
        }
        else {
            $("#txtDesignationIDedit").prop("disabled", false);
        }


    });


    $('#txtRoleIDUpdate').change(function () {
        var rol = $('#txtRoleIDUpdate').val();
        console.log(rol);
        $('#txtDistributorIDUpdate').html('');
        $.ajax({
            type: "post",
            url: "/Role/GetDistrict?Role_ID=" + rol,
            data: { Role_ID: rol },
            datatype: "json",
            traditional: true,
            success: function (data) {
                var s1 = '<option value="-1"></option>';
                for (var i = 0; i < data.length; i++) {
                    s1 += '<option value="' + data[i].Distributor_ID + '">' + data[i].Distributor_Name + '</option>';
                }
                $("#txtDistributorIDUpdate").html(s1);
            }

            //{
            //    $.each(data, function (index, value) {
            //        $('#Distributor_ID').append('<option value="' + value.Distributor_ID + '">' + value.Distributor_Name + '</option>');
            //    });
            //}
        });
    });


    $('#txtDistributorID').change(function () {
        var rol = $('#txtDistributorID').val();

        //$.ajax({
        //    type: "post",
        //    url: "getArea?customer=" + rol,
        //    data: { customer: rol },
        //    datatype: "json",
        //    traditional: true,
        //    success: function (data) {

                var s1 = '';
                s1 += '<option value="1000">EBM</option>';
                s1 += '<option value="2000">CFL</option>';
                $("#SelectSalesOrg").attr("multiple", "multiple");
                $("#SelectSalesOrg").html(s1);
                $("#SelectSalesOrg").multiselect({
                    columns: 1,
                    placeholder: 'Please Select Sales Organization',
                    search: true,
                    searchOptions: {
                        'default': 'Search'
                    },
                    selectAll: true
                });
                //$("#SelectSalesOrg").multiselect("reload");
                //$.ajax({
                //    type: "post",
                //    url: "GetUserDrop",
                //    datatype: "json",
                //    traditional: true,
                //    success: function (data2) {
                //        var su = '<option value="-1">Chose UserName</option>';
                //        for (var i = 0; i < data2.length; i++) {
                //            su += '<option value="' + data2[i].User_ID + '">' + data2[i].UserFirstName + '</option>';
                //        }
                //        $("#txtUserName").html(su);
                //    }
                //});
            //}

            //{
            //    $.each(data, function (index, value) {
            //        $('#Distributor_ID').append('<option value="' + value.Distributor_ID + '">' + value.Distributor_Name + '</option>');
            //    });
            //}
        //});
    });

    $('#SelectSalesOrg').change(function () {
        if ($('#SelectSalesOrg').children("option:selected").val() < 0) {
            $("#SelectDivision").html('');
            $("#SelectDivision").multiselect("reload");
        }
        else {

            var s2 = '<option value="10">Biscuit</option>';
            s2 += '<option value="30">Cake</option>';
            $("#SelectDivision").attr("multiple", "multiple");
            $("#SelectDivision").html(s2);
            $("#SelectDivision").multiselect({
                columns: 1,
                placeholder: 'Please Select Division',
                search: true,
                searchOptions: {
                    'default': 'Search'
                },
                selectAll: true
            });
            $("#SelectDivision").multiselect("reload");
        }
    });
    $("#drpRegions").change(function () {
        var rol = $('#drpRegions').val();
        if (rol.length > 1)
            rol = rol.join(", ")
        $('#txtRegionCode').val(rol);
        $.ajax({
            type: "POST",
            url: "getAllArea?regionCode=" + rol,
            data: { regionCode: rol },
            datatype: "json",
            traditional: true,
            success: function (data) {
                var s1 = '';//<option value="">Select Area</option>
                for (var i = 0; i < data.length; i++) {
                    s1 += '<option value="' + data[i].AreaCode + '">' + data[i].AreaDesc + '</option>';
                }
                $("#drpArea").attr("multiple", "multiple");
                $("#drpArea").html(s1);
                $("#drpArea").multiselect({
                    columns: 1,
                    placeholder: 'Please Select Area',
                    search: true,
                    searchOptions: {
                        'default': 'Search'
                    },
                    selectAll: true
                });
                $("#drpArea").multiselect("reload");

                $.ajax({
                    type: "post",
                    url: "GetUserDrop",
                    datatype: "json",
                    traditional: true,
                    success: function (data2) {
                        var su = '<option value="-1">Chose UserName</option>';
                        for (var i = 0; i < data2.length; i++) {
                            su += '<option value="' + data2[i].User_ID + '">' + data2[i].UserFirstName + '</option>';
                        }
                        $("#txtUserName").html(su);
                    }
                });
            }

            //{
            //    $.each(data, function (index, value) {
            //        $('#Distributor_ID').append('<option value="' + value.Distributor_ID + '">' + value.Distributor_Name + '</option>');
            //    });
            //}
        });
    });

    $("#drpArea").change(function () {
        var rol = $('#drpArea').val();
        if (rol.length > 1)
            rol = rol.join(", ")
        $('#txtAreaCode').val(rol);
        $.ajax({
            type: "POST",
            url: "getAllTerritory?AreaCode=" + rol,
            data: { AreaCode: rol },
            datatype: "json",
            traditional: true,
            success: function (data) {
                var s1 = '';//<option value="">Select Territory</option>
                for (var i = 0; i < data.length; i++) {
                    s1 += '<option value="' + data[i].TerritoryCode + '">' + data[i].TerritoryDesc + '</option>';
                }
                $("#drpTerritory").attr("multiple", "multiple");
                $("#drpTerritory").html(s1);
                $("#drpTerritory").multiselect({
                    columns: 1,
                    placeholder: 'Please Select Territory',
                    search: true,
                    searchOptions: {
                        'default': 'Search'
                    },
                    selectAll: true
                });
                $("#drpTerritory").multiselect("reload");
            }

            //{
            //    $.each(data, function (index, value) {
            //        $('#Distributor_ID').append('<option value="' + value.Distributor_ID + '">' + value.Distributor_Name + '</option>');
            //    });
            //}
        });
    });

    $("#drpTerritory").change(function () {
        var rol = $('#drpTerritory').val();
        if (rol.length > 1)
            rol = rol.join(", ")
        $('#txtTerritoryCode').val(rol);
        $.ajax({
            type: "POST",
            url: "getAllTown?TerritoryCode=" + rol,
            data: { TerritoryCode: rol },
            datatype: "json",
            traditional: true,
            success: function (data) {
                var s1 = '';//<option value="">Select Town</option>
                for (var i = 0; i < data.length; i++) {
                    s1 += '<option value="' + data[i].TownCode + '">' + data[i].TownDesc + '</option>';
                }
                $("#drpTown").attr("multiple", "multiple");
                $("#drpTown").html(s1);
                $("#drpTown").multiselect({
                    columns: 1,
                    placeholder: 'Please Select Town',
                    search: true,
                    searchOptions: {
                        'default': 'Search'
                    },
                    selectAll: true
                });
                $("#drpTown").multiselect("reload");
            }

            //{
            //    $.each(data, function (index, value) {
            //        $('#Distributor_ID').append('<option value="' + value.Distributor_ID + '">' + value.Distributor_Name + '</option>');
            //    });
            //}
        });
    });

    $('#drpTown').change(function () {

        var Region = $('#drpRegions').val();
        if (Region.length > 1)
            Region = Region.join(", ")
        var Area = $('#drpArea').val();
        if (Area.length > 1)
            Area = Area.join(", ")
        var Territory = $('#drpTerritory').val();
        if (Territory.length > 1)
            Territory = Territory.join(", ")
        var Town = $('#drpTown').val();
        if (Town.length > 1)
            Town = Town.join(", ")
        $('#txtTownCode').val(Town);
        $.ajax({
            type: "post",
            url: "GetDistrict",
            data: {
                Region: Region,
                Area: Area,
                Territory: Territory,
                Town: Town
            },
            datatype: "json",
            traditional: true,
            success: function (data) {
                var s1 = '';
                for (var i = 0; i < data.length; i++) {
                    s1 += '<option value="' + data[i].Distributor_ID + '">' + data[i].Distributor_Name + '</option>';
                }
                $("#txtDistributorID").attr("multiple", "multiple");
                $("#txtDistributorID").html(s1);
                $("#txtDistributorID").multiselect({
                    columns: 1,
                    placeholder: 'Please Select Distributors',
                    search: true,
                    searchOptions: {
                        'default': 'Search'
                    },
                    selectAll: true
                });
                $("#txtDistributorID").multiselect("reload");
            }

        });
    });





});





function register(url) {
   // debugger;
    var RegionCode = $("#txtRegionCode").val();
    //RegionCode = RegionCode.join(", ")
    var AreaCode = $("#txtAreaCode").val();
    //AreaCode = AreaCode.join(", ")
    var TerritoryCode = $("#txtRegionCode").val();
    // TerritoryCode = TerritoryCode.join(", ")
    var TownCode = $("#txtTownCode").val();
    // TownCode = TownCode.join(", ")
    var login = {
        Role_ID: $("#RoleId").val(),
        //UserName: $("#txtUserName").val(),
        Pass: $("#txtPass").val(),
        Distributor_ID: $("#txtDistributorID").val().join(", "),
        RegionCode: RegionCode,
        AreaCode: AreaCode,
        TerritoryCode: TerritoryCode,
        TownCode: TownCode,
        SalesOrg: $('#SelectSalesOrg').val().join(", "),
        Division: $('#SelectDivision').val().join(", "),
        UserName: $('#txtUserName').children("option:selected").text()
    }
    var User = {
        Designation_ID: $("#txtDesignationID").val(),
        UserFirstName: $("#txtUserFirstName").val(),
        UserLastName: $("#txtUserLastName").val(),
        IPAddress: 0
    }
    var obj = new Object();

    var model = {
        "login": login,
        "User": User
    }

    //if (!$("MyForm").valid())
    //{
    //    return false;
    //}
    // alert(JSON.stringify(model));
    Common.Ajax('POST', url, JSON.stringify(model), 'json', successUserRegistrationHandler);
}

function UpdateRegiser(url) {
    var LoginUpdate = {
        Login_ID: $("#txtLogin_IDUpdate").val(),
        Role_ID: $("#txtRoleIDUpdate").val(),
        UserName: $("#txtUserNameup").val(),
        Pass: $("#txtPassup").val(),
        //Distributor_ID: $("#txtDistributorIDUpdate").val(),
        RegionCode: $("#txtRegionCode1").val(),
        TerritoryCode: $("#txtTerritoryCode1").val(),
        TownCode: $("#txtTownCode1").val(),
        AreaCode: $("#txtAreaCode1").val(),


    }
    var UserUpdate = {

        Designation_ID: $("#txtDesignationIDedit").val(),
        UserFirstName: $("#txtUserFirstNameup").val(),
        UserLastName: $("#txtUserLastNameup").val(),
        User_ID: $("#UserIDUpdate").val(),
    }
    var model = {
        "login": LoginUpdate,
        "User": UserUpdate
    }
    // alert(JSON.stringify(model));
    Common.Ajax('POST', url, JSON.stringify(model), 'json', successUpdateUserRegistrationHandler);
}




function BindDropDownRegion(url) {
    Common.Ajax('GET', url, {}, 'json', BindDropDownRegionHandler);
}
function BindDropDownRole(url) {
    Common.Ajax('GET', url, {}, 'json', BindDropDownRoleHandler);
}
function BindDropDownRoleEdit(url) {
    Common.Ajax('GET', url, {}, 'json', BindDropDownRoleEditableHandler);
}
function BindDropDownRoleEditableHandler(response) {
    var ss = '<option value="-1">Please Select a Role</option>';
    for (var i = 0; i < response.length; i++) {
        ss += '<option value="' + response[i].Role_ID + '">' + response[i].Rele_Desc + '</option>';
    }
    $("#txtRoleIDUpdate").html(ss);
}

function BindDropDownDesignation(url) {
    Common.Ajax('GET', url, {}, 'json', BindDropDownDesignationHandler);
}
function BindDropDownDesignationEdit(url) {
    Common.Ajax('GET', url, {}, 'json', BindDropDownDesignationEditableHandler);
}
function BindDropDownDesignationEditableHandler(response) {
    var s = '<option value="-1"></option>';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].Designation_ID + '">' + response[i].DesigantionDesc + '</option>';
    }
    $("#txtDesignationIDedit").html(s);
    //$('#txtDesignationID [value=#txtDesignationID]').attr('selected', 'true');
}
function BindDropDownRegionHandler(response) {
    var s = '';//<option value="0">Please Select a region</option>
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].RegionCode + '">' + response[i].RegionDesc + '</option>';
    }
    $("#drpRegions").attr("multiple", "multiple");
    $("#drpRegions").html(s);
    $("#drpRegions").multiselect({
        columns: 1,
        placeholder: 'Please Select region',
        search: true,
        searchOptions: {
            'default': 'Search'
        },
        selectAll: true
    });
    $("#drpRegions").multiselect("reload");
}
function BindDropDownRoleHandler(response) {
    var s = '<option value="-1">Please Select a Role</option>';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].Role_ID + '">' + response[i].Rele_Desc + '</option>';
    }
    $("#RoleId").html(s);
}
function BindDropDownDesignationHandler(response) {
    var s = '<option value="-1">Please Select a Designation</option>';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].Designation_ID + '">' + response[i].DesigantionDesc + '</option>';
    }
    $("#txtDesignationID").html(s);
}
function successUserRegistrationHandler(response) {

    if (response == '1') {
        $('#successAlert').show('fade');
        setTimeout(function () {
            $('#successAlert').hide('fade');
        }, 5000);
        $("#formID")[0].reset();
        $('#RegisterLists').DataTable().ajax.reload();
    }
    if (response == '-1') {
        $('#warningAlert').show('fade');
        setTimeout(function () {
            $('#warningAlert').hide('fade');
        }, 5000);

        setTimeout(function () {
            $('#warningAlert').hide('fade');
        }, 5000);
    }
}

function successUpdateUserRegistrationHandler(response) {

    if (response == '2') {
        $('#UpdatesuccessAlert').show('fade');
        setTimeout(function () {
            $('#UpdatesuccessAlert').hide('fade');
        }, 5000);
        setTimeout(function () {
            $('#UpdatesuccessAlert').hide('fade');
        }, 5000);
        $("#formID")[0].reset();
        $('#RegisterLists').DataTable().ajax.reload();
    }
    if (response == '-2') {
        $('#warningAlert').show('fade');
        setTimeout(function () {
            $('#UpdatewarningAlert').hide('fade');
        }, 5000);

        setTimeout(function () {
            $('#UpdatewarningAlert').hide('fade');
        }, 5000);
    }
}



function EditRoles(RoleID) {
    var url = "";
    $("#largeModal").modal();
}