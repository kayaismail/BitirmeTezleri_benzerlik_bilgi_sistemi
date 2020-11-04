$(document).ready(function () {
    var count = 1;

    $(".add").click(function () {
        count++;
        $("ul").append("<li class = \'item" + count + "\'>" +
            "<label for = \'item " + count + " \' title = 'Mark Complete'></label>" +
            "<input maxlength = '50' autofocus = 'autofocus' \
                    placeholder = 'Click to edit' class = \'item" + count + "-textbox\' />" +
            "<span class = 'icon-remove' title = 'Remove item'></span>" +
            "</li>");
        iconRemove();
    });

    iconRemove();
    function iconRemove() {
        $("[class*='icon-remove']").click(function () {
            $(this).parents("li[class*='item']").remove();

        });
    }

});