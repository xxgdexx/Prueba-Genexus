gx.evt.autoSkip=!1;gx.define("produccion.operarios",!1,function(){var n,t;this.ServerClass="produccion.operarios";this.PackageName="GeneXus.Programs";this.ServerFullClass="produccion.operarios.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV7OPECod=gx.fn.getControlValue("vOPECOD");this.Gx_BScreen=gx.fn.getIntegerValue("vGXBSCREEN",",");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV9TrnContext=gx.fn.getControlValue("vTRNCONTEXT")};this.Valid_Opecod=function(){return this.validCliEvt("Valid_Opecod",0,function(){try{var n=gx.util.balloon.getNew("OPECOD");if(this.AnyError=0,gx.text.compare("",this.A321OPECod)==0)try{n.setError(gx.text.format("%1 es requerido.","Codigo Operario","","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Opedsc=function(){return this.validCliEvt("Valid_Opedsc",0,function(){try{var n=gx.util.balloon.getNew("OPEDSC");if(this.AnyError=0,gx.text.compare("",this.A1422OPEDsc)==0)try{n.setError(gx.text.format("%1 es requerido.","Operario","","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e126i2_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e136i146_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e146i146_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41];this.GXLastCtrlId=41;this.DVPANEL_TABLEATTRIBUTESContainer=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_TABLEATTRIBUTESContainer","Dvpanel_tableattributes","DVPANEL_TABLEATTRIBUTES");t=this.DVPANEL_TABLEATTRIBUTESContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Width","Width","100%","str");t.setProp("Height","Height","100","str");t.setProp("AutoWidth","Autowidth",!1,"bool");t.setProp("AutoHeight","Autoheight",!0,"bool");t.setProp("Cls","Cls","PanelFilled Panel_BaseColor","str");t.setProp("ShowHeader","Showheader",!0,"bool");t.setProp("Title","Title","Información General","str");t.setProp("Collapsible","Collapsible",!1,"bool");t.setProp("Collapsed","Collapsed",!1,"bool");t.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");t.setProp("IconPosition","Iconposition","Right","str");t.setProp("AutoScroll","Autoscroll",!1,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"TABLEATTRIBUTES",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Opecod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"OPECOD",gxz:"Z321OPECod",gxold:"O321OPECod",gxvar:"A321OPECod",ucs:[],op:[22],ip:[22],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A321OPECod=n)},v2z:function(n){n!==undefined&&(gx.O.Z321OPECod=n)},v2c:function(){gx.fn.setControlValue("OPECOD",gx.O.A321OPECod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A321OPECod=this.val())},val:function(){return gx.fn.getControlValue("OPECOD")},nac:function(){return!(gx.text.compare("",this.AV7OPECod)==0)}};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Opedsc,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"OPEDSC",gxz:"Z1422OPEDsc",gxold:"O1422OPEDsc",gxvar:"A1422OPEDsc",ucs:[],op:[27],ip:[27],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1422OPEDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z1422OPEDsc=n)},v2c:function(){gx.fn.setControlValue("OPEDSC",gx.O.A1422OPEDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1422OPEDsc=this.val())},val:function(){return gx.fn.getControlValue("OPEDSC")},nac:gx.falseFn};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"OPESTS",gxz:"Z1423OPESts",gxold:"O1423OPESts",gxvar:"A1423OPESts",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.A1423OPESts=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1423OPESts=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("OPESTS",gx.O.A1423OPESts)},c2v:function(){this.val()!==undefined&&(gx.O.A1423OPESts=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("OPESTS",",")},nac:gx.falseFn};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"BTNTRN_ENTER",grid:0,evt:"e136i146_client",std:"ENTER"};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"BTNTRN_CANCEL",grid:0,evt:"e146i146_client"};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"BTNTRN_DELETE",grid:0,evt:"e156i146_client",std:"DELETE"};this.A321OPECod="";this.Z321OPECod="";this.O321OPECod="";this.A1422OPEDsc="";this.Z1422OPEDsc="";this.O1422OPEDsc="";this.A1423OPESts=0;this.Z1423OPESts=0;this.O1423OPESts=0;this.AV8WWPContext={UserId:0,UserName:""};this.AV9TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV7OPECod="";this.AV10WebSession={};this.A321OPECod="";this.Gx_BScreen=0;this.A1422OPEDsc="";this.A1423OPESts=0;this.Gx_mode="";this.Events={e126i2_client:["AFTER TRN",!0],e136i146_client:["ENTER",!0],e146i146_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV7OPECod",fld:"vOPECOD",pic:"",hsh:!0}],[]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{av:"AV7OPECod",fld:"vOPECOD",pic:"",hsh:!0}],[]];this.EvtParms["AFTER TRN"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"A321OPECod",fld:"OPECOD",pic:""},{av:"A1422OPEDsc",fld:"OPEDSC",pic:""},{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0}],[]];this.EvtParms.VALID_OPECOD=[[{av:"A321OPECod",fld:"OPECOD",pic:""}],[{av:"A321OPECod",fld:"OPECOD",pic:""}]];this.EvtParms.VALID_OPEDSC=[[{av:"A1422OPEDsc",fld:"OPEDSC",pic:""}],[{av:"A1422OPEDsc",fld:"OPEDSC",pic:""}]];this.EnterCtrl=["BTNTRN_ENTER"];this.setVCMap("AV7OPECod","vOPECOD",0,"char",20,0);this.setVCMap("Gx_BScreen","vGXBSCREEN",0,"int",1,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV9TrnContext","vTRNCONTEXT",0,"WWPBaseObjectsWWPTransactionContext",0,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.produccion.operarios)})