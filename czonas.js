gx.evt.autoSkip=!1;gx.define("czonas",!1,function(){this.ServerClass="czonas";this.PackageName="GeneXus.Programs";this.ServerFullClass="czonas.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Zoncod=function(){return this.validSrvEvt("Valid_Zoncod",0).then(function(n){return n}.closure(this))};this.e1140139_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e1240139_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,5,6,7,8,9,15,18,20,21,24,26,29,31,34,35,36,37,38];this.GXLastCtrlId=38;n[2]={id:2,fld:"TABLE1",grid:0};n[5]={id:5,fld:"BTN_FIRST",grid:0,evt:"e1340139_client",std:"FIRST"};n[6]={id:6,fld:"BTN_PREVIOUS",grid:0,evt:"e1440139_client",std:"PREVIOUS"};n[7]={id:7,fld:"BTN_NEXT",grid:0,evt:"e1540139_client",std:"NEXT"};n[8]={id:8,fld:"BTN_LAST",grid:0,evt:"e1640139_client",std:"LAST"};n[9]={id:9,fld:"BTN_SELECT",grid:0,evt:"e1740139_client",std:"SELECT"};n[15]={id:15,fld:"TABLE2",grid:0};n[18]={id:18,fld:"TEXTBLOCK1",format:0,grid:0,ctrltype:"textblock"};n[20]={id:20,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Zoncod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ZONCOD",gxz:"Z158ZonCod",gxold:"O158ZonCod",gxvar:"A158ZonCod",ucs:[],op:[31,26],ip:[31,26,20],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A158ZonCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z158ZonCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("ZONCOD",gx.O.A158ZonCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A158ZonCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("ZONCOD",",")},nac:gx.falseFn};n[21]={id:21,fld:"BTN_GET",grid:0,evt:"e1840139_client",std:"GET"};n[24]={id:24,fld:"TEXTBLOCK2",format:0,grid:0,ctrltype:"textblock"};n[26]={id:26,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ZONDSC",gxz:"Z2094ZonDsc",gxold:"O2094ZonDsc",gxvar:"A2094ZonDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2094ZonDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z2094ZonDsc=n)},v2c:function(){gx.fn.setControlValue("ZONDSC",gx.O.A2094ZonDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2094ZonDsc=this.val())},val:function(){return gx.fn.getControlValue("ZONDSC")},nac:gx.falseFn};n[29]={id:29,fld:"TEXTBLOCK3",format:0,grid:0,ctrltype:"textblock"};n[31]={id:31,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ZONSTS",gxz:"Z2095ZonSts",gxold:"O2095ZonSts",gxvar:"A2095ZonSts",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2095ZonSts=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z2095ZonSts=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("ZONSTS",gx.O.A2095ZonSts,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2095ZonSts=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("ZONSTS",",")},nac:gx.falseFn};n[34]={id:34,fld:"BTN_ENTER",grid:0,evt:"e1140139_client",std:"ENTER"};n[35]={id:35,fld:"BTN_CHECK",grid:0,evt:"e1940139_client",std:"CHECK"};n[36]={id:36,fld:"BTN_CANCEL",grid:0,evt:"e1240139_client"};n[37]={id:37,fld:"BTN_DELETE",grid:0,evt:"e2040139_client",std:"DELETE"};n[38]={id:38,fld:"BTN_HELP",grid:0,evt:"e2140139_client"};this.A158ZonCod=0;this.Z158ZonCod=0;this.O158ZonCod=0;this.A2094ZonDsc="";this.Z2094ZonDsc="";this.O2094ZonDsc="";this.A2095ZonSts=0;this.Z2095ZonSts=0;this.O2095ZonSts=0;this.A158ZonCod=0;this.A2094ZonDsc="";this.A2095ZonSts=0;this.Events={e1140139_client:["ENTER",!0],e1240139_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_ZONCOD=[[{av:"A158ZonCod",fld:"ZONCOD",pic:"ZZZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A2094ZonDsc",fld:"ZONDSC",pic:""},{av:"A2095ZonSts",fld:"ZONSTS",pic:"9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z158ZonCod"},{av:"Z2094ZonDsc"},{av:"Z2095ZonSts"},{ctrl:"BTN_GET",prop:"Enabled"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"},{ctrl:"BTN_CHECK",prop:"Enabled"}]];this.EnterCtrl=["BTN_ENTER"];this.CheckCtrl=["BTN_CHECK"];this.Initialize()});gx.wi(function(){gx.createParentObj(this.czonas)})