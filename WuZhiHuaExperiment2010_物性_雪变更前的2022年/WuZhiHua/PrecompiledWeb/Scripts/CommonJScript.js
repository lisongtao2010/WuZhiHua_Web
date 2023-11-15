//行选择 变色
var GL_OLD_SELECTED_ROW;

var oColor = { white: "#fff", red: "red" };
var oCSS = { BGColor: "background-color", FontColor: "color" };

function RowSelect(e) {
    keyBoardFlg = true; //Tools 页专用  为什么？

    Gl_FocusTextbox = null;

    if (GL_OLD_SELECTED_ROW != undefined) {
        //根据结果 设置背景色
        SetResultBackColorByResult(GL_OLD_SELECTED_ROW);
        $(GL_OLD_SELECTED_ROW).css(oCSS.BGColor, oColor.white); //前回选择的航颜色恢复
    }

    $(e).css(oCSS.BGColor, conSelectRowClolor); //当前选择航变色
    GL_OLD_SELECTED_ROW = e; //纪录当前行

    if (document.activeElement.tagName == "TEXTAREA" ) {

    }else if (document.activeElement.tagName != "INPUT" ) {
        e.focus();
    }

}

function GetResultTDFromTr(tr) {

    var resultTd;

    tr = FindParentTR(tr);

    if (tr == null) {
        return null;
    }

    resultTd = $(tr).find(".JQ_JIEGUO");

    if (resultTd.length > 0) {
        return resultTd;
    }

    return null;

}


function SetResultBackColorByResult(sender) {
    var JqTd;
    var txt;
    JqTd = GetResultTDFromTr(sender);

    if (JqTd != null) {
        txt = JqTd[0].innerText;
        if (txt == '合' || txt == '微' || txt == '警') { //LightGreen
            JqTd.css(oCSS.BGColor, conLightGreen); //绿
            return;
        } else if (txt == '') { } else {
            JqTd.css(oCSS.BGColor, conLightRed); //红
            return;
        }
    }
}


//////////////////小键盘输入///////////////////////

//////////////////////////////////////////////////



function KeyBoard(e) {

    var txt;
    txt = $(e).text();
    var oldBgColor;
    oldBgColor = $(e).css(oCSS.BGColor);

    if (oldBgColor != "rgb(193, 205, 193)") {

        $(e).css(oCSS.BGColor, "#C1CDC1");

        setTimeout(function () {
            $(e).css(oCSS.BGColor, oldBgColor);
        }, 200);

    }



    var obj;

    if (Gl_FocusTextbox == null) {
        obj = GL_OLD_SELECTED_ROW;
    } else {
        obj = Gl_FocusTextbox;
    }

    if (txt == '合' || txt == '轻' || txt == '微' || txt == '中' || txt == '重' || txt == '警') {
        SetSelectResult(txt);
        UpdateRow();
        SetNextFocus(event, obj ,false);
    } else if (txt == '回车') {

        CheckRowInput(Gl_FocusTextbox);
        UpdateRow();
        SetNextFocus(event, obj, true);
    } else {

        if (Gl_FocusTextbox == null) {

        } else {
            if (txt == "删") {
                $(Gl_FocusTextbox).val("");
            } else {
                $(Gl_FocusTextbox).val($(Gl_FocusTextbox).val() + txt);
                $(Gl_FocusTextbox)[0].focus();
            }
        }

    }
}



function SetSelectResult(txt) {
    var JqTd;
    JqTd = GetResultTDFromTr(GL_OLD_SELECTED_ROW);

    if (JqTd != null) {
        JqTd.text(txt);
    }

}


//////////////////检查本画面是否全部OK///////////////////////

//////////////////////////////////////////////////

var ALLROWFLG;

function CheckAllOk() {
    ALLROWFLG = 0;

    $.each($(".JQ_JIEGUO"), function (index, item) {

        //return false;——跳出所有循环；相当于 javascript 中的 break 效果。
        //return true;——跳出当前循环，进入下一个循环；相当于 javascript 中的 continue 效果

        if (ALLROWFLG != 0) {
            return true;
        }
        if (ALLROWFLG == 0 && ($(this).text() == '轻' || $(this).text() == '中' || $(this).text() == '重' || $(this).text() == '误')) {
            ALLROWFLG = 1;
            return false;
        } else if (ALLROWFLG == 0 && $(this).text() == '') {
            ALLROWFLG = 2;
            return true;
        }
    });

    if (ALLROWFLG == 1) {
        $(".JQ_SELECT_CELL").css(oCSS.FontColor, oColor.red);
    } else if (ALLROWFLG == 2) {
        $(".JQ_SELECT_CELL").css(oCSS.FontColor, oColor.red);
    } else {
        $(".JQ_SELECT_CELL").css(oCSS.FontColor, "#00A600"); //全部合格
    }
}




