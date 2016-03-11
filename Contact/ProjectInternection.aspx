<%@ Page Title="" Language="C#" MasterPageFile="~/Contact/Contact.master" AutoEventWireup="true" CodeFile="ProjectInternection.aspx.cs" Inherits="Contact_Contact_ProjectInternection" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <script  type="text/javascript" src="../My97DatePicker/WdatePicker.js" ></script> 
    <table cellpadding="0" cellspacing="0" class="infolist_vt" width="92%" align="center">
        <tr>
            <th class="caption" colspan="2">
                所有项目管理
            </th>
        </tr>
        <tr>
            <th class="common">
                <p>
                    &nbsp;&nbsp;&nbsp;&nbsp;搜索方式</p>
            </th>
            <td class="common" style="width: 82%">
                <asp:DropDownList ID="dropSearch" runat="server" Width="140px">
                    <asp:ListItem Value="按项目编号搜索">按项目编号搜索</asp:ListItem>
                    <asp:ListItem>按项目名称搜索</asp:ListItem>
                </asp:DropDownList>
            </td>
            <tr>
                <th width="18%" class="common">
                    &nbsp;&nbsp;&nbsp;&nbsp;关键字
                </th>
                <td class="common" style="width: 82%">
                    <asp:TextBox ID="txtSearch" runat="server" Width="140px"></asp:TextBox>
                    &nbsp;<asp:Button ID="btSearch" CssClass="button" runat="server" Text="搜 索" OnClick="btSearch_Click1" />
                </td>
            </tr>
            </tr>
            </table>
            <table>
            <tr>
                <td class="common">
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <%--<asp:Button ID="btnDelete" runat="server" CssClass="button" Text="批量删除" OnClick="btnDelete_Click" />--%>
                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">批量删除</asp:LinkButton>
                </td>
                           <td class="common">
                    &nbsp;
                    <a href="EditorProjectPaper.aspx" >添加项目</a>
                </td>
            </tr>
            </table>
             <table cellpadding="0" cellspacing="0" class="infolist_vt" width="92%" align="center">
            <tr>
                <td class="common">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="100%"
                        OnRowUpdating="GridView1_RowUpdating" OnRowEditing="GridView1_RowEditing" OnRowDeleting="GridView1_RowDeleting"
                        OnRowCancelingEdit="GridView1_RowCancelingEdit">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <center>
                                        <asp:CheckBox ID="chkBox" runat="server" />
                                    </center>
                                </ItemTemplate>
                                <ItemStyle Width="10%" />
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkBoxAll" Text="全选" OnCheckedChanged="chkBoxAll_CheckedChanged"
                                        runat="server" AutoPostBack="true" />
                                </HeaderTemplate>
                            </asp:TemplateField>
                          <asp:TemplateField HeaderText="项目编号">
                                <ItemTemplate>
                                    <center>
                                        <asp:Label ID="lbID" runat="server" Text='<%#Eval("PPID") %>'></asp:Label>
                                    </center>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="项目类型">
                                <ItemTemplate>  
                                    <center>
                                        <asp:Label ID="lbName2" runat="server" Text='<%#Eval("PTName") %>'></asp:Label>
                                    </center>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="CboTP2" runat="server" AutoGenerateColumns="False" >
                                          <asp:ListItem Value="1">android</asp:ListItem>
                                             <asp:ListItem Value="2">Web</asp:ListItem>
                                               <asp:ListItem Value="3">IOS</asp:ListItem>
                                    </asp:DropDownList>
                                   
                                </EditItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="项目名称">
                                <ItemTemplate>
                                    <center>
                                        <asp:Label ID="lbName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                    </center>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtName" Text='<%#Eval("Name") %>' runat="server"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                           

                          
                            <asp:TemplateField 　HeaderText="完成时间">
                                <ItemTemplate >
                                    <center>
                                        <asp:Label ID="lbFhtime" runat="server" Text='<%#Eval("FhdateTime") %>'></asp:Label>
                                    </center>
                                </ItemTemplate>
                                
                            </asp:TemplateField>   
                            <asp:TemplateField 　HeaderText="是否接包">
                                <ItemTemplate >
                                    <center>
                                        <asp:Label  style="color:red" ID="lbAccept" runat="server" Text='<%#Eval("IsAccept") %>'></asp:Label>
                                    </center>
                                </ItemTemplate>
                                
                            </asp:TemplateField>   
                         
                            <asp:TemplateField HeaderText="修改">
                              <ItemTemplate>
                                 <center>
                                  <a href='EditorProjectPaper2.aspx?height=460;width=600&PPID=<%#Eval("PPID") %>' class="thickbox">修改</a>
                                 </center>
                              
                              </ItemTemplate>
                            
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="查看详细描述">
                            <ItemTemplate>
                            <center>
                            <a href='ProjectPaperView2.aspx?height=460;width=600&PPID=<%#Eval("PPID") %>' class="thickbox">查看描述</a>
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
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged"
                            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" PageSize="20">
                        </webdiyer:AspNetPager>
                    </center>
                </td>
            </tr>
    </table>
</asp:Content>

