<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="UserHoliday.aspx.cs" Inherits="Admin_UserHoliday" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <table cellspacing="0" cellpadding="0" class="infolist_vt" style="width: 92%">
                <tr>
                    <th colspan="2" class="caption">
                        用户请假管理
                    </th>
                </tr>
                <tr>
                    <th class="common" style="width: 18%">
                        搜索方式：
                    </th>
                    <td style="width: 82%" class="common">
                        <asp:DropDownList ID="dropSearch" runat="server" Width="200px">
                            <asp:ListItem Value="1">按编号搜索</asp:ListItem>
                            <asp:ListItem Value="2">按姓名搜索</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                    <tr>
                    <th class="common">
                        关键字：
                        </th>
                        <td class="common">
                        <asp:TextBox ID="txtSearch" runat="server" Width="195px"></asp:TextBox>
                        &nbsp;<asp:Button ID="btSearch" runat="server" Text="查询" OnClick="btSearch_Click1" Width="57px" />
                    </td>
                </tr>
            </table>
            <br>
            <table cellpadding="0" cellspacing="0" class="infolist_hr" style="width: 92%">
                <tr>
                    <th class="caption">
                        用户请假列表
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="编号">
                                    <ItemTemplate>
                                        <center>
                                            <asp:Label ID="lbID" runat="server" Text='<%#Eval("UserID") %>'></asp:Label>
                                        </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="姓名">
                                    <ItemTemplate>
                                        <%#Eval("UserName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                
                                <asp:TemplateField HeaderText="查看详情">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbDetail" runat="server" CommandArgument='<%# Eval("UserID") %>'
                                            OnCommand="lbDetail_Command">查看详情</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="common">
                       <center>
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页"
                            NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged" PageSize="20" PrevPageText="上一页"
                            Style="text-align: center">
                        </webdiyer:AspNetPager>
                      </center>
                    </td>
                </tr>          
            </table>
            <%--
        </ContentTemplate>
    </asp:UpdatePanel>--%>

</asp:Content>


