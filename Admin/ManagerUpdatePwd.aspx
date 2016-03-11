<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ManagerUpdatePwd.aspx.cs" Inherits="Admin_UpdatePwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%" class="infolist_vt" cellspdding="0" cellspacing="0">
        <tr>
            <th colspan="2" class="caption">
                修改密码
            </th>
        </tr>
        <tr>
            <th class="common" align="right" width="18%">
                旧密码:
            </th>
            <td align="left" style="width:82%" class="common">
                <asp:TextBox ID="TextBox1" runat="server" TextMode="Password" Width="199px">

                </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th align="right" class="common">
                新密码:
            </th>
            <td align="left" class="common" >
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" Width="199px" >

                </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequierFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th align="right" class="common">
                新密码:
            </th>
            <td align="left" class="Common">
                <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" Width="199px">

                </asp:TextBox>
                <asp:CompareValidator ID="CompareValidator" runat="server" ControlToCompare="TextBox2" ControlToValidate="TextBox3" Display="Dynamic" ErrorMessage="*密码一致"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="common">
                <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button_Click1" />
                <asp:Label ID="Label1" runat="server" Text="Label" Visible="false" ></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

