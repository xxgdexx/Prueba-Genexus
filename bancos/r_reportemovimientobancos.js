gx.evt.autoSkip=!1;gx.define("bancos.r_reportemovimientobancos",!1,function(){var n,t,i,u,r;this.ServerClass="bancos.r_reportemovimientobancos";this.PackageName="GeneXus.Programs";this.ServerFullClass="bancos.r_reportemovimientobancos.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Validv_Fdesde=function(){return this.validCliEvt("Validv_Fdesde",0,function(){try{var n=gx.util.balloon.getNew("vFDESDE");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV8FDesde)===0||new gx.date.gxdate(this.AV8FDesde).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo FDesde fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Fhasta=function(){return this.validCliEvt("Validv_Fhasta",0,function(){try{var n=gx.util.balloon.getNew("vFHASTA");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV9FHasta)===0||new gx.date.gxdate(this.AV9FHasta).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo FHasta fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e143h2_client=function(){return this.executeServerEvent("'DOBTNIMPRIMIR'",!1,null,!1,!1)};this.e153h2_client=function(){return this.executeServerEvent("'DOBTNEXCEL'",!1,null,!1,!1)};this.e163h2_client=function(){return this.executeServerEvent("'DOBTNSALIR'",!1,null,!1,!1)};this.e123h2_client=function(){return this.executeServerEvent("COMBO_PAGCBCOD.ONOPTIONCLICKED",!1,null,!0,!0)};this.e113h2_client=function(){return this.executeServerEvent("COMBO_PAGBANCOD.ONOPTIONCLICKED",!1,null,!0,!0)};this.e183h2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e193h2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,26,27,28,29,30,31,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,71,72,73,74,75];this.GXLastCtrlId=75;this.COMBO_PAGBANCODContainer=gx.uc.getNew(this,25,0,"BootstrapDropDownOptions","COMBO_PAGBANCODContainer","Combo_pagbancod","COMBO_PAGBANCOD");t=this.COMBO_PAGBANCODContainer;t.setProp("Class","Class","","char");t.setProp("IconType","Icontype","Image","str");t.setProp("Icon","Icon","","str");t.setProp("Caption","Caption","","str");t.setProp("Tooltip","Tooltip","","str");t.setProp("Cls","Cls","ExtendedCombo AttributeRealWidth50With","str");t.setDynProp("SelectedValue_set","Selectedvalue_set","","char");t.setProp("SelectedValue_get","Selectedvalue_get","","char");t.setProp("SelectedText_set","Selectedtext_set","","char");t.setProp("SelectedText_get","Selectedtext_get","","char");t.setProp("GAMOAuthToken","Gamoauthtoken","","char");t.setProp("DDOInternalName","Ddointernalname","","char");t.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");t.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");t.setProp("Enabled","Enabled",!0,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");t.setProp("DataListType","Datalisttype","Dynamic","str");t.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");t.setProp("DataListFixedValues","Datalistfixedvalues","","char");t.setProp("IsGridItem","Isgriditem",!1,"bool");t.setProp("HasDescription","Hasdescription",!1,"bool");t.setProp("DataListProc","Datalistproc","","str");t.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");t.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");t.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");t.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");t.setProp("EmptyItem","Emptyitem",!0,"bool");t.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");t.setProp("HTMLTemplate","Htmltemplate","","str");t.setProp("MultipleValuesType","Multiplevaluestype","Text","str");t.setProp("LoadingData","Loadingdata","","char");t.setProp("NoResultsFound","Noresultsfound","","char");t.setProp("EmptyItemText","Emptyitemtext","GX_EmptyItemText","str");t.setProp("OnlySelectedValues","Onlyselectedvalues","","char");t.setProp("SelectAllText","Selectalltext","","char");t.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");t.setProp("AddNewOptionText","Addnewoptiontext","","str");t.addV2CFunction("AV15DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");t.addC2VFunction(function(n){n.ParentObject.AV15DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV15DDO_TitleSettingsIcons)});t.addV2CFunction("AV11PagBanCod_Data","vPAGBANCOD_DATA","SetDropDownOptionsData");t.addC2VFunction(function(n){n.ParentObject.AV11PagBanCod_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vPAGBANCOD_DATA",n.ParentObject.AV11PagBanCod_Data)});t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("OnOptionClicked",this.e113h2_client);this.setUserControl(t);this.COMBO_PAGCBCODContainer=gx.uc.getNew(this,32,0,"BootstrapDropDownOptions","COMBO_PAGCBCODContainer","Combo_pagcbcod","COMBO_PAGCBCOD");i=this.COMBO_PAGCBCODContainer;i.setProp("Class","Class","","char");i.setProp("IconType","Icontype","Image","str");i.setProp("Icon","Icon","","str");i.setProp("Caption","Caption","","str");i.setProp("Tooltip","Tooltip","","str");i.setProp("Cls","Cls","ExtendedCombo AttributeRealWidth50With","str");i.setDynProp("SelectedValue_set","Selectedvalue_set","","char");i.setProp("SelectedValue_get","Selectedvalue_get","","char");i.setDynProp("SelectedText_set","Selectedtext_set","","char");i.setProp("SelectedText_get","Selectedtext_get","","char");i.setProp("GAMOAuthToken","Gamoauthtoken","","char");i.setProp("DDOInternalName","Ddointernalname","","char");i.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");i.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");i.setProp("Enabled","Enabled",!0,"bool");i.setProp("Visible","Visible",!0,"bool");i.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");i.setProp("DataListType","Datalisttype","Dynamic","str");i.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");i.setProp("DataListFixedValues","Datalistfixedvalues","","char");i.setProp("IsGridItem","Isgriditem",!1,"bool");i.setProp("HasDescription","Hasdescription",!1,"bool");i.setProp("DataListProc","Datalistproc","Bancos.R_ReporteMovimientoBancosLoadDVCombo","str");i.setDynProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");i.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");i.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");i.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");i.setProp("EmptyItem","Emptyitem",!0,"bool");i.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");i.setProp("HTMLTemplate","Htmltemplate","","str");i.setProp("MultipleValuesType","Multiplevaluestype","Text","str");i.setProp("LoadingData","Loadingdata","","str");i.setProp("NoResultsFound","Noresultsfound","","str");i.setProp("EmptyItemText","Emptyitemtext","GX_EmptyItemText","str");i.setProp("OnlySelectedValues","Onlyselectedvalues","","char");i.setProp("SelectAllText","Selectalltext","","char");i.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");i.setProp("AddNewOptionText","Addnewoptiontext","","str");i.addV2CFunction("AV15DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");i.addC2VFunction(function(n){n.ParentObject.AV15DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV15DDO_TitleSettingsIcons)});i.addV2CFunction("AV14PagCBCod_Data","vPAGCBCOD_DATA","SetDropDownOptionsData");i.addC2VFunction(function(n){n.ParentObject.AV14PagCBCod_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vPAGCBCOD_DATA",n.ParentObject.AV14PagCBCod_Data)});i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});i.addEventHandler("OnOptionClicked",this.e123h2_client);this.setUserControl(i);this.DVPANEL_PANEL1Container=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_PANEL1Container","Dvpanel_panel1","DVPANEL_PANEL1");u=this.DVPANEL_PANEL1Container;u.setProp("Class","Class","","char");u.setProp("Enabled","Enabled",!0,"boolean");u.setProp("Width","Width","100%","str");u.setProp("Height","Height","100","str");u.setProp("AutoWidth","Autowidth",!1,"bool");u.setProp("AutoHeight","Autoheight",!0,"bool");u.setProp("Cls","Cls","PanelFilled Panel_BaseColor","str");u.setProp("ShowHeader","Showheader",!0,"bool");u.setProp("Title","Title","Reporte de Movimiento de Bancos","str");u.setProp("Collapsible","Collapsible",!0,"bool");u.setProp("Collapsed","Collapsed",!1,"bool");u.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");u.setProp("IconPosition","Iconposition","Right","str");u.setProp("AutoScroll","Autoscroll",!1,"bool");u.setProp("Visible","Visible",!0,"bool");u.setProp("Gx Control Type","Gxcontroltype","","int");u.setC2ShowFunction(function(n){n.show()});this.setUserControl(u);this.INNEWWINDOWContainer=gx.uc.getNew(this,70,41,"InNewWindow","INNEWWINDOWContainer","Innewwindow","INNEWWINDOW");r=this.INNEWWINDOWContainer;r.setProp("Class","Class","","char");r.setProp("Enabled","Enabled",!0,"boolean");r.setProp("Width","Width","50","str");r.setProp("Height","Height","50","str");r.setProp("Name","Name","","str");r.setDynProp("Target","Target","","str");r.setProp("Fullscreen","Fullscreen",!1,"bool");r.setProp("Location","Location",!0,"bool");r.setProp("MenuBar","Menubar",!0,"bool");r.setProp("Resizable","Resizable",!0,"bool");r.setProp("Scrollbars","Scrollbars",!0,"bool");r.setProp("TitleBar","Titlebar",!0,"bool");r.setProp("ToolBar","Toolbar",!0,"bool");r.setProp("directories","Directories",!0,"bool");r.setProp("status","Status",!0,"bool");r.setProp("copyhistory","Copyhistory",!0,"bool");r.setProp("top","Top","5","str");r.setProp("left","Left","5","str");r.setProp("fitscreen","Fitscreen",!1,"bool");r.setProp("RefreshParentOnClose","Refreshparentonclose",!1,"bool");r.setProp("Targets","Targets","","str");r.setProp("Visible","Visible",!0,"bool");r.setC2ShowFunction(function(n){n.show()});this.setUserControl(r);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"PANEL1",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"TABLESPLITTEDPAGBANCOD",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"TEXTBLOCKCOMBO_PAGBANCOD",format:0,grid:0,ctrltype:"textblock"};n[24]={id:24,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"TABLESPLITTEDPAGCBCOD",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"TEXTBLOCKCOMBO_PAGCBCOD",format:0,grid:0,ctrltype:"textblock"};n[31]={id:31,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"UNNAMEDTABLEFDESDE",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"TEXTBLOCKFDESDE",format:0,grid:0,ctrltype:"textblock"};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Fdesde,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFDESDE",gxz:"ZV8FDesde",gxold:"OV8FDesde",gxvar:"AV8FDesde",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[41],ip:[41],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8FDesde=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV8FDesde=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vFDESDE",gx.O.AV8FDesde,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8FDesde=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vFDESDE")},nac:gx.falseFn};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"UNNAMEDTABLEFHASTA",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"TEXTBLOCKFHASTA",format:0,grid:0,ctrltype:"textblock"};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Fhasta,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFHASTA",gxz:"ZV9FHasta",gxold:"OV9FHasta",gxvar:"AV9FHasta",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[49],ip:[49],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV9FHasta=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV9FHasta=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vFHASTA",gx.O.AV9FHasta,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV9FHasta=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vFHASTA")},nac:gx.falseFn};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"UNNAMEDTABLETIPO",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"TEXTBLOCKTIPO",format:0,grid:0,ctrltype:"textblock"};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,lvl:0,type:"char",len:1,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTIPO",gxz:"ZV12Tipo",gxold:"OV12Tipo",gxvar:"AV12Tipo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"radio",v2v:function(n){n!==undefined&&(gx.O.AV12Tipo=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12Tipo=n)},v2c:function(){gx.fn.setRadioValue("vTIPO",gx.O.AV12Tipo)},c2v:function(){this.val()!==undefined&&(gx.O.AV12Tipo=this.val())},val:function(){return gx.fn.getControlValue("vTIPO")},nac:gx.falseFn};n[59]={id:59,fld:"",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"BTNBTNIMPRIMIR",grid:0,evt:"e143h2_client"};n[64]={id:64,fld:"",grid:0};n[65]={id:65,fld:"BTNBTNEXCEL",grid:0,evt:"e153h2_client"};n[66]={id:66,fld:"",grid:0};n[67]={id:67,fld:"BTNBTNSALIR",grid:0,evt:"e163h2_client"};n[68]={id:68,fld:"",grid:0};n[69]={id:69,fld:"",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[74]={id:74,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPAGBANCOD",gxz:"ZV10PagBanCod",gxold:"OV10PagBanCod",gxvar:"AV10PagBanCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV10PagBanCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV10PagBanCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vPAGBANCOD",gx.O.AV10PagBanCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV10PagBanCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vPAGBANCOD",",")},nac:gx.falseFn};n[75]={id:75,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPAGCBCOD",gxz:"ZV13PagCBCod",gxold:"OV13PagCBCod",gxvar:"AV13PagCBCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV13PagCBCod=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13PagCBCod=n)},v2c:function(){gx.fn.setControlValue("vPAGCBCOD",gx.O.AV13PagCBCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV13PagCBCod=this.val())},val:function(){return gx.fn.getControlValue("vPAGCBCOD")},nac:gx.falseFn};this.AV8FDesde=gx.date.nullDate();this.ZV8FDesde=gx.date.nullDate();this.OV8FDesde=gx.date.nullDate();this.AV9FHasta=gx.date.nullDate();this.ZV9FHasta=gx.date.nullDate();this.OV9FHasta=gx.date.nullDate();this.AV12Tipo="";this.ZV12Tipo="";this.OV12Tipo="";this.AV10PagBanCod=0;this.ZV10PagBanCod=0;this.OV10PagBanCod=0;this.AV13PagCBCod="";this.ZV13PagCBCod="";this.OV13PagCBCod="";this.AV15DDO_TitleSettingsIcons={Default_fi:"",Filtered_fi:"",SortedASC_fi:"",SortedDSC_fi:"",FilteredSortedASC_fi:"",FilteredSortedDSC_fi:"",OptionSortASC_fi:"",OptionSortDSC_fi:"",OptionApplyFilter_fi:"",OptionFilteringData_fi:"",OptionCleanFilters_fi:"",SelectedOption_fi:"",MultiselOption_fi:"",MultiselSelOption_fi:"",TreeviewCollapse_fi:"",TreeviewExpand_fi:"",FixLeft_fi:"",FixRight_fi:""};this.AV8FDesde=gx.date.nullDate();this.AV9FHasta=gx.date.nullDate();this.AV12Tipo="";this.AV10PagBanCod=0;this.AV13PagCBCod="";this.A483BanSts=0;this.A372BanCod=0;this.A482BanDsc="";this.A504CBSts=0;this.A377CBCod="";this.Events={e143h2_client:["'DOBTNIMPRIMIR'",!0],e153h2_client:["'DOBTNEXCEL'",!0],e163h2_client:["'DOBTNSALIR'",!0],e123h2_client:["COMBO_PAGCBCOD.ONOPTIONCLICKED",!0],e113h2_client:["COMBO_PAGBANCOD.ONOPTIONCLICKED",!0],e183h2_client:["ENTER",!0],e193h2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{ctrl:"vTIPO"},{av:"AV12Tipo",fld:"vTIPO",pic:""}],[{ctrl:"vTIPO"},{av:"AV12Tipo",fld:"vTIPO",pic:""}]];this.EvtParms["'DOBTNIMPRIMIR'"]=[[{av:"AV10PagBanCod",fld:"vPAGBANCOD",pic:"ZZZZZ9"},{av:"AV13PagCBCod",fld:"vPAGCBCOD",pic:""},{av:"AV8FDesde",fld:"vFDESDE",pic:""},{av:"AV9FHasta",fld:"vFHASTA",pic:""},{ctrl:"vTIPO"},{av:"AV12Tipo",fld:"vTIPO",pic:""}],[{av:"this.INNEWWINDOWContainer.Target",ctrl:"INNEWWINDOW",prop:"Target"},{ctrl:"vTIPO"},{av:"AV12Tipo",fld:"vTIPO",pic:""}]];this.EvtParms["'DOBTNEXCEL'"]=[[{av:"AV10PagBanCod",fld:"vPAGBANCOD",pic:"ZZZZZ9"},{av:"AV13PagCBCod",fld:"vPAGCBCOD",pic:""},{av:"AV8FDesde",fld:"vFDESDE",pic:""},{av:"AV9FHasta",fld:"vFHASTA",pic:""},{ctrl:"vTIPO"},{av:"AV12Tipo",fld:"vTIPO",pic:""}],[{av:"AV9FHasta",fld:"vFHASTA",pic:""},{av:"AV8FDesde",fld:"vFDESDE",pic:""},{av:"AV13PagCBCod",fld:"vPAGCBCOD",pic:""},{av:"AV10PagBanCod",fld:"vPAGBANCOD",pic:"ZZZZZ9"},{ctrl:"vTIPO"},{av:"AV12Tipo",fld:"vTIPO",pic:""}]];this.EvtParms["'DOBTNSALIR'"]=[[{ctrl:"vTIPO"},{av:"AV12Tipo",fld:"vTIPO",pic:""}],[{ctrl:"vTIPO"},{av:"AV12Tipo",fld:"vTIPO",pic:""}]];this.EvtParms["COMBO_PAGCBCOD.ONOPTIONCLICKED"]=[[{av:"this.COMBO_PAGCBCODContainer.SelectedValue_get",ctrl:"COMBO_PAGCBCOD",prop:"SelectedValue_get"},{ctrl:"vTIPO"},{av:"AV12Tipo",fld:"vTIPO",pic:""}],[{av:"AV13PagCBCod",fld:"vPAGCBCOD",pic:""},{ctrl:"vTIPO"},{av:"AV12Tipo",fld:"vTIPO",pic:""}]];this.EvtParms["COMBO_PAGBANCOD.ONOPTIONCLICKED"]=[[{av:"AV10PagBanCod",fld:"vPAGBANCOD",pic:"ZZZZZ9"},{av:"this.COMBO_PAGBANCODContainer.SelectedValue_get",ctrl:"COMBO_PAGBANCOD",prop:"SelectedValue_get"},{ctrl:"vTIPO"},{av:"AV12Tipo",fld:"vTIPO",pic:""}],[{av:"AV10PagBanCod",fld:"vPAGBANCOD",pic:"ZZZZZ9"},{av:"AV13PagCBCod",fld:"vPAGCBCOD",pic:""},{av:"this.COMBO_PAGCBCODContainer.SelectedValue_set",ctrl:"COMBO_PAGCBCOD",prop:"SelectedValue_set"},{av:"this.COMBO_PAGCBCODContainer.SelectedText_set",ctrl:"COMBO_PAGCBCOD",prop:"SelectedText_set"},{ctrl:"vTIPO"},{av:"AV12Tipo",fld:"vTIPO",pic:""}]];this.EvtParms.ENTER=[[{ctrl:"vTIPO"},{av:"AV12Tipo",fld:"vTIPO",pic:""}],[{ctrl:"vTIPO"},{av:"AV12Tipo",fld:"vTIPO",pic:""}]];this.EvtParms.VALIDV_FDESDE=[[{ctrl:"vTIPO"},{av:"AV12Tipo",fld:"vTIPO",pic:""}],[{ctrl:"vTIPO"},{av:"AV12Tipo",fld:"vTIPO",pic:""}]];this.EvtParms.VALIDV_FHASTA=[[{ctrl:"vTIPO"},{av:"AV12Tipo",fld:"vTIPO",pic:""}],[{ctrl:"vTIPO"},{av:"AV12Tipo",fld:"vTIPO",pic:""}]];this.Initialize();this.setSDTMapping("WWPBaseObjects\\DVB_SDTDropDownOptionsTitleSettingsIcons",{Default_fi:{extr:"def"},Filtered_fi:{extr:"fil"},SortedASC_fi:{extr:"asc"},SortedDSC_fi:{extr:"dsc"},FilteredSortedASC_fi:{extr:"fasc"},FilteredSortedDSC_fi:{extr:"fdsc"},OptionSortASC_fi:{extr:"osasc"},OptionSortDSC_fi:{extr:"osdsc"},OptionApplyFilter_fi:{extr:"app"},OptionFilteringData_fi:{extr:"fildata"},OptionCleanFilters_fi:{extr:"cle"},SelectedOption_fi:{extr:"selo"},MultiselOption_fi:{extr:"mul"},MultiselSelOption_fi:{extr:"muls"},TreeviewCollapse_fi:{extr:"tcol"},TreeviewExpand_fi:{extr:"texp"},FixLeft_fi:{extr:"fixl"},FixRight_fi:{extr:"fixr"}});this.setSDTMapping("WWPBaseObjects\\DVB_SDTComboData.Item",{Title:{extr:"T"},Children:{extr:"C"}})});gx.wi(function(){gx.createParentObj(this.bancos.r_reportemovimientobancos)})