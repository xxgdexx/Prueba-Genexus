gx.evt.autoSkip=!1;gx.define("ventas.r_antiguedadsaldos",!1,function(){var n,t,i,r,u,f,o,e;this.ServerClass="ventas.r_antiguedadsaldos";this.PackageName="GeneXus.Programs";this.ServerFullClass="ventas.r_antiguedadsaldos.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV22FHasta=gx.fn.getDateValue("vFHASTA");this.AV37Serie=gx.fn.getControlValue("vSERIE");this.AV46TipLetras=gx.fn.getIntegerValue("vTIPLETRAS",",")};this.e175e1_client=function(){return this.clearMessages(),this.refreshOutputs([{av:"AV53Flag2",fld:"vFLAG2",pic:"9"},{ctrl:"vFLAG"},{av:"AV23Flag",fld:"vFLAG",pic:"9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e185e1_client=function(){return this.clearMessages(),this.AV30MonCod=gx.num.trunc(gx.num.val(this.COMBO_MONCODContainer.SelectedValue_get),0),this.refreshOutputs([{av:"AV30MonCod",fld:"vMONCOD",pic:"ZZZZZ9"},{av:"AV53Flag2",fld:"vFLAG2",pic:"9"},{ctrl:"vFLAG"},{av:"AV23Flag",fld:"vFLAG",pic:"9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e195e1_client=function(){return this.clearMessages(),this.AV41TipCCod=gx.num.trunc(gx.num.val(this.COMBO_TIPCCODContainer.SelectedValue_get),0),this.refreshOutputs([{av:"AV41TipCCod",fld:"vTIPCCOD",pic:"ZZZZZ9"},{av:"AV53Flag2",fld:"vFLAG2",pic:"9"},{ctrl:"vFLAG"},{av:"AV23Flag",fld:"vFLAG",pic:"9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e205e1_client=function(){return this.clearMessages(),this.AV51ZonCod=gx.num.trunc(gx.num.val(this.COMBO_ZONCODContainer.SelectedValue_get),0),this.refreshOutputs([{av:"AV51ZonCod",fld:"vZONCOD",pic:"ZZZZZ9"},{av:"AV53Flag2",fld:"vFLAG2",pic:"9"},{ctrl:"vFLAG"},{av:"AV23Flag",fld:"vFLAG",pic:"9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e215e1_client=function(){return this.clearMessages(),this.AV43TipCod=this.COMBO_TIPCODContainer.SelectedValue_get,this.refreshOutputs([{av:"AV43TipCod",fld:"vTIPCOD",pic:""},{av:"AV53Flag2",fld:"vFLAG2",pic:"9"},{ctrl:"vFLAG"},{av:"AV23Flag",fld:"vFLAG",pic:"9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e225e1_client=function(){return this.clearMessages(),this.AV49VenCod=gx.num.trunc(gx.num.val(this.COMBO_VENCODContainer.SelectedValue_get),0),this.refreshOutputs([{av:"AV49VenCod",fld:"vVENCOD",pic:"ZZZZZ9"},{av:"AV53Flag2",fld:"vFLAG2",pic:"9"},{ctrl:"vFLAG"},{av:"AV23Flag",fld:"vFLAG",pic:"9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e165e1_client=function(){return this.clearMessages(),this.popupOpenUrl(gx.http.formatLink("generales.wwbusquedacliente.aspx",["",""]),["AV6CliCod","AV8CliDsc"]),this.refreshOutputs([{av:"AV8CliDsc",fld:"vCLIDSC",pic:""},{av:"AV6CliCod",fld:"vCLICOD",pic:""},{av:"AV53Flag2",fld:"vFLAG2",pic:"9"},{ctrl:"vFLAG"},{av:"AV23Flag",fld:"vFLAG",pic:"9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e125e2_client=function(){return this.executeServerEvent("'DOBTNIMPRIMIR'",!1,null,!1,!1)};this.e135e2_client=function(){return this.executeServerEvent("'DOBTNSALIR'",!1,null,!1,!1)};this.e145e2_client=function(){return this.executeServerEvent("'DOBTNEXCEL'",!0,null,!1,!1)};this.e235e2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e245e2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,26,27,28,29,30,31,32,34,35,36,37,38,39,40,42,43,44,45,46,47,48,50,51,52,53,54,55,56,57,60,61,63,65,66,67,68,69,70,71,72,73,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100,101,103,104,105,106,107,108,109,110];this.GXLastCtrlId=110;this.COMBO_VENCODContainer=gx.uc.getNew(this,25,0,"BootstrapDropDownOptions","COMBO_VENCODContainer","Combo_vencod","COMBO_VENCOD");t=this.COMBO_VENCODContainer;t.setProp("Class","Class","","char");t.setProp("IconType","Icontype","Image","str");t.setProp("Icon","Icon","","str");t.setProp("Caption","Caption","","str");t.setProp("Tooltip","Tooltip","","str");t.setProp("Cls","Cls","ExtendedCombo AttributeRealWidth50With","str");t.setDynProp("SelectedValue_set","Selectedvalue_set","","char");t.setProp("SelectedValue_get","Selectedvalue_get","","char");t.setProp("SelectedText_set","Selectedtext_set","","char");t.setProp("SelectedText_get","Selectedtext_get","","char");t.setProp("GAMOAuthToken","Gamoauthtoken","","char");t.setProp("DDOInternalName","Ddointernalname","","char");t.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");t.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");t.setProp("Enabled","Enabled",!0,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");t.setProp("DataListType","Datalisttype","Dynamic","str");t.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");t.setProp("DataListFixedValues","Datalistfixedvalues","","char");t.setProp("IsGridItem","Isgriditem",!1,"bool");t.setProp("HasDescription","Hasdescription",!1,"bool");t.setProp("DataListProc","Datalistproc","","str");t.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");t.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");t.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");t.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");t.setProp("EmptyItem","Emptyitem",!0,"bool");t.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");t.setProp("HTMLTemplate","Htmltemplate","","str");t.setProp("MultipleValuesType","Multiplevaluestype","Text","str");t.setProp("LoadingData","Loadingdata","","char");t.setProp("NoResultsFound","Noresultsfound","","char");t.setProp("EmptyItemText","Emptyitemtext","GX_EmptyItemText","str");t.setProp("OnlySelectedValues","Onlyselectedvalues","","char");t.setProp("SelectAllText","Selectalltext","","char");t.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");t.setProp("AddNewOptionText","Addnewoptiontext","","str");t.setProp("DropDownOptionsTitleSettingsIcons","Dropdownoptionstitlesettingsicons","","str");t.addV2CFunction("AV50VenCod_Data","vVENCOD_DATA","SetDropDownOptionsData");t.addC2VFunction(function(n){n.ParentObject.AV50VenCod_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vVENCOD_DATA",n.ParentObject.AV50VenCod_Data)});t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("OnOptionClicked",this.e225e1_client);this.setUserControl(t);this.COMBO_TIPCODContainer=gx.uc.getNew(this,33,0,"BootstrapDropDownOptions","COMBO_TIPCODContainer","Combo_tipcod","COMBO_TIPCOD");i=this.COMBO_TIPCODContainer;i.setProp("Class","Class","","char");i.setProp("IconType","Icontype","Image","str");i.setProp("Icon","Icon","","str");i.setProp("Caption","Caption","","str");i.setProp("Tooltip","Tooltip","","str");i.setProp("Cls","Cls","ExtendedCombo AttributeRealWidth50With","str");i.setDynProp("SelectedValue_set","Selectedvalue_set","","char");i.setProp("SelectedValue_get","Selectedvalue_get","","char");i.setProp("SelectedText_set","Selectedtext_set","","char");i.setProp("SelectedText_get","Selectedtext_get","","char");i.setProp("GAMOAuthToken","Gamoauthtoken","","char");i.setProp("DDOInternalName","Ddointernalname","","char");i.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");i.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");i.setProp("Enabled","Enabled",!0,"bool");i.setProp("Visible","Visible",!0,"bool");i.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");i.setProp("DataListType","Datalisttype","Dynamic","str");i.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");i.setProp("DataListFixedValues","Datalistfixedvalues","","char");i.setProp("IsGridItem","Isgriditem",!1,"bool");i.setProp("HasDescription","Hasdescription",!1,"bool");i.setProp("DataListProc","Datalistproc","","str");i.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");i.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");i.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");i.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");i.setProp("EmptyItem","Emptyitem",!0,"bool");i.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");i.setProp("HTMLTemplate","Htmltemplate","","str");i.setProp("MultipleValuesType","Multiplevaluestype","Text","str");i.setProp("LoadingData","Loadingdata","","char");i.setProp("NoResultsFound","Noresultsfound","","char");i.setProp("EmptyItemText","Emptyitemtext","GX_EmptyItemText","str");i.setProp("OnlySelectedValues","Onlyselectedvalues","","char");i.setProp("SelectAllText","Selectalltext","","char");i.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");i.setProp("AddNewOptionText","Addnewoptiontext","","str");i.setProp("DropDownOptionsTitleSettingsIcons","Dropdownoptionstitlesettingsicons","","str");i.addV2CFunction("AV44TipCod_Data","vTIPCOD_DATA","SetDropDownOptionsData");i.addC2VFunction(function(n){n.ParentObject.AV44TipCod_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vTIPCOD_DATA",n.ParentObject.AV44TipCod_Data)});i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});i.addEventHandler("OnOptionClicked",this.e215e1_client);this.setUserControl(i);this.COMBO_ZONCODContainer=gx.uc.getNew(this,41,0,"BootstrapDropDownOptions","COMBO_ZONCODContainer","Combo_zoncod","COMBO_ZONCOD");r=this.COMBO_ZONCODContainer;r.setProp("Class","Class","","char");r.setProp("IconType","Icontype","Image","str");r.setProp("Icon","Icon","","str");r.setProp("Caption","Caption","","str");r.setProp("Tooltip","Tooltip","","str");r.setProp("Cls","Cls","ExtendedCombo AttributeRealWidth50With","str");r.setDynProp("SelectedValue_set","Selectedvalue_set","","char");r.setProp("SelectedValue_get","Selectedvalue_get","","char");r.setProp("SelectedText_set","Selectedtext_set","","char");r.setProp("SelectedText_get","Selectedtext_get","","char");r.setProp("GAMOAuthToken","Gamoauthtoken","","char");r.setProp("DDOInternalName","Ddointernalname","","char");r.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");r.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");r.setProp("Enabled","Enabled",!0,"bool");r.setProp("Visible","Visible",!0,"bool");r.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");r.setProp("DataListType","Datalisttype","Dynamic","str");r.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");r.setProp("DataListFixedValues","Datalistfixedvalues","","char");r.setProp("IsGridItem","Isgriditem",!1,"bool");r.setProp("HasDescription","Hasdescription",!1,"bool");r.setProp("DataListProc","Datalistproc","","str");r.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");r.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");r.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");r.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");r.setProp("EmptyItem","Emptyitem",!0,"bool");r.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");r.setProp("HTMLTemplate","Htmltemplate","","str");r.setProp("MultipleValuesType","Multiplevaluestype","Text","str");r.setProp("LoadingData","Loadingdata","","char");r.setProp("NoResultsFound","Noresultsfound","","char");r.setProp("EmptyItemText","Emptyitemtext","GX_EmptyItemText","str");r.setProp("OnlySelectedValues","Onlyselectedvalues","","char");r.setProp("SelectAllText","Selectalltext","","char");r.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");r.setProp("AddNewOptionText","Addnewoptiontext","","str");r.setProp("DropDownOptionsTitleSettingsIcons","Dropdownoptionstitlesettingsicons","","str");r.addV2CFunction("AV52ZonCod_Data","vZONCOD_DATA","SetDropDownOptionsData");r.addC2VFunction(function(n){n.ParentObject.AV52ZonCod_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vZONCOD_DATA",n.ParentObject.AV52ZonCod_Data)});r.setProp("Gx Control Type","Gxcontroltype","","int");r.setC2ShowFunction(function(n){n.show()});r.addEventHandler("OnOptionClicked",this.e205e1_client);this.setUserControl(r);this.COMBO_TIPCCODContainer=gx.uc.getNew(this,49,0,"BootstrapDropDownOptions","COMBO_TIPCCODContainer","Combo_tipccod","COMBO_TIPCCOD");u=this.COMBO_TIPCCODContainer;u.setProp("Class","Class","","char");u.setProp("IconType","Icontype","Image","str");u.setProp("Icon","Icon","","str");u.setProp("Caption","Caption","","str");u.setProp("Tooltip","Tooltip","","str");u.setProp("Cls","Cls","ExtendedCombo AttributeRealWidth50With","str");u.setDynProp("SelectedValue_set","Selectedvalue_set","","char");u.setProp("SelectedValue_get","Selectedvalue_get","","char");u.setProp("SelectedText_set","Selectedtext_set","","char");u.setProp("SelectedText_get","Selectedtext_get","","char");u.setProp("GAMOAuthToken","Gamoauthtoken","","char");u.setProp("DDOInternalName","Ddointernalname","","char");u.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");u.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");u.setProp("Enabled","Enabled",!0,"bool");u.setProp("Visible","Visible",!0,"bool");u.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");u.setProp("DataListType","Datalisttype","Dynamic","str");u.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");u.setProp("DataListFixedValues","Datalistfixedvalues","","char");u.setProp("IsGridItem","Isgriditem",!1,"bool");u.setProp("HasDescription","Hasdescription",!1,"bool");u.setProp("DataListProc","Datalistproc","","str");u.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");u.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");u.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");u.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");u.setProp("EmptyItem","Emptyitem",!0,"bool");u.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");u.setProp("HTMLTemplate","Htmltemplate","","str");u.setProp("MultipleValuesType","Multiplevaluestype","Text","str");u.setProp("LoadingData","Loadingdata","","char");u.setProp("NoResultsFound","Noresultsfound","","char");u.setProp("EmptyItemText","Emptyitemtext","GX_EmptyItemText","str");u.setProp("OnlySelectedValues","Onlyselectedvalues","","char");u.setProp("SelectAllText","Selectalltext","","char");u.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");u.setProp("AddNewOptionText","Addnewoptiontext","","str");u.setProp("DropDownOptionsTitleSettingsIcons","Dropdownoptionstitlesettingsicons","","str");u.addV2CFunction("AV42TipCCod_Data","vTIPCCOD_DATA","SetDropDownOptionsData");u.addC2VFunction(function(n){n.ParentObject.AV42TipCCod_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vTIPCCOD_DATA",n.ParentObject.AV42TipCCod_Data)});u.setProp("Gx Control Type","Gxcontroltype","","int");u.setC2ShowFunction(function(n){n.show()});u.addEventHandler("OnOptionClicked",this.e195e1_client);this.setUserControl(u);this.COMBO_MONCODContainer=gx.uc.getNew(this,74,61,"BootstrapDropDownOptions","COMBO_MONCODContainer","Combo_moncod","COMBO_MONCOD");f=this.COMBO_MONCODContainer;f.setProp("Class","Class","","char");f.setProp("IconType","Icontype","Image","str");f.setProp("Icon","Icon","","str");f.setProp("Caption","Caption","","str");f.setProp("Tooltip","Tooltip","","str");f.setProp("Cls","Cls","ExtendedCombo AttributeRealWidth50With","str");f.setDynProp("SelectedValue_set","Selectedvalue_set","","char");f.setProp("SelectedValue_get","Selectedvalue_get","","char");f.setProp("SelectedText_set","Selectedtext_set","","char");f.setProp("SelectedText_get","Selectedtext_get","","char");f.setProp("GAMOAuthToken","Gamoauthtoken","","char");f.setProp("DDOInternalName","Ddointernalname","","char");f.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");f.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");f.setProp("Enabled","Enabled",!0,"bool");f.setProp("Visible","Visible",!0,"bool");f.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");f.setProp("DataListType","Datalisttype","Dynamic","str");f.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");f.setProp("DataListFixedValues","Datalistfixedvalues","","char");f.setProp("IsGridItem","Isgriditem",!1,"bool");f.setProp("HasDescription","Hasdescription",!1,"bool");f.setProp("DataListProc","Datalistproc","","str");f.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");f.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");f.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");f.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");f.setProp("EmptyItem","Emptyitem",!0,"bool");f.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");f.setProp("HTMLTemplate","Htmltemplate","","str");f.setProp("MultipleValuesType","Multiplevaluestype","Text","str");f.setProp("LoadingData","Loadingdata","","char");f.setProp("NoResultsFound","Noresultsfound","","char");f.setProp("EmptyItemText","Emptyitemtext","GX_EmptyItemText","str");f.setProp("OnlySelectedValues","Onlyselectedvalues","","char");f.setProp("SelectAllText","Selectalltext","","char");f.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");f.setProp("AddNewOptionText","Addnewoptiontext","","str");f.setProp("DropDownOptionsTitleSettingsIcons","Dropdownoptionstitlesettingsicons","","str");f.addV2CFunction("AV31MonCod_Data","vMONCOD_DATA","SetDropDownOptionsData");f.addC2VFunction(function(n){n.ParentObject.AV31MonCod_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vMONCOD_DATA",n.ParentObject.AV31MonCod_Data)});f.setProp("Gx Control Type","Gxcontroltype","","int");f.setC2ShowFunction(function(n){n.show()});f.addEventHandler("OnOptionClicked",this.e185e1_client);this.setUserControl(f);this.DVPANEL_PANEL1Container=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_PANEL1Container","Dvpanel_panel1","DVPANEL_PANEL1");o=this.DVPANEL_PANEL1Container;o.setProp("Class","Class","","char");o.setProp("Enabled","Enabled",!0,"boolean");o.setProp("Width","Width","100%","str");o.setProp("Height","Height","100","str");o.setProp("AutoWidth","Autowidth",!1,"bool");o.setProp("AutoHeight","Autoheight",!0,"bool");o.setProp("Cls","Cls","PanelFilled Panel_BaseColor","str");o.setProp("ShowHeader","Showheader",!0,"bool");o.setProp("Title","Title","Reporte de Antiguedad de Saldos","str");o.setProp("Collapsible","Collapsible",!0,"bool");o.setProp("Collapsed","Collapsed",!1,"bool");o.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");o.setProp("IconPosition","Iconposition","Right","str");o.setProp("AutoScroll","Autoscroll",!1,"bool");o.setProp("Visible","Visible",!0,"bool");o.setProp("Gx Control Type","Gxcontroltype","","int");o.setC2ShowFunction(function(n){n.show()});this.setUserControl(o);this.INNEWWINDOWContainer=gx.uc.getNew(this,102,61,"InNewWindow","INNEWWINDOWContainer","Innewwindow","INNEWWINDOW");e=this.INNEWWINDOWContainer;e.setProp("Class","Class","","char");e.setProp("Enabled","Enabled",!0,"boolean");e.setProp("Width","Width","50","str");e.setProp("Height","Height","50","str");e.setProp("Name","Name","","str");e.setDynProp("Target","Target","","str");e.setProp("Fullscreen","Fullscreen",!1,"bool");e.setProp("Location","Location",!0,"bool");e.setProp("MenuBar","Menubar",!0,"bool");e.setProp("Resizable","Resizable",!0,"bool");e.setProp("Scrollbars","Scrollbars",!0,"bool");e.setProp("TitleBar","Titlebar",!0,"bool");e.setProp("ToolBar","Toolbar",!0,"bool");e.setProp("directories","Directories",!0,"bool");e.setProp("status","Status",!0,"bool");e.setProp("copyhistory","Copyhistory",!0,"bool");e.setProp("top","Top","5","str");e.setProp("left","Left","5","str");e.setProp("fitscreen","Fitscreen",!1,"bool");e.setProp("RefreshParentOnClose","Refreshparentonclose",!1,"bool");e.setProp("Targets","Targets","","str");e.setProp("Visible","Visible",!0,"bool");e.setC2ShowFunction(function(n){n.show()});this.setUserControl(e);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"PANEL1",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"TABLESPLITTEDVENCOD",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"TEXTBLOCKCOMBO_VENCOD",format:0,grid:0,ctrltype:"textblock"};n[24]={id:24,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"TABLESPLITTEDTIPCOD",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"TEXTBLOCKCOMBO_TIPCOD",format:0,grid:0,ctrltype:"textblock"};n[32]={id:32,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"TABLESPLITTEDZONCOD",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"TEXTBLOCKCOMBO_ZONCOD",format:0,grid:0,ctrltype:"textblock"};n[40]={id:40,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"TABLESPLITTEDTIPCCOD",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"TEXTBLOCKCOMBO_TIPCCOD",format:0,grid:0,ctrltype:"textblock"};n[48]={id:48,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"TABLESPLITTEDCLICOD",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"TEXTBLOCKCLICOD",format:0,grid:0,ctrltype:"textblock"};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"TABLEMERGEDCLICOD",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCLICOD",gxz:"ZV6CliCod",gxold:"OV6CliCod",gxvar:"AV6CliCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6CliCod=n)},v2z:function(n){n!==undefined&&(gx.O.ZV6CliCod=n)},v2c:function(){gx.fn.setControlValue("vCLICOD",gx.O.AV6CliCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6CliCod=this.val())},val:function(){return gx.fn.getControlValue("vCLICOD")},nac:gx.falseFn};n[63]={id:63,fld:"BTNBUSCAR",grid:0,evt:"e165e1_client"};n[65]={id:65,fld:"",grid:0};n[66]={id:66,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCLIDSC",gxz:"ZV8CliDsc",gxold:"OV8CliDsc",gxvar:"AV8CliDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8CliDsc=n)},v2z:function(n){n!==undefined&&(gx.O.ZV8CliDsc=n)},v2c:function(){gx.fn.setControlValue("vCLIDSC",gx.O.AV8CliDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8CliDsc=this.val())},val:function(){return gx.fn.getControlValue("vCLIDSC")},nac:gx.falseFn};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,fld:"TABLESPLITTEDMONCOD",grid:0};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"TEXTBLOCKCOMBO_MONCOD",format:0,grid:0,ctrltype:"textblock"};n[73]={id:73,fld:"",grid:0};n[75]={id:75,fld:"",grid:0};n[76]={id:76,fld:"",grid:0};n[77]={id:77,fld:"UNNAMEDTABLEFLAG2",grid:0};n[78]={id:78,fld:"",grid:0};n[79]={id:79,fld:"",grid:0};n[80]={id:80,fld:"TEXTBLOCKFLAG2",format:0,grid:0,ctrltype:"textblock"};n[81]={id:81,fld:"",grid:0};n[82]={id:82,fld:"",grid:0};n[83]={id:83,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFLAG2",gxz:"ZV53Flag2",gxold:"OV53Flag2",gxvar:"AV53Flag2",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.AV53Flag2=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV53Flag2=gx.num.intval(n))},v2c:function(){gx.fn.setCheckBoxValue("vFLAG2",gx.O.AV53Flag2,"1")},c2v:function(){this.val()!==undefined&&(gx.O.AV53Flag2=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vFLAG2",",")},nac:gx.falseFn,values:[1,0]};n[84]={id:84,fld:"",grid:0};n[85]={id:85,fld:"",grid:0};n[86]={id:86,fld:"UNNAMEDTABLEFLAG",grid:0};n[87]={id:87,fld:"",grid:0};n[88]={id:88,fld:"",grid:0};n[89]={id:89,fld:"TEXTBLOCKFLAG",format:0,grid:0,ctrltype:"textblock"};n[90]={id:90,fld:"",grid:0};n[91]={id:91,fld:"",grid:0};n[92]={id:92,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFLAG",gxz:"ZV23Flag",gxold:"OV23Flag",gxvar:"AV23Flag",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"radio",v2v:function(n){n!==undefined&&(gx.O.AV23Flag=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV23Flag=gx.num.intval(n))},v2c:function(){gx.fn.setRadioValue("vFLAG",gx.O.AV23Flag)},c2v:function(){this.val()!==undefined&&(gx.O.AV23Flag=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vFLAG",",")},nac:gx.falseFn};n[93]={id:93,fld:"",grid:0};n[94]={id:94,fld:"",grid:0};n[95]={id:95,fld:"",grid:0};n[96]={id:96,fld:"",grid:0};n[97]={id:97,fld:"BTNBTNIMPRIMIR",grid:0,evt:"e125e2_client"};n[98]={id:98,fld:"",grid:0};n[99]={id:99,fld:"BTNBTNSALIR",grid:0,evt:"e135e2_client"};n[100]={id:100,fld:"",grid:0};n[101]={id:101,fld:"",grid:0};n[103]={id:103,fld:"",grid:0};n[104]={id:104,fld:"",grid:0};n[105]={id:105,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[106]={id:106,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vVENCOD",gxz:"ZV49VenCod",gxold:"OV49VenCod",gxvar:"AV49VenCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV49VenCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV49VenCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vVENCOD",gx.O.AV49VenCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV49VenCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vVENCOD",",")},nac:gx.falseFn};n[107]={id:107,lvl:0,type:"char",len:3,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTIPCOD",gxz:"ZV43TipCod",gxold:"OV43TipCod",gxvar:"AV43TipCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV43TipCod=n)},v2z:function(n){n!==undefined&&(gx.O.ZV43TipCod=n)},v2c:function(){gx.fn.setControlValue("vTIPCOD",gx.O.AV43TipCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV43TipCod=this.val())},val:function(){return gx.fn.getControlValue("vTIPCOD")},nac:gx.falseFn};n[108]={id:108,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vZONCOD",gxz:"ZV51ZonCod",gxold:"OV51ZonCod",gxvar:"AV51ZonCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV51ZonCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV51ZonCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vZONCOD",gx.O.AV51ZonCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV51ZonCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vZONCOD",",")},nac:gx.falseFn};n[109]={id:109,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTIPCCOD",gxz:"ZV41TipCCod",gxold:"OV41TipCCod",gxvar:"AV41TipCCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV41TipCCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV41TipCCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vTIPCCOD",gx.O.AV41TipCCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV41TipCCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vTIPCCOD",",")},nac:gx.falseFn};n[110]={id:110,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vMONCOD",gxz:"ZV30MonCod",gxold:"OV30MonCod",gxvar:"AV30MonCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV30MonCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV30MonCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vMONCOD",gx.O.AV30MonCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV30MonCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vMONCOD",",")},nac:gx.falseFn};this.AV6CliCod="";this.ZV6CliCod="";this.OV6CliCod="";this.AV8CliDsc="";this.ZV8CliDsc="";this.OV8CliDsc="";this.AV53Flag2=0;this.ZV53Flag2=0;this.OV53Flag2=0;this.AV23Flag=0;this.ZV23Flag=0;this.OV23Flag=0;this.AV49VenCod=0;this.ZV49VenCod=0;this.OV49VenCod=0;this.AV43TipCod="";this.ZV43TipCod="";this.OV43TipCod="";this.AV51ZonCod=0;this.ZV51ZonCod=0;this.OV51ZonCod=0;this.AV41TipCCod=0;this.ZV41TipCCod=0;this.OV41TipCCod=0;this.AV30MonCod=0;this.ZV30MonCod=0;this.OV30MonCod=0;this.AV50VenCod_Data=[];this.AV44TipCod_Data=[];this.AV52ZonCod_Data=[];this.AV42TipCCod_Data=[];this.AV6CliCod="";this.AV8CliDsc="";this.AV31MonCod_Data=[];this.AV53Flag2=0;this.AV23Flag=0;this.AV49VenCod=0;this.AV43TipCod="";this.AV51ZonCod=0;this.AV41TipCCod=0;this.AV30MonCod=0;this.A2047VenSts=0;this.A309VenCod=0;this.A2045VenDsc="";this.A1919TipSts=0;this.A149TipCod="";this.A1910TipDsc="";this.A2095ZonSts=0;this.A158ZonCod=0;this.A2094ZonDsc="";this.A1908TipCSts=0;this.A159TipCCod=0;this.A1905TipCDsc="";this.A1235MonSts=0;this.A180MonCod=0;this.A1234MonDsc="";this.AV22FHasta=gx.date.nullDate();this.AV37Serie="";this.AV46TipLetras=0;this.Events={e125e2_client:["'DOBTNIMPRIMIR'",!0],e135e2_client:["'DOBTNSALIR'",!0],e145e2_client:["'DOBTNEXCEL'",!0],e235e2_client:["ENTER",!0],e245e2_client:["CANCEL",!0],e175e1_client:["'DOBTNBUSCAR'",!1],e185e1_client:["COMBO_MONCOD.ONOPTIONCLICKED",!1],e195e1_client:["COMBO_TIPCCOD.ONOPTIONCLICKED",!1],e205e1_client:["COMBO_ZONCOD.ONOPTIONCLICKED",!1],e215e1_client:["COMBO_TIPCOD.ONOPTIONCLICKED",!1],e225e1_client:["COMBO_VENCOD.ONOPTIONCLICKED",!1],e165e1_client:["BTNBUSCAR.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"AV53Flag2",fld:"vFLAG2",pic:"9"},{ctrl:"vFLAG"},{av:"AV23Flag",fld:"vFLAG",pic:"9"}],[{av:"AV53Flag2",fld:"vFLAG2",pic:"9"},{ctrl:"vFLAG"},{av:"AV23Flag",fld:"vFLAG",pic:"9"}]];this.EvtParms["'DOBTNIMPRIMIR'"]=[[{av:"AV49VenCod",fld:"vVENCOD",pic:"ZZZZZ9"},{av:"AV43TipCod",fld:"vTIPCOD",pic:""},{av:"AV51ZonCod",fld:"vZONCOD",pic:"ZZZZZ9"},{av:"AV41TipCCod",fld:"vTIPCCOD",pic:"ZZZZZ9"},{av:"AV6CliCod",fld:"vCLICOD",pic:""},{av:"AV30MonCod",fld:"vMONCOD",pic:"ZZZZZ9"},{av:"AV53Flag2",fld:"vFLAG2",pic:"9"},{ctrl:"vFLAG"},{av:"AV23Flag",fld:"vFLAG",pic:"9"}],[{av:"this.INNEWWINDOWContainer.Target",ctrl:"INNEWWINDOW",prop:"Target"},{av:"AV53Flag2",fld:"vFLAG2",pic:"9"},{ctrl:"vFLAG"},{av:"AV23Flag",fld:"vFLAG",pic:"9"}]];this.EvtParms["'DOBTNSALIR'"]=[[{av:"AV53Flag2",fld:"vFLAG2",pic:"9"},{ctrl:"vFLAG"},{av:"AV23Flag",fld:"vFLAG",pic:"9"}],[{av:"AV53Flag2",fld:"vFLAG2",pic:"9"},{ctrl:"vFLAG"},{av:"AV23Flag",fld:"vFLAG",pic:"9"}]];this.EvtParms["'DOBTNBUSCAR'"]=[[{av:"AV53Flag2",fld:"vFLAG2",pic:"9"},{ctrl:"vFLAG"},{av:"AV23Flag",fld:"vFLAG",pic:"9"}],[{av:"AV53Flag2",fld:"vFLAG2",pic:"9"},{ctrl:"vFLAG"},{av:"AV23Flag",fld:"vFLAG",pic:"9"}]];this.EvtParms["COMBO_MONCOD.ONOPTIONCLICKED"]=[[{av:"this.COMBO_MONCODContainer.SelectedValue_get",ctrl:"COMBO_MONCOD",prop:"SelectedValue_get"},{av:"AV53Flag2",fld:"vFLAG2",pic:"9"},{ctrl:"vFLAG"},{av:"AV23Flag",fld:"vFLAG",pic:"9"}],[{av:"AV30MonCod",fld:"vMONCOD",pic:"ZZZZZ9"},{av:"AV53Flag2",fld:"vFLAG2",pic:"9"},{ctrl:"vFLAG"},{av:"AV23Flag",fld:"vFLAG",pic:"9"}]];this.EvtParms["COMBO_TIPCCOD.ONOPTIONCLICKED"]=[[{av:"this.COMBO_TIPCCODContainer.SelectedValue_get",ctrl:"COMBO_TIPCCOD",prop:"SelectedValue_get"},{av:"AV53Flag2",fld:"vFLAG2",pic:"9"},{ctrl:"vFLAG"},{av:"AV23Flag",fld:"vFLAG",pic:"9"}],[{av:"AV41TipCCod",fld:"vTIPCCOD",pic:"ZZZZZ9"},{av:"AV53Flag2",fld:"vFLAG2",pic:"9"},{ctrl:"vFLAG"},{av:"AV23Flag",fld:"vFLAG",pic:"9"}]];this.EvtParms["COMBO_ZONCOD.ONOPTIONCLICKED"]=[[{av:"this.COMBO_ZONCODContainer.SelectedValue_get",ctrl:"COMBO_ZONCOD",prop:"SelectedValue_get"},{av:"AV53Flag2",fld:"vFLAG2",pic:"9"},{ctrl:"vFLAG"},{av:"AV23Flag",fld:"vFLAG",pic:"9"}],[{av:"AV51ZonCod",fld:"vZONCOD",pic:"ZZZZZ9"},{av:"AV53Flag2",fld:"vFLAG2",pic:"9"},{ctrl:"vFLAG"},{av:"AV23Flag",fld:"vFLAG",pic:"9"}]];this.EvtParms["COMBO_TIPCOD.ONOPTIONCLICKED"]=[[{av:"this.COMBO_TIPCODContainer.SelectedValue_get",ctrl:"COMBO_TIPCOD",prop:"SelectedValue_get"},{av:"AV53Flag2",fld:"vFLAG2",pic:"9"},{ctrl:"vFLAG"},{av:"AV23Flag",fld:"vFLAG",pic:"9"}],[{av:"AV43TipCod",fld:"vTIPCOD",pic:""},{av:"AV53Flag2",fld:"vFLAG2",pic:"9"},{ctrl:"vFLAG"},{av:"AV23Flag",fld:"vFLAG",pic:"9"}]];this.EvtParms["COMBO_VENCOD.ONOPTIONCLICKED"]=[[{av:"this.COMBO_VENCODContainer.SelectedValue_get",ctrl:"COMBO_VENCOD",prop:"SelectedValue_get"},{av:"AV53Flag2",fld:"vFLAG2",pic:"9"},{ctrl:"vFLAG"},{av:"AV23Flag",fld:"vFLAG",pic:"9"}],[{av:"AV49VenCod",fld:"vVENCOD",pic:"ZZZZZ9"},{av:"AV53Flag2",fld:"vFLAG2",pic:"9"},{ctrl:"vFLAG"},{av:"AV23Flag",fld:"vFLAG",pic:"9"}]];this.EvtParms["'DOBTNEXCEL'"]=[[{av:"AV41TipCCod",fld:"vTIPCCOD",pic:"ZZZZZ9"},{av:"AV6CliCod",fld:"vCLICOD",pic:""},{av:"AV43TipCod",fld:"vTIPCOD",pic:""},{av:"AV30MonCod",fld:"vMONCOD",pic:"ZZZZZ9"},{av:"AV22FHasta",fld:"vFHASTA",pic:""},{av:"AV51ZonCod",fld:"vZONCOD",pic:"ZZZZZ9"},{av:"AV37Serie",fld:"vSERIE",pic:""},{av:"AV46TipLetras",fld:"vTIPLETRAS",pic:"9"},{av:"AV49VenCod",fld:"vVENCOD",pic:"ZZZZZ9"},{av:"AV53Flag2",fld:"vFLAG2",pic:"9"},{ctrl:"vFLAG"},{av:"AV23Flag",fld:"vFLAG",pic:"9"}],[{av:"AV49VenCod",fld:"vVENCOD",pic:"ZZZZZ9"},{av:"AV46TipLetras",fld:"vTIPLETRAS",pic:"9"},{av:"AV37Serie",fld:"vSERIE",pic:""},{av:"AV51ZonCod",fld:"vZONCOD",pic:"ZZZZZ9"},{av:"AV22FHasta",fld:"vFHASTA",pic:""},{av:"AV30MonCod",fld:"vMONCOD",pic:"ZZZZZ9"},{av:"AV43TipCod",fld:"vTIPCOD",pic:""},{av:"AV6CliCod",fld:"vCLICOD",pic:""},{av:"AV41TipCCod",fld:"vTIPCCOD",pic:"ZZZZZ9"},{av:"AV53Flag2",fld:"vFLAG2",pic:"9"},{ctrl:"vFLAG"},{av:"AV23Flag",fld:"vFLAG",pic:"9"}]];this.EvtParms["BTNBUSCAR.CLICK"]=[[{av:"AV53Flag2",fld:"vFLAG2",pic:"9"},{ctrl:"vFLAG"},{av:"AV23Flag",fld:"vFLAG",pic:"9"}],[{av:"AV8CliDsc",fld:"vCLIDSC",pic:""},{av:"AV6CliCod",fld:"vCLICOD",pic:""},{av:"AV53Flag2",fld:"vFLAG2",pic:"9"},{ctrl:"vFLAG"},{av:"AV23Flag",fld:"vFLAG",pic:"9"}]];this.EvtParms.ENTER=[[{av:"AV53Flag2",fld:"vFLAG2",pic:"9"},{ctrl:"vFLAG"},{av:"AV23Flag",fld:"vFLAG",pic:"9"}],[{av:"AV53Flag2",fld:"vFLAG2",pic:"9"},{ctrl:"vFLAG"},{av:"AV23Flag",fld:"vFLAG",pic:"9"}]];this.setVCMap("AV22FHasta","vFHASTA",0,"date",8,0);this.setVCMap("AV37Serie","vSERIE",0,"char",4,0);this.setVCMap("AV46TipLetras","vTIPLETRAS",0,"int",1,0);this.Initialize();this.setSDTMapping("WWPBaseObjects\\DVB_SDTDropDownOptionsTitleSettingsIcons",{Default_fi:{extr:"def"},Filtered_fi:{extr:"fil"},SortedASC_fi:{extr:"asc"},SortedDSC_fi:{extr:"dsc"},FilteredSortedASC_fi:{extr:"fasc"},FilteredSortedDSC_fi:{extr:"fdsc"},OptionSortASC_fi:{extr:"osasc"},OptionSortDSC_fi:{extr:"osdsc"},OptionApplyFilter_fi:{extr:"app"},OptionFilteringData_fi:{extr:"fildata"},OptionCleanFilters_fi:{extr:"cle"},SelectedOption_fi:{extr:"selo"},MultiselOption_fi:{extr:"mul"},MultiselSelOption_fi:{extr:"muls"},TreeviewCollapse_fi:{extr:"tcol"},TreeviewExpand_fi:{extr:"texp"},FixLeft_fi:{extr:"fixl"},FixRight_fi:{extr:"fixr"}});this.setSDTMapping("WWPBaseObjects\\DVB_SDTComboData.Item",{Title:{extr:"T"},Children:{extr:"C"}})});gx.wi(function(){gx.createParentObj(this.ventas.r_antiguedadsaldos)})