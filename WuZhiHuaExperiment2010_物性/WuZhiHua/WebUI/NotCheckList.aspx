<%@ Page Title="" Language="VB" MasterPageFile="~/Site.Mobile.master" AutoEventWireup="false" CodeFile="NotCheckList.aspx.vb" Inherits="NotCheckList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server"></asp:Content>
<asp:Content ID="C1" ContentPlaceHolderID="FC" runat="Server">

    <%--MESSAGE--%>
    <div class="div_msg_new">
        <input id="tbxScanSave" type="text" class="text_scan_save_new" autocomplete="off" />
        <asp:Label ID="lblMessage" runat="server" Text="" Style="color: Red"></asp:Label>
    </div>

    <div class="div_ms_notcheck">
         <div style="width: 100%; text-align: center; color: Red;">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnPreDay" runat="server" Text="<" CssClass="jq_sel" Style="width: 80px; height: 80px; font-size: 50px;" /></td>
                    <td>日期必须选择
                    <br />
                        <asp:TextBox ID="tbxDate_key" class="jq_zzc" runat="server" MaxLength="20" Style="font-size: 25px; background-color: #FFAA00; ime-mode: disabled; width: 150px; float: left"
                            onkeydown="if(event.keyCode==13){GetDateFormat(this)}" placeholder="7日内"></asp:TextBox></td>
                    <td>
                        <asp:Button ID="btnNextDay" runat="server" Text=">" CssClass="jq_sel" Style="width: 80px; height: 80px; font-size: 50px;" />
                    </td>
                    <td>
                        <asp:Button ID="btnReSearch" runat="server" Text="检索" CssClass="btn_common_new" />
                         <asp:Button ID="btnReSearchSum" runat="server" Text="合并检索" CssClass="btn_common_new" />
                    </td>
                    <td>
                        <asp:Button ID="btnOutput" runat="server" Text="出力" CssClass="btn_common_new" />
                    </td>
                    <td>
                        <asp:Button ID="btnClose" runat="server" Text="关闭" CssClass="btn_common_new" OnClientClick = "window.close();return false; "/>
                    </td>
                </tr>
            </table>

        </div>

        <asp:GridView ID="gvNotCheckMS" runat="server" AutoGenerateColumns="False" Width="" EnableModelValidation="True" Font-Size="30px">
            <Columns>
                <asp:TemplateField HeaderText="中间材CD">
                    <ItemTemplate>
                        <%#Eval("中间材CD").ToString%>
                    </ItemTemplate>
                    <ItemStyle Width="80" HorizontalAlign="center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="型番">
                    <ItemTemplate>
                        <%#Eval("型番").ToString%>
                    </ItemTemplate>
                    <ItemStyle Width="300" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="作番">
                    <ItemTemplate>
                        <%#Eval("作番").ToString%>
                    </ItemTemplate>
                    <ItemStyle Width="200" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="线">
                    <ItemTemplate>
                        <%#Eval("生产线").ToString%>
                    </ItemTemplate>
                    <ItemStyle Width="80" HorizontalAlign="center" />
                </asp:TemplateField>
                                <asp:TemplateField HeaderText="号机">
                    <ItemTemplate>
                        <%#Eval("号机").ToString%>
                    </ItemTemplate>
                    <ItemStyle Width="180" HorizontalAlign="center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="数量">
                    <ItemTemplate>
                        <%#Eval("数量").ToString%>
                    </ItemTemplate>
                    <ItemStyle Width="100" HorizontalAlign="right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="生产日">
                    <ItemTemplate>
                        <%#SetDateYMD(Eval("生产日").ToString）%>
                    </ItemTemplate>
                    <ItemStyle Width="180" HorizontalAlign="center" />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="tbl_ms_title_new" />
        </asp:GridView>

    </div>

</asp:Content>

