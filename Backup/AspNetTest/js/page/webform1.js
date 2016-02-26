function CheckValidCode() {
    var $vcode = $.trim($("#VCode").val());
    var valid = false;
    $.ajax({
        url: "/ASHX/AjaxHandler.ashx",
        data: { "type": "CHECKVALIDATECODE", "vcode": $vcode },
        dataType: "json",
        async: false,
        success: function (response) {
            console.log(response.State);
            if (response.State == -1 || response.State == -2) {
                $("#VCode").parent().children(".error").html(response.Msg);
                $("#VCodeImage").trigger("click");
                valid = false;
            }
            else if (response.State == 0) {
                $("#VCode").parent().children(".error").html(response.Msg);
                valid = true;
            }
        }
    });
    return valid;
}

function CheckFormValidate() {
    var flag = false;
    var uname = $.trim($("#UserName").val());
    if (uname == "") {
        $("#UserName").focus();
        $("#UserName").parent().children(".error").html("用户名不能为空");
        return false;
    }
    var passwd = $.trim($("#UserPass").val());
    if (passwd == "") {
        $("#UserPass").focus();
        $("#UserPass").parent().children(".error").html("密码不能为空");
        return false;
    }
    var $vcode = $.trim($("#VCode").val());
    if ($vcode == "") {
        $("#VCode").focus();
        $("#VCode").parent().children(".error").html("验证码不能为空");
        return false;
    }

    var valid = CheckValidCode();
    if (valid == false) return false;
}


function RefreshValidCode() {
    $("#VCodeImage").bind("click", function () {
        $(this).attr("src", "/GetVCode.aspx?t=" + new Date().getDate() + new Date().getMilliseconds());
    });
}

$(function () {
    RefreshValidCode();
});
