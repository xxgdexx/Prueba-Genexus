gx.evt.autoSkip=!1;gx.define("pooperarios",!1,function(){this.ServerClass="pooperarios";this.PackageName="GeneXus.Programs";this.ServerFullClass="pooperarios.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Opecod=function(){return this.validSrvEvt("Valid_Opecod",0).then(function(n){return n}.closure(this))};this.e1147146_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e1247146_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,5,6,7,8,9,15,18,20,21,24,26,29,31,34,35,36,37,38];this.GXLastCtrlId=38;n[2]={id:2,fld:"TABLE1",grid:0};n[5]={id:5,fld:"BTN_FIRST",grid:0,evt:"e1347146_client",std:"FIRST"};n[6]={id:6,fld:"BTN_PREVIOUS",grid:0,evt:"e1447146_client",std:"PREVIOUS"};n[7]={id:7,fld:"BTN_NEXT",grid:0,evt:"e1547146_client",std:"NEXT"};n[8]={id:8,fld:"BTN_LAST",grid:0,evt:"e1647146_client",std:"LAST"};n[9]={id:9,fld:"BTN_SELECT",grid:0,evt:"e1747146_client",std:"SELECT"};n[15]={id:15,fld:"TABLE2",grid:0};n[18]={id:18,fld:"TEXTBLOCK1",format:0,grid:0,ctrltype:"textblock"};n[20]={id:20,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Opecod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"OPECOD",gxz:"Z321OPECod",gxold:"O321OPECod",gxvar:"A321OPECod",ucs:[],op:[31,26],ip:[31,26,20],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A321OPECod=n)},v2z:function(n){n!==undefined&&(gx.O.Z321OPECod=n)},v2c:function(){gx.fn.setControlValue("OPECOD",gx.O.A321OPECod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A321OPECod=this.val())},val:function(){return gx.fn.getControlValue("OPECOD")},nac:gx.falseFn};n[21]={id:21,fld:"BTN_GET",grid:0,evt:"e1847146_client",std:"GET"};n[24]={id:24,fld:"TEXTBLOCK2",format:0,grid:0,ctrltype:"textblock"};n[26]={id:26,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"OPEDSC",gxz:"Z1422OPEDsc",gxold:"O1422OPEDsc",gxvar:"A1422OPEDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1422OPEDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z1422OPEDsc=n)},v2c:function(){gx.fn.setControlValue("OPEDSC",gx.O.A1422OPEDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1422OPEDsc=this.val())},val:function(){return gx.fn.getControlValue("OPEDSC")},nac:gx.falseFn};n[29]={id:29,fld:"TEXTBLOCK3",format:0,grid:0,ctrltype:"textblock"};n[31]={id:31,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"OPESTS",gxz:"Z1423OPESts",gxold:"O1423OPESts",gxvar:"A1423OPESts",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.A1423OPESts=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1423OPESts=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("OPESTS",gx.O.A1423OPESts)},c2v:function(){this.val()!==undefined&&(gx.O.A1423OPESts=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("OPESTS",",")},nac:gx.falseFn};n[34]={id:34,fld:"BTN_ENTER",grid:0,evt:"e1147146_client",std:"ENTER"};n[35]={id:35,fld:"BTN_CHECK",grid:0,evt:"e1947146_client",std:"CHECK"};n[36]={id:36,fld:"BTN_CANCEL",grid:0,evt:"e1247146_client"};n[37]={id:37,fld:"BTN_DELETE",grid:0,evt:"e2047146_client",std:"DELETE"};n[38]={id:38,fld:"BTN_HELP",grid:0,evt:"e2147146_client"};this.A321OPECod="";this.Z321OPECod="";this.O321OPECod="";this.A1422OPEDsc="";this.Z1422OPEDsc="";this.O1422OPEDsc="";this.A1423OPESts=0;this.Z1423OPESts=0;this.O1423OPESts=0;this.A321OPECod="";this.A1422OPEDsc="";this.A1423OPESts=0;this.Events={e1147146_client:["ENTER",!0],e1247146_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_OPECOD=[[{ctrl:"OPESTS"},{av:"A1423OPESts",fld:"OPESTS",pic:"9"},{av:"A321OPECod",fld:"OPECOD",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A1422OPEDsc",fld:"OPEDSC",pic:""},{ctrl:"OPESTS"},{av:"A1423OPESts",fld:"OPESTS",pic:"9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z321OPECod"},{av:"Z1422OPEDsc"},{av:"Z1423OPESts"},{ctrl:"BTN_GET",prop:"Enabled"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"},{ctrl:"BTN_CHECK",prop:"Enabled"}]];this.EnterCtrl=["BTN_ENTER"];this.CheckCtrl=["BTN_CHECK"];this.Initialize()});gx.wi(function(){gx.createParentObj(this.pooperarios)})