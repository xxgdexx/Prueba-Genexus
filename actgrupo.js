gx.evt.autoSkip=!1;gx.define("actgrupo",!1,function(){this.ServerClass="actgrupo";this.PackageName="GeneXus.Programs";this.ServerFullClass="actgrupo.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Actclacod=function(){return this.validSrvEvt("Valid_Actclacod",0).then(function(n){return n}.closure(this))};this.Valid_Actgrupcod=function(){return this.validSrvEvt("Valid_Actgrupcod",0).then(function(n){return n}.closure(this))};this.e116x191_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e126x191_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,6,7,13,15,18,20,23,25,28,30,33,35];this.GXLastCtrlId=35;n[2]={id:2,fld:"GROUP1",grid:0};n[3]={id:3,fld:"TABLE2",grid:0};n[6]={id:6,fld:"IMAGE1",grid:0,evt:"e116x191_client",std:"ENTER"};n[7]={id:7,fld:"IMAGE2",grid:0,evt:"e136x191_client"};n[13]={id:13,fld:"TEXTBLOCK5",format:0,grid:0,ctrltype:"textblock"};n[15]={id:15,lvl:0,type:"svchar",len:5,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Actclacod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTCLACOD",gxz:"Z426ACTClaCod",gxold:"O426ACTClaCod",gxvar:"A426ACTClaCod",ucs:[],op:[],ip:[15],nacdep:[],ctrltype:"dyncombo",v2v:function(n){n!==undefined&&(gx.O.A426ACTClaCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z426ACTClaCod=n)},v2c:function(){gx.fn.setComboBoxValue("ACTCLACOD",gx.O.A426ACTClaCod)},c2v:function(){this.val()!==undefined&&(gx.O.A426ACTClaCod=this.val())},val:function(){return gx.fn.getControlValue("ACTCLACOD")},nac:gx.falseFn};n[18]={id:18,fld:"TEXTBLOCK1",format:0,grid:0,ctrltype:"textblock"};n[20]={id:20,lvl:0,type:"svchar",len:5,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Actgrupcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTGRUPCOD",gxz:"Z2103ACTGrupCod",gxold:"O2103ACTGrupCod",gxvar:"A2103ACTGrupCod",ucs:[],op:[35,30,25],ip:[35,30,25,20,15],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2103ACTGrupCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z2103ACTGrupCod=n)},v2c:function(){gx.fn.setControlValue("ACTGRUPCOD",gx.O.A2103ACTGrupCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2103ACTGrupCod=this.val())},val:function(){return gx.fn.getControlValue("ACTGRUPCOD")},nac:gx.falseFn};n[23]={id:23,fld:"TEXTBLOCK2",format:0,grid:0,ctrltype:"textblock"};n[25]={id:25,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTGRUPDSC",gxz:"Z2196ACTGrupDsc",gxold:"O2196ACTGrupDsc",gxvar:"A2196ACTGrupDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2196ACTGrupDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z2196ACTGrupDsc=n)},v2c:function(){gx.fn.setControlValue("ACTGRUPDSC",gx.O.A2196ACTGrupDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2196ACTGrupDsc=this.val())},val:function(){return gx.fn.getControlValue("ACTGRUPDSC")},nac:gx.falseFn};n[28]={id:28,fld:"TEXTBLOCK4",format:0,grid:0,ctrltype:"textblock"};n[30]={id:30,lvl:0,type:"svchar",len:5,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTGRUPABR",gxz:"Z2195ACTGrupAbr",gxold:"O2195ACTGrupAbr",gxvar:"A2195ACTGrupAbr",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2195ACTGrupAbr=n)},v2z:function(n){n!==undefined&&(gx.O.Z2195ACTGrupAbr=n)},v2c:function(){gx.fn.setControlValue("ACTGRUPABR",gx.O.A2195ACTGrupAbr,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2195ACTGrupAbr=this.val())},val:function(){return gx.fn.getControlValue("ACTGRUPABR")},nac:gx.falseFn};n[33]={id:33,fld:"TEXTBLOCK3",format:0,grid:0,ctrltype:"textblock"};n[35]={id:35,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTGRUPSTS",gxz:"Z2197ACTGrupSts",gxold:"O2197ACTGrupSts",gxvar:"A2197ACTGrupSts",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.A2197ACTGrupSts=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z2197ACTGrupSts=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("ACTGRUPSTS",gx.O.A2197ACTGrupSts)},c2v:function(){this.val()!==undefined&&(gx.O.A2197ACTGrupSts=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("ACTGRUPSTS",",")},nac:gx.falseFn};this.A426ACTClaCod="";this.Z426ACTClaCod="";this.O426ACTClaCod="";this.A2103ACTGrupCod="";this.Z2103ACTGrupCod="";this.O2103ACTGrupCod="";this.A2196ACTGrupDsc="";this.Z2196ACTGrupDsc="";this.O2196ACTGrupDsc="";this.A2195ACTGrupAbr="";this.Z2195ACTGrupAbr="";this.O2195ACTGrupAbr="";this.A2197ACTGrupSts=0;this.Z2197ACTGrupSts=0;this.O2197ACTGrupSts=0;this.A426ACTClaCod="";this.A2103ACTGrupCod="";this.A2196ACTGrupDsc="";this.A2195ACTGrupAbr="";this.A2197ACTGrupSts=0;this.Events={e116x191_client:["ENTER",!0],e126x191_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0},{ctrl:"ACTCLACOD"},{av:"A426ACTClaCod",fld:"ACTCLACOD",pic:""}],[{ctrl:"ACTCLACOD"},{av:"A426ACTClaCod",fld:"ACTCLACOD",pic:""}]];this.EvtParms.REFRESH=[[{ctrl:"ACTCLACOD"},{av:"A426ACTClaCod",fld:"ACTCLACOD",pic:""}],[{ctrl:"ACTCLACOD"},{av:"A426ACTClaCod",fld:"ACTCLACOD",pic:""}]];this.EvtParms.VALID_ACTCLACOD=[[{ctrl:"ACTCLACOD"},{av:"A426ACTClaCod",fld:"ACTCLACOD",pic:""}],[{ctrl:"ACTCLACOD"},{av:"A426ACTClaCod",fld:"ACTCLACOD",pic:""}]];this.EvtParms.VALID_ACTGRUPCOD=[[{ctrl:"ACTGRUPSTS"},{av:"A2197ACTGrupSts",fld:"ACTGRUPSTS",pic:"9"},{av:"A2103ACTGrupCod",fld:"ACTGRUPCOD",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{ctrl:"ACTCLACOD"},{av:"A426ACTClaCod",fld:"ACTCLACOD",pic:""}],[{av:"A2196ACTGrupDsc",fld:"ACTGRUPDSC",pic:""},{av:"A2195ACTGrupAbr",fld:"ACTGRUPABR",pic:""},{ctrl:"ACTGRUPSTS"},{av:"A2197ACTGrupSts",fld:"ACTGRUPSTS",pic:"9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z426ACTClaCod"},{av:"Z2103ACTGrupCod"},{av:"Z2196ACTGrupDsc"},{av:"Z2195ACTGrupAbr"},{av:"Z2197ACTGrupSts"},{av:'gx.fn.getCtrlProperty("IMAGE1","Enabled")',ctrl:"IMAGE1",prop:"Enabled"},{ctrl:"ACTCLACOD"},{av:"A426ACTClaCod",fld:"ACTCLACOD",pic:""}]];this.EnterCtrl=["IMAGE1"];this.Initialize()});gx.wi(function(){gx.createParentObj(this.actgrupo)})