<%@ page title="" language="VB" masterpagefile="~/Site.Mobile.master" autoeventwireup="false" inherits="CheckCunFaMobile, App_Web_3cpo1glw" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="C1" ContentPlaceHolderID="FC" runat="Server">
    <script src="Scripts/CheckJScript.js" type="text/javascript"></script>
    <script src="Scripts/UpdateJScript.js" type="text/javascript"></script>
    <script language="javascript">
        var Gl_FocusTextbox;
        Gl_FocusTextbox = null;
        function Show100(v) {
            $(".JQ_IMG").css("width", v);
        }
        function SelectKind(Classify_id) {
            $("#ctl00_FC_hidClassify_id").val(Classify_id);
            $("#ctl00_FC_btnKensaku").click();
        }
    </script>
    <div style="margin-left: 10px;">
        <table>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Label ID="lblMessage" runat="server" Text="" Style="color: Red"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <%--Title--%>
    <table cellspacing="0" rules="all" border="0" class="table_title_new">
        <tr>
            <th class="title_th">
                <a>LIXIL</a><br />
                <a class="ver">
                    <%Response.Write(System.Configuration.ConfigurationManager.AppSettings("ver").ToString)%></a>
            </th>
            <td style="width: 40px;">
                &nbsp;
            </td>
            <td style="width: 140px;">
                <asp:TextBox ID="tbxGoodsCd" runat="server" CssClass="textbox_lable_white" ReadOnly="true"></asp:TextBox>
                <br />
                <asp:TextBox ID="tbxMakeNumber" runat="server" CssClass="textbox_lable_white" ReadOnly="true"></asp:TextBox>
            </td>
            <td style="width: 140px;">
                <asp:TextBox ID="tbxCheckUserCd" runat="server" CssClass="textbox_lable_white" ReadOnly="true"></asp:TextBox>
            </td>
            <th style="">
                <asp:Button ID="btnKensaku" runat="server" Text="" Style="visibility: hidden;" />
                <asp:Button ID="Button1" runat="server" Text="外观>治具" CssClass="btn_common_new" />
                <asp:Button ID="btnJiaSame" runat="server" Text="待判" CssClass="btn_common_new" OnClientClick="UpdateRow(false);return ConfirmMsg(this);" />
                <asp:Button ID="btnSave" runat="server" Text="完了" CssClass="btn_common_new" OnClientClick="UpdateRow(false);return ConfirmKanryouMsg(this);" />
                <asp:Button ID="btnSave0" runat="server" Text="假保存" CssClass="btn_common_new" OnClientClick="UpdateRow(false);return ConfirmMsg(this);" />
                <asp:Button ID="btnBack" runat="server" Text="退出" CssClass="btn_common_new" OnClientClick="UpdateRow(false);return ConfirmMsg(this);" />
            </th>
        </tr>
    </table>
    <div class="div_ms_new" style="overflow: hidden; text-align: center;">
        <table cellspacing="0" border="0" style="width: 100%;">
            <tr style="border-bottom-width: thick; border-bottom-width: 2px;">
                <td style="color: #333;">
                    <div class="tbl_komoku_title_new" style="line-height: 34px;">
                        <asp:Label ID="lblKind" runat="server" Text="" Style="font-size: 34px;"></asp:Label>
                    </div>
                </td>
                <td style="border-width: 0px;">
                    <div style="text-align: right; border-width: 0px;">
                        <asp:Label ID="lbl_RESULT_MSG" runat="server" Text="" CssClass="JQ_RESULT_MSG" Style="font-size: 26px;
                            color: Red;"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <th colspan="2">
                    <hr />
                    <div style="text-align: center; background-color: #fff; width: 1283px; overflow: auto;">
                        <%
                            Response.Write(GetKindLinks())
                        %>
                    </div>
                </th>
            </tr>
        </table>
    </div>
    <%--MS TITLE--%>
    <div class="div_ms_new" style="overflow: hidden; margin-bottom: 0px;">
        <table cellspacing="0" border="1" class="J_ms_title tbl_ms_title_new">
            <tr>
                <td style="width: 10%;">
                    <input id="tbxScanSave" type="text" class="text_scan_save_new" autocomplete="off" />
                    位置
                </td>
                <td style="width: 20%;">
                    检查项目
                </td>
                <td style="width: 5%;">
                    方法
                </td>
                <td style="width: 15%;">
                    实测1
                </td>
                <td style="width: 15%;">
                    实测2
                </td>
                <td style="width: 5%;">
                    结果
                </td>
                <td style="width: 10%;">
                    备注
                </td>
                <td>
                    基准
                </td>
            </tr>
        </table>
    </div>
    <%--MS--%>
    <div class="J_ms_title_div" style="">
        <asp:GridView ID="gvLastCheckResultMS" CssClass="JQ_CheckMS J_ms_title_gv" runat="server" AutoGenerateColumns="False"
            ShowHeader="false" >
            <Columns>
                <asp:TemplateField HeaderText="位置">
                    <ItemTemplate>
                        <%--<a style="color:Blue;"><%# Eval("check_times").ToString%></a>:--%>
                        <a style="color: Blue;">
                            <%# Eval("kind").ToString%></a>| <a style="color: red;">
                                <%# Eval("check_position").ToString%></a>
                    </ItemTemplate>
                    <ItemStyle Width="10%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="检查项目">
                    <ItemTemplate>
                        <%# Eval("check_item").ToString%>
                    </ItemTemplate>
                    <ItemStyle Width="20%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="方法">
                    <ItemTemplate>
                        <%# Eval("check_way").ToString%>
                    </ItemTemplate>
                    <ItemStyle Width="5%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="实测1">
                    <ItemTemplate>
                        <input type="text" readonly="readonly" class='<%#Com.GetTextBoxClass(Eval("check_way").ToString) %> JQ_SHICE1'
                            value='<%#Eval("measure_value1").ToString%>' style="display: <%# Com.GetTextBoxEnable(Eval("benchmark_type").ToString,1) %>;" />
                    </ItemTemplate>
                    <ItemStyle Width="15%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="实测2">
                    <ItemTemplate>
                        <input type="text" class='<%#Com.GetTextBoxClass(Eval("check_way").ToString) %> JQ_SHICE2'
                            value='<%#Eval("measure_value2").ToString%>' style="display: <%# Com.GetTextBoxEnable(Eval("benchmark_type").ToString,2) %>;" />
                    </ItemTemplate>
                    <ItemStyle Width="15%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="结果">
                    <ItemTemplate>
                        <%# Com.GetTextJieguo(Eval("result").ToString)%></ItemTemplate>
                    <ItemStyle Width="5%" HorizontalAlign="Center" CssClass="JQ_JIEGUO" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="备注">
                    <ItemTemplate>
                        <textarea rows="2" id="TextArea1" class='JQ_BEIZHU textbox_common' maxlength="100"><%#Eval("remarks").ToString %></textarea>
                    </ItemTemplate>
                    <ItemStyle Width="10%" Font-Size="12" CssClass="JQ_BEIZHU" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <%# Com.GetRemark(Eval("remarks").ToString, Eval("result").ToString, Eval("benchmark_type").ToString, Eval("benchmark_type_old").ToString, Eval("benchmark_value1").ToString, Eval("benchmark_value2").ToString, Eval("benchmark_value3").ToString, Eval("benchmark_value1_old").ToString, Eval("benchmark_value2_old").ToString, Eval("benchmark_value3_old").ToString, Eval("measure_value1").ToString, Eval("measure_value2").ToString)%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <%--图片百分比--%>
    <div class="div_ms_new" style="overflow: hidden; margin-bottom: 0px;">
        <table style="width: 1286px;">
            <tr>
                <td>
                    <input type="button" value="50%" onclick="Show100('50%')" class="pic_per" />
                    <input type="button" value="70%" onclick="Show100('70%')" class="pic_per" />
                    <input type="button" value="100%" onclick="Show100('100%')" class="pic_per" />
                    <input type="button" value="120%" onclick="Show100('120%')" class="pic_per" />
                    <input type="button" value="150%" onclick="Show100('150%')" class="pic_per" />
                    <input type="button" value="200%" onclick="Show100('200%')" class="pic_per" />
                    %
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
    <%--图片 小键盘--%>
    <div class="div_ms_new" style="overflow: hidden; margin-bottom: 0px;">
        <table>
            <tr>
                <td style="width: 72%; text-align: left; vertical-align: top;">
                    <div style="width: 100%; height: 700px; overflow: auto;">
                        <asp:Image ID="imgLook" runat="server" CssClass="JQ_IMG" />
                    </div>
                </td>
                <td style="text-align: left; vertical-align: top;">
                    <table cellspacing="0" border="1" style="" class="keybd">
