function CheckRowInput(e) {

    //如果不是实测的入力框
    if (!IsInputDisplayAndShiCe(e, "JQ_SHICE")) {
        return;
    }

    //文本框对象
    var txt;
    txt = e;

    //获得 TR 对象
    var tr = GetTR(e);
    if (tr == null) { return; }

    //文本框值
    var value;
    value = e.value;

    //结果
    var Result;
    Result = false;

    //基准值 类型 值1～3
    var zbenchmark_type = tr.attr("zbenchmark_type");
    var zbenchmark_value1 = tr.attr("zbenchmark_value1");
    var zbenchmark_value2 = tr.attr("zbenchmark_value2");
    var zbenchmark_value3 = tr.attr("zbenchmark_value3");

    z_value1 = zbenchmark_value1.replace(/-/g, "");
    z_value2 = zbenchmark_value2.replace(/-/g, "");
    z_value3 = zbenchmark_value3.replace(/-/g, "");
    var jizhun = "(" + z_value1 +","+ z_value2+"," + z_value3+")";

    if (zbenchmark_type != '12' && zbenchmark_type != '00') {
        if (isInteger(value)) {
            e.value = value + ".0"
        }
    }

    if (zbenchmark_type == '00') {//目视
    } else if (zbenchmark_type == '01') {
        // K1 = In
        Result = (value == z_value1);

    } else if (zbenchmark_type == '02') {
        // IN < V1
        Result = (parseFloat(value) < parseFloat(zbenchmark_value1));

    } else if (zbenchmark_type == '03') {
        // IN <= V1
        Result = (parseFloat(value) <= parseFloat(zbenchmark_value1));

    } else if (zbenchmark_type == '04') {
        // IN > V1
        Result = (parseFloat(value) > parseFloat(zbenchmark_value1));

    } else if (zbenchmark_type == '05') {
        // IN >= V1
        Result = (parseFloat(value) >= parseFloat(zbenchmark_value1));

    } else if (zbenchmark_type == '06') {
        // V1+V3 <= IN <= V1+V2
        Result = (parseFloat(value) >= parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value3) && parseFloat(value) <= parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value2));

    } else if (zbenchmark_type == '10') {
        /// 0 <= IN <= v1/1000
        Result = (parseFloat(value) >= 0 && parseFloat(value) <= parseFloat(zbenchmark_value1) / 1000);

    } else if (zbenchmark_type == '12') {
        var temp;
        temp = ('20' + value).replace("Y7", "").toUpperCase();
        
        //    '小口标签日期测试，1.有没有标签，有就算合格 2.没有就算NG   3.有的话扫描到的日期如果和当前 要在当前日期的加减3天以内，则为正确 不是的话就是OW
        if (parseFloat(temp) + 3 >= parseFloat(getNowFormatDate()) && parseFloat(temp) - 3 <= parseFloat(getNowFormatDate())) {
            Result = true;
        } else {
            jizhun = "前后3日以内";
            Result = false;
        }
    } else if (zbenchmark_type == '13') {
        // 0 < IN <=V1
        Result =  (parseFloat(value) > 0 && parseFloat(value) <= parseFloat(zbenchmark_value1));

    } else if (zbenchmark_type == '14') {
        // V1+V3<= IN < V1+V2
        Result = (parseFloat(value) >= parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value3) && parseFloat(value) < parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value2));

    } else if (zbenchmark_type == '15-1') {
        // IN > V1
        Result = (parseFloat(value) > parseFloat(zbenchmark_value1));

    } else if (zbenchmark_type == '16-1') {
        // IN < V1
        
        Result = (parseFloat(value) < parseFloat(zbenchmark_value1));

    } else if (zbenchmark_type == '17-1') {
        // IN >= V1
        Result = (parseFloat(value) >= parseFloat(zbenchmark_value1));

    } else if (zbenchmark_type == '18-1') {
        // IN <= V1
        Result = (parseFloat(value) <= parseFloat(zbenchmark_value1));

    } else if (zbenchmark_type == '19-1') {
        // V1 + V3 < IN < V1 + V2
        //
        Result = (parseFloat(value) > parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value3) && parseFloat(value) < parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value2));

    } else if (zbenchmark_type == '20-1') {
        // V1+v3 <= IN < V1 + V2
        Result = (parseFloat(value) >= parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value3) && parseFloat(value) < parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value2));
    }

    //绝对值取得
    var cha;
    cha = GetCha(tr);

    if (zbenchmark_type == '15-2') {
        // ｜V1-V2｜》v
        Result = (parseFloat(cha) > parseFloat(zbenchmark_value1));

    } else if (zbenchmark_type == '16-2') {
        // ｜V1-V2｜《v1
        Result = (parseFloat(cha) < parseFloat(zbenchmark_value1));

    } else if (zbenchmark_type == '17-2') {
        // ｜V1-V2｜》＝V1
        Result = (parseFloat(cha) >= parseFloat(zbenchmark_value1));

    } else if (zbenchmark_type == '18-2') {
        //｜V1-V2｜《＝V1
        Result = (parseFloat(cha) <= parseFloat(zbenchmark_value1));

    } else if (zbenchmark_type == '19-2') {
        // V1+V3 《 ｜V1-V2｜ 《 V1+V3
        Result = (parseFloat(cha) > parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value3) && parseFloat(cha) < parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value2));

    } else if (zbenchmark_type == '20-2') {
        // v1+v3 《＝｜V1-V2｜ 《 v1 ＋ V2
        Result = (parseFloat(cha) >= parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value3) && parseFloat(cha) < parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value2));
    }

    //如果正确  1.设置合格   2.设置背景色   3.清空 备考
    if (Result) {
        //结果
        $($(e).parent().parent().children("td")[5]).text('合'); //合格
        //基准
        //$($(e).parent().parent().children("td")[6].children[0]).val(''); //备考
        $($(e).parent().parent().children("td")[7]).text(''); //备考

    } else {
        //结果
        $($(e).parent().parent().children("td")[5]).text('误');
        //基准 
        //$($(e).parent().parent().children("td")[6].children[0]).val(jizhun);
        $($(e).parent().parent().children("td")[7]).text(jizhun);
    }

}

//差 的绝对值 取得
function GetCha(e) {
    var v1, v2;
    v1 = e.children("td")[3].children[0].value; //parseFloat($(e.children("td")[3]).text());
    v2 = e.children("td")[4].children[0].value; // parseFloat($(e.children("td")[4]).text());
    return Math.abs(v1 - v2);
}

// 日期 YYYYMMDD 取得
function getNowFormatDate() {
    var day = new Date();
    var Year = 0;
    var Month = 0;
    var Day = 0;
    var CurrentDate = "";
    Year = day.getFullYear(); //支持IE和火狐浏览器.
    Month = day.getMonth() + 1;
    Day = day.getDate();
    CurrentDate += Year;
    if (Month >= 10) {
        CurrentDate += Month;
    }
    else {
        CurrentDate += "0" + Month;
    }
    if (Day >= 10) {
        CurrentDate += Day;
    }
    else {
        CurrentDate += "0" + Day;
    }
    return "" + CurrentDate;
}
