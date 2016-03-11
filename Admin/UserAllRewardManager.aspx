<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="UserAllRewardManager.aspx.cs" Inherits="Admin_UserAllRewardManager" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="0" class="infolist_vt">
        <tr>
            <th class="caption">组员上报问题奖励列表 </th>
        </tr>
        <tr>
         
            
       </tr> 
            
        <tr>

            <td>
                <asp:DataList ID="DataList1" runat="server" Width="100%">
                    <ItemTemplate>
                        <table cellpadding="0" cellspacing="0" class="infolist_vt" style="width: 100%">
                            <tr>
                                <th align="right" class="common" style="width: 18%">编号： </th>
                                <td class="common" style="width: 82%">&nbsp;<%#Eval("row_number") %><asp:Label ID="lblWrongProblemID" runat="server" Text='<%#Eval("RewardProblemID") %>' Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <th align="right" class="common" style="width: 18%">上报用户： </th>
                                <td class="common" style="width: 82%">&nbsp;
                                    <asp:Label ID="lblUserName" runat="server" Text='<%#Eval("UserName") %>'></asp:Label>
                                    <asp:Label ID="lblUserID" runat="server" Text='<%#Eval("UserID") %>' Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <th align="right" class="common" style="width: 18%">原因： </th>
                                <td class="common" style="width: 82%">&nbsp;
                                    <asp:Label ID="lblProName" runat="server" Text='<%#Eval("Des") %>'></asp:Label>
                                </td>
                            </tr>
                            
                            <tr>
                                <th align="right" class="common" style="width: 18%">上报时间： </th>
                                <td class="common">&nbsp;
                                    <asp:Label ID="lblDateUp" runat="server" Text='<%#Eval("DateUp") %>'></asp:Label>
                                </td>
                            </tr>
                           <tr>
                                <th align="right" class="common" style="width: 18%">回复： </th>
                                <td class="common">&nbsp;
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("ManagerBack") %>'></asp:Label>
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
                    <webdiyer:aspnetpager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" onpagechanged="AspNetPager1_PageChanged" PageSize="5" PrevPageText="上一页">
                            </webdiyer:aspnetpager>
                </center>
            </td>
        </tr>
    </table>

    </asp:Content>


