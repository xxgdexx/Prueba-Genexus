gx.evt.autoSkip=!1;gx.define("configuracion.monedas",!1,function(){var n,t;this.ServerClass="configuracion.monedas";this.PackageName="GeneXus.Programs";this.ServerFullClass="configuracion.monedas.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV7MonCod=gx.fn.getIntegerValue("vMONCOD",",");this.AV13cMonCod=gx.fn.getIntegerValue("vCMONCOD",",");this.Gx_BScreen=gx.fn.getIntegerValue("vGXBSCREEN",",");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV11TrnContext=gx.fn.getControlValue("vTRNCONTEXT")};this.Valid_Moncod=function(){return this.validCliEvt("Valid_Moncod",0,function(){try{var n=gx.util.balloon.getNew("MONCOD");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Mondsc=function(){return this.validCliEvt("Valid_Mondsc",0,function(){try{var n=gx.util.balloon.getNew("MONDSC");if(this.AnyError=0,gx.text.compare("",this.A1234MonDsc)==0)try{n.setError(gx.text.format("%1 es requerido.","Moneda","","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Monabr=function(){return this.validCliEvt("Valid_Monabr",0,function(){try{var n=gx.util.balloon.getNew("MONABR");if(this.AnyError=0,gx.text.compare("",this.A1233MonAbr)==0)try{n.setError(gx.text.format("%1 es requerido.","Abr. Moneda","","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Monsunat=function(){return this.validCliEvt("Valid_Monsunat",0,function(){try{var n=gx.util.balloon.getNew("MONSUNAT");if(this.AnyError=0,gx.text.compare("",this.A1236MonSunat)==0)try{n.setError(gx.text.format("%1 es requerido.","Cod.Sunat","","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e12612_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e1361103_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e1461103_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50];this.GXLastCtrlId=50;this.DVPANEL_TABLEATTRIBUTESContainer=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_TABLEATTRIBUTESContainer","Dvpanel_tableattributes","DVPANEL_TABLEATTRIBUTES");t=this.DVPANEL_TABLEATTRIBUTESContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Width","Width","100%","str");t.setProp("Height","Height","100","str");t.setProp("AutoWidth","Autowidth",!1,"bool");t.setProp("AutoHeight","Autoheight",!0,"bool");t.setProp("Cls","Cls","PanelFilled Panel_BaseColor","str");t.setProp("ShowHeader","Showheader",!0,"bool");t.setProp("Title","Title","Información General","str");t.setProp("Collapsible","Collapsible",!1,"bool");t.setProp("Collapsed","Collapsed",!1,"bool");t.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");t.setProp("IconPosition","Iconposition","Right","str");t.setProp("AutoScroll","Autoscroll",!1,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"TABLEATTRIBUTES",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Mondsc,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MONDSC",gxz:"Z1234MonDsc",gxold:"O1234MonDsc",gxvar:"A1234MonDsc",ucs:[],op:[22],ip:[22],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1234MonDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z1234MonDsc=n)},v2c:function(){gx.fn.setControlValue("MONDSC",gx.O.A1234MonDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1234MonDsc=this.val())},val:function(){return gx.fn.getControlValue("MONDSC")},nac:gx.falseFn};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,lvl:0,type:"char",len:5,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Monabr,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MONABR",gxz:"Z1233MonAbr",gxold:"O1233MonAbr",gxvar:"A1233MonAbr",ucs:[],op:[27],ip:[27],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1233MonAbr=n)},v2z:function(n){n!==undefined&&(gx.O.Z1233MonAbr=n)},v2c:function(){gx.fn.setControlValue("MONABR",gx.O.A1233MonAbr,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1233MonAbr=this.val())},val:function(){return gx.fn.getControlValue("MONABR")},nac:gx.falseFn};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,lvl:0,type:"svchar",len:3,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Monsunat,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MONSUNAT",gxz:"Z1236MonSunat",gxold:"O1236MonSunat",gxvar:"A1236MonSunat",ucs:[],op:[32],ip:[32],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1236MonSunat=n)},v2z:function(n){n!==undefined&&(gx.O.Z1236MonSunat=n)},v2c:function(){gx.fn.setControlValue("MONSUNAT",gx.O.A1236MonSunat,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1236MonSunat=this.val())},val:function(){return gx.fn.getControlValue("MONSUNAT")},nac:gx.falseFn};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MONSTS",gxz:"Z1235MonSts",gxold:"O1235MonSts",gxvar:"A1235MonSts",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1235MonSts=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1235MonSts=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("MONSTS",gx.O.A1235MonSts,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1235MonSts=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("MONSTS",",")},nac:gx.falseFn};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"BTNTRN_ENTER",grid:0,evt:"e1361103_client",std:"ENTER"};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"BTNTRN_CANCEL",grid:0,evt:"e1461103_client"};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"BTNTRN_DELETE",grid:0,evt:"e1561103_client",std:"DELETE"};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[50]={id:50,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Moncod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MONCOD",gxz:"Z180MonCod",gxold:"O180MonCod",gxvar:"A180MonCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A180MonCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z180MonCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("MONCOD",gx.O.A180MonCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A180MonCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("MONCOD",",")},nac:function(){return!(0==this.AV7MonCod)}};this.A1234MonDsc="";this.Z1234MonDsc="";this.O1234MonDsc="";this.A1233MonAbr="";this.Z1233MonAbr="";this.O1233MonAbr="";this.A1236MonSunat="";this.Z1236MonSunat="";this.O1236MonSunat="";this.A1235MonSts=0;this.Z1235MonSts=0;this.O1235MonSts=0;this.A180MonCod=0;this.Z180MonCod=0;this.O180MonCod=0;this.AV10WWPContext={UserId:0,UserName:""};this.AV11TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV7MonCod=0;this.AV12WebSession={};this.A180MonCod=0;this.AV13cMonCod=0;this.Gx_BScreen=0;this.A1234MonDsc="";this.A1233MonAbr="";this.A1235MonSts=0;this.A1236MonSunat="";this.Gx_mode="";this.Events={e12612_client:["AFTER TRN",!0],e1361103_client:["ENTER",!0],e1461103_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV7MonCod",fld:"vMONCOD",pic:"ZZZZZ9",hsh:!0}],[]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV11TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{av:"AV7MonCod",fld:"vMONCOD",pic:"ZZZZZ9",hsh:!0}],[]];this.EvtParms["AFTER TRN"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"A180MonCod",fld:"MONCOD",pic:"ZZZZZ9"},{av:"A1234MonDsc",fld:"MONDSC",pic:""},{av:"AV11TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0}],[]];this.EvtParms.VALID_MONDSC=[[{av:"A1234MonDsc",fld:"MONDSC",pic:""}],[{av:"A1234MonDsc",fld:"MONDSC",pic:""}]];this.EvtParms.VALID_MONABR=[[{av:"A1233MonAbr",fld:"MONABR",pic:""}],[{av:"A1233MonAbr",fld:"MONABR",pic:""}]];this.EvtParms.VALID_MONSUNAT=[[{av:"A1236MonSunat",fld:"MONSUNAT",pic:""}],[{av:"A1236MonSunat",fld:"MONSUNAT",pic:""}]];this.EvtParms.VALID_MONCOD=[[],[]];this.EnterCtrl=["BTNTRN_ENTER"];this.setVCMap("AV7MonCod","vMONCOD",0,"int",6,0);this.setVCMap("AV13cMonCod","vCMONCOD",0,"int",6,0);this.setVCMap("Gx_BScreen","vGXBSCREEN",0,"int",1,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV11TrnContext","vTRNCONTEXT",0,"WWPBaseObjectsWWPTransactionContext",0,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.configuracion.monedas)})