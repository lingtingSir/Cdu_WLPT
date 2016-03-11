<%@ Page Title="" Language="C#" MasterPageFile="~/Users/User.master" AutoEventWireup="true" CodeFile="UserIntegral.aspx.cs" Inherits="Users_UserIntegral" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
      <ContentTemplate>--%>
       <br /><br />
                        <table style="width: 92%" cellpadding="0" cellspacing="0" class="infolist_hr">
                            <tr>
                                <th class="caption">
                                    考试币详情
                                </th>
                            </tr>
                            <tr>
                                <td valign="top" class="common">
                                    <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="编号">
                                                <ItemTemplate>
                                                    <%#Eval("row_number") %>
                                                    <asp:Label ID="lblDetailID" runat="server" Text='<%#Eval("DetailID") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="20%" CssClass="center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="积分变化">
                                                <ItemTemplate>
                                                    <%#Eval("IntegralChange") %>
                                                </ItemTemplate>
                                                <ItemStyle Width="20%" CssClass="center"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="变化说明">
                                                <ItemTemplate>
                                                    <%#Eval("ChangeDes")%>
                                                </ItemTemplate>
                                                <ItemStyle Width="60%" CssClass="center" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <center>
                                      <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页"
                                          NextPageText="下一页" PrevPageText="上一页" 
                                             onpagechanged="AspNetPager1_PageChanged" >
                                        </webdiyer:AspNetPager>
                                    </center>
                                </td>
                            </tr>
                        </table>
          <br />
  <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>

