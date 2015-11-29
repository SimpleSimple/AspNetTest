function CheckValidCode() {
    var $vcode = $.trim($("#VCode").val());
    $.ajax({
        url: "/ASHX/AjaxHandler.ashx",
        data: { "type": "CHECKVALIDATECODE", "vcode": $vcode },
        dataType: "json",
        async: false,
        success: function (response) {
            if (response.State == -1) {
                $("#VCode").parent().children(".tips").html(response.Msg);
                return;
            }
            if (response.State == -2) {
                $("#VCode").parent().children(".tips").html(response.Msg);
                //window.location.href = window.location.href;
                return;
            }
            if (response.State == 0) {
                $("#VCode").parent().children(".tips").html(response.Msg);
            }
        }
    });
}

function CheckFormValidate() {
    var flag = false;
    var uname = $.trim($("#UserName").val());
    if (uname == "") {
        $("#UserName").focus();
        $("#UserName").parent().children(".tips").html("用户名不能为空");
        return false;
    }
    var $vcode = $.trim($("#VCode").val());
    if ($vcode == "") {
        $("#VCode").focus();
        $("#VCode").parent().children(".tips").html("验证码不能为空");
        return false;
    }
    //    var valid;
    //    $.ajax({
    //        url: "/ASHX/AjaxHandler.ashx",
    //        data: { "type": "CHECKVALIDATECODE", "vcode": $vcode },
    //        dataType: "json",
    //        async: false,
    //        success: function (response) {
    //            if (response.State == -1) {
    //                valid = false;
    //                alert(response.Msg);
    //            }
    //            if (response.State == 0) {
    //                valid = true;
    //                alert(response.Msg);
    //            }
    //        }
    //    });
    //    return valid;
}


$(function () {
    $("#VCodeImage").bind("click", function () {
        $(this).attr("src", "/GetVCode.aspx?t=" + new Date().getDate() + new Date().getMilliseconds());
    });
});