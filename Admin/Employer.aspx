<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Employer.aspx.cs" Inherits="Admin_Employer" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <script  type="text/javascript" src="../My97DatePicker/WdatePicker.js" ></script> 
    <table cellpadding="0" cellspacing="0" class="infolist_vt" width="92%" align="center">
        <tr>
            <th class="caption" colspan="2">
                所有发包管理
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
                </td>
                           <td class="common">
                    &nbsp;&nbsp;
                </td>
            </tr>
            </table>
             <table cellpadding="0" cellspacing="0" class="infolist_vt" width="92%" align="center">
            <tr>
                <td class="common">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="100%" >
                        <Columns>
                           
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
                                 <EditItemTemplate>            
        
                                     <asp:TextBox ID="txtFhTime" runat="server" CssClass="ipt" onClick="WdatePicker()"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>   
                         　　
                            <asp:TemplateField HeaderText="查看分配结果">
                              <ItemTemplate>
                                  <center>
                                 <asp:LinkButton ID="LinkButton2" runat="server" OnCommand="LinkButton2_Command" CommandArgument='<%# Eval("PPID") %>'>查看分配结果</asp:LinkButton>
                                 </center>
                              </ItemTemplate>
                            
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="分配项目">
                            <ItemTemplate>
                             <center>
                                 <asp:LinkButton ID="LinkButton3" runat="server" OnCommand="LinkButton3_Command" CommandArgument='<%# Eval("PPID") %>'>分配项目</asp:LinkButton>
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
    <br />
    <table id="Look" style="width: 92%" class="infolist_hr" cellpadding="0" cellspacing="0" visible="false" runat="server">
                <tr>
                    <th class="caption">
                       分配结果如下：
                    </th>
                </tr>
                <tr>
                    <td class="common"  >
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="100%"    
                                >
                           
                            <Columns>
                           
                                <asp:TemplateField        >
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkBox" runat="server" />
                                    </ItemTemplate>
                                    <HeaderTemplate >
                                        <asp:CheckBox ID="chkBoxAll" runat="server" Text="全选" OnCheckedChanged="chkBoxAll_CheckedChanged"
                                            AutoPostBack="True" />
                                    </HeaderTemplate>
                                     
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="项目组名称">
                            <ItemTemplate>
                                <%#Eval("DepartmentName") %>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("DepartmentName") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                                <asp:TemplateField HeaderText="项目名称">
                                    <ItemTemplate>
                                        <%#Eval("Name")%>
                                    </ItemTemplate>
                                    
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="项目组组长">
                                    <ItemTemplate>
                                        <%#Eval("ProjectHead")%>
                                    </ItemTemplate>
                                    
                            
                                </asp:TemplateField>
                                 
                            </Columns>
                            <EmptyDataTemplate>
                                尚未分配项目组
                            </EmptyDataTemplate>
                        </asp:GridView>
                     
                         
                    </td>
                    
                </tr>
                <tr>
                    <td class="common indentten">
                         <center>
                        <webdiyer:AspNetPager ID="AspNetPager2" runat="server" OnPageChanged="AspNetPager1_PageChanged"
                            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" PageSize="20">
                        </webdiyer:AspNetPager>
                        </center>
                        </td>
                       
                </tr>
                <tr>
            <td>
                &nbsp;&nbsp;
                <asp:Button ID="btDelete" runat="server" Text="删 除" onclick="btDelete_Click" />
            &nbsp; <asp:Button ID="btOpen" runat="server" Text="关 闭" 
                    OnClick="btOpen_Click1" />
            </td>
        </tr>
    
        </table> 
    <br />

    <table id="add" runat="server" cellpadding="0" cellspacing="0" class="infolist_vt" visible="false" >
                   <tr>
                       <th class="caption" colspan="2">项目分配 </th>
                   </tr>
                   <tr>
                       <td class="common right" colspan="2">
                           <asp:Button ID="Button3" runat="server" CssClass="button" onclick="Button3_Click" Text="确 定" />
                           &nbsp;<asp:Button ID="Button4" runat="server" CssClass="button" onclick="Button4_Click" Text="取 消" />
                       </td>
                   </tr>
                   <tr>
                       <th class="common">项目组(部门)</th>
                        <td class="common" style="width: 82%">
                        &nbsp;
                        <asp:DropDownList ID="OkDepartment" runat="server" AutoPostBack="True" Width="200px" >
                        </asp:DropDownList>
                    </td>
                   </tr>
                   </table>

    <br />

    <table style="width:92%" class="infolist_hr" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                &nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
        </tr>
               
            </table>
</asp:Content>



