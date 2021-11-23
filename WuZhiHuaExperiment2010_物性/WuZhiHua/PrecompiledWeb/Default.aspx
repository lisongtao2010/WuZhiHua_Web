<%@ Page Title="" Language="VB" MasterPageFile="~/Site.Mobile.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" EnableEventValidation ="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .auto-style1 {
            text-align: right;
            color: #000066;
        }

        .auto-style2 {
            width: 160px;
            height: 62px;
        }

        .auto-style3 {
            width: 50px;
            height: 62px;
        }

        .auto-style4 {
            width: 140px;
            height: 62px;
        }

        .auto-style5 {
            width: 70px;
            height: 62px;
        }

        .auto-style6 {
            width: 90px;
            height: 62px;
        }

        .auto-style7 {
            height: 62px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FC" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MC" runat="Server">
    <%--扫描--%>
    <script language="javascript" type="text/javascript" src="./Default.js"></script>
    <%--欠品更新--%>

    <%--Title--%>
    <table cellspacing="0" rules="all" border="0" class="table_title_new">
        <tr>
            <th style="font-size: 25px; color: #fff;" class="auto-style2">
                <a style="font-size: 34px;">L</a>
                <a style="font-size: 32px;">I</a>
                <a style="font-size: 30px;">X</a>
                <a style="font-size: 32px;">I</a>
                <a style="font-size: 34px;">L</a>
                <a style="font-size: 11px;">ver1.0</a>

            </th>
            <th class="auto-style3">CD
            </th>
            <td class="auto-style4">
                <asp:TextBox ID="tbxGoodsCd" runat="server" CssClass="defaultPage_textbox_scan" Text="" Width="140" AutoCompleteType="None"></asp:TextBox>
            </td>
            <th class="auto-style5">区分</th>
            <td class="auto-style4">
                <asp:TextBox ID="tbxMakeNumber" runat="server" CssClass="defaultPage_textbox_scan" Text="" Width="140" AutoCompleteType="None"></asp:TextBox>
            </td>
            <th class="auto-style6">检查员</th>
            <td class="auto-style4">
                <asp:TextBox ID="tbxCheckUserCd" runat="server" CssClass="defaultPage_textbox_scan" Text="302503" Width="140" AutoCompleteType="None"></asp:TextBox>
            </td>
            <th class="auto-style7">
                <asp:Button ID="btnKensaku" runat="server" Text="查询" CssClass="btn_common_new" />
                <asp:Button ID="btnByHand1" runat="server" Text="手入力" CssClass="btn_common_new" />
                <asp:Button ID="btnByHand2" runat="server" Text="清空" CssClass="btn_common_new" />
            </th>
        </tr>
        <tr>
            <th style="font-size: 25px;" colspan="3"><a id="kl"> 型番 </a><asp:TextBox ID="tbxXingfan" runat="server" CssClass="defaultPage_textbox_scan" Text="" Width="260" AutoCompleteType="None" list="xingfan_list"></asp:TextBox>
            </th>
            <th style="width: 70px;" class="auto-style1">部<br />门</th>
            <td style="width: 140px;">
                <%--<asp:TextBox ID="tbxBumen" runat="server" CssClass="defaultPage_textbox_scan" Text="" Width="140" AutoCompleteType="None" list="xingfan_bumen_list"></asp:TextBox>--%>
                <asp:ListBox ID="lbBumen" runat="server" Width="115px" style="font-size:24px;"></asp:ListBox>
            </td>
            <th style="width: 90px;">生<br />产<br />线</th>
            <td colspan="2" style="text-align:left">
<%--                <asp:TextBox ID="tbxLineName" runat="server" CssClass="defaultPage_textbox_scan" Text="" Width="340" AutoCompleteType="None" list="line_name_list"></asp:TextBox>--%>

                <asp:ListBox ID="cbLineName" runat="server" Width="300" style="font-size:24px;"></asp:ListBox>
            </td>
        </tr>
    </table>
    <datalist id="xingfan_list">
        <%=xingfan_list.ToString%>
    </datalist>

    <datalist id="xingfan_bumen_list">
    </datalist>

    <datalist id="line_name_list">
    </datalist>
    <%--MESSAGE--%>
    <div class="div_msg_new">
        <input id="tbxScanSave" type="text" class="text_scan_save_new" autocomplete="off" />
        <asp:Label ID="lblMessage" runat="server" Text="" Style="color: Red"></asp:Label>
        <asp:Label ID="lblHint" runat="server" Text="" Style="color: blue"></asp:Label>
    </div>

    <%--BUTTON--%>
    <div class="div_ms_new" style="overflow: hidden; text-align: center;">
        <asp:Button ID="btnReCheck" runat="server" Text="新规检查" CssClass="btn_common_new" Visible="false" Width="33%" />
        <asp:Button ID="btnDefault" runat="server" Text="默认结果" CssClass="btn_common_new" Visible="false" Width="33%" />
        <asp:Button ID="btnContinueCheck" runat="server" Text="继续检查" CssClass="btn_common_new" Visible="false" Width="33%" />

    </div>
    <div class="div_ms_new" style="overflow: hidden; text-align: left; color: Red; font-size: 30px; font-weight: bold;">
        <asp:Label ID="lblChecked" runat="server" Text="检查完了的数据" Style="color: Red" Visible="false"></asp:Label>

    </div>
    <div class="div_ms_new">
        <asp:GridView ID="gvLastCheckResultMS" runat="server" AutoGenerateColumns="False" Width="1250px">
            <Columns>
                <asp:TemplateField HeaderText="ID<br>作番">
                    <ItemTemplate>
                        <%#Eval("ID").ToString%>
                        <input type="text" class="textbox_lable" value='<%#Eval("作番").ToString%>' style='width: 200px; color: <%# GetSameMakeNoFontColor(Eval("作番").ToString) %>' readonly="true" />
                    </ItemTemplate>
                    <ItemStyle Width="200" />
                </asp:TemplateField>

                <%--            <asp:TemplateField HeaderText ="生产线-数量<br>生产实际日">
                <ItemTemplate >
                    <input type="text" class="textbox_lable" value='<%#Eval("生产线").ToString & "-" & Eval("数量").ToString%>' style="width:240px;" readonly="true" />
                    <%#SetDateF(Eval("生产实际日").ToString）%>
                </ItemTemplate>
                <ItemStyle Width="240" />
            </asp:TemplateField>--%>

                <asp:TemplateField HeaderText="结果<br>状态">
                    <ItemTemplate>
                        <input type="text" class="textbox_lable" value='<%#Eval("结果").ToString%>' style="width: 80px;" readonly="true" />
                        <input type="text" class="textbox_lable" value='<%#Eval("状态").ToString%>' style="width: 80px;" readonly="true" />
                    </ItemTemplate>
                    <ItemStyle Width="80" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="检查员">
                    <ItemTemplate>
                        <%#Eval("检查员").ToString%>多人
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
                        <input type="text" class="textbox_lable" value='<%#Eval("继承结果").ToString%>' style="width: 200px; font-size: 24px;" readonly="true" />
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
                        <input type="button" value="编辑" class="btn_common_new" onclick="return fnedit('<%#Eval("ID").ToString%>','<%#Eval("作番").ToString%>')" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>

            </Columns>
            <HeaderStyle CssClass="tbl_ms_title_new" />
        </asp:GridView>
    </div>
    <br />
    <div class="div_ms_new" style="overflow: hidden; text-align: left; color: Red; font-size: 30px; font-weight: bold;">
        <asp:Label ID="lblChecking" runat="server" Text="检查中的数据" Style="color: Red" Visible="false"></asp:Label>
    </div>

    <div class="div_ms_new">
        <asp:GridView ID="GVFlg3" runat="server" AutoGenerateColumns="False" Width="1250px">
            <Columns>
                <asp:TemplateField HeaderText="ID<br>作番">
                    <ItemTemplate>
                        <%#Eval("ID").ToString%>
                        <input type="text" class="textbox_lable" value='<%#Eval("作番").ToString%>' style='width: 200px; color: <%# GetSameMakeNoFontColor(Eval("作番").ToString) %>' readonly="readonly" />
                    </ItemTemplate>
                    <ItemStyle Width="200" />
                </asp:TemplateField>

                <%--<asp:TemplateField HeaderText ="生产线-数量<br>生产实际日">
<ItemTemplate >
<input type="text" class="textbox_lable" value='<%#Eval("生产线").ToString & "-" & Eval("数量").ToString%>' style="width:240px;" readonly="readonly" />
<%#SetDateF(Eval("生产实际日").ToString）%>
</ItemTemplate>
<ItemStyle Width="240" />
</asp:TemplateField>--%>

                <asp:TemplateField HeaderText="结果<br>状态">
                    <ItemTemplate>
                        <input type="text" class="textbox_lable" value='<%#Eval("结果").ToString%>' style="width: 80px;" readonly="readonly" />
                        <input type="text" class="textbox_lable" value='<%#Eval("状态").ToString%>' style="width: 80px;" readonly="readonly" />
                    </ItemTemplate>
                    <ItemStyle Width="80" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="检查员">
                    <ItemTemplate>
                        <%#Eval("检查员").ToString%>多人
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
                        <input type="text" class="textbox_lable" value='<%#Eval("继承结果").ToString%>' style="width: 200px; font-size: 24px;" readonly="true" />
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
                        <input type="button" value="编辑" class="btn_common_new" onclick="return fnedit('<%#Eval("ID").ToString%>','<%#Eval("作番").ToString%>')" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>

            </Columns>
            <HeaderStyle CssClass="tbl_ms_title_new" />
        </asp:GridView>
    </div>



    <asp:Button ID="btnEdit" runat="server" Text="编辑" CssClass="Common_button" Style="width: 140px; margin-left: 10px; visibility: hidden;" />
    <asp:HiddenField ID="hidResultID" runat="server" />
    <asp:HiddenField ID="hidKbn" runat="server" />
    <asp:HiddenField ID="hidDLX" runat="server" />
      <asp:HiddenField ID="hidBumen" runat="server" />
      <asp:HiddenField ID="hidLineName" runat="server" />
    <script>
        function fnedit(id, kbn) {
            $("#ctl00_MC_hidResultID").val(id);
            $("#ctl00_MC_hidKbn").val(kbn);
            $("#ctl00_MC_btnEdit").click();
            return false;
        }


    </script>

</asp:Content>

