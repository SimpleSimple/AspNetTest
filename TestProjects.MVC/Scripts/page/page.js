jQuery(function () {

    $("#verifyCodeSend").click(function () {
        var phone = $("#verifyCode").val();
        $.ajax({
            type: "get",
            url: "/SMS/SendVerifyCode?phone=" + phone + "&t=" + new Date().getTime(),
            data: {},
            dataType: "json",
            success: function (data) {
                alert(JSON.stringify(data));
            }
        });
    });
});