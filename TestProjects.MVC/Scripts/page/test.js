(function ($) {
    var data = [{ 'Ntradeid': 69, 'Nuserid': 1680009, 'Dtime': '2015-05-22T10:03:45.156135+08:00', 'Calias': '测试员', 'Cname': '免费献花' }, { 'Ntradeid': 84, 'Nuserid': 1680009, 'Dtime': '2015-05-22T10:03:52.802071+08:00', 'Calias': '测试员', 'Cname': '免费献花' }, { 'tradeid': 97, 'Nuserid': 1680009, 'Dtime': '2015-05-22T10:04:00.347457+08:00', 'Calias': '测试员', 'Cname': '免费献花' }];
    $.each(data, function (i, n) {
        if (i < 10)
            alert(i + " - " + n);
    });
})(jQuery);
