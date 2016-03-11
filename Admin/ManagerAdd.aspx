<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ManagerAdd.aspx.cs" Inherits="Admin_ManagerAdd" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
        <ContentTemplate>
            <table cellspacing="0" cellpadding="0" class="infolist_vt" style="width:92%">
                <tr>
                    <th colspan="2" class="caption">
                       管理员管理
                    </th>
                </tr>
                <tr>
                    <th width="18%" class="common">
                        &nbsp;&nbsp;&nbsp;&nbsp;部&nbsp;&nbsp;&nbsp; 门</th>
                    <td class="common" style="width: 82%">
                        <asp:DropDownList ID="dropDepartment" runat="server" AutoPostBack="True"
                            Width="140px" OnSelectedIndexChanged="dropDepartment_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <th class="common" style="height: 25px">
                        &nbsp;&nbsp;&nbsp;&nbsp;角&nbsp;&nbsp;&nbsp; 色</th>
                    <td class="common" style="width: 82%;">
                        <asp:DropDownList ID="dropPower" runat="server" Height="25px" Width="140px" OnSelectedIndexChanged="dropPower_SelectedIndexChanged"
                            AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <th class="common">
                        <p>
                            &nbsp;&nbsp;&nbsp;&nbsp;搜索方式</p>
                    </th>
                    <td class="common" style="width: 82%">
                        <asp:DropDownList ID="dropSearch" runat="server" Width="140px">
                            <asp:ListItem Value="按管理员号搜索">按管理员号搜索</asp:ListItem>
                            <asp:ListItem>按姓名搜索</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <tr>
                        <th width="18%" class="common">
                            &nbsp;&nbsp;&nbsp;&nbsp;关键字
                        </th>
                        <td class="common" style="width: 82%">
                            <asp:TextBox ID="txtSearch" runat="server" Width="140px"></asp:TextBox>
                            &nbsp;<asp:Button ID="btSearch" CssClass="button" runat="server" Text="搜 索" OnClick="btSearch_Click1" />
                        </td>
                    </tr>
                    
            </table>
            <br />
            <table style="width:92%" class="infolist_hr" >
                <tr>
                    <td class="common">
                        <table style="width: 92%" class="infolist_hr" cellpadding="0" cellspacing="0">
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
                                     <ItemStyle Width="8%" />
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkBoxAll" runat="server" Text="全选" OnCheckedChanged="chkBoxAll_CheckedChanged"
                                            AutoPostBack="True" />
                                    </HeaderTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="管理员号">
                                    <ItemTemplate>
                                        <asp:Label ID="lbID" runat="server" Text='<%#Eval("ManagerID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="姓名">
                                    <ItemTemplate>
                                        <%#Eval("ManagerName")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="部门">
                                    <ItemTemplate>
                                        <%#Eval("DepartmentName")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="角色">
                                    <ItemTemplate>
                                        <%#Eval("PowerName")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="编辑/查看备注">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("ManagerID") %>'
                                            OnCommand="LinkButton1_Command">编辑/查看备注</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="修改密码">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("ManagerID") %>'
                                            OnCommand="LinkButton2_Command">修改密码</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowDeleteButton="True" HeaderText="操作" DeleteText="&lt;div id=&quot;aaa&quot; onclick=&quot;return confirm('你确定要删除吗？')&quot;&gt;删除&lt;/div&gt;" />
                            </Columns>
                            <EmptyDataTemplate>
                                尚未添加管理严数据
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="common indentten">
                        <asp:Button ID="btDelete" runat="server" CssClass="button" Text="批量删除" OnClientClick="return confirm('管理员是基础数据，您确定要删除?')"
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
                    </td>
                </tr>
            </table>
            <br />
            <table cellspacing="0" cellpadding="0" class="infolist_vt" style="width: 92%" id="add"
                runat="server">
                <tr>
                    <th colspan="2" class="caption">
                        管理员添加&nbsp;
                    </th>
                </tr>
                <tr>
                    <td class="common right" style="width: 82%" colspan="2">
                        <asp:Button ID="btOk" CssClass="button" runat="server" Text="提 交" ValidationGroup="1" OnClick="btOk_Click1" />
                        &nbsp;
                        <asp:Button ID="btReset" CssClass="button" runat="server" Text="重 置" OnClick="btReset_Click1" />
                    </td>
                </tr>
                <tr>
                    <th width="18%" class="common">
                        部&nbsp;&nbsp; 门:
                    </th>
                    <td class="common" style="width: 82%">
                        &nbsp;
                        <asp:DropDownList ID="OkDepartment" runat="server" AutoPostBack="True" Width="162px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <th class="common" style="height: 25px">
                        角&nbsp;&nbsp; 色:
                    </th>
                    <td class="common" style="width: 82%; height: 25px;">
                        &nbsp;
                        <asp:DropDownList ID="OkPower" runat="server" Width="162px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <th class="common" style="height: 25px">
                        管理员号:</th>
                    <td class="common" style="width: 82%; height: 25px;">
                        &nbsp;
                        <asp:TextBox ID="OkID" runat="server" Width="160px" ValidationGroup="1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                            ControlToValidate="OkID" Display="Dynamic" ValidationGroup="1"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" Display="Dynamic"
                            ControlToValidate="OkID" ErrorMessage="管理员号不能超过50个字" ValidationExpression="^(\s|\S){1,50}$"
                            ValidationGroup="1"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <th class="common" style="height: 25px">
                        姓&nbsp;&nbsp; 名:</th>
                    <td class="common" style="width: 82%; height: 25px;">
                        &nbsp;
                        <asp:TextBox ID="OkName" runat="server" Width="160px" ValidationGroup="1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                            ControlToValidate="OkName" Display="Dynamic" ValidationGroup="1"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic"
                            ControlToValidate="OkName" ErrorMessage="姓名不能超过100个字" ValidationExpression="^(\s|\S){1,100}$"
                            ValidationGroup="1"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <th class="common" style="height: 25px">
                        验证码:</th>
                    <td class="common" style="width: 82%; height: 25px;">
                        &nbsp;
                        <asp:TextBox ID="txtCode" runat="server" Width="90px"></asp:TextBox>
                        <asp:ImageButton ID="ImageCheck" ImageUrl="../Code.aspx" runat="server" />
                    </td>
                </tr>
            </table>
            <br />
            <table cellspacing="0" cellpadding="0" class="infolist_vt" style="width: 92%" id="edit"
                runat="server" visible="false">
                <tbody>
                    <tr>
                        <th colspan="2" class="caption">
                            管理员信息
                        </th>
                    </tr>
                    <tr>
                        <td class="common right" style="width: 82%" colspan="2">
                            <asp:Button ID="btUp" CssClass="button" runat="server" Text="修 改" OnClick="btUp_Click1" />
                            &nbsp;
                            <asp:Button ID="btCancel"  CssClass="button" runat="server" Text="取 消" OnClick="btReset_Click1" />
                        </td>
                    </tr>
                    <tr>
                        <th width="18%" class="common" style="height: 25px">
                            部&nbsp;&nbsp; 门：
                        </th>
                        <td class="common" style="width: 82%; height: 25px;">
                            &nbsp;
                            <asp:DropDownList ID="upDepartment" runat="server" Width="131px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th class="common">
                            权&nbsp;&nbsp; 限：
                        </th>
                        <td class="common" style="width: 82%">
                            &nbsp;
                            <asp:DropDownList ID="upPower" runat="server" Width="131px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th class="common">
                            账&nbsp;&nbsp; 号：<span class="style1">  </span>
                        </th>
                        <td class="common" style="width: 82%">
                            &nbsp;
                            <asp:Label ID="upID" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th class="common" nowrap>
                            　　　姓&nbsp;&nbsp; 名：<span class="style1"> &nbsp; </span>
                        </th>
                        <td class="common" style="width: 82%">
                            &nbsp;
                            <asp:TextBox ID="upName" runat="server" Width="126px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="该项不能为空"
                                ControlToValidate="upName" Display="Dynamic" ValidationGroup="2"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic"
                                ControlToValidate="upName" ErrorMessage="姓名不能超过100个字" ValidationExpression="^(\s|\S){1,100}$"
                                ValidationGroup="2"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th class="common">
                        </th>
                        <td class="common" style="width: 82%">
                            &nbsp;
                            <asp:TextBox ID="upDes" runat="server" Height="62px" TextMode="MultiLine" Visible="false"
                                Width="217px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th class="common">
                            验证码：
                        </th>
                        <td class="common" style="width: 82%">
                            &nbsp;
                            <asp:TextBox ID="TextBox1" runat="server" Width="64px"></asp:TextBox>
                            <asp:ImageButton ID="ImageButton1" ImageUrl="../Code.aspx" runat="server" />
                        </td>
                    </tr>
            </table><br />
            <table cellspacing="0" cellpadding="0" class="infolist_vt" id="ChangePwd" runat="server"
                style="width: 92%" visible="false">
                <tr>
                    <th colspan="2" class="caption">
                        修改密码
                    </th>
                </tr>
                <tr>
                    <td class="common right" style="width: 82%" colspan="2">
                        &nbsp;
                        <asp:Button ID="upPwd" CssClass="button" runat="server" Text="修 改" ValidationGroup="3" OnClick="upPwd_Click1" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="upCancel" CssClass="button"  runat="server" Text="取 消" OnClick="upCancel_Click1" />
                    </td>
                </tr>
                <tr>
                    <th width="18%" class="common">
                        请输入新密码：
                    </th>
                    <td class="common" style="width: 82%">
                        &nbsp;
                        <asp:TextBox ID="txtPwd" runat="server" Width="188px" ValidationGroup="3" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPwd"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="3"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Display="Dynamic"
                            ControlToValidate="txtPwd" ErrorMessage="密码不能超过100个字" ValidationExpression="^(\s|\S){1,100}$"
                            ValidationGroup="3"></asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
        </ContentTemplate>



    </asp:UpdatePanel>
</asp:Content>

