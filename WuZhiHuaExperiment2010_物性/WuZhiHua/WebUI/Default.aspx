<%@ Page Title="" Language="VB" MasterPageFile="~/Site.Mobile.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        /* 去掉默认样式，设置新的样式 */
        .select-style {
            position: relative;
            display: inline-block;
        }

            .select-style select {
                display: inline-block;
                box-sizing: border-box;
                background: none;
                border: 1px solid #222;
                outline: none;
                -webkit-appearance: none;
                padding: 5px 15px 5px 5px;
                line-height: inherit;
                color: inherit;
                cursor: pointer;
                font-size: 14px;
                position: relative;
                z-index: 3;
                height: 100%;
                border-radius: 2px;
            }

            .select-style:after {
                content: '';
                color: red;
                position: absolute;
                top: 0;
                bottom: 0;
                right: 5px;
                height: 100%;
                padding: 5px 0;
            }

            .select-style select option {
                color: #222;
            }

                .select-style select option:hover {
                    background-co: #535353;
                    color: #fff;
                }

                .select-style select option:checked {
                    background: #535353;
                    color: #fff;
                }

        #ctl00_MC_gvNg td {
            border: 1px solid #ccc;
        }

        #ctl00_MC_gvNg th {
            border: 1px solid #ccc;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FC" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MC" runat="Server">
    <%--扫描--%>
    <script language="javascript" type="text/javascript" src="./Default.js?ver=1.1112"></script>
    <%--欠品更新--%>    <%--Title--%>
    <table cellspacing="0" rules="all" border="0" class="table_title_new">
        <tr>
            <th style="font-size: 25px; color: #fff; width: 4px"></th>
            <th style="font-size: 20px;"></th>
            <th>

                <asp:Button ID="btnKensaku" runat="server" Text="查询" CssClass="btn_common_new" />


            </th>
            <th>
                <asp:Button ID="btnByHand2" runat="server" Text="清空" CssClass="btn_common_new" />

            </th>
            <td>
                <asp:Button ID="btnByHand1" runat="server" Text="手入力" CssClass="btn_common_new" />
            </td>
            <th>
                <a href="APP/MWF/MachineData.application" style="height: 40px; font-size: 40px; color:#fff"><span class="">投影仪连接</span></a>
            </th>
        </tr>
    </table>
    <table style="font-size: 36px;">
        <tr style="text-align: center; background-color: blue; color: #fff;">
            <td class="auto-style1">CD/型番</td>
            <td>部                门</td>
            <td>生产线</td>
            <td style="width: 140px;">1,2,3检</td>
            <td style="background-color: #000">区分</td>
            <td>检查员</td>

        </tr>
        <tr style="vertical-align: top;">
            <td>
                <asp:TextBox ID="tbxGoodsCd" runat="server" CssClass="defaultPage_textbox_scan" Text="" Width="360" Height="36px" AutoCompleteType="None" list="xingfan_list" Font-Size="34px"></asp:TextBox>
            </td>
            <td>
                <asp:ListBox ID="lbBumen" runat="server" CssClass="select-style" Width="140px" Style="font-size: 34px;"></asp:ListBox>
            </td>
            <td>

                <asp:ListBox ID="cbLineName" runat="server" CssClass="select-style" Width="300px" Style="font-size: 34px;"></asp:ListBox>
            </td>
            <td>
                <asp:ListBox ID="lblChkKbn" runat="server" CssClass="select-style" Width="140px" Style="font-size: 34px;">
                    <asp:ListItem Selected="True" Value="1">一</asp:ListItem>
                    <asp:ListItem Value="2">二</asp:ListItem>
                    <asp:ListItem Value="3">三</asp:ListItem>
                </asp:ListBox>
            </td>
            <td>
                <asp:TextBox ID="tbxMakeNumber" runat="server" CssClass="defaultPage_textbox_scan" Height="36px" Text="" Width="140" AutoCompleteType="None" Font-Size="34px"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="tbxCheckUserCd" runat="server" CssClass="defaultPage_textbox_scan" Height="36px" Text="302503" Width="140" AutoCompleteType="None" Font-Size="34px"></asp:TextBox>
            </td>
            <td></td>
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
    <div class="div_ms_new div_ng" style="overflow: hidden; text-align: left; color: Red; font-size: 30px; font-weight: bold;">
        <asp:Label ID="lblNg" runat="server" Text="半年NG项目" Style="color: Red" Visible="false"></asp:Label>
        <asp:Button ID="btnHid" runat="server" Text="隐藏" OnClientClick="$('.div_ng').hide();return false;" Font-Size="30px" />
        <asp:GridView ID="gvNg" runat="server" Width="1250px" CellPadding="4" EnableModelValidation="True" ForeColor="#333333" GridLines="None" BorderColor="#6699FF" BorderStyle="Dashed" BorderWidth="1px">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        </asp:GridView>
    </div>
    <div class="div_ms_plan">
        <div style="width: 100%; text-align: center; color: Red;">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnPreDay" runat="server" Text="<" CssClass="jq_sel" Style="width: 80px; height: 80px; font-size: 50px;" /></td>
                    <td>生产日必须选择
                    <br />
                        <asp:TextBox ID="tbxDate_key" class="jq_zzc" runat="server" MaxLength="20" Style="font-size: 25px; background-color: #FFAA00; ime-mode: disabled; width: 150px; float: left"
                            onkeydown="if(event.keyCode==13){GetDateFormat(this)}" placeholder="7日内"></asp:TextBox></td>
                    <td>
                        <asp:Button ID="btnNextDay" runat="server" Text=">" CssClass="jq_sel" Style="width: 80px; height: 80px; font-size: 50px;"/>
                    </td>
                    <td style="font-size: 25px;">只匹配到一个型番<br />
                        的计划数据已经隐藏!! 
                    </td>
                    <td>
                        <asp:Button ID="btnReCheck" runat="server" Text="新规检查" CssClass="btn_common_new" Visible="false" Width="300px" />
                    </td>
                    <td>
                        <asp:Button ID="btnNotCheckList" runat="server" Text="未检查一览" CssClass="btn_common_new" Width="300px" OnClientClick="window.open('NotCheckList.aspx');return false; " />
                    </td>

                </tr>
            </table>

        </div>

        <asp:GridView ID="gvPlanMS" runat="server" AutoGenerateColumns="False" Width="" EnableModelValidation="True" Font-Size="30px">
            <Columns>
                <asp:TemplateField HeaderText="选择-中间材CD">
                    <ItemTemplate>
                        <asp:CheckBox ID="cbMerge" runat="server" CssClass="jq_zzcChk" Text=' <%#Eval("中间材CD").ToString%>' Style="width: 60px; height: 60px;" />
                    </ItemTemplate>
                    <ItemStyle Width="450" HorizontalAlign="left" Font-Size="40px" ForeColor="Blue" />
                </asp:TemplateField>
                <%--                <asp:TemplateField HeaderText="中间材CD">
                    <ItemTemplate>
                        <%#Eval("中间材CD").ToString%>
                    </ItemTemplate>
                    <ItemStyle Width="200" />
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="作番">
                    <ItemTemplate>
                        <asp:Label ID="lblmakeNumber" runat="server" Text='<%# Eval("作番").ToString %>'></asp:Label>
                        <%-- %> <%#Eval("作番").ToString%>--%>
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
                    <ItemStyle Width="80" HorizontalAlign="center" />
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
                <asp:TemplateField HeaderText="匹配型番">
                    <ItemTemplate>
                        <%#Eval("匹配型番").ToString%>
                    </ItemTemplate>
                    <ItemStyle Width="300" />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="tbl_ms_title_new" />
        </asp:GridView>
    </div>
    <hr />
    <%--BUTTON--%>
    <div class="div_ms_new" style="overflow: hidden; text-align: center;">

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
                        <input type="button" value="编辑" class="btn_common_new" onclick="return fnedit('<%#Eval("ID").ToString%>    ','<%#Eval("作番").ToString%>    ')" />
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
                        <input type="button" value="编辑" class="btn_common_new" onclick="return fnedit('<%#Eval("ID").ToString%>    ','<%#Eval("作番").ToString%>    ')" />
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

