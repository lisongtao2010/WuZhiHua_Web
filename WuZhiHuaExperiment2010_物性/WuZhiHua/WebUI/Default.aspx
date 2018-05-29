<%@ Page Title="" Language="VB" MasterPageFile="~/Site.Mobile.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FC" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MC" Runat="Server">

<%--扫描--%>
<script language="javascript">

    var Gl_FocusTextbox;
    Gl_FocusTextbox = null;
    $(document).ready(function () {

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


</script>

<%--欠品更新--%>
<script>
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
</script>

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
        <th style="width:50px;">
            CD
        </th>
        <td style="width:140px;">
            <asp:TextBox ID="tbxGoodsCd" runat="server" CssClass="defaultPage_textbox_scan" Text ="" Width="140" AutoCompleteType="None"></asp:TextBox>
        </td>
        <th style="width:70px;">
            区分</th>
        <td style="width:140px;">
            <asp:TextBox ID="tbxMakeNumber" runat="server" CssClass="defaultPage_textbox_scan" Text="" Width="140" AutoCompleteType="None"></asp:TextBox>
        </td>
        <th style="width:90px;">
            检查员</th>
        <td style="width:140px;">
            <asp:TextBox ID="tbxCheckUserCd" runat="server" CssClass="defaultPage_textbox_scan" Text = "302503" Width="140" AutoCompleteType="None"></asp:TextBox>
        </td>
        <th style="">
            <asp:Button ID="btnKensaku" runat="server" Text="查询"  CssClass="btn_common_new" />
            <asp:Button ID="btnByHand1" runat="server" Text="手入力" CssClass="btn_common_new" />
            <asp:Button ID="btnByHand2" runat="server" Text="清空" CssClass="btn_common_new" />
        </th>
    </tr>
</table>

<%--MESSAGE--%>
<div class="div_msg_new">
    <input id="tbxScanSave" type="text" class="text_scan_save_new" autocomplete="off"  />
    <asp:Label ID="lblMessage" runat="server" Text="" style="color:Red"></asp:Label>
    <asp:Label ID="lblHint" runat="server" Text="" style="color:blue"></asp:Label>
</div>

<%--BUTTON--%>
<div class="div_ms_new" style="overflow:hidden; text-align:center;">
    <asp:Button ID="btnReCheck" runat="server" Text="新规检查" CssClass="btn_common_new" Visible = "false" Width="33%"  />
    <asp:Button ID="btnDefault" runat="server" Text="默认结果" CssClass="btn_common_new" Visible = "false" Width="33%" />
    <asp:Button ID="btnContinueCheck" runat="server" Text="继续检查" CssClass="btn_common_new" Visible = "false" Width="33%" />

</div>
<div class="div_ms_new" style="overflow:hidden; text-align:left; color:Red; font-size:30px; font-weight:bold;">
   <asp:Label ID="lblChecked" runat="server" Text="检查完了的数据" style="color:Red" Visible = "false"></asp:Label>
    
</div>
<div class="div_ms_new">
    <asp:GridView ID="gvLastCheckResultMS" runat="server" AutoGenerateColumns="False" width="1250px">
        <Columns>
            <asp:TemplateField HeaderText ="ID<br>作番">
                <ItemTemplate>
                    <%#Eval("ID").ToString%>
                    <input type="text" class="textbox_lable" value='<%#Eval("作番").ToString%>' style='width:200px; color:<%# GetSameMakeNoFontColor(Eval("作番").ToString) %>' readonly="true"/>
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

            <asp:TemplateField HeaderText ="结果<br>状态">
                <ItemTemplate >
                    <input type="text" class="textbox_lable" value='<%#Eval("结果").ToString%>' style="width:80px;" readonly="true"/>
                    <input type="text" class="textbox_lable" value='<%#Eval("状态").ToString%>' style="width:80px;" readonly="true"/>
                </ItemTemplate>
                <ItemStyle Width="80" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText ="检查员">
                <ItemTemplate >
                    <%#Eval("检查员").ToString%>多人
                    <%#Eval("检查员CD").ToString%>
                 </ItemTemplate>
                    <ItemStyle Width="100" />
            </asp:TemplateField>


            <asp:TemplateField HeaderText ="开始<br>结束时间">
                <ItemTemplate >
                    <%#SetDateF(Eval("开始时间").ToString）%><br />
                    <%#SetDateF(Eval("结束时间").ToString）%>
                </ItemTemplate>
                <ItemStyle Width="200" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText ="继承<br>结果">
                <ItemTemplate >
                    <input type="text" class="textbox_lable" value='<%#Eval("继承结果").ToString%>' style="width:200px; font-size:24px;" readonly="true"/>
                </ItemTemplate>
                <ItemStyle Width="200" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText ="欠品">
                <ItemTemplate >

                    <asp:CheckBox ID="cbQianpin" runat="server" text="是否欠品"/>
                </ItemTemplate>
                        <ItemStyle Width="150" />
            </asp:TemplateField>
                 
            <asp:TemplateField HeaderText ="编辑谨慎使用">
                <ItemTemplate >
                    <input type = "button" value="编辑" class="btn_common_new" onclick = "return fnedit('<%#Eval("ID").ToString%>','<%#Eval("作番").ToString%>')"/>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            
        </Columns>
        <HeaderStyle CssClass="tbl_ms_title_new" />
    </asp:GridView>
</div>
<br /> 
<div class="div_ms_new" style="overflow:hidden; text-align:left; color:Red; font-size:30px; font-weight:bold;">
    <asp:Label ID="lblChecking" runat="server" Text="检查中的数据" style="color:Red" Visible = "false"></asp:Label>
</div>
    
<div class="div_ms_new">
<asp:GridView ID="GVFlg3" runat="server" AutoGenerateColumns="False" width="1250px"  >
<Columns>
<asp:TemplateField HeaderText ="ID<br>作番">
<ItemTemplate>
<%#Eval("ID").ToString%>
<input type="text" class="textbox_lable" value='<%#Eval("作番").ToString%>' style='width:200px; color:<%# GetSameMakeNoFontColor(Eval("作番").ToString) %>' readonly="readonly"/>
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

<asp:TemplateField HeaderText ="结果<br>状态">
<ItemTemplate >
<input type="text" class="textbox_lable" value='<%#Eval("结果").ToString%>' style="width:80px;" readonly="readonly"/>
<input type="text" class="textbox_lable" value='<%#Eval("状态").ToString%>' style="width:80px;" readonly="readonly"/>
</ItemTemplate>
<ItemStyle Width="80" />
</asp:TemplateField>

<asp:TemplateField HeaderText ="检查员">
<ItemTemplate >
<%#Eval("检查员").ToString%>多人
<%#Eval("检查员CD").ToString%>
</ItemTemplate>
<ItemStyle Width="100" />
</asp:TemplateField>


<asp:TemplateField HeaderText ="开始<br>结束时间">
<ItemTemplate >
<%#SetDateF(Eval("开始时间").ToString）%><br />
<%#SetDateF(Eval("结束时间").ToString）%>
</ItemTemplate>
<ItemStyle Width="200" />
</asp:TemplateField>

<asp:TemplateField HeaderText ="继承<br>结果">
<ItemTemplate >
<input type="text" class="textbox_lable" value='<%#Eval("继承结果").ToString%>' style="width:200px; font-size:24px;" readonly="true"/>
</ItemTemplate>
<ItemStyle Width="200" />
</asp:TemplateField>
<asp:TemplateField HeaderText ="欠品">
<ItemTemplate >

<asp:CheckBox ID="cbQianpin" runat="server" text="是否欠品"/>
</ItemTemplate>
<ItemStyle Width="150" />
</asp:TemplateField>
                 
<asp:TemplateField HeaderText ="编辑">
<ItemTemplate >
<input type = "button" value="编辑" class="btn_common_new" onclick = "return fnedit('<%#Eval("ID").ToString%>','<%#Eval("作番").ToString%>')"/>
</ItemTemplate>
<ItemStyle HorizontalAlign="Center" />
</asp:TemplateField>
            
</Columns>
<HeaderStyle CssClass="tbl_ms_title_new" />
</asp:GridView>
</div>
            <asp:Button ID="btnEdit" runat="server" Text="编辑" CssClass="Common_button" style="width:140px; margin-left:10px ;  visibility:hidden;" />
            <asp:HiddenField ID="hidResultID" runat="server" />
            <asp:HiddenField ID="hidKbn" runat="server" />
            <script>
                function fnedit(id,kbn) {
                    $("#ctl00_MC_hidResultID").val(id);
                    $("#ctl00_MC_hidKbn").val(kbn);
                    $("#ctl00_MC_btnEdit").click();
                    return false;
                }
            
            
            </script>

</asp:Content>

