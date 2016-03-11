<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login_1.aspx.cs" Inherits="Login_1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>梦工厂网络平台</title>
    <meta name="Title" content="梦工厂" />
    <meta name="Description" content="" />
    <meta name="Keywords" content="梦工厂" />    

 <script src="js/Ajax.js" type="text/javascript"></script>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/Drag.js" type="text/javascript"></script>


     <%--弹出窗口--%>
    <link href="Admin/css/resource.css" rel="stylesheet" type="text/css" />   
    <link href="" rel="stylesheet" type="text/css" />   
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




   
     <script type="text/javascript">


         window.onload = function () {
             Drag.init(document.getElementById("handle"), document.getElementById("mLogindialog"));//拖动的是handle2 移动的是dragBody2 但是hanlde2又在dragBody2之内
         }


    </script>

    

</head>
<body style="font-size: 12px; margin: 0px; overflow-x: hidden; overflow-y: hidden"

    scroll="no">
    <form id="form1" runat="server">
    <center>
        <img src="/images/index2.png" style="width: 100%; height: 100%; margin: 0px; padding: 0px;" />
        <div style="text-align: center; vertical-align:middle;" class="login_right">
            <div id="mLogindialog" style="background-image: url('/images/login_right.jpg'); height: 320px;
                width: 450px; position: absolute; top: 168px; left: 485px; display:none;">
                <div id="handle" style="width:100%;height:30px;"></div>
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
                                <asp:RadioButton ID="RBtnContact"  runat="server" GroupName="Login" Text="发包" BorderStyle="None"
                                    BorderWidth="0px" />
                            </td>
                            <td>
                                <asp:RadioButton ID="RBtnManager"  Checked="true"  runat="server" GroupName="Login" Text="管理员" BorderStyle="None"
                                    BorderWidth="0px" />
                            </td>
                            <td>
                                <asp:RadioButton ID="RBtnUser" runat="server" Text="用户" GroupName="Login" BorderStyle="None"
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
        </div>
    </center>

    <script src="/js/PublicJS.js" type="text/javascript"></script>

    <script type="text/javascript">
        $("#mLogindialog").show();
    </script>
        </form>
</body></html> 