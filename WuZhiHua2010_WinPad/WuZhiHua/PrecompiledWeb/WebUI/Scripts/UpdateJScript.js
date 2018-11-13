
function ConfirmMsg(e) {
    return confirm('是否' + e.value+"?");
}


function ConfirmKanryouMsg(e) {

    var myResult;
    myResult = '';

    var msg;
    msg = "";
    $.ajax({
        type: "POST",
        async: false,
        url: "AJAX.aspx?k=2&param=" + $("#ctl00_FC_hidResult_id").val(),
        success: function (d) {
            if (d == "OK") {
                myResult = 'OK';
            } else if (d.split(',')[0] == 'LOU') {
                myResult = 'LOU';
                msg = d.split(',')[1];
            } else {
                myResult = 'NG';
                msg = d;
            }
        },
        error: function (e) {
            alert(e.responseText);
        }
    });

    if (myResult == 'OK') {
        return true;
        //return confirm('是否' + e.value + "?");
    } else if (myResult == 'LOU') {
        alert("存在漏检的情况[" + msg + "]");
        alert("不能完了退出");
        return false;
    } else {
        return true;
        //alert("存在轻 中 重 误 漏检的情况[" + msg + "]");
        //return confirm('是否完了');
    }


}




function UpdateRow(myasyn) {

    var tr;
    tr = $(dom_old_select_row);

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
    var value1, value2;

    value1 = tr.children("td")[3].children[0].value;
    value2 = tr.children("td")[4].children[0].value;
    var jieguo;
    jieguo = $(tr.children("td")[5]).text();

    var beizhu;
    beizhu = tr.children("td")[6].children[0].value;

    if (!checkSpecial(beizhu)) {
        alert("备注不能填写@%&!*等特殊字符");
        tr.children("td")[6].children[0].focus();
        return false;
     }
 



    var param;
    param = Result_id + '|' + checkID + '|' + value1 + '|' + value2 + '|' + jieguo + '|' + zbenchmark_type + '|' + zbenchmark_value1 + '|' + zbenchmark_value2 + '|' + zbenchmark_value3 + '|' + dis_no + '|' + beizhu + '|' + checkTimes;

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