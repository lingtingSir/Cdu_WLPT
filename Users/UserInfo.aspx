<%@ Page Title="" Language="C#" MasterPageFile="~/Users/User.master" AutoEventWireup="true" CodeFile="UserInfo.aspx.cs" Inherits="Users_UserInfo" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:60%;height:210px;text-align:center; " class="infolist_vt">
        <tr>
            <th colspan="2" class="common" style="height:35px">
                修改个人信息
            </th>
            
        </tr>
        <tr>
            <th class="common" style="height:33px"  >
                账号:

            </th>
            <td class="common" style="height:33px">
                <asp:Label ID="lblID" runat="server" Text="Label" ></asp:Label>
            </td>

        </tr>
        <tr>
            <th class="common" >
                姓名:
            </th>
            <td class="common" >
                <asp:TextBox ID="txtName" runat="server"> </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="该项不能为空"
                    ControlToValidate="txtName" Display="Dynamic" ValidationGroup="u"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" Display="Dynamic"
                    ControlToValidate="txtName" ErrorMessage="姓名不能超过100个字" ValidationExpression="^(\s|\S){1,100}$"
                    ValidationGroup="u"></asp:RegularExpressionValidator>   
            </td>
        </tr>
        <tr>
            <th class="common">
                照片:
             </th>
            <td class="common">
                <asp:Image ID="upImage" runat="server" Height="140px" Width="120px" />&nbsp;&nbsp;
                <asp:FileUpload id="upFileUpLoad" runat="server" Visible="false"  />
                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                    ControlToValidate="upFileUpLoad" ErrorMessage="文件格式不正确，必须为图片" ValidationExpression="^[a-zA-Z]:(\\.+)(.JPEG|.jpeg|.JPG|.jpg|.GIF|.gif|.BMP|.bmp|.PNG|.png)$"
                    ValidationGroup="u"></asp:RegularExpressionValidator>
            </td>
        </tr>
        
        <tr>
            <th class="common">


            </th>
            <td class="common">
                (是否重传？<asp:LinkButton ID="IsOK" runat="server" OnClick="IsOK_Click">重传</asp:LinkButton>
                )<asp:Label ID="lbImage" runat="server" Text="Label" Visible="false"></asp:Label>

            </td>

         </tr>
        <tr>
            <th class="common">

                备注:
            </th>
            <td align="left">

                <FCKeditorV2:FCKeditor ID="txtUserDes" runat="server" Height="230px" HtmlEncodeOutput="false"  Width="80%">
                    </FCKeditorV2:FCKeditor>
            </td>
        </tr>
        <tr>
            <th class="common">

            </th>
            <td class="common">
                <asp:Button ID="btOK" CssClass="button" runat="server" Text="修改" ValidationGroup="u" OnClick="btOK_Click1" />
                &nbsp;
                <asp:Button ID="btCancel" CssClass="button"  runat="server" Text="取 消" OnClick="btCancel_Click"  />
            </td>
        </tr>
        </table>
    </asp:Content>

