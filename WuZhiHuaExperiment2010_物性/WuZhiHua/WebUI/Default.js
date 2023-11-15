var Gl_FocusTextbox;
Gl_FocusTextbox = null;

$(document).ready(function () {

    $(".jq_zzcChk input[type=checkbox]").each(function () {

        $(this).width(40);
        $(this).height(40);

    });

    $(".jq_zzcChk input[type=checkbox]").click(function () {
        if (this.checked) {
            $(this).parent().css("color", "blue");
        } else {
            $(this).parent().css("color", "#000");
        }

    });
    $("#ctl00_MC_btnReCheck").click(function (e) {
        var rtv;
        rtv = false;
        $(".jq_zzcChk input[type=checkbox]").each(function () {
            if (this.checked) {
                rtv = true;
            }
        });
        if (rtv == false) {
            alert("请注意：没有选择对应的计划，但是继续新规了");
            return true;
        }
        return true;
        //jq_zzc
    });


    $("#kl").click(function (e) {
        $("#ctl00_MC_tbxGoodsCd").val('');
        $("#ctl00_MC_hidBumen").val('');
        $("#ctl00_MC_hidLineName").val('');
    });

    var arrDLX = [];
    var arrDLXAll = $("#ctl00_MC_hidDLX").val().split("|");
    var arrDataListForDLX = [];

    var i;
    var arrHTML_xingfan = [];
    var arrHTML_bumen = [];
    var arrHTML_line = [];
    for (i = 0; i <= arrDLXAll.length - 1; i++) {
        //var cl = arrDLXAll[i].split(",");
        arrDLX.push(arrDLXAll[i].split(","));
        //型番设定
        //arrHTML_xingfan.push("<option value=\"" + arrDLX[i][2] + "\">" + arrDLX[i][2] +"</option>");
    }

    function InitAll() {


        InitBumen();
        if ($("#ctl00_MC_hidBumen").val() != '') {
            $("#ctl00_MC_lbBumen").val($("#ctl00_MC_hidBumen").val());
        }
        InitLines();
        if ($("#ctl00_MC_hidLineName").val() != '') {
            $("#ctl00_MC_cbLineName").val($("#ctl00_MC_hidLineName").val());
        }

    }


    function InitBumen() {
        var xingfan = $("#ctl00_MC_tbxGoodsCd").val();
        var arrBumen = [];

        arrHTML_bumen = [];
        for (i = 0; i <= arrDLX.length - 1; i++) {
            if ((arrBumen.length == 0 || arrBumen.indexOf(arrDLX[i][0]) < 0) && xingfan == arrDLX[i][2]) {
                arrHTML_bumen.push("<option value=\"" + arrDLX[i][0] + "\">" + arrDLX[i][0] + "</option>");
                arrBumen.push(arrDLX[i][0]);
            }

        }
        $("#ctl00_MC_lbBumen").html(arrHTML_bumen.join("\n"));



        InitLines();
    }

    InitAll();

    $("#ctl00_MC_tbxGoodsCd").bind("input propertychange", function () {

        InitBumen();

        $("#ctl00_MC_lbBumen")[0].selectedIndex = 0;
        $("#ctl00_MC_hidBumen").val($("#ctl00_MC_lbBumen").val());

        InitLines();

        $("#ctl00_MC_cbLineName")[0].selectedIndex = 0;
        $("#ctl00_MC_hidLineName").val($("#ctl00_MC_cbLineName").val());

        //cbLineName

    });

    $("#ctl00_MC_lbBumen").change(function () {

        InitLines();

        /* $("#ctl00_MC_cbLineName").html(arrHTML_line.join("\n"));*/
        $("#ctl00_MC_cbLineName")[0].selectedIndex = 0;
        $("#ctl00_MC_hidLineName").val($("#ctl00_MC_cbLineName").val());

        $("#ctl00_MC_hidBumen").val($("#ctl00_MC_lbBumen").val());
        //var arrLineName = [];
    });

    $("#ctl00_MC_cbLineName").change(function () {
        $("#ctl00_MC_hidLineName").val($("#ctl00_MC_cbLineName").val());
        //var arrLineName = [];
    });

    function InitLines() {
        var xingfan = $("#ctl00_MC_tbxGoodsCd").val();
        var bumen = $("#ctl00_MC_lbBumen").val();
        arrHTML_line = [];
        for (i = 0; i <= arrDLX.length - 1; i++) {
            if (arrDLX[i][2] == xingfan && arrDLX[i][0] == bumen) {
                arrHTML_line.push("<option value=\"" + arrDLX[i][1] + "\">" + arrDLX[i][1] + "</option>");
                //arrLineName.push(arrDLX[i][1]);
            }
        }
        $("#ctl00_MC_cbLineName").html(arrHTML_line.join("\n"));
    }


    //lbBumen
    //xingfan_bumen_list
    //line_name_list



    //文本框 选择时 选择行
    $(".defaultPage_textbox_scan").focus(function (e) {
        Gl_FocusTextbox = this;
    });

    //扫描文本框 鼠标抬起
    $(".defaultPage_textbox_scan").mouseup(function (e) {
        this.select();
    });

    //扫描文本框 焦点到下一个元素 因为除了IE浏览器都不支持 Key.Code = 13*/
    $(".defaultPage_textbox_scan").keydown(function (e) {

        if (e.which == 13) {
            //获得行的基准值 ，并且根据基准值进行检查
            //CheckRowInput(this);
            //设置焦点到下一个单元格
            //SetNextFocus(e, this);

            e.preventDefault ? e.preventDefault() : e.returnValue = false;
        } else if (e.which == 0) {
            GL_JQ_SCAN_TEXTBOX = $(this);
            $(this).val("");
            $("#tbxScanSave").val("");
            $("#tbxScanSave").select();
            return false;
        }
    });

    $("#tbxScanSave").keydown(function (e) {

        var curKey = e.which;

        if (curKey == 13) {
            var v;
            v = $(this).val();
            v = v.replace(/ /g, "");
            v = v.replace(/-/g, "");

            if (v.length > 8) {
                v = v.substring(4, v.length - 4);

                if (v.substring(0, 2) != 'Y7') {
                    v = v.replace(/-/g, "");
                }

                $(this).val(v);

                GL_JQ_SCAN_TEXTBOX.val(v);
            }

            e.preventDefault ? e.preventDefault() : e.returnValue = false;
            return false;
        }
    });



});


