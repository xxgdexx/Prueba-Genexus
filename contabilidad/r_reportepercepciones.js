gx.evt.autoSkip=!1;gx.define("contabilidad.r_reportepercepciones",!1,function(){var n,t,r,i;this.ServerClass="contabilidad.r_reportepercepciones";this.PackageName="GeneXus.Programs";this.ServerFullClass="contabilidad.r_reportepercepciones.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Validv_Fdesde=function(){return this.validCliEvt("Validv_Fdesde",0,function(){try{var n=gx.util.balloon.getNew("vFDESDE");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV12FDesde)===0||new gx.date.gxdate(this.AV12FDesde).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo FDesde fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Fhasta=function(){return this.validCliEvt("Validv_Fhasta",0,function(){try{var n=gx.util.balloon.getNew("vFHASTA");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV13FHasta)===0||new gx.date.gxdate(this.AV13FHasta).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo FHasta fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e155w1_client=function(){return this.clearMessages(),this.popupOpenUrl(gx.http.formatLink("generales.wwbusquedacliente.aspx",["",""]),["AV6CliCod","AV7CliDsc"]),this.refreshOutputs([{av:"AV7CliDsc",fld:"vCLIDSC",pic:""},{av:"AV6CliCod",fld:"vCLICOD",pic:""},{ctrl:"vTIPO"},{av:"AV16Tipo",fld:"vTIPO",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e165w1_client=function(){return this.clearMessages(),this.AV14TipCCod=gx.num.trunc(gx.num.val(this.COMBO_TIPCCODContainer.SelectedValue_get),0),this.refreshOutputs([{av:"AV14TipCCod",fld:"vTIPCCOD",pic:"ZZZZZ9"},{ctrl:"vTIPO"},{av:"AV16Tipo",fld:"vTIPO",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e125w2_client=function(){return this.executeServerEvent("'DOBTNIMPRIMIR'",!1,null,!1,!1)};this.e135w2_client=function(){return this.executeServerEvent("'DOBTNSALIR'",!1,null,!1,!1)};this.e175w2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e185w2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,26,27,28,29,30,31,32,35,36,38,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,78,79,80,81];this.GXLastCtrlId=81;this.COMBO_TIPCCODContainer=gx.uc.getNew(this,25,0,"BootstrapDropDownOptions","COMBO_TIPCCODContainer","Combo_tipccod","COMBO_TIPCCOD");t=this.COMBO_TIPCCODContainer;t.setProp("Class","Class","","char");t.setProp("IconType","Icontype","Image","str");t.setProp("Icon","Icon","","str");t.setProp("Caption","Caption","","str");t.setProp("Tooltip","Tooltip","","str");t.setProp("Cls","Cls","ExtendedCombo AttributeRealWidth50With","str");t.setDynProp("SelectedValue_set","Selectedvalue_set","","char");t.setProp("SelectedValue_get","Selectedvalue_get","","char");t.setProp("SelectedText_set","Selectedtext_set","","char");t.setProp("SelectedText_get","Selectedtext_get","","char");t.setProp("GAMOAuthToken","Gamoauthtoken","","char");t.setProp("DDOInternalName","Ddointernalname","","char");t.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");t.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");t.setProp("Enabled","Enabled",!0,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");t.setProp("DataListType","Datalisttype","Dynamic","str");t.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");t.setProp("DataListFixedValues","Datalistfixedvalues","","char");t.setProp("IsGridItem","Isgriditem",!1,"bool");t.setProp("HasDescription","Hasdescription",!1,"bool");t.setProp("DataListProc","Datalistproc","","str");t.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");t.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");t.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");t.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");t.setProp("EmptyItem","Emptyitem",!0,"bool");t.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");t.setProp("HTMLTemplate","Htmltemplate","","str");t.setProp("MultipleValuesType","Multiplevaluestype","Text","str");t.setProp("LoadingData","Loadingdata","","char");t.setProp("NoResultsFound","Noresultsfound","","char");t.setProp("EmptyItemText","Emptyitemtext","GX_EmptyItemText","str");t.setProp("OnlySelectedValues","Onlyselectedvalues","","char");t.setProp("SelectAllText","Selectalltext","","char");t.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");t.setProp("AddNewOptionText","Addnewoptiontext","","str");t.setProp("DropDownOptionsTitleSettingsIcons","Dropdownoptionstitlesettingsicons","","str");t.addV2CFunction("AV15TipCCod_Data","vTIPCCOD_DATA","SetDropDownOptionsData");t.addC2VFunction(function(n){n.ParentObject.AV15TipCCod_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vTIPCCOD_DATA",n.ParentObject.AV15TipCCod_Data)});t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("OnOptionClicked",this.e165w1_client);this.setUserControl(t);this.DVPANEL_PANEL1Container=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_PANEL1Container","Dvpanel_panel1","DVPANEL_PANEL1");r=this.DVPANEL_PANEL1Container;r.setProp("Class","Class","","char");r.setProp("Enabled","Enabled",!0,"boolean");r.setProp("Width","Width","100%","str");r.setProp("Height","Height","100","str");r.setProp("AutoWidth","Autowidth",!1,"bool");r.setProp("AutoHeight","Autoheight",!0,"bool");r.setProp("Cls","Cls","PanelFilled Panel_BaseColor","str");r.setProp("ShowHeader","Showheader",!0,"bool");r.setProp("Title","Title","Reporte de Percepciones","str");r.setProp("Collapsible","Collapsible",!0,"bool");r.setProp("Collapsed","Collapsed",!1,"bool");r.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");r.setProp("IconPosition","Iconposition","Right","str");r.setProp("AutoScroll","Autoscroll",!1,"bool");r.setProp("Visible","Visible",!0,"bool");r.setProp("Gx Control Type","Gxcontroltype","","int");r.setC2ShowFunction(function(n){n.show()});this.setUserControl(r);this.INNEWWINDOWContainer=gx.uc.getNew(this,77,36,"InNewWindow","INNEWWINDOWContainer","Innewwindow","INNEWWINDOW");i=this.INNEWWINDOWContainer;i.setProp("Class","Class","","char");i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("Width","Width","50","str");i.setProp("Height","Height","50","str");i.setProp("Name","Name","","str");i.setDynProp("Target","Target","","str");i.setProp("Fullscreen","Fullscreen",!1,"bool");i.setProp("Location","Location",!0,"bool");i.setProp("MenuBar","Menubar",!0,"bool");i.setProp("Resizable","Resizable",!0,"bool");i.setProp("Scrollbars","Scrollbars",!0,"bool");i.setProp("TitleBar","Titlebar",!0,"bool");i.setProp("ToolBar","Toolbar",!0,"bool");i.setProp("directories","Directories",!0,"bool");i.setProp("status","Status",!0,"bool");i.setProp("copyhistory","Copyhistory",!0,"bool");i.setProp("top","Top","5","str");i.setProp("left","Left","5","str");i.setProp("fitscreen","Fitscreen",!1,"bool");i.setProp("RefreshParentOnClose","Refreshparentonclose",!1,"bool");i.setProp("Targets","Targets","","str");i.setProp("Visible","Visible",!0,"bool");i.setC2ShowFunction(function(n){n.show()});this.setUserControl(i);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"PANEL1",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"TABLESPLITTEDTIPCCOD",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"TEXTBLOCKCOMBO_TIPCCOD",format:0,grid:0,ctrltype:"textblock"};n[24]={id:24,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"TABLESPLITTEDCLICOD",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"TEXTBLOCKCLICOD",format:0,grid:0,ctrltype:"textblock"};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"TABLEMERGEDCLICOD",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCLICOD",gxz:"ZV6CliCod",gxold:"OV6CliCod",gxvar:"AV6CliCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6CliCod=n)},v2z:function(n){n!==undefined&&(gx.O.ZV6CliCod=n)},v2c:function(){gx.fn.setControlValue("vCLICOD",gx.O.AV6CliCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6CliCod=this.val())},val:function(){return gx.fn.getControlValue("vCLICOD")},nac:gx.falseFn};n[38]={id:38,fld:"BTNBUSCARCLI",grid:0,evt:"e155w1_client"};n[40]={id:40,fld:"",grid:0};n[41]={id:41,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCLIDSC",gxz:"ZV7CliDsc",gxold:"OV7CliDsc",gxvar:"AV7CliDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7CliDsc=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7CliDsc=n)},v2c:function(){gx.fn.setControlValue("vCLIDSC",gx.O.AV7CliDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7CliDsc=this.val())},val:function(){return gx.fn.getControlValue("vCLIDSC")},nac:gx.falseFn};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"UNNAMEDTABLEFDESDE",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"TEXTBLOCKFDESDE",format:0,grid:0,ctrltype:"textblock"};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"",grid:0};n[50]={id:50,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Fdesde,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFDESDE",gxz:"ZV12FDesde",gxold:"OV12FDesde",gxvar:"AV12FDesde",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[50],ip:[50],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV12FDesde=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV12FDesde=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vFDESDE",gx.O.AV12FDesde,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV12FDesde=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vFDESDE")},nac:gx.falseFn};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"UNNAMEDTABLEFHASTA",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"TEXTBLOCKFHASTA",format:0,grid:0,ctrltype:"textblock"};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Fhasta,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFHASTA",gxz:"ZV13FHasta",gxold:"OV13FHasta",gxvar:"AV13FHasta",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[58],ip:[58],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV13FHasta=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV13FHasta=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vFHASTA",gx.O.AV13FHasta,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV13FHasta=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vFHASTA")},nac:gx.falseFn};n[59]={id:59,fld:"",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"UNNAMEDTABLETIPO",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"",grid:0};n[64]={id:64,fld:"TEXTBLOCKTIPO",format:0,grid:0,ctrltype:"textblock"};n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"",grid:0};n[67]={id:67,lvl:0,type:"char",len:1,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTIPO",gxz:"ZV16Tipo",gxold:"OV16Tipo",gxvar:"AV16Tipo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"radio",v2v:function(n){n!==undefined&&(gx.O.AV16Tipo=n)},v2z:function(n){n!==undefined&&(gx.O.ZV16Tipo=n)},v2c:function(){gx.fn.setRadioValue("vTIPO",gx.O.AV16Tipo)},c2v:function(){this.val()!==undefined&&(gx.O.AV16Tipo=this.val())},val:function(){return gx.fn.getControlValue("vTIPO")},nac:gx.falseFn};n[68]={id:68,fld:"",grid:0};n[69]={id:69,fld:"",grid:0};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"BTNBTNIMPRIMIR",grid:0,evt:"e125w2_client"};n[73]={id:73,fld:"",grid:0};n[74]={id:74,fld:"BTNBTNSALIR",grid:0,evt:"e135w2_client"};n[75]={id:75,fld:"",grid:0};n[76]={id:76,fld:"",grid:0};n[78]={id:78,fld:"",grid:0};n[79]={id:79,fld:"",grid:0};n[80]={id:80,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[81]={id:81,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTIPCCOD",gxz:"ZV14TipCCod",gxold:"OV14TipCCod",gxvar:"AV14TipCCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV14TipCCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV14TipCCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vTIPCCOD",gx.O.AV14TipCCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV14TipCCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vTIPCCOD",",")},nac:gx.falseFn};this.AV6CliCod="";this.ZV6CliCod="";this.OV6CliCod="";this.AV7CliDsc="";this.ZV7CliDsc="";this.OV7CliDsc="";this.AV12FDesde=gx.date.nullDate();this.ZV12FDesde=gx.date.nullDate();this.OV12FDesde=gx.date.nullDate();this.AV13FHasta=gx.date.nullDate();this.ZV13FHasta=gx.date.nullDate();this.OV13FHasta=gx.date.nullDate();this.AV16Tipo="";this.ZV16Tipo="";this.OV16Tipo="";this.AV14TipCCod=0;this.ZV14TipCCod=0;this.OV14TipCCod=0;this.AV15TipCCod_Data=[];this.AV6CliCod="";this.AV7CliDsc="";this.AV12FDesde=gx.date.nullDate();this.AV13FHasta=gx.date.nullDate();this.AV16Tipo="";this.AV14TipCCod=0;this.A1908TipCSts=0;this.A159TipCCod=0;this.A1905TipCDsc="";this.Events={e125w2_client:["'DOBTNIMPRIMIR'",!0],e135w2_client:["'DOBTNSALIR'",!0],e175w2_client:["ENTER",!0],e185w2_client:["CANCEL",!0],e155w1_client:["'DOBTNBUSCARCLI'",!1],e165w1_client:["COMBO_TIPCCOD.ONOPTIONCLICKED",!1]};this.EvtParms.REFRESH=[[{ctrl:"vTIPO"},{av:"AV16Tipo",fld:"vTIPO",pic:""}],[{ctrl:"vTIPO"},{av:"AV16Tipo",fld:"vTIPO",pic:""}]];this.EvtParms["'DOBTNIMPRIMIR'"]=[[{av:"AV14TipCCod",fld:"vTIPCCOD",pic:"ZZZZZ9"},{av:"AV6CliCod",fld:"vCLICOD",pic:""},{av:"AV12FDesde",fld:"vFDESDE",pic:""},{av:"AV13FHasta",fld:"vFHASTA",pic:""},{ctrl:"vTIPO"},{av:"AV16Tipo",fld:"vTIPO",pic:""}],[{av:"this.INNEWWINDOWContainer.Target",ctrl:"INNEWWINDOW",prop:"Target"},{ctrl:"vTIPO"},{av:"AV16Tipo",fld:"vTIPO",pic:""}]];this.EvtParms["'DOBTNSALIR'"]=[[{ctrl:"vTIPO"},{av:"AV16Tipo",fld:"vTIPO",pic:""}],[{ctrl:"vTIPO"},{av:"AV16Tipo",fld:"vTIPO",pic:""}]];this.EvtParms["'DOBTNBUSCARCLI'"]=[[{ctrl:"vTIPO"},{av:"AV16Tipo",fld:"vTIPO",pic:""}],[{av:"AV7CliDsc",fld:"vCLIDSC",pic:""},{av:"AV6CliCod",fld:"vCLICOD",pic:""},{ctrl:"vTIPO"},{av:"AV16Tipo",fld:"vTIPO",pic:""}]];this.EvtParms["COMBO_TIPCCOD.ONOPTIONCLICKED"]=[[{av:"this.COMBO_TIPCCODContainer.SelectedValue_get",ctrl:"COMBO_TIPCCOD",prop:"SelectedValue_get"},{ctrl:"vTIPO"},{av:"AV16Tipo",fld:"vTIPO",pic:""}],[{av:"AV14TipCCod",fld:"vTIPCCOD",pic:"ZZZZZ9"},{ctrl:"vTIPO"},{av:"AV16Tipo",fld:"vTIPO",pic:""}]];this.EvtParms.ENTER=[[{ctrl:"vTIPO"},{av:"AV16Tipo",fld:"vTIPO",pic:""}],[{ctrl:"vTIPO"},{av:"AV16Tipo",fld:"vTIPO",pic:""}]];this.EvtParms.VALIDV_FDESDE=[[{ctrl:"vTIPO"},{av:"AV16Tipo",fld:"vTIPO",pic:""}],[{ctrl:"vTIPO"},{av:"AV16Tipo",fld:"vTIPO",pic:""}]];this.EvtParms.VALIDV_FHASTA=[[{ctrl:"vTIPO"},{av:"AV16Tipo",fld:"vTIPO",pic:""}],[{ctrl:"vTIPO"},{av:"AV16Tipo",fld:"vTIPO",pic:""}]];this.Initialize();this.setSDTMapping("WWPBaseObjects\\DVB_SDTDropDownOptionsTitleSettingsIcons",{Default_fi:{extr:"def"},Filtered_fi:{extr:"fil"},SortedASC_fi:{extr:"asc"},SortedDSC_fi:{extr:"dsc"},FilteredSortedASC_fi:{extr:"fasc"},FilteredSortedDSC_fi:{extr:"fdsc"},OptionSortASC_fi:{extr:"osasc"},OptionSortDSC_fi:{extr:"osdsc"},OptionApplyFilter_fi:{extr:"app"},OptionFilteringData_fi:{extr:"fildata"},OptionCleanFilters_fi:{extr:"cle"},SelectedOption_fi:{extr:"selo"},MultiselOption_fi:{extr:"mul"},MultiselSelOption_fi:{extr:"muls"},TreeviewCollapse_fi:{extr:"tcol"},TreeviewExpand_fi:{extr:"texp"},FixLeft_fi:{extr:"fixl"},FixRight_fi:{extr:"fixr"}});this.setSDTMapping("WWPBaseObjects\\DVB_SDTComboData.Item",{Title:{extr:"T"},Children:{extr:"C"}})});gx.wi(function(){gx.createParentObj(this.contabilidad.r_reportepercepciones)})