gx.evt.autoSkip=!1;gx.define("cmonedas",!1,function(){this.ServerClass="cmonedas";this.PackageName="GeneXus.Programs";this.ServerFullClass="cmonedas.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.A1236MonSunat=gx.fn.getControlValue("MONSUNAT")};this.Valid_Moncod=function(){return this.validSrvEvt("Valid_Moncod",0).then(function(n){return n}.closure(this))};this.e1130103_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e1230103_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,5,6,7,8,9,15,18,20,21,24,26,29,31,34,36,39,40,41,42,43];this.GXLastCtrlId=43;n[2]={id:2,fld:"TABLE1",grid:0};n[5]={id:5,fld:"BTN_FIRST",grid:0,evt:"e1330103_client",std:"FIRST"};n[6]={id:6,fld:"BTN_PREVIOUS",grid:0,evt:"e1430103_client",std:"PREVIOUS"};n[7]={id:7,fld:"BTN_NEXT",grid:0,evt:"e1530103_client",std:"NEXT"};n[8]={id:8,fld:"BTN_LAST",grid:0,evt:"e1630103_client",std:"LAST"};n[9]={id:9,fld:"BTN_SELECT",grid:0,evt:"e1730103_client",std:"SELECT"};n[15]={id:15,fld:"TABLE2",grid:0};n[18]={id:18,fld:"TEXTBLOCK1",format:0,grid:0,ctrltype:"textblock"};n[20]={id:20,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Moncod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MONCOD",gxz:"Z180MonCod",gxold:"O180MonCod",gxvar:"A180MonCod",ucs:[],op:[36,31,26],ip:[36,31,26,20],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A180MonCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z180MonCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("MONCOD",gx.O.A180MonCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A180MonCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("MONCOD",",")},nac:gx.falseFn};n[21]={id:21,fld:"BTN_GET",grid:0,evt:"e1830103_client",std:"GET"};n[24]={id:24,fld:"TEXTBLOCK2",format:0,grid:0,ctrltype:"textblock"};n[26]={id:26,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MONDSC",gxz:"Z1234MonDsc",gxold:"O1234MonDsc",gxvar:"A1234MonDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1234MonDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z1234MonDsc=n)},v2c:function(){gx.fn.setControlValue("MONDSC",gx.O.A1234MonDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1234MonDsc=this.val())},val:function(){return gx.fn.getControlValue("MONDSC")},nac:gx.falseFn};n[29]={id:29,fld:"TEXTBLOCK3",format:0,grid:0,ctrltype:"textblock"};n[31]={id:31,lvl:0,type:"char",len:5,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MONABR",gxz:"Z1233MonAbr",gxold:"O1233MonAbr",gxvar:"A1233MonAbr",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1233MonAbr=n)},v2z:function(n){n!==undefined&&(gx.O.Z1233MonAbr=n)},v2c:function(){gx.fn.setControlValue("MONABR",gx.O.A1233MonAbr,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1233MonAbr=this.val())},val:function(){return gx.fn.getControlValue("MONABR")},nac:gx.falseFn};n[34]={id:34,fld:"TEXTBLOCK4",format:0,grid:0,ctrltype:"textblock"};n[36]={id:36,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MONSTS",gxz:"Z1235MonSts",gxold:"O1235MonSts",gxvar:"A1235MonSts",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1235MonSts=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1235MonSts=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("MONSTS",gx.O.A1235MonSts,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1235MonSts=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("MONSTS",",")},nac:gx.falseFn};n[39]={id:39,fld:"BTN_ENTER",grid:0,evt:"e1130103_client",std:"ENTER"};n[40]={id:40,fld:"BTN_CHECK",grid:0,evt:"e1930103_client",std:"CHECK"};n[41]={id:41,fld:"BTN_CANCEL",grid:0,evt:"e1230103_client"};n[42]={id:42,fld:"BTN_DELETE",grid:0,evt:"e2030103_client",std:"DELETE"};n[43]={id:43,fld:"BTN_HELP",grid:0,evt:"e2130103_client"};this.A180MonCod=0;this.Z180MonCod=0;this.O180MonCod=0;this.A1234MonDsc="";this.Z1234MonDsc="";this.O1234MonDsc="";this.A1233MonAbr="";this.Z1233MonAbr="";this.O1233MonAbr="";this.A1235MonSts=0;this.Z1235MonSts=0;this.O1235MonSts=0;this.A180MonCod=0;this.A1234MonDsc="";this.A1233MonAbr="";this.A1235MonSts=0;this.A1236MonSunat="";this.Events={e1130103_client:["ENTER",!0],e1230103_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[{av:"A1236MonSunat",fld:"MONSUNAT",pic:""}],[]];this.EvtParms.VALID_MONCOD=[[{av:"A1236MonSunat",fld:"MONSUNAT",pic:""},{av:"A180MonCod",fld:"MONCOD",pic:"ZZZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A1234MonDsc",fld:"MONDSC",pic:""},{av:"A1233MonAbr",fld:"MONABR",pic:""},{av:"A1235MonSts",fld:"MONSTS",pic:"9"},{av:"A1236MonSunat",fld:"MONSUNAT",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z180MonCod"},{av:"Z1234MonDsc"},{av:"Z1233MonAbr"},{av:"Z1235MonSts"},{av:"Z1236MonSunat"},{ctrl:"BTN_GET",prop:"Enabled"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"},{ctrl:"BTN_CHECK",prop:"Enabled"}]];this.EnterCtrl=["BTN_ENTER"];this.CheckCtrl=["BTN_CHECK"];this.setVCMap("A1236MonSunat","MONSUNAT",0,"svchar",3,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.cmonedas)})