function pushMessage(t) {
    var mes = 'Info|Implement independently';
    $.Notify({
        caption: mes.split("|")[0],
        content: mes.split("|")[1],
        type: t
    });
}

$(function () {
    $('.sidebar').on('click', 'li', function () {
        if (!$(this).hasClass('active')) {
            $('.sidebar li').removeClass('active');
            $(this).addClass('active');
        }
    })
})
function showNotifyDefault(content,type) {
    showNotify('', content, type, true, 7000, false, '', '');
}
function showNotify(caption, content, type, shadow, timeout, keepOpen, style, icon) {
    $.Notify({
        caption: caption,
        content: content,
        type: type,
        shadow: shadow,
        timeout: timeout,
        keepOpen: keepOpen,
        style: style,
        icon: icon
    });
}
function showDialog(id) {
    var dialog = $(id).data('dialog');
    dialog.open();
}
