gx.evt.autoSkip=!1;gx.define("contabilidad.tipoauxiliar",!1,function(){var n,t;this.ServerClass="contabilidad.tipoauxiliar";this.PackageName="GeneXus.Programs";this.ServerFullClass="contabilidad.tipoauxiliar.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV7TipACod=gx.fn.getIntegerValue("vTIPACOD",",");this.AV11cTipACod=gx.fn.getIntegerValue("vCTIPACOD",",");this.Gx_BScreen=gx.fn.getIntegerValue("vGXBSCREEN",",");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV9TrnContext=gx.fn.getControlValue("vTRNCONTEXT")};this.Valid_Tipacod=function(){return this.validCliEvt("Valid_Tipacod",0,function(){try{var n=gx.util.balloon.getNew("TIPACOD");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Tipadsc=function(){return this.validCliEvt("Valid_Tipadsc",0,function(){try{var n=gx.util.balloon.getNew("TIPADSC");if(this.AnyError=0,gx.text.compare("",this.A1900TipADsc)==0)try{n.setError(gx.text.format("%1 es requerido.","Tipo de Auxiliar","","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e126m2_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e136m70_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e146m70_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40];this.GXLastCtrlId=40;this.DVPANEL_TABLEATTRIBUTESContainer=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_TABLEATTRIBUTESContainer","Dvpanel_tableattributes","DVPANEL_TABLEATTRIBUTES");t=this.DVPANEL_TABLEATTRIBUTESContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Width","Width","100%","str");t.setProp("Height","Height","100","str");t.setProp("AutoWidth","Autowidth",!1,"bool");t.setProp("AutoHeight","Autoheight",!0,"bool");t.setProp("Cls","Cls","PanelFilled Panel_BaseColor","str");t.setProp("ShowHeader","Showheader",!0,"bool");t.setProp("Title","Title","Información General","str");t.setProp("Collapsible","Collapsible",!1,"bool");t.setProp("Collapsed","Collapsed",!1,"bool");t.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");t.setProp("IconPosition","Iconposition","Right","str");t.setProp("AutoScroll","Autoscroll",!1,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"TABLEATTRIBUTES",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Tipadsc,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TIPADSC",gxz:"Z1900TipADsc",gxold:"O1900TipADsc",gxvar:"A1900TipADsc",ucs:[],op:[22],ip:[22],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1900TipADsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z1900TipADsc=n)},v2c:function(){gx.fn.setControlValue("TIPADSC",gx.O.A1900TipADsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1900TipADsc=this.val())},val:function(){return gx.fn.getControlValue("TIPADSC")},nac:gx.falseFn};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TIPASTS",gxz:"Z1902TipASts",gxold:"O1902TipASts",gxvar:"A1902TipASts",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.A1902TipASts=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1902TipASts=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("TIPASTS",gx.O.A1902TipASts)},c2v:function(){this.val()!==undefined&&(gx.O.A1902TipASts=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("TIPASTS",",")},nac:gx.falseFn};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"BTNTRN_ENTER",grid:0,evt:"e136m70_client",std:"ENTER"};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"BTNTRN_CANCEL",grid:0,evt:"e146m70_client"};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"BTNTRN_DELETE",grid:0,evt:"e156m70_client",std:"DELETE"};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[40]={id:40,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Tipacod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TIPACOD",gxz:"Z70TipACod",gxold:"O70TipACod",gxvar:"A70TipACod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A70TipACod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z70TipACod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("TIPACOD",gx.O.A70TipACod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A70TipACod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("TIPACOD",",")},nac:function(){return!(0==this.AV7TipACod)}};this.A1900TipADsc="";this.Z1900TipADsc="";this.O1900TipADsc="";this.A1902TipASts=0;this.Z1902TipASts=0;this.O1902TipASts=0;this.A70TipACod=0;this.Z70TipACod=0;this.O70TipACod=0;this.AV8WWPContext={UserId:0,UserName:""};this.AV9TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV7TipACod=0;this.AV10WebSession={};this.A70TipACod=0;this.AV11cTipACod=0;this.Gx_BScreen=0;this.A1900TipADsc="";this.A1902TipASts=0;this.Gx_mode="";this.Events={e126m2_client:["AFTER TRN",!0],e136m70_client:["ENTER",!0],e146m70_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV7TipACod",fld:"vTIPACOD",pic:"ZZZZZ9",hsh:!0}],[]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{av:"AV7TipACod",fld:"vTIPACOD",pic:"ZZZZZ9",hsh:!0}],[]];this.EvtParms["AFTER TRN"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"A70TipACod",fld:"TIPACOD",pic:"ZZZZZ9"},{av:"A1900TipADsc",fld:"TIPADSC",pic:""},{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0}],[]];this.EvtParms.VALID_TIPADSC=[[{av:"A1900TipADsc",fld:"TIPADSC",pic:""}],[{av:"A1900TipADsc",fld:"TIPADSC",pic:""}]];this.EvtParms.VALID_TIPACOD=[[],[]];this.EnterCtrl=["BTNTRN_ENTER"];this.setVCMap("AV7TipACod","vTIPACOD",0,"int",6,0);this.setVCMap("AV11cTipACod","vCTIPACOD",0,"int",6,0);this.setVCMap("Gx_BScreen","vGXBSCREEN",0,"int",1,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV9TrnContext","vTRNCONTEXT",0,"WWPBaseObjectsWWPTransactionContext",0,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.contabilidad.tipoauxiliar)})