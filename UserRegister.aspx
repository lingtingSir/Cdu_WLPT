<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserRegister.aspx.cs" Inherits="UserRegister" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>注册</title>
    <link href="Admin/css/resource.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
   <%-- <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <table  style="text-align: center;" class="infolist_vt">
        <tr>
            <th colspan="2" class="common">
                <h3>注册</h3>
            <hr align="left"   style="color: Green;width: 100%;height: 3px;"/></th> 
        </tr>
        <tr>
            <th style="width: 80px; height: 25px;" class="common">
                用户名：
            </th>
            <td class="common">
                <asp:TextBox ID="txtUserName" runat="server" Style="width: 200px;" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                
            </td>
        </tr>
        <tr>
            <th class="common">
                姓名：
            </th>
            <td class="common">
                <asp:TextBox ID="txtUserID" runat="server" Style="width: 200px;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtUserID"></asp:RequiredFieldValidator>
                    <%--<asp:Label ID="lbIfOn" runat="server" ForeColor="Red" Text="该用户已存在" Visible="false"></asp:Label>--%>
               <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate></ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
        </tr>
        <tr  >
            <th class="common">
                设置密码：
            </th>
            <td class="common">
                <asp:TextBox ID="txtUserPwd" TextMode="Password" runat="server" Style="width: 200px;"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtUserPwd"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <br />
        <tr>
            <th class="common">
                确认密码：
            </th>
            <td class="common">
                <asp:TextBox ID="txtConfirmUserPwd" TextMode="Password" runat="server" Style="width: 200px;"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="密码错误"
                    ControlToCompare="txtUserPwd" ControlToValidate="txtConfirmUserPwd"></asp:CompareValidator>
            </td>
        </tr>
        
        <tr>
            <th class="common">
                用户描述：
            </th>
            <td class="common">
                <asp:TextBox ID="txtUserDes" runat="server" Style="width: 200px;" Height="50px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th class="common">
            </th>
            <td class="common">
                <asp:Button ID="btRegister" runat="server" CssClass="button" Text="注册" 
                    Width="60px" OnClick="btRegister_Click1"   />
                &nbsp;&nbsp;
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

