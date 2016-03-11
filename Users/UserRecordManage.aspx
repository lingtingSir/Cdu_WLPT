<%@ Page Title="" Language="C#" MasterPageFile="~/Users/User.master" AutoEventWireup="true" CodeFile="UserRecordManage.aspx.cs" Inherits="Users_UserRecordManage" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellspacing="0" cellpadding="0" class="infolist_vt" style="width: 92%">
                <tr>
                    <th colspan="4" class="caption">
                        会议管理
                    </th>
                </tr>
                <tr>
                    <th class="common" style="width: 10%">
                        项目名称：
                    </th>
                    <td style="width: 40%" class="common">
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </td>
                    
                    
                </tr>
            </table>
            <br />
            <table cellpadding="0" cellspacing="0" class="infolist_hr" style="width: 92%">
                <tr>
                    <th class="caption">
                        会议详情
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
                                        <asp:Label ID="lbID" runat="server" Text='<%#Eval("RecordID") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="项目名称">
                                    <ItemTemplate>
                                        <%#Eval("Name") %>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" />
                                   
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="时间">
                                    <ItemTemplate>
                                        <%#Eval("PresentDate") %>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" />
                                   
                                </asp:TemplateField>
                                
                                 <asp:TemplateField HeaderText="查看会议记录内容">
                            <ItemTemplate>
                            <center>
                            <a href='ProjectPaperRecordWrong.aspx?RecordID=<%#Eval("RecordID") %>'>查看会议记录内容</a>
                            </center>
                            </ItemTemplate> 
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

</asp:Content>

