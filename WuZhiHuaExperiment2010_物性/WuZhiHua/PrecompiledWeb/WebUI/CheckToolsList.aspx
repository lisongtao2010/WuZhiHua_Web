<%@ page title="" language="VB" masterpagefile="~/Site.Mobile.master" autoeventwireup="false" inherits="CheckCunFaMobile, App_Web_wq0q1dtw" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server"></asp:Content>
<asp:Content ID="C1" ContentPlaceHolderID="FC" Runat="Server">
    <script src="Scripts/CheckJScript.js"></script>
    <script src="Scripts/UpdateJScript.js"></script>
    <script language="javascript">
        var Gl_FocusTextbox;
        var Gl_FocusTextboxTools;
        Gl_FocusTextboxTools = null;
        Gl_FocusTextbox = null;
        var keyBoardFlg;
        keyBoardFlg = false;

        var conLightGreen;
        var conLightBlue;
        var conLightRed;
        var conSelectRowClolor;
        conLightGreen = "#93FF93";
        conLightBlue = "#84C1FF";
        conLightRed = "#FF2D2D";
        conSelectRowClolor = "#FFE4B5";

        $(document).ready(function () {

            var scan_cd;


            function ScanToolsList(e) {

                var scan_cd;
                var isAllScanned;
                var isHaveScanned;
                scan_cd = $(e).val();
                isAllScanned = true;
                isHaveScanned = false;

                scan_cd = $(e).val();



                $.each($(".textbox_scan_tools"), function (index, item) {
                    // 如果扫描CD 和 列表治具相同
                    if (scan_cd == $(this).val()) {
                        $(this).css("background-color", conLightGreen);
                        $(this).attr("isScanned", "1");
                        isHaveScanned = true;

                    }

                });

                if (isHaveScanned) {
                    $(".JQ_msg").text("扫描成功")

                } else {
                    $(".JQ_msg").text("未扫描到相同治具")

                }

                $.each($(".textbox_scan_tools"), function (index, item) {
                    // 如果扫描CD 和 列表治具相同
                    if ($(this).attr("isScanned") == "0") {
                        isAllScanned = false;

                    }

                });

                if (isAllScanned) {

                    $(".JQ_Tools").removeAttr("disabled");
                    $(".JQ_Tools").click()


                };


            }


            //扫描治具
            $("#tbxScanSaveTools").keydown(function (e) {
                var curKey = e.which;
                if (curKey == 13) {
                    var v;
                    v = $(this).val();
                    if (v.length > 8) {
                        v = v.substring(4, v.length - 4);
                        v = v.replace(/ /g, "");
                        v = v.replace(/-/g, "");
                        if (v.substring(0, 2) != 'Y7') {
                            v = v.replace(/-/g, "");

                        }
                        $(this).val(v);
                        ScanToolsList(this);
                        $(this).val("");


                    }
                    e.preventDefault ? e.preventDefault() : e.returnValue = false;
                    return false;

                }

            });

            $("#tbxScanSaveTools").focus();


        });


    </script>

     <div style="margin-left:10px;">
            <table>
                <tr>
                    <td></td>
                    <td><asp:Label ID="lblMessage" runat="server" Text="" style="color:Red"></asp:Label></td>
                </tr>
            </table>        
    </div>
    <%--background-image: url('Img/body1.png'); --%>
<%--Title--%>
<table cellspacing="0" rules="all" border="0" class="table_title_new">
<tr>
    <th style="width:160px; font-size:25px; color:#fff;">
        <a style="font-size:34px;">L</a>
        <a style="font-size:32px;">I</a>
        <a style="font-size:30px;">X</a>
        <a style="font-size:32px;">I</a>
        <a style="font-size:34px;">L</a>
        <a style="font-size:11px;">ver1.0</a>
    </th>
<td style="width:40px;">&nbsp;</td>
<td style="width:140px;">
<asp:TextBox ID="tbxGoodsCd" runat="server" CssClass="textbox_lable_white" Text ="L0820MJYA" ReadOnly="true"></asp:TextBox>
<br />
<asp:TextBox ID="tbxMakeNumber" runat="server" CssClass="textbox_lable_white" Text="074090017" ReadOnly="true"></asp:TextBox></td>
<td style="width:140px;">
<asp:TextBox ID="tbxCheckUserCd" runat="server" CssClass="textbox_lable_white" ReadOnly="true"></asp:TextBox>
</td>
              
<th style="">

    <asp:Button ID="Button1" runat="server" Text="治具检查" CssClass="btn_common_new JQ_Tools" Enabled="false"/>
    <asp:Button ID="Button2" runat="server" Text="治具>外观" CssClass="btn_common_new"/>
    <asp:Button ID="btnBack" runat="server" Text="退出" CssClass="btn_common_new"      OnClientClick="UpdateRow();" />
</th>
</tr>
</table> 
<br />
&nbsp;扫描：
<input id="tbxScanSaveTools" type="text" class="textbox" autocomplete="off"  style="width:200px;height:30px;" />
<asp:Label ID="Label1" CssClass="JQ_msg" runat="server" Text="" style="color:Red"></asp:Label>
<br /><br />
<%--项目选择--%>
<div class="div_ms_new" style="overflow:hidden; text-align:center;">  
<table cellspacing="0" rules="all" border="0" style="width:1283px;">
<tr>
    <th style="width:1020px;color:#333;">
        <div class="" style="width:100%" >
            <asp:Label ID="lblKind" runat="server" Text="" style="font-size:34px;"></asp:Label>
        </div>
        <div class="JQ_KindsDiv JQ_KINDS" style="width:100%; background-color:#fff;  color:#000;">
        <asp:GridView ID="gvZhiju" runat="server" AutoGenerateColumns = "false" Width="100%"  CssClass="tools_table">
            <Columns>
                <asp:TemplateField HeaderText ="标准条形码">
                    <ItemTemplate><%# Eval("tools_no").ToString%></ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText ="实际录入条形码">
                        <ItemTemplate>
                    <input type="text" readonly="readonly" class='textbox textbox_scan_tools' isScanned='0' value='<%#Eval("barcode").ToString%>' barcode='<%#Eval("barcode").ToString%>' classify_id='<%#Eval("classify_id").ToString%>'
                        style="width:100%;"
                    /> 
                    </ItemTemplate>
                    <ItemStyle ForeColor="Black" Width="300" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText ="编号">
                    <ItemTemplate>
                    <input type="text" class="textbox_lable" value='<%#Eval("remarks").ToString%>' style="width:100%; text-align:center;" readonly="true" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText ="名称">
                    <ItemTemplate>
                        <input type="text" class="JQ_TOOLS_LABLE button" value='<%#Eval("classify_name").ToString%>' style='width:100%; text-align:center; border-style:none; <%#GetDisplay(Eval("classify_id").ToString,false)%>' readonly="true" />
                        <input type="button" class="JQ_TOOLS_LINK button" value='<%#Eval("classify_name").ToString%>' style="width:100%; height:100%; text-align:center; <%#GetDisplay(Eval("classify_id").ToString,true)%>" 
                        onclick='' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="tbl_ms_title_new" />
        </asp:GridView>
        </div>    
    </th>
</tr>
</table> 
</div>


    <asp:HiddenField ID="hidResult_id" runat="server" />
    <asp:HiddenField ID="hidGoods_cd" runat="server" />
    <asp:HiddenField ID="hidKind_cd" runat="server" />
    <asp:HiddenField ID="hidClassify_id" runat="server" />
    <asp:HiddenField ID="hidTools_id" runat="server" />
    <asp:HiddenField ID="hidPicture_id" runat="server" />


</asp:Content>

