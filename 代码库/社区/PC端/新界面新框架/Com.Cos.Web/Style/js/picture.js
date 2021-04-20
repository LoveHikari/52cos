(function ($) {
    $.fn.extend({

        "fileUpload": function (settings) {

            settings = $.extend({
                maxwidth: 800, //最大宽度限制
                MIME: 'image/jpeg', //输出类型
                multiple: 'multiple', //多选
                maxnum: 700, //可以上传的最大数量
                mapsel: '#map', //缩略图外层选择器
                imgBox: "ctb[attach-ids][]",
                insertSwitch: true
            }, settings);  //使用jQuery.extend 覆盖插件默认参数

            if (!($('input#file-input').length > 0 && $('canvas#canvas').length > 0)) {
                addele(this, settings.multiple);
            }
            //var $file = $('#file-input');
            ////触发选择文件
            //$(this).on('click', function () {
            //    $file.click();
            //});

            var imglist = [];
            var i = 0;
            $(this).on('change', function () {

                var fileList = this.files;

                if (fileList.length > settings.maxnum) {
                    alert("超过允许上传的限制: " + settings.maxnum);
                    return false;
                }

                var reader = new FileReader();
                reader.readAsDataURL(fileList[0]);
                reader.onload = function (e) {
                    //预览
                    //$('#img').html('<img src="' + this.result + '" alt=""/>');
                }

                //压缩

                $.each(fileList, function (index, value) {
                    var $img = new Image();
                    $img.src = window.URL.createObjectURL(value);
                    $img.onload = function () {
                        window.canvasUtil.rotateImg($img, name, [settings]);
                    }

                });

            });

            var o = settings.mapsel + " div";
            $(document).on("mouseover", o, function () { //出现删除
                $(".dispel", this).show();
            });
            $(document).on("mouseout", o, function () { //隐藏删除
                $(".dispel", this).hide();
            });
            //删除图片，同时删除list
            $(document).on('click', ".dispel", function () {
                $(this).parent("div").remove();
                console.info($(this).prev().attr("src"));
                for (var j = 0; j < imglist.length; j++) {
                    if (imglist[j] === $(this).prev().attr("src")) {
                        imglist.splice(j, 1);
                        $('#hidimg').val(imglist);
                    }
                }
            });
        }


    });

    function name(canvastemp, settings) {
        var width = canvastemp.width,
            height = canvastemp.height,
            scale = width / height;
        //if (width >= settings.maxwidth) {
        width = parseInt(settings.maxwidth);
        height = parseInt(width / scale);
        //} //当图片宽度大于maxwidth时压缩到maxwidth

        var $canvas = $('#canvas');
        var ctx = $canvas[0].getContext('2d');
        $canvas.attr({ width: width, height: height });
        ctx.drawImage(canvastemp, 0, 0, width, height);
        //压缩后的base码，可以传到后台保存
        var base64 = $canvas[0].toDataURL(settings.MIME);
        
        //裁剪
        var $canvas2 = $('#canvas2');
        var ctx2 = $canvas2[0].getContext('2d');
        $canvas2.attr({ width: 320, height: 180 });

        ctx2.drawImage($canvas[0], ($canvas[0].width - 320) / 2, ($canvas[0].height - 180) / 2, 320, 180, 0, 0, 320, 180);

        var base642 = $canvas2[0].toDataURL(settings.MIME);
        
        var id, id2;
        $.ajax({
            cache: false,  //是否读缓存
            type: "post",
            url: "/Service/HomeManage/UploadImgs.ashx",
            data: {
                b: base64,
                b2: base642
            },
            //dataType: "json",  //返回的类型
            async: false,  //是否异步
            success: function (res) {
                var msg = eval("(" + res + ")");
                if (msg.status == "success") {
                    id = msg.imgid;
                    id2 = msg.img2id;
                    base64 = msg.img;
                    base642 = msg.img2;
                } else {
                    swal("小2提醒您", "系统发生错误", "error");
                    //return false;
                }
            },
            error: function () {
                swal("小2提醒您", "系统繁忙，请稍后再试", "error");
                return false;
            }
        });

        //if (imglist.indexOf(base64) < 0) {
        //var h = '<div style="position: relative;float: left;"></div>';
        //$(settings.mapsel).append(h);
        //html = '<img src="' + base64 + '" alt="" style="width:105px;height: 105px;"/><a style="display: none;display:inline-block; width:18px;height:18px;position:absolute;right:0px; top:0px;" href="javascript:void(0);" class="dispel icono-crossCircle"></a>';
        //imglist.push(base64);
        //$('#hidimg').val(imglist);
        //console.info($('div a', settings.mapsel).length);
        //$($(settings.mapsel).children('div').get($('div a', settings.mapsel).length)).html(html);
        html = $(settings.mapsel).html();
        html += "<div id='img-12614' class='thumbnail-tpl g-phone-1-2 g-tablet-1-3 g-desktop-1-4' style='display: block;'>";
        html += "<a class='img-link' href='" + base64 + "' target='_blank' title='点击查看原图'>";
        html += "<img src='" + base642 + "' alt=''>";
        html += "</a>";
        if (settings.insertSwitch) {
            html += "<a href='javascript:;' class='btn btn-default btn-block ctb-insert-btn' id='ctb-insert-" + id + "' data-size='large' data-attach-page-url='#' data-width='440' data-height='616' data-large-url='" + base64 + "'>";
            html += "<i class='fa fa-plug'></i> 插入到文章</a>";
        }
        html += "<input type='radio' name='ctb[thumbnail-id]' id='img-thumbnail-" + id2 + "' value='" + id2 + "' hidden='' class='img-thumbnail-checkbox'>";
        html += "<label for='img-thumbnail-" + id2 + "' class='ctb-set-cover-btn'>";
        html += "<i class='fa fa-star'></i> 设为封面</label>";
        html += "<input type='hidden' name='" + settings.imgBox + "' value='" + id + "'></div>";
        $(settings.mapsel).html(html);
        i++;
        //}
    }


    //生成产生缩略图的容器
    function addele(thisObj, multiple) {
        var $this = $(thisObj);
        var html = "<div style='display:none'><input id='file-input' type='file' " + multiple + " accept='image/png,image/gif,image/jpeg'/>";
        html += "<canvas id='canvas'></canvas><canvas id='canvas2'></canvas>";
        html += "<textarea id='hidimg'></textarea></div>";
        $this.before(html);
    }
})(jQuery);