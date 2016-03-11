<%@ Page Title="" Language="C#" MasterPageFile="~/Users/User.master" AutoEventWireup="true" CodeFile="UserPwdUpdate.aspx.cs" Inherits="Users_UserPwdUpdate" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table style="width: 450px; height: 200px; text-align: center;" class="infolist_vt">
        <tr>
            <th colspan="2" class="common" style="width: 80px; height: 40px;">
                密码修改</th> 
        </tr>
        <tr>
            <th style="width: 80px; height: 25px;" class="common">
                <asp:Label ID="Label2" runat="server" Text="用户名："></asp:Label>
            </th>
            <td class="common">
                &nbsp;
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <th style="width: 80px; height: 25px;" class="common">
                <asp:Label ID="Label3" runat="server" Text="原密码："></asp:Label>
            </th>
            <td class="common">
                <asp:TextBox ID="TextBox1" runat="server" style="width:165px;height:18px" 
                    TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="*" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th style="width: 80; height: 25px;" class="common">
                <asp:Label ID="Label4" runat="server" Text="新密码："></asp:Label>
            </th>
            <td class="common">
                <asp:TextBox ID="TextBox2" runat="server" style="width:165px;height:18px" 
                    Height="23px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="*" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ErrorMessage="请输入6-12位密码" ControlToValidate="TextBox2" 
                    ValidationExpression="\S{5,12}\S"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <th style="width: 80px; height: 25px;" class="common" >
                <asp:Label ID="Label5" runat="server" Text="确认密码："></asp:Label>
            </th>
            <td class="common">
                <asp:TextBox ID="TextBox3" runat="server" style="width:165px;height:18px" 
                    TextMode="Password"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ErrorMessage="密码输入不一致" ControlToCompare="TextBox2" 
                    ControlToValidate="TextBox3"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td  colspan="2" class="common" style=" height: 40px;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" Text="确认修改" Height="29px" 
                    Width="60px" onclick="Button1_Click" />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" Text="重    置" Height="29px" 
                    Width="60px" onclick="Button2_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

