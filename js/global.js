// JavaScript Document

$(function(){

	$(".nav dl").hover(function(){
		$(this).children("dd").show();	
	},function(){
		$(this).children("dd").hide();	
	});

});