gx.evt.autoSkip=!1;gx.define("ctiposlistas",!1,function(){this.ServerClass="ctiposlistas";this.PackageName="GeneXus.Programs";this.ServerFullClass="ctiposlistas.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Tiplcod=function(){return this.validSrvEvt("Valid_Tiplcod",0).then(function(n){return n}.closure(this))};this.e113v134_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e123v134_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,5,6,7,8,9,15,18,20,21,24,26,29,31,34,36,39,40,41,42,43];this.GXLastCtrlId=43;n[2]={id:2,fld:"TABLE1",grid:0};n[5]={id:5,fld:"BTN_FIRST",grid:0,evt:"e133v134_client",std:"FIRST"};n[6]={id:6,fld:"BTN_PREVIOUS",grid:0,evt:"e143v134_client",std:"PREVIOUS"};n[7]={id:7,fld:"BTN_NEXT",grid:0,evt:"e153v134_client",std:"NEXT"};n[8]={id:8,fld:"BTN_LAST",grid:0,evt:"e163v134_client",std:"LAST"};n[9]={id:9,fld:"BTN_SELECT",grid:0,evt:"e173v134_client",std:"SELECT"};n[15]={id:15,fld:"TABLE2",grid:0};n[18]={id:18,fld:"TEXTBLOCK1",format:0,grid:0,ctrltype:"textblock"};n[20]={id:20,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Tiplcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TIPLCOD",gxz:"Z202TipLCod",gxold:"O202TipLCod",gxvar:"A202TipLCod",ucs:[],op:[36,31,26],ip:[36,31,26,20],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A202TipLCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z202TipLCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("TIPLCOD",gx.O.A202TipLCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A202TipLCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("TIPLCOD",",")},nac:gx.falseFn};n[21]={id:21,fld:"BTN_GET",grid:0,evt:"e183v134_client",std:"GET"};n[24]={id:24,fld:"TEXTBLOCK2",format:0,grid:0,ctrltype:"textblock"};n[26]={id:26,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TIPLDSC",gxz:"Z1912TipLDsc",gxold:"O1912TipLDsc",gxvar:"A1912TipLDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1912TipLDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z1912TipLDsc=n)},v2c:function(){gx.fn.setControlValue("TIPLDSC",gx.O.A1912TipLDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1912TipLDsc=this.val())},val:function(){return gx.fn.getControlValue("TIPLDSC")},nac:gx.falseFn};n[29]={id:29,fld:"TEXTBLOCK3",format:0,grid:0,ctrltype:"textblock"};n[31]={id:31,lvl:0,type:"char",len:5,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TIPLABR",gxz:"Z1911TipLAbr",gxold:"O1911TipLAbr",gxvar:"A1911TipLAbr",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1911TipLAbr=n)},v2z:function(n){n!==undefined&&(gx.O.Z1911TipLAbr=n)},v2c:function(){gx.fn.setControlValue("TIPLABR",gx.O.A1911TipLAbr,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1911TipLAbr=this.val())},val:function(){return gx.fn.getControlValue("TIPLABR")},nac:gx.falseFn};n[34]={id:34,fld:"TEXTBLOCK4",format:0,grid:0,ctrltype:"textblock"};n[36]={id:36,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TIPLSTS",gxz:"Z1914TipLSts",gxold:"O1914TipLSts",gxvar:"A1914TipLSts",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.A1914TipLSts=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1914TipLSts=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("TIPLSTS",gx.O.A1914TipLSts)},c2v:function(){this.val()!==undefined&&(gx.O.A1914TipLSts=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("TIPLSTS",",")},nac:gx.falseFn};n[39]={id:39,fld:"BTN_ENTER",grid:0,evt:"e113v134_client",std:"ENTER"};n[40]={id:40,fld:"BTN_CHECK",grid:0,evt:"e193v134_client",std:"CHECK"};n[41]={id:41,fld:"BTN_CANCEL",grid:0,evt:"e123v134_client"};n[42]={id:42,fld:"BTN_DELETE",grid:0,evt:"e203v134_client",std:"DELETE"};n[43]={id:43,fld:"BTN_HELP",grid:0,evt:"e213v134_client"};this.A202TipLCod=0;this.Z202TipLCod=0;this.O202TipLCod=0;this.A1912TipLDsc="";this.Z1912TipLDsc="";this.O1912TipLDsc="";this.A1911TipLAbr="";this.Z1911TipLAbr="";this.O1911TipLAbr="";this.A1914TipLSts=0;this.Z1914TipLSts=0;this.O1914TipLSts=0;this.A202TipLCod=0;this.A1912TipLDsc="";this.A1911TipLAbr="";this.A1914TipLSts=0;this.Events={e113v134_client:["ENTER",!0],e123v134_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_TIPLCOD=[[{ctrl:"TIPLSTS"},{av:"A1914TipLSts",fld:"TIPLSTS",pic:"9"},{av:"A202TipLCod",fld:"TIPLCOD",pic:"ZZZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A1912TipLDsc",fld:"TIPLDSC",pic:""},{av:"A1911TipLAbr",fld:"TIPLABR",pic:""},{ctrl:"TIPLSTS"},{av:"A1914TipLSts",fld:"TIPLSTS",pic:"9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z202TipLCod"},{av:"Z1912TipLDsc"},{av:"Z1911TipLAbr"},{av:"Z1914TipLSts"},{ctrl:"BTN_GET",prop:"Enabled"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"},{ctrl:"BTN_CHECK",prop:"Enabled"}]];this.EnterCtrl=["BTN_ENTER"];this.CheckCtrl=["BTN_CHECK"];this.Initialize()});gx.wi(function(){gx.createParentObj(this.ctiposlistas)})