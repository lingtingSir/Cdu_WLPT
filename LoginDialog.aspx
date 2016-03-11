<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginDialog.aspx.cs" Inherits="LoginDialog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
 <title>登录</title>
 
    
     <%--弹出窗口--%>
    <link href="Admin/css/resource.css" rel="stylesheet" type="text/css" />   
    
    <script type="text/javascript" src="Admin/js/jquery.js"></script>

    <script type="text/javascript" src="Admin/js/thickbox_plus.js"></script>

    <link rel="stylesheet" type="text/css" href="Admin/css/thickbox.css" />
    <%--弹出窗口--%>
    <%--曾沿用--%>
    <link rel="stylesheet" href="style/base/jw.css" type="text/css" media="all" />
    <link rel="stylesheet" href="style/standard/jw.css" type="text/css" media="all" />
    <style type="text/css">
        .fangshua
        {
            font-weight: bold;
            font-size: 14px;
            color: red;
        }
        .boder1
        {
            border: none;
            border-bottom-style: none;
            border-left: none;
            border-left-style: none;
        }
    </style>
    <%--曾沿用--%>
</head>
<body style="font-size: 12px;">
    <form id="form1" runat="server">
    <div class="login_right">
            <dl>
                <table>
                    <tr>
                        <td>
                            <dt class="uesr">
                                <label>
                                    用户名：</label></dt>
                        </td>
                        <td>
                            <dd>
                                <asp:TextBox ID="TxtID" runat="server" Style="margin-bottom: 0px" Width="90px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtID"
                                    ErrorMessage="*" ValidationGroup="login"></asp:RequiredFieldValidator>
                            </dd>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dt class="passw">
                                <label>
                                    密 码：</label></dt>
                        </td>
                        <td>
                            <dd>
                                <asp:TextBox ID="TxtPwd" runat="server" TextMode="Password" Width="90px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtPwd"
                                    ErrorMessage="*" ValidationGroup="login"></asp:RequiredFieldValidator>
                            </dd>
                        </td>
                    </tr>
                </table>
                <dt></dt>
                <dd>
                    <table id="RadioButtonList1" border="0">
                        <tr>
                            <td>
                                <asp:RadioButton ID="RBtnTeacher0"  runat="server" GroupName="Login" Text="发包" BorderStyle="None"
                                    BorderWidth="0px" />
                            </td>
                            <td>
                                <asp:RadioButton ID="RBtnTeacher"  Checked="true"  runat="server" GroupName="Login" Text="管理员" BorderStyle="None"
                                    BorderWidth="0px" />
                            </td>
                            <td>
                                <asp:RadioButton ID="RBtnAdmin" runat="server" Text="用户" GroupName="Login" BorderStyle="None"
                                    BorderWidth="0px" />
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                  
                </dd>
                
                <dt></dt>
                <dd>
                    
                    <asp:Button ID="BtnLogin" runat="server" CssClass="btn_dl" 
                        OnClick="BtnLogin_Click" ValidationGroup="login" />
                    <asp:Button ID="BtnReset" runat="server" CssClass="btn_cz" OnClick="BtnReset_Click" />
                </dd>
                
                <br/>
                <dd>
                    <a href='UserRegister.aspx?height=350;width=500' class="thickbox">我要注册...</a>
                </dd>    
            </dl>
        </div>
        </form>
</body>
</html>