gx.evt.autoSkip=!1;gx.define("contabilidad.rubros",!1,function(){var n,t;this.ServerClass="contabilidad.rubros";this.PackageName="GeneXus.Programs";this.ServerFullClass="contabilidad.rubros.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV9TotTipo=gx.fn.getControlValue("vTOTTIPO");this.AV10TotRub=gx.fn.getIntegerValue("vTOTRUB",",");this.AV11RubCod=gx.fn.getIntegerValue("vRUBCOD",",");this.Gx_BScreen=gx.fn.getIntegerValue("vGXBSCREEN",",");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV13TrnContext=gx.fn.getControlValue("vTRNCONTEXT")};this.Valid_Tottipo=function(){return this.validSrvEvt("Valid_Tottipo",0).then(function(n){return n}.closure(this))};this.Valid_Totrub=function(){return this.validSrvEvt("Valid_Totrub",0).then(function(n){return n}.closure(this))};this.Valid_Rubcod=function(){return this.validCliEvt("Valid_Rubcod",0,function(){try{var n=gx.util.balloon.getNew("RUBCOD");this.AnyError=0;this.refreshOutputs([{ctrl:"TOTTIPO"},{av:"A114TotTipo",fld:"TOTTIPO",pic:""},{ctrl:"TOTRUB"},{av:"A115TotRub",fld:"TOTRUB",pic:"ZZZZZ9"}])}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e12752_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e137565_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e147565_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66];this.GXLastCtrlId=66;this.DVPANEL_TABLEATTRIBUTESContainer=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_TABLEATTRIBUTESContainer","Dvpanel_tableattributes","DVPANEL_TABLEATTRIBUTES");t=this.DVPANEL_TABLEATTRIBUTESContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Width","Width","100%","str");t.setProp("Height","Height","100","str");t.setProp("AutoWidth","Autowidth",!1,"bool");t.setProp("AutoHeight","Autoheight",!0,"bool");t.setProp("Cls","Cls","PanelFilled Panel_BaseColor","str");t.setProp("ShowHeader","Showheader",!0,"bool");t.setProp("Title","Title","Información General","str");t.setProp("Collapsible","Collapsible",!1,"bool");t.setProp("Collapsed","Collapsed",!1,"bool");t.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");t.setProp("IconPosition","Iconposition","Right","str");t.setProp("AutoScroll","Autoscroll",!1,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"TABLEATTRIBUTES",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,lvl:0,type:"char",len:3,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Tottipo,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TOTTIPO",gxz:"Z114TotTipo",gxold:"O114TotTipo",gxvar:"A114TotTipo",ucs:[],op:[27],ip:[27,22],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.A114TotTipo=n)},v2z:function(n){n!==undefined&&(gx.O.Z114TotTipo=n)},v2c:function(){gx.fn.setComboBoxValue("TOTTIPO",gx.O.A114TotTipo)},c2v:function(){this.val()!==undefined&&(gx.O.A114TotTipo=this.val())},val:function(){return gx.fn.getControlValue("TOTTIPO")},nac:function(){return!(gx.text.compare("",this.AV9TotTipo)==0)}};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Totrub,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TOTRUB",gxz:"Z115TotRub",gxold:"O115TotRub",gxvar:"A115TotRub",ucs:[],op:[32],ip:[32,27,22],nacdep:[],ctrltype:"dyncombo",v2v:function(n){n!==undefined&&(gx.O.A115TotRub=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z115TotRub=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("TOTRUB",gx.O.A115TotRub)},c2v:function(){this.val()!==undefined&&(gx.O.A115TotRub=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("TOTRUB",",")},nac:function(){return!(0==this.AV10TotRub)}};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TOTDSC",gxz:"Z1928TotDsc",gxold:"O1928TotDsc",gxvar:"A1928TotDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1928TotDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z1928TotDsc=n)},v2c:function(){gx.fn.setControlValue("TOTDSC",gx.O.A1928TotDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1928TotDsc=this.val())},val:function(){return gx.fn.getControlValue("TOTDSC")},nac:gx.falseFn};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Rubcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RUBCOD",gxz:"Z116RubCod",gxold:"O116RubCod",gxvar:"A116RubCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A116RubCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z116RubCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("RUBCOD",gx.O.A116RubCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A116RubCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("RUBCOD",",")},nac:function(){return!(0==this.AV11RubCod)}};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RUBDSC",gxz:"Z1822RubDsc",gxold:"O1822RubDsc",gxvar:"A1822RubDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1822RubDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z1822RubDsc=n)},v2c:function(){gx.fn.setControlValue("RUBDSC",gx.O.A1822RubDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1822RubDsc=this.val())},val:function(){return gx.fn.getControlValue("RUBDSC")},nac:gx.falseFn};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RUBDSCTOT",gxz:"Z1823RubDscTot",gxold:"O1823RubDscTot",gxvar:"A1823RubDscTot",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1823RubDscTot=n)},v2z:function(n){n!==undefined&&(gx.O.Z1823RubDscTot=n)},v2c:function(){gx.fn.setControlValue("RUBDSCTOT",gx.O.A1823RubDscTot,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1823RubDscTot=this.val())},val:function(){return gx.fn.getControlValue("RUBDSCTOT")},nac:gx.falseFn};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,lvl:0,type:"int",len:2,dec:0,sign:!1,pic:"Z9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RUBORD",gxz:"Z117RubOrd",gxold:"O117RubOrd",gxvar:"A117RubOrd",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A117RubOrd=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z117RubOrd=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("RUBORD",gx.O.A117RubOrd,0)},c2v:function(){this.val()!==undefined&&(gx.O.A117RubOrd=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("RUBORD",",")},nac:gx.falseFn};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RUBSTS",gxz:"Z1829RubSts",gxold:"O1829RubSts",gxvar:"A1829RubSts",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1829RubSts=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1829RubSts=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("RUBSTS",gx.O.A1829RubSts,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1829RubSts=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("RUBSTS",",")},nac:gx.falseFn};n[58]={id:58,fld:"",grid:0};n[59]={id:59,fld:"",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"BTNTRN_ENTER",grid:0,evt:"e137565_client",std:"ENTER"};n[63]={id:63,fld:"",grid:0};n[64]={id:64,fld:"BTNTRN_CANCEL",grid:0,evt:"e147565_client"};n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"BTNTRN_DELETE",grid:0,evt:"e157565_client",std:"DELETE"};this.A114TotTipo="";this.Z114TotTipo="";this.O114TotTipo="";this.A115TotRub=0;this.Z115TotRub=0;this.O115TotRub=0;this.A1928TotDsc="";this.Z1928TotDsc="";this.O1928TotDsc="";this.A116RubCod=0;this.Z116RubCod=0;this.O116RubCod=0;this.A1822RubDsc="";this.Z1822RubDsc="";this.O1822RubDsc="";this.A1823RubDscTot="";this.Z1823RubDscTot="";this.O1823RubDscTot="";this.A117RubOrd=0;this.Z117RubOrd=0;this.O117RubOrd=0;this.A1829RubSts=0;this.Z1829RubSts=0;this.O1829RubSts=0;this.AV12WWPContext={UserId:0,UserName:""};this.AV13TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV9TotTipo="";this.AV10TotRub=0;this.AV11RubCod=0;this.AV14WebSession={};this.A114TotTipo="";this.A115TotRub=0;this.A116RubCod=0;this.Gx_BScreen=0;this.A1928TotDsc="";this.A1822RubDsc="";this.A1823RubDscTot="";this.A117RubOrd=0;this.A1829RubSts=0;this.Gx_mode="";this.Events={e12752_client:["AFTER TRN",!0],e137565_client:["ENTER",!0],e147565_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV9TotTipo",fld:"vTOTTIPO",pic:"",hsh:!0},{av:"AV10TotRub",fld:"vTOTRUB",pic:"ZZZZZ9",hsh:!0},{av:"AV11RubCod",fld:"vRUBCOD",pic:"ZZZZZ9",hsh:!0},{ctrl:"TOTTIPO"},{av:"A114TotTipo",fld:"TOTTIPO",pic:""},{ctrl:"TOTRUB"},{av:"A115TotRub",fld:"TOTRUB",pic:"ZZZZZ9"}],[{ctrl:"TOTTIPO"},{av:"A114TotTipo",fld:"TOTTIPO",pic:""},{ctrl:"TOTRUB"},{av:"A115TotRub",fld:"TOTRUB",pic:"ZZZZZ9"}]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV13TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{av:"AV9TotTipo",fld:"vTOTTIPO",pic:"",hsh:!0},{av:"AV10TotRub",fld:"vTOTRUB",pic:"ZZZZZ9",hsh:!0},{av:"AV11RubCod",fld:"vRUBCOD",pic:"ZZZZZ9",hsh:!0},{ctrl:"TOTTIPO"},{av:"A114TotTipo",fld:"TOTTIPO",pic:""},{ctrl:"TOTRUB"},{av:"A115TotRub",fld:"TOTRUB",pic:"ZZZZZ9"}],[{ctrl:"TOTTIPO"},{av:"A114TotTipo",fld:"TOTTIPO",pic:""},{ctrl:"TOTRUB"},{av:"A115TotRub",fld:"TOTRUB",pic:"ZZZZZ9"}]];this.EvtParms["AFTER TRN"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV13TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{ctrl:"TOTTIPO"},{av:"A114TotTipo",fld:"TOTTIPO",pic:""},{ctrl:"TOTRUB"},{av:"A115TotRub",fld:"TOTRUB",pic:"ZZZZZ9"}],[{ctrl:"TOTTIPO"},{av:"A114TotTipo",fld:"TOTTIPO",pic:""},{ctrl:"TOTRUB"},{av:"A115TotRub",fld:"TOTRUB",pic:"ZZZZZ9"}]];this.EvtParms.VALID_TOTTIPO=[[{ctrl:"TOTTIPO"},{av:"A114TotTipo",fld:"TOTTIPO",pic:""},{ctrl:"TOTRUB"},{av:"A115TotRub",fld:"TOTRUB",pic:"ZZZZZ9"}],[{ctrl:"TOTTIPO"},{av:"A114TotTipo",fld:"TOTTIPO",pic:""},{ctrl:"TOTRUB"},{av:"A115TotRub",fld:"TOTRUB",pic:"ZZZZZ9"}]];this.EvtParms.VALID_TOTRUB=[[{av:"A1928TotDsc",fld:"TOTDSC",pic:""},{ctrl:"TOTTIPO"},{av:"A114TotTipo",fld:"TOTTIPO",pic:""},{ctrl:"TOTRUB"},{av:"A115TotRub",fld:"TOTRUB",pic:"ZZZZZ9"}],[{av:"A1928TotDsc",fld:"TOTDSC",pic:""},{ctrl:"TOTTIPO"},{av:"A114TotTipo",fld:"TOTTIPO",pic:""},{ctrl:"TOTRUB"},{av:"A115TotRub",fld:"TOTRUB",pic:"ZZZZZ9"}]];this.EvtParms.VALID_RUBCOD=[[{ctrl:"TOTTIPO"},{av:"A114TotTipo",fld:"TOTTIPO",pic:""},{ctrl:"TOTRUB"},{av:"A115TotRub",fld:"TOTRUB",pic:"ZZZZZ9"}],[{ctrl:"TOTTIPO"},{av:"A114TotTipo",fld:"TOTTIPO",pic:""},{ctrl:"TOTRUB"},{av:"A115TotRub",fld:"TOTRUB",pic:"ZZZZZ9"}]];this.EnterCtrl=["BTNTRN_ENTER"];this.setVCMap("AV9TotTipo","vTOTTIPO",0,"char",3,0);this.setVCMap("AV10TotRub","vTOTRUB",0,"int",6,0);this.setVCMap("AV11RubCod","vRUBCOD",0,"int",6,0);this.setVCMap("Gx_BScreen","vGXBSCREEN",0,"int",1,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV13TrnContext","vTRNCONTEXT",0,"WWPBaseObjectsWWPTransactionContext",0,0);this.Initialize();this.setSDTMapping("WWPBaseObjects\\DVB_SDTDropDownOptionsTitleSettingsIcons",{Default_fi:{extr:"def"},Filtered_fi:{extr:"fil"},SortedASC_fi:{extr:"asc"},SortedDSC_fi:{extr:"dsc"},FilteredSortedASC_fi:{extr:"fasc"},FilteredSortedDSC_fi:{extr:"fdsc"},OptionSortASC_fi:{extr:"osasc"},OptionSortDSC_fi:{extr:"osdsc"},OptionApplyFilter_fi:{extr:"app"},OptionFilteringData_fi:{extr:"fildata"},OptionCleanFilters_fi:{extr:"cle"},SelectedOption_fi:{extr:"selo"},MultiselOption_fi:{extr:"mul"},MultiselSelOption_fi:{extr:"muls"},TreeviewCollapse_fi:{extr:"tcol"},TreeviewExpand_fi:{extr:"texp"},FixLeft_fi:{extr:"fixl"},FixRight_fi:{extr:"fixr"}});this.setSDTMapping("WWPBaseObjects\\WWPTransactionContext",{Attributes:{sdt:"WWPBaseObjects\\WWPTransactionContext.Attribute"}});this.setSDTMapping("WWPBaseObjects\\DVB_SDTComboData.Item",{Title:{extr:"T"},Children:{extr:"C"}})});gx.wi(function(){gx.createParentObj(this.contabilidad.rubros)})