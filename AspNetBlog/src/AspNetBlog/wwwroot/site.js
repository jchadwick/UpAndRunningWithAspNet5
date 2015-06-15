$(function () {

    $('.blog-main').on('click', 'nav a', function () {

        var link = $(this),
            url = link.attr('href');

        $('.blog-main').load(url);

        return false;

    });

});