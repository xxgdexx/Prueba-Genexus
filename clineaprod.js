gx.evt.autoSkip=!1;gx.define("clineaprod",!1,function(){this.ServerClass="clineaprod";this.PackageName="GeneXus.Programs";this.ServerFullClass="clineaprod.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Lincod=function(){return this.validSrvEvt("Valid_Lincod",0).then(function(n){return n}.closure(this))};this.e112o17_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e122o17_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,5,6,7,8,9,15,18,20,21,24,26,29,31,34,36,39,41,44,46,49,51,54,56,59,61,64,66,69,70,71,72,73];this.GXLastCtrlId=73;n[2]={id:2,fld:"TABLE1",grid:0};n[5]={id:5,fld:"BTN_FIRST",grid:0,evt:"e132o17_client",std:"FIRST"};n[6]={id:6,fld:"BTN_PREVIOUS",grid:0,evt:"e142o17_client",std:"PREVIOUS"};n[7]={id:7,fld:"BTN_NEXT",grid:0,evt:"e152o17_client",std:"NEXT"};n[8]={id:8,fld:"BTN_LAST",grid:0,evt:"e162o17_client",std:"LAST"};n[9]={id:9,fld:"BTN_SELECT",grid:0,evt:"e172o17_client",std:"SELECT"};n[15]={id:15,fld:"TABLE2",grid:0};n[18]={id:18,fld:"TEXTBLOCK1",format:0,grid:0,ctrltype:"textblock"};n[20]={id:20,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Lincod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LINCOD",gxz:"Z52LinCod",gxold:"O52LinCod",gxvar:"A52LinCod",ucs:[],op:[66,61,56,51,46,41,36,31,26],ip:[66,61,56,51,46,41,36,31,26,20],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A52LinCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z52LinCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("LINCOD",gx.O.A52LinCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A52LinCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("LINCOD",",")},nac:gx.falseFn};n[21]={id:21,fld:"BTN_GET",grid:0,evt:"e182o17_client",std:"GET"};n[24]={id:24,fld:"TEXTBLOCK2",format:0,grid:0,ctrltype:"textblock"};n[26]={id:26,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LINDSC",gxz:"Z1153LinDsc",gxold:"O1153LinDsc",gxvar:"A1153LinDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1153LinDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z1153LinDsc=n)},v2c:function(){gx.fn.setControlValue("LINDSC",gx.O.A1153LinDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1153LinDsc=this.val())},val:function(){return gx.fn.getControlValue("LINDSC")},nac:gx.falseFn};n[29]={id:29,fld:"TEXTBLOCK3",format:0,grid:0,ctrltype:"textblock"};n[31]={id:31,lvl:0,type:"char",len:5,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LINABR",gxz:"Z1152LinAbr",gxold:"O1152LinAbr",gxvar:"A1152LinAbr",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1152LinAbr=n)},v2z:function(n){n!==undefined&&(gx.O.Z1152LinAbr=n)},v2c:function(){gx.fn.setControlValue("LINABR",gx.O.A1152LinAbr,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1152LinAbr=this.val())},val:function(){return gx.fn.getControlValue("LINABR")},nac:gx.falseFn};n[34]={id:34,fld:"TEXTBLOCK4",format:0,grid:0,ctrltype:"textblock"};n[36]={id:36,lvl:0,type:"svchar",len:5,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LINSUNAT",gxz:"Z1160LinSunat",gxold:"O1160LinSunat",gxvar:"A1160LinSunat",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1160LinSunat=n)},v2z:function(n){n!==undefined&&(gx.O.Z1160LinSunat=n)},v2c:function(){gx.fn.setControlValue("LINSUNAT",gx.O.A1160LinSunat,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1160LinSunat=this.val())},val:function(){return gx.fn.getControlValue("LINSUNAT")},nac:gx.falseFn};n[39]={id:39,fld:"TEXTBLOCK5",format:0,grid:0,ctrltype:"textblock"};n[41]={id:41,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LINSTK",gxz:"Z1158LinStk",gxold:"O1158LinStk",gxvar:"A1158LinStk",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1158LinStk=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1158LinStk=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("LINSTK",gx.O.A1158LinStk,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1158LinStk=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("LINSTK",",")},nac:gx.falseFn};n[44]={id:44,fld:"TEXTBLOCK6",format:0,grid:0,ctrltype:"textblock"};n[46]={id:46,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LINSTS",gxz:"Z1159LinSts",gxold:"O1159LinSts",gxvar:"A1159LinSts",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1159LinSts=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1159LinSts=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("LINSTS",gx.O.A1159LinSts,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1159LinSts=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("LINSTS",",")},nac:gx.falseFn};n[49]={id:49,fld:"TEXTBLOCK7",format:0,grid:0,ctrltype:"textblock"};n[51]={id:51,lvl:0,type:"svchar",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LINREF1",gxz:"Z1154LinRef1",gxold:"O1154LinRef1",gxvar:"A1154LinRef1",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1154LinRef1=n)},v2z:function(n){n!==undefined&&(gx.O.Z1154LinRef1=n)},v2c:function(){gx.fn.setControlValue("LINREF1",gx.O.A1154LinRef1,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1154LinRef1=this.val())},val:function(){return gx.fn.getControlValue("LINREF1")},nac:gx.falseFn};n[54]={id:54,fld:"TEXTBLOCK8",format:0,grid:0,ctrltype:"textblock"};n[56]={id:56,lvl:0,type:"svchar",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LINREF2",gxz:"Z1155LinRef2",gxold:"O1155LinRef2",gxvar:"A1155LinRef2",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1155LinRef2=n)},v2z:function(n){n!==undefined&&(gx.O.Z1155LinRef2=n)},v2c:function(){gx.fn.setControlValue("LINREF2",gx.O.A1155LinRef2,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1155LinRef2=this.val())},val:function(){return gx.fn.getControlValue("LINREF2")},nac:gx.falseFn};n[59]={id:59,fld:"TEXTBLOCK9",format:0,grid:0,ctrltype:"textblock"};n[61]={id:61,lvl:0,type:"svchar",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LINREF3",gxz:"Z1156LinRef3",gxold:"O1156LinRef3",gxvar:"A1156LinRef3",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1156LinRef3=n)},v2z:function(n){n!==undefined&&(gx.O.Z1156LinRef3=n)},v2c:function(){gx.fn.setControlValue("LINREF3",gx.O.A1156LinRef3,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1156LinRef3=this.val())},val:function(){return gx.fn.getControlValue("LINREF3")},nac:gx.falseFn};n[64]={id:64,fld:"TEXTBLOCK10",format:0,grid:0,ctrltype:"textblock"};n[66]={id:66,lvl:0,type:"svchar",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LINREF4",gxz:"Z1157LinRef4",gxold:"O1157LinRef4",gxvar:"A1157LinRef4",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1157LinRef4=n)},v2z:function(n){n!==undefined&&(gx.O.Z1157LinRef4=n)},v2c:function(){gx.fn.setControlValue("LINREF4",gx.O.A1157LinRef4,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1157LinRef4=this.val())},val:function(){return gx.fn.getControlValue("LINREF4")},nac:gx.falseFn};n[69]={id:69,fld:"BTN_ENTER",grid:0,evt:"e112o17_client",std:"ENTER"};n[70]={id:70,fld:"BTN_CHECK",grid:0,evt:"e192o17_client",std:"CHECK"};n[71]={id:71,fld:"BTN_CANCEL",grid:0,evt:"e122o17_client"};n[72]={id:72,fld:"BTN_DELETE",grid:0,evt:"e202o17_client",std:"DELETE"};n[73]={id:73,fld:"BTN_HELP",grid:0,evt:"e212o17_client"};this.A52LinCod=0;this.Z52LinCod=0;this.O52LinCod=0;this.A1153LinDsc="";this.Z1153LinDsc="";this.O1153LinDsc="";this.A1152LinAbr="";this.Z1152LinAbr="";this.O1152LinAbr="";this.A1160LinSunat="";this.Z1160LinSunat="";this.O1160LinSunat="";this.A1158LinStk=0;this.Z1158LinStk=0;this.O1158LinStk=0;this.A1159LinSts=0;this.Z1159LinSts=0;this.O1159LinSts=0;this.A1154LinRef1="";this.Z1154LinRef1="";this.O1154LinRef1="";this.A1155LinRef2="";this.Z1155LinRef2="";this.O1155LinRef2="";this.A1156LinRef3="";this.Z1156LinRef3="";this.O1156LinRef3="";this.A1157LinRef4="";this.Z1157LinRef4="";this.O1157LinRef4="";this.A52LinCod=0;this.A1153LinDsc="";this.A1152LinAbr="";this.A1160LinSunat="";this.A1158LinStk=0;this.A1159LinSts=0;this.A1154LinRef1="";this.A1155LinRef2="";this.A1156LinRef3="";this.A1157LinRef4="";this.Events={e112o17_client:["ENTER",!0],e122o17_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_LINCOD=[[{av:"A52LinCod",fld:"LINCOD",pic:"ZZZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A1153LinDsc",fld:"LINDSC",pic:""},{av:"A1152LinAbr",fld:"LINABR",pic:""},{av:"A1160LinSunat",fld:"LINSUNAT",pic:""},{av:"A1158LinStk",fld:"LINSTK",pic:"9"},{av:"A1159LinSts",fld:"LINSTS",pic:"9"},{av:"A1154LinRef1",fld:"LINREF1",pic:""},{av:"A1155LinRef2",fld:"LINREF2",pic:""},{av:"A1156LinRef3",fld:"LINREF3",pic:""},{av:"A1157LinRef4",fld:"LINREF4",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z52LinCod"},{av:"Z1153LinDsc"},{av:"Z1152LinAbr"},{av:"Z1160LinSunat"},{av:"Z1158LinStk"},{av:"Z1159LinSts"},{av:"Z1154LinRef1"},{av:"Z1155LinRef2"},{av:"Z1156LinRef3"},{av:"Z1157LinRef4"},{ctrl:"BTN_GET",prop:"Enabled"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"},{ctrl:"BTN_CHECK",prop:"Enabled"}]];this.EnterCtrl=["BTN_ENTER"];this.CheckCtrl=["BTN_CHECK"];this.Initialize()});gx.wi(function(){gx.createParentObj(this.clineaprod)})