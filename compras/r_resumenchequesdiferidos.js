gx.evt.autoSkip=!1;gx.define("compras.r_resumenchequesdiferidos",!1,function(){var n,t,i,r,f,u;this.ServerClass="compras.r_resumenchequesdiferidos";this.PackageName="GeneXus.Programs";this.ServerFullClass="compras.r_resumenchequesdiferidos.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV16TipPCod=gx.fn.getIntegerValue("vTIPPCOD",",")};this.Validv_Fdesde=function(){return this.validCliEvt("Validv_Fdesde",0,function(){try{var n=gx.util.balloon.getNew("vFDESDE");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV8Fdesde)===0||new gx.date.gxdate(this.AV8Fdesde).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Fdesde fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e153s1_client=function(){return this.clearMessages(),this.popupOpenUrl(gx.http.formatLink("generales.wwbusquedaproveedor.aspx",["",""]),["AV12PrvCod","AV13PrvDsc"]),this.refreshOutputs([{av:"AV13PrvDsc",fld:"vPRVDSC",pic:""},{av:"AV12PrvCod",fld:"vPRVCOD",pic:"@!"},{ctrl:"vFLAG"},{av:"AV9Flag",fld:"vFLAG",pic:"9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e163s1_client=function(){return this.clearMessages(),this.AV10MonCod=gx.num.trunc(gx.num.val(this.COMBO_MONCODContainer.SelectedValue_get),0),this.refreshOutputs([{av:"AV10MonCod",fld:"vMONCOD",pic:"ZZZZZ9"},{ctrl:"vFLAG"},{av:"AV9Flag",fld:"vFLAG",pic:"9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e173s1_client=function(){return this.clearMessages(),this.AV6EstCod=this.COMBO_ESTCODContainer.SelectedValue_get,this.refreshOutputs([{av:"AV6EstCod",fld:"vESTCOD",pic:""},{ctrl:"vFLAG"},{av:"AV9Flag",fld:"vFLAG",pic:"9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e183s1_client=function(){return this.clearMessages(),this.AV14TprvCod=gx.num.trunc(gx.num.val(this.COMBO_TPRVCODContainer.SelectedValue_get),0),this.refreshOutputs([{av:"AV14TprvCod",fld:"vTPRVCOD",pic:"ZZZZZ9"},{ctrl:"vFLAG"},{av:"AV9Flag",fld:"vFLAG",pic:"9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e123s2_client=function(){return this.executeServerEvent("'DOBTNIMPRIMIR'",!1,null,!1,!1)};this.e133s2_client=function(){return this.executeServerEvent("'DOBTNSALIR'",!1,null,!1,!1)};this.e193s2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e203s2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,26,27,28,29,30,31,33,34,35,36,37,38,39,40,43,44,46,48,49,50,51,52,53,54,55,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,85,86,87,88,89,90];this.GXLastCtrlId=90;this.COMBO_TPRVCODContainer=gx.uc.getNew(this,25,0,"BootstrapDropDownOptions","COMBO_TPRVCODContainer","Combo_tprvcod","COMBO_TPRVCOD");t=this.COMBO_TPRVCODContainer;t.setProp("Class","Class","","char");t.setProp("IconType","Icontype","Image","str");t.setProp("Icon","Icon","","str");t.setProp("Caption","Caption","","str");t.setProp("Tooltip","Tooltip","","str");t.setProp("Cls","Cls","ExtendedCombo AttributeRealWidth50With","str");t.setDynProp("SelectedValue_set","Selectedvalue_set","","char");t.setProp("SelectedValue_get","Selectedvalue_get","","char");t.setProp("SelectedText_set","Selectedtext_set","","char");t.setProp("SelectedText_get","Selectedtext_get","","char");t.setProp("GAMOAuthToken","Gamoauthtoken","","char");t.setProp("DDOInternalName","Ddointernalname","","char");t.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");t.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");t.setProp("Enabled","Enabled",!0,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");t.setProp("DataListType","Datalisttype","Dynamic","str");t.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");t.setProp("DataListFixedValues","Datalistfixedvalues","","char");t.setProp("IsGridItem","Isgriditem",!1,"bool");t.setProp("HasDescription","Hasdescription",!1,"bool");t.setProp("DataListProc","Datalistproc","","str");t.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");t.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");t.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");t.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");t.setProp("EmptyItem","Emptyitem",!0,"bool");t.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");t.setProp("HTMLTemplate","Htmltemplate","","str");t.setProp("MultipleValuesType","Multiplevaluestype","Text","str");t.setProp("LoadingData","Loadingdata","","char");t.setProp("NoResultsFound","Noresultsfound","","char");t.setProp("EmptyItemText","Emptyitemtext","GX_EmptyItemText","str");t.setProp("OnlySelectedValues","Onlyselectedvalues","","char");t.setProp("SelectAllText","Selectalltext","","char");t.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");t.setProp("AddNewOptionText","Addnewoptiontext","","str");t.setProp("DropDownOptionsTitleSettingsIcons","Dropdownoptionstitlesettingsicons","","str");t.addV2CFunction("AV15TprvCod_Data","vTPRVCOD_DATA","SetDropDownOptionsData");t.addC2VFunction(function(n){n.ParentObject.AV15TprvCod_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vTPRVCOD_DATA",n.ParentObject.AV15TprvCod_Data)});t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("OnOptionClicked",this.e183s1_client);this.setUserControl(t);this.COMBO_ESTCODContainer=gx.uc.getNew(this,32,0,"BootstrapDropDownOptions","COMBO_ESTCODContainer","Combo_estcod","COMBO_ESTCOD");i=this.COMBO_ESTCODContainer;i.setProp("Class","Class","","char");i.setProp("IconType","Icontype","Image","str");i.setProp("Icon","Icon","","str");i.setProp("Caption","Caption","","str");i.setProp("Tooltip","Tooltip","","str");i.setProp("Cls","Cls","ExtendedCombo AttributeRealWidth50With","str");i.setDynProp("SelectedValue_set","Selectedvalue_set","","char");i.setProp("SelectedValue_get","Selectedvalue_get","","char");i.setProp("SelectedText_set","Selectedtext_set","","char");i.setProp("SelectedText_get","Selectedtext_get","","char");i.setProp("GAMOAuthToken","Gamoauthtoken","","char");i.setProp("DDOInternalName","Ddointernalname","","char");i.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");i.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");i.setProp("Enabled","Enabled",!0,"bool");i.setProp("Visible","Visible",!0,"bool");i.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");i.setProp("DataListType","Datalisttype","Dynamic","str");i.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");i.setProp("DataListFixedValues","Datalistfixedvalues","","char");i.setProp("IsGridItem","Isgriditem",!1,"bool");i.setProp("HasDescription","Hasdescription",!1,"bool");i.setProp("DataListProc","Datalistproc","","str");i.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");i.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");i.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");i.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");i.setProp("EmptyItem","Emptyitem",!0,"bool");i.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");i.setProp("HTMLTemplate","Htmltemplate","","str");i.setProp("MultipleValuesType","Multiplevaluestype","Text","str");i.setProp("LoadingData","Loadingdata","","char");i.setProp("NoResultsFound","Noresultsfound","","char");i.setProp("EmptyItemText","Emptyitemtext","GX_EmptyItemText","str");i.setProp("OnlySelectedValues","Onlyselectedvalues","","char");i.setProp("SelectAllText","Selectalltext","","char");i.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");i.setProp("AddNewOptionText","Addnewoptiontext","","str");i.setProp("DropDownOptionsTitleSettingsIcons","Dropdownoptionstitlesettingsicons","","str");i.addV2CFunction("AV7EstCod_Data","vESTCOD_DATA","SetDropDownOptionsData");i.addC2VFunction(function(n){n.ParentObject.AV7EstCod_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vESTCOD_DATA",n.ParentObject.AV7EstCod_Data)});i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});i.addEventHandler("OnOptionClicked",this.e173s1_client);this.setUserControl(i);this.COMBO_MONCODContainer=gx.uc.getNew(this,56,44,"BootstrapDropDownOptions","COMBO_MONCODContainer","Combo_moncod","COMBO_MONCOD");r=this.COMBO_MONCODContainer;r.setProp("Class","Class","","char");r.setProp("IconType","Icontype","Image","str");r.setProp("Icon","Icon","","str");r.setProp("Caption","Caption","","str");r.setProp("Tooltip","Tooltip","","str");r.setProp("Cls","Cls","ExtendedCombo Attribute","str");r.setDynProp("SelectedValue_set","Selectedvalue_set","","char");r.setProp("SelectedValue_get","Selectedvalue_get","","char");r.setProp("SelectedText_set","Selectedtext_set","","char");r.setProp("SelectedText_get","Selectedtext_get","","char");r.setProp("GAMOAuthToken","Gamoauthtoken","","char");r.setProp("DDOInternalName","Ddointernalname","","char");r.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");r.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");r.setProp("Enabled","Enabled",!0,"bool");r.setProp("Visible","Visible",!0,"bool");r.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");r.setProp("DataListType","Datalisttype","Dynamic","str");r.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");r.setProp("DataListFixedValues","Datalistfixedvalues","","char");r.setProp("IsGridItem","Isgriditem",!1,"bool");r.setProp("HasDescription","Hasdescription",!1,"bool");r.setProp("DataListProc","Datalistproc","","str");r.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");r.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");r.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");r.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");r.setProp("EmptyItem","Emptyitem",!0,"bool");r.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");r.setProp("HTMLTemplate","Htmltemplate","","str");r.setProp("MultipleValuesType","Multiplevaluestype","Text","str");r.setProp("LoadingData","Loadingdata","","char");r.setProp("NoResultsFound","Noresultsfound","","char");r.setProp("EmptyItemText","Emptyitemtext","GX_EmptyItemText","str");r.setProp("OnlySelectedValues","Onlyselectedvalues","","char");r.setProp("SelectAllText","Selectalltext","","char");r.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");r.setProp("AddNewOptionText","Addnewoptiontext","","str");r.setProp("DropDownOptionsTitleSettingsIcons","Dropdownoptionstitlesettingsicons","","str");r.addV2CFunction("AV11MonCod_Data","vMONCOD_DATA","SetDropDownOptionsData");r.addC2VFunction(function(n){n.ParentObject.AV11MonCod_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vMONCOD_DATA",n.ParentObject.AV11MonCod_Data)});r.setProp("Gx Control Type","Gxcontroltype","","int");r.setC2ShowFunction(function(n){n.show()});r.addEventHandler("OnOptionClicked",this.e163s1_client);this.setUserControl(r);this.DVPANEL_PANEL1Container=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_PANEL1Container","Dvpanel_panel1","DVPANEL_PANEL1");f=this.DVPANEL_PANEL1Container;f.setProp("Class","Class","","char");f.setProp("Enabled","Enabled",!0,"boolean");f.setProp("Width","Width","100%","str");f.setProp("Height","Height","100","str");f.setProp("AutoWidth","Autowidth",!1,"bool");f.setProp("AutoHeight","Autoheight",!0,"bool");f.setProp("Cls","Cls","PanelFilled Panel_BaseColor","str");f.setProp("ShowHeader","Showheader",!0,"bool");f.setProp("Title","Title","Resumen de Cheques Diferidos por periodos","str");f.setProp("Collapsible","Collapsible",!0,"bool");f.setProp("Collapsed","Collapsed",!1,"bool");f.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");f.setProp("IconPosition","Iconposition","Right","str");f.setProp("AutoScroll","Autoscroll",!1,"bool");f.setProp("Visible","Visible",!0,"bool");f.setProp("Gx Control Type","Gxcontroltype","","int");f.setC2ShowFunction(function(n){n.show()});this.setUserControl(f);this.INNEWWINDOWContainer=gx.uc.getNew(this,84,44,"InNewWindow","INNEWWINDOWContainer","Innewwindow","INNEWWINDOW");u=this.INNEWWINDOWContainer;u.setProp("Class","Class","","char");u.setProp("Enabled","Enabled",!0,"boolean");u.setProp("Width","Width","50","str");u.setProp("Height","Height","50","str");u.setProp("Name","Name","","str");u.setDynProp("Target","Target","","str");u.setProp("Fullscreen","Fullscreen",!1,"bool");u.setProp("Location","Location",!0,"bool");u.setProp("MenuBar","Menubar",!0,"bool");u.setProp("Resizable","Resizable",!0,"bool");u.setProp("Scrollbars","Scrollbars",!0,"bool");u.setProp("TitleBar","Titlebar",!0,"bool");u.setProp("ToolBar","Toolbar",!0,"bool");u.setProp("directories","Directories",!0,"bool");u.setProp("status","Status",!0,"bool");u.setProp("copyhistory","Copyhistory",!0,"bool");u.setProp("top","Top","5","str");u.setProp("left","Left","5","str");u.setProp("fitscreen","Fitscreen",!1,"bool");u.setProp("RefreshParentOnClose","Refreshparentonclose",!1,"bool");u.setProp("Targets","Targets","","str");u.setProp("Visible","Visible",!0,"bool");u.setC2ShowFunction(function(n){n.show()});this.setUserControl(u);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"PANEL1",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"TABLESPLITTEDTPRVCOD",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"TEXTBLOCKCOMBO_TPRVCOD",format:0,grid:0,ctrltype:"textblock"};n[24]={id:24,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"TABLESPLITTEDESTCOD",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"TEXTBLOCKCOMBO_ESTCOD",format:0,grid:0,ctrltype:"textblock"};n[31]={id:31,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"TABLESPLITTEDPRVCOD",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"TEXTBLOCKPRVCOD",format:0,grid:0,ctrltype:"textblock"};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"TABLEMERGEDPRVCOD",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,lvl:0,type:"char",len:20,dec:0,sign:!1,pic:"@!",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPRVCOD",gxz:"ZV12PrvCod",gxold:"OV12PrvCod",gxvar:"AV12PrvCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV12PrvCod=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12PrvCod=n)},v2c:function(){gx.fn.setControlValue("vPRVCOD",gx.O.AV12PrvCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV12PrvCod=this.val())},val:function(){return gx.fn.getControlValue("vPRVCOD")},nac:gx.falseFn};n[46]={id:46,fld:"BTNBUSCAR",grid:0,evt:"e153s1_client"};n[48]={id:48,fld:"",grid:0};n[49]={id:49,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPRVDSC",gxz:"ZV13PrvDsc",gxold:"OV13PrvDsc",gxvar:"AV13PrvDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV13PrvDsc=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13PrvDsc=n)},v2c:function(){gx.fn.setControlValue("vPRVDSC",gx.O.AV13PrvDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV13PrvDsc=this.val())},val:function(){return gx.fn.getControlValue("vPRVDSC")},nac:gx.falseFn};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"TABLESPLITTEDMONCOD",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"TEXTBLOCKCOMBO_MONCOD",format:0,grid:0,ctrltype:"textblock"};n[55]={id:55,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,fld:"UNNAMEDTABLEFLAG",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"TEXTBLOCKFLAG",format:0,grid:0,ctrltype:"textblock"};n[63]={id:63,fld:"",grid:0};n[64]={id:64,fld:"",grid:0};n[65]={id:65,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFLAG",gxz:"ZV9Flag",gxold:"OV9Flag",gxvar:"AV9Flag",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"radio",v2v:function(n){n!==undefined&&(gx.O.AV9Flag=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV9Flag=gx.num.intval(n))},v2c:function(){gx.fn.setRadioValue("vFLAG",gx.O.AV9Flag)},c2v:function(){this.val()!==undefined&&(gx.O.AV9Flag=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vFLAG",",")},nac:gx.falseFn};n[66]={id:66,fld:"",grid:0};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"UNNAMEDTABLEFDESDE",grid:0};n[69]={id:69,fld:"",grid:0};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"TEXTBLOCKFDESDE",format:0,grid:0,ctrltype:"textblock"};n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"",grid:0};n[74]={id:74,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Fdesde,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFDESDE",gxz:"ZV8Fdesde",gxold:"OV8Fdesde",gxvar:"AV8Fdesde",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[74],ip:[74],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8Fdesde=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV8Fdesde=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vFDESDE",gx.O.AV8Fdesde,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8Fdesde=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vFDESDE")},nac:gx.falseFn};n[75]={id:75,fld:"",grid:0};n[76]={id:76,fld:"",grid:0};n[77]={id:77,fld:"",grid:0};n[78]={id:78,fld:"",grid:0};n[79]={id:79,fld:"BTNBTNIMPRIMIR",grid:0,evt:"e123s2_client"};n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"BTNBTNSALIR",grid:0,evt:"e133s2_client"};n[82]={id:82,fld:"",grid:0};n[83]={id:83,fld:"",grid:0};n[85]={id:85,fld:"",grid:0};n[86]={id:86,fld:"",grid:0};n[87]={id:87,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[88]={id:88,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTPRVCOD",gxz:"ZV14TprvCod",gxold:"OV14TprvCod",gxvar:"AV14TprvCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV14TprvCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV14TprvCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vTPRVCOD",gx.O.AV14TprvCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV14TprvCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vTPRVCOD",",")},nac:gx.falseFn};n[89]={id:89,lvl:0,type:"char",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vESTCOD",gxz:"ZV6EstCod",gxold:"OV6EstCod",gxvar:"AV6EstCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6EstCod=n)},v2z:function(n){n!==undefined&&(gx.O.ZV6EstCod=n)},v2c:function(){gx.fn.setControlValue("vESTCOD",gx.O.AV6EstCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6EstCod=this.val())},val:function(){return gx.fn.getControlValue("vESTCOD")},nac:gx.falseFn};n[90]={id:90,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vMONCOD",gxz:"ZV10MonCod",gxold:"OV10MonCod",gxvar:"AV10MonCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV10MonCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV10MonCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vMONCOD",gx.O.AV10MonCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV10MonCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vMONCOD",",")},nac:gx.falseFn};this.AV12PrvCod="";this.ZV12PrvCod="";this.OV12PrvCod="";this.AV13PrvDsc="";this.ZV13PrvDsc="";this.OV13PrvDsc="";this.AV9Flag=0;this.ZV9Flag=0;this.OV9Flag=0;this.AV8Fdesde=gx.date.nullDate();this.ZV8Fdesde=gx.date.nullDate();this.OV8Fdesde=gx.date.nullDate();this.AV14TprvCod=0;this.ZV14TprvCod=0;this.OV14TprvCod=0;this.AV6EstCod="";this.ZV6EstCod="";this.OV6EstCod="";this.AV10MonCod=0;this.ZV10MonCod=0;this.OV10MonCod=0;this.AV15TprvCod_Data=[];this.AV7EstCod_Data=[];this.AV12PrvCod="";this.AV13PrvDsc="";this.AV11MonCod_Data=[];this.AV9Flag=0;this.AV8Fdesde=gx.date.nullDate();this.AV14TprvCod=0;this.AV6EstCod="";this.AV10MonCod=0;this.A1942TprvSts=0;this.A298TprvCod=0;this.A1941TprvDsc="";this.A975EstSts=0;this.A140EstCod="";this.A602EstDsc="";this.A1235MonSts=0;this.A180MonCod=0;this.A1234MonDsc="";this.AV16TipPCod=0;this.Events={e123s2_client:["'DOBTNIMPRIMIR'",!0],e133s2_client:["'DOBTNSALIR'",!0],e193s2_client:["ENTER",!0],e203s2_client:["CANCEL",!0],e153s1_client:["'DOBTNBUSCAR'",!1],e163s1_client:["COMBO_MONCOD.ONOPTIONCLICKED",!1],e173s1_client:["COMBO_ESTCOD.ONOPTIONCLICKED",!1],e183s1_client:["COMBO_TPRVCOD.ONOPTIONCLICKED",!1]};this.EvtParms.REFRESH=[[{av:"AV16TipPCod",fld:"vTIPPCOD",pic:"ZZZZZ9",hsh:!0},{ctrl:"vFLAG"},{av:"AV9Flag",fld:"vFLAG",pic:"9"}],[{ctrl:"vFLAG"},{av:"AV9Flag",fld:"vFLAG",pic:"9"}]];this.EvtParms["'DOBTNIMPRIMIR'"]=[[{av:"AV16TipPCod",fld:"vTIPPCOD",pic:"ZZZZZ9",hsh:!0},{av:"AV12PrvCod",fld:"vPRVCOD",pic:"@!"},{av:"AV10MonCod",fld:"vMONCOD",pic:"ZZZZZ9"},{av:"AV8Fdesde",fld:"vFDESDE",pic:""},{ctrl:"vFLAG"},{av:"AV9Flag",fld:"vFLAG",pic:"9"}],[{av:"this.INNEWWINDOWContainer.Target",ctrl:"INNEWWINDOW",prop:"Target"},{ctrl:"vFLAG"},{av:"AV9Flag",fld:"vFLAG",pic:"9"}]];this.EvtParms["'DOBTNSALIR'"]=[[{ctrl:"vFLAG"},{av:"AV9Flag",fld:"vFLAG",pic:"9"}],[{ctrl:"vFLAG"},{av:"AV9Flag",fld:"vFLAG",pic:"9"}]];this.EvtParms["'DOBTNBUSCAR'"]=[[{ctrl:"vFLAG"},{av:"AV9Flag",fld:"vFLAG",pic:"9"}],[{av:"AV13PrvDsc",fld:"vPRVDSC",pic:""},{av:"AV12PrvCod",fld:"vPRVCOD",pic:"@!"},{ctrl:"vFLAG"},{av:"AV9Flag",fld:"vFLAG",pic:"9"}]];this.EvtParms["COMBO_MONCOD.ONOPTIONCLICKED"]=[[{av:"this.COMBO_MONCODContainer.SelectedValue_get",ctrl:"COMBO_MONCOD",prop:"SelectedValue_get"},{ctrl:"vFLAG"},{av:"AV9Flag",fld:"vFLAG",pic:"9"}],[{av:"AV10MonCod",fld:"vMONCOD",pic:"ZZZZZ9"},{ctrl:"vFLAG"},{av:"AV9Flag",fld:"vFLAG",pic:"9"}]];this.EvtParms["COMBO_ESTCOD.ONOPTIONCLICKED"]=[[{av:"this.COMBO_ESTCODContainer.SelectedValue_get",ctrl:"COMBO_ESTCOD",prop:"SelectedValue_get"},{ctrl:"vFLAG"},{av:"AV9Flag",fld:"vFLAG",pic:"9"}],[{av:"AV6EstCod",fld:"vESTCOD",pic:""},{ctrl:"vFLAG"},{av:"AV9Flag",fld:"vFLAG",pic:"9"}]];this.EvtParms["COMBO_TPRVCOD.ONOPTIONCLICKED"]=[[{av:"this.COMBO_TPRVCODContainer.SelectedValue_get",ctrl:"COMBO_TPRVCOD",prop:"SelectedValue_get"},{ctrl:"vFLAG"},{av:"AV9Flag",fld:"vFLAG",pic:"9"}],[{av:"AV14TprvCod",fld:"vTPRVCOD",pic:"ZZZZZ9"},{ctrl:"vFLAG"},{av:"AV9Flag",fld:"vFLAG",pic:"9"}]];this.EvtParms.ENTER=[[{ctrl:"vFLAG"},{av:"AV9Flag",fld:"vFLAG",pic:"9"}],[{ctrl:"vFLAG"},{av:"AV9Flag",fld:"vFLAG",pic:"9"}]];this.EvtParms.VALIDV_FDESDE=[[{ctrl:"vFLAG"},{av:"AV9Flag",fld:"vFLAG",pic:"9"}],[{ctrl:"vFLAG"},{av:"AV9Flag",fld:"vFLAG",pic:"9"}]];this.setVCMap("AV16TipPCod","vTIPPCOD",0,"int",6,0);this.Initialize();this.setSDTMapping("WWPBaseObjects\\DVB_SDTComboData.Item",{Title:{extr:"T"},Children:{extr:"C"}})});gx.wi(function(){gx.createParentObj(this.compras.r_resumenchequesdiferidos)})