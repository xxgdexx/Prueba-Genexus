gx.evt.autoSkip=!1;gx.define("actarea",!1,function(){this.ServerClass="actarea";this.PackageName="GeneXus.Programs";this.ServerFullClass="actarea.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Actareacod=function(){return this.validSrvEvt("Valid_Actareacod",0).then(function(n){return n}.closure(this))};this.e116t187_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e126t187_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,6,7,13,15,18,20,23,25];this.GXLastCtrlId=25;n[2]={id:2,fld:"GROUP1",grid:0};n[3]={id:3,fld:"TABLE2",grid:0};n[6]={id:6,fld:"IMAGE1",grid:0,evt:"e116t187_client",std:"ENTER"};n[7]={id:7,fld:"IMAGE2",grid:0,evt:"e136t187_client"};n[13]={id:13,fld:"TEXTBLOCK1",format:0,grid:0,ctrltype:"textblock"};n[15]={id:15,lvl:0,type:"svchar",len:5,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Actareacod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTAREACOD",gxz:"Z2102ACTAreaCod",gxold:"O2102ACTAreaCod",gxvar:"A2102ACTAreaCod",ucs:[],op:[25,20],ip:[25,20,15],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2102ACTAreaCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z2102ACTAreaCod=n)},v2c:function(){gx.fn.setControlValue("ACTAREACOD",gx.O.A2102ACTAreaCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2102ACTAreaCod=this.val())},val:function(){return gx.fn.getControlValue("ACTAREACOD")},nac:gx.falseFn};n[18]={id:18,fld:"TEXTBLOCK2",format:0,grid:0,ctrltype:"textblock"};n[20]={id:20,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTAREADSC",gxz:"Z2172ACTAreaDsc",gxold:"O2172ACTAreaDsc",gxvar:"A2172ACTAreaDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2172ACTAreaDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z2172ACTAreaDsc=n)},v2c:function(){gx.fn.setControlValue("ACTAREADSC",gx.O.A2172ACTAreaDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2172ACTAreaDsc=this.val())},val:function(){return gx.fn.getControlValue("ACTAREADSC")},nac:gx.falseFn};n[23]={id:23,fld:"TEXTBLOCK3",format:0,grid:0,ctrltype:"textblock"};n[25]={id:25,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTAREASTS",gxz:"Z2173ACTAreaSts",gxold:"O2173ACTAreaSts",gxvar:"A2173ACTAreaSts",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.A2173ACTAreaSts=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z2173ACTAreaSts=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("ACTAREASTS",gx.O.A2173ACTAreaSts)},c2v:function(){this.val()!==undefined&&(gx.O.A2173ACTAreaSts=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("ACTAREASTS",",")},nac:gx.falseFn};this.A2102ACTAreaCod="";this.Z2102ACTAreaCod="";this.O2102ACTAreaCod="";this.A2172ACTAreaDsc="";this.Z2172ACTAreaDsc="";this.O2172ACTAreaDsc="";this.A2173ACTAreaSts=0;this.Z2173ACTAreaSts=0;this.O2173ACTAreaSts=0;this.A2102ACTAreaCod="";this.A2172ACTAreaDsc="";this.A2173ACTAreaSts=0;this.Events={e116t187_client:["ENTER",!0],e126t187_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_ACTAREACOD=[[{ctrl:"ACTAREASTS"},{av:"A2173ACTAreaSts",fld:"ACTAREASTS",pic:"9"},{av:"A2102ACTAreaCod",fld:"ACTAREACOD",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A2172ACTAreaDsc",fld:"ACTAREADSC",pic:""},{ctrl:"ACTAREASTS"},{av:"A2173ACTAreaSts",fld:"ACTAREASTS",pic:"9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z2102ACTAreaCod"},{av:"Z2172ACTAreaDsc"},{av:"Z2173ACTAreaSts"},{av:'gx.fn.getCtrlProperty("IMAGE1","Enabled")',ctrl:"IMAGE1",prop:"Enabled"}]];this.EnterCtrl=["IMAGE1"];this.Initialize()});gx.wi(function(){gx.createParentObj(this.actarea)})