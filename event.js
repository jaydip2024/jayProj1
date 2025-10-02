$(document).ready(function () {
    $('#sname').focus(function () {
        $(this).css('background-color', 'lime');
    })
    $('#sname,#sdate').blur(function () {
        $(this).css('background-color', '');
    })
    $('#sname').change(function () {
        $(this).css('background-color', 'pink');
    })
    
})