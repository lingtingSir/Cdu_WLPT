<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ManagerUpdateDes.aspx.cs" Inherits="Admin_ManagerUpdateDes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" >
        function PictureShow() {
            document.getElementById("ctl00_ContentPlaceHolder1_upImage").src = document.getElementById("ctl00$ContentPlaceHolder1$upFileUpLoad").value;
        }

</script>
    <table style="width:100%" class="infolist_vt" cellspacing="0" cellpadding="0">
        <tr>
            <th class="caption" colspan="2">
                修改管理员信息
            </th>
            
        </tr>
        <tr>
            <th align="right" class="common" style="width:18%">
                学&nbsp;&nbsp;&nbsp;号
            </th>
                <td align="left" class="common">
                    <asp:Label runat="server" ID="lbID"></asp:Label>
                </td>
            
        </tr>
        <tr>
            <th align="right" style="width:18%" class="common">
                姓&nbsp;&nbsp;&nbsp;名:
            </th>
            <td align="left" class="common">
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="该项不能为空"
                    ControlToValidate="txtName" Display="Dynamic" ValidationGroup="u"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" Display="Dynamic"
                    ControlToValidate="txtName" ErrorMessage="姓名不能超过100个字" ValidationExpression="^(\s|\S){1,100}$"
                    ValidationGroup="u"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <th align="right" style="width: 18%" class="common">
                部&nbsp;&nbsp; 门：
            </th>
            <td align="left" class="common">
                <asp:Label ID="lbDepartmentName" runat="server" Text="Label"></asp:Label><asp:Label
                    ID="lbDepartmentID" runat="server" Text="Label" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <th align="right" style="width: 18%" class="common">
                角&nbsp;&nbsp; 色：
            </th>
            <td align="left" class="common">
                <asp:Label ID="lbPowerName" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="lbPowerID" runat="server" Text="Label" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <th align="right" style="width:18%" class="common">
                照&nbsp;&nbsp;片:
            </th>
            <td align="left" class="common">
                <asp:Image ID="upImage" runat="server" Height="140px" Width="120px" />
                &nbsp;&nbsp;
                <asp:FileUpload
                    ID="upFileUpLoad" runat="server" Visible="false" onchange="PictureShow();" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                    ControlToValidate="upFileUpLoad" ErrorMessage="文件格式不正确，必须为图片" ValidationExpression="^[a-zA-Z]:(\\.+)(.JPEG|.jpeg|.JPG|.jpg|.GIF|.gif|.BMP|.bmp|.PNG|.png)$"
                    ValidationGroup="u"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <th align="right" style="width:18%" class="common">

            </th>
           <td align="left" class="common">
                (是否重传？<asp:LinkButton ID="IsOK" runat="server" OnClick="IsOK_Click">重传</asp:LinkButton>
                )<asp:Label ID="lbImage" runat="server" Text="Label" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <th align="right" style="width: 18%"class="common">
                备&nbsp;&nbsp; 注：
            </th>
            <td align="left" class="common">
                <asp:TextBox ID="txtDes" runat="server" Height="63px" TextMode="MultiLine" Width="320px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic"
                    ControlToValidate="txtDes" ErrorMessage="描述不能超过500个字" ValidationExpression="^(\s|\S){1,500}$"
                    ValidationGroup="u"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="common">
                <asp:Button ID="btOK" runat="server" Text="修  改" onclick="btOK_Click1" style="height: 21px" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btCancel" runat="server" Text="取  消" onclick="btCancel_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

