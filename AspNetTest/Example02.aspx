<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Example02.aspx.cs" Inherits="AspNetTest.Example02" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>同时在线人数</title>
    <script src="js/jquery-1.8.3.min.js" type="text/javascript"></script>

</head>
<body>
    <!-- 
        使用ECharts图表插件来做站点同时在线人
    -->
    <form id="form1" runat="server">
        <div class="pages">
            <div id="main" style="width: 80%; height: 500px;">
            </div>
        </div>
    </form>
    <script src="http://echarts.baidu.com/build/dist/echarts.js" type="text/javascript"></script>

    <script src="js/page/example02.js" type="text/javascript"></script>
</body>
</html>
