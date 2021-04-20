
(function ($) {
    var imglist = []; //图片base64列表
    var imglist2 = []; //缩略图base64列表
    var i = [];  //图片数量

    $.fn.extend({

        "fileUpload": function (settings) {

            settings = $.extend({
                maxwidth: 800, //最大宽度限制
                MIME: 'image/jpeg', //输出类型
                multiple: 'multiple', //多选
                maxnum: 700, //可以上传的最大数量
                mapsel: 'map', //缩略图容器
                imgBox: "#img1", //图片缓存选择器
                imgBox2: "#img2", //缩略图缓存选择器
                fileInput: "file-input",
                index:0
            }, settings);  //使用jQuery.extend 覆盖插件默认参数
            imglist.push([]);
            imglist2.push([]);
            i.push([]);
            if (!($('input#' + settings.fileInput).length > 0 && $('canvas#canvas').length > 0)) {
                addele(this, settings.multiple, settings.fileInput);
            }
            var $file = $('#' + settings.fileInput);
            //触发选择文件
            $(document).on('click', this.selector, function () {
                if (i[settings.index] <settings.maxnum) {
                    $file.click();
                }
                
            });

            $file.on('change', function () {

                var fileList = this.files;

                if (fileList.length > settings.maxnum) {
                    alert("超过允许上传的限制: " + settings.maxnum);
                    return false;
                }

                //预览
                var reader = new FileReader();
                reader.readAsDataURL(fileList[0]);
                reader.onload = function (e) {
                    //$('#img').html('<img src="' + this.result + '" alt=""/>');
                    //$('#img').attr("src", this.result).attr("style", "margin: 0; max-width: 79px;max-height: 79px");
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
                
                for (var j = 0; j < imglist.length; j++) {
                    if (imglist[j] === $(this).prev().attr("src")) {
                        imglist.splice(j, 1);
                        $('#hidimg').val(imglist);
                    }
                }
            });
        }
    });

    //处理图片回调
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
        imglist[settings.index].push(base64);
        //裁剪
        var $canvas2 = $('#canvas2');
        var ctx2 = $canvas2[0].getContext('2d');
        $canvas2.attr({ width: 240, height: 160 });

        ctx2.drawImage($canvas[0], 0,0,240, 160);

        var base642 = $canvas2[0].toDataURL(settings.MIME);
        imglist2[settings.index].push(base642);
        //将图片base码缓存
        $(settings.imgBox).val(imglist[settings.index]);
        $(settings.imgBox2).val(imglist2[settings.index]);
        i[settings.index]++; //图片数量
        console.log(i[settings.index]);
        //预览
        console.log(settings.mapsel);
        document.getElementById(settings.mapsel).innerHTML += "<li><img src='" + base642 + "' style='margin: 0; max-width: 79px;max-height: 79px'/></li>";
    }


    //生成产生缩略图的容器
    function addele(thisObj, multiple, fileInput) {
        var $this = $(thisObj);
        var html = "<div style='display:none'><input id='" + fileInput+"' type='file' " + multiple + " accept='image/png,image/gif,image/jpeg'/>";
        html += "<canvas id='canvas'></canvas><canvas id='canvas2'></canvas>";
        html += "<textarea id='hidimg'></textarea></div>";
        $this.before(html);
    }
})(jQuery);