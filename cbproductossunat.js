gx.evt.autoSkip=!1;gx.define("cbproductossunat",!1,function(){this.ServerClass="cbproductossunat";this.PackageName="GeneXus.Programs";this.ServerFullClass="cbproductossunat.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Cbsucod=function(){return this.validSrvEvt("Valid_Cbsucod",0).then(function(n){return n}.closure(this))};this.e11055_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e12055_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42];this.GXLastCtrlId=42;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"TABLEMAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"BTN_FIRST",grid:0,evt:"e13055_client",std:"FIRST"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"BTN_PREVIOUS",grid:0,evt:"e14055_client",std:"PREVIOUS"};n[15]={id:15,fld:"",grid:0};n[16]={id:16,fld:"BTN_NEXT",grid:0,evt:"e15055_client",std:"NEXT"};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"BTN_LAST",grid:0,evt:"e16055_client",std:"LAST"};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"BTN_SELECT",grid:0,evt:"e17055_client",std:"SELECT"};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cbsucod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CBSUCOD",gxz:"Z47CBSuCod",gxold:"O47CBSuCod",gxvar:"A47CBSuCod",ucs:[],op:[33],ip:[33,28],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A47CBSuCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z47CBSuCod=n)},v2c:function(){gx.fn.setControlValue("CBSUCOD",gx.O.A47CBSuCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A47CBSuCod=this.val())},val:function(){return gx.fn.getControlValue("CBSUCOD")},nac:gx.falseFn};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,lvl:0,type:"svchar",len:200,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CBSUDSC",gxz:"Z505CBSuDsc",gxold:"O505CBSuDsc",gxvar:"A505CBSuDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A505CBSuDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z505CBSuDsc=n)},v2c:function(){gx.fn.setControlValue("CBSUDSC",gx.O.A505CBSuDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A505CBSuDsc=this.val())},val:function(){return gx.fn.getControlValue("CBSUDSC")},nac:gx.falseFn};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"BTN_ENTER",grid:0,evt:"e11055_client",std:"ENTER"};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"BTN_CANCEL",grid:0,evt:"e12055_client"};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"BTN_DELETE",grid:0,evt:"e18055_client",std:"DELETE"};this.A47CBSuCod="";this.Z47CBSuCod="";this.O47CBSuCod="";this.A505CBSuDsc="";this.Z505CBSuDsc="";this.O505CBSuDsc="";this.A47CBSuCod="";this.A505CBSuDsc="";this.Events={e11055_client:["ENTER",!0],e12055_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_CBSUCOD=[[{av:"A47CBSuCod",fld:"CBSUCOD",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A505CBSuDsc",fld:"CBSUDSC",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z47CBSuCod"},{av:"Z505CBSuDsc"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"}]];this.EnterCtrl=["BTN_ENTER"];this.Initialize()});gx.wi(function(){gx.createParentObj(this.cbproductossunat)})