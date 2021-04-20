<%@ Page Title="" Language="C#" ValidateRequest="false" MasterPageFile="~/Pages/App_Master/AccountMaster.master" AutoEventWireup="true" CodeBehind="Contributions.aspx.cs" Inherits="Com.Cos.Web.Pages.HomeManage.Contributions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Style/css/frontend-logged-default.css" rel="stylesheet" />
    <script src="/plugins/sweetalert/sweetalert.min.js"></script>
    <link href="/plugins/sweetalert/sweetalert.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="form" runat="server">
    <!--说明-->
    <div class="well">
        <font size="3px"><strong><font color="red"><p> 投稿须知</p> </font></strong></font>
        <font size="2px"><strong><font color="red"><p>1.投稿勿直接传压缩包，可以填写链接在下方 </p></font> </strong></font>
        <font size="2px"><strong><font color="red"><p>2.r18以及露点内容需打码，请特别注意 </p> </font></strong> </font>
        <font size="2px"><strong><font color="red"><p>3.传完图之后，请务必点击批量插入文章内，切记 </p> </font></strong></font>
        <font size="2px"><strong><font color="red"><p>3.传完图之后，请务必点击批量插入文章内，切记</p> </font></strong></font>
        <font size="2px"><strong><font color="red"><p>重要事情说2遍</p> </font></strong></font>
        <font size="2px"><strong><font color="red">投稿音乐，可用网易音乐，在文章插入代码 [hermit auto="1" loop="0" unexpand="0" fullheight="1"]netease_songs#:网易音乐id[/hermit]</font></strong></font>
    </div>
    <!---->

