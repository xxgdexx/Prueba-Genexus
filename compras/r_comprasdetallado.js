gx.evt.autoSkip=!1;gx.define("compras.r_comprasdetallado",!1,function(){var n,t,r,i;this.ServerClass="compras.r_comprasdetallado";this.PackageName="GeneXus.Programs";this.ServerFullClass="compras.r_comprasdetallado.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Validv_Fdesde=function(){return this.validCliEvt("Validv_Fdesde",0,function(){try{var n=gx.util.balloon.getNew("vFDESDE");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV12Fdesde)===0||new gx.date.gxdate(this.AV12Fdesde).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Fdesde fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Fhasta=function(){return this.validCliEvt("Validv_Fhasta",0,function(){try{var n=gx.util.balloon.getNew("vFHASTA");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV13Fhasta)===0||new gx.date.gxdate(this.AV13Fhasta).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Fhasta fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e18421_client=function(){return this.clearMessages(),this.popupOpenUrl(gx.http.formatLink("generales.wwbusquedaproveedor.aspx",["",""]),["AV5PrvCod","AV6PrvDsc"]),this.refreshOutputs([{av:"AV6PrvDsc",fld:"vPRVDSC",pic:""},{av:"AV5PrvCod",fld:"vPRVCOD",pic:"@!"},{ctrl:"vOPC"},{av:"AV14Opc",fld:"vOPC",pic:"9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e17421_client=function(){return this.clearMessages(),this.popupOpenUrl(gx.http.formatLink("generales.wwbusquedaproducto.aspx",["","",""]),["AV7ProdCod","AV8ProdDsc"]),this.refreshOutputs([{av:"AV8ProdDsc",fld:"vPRODDSC",pic:""},{av:"AV7ProdCod",fld:"vPRODCOD",pic:"@!"},{ctrl:"vOPC"},{av:"AV14Opc",fld:"vOPC",pic:"9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e16421_client=function(){return this.clearMessages(),this.popupOpenUrl(gx.http.formatLink("generales.wwbusquedaplancuenta.aspx",[this.AV9CueCod,""]),["AV9CueCod","AV10CueDsc"]),this.refreshOutputs([{av:"AV10CueDsc",fld:"vCUEDSC",pic:""},{av:"AV9CueCod",fld:"vCUECOD",pic:""},{ctrl:"vOPC"},{av:"AV14Opc",fld:"vOPC",pic:"9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e19421_client=function(){return this.clearMessages(),this.AV11MonCod=gx.num.trunc(gx.num.val(this.COMBO_MONCODContainer.SelectedValue_get),0),this.refreshOutputs([{av:"AV11MonCod",fld:"vMONCOD",pic:"ZZZZZ9"},{ctrl:"vOPC"},{av:"AV14Opc",fld:"vOPC",pic:"9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e20422_client=function(){return this.clearMessages(),this.popupOpenUrl(gx.http.formatLink("generales.wwbusquedaproducto.aspx",["","",""]),["AV7ProdCod","AV8ProdDsc"]),this.refreshOutputs([{av:"AV8ProdDsc",fld:"vPRODDSC",pic:""},{av:"AV7ProdCod",fld:"vPRODCOD",pic:"@!"},{ctrl:"vOPC"},{av:"AV14Opc",fld:"vOPC",pic:"9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e21422_client=function(){return this.clearMessages(),this.popupOpenUrl(gx.http.formatLink("generales.wwbusquedaplancuenta.aspx",[this.AV9CueCod,""]),["AV9CueCod","AV10CueDsc"]),this.refreshOutputs([{av:"AV10CueDsc",fld:"vCUEDSC",pic:""},{av:"AV9CueCod",fld:"vCUECOD",pic:""},{ctrl:"vOPC"},{av:"AV14Opc",fld:"vOPC",pic:"9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e12422_client=function(){return this.executeServerEvent("'DOBTNIMPRIMIR'",!1,null,!1,!1)};this.e13422_client=function(){return this.executeServerEvent("'DOBTNEXCEL'",!1,null,!1,!1)};this.e14422_client=function(){return this.executeServerEvent("'DOBTNSALIR'",!1,null,!1,!1)};this.e22422_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e23422_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,25,28,29,31,33,34,35,36,37,38,39,40,41,42,45,46,48,50,51,52,53,54,55,56,57,58,59,62,63,65,67,68,69,70,71,72,73,74,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100,101,102,103,104,105,106,107,108,109,110,111,112,114,115,116,117];this.GXLastCtrlId=117;this.COMBO_MONCODContainer=gx.uc.getNew(this,75,29,"BootstrapDropDownOptions","COMBO_MONCODContainer","Combo_moncod","COMBO_MONCOD");t=this.COMBO_MONCODContainer;t.setProp("Class","Class","","char");t.setProp("IconType","Icontype","Image","str");t.setProp("Icon","Icon","","str");t.setProp("Caption","Caption","","str");t.setProp("Tooltip","Tooltip","","str");t.setProp("Cls","Cls","ExtendedCombo AttributeRealWidth50With","str");t.setDynProp("SelectedValue_set","Selectedvalue_set","","char");t.setProp("SelectedValue_get","Selectedvalue_get","","char");t.setProp("SelectedText_set","Selectedtext_set","","char");t.setProp("SelectedText_get","Selectedtext_get","","char");t.setProp("GAMOAuthToken","Gamoauthtoken","","char");t.setProp("DDOInternalName","Ddointernalname","","char");t.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");t.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");t.setProp("Enabled","Enabled",!0,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");t.setProp("DataListType","Datalisttype","Dynamic","str");t.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");t.setProp("DataListFixedValues","Datalistfixedvalues","","char");t.setProp("IsGridItem","Isgriditem",!1,"bool");t.setProp("HasDescription","Hasdescription",!1,"bool");t.setProp("DataListProc","Datalistproc","","str");t.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");t.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");t.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");t.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");t.setProp("EmptyItem","Emptyitem",!0,"bool");t.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");t.setProp("HTMLTemplate","Htmltemplate","","str");t.setProp("MultipleValuesType","Multiplevaluestype","Text","str");t.setProp("LoadingData","Loadingdata","","char");t.setProp("NoResultsFound","Noresultsfound","","char");t.setProp("EmptyItemText","Emptyitemtext","GX_EmptyItemText","str");t.setProp("OnlySelectedValues","Onlyselectedvalues","","char");t.setProp("SelectAllText","Selectalltext","","char");t.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");t.setProp("AddNewOptionText","Addnewoptiontext","","str");t.setProp("DropDownOptionsTitleSettingsIcons","Dropdownoptionstitlesettingsicons","","str");t.addV2CFunction("AV15MonCod_Data","vMONCOD_DATA","SetDropDownOptionsData");t.addC2VFunction(function(n){n.ParentObject.AV15MonCod_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vMONCOD_DATA",n.ParentObject.AV15MonCod_Data)});t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("OnOptionClicked",this.e19421_client);this.setUserControl(t);this.DVPANEL_PANEL1Container=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_PANEL1Container","Dvpanel_panel1","DVPANEL_PANEL1");r=this.DVPANEL_PANEL1Container;r.setProp("Class","Class","","char");r.setProp("Enabled","Enabled",!0,"boolean");r.setProp("Width","Width","100%","str");r.setProp("Height","Height","100","str");r.setProp("AutoWidth","Autowidth",!1,"bool");r.setProp("AutoHeight","Autoheight",!0,"bool");r.setProp("Cls","Cls","PanelFilled Panel_BaseColor","str");r.setProp("ShowHeader","Showheader",!0,"bool");r.setProp("Title","Title","Reporte de Compras Detallado","str");r.setProp("Collapsible","Collapsible",!0,"bool");r.setProp("Collapsed","Collapsed",!1,"bool");r.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");r.setProp("IconPosition","Iconposition","Right","str");r.setProp("AutoScroll","Autoscroll",!1,"bool");r.setProp("Visible","Visible",!0,"bool");r.setProp("Gx Control Type","Gxcontroltype","","int");r.setC2ShowFunction(function(n){n.show()});this.setUserControl(r);this.INNEWWINDOWContainer=gx.uc.getNew(this,113,29,"InNewWindow","INNEWWINDOWContainer","Innewwindow","INNEWWINDOW");i=this.INNEWWINDOWContainer;i.setProp("Class","Class","","char");i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("Width","Width","50","str");i.setProp("Height","Height","50","str");i.setProp("Name","Name","","str");i.setDynProp("Target","Target","","str");i.setProp("Fullscreen","Fullscreen",!1,"bool");i.setProp("Location","Location",!0,"bool");i.setProp("MenuBar","Menubar",!0,"bool");i.setProp("Resizable","Resizable",!0,"bool");i.setProp("Scrollbars","Scrollbars",!0,"bool");i.setProp("TitleBar","Titlebar",!0,"bool");i.setProp("ToolBar","Toolbar",!0,"bool");i.setProp("directories","Directories",!0,"bool");i.setProp("status","Status",!0,"bool");i.setProp("copyhistory","Copyhistory",!0,"bool");i.setProp("top","Top","5","str");i.setProp("left","Left","5","str");i.setProp("fitscreen","Fitscreen",!1,"bool");i.setProp("RefreshParentOnClose","Refreshparentonclose",!1,"bool");i.setProp("Targets","Targets","","str");i.setProp("Visible","Visible",!0,"bool");i.setC2ShowFunction(function(n){n.show()});this.setUserControl(i);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"PANEL1",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"TABLESPLITTEDPRVCOD",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"TEXTBLOCKPRVCOD",format:0,grid:0,ctrltype:"textblock"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"TABLEMERGEDPRVCOD",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,lvl:0,type:"char",len:20,dec:0,sign:!1,pic:"@!",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPRVCOD",gxz:"ZV5PrvCod",gxold:"OV5PrvCod",gxvar:"AV5PrvCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV5PrvCod=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5PrvCod=n)},v2c:function(){gx.fn.setControlValue("vPRVCOD",gx.O.AV5PrvCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV5PrvCod=this.val())},val:function(){return gx.fn.getControlValue("vPRVCOD")},nac:gx.falseFn};n[31]={id:31,fld:"BTNPROV",grid:0,evt:"e18421_client"};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPRVDSC",gxz:"ZV6PrvDsc",gxold:"OV6PrvDsc",gxvar:"AV6PrvDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6PrvDsc=n)},v2z:function(n){n!==undefined&&(gx.O.ZV6PrvDsc=n)},v2c:function(){gx.fn.setControlValue("vPRVDSC",gx.O.AV6PrvDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6PrvDsc=this.val())},val:function(){return gx.fn.getControlValue("vPRVDSC")},nac:gx.falseFn};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"TABLESPLITTEDPRODCOD",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"TEXTBLOCKPRODCOD",format:0,grid:0,ctrltype:"textblock"};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"TABLEMERGEDPRODCOD",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,lvl:0,type:"char",len:15,dec:0,sign:!1,pic:"@!",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPRODCOD",gxz:"ZV7ProdCod",gxold:"OV7ProdCod",gxvar:"AV7ProdCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7ProdCod=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7ProdCod=n)},v2c:function(){gx.fn.setControlValue("vPRODCOD",gx.O.AV7ProdCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7ProdCod=this.val())},val:function(){return gx.fn.getControlValue("vPRODCOD")},nac:gx.falseFn};n[48]={id:48,fld:"BTNPRODUC",grid:0,evt:"e17421_client"};n[50]={id:50,fld:"",grid:0};n[51]={id:51,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPRODDSC",gxz:"ZV8ProdDsc",gxold:"OV8ProdDsc",gxvar:"AV8ProdDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8ProdDsc=n)},v2z:function(n){n!==undefined&&(gx.O.ZV8ProdDsc=n)},v2c:function(){gx.fn.setControlValue("vPRODDSC",gx.O.AV8ProdDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8ProdDsc=this.val())},val:function(){return gx.fn.getControlValue("vPRODDSC")},nac:gx.falseFn};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"TABLESPLITTEDCUECOD",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"TEXTBLOCKCUECOD",format:0,grid:0,ctrltype:"textblock"};n[58]={id:58,fld:"",grid:0};n[59]={id:59,fld:"TABLEMERGEDCUECOD",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,lvl:0,type:"char",len:15,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCUECOD",gxz:"ZV9CueCod",gxold:"OV9CueCod",gxvar:"AV9CueCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV9CueCod=n)},v2z:function(n){n!==undefined&&(gx.O.ZV9CueCod=n)},v2c:function(){gx.fn.setControlValue("vCUECOD",gx.O.AV9CueCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV9CueCod=this.val())},val:function(){return gx.fn.getControlValue("vCUECOD")},nac:gx.falseFn};n[65]={id:65,fld:"BTNGASTO",grid:0,evt:"e16421_client"};n[67]={id:67,fld:"",grid:0};n[68]={id:68,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCUEDSC",gxz:"ZV10CueDsc",gxold:"OV10CueDsc",gxvar:"AV10CueDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV10CueDsc=n)},v2z:function(n){n!==undefined&&(gx.O.ZV10CueDsc=n)},v2c:function(){gx.fn.setControlValue("vCUEDSC",gx.O.AV10CueDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV10CueDsc=this.val())},val:function(){return gx.fn.getControlValue("vCUEDSC")},nac:gx.falseFn};n[69]={id:69,fld:"",grid:0};n[70]={id:70,fld:"TABLESPLITTEDMONCOD",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"TEXTBLOCKCOMBO_MONCOD",format:0,grid:0,ctrltype:"textblock"};n[74]={id:74,fld:"",grid:0};n[76]={id:76,fld:"",grid:0};n[77]={id:77,fld:"",grid:0};n[78]={id:78,fld:"UNNAMEDTABLEFDESDE",grid:0};n[79]={id:79,fld:"",grid:0};n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"TEXTBLOCKFDESDE",format:0,grid:0,ctrltype:"textblock"};n[82]={id:82,fld:"",grid:0};n[83]={id:83,fld:"",grid:0};n[84]={id:84,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Fdesde,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFDESDE",gxz:"ZV12Fdesde",gxold:"OV12Fdesde",gxvar:"AV12Fdesde",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[84],ip:[84],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV12Fdesde=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV12Fdesde=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vFDESDE",gx.O.AV12Fdesde,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV12Fdesde=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vFDESDE")},nac:gx.falseFn};n[85]={id:85,fld:"",grid:0};n[86]={id:86,fld:"",grid:0};n[87]={id:87,fld:"UNNAMEDTABLEFHASTA",grid:0};n[88]={id:88,fld:"",grid:0};n[89]={id:89,fld:"",grid:0};n[90]={id:90,fld:"TEXTBLOCKFHASTA",format:0,grid:0,ctrltype:"textblock"};n[91]={id:91,fld:"",grid:0};n[92]={id:92,fld:"",grid:0};n[93]={id:93,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Fhasta,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFHASTA",gxz:"ZV13Fhasta",gxold:"OV13Fhasta",gxvar:"AV13Fhasta",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[93],ip:[93],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV13Fhasta=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV13Fhasta=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vFHASTA",gx.O.AV13Fhasta,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV13Fhasta=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vFHASTA")},nac:gx.falseFn};n[94]={id:94,fld:"",grid:0};n[95]={id:95,fld:"UNNAMEDTABLEOPC",grid:0};n[96]={id:96,fld:"",grid:0};n[97]={id:97,fld:"",grid:0};n[98]={id:98,fld:"TEXTBLOCKOPC",format:0,grid:0,ctrltype:"textblock"};n[99]={id:99,fld:"",grid:0};n[100]={id:100,fld:"",grid:0};n[101]={id:101,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vOPC",gxz:"ZV14Opc",gxold:"OV14Opc",gxvar:"AV14Opc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"radio",v2v:function(n){n!==undefined&&(gx.O.AV14Opc=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV14Opc=gx.num.intval(n))},v2c:function(){gx.fn.setRadioValue("vOPC",gx.O.AV14Opc)},c2v:function(){this.val()!==undefined&&(gx.O.AV14Opc=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vOPC",",")},nac:gx.falseFn};n[102]={id:102,fld:"",grid:0};n[103]={id:103,fld:"",grid:0};n[104]={id:104,fld:"",grid:0};n[105]={id:105,fld:"",grid:0};n[106]={id:106,fld:"BTNBTNIMPRIMIR",grid:0,evt:"e12422_client"};n[107]={id:107,fld:"",grid:0};n[108]={id:108,fld:"BTNBTNEXCEL",grid:0,evt:"e13422_client"};n[109]={id:109,fld:"",grid:0};n[110]={id:110,fld:"BTNBTNSALIR",grid:0,evt:"e14422_client"};n[111]={id:111,fld:"",grid:0};n[112]={id:112,fld:"",grid:0};n[114]={id:114,fld:"",grid:0};n[115]={id:115,fld:"",grid:0};n[116]={id:116,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[117]={id:117,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vMONCOD",gxz:"ZV11MonCod",gxold:"OV11MonCod",gxvar:"AV11MonCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV11MonCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV11MonCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vMONCOD",gx.O.AV11MonCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV11MonCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vMONCOD",",")},nac:gx.falseFn};this.AV5PrvCod="";this.ZV5PrvCod="";this.OV5PrvCod="";this.AV6PrvDsc="";this.ZV6PrvDsc="";this.OV6PrvDsc="";this.AV7ProdCod="";this.ZV7ProdCod="";this.OV7ProdCod="";this.AV8ProdDsc="";this.ZV8ProdDsc="";this.OV8ProdDsc="";this.AV9CueCod="";this.ZV9CueCod="";this.OV9CueCod="";this.AV10CueDsc="";this.ZV10CueDsc="";this.OV10CueDsc="";this.AV12Fdesde=gx.date.nullDate();this.ZV12Fdesde=gx.date.nullDate();this.OV12Fdesde=gx.date.nullDate();this.AV13Fhasta=gx.date.nullDate();this.ZV13Fhasta=gx.date.nullDate();this.OV13Fhasta=gx.date.nullDate();this.AV14Opc=0;this.ZV14Opc=0;this.OV14Opc=0;this.AV11MonCod=0;this.ZV11MonCod=0;this.OV11MonCod=0;this.AV5PrvCod="";this.AV6PrvDsc="";this.AV7ProdCod="";this.AV8ProdDsc="";this.AV9CueCod="";this.AV10CueDsc="";this.AV15MonCod_Data=[];this.AV12Fdesde=gx.date.nullDate();this.AV13Fhasta=gx.date.nullDate();this.AV14Opc=0;this.AV11MonCod=0;this.A1235MonSts=0;this.A180MonCod=0;this.A1234MonDsc="";this.Events={e12422_client:["'DOBTNIMPRIMIR'",!0],e13422_client:["'DOBTNEXCEL'",!0],e14422_client:["'DOBTNSALIR'",!0],e22422_client:["ENTER",!0],e23422_client:["CANCEL",!0],e18421_client:["'DOBTNPROV'",!1],e17421_client:["'DOBTNPRODUC'",!1],e16421_client:["'DOBTNGASTO'",!1],e19421_client:["COMBO_MONCOD.ONOPTIONCLICKED",!1],e20422_client:["'DOBTNPROD'",!1],e21422_client:["'DOBTNCUENTA'",!1]};this.EvtParms.REFRESH=[[{ctrl:"vOPC"},{av:"AV14Opc",fld:"vOPC",pic:"9"}],[{ctrl:"vOPC"},{av:"AV14Opc",fld:"vOPC",pic:"9"}]];this.EvtParms["'DOBTNIMPRIMIR'"]=[[{av:"AV9CueCod",fld:"vCUECOD",pic:""},{av:"AV7ProdCod",fld:"vPRODCOD",pic:"@!"},{av:"AV5PrvCod",fld:"vPRVCOD",pic:"@!"},{av:"AV11MonCod",fld:"vMONCOD",pic:"ZZZZZ9"},{av:"AV12Fdesde",fld:"vFDESDE",pic:""},{av:"AV13Fhasta",fld:"vFHASTA",pic:""},{ctrl:"vOPC"},{av:"AV14Opc",fld:"vOPC",pic:"9"}],[{av:"this.INNEWWINDOWContainer.Target",ctrl:"INNEWWINDOW",prop:"Target"},{ctrl:"vOPC"},{av:"AV14Opc",fld:"vOPC",pic:"9"}]];this.EvtParms["'DOBTNEXCEL'"]=[[{av:"AV9CueCod",fld:"vCUECOD",pic:""},{av:"AV7ProdCod",fld:"vPRODCOD",pic:"@!"},{av:"AV5PrvCod",fld:"vPRVCOD",pic:"@!"},{av:"AV11MonCod",fld:"vMONCOD",pic:"ZZZZZ9"},{av:"AV12Fdesde",fld:"vFDESDE",pic:""},{av:"AV13Fhasta",fld:"vFHASTA",pic:""},{ctrl:"vOPC"},{av:"AV14Opc",fld:"vOPC",pic:"9"}],[{av:"AV13Fhasta",fld:"vFHASTA",pic:""},{av:"AV12Fdesde",fld:"vFDESDE",pic:""},{av:"AV11MonCod",fld:"vMONCOD",pic:"ZZZZZ9"},{av:"AV5PrvCod",fld:"vPRVCOD",pic:"@!"},{av:"AV7ProdCod",fld:"vPRODCOD",pic:"@!"},{av:"AV9CueCod",fld:"vCUECOD",pic:""},{ctrl:"vOPC"},{av:"AV14Opc",fld:"vOPC",pic:"9"}]];this.EvtParms["'DOBTNSALIR'"]=[[{ctrl:"vOPC"},{av:"AV14Opc",fld:"vOPC",pic:"9"}],[{ctrl:"vOPC"},{av:"AV14Opc",fld:"vOPC",pic:"9"}]];this.EvtParms["'DOBTNPROV'"]=[[{ctrl:"vOPC"},{av:"AV14Opc",fld:"vOPC",pic:"9"}],[{av:"AV6PrvDsc",fld:"vPRVDSC",pic:""},{av:"AV5PrvCod",fld:"vPRVCOD",pic:"@!"},{ctrl:"vOPC"},{av:"AV14Opc",fld:"vOPC",pic:"9"}]];this.EvtParms["'DOBTNPRODUC'"]=[[{ctrl:"vOPC"},{av:"AV14Opc",fld:"vOPC",pic:"9"}],[{av:"AV8ProdDsc",fld:"vPRODDSC",pic:""},{av:"AV7ProdCod",fld:"vPRODCOD",pic:"@!"},{ctrl:"vOPC"},{av:"AV14Opc",fld:"vOPC",pic:"9"}]];this.EvtParms["'DOBTNGASTO'"]=[[{av:"AV9CueCod",fld:"vCUECOD",pic:""},{ctrl:"vOPC"},{av:"AV14Opc",fld:"vOPC",pic:"9"}],[{av:"AV10CueDsc",fld:"vCUEDSC",pic:""},{av:"AV9CueCod",fld:"vCUECOD",pic:""},{ctrl:"vOPC"},{av:"AV14Opc",fld:"vOPC",pic:"9"}]];this.EvtParms["COMBO_MONCOD.ONOPTIONCLICKED"]=[[{av:"this.COMBO_MONCODContainer.SelectedValue_get",ctrl:"COMBO_MONCOD",prop:"SelectedValue_get"},{ctrl:"vOPC"},{av:"AV14Opc",fld:"vOPC",pic:"9"}],[{av:"AV11MonCod",fld:"vMONCOD",pic:"ZZZZZ9"},{ctrl:"vOPC"},{av:"AV14Opc",fld:"vOPC",pic:"9"}]];this.EvtParms["'DOBTNPROD'"]=[[{ctrl:"vOPC"},{av:"AV14Opc",fld:"vOPC",pic:"9"}],[{av:"AV8ProdDsc",fld:"vPRODDSC",pic:""},{av:"AV7ProdCod",fld:"vPRODCOD",pic:"@!"},{ctrl:"vOPC"},{av:"AV14Opc",fld:"vOPC",pic:"9"}]];this.EvtParms["'DOBTNCUENTA'"]=[[{av:"AV9CueCod",fld:"vCUECOD",pic:""},{ctrl:"vOPC"},{av:"AV14Opc",fld:"vOPC",pic:"9"}],[{av:"AV10CueDsc",fld:"vCUEDSC",pic:""},{av:"AV9CueCod",fld:"vCUECOD",pic:""},{ctrl:"vOPC"},{av:"AV14Opc",fld:"vOPC",pic:"9"}]];this.EvtParms.ENTER=[[{ctrl:"vOPC"},{av:"AV14Opc",fld:"vOPC",pic:"9"}],[{ctrl:"vOPC"},{av:"AV14Opc",fld:"vOPC",pic:"9"}]];this.EvtParms.VALIDV_FDESDE=[[{ctrl:"vOPC"},{av:"AV14Opc",fld:"vOPC",pic:"9"}],[{ctrl:"vOPC"},{av:"AV14Opc",fld:"vOPC",pic:"9"}]];this.EvtParms.VALIDV_FHASTA=[[{ctrl:"vOPC"},{av:"AV14Opc",fld:"vOPC",pic:"9"}],[{ctrl:"vOPC"},{av:"AV14Opc",fld:"vOPC",pic:"9"}]];this.Initialize();this.setSDTMapping("WWPBaseObjects\\DVB_SDTComboData.Item",{Title:{extr:"T"},Children:{extr:"C"}})});gx.wi(function(){gx.createParentObj(this.compras.r_comprasdetallado)})