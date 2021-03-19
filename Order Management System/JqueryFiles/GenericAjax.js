var Common;

Common = {

    Ajax: function (httpMethod, url, data, type, successCallBack, async, cache) {
        if (typeof async == "undefined") {
            async = true;
        }
        if (typeof cache == "undefined") {
            cache = false;
        }

        var ajaxObj = $.ajax({
            type: httpMethod.toUpperCase(),
            url: url,
            data: data,
            contentType: "application/json; charset=utf-8",
            dataType: type,
            async: async,
            cache: cache,
            success: successCallBack,
            error: function (err, type, httpStatus) {
                var a = Common.AjaxFailureCallback(err, type, httpStatus);
                alert(a);
            }
        });

        return ajaxObj;
    },

    DisplaySuccess: function (message) {
        Common.ShowSuccessSavedMessage(message);
    },

    DisplayError: function (error) {
        Common.ShowFailSavedMessage(message);
    },

    AjaxFailureCallback: function (err, type, httpStatus) {
        
        var failureMessage = 'Error occurred in ajax call' + err.status + " - " + err.responseText + " - " + httpStatus;
        console.log(failureMessage);
        return httpStatus+" "+err.status;
    },

    ShowSuccessSavedMessage: function (messageText) {


        $.blockUI({ message: messageText });
        setTimeout($.unblockUI, 1500);
    },

    ShowFailSavedMessage: function (messageText) {


        $.blockUI({ message: messageText });
        setTimeout($.unblockUI, 1500);
    }
}
