//$.ajaxSetup({
//    async: false
//});    



function CallServerMethod(type, method, objid, params) {
    $.ajax({
        type: "POST",
        url: "/AjaxMethod.aspx?Type=" + type + "&Method=" + method + params,
        data: "{}",
        async: false,
        success: function(msg) {
            $('#' + objid).html(msg);
            //$('#' + objid).html("123");
        }
    });
}

function CallServerMethodGetResult(type, method, params) {
    var result = "";
    $.ajax({
        type: "POST",
        url: "/AjaxMethod.aspx?Type=" + type + "&Method=" + method + params,
        data: "{}",
        async: false,
        success: function(msg) {
            result = msg;
        }
    });
    return result;
}


function CallServerMethodGetXmlResult(type, method, params) {
    var result = "";
    $.ajax({
        type: "POST",
        dataType: "xml",
        url: "/AjaxMethod.aspx?Type=" + type + "&Method=" + method + params,
        data: "{}",
        async: false,
        success: function(msg) {
            result = msg;
        }
    });
    return result;
}

//JS方法 参数说明：类库名，类名，命名空间名，方法名，传入参数，调用类型 1:get 2:post, 回调函数 , 是否异步
function CallBoMethod(mLibName, mClassName, mClassNameSpace, mMethodname, mParams, mType, mCallBack, isasync) {

    var _result = null;
    if (isasync)
    {
        $.ajaxSetup({async:true});
    }
    else
    {
        $.ajaxSetup({async:false});
    }
    switch (mType) {
        case 1:

            jQuery.get('CallLocalBo.ashx?' + mParams,
              { async: false, data: mParams, type: mClassNameSpace + '.' + mClassName + ';' + mLibName, method: mMethodname },
              function(data) { mCallBack(data); },
              //mCallBack(data),
              '');
            break;
        case 2:
            jQuery.post('CallLocalBo.ashx',
              { async: false, data: mParams, type: mClassNameSpace + '.' + mClassName + ';' + mLibName, method: mMethodname },
              function(data) { mCallBack(data); },
              //mCallBack(data),
              '');
            break;
        default:
            jQuery.post('CallLocalBo.ashx?' + mParams,
              { async: false, data: mParams, type: mClassNameSpace + '.' + mClassName + ';' + mLibName, method: mMethodname },
              function(data) { mCallBack(data); },
              //mCallBack(data),
              '');
             break;
      }
  }

  //JS方法 参数说明：类库名，类名，命名空间名，方法名，传入参数，调用类型 1:get 2:post, 回调函数 , 是否异步
  function CallCloudyBoMethod(mLibName, mClassName, mClassNameSpace, mMethodname, mParams, mType, mCallBack, isasync) {

      var _result = null;
      if (isasync) {
          $.ajaxSetup({ async: true });
      }
      else {
          $.ajaxSetup({ async: false });
      }
      switch (mType) {
          case 1:

              jQuery.get('CallCloudyBo.ashx?' + mParams,
              { async: false, data: mParams, type: mClassNameSpace + '.' + mClassName + ';' + mLibName, method: mMethodname },
              function(data) { mCallBack(data); },
              //mCallBack(data),
              '');
              break;
          case 2:
              jQuery.post('CallCloudyBo.ashx',
              { async: false, data: mParams, type: mClassNameSpace + '.' + mClassName + ';' + mLibName, method: mMethodname },
              function(data) { mCallBack(data); },
              //mCallBack(data),
              '');
              break;
          default:
              jQuery.post('CallCloudyBo.ashx?' + mParams,
              { async: false, data: mParams, type: mClassNameSpace + '.' + mClassName + ';' + mLibName, method: mMethodname },
              function(data) { mCallBack(data); },
              //mCallBack(data),
              '');
              break;
      }
  }