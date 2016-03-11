//是否是弹出窗
function GetIsOpenWindow()
{
    var _re = CallBoMethod("BSA3BO", "PublicBO", "BSA3BO.PublicApi.BO", "GetIsOpenWindow","",2, GetSaveResult);
}
function GetSaveResult(result)
{
    if(result=="0")
    {
        $("#mLogindialog").show();
    }
    else
        showLogin();
}

function showLogin() //用户登录
{
    document.getElementById("DialogTitle"+"Dialog1").innerHTML = "";
   
}

$(document).ready(function(){
    GetIsOpenWindow();
});



//取出url中的各个参数对应的值 url参数解析
function getURLParam(strParamName, url) {
    var strReturn = "";
    var strHref = url.toLowerCase();
    if (strHref.indexOf("?") > -1) {
        var strQueryString = strHref.substr(strHref.indexOf("?") + 1).toLowerCase();
        var aQueryString = strQueryString.split("&");
        for (var iParam = 0; iParam < aQueryString.length; iParam++) {
            if (aQueryString[iParam].indexOf(strParamName.toLowerCase() + "=") > -1) {
                var aParam = aQueryString[iParam].split("=");
                strReturn = aParam[1];
                break;
            }
        }
    }
    return strReturn;
}

//根据编号找名称
function getNameByNo(tablname,namefilename,nofileno,objId)
{
   var type="publicbo";
   var method= "GetNameByNo";
   var objid = objId;
   
   var mTableName = tablname;
   var mNameFileName = namefilename;
   var mNoFileNo = nofileno;
   var mNoValue = document.getElementById(objId).value;
    
   var params = "";
   params = "&table="+mTableName+"&name="+mNameFileName+
            "&no=" + mNoFileNo + "&noValue=" + encodeURIComponent(mNoValue);
  
   var mNameValue = CallServerMethodGetResult(type, method, params);
   document.getElementById(objId).setAttribute("NoValue", mNoValue);
   if (mNameValue!="error")
      document.getElementById(objId).value = mNameValue;
}
//根据编号找名称,给另外指定的文本框赋值
function getNameByNo1(tablname,namefilename,nofileno,objId,setValueOjbId)//setValueOjbId要被赋值的文本框
{
   var type="publicbo";
   var method= "GetNameByNo";
   var objid = objId;
   
   var mTableName = tablname;
   var mNameFileName = namefilename;
   var mNoFileNo = nofileno;
   var mNoValue = document.getElementById(objId).value;
    
   var params = "";
   params = "&table="+mTableName+"&name="+mNameFileName+
            "&no=" + mNoFileNo + "&noValue=" + encodeURIComponent(mNoValue);
  
   var mNameValue = CallServerMethodGetResult(type, method, params);
   document.getElementById(objId).setAttribute("NoValue", mNoValue);
   if (mNameValue!="error")
      document.getElementById(setValueOjbId).value = mNameValue; //以前是objId，改成了setValueOjbId
}
//根据编号找名称
function getNameByNoValue(tablname, namefilename, nofileno, mNoValue) {
    var type = "publicbo";
    var method = "GetNameByNo";

    var mTableName = tablname;
    var mNameFileName = namefilename;
    var mNoFileNo = nofileno;

    var params = "";
    params = "&table=" + mTableName + "&name=" + mNameFileName +
            "&no=" + mNoFileNo + "&noValue=" + encodeURIComponent(mNoValue);

    var mNameValue = CallServerMethodGetResult(type, method, params);
    if (mNameValue != "error")
        return mNameValue;
    else
        return "";    
}

//获得焦点显示编号
function getNoByName(objId)
{
    var mNoValue = document.getElementById(objId).value;
    try{
      mNoValue = document.getElementById(objId).getAttribute("NoValue");
      if(mNoValue!=null && mNoValue!="")
        document.getElementById(objId).value = mNoValue;
        
    }
    catch(e){}
    document.getElementById(objId).select();
}

