gx.evt.autoSkip=!1;gx.define("almacen.r_stockactual",!1,function(){var n,t,i,r,u,e,f;this.ServerClass="almacen.r_stockactual";this.PackageName="GeneXus.Programs";this.ServerFullClass="almacen.r_stockactual.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Validv_Fdesde=function(){return this.validCliEvt("Validv_Fdesde",0,function(){try{var n=gx.util.balloon.getNew("vFDESDE");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV23FDesde)===0||new gx.date.gxdate(this.AV23FDesde).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo FDesde fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e172r1_client=function(){return this.clearMessages(),this.AV8FamCod=gx.num.trunc(gx.num.val(this.COMBO_FAMCODContainer.SelectedValue_get),0),this.refreshOutputs([{av:"AV8FamCod",fld:"vFAMCOD",pic:"ZZZZZ9"},{ctrl:"vTIPOORDEN"},{av:"AV12TipoOrden",fld:"vTIPOORDEN",pic:"9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e182r1_client=function(){return this.clearMessages(),this.AV7SubLCod=gx.num.trunc(gx.num.val(this.COMBO_SUBLCODContainer.SelectedValue_get),0),this.refreshOutputs([{av:"AV7SubLCod",fld:"vSUBLCOD",pic:"ZZZZZ9"},{ctrl:"vTIPOORDEN"},{av:"AV12TipoOrden",fld:"vTIPOORDEN",pic:"9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e192r1_client=function(){return this.clearMessages(),this.AV6LinCod=gx.num.trunc(gx.num.val(this.COMBO_LINCODContainer.SelectedValue_get),0),this.refreshOutputs([{av:"AV6LinCod",fld:"vLINCOD",pic:"ZZZZZ9"},{ctrl:"vTIPOORDEN"},{av:"AV12TipoOrden",fld:"vTIPOORDEN",pic:"9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e202r1_client=function(){return this.clearMessages(),this.AV5AlmCod=gx.num.trunc(gx.num.val(this.COMBO_ALMCODContainer.SelectedValue_get),0),this.refreshOutputs([{av:"AV5AlmCod",fld:"vALMCOD",pic:"ZZZZZ9"},{ctrl:"vTIPOORDEN"},{av:"AV12TipoOrden",fld:"vTIPOORDEN",pic:"9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e122r2_client=function(){return this.executeServerEvent("'DOBTNIMPRIMIR'",!1,null,!1,!1)};this.e132r2_client=function(){return this.executeServerEvent("'DOBTNEXCEL'",!1,null,!1,!1)};this.e142r2_client=function(){return this.executeServerEvent("'DOBTNSALIR'",!1,null,!1,!1)};this.e152r2_client=function(){return this.executeServerEvent("'DOBTNBUSCAR'",!0,null,!1,!1)};this.e212r2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e222r2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,26,27,28,29,30,31,32,34,35,36,37,38,39,40,42,43,44,45,46,47,48,50,51,52,53,54,55,56,57,60,61,63,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,97,98,99,100,101,102,103];this.GXLastCtrlId=103;this.COMBO_ALMCODContainer=gx.uc.getNew(this,25,0,"BootstrapDropDownOptions","COMBO_ALMCODContainer","Combo_almcod","COMBO_ALMCOD");t=this.COMBO_ALMCODContainer;t.setProp("Class","Class","","char");t.setProp("IconType","Icontype","Image","str");t.setProp("Icon","Icon","","str");t.setProp("Caption","Caption","","str");t.setProp("Tooltip","Tooltip","","str");t.setProp("Cls","Cls","ExtendedCombo AttributeRealWidth50With","str");t.setDynProp("SelectedValue_set","Selectedvalue_set","","char");t.setProp("SelectedValue_get","Selectedvalue_get","","char");t.setProp("SelectedText_set","Selectedtext_set","","char");t.setProp("SelectedText_get","Selectedtext_get","","char");t.setProp("GAMOAuthToken","Gamoauthtoken","","char");t.setProp("DDOInternalName","Ddointernalname","","char");t.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");t.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");t.setProp("Enabled","Enabled",!0,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");t.setProp("DataListType","Datalisttype","Dynamic","str");t.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");t.setProp("DataListFixedValues","Datalistfixedvalues","","char");t.setProp("IsGridItem","Isgriditem",!1,"bool");t.setProp("HasDescription","Hasdescription",!1,"bool");t.setProp("DataListProc","Datalistproc","","str");t.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");t.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");t.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");t.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");t.setProp("EmptyItem","Emptyitem",!0,"bool");t.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");t.setProp("HTMLTemplate","Htmltemplate","","str");t.setProp("MultipleValuesType","Multiplevaluestype","Text","str");t.setProp("LoadingData","Loadingdata","","char");t.setProp("NoResultsFound","Noresultsfound","","char");t.setProp("EmptyItemText","Emptyitemtext","GX_EmptyItemText","str");t.setProp("OnlySelectedValues","Onlyselectedvalues","","char");t.setProp("SelectAllText","Selectalltext","","char");t.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");t.setProp("AddNewOptionText","Addnewoptiontext","","str");t.setProp("DropDownOptionsTitleSettingsIcons","Dropdownoptionstitlesettingsicons","","str");t.addV2CFunction("AV14AlmCod_Data","vALMCOD_DATA","SetDropDownOptionsData");t.addC2VFunction(function(n){n.ParentObject.AV14AlmCod_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vALMCOD_DATA",n.ParentObject.AV14AlmCod_Data)});t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("OnOptionClicked",this.e202r1_client);this.setUserControl(t);this.COMBO_LINCODContainer=gx.uc.getNew(this,33,0,"BootstrapDropDownOptions","COMBO_LINCODContainer","Combo_lincod","COMBO_LINCOD");i=this.COMBO_LINCODContainer;i.setProp("Class","Class","","char");i.setProp("IconType","Icontype","Image","str");i.setProp("Icon","Icon","","str");i.setProp("Caption","Caption","","str");i.setProp("Tooltip","Tooltip","","str");i.setProp("Cls","Cls","ExtendedCombo AttributeRealWidth50With","str");i.setDynProp("SelectedValue_set","Selectedvalue_set","","char");i.setProp("SelectedValue_get","Selectedvalue_get","","char");i.setProp("SelectedText_set","Selectedtext_set","","char");i.setProp("SelectedText_get","Selectedtext_get","","char");i.setProp("GAMOAuthToken","Gamoauthtoken","","char");i.setProp("DDOInternalName","Ddointernalname","","char");i.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");i.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");i.setProp("Enabled","Enabled",!0,"bool");i.setProp("Visible","Visible",!0,"bool");i.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");i.setProp("DataListType","Datalisttype","Dynamic","str");i.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");i.setProp("DataListFixedValues","Datalistfixedvalues","","char");i.setProp("IsGridItem","Isgriditem",!1,"bool");i.setProp("HasDescription","Hasdescription",!1,"bool");i.setProp("DataListProc","Datalistproc","","str");i.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");i.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");i.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");i.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");i.setProp("EmptyItem","Emptyitem",!0,"bool");i.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");i.setProp("HTMLTemplate","Htmltemplate","","str");i.setProp("MultipleValuesType","Multiplevaluestype","Text","str");i.setProp("LoadingData","Loadingdata","","char");i.setProp("NoResultsFound","Noresultsfound","","char");i.setProp("EmptyItemText","Emptyitemtext","GX_EmptyItemText","str");i.setProp("OnlySelectedValues","Onlyselectedvalues","","char");i.setProp("SelectAllText","Selectalltext","","char");i.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");i.setProp("AddNewOptionText","Addnewoptiontext","","str");i.setProp("DropDownOptionsTitleSettingsIcons","Dropdownoptionstitlesettingsicons","","str");i.addV2CFunction("AV16LinCod_Data","vLINCOD_DATA","SetDropDownOptionsData");i.addC2VFunction(function(n){n.ParentObject.AV16LinCod_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vLINCOD_DATA",n.ParentObject.AV16LinCod_Data)});i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});i.addEventHandler("OnOptionClicked",this.e192r1_client);this.setUserControl(i);this.COMBO_SUBLCODContainer=gx.uc.getNew(this,41,0,"BootstrapDropDownOptions","COMBO_SUBLCODContainer","Combo_sublcod","COMBO_SUBLCOD");r=this.COMBO_SUBLCODContainer;r.setProp("Class","Class","","char");r.setProp("IconType","Icontype","Image","str");r.setProp("Icon","Icon","","str");r.setProp("Caption","Caption","","str");r.setProp("Tooltip","Tooltip","","str");r.setProp("Cls","Cls","ExtendedCombo AttributeRealWidth50With","str");r.setDynProp("SelectedValue_set","Selectedvalue_set","","char");r.setProp("SelectedValue_get","Selectedvalue_get","","char");r.setProp("SelectedText_set","Selectedtext_set","","char");r.setProp("SelectedText_get","Selectedtext_get","","char");r.setProp("GAMOAuthToken","Gamoauthtoken","","char");r.setProp("DDOInternalName","Ddointernalname","","char");r.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");r.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");r.setProp("Enabled","Enabled",!0,"bool");r.setProp("Visible","Visible",!0,"bool");r.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");r.setProp("DataListType","Datalisttype","Dynamic","str");r.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");r.setProp("DataListFixedValues","Datalistfixedvalues","","char");r.setProp("IsGridItem","Isgriditem",!1,"bool");r.setProp("HasDescription","Hasdescription",!1,"bool");r.setProp("DataListProc","Datalistproc","","str");r.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");r.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");r.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");r.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");r.setProp("EmptyItem","Emptyitem",!0,"bool");r.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");r.setProp("HTMLTemplate","Htmltemplate","","str");r.setProp("MultipleValuesType","Multiplevaluestype","Text","str");r.setProp("LoadingData","Loadingdata","","char");r.setProp("NoResultsFound","Noresultsfound","","char");r.setProp("EmptyItemText","Emptyitemtext","GX_EmptyItemText","str");r.setProp("OnlySelectedValues","Onlyselectedvalues","","char");r.setProp("SelectAllText","Selectalltext","","char");r.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");r.setProp("AddNewOptionText","Addnewoptiontext","","str");r.setProp("DropDownOptionsTitleSettingsIcons","Dropdownoptionstitlesettingsicons","","str");r.addV2CFunction("AV17SubLCod_Data","vSUBLCOD_DATA","SetDropDownOptionsData");r.addC2VFunction(function(n){n.ParentObject.AV17SubLCod_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vSUBLCOD_DATA",n.ParentObject.AV17SubLCod_Data)});r.setProp("Gx Control Type","Gxcontroltype","","int");r.setC2ShowFunction(function(n){n.show()});r.addEventHandler("OnOptionClicked",this.e182r1_client);this.setUserControl(r);this.COMBO_FAMCODContainer=gx.uc.getNew(this,49,0,"BootstrapDropDownOptions","COMBO_FAMCODContainer","Combo_famcod","COMBO_FAMCOD");u=this.COMBO_FAMCODContainer;u.setProp("Class","Class","","char");u.setProp("IconType","Icontype","Image","str");u.setProp("Icon","Icon","","str");u.setProp("Caption","Caption","","str");u.setProp("Tooltip","Tooltip","","str");u.setProp("Cls","Cls","ExtendedCombo AttributeRealWidth50With","str");u.setDynProp("SelectedValue_set","Selectedvalue_set","","char");u.setProp("SelectedValue_get","Selectedvalue_get","","char");u.setProp("SelectedText_set","Selectedtext_set","","char");u.setProp("SelectedText_get","Selectedtext_get","","char");u.setProp("GAMOAuthToken","Gamoauthtoken","","char");u.setProp("DDOInternalName","Ddointernalname","","char");u.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");u.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");u.setProp("Enabled","Enabled",!0,"bool");u.setProp("Visible","Visible",!0,"bool");u.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");u.setProp("DataListType","Datalisttype","Dynamic","str");u.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");u.setProp("DataListFixedValues","Datalistfixedvalues","","char");u.setProp("IsGridItem","Isgriditem",!1,"bool");u.setProp("HasDescription","Hasdescription",!1,"bool");u.setProp("DataListProc","Datalistproc","","str");u.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");u.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");u.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");u.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");u.setProp("EmptyItem","Emptyitem",!0,"bool");u.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");u.setProp("HTMLTemplate","Htmltemplate","","str");u.setProp("MultipleValuesType","Multiplevaluestype","Text","str");u.setProp("LoadingData","Loadingdata","","char");u.setProp("NoResultsFound","Noresultsfound","","char");u.setProp("EmptyItemText","Emptyitemtext","GX_EmptyItemText","str");u.setProp("OnlySelectedValues","Onlyselectedvalues","","char");u.setProp("SelectAllText","Selectalltext","","char");u.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");u.setProp("AddNewOptionText","Addnewoptiontext","","str");u.setProp("DropDownOptionsTitleSettingsIcons","Dropdownoptionstitlesettingsicons","","str");u.addV2CFunction("AV18FamCod_Data","vFAMCOD_DATA","SetDropDownOptionsData");u.addC2VFunction(function(n){n.ParentObject.AV18FamCod_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vFAMCOD_DATA",n.ParentObject.AV18FamCod_Data)});u.setProp("Gx Control Type","Gxcontroltype","","int");u.setC2ShowFunction(function(n){n.show()});u.addEventHandler("OnOptionClicked",this.e172r1_client);this.setUserControl(u);this.DVPANEL_PANEL1Container=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_PANEL1Container","Dvpanel_panel1","DVPANEL_PANEL1");e=this.DVPANEL_PANEL1Container;e.setProp("Class","Class","","char");e.setProp("Enabled","Enabled",!0,"boolean");e.setProp("Width","Width","100%","str");e.setProp("Height","Height","100","str");e.setProp("AutoWidth","Autowidth",!1,"bool");e.setProp("AutoHeight","Autoheight",!0,"bool");e.setProp("Cls","Cls","PanelFilled Panel_BaseColor","str");e.setProp("ShowHeader","Showheader",!0,"bool");e.setProp("Title","Title","Reporte de Stock Actual","str");e.setProp("Collapsible","Collapsible",!0,"bool");e.setProp("Collapsed","Collapsed",!1,"bool");e.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");e.setProp("IconPosition","Iconposition","Right","str");e.setProp("AutoScroll","Autoscroll",!1,"bool");e.setProp("Visible","Visible",!0,"bool");e.setProp("Gx Control Type","Gxcontroltype","","int");e.setC2ShowFunction(function(n){n.show()});this.setUserControl(e);this.INNEWWINDOWContainer=gx.uc.getNew(this,96,61,"InNewWindow","INNEWWINDOWContainer","Innewwindow","INNEWWINDOW");f=this.INNEWWINDOWContainer;f.setProp("Class","Class","","char");f.setProp("Enabled","Enabled",!0,"boolean");f.setProp("Width","Width","50","str");f.setProp("Height","Height","50","str");f.setProp("Name","Name","","str");f.setDynProp("Target","Target","","str");f.setProp("Fullscreen","Fullscreen",!1,"bool");f.setProp("Location","Location",!0,"bool");f.setProp("MenuBar","Menubar",!0,"bool");f.setProp("Resizable","Resizable",!0,"bool");f.setProp("Scrollbars","Scrollbars",!0,"bool");f.setProp("TitleBar","Titlebar",!0,"bool");f.setProp("ToolBar","Toolbar",!0,"bool");f.setProp("directories","Directories",!0,"bool");f.setProp("status","Status",!0,"bool");f.setProp("copyhistory","Copyhistory",!0,"bool");f.setProp("top","Top","5","str");f.setProp("left","Left","5","str");f.setProp("fitscreen","Fitscreen",!1,"bool");f.setProp("RefreshParentOnClose","Refreshparentonclose",!1,"bool");f.setProp("Targets","Targets","","str");f.setProp("Visible","Visible",!0,"bool");f.setC2ShowFunction(function(n){n.show()});this.setUserControl(f);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"PANEL1",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"TABLESPLITTEDALMCOD",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"TEXTBLOCKCOMBO_ALMCOD",format:0,grid:0,ctrltype:"textblock"};n[24]={id:24,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"TABLESPLITTEDLINCOD",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"TEXTBLOCKCOMBO_LINCOD",format:0,grid:0,ctrltype:"textblock"};n[32]={id:32,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"TABLESPLITTEDSUBLCOD",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"TEXTBLOCKCOMBO_SUBLCOD",format:0,grid:0,ctrltype:"textblock"};n[40]={id:40,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"TABLESPLITTEDFAMCOD",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"TEXTBLOCKCOMBO_FAMCOD",format:0,grid:0,ctrltype:"textblock"};n[48]={id:48,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"TABLESPLITTEDPRODCOD",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"TEXTBLOCKPRODCOD",format:0,grid:0,ctrltype:"textblock"};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"TABLEMERGEDPRODCOD",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,lvl:0,type:"char",len:15,dec:0,sign:!1,pic:"@!",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPRODCOD",gxz:"ZV9ProdCod",gxold:"OV9ProdCod",gxvar:"AV9ProdCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV9ProdCod=n)},v2z:function(n){n!==undefined&&(gx.O.ZV9ProdCod=n)},v2c:function(){gx.fn.setControlValue("vPRODCOD",gx.O.AV9ProdCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV9ProdCod=this.val())},val:function(){return gx.fn.getControlValue("vPRODCOD")},nac:gx.falseFn};n[63]={id:63,fld:"BTNBUSCAR",grid:0,evt:"e152r2_client"};n[65]={id:65,fld:"",grid:0};n[66]={id:66,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPRODDSC",gxz:"ZV13ProdDsc",gxold:"OV13ProdDsc",gxvar:"AV13ProdDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV13ProdDsc=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13ProdDsc=n)},v2c:function(){gx.fn.setControlValue("vPRODDSC",gx.O.AV13ProdDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV13ProdDsc=this.val())},val:function(){return gx.fn.getControlValue("vPRODDSC")},nac:gx.falseFn};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,fld:"UNNAMEDTABLEFDESDE",grid:0};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"TEXTBLOCKFDESDE",format:0,grid:0,ctrltype:"textblock"};n[73]={id:73,fld:"",grid:0};n[74]={id:74,fld:"",grid:0};n[75]={id:75,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Fdesde,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFDESDE",gxz:"ZV23FDesde",gxold:"OV23FDesde",gxvar:"AV23FDesde",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[75],ip:[75],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV23FDesde=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV23FDesde=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vFDESDE",gx.O.AV23FDesde,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV23FDesde=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vFDESDE")},nac:gx.falseFn};n[76]={id:76,fld:"",grid:0};n[77]={id:77,fld:"",grid:0};n[78]={id:78,fld:"UNNAMEDTABLETIPOORDEN",grid:0};n[79]={id:79,fld:"",grid:0};n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"TEXTBLOCKTIPOORDEN",format:0,grid:0,ctrltype:"textblock"};n[82]={id:82,fld:"",grid:0};n[83]={id:83,fld:"",grid:0};n[84]={id:84,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTIPOORDEN",gxz:"ZV12TipoOrden",gxold:"OV12TipoOrden",gxvar:"AV12TipoOrden",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"radio",v2v:function(n){n!==undefined&&(gx.O.AV12TipoOrden=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV12TipoOrden=gx.num.intval(n))},v2c:function(){gx.fn.setRadioValue("vTIPOORDEN",gx.O.AV12TipoOrden)},c2v:function(){this.val()!==undefined&&(gx.O.AV12TipoOrden=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vTIPOORDEN",",")},nac:gx.falseFn};n[85]={id:85,fld:"",grid:0};n[86]={id:86,fld:"",grid:0};n[87]={id:87,fld:"",grid:0};n[88]={id:88,fld:"",grid:0};n[89]={id:89,fld:"BTNBTNIMPRIMIR",grid:0,evt:"e122r2_client"};n[90]={id:90,fld:"",grid:0};n[91]={id:91,fld:"BTNBTNEXCEL",grid:0,evt:"e132r2_client"};n[92]={id:92,fld:"",grid:0};n[93]={id:93,fld:"BTNBTNSALIR",grid:0,evt:"e142r2_client"};n[94]={id:94,fld:"",grid:0};n[95]={id:95,fld:"",grid:0};n[97]={id:97,fld:"",grid:0};n[98]={id:98,fld:"",grid:0};n[99]={id:99,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[100]={id:100,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vALMCOD",gxz:"ZV5AlmCod",gxold:"OV5AlmCod",gxvar:"AV5AlmCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV5AlmCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV5AlmCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vALMCOD",gx.O.AV5AlmCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV5AlmCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vALMCOD",",")},nac:gx.falseFn};n[101]={id:101,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINCOD",gxz:"ZV6LinCod",gxold:"OV6LinCod",gxvar:"AV6LinCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6LinCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6LinCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vLINCOD",gx.O.AV6LinCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6LinCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vLINCOD",",")},nac:gx.falseFn};n[102]={id:102,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSUBLCOD",gxz:"ZV7SubLCod",gxold:"OV7SubLCod",gxvar:"AV7SubLCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7SubLCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV7SubLCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vSUBLCOD",gx.O.AV7SubLCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7SubLCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vSUBLCOD",",")},nac:gx.falseFn};n[103]={id:103,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFAMCOD",gxz:"ZV8FamCod",gxold:"OV8FamCod",gxvar:"AV8FamCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8FamCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV8FamCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vFAMCOD",gx.O.AV8FamCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8FamCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vFAMCOD",",")},nac:gx.falseFn};this.AV9ProdCod="";this.ZV9ProdCod="";this.OV9ProdCod="";this.AV13ProdDsc="";this.ZV13ProdDsc="";this.OV13ProdDsc="";this.AV23FDesde=gx.date.nullDate();this.ZV23FDesde=gx.date.nullDate();this.OV23FDesde=gx.date.nullDate();this.AV12TipoOrden=0;this.ZV12TipoOrden=0;this.OV12TipoOrden=0;this.AV5AlmCod=0;this.ZV5AlmCod=0;this.OV5AlmCod=0;this.AV6LinCod=0;this.ZV6LinCod=0;this.OV6LinCod=0;this.AV7SubLCod=0;this.ZV7SubLCod=0;this.OV7SubLCod=0;this.AV8FamCod=0;this.ZV8FamCod=0;this.OV8FamCod=0;this.AV14AlmCod_Data=[];this.AV16LinCod_Data=[];this.AV17SubLCod_Data=[];this.AV18FamCod_Data=[];this.AV9ProdCod="";this.AV13ProdDsc="";this.AV23FDesde=gx.date.nullDate();this.AV12TipoOrden=0;this.AV5AlmCod=0;this.AV6LinCod=0;this.AV7SubLCod=0;this.AV8FamCod=0;this.A438AlmSts=0;this.A63AlmCod=0;this.A436AlmDsc="";this.A1159LinSts=0;this.A52LinCod=0;this.A1153LinDsc="";this.A1893SublSts=0;this.A51SublCod=0;this.A1892SublDsc="";this.A979FamSts=0;this.A50FamCod=0;this.A977FamDsc="";this.Events={e122r2_client:["'DOBTNIMPRIMIR'",!0],e132r2_client:["'DOBTNEXCEL'",!0],e142r2_client:["'DOBTNSALIR'",!0],e152r2_client:["'DOBTNBUSCAR'",!0],e212r2_client:["ENTER",!0],e222r2_client:["CANCEL",!0],e172r1_client:["COMBO_FAMCOD.ONOPTIONCLICKED",!1],e182r1_client:["COMBO_SUBLCOD.ONOPTIONCLICKED",!1],e192r1_client:["COMBO_LINCOD.ONOPTIONCLICKED",!1],e202r1_client:["COMBO_ALMCOD.ONOPTIONCLICKED",!1]};this.EvtParms.REFRESH=[[{ctrl:"vTIPOORDEN"},{av:"AV12TipoOrden",fld:"vTIPOORDEN",pic:"9"}],[{ctrl:"vTIPOORDEN"},{av:"AV12TipoOrden",fld:"vTIPOORDEN",pic:"9"}]];this.EvtParms["'DOBTNIMPRIMIR'"]=[[{av:"AV6LinCod",fld:"vLINCOD",pic:"ZZZZZ9"},{av:"AV7SubLCod",fld:"vSUBLCOD",pic:"ZZZZZ9"},{av:"AV8FamCod",fld:"vFAMCOD",pic:"ZZZZZ9"},{av:"AV5AlmCod",fld:"vALMCOD",pic:"ZZZZZ9"},{av:"AV9ProdCod",fld:"vPRODCOD",pic:"@!"},{av:"AV23FDesde",fld:"vFDESDE",pic:""},{ctrl:"vTIPOORDEN"},{av:"AV12TipoOrden",fld:"vTIPOORDEN",pic:"9"}],[{av:"this.INNEWWINDOWContainer.Target",ctrl:"INNEWWINDOW",prop:"Target"},{ctrl:"vTIPOORDEN"},{av:"AV12TipoOrden",fld:"vTIPOORDEN",pic:"9"}]];this.EvtParms["'DOBTNEXCEL'"]=[[{av:"AV6LinCod",fld:"vLINCOD",pic:"ZZZZZ9"},{av:"AV7SubLCod",fld:"vSUBLCOD",pic:"ZZZZZ9"},{av:"AV8FamCod",fld:"vFAMCOD",pic:"ZZZZZ9"},{av:"AV5AlmCod",fld:"vALMCOD",pic:"ZZZZZ9"},{av:"AV9ProdCod",fld:"vPRODCOD",pic:"@!"},{av:"AV23FDesde",fld:"vFDESDE",pic:""},{ctrl:"vTIPOORDEN"},{av:"AV12TipoOrden",fld:"vTIPOORDEN",pic:"9"}],[{av:"AV23FDesde",fld:"vFDESDE",pic:""},{av:"AV9ProdCod",fld:"vPRODCOD",pic:"@!"},{av:"AV5AlmCod",fld:"vALMCOD",pic:"ZZZZZ9"},{av:"AV8FamCod",fld:"vFAMCOD",pic:"ZZZZZ9"},{av:"AV7SubLCod",fld:"vSUBLCOD",pic:"ZZZZZ9"},{av:"AV6LinCod",fld:"vLINCOD",pic:"ZZZZZ9"},{ctrl:"vTIPOORDEN"},{av:"AV12TipoOrden",fld:"vTIPOORDEN",pic:"9"}]];this.EvtParms["'DOBTNSALIR'"]=[[{ctrl:"vTIPOORDEN"},{av:"AV12TipoOrden",fld:"vTIPOORDEN",pic:"9"}],[{ctrl:"vTIPOORDEN"},{av:"AV12TipoOrden",fld:"vTIPOORDEN",pic:"9"}]];this.EvtParms["'DOBTNBUSCAR'"]=[[{ctrl:"vTIPOORDEN"},{av:"AV12TipoOrden",fld:"vTIPOORDEN",pic:"9"}],[{av:"AV13ProdDsc",fld:"vPRODDSC",pic:""},{av:"AV9ProdCod",fld:"vPRODCOD",pic:"@!"},{ctrl:"vTIPOORDEN"},{av:"AV12TipoOrden",fld:"vTIPOORDEN",pic:"9"}]];this.EvtParms["COMBO_FAMCOD.ONOPTIONCLICKED"]=[[{av:"this.COMBO_FAMCODContainer.SelectedValue_get",ctrl:"COMBO_FAMCOD",prop:"SelectedValue_get"},{ctrl:"vTIPOORDEN"},{av:"AV12TipoOrden",fld:"vTIPOORDEN",pic:"9"}],[{av:"AV8FamCod",fld:"vFAMCOD",pic:"ZZZZZ9"},{ctrl:"vTIPOORDEN"},{av:"AV12TipoOrden",fld:"vTIPOORDEN",pic:"9"}]];this.EvtParms["COMBO_SUBLCOD.ONOPTIONCLICKED"]=[[{av:"this.COMBO_SUBLCODContainer.SelectedValue_get",ctrl:"COMBO_SUBLCOD",prop:"SelectedValue_get"},{ctrl:"vTIPOORDEN"},{av:"AV12TipoOrden",fld:"vTIPOORDEN",pic:"9"}],[{av:"AV7SubLCod",fld:"vSUBLCOD",pic:"ZZZZZ9"},{ctrl:"vTIPOORDEN"},{av:"AV12TipoOrden",fld:"vTIPOORDEN",pic:"9"}]];this.EvtParms["COMBO_LINCOD.ONOPTIONCLICKED"]=[[{av:"this.COMBO_LINCODContainer.SelectedValue_get",ctrl:"COMBO_LINCOD",prop:"SelectedValue_get"},{ctrl:"vTIPOORDEN"},{av:"AV12TipoOrden",fld:"vTIPOORDEN",pic:"9"}],[{av:"AV6LinCod",fld:"vLINCOD",pic:"ZZZZZ9"},{ctrl:"vTIPOORDEN"},{av:"AV12TipoOrden",fld:"vTIPOORDEN",pic:"9"}]];this.EvtParms["COMBO_ALMCOD.ONOPTIONCLICKED"]=[[{av:"this.COMBO_ALMCODContainer.SelectedValue_get",ctrl:"COMBO_ALMCOD",prop:"SelectedValue_get"},{ctrl:"vTIPOORDEN"},{av:"AV12TipoOrden",fld:"vTIPOORDEN",pic:"9"}],[{av:"AV5AlmCod",fld:"vALMCOD",pic:"ZZZZZ9"},{ctrl:"vTIPOORDEN"},{av:"AV12TipoOrden",fld:"vTIPOORDEN",pic:"9"}]];this.EvtParms.ENTER=[[{ctrl:"vTIPOORDEN"},{av:"AV12TipoOrden",fld:"vTIPOORDEN",pic:"9"}],[{ctrl:"vTIPOORDEN"},{av:"AV12TipoOrden",fld:"vTIPOORDEN",pic:"9"}]];this.EvtParms.VALIDV_FDESDE=[[{ctrl:"vTIPOORDEN"},{av:"AV12TipoOrden",fld:"vTIPOORDEN",pic:"9"}],[{ctrl:"vTIPOORDEN"},{av:"AV12TipoOrden",fld:"vTIPOORDEN",pic:"9"}]];this.Initialize();this.setSDTMapping("WWPBaseObjects\\DVB_SDTComboData.Item",{Title:{extr:"T"},Children:{extr:"C"}})});gx.wi(function(){gx.createParentObj(this.almacen.r_stockactual)})