gx.evt.autoSkip=!1;gx.define("configuracion.formapago",!1,function(){var n,t;this.ServerClass="configuracion.formapago";this.PackageName="GeneXus.Programs";this.ServerFullClass="configuracion.formapago.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV7ForCod=gx.fn.getIntegerValue("vFORCOD",",");this.AV15cForCod=gx.fn.getIntegerValue("vCFORCOD",",");this.Gx_BScreen=gx.fn.getIntegerValue("vGXBSCREEN",",");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV11TrnContext=gx.fn.getControlValue("vTRNCONTEXT")};this.Valid_Forcod=function(){return this.validCliEvt("Valid_Forcod",0,function(){try{var n=gx.util.balloon.getNew("FORCOD");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Fordsc=function(){return this.validCliEvt("Valid_Fordsc",0,function(){try{var n=gx.util.balloon.getNew("FORDSC");if(this.AnyError=0,gx.text.compare("",this.A988ForDsc)==0)try{n.setError(gx.text.format("%1 es requerido.","Forma de pago","","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Forabr=function(){return this.validCliEvt("Valid_Forabr",0,function(){try{var n=gx.util.balloon.getNew("FORABR");if(this.AnyError=0,gx.text.compare("",this.A986ForAbr)==0)try{n.setError(gx.text.format("%1 es requerido.","Abreviatura forma pago","","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Forsunat=function(){return this.validCliEvt("Valid_Forsunat",0,function(){try{var n=gx.util.balloon.getNew("FORSUNAT");if(this.AnyError=0,gx.text.compare("",this.A990ForSunat)==0)try{n.setError(gx.text.format("%1 es requerido.","Cod.Sunat","","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e125k2_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e135k81_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e145k81_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55];this.GXLastCtrlId=55;this.DVPANEL_TABLEATTRIBUTESContainer=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_TABLEATTRIBUTESContainer","Dvpanel_tableattributes","DVPANEL_TABLEATTRIBUTES");t=this.DVPANEL_TABLEATTRIBUTESContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Width","Width","100%","str");t.setProp("Height","Height","100","str");t.setProp("AutoWidth","Autowidth",!1,"bool");t.setProp("AutoHeight","Autoheight",!0,"bool");t.setProp("Cls","Cls","PanelFilled Panel_BaseColor","str");t.setProp("ShowHeader","Showheader",!0,"bool");t.setProp("Title","Title","Información General","str");t.setProp("Collapsible","Collapsible",!1,"bool");t.setProp("Collapsed","Collapsed",!1,"bool");t.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");t.setProp("IconPosition","Iconposition","Right","str");t.setProp("AutoScroll","Autoscroll",!1,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"TABLEATTRIBUTES",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Fordsc,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FORDSC",gxz:"Z988ForDsc",gxold:"O988ForDsc",gxvar:"A988ForDsc",ucs:[],op:[22],ip:[22],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A988ForDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z988ForDsc=n)},v2c:function(){gx.fn.setControlValue("FORDSC",gx.O.A988ForDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A988ForDsc=this.val())},val:function(){return gx.fn.getControlValue("FORDSC")},nac:gx.falseFn};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,lvl:0,type:"char",len:5,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Forabr,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FORABR",gxz:"Z986ForAbr",gxold:"O986ForAbr",gxvar:"A986ForAbr",ucs:[],op:[27],ip:[27],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A986ForAbr=n)},v2z:function(n){n!==undefined&&(gx.O.Z986ForAbr=n)},v2c:function(){gx.fn.setControlValue("FORABR",gx.O.A986ForAbr,0)},c2v:function(){this.val()!==undefined&&(gx.O.A986ForAbr=this.val())},val:function(){return gx.fn.getControlValue("FORABR")},nac:gx.falseFn};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,lvl:0,type:"char",len:5,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Forsunat,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FORSUNAT",gxz:"Z990ForSunat",gxold:"O990ForSunat",gxvar:"A990ForSunat",ucs:[],op:[32],ip:[32],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A990ForSunat=n)},v2z:function(n){n!==undefined&&(gx.O.Z990ForSunat=n)},v2c:function(){gx.fn.setControlValue("FORSUNAT",gx.O.A990ForSunat,0)},c2v:function(){this.val()!==undefined&&(gx.O.A990ForSunat=this.val())},val:function(){return gx.fn.getControlValue("FORSUNAT")},nac:gx.falseFn};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FORBANSTS",gxz:"Z987ForBanSts",gxold:"O987ForBanSts",gxvar:"A987ForBanSts",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.A987ForBanSts=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z987ForBanSts=gx.num.intval(n))},v2c:function(){gx.fn.setCheckBoxValue("FORBANSTS",gx.O.A987ForBanSts,"1")},c2v:function(){this.val()!==undefined&&(gx.O.A987ForBanSts=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("FORBANSTS",",")},nac:gx.falseFn,values:[1,0]};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FORSTS",gxz:"Z989ForSts",gxold:"O989ForSts",gxvar:"A989ForSts",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.A989ForSts=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z989ForSts=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("FORSTS",gx.O.A989ForSts)},c2v:function(){this.val()!==undefined&&(gx.O.A989ForSts=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("FORSTS",",")},nac:gx.falseFn};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"BTNTRN_ENTER",grid:0,evt:"e135k81_client",std:"ENTER"};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"BTNTRN_CANCEL",grid:0,evt:"e145k81_client"};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"BTNTRN_DELETE",grid:0,evt:"e155k81_client",std:"DELETE"};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[55]={id:55,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Forcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FORCOD",gxz:"Z143ForCod",gxold:"O143ForCod",gxvar:"A143ForCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A143ForCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z143ForCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("FORCOD",gx.O.A143ForCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A143ForCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("FORCOD",",")},nac:function(){return!(0==this.AV7ForCod)}};this.A988ForDsc="";this.Z988ForDsc="";this.O988ForDsc="";this.A986ForAbr="";this.Z986ForAbr="";this.O986ForAbr="";this.A990ForSunat="";this.Z990ForSunat="";this.O990ForSunat="";this.A987ForBanSts=0;this.Z987ForBanSts=0;this.O987ForBanSts=0;this.A989ForSts=0;this.Z989ForSts=0;this.O989ForSts=0;this.A143ForCod=0;this.Z143ForCod=0;this.O143ForCod=0;this.AV10WWPContext={UserId:0,UserName:""};this.AV11TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV7ForCod=0;this.AV12WebSession={};this.A143ForCod=0;this.AV15cForCod=0;this.Gx_BScreen=0;this.A988ForDsc="";this.A986ForAbr="";this.A990ForSunat="";this.A987ForBanSts=0;this.A989ForSts=0;this.Gx_mode="";this.Events={e125k2_client:["AFTER TRN",!0],e135k81_client:["ENTER",!0],e145k81_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV7ForCod",fld:"vFORCOD",pic:"ZZZZZ9",hsh:!0},{av:"A987ForBanSts",fld:"FORBANSTS",pic:"9"}],[{av:"A987ForBanSts",fld:"FORBANSTS",pic:"9"}]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV11TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{av:"AV7ForCod",fld:"vFORCOD",pic:"ZZZZZ9",hsh:!0},{av:"A987ForBanSts",fld:"FORBANSTS",pic:"9"}],[{av:"A987ForBanSts",fld:"FORBANSTS",pic:"9"}]];this.EvtParms["AFTER TRN"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"A143ForCod",fld:"FORCOD",pic:"ZZZZZ9"},{av:"A988ForDsc",fld:"FORDSC",pic:""},{av:"AV11TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{av:"A987ForBanSts",fld:"FORBANSTS",pic:"9"}],[{av:"A987ForBanSts",fld:"FORBANSTS",pic:"9"}]];this.EvtParms.VALID_FORDSC=[[{av:"A988ForDsc",fld:"FORDSC",pic:""},{av:"A987ForBanSts",fld:"FORBANSTS",pic:"9"}],[{av:"A988ForDsc",fld:"FORDSC",pic:""},{av:"A987ForBanSts",fld:"FORBANSTS",pic:"9"}]];this.EvtParms.VALID_FORABR=[[{av:"A986ForAbr",fld:"FORABR",pic:""},{av:"A987ForBanSts",fld:"FORBANSTS",pic:"9"}],[{av:"A986ForAbr",fld:"FORABR",pic:""},{av:"A987ForBanSts",fld:"FORBANSTS",pic:"9"}]];this.EvtParms.VALID_FORSUNAT=[[{av:"A990ForSunat",fld:"FORSUNAT",pic:""},{av:"A987ForBanSts",fld:"FORBANSTS",pic:"9"}],[{av:"A990ForSunat",fld:"FORSUNAT",pic:""},{av:"A987ForBanSts",fld:"FORBANSTS",pic:"9"}]];this.EvtParms.VALID_FORCOD=[[{av:"A987ForBanSts",fld:"FORBANSTS",pic:"9"}],[{av:"A987ForBanSts",fld:"FORBANSTS",pic:"9"}]];this.EnterCtrl=["BTNTRN_ENTER"];this.setVCMap("AV7ForCod","vFORCOD",0,"int",6,0);this.setVCMap("AV15cForCod","vCFORCOD",0,"int",6,0);this.setVCMap("Gx_BScreen","vGXBSCREEN",0,"int",1,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV11TrnContext","vTRNCONTEXT",0,"WWPBaseObjectsWWPTransactionContext",0,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.configuracion.formapago)})