//根据单据类型单据编号格式获取相关单据的单号
function getSqNo(mSqId, mDefaultPat) {
    var type = "SqNo";
    var method = "SqNoGet";
    var params = "";
    params = "&sqid=" + mSqId + "&defaultpat=" + mDefaultPat;  
    return CallServerMethodGetResult(type, method, params);   
    //SqNo.SqNoGet("PC", DateTime.Now.ToString("yyyy-MM-dd"), 0, "PCYMDDNNNN");
}

var arrayField="";//定义要查询的字段数组
var arrayFieldControl=""; //定义需要赋值的控件ID数组
//根据主键查找其它详细信息   表名   需要查询的字段名    查询条件    需要赋值的控件ID
function GetDetailByPrimary(mTableName, mFieldNames, mPrimarysWhere, mFieldControl)
{
    arrayField = mFieldNames.split(',');
    arrayFieldControl = mFieldControl.split(',');
    var _params = mTableName+"&"+mFieldNames+"&"+mPrimarysWhere;
    var _re = CallBoMethod("EMPBO", "publicbo", "EMPBO.PublicApi.bo", "GetDetailByPrimary",_params,2, GetDetailResult);
}
function GetDetailResult(_detailxml)
{
    var xml = _detailxml;
    $(xml).find("ds").each(function() {
        for(var j=0;j<arrayField.length;j++)
        {
            if(arrayFieldControl[j].slice(-3)=="txt"||arrayFieldControl[j].slice(-3)=="com")
            {
                $("#"+arrayFieldControl[j]).val($(this).find(arrayField[j]).text());
            }else if(arrayFieldControl[j].slice(-3)=="lbl")
            {
                $("#"+arrayFieldControl[j]).text($(this).find(arrayField[j]).text());
            }else if(arrayFieldControl[j].slice(-3)=="chk")
            {
                if($(this).find(arrayField[j]).text()=="1")
                {
                    $("#"+arrayFieldControl[j]).attr("checked","checked");
                }
                else
                {
                    $("#"+arrayFieldControl[j]).removeAttr("checked");
                }
            }
        }
    });
}

function addSqNo(mSqId, mDefaultPat) {
    var type = "SqNo";
    var method = "SqNoAdd";
    var params = "";
    params = "&sqid=" + mSqId + "&defaultpat=" + mDefaultPat;
    return CallServerMethodGetResult(type, method, params);
    //SqNo.SqNoGet("PC", DateTime.Now.ToString("yyyy-MM-dd"), 0, "PCYMDDNNNN");
}

function BodyReSize() {
    var height = document.documentElement.clientHeight -
	             document.getElementById("documentfoottbl").clientHeight -
	             document.getElementById("documentheadtbl").clientHeight -
	             28;
    document.getElementById("documentbodytbl").style.height = height + "px";
    var width = document.documentElement.clientWidth - 60;
    document.getElementById("documentbodytbl").style.width = width + "px";
}


$(window).resize(function() {
    try {
        BodyReSize();
    }
    catch (e) { }
});

Date.prototype.format = function(mask) {
    var d = this;
    var zeroize = function(value, length) {
        if (!length) length = 2;
        value = String(value);
        for (var i = 0, zeros = ''; i < (length - value.length); i++) {
            zeros += '0';
        }
        return zeros + value;
    };

    return mask.replace(/"[^"]*"|'[^']*'|\b(?:d{1,4}|m{1,4}|yy(?:yy)?|([hHMstT])\1?|[lLZ])\b/g, function($0) {
        switch ($0) {
            case 'd': return d.getDate();
            case 'dd': return zeroize(d.getDate());
            case 'ddd': return ['Sun', 'Mon', 'Tue', 'Wed', 'Thr', 'Fri', 'Sat'][d.getDay()];
            case 'dddd': return ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'][d.getDay()];
            case 'M': return d.getMonth() + 1;
            case 'MM': return zeroize(d.getMonth() + 1);
            case 'MMM': return ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'][d.getMonth()];
            case 'MMMM': return ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'][d.getMonth()];
            case 'yy': return String(d.getFullYear()).substr(2);
            case 'yyyy': return d.getFullYear();
            case 'h': return d.getHours() % 12 || 12;
            case 'hh': return zeroize(d.getHours() % 12 || 12);
            case 'H': return d.getHours();
            case 'HH': return zeroize(d.getHours());
            case 'm': return d.getMinutes();
            case 'mm': return zeroize(d.getMinutes());
            case 's': return d.getSeconds();
            case 'ss': return zeroize(d.getSeconds());
            case 'l': return zeroize(d.getMilliseconds(), 3);
            case 'L': var m = d.getMilliseconds();
                if (m > 99) m = Math.round(m / 10);
                return zeroize(m);
            case 'tt': return d.getHours() < 12 ? 'am' : 'pm';
            case 'TT': return d.getHours() < 12 ? 'AM' : 'PM';
            case 'Z': return d.toUTCString().match(/[A-Z]+$/);
                // Return quoted strings with the surrounding quotes removed     
            default: return $0.substr(1, $0.length - 2);
        }
    });
};


