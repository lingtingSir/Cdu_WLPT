$(function () {
    $(".addfav").click(function () {　　　　//$里面是链接的id 
        var ctrl = (navigator.userAgent.toLowerCase()).indexOf('mac') != -1 ? 'Command/Cmd' : 'CTRL';
        var sTitle = document.title;
        var sUrl = document.URL;
        if (document.all) {
            window.external.addFavorite(sUrl, sTitle)
        } else if (window.sidebar) {
            $(this).attr("rel", "sidebar");
            window.sidebar.addPanel(sTitle, sUrl, "")
        } else {　　　　//添加收藏的快捷键 
            alert('添加失败\n您可以尝试通过快捷键' + ctrl + ' + D 加入到收藏夹~')
        }
        return false;
    });
});