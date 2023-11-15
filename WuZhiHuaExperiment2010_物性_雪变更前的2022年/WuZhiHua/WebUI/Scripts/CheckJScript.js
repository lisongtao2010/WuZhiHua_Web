

function isInteger(obj) {
    return obj % 1 === 0 && obj.indexOf(".") == -1 && obj != '';
}
 function toDecimal(x) {
    var f = parseFloat(x);
    if (isNaN(f)) {
        return;
    }
    f = Math.round(x * 10) / 10;

    if(isInteger(f+'')) {
        f = f + ".0";
    }
    return f;
}

function KesanBilink(e,key) {
   return Math.round(Math.round(25 / key * e.value * 100) / 10) / 10;
}

function CheckRowInput(e) {

    //如果不是实测的入力框
    if (!IsInputDisplayAndShiCe(e, "JQ_SHICE")) {
        return;
    }

    //文本框对象
    var txt;
    txt = e;

    //获得 TR 对象
    var tr;
    tr = $(e).parent().parent();

    if (e == null) { return; }

    //基准值 类型 值1～3
    var zbenchmark_type;
    var zbenchmark_value1;
    var zbenchmark_value2;
    var zbenchmark_value3;

    zbenchmark_type = tr.attr("zbenchmark_type");
    zbenchmark_value1 = tr.attr("zbenchmark_value1");
    zbenchmark_value2 = tr.attr("zbenchmark_value2");
    zbenchmark_value3 = tr.attr("zbenchmark_value3");



    //ピーリンク
    if (parseInt(zbenchmark_type) >= 60 && parseInt(zbenchmark_type) <= 65) {

        if (GL_JQ_INPUT_TEXTBOX_OLD_VALUE != e.value) {

            //计算变换
            if (parseInt(zbenchmark_type) == 60 || parseInt(zbenchmark_type) == 61) {
                //e.value = Math.round(25 / 5 * e.value * 10) / 10;
                e.value = Math.round(Math.round(25 / 5 * e.value * 100)/10)/10;
            }
            if (parseInt(zbenchmark_type) == 62 || parseInt(zbenchmark_type) == 63) {
                //e.value = Math.round(25 / 10 * e.value * 10) / 10;
                e.value = Math.round(Math.round(25 / 10 * e.value * 100)/10)/10;
            }
            if (parseInt(zbenchmark_type) == 64 || parseInt(zbenchmark_type) == 65) {
                //e.value = Math.round(25 / 15 * e.value * 10) / 10;
                e.value = Math.round(Math.round(25 / 15 * e.value * 100)/10)/10;
            }

        }

        if (parseInt(zbenchmark_type) == 60 || parseInt(zbenchmark_type) == 62 || parseInt(zbenchmark_type) == 64) {
            zbenchmark_type = "50";
        }
        if (parseInt(zbenchmark_type) == 61 || parseInt(zbenchmark_type) == 63 || parseInt(zbenchmark_type) == 65) {
            zbenchmark_type = "51";
        }

    }

    //ピーリンク 2 Width
    if (parseInt(zbenchmark_type) >= 66 && parseInt(zbenchmark_type) <= 71) {

        var v135 = "135";
        var v246 = "246";
        var ky = ($(e).parent().index() + 1) + "";  //$(e).attr("id");

        if (parseInt(zbenchmark_type) == 66) {
            if (v246.indexOf(ky) >= 0) {
                e.value = KesanBilink(e, 15);
            }
        } else if (parseInt(zbenchmark_type) == 67) {
            if (v246.indexOf(ky) >= 0) {
                e.value = KesanBilink(e, 10);
            }
        } else if (parseInt(zbenchmark_type) == 68) {
            if (v246.indexOf(ky) >= 0) {
                e.value = KesanBilink(e, 5);
            }
        } else if (parseInt(zbenchmark_type) == 69) {
            if (v135.indexOf(ky) >= 0) {
                e.value = KesanBilink(e, 15);
            }
            if (v246.indexOf(ky) >= 0) {
                e.value = KesanBilink(e, 10);
            }
        } else if (parseInt(zbenchmark_type) == 70) {
            if (v135.indexOf(ky) >= 0) {
                e.value = KesanBilink(e, 15);
            }
            if (v246.indexOf(ky) >= 0) {
                e.value = KesanBilink(e, 5);
            }
        } else if (parseInt(zbenchmark_type) == 71) {
            if (v135.indexOf(ky) >= 0) {
                e.value = KesanBilink(e, 10);
            }
            if (v246.indexOf(ky) >= 0) {
                e.value = KesanBilink(e, 5);
            }
        }

        zbenchmark_type = "50"; //输入1~6 的值，求平均数>=基准值1①，并且求最小值>=基准值1②

    }

    if (parseInt(zbenchmark_type) == 56) {
        if (GL_JQ_INPUT_TEXTBOX_OLD_VALUE != e.value) {
            //计算变换 表面胶合强度
            e.value = Math.round(Math.round(e.value / 400 * 100) / 10) / 10;
        }
    }

    //平面引张
    //tr.attr("check_item");
    if (parseInt(zbenchmark_type) == 54) {

        if (GL_JQ_INPUT_TEXTBOX_OLD_VALUE != e.value) {

            if (tr.attr("check_item") == "正面") {
                if(("6024,6025,6160,7283,6400,7423,7424").indexOf($("#ctl00_FC_tbxGoodsCd").val()) == -1){
                    //计算变换 平面引张
                    //e.value = Math.round(e.value / 4 * 10) / 10;
                    e.value = Math.round(Math.round(e.value / 4 * 100) / 10) / 10;
                }
            } else if (tr.attr("check_item") == "背面") {
                //e.value = Math.round(e.value / 4 * 10) / 10;
                e.value = Math.round(Math.round(e.value / 4 * 100) / 10) / 10;

            } else if (tr.attr("check_item") == "膜与膜") {

            }
        }
    }


    //文本框值
    var value;
    value = e.value;




    //结果
    var Result;
    Result = false;


    if (zbenchmark_type != '12' && zbenchmark_type != '00' && zbenchmark_type != '55') {
        if (isInteger(value)) {
            e.value = value + ".0"
        }
    }


    var jizhun;

    if (zbenchmark_type == '00') {//目视
    } else if (zbenchmark_type == '01') {
        // K1 = In

        if (value == zbenchmark_value1.replace(/-/g, "")) {
            Result = true;
        } else {
            //jizhun = "=" + zbenchmark_value1.replace(/-/g, "");
            jizhun = "(" + zbenchmark_value1.replace(/-/g, "") +","+ zbenchmark_value2.replace(/-/g, "")+"," + zbenchmark_value3.replace(/-/g, "")+")";
            Result = false;
        }
    } else if (zbenchmark_type == '02') {
        // IN < V1
        if (parseFloat(value) < parseFloat(zbenchmark_value1)) {
            Result = true;
        } else {
            //jizhun = "<" + zbenchmark_value1;
            jizhun = "(" + zbenchmark_value1.replace(/-/g, "") + "," + zbenchmark_value2.replace(/-/g, "") + "," + zbenchmark_value3.replace(/-/g, "") + ")";
            Result = false;
        }
    } else if (zbenchmark_type == '03') {
        // IN <= V1
        if (parseFloat(value) <= parseFloat(zbenchmark_value1)) {
            Result = true;
        } else {
            //jizhun = "<=" + zbenchmark_value1;
            jizhun = "(" + zbenchmark_value1.replace(/-/g, "") + "," + zbenchmark_value2.replace(/-/g, "") + "," + zbenchmark_value3.replace(/-/g, "") + ")";

            Result = false;
        }
    } else if (zbenchmark_type == '04') {
        // IN > V1
        if (parseFloat(value) > parseFloat(zbenchmark_value1)) {
            Result = true;
        } else {
            //jizhun = ">" + zbenchmark_value1;
            jizhun = "(" + zbenchmark_value1.replace(/-/g, "") + "," + zbenchmark_value2.replace(/-/g, "") + "," + zbenchmark_value3.replace(/-/g, "") + ")";

            Result = false;
        }
    } else if (zbenchmark_type == '05') {
        // IN >= V1
        if (parseFloat(value) >= parseFloat(zbenchmark_value1)) {
            Result = true;
        } else {
           // jizhun = ">=" + zbenchmark_value1;
            jizhun = "(" + zbenchmark_value1.replace(/-/g, "") + "," + zbenchmark_value2.replace(/-/g, "") + "," + zbenchmark_value3.replace(/-/g, "") + ")";
            Result = false;
        }
    } else if (zbenchmark_type == '06') {
        // V1+V3 <= IN <= V1+V2
        if (parseFloat(value) >= accAdd(parseFloat(zbenchmark_value1) , parseFloat(zbenchmark_value3)) && parseFloat(value) <= accAdd(parseFloat(zbenchmark_value1), parseFloat(zbenchmark_value2))) {
            Result = true;
        } else {
           // jizhun = (parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value3)) + "～" + (parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value2));
            jizhun = "(" + zbenchmark_value1.replace(/-/g, "") + "," + zbenchmark_value2.replace(/-/g, "") + "," + zbenchmark_value3.replace(/-/g, "") + ")";
            Result = false;
        }
    } else if (zbenchmark_type == '10') {
        /// 0 <= IN <= v1/1000
        if (parseFloat(value) >= 0 && parseFloat(value) <= parseFloat(zbenchmark_value1) / 1000) {
            Result = true;
        } else {
            //jizhun = "0～" + parseFloat(zbenchmark_value1) / 1000;
            jizhun = "(" + zbenchmark_value1.replace(/-/g, "") + "," + zbenchmark_value2.replace(/-/g, "") + "," + zbenchmark_value3.replace(/-/g, "") + ")";
            Result = false;
        }
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
        if (parseFloat(value) > 0 && parseFloat(value) <= parseFloat(zbenchmark_value1)) {
            Result = true;
        } else {
            //jizhun = "0～" + parseFloat(zbenchmark_value1) / 1000;
            jizhun = "(" + zbenchmark_value1.replace(/-/g, "") + "," + zbenchmark_value2.replace(/-/g, "") + "," + zbenchmark_value3.replace(/-/g, "") + ")";
            Result = false;
        }
    } else if (zbenchmark_type == '14') {
        // V1+V3<= IN < V1+V2
        if (parseFloat(value) >= accAdd(parseFloat(zbenchmark_value1), parseFloat(zbenchmark_value3)) && parseFloat(value) < accAdd(parseFloat(zbenchmark_value1) , parseFloat(zbenchmark_value2))) {
            Result = true;
        } else {
            //jizhun = (parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value3)) + "～" + (parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value2));
            jizhun = "(" + zbenchmark_value1.replace(/-/g, "") + "," + zbenchmark_value2.replace(/-/g, "") + "," + zbenchmark_value3.replace(/-/g, "") + ")";
            Result = false;
        }
    } else if (zbenchmark_type == '15-1') {
        // IN > V1
        if (parseFloat(value) > parseFloat(zbenchmark_value1)) {
            Result = true;
        } else {
            //jizhun = ">" + zbenchmark_value1;
            jizhun = "(" + zbenchmark_value1.replace(/-/g, "") + "," + zbenchmark_value2.replace(/-/g, "") + "," + zbenchmark_value3.replace(/-/g, "") + ")";
            Result = false;
        }
    } else if (zbenchmark_type == '16-1') {
        // IN < V1
        if (parseFloat(value) < parseFloat(zbenchmark_value1)) {
            Result = true;
        } else {
           // jizhun = "<" + zbenchmark_value1;
            jizhun = "(" + zbenchmark_value1.replace(/-/g, "") + "," + zbenchmark_value2.replace(/-/g, "") + "," + zbenchmark_value3.replace(/-/g, "") + ")";
            Result = false;
        }
    } else if (zbenchmark_type == '17-1') {
        // IN >= V1
        if (parseFloat(value) >= parseFloat(zbenchmark_value1)) {
            Result = true;
        } else {
            //jizhun = ">=" + zbenchmark_value1;
            jizhun = "(" + zbenchmark_value1.replace(/-/g, "") + "," + zbenchmark_value2.replace(/-/g, "") + "," + zbenchmark_value3.replace(/-/g, "") + ")";
            Result = false;
        }
    } else if (zbenchmark_type == '18-1') {
        // IN <= V1
        if (parseFloat(value) <= parseFloat(zbenchmark_value1)) {
            Result = true;
        } else {
            //jizhun = "<=" + zbenchmark_value1;
            jizhun = "(" + zbenchmark_value1.replace(/-/g, "") + "," + zbenchmark_value2.replace(/-/g, "") + "," + zbenchmark_value3.replace(/-/g, "") + ")";
            Result = false;
        }
    } else if (zbenchmark_type == '19-1') {
        // V1 + V3 < IN < V1 + V2
        if (parseFloat(value) > accAdd(parseFloat(zbenchmark_value1) , parseFloat(zbenchmark_value3)) && parseFloat(value) < accAdd(parseFloat(zbenchmark_value1) , parseFloat(zbenchmark_value2))) {
            Result = true;
        } else {
            //jizhun = (parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value3)) + "～" + (parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value2));
            jizhun = "(" + zbenchmark_value1.replace(/-/g, "") + "," + zbenchmark_value2.replace(/-/g, "") + "," + zbenchmark_value3.replace(/-/g, "") + ")";
            Result = false;
        }
    } else if (zbenchmark_type == '20-1') {
        // V1+v3 <= IN < V1 + V2
        if (parseFloat(value) >= accAdd(parseFloat(zbenchmark_value1) , parseFloat(zbenchmark_value3)) && parseFloat(value) < accAdd(parseFloat(zbenchmark_value1) , parseFloat(zbenchmark_value2))) {
            Result = true;
        } else {
            //jizhun = (parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value3)) + "～" + (parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value2));
            jizhun = "(" + zbenchmark_value1.replace(/-/g, "") + "," + zbenchmark_value2.replace(/-/g, "") + "," + zbenchmark_value3.replace(/-/g, "") + ")";
            Result = false;
        }
    }

    

    //绝对值取得
    var cha;
    cha = GetCha(tr);

    if (zbenchmark_type == '15-2') {
        // ｜V1-V2｜》v

        if (parseFloat(cha) > parseFloat(zbenchmark_value1)) {
            Result = true;
        } else {
            //jizhun = ">" + zbenchmark_value1;
            jizhun = "(" + zbenchmark_value1.replace(/-/g, "") + "," + zbenchmark_value2.replace(/-/g, "") + "," + zbenchmark_value3.replace(/-/g, "") + ")";
            Result = false;
        }

    } else if (zbenchmark_type == '16-2') {
        // ｜V1-V2｜《v1
        if (parseFloat(cha) < parseFloat(zbenchmark_value1)) {
            Result = true;
        } else {
            //jizhun = "<" + zbenchmark_value1;
            jizhun = "(" + zbenchmark_value1.replace(/-/g, "") + "," + zbenchmark_value2.replace(/-/g, "") + "," + zbenchmark_value3.replace(/-/g, "") + ")";
            Result = false;
        }
    } else if (zbenchmark_type == '17-2') {
        // ｜V1-V2｜》＝V1
        if (parseFloat(cha) >= parseFloat(zbenchmark_value1)) {
            Result = true;
        } else {
            //jizhun = ">=" + zbenchmark_value1;
            jizhun = "(" + zbenchmark_value1.replace(/-/g, "") + "," + zbenchmark_value2.replace(/-/g, "") + "," + zbenchmark_value3.replace(/-/g, "") + ")";
            Result = false;
        }
    } else if (zbenchmark_type == '18-2') {
        //｜V1-V2｜《＝V1
        if (parseFloat(cha) <= parseFloat(zbenchmark_value1)) {
            Result = true;
        } else {
           // jizhun = "<=" + zbenchmark_value1;
            jizhun = "(" + zbenchmark_value1.replace(/-/g, "") + "," + zbenchmark_value2.replace(/-/g, "") + "," + zbenchmark_value3.replace(/-/g, "") + ")";
            Result = false;
        }
    } else if (zbenchmark_type == '19-2') {
        // V1+V3 《 ｜V1-V2｜ 《 V1+V3
        if (parseFloat(cha) > accAdd(parseFloat(zbenchmark_value1) , parseFloat(zbenchmark_value3)) && parseFloat(cha) < accAdd(parseFloat(zbenchmark_value1) , parseFloat(zbenchmark_value2))) {
            Result = true;
        } else {
           // jizhun = (parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value3)) + "～" + (parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value2));
            jizhun = "(" + zbenchmark_value1.replace(/-/g, "") + "," + zbenchmark_value2.replace(/-/g, "") + "," + zbenchmark_value3.replace(/-/g, "") + ")";
            Result = false;
        }
    } else if (zbenchmark_type == '20-2') {
        // v1+v3 《＝｜V1-V2｜ 《 v1 ＋ V2
        if (parseFloat(cha) >= accAdd(parseFloat(zbenchmark_value1), parseFloat(zbenchmark_value3)) && parseFloat(cha) < accAdd(parseFloat(zbenchmark_value1), parseFloat(zbenchmark_value2))) {
            Result = true;
        } else {
           // jizhun = (parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value3)) + "～" + (parseFloat(zbenchmark_value1) + parseFloat(zbenchmark_value2));
            jizhun = "(" + zbenchmark_value1.replace(/-/g, "") + "," + zbenchmark_value2.replace(/-/g, "") + "," + zbenchmark_value3.replace(/-/g, "") + ")";
            Result = false;
        }
    }

    if (zbenchmark_type == '50') {//输入6个值，求平均数>=基准值1①，并且求最小值>=基准值1②

        var value1;
        var value2;
        var value3;
        var value4;
        var value5;
        var value6;
        var COND;
        var haveValueSuu;
        var sumValue;
        var minValue;
        var maxValue;
        var avgValue;
        haveValueSuu = 0;
        sumValue = 0;
        minValue = 0;
        maxValue = 0;
        avgValue = 0;

        /*
        if (zbenchmark_type != '12' && zbenchmark_type != '00') {
        if (isInteger(value)) {
        e.value = value + ".0"
        }
        }
        */
        COND = 1;
        while (COND <= 6) {
            value = $($(e).parent().parent()).find('.JQ_SHICE' + COND).val();
            if (value != '') {
                haveValueSuu++;
                eval("value" + COND + " = parseFloat(value); ");
                sumValue = sumValue + parseFloat(value);
                if (minValue == 0 || minValue > parseFloat(value)) {
                    minValue = value;
                }
                if (maxValue == 0 || maxValue < parseFloat(value)) {
                    maxValue = value;
                }

            }
            COND++;
        }



        //六个数全部输入
        if (haveValueSuu == 6) {

            avgValue = sumValue / 6;

            $($(e).parent().parent()).find(".JQ_atai2").val(toDecimal(minValue));
            $($(e).parent().parent()).find(".JQ_atai1").val(toDecimal(avgValue));

            var zbenchmark_value1_1;
            var zbenchmark_value1_2;
            var zbenchmark_value2_1;
            var zbenchmark_value2_2;
            var zbenchmark_value3_1;
            var zbenchmark_value3_2;

            zbenchmark_value1_1 = zbenchmark_value1.split('^')[0];
            zbenchmark_value1_2 = zbenchmark_value1.split('^')[1];
            zbenchmark_value2_1 = zbenchmark_value2.split('^')[0];
            zbenchmark_value2_2 = zbenchmark_value2.split('^')[1];
            zbenchmark_value3_1 = zbenchmark_value3.split('^')[0];
            zbenchmark_value3_2 = zbenchmark_value3.split('^')[1];

            // <=value<=

            if (CheckMax(avgValue, zbenchmark_value1_1)
                    && CheckMax(minValue, zbenchmark_value1_2)
            ) {
                Result = true;
            } else {
                Result = false;
                jizhun = "(" + zbenchmark_value1.replace(/-/g, "") + "," + zbenchmark_value2.replace(/-/g, "") + "," + zbenchmark_value3.replace(/-/g, "") + ")";
            }

        } else {

            $($(e).parent().parent()).find(".JQ_atai2").val('');
            $($(e).parent().parent()).find(".JQ_atai1").val('');

        }

    } else if (zbenchmark_type == '51') {//输入3个值，求平均数>=基准值1①，并且求最小值>=基准值1②

        var value1;
        var value2;
        var value3;
        var value4;
        var value5;
        var value6;
        var COND;
        var haveValueSuu;
        var sumValue;
        var minValue;
        var maxValue;
        var avgValue;
        haveValueSuu = 0;
        sumValue = 0;
        minValue = 0;
        maxValue = 0;
        avgValue = 0;

        /*
        if (zbenchmark_type != '12' && zbenchmark_type != '00') {
        if (isInteger(value)) {
        e.value = value + ".0"
        }
        }
        */
        COND = 1;
        while (COND <= 6) {
            value = $($(e).parent().parent()).find('.JQ_SHICE' + COND).val();
            if (value != '') {
                haveValueSuu++;
                eval("value" + COND + " = parseFloat(value); ");
                sumValue = sumValue + parseFloat(value);
                if (minValue == 0 || minValue > parseFloat(value)) {
                    minValue = value;
                }
                if (maxValue == 0 || maxValue < parseFloat(value)) {
                    maxValue = value;
                }

            }
            COND++;
        }



        //六个数全部输入
        if (haveValueSuu == 3) {

            avgValue = sumValue / 3;

            $($(e).parent().parent()).find(".JQ_atai2").val(minValue);
            $($(e).parent().parent()).find(".JQ_atai1").val(avgValue.toFixed(1));

            var zbenchmark_value1_1;
            var zbenchmark_value1_2;
            var zbenchmark_value2_1;
            var zbenchmark_value2_2;
            var zbenchmark_value3_1;
            var zbenchmark_value3_2;

            zbenchmark_value1_1 = zbenchmark_value1.split('^')[0];
            zbenchmark_value1_2 = zbenchmark_value1.split('^')[1];
            zbenchmark_value2_1 = zbenchmark_value2.split('^')[0];
            zbenchmark_value2_2 = zbenchmark_value2.split('^')[1];
            zbenchmark_value3_1 = zbenchmark_value3.split('^')[0];
            zbenchmark_value3_2 = zbenchmark_value3.split('^')[1];

            // <=value<=

            if (CheckMax(avgValue, zbenchmark_value1_1)
                    && CheckMax(minValue, zbenchmark_value1_2)
            ) {
                Result = true;
            } else {
                Result = false;
                jizhun = "(" + zbenchmark_value1.replace(/-/g, "") + "," + zbenchmark_value2.replace(/-/g, "") + "," + zbenchmark_value3.replace(/-/g, "") + ")";
            }

        } else {

            //$($(e).parent().parent()).find(".JQ_atai2").val('');
            $($(e).parent().parent()).find(".JQ_atai1").val('');

        }

    } else if (zbenchmark_type == '52') {//输入6个值，求最大数>=基准值1


        var value1;
        var value2;
        var value3;
        var value4;
        var value5;
        var value6;
        var COND;
        var haveValueSuu;
        var sumValue;
        var minValue;
        var maxValue;
        var avgValue;
        haveValueSuu = 0;
        sumValue = 0;
        minValue = 0;
        maxValue = 0;
        avgValue = 0;

        /*
        if (zbenchmark_type != '12' && zbenchmark_type != '00') {
        if (isInteger(value)) {
        e.value = value + ".0"
        }
        }
        */
        COND = 1;
        while (COND <= 6) {
            value = $($(e).parent().parent()).find('.JQ_SHICE' + COND).val();
            if (value != '') {
                haveValueSuu++;
                eval("value" + COND + " = parseFloat(value); ");
                sumValue = sumValue + parseFloat(value);
                if (minValue == 0 || minValue > parseFloat(value)) {
                    minValue = value;
                }
                if (maxValue == 0 || maxValue < parseFloat(value)) {
                    maxValue = value;
                }

            }
            COND++;
        }



        //六个数全部输入
        if (haveValueSuu == 6) {

            avgValue = sumValue / 6;

            $($(e).parent().parent()).find(".JQ_atai1").val(maxValue);
            $($(e).parent().parent()).find(".JQ_atai2").val('');

            // <=value<=

            if (CheckMin(maxValue, zbenchmark_value1)) {
                Result = true;
            } else {
                Result = false;
                jizhun = "(" + zbenchmark_value1.replace(/-/g, "") + "," + zbenchmark_value2.replace(/-/g, "") + "," + zbenchmark_value3.replace(/-/g, "") + ")";
            }

        } else {
            $($(e).parent().parent()).find(".JQ_atai2").val('');
            $($(e).parent().parent()).find(".JQ_atai1").val('');
        }
    } else if (zbenchmark_type == '53') {//输入3个值，求最大数>=基准值1

        var value1;
        var value2;
        var value3;
        var value4;
        var value5;
        var value6;
        var COND;
        var haveValueSuu;
        var sumValue;
        var minValue;
        var maxValue;
        var avgValue;
        haveValueSuu = 0;
        sumValue = 0;
        minValue = 0;
        maxValue = 0;
        avgValue = 0;

        /*
        if (zbenchmark_type != '12' && zbenchmark_type != '00') {
        if (isInteger(value)) {
        e.value = value + ".0"
        }
        }
        */
        COND = 1;
        while (COND <= 6) {
            value = $($(e).parent().parent()).find('.JQ_SHICE' + COND).val();
            if (value != '') {
                haveValueSuu++;
                eval("value" + COND + " = parseFloat(value); ");
                sumValue = sumValue + parseFloat(value);
                if (minValue == 0 || minValue > parseFloat(value)) {
                    minValue = value;
                }
                if (maxValue == 0 || maxValue < parseFloat(value)) {
                    maxValue = value;
                }

            }
            COND++;
        }



        //六个数全部输入
        if (haveValueSuu == 3) {

            avgValue = sumValue / 3;

            $($(e).parent().parent()).find(".JQ_atai1").val(maxValue);
            //$($(e).parent().parent()).find(".JQ_atai2").val('');

            // <=value<=

            if (CheckMin(maxValue, zbenchmark_value1)) {
                Result = true;
            } else {
                Result = false;
                jizhun = "(" + zbenchmark_value1.replace(/-/g, "") + "," + zbenchmark_value2.replace(/-/g, "") + "," + zbenchmark_value3.replace(/-/g, "") + ")";
            }

        } else {
            //$($(e).parent().parent()).find(".JQ_atai2").val('');
            $($(e).parent().parent()).find(".JQ_atai1").val('');
        }
    } else if (zbenchmark_type == '54') {//输入3个值，求最小数>=基准值1
        //***平面引张

        var value1;
        var value2;
        var value3;
        var value4;
        var value5;
        var value6;
        var COND;
        var haveValueSuu;
        var sumValue;
        var minValue;
        var maxValue;
        var avgValue;
        haveValueSuu = 0;
        sumValue = 0;
        minValue = 0;
        maxValue = 0;
        avgValue = 0;

        /*
        if (zbenchmark_type != '12' && zbenchmark_type != '00') {
        if (isInteger(value)) {
        e.value = value + ".0"
        }
        }
        */
        COND = 1;
        while (COND <= 6) {
            value = $($(e).parent().parent()).find('.JQ_SHICE' + COND).val();
            if (value != '') {
                haveValueSuu++;
                eval("value" + COND + " = parseFloat(value); ");
                sumValue = sumValue + parseFloat(value);
                if (minValue == 0 || minValue > parseFloat(value)) {
                    minValue = value;
                }
                if (maxValue == 0 || maxValue < parseFloat(value)) {
                    maxValue = value;
                }

            }
            COND++;
        }



        //六个数全部输入
        if (haveValueSuu == 3) {

            avgValue = sumValue / 3;

            $($(e).parent().parent()).find(".JQ_atai1").val(minValue);
            //$($(e).parent().parent()).find(".JQ_atai2").val('');

            // <=value<=

            if (CheckMax(minValue, zbenchmark_value1)) {
                Result = true;
            } else {
                Result = false;
                jizhun = "(" + zbenchmark_value1.replace(/-/g, "") + "," + zbenchmark_value2.replace(/-/g, "") + "," + zbenchmark_value3.replace(/-/g, "") + ")";
            }

        } else {
            //$($(e).parent().parent()).find(".JQ_atai2").val('');
            $($(e).parent().parent()).find(".JQ_atai1").val('');
        }
    } else if (zbenchmark_type == '55') {
        // ｜V1-V2｜《v1
        if (parseFloat(cha) / value < parseFloat(zbenchmark_value1)) {
            Result = true;
        } else {
            //jizhun = "<" + zbenchmark_value1;
            jizhun = "(" + zbenchmark_value1.replace(/-/g, "") + "," + zbenchmark_value2.replace(/-/g, "") + "," + zbenchmark_value3.replace(/-/g, "") + ")";
            Result = false;
        }

    } else if (zbenchmark_type == '56') {//输入6个值，求平均数>=基准值1
        var value1;
        var value2;
        var value3;
        var value4;
        var value5;
        var value6;
        var COND;
        var haveValueSuu;
        var sumValue;
        var minValue;
        var maxValue;
        var avgValue;
        haveValueSuu = 0;
        sumValue = 0;
        minValue = 0;
        maxValue = 0;
        avgValue = 0;

        /*
        if (zbenchmark_type != '12' && zbenchmark_type != '00') {
        if (isInteger(value)) {
        e.value = value + ".0"
        }
        }
        */
        COND = 1;
        while (COND <= 6) {
            value = $($(e).parent().parent()).find('.JQ_SHICE' + COND).val();
            if (value != '') {
                haveValueSuu++;
                eval("value" + COND + " = parseFloat(value); ");
                sumValue = sumValue + parseFloat(value);
                if (minValue == 0 || minValue > parseFloat(value)) {
                    minValue = value;
                }
                if (maxValue == 0 || maxValue < parseFloat(value)) {
                    maxValue = value;
                }

            }
            COND++;
        }



        //六个数全部输入
        if (haveValueSuu == 6) {

            avgValue = sumValue / 6;

            $($(e).parent().parent()).find(".JQ_atai1").val(avgValue.toFixed(1));
            $($(e).parent().parent()).find(".JQ_atai2").val('');

            // <=value<=

            if (CheckMax(avgValue, zbenchmark_value1)) {
                Result = true;
            } else {
                Result = false;
                jizhun = "(" + zbenchmark_value1.replace(/-/g, "") + "," + zbenchmark_value2.replace(/-/g, "") + "," + zbenchmark_value3.replace(/-/g, "") + ")";
            }

        } else {
            $($(e).parent().parent()).find(".JQ_atai2").val('');
            $($(e).parent().parent()).find(".JQ_atai1").val('');
        }
    } else if (zbenchmark_type == '57') {//输入6个值，每个数都<=基准值1（其中5个数合格时，则判定合格）

        var value1;
        var value2;
        var value3;
        var value4;
        var value5;
        var value6;
        var COND;
        var haveValueSuu;
        var sumValue;
        var minValue;
        var maxValue;
        var avgValue;
        var okSuu;
        haveValueSuu = 0;
        sumValue = 0;
        minValue = 0;
        maxValue = 0;
        avgValue = 0;
        okSuu = 0;

        /*
        if (zbenchmark_type != '12' && zbenchmark_type != '00') {
        if (isInteger(value)) {
        e.value = value + ".0"
        }
        }
        */
        COND = 1;
        while (COND <= 6) {
            value = $($(e).parent().parent()).find('.JQ_SHICE' + COND).val();
            if (value != '') {
                haveValueSuu++;
                eval("value" + COND + " = parseFloat(value); ");
                sumValue = sumValue + parseFloat(value);
                if (minValue == 0 || minValue > parseFloat(value)) {
                    minValue = value;
                }
                if (maxValue == 0 || maxValue < parseFloat(value)) {
                    maxValue = value;
                }
                if (value <= parseFloat(zbenchmark_value1)) {
                    okSuu++;
                }


            }
            COND++;
        }



        //六个数全部输入
        if (haveValueSuu == 6) {

            avgValue = sumValue / 6;

            $($(e).parent().parent()).find(".JQ_atai1").val('');
            $($(e).parent().parent()).find(".JQ_atai2").val('');

            if (okSuu >= 5) {
                Result = true;
            } else {
                Result = false;
                jizhun = "(" + zbenchmark_value1.replace(/-/g, "") + "," + zbenchmark_value2.replace(/-/g, "") + "," + zbenchmark_value3.replace(/-/g, "") + ")";
            }

        } else {
            $($(e).parent().parent()).find(".JQ_atai2").val('');
            $($(e).parent().parent()).find(".JQ_atai1").val('');
        }
    }


    //如果正确  1.设置合格   2.设置背景色   3.清空 备考
    if (Result) {

        //结果
        //$($(e).parent().parent().children("td")[5]).text('合'); //合格
        $($(e).parent().parent()).find(".JQ_JIEGUO").text('合'); 
        //基准
        //$($(e).parent().parent().children("td")[6].children[0]).val(''); //备考
        //$($(e).parent().parent().children("td")[7]).text(''); //备考
        $($(e).parent().parent()).find(".JQ_BEIZHU").text(''); 
        
   

    } else {
        //结果
        //$($(e).parent().parent().children("td")[5]).text('误');
        $($(e).parent().parent()).find(".JQ_JIEGUO").text('误'); 
        //基准 
        //$($(e).parent().parent().children("td")[6].children[0]).val(jizhun);
        //$($(e).parent().parent().children("td")[7]).text(jizhun);
        $($(e).parent().parent()).find(".JQ_JIZHUN").text(jizhun);

    }

    SetResultBackColorByResult($(e).parent().parent());

}