function formatFloat(src, pos) {
    return Math.round(src * Math.pow(10, pos)) / Math.pow(10, pos);
}

//屏蔽IE Firefox默认快捷键
function stopDefault(e) {
    // Prevent the default browser action (W3C)
    if (e && e.preventDefault)
        e.preventDefault();
    else
    // A shortcut for stoping the browser action in IE
        window.event.returnValue = false;
    return false;
}

//load xml string 加载 XML 字符串
function loadXmlString(xmlString) {
    var _xmlDoc = null;
    if (!window.DOMParser && window.ActiveXObject) {
        var xmlDomVersions = ['MSXML2.DOMDocument.6.0', 'MSXML2.DOMDocument.3.0', 'Microsoft.XMLDOM'];
        for (var i = 0; i < xmlDomVersions.length; i++) {
            try {
                _xmlDoc = new ActiveXObject(xmlDomVersions[i]);
                _xmlDoc.async = false;
                _xmlDoc.loadXML(xmlString);
                break;
            }
            catch (e) { }
        }
    }
    else if (window.DOMParser && document.implementation && document.implementation.createDocument) {
        try {
            domParser = new DOMParser();
            _xmlDoc = domParser.parseFromString(xmlString, 'text/xml');
        }
        catch (e) { }
    }

    return _xmlDoc;
}

var currentopenquerytablename = ""; //表名
var currentopenqueryfieldnames = ""; //查询字段
var currentopenqueryfieldcnnames = ""; //表头名称
var currentopenqueryorderfield = ""; //排序字段及排序方式
var currentopenquerywhere = "";  //查询条件
var currentopenquerydatefieldname = ""; //查询的日期字段
var currentcontextMenuField = "";


var mQueryOpenWindowStrWhere = ""; //取值开窗的条件

var queryTableName = ""; //基础资料速查传的表名
var queryFieldNames = ""; //基础资料速查传的字段名

//上传图片的后处理 返回的URL    要显示文件的A对象ID                         要存放URL的对象ID
function UploadFile(mFileUrl, mParentDownLoadObjectId, mParentImageObjectId, mParentObjectId) {
    var obj = document.getElementById(mParentDownLoadObjectId);
    if (obj != null) obj.href = mFileUrl;
    obj = document.getElementById(mParentImageObjectId);
    if (obj != null) obj.src = mFileUrl;    
    obj = document.getElementById(mParentObjectId);
    if (obj != null) obj.value = mFileUrl;
}

//弹出无状态栏的窗口
function fullScreen(theURL) {
    window.open(theURL, '', 'fullscreen=yes, scrollbars=auto');
}

//窗口最大化
function maxWindow() {
    window.moveTo(0, 0);
    if (document.all) {
        top.window.resizeTo(screen.availWidth, screen.availHeight);
    }

    else if (document.layers || document.getElementById) {
        if (top.window.outerHeight < screen.availHeight || top.window.outerWidth < screen.availWidth) {
            top.window.outerHeight = screen.availHeight;
            top.window.outerWidth = screen.availWidth;
        }
    }
}