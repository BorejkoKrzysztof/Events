
// SHOW HIDDEN MENU 
$('.toggleButton').on('click', function () {
    $('.buttonElement:nth-child(1)')
        .toggleClass('activeToggleButtonSpan1');

    $('.buttonElement:nth-child(2)')
        .toggleClass('activeToggleButtonSpan2');

    $('.buttonElement:nth-child(3)')
        .toggleClass('activeToggleButtonSpan3');

    $('.hiddenMenu').toggleClass('activeHiddenMenu');
});

// SHOW DESCRIPTION ITEMS ON MAIN PAGE 
function scrollHide() {
    const windowHeight = $(window).height();
    const scrollValue = $(document).scrollTop();

    const $secondDescriptionItem = $('div.index div p.subtitle:nth-child(2)');
    const secondDescriptionItemFromTop = $secondDescriptionItem.offset().top
    const secondDescriptionHeight = $secondDescriptionItem.outerHeight();

    const $thirdDescriptionItem = $('div.index div p.subtitle:nth-child(3)');
    const thirdDescriptionItemFromTop = $thirdDescriptionItem.offset().top
    const thirdDescriptionHeight = $thirdDescriptionItem.outerHeight();

    const $fourthDescriptionItem = $('div.index div p.subtitle:nth-child(4)');
    const fourthDescriptionItemFromTop = $fourthDescriptionItem.offset().top
    const fourthDescriptionHeight = $fourthDescriptionItem.outerHeight();

    if (scrollValue > thirdDescriptionItemFromTop + thirdDescriptionHeight - windowHeight) {
        $thirdDescriptionItem.addClass('active');
    }

    if (scrollValue > secondDescriptionItemFromTop + secondDescriptionHeight - windowHeight) {
        $secondDescriptionItem.addClass('active');
    }

    if (scrollValue > fourthDescriptionItemFromTop + fourthDescriptionHeight - windowHeight) {
        $fourthDescriptionItem.addClass('active');
    }
}

$(document).on('scroll', scrollHide);