gx.evt.autoSkip=!1;gx.define("produccion.r_resumenordenesproducciondetalle",!1,function(){var n,t,r,i;this.ServerClass="produccion.r_resumenordenesproducciondetalle";this.PackageName="GeneXus.Programs";this.ServerFullClass="produccion.r_resumenordenesproducciondetalle.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Validv_Fdesde=function(){return this.validCliEvt("Validv_Fdesde",0,function(){try{var n=gx.util.balloon.getNew("vFDESDE");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV7FDesde)===0||new gx.date.gxdate(this.AV7FDesde).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo FDesde fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Fhasta=function(){return this.validCliEvt("Validv_Fhasta",0,function(){try{var n=gx.util.balloon.getNew("vFHASTA");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV8FHasta)===0||new gx.date.gxdate(this.AV8FHasta).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo FHasta fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e166u1_client=function(){return this.clearMessages(),this.popupOpenUrl(gx.http.formatLink("generales.wwbusquedaproducto.aspx",["",""]),["AV9ProdCod","AV10ProdDsc"]),this.refreshOutputs([{av:"AV10ProdDsc",fld:"vPRODDSC",pic:""},{av:"AV9ProdCod",fld:"vPRODCOD",pic:"@!"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e176u1_client=function(){return this.clearMessages(),this.AV12OrdCod=this.COMBO_ORDCODContainer.SelectedValue_get,this.refreshOutputs([{av:"AV12OrdCod",fld:"vORDCOD",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e126u2_client=function(){return this.executeServerEvent("'DOBTNIMPRIMIR'",!1,null,!1,!1)};this.e136u2_client=function(){return this.executeServerEvent("'DOBTNEXCEL'",!1,null,!1,!1)};this.e146u2_client=function(){return this.executeServerEvent("'DOBTNSALIR'",!1,null,!1,!1)};this.e186u2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e196u2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,25,28,29,31,33,34,35,36,37,38,39,40,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,71,72,73,74];this.GXLastCtrlId=74;this.COMBO_ORDCODContainer=gx.uc.getNew(this,41,29,"BootstrapDropDownOptions","COMBO_ORDCODContainer","Combo_ordcod","COMBO_ORDCOD");t=this.COMBO_ORDCODContainer;t.setProp("Class","Class","","char");t.setProp("IconType","Icontype","Image","str");t.setProp("Icon","Icon","","str");t.setProp("Caption","Caption","","str");t.setProp("Tooltip","Tooltip","","str");t.setProp("Cls","Cls","ExtendedCombo AttributeRealWidth50With","str");t.setDynProp("SelectedValue_set","Selectedvalue_set","","char");t.setProp("SelectedValue_get","Selectedvalue_get","","char");t.setProp("SelectedText_set","Selectedtext_set","","char");t.setProp("SelectedText_get","Selectedtext_get","","char");t.setProp("GAMOAuthToken","Gamoauthtoken","","char");t.setProp("DDOInternalName","Ddointernalname","","char");t.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");t.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");t.setProp("Enabled","Enabled",!0,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");t.setProp("DataListType","Datalisttype","Dynamic","str");t.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");t.setProp("DataListFixedValues","Datalistfixedvalues","","char");t.setProp("IsGridItem","Isgriditem",!1,"bool");t.setProp("HasDescription","Hasdescription",!1,"bool");t.setProp("DataListProc","Datalistproc","","str");t.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");t.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");t.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");t.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");t.setProp("EmptyItem","Emptyitem",!0,"bool");t.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");t.setProp("HTMLTemplate","Htmltemplate","","str");t.setProp("MultipleValuesType","Multiplevaluestype","Text","str");t.setProp("LoadingData","Loadingdata","","char");t.setProp("NoResultsFound","Noresultsfound","","char");t.setProp("EmptyItemText","Emptyitemtext","GX_EmptyItemText","str");t.setProp("OnlySelectedValues","Onlyselectedvalues","","char");t.setProp("SelectAllText","Selectalltext","","char");t.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");t.setProp("AddNewOptionText","Addnewoptiontext","","str");t.setProp("DropDownOptionsTitleSettingsIcons","Dropdownoptionstitlesettingsicons","","str");t.addV2CFunction("AV13OrdCod_Data","vORDCOD_DATA","SetDropDownOptionsData");t.addC2VFunction(function(n){n.ParentObject.AV13OrdCod_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vORDCOD_DATA",n.ParentObject.AV13OrdCod_Data)});t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("OnOptionClicked",this.e176u1_client);this.setUserControl(t);this.DVPANEL_PANEL1Container=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_PANEL1Container","Dvpanel_panel1","DVPANEL_PANEL1");r=this.DVPANEL_PANEL1Container;r.setProp("Class","Class","","char");r.setProp("Enabled","Enabled",!0,"boolean");r.setProp("Width","Width","100%","str");r.setProp("Height","Height","100","str");r.setProp("AutoWidth","Autowidth",!1,"bool");r.setProp("AutoHeight","Autoheight",!0,"bool");r.setProp("Cls","Cls","PanelFilled Panel_BaseColor","str");r.setProp("ShowHeader","Showheader",!0,"bool");r.setProp("Title","Title","Resumen de Ordenes de Producción Detalle","str");r.setProp("Collapsible","Collapsible",!0,"bool");r.setProp("Collapsed","Collapsed",!1,"bool");r.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");r.setProp("IconPosition","Iconposition","Right","str");r.setProp("AutoScroll","Autoscroll",!1,"bool");r.setProp("Visible","Visible",!0,"bool");r.setProp("Gx Control Type","Gxcontroltype","","int");r.setC2ShowFunction(function(n){n.show()});this.setUserControl(r);this.INNEWWINDOWContainer=gx.uc.getNew(this,70,29,"InNewWindow","INNEWWINDOWContainer","Innewwindow","INNEWWINDOW");i=this.INNEWWINDOWContainer;i.setProp("Class","Class","","char");i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("Width","Width","50","str");i.setProp("Height","Height","50","str");i.setProp("Name","Name","","str");i.setDynProp("Target","Target","","str");i.setProp("Fullscreen","Fullscreen",!1,"bool");i.setProp("Location","Location",!0,"bool");i.setProp("MenuBar","Menubar",!0,"bool");i.setProp("Resizable","Resizable",!0,"bool");i.setProp("Scrollbars","Scrollbars",!0,"bool");i.setProp("TitleBar","Titlebar",!0,"bool");i.setProp("ToolBar","Toolbar",!0,"bool");i.setProp("directories","Directories",!0,"bool");i.setProp("status","Status",!0,"bool");i.setProp("copyhistory","Copyhistory",!0,"bool");i.setProp("top","Top","5","str");i.setProp("left","Left","5","str");i.setProp("fitscreen","Fitscreen",!1,"bool");i.setProp("RefreshParentOnClose","Refreshparentonclose",!1,"bool");i.setProp("Targets","Targets","","str");i.setProp("Visible","Visible",!0,"bool");i.setC2ShowFunction(function(n){n.show()});this.setUserControl(i);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"PANEL1",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"TABLESPLITTEDPRODCOD",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"TEXTBLOCKPRODCOD",format:0,grid:0,ctrltype:"textblock"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"TABLEMERGEDPRODCOD",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,lvl:0,type:"char",len:15,dec:0,sign:!1,pic:"@!",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPRODCOD",gxz:"ZV9ProdCod",gxold:"OV9ProdCod",gxvar:"AV9ProdCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV9ProdCod=n)},v2z:function(n){n!==undefined&&(gx.O.ZV9ProdCod=n)},v2c:function(){gx.fn.setControlValue("vPRODCOD",gx.O.AV9ProdCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV9ProdCod=this.val())},val:function(){return gx.fn.getControlValue("vPRODCOD")},nac:gx.falseFn};n[31]={id:31,fld:"BTNBUSCARSER",grid:0,evt:"e166u1_client"};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPRODDSC",gxz:"ZV10ProdDsc",gxold:"OV10ProdDsc",gxvar:"AV10ProdDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV10ProdDsc=n)},v2z:function(n){n!==undefined&&(gx.O.ZV10ProdDsc=n)},v2c:function(){gx.fn.setControlValue("vPRODDSC",gx.O.AV10ProdDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV10ProdDsc=this.val())},val:function(){return gx.fn.getControlValue("vPRODDSC")},nac:gx.falseFn};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"TABLESPLITTEDORDCOD",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"TEXTBLOCKCOMBO_ORDCOD",format:0,grid:0,ctrltype:"textblock"};n[40]={id:40,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"UNNAMEDTABLEFDESDE",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"TEXTBLOCKFDESDE",format:0,grid:0,ctrltype:"textblock"};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"",grid:0};n[50]={id:50,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Fdesde,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFDESDE",gxz:"ZV7FDesde",gxold:"OV7FDesde",gxvar:"AV7FDesde",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[50],ip:[50],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7FDesde=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV7FDesde=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vFDESDE",gx.O.AV7FDesde,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7FDesde=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vFDESDE")},nac:gx.falseFn};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"UNNAMEDTABLEFHASTA",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"TEXTBLOCKFHASTA",format:0,grid:0,ctrltype:"textblock"};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Fhasta,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFHASTA",gxz:"ZV8FHasta",gxold:"OV8FHasta",gxvar:"AV8FHasta",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[58],ip:[58],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8FHasta=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV8FHasta=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vFHASTA",gx.O.AV8FHasta,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8FHasta=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vFHASTA")},nac:gx.falseFn};n[59]={id:59,fld:"",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"BTNBTNIMPRIMIR",grid:0,evt:"e126u2_client"};n[64]={id:64,fld:"",grid:0};n[65]={id:65,fld:"BTNBTNEXCEL",grid:0,evt:"e136u2_client"};n[66]={id:66,fld:"",grid:0};n[67]={id:67,fld:"BTNBTNSALIR",grid:0,evt:"e146u2_client"};n[68]={id:68,fld:"",grid:0};n[69]={id:69,fld:"",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[74]={id:74,lvl:0,type:"char",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vORDCOD",gxz:"ZV12OrdCod",gxold:"OV12OrdCod",gxvar:"AV12OrdCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV12OrdCod=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12OrdCod=n)},v2c:function(){gx.fn.setControlValue("vORDCOD",gx.O.AV12OrdCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV12OrdCod=this.val())},val:function(){return gx.fn.getControlValue("vORDCOD")},nac:gx.falseFn};this.AV9ProdCod="";this.ZV9ProdCod="";this.OV9ProdCod="";this.AV10ProdDsc="";this.ZV10ProdDsc="";this.OV10ProdDsc="";this.AV7FDesde=gx.date.nullDate();this.ZV7FDesde=gx.date.nullDate();this.OV7FDesde=gx.date.nullDate();this.AV8FHasta=gx.date.nullDate();this.ZV8FHasta=gx.date.nullDate();this.OV8FHasta=gx.date.nullDate();this.AV12OrdCod="";this.ZV12OrdCod="";this.OV12OrdCod="";this.AV9ProdCod="";this.AV10ProdDsc="";this.AV13OrdCod_Data=[];this.AV7FDesde=gx.date.nullDate();this.AV8FHasta=gx.date.nullDate();this.AV12OrdCod="";this.A1740ProSts="";this.A322ProCod="";this.Events={e126u2_client:["'DOBTNIMPRIMIR'",!0],e136u2_client:["'DOBTNEXCEL'",!0],e146u2_client:["'DOBTNSALIR'",!0],e186u2_client:["ENTER",!0],e196u2_client:["CANCEL",!0],e166u1_client:["'DOBTNBUSCARSER'",!1],e176u1_client:["COMBO_ORDCOD.ONOPTIONCLICKED",!1]};this.EvtParms.REFRESH=[[],[]];this.EvtParms["'DOBTNIMPRIMIR'"]=[[{av:"AV9ProdCod",fld:"vPRODCOD",pic:"@!"},{av:"AV7FDesde",fld:"vFDESDE",pic:""},{av:"AV8FHasta",fld:"vFHASTA",pic:""},{av:"AV12OrdCod",fld:"vORDCOD",pic:""}],[{av:"this.INNEWWINDOWContainer.Target",ctrl:"INNEWWINDOW",prop:"Target"}]];this.EvtParms["'DOBTNEXCEL'"]=[[{av:"AV9ProdCod",fld:"vPRODCOD",pic:"@!"},{av:"AV7FDesde",fld:"vFDESDE",pic:""},{av:"AV8FHasta",fld:"vFHASTA",pic:""},{av:"AV12OrdCod",fld:"vORDCOD",pic:""}],[{av:"AV12OrdCod",fld:"vORDCOD",pic:""},{av:"AV8FHasta",fld:"vFHASTA",pic:""},{av:"AV7FDesde",fld:"vFDESDE",pic:""},{av:"AV9ProdCod",fld:"vPRODCOD",pic:"@!"}]];this.EvtParms["'DOBTNSALIR'"]=[[],[]];this.EvtParms["'DOBTNBUSCARSER'"]=[[],[{av:"AV10ProdDsc",fld:"vPRODDSC",pic:""},{av:"AV9ProdCod",fld:"vPRODCOD",pic:"@!"}]];this.EvtParms["COMBO_ORDCOD.ONOPTIONCLICKED"]=[[{av:"this.COMBO_ORDCODContainer.SelectedValue_get",ctrl:"COMBO_ORDCOD",prop:"SelectedValue_get"}],[{av:"AV12OrdCod",fld:"vORDCOD",pic:""}]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALIDV_FDESDE=[[],[]];this.EvtParms.VALIDV_FHASTA=[[],[]];this.Initialize();this.setSDTMapping("WWPBaseObjects\\DVB_SDTComboData.Item",{Title:{extr:"T"},Children:{extr:"C"}})});gx.wi(function(){gx.createParentObj(this.produccion.r_resumenordenesproducciondetalle)})