gx.evt.autoSkip=!1;gx.define("ctipdoc",!1,function(){this.ServerClass="ctipdoc";this.PackageName="GeneXus.Programs";this.ServerFullClass="ctipdoc.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.A1909TipCxP=gx.fn.getIntegerValue("TIPCXP",",");this.A1903TipBan=gx.fn.getIntegerValue("TIPBAN",",")};this.Valid_Tipcod=function(){return this.validSrvEvt("Valid_Tipcod",0).then(function(n){return n}.closure(this))};this.e113q129_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e123q129_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,5,6,7,8,9,15,18,20,21,24,26,29,31,34,36,39,41,44,46,49,51,54,56,59,60,61,62,63];this.GXLastCtrlId=63;n[2]={id:2,fld:"TABLE1",grid:0};n[5]={id:5,fld:"BTN_FIRST",grid:0,evt:"e133q129_client",std:"FIRST"};n[6]={id:6,fld:"BTN_PREVIOUS",grid:0,evt:"e143q129_client",std:"PREVIOUS"};n[7]={id:7,fld:"BTN_NEXT",grid:0,evt:"e153q129_client",std:"NEXT"};n[8]={id:8,fld:"BTN_LAST",grid:0,evt:"e163q129_client",std:"LAST"};n[9]={id:9,fld:"BTN_SELECT",grid:0,evt:"e173q129_client",std:"SELECT"};n[15]={id:15,fld:"TABLE2",grid:0};n[18]={id:18,fld:"TEXTBLOCK1",format:0,grid:0,ctrltype:"textblock"};n[20]={id:20,lvl:0,type:"char",len:3,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Tipcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TIPCOD",gxz:"Z149TipCod",gxold:"O149TipCod",gxvar:"A149TipCod",ucs:[],op:[56,51,46,41,36,31,26],ip:[56,51,46,41,36,31,26,20],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A149TipCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z149TipCod=n)},v2c:function(){gx.fn.setControlValue("TIPCOD",gx.O.A149TipCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A149TipCod=this.val())},val:function(){return gx.fn.getControlValue("TIPCOD")},nac:gx.falseFn};n[21]={id:21,fld:"BTN_GET",grid:0,evt:"e183q129_client",std:"GET"};n[24]={id:24,fld:"TEXTBLOCK2",format:0,grid:0,ctrltype:"textblock"};n[26]={id:26,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TIPDSC",gxz:"Z1910TipDsc",gxold:"O1910TipDsc",gxvar:"A1910TipDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1910TipDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z1910TipDsc=n)},v2c:function(){gx.fn.setControlValue("TIPDSC",gx.O.A1910TipDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1910TipDsc=this.val())},val:function(){return gx.fn.getControlValue("TIPDSC")},nac:gx.falseFn};n[29]={id:29,fld:"TEXTBLOCK3",format:0,grid:0,ctrltype:"textblock"};n[31]={id:31,lvl:0,type:"char",len:5,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TIPABR",gxz:"Z306TipAbr",gxold:"O306TipAbr",gxvar:"A306TipAbr",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A306TipAbr=n)},v2z:function(n){n!==undefined&&(gx.O.Z306TipAbr=n)},v2c:function(){gx.fn.setControlValue("TIPABR",gx.O.A306TipAbr,0)},c2v:function(){this.val()!==undefined&&(gx.O.A306TipAbr=this.val())},val:function(){return gx.fn.getControlValue("TIPABR")},nac:gx.falseFn};n[34]={id:34,fld:"TEXTBLOCK4",format:0,grid:0,ctrltype:"textblock"};n[36]={id:36,lvl:0,type:"int",len:2,dec:0,sign:!0,pic:"Z9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TIPSIGNO",gxz:"Z511TipSigno",gxold:"O511TipSigno",gxvar:"A511TipSigno",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A511TipSigno=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z511TipSigno=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("TIPSIGNO",gx.O.A511TipSigno,0)},c2v:function(){this.val()!==undefined&&(gx.O.A511TipSigno=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("TIPSIGNO",",")},nac:gx.falseFn};n[39]={id:39,fld:"TEXTBLOCK5",format:0,grid:0,ctrltype:"textblock"};n[41]={id:41,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TIPSTS",gxz:"Z1919TipSts",gxold:"O1919TipSts",gxvar:"A1919TipSts",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1919TipSts=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1919TipSts=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("TIPSTS",gx.O.A1919TipSts,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1919TipSts=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("TIPSTS",",")},nac:gx.falseFn};n[44]={id:44,fld:"TEXTBLOCK6",format:0,grid:0,ctrltype:"textblock"};n[46]={id:46,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TIPVTA",gxz:"Z1921TipVta",gxold:"O1921TipVta",gxvar:"A1921TipVta",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1921TipVta=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1921TipVta=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("TIPVTA",gx.O.A1921TipVta,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1921TipVta=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("TIPVTA",",")},nac:gx.falseFn};n[49]={id:49,fld:"TEXTBLOCK7",format:0,grid:0,ctrltype:"textblock"};n[51]={id:51,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TIPCMP",gxz:"Z1906TipCmp",gxold:"O1906TipCmp",gxvar:"A1906TipCmp",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1906TipCmp=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1906TipCmp=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("TIPCMP",gx.O.A1906TipCmp,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1906TipCmp=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("TIPCMP",",")},nac:gx.falseFn};n[54]={id:54,fld:"TEXTBLOCK8",format:0,grid:0,ctrltype:"textblock"};n[56]={id:56,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TIPRHO",gxz:"Z1915TipRHo",gxold:"O1915TipRHo",gxvar:"A1915TipRHo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1915TipRHo=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1915TipRHo=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("TIPRHO",gx.O.A1915TipRHo,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1915TipRHo=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("TIPRHO",",")},nac:gx.falseFn};n[59]={id:59,fld:"BTN_ENTER",grid:0,evt:"e113q129_client",std:"ENTER"};n[60]={id:60,fld:"BTN_CHECK",grid:0,evt:"e193q129_client",std:"CHECK"};n[61]={id:61,fld:"BTN_CANCEL",grid:0,evt:"e123q129_client"};n[62]={id:62,fld:"BTN_DELETE",grid:0,evt:"e203q129_client",std:"DELETE"};n[63]={id:63,fld:"BTN_HELP",grid:0,evt:"e213q129_client"};this.A149TipCod="";this.Z149TipCod="";this.O149TipCod="";this.A1910TipDsc="";this.Z1910TipDsc="";this.O1910TipDsc="";this.A306TipAbr="";this.Z306TipAbr="";this.O306TipAbr="";this.A511TipSigno=0;this.Z511TipSigno=0;this.O511TipSigno=0;this.A1919TipSts=0;this.Z1919TipSts=0;this.O1919TipSts=0;this.A1921TipVta=0;this.Z1921TipVta=0;this.O1921TipVta=0;this.A1906TipCmp=0;this.Z1906TipCmp=0;this.O1906TipCmp=0;this.A1915TipRHo=0;this.Z1915TipRHo=0;this.O1915TipRHo=0;this.A149TipCod="";this.A1910TipDsc="";this.A306TipAbr="";this.A511TipSigno=0;this.A1919TipSts=0;this.A1921TipVta=0;this.A1906TipCmp=0;this.A1915TipRHo=0;this.A1909TipCxP=0;this.A1903TipBan=0;this.Events={e113q129_client:["ENTER",!0],e123q129_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[{av:"A1909TipCxP",fld:"TIPCXP",pic:"9"},{av:"A1903TipBan",fld:"TIPBAN",pic:"9"}],[]];this.EvtParms.VALID_TIPCOD=[[{av:"A1903TipBan",fld:"TIPBAN",pic:"9"},{av:"A1909TipCxP",fld:"TIPCXP",pic:"9"},{av:"A149TipCod",fld:"TIPCOD",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A1910TipDsc",fld:"TIPDSC",pic:""},{av:"A306TipAbr",fld:"TIPABR",pic:""},{av:"A511TipSigno",fld:"TIPSIGNO",pic:"Z9"},{av:"A1919TipSts",fld:"TIPSTS",pic:"9"},{av:"A1921TipVta",fld:"TIPVTA",pic:"9"},{av:"A1906TipCmp",fld:"TIPCMP",pic:"9"},{av:"A1915TipRHo",fld:"TIPRHO",pic:"9"},{av:"A1909TipCxP",fld:"TIPCXP",pic:"9"},{av:"A1903TipBan",fld:"TIPBAN",pic:"9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z149TipCod"},{av:"Z1910TipDsc"},{av:"Z306TipAbr"},{av:"Z511TipSigno"},{av:"Z1919TipSts"},{av:"Z1921TipVta"},{av:"Z1906TipCmp"},{av:"Z1915TipRHo"},{av:"Z1909TipCxP"},{av:"Z1903TipBan"},{ctrl:"BTN_GET",prop:"Enabled"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"},{ctrl:"BTN_CHECK",prop:"Enabled"}]];this.EnterCtrl=["BTN_ENTER"];this.CheckCtrl=["BTN_CHECK"];this.setVCMap("A1909TipCxP","TIPCXP",0,"int",1,0);this.setVCMap("A1903TipBan","TIPBAN",0,"int",1,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.ctipdoc)})