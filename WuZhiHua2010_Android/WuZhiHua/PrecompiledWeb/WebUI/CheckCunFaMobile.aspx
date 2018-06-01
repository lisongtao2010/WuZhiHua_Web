<%@ page title="" language="VB" masterpagefile="~/Site.Mobile.master" autoeventwireup="false" inherits="CheckCunFaMobile, App_Web_bqmlfxkf" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server"></asp:Content>
<asp:Content ID="C1" ContentPlaceHolderID="FC" Runat="Server">
    <script src="Scripts/CheckJScript.js" type="text/javascript"></script>
    <script src="Scripts/UpdateJScript.js" type="text/javascript"></script>

    <script>
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

     <div style="margin-left:10px;">
            <table>
                <tr>
                    <td></td>
                    <td><asp:Label ID="lblMessage" runat="server" Text="" style="color:Red"></asp:Label></td>
                </tr>
            </table>        
    </div>
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
        <asp:TextBox ID="tbxGoodsCd" runat="server" CssClass="textbox_lable_white" Text ="L0620MJJE" ReadOnly="true"></asp:TextBox>
        <br />
        <asp:TextBox ID="tbxMakeNumber" runat="server" CssClass="textbox_lable_white" Text="074090017" ReadOnly="true"></asp:TextBox></td>
        <td style="width:140px;">
            <asp:TextBox ID="tbxCheckUserCd" runat="server" CssClass="textbox_lable_white" ReadOnly="true"></asp:TextBox>
        </td>
              
        <th style="">
            <asp:Button ID="btnKensaku" runat="server" Text="" style="visibility:hidden;" />
            <asp:Button ID="Button1" runat="server" Text="外观>治具" CssClass="btn_common_new"/>
            <asp:Button ID="btnJiaSame" runat="server" Text="待判"  CssClass="btn_common_new"  OnClientClick="UpdateRow(false);return ConfirmMsg(this);" />
            <asp:Button ID="btnSave" runat="server" Text="完了" CssClass="btn_common_new"      OnClientClick="UpdateRow(false);return ConfirmKanryouMsg(this);" />
            <asp:Button ID="btnSave0" runat="server" Text="假保存" CssClass="btn_common_new"   OnClientClick="UpdateRow(false);return ConfirmMsg(this);" />
            <asp:Button ID="btnBack" runat="server" Text="退出" CssClass="btn_common_new"      OnClientClick="UpdateRow(false);return ConfirmMsg(this);" />
        </th>
    </tr>
</table> 

<div class="div_ms_new" style="overflow:hidden; text-align:center;">    
    <table cellspacing="0" rules="all" border="0" style="width:1283px;">
    <tr>
        <th style="color:#333;"   >
            <div class="tbl_komoku_title_new" style="width:100%" >
                <asp:Label ID="lblKind" runat="server" Text="" style="font-size:34px;"></asp:Label>
            </div>

            <div style="text-align:center; background-color:#fff; width:1283px; overflow:auto;">      
            <%
            Response.Write(GetKindLinks())
            %>
            </div>    
        </th>
    </tr>
</table> 
</div>

<%--MS TITLE--%>
<div class="div_ms_new" style="overflow:hidden; margin-bottom:0px;">
<table cellspacing="0" border="1" class="tbl_ms_title_new" 
        style="width:1286px; 
        border-collapse:collapse;
        font-size:24px;
        font-weight:bold;
        text-align:center;
        border-color:#fff; 
        " >
<tr>
<td  style="width:140px;">
<input id="tbxScanSave" type="text" class="text_scan_save_new" autocomplete="off"  />
位置</td>    
<td  style="width:300px;">检查项目</td>
<td  style="width:80px;">方法</td>
<td  style="width:160px;">实测1</td>
<td  style="width:160px;">实测2</td>
<td  style="width:80px;">结果</td>
<td style="width:162px;">备注</td>
<td >基准</td>
</tr>
</table>
</div>

<%--MS--%>
<div style="width:1300px; height:670px; overflow:scroll ; font-size:26px; color:#333;">
<asp:GridView ID="gvLastCheckResultMS" CssClass="JQ_CheckMS" runat="server" AutoGenerateColumns="False" ShowHeader="false" width="1286px"  >
<Columns>
<asp:TemplateField HeaderText ="位置">
<ItemTemplate>
<%--<a style="color:Blue;"><%# Eval("check_times").ToString%></a>:--%>
<a style="color:Blue;"><%# Eval("kind").ToString%></a>|
<a style="color:red;"><%# Eval("check_position").ToString%></a>          
</ItemTemplate>                       
<ItemStyle Width="140" />
</asp:TemplateField>
<asp:TemplateField HeaderText ="检查项目">
<ItemTemplate>
<%# Eval("check_item").ToString%>
</ItemTemplate>
<ItemStyle Width="300" />                       
</asp:TemplateField>
<asp:TemplateField HeaderText ="方法">
<ItemTemplate>
<%# Eval("check_way").ToString%>
</ItemTemplate>
<ItemStyle Width="80" />                       
</asp:TemplateField>
<asp:TemplateField HeaderText ="实测1">
<ItemTemplate >
<input type="text" readonly="readonly" class='<%#GetTextBoxClass(Eval("check_way").ToString) %> JQ_SHICE1' value='<%#Eval("measure_value1").ToString%>' 
style=" display:<%# GetTextBoxEnable(Eval("benchmark_type").ToString,1) %>;"/>
</ItemTemplate>
<ItemStyle Width="160" /> 
</asp:TemplateField>
<asp:TemplateField HeaderText ="实测2">
<ItemTemplate >
<input type="text" class='<%#GetTextBoxClass(Eval("check_way").ToString) %> JQ_SHICE2' value='<%#Eval("measure_value2").ToString%>' 
style="display:<%# GetTextBoxEnable(Eval("benchmark_type").ToString,2) %>;"/>
</ItemTemplate>
<ItemStyle Width="160" />
</asp:TemplateField>
<asp:TemplateField HeaderText ="结果">
<ItemTemplate ><%# GetTextJieguo(Eval("result").ToString)%></ItemTemplate>
<ItemStyle Width="80" HorizontalAlign="Center" CssClass="JQ_JIEGUO" />
</asp:TemplateField>
<asp:TemplateField HeaderText ="备注">
<ItemTemplate >


