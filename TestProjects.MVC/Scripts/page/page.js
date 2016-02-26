$(function () {
    var phone = $("#verifyCode").val();
    $("#verifyCodeSend").click(function () {
        $.ajax({
            type:"get",
            url: "/SMS/SendVerifyCode?t="+new Date(),
            data: {'phone':phone},
            dataType: "json",
            success: function (data) {
                alert(data);
            }
        });
    });
});