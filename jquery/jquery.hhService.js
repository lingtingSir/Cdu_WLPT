// JavaScript Document

/**
 * jquery.hhService 左侧客服插件
 * User: huanhuan
 * QQ: 651471385
 * Email: th.wanghuan@gmail.com
 * 微博: huanhuan的天使
 * Data 2013-04-03
 * Dependence jquery-1.7.2.min.js
 * 参数 : float --> 悬浮方向[left or right]
 * minStatue --> 最小状态，只有show_btn
 * skin      --> 皮肤控制
 * durationTime --> 完成时间
 * web:https://github.com/huanhuan1989  
			 http://www.cnblogs.com/huanhuan1989/
 **/

;(function($){
    $.fn.fix = function(options){
      var defaults = {
	    	float : 'left',
				minStatue : false,
				skin : 'gray',
				durationTime : 1000	
    	}
	    var options = $.extend(defaults, options);		
	
	    this.each(function(){
	    	//获取对象
				var thisBox = $(this),
						closeBtn = thisBox.find('.close_btn' ),
						show_btn = thisBox.find('.show_btn' ),
						sideContent = thisBox.find('.side_content'),
						contentWidth = thisBox.find('.side_list').width(),
						sideList = thisBox.find('.side_list');	
				var defaultTop = thisBox.offset().top;	//对象的默认top	
				
				thisBox.css(options.float, 0);			
				if(options.minStatue){
					$(".show_btn").css("float", options.float);
					sideContent.css('width', 0);
					show_btn.css('width', 25);
				}
				//皮肤控制
				if(options.skin) thisBox.addClass('side_'+options.skin);
										
				//核心scroll事件			
				$(window).bind("scroll",function(){
					var offsetTop = defaultTop + $(window).scrollTop() + "px";
		      thisBox.animate({
		      	top: offsetTop
		      },
		      {
		      	duration: options.durationTime,	
		      	queue: false    //此动画将不进入动画队列
		      });
				});	
				
				//close事件
				closeBtn.bind("click",function(){
					sideContent.animate({width: '0'},"fast");
	      	show_btn.stop(true, true).delay(300).animate({ width: '33px'},"fast").css('float','right');
	        //thisBox.width(thisBox.find('.show_btn' ).width());
				});
				
				//show事件
				show_btn.click(function() {
					$(this).animate({width: '0px'},"fast");
		      thisBox.width(contentWidth);
		      sideContent.stop(true, true).delay(200).animate({ width: '167px'},"fast");
		    });
					
	    });	//end this.each
    };
})(jQuery);