var GL_JQ_SCAN_TEXTBOX;

var defaultPage_textbox_scan_do = false;

function SetDefaultScanData(id,isEnter) {
    if (defaultPage_textbox_scan_do) {
        var BarCd = new ReadBarCode($(id).val());
        if (BarCd.kind == "2") {
            $("#ctl00_MC_tbxGoodsCd").val(BarCd.zhiPinCd);
            $("#ctl00_MC_tbxMakeNumber").val(BarCd.zuofan);
            $("#ctl00_MC_tbxCheckUserCd").select();
        } else if (BarCd.kind == "1") {
            if (isEnter) {
                if (id == "#ctl00_MC_tbxGoodsCd") {
                    $("#ctl00_MC_tbxMakeNumber").select();
                } else if (id == "#ctl00_MC_tbxMakeNumber") {
                    $("#ctl00_MC_tbxCheckUserCd").select();
                }
            }
  
        }
    }

    $("#ctl00_MC_tbxGoodsCd").val($("#ctl00_MC_tbxGoodsCd").val().replace(/-/g, ""));
    $("#ctl00_MC_tbxMakeNumber").val($("#ctl00_MC_tbxMakeNumber").val().replace(/-/g, ""));

}

$(document).ready(function () {

    if (IsPC()) {

        //Default Page
        if (defaultPage) {

            //文本框 选择时 选择行
            $(".defaultPage_textbox_scan").focus(function (e) {
                this.select();
            });

            //扫描文本框 鼠标抬起
            $(".defaultPage_textbox_scan").mouseup(function (e) {
                this.select();
            });

//            $(".defaultPage_textbox_scan").keydown(function (e) {

//                defaultPage_textbox_scan_do = true;

//                var id;
//                id = "#" + $(this).attr("id");

//                var curKey = e.which;
//                if (curKey == 13 && $(".defaultPage_textbox_scan").length > 0) {
//                    SetDefaultScanData(id, true);
//                    defaultPage_textbox_scan_do = false;
//                    e.preventDefault ? e.preventDefault() : e.returnValue = false;
//                }

////                setTimeout(function () {
////                    SetDefaultScanData(id, false);
////                    defaultPage_textbox_scan_do = false;
////                }, 700);

//            });

            $(".defaultPage_textbox_scan").keyup(function (e) {

//                var id;
//                id = "#" + $(this).attr("id");

//                setTimeout(function () {
//                    SetDefaultScanData(id, false);
//                    defaultPage_textbox_scan_do = false;
//                }, 500);

            });

            $(".defaultPage_textbox_scan").keydown(function (e) {

                defaultPage_textbox_scan_do = true;
                var id;
                id = "#" + $(this).attr("id");

                var curKey = e.which;
                if (curKey == 13 && $(".defaultPage_textbox_scan").length > 0) {
                    SetDefaultScanData(id, true);
                    defaultPage_textbox_scan_do = false;
                    e.preventDefault ? e.preventDefault() : e.returnValue = false;
                }

//                setTimeout(function () {
//                    SetDefaultScanData(id, false);
//                    defaultPage_textbox_scan_do = false;
//                }, 700);

            });



        } else {

            /*****/
            //////////////////扫描textbox///////////////////////
            //配合扫描器 Textbox
            //  设置背景色
            //  选择行
            //  设置全局active Textbox
            //////////////////////////////////////////////////

            var OLD_TEXTOBX_SCAN_VALUE = "";

            //$('.textbox_scan').attr("readonly", false);
            //Cell 选择
            $(".textbox_scan").on("focus mouseup", function () {
                OLD_TEXTOBX_SCAN_VALUE = $(this).val();
                $(this).css("background-color", conLightGreen);
                RowSelect(FindParentTR(this));
                Gl_FocusTextbox = this;
            });
            //失去焦点
            $(".textbox_scan").blur(function (e) {
                $(this).css("background-color", conLightYellow);
            });
            /*
            //获得焦点
            $(".textbox_scan").focus(function (e) {
            $(this).css("background-color", conLightGreen);
            RowSelect(FindParentTR(this));
            Gl_FocusTextbox = this;
            
            });





            //扫描文本框 鼠标抬起
            $(".textbox_scan").mouseup(function (e) {
            this.select();
            });
            */

            var keyUpFlg = false;
            $(".textbox_scan").keyup(function (e) {

            });
            //扫描文本框 焦点到下一个元素 因为除了IE浏览器都不支持 Key.Code = 13*/
            $(".textbox_scan").keydown(function (e) {

                if (!keyUpFlg) {
                    $(this).attr("readonly", false);
                    $(this)[0].select();
                    keyUpFlg = true;
                }


                if (e.which == 13) {

                    $(this).attr("readonly", true);
                    keyUpFlg = false;

                    var olen = OLD_TEXTOBX_SCAN_VALUE.length;

                    var value = $(this).val();

                    //value = value.right(value.length - olen);

                    $(this).val(value);

                    var BarCd = new ReadBarCode($(this).val());

                    //二维码扫描 生产明细书
                    tr = FindParentTR(Gl_FocusTextbox);

                    var zbenchmark_type;
                    var zbenchmark_value1;

                    //获得 TR 对象
                    if (tr != null) {
                        zbenchmark_type = tr.attr("zbenchmark_type");
                        zbenchmark_value1 = tr.attr("zbenchmark_value1").replace(/-/g, "");
                    }

                    if (BarCd.kind == "2") {
                        //二维码扫描 生产明细书
                        if (zbenchmark_type == "00" || zbenchmark_type == "01") {
                            if (BarCd.zuofan == zbenchmark_value1 || BarCd.zhiPinCd == zbenchmark_value1 || BarCd.kunBaoSuu == zbenchmark_value1 || BarCd.tuoPanXuHao == zbenchmark_value1 || BarCd.xiangXian == zbenchmark_value1) {
                                $(this).val(zbenchmark_value1);
                            } else {
                                $(this).val("二维码不符");
                            }
                        }

                    } else if (BarCd.kind == "3") {
                        if (zbenchmark_type == "12") {
                            $(this).val(BarCd.lotRiQi);
                        } else {
                            $(this).val(BarCd.cd);
                        }
                    } else {

                        $(this).val(BarCd.cd);

                    }

                    //检查输入值
                    CheckRowInput($(this)[0]);
                    //更新行数据
                    UpdateRow();
                    //设置下一个焦点
                    SetNextFocus(e, $(this)[0], true);

                    e.preventDefault ? e.preventDefault() : e.returnValue = false;

                }

            });
        }




    } else {


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
    }






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

    var keyUpFlg = false;
    $(".textbox_input").blur(function () {
        keyUpFlg = false;
    });

    //输入文本框 
    $(".textbox_input").keydown(function (e) {

        if (!keyUpFlg) {
            $(this).attr("readonly", false);
            $(this)[0].select();
            keyUpFlg = true;
        }

        if (e.which == 13) {

            $(this).attr("readonly", true);
            CheckRowInput(this);
            UpdateRow();
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
};

function ReMakeScanText(value) {
    var len;
    len = value.length;
    if (len > 8) {
        value = value.substring(4, len - 4);
        value = value.replace(/ /g, "");
        value = value.replace(/-/g, "");
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
String.prototype.trim = function() {
    return this.replace(/(^\s*)|(\s*$)/g, '');
}
String.prototype.ltrim = function() {
    return this.replace(/(^\s*)/g, '');
}
String.prototype.rtrim = function() {
    return this.replace(/(\s*$)/g, '');
}
String.prototype.right = function(length) {
    if (this.length - length >= 0 && this.length >= 0 && this.length - length <= this.length) {
        return this.substring(this.length - length, this.length);
    } else {
        return this
    }
}
String.prototype.left = function(length) {
    if (this.length - length >= 0 && this.length >= 0 && this.length - length <= this.length) {
        return this.substring(0, length);
    } else {
        return this
    }
}
function IsContains(str, substr) {
    return str.indexOf(substr) >= 0;
}
function ReadBarCode(cd) {

    if (cd.split("/").length == 8) {
        this.kind = "2";
        this.zuofan = cd.split("/")[7].trim().replace(/-/g, "");
        this.zhiPinCd = cd.split("/")[1].trim().replace(/-/g, "");
        this.kunBaoSuu = cd.split("/")[3].trim().replace(/-/g, "");
        this.tuoPanXuHao = cd.split("/")[6].trim().replace(/-/g, "");
        this.xiangXian = cd.split("/")[5].trim().replace(/-/g, "");

    } else if (cd.split("/").length >= 5) {
        this.kind = "2";
        this.zuofan = cd.split("/")[0].trim().replace(/-/g, "");
        this.zhiPinCd = cd.split("/")[1].trim().replace(/-/g, "");
        this.kunBaoSuu = cd.split("/")[2].trim().replace(/-/g, "");
        this.tuoPanXuHao = cd.split("/")[3].trim().replace(/-/g, "");
        this.xiangXian = cd.split("/")[4].trim().replace(/-/g, "");
    } else if (cd.right(2) == "/C") {
        this.kind = "3";
        this.cd = cd.left(16).trim().replace(/-/g, "");
        this.lotRiQi = cd.substring(16, 25).trim();
    } else {
        this.kind = "1";
        this.cd = cd;
        this.cd = this.cd.replace(/ /g, "");
        this.cd = this.cd.replace(/-/g, "");
    }
    return this;
}
function IsPC() {
    var userAgentInfo = navigator.userAgent;
    var Agents = ["Android", "iPhone", "SymbianOS", "Windows Phone", "iPad", "iPod"];
    var flag = true;
    for (var v = 0; v < Agents.length; v++) {
        if (userAgentInfo.indexOf(Agents[v]) > 0) {
            flag = false;
            break;
        }
    }
    return flag;
}