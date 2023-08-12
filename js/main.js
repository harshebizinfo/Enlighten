(function($) {

	"use strict";

	var fullHeight = function() {

		$('.js-fullheight').css('height', $(window).height());
		$(window).resize(function(){
			$('.js-fullheight').css('height', $(window).height());
		});

	};
	fullHeight();

	$('#sidebarCollapse').on('click', function () {
      $('#sidebar').toggleClass('active');
	});
	$('#childtb2 li').on('click', function () {
		
		$('.section.active').removeClass('active');
		$('#section-group2').addClass('active');
		//window.location.href = "AddTeacher.aspx";
	});
	//if ($('.section').hasClass('active')) { }

})(jQuery);
