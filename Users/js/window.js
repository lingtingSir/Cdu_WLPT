// JavaScript Document
//公用函数
var fw = {};
fw.dom = {};
fw.ui = {};
fw.array = {};
fw.com = {};
fw.com.ui = {};
fw.isIE = !!document.all;
fw.isFF = !fw.isIE;
fw.getId = function (id) {
    return document.getElementById(id);
}
fw.get = function (v) {
    return typeof v == "string" ? fw.getId(v) : v;
}
fw.setStyle = function(obj,st){
for (var i in st){
   obj.style[i] = st[i];
} 
}
fw.create = function(parentObj,tag,args){
var obj = document.createElement(tag);
if (args){
   for (var item in args){
    if (item=="style") {
     fw.setStyle(obj,args[item]);
    }else if (item=="range"){
     obj.style.position = "absolute";
     fw.dom.setRange(obj,args[item]);
    }else if (item=="html"){
     obj.innerHTML = args.html;
    }else if (item=="className"){
     obj.className = args[item]; 
    }else{
     obj.setAttribute(item,args[item]);
    }
   }
}
parentObj.appendChild(obj);
return obj;
}
fw.bind = function() {
var args = fw.array.clone(arguments);
var obj = args.shift();
var method = args.shift();
//method.prototype;
// assert method != null;
if (typeof method != "function"){
   throw "Invalid method: " + method;
}
return function() {
   var iargs = [];
   for (var i = 0; i < arguments.length; i++){
    iargs.push(arguments[i]);
   }
   return method.apply(obj, args.concat(iargs));
}
}
fw.array.each = function (arr, callBack) {
    for (var i = 0, l = arr.length; i < l; i++) {
        callBack(arr[i]);
    }
}
fw.array.clone = function (arr_old) {
    var arr_new = [];
    fw.array.each(arr_old, function (val) {arr_new.push(val);});
    return arr_new;
}
fw.dom.getLeft = function (o) {
    return parseInt(o.style.left) || 0;
}
fw.dom.getTop = function (o) {
    return parseInt(o.style.top) || 0;
}
fw.dom.getXy = function (o) {
    return {x:fw.dom.getLeft(o), y:fw.dom.getTop(o)};
}
fw.dom.setLeft = function (o, px) {
    o.style.left = px + "px";
}
fw.dom.setTop = function (o, px) {
    o.style.top = px + "px";
}
fw.dom.setWidth = function (o, px) {
    o.style.width = px + "px";
}
fw.dom.setHeight = function (o, px) {
    o.style.height = px + "px";
}
fw.dom.setXy = function (o, x, y) {
    fw.dom.setLeft(o, x);
    fw.dom.setTop(o, y);
}
fw.dom.setSize = function (o, w, h) {
    fw.dom.setWidth(o, w);
    fw.dom.setHeight(o, h);
}
fw.dom.setRange = function (o, r) {
    fw.dom.setXy(o, r[0], r[1]);
    fw.dom.setSize(o, r[2], r[3]);
}
if (fw.isIE){
fw.event = function (){
   var e = window.event;
   if (!e.target){
    e.target = e.srcElement;
   }
   return e;
}
fw.capture = {
   start : function (obj){
    obj.setCapture();
   },
   end : function (obj){
    obj.releaseCapture();
   }
}
}else{
fw.event = function () {
   var e, f = arguments.callee;
       while ((f = f.caller)) {
           if ((e = f.arguments[0]) && /Event/.test(e.constructor.toString())) {
               return e;
            }
       }
}
fw.capture = {
   start : function(obj){
    window.captureEvents(Event.MouseMove|Event.MouseUp);
   },
   end : function(obj){
    window.releaseEvents(Event.MouseMove|Event.MouseUp);
   }
}
}

//拖动
fw.ui.drag = function (obj){
obj = fw.get(obj);
obj.style.position = "absolute";

var isMoveAble = false;
var xy;
obj.onmousedown = function (){
   fw.capture.start(obj);
   isMoveAble = true;
   var evt = fw.event();
   xy = fw.dom.getXy(obj);
   xy = {
    x : evt.clientX - xy.x,
    y : evt.clientY - xy.y
   }
}
obj.onmousemove = function (){
   if (isMoveAble){
    var evt = fw.event();
    fw.dom.setXy(obj, evt.clientX-xy.x, evt.clientY-xy.y);
   }
}
obj.onmouseup = function (){
   fw.capture.end(obj);
   isMoveAble = false;
}
}


//窗口类
fw.com.ui.window = function(json){
this.obj = {};
var html = '<div class="box-tl"><div class="box-tr"><div class="box-tc" id="fw.com.ui.window.title"></div></div></div><div class="box-ml"><div class="box-mr"><div class="box-mc" id="fw.com.ui.window.panel"></div></div></div><div class="box-bl"><div class="box-br"><div class="box-bc"></div></div></div><div class="box-tool"><a href="javascript:void(0);" id="fw.com.ui.window.close"></a></div>'; 
this.obj.box = fw.create(document.body,"div",{className:"box",style:{
   position:"absolute", display:json.display?json.display:""
},html:html});
fw.getId("fw.com.ui.window.close").onclick = fw.bind(this,this.hide);
fw.getId("fw.com.ui.window.title").innerHTML = json.title?json.title:"";
with(fw.getId("fw.com.ui.window.panel")){
   innerHTML = json.html?json.html:"";
   style.height = (json.range[3]+140)+"px";
}
fw.dom.setRange(this.obj.box, json.range);
fw.ui.drag(this.obj.box);
}

//显示窗口
fw.com.ui.window.prototype.show = function(){
this.obj.box.style.display = ""; 
}

//隐藏窗口
fw.com.ui.window.prototype.hide = function(){
this.obj.box.style.display = "none"; 
}
