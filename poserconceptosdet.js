gx.evt.autoSkip=!1;gx.define("poserconceptosdet",!1,function(){this.ServerClass="poserconceptosdet";this.PackageName="GeneXus.Programs";this.ServerFullClass="poserconceptosdet.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Pserconccod=function(){return this.validSrvEvt("Valid_Pserconccod",0).then(function(n){return n}.closure(this))};this.Valid_Pserdconccuecod=function(){return this.validSrvEvt("Valid_Pserdconccuecod",0).then(function(n){return n}.closure(this))};this.e114j158_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e124j158_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,5,6,7,8,9,15,18,20,23,25,26,29,31,34,35,36,37,38];this.GXLastCtrlId=38;n[2]={id:2,fld:"TABLE1",grid:0};n[5]={id:5,fld:"BTN_FIRST",grid:0,evt:"e134j158_client",std:"FIRST"};n[6]={id:6,fld:"BTN_PREVIOUS",grid:0,evt:"e144j158_client",std:"PREVIOUS"};n[7]={id:7,fld:"BTN_NEXT",grid:0,evt:"e154j158_client",std:"NEXT"};n[8]={id:8,fld:"BTN_LAST",grid:0,evt:"e164j158_client",std:"LAST"};n[9]={id:9,fld:"BTN_SELECT",grid:0,evt:"e174j158_client",std:"SELECT"};n[15]={id:15,fld:"TABLE2",grid:0};n[18]={id:18,fld:"TEXTBLOCK1",format:0,grid:0,ctrltype:"textblock"};n[20]={id:20,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Pserconccod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PSERCONCCOD",gxz:"Z332PSerConcCod",gxold:"O332PSerConcCod",gxvar:"A332PSerConcCod",ucs:[],op:[],ip:[20],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A332PSerConcCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z332PSerConcCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("PSERCONCCOD",gx.O.A332PSerConcCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A332PSerConcCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("PSERCONCCOD",",")},nac:gx.falseFn};n[23]={id:23,fld:"TEXTBLOCK2",format:0,grid:0,ctrltype:"textblock"};n[25]={id:25,lvl:0,type:"char",len:15,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Pserdconccuecod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PSERDCONCCUECOD",gxz:"Z333PSerDConcCueCod",gxold:"O333PSerDConcCueCod",gxvar:"A333PSerDConcCueCod",ucs:[],op:[31],ip:[31,25,20],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A333PSerDConcCueCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z333PSerDConcCueCod=n)},v2c:function(){gx.fn.setControlValue("PSERDCONCCUECOD",gx.O.A333PSerDConcCueCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A333PSerDConcCueCod=this.val())},val:function(){return gx.fn.getControlValue("PSERDCONCCUECOD")},nac:gx.falseFn};n[26]={id:26,fld:"BTN_GET",grid:0,evt:"e184j158_client",std:"GET"};n[29]={id:29,fld:"TEXTBLOCK3",format:0,grid:0,ctrltype:"textblock"};n[31]={id:31,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PSERDCONCCUEDSC",gxz:"Z1801PSerDConcCueDsc",gxold:"O1801PSerDConcCueDsc",gxvar:"A1801PSerDConcCueDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1801PSerDConcCueDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z1801PSerDConcCueDsc=n)},v2c:function(){gx.fn.setControlValue("PSERDCONCCUEDSC",gx.O.A1801PSerDConcCueDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1801PSerDConcCueDsc=this.val())},val:function(){return gx.fn.getControlValue("PSERDCONCCUEDSC")},nac:gx.falseFn};n[34]={id:34,fld:"BTN_ENTER",grid:0,evt:"e114j158_client",std:"ENTER"};n[35]={id:35,fld:"BTN_CHECK",grid:0,evt:"e194j158_client",std:"CHECK"};n[36]={id:36,fld:"BTN_CANCEL",grid:0,evt:"e124j158_client"};n[37]={id:37,fld:"BTN_DELETE",grid:0,evt:"e204j158_client",std:"DELETE"};n[38]={id:38,fld:"BTN_HELP",grid:0,evt:"e214j158_client"};this.A332PSerConcCod=0;this.Z332PSerConcCod=0;this.O332PSerConcCod=0;this.A333PSerDConcCueCod="";this.Z333PSerDConcCueCod="";this.O333PSerDConcCueCod="";this.A1801PSerDConcCueDsc="";this.Z1801PSerDConcCueDsc="";this.O1801PSerDConcCueDsc="";this.A332PSerConcCod=0;this.A333PSerDConcCueCod="";this.A1801PSerDConcCueDsc="";this.Events={e114j158_client:["ENTER",!0],e124j158_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_PSERCONCCOD=[[{av:"A332PSerConcCod",fld:"PSERCONCCOD",pic:"ZZZZZ9"}],[]];this.EvtParms.VALID_PSERDCONCCUECOD=[[{av:"A332PSerConcCod",fld:"PSERCONCCOD",pic:"ZZZZZ9"},{av:"A333PSerDConcCueCod",fld:"PSERDCONCCUECOD",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A1801PSerDConcCueDsc",fld:"PSERDCONCCUEDSC",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z332PSerConcCod"},{av:"Z333PSerDConcCueCod"},{av:"Z1801PSerDConcCueDsc"},{ctrl:"BTN_GET",prop:"Enabled"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"},{ctrl:"BTN_CHECK",prop:"Enabled"}]];this.EnterCtrl=["BTN_ENTER"];this.CheckCtrl=["BTN_CHECK"];this.Initialize()});gx.wi(function(){gx.createParentObj(this.poserconceptosdet)})