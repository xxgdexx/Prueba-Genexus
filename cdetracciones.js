gx.evt.autoSkip=!1;gx.define("cdetracciones",!1,function(){this.ServerClass="cdetracciones";this.PackageName="GeneXus.Programs";this.ServerFullClass="cdetracciones.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Cdetcod=function(){return this.validSrvEvt("Valid_Cdetcod",0).then(function(n){return n}.closure(this))};this.Valid_Cdetdsc=function(){return this.validCliEvt("Valid_Cdetdsc",0,function(){try{var n=gx.util.balloon.getNew("CDETDSC");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Cdetporcentaje=function(){return this.validCliEvt("Valid_Cdetporcentaje",0,function(){try{var n=gx.util.balloon.getNew("CDETPORCENTAJE");this.AnyError=0;try{this.A518cDetDescripcion=gx.text.trim(this.A519cDetDsc)+" - "+gx.text.padl(gx.text.ltrim(gx.text.rtrim(gx.num.str(this.A520cDetPorcentaje,4,1))),6,"")+"%"}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e11066_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e12066_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57];this.GXLastCtrlId=57;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"TABLEMAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"BTN_FIRST",grid:0,evt:"e13066_client",std:"FIRST"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"BTN_PREVIOUS",grid:0,evt:"e14066_client",std:"PREVIOUS"};n[15]={id:15,fld:"",grid:0};n[16]={id:16,fld:"BTN_NEXT",grid:0,evt:"e15066_client",std:"NEXT"};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"BTN_LAST",grid:0,evt:"e16066_client",std:"LAST"};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"BTN_SELECT",grid:0,evt:"e17066_client",std:"SELECT"};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cdetcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CDETCOD",gxz:"Z46cDetCod",gxold:"O46cDetCod",gxvar:"A46cDetCod",ucs:[],op:[43,38,33],ip:[43,38,33,28],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A46cDetCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z46cDetCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("CDETCOD",gx.O.A46cDetCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A46cDetCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CDETCOD",",")},nac:gx.falseFn};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cdetdsc,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CDETDSC",gxz:"Z519cDetDsc",gxold:"O519cDetDsc",gxvar:"A519cDetDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A519cDetDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z519cDetDsc=n)},v2c:function(){gx.fn.setControlValue("CDETDSC",gx.O.A519cDetDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A519cDetDsc=this.val())},val:function(){return gx.fn.getControlValue("CDETDSC")},nac:gx.falseFn};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,lvl:0,type:"decimal",len:15,dec:2,sign:!0,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cdetporcentaje,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CDETPORCENTAJE",gxz:"Z520cDetPorcentaje",gxold:"O520cDetPorcentaje",gxvar:"A520cDetPorcentaje",ucs:[],op:[48],ip:[48,38,33],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A520cDetPorcentaje=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z520cDetPorcentaje=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("CDETPORCENTAJE",gx.O.A520cDetPorcentaje,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A520cDetPorcentaje=this.val())},val:function(){return gx.fn.getDecimalValue("CDETPORCENTAJE",",",".")},nac:gx.falseFn};this.declareDomainHdlr(38,function(){});n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CDETSTS",gxz:"Z521cDetSts",gxold:"O521cDetSts",gxvar:"A521cDetSts",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A521cDetSts=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z521cDetSts=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("CDETSTS",gx.O.A521cDetSts,0)},c2v:function(){this.val()!==undefined&&(gx.O.A521cDetSts=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CDETSTS",",")},nac:gx.falseFn};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CDETDESCRIPCION",gxz:"Z518cDetDescripcion",gxold:"O518cDetDescripcion",gxvar:"A518cDetDescripcion",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A518cDetDescripcion=n)},v2z:function(n){n!==undefined&&(gx.O.Z518cDetDescripcion=n)},v2c:function(){gx.fn.setControlValue("CDETDESCRIPCION",gx.O.A518cDetDescripcion,0)},c2v:function(){this.val()!==undefined&&(gx.O.A518cDetDescripcion=this.val())},val:function(){return gx.fn.getControlValue("CDETDESCRIPCION")},nac:gx.falseFn};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"BTN_ENTER",grid:0,evt:"e11066_client",std:"ENTER"};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"BTN_CANCEL",grid:0,evt:"e12066_client"};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"BTN_DELETE",grid:0,evt:"e18066_client",std:"DELETE"};this.A46cDetCod=0;this.Z46cDetCod=0;this.O46cDetCod=0;this.A519cDetDsc="";this.Z519cDetDsc="";this.O519cDetDsc="";this.A520cDetPorcentaje=0;this.Z520cDetPorcentaje=0;this.O520cDetPorcentaje=0;this.A521cDetSts=0;this.Z521cDetSts=0;this.O521cDetSts=0;this.A518cDetDescripcion="";this.Z518cDetDescripcion="";this.O518cDetDescripcion="";this.A46cDetCod=0;this.A518cDetDescripcion="";this.A519cDetDsc="";this.A520cDetPorcentaje=0;this.A521cDetSts=0;this.Events={e11066_client:["ENTER",!0],e12066_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_CDETCOD=[[{av:"A46cDetCod",fld:"CDETCOD",pic:"ZZZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A519cDetDsc",fld:"CDETDSC",pic:""},{av:"A520cDetPorcentaje",fld:"CDETPORCENTAJE",pic:"ZZZZZZ,ZZZ,ZZ9.99"},{av:"A521cDetSts",fld:"CDETSTS",pic:"9"},{av:"A518cDetDescripcion",fld:"CDETDESCRIPCION",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z46cDetCod"},{av:"Z519cDetDsc"},{av:"Z520cDetPorcentaje"},{av:"Z521cDetSts"},{av:"Z518cDetDescripcion"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"}]];this.EvtParms.VALID_CDETDSC=[[],[]];this.EvtParms.VALID_CDETPORCENTAJE=[[{av:"A518cDetDescripcion",fld:"CDETDESCRIPCION",pic:""},{av:"A520cDetPorcentaje",fld:"CDETPORCENTAJE",pic:"ZZZZZZ,ZZZ,ZZ9.99"},{av:"A519cDetDsc",fld:"CDETDSC",pic:""}],[{av:"A518cDetDescripcion",fld:"CDETDESCRIPCION",pic:""}]];this.EnterCtrl=["BTN_ENTER"];this.Initialize()});gx.wi(function(){gx.createParentObj(this.cdetracciones)})