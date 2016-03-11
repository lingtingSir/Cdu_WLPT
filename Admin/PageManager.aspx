<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="PageManager.aspx.cs" Inherits="Admin_PageManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:92%" class="infolist_vt">
        <tr>
            <th style="font-size:large;font-weight:bolder;"  class="caption" >
                <br />
               　页面管理
            </th>

        </tr>
        <tr>
            <td class="common">
                <asp:GridView ID="GridView1" runat="server" Width="100%" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                    OnrowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"
                    AutoGenerateColumns="false">
                   <Columns>
                       <asp:TemplateField>
                           <ItemTemplate>
                               <center>
                                   <asp:CheckBox id="chkBox" runat="server" />
                               </center>
                           </ItemTemplate>
                           <ItemStyle Width="8%" />
                           <HeaderTemplate>
                               <asp:CheckBox ID="chkBoxAll"  runat="server" Text="全选" AutoPostBack="True" />
                           </HeaderTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="页面名称">
                           <ItemTemplate>
                               <asp:Label ID="lbID" runat="server" Text='<%#Eval("ID")%>' Visible="false"></asp:Label>
                                <%#Eval("PageName") %>
                           </ItemTemplate>
                           <EditItemTemplate>
                               <asp:Label ID="lbID" runat="server" Text='<%#Eval("ID") %>' Visible="false"></asp:Label>
                               <asp:TextBox ID="txtName1" runat="server" Text='<%#Eval("PageName")%>'></asp:TextBox>
                           </EditItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="子页面">
                           <ItemTemplate>
                               <a href="PageManager.aspx?id=<%#Eval("ID") %>">查看(<%#Eval("ChildCount") %>)</a>

                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="编辑描述" Visible="false">
                           <ItemTemplate>
                               <a href="UpdatePageDes.aspx?height=300;width=600&id=<%#Eval("ID")%>&s=<%=getstring()%>"
                                   class="thickbox">编辑页面描述 </a>
                           </ItemTemplate>

                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="页面顺序">
                           <ItemTemplate>
                               <%#Eval("PageSort") %>
                           </ItemTemplate>
                           <EditItemTemplate>
                               <asp:TextBox ID="txtSort" runat="server" Text='<%#Eval("PageSort")%>'>

                               </asp:TextBox>
                           </EditItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="页面地址">
                           <ItemTemplate>
                               <%#Eval("PageUrl") %>
                           </ItemTemplate>
                           <EditItemTemplate>
                               <asp:TextBox ID="txtUrl" runat="server" Text='<%#Eval("PageUrl") %>'>

                               </asp:TextBox>
                           </EditItemTemplate>
                       </asp:TemplateField>
                       <asp:CommandField  ShowEditButton="true"/>
                       <asp:CommandField ShowDeleteButton="true" DeleteText="&lt;div onclick=&quot;return confirm('你确定要删除吗？')&quot;&gt;删除&lt;div&gt;" />
                   </Columns>

                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="common">
                &nbsp;<asp:Button ID="btDelete" runat="server" Text="删 除" OnClientClick="return confirm('你确定要删除吗?')"
                    OnClick="btDelete_Click" />
            </td>
        </tr>


    </table>
    <br />
    <table cellspacing="0" cellpadding="0" class="infolist_vt" style="width:92%">
        <tr>
            <th colspan="2" class="caption">
                页面添加
            </th>
        </tr>
        <tr>
            <th class="common" style="width:18%">
                页面名称:
            </th>
            <td class="common" style="width:82%">
                <asp:TextBox ID="txtName" runat="server" Width="191px" ValidationGroup="1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequireFieldValidator1" runat="server" ErrorMessage="该项不能为空"
                   ValidationGroup="1" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" Display="Dynamic"
                    ControlToValidate="txtName" ErrorMessage="页面名称不能超过100个字" ValidationExpression="^(\s|\S){1,100}$"
                    ValidationGroup="1"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <th class="common">
                页面地址:
            </th>
            <td class="common">
                <asp:TextBox ID="txtDes" runat="server" Width="191px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="该项不能为空"
                    ValidationGroup="1" ControlToValidate="txtDes"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                    ControlToValidate="txtDes" ErrorMessage="页面地址不能超过200字" ValidationExpression="^(\s|\S){1,200}"
                    ValidationGroup="1"></asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
             <th class="common">
                验&nbsp; 证&nbsp; 码：
             </th>
             <td class="common">
                 <asp:TextBox ID="txtCode" runat="server" Width="104px"></asp:TextBox>
                 <asp:ImageButton ID="ImageCheck" ImageUrl="../Code.aspx"  runat="server" />
             </td>
         </tr>
        <tr>
            <td class="common" colspan="2">
                &nbsp;&nbsp;
                <asp:Button ID="ImageButton1" runat="server" Text="提交" OnClick="ImagesButton1_Click"
                    ValidationGroup="1" Width="58px" />
            </td>
        </tr>
    </table>
</asp:Content>

