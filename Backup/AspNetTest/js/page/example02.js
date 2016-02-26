require.config({
    paths: {
        echarts: '/js/echarts'
    }
});

function init() {
    console.log("init...");
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
                     $.get("/Ashx/AjaxHandler.ashx", { "type": "GETONLINES", beginDate: $("#startDate").val(), endDate: $("#endDate").val() }, function (data) {

                         dates += "[";
                         seriesArr += "[";
                         $.each(data, function (k, v) {
                             if (k == data.length - 1) {
                                 dates += "'" + v.tick + "'";
                                 seriesArr += v.totals;
                             }
                             else {
                                 dates += "'" + v.tick + "',";
                                 seriesArr += v.totals + ",";
                             }
                         });
                         dates += "]";
                         seriesArr += "]";
                         console.log("date:" + dates + " " + "series:" + seriesArr);

                         myChart.setOption({
                             title: {
                                 text: '同时在线人数'
                             },
                             tooltip: {
                                 trigger: 'axis'
                             },
                             legend: {
                                 data: ['同时在线人数']
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
                                     name: '同时在线人数',
                                     type: 'line',
                                     smooth: true,
                                     itemStyle: { normal: { areaStyle: { type: 'default'}} },
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