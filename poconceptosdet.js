gx.evt.autoSkip=!1;gx.define("poconceptosdet",!1,function(){this.ServerClass="poconceptosdet";this.PackageName="GeneXus.Programs";this.ServerFullClass="poconceptosdet.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Poconccod=function(){return this.validSrvEvt("Valid_Poconccod",0).then(function(n){return n}.closure(this))};this.Valid_Poconcdcuecod=function(){return this.validSrvEvt("Valid_Poconcdcuecod",0).then(function(n){return n}.closure(this))};this.e1143182_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e1243182_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52];this.GXLastCtrlId=52;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"TABLEMAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"BTN_FIRST",grid:0,evt:"e1343182_client",std:"FIRST"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"BTN_PREVIOUS",grid:0,evt:"e1443182_client",std:"PREVIOUS"};n[15]={id:15,fld:"",grid:0};n[16]={id:16,fld:"BTN_NEXT",grid:0,evt:"e1543182_client",std:"NEXT"};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"BTN_LAST",grid:0,evt:"e1643182_client",std:"LAST"};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"BTN_SELECT",grid:0,evt:"e1743182_client",std:"SELECT"};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Poconccod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"POCONCCOD",gxz:"Z313PoConcCod",gxold:"O313PoConcCod",gxvar:"A313PoConcCod",ucs:[],op:[],ip:[28],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A313PoConcCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z313PoConcCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("POCONCCOD",gx.O.A313PoConcCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A313PoConcCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("POCONCCOD",",")},nac:gx.falseFn};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,lvl:0,type:"char",len:15,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Poconcdcuecod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"POCONCDCUECOD",gxz:"Z315PoConcDCueCod",gxold:"O315PoConcDCueCod",gxvar:"A315PoConcDCueCod",ucs:[],op:[38,43],ip:[38,43,33,28],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A315PoConcDCueCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z315PoConcDCueCod=n)},v2c:function(){gx.fn.setControlValue("POCONCDCUECOD",gx.O.A315PoConcDCueCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A315PoConcDCueCod=this.val())},val:function(){return gx.fn.getControlValue("POCONCDCUECOD")},nac:gx.falseFn};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"POCONCDCUEDSC",gxz:"Z1647PoConcDCueDsc",gxold:"O1647PoConcDCueDsc",gxvar:"A1647PoConcDCueDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1647PoConcDCueDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z1647PoConcDCueDsc=n)},v2c:function(){gx.fn.setControlValue("POCONCDCUEDSC",gx.O.A1647PoConcDCueDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1647PoConcDCueDsc=this.val())},val:function(){return gx.fn.getControlValue("POCONCDCUEDSC")},nac:gx.falseFn};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,lvl:0,type:"char",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"POCONCCOSCOD",gxz:"Z316PoConcCosCod",gxold:"O316PoConcCosCod",gxvar:"A316PoConcCosCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A316PoConcCosCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z316PoConcCosCod=n)},v2c:function(){gx.fn.setControlValue("POCONCCOSCOD",gx.O.A316PoConcCosCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A316PoConcCosCod=this.val())},val:function(){return gx.fn.getControlValue("POCONCCOSCOD")},nac:gx.falseFn};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"BTN_ENTER",grid:0,evt:"e1143182_client",std:"ENTER"};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"BTN_CANCEL",grid:0,evt:"e1243182_client"};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"BTN_DELETE",grid:0,evt:"e1843182_client",std:"DELETE"};this.A313PoConcCod=0;this.Z313PoConcCod=0;this.O313PoConcCod=0;this.A315PoConcDCueCod="";this.Z315PoConcDCueCod="";this.O315PoConcDCueCod="";this.A1647PoConcDCueDsc="";this.Z1647PoConcDCueDsc="";this.O1647PoConcDCueDsc="";this.A316PoConcCosCod="";this.Z316PoConcCosCod="";this.O316PoConcCosCod="";this.A313PoConcCod=0;this.A315PoConcDCueCod="";this.A1647PoConcDCueDsc="";this.A316PoConcCosCod="";this.Events={e1143182_client:["ENTER",!0],e1243182_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_POCONCCOD=[[{av:"A313PoConcCod",fld:"POCONCCOD",pic:"ZZZZZ9"}],[]];this.EvtParms.VALID_POCONCDCUECOD=[[{av:"A313PoConcCod",fld:"POCONCCOD",pic:"ZZZZZ9"},{av:"A315PoConcDCueCod",fld:"POCONCDCUECOD",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A316PoConcCosCod",fld:"POCONCCOSCOD",pic:""},{av:"A1647PoConcDCueDsc",fld:"POCONCDCUEDSC",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z313PoConcCod"},{av:"Z315PoConcDCueCod"},{av:"Z316PoConcCosCod"},{av:"Z1647PoConcDCueDsc"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"}]];this.EnterCtrl=["BTN_ENTER"];this.Initialize()});gx.wi(function(){gx.createParentObj(this.poconceptosdet)})