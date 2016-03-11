<%@ Page Title="" Language="C#" MasterPageFile="~/Users/User.master" AutoEventWireup="true" CodeFile="UpdatePwd.aspx.cs" Inherits="Users_UpdatePwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 450px; height: 200px; text-align: center;"  class="infolist_vt">
        <tr>
            <th colspan="2" class="common" style="width: 80px; height: 30px;">
                修改密码
            </th>
        </tr>
        <tr>
            <th class="common" style="width: 80px; height: 20px;">
                旧密码：
            </th>
            <td class="common">
                <asp:TextBox ID="TextBox1" runat="server" TextMode="Password" Width="199px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th class="common" style="width: 80px; height: 20px;">
                新密码：
            </th>
            <td class="common">
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" Width="199px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                    ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th class="common" style="width: 80px; height: 20px;">
                确认密码：
            </th>
            <td class="common">
                <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" Width="199px"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox2"
                    ControlToValidate="TextBox3" Display="Dynamic" ErrorMessage="*密码一致"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <th class="common" style="width: 80px; height: 20px;">
            </th>
            <td class="common">
                <asp:Button ID="ibOK" CssClass="button" runat="server" Text="修改密码" OnClick="ibOK_Click" />
            </td>
        </tr>
    </table>
</asp:Content>


