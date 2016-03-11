<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="PowerManager.aspx.cs" Inherits="Admin_PowerManager" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:92%" class="infolist_hr" cellspadding="0" cellspacing="0">
        <tr>
            <th class="common">
                权限管理
            </th>
        </tr>
        <tr>
            <td class="common">
                <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="false"
                    OnRowDeleting="GridView1_RowDeleting">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <center>
                                    <asp:CheckBox id="chkBox" runat="server" />

                                   
                                </center>
                            </ItemTemplate>
                            <ItemStyle  Width="8%"/>
                            <HeaderTemplate>
                                <asp:CheckBox id="chkBoxAll" runat="server" Text="全选" AutoPostBack="true" OnCheckedChanged="chkBoxAll_CheckedChanged"  />

                            </HeaderTemplate>

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:Label ID="lbID" runat="server" Text='<%#Eval("PowerID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="类型名称">
                            <ItemTemplate>
                            <%#Eval("PowerName") %>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="类型描述"> 
                            <ItemTemplate>
                                <%# GetSub(Eval("PowerDes").ToString().Trim(),15) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("PowerID") %>'
                                    OnCommand="LinkButton1_Command">编辑

                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowDeleteButton="true" DeleteText="&lt;div onclick=&quot;return confirm('你确定要删除吗？')&quot;&gt;删除&lt;/div&gt;" />             
                    </Columns>
                    <EmptyDataTemplate>
                        未添加数据
                    </EmptyDataTemplate>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="common indentten">
                <center>
                  <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged"
                        FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" PageSize="20">
                    </webdiyer:AspNetPager>
                </center>

            </td>
        </tr>
    </table>
    <br />
    <table cellspacing="0" cellpadding="0" class="infolist_vt" style="width:92%">
        <tr>
            <th colspan="2" class="caption">
                权限管理
            </th>
            
        </tr>
        <tr>
            <th width="18%" class="common">
                <asp:Label ID="Label1" runat="server" Text="类型ID"> 

                </asp:Label>
               
            </th>
            <td width="82%" class="common">
                &nbsp;
                <asp:TextBox ID="txtID" runat="server" Style="margin-bottom:0px; width:292px; " ValidationGroup="1"   >

                </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtID"
                    Display="Dynamic" ErrorMessage="*" ValidationGroup="1">

                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="请输入正整数"
                    ValidationExpression="^\d+$" ControlToValidate="txtID" Display="Dynamic" ValidationGroup="1">

                </asp:RegularExpressionValidator>
            </td>

        </tr>
        <tr>
            <th class="common">
                类型名称
            </th>
            <td class="common" style="width:82%">
                &nbsp;
                <asp:TextBox ID="txtName" runat="server" Width="292px" ValidationGroup="1"> </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtName" 
                    Display="Dynamic"  ErrorMessage="*" ValidationGroup="1"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic"
                    ControlToValidate="txtName" ErrorMessage="类型名称不得超过100个字" ValidationGroup="1" ValidationExpression="^(\s|\S){1,100}$"
                    ></asp:RegularExpressionValidator>

            </td>
        </tr>
        <tr>  
            <th class="common">
                类型描述:
            </th>
            <td class="common">
                &nbsp;
                <asp:TextBox runat="server" ID="txtDes" Height="54px" TextMode="MultiLine" Width="292px" >

                </asp:TextBox>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" Display="Dynamic"
                    ControlToValidate="txtDes" ErrorMessage="类型描述不能超过500个字" ValidationExpression="^(\s|\S){1,500}$"
                    ValidationGroup="1"></asp:RegularExpressionValidator>
            </td>
           
        </tr>
         <tr>
                <td colspan="2" class="common">
                    <asp:Button ID="btOK" runat="server" ValidationGroup="1" Text="提交" OnClick="btOK_Click1" />
                    &nbsp;&nbsp;&nbsp;&nbsp;


                     <asp:Button ID="btReset" runat="server" Text="重 置" OnClick="btReset_Click1" />
                </td>
               

                
            </tr>
    </table>
</asp:Content>