//////////////////检查是否是最后一行///////////////////////

//////////////////////////////////////////////////


function IsLastRow(sender) {
    return (GetMSRowsCount() - 1 == GetRowIndex(sender));
} /* 获得明细行数 */
var GL_MsRowCount;
GL_MsRowCount = -1;

function GetMSRowsCount() {
    if (GL_MsRowCount == -1) {
        GL_MsRowCount = $(".JQ_CheckMS")[0].rows.length;
    }
    return GL_MsRowCount;
}



//////////////////获得下一个元素///////////////////////

//////////////////////////////////////////////////


/* 获得下一个元素 */

function SetNextFocus(e, sender ,nextTextBoxFlg) {

    //检查所有输入项目是否OK
    CheckAllOk();

    var obj;
    obj = $(sender);
    if (nextTextBoxFlg && obj.length > 0) {


        if (obj[0].tagName == "INPUT" && obj.css("display") != "none") {

            var idxShice;
            idxShice = 1;

            while (idxShice < 6) {
                
                //如果不是实测的入力框
                //if (obj[0].className.indexOf("JQ_SHICE" + idxShice) != -1) {
                if (IsInputDisplayAndShiCe(obj, "JQ_SHICE" + idxShice)) {
                    /*
                    var nextTR;
                    nextTR = $(FindParentTR(sender));

                    var shiceObj;
                    shiceObj = nextTR.find(".JQ_SHICE" + (idxShice+1));
                    if (shiceObj.css("display") != "none") {
                        SetFocusAndSelectText(shiceObj);
                        return true;
                    }*/

                    if (SetFocusSelectShiCe_And_SelectRow(GetTR(sender), ".JQ_SHICE" + (idxShice + 1))) {
                        return true;
                    } 

                    idxShice = 10; //exit while

                }

                idxShice++;

            }

        }
    }

    if (IsLastRow(sender)) {
        SetFocusAndSelectText(sender);
        return;
    } else {
        SelectNextRow_And_SetTextBoxFocus(sender);
    }

    return true;

}


function SetFocusAndSelectText(sender) {
    var obj;
    obj = $(sender);
    if (obj.length > 0) {
        obj[0].focus();
        if (obj[0].tagName == "INPUT") {
            obj[0].select();
            GL_JQ_INPUT_TEXTBOX_OLD_VALUE = obj[0].value;
        }
    }
}


function IsInputDisplayAndShiCe(sender, shiCeName) {
    var obj = $(sender);
    try {
        if (obj[0].tagName == "INPUT" && obj.css("display") != "none") {
            if (obj[0].className.indexOf(shiCeName) != -1) {
                return true;
            }
        }
        return false;

    } catch (e) {
        return false;
    }
}


/* 选择下一行 */
function SelectNextRow_And_SetTextBoxFocus(sender) {
    var nextTR = GetNextTR(sender);
    if (nextTR == null) {
        RowSelect(nextTR[0]);
        return true;
    } else {
        if (SetFocusSelectShiCe_And_SelectRow(nextTR, ".JQ_SHICE1")) { return true; }
        if (SetFocusSelectShiCe_And_SelectRow(nextTR, ".JQ_SHICE2")) { return true; }
        RowSelect(nextTR[0]);
    }
}



    //获得下一个TR
    function GetTR(sender) {
        var tr;
        tr = $(FindParentTR(sender));
        if (tr.length > 0) {
            return tr;
        } else {
            return null;
        }
    }

    //获得下一个TR
    function GetNextTR(sender) {
        var tr;
        tr = $(FindParentTR(sender));
        if (tr.length > 0) {
            if (tr.next().length > 0) {
                return tr.next();
            } else {
                return null;
            }
        } else {
            return null;
        }
    }

    //设置实测值焦点
    function SetFocusSelectShiCe_And_SelectRow(jq_tr, shiCeName) {

        var jq_shiCeObj;

        jq_ShiCeObj = jq_tr.find(shiCeName);

        if (jq_ShiCeObj.length > 0) {
            if (jq_ShiCeObj.css("display") != "none") {
                RowSelect(jq_tr[0]);
                jq_ShiCeObj[0].focus();
                jq_ShiCeObj[0].select();
                GL_JQ_INPUT_TEXTBOX_OLD_VALUE = jq_ShiCeObj[0].value;
                return true;
            }
        }

        return false;
    }


//获得活动行号
function GetRowIndex(sender) {
    try {
            var objTr;
            objTr = FindParentTR(sender);

            if (objTr == null) {
                return -1;
            } else {
                return $(objTr)[0].rowIndex;
            }

        } catch (e) {
            return -1;
        }
}