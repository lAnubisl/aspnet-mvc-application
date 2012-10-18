$(document).ready(function () {
    $('.categoriesTable tr, .productsTable tr, .consignmentLoadTable tr, .usersTable tr').each(function () {
        $(this).mouseover(function () {
            $(this).addClass('activeRow');
        });
        $(this).mouseout(function () {
            $(this).removeClass('activeRow');
        });
    });
})