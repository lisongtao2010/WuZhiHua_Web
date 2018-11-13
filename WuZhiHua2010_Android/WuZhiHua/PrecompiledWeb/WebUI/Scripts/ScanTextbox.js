//选择的扫描Textbox
var GL_JQ_SCAN_TEXTBOX;

$(document).ready(function () {

    //////////////////配合扫描器///////////////////////
    //配合扫描器 Textbox
    //  配合扫描器 设置成扫描到的内容 前后去掉4个字符
    //  上边的内容放到激活的扫描Textbox
    //  更新行数据
    //  设置下一个焦点
    //////////////////////////////////////////////////
    $("#tbxScanSave").keydown(function (e) {

        var curKey = e.which;

        if (curKey == 13) {
            var v;
            v = ReMakeScanText($(this).val());

            //如果有扫描内容
            if (v.length > 0) {

                //扫描器 设置  
                $(this).val(v);

                //扫描Textbox 设置
                GL_JQ_SCAN_TEXTBOX.val(v);

                //检查输入值
                CheckRowInput(Gl_FocusTextbox);

                //更新行数据
                UpdateRow();

                //设置下一个焦点
                SetNextFocus(e, GL_JQ_SCAN_TEXTBOX[0], true);

            }

            e.preventDefault ? e.preventDefault() : e.returnValue = false;

            return false;

        }

    });

    //////////////////扫描textbox///////////////////////
    //配合扫描器 Textbox
    //  设置背景色
    //  选择行
    //  设置全局active Textbox
    //////////////////////////////////////////////////
    //获得焦点
    $(".textbox_scan").focus(function (e) {
        $(this).css("background-color", conLightGreen);
        RowSelect(FindParentTR(this));
        Gl_FocusTextbox = this;
    });
    //失去焦点
    $(".textbox_scan").blur(function (e) {
        $(this).css("background-color", conLightYellow);
    });
    //扫描文本框 鼠标抬起
    $(".textbox_scan").mouseup(function (e) {
        this.select();
    });

    //扫描文本框 焦点到下一个元素 因为除了IE浏览器都不支持 Key.Code = 13*/
    $(".textbox_scan").keydown(function (e) {

        if (e.which == 13) {
            $(this).val($(this).val().replace(/-/g, ""));
            //获得行的基准值 ，并且根据基准值进行检查
            CheckRowInput(this);
            //设置焦点到下一个单元格
            SetNextFocus(e, this, true);

            e.preventDefault ? e.preventDefault() : e.returnValue = false;
        } else if (e.which == 0) {
            GL_JQ_SCAN_TEXTBOX = $(this);
            $(this).val("");
            $("#tbxScanSave").val("");
            $("#tbxScanSave").select();
            return false;
        }
    });



    $(".textbox_input").focus(function (e) {
        $(this).css("background-color", conLightGreen);
        RowSelect(FindParentTR(this));
        Gl_FocusTextbox = this;
    });

    $(".textbox_input").blur(function (e) {
        $(this).css("background-color", "#99FFFF");
    });
    //输入文本框 鼠标抬起
    $(".textbox_input").mouseup(function (e) {
        this.select();
    });

    //输入文本框 
    $(".textbox_input").keydown(function (e) {
        if (e.which == 13) {
            //设置焦点到下一个单元格
            SetNextFocus(e, this, true);
            e.preventDefault ? e.preventDefault() : e.returnValue = false;
        }
    });





    $(".JQ_BEIZHU").focus(function (e) {

        RowSelect(FindParentTR(this));
        Gl_FocusTextbox = this;
        return true;
    });

    $(".JQ_BEIZHU").keydown(function (e) {

        if (e.which == 13) {
            //获得行的基准值 ，并且根据基准值进行检查
            CheckRowInput(this);
            //设置焦点到下一个单元格
            SetNextFocus(e, this, false);

            e.preventDefault ? e.preventDefault() : e.returnValue = false;
        }
    });


});

/*寻找父元素TR*/
function FindParentTR(e) {
    if ($(e).length > 0) {
        if ($(e)[0].tagName == "TR") {
            return $(e);
        } else {
            return FindParentTR($(e).parent());
        }
    } else {
        return null;
    }
}




/*扫描条码内容再整理*/
function ReMakeScanText(value) {
    //扫描器的内容  前后追加4个字符串
    var len;
    len = value.length;
    if (len > 8) {
        value = value.substring(4, len - 4);
        value = value.replace(/ /g, "");
        value = value.replace(/-/g, "");
        //如果扫描条码开头 是"Y7"那么表示扫描的是日期标签
        if (value.substring(0, 2) != 'Y7') {
            value = value.replace(/-/g, "");
        }

        return value;

    } else {

        return value;
    }
}

function isInteger(obj) {
    return obj % 1 === 0 && obj.indexOf(".") == -1 && obj != '';
}