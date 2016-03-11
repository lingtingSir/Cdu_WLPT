<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProjectPaperRecordWrong.aspx.cs" Inherits="Users_ProjectPaperRecordWrong" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../Users/css/base.css" rel="stylesheet" type="text/css" />
    <link href="../Users/css/resource.css" rel="stylesheet" type="text/css" />
    

     <script  type="text/javascript" src="../My97DatePicker/WdatePicker.js" ></script> 
    <link href="Css/sms.Css" rel="stylesheet" type="text/css" media="screen" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table cellspacing="0" cellpadding="0" class="infolist_vt">
            <tbody>
                <tr>
                    <th colspan="2" class="caption">
                        编辑简介 <asp:Label ID="Des" runat="server"   Text=""></asp:Label>
                    </th>
                </tr>
                <tr>
                    <td colspan="2" class="common right">
                        <asp:Button ID="Button1" runat="server" Text="修改" CssClass="button" onclick="Button1_Click"　style="text-align:right;" OnClientClick="history.go(-2)" />
                        <br />
                    </td>
                </tr>
               <tr><th class="common">会议时间：</th><td class="common">
           &nbsp;&nbsp; 
                    

            <asp:TextBox ID="TextBox1" runat="server" CssClass="ipt" onClick="WdatePicker()"></asp:TextBox>
        </td>

        </tr>
                <tr>
                    <th class="common" nowrap>
                        内容编辑<span class="style1"> * </span>
                    </th>
                    <td class="common" style="width: 82%">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="common">
                        <div>
                            
                            <FCKeditorV2:FCKeditor ID="txtDes" runat="server" HtmlEncodeOutput="false" > 
                            </FCKeditorV2:FCKeditor>
                           
                        </div>
                    </td>
                </tr>
                </table>
    </div>
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
    </form>
</body>
</html>