<tr style="height: 100px;">
<td onclick="KeyBoard(this);">7</td>
<td onclick="KeyBoard(this);">8</td>
<td onclick="KeyBoard(this);">9</td>
</tr>
<tr style="height: 100px;">
<td onclick="KeyBoard(this);">4</td>
<td onclick="KeyBoard(this);">5</td>
<td onclick="KeyBoard(this);">6</td>
</tr>
<tr style="height: 100px;">
<td onclick="KeyBoard(this);">1</td>
<td onclick="KeyBoard(this);">2</td>
<td onclick="KeyBoard(this);">3</td>
</tr>
<tr style="height: 100px;">
<td onclick="KeyBoard(this);">0</td>
<td onclick="KeyBoard(this);">.</td>
<td onclick="KeyBoard(this);">删</td>
</tr>
<tr style="height: 100px;">
<td onclick="KeyBoard(this);" colspan="3">回车</td>
</tr>
<tr style="height: 100px;">
<td runat="server" id="tdJinggao" onclick="KeyBoard(this);  " style="background-color: green;">警</td>
<td onclick="KeyBoard(this);" style="background-color: green;">微</td>
<td onclick="KeyBoard(this);" style="background-color: Red;">轻</td>
</tr>
<tr style="height: 100px;">
<td onclick="KeyBoard(this);" style="background-color: Red;">中</td>
<td onclick="KeyBoard(this);" style="background-color: Red;">重</td>
<td onclick="KeyBoard(this);" style="background-color: green;">合</td>
</tr>
</table>
                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="hidResult_id" runat="server" />
    <asp:HiddenField ID="hidGoods_cd" runat="server" />
    <asp:HiddenField ID="hidKind_cd" runat="server" />
    <asp:HiddenField ID="hidClassify_id" runat="server" />
    <asp:HiddenField ID="hidTools_id" runat="server" />
    <asp:HiddenField ID="hidPicture_id" runat="server" />
    <script language="javascript">
        $(document).ready(function () {
            Show100('100%');
            try {
                RowSelect($(".JQ_CheckMS")[0].rows[0]);
            } catch (e) {
            }
            try {
                var shiceObj;
                shiceObj = $($(".JQ_CheckMS")[0].rows[0]).find(".JQ_SHICE1");
                if (shiceObj.css("display") != "none") {
                    SetFocusAndSelectText(shiceObj);
                }
            } catch (e) {
            }



        });
    </script>
</asp:Content>
