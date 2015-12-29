<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Example02.aspx.cs" Inherits="AspNetTest.Example02" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>同时在线人数</title>
    <script src="js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="js/echarts/echarts.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="pages">
        <div id="main" style="width:80%;height:500px;"></div>
    </div>
    </form>
    <script type="text/javascript">

            require.config({
                paths: {
                    echarts: '/js/echarts'
                }
            });

            function init() {
                require(
                 [
                     'echarts',
                     'echarts/theme/macarons',
                     'echarts/chart/bar',
                     'echarts/chart/line',
                     'echarts/chart/map'
                 ],
                 function (ec) {
                     var myChart = ec.init(document.getElementById('main'));
                     
                     var dates = "", seriesArr = "";
                     $.get("/Ashx/AjaxHandler.ashx", { beginDate: $("#startDate").val(), endDate: $("#endDate").val() }, function (data) {
                         dates += "[";
                         seriesArr += "[";
                         $.each(data, function (k, v) {
                             if (k == data.length - 1) {
                                 dates += "'" + v.login_time + "'";
                                 seriesArr += v.totals;
                             }
                             else {
                                 dates += "'" + v.login_time + "',";
                                 seriesArr += v.totals + ",";
                             }
                         });
                         dates += "]";
                         seriesArr += "]";

                         myChart.setOption({
                             title: {
                                 text: '每日登录人数'
                             },
                             tooltip: {
                                 trigger: 'axis'
                             },
                             legend: {
                                 data: ['登录人数']
                             },
                             toolbox: {
                                 show: true,
                                 feature: {
                                     mark: { show: true },
                                     dataView: { show: true, readOnly: false },
                                     magicType: { show: true, type: ['line', 'bar'] },
                                     restore: { show: true },
                                     saveAsImage: { show: true }
                                 }
                             },
                             calculable: true,
                             xAxis: [
                                 {
                                     type: 'category',
                                     boundaryGap: false,
                                     data: eval(dates)
                                 }
                             ],
                             yAxis: [
                                 {
                                     type: 'value',
                                     splitArea: { show: true }
                                 }
                             ],
                             series: [
                                 {
                                     name: '登录人数',
                                     type: 'line',
                                     smooth: true,
                                     itemStyle: { normal: { areaStyle: { type: 'default' } } },
                                     data: eval(seriesArr)
                                 }
                             ]
                         });
                         myChart.setTheme("macarons");
                     }, "json");
                 });
            };

            $(function () {
                init();
            });
    </script>
</body>
</html>
