<%@ page title="" language="VB" masterpagefile="~/Site.Mobile.master" autoeventwireup="false" inherits="_Default, App_Web_sso22jpa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FC" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MC" runat="Server">
    <%--扫描--%>
    <script language="javascript" type="text/javascript">

        var Gl_FocusTextbox;
        Gl_FocusTextbox = null;
        defaultPage = true;

    </script>
    <%--欠品更新--%>
    <script language="javascript" type="text/javascript">
        function fnUpdQianpin(e, id) {
            var qianpin_flg;
            if (e.checked) {
                qianpin_flg = '1';
            } else {
                qianpin_flg = '0';
            }

            $.ajax({
                type: "POST",
                url: "AJAX.aspx?k=31&param=" + id + '|' + qianpin_flg + '|' + $("#ctl00_MC_tbxCheckUserCd").val(),
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
    </script>
    <%--Title--%>
    <table cellspacing="0" rules="all" border="0" class="table_title_new">
        <tr>
            <th class="title_th">
                <a>LIXIL</a><br />
                <a class="ver">
                    <%Response.Write(System.Configuration.ConfigurationManager.AppSettings("ver").ToString)%></a>
            </th>
            <td style="width: 210px;">
                ＣＤ
                <asp:TextBox ID="tbxGoodsCd" runat="server" CssClass="defaultPage_textbox_scan" Text=""
                    Width="330" AutoCompleteType="Disabled" ></asp:TextBox>
            </td>
            <td style="width: 210px;">
                座番
                <asp:TextBox ID="tbxMakeNumber" runat="server" CssClass="defaultPage_textbox_scan"
                    Text="" Width="230" AutoCompleteType="Disabled"></asp:TextBox>
            </td>
            <td style="width: 140px;">
                检查员CD
                <asp:TextBox ID="tbxCheckUserCd" runat="server" CssClass="defaultPage_textbox"
                    Text="" Width="140" AutoCompleteType="None"></asp:TextBox>
            </td>
            <th style="">
                <asp:Button ID="btnKensaku" runat="server" Text="查询" CssClass="btn_common_new" />
                <asp:Button ID="btnByHand1" runat="server" Text="手入力" CssClass="btn_common_new" />
                <asp:Button ID="btnByHand2" runat="server" Text="清空" CssClass="btn_common_new" />
            </th>
        </tr>
    </table>
    <%--MESSAGE--%>
    <div class="div_msg_new">
        <input id="tbxScanSave" type="text" class="text_scan_save_new" autocomplete="off" />
        <asp:Label ID="lblMessage" runat="server" Text="" Style="color: Red"></asp:Label>
        <asp:Label ID="lblHint" runat="server" Text="" Style="color: blue"></asp:Label>
    </div>
    <%--BUTTON--%>
    <div class="div_ms_new" style="overflow: hidden; text-align: center;">
        <asp:Button ID="btnReCheck" runat="server" Text="新规检查" CssClass="btn_common_new"
            Visible="false" Width="33%" />
        <asp:Button ID="btnDefault" runat="server" Text="默认结果" CssClass="btn_common_new"
            Visible="false" Width="33%" />
        <asp:Button ID="btnContinueCheck" runat="server" Text="继续检查" CssClass="btn_common_new"
            Visible="false" Width="33%" />
    </div>
    <div class="div_ms_new">
        <asp:GridView ID="gvLastCheckResultMS" runat="server" AutoGenerateColumns="False"
            Width="1450px">
            <Columns>
                <asp:TemplateField HeaderText="ID<br>作番">
                    <ItemTemplate>
                        <%#Eval("ID").ToString%>
                        <input type="text" class="textbox_lable" value='<%#Eval("作番").ToString%>' style='width: 200px;
                            color: <%# GetSameMakeNoFontColor(Eval("作番").ToString) %>' readonly="readonly" />
                    </ItemTemplate>
                    <ItemStyle Width="200" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="生产线-数量<br>生产实际日">
                    <ItemTemplate>
                        <input type="text" class="textbox_lable" value='<%#Eval("生产线").ToString & "-" & Eval("数量").ToString%>'
                            style="width: 240px;" readonly="readonly" />
                        <%#SetDateF(Eval("生产实际日").ToString）%>
                    </ItemTemplate>
                    <ItemStyle Width="240" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="结果<br>状态">
                    <ItemTemplate>
                        <input type="text" class="textbox_lable" value='<%#Eval("结果").ToString%>' style="width: 80px;"
                            readonly="readonly" />
                        <input type="text" class="textbox_lable" value='<%#Eval("状态").ToString%>' style="width: 80px;"
                            readonly="readonly" />
                    </ItemTemplate>
                    <ItemStyle Width="80" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="检查员">
                    <ItemTemplate>
                        <%#Eval("检查员").ToString%>
                        <%#Eval("检查员CD").ToString%>
                    </ItemTemplate>
                    <ItemStyle Width="100" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="开始<br>结束时间">
                    <ItemTemplate>
                        <%#SetDateF(Eval("开始时间").ToString）%><br />
                        <%#SetDateF(Eval("结束时间").ToString）%>
                    </ItemTemplate>
                    <ItemStyle Width="200" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="继承<br>结果">
                    <ItemTemplate>
                        <input type="text" class="textbox_lable" value='<%#Eval("继承结果").ToString%>' style="width: 200px;
                            font-size: 24px;" readonly="true" />
                    </ItemTemplate>
                    <ItemStyle Width="200" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="欠品">
                    <ItemTemplate>
                        <asp:CheckBox ID="cbQianpin" runat="server" Text="是否欠品" />
                    </ItemTemplate>
                    <ItemStyle Width="150" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="编辑谨慎使用">
                    <ItemTemplate>
                        <input type="button" value="编辑" class="btn_common_new" onclick="return fnedit('<%#Eval("ID").ToString%>')" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="tbl_ms_title_new" />
        </asp:GridView>
    </div>
    <br />
    <div class="div_ms_new" style="overflow: hidden; text-align: center; color: Red;
        font-size: 30px; font-weight: bold;">
        下面是临时保存的数据 （可能是中途退出的）
    </div>
    <div class="div_ms_new">
        <asp:GridView ID="GVFlg3" runat="server" AutoGenerateColumns="False" Width="1450px">
            <Columns>
                <asp:TemplateField HeaderText="ID<br>作番">
                    <ItemTemplate>
                        <%#Eval("ID").ToString%>
                        <input type="text" class="textbox_lable" value='<%#Eval("作番").ToString%>' style='width: 200px;
                            color: <%# GetSameMakeNoFontColor(Eval("作番").ToString) %>' readonly="readonly" />
                    </ItemTemplate>
                    <ItemStyle Width="200" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="生产线-数量<br>生产实际日">
                    <ItemTemplate>
                        <input type="text" class="textbox_lable" value='<%#Eval("生产线").ToString & "-" & Eval("数量").ToString%>'
                            style="width: 240px;" readonly="readonly" />
                        <%#SetDateF(Eval("生产实际日").ToString）%>
                    </ItemTemplate>
                    <ItemStyle Width="240" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="结果<br>状态">
                    <ItemTemplate>
                        <input type="text" class="textbox_lable" value='<%#Eval("结果").ToString%>' style="width: 80px;"
                            readonly="readonly" />
                        <input type="text" class="textbox_lable" value='<%#Eval("状态").ToString%>' style="width: 80px;"
                            readonly="readonly" />
                    </ItemTemplate>
                    <ItemStyle Width="80" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="检查员">
                    <ItemTemplate>
                        <%#Eval("检查员").ToString%>
                        <%#Eval("检查员CD").ToString%>
                    </ItemTemplate>
                    <ItemStyle Width="100" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="开始<br>结束时间">
                    <ItemTemplate>
                        <%#SetDateF(Eval("开始时间").ToString）%><br />
                        <%#SetDateF(Eval("结束时间").ToString）%>
                    </ItemTemplate>
                    <ItemStyle Width="200" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="继承<br>结果">
                    <ItemTemplate>
                        <input type="text" class="textbox_lable" value='<%#Eval("继承结果").ToString%>' style="width: 200px;
                            font-size: 24px;" readonly="readonly" />
                    </ItemTemplate>
                    <ItemStyle Width="200" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="欠品">
                    <ItemTemplate>
                        <asp:CheckBox ID="cbQianpin" runat="server" Text="是否欠品" />
                    </ItemTemplate>
                    <ItemStyle Width="150" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="编辑">
                    <ItemTemplate>
                        <input type="button" value="编辑" class="btn_common_new" onclick="return fnedit('<%#Eval("ID").ToString%>')" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="tbl_ms_title_new" />
        </asp:GridView>
    </div>
    <asp:Button ID="btnEdit" runat="server" Text="编辑" CssClass="Common_button" Style="width: 140px;
        margin-left: 10px; visibility: hidden;" />
    <asp:HiddenField ID="hidResultID" runat="server" />
    <script language="javascript" type="text/javascript">
        function fnedit(id) {
            $("#ctl00_MC_hidResultID").val(id);
            $("#ctl00_MC_btnEdit").click();
            return false;
        }
    </script>
</asp:Content>
