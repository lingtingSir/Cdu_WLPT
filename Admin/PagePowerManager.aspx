<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="PagePowerManager.aspx.cs" Inherits="Admin_PagePowerManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>
    <table style="width:92%">
        <tr>
            <td class="common" style="padding-left:30px; text-align:left">
                <asp:Label ID="lbManager" runat="server" Text="Label"></asp:Label>
                页面权限分配
            </td>
        </tr>
    </table>
    <table cellspacing="0" cellpadding="0" class="infolist_vt" style="width:92%;">
        <tr>
            <td align="left">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="false"
                            OnRowDataBound="GridView1_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table width="100%">
                                            <tr>
                                                <td valign="top" align="right" width="30%">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:LinkButton ID="lkPages" runat="server" Visible="false"  CommandArgument='<%#Eval("ID") %>'
                                                        CommandName='<%#Eval("PageSort") %>' Text='<%#Eval("pageurl") %>' > </asp:LinkButton>
                                                    <asp:CheckBox  ID="ckParent" runat="server" Text='<%#Eval("pagename") %>' TextAlign="left"
                                                        ToolTip='<%# Container.DataItemIndex %>' AutoPostBack="true" OnCheckedChanged="ckParent_CheckedChanged"
                                                        />

                                                </td>
                                                <td valign="top" width="70%" align="left" valign="top">
                                                    <asp:CheckBoxList ID="ckChild" runat="server" RepeatColumns="4" RepeatDirection="Horizontal"
                                                        Enabled="false" TextAlign="left">

                                                    </asp:CheckBoxList>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button id="Button1" runat="server" Text="提交" OnClick="Button1_Click"/>
            </td>
        </tr>
        <tr>
            <td valign="bottom">
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>

    </table>
</asp:Content>
