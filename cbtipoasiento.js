gx.evt.autoSkip=!1;gx.define("cbtipoasiento",!1,function(){this.ServerClass="cbtipoasiento";this.PackageName="GeneXus.Programs";this.ServerFullClass="cbtipoasiento.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.A2256TASISunat=gx.fn.getControlValue("TASISUNAT")};this.Valid_Tasicod=function(){return this.validSrvEvt("Valid_Tasicod",0).then(function(n){return n}.closure(this))};this.e112271_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e122271_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,5,6,7,8,9,15,18,20,21,24,26,29,31,34,36,39,40,41,42,43];this.GXLastCtrlId=43;n[2]={id:2,fld:"TABLE1",grid:0};n[5]={id:5,fld:"BTN_FIRST",grid:0,evt:"e132271_client",std:"FIRST"};n[6]={id:6,fld:"BTN_PREVIOUS",grid:0,evt:"e142271_client",std:"PREVIOUS"};n[7]={id:7,fld:"BTN_NEXT",grid:0,evt:"e152271_client",std:"NEXT"};n[8]={id:8,fld:"BTN_LAST",grid:0,evt:"e162271_client",std:"LAST"};n[9]={id:9,fld:"BTN_SELECT",grid:0,evt:"e172271_client",std:"SELECT"};n[15]={id:15,fld:"TABLE2",grid:0};n[18]={id:18,fld:"TEXTBLOCK1",format:0,grid:0,ctrltype:"textblock"};n[20]={id:20,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Tasicod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TASICOD",gxz:"Z126TASICod",gxold:"O126TASICod",gxvar:"A126TASICod",ucs:[],op:[36,31,26],ip:[36,31,26,20],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A126TASICod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z126TASICod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("TASICOD",gx.O.A126TASICod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A126TASICod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("TASICOD",",")},nac:gx.falseFn};n[21]={id:21,fld:"BTN_GET",grid:0,evt:"e182271_client",std:"GET"};n[24]={id:24,fld:"TEXTBLOCK2",format:0,grid:0,ctrltype:"textblock"};n[26]={id:26,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TASIDSC",gxz:"Z1895TASIDsc",gxold:"O1895TASIDsc",gxvar:"A1895TASIDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1895TASIDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z1895TASIDsc=n)},v2c:function(){gx.fn.setControlValue("TASIDSC",gx.O.A1895TASIDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1895TASIDsc=this.val())},val:function(){return gx.fn.getControlValue("TASIDSC")},nac:gx.falseFn};n[29]={id:29,fld:"TEXTBLOCK3",format:0,grid:0,ctrltype:"textblock"};n[31]={id:31,lvl:0,type:"char",len:5,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TASIABR",gxz:"Z1894TASIAbr",gxold:"O1894TASIAbr",gxvar:"A1894TASIAbr",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1894TASIAbr=n)},v2z:function(n){n!==undefined&&(gx.O.Z1894TASIAbr=n)},v2c:function(){gx.fn.setControlValue("TASIABR",gx.O.A1894TASIAbr,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1894TASIAbr=this.val())},val:function(){return gx.fn.getControlValue("TASIABR")},nac:gx.falseFn};n[34]={id:34,fld:"TEXTBLOCK4",format:0,grid:0,ctrltype:"textblock"};n[36]={id:36,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TASISTS",gxz:"Z1896TASISts",gxold:"O1896TASISts",gxvar:"A1896TASISts",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.A1896TASISts=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1896TASISts=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("TASISTS",gx.O.A1896TASISts)},c2v:function(){this.val()!==undefined&&(gx.O.A1896TASISts=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("TASISTS",",")},nac:gx.falseFn};n[39]={id:39,fld:"BTN_ENTER",grid:0,evt:"e112271_client",std:"ENTER"};n[40]={id:40,fld:"BTN_CHECK",grid:0,evt:"e192271_client",std:"CHECK"};n[41]={id:41,fld:"BTN_CANCEL",grid:0,evt:"e122271_client"};n[42]={id:42,fld:"BTN_DELETE",grid:0,evt:"e202271_client",std:"DELETE"};n[43]={id:43,fld:"BTN_HELP",grid:0,evt:"e212271_client"};this.A126TASICod=0;this.Z126TASICod=0;this.O126TASICod=0;this.A1895TASIDsc="";this.Z1895TASIDsc="";this.O1895TASIDsc="";this.A1894TASIAbr="";this.Z1894TASIAbr="";this.O1894TASIAbr="";this.A1896TASISts=0;this.Z1896TASISts=0;this.O1896TASISts=0;this.A126TASICod=0;this.A1895TASIDsc="";this.A1894TASIAbr="";this.A1896TASISts=0;this.A2256TASISunat="";this.Events={e112271_client:["ENTER",!0],e122271_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[{av:"A2256TASISunat",fld:"TASISUNAT",pic:""}],[]];this.EvtParms.VALID_TASICOD=[[{av:"A2256TASISunat",fld:"TASISUNAT",pic:""},{ctrl:"TASISTS"},{av:"A1896TASISts",fld:"TASISTS",pic:"9"},{av:"A126TASICod",fld:"TASICOD",pic:"ZZZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A1895TASIDsc",fld:"TASIDSC",pic:""},{av:"A1894TASIAbr",fld:"TASIABR",pic:""},{ctrl:"TASISTS"},{av:"A1896TASISts",fld:"TASISTS",pic:"9"},{av:"A2256TASISunat",fld:"TASISUNAT",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z126TASICod"},{av:"Z1895TASIDsc"},{av:"Z1894TASIAbr"},{av:"Z1896TASISts"},{av:"Z2256TASISunat"},{ctrl:"BTN_GET",prop:"Enabled"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"},{ctrl:"BTN_CHECK",prop:"Enabled"}]];this.EnterCtrl=["BTN_ENTER"];this.CheckCtrl=["BTN_CHECK"];this.setVCMap("A2256TASISunat","TASISUNAT",0,"char",5,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.cbtipoasiento)})