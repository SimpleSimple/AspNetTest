<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AspNetTest.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>From表单提交与验证</title>
    <link href="css/webform1.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
    <script src="js/jquery-1.4.1.min.js" type="text/javascript"></script>
</head>
<body>
    <div class="pages">
        <form class="form-group" action="" method="post">
        <input type="hidden" name="act" value="login" />
        <div class="single-line">
            用户名：<input class="input" type="text" name="UserName" id="UserName" /><span class="tips"></span>
        </div>
        <div class="single-line">
            验证码：<input class="input" type="text" name="VCode" id="VCode" onblur="CheckValidCode(this);" />
            <img id="VCodeImage" src="GetVCode.aspx" alt="看不清楚，请点击" style="width: 80px; height: 25px;" />
            <div class="tips"></div>
        </div>
        <button class="btn-submit" onclick="javascript:CheckFormValidate(); return false;">
            Log In</button>
        </form>
    </div>
    <script src="js/page/webform1.js" type="text/javascript"></script>
</body>
</html>
