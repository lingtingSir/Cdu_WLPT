<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="UserManager.aspx.cs" Inherits="Admin_UserManager" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
               <br />
            <table cellspacing="0" cellpadding="0" class="infolist_vt">
                <tr>
                    <th colspan="2" class="caption">
                        条件搜索
                    </th>
                </tr>
                <tr>
                    <th width="18%" class="common">
                        搜索方式：
                    </th>
                    <td class="common" style="width: 82%">
                        &nbsp;
                        <asp:DropDownList ID="dropSearch" runat="server" Width="136px">
                            <asp:ListItem Value="1">按账号搜索</asp:ListItem>
                            <asp:ListItem Value="2">按姓名搜索</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <th class="common" style="height: 25px">
                        关键字：
                    </th>
                    <td class="common" style="width: 82%; height: 25px;">
                        &nbsp;
                        <asp:TextBox ID="txtSearch" runat="server" Width="135px"></asp:TextBox>
                        <asp:Button ID="btSearch" runat="server" Text="搜 索" OnClick="btSearch_Click1" />
                    </td>
                </tr>
            </table>
            <br />
            <table style="width: 96%" class="infolist_hr" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="common">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                            OnRowDeleting="GridView1_RowDeleting">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <center>
                                            <asp:CheckBox ID="chkBox" runat="server" />
                                        </center>
                                    </ItemTemplate>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkBoxAll" runat="server" Text="全选" OnCheckedChanged="chkBoxAll_CheckedChanged"
                                            AutoPostBack="True" />
                                    </HeaderTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="账号">
                                    <ItemTemplate>
                                        <asp:Label ID="lbID" runat="server" Text='<%#Eval("UserID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="项目组">
                                    <ItemTemplate>
                                        <%#Eval("DepartmentName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="姓名">
                                    <ItemTemplate>
                                        <%#Eval("UserName")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="注册日期">
                                    <ItemTemplate>
                                        <%#Eval("RegisterDate")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="过期日期">
                                    <ItemTemplate>
                                        <%#Eval("OverDate")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="修改密码">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("UserID") %>'
                                            OnCommand="LinkButton2_Command">修改密码</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="续期">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%# Eval("UserID") %>'
                                            OnCommand="LinkButton3_Command">续期</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowDeleteButton="True" DeleteText="&lt;div id=&quot;aaa&quot; onclick=&quot;return confirm('你确定要删除吗？')&quot;&gt;删除&lt;/div&gt;" />
                            </Columns>
                            <EmptyDataTemplate>
                                尚未添加学生数据
                            </EmptyDataTemplate>
                        </asp:GridView>
                        &nbsp;
                        <asp:Button ID="btDelete" runat="server" Text="批量删除" OnClientClick="return confirm('你确定要删除吗?')"
                            OnClick="btDelete_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="common indentten">
                        <center>
                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged"
                                FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" PageSize="20">
                            </webdiyer:AspNetPager>
                        </center>
                </tr>
               
            </table>
                <br />
               <table id="add" runat="server" cellpadding="0" cellspacing="0" class="infolist_vt">
                   <tr>
                       <th class="caption" colspan="2">添加用户 </th>
                   </tr>
                   <tr>
                       <td class="common right" colspan="2">
                           <asp:Button ID="Button3" runat="server" CssClass="button" onclick="Button3_Click" Text="确 定" />
                           &nbsp;<asp:Button ID="Button4" runat="server" CssClass="button" onclick="Button4_Click" Text="取 消" />
                       </td>
                   </tr>
                   <tr>
                       <th class="common" width="18%">用户名: </th>
                       <td class="common">&nbsp;
                           <asp:TextBox ID="txtUserName" runat="server" Style="width: 200px;"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <th class="common">用户ID: </th>
                       <td class="common">&nbsp;
                           <asp:TextBox ID="txtUserID" runat="server" Style="width: 200px;"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <th class="common">项目组(部门)</th>
                        <td class="common" style="width: 82%">
                        &nbsp;
                        <asp:DropDownList ID="OkDepartment" runat="server" AutoPostBack="True" Width="200px" OnSelectedIndexChanged="OkDepartment_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                   </tr>
                   <tr>
                       <th class="common">设置密码:</th>
                       <td class="common">&nbsp;
                           <asp:TextBox ID="txtUserPwd" runat="server" Style="width: 200px;" TextMode="Password"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <th class="common">确认密码:<span class="style1"> &nbsp; </span></th>
                       <td class="common">&nbsp;
                           <asp:TextBox ID="txtConfirmUserPwd" runat="server" Style="width: 200px;" TextMode="Password"></asp:TextBox>
                           <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtUserPwd" ControlToValidate="txtConfirmUserPwd" ErrorMessage="密码错误"></asp:CompareValidator>
                       </td>
                   </tr>
                   <tr>
                       <th class="common">用户描述： </th>
                       <td class="common">&nbsp;
                           <asp:TextBox ID="txtUserDes" runat="server" Height="50px" Style="width: 200px;"></asp:TextBox>
                           
                       </td>
                   </tr>
               </table>
             <br />





            <table cellspacing="0" id="ChangePwd" runat="server" cellpadding="0" class="infolist_vt" visible="false">
                <tr>
                    <th colspan="2" class="caption">
                        修改密码
                    </th>
                </tr>
                <tr>
                    <th width="18%" class="common">
                        请输入新密码：
                    </th>
                    <td class="common" style="width: 82%">
                        &nbsp;
                        <asp:TextBox ID="txtPwd" runat="server" Width="188px" ValidationGroup="2"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPwd"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="2"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Display="Dynamic"
                            ControlToValidate="txtPwd" ErrorMessage="密码不能超过50个字" ValidationExpression="^(\s|\S){1,50}$"
                            ValidationGroup="1"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="common" colspan="2">
                        <asp:Button ID="upPwd" runat="server"   Text="修 改" OnClick="upPwd_Click" />
                        &nbsp;&nbsp;
                        <asp:Button ID="upCancel" runat="server" Text="取 消" OnClick="upCancel_Click1" />
                    </td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="0" class="infolist_vt" runat="server" id="Renewal" visible="false">
                <tr>
                    <th colspan="2" class="caption">
                        用户续期
                    </th>
                </tr>
                <tr>
                    <th width="18%" class="common">
                        选择期限：
                    </th>
                    <td class="common" style="width: 82%">
                        &nbsp;
                        <asp:DropDownList ID="DropDay" runat="server" Width="136px">
                            <asp:ListItem Value="5">5天</asp:ListItem>
                            <asp:ListItem Value="10">10天</asp:ListItem>
                            <asp:ListItem Value="15">15天</asp:ListItem>
                            <asp:ListItem Value="20">20天</asp:ListItem>
                            <asp:ListItem Value="25">25天</asp:ListItem>
                            <asp:ListItem Value="30">30天</asp:ListItem>
                            <asp:ListItem Value="35">35天</asp:ListItem>
                            <asp:ListItem Value="40">40天</asp:ListItem>
                            <asp:ListItem Value="45">45天</asp:ListItem>
                            <asp:ListItem Value="60">60天</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    </tr>
                    <tr>
                        <td class="common" colspan="2">
                            <asp:Button ID="RenewalUp" runat="server" Text="提 交" OnClick="RenewalUp_Click" />
                            &nbsp;&nbsp;
                            <asp:Button ID="RenewalCancel" runat="server" Text="取 消" OnClick="RenewalCancel_Click" />
                        </td>
                    </tr>
            </table>
            </ContentTemplate>

        </asp:UpdatePanel>
</asp:Content>

