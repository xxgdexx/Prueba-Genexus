gx.evt.autoSkip=!1;gx.define("aunitrasportes",!1,function(){this.ServerClass="aunitrasportes";this.PackageName="GeneXus.Programs";this.ServerFullClass="aunitrasportes.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Untcod=function(){return this.validSrvEvt("Valid_Untcod",0).then(function(n){return n}.closure(this))};this.e111j53_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e121j53_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,5,6,7,8,9,15,18,20,21,24,26,29,31,34,36,39,41,44,46,49,51,54,55,56,57,58];this.GXLastCtrlId=58;n[2]={id:2,fld:"TABLE1",grid:0};n[5]={id:5,fld:"BTN_FIRST",grid:0,evt:"e131j53_client",std:"FIRST"};n[6]={id:6,fld:"BTN_PREVIOUS",grid:0,evt:"e141j53_client",std:"PREVIOUS"};n[7]={id:7,fld:"BTN_NEXT",grid:0,evt:"e151j53_client",std:"NEXT"};n[8]={id:8,fld:"BTN_LAST",grid:0,evt:"e161j53_client",std:"LAST"};n[9]={id:9,fld:"BTN_SELECT",grid:0,evt:"e171j53_client",std:"SELECT"};n[15]={id:15,fld:"TABLE2",grid:0};n[18]={id:18,fld:"TEXTBLOCK1",format:0,grid:0,ctrltype:"textblock"};n[20]={id:20,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Untcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"UNTCOD",gxz:"Z9UNTCod",gxold:"O9UNTCod",gxvar:"A9UNTCod",ucs:[],op:[51,46,41,36,31,26],ip:[51,46,41,36,31,26,20],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A9UNTCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z9UNTCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("UNTCOD",gx.O.A9UNTCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A9UNTCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("UNTCOD",",")},nac:gx.falseFn};n[21]={id:21,fld:"BTN_GET",grid:0,evt:"e181j53_client",std:"GET"};n[24]={id:24,fld:"TEXTBLOCK2",format:0,grid:0,ctrltype:"textblock"};n[26]={id:26,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"UNTDSC",gxz:"Z2002UNTDsc",gxold:"O2002UNTDsc",gxvar:"A2002UNTDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2002UNTDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z2002UNTDsc=n)},v2c:function(){gx.fn.setControlValue("UNTDSC",gx.O.A2002UNTDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2002UNTDsc=this.val())},val:function(){return gx.fn.getControlValue("UNTDSC")},nac:gx.falseFn};n[29]={id:29,fld:"TEXTBLOCK3",format:0,grid:0,ctrltype:"textblock"};n[31]={id:31,lvl:0,type:"char",len:50,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"UNTMARCA",gxz:"Z2003UNTMarca",gxold:"O2003UNTMarca",gxvar:"A2003UNTMarca",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2003UNTMarca=n)},v2z:function(n){n!==undefined&&(gx.O.Z2003UNTMarca=n)},v2c:function(){gx.fn.setControlValue("UNTMARCA",gx.O.A2003UNTMarca,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2003UNTMarca=this.val())},val:function(){return gx.fn.getControlValue("UNTMARCA")},nac:gx.falseFn};n[34]={id:34,fld:"TEXTBLOCK4",format:0,grid:0,ctrltype:"textblock"};n[36]={id:36,lvl:0,type:"char",len:50,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"UNTPLACA",gxz:"Z2005UNTPlaca",gxold:"O2005UNTPlaca",gxvar:"A2005UNTPlaca",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2005UNTPlaca=n)},v2z:function(n){n!==undefined&&(gx.O.Z2005UNTPlaca=n)},v2c:function(){gx.fn.setControlValue("UNTPLACA",gx.O.A2005UNTPlaca,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2005UNTPlaca=this.val())},val:function(){return gx.fn.getControlValue("UNTPLACA")},nac:gx.falseFn};n[39]={id:39,fld:"TEXTBLOCK5",format:0,grid:0,ctrltype:"textblock"};n[41]={id:41,lvl:0,type:"char",len:50,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"UNTMOD",gxz:"Z2004UNTMod",gxold:"O2004UNTMod",gxvar:"A2004UNTMod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2004UNTMod=n)},v2z:function(n){n!==undefined&&(gx.O.Z2004UNTMod=n)},v2c:function(){gx.fn.setControlValue("UNTMOD",gx.O.A2004UNTMod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2004UNTMod=this.val())},val:function(){return gx.fn.getControlValue("UNTMOD")},nac:gx.falseFn};n[44]={id:44,fld:"TEXTBLOCK6",format:0,grid:0,ctrltype:"textblock"};n[46]={id:46,lvl:0,type:"char",len:50,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"UNTANO",gxz:"Z2001UNTAno",gxold:"O2001UNTAno",gxvar:"A2001UNTAno",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2001UNTAno=n)},v2z:function(n){n!==undefined&&(gx.O.Z2001UNTAno=n)},v2c:function(){gx.fn.setControlValue("UNTANO",gx.O.A2001UNTAno,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2001UNTAno=this.val())},val:function(){return gx.fn.getControlValue("UNTANO")},nac:gx.falseFn};n[49]={id:49,fld:"TEXTBLOCK7",format:0,grid:0,ctrltype:"textblock"};n[51]={id:51,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"UNTSTS",gxz:"Z2006UNTSts",gxold:"O2006UNTSts",gxvar:"A2006UNTSts",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2006UNTSts=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z2006UNTSts=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("UNTSTS",gx.O.A2006UNTSts,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2006UNTSts=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("UNTSTS",",")},nac:gx.falseFn};n[54]={id:54,fld:"BTN_ENTER",grid:0,evt:"e111j53_client",std:"ENTER"};n[55]={id:55,fld:"BTN_CHECK",grid:0,evt:"e191j53_client",std:"CHECK"};n[56]={id:56,fld:"BTN_CANCEL",grid:0,evt:"e121j53_client"};n[57]={id:57,fld:"BTN_DELETE",grid:0,evt:"e201j53_client",std:"DELETE"};n[58]={id:58,fld:"BTN_HELP",grid:0,evt:"e211j53_client"};this.A9UNTCod=0;this.Z9UNTCod=0;this.O9UNTCod=0;this.A2002UNTDsc="";this.Z2002UNTDsc="";this.O2002UNTDsc="";this.A2003UNTMarca="";this.Z2003UNTMarca="";this.O2003UNTMarca="";this.A2005UNTPlaca="";this.Z2005UNTPlaca="";this.O2005UNTPlaca="";this.A2004UNTMod="";this.Z2004UNTMod="";this.O2004UNTMod="";this.A2001UNTAno="";this.Z2001UNTAno="";this.O2001UNTAno="";this.A2006UNTSts=0;this.Z2006UNTSts=0;this.O2006UNTSts=0;this.A9UNTCod=0;this.A2002UNTDsc="";this.A2003UNTMarca="";this.A2005UNTPlaca="";this.A2004UNTMod="";this.A2001UNTAno="";this.A2006UNTSts=0;this.Events={e111j53_client:["ENTER",!0],e121j53_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_UNTCOD=[[{av:"A9UNTCod",fld:"UNTCOD",pic:"ZZZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A2002UNTDsc",fld:"UNTDSC",pic:""},{av:"A2003UNTMarca",fld:"UNTMARCA",pic:""},{av:"A2005UNTPlaca",fld:"UNTPLACA",pic:""},{av:"A2004UNTMod",fld:"UNTMOD",pic:""},{av:"A2001UNTAno",fld:"UNTANO",pic:""},{av:"A2006UNTSts",fld:"UNTSTS",pic:"9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z9UNTCod"},{av:"Z2002UNTDsc"},{av:"Z2003UNTMarca"},{av:"Z2005UNTPlaca"},{av:"Z2004UNTMod"},{av:"Z2001UNTAno"},{av:"Z2006UNTSts"},{ctrl:"BTN_GET",prop:"Enabled"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"},{ctrl:"BTN_CHECK",prop:"Enabled"}]];this.EnterCtrl=["BTN_ENTER"];this.CheckCtrl=["BTN_CHECK"];this.Initialize()});gx.wi(function(){gx.createParentObj(this.aunitrasportes)})