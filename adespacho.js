gx.evt.autoSkip=!1;gx.define("adespacho",!1,function(){this.ServerClass="adespacho";this.PackageName="GeneXus.Programs";this.ServerFullClass="adespacho.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Descod=function(){return this.validSrvEvt("Valid_Descod",0).then(function(n){return n}.closure(this))};this.Valid_Desfec=function(){return this.validCliEvt("Valid_Desfec",0,function(){try{var n=gx.util.balloon.getNew("DESFEC");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.A875DesFec)==0||new gx.date.gxdate(this.A875DesFec).compare(gx.date.ymdhmstot(1753,1,1,0,0,0))>=0))try{n.setError("Campo Fecha Despacho fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Chocod=function(){return this.validSrvEvt("Valid_Chocod",0).then(function(n){return n}.closure(this))};this.Valid_Ayucod=function(){return this.validSrvEvt("Valid_Ayucod",0).then(function(n){return n}.closure(this))};this.Valid_Untcod=function(){return this.validSrvEvt("Valid_Untcod",0).then(function(n){return n}.closure(this))};this.e111236_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e121236_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,5,6,7,8,9,15,18,20,21,24,26,29,31,34,36,39,41,44,46,49,51,54,55,56,57,58];this.GXLastCtrlId=58;n[2]={id:2,fld:"TABLE1",grid:0};n[5]={id:5,fld:"BTN_FIRST",grid:0,evt:"e131236_client",std:"FIRST"};n[6]={id:6,fld:"BTN_PREVIOUS",grid:0,evt:"e141236_client",std:"PREVIOUS"};n[7]={id:7,fld:"BTN_NEXT",grid:0,evt:"e151236_client",std:"NEXT"};n[8]={id:8,fld:"BTN_LAST",grid:0,evt:"e161236_client",std:"LAST"};n[9]={id:9,fld:"BTN_SELECT",grid:0,evt:"e171236_client",std:"SELECT"};n[15]={id:15,fld:"TABLE2",grid:0};n[18]={id:18,fld:"TEXTBLOCK1",format:0,grid:0,ctrltype:"textblock"};n[20]={id:20,lvl:0,type:"char",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Descod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DESCOD",gxz:"Z8DesCod",gxold:"O8DesCod",gxvar:"A8DesCod",ucs:[],op:[41,36,31,51,46,26],ip:[41,36,31,51,46,26,20],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A8DesCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z8DesCod=n)},v2c:function(){gx.fn.setControlValue("DESCOD",gx.O.A8DesCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A8DesCod=this.val())},val:function(){return gx.fn.getControlValue("DESCOD")},nac:gx.falseFn};n[21]={id:21,fld:"BTN_GET",grid:0,evt:"e181236_client",std:"GET"};n[24]={id:24,fld:"TEXTBLOCK2",format:0,grid:0,ctrltype:"textblock"};n[26]={id:26,lvl:0,type:"dtime",len:8,dec:5,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Desfec,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DESFEC",gxz:"Z875DesFec",gxold:"O875DesFec",gxvar:"A875DesFec",dp:{f:0,st:!0,wn:!1,mf:!1,pic:"99/99/99 99:99",dec:5},ucs:[],op:[26],ip:[26],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A875DesFec=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z875DesFec=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("DESFEC",gx.O.A875DesFec,0)},c2v:function(){this.val()!==undefined&&(gx.O.A875DesFec=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getDateTimeValue("DESFEC")},nac:gx.falseFn};n[29]={id:29,fld:"TEXTBLOCK3",format:0,grid:0,ctrltype:"textblock"};n[31]={id:31,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Chocod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHOCOD",gxz:"Z10ChoCod",gxold:"O10ChoCod",gxvar:"A10ChoCod",ucs:[],op:[],ip:[31],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A10ChoCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z10ChoCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("CHOCOD",gx.O.A10ChoCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A10ChoCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CHOCOD",",")},nac:gx.falseFn};n[34]={id:34,fld:"TEXTBLOCK4",format:0,grid:0,ctrltype:"textblock"};n[36]={id:36,lvl:0,type:"char",len:15,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Ayucod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AYUCOD",gxz:"Z1AYUCod",gxold:"O1AYUCod",gxvar:"A1AYUCod",ucs:[],op:[],ip:[36],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1AYUCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z1AYUCod=n)},v2c:function(){gx.fn.setControlValue("AYUCOD",gx.O.A1AYUCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1AYUCod=this.val())},val:function(){return gx.fn.getControlValue("AYUCOD")},nac:gx.falseFn};n[39]={id:39,fld:"TEXTBLOCK5",format:0,grid:0,ctrltype:"textblock"};n[41]={id:41,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Untcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"UNTCOD",gxz:"Z9UNTCod",gxold:"O9UNTCod",gxvar:"A9UNTCod",ucs:[],op:[],ip:[41],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A9UNTCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z9UNTCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("UNTCOD",gx.O.A9UNTCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A9UNTCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("UNTCOD",",")},nac:gx.falseFn};n[44]={id:44,fld:"TEXTBLOCK6",format:0,grid:0,ctrltype:"textblock"};n[46]={id:46,lvl:0,type:"vchar",len:500,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DESOBS",gxz:"Z876DesObs",gxold:"O876DesObs",gxvar:"A876DesObs",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A876DesObs=n)},v2z:function(n){n!==undefined&&(gx.O.Z876DesObs=n)},v2c:function(){gx.fn.setControlValue("DESOBS",gx.O.A876DesObs,0)},c2v:function(){this.val()!==undefined&&(gx.O.A876DesObs=this.val())},val:function(){return gx.fn.getControlValue("DESOBS")},nac:gx.falseFn};n[49]={id:49,fld:"TEXTBLOCK7",format:0,grid:0,ctrltype:"textblock"};n[51]={id:51,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DESDITEM",gxz:"Z874DesDItem",gxold:"O874DesDItem",gxvar:"A874DesDItem",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A874DesDItem=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z874DesDItem=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("DESDITEM",gx.O.A874DesDItem,0)},c2v:function(){this.val()!==undefined&&(gx.O.A874DesDItem=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("DESDITEM",",")},nac:gx.falseFn};n[54]={id:54,fld:"BTN_ENTER",grid:0,evt:"e111236_client",std:"ENTER"};n[55]={id:55,fld:"BTN_CHECK",grid:0,evt:"e191236_client",std:"CHECK"};n[56]={id:56,fld:"BTN_CANCEL",grid:0,evt:"e121236_client"};n[57]={id:57,fld:"BTN_DELETE",grid:0,evt:"e201236_client",std:"DELETE"};n[58]={id:58,fld:"BTN_HELP",grid:0,evt:"e211236_client"};this.A8DesCod="";this.Z8DesCod="";this.O8DesCod="";this.A875DesFec=gx.date.nullDate();this.Z875DesFec=gx.date.nullDate();this.O875DesFec=gx.date.nullDate();this.A10ChoCod=0;this.Z10ChoCod=0;this.O10ChoCod=0;this.A1AYUCod="";this.Z1AYUCod="";this.O1AYUCod="";this.A9UNTCod=0;this.Z9UNTCod=0;this.O9UNTCod=0;this.A876DesObs="";this.Z876DesObs="";this.O876DesObs="";this.A874DesDItem=0;this.Z874DesDItem=0;this.O874DesDItem=0;this.A8DesCod="";this.A875DesFec=gx.date.nullDate();this.A10ChoCod=0;this.A1AYUCod="";this.A9UNTCod=0;this.A876DesObs="";this.A874DesDItem=0;this.Events={e111236_client:["ENTER",!0],e121236_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_DESCOD=[[{av:"A8DesCod",fld:"DESCOD",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A875DesFec",fld:"DESFEC",pic:"99/99/99 99:99"},{av:"A10ChoCod",fld:"CHOCOD",pic:"ZZZZZ9"},{av:"A1AYUCod",fld:"AYUCOD",pic:""},{av:"A9UNTCod",fld:"UNTCOD",pic:"ZZZZZ9"},{av:"A876DesObs",fld:"DESOBS",pic:""},{av:"A874DesDItem",fld:"DESDITEM",pic:"ZZZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z8DesCod"},{av:"Z875DesFec"},{av:"Z10ChoCod"},{av:"Z1AYUCod"},{av:"Z9UNTCod"},{av:"Z876DesObs"},{av:"Z874DesDItem"},{ctrl:"BTN_GET",prop:"Enabled"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"},{ctrl:"BTN_CHECK",prop:"Enabled"}]];this.EvtParms.VALID_DESFEC=[[{av:"A875DesFec",fld:"DESFEC",pic:"99/99/99 99:99"}],[{av:"A875DesFec",fld:"DESFEC",pic:"99/99/99 99:99"}]];this.EvtParms.VALID_CHOCOD=[[{av:"A10ChoCod",fld:"CHOCOD",pic:"ZZZZZ9"}],[]];this.EvtParms.VALID_AYUCOD=[[{av:"A1AYUCod",fld:"AYUCOD",pic:""}],[]];this.EvtParms.VALID_UNTCOD=[[{av:"A9UNTCod",fld:"UNTCOD",pic:"ZZZZZ9"}],[]];this.EnterCtrl=["BTN_ENTER"];this.CheckCtrl=["BTN_CHECK"];this.Initialize()});gx.wi(function(){gx.createParentObj(this.adespacho)})