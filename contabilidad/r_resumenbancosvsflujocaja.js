gx.evt.autoSkip=!1;gx.define("contabilidad.r_resumenbancosvsflujocaja",!1,function(){var n,t,i,u,r;this.ServerClass="contabilidad.r_resumenbancosvsflujocaja";this.PackageName="GeneXus.Programs";this.ServerFullClass="contabilidad.r_resumenbancosvsflujocaja.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Validv_Fdesde=function(){return this.validCliEvt("Validv_Fdesde",0,function(){try{var n=gx.util.balloon.getNew("vFDESDE");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV11FDesde)===0||new gx.date.gxdate(this.AV11FDesde).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo FDesde fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Fhasta=function(){return this.validCliEvt("Validv_Fhasta",0,function(){try{var n=gx.util.balloon.getNew("vFHASTA");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV12FHasta)===0||new gx.date.gxdate(this.AV12FHasta).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo FHasta fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e144z2_client=function(){return this.executeServerEvent("'DOBTNIMPRIMIR'",!1,null,!1,!1)};this.e154z2_client=function(){return this.executeServerEvent("'DOBTNEXCEL'",!1,null,!1,!1)};this.e164z2_client=function(){return this.executeServerEvent("'DOBTNSALIR'",!1,null,!1,!1)};this.e124z2_client=function(){return this.executeServerEvent("COMBO_BANCUENTA.ONOPTIONCLICKED",!1,null,!0,!0)};this.e114z2_client=function(){return this.executeServerEvent("COMBO_BANCOD.ONOPTIONCLICKED",!1,null,!0,!0)};this.e184z2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e194z2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,26,27,28,29,30,31,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,62,63,64,65,66];this.GXLastCtrlId=66;this.COMBO_BANCODContainer=gx.uc.getNew(this,25,0,"BootstrapDropDownOptions","COMBO_BANCODContainer","Combo_bancod","COMBO_BANCOD");t=this.COMBO_BANCODContainer;t.setProp("Class","Class","","char");t.setProp("IconType","Icontype","Image","str");t.setProp("Icon","Icon","","str");t.setProp("Caption","Caption","","str");t.setProp("Tooltip","Tooltip","","str");t.setProp("Cls","Cls","ExtendedCombo AttributeRealWidth50With","str");t.setDynProp("SelectedValue_set","Selectedvalue_set","","char");t.setProp("SelectedValue_get","Selectedvalue_get","","char");t.setProp("SelectedText_set","Selectedtext_set","","char");t.setProp("SelectedText_get","Selectedtext_get","","char");t.setProp("GAMOAuthToken","Gamoauthtoken","","char");t.setProp("DDOInternalName","Ddointernalname","","char");t.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");t.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");t.setProp("Enabled","Enabled",!0,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");t.setProp("DataListType","Datalisttype","Dynamic","str");t.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");t.setProp("DataListFixedValues","Datalistfixedvalues","","char");t.setProp("IsGridItem","Isgriditem",!1,"bool");t.setProp("HasDescription","Hasdescription",!1,"bool");t.setProp("DataListProc","Datalistproc","","str");t.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");t.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");t.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");t.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");t.setProp("EmptyItem","Emptyitem",!0,"bool");t.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");t.setProp("HTMLTemplate","Htmltemplate","","str");t.setProp("MultipleValuesType","Multiplevaluestype","Text","str");t.setProp("LoadingData","Loadingdata","","char");t.setProp("NoResultsFound","Noresultsfound","","char");t.setProp("EmptyItemText","Emptyitemtext","GX_EmptyItemText","str");t.setProp("OnlySelectedValues","Onlyselectedvalues","","char");t.setProp("SelectAllText","Selectalltext","","char");t.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");t.setProp("AddNewOptionText","Addnewoptiontext","","str");t.addV2CFunction("AV24DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");t.addC2VFunction(function(n){n.ParentObject.AV24DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV24DDO_TitleSettingsIcons)});t.addV2CFunction("AV23BanCod_Data","vBANCOD_DATA","SetDropDownOptionsData");t.addC2VFunction(function(n){n.ParentObject.AV23BanCod_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vBANCOD_DATA",n.ParentObject.AV23BanCod_Data)});t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("OnOptionClicked",this.e114z2_client);this.setUserControl(t);this.COMBO_BANCUENTAContainer=gx.uc.getNew(this,32,0,"BootstrapDropDownOptions","COMBO_BANCUENTAContainer","Combo_bancuenta","COMBO_BANCUENTA");i=this.COMBO_BANCUENTAContainer;i.setProp("Class","Class","","char");i.setProp("IconType","Icontype","Image","str");i.setProp("Icon","Icon","","str");i.setProp("Caption","Caption","","str");i.setProp("Tooltip","Tooltip","","str");i.setProp("Cls","Cls","ExtendedCombo AttributeRealWidth50With","str");i.setDynProp("SelectedValue_set","Selectedvalue_set","","char");i.setProp("SelectedValue_get","Selectedvalue_get","","char");i.setDynProp("SelectedText_set","Selectedtext_set","","char");i.setProp("SelectedText_get","Selectedtext_get","","char");i.setProp("GAMOAuthToken","Gamoauthtoken","","char");i.setProp("DDOInternalName","Ddointernalname","","char");i.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");i.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");i.setProp("Enabled","Enabled",!0,"bool");i.setProp("Visible","Visible",!0,"bool");i.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");i.setProp("DataListType","Datalisttype","Dynamic","str");i.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");i.setProp("DataListFixedValues","Datalistfixedvalues","","char");i.setProp("IsGridItem","Isgriditem",!1,"bool");i.setProp("HasDescription","Hasdescription",!1,"bool");i.setProp("DataListProc","Datalistproc","Contabilidad.R_ResumenBancosVSFlujoCajaLoadDVCombo","str");i.setDynProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");i.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");i.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");i.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");i.setProp("EmptyItem","Emptyitem",!0,"bool");i.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");i.setProp("HTMLTemplate","Htmltemplate","","str");i.setProp("MultipleValuesType","Multiplevaluestype","Text","str");i.setProp("LoadingData","Loadingdata","","str");i.setProp("NoResultsFound","Noresultsfound","","str");i.setProp("EmptyItemText","Emptyitemtext","GX_EmptyItemText","str");i.setProp("OnlySelectedValues","Onlyselectedvalues","","char");i.setProp("SelectAllText","Selectalltext","","char");i.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");i.setProp("AddNewOptionText","Addnewoptiontext","","str");i.addV2CFunction("AV24DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");i.addC2VFunction(function(n){n.ParentObject.AV24DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV24DDO_TitleSettingsIcons)});i.addV2CFunction("AV25BanCuenta_Data","vBANCUENTA_DATA","SetDropDownOptionsData");i.addC2VFunction(function(n){n.ParentObject.AV25BanCuenta_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vBANCUENTA_DATA",n.ParentObject.AV25BanCuenta_Data)});i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});i.addEventHandler("OnOptionClicked",this.e124z2_client);this.setUserControl(i);this.DVPANEL_PANEL1Container=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_PANEL1Container","Dvpanel_panel1","DVPANEL_PANEL1");u=this.DVPANEL_PANEL1Container;u.setProp("Class","Class","","char");u.setProp("Enabled","Enabled",!0,"boolean");u.setProp("Width","Width","100%","str");u.setProp("Height","Height","100","str");u.setProp("AutoWidth","Autowidth",!1,"bool");u.setProp("AutoHeight","Autoheight",!0,"bool");u.setProp("Cls","Cls","PanelFilled Panel_BaseColor","str");u.setProp("ShowHeader","Showheader",!0,"bool");u.setProp("Title","Title","Resumen de Bancos vs Flujo de Caja","str");u.setProp("Collapsible","Collapsible",!0,"bool");u.setProp("Collapsed","Collapsed",!1,"bool");u.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");u.setProp("IconPosition","Iconposition","Right","str");u.setProp("AutoScroll","Autoscroll",!1,"bool");u.setProp("Visible","Visible",!0,"bool");u.setProp("Gx Control Type","Gxcontroltype","","int");u.setC2ShowFunction(function(n){n.show()});this.setUserControl(u);this.INNEWWINDOWContainer=gx.uc.getNew(this,61,41,"InNewWindow","INNEWWINDOWContainer","Innewwindow","INNEWWINDOW");r=this.INNEWWINDOWContainer;r.setProp("Class","Class","","char");r.setProp("Enabled","Enabled",!0,"boolean");r.setProp("Width","Width","50","str");r.setProp("Height","Height","50","str");r.setProp("Name","Name","","str");r.setDynProp("Target","Target","","str");r.setProp("Fullscreen","Fullscreen",!1,"bool");r.setProp("Location","Location",!0,"bool");r.setProp("MenuBar","Menubar",!0,"bool");r.setProp("Resizable","Resizable",!0,"bool");r.setProp("Scrollbars","Scrollbars",!0,"bool");r.setProp("TitleBar","Titlebar",!0,"bool");r.setProp("ToolBar","Toolbar",!0,"bool");r.setProp("directories","Directories",!0,"bool");r.setProp("status","Status",!0,"bool");r.setProp("copyhistory","Copyhistory",!0,"bool");r.setProp("top","Top","5","str");r.setProp("left","Left","5","str");r.setProp("fitscreen","Fitscreen",!1,"bool");r.setProp("RefreshParentOnClose","Refreshparentonclose",!1,"bool");r.setProp("Targets","Targets","","str");r.setProp("Visible","Visible",!0,"bool");r.setC2ShowFunction(function(n){n.show()});this.setUserControl(r);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"PANEL1",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"TABLESPLITTEDBANCOD",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"TEXTBLOCKCOMBO_BANCOD",format:0,grid:0,ctrltype:"textblock"};n[24]={id:24,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"TABLESPLITTEDBANCUENTA",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"TEXTBLOCKCOMBO_BANCUENTA",format:0,grid:0,ctrltype:"textblock"};n[31]={id:31,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"UNNAMEDTABLEFDESDE",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"TEXTBLOCKFDESDE",format:0,grid:0,ctrltype:"textblock"};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Fdesde,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFDESDE",gxz:"ZV11FDesde",gxold:"OV11FDesde",gxvar:"AV11FDesde",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[41],ip:[41],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV11FDesde=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV11FDesde=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vFDESDE",gx.O.AV11FDesde,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV11FDesde=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vFDESDE")},nac:gx.falseFn};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"UNNAMEDTABLEFHASTA",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"TEXTBLOCKFHASTA",format:0,grid:0,ctrltype:"textblock"};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Fhasta,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFHASTA",gxz:"ZV12FHasta",gxold:"OV12FHasta",gxvar:"AV12FHasta",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[49],ip:[49],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV12FHasta=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV12FHasta=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vFHASTA",gx.O.AV12FHasta,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV12FHasta=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vFHASTA")},nac:gx.falseFn};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"BTNBTNIMPRIMIR",grid:0,evt:"e144z2_client"};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"BTNBTNEXCEL",grid:0,evt:"e154z2_client"};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"BTNBTNSALIR",grid:0,evt:"e164z2_client"};n[59]={id:59,fld:"",grid:0};n[60]={id:60,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"",grid:0};n[64]={id:64,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[65]={id:65,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vBANCOD",gxz:"ZV21BanCod",gxold:"OV21BanCod",gxvar:"AV21BanCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV21BanCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV21BanCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vBANCOD",gx.O.AV21BanCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV21BanCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vBANCOD",",")},nac:gx.falseFn};n[66]={id:66,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vBANCUENTA",gxz:"ZV22BanCuenta",gxold:"OV22BanCuenta",gxvar:"AV22BanCuenta",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV22BanCuenta=n)},v2z:function(n){n!==undefined&&(gx.O.ZV22BanCuenta=n)},v2c:function(){gx.fn.setControlValue("vBANCUENTA",gx.O.AV22BanCuenta,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV22BanCuenta=this.val())},val:function(){return gx.fn.getControlValue("vBANCUENTA")},nac:gx.falseFn};this.AV11FDesde=gx.date.nullDate();this.ZV11FDesde=gx.date.nullDate();this.OV11FDesde=gx.date.nullDate();this.AV12FHasta=gx.date.nullDate();this.ZV12FHasta=gx.date.nullDate();this.OV12FHasta=gx.date.nullDate();this.AV21BanCod=0;this.ZV21BanCod=0;this.OV21BanCod=0;this.AV22BanCuenta="";this.ZV22BanCuenta="";this.OV22BanCuenta="";this.AV24DDO_TitleSettingsIcons={Default_fi:"",Filtered_fi:"",SortedASC_fi:"",SortedDSC_fi:"",FilteredSortedASC_fi:"",FilteredSortedDSC_fi:"",OptionSortASC_fi:"",OptionSortDSC_fi:"",OptionApplyFilter_fi:"",OptionFilteringData_fi:"",OptionCleanFilters_fi:"",SelectedOption_fi:"",MultiselOption_fi:"",MultiselSelOption_fi:"",TreeviewCollapse_fi:"",TreeviewExpand_fi:"",FixLeft_fi:"",FixRight_fi:""};this.AV11FDesde=gx.date.nullDate();this.AV12FHasta=gx.date.nullDate();this.AV21BanCod=0;this.AV22BanCuenta="";this.A483BanSts=0;this.A372BanCod=0;this.A482BanDsc="";this.A504CBSts=0;this.A377CBCod="";this.Events={e144z2_client:["'DOBTNIMPRIMIR'",!0],e154z2_client:["'DOBTNEXCEL'",!0],e164z2_client:["'DOBTNSALIR'",!0],e124z2_client:["COMBO_BANCUENTA.ONOPTIONCLICKED",!0],e114z2_client:["COMBO_BANCOD.ONOPTIONCLICKED",!0],e184z2_client:["ENTER",!0],e194z2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[],[]];this.EvtParms["'DOBTNIMPRIMIR'"]=[[{av:"AV21BanCod",fld:"vBANCOD",pic:"ZZZZZ9"},{av:"AV11FDesde",fld:"vFDESDE",pic:""},{av:"AV12FHasta",fld:"vFHASTA",pic:""},{av:"AV22BanCuenta",fld:"vBANCUENTA",pic:""}],[{av:"this.INNEWWINDOWContainer.Target",ctrl:"INNEWWINDOW",prop:"Target"}]];this.EvtParms["'DOBTNEXCEL'"]=[[{av:"AV21BanCod",fld:"vBANCOD",pic:"ZZZZZ9"},{av:"AV11FDesde",fld:"vFDESDE",pic:""},{av:"AV12FHasta",fld:"vFHASTA",pic:""},{av:"AV22BanCuenta",fld:"vBANCUENTA",pic:""}],[{av:"AV22BanCuenta",fld:"vBANCUENTA",pic:""},{av:"AV12FHasta",fld:"vFHASTA",pic:""},{av:"AV11FDesde",fld:"vFDESDE",pic:""},{av:"AV21BanCod",fld:"vBANCOD",pic:"ZZZZZ9"}]];this.EvtParms["'DOBTNSALIR'"]=[[],[]];this.EvtParms["COMBO_BANCUENTA.ONOPTIONCLICKED"]=[[{av:"this.COMBO_BANCUENTAContainer.SelectedValue_get",ctrl:"COMBO_BANCUENTA",prop:"SelectedValue_get"}],[{av:"AV22BanCuenta",fld:"vBANCUENTA",pic:""}]];this.EvtParms["COMBO_BANCOD.ONOPTIONCLICKED"]=[[{av:"AV21BanCod",fld:"vBANCOD",pic:"ZZZZZ9"},{av:"this.COMBO_BANCODContainer.SelectedValue_get",ctrl:"COMBO_BANCOD",prop:"SelectedValue_get"}],[{av:"AV21BanCod",fld:"vBANCOD",pic:"ZZZZZ9"},{av:"AV22BanCuenta",fld:"vBANCUENTA",pic:""},{av:"this.COMBO_BANCUENTAContainer.SelectedValue_set",ctrl:"COMBO_BANCUENTA",prop:"SelectedValue_set"},{av:"this.COMBO_BANCUENTAContainer.SelectedText_set",ctrl:"COMBO_BANCUENTA",prop:"SelectedText_set"}]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALIDV_FDESDE=[[],[]];this.EvtParms.VALIDV_FHASTA=[[],[]];this.Initialize();this.setSDTMapping("WWPBaseObjects\\DVB_SDTDropDownOptionsTitleSettingsIcons",{Default_fi:{extr:"def"},Filtered_fi:{extr:"fil"},SortedASC_fi:{extr:"asc"},SortedDSC_fi:{extr:"dsc"},FilteredSortedASC_fi:{extr:"fasc"},FilteredSortedDSC_fi:{extr:"fdsc"},OptionSortASC_fi:{extr:"osasc"},OptionSortDSC_fi:{extr:"osdsc"},OptionApplyFilter_fi:{extr:"app"},OptionFilteringData_fi:{extr:"fildata"},OptionCleanFilters_fi:{extr:"cle"},SelectedOption_fi:{extr:"selo"},MultiselOption_fi:{extr:"mul"},MultiselSelOption_fi:{extr:"muls"},TreeviewCollapse_fi:{extr:"tcol"},TreeviewExpand_fi:{extr:"texp"},FixLeft_fi:{extr:"fixl"},FixRight_fi:{extr:"fixr"}});this.setSDTMapping("WWPBaseObjects\\DVB_SDTComboData.Item",{Title:{extr:"T"},Children:{extr:"C"}})});gx.wi(function(){gx.createParentObj(this.contabilidad.r_resumenbancosvsflujocaja)})