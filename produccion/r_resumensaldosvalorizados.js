gx.evt.autoSkip=!1;gx.define("produccion.r_resumensaldosvalorizados",!1,function(){var n,t,i,r,f,u;this.ServerClass="produccion.r_resumensaldosvalorizados";this.PackageName="GeneXus.Programs";this.ServerFullClass="produccion.r_resumensaldosvalorizados.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV32OpcEntrada=gx.fn.getIntegerValue("vOPCENTRADA",",")};this.e16701_client=function(){return this.clearMessages(),this.popupOpenUrl(gx.http.formatLink("generales.wwbusquedaproducto.aspx",["",""]),["AV21ProdCod","AV22ProdDsc"]),this.refreshOutputs([{av:"AV22ProdDsc",fld:"vPRODDSC",pic:""},{av:"AV21ProdCod",fld:"vPRODCOD",pic:"@!"},{ctrl:"vALMCOD"},{av:"AV5AlmCod",fld:"vALMCOD",pic:"ZZZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e17701_client=function(){return this.clearMessages(),this.AV10FamCod=gx.num.trunc(gx.num.val(this.COMBO_FAMCODContainer.SelectedValue_get),0),this.refreshOutputs([{av:"AV10FamCod",fld:"vFAMCOD",pic:"ZZZZZ9"},{ctrl:"vALMCOD"},{av:"AV5AlmCod",fld:"vALMCOD",pic:"ZZZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e18701_client=function(){return this.clearMessages(),this.AV24SubLCod=gx.num.trunc(gx.num.val(this.COMBO_SUBLCODContainer.SelectedValue_get),0),this.refreshOutputs([{av:"AV24SubLCod",fld:"vSUBLCOD",pic:"ZZZZZ9"},{ctrl:"vALMCOD"},{av:"AV5AlmCod",fld:"vALMCOD",pic:"ZZZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e19701_client=function(){return this.clearMessages(),this.AV18LinCod=gx.num.trunc(gx.num.val(this.COMBO_LINCODContainer.SelectedValue_get),0),this.refreshOutputs([{av:"AV18LinCod",fld:"vLINCOD",pic:"ZZZZZ9"},{ctrl:"vALMCOD"},{av:"AV5AlmCod",fld:"vALMCOD",pic:"ZZZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e12702_client=function(){return this.executeServerEvent("'DOBTNIMPRIMIR'",!1,null,!1,!1)};this.e13702_client=function(){return this.executeServerEvent("'DOBTNEXCEL'",!1,null,!1,!1)};this.e14702_client=function(){return this.executeServerEvent("'DOBTNSALIR'",!1,null,!1,!1)};this.e20702_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e21702_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,34,35,36,37,38,39,40,42,43,44,45,46,47,49,50,51,52,53,54,55,56,59,60,62,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,95,96,97,98,99,100];this.GXLastCtrlId=100;this.COMBO_LINCODContainer=gx.uc.getNew(this,33,26,"BootstrapDropDownOptions","COMBO_LINCODContainer","Combo_lincod","COMBO_LINCOD");t=this.COMBO_LINCODContainer;t.setProp("Class","Class","","char");t.setProp("IconType","Icontype","Image","str");t.setProp("Icon","Icon","","str");t.setProp("Caption","Caption","","str");t.setProp("Tooltip","Tooltip","","str");t.setProp("Cls","Cls","ExtendedCombo AttributeRealWidth50With","str");t.setDynProp("SelectedValue_set","Selectedvalue_set","","char");t.setProp("SelectedValue_get","Selectedvalue_get","","char");t.setProp("SelectedText_set","Selectedtext_set","","char");t.setProp("SelectedText_get","Selectedtext_get","","char");t.setProp("GAMOAuthToken","Gamoauthtoken","","char");t.setProp("DDOInternalName","Ddointernalname","","char");t.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");t.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");t.setProp("Enabled","Enabled",!0,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");t.setProp("DataListType","Datalisttype","Dynamic","str");t.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");t.setProp("DataListFixedValues","Datalistfixedvalues","","char");t.setProp("IsGridItem","Isgriditem",!1,"bool");t.setProp("HasDescription","Hasdescription",!1,"bool");t.setProp("DataListProc","Datalistproc","","str");t.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");t.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");t.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");t.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");t.setProp("EmptyItem","Emptyitem",!0,"bool");t.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");t.setProp("HTMLTemplate","Htmltemplate","","str");t.setProp("MultipleValuesType","Multiplevaluestype","Text","str");t.setProp("LoadingData","Loadingdata","","char");t.setProp("NoResultsFound","Noresultsfound","","char");t.setProp("EmptyItemText","Emptyitemtext","GX_EmptyItemText","str");t.setProp("OnlySelectedValues","Onlyselectedvalues","","char");t.setProp("SelectAllText","Selectalltext","","char");t.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");t.setProp("AddNewOptionText","Addnewoptiontext","","str");t.setProp("DropDownOptionsTitleSettingsIcons","Dropdownoptionstitlesettingsicons","","str");t.addV2CFunction("AV19LinCod_Data","vLINCOD_DATA","SetDropDownOptionsData");t.addC2VFunction(function(n){n.ParentObject.AV19LinCod_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vLINCOD_DATA",n.ParentObject.AV19LinCod_Data)});t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("OnOptionClicked",this.e19701_client);this.setUserControl(t);this.COMBO_SUBLCODContainer=gx.uc.getNew(this,41,26,"BootstrapDropDownOptions","COMBO_SUBLCODContainer","Combo_sublcod","COMBO_SUBLCOD");i=this.COMBO_SUBLCODContainer;i.setProp("Class","Class","","char");i.setProp("IconType","Icontype","Image","str");i.setProp("Icon","Icon","","str");i.setProp("Caption","Caption","","str");i.setProp("Tooltip","Tooltip","","str");i.setProp("Cls","Cls","ExtendedCombo AttributeRealWidth50With","str");i.setDynProp("SelectedValue_set","Selectedvalue_set","","char");i.setProp("SelectedValue_get","Selectedvalue_get","","char");i.setProp("SelectedText_set","Selectedtext_set","","char");i.setProp("SelectedText_get","Selectedtext_get","","char");i.setProp("GAMOAuthToken","Gamoauthtoken","","char");i.setProp("DDOInternalName","Ddointernalname","","char");i.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");i.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");i.setProp("Enabled","Enabled",!0,"bool");i.setProp("Visible","Visible",!0,"bool");i.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");i.setProp("DataListType","Datalisttype","Dynamic","str");i.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");i.setProp("DataListFixedValues","Datalistfixedvalues","","char");i.setProp("IsGridItem","Isgriditem",!1,"bool");i.setProp("HasDescription","Hasdescription",!1,"bool");i.setProp("DataListProc","Datalistproc","","str");i.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");i.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");i.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");i.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");i.setProp("EmptyItem","Emptyitem",!0,"bool");i.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");i.setProp("HTMLTemplate","Htmltemplate","","str");i.setProp("MultipleValuesType","Multiplevaluestype","Text","str");i.setProp("LoadingData","Loadingdata","","char");i.setProp("NoResultsFound","Noresultsfound","","char");i.setProp("EmptyItemText","Emptyitemtext","GX_EmptyItemText","str");i.setProp("OnlySelectedValues","Onlyselectedvalues","","char");i.setProp("SelectAllText","Selectalltext","","char");i.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");i.setProp("AddNewOptionText","Addnewoptiontext","","str");i.setProp("DropDownOptionsTitleSettingsIcons","Dropdownoptionstitlesettingsicons","","str");i.addV2CFunction("AV25SubLCod_Data","vSUBLCOD_DATA","SetDropDownOptionsData");i.addC2VFunction(function(n){n.ParentObject.AV25SubLCod_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vSUBLCOD_DATA",n.ParentObject.AV25SubLCod_Data)});i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});i.addEventHandler("OnOptionClicked",this.e18701_client);this.setUserControl(i);this.COMBO_FAMCODContainer=gx.uc.getNew(this,48,26,"BootstrapDropDownOptions","COMBO_FAMCODContainer","Combo_famcod","COMBO_FAMCOD");r=this.COMBO_FAMCODContainer;r.setProp("Class","Class","","char");r.setProp("IconType","Icontype","Image","str");r.setProp("Icon","Icon","","str");r.setProp("Caption","Caption","","str");r.setProp("Tooltip","Tooltip","","str");r.setProp("Cls","Cls","ExtendedCombo AttributeRealWidth50With","str");r.setDynProp("SelectedValue_set","Selectedvalue_set","","char");r.setProp("SelectedValue_get","Selectedvalue_get","","char");r.setProp("SelectedText_set","Selectedtext_set","","char");r.setProp("SelectedText_get","Selectedtext_get","","char");r.setProp("GAMOAuthToken","Gamoauthtoken","","char");r.setProp("DDOInternalName","Ddointernalname","","char");r.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");r.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");r.setProp("Enabled","Enabled",!0,"bool");r.setProp("Visible","Visible",!0,"bool");r.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");r.setProp("DataListType","Datalisttype","Dynamic","str");r.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");r.setProp("DataListFixedValues","Datalistfixedvalues","","char");r.setProp("IsGridItem","Isgriditem",!1,"bool");r.setProp("HasDescription","Hasdescription",!1,"bool");r.setProp("DataListProc","Datalistproc","","str");r.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");r.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");r.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");r.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");r.setProp("EmptyItem","Emptyitem",!0,"bool");r.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");r.setProp("HTMLTemplate","Htmltemplate","","str");r.setProp("MultipleValuesType","Multiplevaluestype","Text","str");r.setProp("LoadingData","Loadingdata","","char");r.setProp("NoResultsFound","Noresultsfound","","char");r.setProp("EmptyItemText","Emptyitemtext","GX_EmptyItemText","str");r.setProp("OnlySelectedValues","Onlyselectedvalues","","char");r.setProp("SelectAllText","Selectalltext","","char");r.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");r.setProp("AddNewOptionText","Addnewoptiontext","","str");r.setProp("DropDownOptionsTitleSettingsIcons","Dropdownoptionstitlesettingsicons","","str");r.addV2CFunction("AV11FamCod_Data","vFAMCOD_DATA","SetDropDownOptionsData");r.addC2VFunction(function(n){n.ParentObject.AV11FamCod_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vFAMCOD_DATA",n.ParentObject.AV11FamCod_Data)});r.setProp("Gx Control Type","Gxcontroltype","","int");r.setC2ShowFunction(function(n){n.show()});r.addEventHandler("OnOptionClicked",this.e17701_client);this.setUserControl(r);this.DVPANEL_PANEL1Container=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_PANEL1Container","Dvpanel_panel1","DVPANEL_PANEL1");f=this.DVPANEL_PANEL1Container;f.setProp("Class","Class","","char");f.setProp("Enabled","Enabled",!0,"boolean");f.setProp("Width","Width","100%","str");f.setProp("Height","Height","100","str");f.setProp("AutoWidth","Autowidth",!1,"bool");f.setProp("AutoHeight","Autoheight",!0,"bool");f.setProp("Cls","Cls","PanelFilled Panel_BaseColor","str");f.setProp("ShowHeader","Showheader",!0,"bool");f.setProp("Title","Title","Resumen de Saldos Valorizados","str");f.setProp("Collapsible","Collapsible",!0,"bool");f.setProp("Collapsed","Collapsed",!1,"bool");f.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");f.setProp("IconPosition","Iconposition","Right","str");f.setProp("AutoScroll","Autoscroll",!1,"bool");f.setProp("Visible","Visible",!0,"bool");f.setProp("Gx Control Type","Gxcontroltype","","int");f.setC2ShowFunction(function(n){n.show()});this.setUserControl(f);this.INNEWWINDOWContainer=gx.uc.getNew(this,94,26,"InNewWindow","INNEWWINDOWContainer","Innewwindow","INNEWWINDOW");u=this.INNEWWINDOWContainer;u.setProp("Class","Class","","char");u.setProp("Enabled","Enabled",!0,"boolean");u.setProp("Width","Width","50","str");u.setProp("Height","Height","50","str");u.setProp("Name","Name","","str");u.setDynProp("Target","Target","","str");u.setProp("Fullscreen","Fullscreen",!1,"bool");u.setProp("Location","Location",!0,"bool");u.setProp("MenuBar","Menubar",!0,"bool");u.setProp("Resizable","Resizable",!0,"bool");u.setProp("Scrollbars","Scrollbars",!0,"bool");u.setProp("TitleBar","Titlebar",!0,"bool");u.setProp("ToolBar","Toolbar",!0,"bool");u.setProp("directories","Directories",!0,"bool");u.setProp("status","Status",!0,"bool");u.setProp("copyhistory","Copyhistory",!0,"bool");u.setProp("top","Top","5","str");u.setProp("left","Left","5","str");u.setProp("fitscreen","Fitscreen",!1,"bool");u.setProp("RefreshParentOnClose","Refreshparentonclose",!1,"bool");u.setProp("Targets","Targets","","str");u.setProp("Visible","Visible",!0,"bool");u.setC2ShowFunction(function(n){n.show()});this.setUserControl(u);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"PANEL1",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"UNNAMEDTABLEALMCOD",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"TEXTBLOCKALMCOD",format:0,grid:0,ctrltype:"textblock"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vALMCOD",gxz:"ZV5AlmCod",gxold:"OV5AlmCod",gxvar:"AV5AlmCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"dyncombo",v2v:function(n){n!==undefined&&(gx.O.AV5AlmCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV5AlmCod=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("vALMCOD",gx.O.AV5AlmCod)},c2v:function(){this.val()!==undefined&&(gx.O.AV5AlmCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vALMCOD",",")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"TABLESPLITTEDLINCOD",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"TEXTBLOCKCOMBO_LINCOD",format:0,grid:0,ctrltype:"textblock"};n[32]={id:32,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"TABLESPLITTEDSUBLCOD",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"TEXTBLOCKCOMBO_SUBLCOD",format:0,grid:0,ctrltype:"textblock"};n[40]={id:40,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"TABLESPLITTEDFAMCOD",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"TEXTBLOCKCOMBO_FAMCOD",format:0,grid:0,ctrltype:"textblock"};n[47]={id:47,fld:"",grid:0};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"TABLESPLITTEDPRODCOD",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"TEXTBLOCKPRODCOD",format:0,grid:0,ctrltype:"textblock"};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"TABLEMERGEDPRODCOD",grid:0};n[59]={id:59,fld:"",grid:0};n[60]={id:60,lvl:0,type:"char",len:15,dec:0,sign:!1,pic:"@!",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPRODCOD",gxz:"ZV21ProdCod",gxold:"OV21ProdCod",gxvar:"AV21ProdCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV21ProdCod=n)},v2z:function(n){n!==undefined&&(gx.O.ZV21ProdCod=n)},v2c:function(){gx.fn.setControlValue("vPRODCOD",gx.O.AV21ProdCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV21ProdCod=this.val())},val:function(){return gx.fn.getControlValue("vPRODCOD")},nac:gx.falseFn};n[62]={id:62,fld:"BTNBUSCAR",grid:0,evt:"e16701_client"};n[64]={id:64,fld:"",grid:0};n[65]={id:65,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPRODDSC",gxz:"ZV22ProdDsc",gxold:"OV22ProdDsc",gxvar:"AV22ProdDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV22ProdDsc=n)},v2z:function(n){n!==undefined&&(gx.O.ZV22ProdDsc=n)},v2c:function(){gx.fn.setControlValue("vPRODDSC",gx.O.AV22ProdDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV22ProdDsc=this.val())},val:function(){return gx.fn.getControlValue("vPRODDSC")},nac:gx.falseFn};n[66]={id:66,fld:"",grid:0};n[67]={id:67,fld:"UNNAMEDTABLEJANO",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,fld:"",grid:0};n[70]={id:70,fld:"TEXTBLOCKJANO",format:0,grid:0,ctrltype:"textblock"};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"",grid:0};n[73]={id:73,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vJANO",gxz:"ZV30jAno",gxold:"OV30jAno",gxvar:"AV30jAno",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV30jAno=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV30jAno=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vJANO",gx.O.AV30jAno,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV30jAno=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vJANO",",")},nac:gx.falseFn};n[74]={id:74,fld:"",grid:0};n[75]={id:75,fld:"",grid:0};n[76]={id:76,fld:"UNNAMEDTABLEJMES",grid:0};n[77]={id:77,fld:"",grid:0};n[78]={id:78,fld:"",grid:0};n[79]={id:79,fld:"TEXTBLOCKJMES",format:0,grid:0,ctrltype:"textblock"};n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"",grid:0};n[82]={id:82,lvl:0,type:"int",len:2,dec:0,sign:!1,pic:"Z9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vJMES",gxz:"ZV31jMes",gxold:"OV31jMes",gxvar:"AV31jMes",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV31jMes=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV31jMes=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("vJMES",gx.O.AV31jMes)},c2v:function(){this.val()!==undefined&&(gx.O.AV31jMes=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vJMES",",")},nac:gx.falseFn};n[83]={id:83,fld:"",grid:0};n[84]={id:84,fld:"",grid:0};n[85]={id:85,fld:"",grid:0};n[86]={id:86,fld:"",grid:0};n[87]={id:87,fld:"BTNBTNIMPRIMIR",grid:0,evt:"e12702_client"};n[88]={id:88,fld:"",grid:0};n[89]={id:89,fld:"BTNBTNEXCEL",grid:0,evt:"e13702_client"};n[90]={id:90,fld:"",grid:0};n[91]={id:91,fld:"BTNBTNSALIR",grid:0,evt:"e14702_client"};n[92]={id:92,fld:"",grid:0};n[93]={id:93,fld:"",grid:0};n[95]={id:95,fld:"",grid:0};n[96]={id:96,fld:"",grid:0};n[97]={id:97,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[98]={id:98,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINCOD",gxz:"ZV18LinCod",gxold:"OV18LinCod",gxvar:"AV18LinCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV18LinCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV18LinCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vLINCOD",gx.O.AV18LinCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV18LinCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vLINCOD",",")},nac:gx.falseFn};n[99]={id:99,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSUBLCOD",gxz:"ZV24SubLCod",gxold:"OV24SubLCod",gxvar:"AV24SubLCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV24SubLCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV24SubLCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vSUBLCOD",gx.O.AV24SubLCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV24SubLCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vSUBLCOD",",")},nac:gx.falseFn};n[100]={id:100,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFAMCOD",gxz:"ZV10FamCod",gxold:"OV10FamCod",gxvar:"AV10FamCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV10FamCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV10FamCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vFAMCOD",gx.O.AV10FamCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV10FamCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vFAMCOD",",")},nac:gx.falseFn};this.AV5AlmCod=0;this.ZV5AlmCod=0;this.OV5AlmCod=0;this.AV21ProdCod="";this.ZV21ProdCod="";this.OV21ProdCod="";this.AV22ProdDsc="";this.ZV22ProdDsc="";this.OV22ProdDsc="";this.AV30jAno=0;this.ZV30jAno=0;this.OV30jAno=0;this.AV31jMes=0;this.ZV31jMes=0;this.OV31jMes=0;this.AV18LinCod=0;this.ZV18LinCod=0;this.OV18LinCod=0;this.AV24SubLCod=0;this.ZV24SubLCod=0;this.OV24SubLCod=0;this.AV10FamCod=0;this.ZV10FamCod=0;this.OV10FamCod=0;this.AV5AlmCod=0;this.AV19LinCod_Data=[];this.AV25SubLCod_Data=[];this.AV11FamCod_Data=[];this.AV21ProdCod="";this.AV22ProdDsc="";this.AV30jAno=0;this.AV31jMes=0;this.AV18LinCod=0;this.AV24SubLCod=0;this.AV10FamCod=0;this.A1159LinSts=0;this.A52LinCod=0;this.A1153LinDsc="";this.A1893SublSts=0;this.A51SublCod=0;this.A1892SublDsc="";this.A979FamSts=0;this.A50FamCod=0;this.A977FamDsc="";this.AV32OpcEntrada=0;this.Events={e12702_client:["'DOBTNIMPRIMIR'",!0],e13702_client:["'DOBTNEXCEL'",!0],e14702_client:["'DOBTNSALIR'",!0],e20702_client:["ENTER",!0],e21702_client:["CANCEL",!0],e16701_client:["'DOBTNBUSCAR'",!1],e17701_client:["COMBO_FAMCOD.ONOPTIONCLICKED",!1],e18701_client:["COMBO_SUBLCOD.ONOPTIONCLICKED",!1],e19701_client:["COMBO_LINCOD.ONOPTIONCLICKED",!1]};this.EvtParms.REFRESH=[[{av:"AV32OpcEntrada",fld:"vOPCENTRADA",pic:"9",hsh:!0},{ctrl:"vALMCOD"},{av:"AV5AlmCod",fld:"vALMCOD",pic:"ZZZZZ9"}],[{ctrl:"vALMCOD"},{av:"AV5AlmCod",fld:"vALMCOD",pic:"ZZZZZ9"}]];this.EvtParms["'DOBTNIMPRIMIR'"]=[[{av:"AV32OpcEntrada",fld:"vOPCENTRADA",pic:"9",hsh:!0},{av:"AV18LinCod",fld:"vLINCOD",pic:"ZZZZZ9"},{av:"AV24SubLCod",fld:"vSUBLCOD",pic:"ZZZZZ9"},{av:"AV10FamCod",fld:"vFAMCOD",pic:"ZZZZZ9"},{av:"AV21ProdCod",fld:"vPRODCOD",pic:"@!"},{av:"AV30jAno",fld:"vJANO",pic:"ZZZ9"},{ctrl:"vJMES"},{av:"AV31jMes",fld:"vJMES",pic:"Z9"},{ctrl:"vALMCOD"},{av:"AV5AlmCod",fld:"vALMCOD",pic:"ZZZZZ9"}],[{av:"this.INNEWWINDOWContainer.Target",ctrl:"INNEWWINDOW",prop:"Target"},{ctrl:"vALMCOD"},{av:"AV5AlmCod",fld:"vALMCOD",pic:"ZZZZZ9"}]];this.EvtParms["'DOBTNEXCEL'"]=[[{av:"AV18LinCod",fld:"vLINCOD",pic:"ZZZZZ9"},{av:"AV24SubLCod",fld:"vSUBLCOD",pic:"ZZZZZ9"},{av:"AV10FamCod",fld:"vFAMCOD",pic:"ZZZZZ9"},{av:"AV21ProdCod",fld:"vPRODCOD",pic:"@!"},{av:"AV30jAno",fld:"vJANO",pic:"ZZZ9"},{ctrl:"vJMES"},{av:"AV31jMes",fld:"vJMES",pic:"Z9"},{ctrl:"vALMCOD"},{av:"AV5AlmCod",fld:"vALMCOD",pic:"ZZZZZ9"}],[{ctrl:"vJMES"},{av:"AV31jMes",fld:"vJMES",pic:"Z9"},{av:"AV30jAno",fld:"vJANO",pic:"ZZZ9"},{av:"AV21ProdCod",fld:"vPRODCOD",pic:"@!"},{av:"AV10FamCod",fld:"vFAMCOD",pic:"ZZZZZ9"},{av:"AV24SubLCod",fld:"vSUBLCOD",pic:"ZZZZZ9"},{av:"AV18LinCod",fld:"vLINCOD",pic:"ZZZZZ9"},{ctrl:"vALMCOD"},{av:"AV5AlmCod",fld:"vALMCOD",pic:"ZZZZZ9"}]];this.EvtParms["'DOBTNSALIR'"]=[[{ctrl:"vALMCOD"},{av:"AV5AlmCod",fld:"vALMCOD",pic:"ZZZZZ9"}],[{ctrl:"vALMCOD"},{av:"AV5AlmCod",fld:"vALMCOD",pic:"ZZZZZ9"}]];this.EvtParms["'DOBTNBUSCAR'"]=[[{ctrl:"vALMCOD"},{av:"AV5AlmCod",fld:"vALMCOD",pic:"ZZZZZ9"}],[{av:"AV22ProdDsc",fld:"vPRODDSC",pic:""},{av:"AV21ProdCod",fld:"vPRODCOD",pic:"@!"},{ctrl:"vALMCOD"},{av:"AV5AlmCod",fld:"vALMCOD",pic:"ZZZZZ9"}]];this.EvtParms["COMBO_FAMCOD.ONOPTIONCLICKED"]=[[{av:"this.COMBO_FAMCODContainer.SelectedValue_get",ctrl:"COMBO_FAMCOD",prop:"SelectedValue_get"},{ctrl:"vALMCOD"},{av:"AV5AlmCod",fld:"vALMCOD",pic:"ZZZZZ9"}],[{av:"AV10FamCod",fld:"vFAMCOD",pic:"ZZZZZ9"},{ctrl:"vALMCOD"},{av:"AV5AlmCod",fld:"vALMCOD",pic:"ZZZZZ9"}]];this.EvtParms["COMBO_SUBLCOD.ONOPTIONCLICKED"]=[[{av:"this.COMBO_SUBLCODContainer.SelectedValue_get",ctrl:"COMBO_SUBLCOD",prop:"SelectedValue_get"},{ctrl:"vALMCOD"},{av:"AV5AlmCod",fld:"vALMCOD",pic:"ZZZZZ9"}],[{av:"AV24SubLCod",fld:"vSUBLCOD",pic:"ZZZZZ9"},{ctrl:"vALMCOD"},{av:"AV5AlmCod",fld:"vALMCOD",pic:"ZZZZZ9"}]];this.EvtParms["COMBO_LINCOD.ONOPTIONCLICKED"]=[[{av:"this.COMBO_LINCODContainer.SelectedValue_get",ctrl:"COMBO_LINCOD",prop:"SelectedValue_get"},{ctrl:"vALMCOD"},{av:"AV5AlmCod",fld:"vALMCOD",pic:"ZZZZZ9"}],[{av:"AV18LinCod",fld:"vLINCOD",pic:"ZZZZZ9"},{ctrl:"vALMCOD"},{av:"AV5AlmCod",fld:"vALMCOD",pic:"ZZZZZ9"}]];this.EvtParms.ENTER=[[{ctrl:"vALMCOD"},{av:"AV5AlmCod",fld:"vALMCOD",pic:"ZZZZZ9"}],[{ctrl:"vALMCOD"},{av:"AV5AlmCod",fld:"vALMCOD",pic:"ZZZZZ9"}]];this.setVCMap("AV32OpcEntrada","vOPCENTRADA",0,"int",1,0);this.Initialize();this.setSDTMapping("WWPBaseObjects\\DVB_SDTComboData.Item",{Title:{extr:"T"},Children:{extr:"C"}})});gx.wi(function(){gx.createParentObj(this.produccion.r_resumensaldosvalorizados)})