var delay = (function(){
  var timer = 0;
  return function(callback, ms){
    clearTimeout (timer);
    timer = setTimeout(callback, ms);
  };
})();
var desktop = true;
if ($(window).width() < 769) {
	desktop = false;
}
layout = function() {
	if(desktop) {
		var winHeight = $(document).height();
		$('#left-nav').height(winHeight);
	}
}
closeModal = function(){
	$('#overlay').fadeOut();
}
showModal = function(modal) {
	$('#overlay').fadeIn();
	$('.modal').hide();
	$('#' + modal).show();
}
$(window).scroll(function() {
	/*var user = $("#navscroll").offset();
	if($(this).scrollTop() > nav.top) {
		$("#navscroll").css({'top' : '20px', 'position' : 'fixed'});
	} else {
		
	} */

});
$(window).resize(function() {

	delay(function(){
	    layout();
       }, 300);
});
exportSVG = function(url) {
	location.href='/image.php?img=' + url + '&color=' + $('#colorInput').val();
}
changeSVG = function(color){
	var svg = $('#canvas-container').find('svg')[0];
	$('#canvas-container svg path').css('fill',color);
}
svgFit = function() {
	var svg = $('#canvas-container').find('svg')[0];
    var w = svg.getAttribute('width').replace('px', '');
    var h = svg.getAttribute('height').replace('px', '');

    svg.removeAttribute('width');
    svg.removeAttribute('height');

    svg.setAttribute('viewBox', '0 0 ' + w + ' ' + h);
	svg.setAttribute('preserveAspectRatio', 'xMinYMin meet');
	svg.setAttribute('width', '100%');
	svg.setAttribute('height', '100%');
}
var selected_icon_size = 512;
var list_icon_size = 64;
var list_font_size = 64;
var default_font_words = 'Enter words to preview';
$(document).ready(function() {
	layout();
	if($('#canvas-container').length) {
		svgFit();
	}
	$('#colorInput').change(function() {
		changeSVG('#' + $(this).val());
	});
	$('#fontColorInput').change(function() {
		$('#fonts .reverse .heading').css({'color': '#' + $(this).val()});
		$('#fonts .non-reverse').css({'background-color': '#' + $(this).val()});
	});
	$('#fontBgInput').change(function() {
		$('#fonts .reverse').css({'background-color': '#' + $(this).val()});
		$('#fonts .non-reverse .heading').css({'color': '#' + $(this).val()});
	});
	$('#fontWordInput').keyup(function() {
		if($(this).val() !== '') {
			$('#fonts .heading').html($(this).val());
		} else {
			$('#fonts .heading').html(default_font_words);
		}
	});
	$('#fontWordInput').blur(function() {
		layout();
		});
	$('#preview-group button').click(function(e) {
  		$('#preview-group button').removeClass('btn-primary').removeClass('active');
  		$(this).addClass('btn-primary').addClass('active');
  		list_icon_size = $(this).data('size');
  		$('#icons img').css({'width':list_icon_size + 'px','height':list_icon_size + 'px'});
  		layout();
	});
	$('#font-preview-group button').click(function(e) {
  		$('#font-preview-group button').removeClass('btn-primary').removeClass('active');
  		$(this).addClass('btn-primary').addClass('active');
  		list_font_size = $(this).data('size');
  		$('#fonts .heading').css({'font-size':list_font_size + 'px'});
  		layout();
	});
	$('#size-group button').click(function(e) {
  		$('#size-group button').removeClass('btn-primary').removeClass('active');
  		$(this).addClass('btn-primary').addClass('active');
  		selected_icon_size = $(this).data('size');
  		$('#icon-preview .image svg').css({'width':size + 'px','height':size + 'px'});
  		//console.log($(this).data());
	});
	$('#size-group button').hover(
	  function() {
	  	var preview_size = $(this).data('size');
  		$('#icon-preview .image svg').css({'width':preview_size + 'px','height':preview_size + 'px'});
	  }, function() {
  		$('#icon-preview .image svg').css({'width':selected_icon_size + 'px','height':selected_icon_size + 'px'});
	  }
	);
	var clone;
	$('#overlay').click(function(e) {
  		closeModal();
	});
	/*$(".icon a").hover(
 		function() {
 			offset = $(this).offset();
 			left = offset.left - 90;
 			var top = offset.top - 90;
    		clone = $(this).clone().appendTo(this).removeClass().addClass('icon-preview').css({'top': top +'px','left': left +'px'});
 	}, function() {
 		$(clone).remove();
 
  	});*/
});
