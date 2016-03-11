<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LinkWord.ascx.cs" Inherits="UserControl_LinkWord" %>
<div id="add-01-main">
    <ul>
        <asp:DataList ID="DataList1" runat="server" EnableViewState="false">
            <ItemTemplate>
                <li><a href='<%#Eval("Linkhref") %>' target="_blank" class="" title='<%#Eval("LinkName") %>'>
                    <%#Eval("LinkName") %>
                </a></li>
            </ItemTemplate>
        </asp:DataList>
     </ul>
</div>