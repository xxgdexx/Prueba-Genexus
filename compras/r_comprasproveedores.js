gx.evt.autoSkip=!1;gx.define("compras.r_comprasproveedores",!1,function(){var n,t,i,r,u,e,f;this.ServerClass="compras.r_comprasproveedores";this.PackageName="GeneXus.Programs";this.ServerFullClass="compras.r_comprasproveedores.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV21DocMonCod=gx.fn.getIntegerValue("vDOCMONCOD",",")};this.Validv_Fdesde=function(){return this.validCliEvt("Validv_Fdesde",0,function(){try{var n=gx.util.balloon.getNew("vFDESDE");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV11Fdesde)===0||new gx.date.gxdate(this.AV11Fdesde).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Fdesde fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Fhasta=function(){return this.validCliEvt("Validv_Fhasta",0,function(){try{var n=gx.util.balloon.getNew("vFHASTA");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV12Fhasta)===0||new gx.date.gxdate(this.AV12Fhasta).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Fhasta fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e163z1_client=function(){return this.clearMessages(),this.popupOpenUrl(gx.http.formatLink("generales.wwbusquedaproveedor.aspx",["",""]),["AV9PrvCod","AV10PrvDsc"]),this.refreshOutputs([{av:"AV10PrvDsc",fld:"vPRVDSC",pic:""},{av:"AV9PrvCod",fld:"vPRVCOD",pic:"@!"},{ctrl:"vTIPO"},{av:"AV13Tipo",fld:"vTIPO",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e173z1_client=function(){return this.clearMessages(),this.AV8MonCod=gx.num.trunc(gx.num.val(this.COMBO_MONCODContainer.SelectedValue_get),0),this.refreshOutputs([{av:"AV8MonCod",fld:"vMONCOD",pic:"ZZZZZ9"},{ctrl:"vTIPO"},{av:"AV13Tipo",fld:"vTIPO",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e183z1_client=function(){return this.clearMessages(),this.AV7PaiCod=this.COMBO_PAICODContainer.SelectedValue_get,this.refreshOutputs([{av:"AV7PaiCod",fld:"vPAICOD",pic:""},{ctrl:"vTIPO"},{av:"AV13Tipo",fld:"vTIPO",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e193z1_client=function(){return this.clearMessages(),this.AV6TPrvCod=gx.num.trunc(gx.num.val(this.COMBO_TPRVCODContainer.SelectedValue_get),0),this.refreshOutputs([{av:"AV6TPrvCod",fld:"vTPRVCOD",pic:"ZZZZZ9"},{ctrl:"vTIPO"},{av:"AV13Tipo",fld:"vTIPO",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e203z1_client=function(){return this.clearMessages(),this.AV5TipCod=this.COMBO_TIPCODContainer.SelectedValue_get,this.refreshOutputs([{av:"AV5TipCod",fld:"vTIPCOD",pic:""},{ctrl:"vTIPO"},{av:"AV13Tipo",fld:"vTIPO",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e123z2_client=function(){return this.executeServerEvent("'DOBTNIMPRIMIR'",!1,null,!1,!1)};this.e133z2_client=function(){return this.executeServerEvent("'DOBTNEXCEL'",!1,null,!1,!1)};this.e143z2_client=function(){return this.executeServerEvent("'DOBTNSALIR'",!1,null,!1,!1)};this.e213z2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e223z2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,26,27,28,29,30,31,33,34,35,36,37,38,39,41,42,43,44,45,46,48,49,50,51,52,53,54,55,58,59,61,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100,101,102,104,105,106,107,108,109,110];this.GXLastCtrlId=110;this.COMBO_TIPCODContainer=gx.uc.getNew(this,25,0,"BootstrapDropDownOptions","COMBO_TIPCODContainer","Combo_tipcod","COMBO_TIPCOD");t=this.COMBO_TIPCODContainer;t.setProp("Class","Class","","char");t.setProp("IconType","Icontype","Image","str");t.setProp("Icon","Icon","","str");t.setProp("Caption","Caption","","str");t.setProp("Tooltip","Tooltip","","str");t.setProp("Cls","Cls","ExtendedCombo AttributeRealWidth50With","str");t.setDynProp("SelectedValue_set","Selectedvalue_set","","char");t.setProp("SelectedValue_get","Selectedvalue_get","","char");t.setProp("SelectedText_set","Selectedtext_set","","char");t.setProp("SelectedText_get","Selectedtext_get","","char");t.setProp("GAMOAuthToken","Gamoauthtoken","","char");t.setProp("DDOInternalName","Ddointernalname","","char");t.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");t.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");t.setProp("Enabled","Enabled",!0,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");t.setProp("DataListType","Datalisttype","Dynamic","str");t.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");t.setProp("DataListFixedValues","Datalistfixedvalues","","char");t.setProp("IsGridItem","Isgriditem",!1,"bool");t.setProp("HasDescription","Hasdescription",!1,"bool");t.setProp("DataListProc","Datalistproc","","str");t.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");t.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");t.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");t.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");t.setProp("EmptyItem","Emptyitem",!0,"bool");t.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");t.setProp("HTMLTemplate","Htmltemplate","","str");t.setProp("MultipleValuesType","Multiplevaluestype","Text","str");t.setProp("LoadingData","Loadingdata","","char");t.setProp("NoResultsFound","Noresultsfound","","char");t.setProp("EmptyItemText","Emptyitemtext","GX_EmptyItemText","str");t.setProp("OnlySelectedValues","Onlyselectedvalues","","char");t.setProp("SelectAllText","Selectalltext","","char");t.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");t.setProp("AddNewOptionText","Addnewoptiontext","","str");t.setProp("DropDownOptionsTitleSettingsIcons","Dropdownoptionstitlesettingsicons","","str");t.addV2CFunction("AV14TipCod_Data","vTIPCOD_DATA","SetDropDownOptionsData");t.addC2VFunction(function(n){n.ParentObject.AV14TipCod_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vTIPCOD_DATA",n.ParentObject.AV14TipCod_Data)});t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("OnOptionClicked",this.e203z1_client);this.setUserControl(t);this.COMBO_TPRVCODContainer=gx.uc.getNew(this,32,0,"BootstrapDropDownOptions","COMBO_TPRVCODContainer","Combo_tprvcod","COMBO_TPRVCOD");i=this.COMBO_TPRVCODContainer;i.setProp("Class","Class","","char");i.setProp("IconType","Icontype","Image","str");i.setProp("Icon","Icon","","str");i.setProp("Caption","Caption","","str");i.setProp("Tooltip","Tooltip","","str");i.setProp("Cls","Cls","ExtendedCombo AttributeRealWidth50With","str");i.setDynProp("SelectedValue_set","Selectedvalue_set","","char");i.setProp("SelectedValue_get","Selectedvalue_get","","char");i.setProp("SelectedText_set","Selectedtext_set","","char");i.setProp("SelectedText_get","Selectedtext_get","","char");i.setProp("GAMOAuthToken","Gamoauthtoken","","char");i.setProp("DDOInternalName","Ddointernalname","","char");i.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");i.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");i.setProp("Enabled","Enabled",!0,"bool");i.setProp("Visible","Visible",!0,"bool");i.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");i.setProp("DataListType","Datalisttype","Dynamic","str");i.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");i.setProp("DataListFixedValues","Datalistfixedvalues","","char");i.setProp("IsGridItem","Isgriditem",!1,"bool");i.setProp("HasDescription","Hasdescription",!1,"bool");i.setProp("DataListProc","Datalistproc","","str");i.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");i.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");i.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");i.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");i.setProp("EmptyItem","Emptyitem",!0,"bool");i.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");i.setProp("HTMLTemplate","Htmltemplate","","str");i.setProp("MultipleValuesType","Multiplevaluestype","Text","str");i.setProp("LoadingData","Loadingdata","","char");i.setProp("NoResultsFound","Noresultsfound","","char");i.setProp("EmptyItemText","Emptyitemtext","GX_EmptyItemText","str");i.setProp("OnlySelectedValues","Onlyselectedvalues","","char");i.setProp("SelectAllText","Selectalltext","","char");i.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");i.setProp("AddNewOptionText","Addnewoptiontext","","str");i.setProp("DropDownOptionsTitleSettingsIcons","Dropdownoptionstitlesettingsicons","","str");i.addV2CFunction("AV16TPrvCod_Data","vTPRVCOD_DATA","SetDropDownOptionsData");i.addC2VFunction(function(n){n.ParentObject.AV16TPrvCod_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vTPRVCOD_DATA",n.ParentObject.AV16TPrvCod_Data)});i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});i.addEventHandler("OnOptionClicked",this.e193z1_client);this.setUserControl(i);this.COMBO_PAICODContainer=gx.uc.getNew(this,40,0,"BootstrapDropDownOptions","COMBO_PAICODContainer","Combo_paicod","COMBO_PAICOD");r=this.COMBO_PAICODContainer;r.setProp("Class","Class","","char");r.setProp("IconType","Icontype","Image","str");r.setProp("Icon","Icon","","str");r.setProp("Caption","Caption","","str");r.setProp("Tooltip","Tooltip","","str");r.setProp("Cls","Cls","ExtendedCombo AttributeRealWidth50With","str");r.setDynProp("SelectedValue_set","Selectedvalue_set","","char");r.setProp("SelectedValue_get","Selectedvalue_get","","char");r.setProp("SelectedText_set","Selectedtext_set","","char");r.setProp("SelectedText_get","Selectedtext_get","","char");r.setProp("GAMOAuthToken","Gamoauthtoken","","char");r.setProp("DDOInternalName","Ddointernalname","","char");r.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");r.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");r.setProp("Enabled","Enabled",!0,"bool");r.setProp("Visible","Visible",!0,"bool");r.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");r.setProp("DataListType","Datalisttype","Dynamic","str");r.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");r.setProp("DataListFixedValues","Datalistfixedvalues","","char");r.setProp("IsGridItem","Isgriditem",!1,"bool");r.setProp("HasDescription","Hasdescription",!1,"bool");r.setProp("DataListProc","Datalistproc","","str");r.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");r.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");r.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");r.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");r.setProp("EmptyItem","Emptyitem",!0,"bool");r.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");r.setProp("HTMLTemplate","Htmltemplate","","str");r.setProp("MultipleValuesType","Multiplevaluestype","Text","str");r.setProp("LoadingData","Loadingdata","","char");r.setProp("NoResultsFound","Noresultsfound","","char");r.setProp("EmptyItemText","Emptyitemtext","GX_EmptyItemText","str");r.setProp("OnlySelectedValues","Onlyselectedvalues","","char");r.setProp("SelectAllText","Selectalltext","","char");r.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");r.setProp("AddNewOptionText","Addnewoptiontext","","str");r.setProp("DropDownOptionsTitleSettingsIcons","Dropdownoptionstitlesettingsicons","","str");r.addV2CFunction("AV17PaiCod_Data","vPAICOD_DATA","SetDropDownOptionsData");r.addC2VFunction(function(n){n.ParentObject.AV17PaiCod_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vPAICOD_DATA",n.ParentObject.AV17PaiCod_Data)});r.setProp("Gx Control Type","Gxcontroltype","","int");r.setC2ShowFunction(function(n){n.show()});r.addEventHandler("OnOptionClicked",this.e183z1_client);this.setUserControl(r);this.COMBO_MONCODContainer=gx.uc.getNew(this,47,0,"BootstrapDropDownOptions","COMBO_MONCODContainer","Combo_moncod","COMBO_MONCOD");u=this.COMBO_MONCODContainer;u.setProp("Class","Class","","char");u.setProp("IconType","Icontype","Image","str");u.setProp("Icon","Icon","","str");u.setProp("Caption","Caption","","str");u.setProp("Tooltip","Tooltip","","str");u.setProp("Cls","Cls","ExtendedCombo AttributeRealWidth50With","str");u.setDynProp("SelectedValue_set","Selectedvalue_set","","char");u.setProp("SelectedValue_get","Selectedvalue_get","","char");u.setProp("SelectedText_set","Selectedtext_set","","char");u.setProp("SelectedText_get","Selectedtext_get","","char");u.setProp("GAMOAuthToken","Gamoauthtoken","","char");u.setProp("DDOInternalName","Ddointernalname","","char");u.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");u.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");u.setProp("Enabled","Enabled",!0,"bool");u.setProp("Visible","Visible",!0,"bool");u.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");u.setProp("DataListType","Datalisttype","Dynamic","str");u.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");u.setProp("DataListFixedValues","Datalistfixedvalues","","char");u.setProp("IsGridItem","Isgriditem",!1,"bool");u.setProp("HasDescription","Hasdescription",!1,"bool");u.setProp("DataListProc","Datalistproc","","str");u.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");u.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");u.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");u.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");u.setProp("EmptyItem","Emptyitem",!0,"bool");u.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");u.setProp("HTMLTemplate","Htmltemplate","","str");u.setProp("MultipleValuesType","Multiplevaluestype","Text","str");u.setProp("LoadingData","Loadingdata","","char");u.setProp("NoResultsFound","Noresultsfound","","char");u.setProp("EmptyItemText","Emptyitemtext","GX_EmptyItemText","str");u.setProp("OnlySelectedValues","Onlyselectedvalues","","char");u.setProp("SelectAllText","Selectalltext","","char");u.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");u.setProp("AddNewOptionText","Addnewoptiontext","","str");u.setProp("DropDownOptionsTitleSettingsIcons","Dropdownoptionstitlesettingsicons","","str");u.addV2CFunction("AV18MonCod_Data","vMONCOD_DATA","SetDropDownOptionsData");u.addC2VFunction(function(n){n.ParentObject.AV18MonCod_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vMONCOD_DATA",n.ParentObject.AV18MonCod_Data)});u.setProp("Gx Control Type","Gxcontroltype","","int");u.setC2ShowFunction(function(n){n.show()});u.addEventHandler("OnOptionClicked",this.e173z1_client);this.setUserControl(u);this.DVPANEL_PANEL1Container=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_PANEL1Container","Dvpanel_panel1","DVPANEL_PANEL1");e=this.DVPANEL_PANEL1Container;e.setProp("Class","Class","","char");e.setProp("Enabled","Enabled",!0,"boolean");e.setProp("Width","Width","100%","str");e.setProp("Height","Height","100","str");e.setProp("AutoWidth","Autowidth",!1,"bool");e.setProp("AutoHeight","Autoheight",!0,"bool");e.setProp("Cls","Cls","PanelFilled Panel_BaseColor","str");e.setProp("ShowHeader","Showheader",!0,"bool");e.setProp("Title","Title","Analisis de Compras por Proveedores","str");e.setProp("Collapsible","Collapsible",!0,"bool");e.setProp("Collapsed","Collapsed",!1,"bool");e.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");e.setProp("IconPosition","Iconposition","Right","str");e.setProp("AutoScroll","Autoscroll",!1,"bool");e.setProp("Visible","Visible",!0,"bool");e.setProp("Gx Control Type","Gxcontroltype","","int");e.setC2ShowFunction(function(n){n.show()});this.setUserControl(e);this.INNEWWINDOWContainer=gx.uc.getNew(this,103,59,"InNewWindow","INNEWWINDOWContainer","Innewwindow","INNEWWINDOW");f=this.INNEWWINDOWContainer;f.setProp("Class","Class","","char");f.setProp("Enabled","Enabled",!0,"boolean");f.setProp("Width","Width","50","str");f.setProp("Height","Height","50","str");f.setProp("Name","Name","","str");f.setDynProp("Target","Target","","str");f.setProp("Fullscreen","Fullscreen",!1,"bool");f.setProp("Location","Location",!0,"bool");f.setProp("MenuBar","Menubar",!0,"bool");f.setProp("Resizable","Resizable",!0,"bool");f.setProp("Scrollbars","Scrollbars",!0,"bool");f.setProp("TitleBar","Titlebar",!0,"bool");f.setProp("ToolBar","Toolbar",!0,"bool");f.setProp("directories","Directories",!0,"bool");f.setProp("status","Status",!0,"bool");f.setProp("copyhistory","Copyhistory",!0,"bool");f.setProp("top","Top","5","str");f.setProp("left","Left","5","str");f.setProp("fitscreen","Fitscreen",!1,"bool");f.setProp("RefreshParentOnClose","Refreshparentonclose",!1,"bool");f.setProp("Targets","Targets","","str");f.setProp("Visible","Visible",!0,"bool");f.setC2ShowFunction(function(n){n.show()});this.setUserControl(f);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"PANEL1",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"TABLESPLITTEDTIPCOD",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"TEXTBLOCKCOMBO_TIPCOD",format:0,grid:0,ctrltype:"textblock"};n[24]={id:24,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"TABLESPLITTEDTPRVCOD",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"TEXTBLOCKCOMBO_TPRVCOD",format:0,grid:0,ctrltype:"textblock"};n[31]={id:31,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"TABLESPLITTEDPAICOD",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"TEXTBLOCKCOMBO_PAICOD",format:0,grid:0,ctrltype:"textblock"};n[39]={id:39,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"TABLESPLITTEDMONCOD",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"TEXTBLOCKCOMBO_MONCOD",format:0,grid:0,ctrltype:"textblock"};n[46]={id:46,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"TABLESPLITTEDPRVCOD",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"TEXTBLOCKPRVCOD",format:0,grid:0,ctrltype:"textblock"};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"TABLEMERGEDPRVCOD",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,lvl:0,type:"char",len:20,dec:0,sign:!1,pic:"@!",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPRVCOD",gxz:"ZV9PrvCod",gxold:"OV9PrvCod",gxvar:"AV9PrvCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV9PrvCod=n)},v2z:function(n){n!==undefined&&(gx.O.ZV9PrvCod=n)},v2c:function(){gx.fn.setControlValue("vPRVCOD",gx.O.AV9PrvCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV9PrvCod=this.val())},val:function(){return gx.fn.getControlValue("vPRVCOD")},nac:gx.falseFn};n[61]={id:61,fld:"BTNBUSCAR",grid:0,evt:"e163z1_client"};n[63]={id:63,fld:"",grid:0};n[64]={id:64,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPRVDSC",gxz:"ZV10PrvDsc",gxold:"OV10PrvDsc",gxvar:"AV10PrvDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV10PrvDsc=n)},v2z:function(n){n!==undefined&&(gx.O.ZV10PrvDsc=n)},v2c:function(){gx.fn.setControlValue("vPRVDSC",gx.O.AV10PrvDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV10PrvDsc=this.val())},val:function(){return gx.fn.getControlValue("vPRVDSC")},nac:gx.falseFn};n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"",grid:0};n[67]={id:67,fld:"UNNAMEDTABLEFDESDE",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,fld:"",grid:0};n[70]={id:70,fld:"TEXTBLOCKFDESDE",format:0,grid:0,ctrltype:"textblock"};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"",grid:0};n[73]={id:73,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Fdesde,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFDESDE",gxz:"ZV11Fdesde",gxold:"OV11Fdesde",gxvar:"AV11Fdesde",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[73],ip:[73],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV11Fdesde=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV11Fdesde=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vFDESDE",gx.O.AV11Fdesde,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV11Fdesde=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vFDESDE")},nac:gx.falseFn};n[74]={id:74,fld:"",grid:0};n[75]={id:75,fld:"",grid:0};n[76]={id:76,fld:"UNNAMEDTABLEFHASTA",grid:0};n[77]={id:77,fld:"",grid:0};n[78]={id:78,fld:"",grid:0};n[79]={id:79,fld:"TEXTBLOCKFHASTA",format:0,grid:0,ctrltype:"textblock"};n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"",grid:0};n[82]={id:82,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Fhasta,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFHASTA",gxz:"ZV12Fhasta",gxold:"OV12Fhasta",gxvar:"AV12Fhasta",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[82],ip:[82],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV12Fhasta=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV12Fhasta=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vFHASTA",gx.O.AV12Fhasta,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV12Fhasta=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vFHASTA")},nac:gx.falseFn};n[83]={id:83,fld:"",grid:0};n[84]={id:84,fld:"",grid:0};n[85]={id:85,fld:"UNNAMEDTABLETIPO",grid:0};n[86]={id:86,fld:"",grid:0};n[87]={id:87,fld:"",grid:0};n[88]={id:88,fld:"TEXTBLOCKTIPO",format:0,grid:0,ctrltype:"textblock"};n[89]={id:89,fld:"",grid:0};n[90]={id:90,fld:"",grid:0};n[91]={id:91,lvl:0,type:"char",len:1,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTIPO",gxz:"ZV13Tipo",gxold:"OV13Tipo",gxvar:"AV13Tipo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"radio",v2v:function(n){n!==undefined&&(gx.O.AV13Tipo=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13Tipo=n)},v2c:function(){gx.fn.setRadioValue("vTIPO",gx.O.AV13Tipo)},c2v:function(){this.val()!==undefined&&(gx.O.AV13Tipo=this.val())},val:function(){return gx.fn.getControlValue("vTIPO")},nac:gx.falseFn};n[92]={id:92,fld:"",grid:0};n[93]={id:93,fld:"",grid:0};n[94]={id:94,fld:"",grid:0};n[95]={id:95,fld:"",grid:0};n[96]={id:96,fld:"BTNBTNIMPRIMIR",grid:0,evt:"e123z2_client"};n[97]={id:97,fld:"",grid:0};n[98]={id:98,fld:"BTNBTNEXCEL",grid:0,evt:"e133z2_client"};n[99]={id:99,fld:"",grid:0};n[100]={id:100,fld:"BTNBTNSALIR",grid:0,evt:"e143z2_client"};n[101]={id:101,fld:"",grid:0};n[102]={id:102,fld:"",grid:0};n[104]={id:104,fld:"",grid:0};n[105]={id:105,fld:"",grid:0};n[106]={id:106,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[107]={id:107,lvl:0,type:"char",len:3,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTIPCOD",gxz:"ZV5TipCod",gxold:"OV5TipCod",gxvar:"AV5TipCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV5TipCod=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5TipCod=n)},v2c:function(){gx.fn.setControlValue("vTIPCOD",gx.O.AV5TipCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV5TipCod=this.val())},val:function(){return gx.fn.getControlValue("vTIPCOD")},nac:gx.falseFn};n[108]={id:108,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTPRVCOD",gxz:"ZV6TPrvCod",gxold:"OV6TPrvCod",gxvar:"AV6TPrvCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6TPrvCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6TPrvCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vTPRVCOD",gx.O.AV6TPrvCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6TPrvCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vTPRVCOD",",")},nac:gx.falseFn};n[109]={id:109,lvl:0,type:"char",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPAICOD",gxz:"ZV7PaiCod",gxold:"OV7PaiCod",gxvar:"AV7PaiCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7PaiCod=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7PaiCod=n)},v2c:function(){gx.fn.setControlValue("vPAICOD",gx.O.AV7PaiCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7PaiCod=this.val())},val:function(){return gx.fn.getControlValue("vPAICOD")},nac:gx.falseFn};n[110]={id:110,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vMONCOD",gxz:"ZV8MonCod",gxold:"OV8MonCod",gxvar:"AV8MonCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8MonCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV8MonCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vMONCOD",gx.O.AV8MonCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8MonCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vMONCOD",",")},nac:gx.falseFn};this.AV9PrvCod="";this.ZV9PrvCod="";this.OV9PrvCod="";this.AV10PrvDsc="";this.ZV10PrvDsc="";this.OV10PrvDsc="";this.AV11Fdesde=gx.date.nullDate();this.ZV11Fdesde=gx.date.nullDate();this.OV11Fdesde=gx.date.nullDate();this.AV12Fhasta=gx.date.nullDate();this.ZV12Fhasta=gx.date.nullDate();this.OV12Fhasta=gx.date.nullDate();this.AV13Tipo="";this.ZV13Tipo="";this.OV13Tipo="";this.AV5TipCod="";this.ZV5TipCod="";this.OV5TipCod="";this.AV6TPrvCod=0;this.ZV6TPrvCod=0;this.OV6TPrvCod=0;this.AV7PaiCod="";this.ZV7PaiCod="";this.OV7PaiCod="";this.AV8MonCod=0;this.ZV8MonCod=0;this.OV8MonCod=0;this.AV14TipCod_Data=[];this.AV16TPrvCod_Data=[];this.AV17PaiCod_Data=[];this.AV18MonCod_Data=[];this.AV9PrvCod="";this.AV10PrvDsc="";this.AV11Fdesde=gx.date.nullDate();this.AV12Fhasta=gx.date.nullDate();this.AV13Tipo="";this.AV5TipCod="";this.AV6TPrvCod=0;this.AV7PaiCod="";this.AV8MonCod=0;this.A1919TipSts=0;this.A149TipCod="";this.A1910TipDsc="";this.A1942TprvSts=0;this.A298TprvCod=0;this.A1941TprvDsc="";this.A1501PaiSts=0;this.A139PaiCod="";this.A1500PaiDsc="";this.A1235MonSts=0;this.A180MonCod=0;this.A1234MonDsc="";this.AV21DocMonCod=0;this.Events={e123z2_client:["'DOBTNIMPRIMIR'",!0],e133z2_client:["'DOBTNEXCEL'",!0],e143z2_client:["'DOBTNSALIR'",!0],e213z2_client:["ENTER",!0],e223z2_client:["CANCEL",!0],e163z1_client:["'DOBTNBUSCAR'",!1],e173z1_client:["COMBO_MONCOD.ONOPTIONCLICKED",!1],e183z1_client:["COMBO_PAICOD.ONOPTIONCLICKED",!1],e193z1_client:["COMBO_TPRVCOD.ONOPTIONCLICKED",!1],e203z1_client:["COMBO_TIPCOD.ONOPTIONCLICKED",!1]};this.EvtParms.REFRESH=[[{ctrl:"vTIPO"},{av:"AV13Tipo",fld:"vTIPO",pic:""}],[{ctrl:"vTIPO"},{av:"AV13Tipo",fld:"vTIPO",pic:""}]];this.EvtParms["'DOBTNIMPRIMIR'"]=[[{av:"AV6TPrvCod",fld:"vTPRVCOD",pic:"ZZZZZ9"},{av:"AV9PrvCod",fld:"vPRVCOD",pic:"@!"},{av:"AV5TipCod",fld:"vTIPCOD",pic:""},{av:"AV7PaiCod",fld:"vPAICOD",pic:""},{av:"AV11Fdesde",fld:"vFDESDE",pic:""},{av:"AV12Fhasta",fld:"vFHASTA",pic:""},{av:"AV21DocMonCod",fld:"vDOCMONCOD",pic:"ZZZZZ9"},{ctrl:"vTIPO"},{av:"AV13Tipo",fld:"vTIPO",pic:""}],[{av:"this.INNEWWINDOWContainer.Target",ctrl:"INNEWWINDOW",prop:"Target"},{ctrl:"vTIPO"},{av:"AV13Tipo",fld:"vTIPO",pic:""}]];this.EvtParms["'DOBTNEXCEL'"]=[[{av:"AV6TPrvCod",fld:"vTPRVCOD",pic:"ZZZZZ9"},{av:"AV9PrvCod",fld:"vPRVCOD",pic:"@!"},{av:"AV5TipCod",fld:"vTIPCOD",pic:""},{av:"AV7PaiCod",fld:"vPAICOD",pic:""},{av:"AV11Fdesde",fld:"vFDESDE",pic:""},{av:"AV12Fhasta",fld:"vFHASTA",pic:""},{av:"AV21DocMonCod",fld:"vDOCMONCOD",pic:"ZZZZZ9"},{ctrl:"vTIPO"},{av:"AV13Tipo",fld:"vTIPO",pic:""}],[{av:"AV21DocMonCod",fld:"vDOCMONCOD",pic:"ZZZZZ9"},{av:"AV12Fhasta",fld:"vFHASTA",pic:""},{av:"AV11Fdesde",fld:"vFDESDE",pic:""},{av:"AV7PaiCod",fld:"vPAICOD",pic:""},{av:"AV5TipCod",fld:"vTIPCOD",pic:""},{av:"AV9PrvCod",fld:"vPRVCOD",pic:"@!"},{av:"AV6TPrvCod",fld:"vTPRVCOD",pic:"ZZZZZ9"},{ctrl:"vTIPO"},{av:"AV13Tipo",fld:"vTIPO",pic:""}]];this.EvtParms["'DOBTNSALIR'"]=[[{ctrl:"vTIPO"},{av:"AV13Tipo",fld:"vTIPO",pic:""}],[{ctrl:"vTIPO"},{av:"AV13Tipo",fld:"vTIPO",pic:""}]];this.EvtParms["'DOBTNBUSCAR'"]=[[{ctrl:"vTIPO"},{av:"AV13Tipo",fld:"vTIPO",pic:""}],[{av:"AV10PrvDsc",fld:"vPRVDSC",pic:""},{av:"AV9PrvCod",fld:"vPRVCOD",pic:"@!"},{ctrl:"vTIPO"},{av:"AV13Tipo",fld:"vTIPO",pic:""}]];this.EvtParms["COMBO_MONCOD.ONOPTIONCLICKED"]=[[{av:"this.COMBO_MONCODContainer.SelectedValue_get",ctrl:"COMBO_MONCOD",prop:"SelectedValue_get"},{ctrl:"vTIPO"},{av:"AV13Tipo",fld:"vTIPO",pic:""}],[{av:"AV8MonCod",fld:"vMONCOD",pic:"ZZZZZ9"},{ctrl:"vTIPO"},{av:"AV13Tipo",fld:"vTIPO",pic:""}]];this.EvtParms["COMBO_PAICOD.ONOPTIONCLICKED"]=[[{av:"this.COMBO_PAICODContainer.SelectedValue_get",ctrl:"COMBO_PAICOD",prop:"SelectedValue_get"},{ctrl:"vTIPO"},{av:"AV13Tipo",fld:"vTIPO",pic:""}],[{av:"AV7PaiCod",fld:"vPAICOD",pic:""},{ctrl:"vTIPO"},{av:"AV13Tipo",fld:"vTIPO",pic:""}]];this.EvtParms["COMBO_TPRVCOD.ONOPTIONCLICKED"]=[[{av:"this.COMBO_TPRVCODContainer.SelectedValue_get",ctrl:"COMBO_TPRVCOD",prop:"SelectedValue_get"},{ctrl:"vTIPO"},{av:"AV13Tipo",fld:"vTIPO",pic:""}],[{av:"AV6TPrvCod",fld:"vTPRVCOD",pic:"ZZZZZ9"},{ctrl:"vTIPO"},{av:"AV13Tipo",fld:"vTIPO",pic:""}]];this.EvtParms["COMBO_TIPCOD.ONOPTIONCLICKED"]=[[{av:"this.COMBO_TIPCODContainer.SelectedValue_get",ctrl:"COMBO_TIPCOD",prop:"SelectedValue_get"},{ctrl:"vTIPO"},{av:"AV13Tipo",fld:"vTIPO",pic:""}],[{av:"AV5TipCod",fld:"vTIPCOD",pic:""},{ctrl:"vTIPO"},{av:"AV13Tipo",fld:"vTIPO",pic:""}]];this.EvtParms.ENTER=[[{ctrl:"vTIPO"},{av:"AV13Tipo",fld:"vTIPO",pic:""}],[{ctrl:"vTIPO"},{av:"AV13Tipo",fld:"vTIPO",pic:""}]];this.EvtParms.VALIDV_FDESDE=[[{ctrl:"vTIPO"},{av:"AV13Tipo",fld:"vTIPO",pic:""}],[{ctrl:"vTIPO"},{av:"AV13Tipo",fld:"vTIPO",pic:""}]];this.EvtParms.VALIDV_FHASTA=[[{ctrl:"vTIPO"},{av:"AV13Tipo",fld:"vTIPO",pic:""}],[{ctrl:"vTIPO"},{av:"AV13Tipo",fld:"vTIPO",pic:""}]];this.setVCMap("AV21DocMonCod","vDOCMONCOD",0,"int",6,0);this.Initialize();this.setSDTMapping("WWPBaseObjects\\DVB_SDTComboData.Item",{Title:{extr:"T"},Children:{extr:"C"}})});gx.wi(function(){gx.createParentObj(this.compras.r_comprasproveedores)})