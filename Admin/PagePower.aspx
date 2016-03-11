<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="PagePower.aspx.cs" Inherits="PagePower" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellspacing="0" cellpadding="0" class="infolist_vt" style="width:92%">
        <tr> 
            <th colspan="2" class="caption">
                管理员权限管理
            </th>
        </tr>
        <tr>
            <th class="common" style="width:18%">
                部 门;
            </th>
            <td class="common" style="width:82%">
                &nbsp;
                <asp:DropDownList ID="dropDepartment" runat="server" AutoPostBack="True" Height="22px" 
                    width="135px" OnSelectedIndexChanged="dropDepartment_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <th class="common" style="height:25px">
                角 色：
            </th>
            <td class="common" style="width:82%;height:25px;">
                &nbsp;
                <asp:DropDownList ID="dropPower" runat="server" Height="22px" Width="135px"  AutoPostBack="True"
                    OnSelectedIndexChanged="dropPower_SelectedIndexChanged">

                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <th class="common" style="height:25px">
                搜索方式:
            </th>
            <td class="common" style="width:82%; height:25px">
                &nbsp;
                <asp:DropDownList ID="dropSearch" runat="server" Height="22px" Width="135px">
                    <asp:ListItem Value="按管理员号搜索">按管理员号搜索</asp:ListItem>
                    <asp:ListItem>按姓名搜索</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <th class="common" style="height:25px">
                关键字:
            </th>
            <td class="common">
                &nbsp;
                <asp:TextBox ID="txtSearch" runat="server" Width="130px"></asp:TextBox>
                <asp:Button  ID="btSearch" runat="server"  Text="查询" OnClick="btSearch_Click1" />
            </td>
        </tr>
     </table>
    <table style="width:92%" class="infolist_ht" cellpadding="0" cellspacing="0">
        <tr>
            <td class="common">
                  <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                   >
                    <Columns>
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
                            <asp:TemplateField HeaderText="权限分配">
                                <itemtemplate>
                                <a href='PagePowerManager.aspx?id=<%# Eval("ManagerID") %>' style="color: Red;" >
                                    <b>
                                        <%#  Container.DataItemIndex+1%></b> 权限分配</a>
                            </itemtemplate>
                                <itemstyle width="10%" />
                            </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        尚未添加管理员数据
                    </EmptyDataTemplate>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="common indentten">
                <center>
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged"
                        FirstPageText="首页" LastPageText="尾页" NextPageText="下一页"　PrevPageText="上一页" PageSize="20">


                    </webdiyer:AspNetPager>
                </center>
            </td>
        </tr>
    </table>
</asp:Content>

