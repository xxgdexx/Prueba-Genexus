gx.evt.autoSkip=!1;gx.define("poorsermaq",!1,function(){this.ServerClass="poorsermaq";this.PackageName="GeneXus.Programs";this.ServerFullClass="poorsermaq.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Psercod=function(){return this.validSrvEvt("Valid_Psercod",0).then(function(n){return n}.closure(this))};this.Valid_Maqcod=function(){return this.validSrvEvt("Valid_Maqcod",0).then(function(n){return n}.closure(this))};this.e114f154_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e124f154_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,5,6,7,8,9,15,18,20,23,25,26,29,31,34,35,36,37,38];this.GXLastCtrlId=38;n[2]={id:2,fld:"TABLE1",grid:0};n[5]={id:5,fld:"BTN_FIRST",grid:0,evt:"e134f154_client",std:"FIRST"};n[6]={id:6,fld:"BTN_PREVIOUS",grid:0,evt:"e144f154_client",std:"PREVIOUS"};n[7]={id:7,fld:"BTN_NEXT",grid:0,evt:"e154f154_client",std:"NEXT"};n[8]={id:8,fld:"BTN_LAST",grid:0,evt:"e164f154_client",std:"LAST"};n[9]={id:9,fld:"BTN_SELECT",grid:0,evt:"e174f154_client",std:"SELECT"};n[15]={id:15,fld:"TABLE2",grid:0};n[18]={id:18,fld:"TEXTBLOCK1",format:0,grid:0,ctrltype:"textblock"};n[20]={id:20,lvl:0,type:"char",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Psercod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PSERCOD",gxz:"Z329PSerCod",gxold:"O329PSerCod",gxvar:"A329PSerCod",ucs:[],op:[],ip:[20],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A329PSerCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z329PSerCod=n)},v2c:function(){gx.fn.setControlValue("PSERCOD",gx.O.A329PSerCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A329PSerCod=this.val())},val:function(){return gx.fn.getControlValue("PSERCOD")},nac:gx.falseFn};n[23]={id:23,fld:"TEXTBLOCK2",format:0,grid:0,ctrltype:"textblock"};n[25]={id:25,lvl:0,type:"char",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Maqcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MAQCOD",gxz:"Z320MAQCod",gxold:"O320MAQCod",gxvar:"A320MAQCod",ucs:[],op:[31],ip:[31,25,20],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A320MAQCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z320MAQCod=n)},v2c:function(){gx.fn.setControlValue("MAQCOD",gx.O.A320MAQCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A320MAQCod=this.val())},val:function(){return gx.fn.getControlValue("MAQCOD")},nac:gx.falseFn};n[26]={id:26,fld:"BTN_GET",grid:0,evt:"e184f154_client",std:"GET"};n[29]={id:29,fld:"TEXTBLOCK3",format:0,grid:0,ctrltype:"textblock"};n[31]={id:31,lvl:0,type:"decimal",len:15,dec:2,sign:!0,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PSERMAQCANT",gxz:"Z1811PSerMaqCant",gxold:"O1811PSerMaqCant",gxvar:"A1811PSerMaqCant",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1811PSerMaqCant=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z1811PSerMaqCant=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("PSERMAQCANT",gx.O.A1811PSerMaqCant,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A1811PSerMaqCant=this.val())},val:function(){return gx.fn.getDecimalValue("PSERMAQCANT",",",".")},nac:gx.falseFn};this.declareDomainHdlr(31,function(){});n[34]={id:34,fld:"BTN_ENTER",grid:0,evt:"e114f154_client",std:"ENTER"};n[35]={id:35,fld:"BTN_CHECK",grid:0,evt:"e194f154_client",std:"CHECK"};n[36]={id:36,fld:"BTN_CANCEL",grid:0,evt:"e124f154_client"};n[37]={id:37,fld:"BTN_DELETE",grid:0,evt:"e204f154_client",std:"DELETE"};n[38]={id:38,fld:"BTN_HELP",grid:0,evt:"e214f154_client"};this.A329PSerCod="";this.Z329PSerCod="";this.O329PSerCod="";this.A320MAQCod="";this.Z320MAQCod="";this.O320MAQCod="";this.A1811PSerMaqCant=0;this.Z1811PSerMaqCant=0;this.O1811PSerMaqCant=0;this.A329PSerCod="";this.A320MAQCod="";this.A1811PSerMaqCant=0;this.Events={e114f154_client:["ENTER",!0],e124f154_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_PSERCOD=[[{av:"A329PSerCod",fld:"PSERCOD",pic:""}],[]];this.EvtParms.VALID_MAQCOD=[[{av:"A329PSerCod",fld:"PSERCOD",pic:""},{av:"A320MAQCod",fld:"MAQCOD",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A1811PSerMaqCant",fld:"PSERMAQCANT",pic:"ZZZZZZ,ZZZ,ZZ9.99"},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z329PSerCod"},{av:"Z320MAQCod"},{av:"Z1811PSerMaqCant"},{ctrl:"BTN_GET",prop:"Enabled"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"},{ctrl:"BTN_CHECK",prop:"Enabled"}]];this.EnterCtrl=["BTN_ENTER"];this.CheckCtrl=["BTN_CHECK"];this.Initialize()});gx.wi(function(){gx.createParentObj(this.poorsermaq)})