//mukio-sect.js
//已知问题,修改winodw.location.hash会使IE标题变得奇怪,不影响使用
function addLoadHandler() {
  if(window.addEventListener) {
    window.addEventListener('load',function(event) { load();},false);
  }
  else if(window.attachEvent) {
    window.attachEvent('onload',function(event) { load();});
  }
  else {
    var previousOnload = window.onload;
    window.onload = function(event) {
      load();
      if (previousOnload) {
        previousOnload(event ? event : window.event);
      }
    }
  }
}
// addLoadHandler();
VideoList = [];

// function load() {
  // renderVideo();
// }
//渲染视频
function renderVideo() {
  // var list = parseList();
  var list = VideoList;
  if (list.length <=0)
    return;
  var index = getVideoIndex();
  // alert(index);
  // return;
  renderList(list,index);
  renderPlayer(list,index);
}
//给生成网页调用的
function addVideo(w,h,flashvars,ptitle,description) {
//  VideoList.push({'width':w,'height':h,'ptitle':ptitle,'flashvars':flashvars,'player':MukioPlayerURI,'desc':description});
  VideoList.push({'width':"100%",'height':"100%",'ptitle':ptitle,'flashvars':flashvars,'player':MukioPlayerURI,'desc':description});
}
//得到播放序号
function getVideoIndex() {
  var hash = window.location.hash;
  // alert(hash);
  if (hash.length <= 1) {
    return 0;
  }
  hash = hash.substr(1);
  var index = parseInt(hash) - 1;
  if (index < 0) {
    return 0;
  }
  // alert(index);
  if (index >= VideoList.length) {
    return VideoList.length - 1;
  }
  return index;
}
//生成播放列表
function renderList(list,index) {
  var pfield = document.getElementById('mkplayer-sectsel');
  if (list.length <= 0)
    return;
  if (list.length == 1) {
    if(!list[0]['ptitle'])
      return;
    else {
      pfield.innerHTML = list[0]['ptitle'];
      return;
    }
  }
  var select = document.createElement('select');
  var opt;
  for (var i = 0;i <list.length;i ++) {
    opt = document.createElement('option');
    opt.setAttribute('value',i);
    if (i == index)
      opt.setAttribute('selected','selected');
    opt.appendChild(document.createTextNode((i+1) + '. ' + list[i]['ptitle']));
    select.appendChild(opt);
  }
  select.onchange = function() {
    // alert(this.options[this.selectedIndex].value);
    var index = parseInt(this.options[this.selectedIndex].value);
    window.location.hash = '#' + (index + 1);
    renderPlayer(VideoList,index);
  };
  pfield.appendChild(select);
}
//嵌入播放器
function renderPlayer(list,index) {
  var descfield = document.getElementById('mkplayer-desc');
  descfield.innerHTML = list[index]['desc']
  var videofield = document.getElementById('mkplayer-box');
    		var wdurl = list[index]['flashvars'];
		var allargs = wdurl.split("&");
		var vid = allargs[0].split("vid=")[1];
		var type = allargs[1].split("type=")[1];
		var file = allargs[0].split("file=")[1];
  var browser={  
    versions:function(){   
           var u = navigator.userAgent, app = navigator.appVersion;   
           return {//移动终端浏览器版本信息   
                trident: u.indexOf('Trident') > -1, //IE内核  
                presto: u.indexOf('Presto') > -1, //opera内核  
                webKit: u.indexOf('AppleWebKit') > -1, //苹果、谷歌内核  
                gecko: u.indexOf('Gecko') > -1 && u.indexOf('KHTML') == -1, //火狐内核  
                mobile: !!u.match(/AppleWebKit.*Mobile.*/), //是否为移动终端  
                ios: !!u.match(/\(i[^;]+;( U;)? CPU.+Mac OS X/), //ios终端  
                android: u.indexOf('Android') > -1 || u.indexOf('Linux') > -1, //android终端或者uc浏览器  
                iPhone: u.indexOf('iPhone') > -1 , //是否为iPhone或者QQHD浏览器  
                iPad: u.indexOf('iPad') > -1, //是否iPad    
                webApp: u.indexOf('Safari') == -1 //是否web应该程序，没有头部与底部  
            };  
         }(),  
         language:(navigator.browserLanguage || navigator.language).toLowerCase()  
}   
  
  if(browser.versions.mobile || browser.versions.ios || browser.versions.android ||   
    browser.versions.iPhone || browser.versions.iPad){  
	if (type == "acyun") {  
	var playerstr = '<iframe id=\"player\" fullscreen=\"0\" frameborder=\"0\" allowfullscreen=\"\" class=\"player\" src=\"http://m.acfun.tv/ykplayer?date=undefined#vid=' + vid +';cover=http://cdn.aixifan.com/dotnet/artemis/u/cms/www/201605/02165135o18vzikl.jpg;title=更多动画尽在九妖萌\" __idm_frm__=\"31\" __idm_id__=\"278529\"></iframe>'; 
 videofield.innerHTML = playerstr;  
}else{
  var playerstr = '<video controls="controls"';
  playerstr += ' src="http://api.kirikiri.tv/189/mobile.php?' + list[index]['flashvars'] + '"';
  playerstr += ' id="mplayer_player-embed" width="100%" height="300px" autoplay="autoplay"></video>';
  videofield.innerHTML = playerstr;      
}}  else{  
		if (type == "video") {  
       	var c = allargs[2].split("cid=")[1];
    var g = "&cid="+c;
	var playerstr = '<div class=\"ani-video-main\"><div class=\"ani-box\"><div class=\"ani-player\"><div class=\"ani-player-box\" style=\"z-index:100;\" id=\'player_box_container\'><embed src="' + list[index]['player'] + '" width="' + list[index]['width'] + '" height="' + list[index]['height'] + '" type="application/x-shockwave-flash" quality="high" allowfullscreen="true" flashvars="' + list[index]['flashvars'] + '&parentId=mkplayer-box"></embed></div></div></div></div><div class=\"cite-tools\"><div class=\"cite-div\">切换线路:</div>';
playerstr += ' <ul><li><a class=\"cite-mukio ie6png\" href=\"javascript:void(0)\" onclick=\"PlayerBox.play(\'mukio\',\'' + file + g + '\',\'\',\'九妖萌\',false,this,\'video\')\"  ondblclick=\"PlayerBox.play(\'mukio\',\'' + file + g + '\',\'\',\'九妖萌\',true,this,\'video\')\">弹幕</a> </li><li><a class=\"cite-qingkong ie6png\" href=\"javascript:void(0)\" onclick=\"PlayerBox.play(\'video\',\'' + file +'\',\'\',\'九妖萌\',false,this,\'video\')\"  ondblclick=\"PlayerBox.play(\'video\',\'' + file + '\',\'\',\'九妖萌\',true,this,\'video\')\"  >站内</a></li></ul>';
playerstr += ' <div class=\"cite-div2\"><span class=\"l-span\"><a href=\"#respond\">我来评论</a></span><span class=\"r-span\"><a onclick=\"error_report(this)\" target=\"_blank\" href=\"http://www.91moe.com/%E6%96%87%E7%AB%A0%E9%97%AE%E9%A2%98%E5%8F%8D%E9%A6%88\">报错反馈</a></span></div></div>'; 
 videofield.innerHTML = playerstr;  
}else if (type == "acyun") {  
	var playerstr = '<iframe id=\"ACFlashPlayer-re\" frameborder=\"0\" allowfullscreen=\"\" style=\"height: 520px; width: 980px; left: 0px; top: 0px;\" src=\"http://114.215.127.140/acfun.html?salt=169290321#token=pi9aa2efqci8uxr;vid=' + vid +';postMessage=1;autoplay=0;fullscreen=0;from=http://www.acfun.tv;hint=最新动漫尽在九妖萌动画。\" __idm_frm__=\"9\"></iframe>'; 
 videofield.innerHTML = playerstr;  
}else{
	 var playerstr = '<div class=\"ani-video-main\"><div class=\"ani-box\"><div class=\"ani-player\"><div class=\"ani-player-box\" style=\"z-index:100;\" id=\'player_box_container\'><embed src="' + list[index]['player'] + '" width="' + list[index]['width'] + '" height="' + list[index]['height'] + '" type="application/x-shockwave-flash" quality="high" allowfullscreen="true" flashvars="' + list[index]['flashvars'] + '&parentId=mkplayer-box"></embed></div></div></div></div><div class=\"cite-tools\"><div class=\"cite-div\">切换线路</div>';
playerstr += ' <ul><li><a class=\"cite-mukio ie6png\"  href=\"javascript:void(0)\" onclick=\"PlayerBox.play(\'mukio\',\'' + vid + '\',\'\',\'九妖萌\',false,this,\'' + type + '\')\"  ondblclick=\"PlayerBox.play(\'mukio\',\'' + vid + '\',\'\',\'九妖萌\',true,this,\'' + type + '\')\">弹幕</a></li><li><a class=\"cite-qingkong ie6png\" href=\"javascript:void(0)\" onclick=\"PlayerBox.play(\'ck\',\'' + vid +'\',\'\',\'九妖萌\',false,this,\'' + type + '\')\"  ondblclick=\"PlayerBox.play(\'ck\',\'' + vid + '\',\'\',\'九妖萌\',true,this,\'' + type + '\')\"  >站内</a></li><li><a class=\"cite-' + type + ' ie6png\" href=\"javascript:void(0)\" onclick=\"PlayerBox.play(\'' + type + '\',\'' + vid +'\',\'\',\'九妖萌\',false,this,\'' + type + '\')\"  ondblclick=\"PlayerBox.play(\''+ type +'\',\'' + vid + '\',\'\',\'九妖萌\',true,this,\'' + type + '\')\"  >站外</a></li><li><a class=\"cite-qingkong ie6png\" href=\"javascript:void(0)\" onclick=\"PlayerBox.play(\'by1\',\'' + vid + '\',\'\',\'九妖萌\',false,this,\'' + type + '\')\"  ondblclick=\"PlayerBox.play(\'by1\',\'' + vid + '\',\'\',\'九妖萌\',true,this,\'' + type + '\')\">备用</a> </li><li><a class=\"cite-qingkong ie6png\" href=\"javascript:void(0)\" onclick=\"PlayerBox.play(\'by2\',\'' + vid + '\',\'\',\'九妖萌\',false,this,\'' + type + '\')\"  ondblclick=\"PlayerBox.play(\'by2\',\'' + vid + '\',\'\',\'九妖萌\',true,this,\'' + type + '\')\">备用</a> </li><li><a class=\"cite-qingkong ie6png\" href=\"javascript:void(0)\" onclick=\"PlayerBox.play(\'by3\',\'' + vid + '\',\'\',\'九妖萌\',false,this,\'' + type + '\')\"  ondblclick=\"PlayerBox.play(\'by3\',\'' + vid + '\',\'\',\'九妖萌\',true,this,\'' + type + '\')\">备用</a> </li></ul>';
playerstr += '<div class=\"cite-div2\"><span class=\"l-span\"><a href=\"#respond\">我来评论</a></span><span class=\"r-span\"><a onclick=\"error_report(this)\" target=\"_blank\" href=\"http://www.91moe.com/%E6%96%87%E7%AB%A0%E9%97%AE%E9%A2%98%E5%8F%8D%E9%A6%88\">报错反馈</a></span></div></div>'; 
 videofield.innerHTML = playerstr; 
    }
            }  

     
}