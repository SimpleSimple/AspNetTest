(function ($) {

    $.extend({
        getUrlVars: function () {
            var vars = [], hash;
            var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
            for (var i = 0; i < hashes.length; i++) {
                hash = hashes[i].split('=');
                vars.push(hash[0]);
                vars[hash[0]] = hash[1];
            }

            return vars;
        },

        getUrlVar: function (name) {
            return $.getUrlVars()[name];
        }
    });

    $.format = function (source, params) {
        if (arguments.length == 1)
            return function () {
                var args = $.makeArray(arguments);
                args.unshift(source);
                return $.format.apply(this, args);
            };
        if (arguments.length > 2 && params.constructor != Array) {
            params = $.makeArray(arguments).slice(1);
        }
        if (params.constructor != Array) {
            params = [params];
        }
        $.each(params, function (i, n) {
            source = source.replace(new RegExp("\\{" + i + "\\}", "g"), n);
        });
        return source;
    };

    function removeHTMLTag(str) {
        str = str.replace(/<\/?[^>]*>/g, ''); //去除HTML tag
        str = str.replace(/[ | ]*\n/g, '\n'); //去除行尾空白
        //str = str.replace(/\n[\s| | ]*\r/g,'\n'); //去除多余空行
        str = str.replace(/ /ig, ''); //去掉 
        return str;
    }

    //针对后端返回的 /Date(47513233)/ 格式日期做的转换
    $.parseJSONDate = function (str, formatStr) {
        var date = false;
        try {
            date = new Date(Number(str.match(/\d+/)[0]));
            str = GetStrByDate(date);
        }
        catch (e) {

        }
        return str || '';
    };
    function GetStrByDate(date) {
        var yy = date.getFullYear();      //年
        var mm = date.getMonth() + 1;     //月
        var dd = date.getDate();          //日
        var hh = date.getHours();         //时
        var ii = date.getMinutes();       //分
        var ss = date.getSeconds();       //秒
        var str = mm + '月' + dd + "日" + hh + '时' + ii + '分';
        return str;
    }
})(jQuery)