<%@ page title="" language="VB" masterpagefile="~/Site.Mobile.master" autoeventwireup="false" inherits="_Default, App_Web_0adv2mkg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style3
        {
            font-weight: bold;
            text-align: center;
            background-color: #FF9900;
        }
        .style6
        {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FC" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MC" Runat="Server">
    <table cellspacing="0" rules="all" border="0" class="table_title_new">
<tr>
    <th style="width:160px; font-size:25px; color:#fff;">
        <a style="font-size:34px;">L</a>
        <a style="font-size:32px;">I</a>
        <a style="font-size:30px;">X</a>
        <a style="font-size:32px;">I</a>
        <a style="font-size:34px;">L</a>
    </th>
            <th style="width:50px;" class="Title">
                &nbsp;</th>
            <td style="width:140px;">
                &nbsp;</td>
            <th style="width:70px;">
                &nbsp;</th>
            <td style="width:140px;">
                &nbsp;</td>
            <th style="width:90px;">
                &nbsp;</th>
            <td style="width:140px;">
                &nbsp;</td>
            <th style="">
                &nbsp;</th>
        </tr>
    </table>

    <br />
    <table style='width:1286px;'>
        <tr class="tbl_ms_title_new" style="text-align:center;" >
            <td width="200">
               检察员</td>
            <td width="200">
                座番</td>
            <td width="200">
                CD</td>
            <td width="200">
                </td>
            <td colspan="2" >
                检查结果</td>
        </tr>
        <tr>
            <td >
                <asp:TextBox ID="tbxCheckUserCd" runat="server" CssClass="textbox_common" Text = "300368" ></asp:TextBox></td>
                
            <td >
                <asp:TextBox ID="tbxMakeNumber" runat="server" CssClass="textbox_common"  Text="074090017" ></asp:TextBox></td>

            <td >
                <asp:TextBox ID="tbxGoodsCd" runat="server" CssClass="textbox_common" Text ="L0820MJYA" ></asp:TextBox></td>


            <td >
                  &nbsp;
                    </td>
            <td  style="font-size:38px; text-align:center;">
                <asp:RadioButton ID="rbtnOk" runat="server" Text="  OK  "  GroupName="jieguoAA" onclick="SelJieguoCheck(this)" CssClass="JQ_RBTN" Checked="true" ForeColor="Red" />
            </td>
            <td  style="font-size:38px;text-align:center;">
                <asp:RadioButton ID="rbtnNG" runat="server" Text="  NG  " GroupName="jieguoAA"  onclick="SelJieguoCheck(this)" CssClass="JQ_RBTN" />
                <script>
                    function SelJieguoCheck(e) {

                        $(".JQ_RBTN").css("color", "#000");
                        $(".JQ_RBTN").parent().css("color", "#000");
                        $(e).parent().css("color", "red");
                    }
                </script>
            </td>
        </tr>
        <tr class="tbl_ms_title_new" style="text-align:center;" >
            <td width="200">
               生产线</td>
            <td width="200">
                数量</td>
            <td width="200">
                </td>
            <td width="200">
                </td>
            <td colspan="2" >
                </td>
        </tr>

        <tr>
        <td>
         <asp:TextBox ID="tbxLineCd" runat="server" CssClass="textbox_common" Text = "" Enabled="false"></asp:TextBox>
        
        </td>
        <td>
         <asp:TextBox ID="tbxSuu" runat="server" CssClass="textbox_common" Text = ""  Enabled="false"></asp:TextBox>
        
        </td>

            <td colspan="4" style="text-align: center">
                <asp:Button ID="btnSelect" runat="server" Text="查询" CssClass="Common_button"  
                     style="width:140px; margin-left:10px" />
                             <asp:Button ID="btnTorokuNew" runat="server" Text="登录" CssClass="Common_button"  
                     style="width:140px; margin-left:10px" />
         <asp:Button ID="btnBack" runat="server" Text="返回" CssClass="Common_button"  
                     style="width:140px; margin-left:10px" />
                     </td>
        </tr>
        <tr>
            <td colspan="6" style="text-align: right">


            </td>
        </tr>
    </table>
    <br />
    <br />

    <asp:Label ID="lblMessage" runat="server" Text="" style="color:Red"></asp:Label>
    <asp:Label ID="lblHint" runat="server" Text="" style="color:blue"></asp:Label>

<div class="div_ms_new">
    <asp:GridView ID="gvLastCheckResultMS" runat="server" AutoGenerateColumns="False" width="1450px">
        <Columns>
            <asp:TemplateField HeaderText ="检查员">
                <ItemTemplate >
                    <%#Eval("检查员").ToString%>
                    <%#Eval("检查员CD").ToString%>
                 </ItemTemplate>
                    <ItemStyle Width="100" />
            </asp:TemplateField>
            

            <asp:TemplateField HeaderText ="ID<br>作番">
                <ItemTemplate>
                    <%#Eval("ID").ToString%>
                    <input type="text" class="textbox_lable" value='<%#Eval("作番").ToString%>' style='width:200px; color:<%# GetSameMakeNoFontColor(Eval("作番").ToString) %>' readonly="true"/>
                </ItemTemplate>
                    <ItemStyle Width="200" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText ="生产线-数量<br>生产实际日">
                <ItemTemplate >
                    <input type="text" class="textbox_lable" value='<%#Eval("生产线").ToString & "-" & Eval("数量").ToString%>' style="width:240px;" readonly="true" />
                    <%#SetDateF(Eval("生产实际日").ToString）%>
                </ItemTemplate>
                <ItemStyle Width="240" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText ="结果<br>状态">
                <ItemTemplate >
                    <input type="text" class="textbox_lable" value='<%#Eval("结果").ToString%>' style="width:80px;" readonly="true"/>
                    <input type="text" class="textbox_lable" value='<%#Eval("状态").ToString%>' style="width:80px;" readonly="true"/>
                </ItemTemplate>
                <ItemStyle Width="80" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText ="开始<br>结束时间">
                <ItemTemplate >
                    <%#SetDateF(Eval("开始时间").ToString）%>
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
<%--            <asp:TemplateField HeaderText ="欠品">
                <ItemTemplate >

                    <asp:CheckBox ID="cbQianpin" runat="server" text="是否欠品"/>
                </ItemTemplate>
                        <ItemStyle Width="150" />
            </asp:TemplateField>--%>
                 
            <asp:TemplateField HeaderText ="编辑谨慎使用">
                <ItemTemplate >
                    <input type = "button" value="编辑" class="btn_common_new" onclick = "return fnedit('<%#Eval("ID").ToString%>')"/>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            
        </Columns>
        <HeaderStyle CssClass="tbl_ms_title_new" />
    </asp:GridView>
</div>
<br /> 
<div class="div_ms_new" style="overflow:hidden; text-align:center; color:Red; font-size:30px; font-weight:bold;">
    下面是临时保存的数据 （可能是中途退出的）
</div>

<div class="div_ms_new">
<asp:GridView ID="GVFlg3" runat="server" AutoGenerateColumns="False" width="1450px"  >
<Columns>

<asp:TemplateField HeaderText ="检查员">
<ItemTemplate >
<%#Eval("检查员").ToString%>
<%#Eval("检查员CD").ToString%>
</ItemTemplate>
<ItemStyle Width="100" />
</asp:TemplateField>


<asp:TemplateField HeaderText ="ID<br>作番">
<ItemTemplate>
<%#Eval("ID").ToString%>
<input type="text" class="textbox_lable" value='<%#Eval("作番").ToString%>' style='width:200px; color:<%# GetSameMakeNoFontColor(Eval("作番").ToString) %>' readonly="true"/>
</ItemTemplate>
<ItemStyle Width="200" />
</asp:TemplateField>

<asp:TemplateField HeaderText ="生产线-数量<br>生产实际日">
<ItemTemplate >
<input type="text" class="textbox_lable" value='<%#Eval("生产线").ToString & "-" & Eval("数量").ToString%>' style="width:240px;" readonly="true" />
<%#SetDateF(Eval("生产实际日").ToString）%>
</ItemTemplate>
<ItemStyle Width="240" />
</asp:TemplateField>

<asp:TemplateField HeaderText ="结果<br>状态">
<ItemTemplate >
<input type="text" class="textbox_lable" value='<%#Eval("结果").ToString%>' style="width:80px;" readonly="true"/>
<input type="text" class="textbox_lable" value='<%#Eval("状态").ToString%>' style="width:80px;" readonly="true"/>
</ItemTemplate>
<ItemStyle Width="80" />
</asp:TemplateField>



<asp:TemplateField HeaderText ="开始<br>结束时间">
<ItemTemplate >
<%#SetDateF(Eval("开始时间").ToString）%>
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
<%--<asp:TemplateField HeaderText ="欠品">
<ItemTemplate >

<asp:CheckBox ID="cbQianpin" runat="server" text="是否欠品"/>
</ItemTemplate>
<ItemStyle Width="150" />
</asp:TemplateField>--%>
                 
<asp:TemplateField HeaderText ="编辑">
<ItemTemplate >
<input type = "button" value="编辑" class="btn_common_new" onclick = "return fnedit('<%#Eval("ID").ToString%>')"/>
</ItemTemplate>
<ItemStyle HorizontalAlign="Center" />
</asp:TemplateField>
            
</Columns>
<HeaderStyle CssClass="tbl_ms_title_new" />
</asp:GridView>
</div>

<div class="div_ms_new" style="overflow:hidden; text-align:center; display:none;">
    <asp:Button ID="btnReCheck" runat="server" Text="新规检查" CssClass="btn_common_new" Visible = "false" Width="33%"  />
    <asp:Button ID="btnDefault" runat="server" Text="默认结果" CssClass="btn_common_new" Visible = "false" Width="33%" />
    <asp:Button ID="btnContinueCheck" runat="server" Text="继续检查" CssClass="btn_common_new" Visible = "false" Width="33%" />

</div>
    
<div class="div_ms_new">
</div>
            <asp:Button ID="btnEdit" runat="server" Text="编辑" CssClass="Common_button" style="width:140px; margin-left:10px ;  visibility:hidden;" />
            <asp:HiddenField ID="hidResultID" runat="server" />
            <script>
                function fnedit(id) {
                    $("#ctl00_MC_hidResultID").val(id);
                    $("#ctl00_MC_btnEdit").click();
                    return false;
                }
            
            
            </script>

</asp:Content>

