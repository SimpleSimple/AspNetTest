﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Example01.aspx.cs" Inherits="AspNetTest.Example01" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <!-- 
        使用反射直接调用一般处理文件中定义的方法
    -->
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
    <script src="js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        (function ($) {
            $(function () {
                $.get("/Ashx/GetHandler.ashx", { "action": "Multiply", "a": 1, "b": 2222 }, function (data, status) {
                    alert(data);
                });

                $.post("/Ashx/PostHandler.ashx", { "action": "add", "a": 1, "b": 2222 }, function (data, status) {
                    alert(data);
                });
            });
        })(jQuery);
    </script>
</body>
</html>