function fnUpdQianpin(e, id) {
    var qianpin_flg;
    if (e.checked) {
        qianpin_flg = '1';
    } else {
        qianpin_flg = '0';
    }

    $.ajax({
        type: "POST",
        url: "AJAX.aspx?k=31&param=" + id + '|' + qianpin_flg,
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

//日付チェック
function GetDateFormat(e) {
    var v;
    var Y;
    var M;
    var D;
    Y = "";
    M = "";
    D = "";
    v = SetDateNoSign(e.value, " ");

    if (v.split("/").length == 3) {
        Y = v.split("/")[0];
        M = v.split("/")[1];
        D = v.split("/")[2];

    } else if (v.split("-").length == 3) {
        Y = v.split("-")[0];
        M = v.split("-")[1];
        D = v.split("-")[2];
    } else {

        v = SetDateNoSign(v, "/");
        v = SetDateNoSign(v, "-");

        if (v.length == 6) { //6桁の場合
            if (v.substring(0, 2) > 70) {
                v = "19" + v;
            } else {
                v = "20" + v;
            }

        } else if (v.length == 4) { //4桁の場合
            dd = new Date();
            v = dd.getFullYear() + v;

        }

        if (v.length == 8) {
            Y = v.substring(0, 4);
            M = v.substring(4, 6);
            D = v.substring(6, 8);
        }
    }

    if (Y.length == 2 && Y.substring(0, 2) > 70) {
        Y = "19" + Y;
    }

    if (Y.length == 2 && Y.substring(0, 2) <= 70) {
        Y = "20" + Y;
    }

    if (Y == 'undefined' || Y == undefined || M == 'undefined' || M == undefined || D == 'undefined' || D == undefined || M.length > 2 || D.length > 2 || Y.length == 3) {
        return false;
    }


    if (M.length == 1) {
        M = "0" + M;
    }
    if (D.length == 1) {
        D = "0" + D;
    }

    if (!checkDateVali(Y, M, D) || Y < "1753") {
        return false;

    } else {
        e.value = Y + "/" + M + "/" + D;
        return Y + "/" + M + "/" + D;

    }
}

function SetDateNoSign(value, sign) {

    var arr;
    var strResult = "";
    arr = value.split(sign);

    var i;

    for (i = 0; i <= arr.length - 1; i++) {
        if (arr[i].length == 1) {
            arr[i] = "0" + arr[i];
        }
    }

    strResult = arr.join("");
    strResult = strResult == "" ? value : strResult;

    return strResult;
}

function checkDateVali(y, m, d) {
    var di = new Date(y, m - 1, d);
    if (di.getFullYear() == y && di.getMonth() == m - 1 && di.getDate() == d) {
        return true;
    }
    return false;
}
