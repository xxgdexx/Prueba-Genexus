gx.evt.autoSkip=!1;gx.define("sgusuarioalmacen",!0,function(n){this.ServerClass="sgusuarioalmacen";this.PackageName="GeneXus.Programs";this.ServerFullClass="sgusuarioalmacen.aspx";this.setObjectType("trn");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Usucod=function(){return this.validSrvEvt("Valid_Usucod",0).then(function(n){return n}.closure(this))};this.Valid_Usualmcod=function(){return this.validSrvEvt("Valid_Usualmcod",0).then(function(n){return n}.closure(this))};this.e110t28_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e120t28_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52];this.GXLastCtrlId=52;t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"TABLEMAIN",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"BTN_FIRST",grid:0,evt:"e130t28_client",std:"FIRST"};t[13]={id:13,fld:"",grid:0};t[14]={id:14,fld:"BTN_PREVIOUS",grid:0,evt:"e140t28_client",std:"PREVIOUS"};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"BTN_NEXT",grid:0,evt:"e150t28_client",std:"NEXT"};t[17]={id:17,fld:"",grid:0};t[18]={id:18,fld:"BTN_LAST",grid:0,evt:"e160t28_client",std:"LAST"};t[19]={id:19,fld:"",grid:0};t[20]={id:20,fld:"BTN_SELECT",grid:0,evt:"e170t28_client",std:"SELECT"};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[24]={id:24,fld:"",grid:0};t[25]={id:25,fld:"",grid:0};t[26]={id:26,fld:"",grid:0};t[27]={id:27,fld:"",grid:0};t[28]={id:28,lvl:0,type:"char",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Usucod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUCOD",gxz:"Z348UsuCod",gxold:"O348UsuCod",gxvar:"A348UsuCod",ucs:[],op:[],ip:[28],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A348UsuCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z348UsuCod=n)},v2c:function(){gx.fn.setControlValue("USUCOD",gx.O.A348UsuCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A348UsuCod=this.val())},val:function(){return gx.fn.getControlValue("USUCOD")},nac:gx.falseFn};t[29]={id:29,fld:"",grid:0};t[30]={id:30,fld:"",grid:0};t[31]={id:31,fld:"",grid:0};t[32]={id:32,fld:"",grid:0};t[33]={id:33,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Usualmcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUALMCOD",gxz:"Z349UsuAlmCod",gxold:"O349UsuAlmCod",gxvar:"A349UsuAlmCod",ucs:[],op:[38,43],ip:[38,43,33,28],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A349UsuAlmCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z349UsuAlmCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("USUALMCOD",gx.O.A349UsuAlmCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A349UsuAlmCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("USUALMCOD",",")},nac:gx.falseFn};t[34]={id:34,fld:"",grid:0};t[35]={id:35,fld:"",grid:0};t[36]={id:36,fld:"",grid:0};t[37]={id:37,fld:"",grid:0};t[38]={id:38,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUALMDSC",gxz:"Z2007UsuAlmDsc",gxold:"O2007UsuAlmDsc",gxvar:"A2007UsuAlmDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2007UsuAlmDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z2007UsuAlmDsc=n)},v2c:function(){gx.fn.setControlValue("USUALMDSC",gx.O.A2007UsuAlmDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2007UsuAlmDsc=this.val())},val:function(){return gx.fn.getControlValue("USUALMDSC")},nac:gx.falseFn};t[39]={id:39,fld:"",grid:0};t[40]={id:40,fld:"",grid:0};t[41]={id:41,fld:"",grid:0};t[42]={id:42,fld:"",grid:0};t[43]={id:43,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUALMSTS",gxz:"Z2008UsuAlmSts",gxold:"O2008UsuAlmSts",gxvar:"A2008UsuAlmSts",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2008UsuAlmSts=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z2008UsuAlmSts=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("USUALMSTS",gx.O.A2008UsuAlmSts,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2008UsuAlmSts=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("USUALMSTS",",")},nac:gx.falseFn};t[44]={id:44,fld:"",grid:0};t[45]={id:45,fld:"",grid:0};t[46]={id:46,fld:"",grid:0};t[47]={id:47,fld:"",grid:0};t[48]={id:48,fld:"BTN_ENTER",grid:0,evt:"e110t28_client",std:"ENTER"};t[49]={id:49,fld:"",grid:0};t[50]={id:50,fld:"BTN_CANCEL",grid:0,evt:"e120t28_client"};t[51]={id:51,fld:"",grid:0};t[52]={id:52,fld:"BTN_DELETE",grid:0,evt:"e180t28_client",std:"DELETE"};this.A348UsuCod="";this.Z348UsuCod="";this.O348UsuCod="";this.A349UsuAlmCod=0;this.Z349UsuAlmCod=0;this.O349UsuAlmCod=0;this.A2007UsuAlmDsc="";this.Z2007UsuAlmDsc="";this.O2007UsuAlmDsc="";this.A2008UsuAlmSts=0;this.Z2008UsuAlmSts=0;this.O2008UsuAlmSts=0;this.A348UsuCod="";this.A349UsuAlmCod=0;this.A2007UsuAlmDsc="";this.A2008UsuAlmSts=0;this.Events={e110t28_client:["ENTER",!0],e120t28_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0},{sPrefix:!0},{sSFPrefix:!0},{sCompEvt:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_USUCOD=[[{av:"A348UsuCod",fld:"USUCOD",pic:""}],[]];this.EvtParms.VALID_USUALMCOD=[[{av:"A348UsuCod",fld:"USUCOD",pic:""},{av:"A349UsuAlmCod",fld:"USUALMCOD",pic:"ZZZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A2008UsuAlmSts",fld:"USUALMSTS",pic:"9"},{av:"A2007UsuAlmDsc",fld:"USUALMDSC",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z348UsuCod"},{av:"Z349UsuAlmCod"},{av:"Z2008UsuAlmSts"},{av:"Z2007UsuAlmDsc"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"}]];this.EnterCtrl=["BTN_ENTER"];this.Initialize()})