<%--    <div id="fm-ctb-loading" class="page-tip">
        <div class="tip-status tip-status-small tip-status-loading"><i class="fa fa-loading fa-fw"></i></div>
    </div>--%>

    <form id="fm-ctb" class="form-horizontal" method="post" action="/Service/HomeManage/SaveContributions.ashx">
        <div class="form-group">
        <div class="g-tablet-1-6 control-label">
                <i class="fa fa-truck"></i>
                类别
            </div>
            <div class="g-tablet-5-6">
                <label class="radio-inline" for="theme_custom_post_source-source-works">
                    <input type="radio" name="theme_custom_post_source[type]" id="theme_custom_post_source-source-works" value="works" class="theme_custom_post_source-source-radio" checked target="theme_custom_post_source-input-works">
                    作品
                </label>
                <label class="radio-inline" for="theme_custom_post_source-source-cooperation">
                    <input type="radio" name="theme_custom_post_source[type]" id="theme_custom_post_source-source-cooperation" value="reprint" class="theme_custom_post_source-source-radio" target="theme_custom_post_source-input-cooperation">
                    合作
                </label>
                <label class="radio-inline" for="theme_custom_post_source-source-activity">
                    <input type="radio" name="theme_custom_post_source[type]" id="theme_custom_post_source-source-activity" value="activity" class="theme_custom_post_source-source-radio" target="theme_custom_post_source-input-activity">
                    活动
                </label>
            </div>
            </div>
        <div class="form-group">
            <label for="ctb-title" class="g-tablet-1-6 control-label">
                文章标题
            </label>
            <div class="g-tablet-5-6">
                <input type="text" name="ctb[post-title]" class="form-control" id="ctb-title" placeholder="文章标题（必填）" title="文章标题必须填写哦" value="" required autofocus>
            </div>
        </div>
        <div class="form-group">
            <label for="ctb-excerpt" class="g-tablet-1-6 control-label">
                文章摘要
            </label>
            <div class="g-tablet-5-6">
                <textarea name="ctb[post-excerpt]" id="ctb-excerpt" rows="3" class="form-control" placeholder="您可以在这里填写摘要向大家简单介绍一下，如果是分页的话将会显示在每页的顶部。"></textarea>
            </div>
        </div>
        <div class="form-group">
            <div class="g-tablet-1-1">
                <label for="ctb-content">
                    文章内容
                </label>
                <div id="wp-ctb-content-wrap" class="wp-core-ui wp-editor-wrap tmce-active">
                    <link rel='stylesheet' id='editor-buttons-css' href='/Style/css/editor.min.css' type='text/css' media='all' />
                    <div id="wp-ctb-content-editor-tools" class="wp-editor-tools hide-if-no-js">
                        <div class="wp-editor-tabs">
                            <button type="button" id="ctb-content-tmce" class="wp-switch-editor switch-tmce" data-wp-editor-id="ctb-content">可视化</button>
                            <button type="button" id="ctb-content-html" class="wp-switch-editor switch-html" data-wp-editor-id="ctb-content">文本</button>
                        </div>
                    </div>
                    <div id="wp-ctb-content-editor-container" class="wp-editor-container">
                        <div id="qt_ctb-content_toolbar" class="quicktags-toolbar"></div>
                        <textarea class="form-control wp-editor-area" rows="20" autocomplete="off" cols="40" name="ctb[post-content]" id="ctb-content"></textarea>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="g-tablet-1-6 control-label">
                <i class="fa fa-image"></i>
                上传预览图
            </div>
            <div class="g-tablet-5-6">
                <div id="ctb-file-area">
                    <div class="" id="ctb-file-btn">
                        <i class="fa fa-upload"></i>
                        选择或拖放图片
                            <input type="file" id="ctb-file" multiple>
                    </div>
                </div>
                <div id="ctb-file-progress-container" class="progress">
                    <div id="ctb-file-progress" class="progress-bar progress-bar-success progress-bar-striped active"></div>
                </div>
                <div id="ctb-file-tool" class="row">
                    <div class="g-tablet-1-2">
                        <a href="javascript:;" id="ctb-batch-insert-btn" class="btn btn-primary btn-block">
                            <i class="fa fa-plug"></i>批量将图片插入到文章内容 </a>
                    </div>
                    <%--<div class="g-tablet-1-2">
                        <select id="ctb-split-number" class="form-control" title="每页显示多少张图片？">
                            <option value="0">不使用图片分页符</option>
                            <option value="1">1 张图片 / 每页</option>
                            <option value="2">2 张图片 / 每页</option>
                            <option value="3">3 张图片 / 每页</option>
                            <option value="4">4 张图片 / 每页</option>
                            <option value="5">5 张图片 / 每页</option>
                            <option value="6">6 张图片 / 每页</option>
                            <option value="7">7 张图片 / 每页</option>
                            <option value="8">8 张图片 / 每页</option>
                            <option value="9">9 张图片 / 每页</option>
                            <option value="10">10 张图片 / 每页</option>
                        </select>
                    </div>--%>
                </div>
                <div id="ctb-file-completion"></div>
                <div id="ctb-files" class="row" style="display: block;">
                </div>
            </div>
        </div>
        <%--<div class="form-group theme_custom_storage-group">
            <div class="g-tablet-1-6 control-label">
                <i class="fa fa-cloud-download"></i>
                网盘链接
            </div>
            <div class="g-tablet-5-6">
                <div id="theme_custom_storage-container" data-tpl="&lt;div class=&quot;theme_custom_storage-item item&quot; id=&quot;theme_custom_storage-item-%placeholder%&quot; data-placeholder=&quot;%placeholder%&quot;&gt;&lt;a href=&quot;javascript:;&quot; class=&quot;del&quot; title=&quot;删除此条目&quot; data-target=&quot;theme_custom_storage-item-%placeholder%&quot;&gt;&lt;i class=&quot;fa fa-times&quot;&gt;&lt;/i&gt;&lt;/a&gt;&lt;div class=&quot;row&quot;&gt;&lt;div class=&quot;g-tablet-1-5&quot;&gt;&lt;input type=&quot;text&quot; name=&quot;theme_custom_storage[%placeholder%][name]&quot; id=&quot;theme_custom_storage-%placeholder%-name&quot; class=&quot;form-control&quot; placeholder=&quot;名称（可选）&quot; title=&quot;名称（可选）&quot; value=&quot;&quot; &gt;&lt;/div&gt;&lt;div class=&quot;g-tablet-2-5&quot;&gt;&lt;input type=&quot;text&quot; class=&quot;form-control&quot; name=&quot;theme_custom_storage[%placeholder%][url]&quot; id=&quot;theme_custom_storage-%placeholder%-url&quot; title=&quot;下载页面的 URL (包括 http://)&quot; placeholder=&quot;下载页面的 URL (包括 http://)&quot; value=&quot;&quot; &gt;&lt;/div&gt;&lt;div class=&quot;g-tablet-1-5&quot;&gt;&lt;input type=&quot;text&quot; class=&quot;form-control&quot; name=&quot;theme_custom_storage[%placeholder%][download-pwd]&quot; id=&quot;theme_custom_storage-%placeholder%-download-pwd&quot; title=&quot;提取码（可选）&quot; placeholder=&quot;提取码（可选）&quot; value=&quot;&quot; &gt;&lt;/div&gt;&lt;div class=&quot;g-tablet-1-5&quot;&gt;&lt;input type=&quot;text&quot; class=&quot;form-control&quot; name=&quot;theme_custom_storage[%placeholder%][extract-pwd]&quot; id=&quot;theme_custom_storage-%placeholder%-extract-pwd&quot; title=&quot;解压密码（可选）&quot; placeholder=&quot;解压密码（可选）&quot; value=&quot;&quot; &gt;&lt;/div&gt;&lt;/div&gt;&lt;/div&gt;">
                    <div class="theme_custom_storage-item item" id="theme_custom_storage-item-0" data-placeholder="0">
                        <a href="javascript:;" class="del" title="删除此条目" data-target="theme_custom_storage-item-0"><i class="fa fa-times"></i></a>
                        <div class="row">
                            <div class="g-tablet-1-5">
                                <input type="text" name="theme_custom_storage[0][name]" id="theme_custom_storage-0-name" class="form-control" placeholder="名称（可选）" title="名称（可选）" value="">
                            </div>
                            <div class="g-tablet-2-5">
                                <input type="text" class="form-control" name="theme_custom_storage[0][url]" id="theme_custom_storage-0-url" title="下载页面的 URL (包括 http://)" placeholder="下载页面的 URL (包括 http://)" value="">
                            </div>
                            <div class="g-tablet-1-5">
                                <input type="text" class="form-control" name="theme_custom_storage[0][download-pwd]" id="theme_custom_storage-0-download-pwd" title="提取码（可选）" placeholder="提取码（可选）" value="">
                            </div>
                            <div class="g-tablet-1-5">
                                <input type="text" class="form-control" name="theme_custom_storage[0][extract-pwd]" id="theme_custom_storage-0-extract-pwd" title="解压密码（可选）" placeholder="解压密码（可选）" value="">
                            </div>
                        </div>
                    </div>
                </div>
                <div id="theme_custom_storage-control">
                    <a href="javascript:;" id="theme_custom_storage-add" class="add btn btn-block btn-primary"><i class="fa fa-plus"></i>添加新链接</a>
                </div>
            </div>
        </div>--%>
        <div class="form-group">
            <div class="g-tablet-1-6 control-label">
                <i class="fa fa-folder-open"></i>
                分类
            </div>
            <div class="g-tablet-5-6" id="ctb-cat-container">
                <select name="ctb[cats][]" class="ctb-cat form-control" required="" id="noteType1">
                    <asp:Literal runat="server" ID="litType1"></asp:Literal>
                </select>
            </div>
        </div>
        <div class="form-group">
            <div class="g-tablet-1-6 control-label">
                <i class="fa fa-tags"></i>
                热门标签
            </div>
            <div class="g-tablet-5-6">
                <div class="checkbox-select">
                    <label class="ctb-tag" for="ctb-tags-21">
                        <input class="ctb-preset-tag" type="checkbox" id="ctb-tags-21" name="ctb[tags][]" value="精选" hidden>
                        <span class="label label-default">精选 </span>
                    </label>
                    <label class="ctb-tag" for="ctb-tags-24">
                        <input class="ctb-preset-tag" type="checkbox" id="ctb-tags-24" name="ctb[tags][]" value="绘画" hidden>
                        <span class="label label-default">绘画 </span>
                    </label>
                    <label class="ctb-tag" for="ctb-tags-19">
                        <input class="ctb-preset-tag" type="checkbox" id="ctb-tags-19" name="ctb[tags][]" value="插画" hidden>
                        <span class="label label-default">插画 </span>
                    </label>
                    <label class="ctb-tag" for="ctb-tags-28">
                        <input class="ctb-preset-tag" type="checkbox" id="ctb-tags-28" name="ctb[tags][]" value="萝莉" hidden>
                        <span class="label label-default">萝莉 </span>
                    </label>
                    <label class="ctb-tag" for="ctb-tags-27">
                        <input class="ctb-preset-tag" type="checkbox" id="ctb-tags-27" name="ctb[tags][]" value="福利" hidden>
                        <span class="label label-default">福利 </span>
                    </label>
                    <label class="ctb-tag" for="ctb-tags-23">
                        <input class="ctb-preset-tag" type="checkbox" id="ctb-tags-23" name="ctb[tags][]" value="教程" hidden>
                        <span class="label label-default">教程 </span>
                    </label>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="g-tablet-1-6 control-label">
                <i class="fa fa-tag"></i>
                自定义标签
            </div>
            <div class="g-tablet-5-6">
                <div class="row">
                    <div class="g-phone-1-2 g-tablet-1-4">
                        <input id="ctb-custom-tag-0" class="ctb-custom-tag form-control" type="text" name="ctb[tags][]" placeholder="自定义标签 1">
                    </div>
                    <div class="g-phone-1-2 g-tablet-1-4">
                        <input id="ctb-custom-tag-1" class="ctb-custom-tag form-control" type="text" name="ctb[tags][]" placeholder="自定义标签 2">
                    </div>
                    <div class="g-phone-1-2 g-tablet-1-4">
                        <input id="ctb-custom-tag-2" class="ctb-custom-tag form-control" type="text" name="ctb[tags][]" placeholder="自定义标签 3">
                    </div>
                    <div class="g-phone-1-2 g-tablet-1-4">
                        <input id="ctb-custom-tag-3" class="ctb-custom-tag form-control" type="text" name="ctb[tags][]" placeholder="自定义标签 4">
                    </div>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="g-tablet-1-6 control-label">
                <i class="fa fa-cube"></i>
                来源
            </div>
            <div class="g-tablet-5-6">
                <label class="radio-inline" for="theme_custom_post_source-source-original">
                    <input type="radio" name="theme_custom_post_source[source]" id="theme_custom_post_source-source-original" value="original" class="theme_custom_post_source-source-radio" checked target="theme_custom_post_source-input-original">
                    原创
                </label>
                <label class="radio-inline" for="theme_custom_post_source-source-reprint">
                    <input type="radio" name="theme_custom_post_source[source]" id="theme_custom_post_source-source-reprint" value="reprint" class="theme_custom_post_source-source-radio" target="theme_custom_post_source-input-reprint">
                    转载
                </label>
                <div class="row theme_custom_post_source-inputs" id="theme_custom_post_source-input-reprint">
                    <div class="g-tablet-1-2">
                        <div class="input-group">
                            <label class="addon" for="theme_custom_post_source-reprint-url">
                                <i class="fa fa-link"></i>
                            </label>
                            <input type="url" class="form-control" name="theme_custom_post_source[reprint][url]" id="theme_custom_post_source-reprint-url" placeholder="作品的来源地址，包括 http://" title="作品的来源地址，包括 http://" value="">
                        </div>
                    </div>
                    <div class="g-tablet-1-2">
                        <div class="input-group">
                            <label class="addon" for="theme_custom_post_source-reprint-author">
                                <i class="fa fa-user"></i>
                            </label>
                            <input type="text" class="form-control" name="theme_custom_post_source[reprint][author]" id="theme_custom_post_source-reprint-author" placeholder="作者" title="作者" value="">
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="g-tablet-1-6">
                <%--<a href="javascript:;" id="ctb-quick-save" class="btn btn-block btn-default btn-lg" title="该文章数据会在您当前的浏览器中，每分钟自动保存一次，您也可以手动进行保存。">
                    <i class="fa fa-save"></i>快速保存 </a>--%>
            </div>
            <div class="g-tablet-5-6">
                <button type="submit" class="btn btn-lg btn-success btn-block submit" data-loading-text="数据发送中，请稍候…">
                    <i class="fa fa-check"></i>
                    提交
                </button>
                <input type="hidden" id="ctb-post-id" name="post-id" value="0">
                <input type="hidden" name="type" value="post">
            </div>
        </div>
    </form>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
    <script>var active_menu="文章投稿"</script>
    <script>window.THEME_CONFIG = { "vars": { "locale": "zh_CN", "iden": "mx", "process_url": "" }, "lang": { "M01": "\u52a0\u8f7d\u4e2d\uff0c\u8bf7\u7a0d\u5019\u2026", "E01": "\u62b1\u6b49\uff0c\u670d\u52a1\u5668\u6b63\u5fd9\uff0c\u65e0\u6cd5\u54cd\u5e94\u4f60\u7684\u8bf7\u6c42\uff0c\u8bf7\u7a0d\u5019\u91cd\u8bd5\u3002" }, "theme_custom_contribution": { "process_url": "/Service/HomeManage/Handler1.ashx", "default_size": "large", "lang": { "M01": "\u52a0\u8f7d\u4e2d\uff0c\u8bf7\u7a0d\u5019\u2026", "M02": "\u6b63\u5728\u4e0a\u4f20 {0}\/{1}\uff0c\u8bf7\u7a0d\u5019\u2026", "M03": "\u70b9\u51fb\u5220\u9664\u6b64\u5f20\u56fe\u7247", "M04": "{0} \u4e2a\u6587\u4ef6\u4e0a\u4f20\u6210\u529f\uff0c\u8bf7\u6309\u9700\u9009\u62e9\u63d2\u5165\u5230\u6587\u7ae0\u5185\u5bb9\u3002", "M05": "\u6765\u6e90", "M06": "\u70b9\u51fb\u67e5\u770b\u539f\u56fe", "M07": "\u8bbe\u4e3a\u5c01\u9762", "M08": "\u53ef\u9009\uff0c\u5199\u4e0b\u4e00\u4e9b\u63cf\u8ff0\u5427", "M09": "\u63d2\u5165\u5230\u6587\u7ae0", "M10": "\u9884\u89c8\u56fe", "M11": "\u5927\u5c3a\u5bf8", "M12": "\u4e2d\u5c3a\u5bf8", "M13": "\u5c0f\u5c3a\u5bf8", "E01": "\u62b1\u6b49\uff0c\u670d\u52a1\u5668\u6b63\u5fd9\uff0c\u65e0\u6cd5\u54cd\u5e94\u4f60\u7684\u8bf7\u6c42\uff0c\u8bf7\u7a0d\u5019\u91cd\u8bd5\u3002", "M14": "\u9009\u62e9\u7c7b\u522b" }, "auto_save": { "lang": { "M01": "\u4f60\u6709\u81ea\u52a8\u4fdd\u5b58\u7248\u672c\uff0c\u9700\u8981\u8fd8\u539f\u5230\u8be5\u7248\u672c\u5417?\u6700\u540e\u4e00\u6b21\u81ea\u52a8\u4fdd\u5b58\u7684\u65f6\u95f4\u662f  {time} \u3002", "M02": "\u6062\u590d\u6587\u7ae0\u6570\u636e\u5b8c\u6bd5\uff0c\u8bf7\u68c0\u67e5\u3002", "M03": "\u6587\u7ae0\u6570\u636e\u5df2\u6210\u529f\u4fdd\u5b58\u5230\u60a8\u7684\u6d4f\u89c8\u5668\u4e2d\u3002" } }, "cats": { "15": { "term_id": 15, "parent": 0, "name": "ACG\u52a8\u753b\u00b7\u756a\u5267", "description": "" }, "386": { "term_id": 386, "parent": 0, "name": "ACG\u6e38\u620f", "description": "" }, "7": { "term_id": 7, "parent": 0, "name": "ACG\u8d44\u8baf", "description": "" }, "11": { "term_id": 11, "parent": 0, "name": "ACG\u97f3\u4e50", "description": "" }, "14": { "term_id": 14, "parent": 6, "name": "COS\u56fe\u96c6", "description": "" }, "25": { "term_id": 25, "parent": 6, "name": "GIF\u52a8\u56fe", "description": "" }, "543": { "term_id": 543, "parent": 15, "name": "OAD\u00b7OVA\u00b7\u5267\u573a\u7248", "description": "" }, "115": { "term_id": 115, "parent": 0, "name": "video", "description": "" }, "5": { "term_id": 5, "parent": 3, "name": "\u4e09\u6b21\u5143\u7ec5\u58eb", "description": "" }, "111": { "term_id": 111, "parent": 3, "name": "\u4e8c&amp;\u4e09\u6b21\u5143-\u7ec5\u58eb\u89c6\u9891", "description": "" }, "4": { "term_id": 4, "parent": 3, "name": "\u4e8c\u6b21\u5143\u7ec5\u58eb", "description": "" }, "163": { "term_id": 163, "parent": 5, "name": "\u5199\u771f", "description": "" }, "6": { "term_id": 6, "parent": 0, "name": "\u52a8\u6f2b\u56fe\u96c6", "description": "" }, "8": { "term_id": 8, "parent": 7, "name": "\u52a8\u6f2b\u8d44\u8baf", "description": "" }, "16": { "term_id": 16, "parent": 15, "name": "\u52a8\u753b\u9884\u544a", "description": "" }, "189": { "term_id": 189, "parent": 99, "name": "\u539f\u521b\u624b\u7ed8", "description": "" }, "188": { "term_id": 188, "parent": 99, "name": "\u539f\u521b\u677f\u7ed8", "description": "" }, "99": { "term_id": 99, "parent": 6, "name": "\u539f\u521b\u7ed8\u753b", "description": "" }, "12": { "term_id": 12, "parent": 11, "name": "\u540c\u4eba\u97f3\u4e50", "description": "" }, "17": { "term_id": 17, "parent": 15, "name": "\u5b8c\u7ed3\u52a8\u753b", "description": "" }, "1": { "term_id": 1, "parent": 0, "name": "\u672a\u5206\u7c7b", "description": "" }, "565": { "term_id": 565, "parent": 3, "name": "\u6b21\u5143\u5996\u7cbe", "description": "" }, "388": { "term_id": 388, "parent": 386, "name": "\u6e38\u620fCG", "description": "" }, "387": { "term_id": 387, "parent": 386, "name": "\u6e38\u620f\u8d44\u6e90", "description": "" }, "9": { "term_id": 9, "parent": 7, "name": "\u6e38\u620f\u8d44\u8baf", "description": "" }, "322": { "term_id": 322, "parent": 0, "name": "\u6f2b\u753b", "description": "" }, "225": { "term_id": 225, "parent": 3, "name": "\u6f2b\u753b\u672c\u5b50\uff08R18)", "description": "" }, "327": { "term_id": 327, "parent": 322, "name": "\u6f2b\u753b\u7efc\u5408", "description": "" }, "10": { "term_id": 10, "parent": 6, "name": "\u753b\u96c6\u753b\u518c", "description": "" }, "572": { "term_id": 572, "parent": 3, "name": "\u7ec5\u58ebcos\u3010\u9ad8\u7ea7\u4f1a\u5458\u4e13\u4eab\u3011", "description": "" }, "3": { "term_id": 3, "parent": 0, "name": "\u7ec5\u58eb\u9053", "description": "" }, "191": { "term_id": 191, "parent": 6, "name": "\u7ed8\u753b\u6559\u7a0b", "description": "" }, "164": { "term_id": 164, "parent": 5, "name": "\u80d6\u6b21", "description": "" }, "165": { "term_id": 165, "parent": 5, "name": "\u817f\u63a7\u4e1d\u889c", "description": "" }, "542": { "term_id": 542, "parent": 15, "name": "\u8fde\u8f7d\u52a8\u753b", "description": "" }, "326": { "term_id": 326, "parent": 322, "name": "\u8fde\u8f7d\u6f2b\u753b", "description": "" }, "13": { "term_id": 13, "parent": 11, "name": "\u97f3\u4e50\u9009\u96c6", "description": "" } } } };</script>
    <link rel='stylesheet' id='buttons-css' href='/Style/css/buttons.min.css' type='text/css' media='all' />
    <script type='text/javascript' src='/Style/js/frontend-entry-logged.js'></script>
    <%--<script type='text/javascript'>var userSettings = { "url": "\/", "uid": "37", "time": "1465009249", "secure": "" };</script>--%>
    <script type='text/javascript' src='/Style/js/utils.min.js'></script>
    <%--<script type='text/javascript' src='http://www.91moe.com/wp-admin/js/editor.min.js?ver=4.4.3'></script>
    <script type='text/javascript'>var quicktagsL10n = { "closeAllOpenTags": "\u5173\u95ed\u6240\u6709\u6253\u5f00\u7684\u6807\u7b7e", "closeTags": "\u5173\u95ed\u6807\u7b7e", "enterURL": "\u8f93\u5165URL", "enterImageURL": "\u8f93\u5165\u56fe\u50cfURL", "enterImageDescription": "\u4e3a\u56fe\u50cf\u8f93\u5165\u63cf\u8ff0", "textdirection": "\u6587\u672c\u65b9\u5411", "toggleTextdirection": "\u5207\u6362\u7f16\u8f91\u5668\u6587\u672c\u4e66\u5199\u65b9\u5411", "dfw": "\u514d\u6253\u6270\u5199\u4f5c\u6a21\u5f0f", "strong": "\u7c97\u4f53", "strongClose": "\u5173\u95ed\u7c97\u4f53\u6807\u7b7e", "em": "\u659c\u4f53", "emClose": "\u5173\u95ed\u659c\u4f53\u6807\u7b7e", "link": "\u63d2\u5165\u94fe\u63a5", "blockquote": "\u5757\u5f15\u7528", "blockquoteClose": "\u5173\u95ed\u5757\u5f15\u7528\u6807\u7b7e", "del": "\u5220\u9664\u7684\u6587\u5b57\uff08\u5220\u9664\u7ebf\uff09", "delClose": "\u5173\u95ed\u5220\u9664\u7ebf\u6807\u7b7e", "ins": "\u63d2\u5165\u7684\u6587\u5b57", "insClose": "\u5173\u95ed\u63d2\u5165\u7684\u6587\u5b57\u6807\u7b7e", "image": "\u63d2\u5165\u56fe\u50cf", "ul": "\u9879\u76ee\u7b26\u53f7\u5217\u8868", "ulClose": "\u5173\u95ed\u9879\u76ee\u7b26\u53f7\u5217\u8868\u6807\u7b7e", "ol": "\u7f16\u53f7\u5217\u8868", "olClose": "\u5173\u95ed\u7f16\u53f7\u5217\u8868\u6807\u7b7e", "li": "\u5217\u8868\u9879\u76ee", "liClose": "\u5173\u95ed\u5217\u8868\u9879\u76ee\u6807\u7b7e", "code": "\u4ee3\u7801", "codeClose": "\u5173\u95ed\u4ee3\u7801\u6807\u7b7e", "more": "\u63d2\u5165\u201cMore\u201d\u6807\u7b7e" };</script>
    <script type='text/javascript' src='http://www.91moe.com/wp-includes/js/quicktags.min.js?ver=4.4.3'></script>
    <script type='text/javascript'>var wpLinkL10n = { "title": "\u63d2\u5165\u6216\u7f16\u8f91\u94fe\u63a5", "update": "\u66f4\u65b0", "save": "\u6dfb\u52a0\u94fe\u63a5", "noTitle": "(\u65e0\u6807\u9898)", "noMatchesFound": "\u672a\u627e\u5230\u7ed3\u679c\u3002" };</script>
    <script type='text/javascript' src='http://www.91moe.com/wp-includes/js/wplink.min.js?ver=4.4.3'></script>
    <script type="text/javascript">tinyMCEPreInit = {
    baseURL: "http://www.91moe.com/wp-includes/js/tinymce", suffix: ".min", mceInit: { 'ctb-content': { theme: "modern", skin: "lightgray", language: "zh", formats: { alignleft: [{ selector: "p,h1,h2,h3,h4,h5,h6,td,th,div,ul,ol,li", styles: { textAlign: "left" } }, { selector: "img,table,dl.wp-caption", classes: "alignleft" }], aligncenter: [{ selector: "p,h1,h2,h3,h4,h5,h6,td,th,div,ul,ol,li", styles: { textAlign: "center" } }, { selector: "img,table,dl.wp-caption", classes: "aligncenter" }], alignright: [{ selector: "p,h1,h2,h3,h4,h5,h6,td,th,div,ul,ol,li", styles: { textAlign: "right" } }, { selector: "img,table,dl.wp-caption", classes: "alignright" }], strikethrough: { inline: "del" } }, relative_urls: false, remove_script_host: false, convert_urls: false, browser_spellcheck: true, fix_list_elements: true, entities: "38,amp,60,lt,62,gt", entity_encoding: "raw", keep_styles: false, cache_suffix: "wp-mce-4208-20151113", preview_styles: "font-family font-size font-weight font-style text-decoration text-transform", end_container_on_empty_block: true, wpeditimage_disable_captions: false, wpeditimage_html5_captions: false, plugins: "charmap,colorpicker,hr,lists,media,paste,tabfocus,textcolor,fullscreen,wordpress,wpautoresize,wpeditimage,wpemoji,wpgallery,wplink,wpdialogs,wptextpattern,wpview,wpembed,image", wp_lang_attr: "zh-CN", external_plugins: { "mukiotag": "http:\/\/www.91moe.com\/wp-content\/plugins\/mukioplayer-for-wordpress\/static\/mukio-tag.js", "mukiomd5": "http:\/\/www.91moe.com\/wp-content\/plugins\/mukioplayer-for-wordpress\/static\/jquery.md5.js", "code": "http:\/\/www.91moe.com\/wp-content\/plugins\/advanced-custom-fields\/js\/tinymce.code.min.js" }, content_css: "http://www.91moe.com/wp-includes/css/dashicons.min.css?ver=4.4.3,http://www.91moe.com/wp-includes/js/tinymce/skins/wordpress/wp-content.css?ver=4.4.3", selector: "#ctb-content", resize: "vertical", menubar: false, wpautop: true, indent: false, toolbar1: "fontsizeselect,bold,italic,strikethrough,bullist,numlist,blockquote,hr,alignleft,aligncenter,alignright,link,unlink,wp_more,spellchecker,fullscreen,wp_adv,anchor,sub,sup,wp_page,mukiotag_button", toolbar2: "formatselect,underline,alignjustify,forecolor,pastetext,removeformat,charmap,outdent,indent,undo,redo,wp_help", toolbar3: "", toolbar4: "", tabfocus_elements: ":prev,:next", body_class: "ctb-content post-type-page post-status-publish locale-zh-cn" } }, qtInit: { 'ctb-content': { id: "ctb-content", buttons: "strong,em,link,block,del,ins,img,ul,ol,li,code,more,close" } }, ref: { plugins: "charmap,colorpicker,hr,lists,media,paste,tabfocus,textcolor,fullscreen,wordpress,wpautoresize,wpeditimage,wpemoji,wpgallery,wplink,wpdialogs,wptextpattern,wpview,wpembed,image", theme: "modern", language: "zh" }, load_ext: function (url, lang) { var sl = tinymce.ScriptLoader; sl.markDone(url + '/langs/' + lang + '.js'); sl.markDone(url + '/langs/' + lang + '_dlg.js'); }
};</script>--%>
    <script type='text/javascript' src='/plugins/tinymce/js/tinymce/tinymce.min.js'></script>
    <%--<script type='text/javascript' src='/plugins/tinymce/js/tinymce/plugins/compat3x/plugin.min.js'></script>--%>
    <%--<script type='text/javascript'>tinymce.addI18n('zh', { "New document": "\u65b0\u6587\u6863", "Formats": "\u683c\u5f0f", "Headings": "\u6807\u9898", "Heading 1": "\u4e00\u7ea7\u6807\u9898", "Heading 2": "\u4e8c\u7ea7\u6807\u9898", "Heading 3": "\u4e09\u7ea7\u6807\u9898", "Heading 4": "\u56db\u7ea7\u6807\u9898", "Heading 5": "\u4e94\u7ea7\u6807\u9898", "Heading 6": "\u516d\u7ea7\u6807\u9898", "Blocks": "\u5757", "Paragraph": "\u6bb5\u843d", "Blockquote": "\u5757\u5f15\u7528", "Preformatted": "\u9884\u683c\u5f0f\u5316", "Address": "\u5730\u5740", "Inline": "\u884c\u5185", "Underline": "\u4e0b\u5212\u7ebf", "Strikethrough": "\u5220\u9664\u7ebf", "Subscript": "\u4e0b\u6807", "Superscript": "\u4e0a\u6807", "Clear formatting": "\u6e05\u9664\u683c\u5f0f", "Bold": "\u7c97\u4f53", "Italic": "\u659c\u4f53", "Code": "\u4ee3\u7801", "Source code": "\u6e90\u4ee3\u7801", "Font Family": "\u5b57\u4f53", "Font Sizes": "\u5b57\u53f7", "Align center": "\u5c45\u4e2d\u5bf9\u9f50", "Align right": "\u53f3\u5bf9\u9f50", "Align left": "\u5de6\u5bf9\u9f50", "Justify": "\u4e24\u7aef\u5bf9\u9f50", "Increase indent": "\u589e\u52a0\u7f29\u8fdb\u91cf", "Decrease indent": "\u51cf\u5c11\u7f29\u8fdb\u91cf", "Cut": "\u526a\u5207", "Copy": "\u590d\u5236", "Paste": "\u7c98\u5e16", "Select all": "\u5168\u9009", "Undo": "\u64a4\u9500", "Redo": "\u91cd\u505a", "Ok": "\u786e\u5b9a", "Cancel": "\u53d6\u6d88", "Close": "\u5173\u95ed", "Visual aids": "\u89c6\u89c9\u8f85\u52a9", "Bullet list": "\u9879\u76ee\u7b26\u53f7\u5217\u8868", "Numbered list": "\u7f16\u53f7\u5217\u8868", "Square": "\u5b9e\u5fc3\u65b9\u5757", "Default": "\u9ed8\u8ba4", "Circle": "\u5706\u5708", "Disc": "\u5706\u70b9", "Lower Greek": "\u5c0f\u5199\u5e0c\u814a\u5b57\u6bcd", "Lower Alpha": "\u5c0f\u5199\u82f1\u6587\u5b57\u6bcd", "Upper Alpha": "\u5927\u5199\u82f1\u6587\u5b57\u6bcd", "Upper Roman": "\u5927\u5199\u7f57\u9a6c\u6570\u5b57", "Lower Roman": "\u5c0f\u5199\u7f57\u9a6c\u6570\u5b57", "Name": "\u540d\u5b57", "Anchor": "\u951a", "Anchors": "\u951a", "Document properties": "\u6587\u6863\u5c5e\u6027", "Robots": "\u673a\u5668\u4eba", "Title": "\u6807\u9898", "Keywords": "\u5173\u952e\u8bcd", "Encoding": "\u7f16\u7801", "Description": "\u56fe\u50cf\u63cf\u8ff0", "Author": "\u4f5c\u8005", "Insert\/edit image": "\u63d2\u5165\u6216\u7f16\u8f91\u56fe\u50cf", "General": "\u5e38\u89c4", "Advanced": "\u9ad8\u7ea7", "Source": "\u6e90", "Border": "\u8fb9\u6846", "Constrain proportions": "\u4fdd\u6301\u957f\u5bbd\u6bd4", "Vertical space": "\u5782\u76f4\u95f4\u9694", "Image description": "\u56fe\u50cf\u63cf\u8ff0", "Style": "\u6837\u5f0f", "Dimensions": "\u5c3a\u5bf8", "Insert image": "\u63d2\u5165\u56fe\u50cf", "Insert date\/time": "\u63d2\u5165\u65e5\u671f\u3001\u65f6\u95f4", "Insert\/edit video": "\u63d2\u5165\u6216\u7f16\u8f91\u89c6\u9891", "Poster": "\u6d77\u62a5", "Alternative source": "\u5907\u7528\u6e90", "Paste your embed code below:": "\u8bf7\u5c06\u5d4c\u5165\u4ee3\u7801\u8d34\u5165\u4e0b\u65b9\uff1a", "Insert video": "\u63d2\u5165\u89c6\u9891", "Embed": "\u5d4c\u5165", "Special character": "\u7279\u6b8a\u5b57\u7b26", "Right to left": "\u4ece\u53f3\u5230\u5de6", "Left to right": "\u4ece\u5de6\u5230\u53f3", "Emoticons": "\u8868\u60c5\u7b26\u53f7", "Nonbreaking space": "\u4e0d\u95f4\u65ad\u7a7a\u683c", "Page break": "\u5206\u9875\u7b26", "Paste as text": "\u7c98\u8d34\u4e3a\u6587\u672c", "Preview": "\u9884\u89c8", "Print": "\u6253\u5370", "Save": "\u4fdd\u5b58", "Fullscreen": "\u5168\u5c4f", "Horizontal line": "\u6c34\u5e73\u7ebf", "Horizontal space": "\u6c34\u5e73\u95f4\u9694", "Restore last draft": "\u6062\u590d\u4e0a\u4e00\u8349\u7a3f", "Insert\/edit link": "\u63d2\u5165\u6216\u7f16\u8f91\u94fe\u63a5", "Remove link": "\u79fb\u9664\u94fe\u63a5", "Color": "\u989c\u8272", "Custom color": "\u81ea\u5b9a\u4e49\u989c\u8272", "Custom...": "\u81ea\u5b9a\u4e49\u2026", "No color": "\u65e0\u989c\u8272", "Could not find the specified string.": "\u65e0\u6cd5\u627e\u5230\u6307\u5b9a\u7684\u5b57\u7b26\u4e32\u3002", "Replace": "\u66ff\u6362", "Next": "\u4e0b\u4e00\u4e2a", "Prev": "\u4e0a\u4e00\u4e2a", "Whole words": "\u5339\u914d\u6574\u8bcd", "Find and replace": "\u67e5\u627e\u548c\u66ff\u6362", "Replace with": "\u66ff\u6362\u4e3a", "Find": "\u67e5\u627e", "Replace all": "\u5168\u90e8\u66ff\u6362", "Match case": "\u5339\u914d\u5927\u5c0f\u5199", "Spellcheck": "\u62fc\u5199\u68c0\u67e5", "Finish": "\u5b8c\u6210", "Ignore all": "\u5168\u90e8\u5ffd\u7565", "Ignore": "\u5ffd\u7565", "Add to Dictionary": "\u6dfb\u52a0\u5230\u8bcd\u5178", "Insert table": "\u63d2\u5165\u8868\u683c", "Delete table": "\u5220\u9664\u8868\u683c", "Table properties": "\u8868\u683c\u5c5e\u6027", "Row properties": "\u8868\u683c\u884c\u5c5e\u6027", "Cell properties": "\u5355\u5143\u683c\u5c5e\u6027", "Border color": "\u8fb9\u6846\u989c\u8272", "Row": "\u884c", "Rows": "\u884c", "Column": "\u5217", "Cols": "\u5217", "Cell": "\u5355\u5143\u683c", "Header cell": "\u8868\u5934\u5355\u5143\u683c", "Header": "\u8868\u5934", "Body": "\u4e3b\u4f53", "Footer": "\u6ce8\u811a", "Insert row before": "\u5728\u4e0a\u65b9\u63d2\u5165\u884c", "Insert row after": "\u5728\u4e0b\u65b9\u63d2\u5165\u884c", "Insert column before": "\u5728\u524d\u65b9\u63d2\u5165\u5217", "Insert column after": "\u5728\u540e\u65b9\u63d2\u5165\u5217", "Paste row before": "\u5728\u4e0a\u65b9\u7c98\u8d34\u8868\u683c\u884c", "Paste row after": "\u5728\u4e0b\u65b9\u7c98\u8d34\u8868\u683c\u884c", "Delete row": "\u5220\u9664\u884c", "Delete column": "\u5220\u9664\u5217", "Cut row": "\u526a\u5207\u8be5\u884c", "Copy row": "\u590d\u5236\u8be5\u884c", "Merge cells": "\u5408\u5e76\u5355\u5143\u683c", "Split cell": "\u62c6\u5206\u5355\u5143\u683c", "Height": "\u9ad8\u5ea6", "Width": "\u5bbd\u5ea6", "Caption": "\u8bf4\u660e", "Alignment": "\u5bf9\u9f50\u65b9\u5f0f", "H Align": "\u6a2a\u5411\u5bf9\u9f50", "Left": "\u5de6", "Center": "\u4e2d", "Right": "\u53f3", "None": "\u65e0", "V Align": "\u7eb5\u5411\u5bf9\u9f50", "Top": "\u9876\u90e8", "Middle": "\u4e2d\u90e8", "Bottom": "\u5e95\u90e8", "Row group": "\u884c\u7ec4", "Column group": "\u5217\u7ec4", "Row type": "\u884c\u7c7b\u578b", "Cell type": "\u5355\u5143\u683c\u7c7b\u578b", "Cell padding": "\u5355\u5143\u683c\u5185\u8fb9\u8ddd", "Cell spacing": "\u5355\u5143\u683c\u95f4\u8ddd", "Scope": "\u8303\u56f4", "Insert template": "\u63d2\u5165\u6a21\u677f", "Templates": "\u6a21\u677f", "Background color": "\u80cc\u666f\u989c\u8272", "Text color": "\u6587\u5b57\u989c\u8272", "Show blocks": "\u663e\u793a\u5757", "Show invisible characters": "\u663e\u793a\u4e0d\u53ef\u89c1\u5b57\u7b26", "Words: {0}": "\u8bcd\u6570\uff1a{0}", "Paste is now in plain text mode. Contents will now be pasted as plain text until you toggle this option off.": "\u5f53\u524d\u5904\u4e8e\u7eaf\u6587\u672c\u7c98\u8d34\u6a21\u5f0f\uff0c\u7c98\u8d34\u7684\u5185\u5bb9\u5c06\u88ab\u89c6\u4f5c\u7eaf\u6587\u672c\u3002\n\n\u5982\u679c\u60a8\u5e0c\u671b\u4eceMicrosoft Word\u7c98\u8d34\u5bcc\u6587\u672c\u5185\u5bb9\uff0c\u8bf7\u5c06\u6b64\u9009\u9879\u5173\u95ed\u3002\u7f16\u8f91\u5668\u5c06\u81ea\u52a8\u6e05\u7406\u4eceWord\u7c98\u8d34\u6765\u7684\u6587\u672c\u3002", "Rich Text Area. Press ALT-F9 for menu. Press ALT-F10 for toolbar. Press ALT-0 for help": "\u5bcc\u6587\u672c\u533a\u57df\u3002\u6309Alt-Shift-H\u67e5\u9605\u5e2e\u52a9\u3002", "You have unsaved changes are you sure you want to navigate away?": "\u79bb\u5f00\u8fd9\u4e2a\u9875\u9762\uff0c\u60a8\u6240\u505a\u7684\u66f4\u6539\u5c06\u4e22\u5931\u3002", "Your browser doesn't support direct access to the clipboard. Please use the Ctrl+X\/C\/V keyboard shortcuts instead.": "\u60a8\u7684\u6d4f\u89c8\u5668\u4e0d\u652f\u6301\u76f4\u63a5\u8bbf\u95ee\u526a\u8d34\u677f\uff0c\u8bf7\u4f7f\u7528\u952e\u76d8\u5feb\u6377\u952e\u6216\u6d4f\u89c8\u5668\u7684\u7f16\u8f91\u83dc\u5355\u3002", "Insert": "\u63d2\u5165", "File": "\u6587\u4ef6", "Edit": "\u7f16\u8f91", "Tools": "\u5de5\u5177", "View": "\u67e5\u770b", "Table": "\u8868\u683c", "Format": "\u683c\u5f0f", "Toolbar Toggle": "\u663e\u793a\/\u9690\u85cf\u5de5\u5177\u680f", "Insert Read More tag": "\u63d2\u5165\u201cMore\u201d\u6807\u7b7e", "Insert Page Break tag": "\u63d2\u5165\u5206\u9875\u6807\u7b7e", "Read more...": "\u9605\u8bfb\u66f4\u591a\u2026", "Distraction-free writing mode": "\u514d\u6253\u6270\u5199\u4f5c\u6a21\u5f0f", "No alignment": "\u65e0\u5bf9\u9f50", "Remove": "\u79fb\u9664", "Edit ": "\u7f16\u8f91", "Keyboard Shortcuts": "\u952e\u76d8\u5feb\u6377\u952e", "Default shortcuts,": "\u9ed8\u8ba4\u5feb\u6377\u65b9\u5f0f\uff0c", "Additional shortcuts,": "\u989d\u5916\u7684\u5feb\u6377\u65b9\u5f0f\uff0c", "Focus shortcuts:": "\u7126\u70b9\u5feb\u6377\u65b9\u5f0f\uff1a", "Inline toolbar (when an image, link or preview is selected)": "\u5185\u8054\u5de5\u5177\u680f\uff08\u5f53\u56fe\u7247\u3001\u94fe\u63a5\u6216\u9884\u89c8\u88ab\u9009\u4e2d\u65f6\uff09", "Editor menu (when enabled)": "\u7f16\u8f91\u83dc\u5355\uff08\u5982\u88ab\u542f\u7528\uff09", "Editor toolbar": "\u7f16\u8f91\u5de5\u5177\u680f", "Elements path": "\u5143\u7d20\u8def\u5f84", "Ctrl + Alt + letter:": "Ctrl+Alt+\u5b57\u6bcd\uff1a", "Shift + Alt + letter:": "Shift+Alt+\u5b57\u6bcd\uff1a", "Cmd + letter:": "Cmd+\u5b57\u6bcd\uff1a", "Ctrl + letter:": "Ctrl+\u5b57\u6bcd\uff1a", "Letter": "\u5b57\u6bcd", "Action": "\u64cd\u4f5c", "To move focus to other buttons use Tab or the arrow keys. To return focus to the editor press Escape or use one of the buttons.": "\u8981\u79fb\u52a8\u7126\u70b9\u5230\u5176\u4ed6\u6309\u94ae\uff0c\u8bf7\u4f7f\u7528Tab\u6216\u7bad\u5934\u952e\uff1b\u8981\u5c06\u7126\u70b9\u79fb\u56de\u7f16\u8f91\u5668\uff0c\u8bf7\u6309Esc\u6216\u4f7f\u7528\u4efb\u610f\u4e00\u4e2a\u6309\u94ae\u3002", "When starting a new paragraph with one of these formatting shortcuts followed by a space, the formatting will be applied automatically. Press Backspace or Escape to undo.": "\u5f53\u4f7f\u7528\u8fd9\u4e9b\u683c\u5f0f\u5feb\u6377\u952e\u540e\u8ddf\u7a7a\u683c\u6765\u521b\u5efa\u65b0\u6bb5\u843d\u65f6\uff0c\u8fd9\u4e9b\u683c\u5f0f\u4f1a\u88ab\u81ea\u52a8\u5e94\u7528\u3002\u6309\u9000\u683c\u6216\u9000\u51fa\u952e\u6765\u64a4\u9500\u3002", "The following formatting shortcuts are replaced when pressing Enter. Press Escape or the Undo button to undo.": "\u4ee5\u4e0b\u683c\u5f0f\u5feb\u6377\u952e\u5728\u6309\u56de\u8f66\u952e\u65f6\u88ab\u66ff\u6362\u3002\u8bf7\u6309\u9000\u51fa\u6216\u64a4\u9500\u952e\u6765\u64a4\u9500\u3002" }); tinymce.ScriptLoader.markDone('http://www.91moe.com/wp-includes/js/tinymce/langs/zh.js');</script>
    <script type='text/javascript' src='http://www.91moe.com/wp-includes/js/tinymce/langs/wp-langs-en.js?ver=4208-20151113'></script>--%>
    <script src="../../Style/js/picture.js"></script>
    <script type="text/javascript">
        //tinyMCEPreInit.load_ext("http://www.91moe.com/wp-content/plugins/mukioplayer-for-wordpress/static", "zh");
        //tinymce.PluginManager.load("mukiotag", "http://www.91moe.com/wp-content/plugins/mukioplayer-for-wordpress/static/mukio-tag.js");
        //tinyMCEPreInit.load_ext("http://www.91moe.com/wp-content/plugins/mukioplayer-for-wordpress/static", "zh");
        //tinymce.PluginManager.load("mukiomd5", "http://www.91moe.com/wp-content/plugins/mukioplayer-for-wordpress/static/jquery.md5.js");
        //tinyMCEPreInit.load_ext("http://www.91moe.com/wp-content/plugins/advanced-custom-fields/js", "zh");
        //tinymce.PluginManager.load("code", "http://www.91moe.com/wp-content/plugins/advanced-custom-fields/js/tinymce.code.min.js");

        //var ajaxurl = "/wp-admin/admin-ajax.php";
        //(function () {
        //    var init, id, $wrap; if (typeof tinymce !== 'undefined') {
        //        for (id in tinyMCEPreInit.mceInit) {
        //            init = tinyMCEPreInit.mceInit[id]; $wrap = tinymce.$('#wp-' + id + '-wrap'); if (($wrap.hasClass('tmce-active') || !tinyMCEPreInit.qtInit.hasOwnProperty(id)) && !init.wp_skip_init) {
        //                tinymce.init(init); if (!window.wpActiveEditor) { window.wpActiveEditor = id; }
        //            }
        //        }
        //    }
        //    if (typeof quicktags !== 'undefined') {
        //        for (id in tinyMCEPreInit.qtInit) {
        //            quicktags(tinyMCEPreInit.qtInit[id]); if (!window.wpActiveEditor) { window.wpActiveEditor = id; }
        //        }
        //    }
        //}());
        $(document).ready(function () {
            tinymce.init({
                selector: 'textarea#ctb-content',
                language: 'zh_CN',
                automatic_uploads: true,
                toolbar1: "fontsizeselect bold italic strikethrough bullist numlist blockquote hr alignleft aligncenter alignright link unlink wp_more fullscreen wp_adv wp_page none",
                toolbar2: "formatselect underline alignjustify forecolor pastetext removeformat charmap outdent indent undo redo wp_help image code codesample",
                menubar: false,
                toolbar_items_size: 'small',
                style_formats: [
                    { title: 'Bold text', inline: 'b' },
                    { title: 'Red text', inline: 'span', styles: { color: '#ff0000' } },
                    { title: 'Red header', block: 'h1', styles: { color: '#ff0000' } },
                    { title: 'Example 1', inline: 'span', classes: 'example1' },
                    { title: 'Example 2', inline: 'span', classes: 'example2' },
                    { title: 'Table styles' },
                    { title: 'Table row 1', selector: 'tr', classes: 'tablerow1' }
                ],
                templates: [
                    { title: 'Test template 1', content: 'Test 1' },
                    { title: 'Test template 2', content: 'Test 2' }
                ], plugins: [
                    "advlist autolink autosave link image lists charmap print preview hr anchor pagebreak spellchecker",
                    "searchreplace visualblocks visualchars code fullscreen insertdatetime media nonbreaking",
                    "table contextmenu directionality emoticons template textcolor paste fullpage textcolor"
                ],

            });
            //分类选择
            $('#noteType1').change(function () {
                var $select = $(this);
                $select.next().remove();
                $.get("/Service/HomeManage/GeNoteType2ByNoteType.ashx", { nt: $(this).val() }, function (res) {
                    $select.after(res);
                });
            });

            //来源点击
            $('input[type="radio"]').click(function () {
                console.info($(this).val());
                if ($(this).val() == "original") {
                    $("#theme_custom_post_source-input-reprint").hide();
                } else {
                    $("#theme_custom_post_source-input-reprint").show();
                }
            });

            $('#ctb-file').fileUpload({ mapsel: '#ctb-files' }); //初始化图片上传

            //点击批量将图片插入到文章内容
            $('#ctb-batch-insert-btn').click(function () {
                $.each($('#ctb-files div'), function (index, value) {
                    tinymce.activeEditor.getBody().innerHTML += "<img src='" + $($("a", value)[0]).attr("href") + "' alt='' />";
                });
            });

            $("#ctb-files").on("click", ".ctb-insert-btn", function () {
                console.info($(this));
                console.info($(this).attr("data-large-url"));
                tinymce.activeEditor.getBody().innerHTML += "<img src='" + $(this).attr("data-large-url") + "' alt='' />";
            });

            //提交
            $('#fm-ctb').bind('submit', function () {
                $('#ctb-content').val(tinymce.activeEditor.getBody().innerHTML);

                var $logbut = $('button[type="submit"]', this);
                var submit_loading_tx = $logbut.attr("data-loading-text");
                $logbut.html(submit_loading_tx);
                $logbut.attr("disabled", !0);

                ajaxSubmit(this, function (res) {
                    if (res == "1") {
                        swal({
                            title: "",
                            text: '发布成功',
                            timer: 3000,
                            showConfirmButton: false
                        });
                        location.reload();
                    } else {
                        swal("小2提醒您", "发布失败，请稍后再试", "error");
                        $logbut.html("<i class='fa fa-check'></i>提交");
                        $logbut.attr("disabled", !!0);
                    }
                }, function () {
                    swal("小2提醒您", "系统繁忙，请稍后再试", "error");
                    $logbut.html("<i class='fa fa-check'></i>提交");
                    $logbut.attr("disabled", !!0);
                });
                return false;
            });
        });

    </script>
</asp:Content>
