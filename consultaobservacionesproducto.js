gx.evt.autoSkip=!1;gx.define("consultaobservacionesproducto",!1,function(){this.ServerClass="consultaobservacionesproducto";this.PackageName="GeneXus.Programs";this.ServerFullClass="consultaobservacionesproducto.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV17pProdCod=gx.fn.getControlValue("vPPRODCOD")};this.e134f2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e144f1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,6,10,11,14,17,18,20,21,24];this.GXLastCtrlId=24;n[2]={id:2,fld:"GROUP1",grid:0};n[3]={id:3,fld:"TABLE3",grid:0};n[6]={id:6,fld:"IMAGE2",grid:0,evt:"e144f1_client"};n[10]={id:10,fld:"GROUP3",grid:0};n[11]={id:11,fld:"TABLE2",grid:0};n[14]={id:14,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPRODDSC",gxz:"ZV19ProdDsc",gxold:"OV19ProdDsc",gxvar:"AV19ProdDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV19ProdDsc=n)},v2z:function(n){n!==undefined&&(gx.O.ZV19ProdDsc=n)},v2c:function(){gx.fn.setControlValue("vPRODDSC",gx.O.AV19ProdDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV19ProdDsc=this.val())},val:function(){return gx.fn.getControlValue("vPRODDSC")},nac:gx.falseFn};n[17]={id:17,fld:"GROUP2",grid:0};n[18]={id:18,lvl:0,type:"vchar",len:2e3,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vMVADOBS",gxz:"ZV11MVADObs",gxold:"OV11MVADObs",gxvar:"AV11MVADObs",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV11MVADObs=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11MVADObs=n)},v2c:function(){gx.fn.setControlValue("vMVADOBS",gx.O.AV11MVADObs,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV11MVADObs=this.val())},val:function(){return gx.fn.getControlValue("vMVADOBS")},nac:gx.falseFn};n[20]={id:20,fld:"GROUP4",grid:0};n[21]={id:21,lvl:0,type:"bits",len:1024,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vIMAGEN",gxz:"ZV26Imagen",gxold:"OV26Imagen",gxvar:"AV26Imagen",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV26Imagen=n)},v2z:function(n){n!==undefined&&(gx.O.ZV26Imagen=n)},v2c:function(){gx.fn.setMultimediaValue("vIMAGEN",gx.O.AV26Imagen,gx.O.AV31Imagen_GXI)},c2v:function(){gx.O.AV31Imagen_GXI=this.val_GXI();this.val()!==undefined&&(gx.O.AV26Imagen=this.val())},val:function(){return gx.fn.getBlobValue("vIMAGEN")},val_GXI:function(){return gx.fn.getControlValue("vIMAGEN_GXI")},gxvar_GXI:"AV31Imagen_GXI",nac:gx.falseFn};n[24]={id:24,lvl:0,type:"char",len:15,dec:0,sign:!1,pic:"@!",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPRODCOD",gxz:"ZV18ProdCod",gxold:"OV18ProdCod",gxvar:"AV18ProdCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV18ProdCod=n)},v2z:function(n){n!==undefined&&(gx.O.ZV18ProdCod=n)},v2c:function(){gx.fn.setControlValue("vPRODCOD",gx.O.AV18ProdCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV18ProdCod=this.val())},val:function(){return gx.fn.getControlValue("vPRODCOD")},nac:gx.falseFn};this.AV19ProdDsc="";this.ZV19ProdDsc="";this.OV19ProdDsc="";this.AV11MVADObs="";this.ZV11MVADObs="";this.OV11MVADObs="";this.AV31Imagen_GXI="";this.AV26Imagen="";this.ZV26Imagen="";this.OV26Imagen="";this.AV18ProdCod="";this.ZV18ProdCod="";this.OV18ProdCod="";this.AV19ProdDsc="";this.AV11MVADObs="";this.AV26Imagen="";this.AV18ProdCod="";this.AV17pProdCod="";this.A40000ProdFoto_GXI="";this.A28ProdCod="";this.A55ProdDsc="";this.A1701ProdObs="";this.A1695ProdFoto="";this.Events={e134f2_client:["ENTER",!0],e144f1_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[],[]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV17pProdCod","vPPRODCOD",0,"char",15,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.consultaobservacionesproducto)})