function CheckMinMaxEq(value, zbenchmark_value1, zbenchmark_value2, zbenchmark_value3) {
    zbenchmark_value1 = parseFloat(zbenchmark_value1);
    zbenchmark_value2 = parseFloat(zbenchmark_value2);
    zbenchmark_value3 = parseFloat(zbenchmark_value3);

    if (value <= (zbenchmark_value1 + zbenchmark_value2) && value >= (zbenchmark_value1 + zbenchmark_value3)) {
        return true;
    } else {
        return false;
    }
}
function CheckMax(value, zbenchmark_value1) {
    zbenchmark_value1 = parseFloat(zbenchmark_value1);
    if (value >= zbenchmark_value1) {
        return true;
    } else {
        return false;
    }
} 
function CheckMin(value, zbenchmark_value1) {
    zbenchmark_value1 = parseFloat(zbenchmark_value1);
    if (value <= zbenchmark_value1) {
        return true;
    } else {
        return false;
    }
}


//差 的绝对值 取得
function GetCha(e) {
    var v1, v2;
    v1 = e.children("td")[3].children[0].value; //parseFloat($(e.children("td")[3]).text());
    $($(e).parent().parent()).find(".JQ_JIEGUO")
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



function RoundUp(num) {
    if (Math.floor(accDiv(accMul(num, 1000), 10)) < accDiv(accMul(num, 1000), 10)) {
        return accDiv(Math.floor(accMul(num, 100) + 1), 100).toFixed(2);
    } else {
        return accDiv(Math.floor(accMul(num, 100)), 100).toFixed(2);
    }
}


/*
JS固有バッグ回避ために、掛け算方法を作成
*/
function accDiv(arg1, arg2) {
    var t1 = 0, t2 = 0, r1, r2;
    try { t1 = arg1.toString().split(".")[1].length } catch (e) { }
    try { t2 = arg2.toString().split(".")[1].length } catch (e) { }
    with (Math) {
        r1 = Number(arg1.toString().replace(".", ""))
        r2 = Number(arg2.toString().replace(".", ""))
        return accMul((r1 / r2), pow(10, t2 - t1));
    }
}

/*
JS固有バッグ回避ために、乗算方法を作成
*/
function accMul(arg1, arg2) {
    var m = 0, s1 = arg1.toString(), s2 = arg2.toString();
    try { m += s1.split(".")[1].length } catch (e) { }
    try { m += s2.split(".")[1].length } catch (e) { }
    return Number(s1.replace(".", "")) * Number(s2.replace(".", "")) / Math.pow(10, m)
}

/*
2013/03/07　P-39443 于磊 新規作成 
JS固有バッグ回避ために、加算方法を作成
*/
function accAdd(arg1, arg2) {
    var r1, r2, m;
    try { r1 = arg1.toString().split(".")[1].length } catch (e) { r1 = 0 }
    try { r2 = arg2.toString().split(".")[1].length } catch (e) { r2 = 0 }
    m = Math.pow(10, Math.max(r1, r2))
    //return (arg1*m+arg2*m)/m;
    return accDiv((accMul(arg1, m) + accMul(arg2, m)), m);
}

/*
2013/03/07　P-39443 于磊 新規作成
JS固有バッグ回避ために、減算方法を作成
*/
function Subtr(arg1, arg2) {
    var r1, r2, m, n;
    try { r1 = arg1.toString().split(".")[1].length } catch (e) { r1 = 0 }
    try { r2 = arg2.toString().split(".")[1].length } catch (e) { r2 = 0 }
    m = Math.pow(10, Math.max(r1, r2));
    n = (r1 >= r2) ? r1 : r2;
    return (accDiv((accMul(arg1, m) - accMul(arg1, m)), m)).toFixed(n);
}

function Fix2(num) {
    return RoundUp(num);
}
