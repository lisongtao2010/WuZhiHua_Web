
function ConfirmMsg(e) {

    return confirm('是否' + e.value+"?");

}

function UpdateRow(myasyn) {

    var tr;
    tr = $(GL_OLD_SELECTED_ROW);

    if (tr.length == 0) {
        return;
    }

    var Result_id;
    Result_id = $("#ctl00_FC_hidResult_id").val();


    var checkID;
    checkID = tr.attr("zID");

    var dis_no;
    dis_no = tr.attr("dis_no");

    //基准值 类型 值1～3
    var zbenchmark_type;
    var zbenchmark_value1;
    var zbenchmark_value2;
    var zbenchmark_value3;

    zbenchmark_type = tr.attr("zbenchmark_type");
    zbenchmark_value1 = tr.attr("zbenchmark_value1");
    zbenchmark_value2 = tr.attr("zbenchmark_value2");
    zbenchmark_value3 = tr.attr("zbenchmark_value3");
    var checkTimes;
    checkTimes = tr.attr("check_times");
    var usercd;
    usercd = $("#ctl00_FC_tbxCheckUserCd").val();

    var value1;
    var value2;
    var value3;
    var value4;
    var value5;
    var value6;
    var COND;
    COND = 1;
    while (COND <= 6) {
        value = $(tr).find('.JQ_SHICE' + COND).val();
        if (value != '') {
            eval("value" + COND + " = parseFloat(value); ");
        } else {
            eval("value" + COND + " = ''; ");
        }
        COND++;
    }



   









    var jieguo;
    jieguo = $(tr).find(".JQ_JIEGUO").text(); 

    var beizhu;
    beizhu = $(tr).find(".JQ_BEIZHU").val();

    if (!checkSpecial(beizhu)) {
        alert("备注不能填写@%&!*等特殊字符");
        tr.children("td")[6].children[0].focus();
        return false;
     }

    var param;
    param = Result_id + '|' + checkID + '|' + value1 + '|' + value2 + '|' + value3 + '|' + value4 + '|' + value5 + '|' + value6 + '|' + jieguo + '|' + zbenchmark_type + '|' + zbenchmark_value1 + '|' + zbenchmark_value2 + '|' + zbenchmark_value3 + '|' + dis_no + '|' + beizhu + '|' + checkTimes + '|' + usercd;

    if (myasyn == undefined) {
        myasyn = true;
    }
    $.ajax({
        type: "POST",
        async: myasyn,
        url: "AJAX.aspx?k=1&param=" + param,
        success: function (d) {
            if (d == "NG") {
                alert("更新出错");
            } else {
                $(".JQ_RESULT_MSG").text(d);
            }
        },
        error: function (e) {
            alert(e.responseText);
        }
    });
}


function checkSpecial(str) {
    if (str == "") { return true; }

    var reg = /^[^@\/\'\\\"#$%&\^\*]+$/;
    if (reg.test(str)) {
        return true;
    } else {

        return false; //包含非法字符

    }
}