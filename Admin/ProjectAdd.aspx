<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ProjectAdd.aspx.cs" Inherits="Admin_ProjectAdd" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table cellpadding="0" cellspacing="0" class="infolist_vt" style="width:92%" align="center">
 <tr>
            <th class="caption" colspan="2">
                试卷添加
            </th>
        </tr>
<tr><th class="common" style="width:20%">试卷名称：</th><td class="common" style="width:80%">&nbsp;&nbsp;
    <asp:TextBox ID="Name" runat="server" Width="398px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ErrorMessage="不能为空" ControlToValidate="Name" ValidationGroup="1"></asp:RequiredFieldValidator>
                                    </td></tr>
<tr><th class="common" style="width:20%">试卷来源：</th><td class="common">

   &nbsp;&nbsp; <asp:DropDownList ID="PRKIDList" runat="server" 
        AutoPostBack="True" ontextchanged="PRKIDList_TextChanged">
    </asp:DropDownList>

</td></tr>
<tr><th class="common">试卷类型：</th><td class="common">
   &nbsp;&nbsp; <asp:DropDownList ID="PaperType" runat="server">
    </asp:DropDownList>
</td></tr>
<tr ><th class="common" style="width:20%">试卷包含试题类型：</th><td class="common">

   
    
     <asp:CheckBoxList ID="CKProblemTypeList" RepeatColumns="6" Enabled="false" runat="server">
    
    </asp:CheckBoxList>
   
  <%-- <a href="ProblemTypeSelect.aspx?height=350;width=500&PRKID=''" class="thickbox">类型选择</a>--%>
   <%--<a href=ProblemTypeSelect.aspx?height=350;width=500' class="thickbox">类型选择</a>--%>

</td></tr>
<%--<tr><th class="common" style="width:20%">试卷试题数量：</th><td class="common">

   &nbsp;&nbsp; <asp:TextBox ID="ProblemNum" runat="server"></asp:TextBox>
   
    <asp:RangeValidator ID="RangeValidator1" ControlToValidate="ProblemNum" runat="server" CultureInvariantValues="false" ValidationGroup="1"  MinimumValue="0" Type="Integer" MaximumValue="1000" ErrorMessage="必须是1~1000"></asp:RangeValidator>
   
   <asp:RequiredFieldValidator
       ID="RequiredFieldValidator2" runat="server" ErrorMessage="不能为空" ValidationGroup="1" ControlToValidate="ProblemNum"></asp:RequiredFieldValidator>


</td></tr>--%>

<tr><th class="common" style="width:20%">描述：</th><td class="common"></td></tr>
<tr><td colspan="2" class="common">
    <FCKeditorV2:FCKeditor ID="FCKeditor1" Height="200px"  runat="server">
    </FCKeditorV2:FCKeditor>
    </td></tr>
    <tr><td class="common" colspan="2">&nbsp;&nbsp;<asp:Button CssClass="button" 
            ID="addPaper" runat="server" Text="确定" onclick="addPaper_Click" ValidationGroup="1" />
        &nbsp;&nbsp; </td></tr>

</table>

</asp:Content>

