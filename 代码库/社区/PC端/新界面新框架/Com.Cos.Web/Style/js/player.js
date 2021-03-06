var PlayerBox = {normal_width:980,normal_height:625,big_width:980,big_height:625,site_name : null};
PlayerBox.play = function(site_name,vid,uu,site_desc,dbclick,anchor_obj,playid){
    if(!dbclick){
        if(site_name && this.site_name == site_name) return ;
    }

    if(anchor_obj){
        $(anchor_obj).parent().siblings('li').removeClass('on');
        $(anchor_obj).parent().addClass('on');
    }

    this.site_name = site_name;
    var flashvars = 'MMControl=false&MMout=false';
    var play_url = '';
   var url_regex = /^htstp\:\/\//i; 
    if(url_regex.test(vid)){
        play_url = vid;
    }else{
        switch(site_name){
            case 'youku':
                play_url = 'http://static.youku.com/v1.0.0222/v/swf/player.swf?VideoIDS=' + vid;
                flashvars += '&isShowRelatedVideo=false&amp;showAd=0&amp;show_pre=1&amp;show_next=1&amp;VideoIDS=' + vid + '&amp;isAutoPlay=true&amp;isDebug=false&amp;UserID=&amp;winType=interior&amp;playMovie=true&amp;RecordCode=1001,1002,1003,1004,1005,1006,2001,3001,3002,3003,3004,3005,3007,3008,9999';
                break;
            case 'tudou':
                var digit_regex = /^\d+$/;
                flashvars = 'tvcCode=-1&hd=2';
                play_url = 'http://tudou.com/v/'+vid+'/&autoPlay=true';
                break;
            case 'tudou2':
                //flashvars = 'tvcCode=-1&hd=2';
                //play_url = 'http://www.gy456.com/js/player/gy007/ckplayer.swf?f=http://www.gy456.com/js/player/api/api.php?url='+vid+'_tudou';
                play_url = 'http://www.tvbyy.com/ckplayer/ckplayer.swf?a='+vid+'_tudou';
                break;
            case 'ku6':
                play_url = "http://player.ku6.com/refer/"+vid+"/v.swf";
                break;
            case 'sina':
                //play_url = 'http://www.8090yy.cn/ckplayer63/ckplayer/ckplayer.swf?f=http://www.saycat.com/ckplayer/video.php?url='+ vid +'_wd6';
                play_url = 'http://p.you.video.sina.com.cn/swf/bokePlayer20140424_V4_1_42_43.swf?vid='+vid+'&clip_id=&imgurl=&auto=1&vblog=1&type=0&tabad=1&autoLoad=1&autoPlay=1&as=0&tjAD=0&tj=0&casualPlay=1&head=0&logo=0&share=0&tHostName=you.video.sina.com.cn';
                break;
            case 'qq1':
                play_url = 'http://mat1.qq.com/news/act3/js/QQPlayer3.swf?vid='+vid+'&skin=http://mat1.qq.com/news/act3/js/skins/QQPlayerSkin.swf&autoplay=1'
                break;
            case 'qq' :
                play_url = 'http://imgcache.qq.com/tencentvideo_v1/player/TencentPlayer.swf?_v=20110829&vid='+ vid +'&autoplay=1';
                break;
            case 'iqiyi':
                //play_url = 'http://www.qiyi.com/player/20110928204744/qiyi_n_player.swf?vid='+vid+'&hideRightpanel=1&hideLightpanel=1&hideSharepanel=1&hideNewWindowpanel=1';
                play_url ='http://dispatcher.video.qiyi.com/disp/shareplayer.swf?vid='+vid+'&tvId='+uu+'&cid=qc_100001_300037&coop=coop_178&bd=1&autoPlay=1';
                break;
            case 'pptv':
                play_url = (vid.length > 13) ?  'http://player.pptv.com/v/'+ vid +'.swf' : 'http://player.pptv.com/cid/'+ vid +'.swf';
                break;
            case 'sohu':
                play_url = 'http://share.vrs.sohu.com/'+ vid +'/v.swf&skinNum=1&topBar=0&showRecommend=0&autoplay=true&api_key=e68e42f2beae6ba9ad6bd25e2625632f&fbarad=';
                break;
            case 'letv':
                play_url = 'http://i7.imgs.letv.com/player/swfPlayer.swf?id='+ vid +'&autoplay=1&isPlayerAd=0';
                break;
            case 'letvyun':
                //play_url = 'http://yuntv.letv.com/bcloud.swf?uu=d955239f11&vu='+ vid +'&auto_play=1&gpcflag=1&allowFullScreen=true&quality=high&allowScriptAccess=always&type=application/x-shockwave-flash';
                //play_url = 'http://yuntv.letv.com/bcloud.swf?uu=ab417c1571&vu='+ vid +'&auto_play=1&gpcflag=1&allowFullScreen=true&quality=high&allowScriptAccess=always&type=application/x-shockwave-flash';
                play_url = 'http://yuntv.letv.com/bcloud.swf?uu='+uu+'&vu='+ vid +'&auto_play=1&gpcflag=1&allowFullScreen=true&quality=high&allowScriptAccess=always&type=application/x-shockwave-flash';
                break;
            case 'qingkong':
                play_url = 'http://donghua.dmzj.com/flvplayer.swf?file=http://v.qingkong.net/bp/a.php/'+ vid +'.mp4&autostart=true';
                break;
            case 'weiyun':
                play_url = 'http://donghua.dmzj.com/flvplayer.swf?file=http://donghuaget.duapp.com/weiyun/'+ vid +'.mp4&autostart=true';
                break;
            case 'cntv':
                play_url = 'http://player.cntv.cn/standard/cntvOutSidePlayer.swf?videoId=VIDE100165778382&videoCenterId='+ vid;
                break;
            case '56':
                play_url = 'http://player.56.com/v_'+ vid +'.swf/1030_ycc20060631.swf';
                break;
            case 'mangguo':
                play_url = 'http://i1.hunantv.com/ui/swf/share/player.swf?video_id='+vid;
                break;
            case 'bilibili':
                play_url = 'http://static.hdslb.com/play.swf';
                flashvars = 'cid='+vid;
                break;
            case 'acfun':
                play_url = 'http://cdn.aixifan.com/player/ACFlashPlayer.out.swf?type=page&url=http://www.acfun.tv/v/ac'+vid;
                break;
            case 'acfun_ab':
                play_url = 'http://cdn.aixifan.com/player/ACFlashPlayer.out.swf?type=page&url=http://www.acfun.tv/v/ab'+vid;
                break;
            case 'mukio':
                play_url = 'http://api.kirikiri.tv/mukio/mukio91.php?vid='+ vid +'&type='+ playid +'&url=' + window.location.href;
                break;
            case 'ck':
                   play_url = 'http://api.kirikiri.tv/play/ck.php?vid='+ vid +'&type='+ playid +'&url=' + window.location.href;
                break;
			case 'by1':
			    if(playid=='youku'){
			       play_url = 'http://api.kirikiri.tv/h5/iva.php?url=http://v.youku.com/v_show/id_'+vid+'.html';
		        }else if(playid=='letv'){
			       play_url = 'http://www.91moe.com/player/video.php?url=www.letv.com/ptv/vplay/'+vid+'.html';			  
		        }else if(playid=='sohu'){
			       play_url = 'http://api.kirikiri.tv/play/ck2.php?type=sohu&vid='+vid;			  
		        }else if(playid=='qq'){
			       play_url = 'http://api.kirikiri.tv/h5/iva.php?url=http://v.qq.com/cover/q/qviv9yyjn83eyfu.html?vid='+vid;			  
		        }else if(playid=='pptv'){
			       play_url = 'http://api.kirikiri.tv/h5/iva.php?url=http://v.pptv.com/show/'+vid+'.html';			  
		        }else if(playid=='tudou'){
			       play_url = 'http://api.kirikiri.tv/h5/iva.php?type=tudou&id='+vid;			  
		        }else{
                   play_url = 'http://api.kirikiri.tv/play/ck2.php?vid='+ vid +'&type='+ playid +'&url=' + window.location.href;}
                break;	
			case 'by2':
                play_url = 'http://api.kirikiri.tv/play/ck2.php?vid='+ vid +'&type='+ playid +'&url=' + window.location.href;
                break;
            case 'by3':
			    if(playid=='youku'){
			       play_url = 'http://www.91moe.com/player/video.php?url=v.youku.com/v_show/id_'+vid+'.html';
		        }else if(playid=='letv'){
			       play_url = 'http://www.91moe.com/player/video.php?url=www.letv.com/ptv/vplay/'+vid+'.html';			  
		        }else if(playid=='sohu'){
			       play_url = 'http://www.91moe.com/player/video.php?type=sohu&vid='+vid;			  
		        }else if(playid=='qq'){
			       play_url = 'http://api.kirikiri.tv/h5/iva.php?url=http://v.qq.com/cover/q/qviv9yyjn83eyfu.html?vid='+vid;			  
		        }else if(playid=='pptv'){
			       play_url = 'http://www.91moe.com/player/video.php?url=v.pptv.com/show/'+vid+'.html';			  
		        }else if(playid=='tudou'){
			       play_url = 'http://api.kirikiri.tv/h5/iva.php?type=tudou&id='+vid;			  
		        }else{
                   play_url = 'http://api.kirikiri.tv/play/ck2.php?vid='+ vid +'&type='+ playid +'&url=' + window.location.href;}
                break;
		    case 'video':
                play_url = 'http://api.kirikiri.tv/h5/iva.php?url='+ vid;
                break;	
            default :
                play_url = vid;
                break;
        }
    }
     if(site_name=='iqiyi'){
        var _param = [];
        _param.push('vid='+vid);  //???????????????vid
        _param.push('tvId='+uu);  //???????????????vid
        _param.push("coop=coop_178");  //??????????????????????????????
        //_param.push("cid=qc_100001_300037");  //cid???????????????????????????????????????????????????
        _param.push("bd=1");  //?????????????????????
        _param.push("autoPlay=1");  //??????????????????
        _param.push("cid=qc_100001_300037");
        play=lib.kit.video.render(
            'width', '596',    //??????????????????????????????
            'height', '488',   //??????????????????????????????
            'src',"http://dispatcher.video.qiyi.com/disp/shareplayer.swf",  //??????????????????????????????????????????
            'id', 'acgobject',
            'bgcolor', '#000000',  //???????????????????????????????????????
            'flashVars', _param.join('&'),
            'align', 'middle',  //?????????????????????????????????????????????????????????????????????????????????
            'isstr','true',
            'allownetworking','internal'
        ); //end AC code
        document.getElementById('player_box_container').innerHTML=play;
    }else if(site_name == 'mukio'){
        play = '<iframe style="width:100%;height:'+ this.normal_height +'px;" src="'+ play_url +'" frameborder="0" border="0" marginwidth="0" marginheight="0" scrolling="no"></iframe>';
        document.getElementById('player_box_container').innerHTML=play;
    }else if(site_name == 'ck'){
        play = '<iframe style="width:100%;height:'+ this.normal_height +'px;" src="'+ play_url +'" frameborder="0" border="0" marginwidth="0" marginheight="0" scrolling="no"></iframe>';
        document.getElementById('player_box_container').innerHTML=play;
    }else if(site_name == 'by1'){
        play = '<iframe style="width:100%;height:'+ this.normal_height +'px;" src="'+ play_url +'" frameborder="0" border="0" marginwidth="0" marginheight="0" scrolling="no" allowfullscreen></iframe>';
        document.getElementById('player_box_container').innerHTML=play;
    }else if(site_name == 'by2'){
        play = '<iframe style="width:100%;height:'+ this.normal_height +'px;" src="'+ play_url +'" frameborder="0" border="0" marginwidth="0" marginheight="0" scrolling="no"></iframe>';
        document.getElementById('player_box_container').innerHTML=play;
    }else if(site_name == 'by3'){
        play = '<iframe style="width:100%;height:'+ this.normal_height +'px;" src="'+ play_url +'" frameborder="0" border="0" marginwidth="0" marginheight="0" scrolling="no"></iframe>';
        document.getElementById('player_box_container').innerHTML=play;
    }else if(site_name == 'video'){
        play = '<iframe style="width:100%;height:'+ this.normal_height +'px;" src="'+ play_url +'" frameborder="0" border="0" marginwidth="0" marginheight="0" scrolling="no" allowfull></iframe>';
        document.getElementById('player_box_container').innerHTML=play;
    }else{
        var swf_obj = new SWFObject(play_url, 'acgobject', this.normal_width,this.normal_height, '9.0.0', '#000000');
        swf_obj.addParam('allowfullscreen', 'true');
        swf_obj.addParam('allownetworking', 'internal');
        swf_obj.addParam('allowscriptaccess', 'always');
        swf_obj.addParam('wmode', 'opaque');
        swf_obj.addParam('quality', 'high');
        swf_obj.addParam('flashvars', flashvars);
        swf_obj.write('player_box_container');
    }
    if(video_site_desc_config){
        site_desc = video_site_desc_config[''+site_name] || site_desc;
    }
    if(document.getElementById('site_desc')){
        document.getElementById('site_desc').innerHTML = site_desc || ' ';
    }
};