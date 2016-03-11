// JavaScript Document
var bannerAD=new Array();
var bannerADlink=new Array();
var adNum=0;
//修改下面的图片地址和相应的链接地址
bannerAD[0]="img/6.jpg";
bannerAD[1]="img/1.jpg";
bannerAD[2]="img/2.jpg";
bannerAD[3]="img/3.jpg";
bannerAD[4]="img/4.jpg";
bannerAD[5]="img/5.jpg";
var preloadedimages=new Array();
for (i=1;i<bannerAD.length;i++){
preloadedimages[i]=new Image();
preloadedimages[i].src=bannerAD[i];
}
function setTransition(){
if (document.all){
bannerADrotator.filters.revealTrans.Transition=Math.floor(Math.random()*23);
bannerADrotator.filters.revealTrans.apply();
}
}
function playTransition(){
if (document.all)
bannerADrotator.filters.revealTrans.play()
}
function nextAd(){
if(adNum<bannerAD.length-1)adNum++ ;
else adNum=0;
setTransition();
document.images.bannerADrotator.src=bannerAD[adNum];
playTransition();
theTimer=setTimeout("nextAd()", 3000);
}
function jump2url(){
jumpUrl=bannerADlink[adNum];
jumpTarget='_blank';
if (jumpUrl != ''){
if (jumpTarget != '')window.open(jumpUrl,jumpTarget);
else location.href=jumpUrl;
}
}
function displayStatusMsg() {
status=bannerADlink[adNum];
document.returnValue = true;
}