<textarea rows="2" id="TextArea1"  class='JQ_BEIZHU textbox_common' 
maxlength="100"><%#Eval("remarks").ToString %></textarea>
            
</ItemTemplate>
<ItemStyle Width="162" Font-Size="12" CssClass="JQ_BEIZHU" />

</asp:TemplateField>
    
<asp:TemplateField HeaderText ="">
<ItemTemplate >
<%# Com.GetRemark(Eval("remarks").ToString, Eval("result").ToString, Eval("benchmark_type").ToString, Eval("benchmark_type_old").ToString, Eval("benchmark_value1").ToString, Eval("benchmark_value2").ToString, Eval("benchmark_value3").ToString, Eval("benchmark_value1_old").ToString, Eval("benchmark_value2_old").ToString, Eval("benchmark_value3_old").ToString, Eval("measure_value1").ToString, Eval("measure_value2").ToString)%>
</ItemTemplate>
  
</asp:TemplateField>                          
</Columns>
</asp:GridView>
</div>

<%--图片百分比--%>
<div class="div_ms_new" style="overflow:hidden; margin-bottom:0px;">
    <table style="width:1286px;">
    <tr>
    <td>
       <input type="button" value=" 50%" onclick="Show100('50%')" class="baifenbiButton"/>
        <input type="button" value=" 70%" onclick="Show100('70%')" class="baifenbiButton"/>
        <input type="button" value="100%" onclick="Show100('100%')" class="baifenbiButton"/>
        <input type="button" value="120%" onclick="Show100('120%')" class="baifenbiButton"/>
        <input type="button" value="150%" onclick="Show100('150%')" class="baifenbiButton"/>
        <input type="button" value="200%" onclick="Show100('200%')" class="baifenbiButton"/>

    </td>
    <td>
        <div  style=" background-color:#fff; color:#000; width:100%; text-align:right;" >
            <asp:Label ID="lbl_RESULT_MSG" runat="server" Text="" CssClass="JQ_RESULT_MSG" style="font-size:24px; color:Red;"  ></asp:Label>
        </div>
    </td>
    
    </tr>
    
    </table>
</div>


<%--图片 小键盘--%>
<div class="div_ms_new" style="overflow:hidden; margin-bottom:0px;">

<table>
    <tr>
        <td style="width:890px; text-align:left; vertical-align:top;">
            <div style="width:880px; height:700px; overflow:auto;">
                <asp:Image ID="imgLook" runat="server" CssClass="JQ_IMG"/>
                    
            </div>
                    
                
        </td>
        <td style="text-align:left; vertical-align:top;">
            <table cellspacing="0" 
		   		        border="1" 
				        style="width:400px; 
						    border-collapse:collapse;
						    font-size:24px;
						    font-weight:bold; 
						    border-color:#eee; 
						    background-image: -webkit-gradient(linear, left top, left bottom, color-stop(0, #4499ee), color-stop(1, #065fb9)); 
						    color:#fff; 
						    text-align:center;" >


	            <tr style="height:100px;">
		            <td onclick="KeyBoard(this);">7</td>
		      	    <td onclick="KeyBoard(this);">8</td>
		      	    <td onclick="KeyBoard(this);">9</td>

		      	 	
	            </tr>
	            <tr style="height:100px;">
		            <td onclick="KeyBoard(this);">4</td>
		      	    <td onclick="KeyBoard(this);">5</td>
		      	    <td onclick="KeyBoard(this);">6</td>

	
	            </tr>
	            <tr style="height:100px;">
		            <td onclick="KeyBoard(this);">1</td>
		      	    <td onclick="KeyBoard(this);">2</td>
		      	    <td onclick="KeyBoard(this);">3</td>
		      	    
	            </tr>

	            <tr style="height:100px;">
		      	    <td onclick="KeyBoard(this);">0</td>
		            <td onclick="KeyBoard(this);">.</td>
                    <td onclick="KeyBoard(this);">删</td>  	
	            </tr>
	            <tr style="height:100px;">
                    <td onclick="KeyBoard(this);" colspan="3">回车</td>  
                </tr>
	            <tr style="height:100px;">
                    <td runat="server" id="tdJinggao" onclick="KeyBoard(this);  "  style=" background-color:green;">警</td>  
                        <td onclick="KeyBoard(this);" style=" background-color:green;">微</td> 	
		      	    <td onclick="KeyBoard(this);" style=" background-color:Red;">轻</td> 
	            </tr>
                <tr style="height:100px;">
		      	    <td onclick="KeyBoard(this);" style=" background-color:Red;">中</td>
		      	    <td onclick="KeyBoard(this);" style=" background-color:Red;">重</td>
                    <td onclick="KeyBoard(this);" style=" background-color:green;">合</td> 
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

    <script>

    $(document).ready(function () {
        Show100('100%');
        RowSelect($(".JQ_CheckMS")[0].rows[0]);
        var shiceObj;
        shiceObj = $($(".JQ_CheckMS")[0].rows[0]).find(".JQ_SHICE1");
        if (shiceObj.css("display") != "none") {
            SetFocusAndSelectText(shiceObj);
        }
    });

    </script>
</asp:Content>

