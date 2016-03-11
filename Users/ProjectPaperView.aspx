<%@ Page Title="" Language="C#" MasterPageFile="~/Users/User.master" AutoEventWireup="true" CodeFile="ProjectPaperView.aspx.cs" Inherits="Users_ProjectPaperView" %>
<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script  type="text/javascript" src="../My97DatePicker/WdatePicker.js" ></script> 
    <table cellpadding="0" cellspacing="0" class="infolist_vt" style="width:92%" align="center">
         <tr>
                    <th class="caption" colspan="2" style="height: 22px">
                        项目描述
                    </th>
                </tr>
        <tr><th class="common" style="width:20%">项目名称：</th><td class="common" style="width:80%">&nbsp;&nbsp;
            <asp:TextBox ID="Name" runat="server" Width="144px"></asp:TextBox>
                                            </td>


        </tr>
        <tr><th class="common">项目类型：</th><td class="common">
           &nbsp;&nbsp; <asp:DropDownList ID="PaperType" runat="server">
            </asp:DropDownList>
        </td>

        </tr>

        <tr><th class="common">开始时间：</th><td class="common">
           &nbsp;&nbsp; 
            <asp:TextBox ID="TextBox1" runat="server" CssClass="ipt" onClick="WdatePicker()"></asp:TextBox>
        </td>

        </tr>
            <tr><th class="common">结束时间：</th><td class="common">
           &nbsp;&nbsp; 
            <asp:TextBox ID="TextBox2" runat="server" CssClass="ipt" onClick="WdatePicker()"></asp:TextBox>
        </td>

        </tr>

        <tr><th class="common">完成时间：</th><td class="common">
           &nbsp;&nbsp; 
            <asp:TextBox ID="TextBox3" runat="server" CssClass="ipt" onClick="WdatePicker()"></asp:TextBox>
        </td>

        </tr>

   
    
           
          
   

        <tr><th class="common" style="width:20%">描述：</th><td class="common"></td></tr>
        <tr><td colspan="2" class="common">
            <fckeditorv2:fckeditor ID="FCKeditor1" Height="200px"  runat="server">
            </fckeditorv2:fckeditor>
            </td></tr>
            <tr><td class="common" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp; 
                </td></tr>

        </table>
</asp:Content>



