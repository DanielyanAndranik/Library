$(document).ready(function () {
	$('.toggle').click(function () {
		var panel = $('.right-side');
		if (panel.hasClass('closed')) {
			panel.removeClass('closed');
			setTimeout(function () {
				$('.toggle i').text('close');
			}, 500);
		}
		else {
			panel.addClass('closed');
			setTimeout(function () {
				$('.toggle i').text('menu');
			}, 500);
		}
	})

	$('.filter-toggle').click(function () {
		var filterBar = $('.filter-bar');
		if (filterBar.hasClass('closed')) {
			filterBar.removeClass('closed');
			setTimeout(function () {
				$('.filter-toggle i').text('keyboard_arrow_up');
			}, 500);
		}
		else {
			filterBar.addClass('closed');
			setTimeout(function () {
				$('.filter-toggle i').text('keyboard_arrow_down');
			}, 500);
		}
	})

	$('tbody').on('click', 'tr', function (event) {
		$(this).addClass('selected').siblings().removeClass('selected');
	});


});


