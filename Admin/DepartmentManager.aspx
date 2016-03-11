<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="DepartmentManager.aspx.cs" Inherits="Admin_DepartmenManager" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:98%" cellspacing="0" cellpadding="0" class="infolist_vt">
        <tr>
            <th class="common" colspan="2"> 
                项目组管理
            </th>

        </tr>
        <tr>
            <th width="8%" class="common">
                关键字:
            </th>
            <td class="common" style="width:82%">
                &nbsp;
                <asp:TextBox ID="txtSearch" runat="server" Width="307px"></asp:TextBox>
                <asp:Button ID="btSearch" runat="server" Text="查询" OnClick="btSearch_Click1" style="height: 21px" 
                    />
                
            </td>
        </tr>
    </table>
    <br/>
    <table style="width:98%" class="infolist_hr" cellpadding="0" cellspacing="0" >
        <tr>
            <th class="caption">
                项目组列表
            </th>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" Width="98%" AutoGenerateColumns="False"
                    OnRowDeleting="GridView1_RowDeleting" BackColor="White" 
                    BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                    <RowStyle BackColor="White" ForeColor="#003399" HorizontalAlign="Center" />
                    <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ControlStyle-Width="20%" >

                    <ControlStyle Width="5%"></ControlStyle>

                            <ItemTemplate  >
                              <center>
                                <asp:CheckBox ID="chkBox" runat="server"  />
                                </center>
                            </ItemTemplate>
                            <HeaderTemplate>
                                <asp:CheckBox ID="chkBoxAll" runat="server" Text="全选" AutoPostBack="True" OnCheckedChanged="chkBoxAll_CheckedChanged" />
                            </HeaderTemplate>
                            
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ID" Visible="False">
                            <ItemTemplate>                        
                            
                                <asp:Label ID="lbID1" runat="server" Text='<%#Eval("DepartmentID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="部门名称">
                            <ItemTemplate>
                                &nbsp;<%# Eval("DepartmentName")%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="部门描述">
                            <ItemTemplate>
                                &nbsp; <%# GetSub(Eval("DepartmentDes").ToString().Trim(), 15)%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                &nbsp; <asp:Label ID="lbID2" runat="server" Text='<%#Eval("DepartmentID") %>'></asp:Label>
                            
                                 &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("DepartmentID") %>'
                                    OnCommand="LinkButton1_Command">编辑</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowDeleteButton="True" DeleteText="&lt;div onclick=&quot;return confirm('你确定要删除吗？')&quot;&gt;删除&lt;/div&gt;" />
                    </Columns>
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <EmptyDataTemplate>
                        尚未添加数据
                    </EmptyDataTemplate>
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" 
                        HorizontalAlign="Center" />
                </asp:GridView>
            </td>
        </tr>
         <tr>
            <td class="common indentten" style="height=20px">
                <center>
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged"
                        FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" PageSize="20">
                    </webdiyer:AspNetPager>
                </center>
            </td>
        </tr>
    </table>
    <table style="width:98%" cellspacing="0" cellpadding="0"  class="infolist_vt" >
        <tr>
            <th class="common" colspan="2">
                项目组管理
            </th>
        </tr>
        <tr>
            <th class="common" style="width:11%">
                项目组名称:
            </th>
            <td class="common" style="width:92%">
                &nbsp;
                <asp:TextBox ID="txtName" runat="server" Width="594px" ValidationGroup="1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                    Display="Dynamic" ErrorMessage="*" ValidationGroup="1"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" Display="Dynamic"
                    ControlToValidate="txtName" ErrorMessage="部门名称不能超过100个字" ValidationExpression="^(\s|\S){1,100}$"
                    ValidationGroup="1"></asp:RegularExpressionValidator>
            </td>
        </tr>
         <tr>
             <th class="common" style="width: 11%">
                 描述：
            </th>
            <td class="common" style="width: 92%">
                &nbsp;
                <asp:TextBox ID="txtDes" runat="server" Height="61px" TextMode="MultiLine" 
                    Width="597px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic"
                    ControlToValidate="txtDes" ErrorMessage="部门描述不能超过500个字" ValidationExpression="^(\s|\S){1,500}$"
                    ValidationGroup="1"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <th class="common" style="height:23px;widht:11%;">
                验证码:

            </th>
            <td class="common" style="width:92%;height:23px">
                &nbsp;
                <asp:TextBox ID="txtCode" runat="server" Width="113px"></asp:TextBox>
                <asp:ImageButton ID="ImageCheck" ImageUrl="~/code.aspx" runat="server" />
            </td>
        </tr>
       <tr>
            <td colspan="2" style="height:20px">
             <br />
           &nbsp;
           <asp:Button ID="btOK" runat="server" Text="提交" ValidationGroup="1" OnClick="btOK_Click1" Width="57px" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btReset" runat="server" Text="取消" Onclick="btReset_Click1"  Width="58px"/>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>

