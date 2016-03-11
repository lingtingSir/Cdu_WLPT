function runImg() { }
runImg.prototype = {
    bigbox: null,//���������
    boxul: null,//������ul
    imglist: null,//������img
    numlist: null,//������countNum
    prov: 0,//�ϴ���ʾ��
    index: 0,//��ǰ��ʾ��
    timer: null,//����ͼƬת��Ч��
    play: null,//�����Զ�����
    imgurl: [],//���ͼƬ
    count: 0,//��ŵĸ���
    $: function (obj) {
        if (typeof (obj) == "string") {
            if (obj.indexOf("#") >= 0) {
                obj = obj.replace("#", "");
                if (document.getElementById(obj)) {
                    return document.getElementById(obj);
                }
                else {
                    alert("û������" + obj);
                    return null;
                }
            }
            else {
                return document.createElement(obj);
            }
        }
        else {
            return obj;
        }
    },
    //��ʼ��
    info: function (id) {
        this.count = this.count <= 3 ? this.count : 3;
        this.bigbox = this.$(id);
        for (var i = 0; i < 2; i++) {
            var ul = this.$("ul");
            for (var j = 1; j <= this.count; j++) {
                var li = this.$("li");
                li.innerHTML = i == 0 ? this.imgurl[j - 1] : j;
                ul.appendChild(li);
            }
            this.bigbox.appendChild(ul);
        }
        this.boxul = this.bigbox.getElementsByTagName("ul");
        this.boxul[0].className = "imgList";
        this.boxul[1].className = "countNum";
        this.imglist = this.boxul[0].getElementsByTagName("li");
        this.numlist = this.boxul[1].getElementsByTagName("li");
        for (var j = 0; j < this.imglist.length; j++) {
            this.alpha(j, 0);
        }
        this.alpha(0, 100);
        this.numlist[0].className = "current";
    },
    //��װ�������
    action: function (id) {
        this.autoplay();
        this.mouseoverout(this.bigbox, this.numlist);
    },
    //ͼƬ�л�Ч��
    imgshow: function (num, numlist, imglist) {
        this.index = num;
        var pralpha = 100;
        var inalpha = 0;
        for (var i = 0; i < numlist.length; i++) {
            numlist[i].className = "";
        }
        numlist[this.index].className = "current";
        clearInterval(this.timer);
        for (var j = 0; j < this.imglist.length; j++) {
            this.alpha(j, 0);
        }
        this.alpha(this.prov, 100);
        this.alpha(this.index, 0);
        var $this = this;
        //����͸������ʵ���л�ͼƬ
        this.timer = setInterval(function () {
            inalpha += 2;
            pralpha -= 2;
            if (inalpha > 100) { inalpha = 100 };//���ܴ���100
            if (pralpha < 0) { pralpha = 100 };
            //Ϊ�����Ը���ʽ
            $this.alpha($this.prov, pralpha);
            $this.alpha($this.index, inalpha);
            if (inalpha == 100 && pralpha == 0) { clearInterval($this.timer) };//������100��ʱ����л������
        }, 20)
    },
    //����͸����
    alpha: function (i, opacity) {
        this.imglist[i].style.opacity = opacity / 100;
        this.imglist[i].style.filter = "alpha(opacity=" + opacity + ")";
    },
    //�Զ�����
    autoplay: function () {
        var $this = this;
        this.play = setInterval(function () {
            $this.prov = $this.index;
            $this.index++;
            if ($this.index > $this.imglist.length - 1) { $this.index = 0 };
            $this.imgshow($this.index, $this.numlist, $this.imglist);
        }, 3000)
    },
    //��������¼�
    mouseoverout: function (box, numlist) {
        var $this = this;
        box.onmouseover = function () {
            clearInterval($this.play);
        }
        box.onmouseout = function () {
            $this.autoplay($this.index);
        }
        for (var i = 0; i < numlist.length; i++) {
            numlist[i].index = i;
            numlist[i].onmouseover = function () {
                $this.prov = $this.index;
                $this.imgshow(this.index, $this.numlist, $this.imglist);
            }
        }
    }
}
