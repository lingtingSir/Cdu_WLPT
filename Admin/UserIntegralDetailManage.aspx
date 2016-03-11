<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="UserIntegralDetailManage.aspx.cs" Inherits="Admin_UserIntegralDetailManage" %>


<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="view1" runat="server">
            <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <table cellspacing="0" cellpadding="0" class="infolist_vt" style="width: 92%">
                <tr>
                    <th colspan="4" class="caption" style="height: 22px">
                        积分审核管理
                    </th>
                </tr>
                <tr>
                    <th class="common" style="width: 15%">
                        用户姓名：
                    </th>
                    <td style="width: 35%" class="common">
                        <asp:Label ID="lblUserName" runat="server"></asp:Label>
                    </td>
                    <th class="common" style="width: 15%;">
                        积分数量：
                    </th>
                    <td style="width: 35%;" class="common">
                        <asp:Label ID="lblIntegral" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <table cellpadding="0" cellspacing="0" class="infolist_hr" style="width: 92%">
                <tr>
                    <th class="caption">
                        待审事项列表
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:DataList ID="DataList1" runat="server" Width="100%">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" class="infolist_vt" style="width: 100%">
                                    <tr>
                                        <th style="width: 18%" class="common" align="right">
                                            编号：
                                        </th>
                                        <td class="common" style="width: 82%">
                                            &nbsp;
                                            <asp:Label ID="lblUserID" runat="server" Text='<%#Eval("RewardProblemID") %>'></asp:Label>
                                          </td>
                                    </tr>
                                    <tr>
                                        <th class="common" style="width: 18%" align="right">
                                            上报用户：
                                        </th>
                                        <td class="common" style="width: 82%">
                                            &nbsp;
                                            <asp:Label ID="lblUserName" runat="server" Text='<%#Eval("UserID") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="common" style="width: 18%" align="right">
                                            描述：
                                        </th>
                                        <td class="common" style="width: 82%;">
                                            &nbsp;
                                            <asp:Label ID="lblUserDes" runat="server" Text='<%#Eval("Des") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="common" style="width: 18%" align="right">
                                            上报时间：
                                        </th>
                                        <td class="common">
                                            &nbsp;
                                            <asp:Label ID="lblDateUp" runat="server" Text='<%#Eval("DateUp") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                      <td class="common" colspan="2" style="padding-left:30%">
                                          <asp:Button ID="Button1" runat="server" Text="认同加分" CommandArgument='<%#Eval("RewardProblemID") %>' 
                                              oncommand="Button1_Command" />
                                          <asp:Button ID="Button2" runat="server" Text="不认同加分" CommandArgument='<%#Eval("RewardProblemID") %>' 
                                              oncommand="Button2_Command" />
                                         
                                      </td>
                                    </tr>
                                </table>
                                <br />
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
                <tr>
                    <td class="common">
                        <center>
                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" 
                                LastPageText="尾页" NextPageText="下一页"
                             PrevPageText="上一页" onpagechanged="AspNetPager1_PageChanged">
                            </webdiyer:AspNetPager>
                        </center>
                    </td>
                </tr>
            </table>
            <%--
        </ContentTemplate>
    </asp:UpdatePanel>--%>
        </asp:View>
        <asp:View ID="view2" runat="server">
            <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <table cellspacing="0" cellpadding="0" class="infolist_vt" style="width: 92%">
                <tr>
                    <th colspan="4" class="caption">
                        积分详情管理
                    </th>
                </tr>
                <tr>
                    <th class="common" style="width: 10%">
                        用户姓名：
                    </th>
                    <td style="width: 40%" class="common">
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </td>
                    <th class="common" style="width: 10%;">
                        积分数量：
                    </th>
                    <td style="width: 40%;" class="common">
                        <asp:Label ID="Label2" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <table cellpadding="0" cellspacing="0" class="infolist_hr" style="width: 92%">
                <tr>
                    <th class="caption">
                        积分详情列表
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                            Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="编号">
                                    <ItemTemplate>
                                        <%#Eval("row_number") %>
                                        <asp:Label ID="lbID" runat="server" Text='<%#Eval("DetailID") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="考试币增减">
                                    <ItemTemplate>
                                        <%#Eval("IntegralChange") %>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" />
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="DropDownList1" runat="server">
                                          <asp:ListItem Value="course">-6</asp:ListItem>
                                          <asp:ListItem Value="paper">-3</asp:ListItem>
                                          <asp:ListItem Value="Article">2</asp:ListItem>
                                          <asp:ListItem Value="ArticleBack">1</asp:ListItem>
                                          <asp:ListItem Value="wrongProblem">5</asp:ListItem>
                                          <asp:ListItem Value="AddWater">-10</asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="增减说明">
                                    <ItemTemplate>
                                        <%#Eval("ChangeDes") %>
                                    </ItemTemplate>
                                    <ItemStyle Width="60%" />
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtChangeDes" runat="server" TextMode="MultiLine" Width="90%" Text='<%#Eval("ChangeDes") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                 <tr>
            <td class="common">
                <center>
                    <webdiyer:AspNetPager ID="AspNetPager2" runat="server" FirstPageText="首页" 
                        LastPageText="尾页" NextPageText="下一页"
                      PrevPageText="上一页" onpagechanged="AspNetPager2_PageChanged">
                    </webdiyer:AspNetPager>
                </center>
            </td>
        </tr>
            </table>
            <%--
        </ContentTemplate>
    </asp:UpdatePanel>--%>
        </asp:View>
    </asp:MultiView>
</asp:Content>

