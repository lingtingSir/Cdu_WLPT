<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdatePageDes.aspx.cs" Inherits="Admin_UpdatePageDes" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Page编辑</title>
    
    <link href="css/resource.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellspacing="0" cellpadding="0" class="infolist_vt">
            <tbody>
                <tr>
                    <th colspan="2" class="caption">
                        编辑简介
                    </th>
                </tr>
                <tr>
                    <td colspan="2" class="common right">
                        <asp:Button ID="Button1" runat="server" Text="确定" OnClick="Button1_Click" />

                    </td>
                </tr>
                <tr>
                    <th class="common">
                        内容编辑<span style="color:red">*</span>
                    </th>
                    <td class="common" style="width:82%">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="common">
                        <div>
                            <FCKeditorV2:FCKeditor id="txtDes" runat="server" Height="200px" Width="100%" HtmlEncodeOutput="false"> 

                            </FCKeditorV2:FCKeditor>
                            <asp:Label ID="lbParent" runat="server" Visible="false" Text="label">

                            </asp:Label>
                        </div>
                    </td>
                </tr>
            </tbody>

        </table>
    </div>
    </form>
</body>
</html>
