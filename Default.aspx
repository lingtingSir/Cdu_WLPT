<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <title>梦工厂网络平台 </title>
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="ext/resources/css/ext-all.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="ext/adapter/ext/ext-base.js"></script>
    <script type="text/javascript" src="ext/ext-all.js"></script>

     <script type="text/javascript">
         Ext.onReady(function () {
             Ext.BLANK_IMAGE_URL = "ext/resources/images/default/s.gif";
             var Tree = Ext.tree;
             var tree = new Tree.TreePanel({
                 el: 'west_content',
                 useArrows: true,
                 autoHeight: true,
                 split: true,
                 lines: true,
                 autoScroll: true,
                 animate: true,
                 enableDD: true,
                 border: false,
                 containerScroll: true,
                 loader: new Tree.TreeLoader({
                     dataUrl: 'ext_tree_json.aspx' //生成 ext 2.0 所需要的树型格式
                 })
             });

             //        // set the root node
             //        var root = new Tree.AsyncTreeNode({
             //            text: '管理员',
             //            draggable:false,
             //            id:'0' // 0 为根目录
             //        });
             //        tree.setRootNode(root);
             //        // render the tree
             //        tree.render();
             //        root.expand();

             var viewport = new Ext.Viewport({
                 layout: 'border',
                 items: [{
                     region: 'west',
                     id: 'west',
                     //el:'panelWest',
                     title: '菜单导航',
                     split: true,
                     width: 200,
                     minSize: 200,
                     maxSize: 400,
                     collapsible: true,
                     margins: '60 0 2 2',
                     cmargins: '60 5 2 2',
                     layout: 'fit',
                     layoutConfig: { activeontop: true },
                     defaults: { bodyStyle: 'margin:0;padding:0;' },
                     //iconCls:'nav',
                     items:
                         new Ext.TabPanel({
                             border: false,
                             activeTab: 0,
                             tabPosition: 'bottom',
                             items: [
     //                              {
     //                                contentEl:'west_content',
     //                                title:'数据列表',
     //                                autoScroll:true,
     //                                bodyStyle:'padding:5px;'
     //                                //html:'<a href="welcome.aspx" target="main">欢迎！</a>',
     //                               },
                                    {
                                        layout: 'accordion', layoutConfig: { animate: true },
                                        title: '后台管理',
                                        autoScroll: true,
                                        border: false,
                                        items: [<%=  GetMenuString() %>]
                                    }

                             ]
                         })
                 }, {
                     region: 'center',
                     el: 'center',
                     deferredRender: false,
                     margins: '60 0 2 0',
                     html: '<iframe id="center-iframe" width="100%" height=100% name="main"  frameborder="0" scrolling="auto" style="border:0px none; background-color:#BBBBBB; "  ></iframe>',
                     autoScroll: true
                 },
            {
                region: 'south',
                margins: '0 0 0 2',
                border: false,
                html: '<div class="menu south">梦工厂网络平台</div>'
            }
                 ]
             });

             setTimeout(function () {
                 Ext.get('loading').remove();
                 Ext.get('loading-mask').fadeOut({ remove: true });
             }, 250)
         });
    </script>
     <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
     <div id="loading-mask" style=""></div>
      <div id="loading">
        <div class="loading-indicator"><img src="ext/resources/extanim32.gif" width="32" height="32" style="margin-right:8px;" align="absmiddle"/>Loading...</div>
      </div>
  <div id="header"><h1><%= ConfigurationManager.AppSettings["SubTitle"] %></h1></div>
  <div class="menu">
                <span style="float: left">欢迎&nbsp;&nbsp;<b><asp:Label ID="lbName" runat="server"
                    Text=""></asp:Label></b>&nbsp;&nbsp
                    &nbsp;&nbsp;<a href="Login_1.aspx">返回首页</a> </span>
                <span id="aLoginOut" runat="server" style="float: right"><a onclick="if (!window.confirm('您确认要注消当前登录用户吗？')){return false;}"
                    href="Login_1.aspx">
                    <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">注销</asp:LinkButton></a></span>
            </div>
  <div id="west">
    
  </div>
  <div id="center">
    
  </div>
  <div id="west_content" style="height:300px; ">

  </div>
    </form>
</body>
</html>


