gx.evt.autoSkip=!1;gx.define("contabilidad.r_resumenanualcentrocostos",!1,function(){var n,t,r,i;this.ServerClass="contabilidad.r_resumenanualcentrocostos";this.PackageName="GeneXus.Programs";this.ServerFullClass="contabilidad.r_resumenanualcentrocostos.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.e18641_client=function(){return this.clearMessages(),this.popupOpenUrl(gx.http.formatLink("generales.wwbusquedaplancuenta.aspx",[this.AV10cCuenta1,""]),["AV10cCuenta1","AV8cCueDsc1"]),this.refreshOutputs([{av:"AV8cCueDsc1",fld:"vCCUEDSC1",pic:""},{av:"AV10cCuenta1",fld:"vCCUENTA1",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e17641_client=function(){return this.clearMessages(),this.popupOpenUrl(gx.http.formatLink("generales.wwbusquedaplancuenta.aspx",[this.AV11cCuenta2,""]),["AV11cCuenta2","AV9cCueDsc2"]),this.refreshOutputs([{av:"AV9cCueDsc2",fld:"vCCUEDSC2",pic:""},{av:"AV11cCuenta2",fld:"vCCUENTA2",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e19641_client=function(){return this.clearMessages(),this.AV6cCosto=this.COMBO_CCOSTOContainer.SelectedValue_get,this.refreshOutputs([{av:"AV6cCosto",fld:"vCCOSTO",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e12642_client=function(){return this.executeServerEvent("'DOBTNIMPRIMIR'",!1,null,!1,!1)};this.e13642_client=function(){return this.executeServerEvent("'DOBTNEXCEL'",!1,null,!1,!1)};this.e14642_client=function(){return this.executeServerEvent("'DOBTNEXCEL2'",!1,null,!1,!1)};this.e15642_client=function(){return this.executeServerEvent("'DOBTNSALIR'",!1,null,!1,!1)};this.e20642_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e21642_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,34,35,36,37,38,39,40,41,44,45,47,49,50,51,52,53,54,55,56,57,60,61,63,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,81,82,83,84];this.GXLastCtrlId=84;this.COMBO_CCOSTOContainer=gx.uc.getNew(this,33,26,"BootstrapDropDownOptions","COMBO_CCOSTOContainer","Combo_ccosto","COMBO_CCOSTO");t=this.COMBO_CCOSTOContainer;t.setProp("Class","Class","","char");t.setProp("IconType","Icontype","Image","str");t.setProp("Icon","Icon","","str");t.setProp("Caption","Caption","","str");t.setProp("Tooltip","Tooltip","","str");t.setProp("Cls","Cls","ExtendedCombo AttributeRealWidth50With","str");t.setDynProp("SelectedValue_set","Selectedvalue_set","","char");t.setProp("SelectedValue_get","Selectedvalue_get","","char");t.setProp("SelectedText_set","Selectedtext_set","","char");t.setProp("SelectedText_get","Selectedtext_get","","char");t.setProp("GAMOAuthToken","Gamoauthtoken","","char");t.setProp("DDOInternalName","Ddointernalname","","char");t.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");t.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");t.setProp("Enabled","Enabled",!0,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");t.setProp("DataListType","Datalisttype","Dynamic","str");t.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");t.setProp("DataListFixedValues","Datalistfixedvalues","","char");t.setProp("IsGridItem","Isgriditem",!1,"bool");t.setProp("HasDescription","Hasdescription",!1,"bool");t.setProp("DataListProc","Datalistproc","","str");t.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");t.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");t.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");t.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");t.setProp("EmptyItem","Emptyitem",!0,"bool");t.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");t.setProp("HTMLTemplate","Htmltemplate","","str");t.setProp("MultipleValuesType","Multiplevaluestype","Text","str");t.setProp("LoadingData","Loadingdata","","char");t.setProp("NoResultsFound","Noresultsfound","","char");t.setProp("EmptyItemText","Emptyitemtext","GX_EmptyItemText","str");t.setProp("OnlySelectedValues","Onlyselectedvalues","","char");t.setProp("SelectAllText","Selectalltext","","char");t.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");t.setProp("AddNewOptionText","Addnewoptiontext","","str");t.setProp("DropDownOptionsTitleSettingsIcons","Dropdownoptionstitlesettingsicons","","str");t.addV2CFunction("AV7cCosto_Data","vCCOSTO_DATA","SetDropDownOptionsData");t.addC2VFunction(function(n){n.ParentObject.AV7cCosto_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vCCOSTO_DATA",n.ParentObject.AV7cCosto_Data)});t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("OnOptionClicked",this.e19641_client);this.setUserControl(t);this.DVPANEL_PANEL1Container=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_PANEL1Container","Dvpanel_panel1","DVPANEL_PANEL1");r=this.DVPANEL_PANEL1Container;r.setProp("Class","Class","","char");r.setProp("Enabled","Enabled",!0,"boolean");r.setProp("Width","Width","100%","str");r.setProp("Height","Height","100","str");r.setProp("AutoWidth","Autowidth",!1,"bool");r.setProp("AutoHeight","Autoheight",!0,"bool");r.setProp("Cls","Cls","PanelFilled Panel_BaseColor","str");r.setProp("ShowHeader","Showheader",!0,"bool");r.setProp("Title","Title","Resumen Anual por Centro de Costos","str");r.setProp("Collapsible","Collapsible",!0,"bool");r.setProp("Collapsed","Collapsed",!1,"bool");r.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");r.setProp("IconPosition","Iconposition","Right","str");r.setProp("AutoScroll","Autoscroll",!1,"bool");r.setProp("Visible","Visible",!0,"bool");r.setProp("Gx Control Type","Gxcontroltype","","int");r.setC2ShowFunction(function(n){n.show()});this.setUserControl(r);this.INNEWWINDOWContainer=gx.uc.getNew(this,80,26,"InNewWindow","INNEWWINDOWContainer","Innewwindow","INNEWWINDOW");i=this.INNEWWINDOWContainer;i.setProp("Class","Class","","char");i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("Width","Width","50","str");i.setProp("Height","Height","50","str");i.setProp("Name","Name","","str");i.setDynProp("Target","Target","","str");i.setProp("Fullscreen","Fullscreen",!1,"bool");i.setProp("Location","Location",!0,"bool");i.setProp("MenuBar","Menubar",!0,"bool");i.setProp("Resizable","Resizable",!0,"bool");i.setProp("Scrollbars","Scrollbars",!0,"bool");i.setProp("TitleBar","Titlebar",!0,"bool");i.setProp("ToolBar","Toolbar",!0,"bool");i.setProp("directories","Directories",!0,"bool");i.setProp("status","Status",!0,"bool");i.setProp("copyhistory","Copyhistory",!0,"bool");i.setProp("top","Top","5","str");i.setProp("left","Left","5","str");i.setProp("fitscreen","Fitscreen",!1,"bool");i.setProp("RefreshParentOnClose","Refreshparentonclose",!1,"bool");i.setProp("Targets","Targets","","str");i.setProp("Visible","Visible",!0,"bool");i.setC2ShowFunction(function(n){n.show()});this.setUserControl(i);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"PANEL1",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"UNNAMEDTABLEANO",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"TEXTBLOCKANO",format:0,grid:0,ctrltype:"textblock"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vANO",gxz:"ZV5Ano",gxold:"OV5Ano",gxvar:"AV5Ano",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV5Ano=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV5Ano=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vANO",gx.O.AV5Ano,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV5Ano=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vANO",",")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"TABLESPLITTEDCCOSTO",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"TEXTBLOCKCOMBO_CCOSTO",format:0,grid:0,ctrltype:"textblock"};n[32]={id:32,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"TABLESPLITTEDCCUENTA1",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"TEXTBLOCKCCUENTA1",format:0,grid:0,ctrltype:"textblock"};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"TABLEMERGEDCCUENTA1",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,lvl:0,type:"char",len:15,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCCUENTA1",gxz:"ZV10cCuenta1",gxold:"OV10cCuenta1",gxvar:"AV10cCuenta1",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV10cCuenta1=n)},v2z:function(n){n!==undefined&&(gx.O.ZV10cCuenta1=n)},v2c:function(){gx.fn.setControlValue("vCCUENTA1",gx.O.AV10cCuenta1,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV10cCuenta1=this.val())},val:function(){return gx.fn.getControlValue("vCCUENTA1")},nac:gx.falseFn};n[47]={id:47,fld:"BTNBUSCARCUE",grid:0,evt:"e18641_client"};n[49]={id:49,fld:"",grid:0};n[50]={id:50,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCCUEDSC1",gxz:"ZV8cCueDsc1",gxold:"OV8cCueDsc1",gxvar:"AV8cCueDsc1",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8cCueDsc1=n)},v2z:function(n){n!==undefined&&(gx.O.ZV8cCueDsc1=n)},v2c:function(){gx.fn.setControlValue("vCCUEDSC1",gx.O.AV8cCueDsc1,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8cCueDsc1=this.val())},val:function(){return gx.fn.getControlValue("vCCUEDSC1")},nac:gx.falseFn};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"TABLESPLITTEDCCUENTA2",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"TEXTBLOCKCCUENTA2",format:0,grid:0,ctrltype:"textblock"};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"TABLEMERGEDCCUENTA2",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,lvl:0,type:"char",len:15,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCCUENTA2",gxz:"ZV11cCuenta2",gxold:"OV11cCuenta2",gxvar:"AV11cCuenta2",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV11cCuenta2=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11cCuenta2=n)},v2c:function(){gx.fn.setControlValue("vCCUENTA2",gx.O.AV11cCuenta2,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV11cCuenta2=this.val())},val:function(){return gx.fn.getControlValue("vCCUENTA2")},nac:gx.falseFn};n[63]={id:63,fld:"BTNBUSCARCUE2",grid:0,evt:"e17641_client"};n[65]={id:65,fld:"",grid:0};n[66]={id:66,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCCUEDSC2",gxz:"ZV9cCueDsc2",gxold:"OV9cCueDsc2",gxvar:"AV9cCueDsc2",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV9cCueDsc2=n)},v2z:function(n){n!==undefined&&(gx.O.ZV9cCueDsc2=n)},v2c:function(){gx.fn.setControlValue("vCCUEDSC2",gx.O.AV9cCueDsc2,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV9cCueDsc2=this.val())},val:function(){return gx.fn.getControlValue("vCCUEDSC2")},nac:gx.falseFn};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,fld:"",grid:0};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"BTNBTNIMPRIMIR",grid:0,evt:"e12642_client"};n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"BTNBTNEXCEL",grid:0,evt:"e13642_client"};n[74]={id:74,fld:"",grid:0};n[75]={id:75,fld:"BTNBTNEXCEL2",grid:0,evt:"e14642_client"};n[76]={id:76,fld:"",grid:0};n[77]={id:77,fld:"BTNBTNSALIR",grid:0,evt:"e15642_client"};n[78]={id:78,fld:"",grid:0};n[79]={id:79,fld:"",grid:0};n[81]={id:81,fld:"",grid:0};n[82]={id:82,fld:"",grid:0};n[83]={id:83,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[84]={id:84,lvl:0,type:"char",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCCOSTO",gxz:"ZV6cCosto",gxold:"OV6cCosto",gxvar:"AV6cCosto",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6cCosto=n)},v2z:function(n){n!==undefined&&(gx.O.ZV6cCosto=n)},v2c:function(){gx.fn.setControlValue("vCCOSTO",gx.O.AV6cCosto,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6cCosto=this.val())},val:function(){return gx.fn.getControlValue("vCCOSTO")},nac:gx.falseFn};this.AV5Ano=0;this.ZV5Ano=0;this.OV5Ano=0;this.AV10cCuenta1="";this.ZV10cCuenta1="";this.OV10cCuenta1="";this.AV8cCueDsc1="";this.ZV8cCueDsc1="";this.OV8cCueDsc1="";this.AV11cCuenta2="";this.ZV11cCuenta2="";this.OV11cCuenta2="";this.AV9cCueDsc2="";this.ZV9cCueDsc2="";this.OV9cCueDsc2="";this.AV6cCosto="";this.ZV6cCosto="";this.OV6cCosto="";this.AV5Ano=0;this.AV7cCosto_Data=[];this.AV10cCuenta1="";this.AV8cCueDsc1="";this.AV11cCuenta2="";this.AV9cCueDsc2="";this.AV6cCosto="";this.A762COSSts=0;this.A79COSCod="";this.A761COSDsc="";this.Events={e12642_client:["'DOBTNIMPRIMIR'",!0],e13642_client:["'DOBTNEXCEL'",!0],e14642_client:["'DOBTNEXCEL2'",!0],e15642_client:["'DOBTNSALIR'",!0],e20642_client:["ENTER",!0],e21642_client:["CANCEL",!0],e18641_client:["'DOBTNBUSCARCUE'",!1],e17641_client:["'DOBTNBUSCARCUE2'",!1],e19641_client:["COMBO_CCOSTO.ONOPTIONCLICKED",!1]};this.EvtParms.REFRESH=[[],[]];this.EvtParms["'DOBTNIMPRIMIR'"]=[[{av:"AV5Ano",fld:"vANO",pic:"ZZZ9"},{av:"AV10cCuenta1",fld:"vCCUENTA1",pic:""},{av:"AV11cCuenta2",fld:"vCCUENTA2",pic:""},{av:"AV6cCosto",fld:"vCCOSTO",pic:""}],[{av:"this.INNEWWINDOWContainer.Target",ctrl:"INNEWWINDOW",prop:"Target"}]];this.EvtParms["'DOBTNEXCEL'"]=[[{av:"AV5Ano",fld:"vANO",pic:"ZZZ9"},{av:"AV10cCuenta1",fld:"vCCUENTA1",pic:""},{av:"AV11cCuenta2",fld:"vCCUENTA2",pic:""},{av:"AV6cCosto",fld:"vCCOSTO",pic:""}],[{av:"AV6cCosto",fld:"vCCOSTO",pic:""},{av:"AV11cCuenta2",fld:"vCCUENTA2",pic:""},{av:"AV10cCuenta1",fld:"vCCUENTA1",pic:""},{av:"AV5Ano",fld:"vANO",pic:"ZZZ9"}]];this.EvtParms["'DOBTNEXCEL2'"]=[[{av:"AV5Ano",fld:"vANO",pic:"ZZZ9"},{av:"AV10cCuenta1",fld:"vCCUENTA1",pic:""},{av:"AV11cCuenta2",fld:"vCCUENTA2",pic:""},{av:"AV6cCosto",fld:"vCCOSTO",pic:""}],[{av:"AV6cCosto",fld:"vCCOSTO",pic:""},{av:"AV11cCuenta2",fld:"vCCUENTA2",pic:""},{av:"AV10cCuenta1",fld:"vCCUENTA1",pic:""},{av:"AV5Ano",fld:"vANO",pic:"ZZZ9"}]];this.EvtParms["'DOBTNSALIR'"]=[[],[]];this.EvtParms["'DOBTNBUSCARCUE'"]=[[{av:"AV10cCuenta1",fld:"vCCUENTA1",pic:""}],[{av:"AV8cCueDsc1",fld:"vCCUEDSC1",pic:""},{av:"AV10cCuenta1",fld:"vCCUENTA1",pic:""}]];this.EvtParms["'DOBTNBUSCARCUE2'"]=[[{av:"AV11cCuenta2",fld:"vCCUENTA2",pic:""}],[{av:"AV9cCueDsc2",fld:"vCCUEDSC2",pic:""},{av:"AV11cCuenta2",fld:"vCCUENTA2",pic:""}]];this.EvtParms["COMBO_CCOSTO.ONOPTIONCLICKED"]=[[{av:"this.COMBO_CCOSTOContainer.SelectedValue_get",ctrl:"COMBO_CCOSTO",prop:"SelectedValue_get"}],[{av:"AV6cCosto",fld:"vCCOSTO",pic:""}]];this.EvtParms.ENTER=[[],[]];this.Initialize();this.setSDTMapping("WWPBaseObjects\\DVB_SDTComboData.Item",{Title:{extr:"T"},Children:{extr:"C"}})});gx.wi(function(){gx.createParentObj(this.contabilidad.r_resumenanualcentrocostos)})