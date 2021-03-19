$(document).ready(function () {
    $("#overlap").hide();
    $("#leftsidebar").css("width", "300px");
    $("#overlap").show();
    if (window.innerWidth > 1100)
        $(".content").css("margin-left", "315px");

    $(window).resize(function () {
        $("#overlap").show();
        if (window.innerWidth > 1100)
            $(".content").css("margin-left", "315px");
        else 
            $(".content").css("margin-left", "0");
    });
    //$("#leftsidebar").hover(function () {
    //}, function () {
    //    //$("#leftsidebar").css("width", "50px");
    //    //$("#overlap").hide();
    //    //$(".content").css("margin-left", "60px")
    //});
});