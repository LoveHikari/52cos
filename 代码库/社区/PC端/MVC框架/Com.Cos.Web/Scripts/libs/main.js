$(function () {
    $('img').on("error", function () {
        this.onerror = "";
        this.src = "http://img.52cos.cn/Upload/photo/gai2.jpg";

    });

    //$('.row1').adipoli({
    //    'startEffect': 'normal',
    //    'hoverEffect': 'popout'
    //});
    //$('.row2').adipoli({
    //    'startEffect': 'overlay',
    //    'hoverEffect': 'sliceDown'
    //});
    //$('.row3').adipoli({
    //    'startEffect': 'transparent',
    //    'hoverEffect': 'boxRandom'
    //});
    //$('.row4').adipoli({
    //    'startEffect': 'overlay',
    //    'hoverEffect': 'foldLeft'
    //});
    //$('.row5').adipoli({
    //    'startEffect': 'transparent',
    //    'hoverEffect': 'boxRainGrowReverse'
    //});
    //$('.row6').adipoli({
    //    'startEffect': 'grayscale',
    //    'hoverEffect': 'normal'
    //});

    function ba() {
        var h = $(window).height() / 3;
        t = $(document).scrollTop();
        if (t > h) {
            $('#fangi').fadeIn();
        } else {
            $('#fangi').fadeOut();
        }
    }

    ba();
    $('#fangi').click(function () {
        $(document).scrollTop(0);
    });
    $(window).scroll(function () {
        ba();
    });
    $('.cinpin .topd .lefts').mouseover(function () {
        $(this).addClass('on');
    });
    $('.cinpin .topd .lefts').mouseout(function () {
        $(this).removeClass('on');
    });
    $('.check em').click(function () {
        if ($(this).find('img').is(":visible")) {
            $(this).find('img').hide();
        } else {
            $(this).find('img').show();
        }
    });
    $('.idont,.lilist').mouseover(function () {
        $('.lilist').show();
    });
    $('.idont,.lilist').mouseout(function () {
        setTimeout(function() { $('.lilist').hide() },3000);
    });
    $('.idont').click(function () {
        console.log($('.lilist').css("display"));
        if ($('.lilist').css("display") == "none") {
            $('.lilist').css("display", "block");
        } else {
            $('.lilist').css("display", "none");
        }
    });
    $(".yuhuanqu li:nth-child(4n+1)").css('margin-left', '0');
    $('.corporation .part1 img.img-style').height($('.corporation .part1').width() * 0.89);
    $('.lefttwenty').height($('.lefttwenty').width() * 1.45);
    $('.conens .cetnrs img').height($('.lefttwenty').width() * 1.39);

});

var swalAlert = {
    /**
     * 自动关闭的对话框
     * @param {} title 标题
     * @param {} text 提示文本
     * @param {} timer 时间
     * @param {} type 模式类型
     * @param {} showConfirmButton 是否显示按钮
     * @returns {} 
     */
    swalAlert: function (title, text, timer, type, showConfirmButton) {
        return  swal({
            title: title,
            text: text,
            timer: timer,
            type: type,
            showConfirmButton: showConfirmButton
        }).catch(swal.noop);

    }
};