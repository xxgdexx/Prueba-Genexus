gx.evt.autoSkip=!1;gx.define("compras.r_analisiscomprasproductoproveedor",!1,function(){var n,t,i,r,f,u;this.ServerClass="compras.r_analisiscomprasproductoproveedor";this.PackageName="GeneXus.Programs";this.ServerFullClass="compras.r_analisiscomprasproductoproveedor.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV19DocMonCod=gx.fn.getIntegerValue("vDOCMONCOD",",");this.AV18Tipo=gx.fn.getControlValue("vTIPO")};this.Validv_Fdesde=function(){return this.validCliEvt("Validv_Fdesde",0,function(){try{var n=gx.util.balloon.getNew("vFDESDE");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV6Fdesde)===0||new gx.date.gxdate(this.AV6Fdesde).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Fecha Desde fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Fhasta=function(){return this.validCliEvt("Validv_Fhasta",0,function(){try{var n=gx.util.balloon.getNew("vFHASTA");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV7Fhasta)===0||new gx.date.gxdate(this.AV7Fhasta).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Fecha Hasta fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e164d1_client=function(){return this.clearMessages(),this.popupOpenUrl(gx.http.formatLink("generales.wwbusquedaproveedor.aspx",["",""]),["AV14PrvCod","AV15PrvDsc"]),this.refreshOutputs([{av:"AV15PrvDsc",fld:"vPRVDSC",pic:""},{av:"AV14PrvCod",fld:"vPRVCOD",pic:"@!"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e154d1_client=function(){return this.clearMessages(),this.popupOpenUrl(gx.http.formatLink("generales.wwbusquedaproducto.aspx",["","",""]),["AV12ProdCod","AV13ProdDsc"]),this.refreshOutputs([{av:"AV13ProdDsc",fld:"vPRODDSC",pic:""},{av:"AV12ProdCod",fld:"vPRODCOD",pic:"@!"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e174d1_client=function(){return this.clearMessages(),this.AV10MonCod=gx.num.trunc(gx.num.val(this.COMBO_MONCODContainer.SelectedValue_get),0),this.refreshOutputs([{av:"AV10MonCod",fld:"vMONCOD",pic:"ZZZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e184d1_client=function(){return this.clearMessages(),this.AV16SublCod=gx.num.trunc(gx.num.val(this.COMBO_SUBLCODContainer.SelectedValue_get),0),this.refreshOutputs([{av:"AV16SublCod",fld:"vSUBLCOD",pic:"ZZZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e194d1_client=function(){return this.clearMessages(),this.AV8LinCod=gx.num.trunc(gx.num.val(this.COMBO_LINCODContainer.SelectedValue_get),0),this.refreshOutputs([{av:"AV8LinCod",fld:"vLINCOD",pic:"ZZZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e124d2_client=function(){return this.executeServerEvent("'DOBTNIMPRIMIR'",!1,null,!1,!1)};this.e134d2_client=function(){return this.executeServerEvent("'DOBTNSALIR'",!1,null,!1,!1)};this.e204d2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e214d2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,26,27,28,29,30,31,33,34,35,36,37,38,39,40,43,44,46,48,49,50,51,52,53,54,55,56,57,60,61,63,65,66,67,68,69,70,71,72,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100,102,103,104,105,106,107];this.GXLastCtrlId=107;this.COMBO_LINCODContainer=gx.uc.getNew(this,25,0,"BootstrapDropDownOptions","COMBO_LINCODContainer","Combo_lincod","COMBO_LINCOD");t=this.COMBO_LINCODContainer;t.setProp("Class","Class","","char");t.setProp("IconType","Icontype","Image","str");t.setProp("Icon","Icon","","str");t.setProp("Caption","Caption","","str");t.setProp("Tooltip","Tooltip","","str");t.setProp("Cls","Cls","ExtendedCombo AttributeRealWidth50With","str");t.setDynProp("SelectedValue_set","Selectedvalue_set","","char");t.setProp("SelectedValue_get","Selectedvalue_get","","char");t.setProp("SelectedText_set","Selectedtext_set","","char");t.setProp("SelectedText_get","Selectedtext_get","","char");t.setProp("GAMOAuthToken","Gamoauthtoken","","char");t.setProp("DDOInternalName","Ddointernalname","","char");t.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");t.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");t.setProp("Enabled","Enabled",!0,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");t.setProp("DataListType","Datalisttype","Dynamic","str");t.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");t.setProp("DataListFixedValues","Datalistfixedvalues","","char");t.setProp("IsGridItem","Isgriditem",!1,"bool");t.setProp("HasDescription","Hasdescription",!1,"bool");t.setProp("DataListProc","Datalistproc","","str");t.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");t.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");t.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");t.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");t.setProp("EmptyItem","Emptyitem",!1,"bool");t.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");t.setProp("HTMLTemplate","Htmltemplate","","str");t.setProp("MultipleValuesType","Multiplevaluestype","Text","str");t.setProp("LoadingData","Loadingdata","","char");t.setProp("NoResultsFound","Noresultsfound","","char");t.setProp("EmptyItemText","Emptyitemtext","","char");t.setProp("OnlySelectedValues","Onlyselectedvalues","","char");t.setProp("SelectAllText","Selectalltext","","char");t.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");t.setProp("AddNewOptionText","Addnewoptiontext","","str");t.setProp("DropDownOptionsTitleSettingsIcons","Dropdownoptionstitlesettingsicons","","str");t.addV2CFunction("AV9LinCod_Data","vLINCOD_DATA","SetDropDownOptionsData");t.addC2VFunction(function(n){n.ParentObject.AV9LinCod_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vLINCOD_DATA",n.ParentObject.AV9LinCod_Data)});t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("OnOptionClicked",this.e194d1_client);this.setUserControl(t);this.COMBO_SUBLCODContainer=gx.uc.getNew(this,32,0,"BootstrapDropDownOptions","COMBO_SUBLCODContainer","Combo_sublcod","COMBO_SUBLCOD");i=this.COMBO_SUBLCODContainer;i.setProp("Class","Class","","char");i.setProp("IconType","Icontype","Image","str");i.setProp("Icon","Icon","","str");i.setProp("Caption","Caption","","str");i.setProp("Tooltip","Tooltip","","str");i.setProp("Cls","Cls","ExtendedCombo AttributeRealWidth50With","str");i.setDynProp("SelectedValue_set","Selectedvalue_set","","char");i.setProp("SelectedValue_get","Selectedvalue_get","","char");i.setProp("SelectedText_set","Selectedtext_set","","char");i.setProp("SelectedText_get","Selectedtext_get","","char");i.setProp("GAMOAuthToken","Gamoauthtoken","","char");i.setProp("DDOInternalName","Ddointernalname","","char");i.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");i.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");i.setProp("Enabled","Enabled",!0,"bool");i.setProp("Visible","Visible",!0,"bool");i.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");i.setProp("DataListType","Datalisttype","Dynamic","str");i.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");i.setProp("DataListFixedValues","Datalistfixedvalues","","char");i.setProp("IsGridItem","Isgriditem",!1,"bool");i.setProp("HasDescription","Hasdescription",!1,"bool");i.setProp("DataListProc","Datalistproc","","str");i.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");i.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");i.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");i.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");i.setProp("EmptyItem","Emptyitem",!1,"bool");i.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");i.setProp("HTMLTemplate","Htmltemplate","","str");i.setProp("MultipleValuesType","Multiplevaluestype","Text","str");i.setProp("LoadingData","Loadingdata","","char");i.setProp("NoResultsFound","Noresultsfound","","char");i.setProp("EmptyItemText","Emptyitemtext","","char");i.setProp("OnlySelectedValues","Onlyselectedvalues","","char");i.setProp("SelectAllText","Selectalltext","","char");i.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");i.setProp("AddNewOptionText","Addnewoptiontext","","str");i.setProp("DropDownOptionsTitleSettingsIcons","Dropdownoptionstitlesettingsicons","","str");i.addV2CFunction("AV17SublCod_Data","vSUBLCOD_DATA","SetDropDownOptionsData");i.addC2VFunction(function(n){n.ParentObject.AV17SublCod_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vSUBLCOD_DATA",n.ParentObject.AV17SublCod_Data)});i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});i.addEventHandler("OnOptionClicked",this.e184d1_client);this.setUserControl(i);this.COMBO_MONCODContainer=gx.uc.getNew(this,73,44,"BootstrapDropDownOptions","COMBO_MONCODContainer","Combo_moncod","COMBO_MONCOD");r=this.COMBO_MONCODContainer;r.setProp("Class","Class","","char");r.setProp("IconType","Icontype","Image","str");r.setProp("Icon","Icon","","str");r.setProp("Caption","Caption","","str");r.setProp("Tooltip","Tooltip","","str");r.setProp("Cls","Cls","ExtendedCombo AttributeRealWidth50With","str");r.setDynProp("SelectedValue_set","Selectedvalue_set","","char");r.setProp("SelectedValue_get","Selectedvalue_get","","char");r.setProp("SelectedText_set","Selectedtext_set","","char");r.setProp("SelectedText_get","Selectedtext_get","","char");r.setProp("GAMOAuthToken","Gamoauthtoken","","char");r.setProp("DDOInternalName","Ddointernalname","","char");r.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");r.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");r.setProp("Enabled","Enabled",!0,"bool");r.setProp("Visible","Visible",!0,"bool");r.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");r.setProp("DataListType","Datalisttype","Dynamic","str");r.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");r.setProp("DataListFixedValues","Datalistfixedvalues","","char");r.setProp("IsGridItem","Isgriditem",!1,"bool");r.setProp("HasDescription","Hasdescription",!1,"bool");r.setProp("DataListProc","Datalistproc","","str");r.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");r.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");r.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");r.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");r.setProp("EmptyItem","Emptyitem",!0,"bool");r.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");r.setProp("HTMLTemplate","Htmltemplate","","str");r.setProp("MultipleValuesType","Multiplevaluestype","Text","str");r.setProp("LoadingData","Loadingdata","","char");r.setProp("NoResultsFound","Noresultsfound","","char");r.setProp("EmptyItemText","Emptyitemtext","GX_EmptyItemText","str");r.setProp("OnlySelectedValues","Onlyselectedvalues","","char");r.setProp("SelectAllText","Selectalltext","","char");r.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");r.setProp("AddNewOptionText","Addnewoptiontext","","str");r.setProp("DropDownOptionsTitleSettingsIcons","Dropdownoptionstitlesettingsicons","","str");r.addV2CFunction("AV11MonCod_Data","vMONCOD_DATA","SetDropDownOptionsData");r.addC2VFunction(function(n){n.ParentObject.AV11MonCod_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vMONCOD_DATA",n.ParentObject.AV11MonCod_Data)});r.setProp("Gx Control Type","Gxcontroltype","","int");r.setC2ShowFunction(function(n){n.show()});r.addEventHandler("OnOptionClicked",this.e174d1_client);this.setUserControl(r);this.DVPANEL_PANEL1Container=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_PANEL1Container","Dvpanel_panel1","DVPANEL_PANEL1");f=this.DVPANEL_PANEL1Container;f.setProp("Class","Class","","char");f.setProp("Enabled","Enabled",!0,"boolean");f.setProp("Width","Width","100%","str");f.setProp("Height","Height","100","str");f.setProp("AutoWidth","Autowidth",!1,"bool");f.setProp("AutoHeight","Autoheight",!0,"bool");f.setProp("Cls","Cls","PanelFilled Panel_BaseColor","str");f.setProp("ShowHeader","Showheader",!0,"bool");f.setProp("Title","Title","Analisis Compras Producto / Proveedor","str");f.setProp("Collapsible","Collapsible",!0,"bool");f.setProp("Collapsed","Collapsed",!1,"bool");f.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");f.setProp("IconPosition","Iconposition","Right","str");f.setProp("AutoScroll","Autoscroll",!1,"bool");f.setProp("Visible","Visible",!0,"bool");f.setProp("Gx Control Type","Gxcontroltype","","int");f.setC2ShowFunction(function(n){n.show()});this.setUserControl(f);this.INNEWWINDOWContainer=gx.uc.getNew(this,101,44,"InNewWindow","INNEWWINDOWContainer","Innewwindow","INNEWWINDOW");u=this.INNEWWINDOWContainer;u.setProp("Class","Class","","char");u.setProp("Enabled","Enabled",!0,"boolean");u.setProp("Width","Width","50","str");u.setProp("Height","Height","50","str");u.setProp("Name","Name","","str");u.setDynProp("Target","Target","","str");u.setProp("Fullscreen","Fullscreen",!1,"bool");u.setProp("Location","Location",!0,"bool");u.setProp("MenuBar","Menubar",!0,"bool");u.setProp("Resizable","Resizable",!0,"bool");u.setProp("Scrollbars","Scrollbars",!0,"bool");u.setProp("TitleBar","Titlebar",!0,"bool");u.setProp("ToolBar","Toolbar",!0,"bool");u.setProp("directories","Directories",!0,"bool");u.setProp("status","Status",!0,"bool");u.setProp("copyhistory","Copyhistory",!0,"bool");u.setProp("top","Top","5","str");u.setProp("left","Left","5","str");u.setProp("fitscreen","Fitscreen",!1,"bool");u.setProp("RefreshParentOnClose","Refreshparentonclose",!1,"bool");u.setProp("Targets","Targets","","str");u.setProp("Visible","Visible",!0,"bool");u.setC2ShowFunction(function(n){n.show()});this.setUserControl(u);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"PANEL1",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"TABLESPLITTEDLINCOD",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"TEXTBLOCKCOMBO_LINCOD",format:0,grid:0,ctrltype:"textblock"};n[24]={id:24,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"TABLESPLITTEDSUBLCOD",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"TEXTBLOCKCOMBO_SUBLCOD",format:0,grid:0,ctrltype:"textblock"};n[31]={id:31,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"TABLESPLITTEDPRVCOD",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"TEXTBLOCKPRVCOD",format:0,grid:0,ctrltype:"textblock"};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"TABLEMERGEDPRVCOD",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,lvl:0,type:"char",len:20,dec:0,sign:!1,pic:"@!",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPRVCOD",gxz:"ZV14PrvCod",gxold:"OV14PrvCod",gxvar:"AV14PrvCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV14PrvCod=n)},v2z:function(n){n!==undefined&&(gx.O.ZV14PrvCod=n)},v2c:function(){gx.fn.setControlValue("vPRVCOD",gx.O.AV14PrvCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV14PrvCod=this.val())},val:function(){return gx.fn.getControlValue("vPRVCOD")},nac:gx.falseFn};n[46]={id:46,fld:"BTNPROV",grid:0,evt:"e164d1_client"};n[48]={id:48,fld:"",grid:0};n[49]={id:49,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPRVDSC",gxz:"ZV15PrvDsc",gxold:"OV15PrvDsc",gxvar:"AV15PrvDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV15PrvDsc=n)},v2z:function(n){n!==undefined&&(gx.O.ZV15PrvDsc=n)},v2c:function(){gx.fn.setControlValue("vPRVDSC",gx.O.AV15PrvDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV15PrvDsc=this.val())},val:function(){return gx.fn.getControlValue("vPRVDSC")},nac:gx.falseFn};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"TABLESPLITTEDPRODCOD",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"TEXTBLOCKPRODCOD",format:0,grid:0,ctrltype:"textblock"};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"TABLEMERGEDPRODCOD",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,lvl:0,type:"char",len:15,dec:0,sign:!1,pic:"@!",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPRODCOD",gxz:"ZV12ProdCod",gxold:"OV12ProdCod",gxvar:"AV12ProdCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV12ProdCod=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12ProdCod=n)},v2c:function(){gx.fn.setControlValue("vPRODCOD",gx.O.AV12ProdCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV12ProdCod=this.val())},val:function(){return gx.fn.getControlValue("vPRODCOD")},nac:gx.falseFn};n[63]={id:63,fld:"BTNPROD",grid:0,evt:"e154d1_client"};n[65]={id:65,fld:"",grid:0};n[66]={id:66,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPRODDSC",gxz:"ZV13ProdDsc",gxold:"OV13ProdDsc",gxvar:"AV13ProdDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV13ProdDsc=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13ProdDsc=n)},v2c:function(){gx.fn.setControlValue("vPRODDSC",gx.O.AV13ProdDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV13ProdDsc=this.val())},val:function(){return gx.fn.getControlValue("vPRODDSC")},nac:gx.falseFn};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"TABLESPLITTEDMONCOD",grid:0};n[69]={id:69,fld:"",grid:0};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"TEXTBLOCKCOMBO_MONCOD",format:0,grid:0,ctrltype:"textblock"};n[72]={id:72,fld:"",grid:0};n[74]={id:74,fld:"",grid:0};n[75]={id:75,fld:"",grid:0};n[76]={id:76,fld:"UNNAMEDTABLEFDESDE",grid:0};n[77]={id:77,fld:"",grid:0};n[78]={id:78,fld:"",grid:0};n[79]={id:79,fld:"TEXTBLOCKFDESDE",format:0,grid:0,ctrltype:"textblock"};n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"",grid:0};n[82]={id:82,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Fdesde,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFDESDE",gxz:"ZV6Fdesde",gxold:"OV6Fdesde",gxvar:"AV6Fdesde",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[82],ip:[82],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6Fdesde=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6Fdesde=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vFDESDE",gx.O.AV6Fdesde,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6Fdesde=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vFDESDE")},nac:gx.falseFn};n[83]={id:83,fld:"",grid:0};n[84]={id:84,fld:"",grid:0};n[85]={id:85,fld:"UNNAMEDTABLEFHASTA",grid:0};n[86]={id:86,fld:"",grid:0};n[87]={id:87,fld:"",grid:0};n[88]={id:88,fld:"TEXTBLOCKFHASTA",format:0,grid:0,ctrltype:"textblock"};n[89]={id:89,fld:"",grid:0};n[90]={id:90,fld:"",grid:0};n[91]={id:91,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Fhasta,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFHASTA",gxz:"ZV7Fhasta",gxold:"OV7Fhasta",gxvar:"AV7Fhasta",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[91],ip:[91],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7Fhasta=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV7Fhasta=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vFHASTA",gx.O.AV7Fhasta,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7Fhasta=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vFHASTA")},nac:gx.falseFn};n[92]={id:92,fld:"",grid:0};n[93]={id:93,fld:"",grid:0};n[94]={id:94,fld:"",grid:0};n[95]={id:95,fld:"",grid:0};n[96]={id:96,fld:"BTNBTNIMPRIMIR",grid:0,evt:"e124d2_client"};n[97]={id:97,fld:"",grid:0};n[98]={id:98,fld:"BTNBTNSALIR",grid:0,evt:"e134d2_client"};n[99]={id:99,fld:"",grid:0};n[100]={id:100,fld:"",grid:0};n[102]={id:102,fld:"",grid:0};n[103]={id:103,fld:"",grid:0};n[104]={id:104,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[105]={id:105,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINCOD",gxz:"ZV8LinCod",gxold:"OV8LinCod",gxvar:"AV8LinCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8LinCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV8LinCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vLINCOD",gx.O.AV8LinCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8LinCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vLINCOD",",")},nac:gx.falseFn};n[106]={id:106,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSUBLCOD",gxz:"ZV16SublCod",gxold:"OV16SublCod",gxvar:"AV16SublCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV16SublCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV16SublCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vSUBLCOD",gx.O.AV16SublCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV16SublCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vSUBLCOD",",")},nac:gx.falseFn};n[107]={id:107,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vMONCOD",gxz:"ZV10MonCod",gxold:"OV10MonCod",gxvar:"AV10MonCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV10MonCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV10MonCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vMONCOD",gx.O.AV10MonCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV10MonCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vMONCOD",",")},nac:gx.falseFn};this.AV14PrvCod="";this.ZV14PrvCod="";this.OV14PrvCod="";this.AV15PrvDsc="";this.ZV15PrvDsc="";this.OV15PrvDsc="";this.AV12ProdCod="";this.ZV12ProdCod="";this.OV12ProdCod="";this.AV13ProdDsc="";this.ZV13ProdDsc="";this.OV13ProdDsc="";this.AV6Fdesde=gx.date.nullDate();this.ZV6Fdesde=gx.date.nullDate();this.OV6Fdesde=gx.date.nullDate();this.AV7Fhasta=gx.date.nullDate();this.ZV7Fhasta=gx.date.nullDate();this.OV7Fhasta=gx.date.nullDate();this.AV8LinCod=0;this.ZV8LinCod=0;this.OV8LinCod=0;this.AV16SublCod=0;this.ZV16SublCod=0;this.OV16SublCod=0;this.AV10MonCod=0;this.ZV10MonCod=0;this.OV10MonCod=0;this.AV9LinCod_Data=[];this.AV17SublCod_Data=[];this.AV14PrvCod="";this.AV15PrvDsc="";this.AV12ProdCod="";this.AV13ProdDsc="";this.AV11MonCod_Data=[];this.AV6Fdesde=gx.date.nullDate();this.AV7Fhasta=gx.date.nullDate();this.AV8LinCod=0;this.AV16SublCod=0;this.AV10MonCod=0;this.A1159LinSts=0;this.A52LinCod=0;this.A1153LinDsc="";this.A51SublCod=0;this.A1892SublDsc="";this.A1235MonSts=0;this.A180MonCod=0;this.A1234MonDsc="";this.AV19DocMonCod=0;this.AV18Tipo="";this.Events={e124d2_client:["'DOBTNIMPRIMIR'",!0],e134d2_client:["'DOBTNSALIR'",!0],e204d2_client:["ENTER",!0],e214d2_client:["CANCEL",!0],e164d1_client:["'DOBTNPROV'",!1],e154d1_client:["'DOBTNPROD'",!1],e174d1_client:["COMBO_MONCOD.ONOPTIONCLICKED",!1],e184d1_client:["COMBO_SUBLCOD.ONOPTIONCLICKED",!1],e194d1_client:["COMBO_LINCOD.ONOPTIONCLICKED",!1]};this.EvtParms.REFRESH=[[{av:"AV19DocMonCod",fld:"vDOCMONCOD",pic:"ZZZZZ9",hsh:!0},{av:"AV18Tipo",fld:"vTIPO",pic:"",hsh:!0}],[]];this.EvtParms["'DOBTNIMPRIMIR'"]=[[{av:"AV8LinCod",fld:"vLINCOD",pic:"ZZZZZ9"},{av:"AV16SublCod",fld:"vSUBLCOD",pic:"ZZZZZ9"},{av:"AV6Fdesde",fld:"vFDESDE",pic:""},{av:"AV7Fhasta",fld:"vFHASTA",pic:""},{av:"AV19DocMonCod",fld:"vDOCMONCOD",pic:"ZZZZZ9",hsh:!0},{av:"AV12ProdCod",fld:"vPRODCOD",pic:"@!"},{av:"AV18Tipo",fld:"vTIPO",pic:"",hsh:!0}],[{av:"this.INNEWWINDOWContainer.Target",ctrl:"INNEWWINDOW",prop:"Target"}]];this.EvtParms["'DOBTNSALIR'"]=[[],[]];this.EvtParms["'DOBTNPROV'"]=[[],[{av:"AV15PrvDsc",fld:"vPRVDSC",pic:""},{av:"AV14PrvCod",fld:"vPRVCOD",pic:"@!"}]];this.EvtParms["'DOBTNPROD'"]=[[],[{av:"AV13ProdDsc",fld:"vPRODDSC",pic:""},{av:"AV12ProdCod",fld:"vPRODCOD",pic:"@!"}]];this.EvtParms["COMBO_MONCOD.ONOPTIONCLICKED"]=[[{av:"this.COMBO_MONCODContainer.SelectedValue_get",ctrl:"COMBO_MONCOD",prop:"SelectedValue_get"}],[{av:"AV10MonCod",fld:"vMONCOD",pic:"ZZZZZ9"}]];this.EvtParms["COMBO_SUBLCOD.ONOPTIONCLICKED"]=[[{av:"this.COMBO_SUBLCODContainer.SelectedValue_get",ctrl:"COMBO_SUBLCOD",prop:"SelectedValue_get"}],[{av:"AV16SublCod",fld:"vSUBLCOD",pic:"ZZZZZ9"}]];this.EvtParms["COMBO_LINCOD.ONOPTIONCLICKED"]=[[{av:"this.COMBO_LINCODContainer.SelectedValue_get",ctrl:"COMBO_LINCOD",prop:"SelectedValue_get"}],[{av:"AV8LinCod",fld:"vLINCOD",pic:"ZZZZZ9"}]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALIDV_FDESDE=[[],[]];this.EvtParms.VALIDV_FHASTA=[[],[]];this.setVCMap("AV19DocMonCod","vDOCMONCOD",0,"int",6,0);this.setVCMap("AV18Tipo","vTIPO",0,"char",1,0);this.Initialize();this.setSDTMapping("WWPBaseObjects\\DVB_SDTComboData.Item",{Title:{extr:"T"},Children:{extr:"C"}})});gx.wi(function(){gx.createParentObj(this.compras.r_analisiscomprasproductoproveedor)})