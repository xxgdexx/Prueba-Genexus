gx.evt.autoSkip=!1;gx.define("ventas.r_registroventasoficial",!1,function(){var n,i,t;this.ServerClass="ventas.r_registroventasoficial";this.PackageName="GeneXus.Programs";this.ServerFullClass="ventas.r_registroventasoficial.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.e125h2_client=function(){return this.executeServerEvent("'DOBTNIMPRIMIR'",!1,null,!1,!1)};this.e135h2_client=function(){return this.executeServerEvent("'DOBTNEXCEL'",!1,null,!1,!1)};this.e145h2_client=function(){return this.executeServerEvent("'DOBTNSALIR'",!1,null,!1,!1)};this.e165h2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e175h2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46];this.GXLastCtrlId=46;this.DVPANEL_PANEL1Container=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_PANEL1Container","Dvpanel_panel1","DVPANEL_PANEL1");i=this.DVPANEL_PANEL1Container;i.setProp("Class","Class","","char");i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("Width","Width","100%","str");i.setProp("Height","Height","100","str");i.setProp("AutoWidth","Autowidth",!1,"bool");i.setProp("AutoHeight","Autoheight",!0,"bool");i.setProp("Cls","Cls","PanelFilled Panel_BaseColor","str");i.setProp("ShowHeader","Showheader",!0,"bool");i.setProp("Title","Title","Reporte Registro de Ventas Oficial","str");i.setProp("Collapsible","Collapsible",!0,"bool");i.setProp("Collapsed","Collapsed",!1,"bool");i.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");i.setProp("IconPosition","Iconposition","Right","str");i.setProp("AutoScroll","Autoscroll",!1,"bool");i.setProp("Visible","Visible",!0,"bool");i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});this.setUserControl(i);this.INNEWWINDOWContainer=gx.uc.getNew(this,47,26,"InNewWindow","INNEWWINDOWContainer","Innewwindow","INNEWWINDOW");t=this.INNEWWINDOWContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Width","Width","50","str");t.setProp("Height","Height","50","str");t.setProp("Name","Name","","str");t.setDynProp("Target","Target","","str");t.setProp("Fullscreen","Fullscreen",!1,"bool");t.setProp("Location","Location",!0,"bool");t.setProp("MenuBar","Menubar",!0,"bool");t.setProp("Resizable","Resizable",!0,"bool");t.setProp("Scrollbars","Scrollbars",!0,"bool");t.setProp("TitleBar","Titlebar",!0,"bool");t.setProp("ToolBar","Toolbar",!0,"bool");t.setProp("directories","Directories",!0,"bool");t.setProp("status","Status",!0,"bool");t.setProp("copyhistory","Copyhistory",!0,"bool");t.setProp("top","Top","5","str");t.setProp("left","Left","5","str");t.setProp("fitscreen","Fitscreen",!1,"bool");t.setProp("RefreshParentOnClose","Refreshparentonclose",!1,"bool");t.setProp("Targets","Targets","","str");t.setProp("Visible","Visible",!0,"bool");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"PANEL1",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"UNNAMEDTABLEJANO",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"TEXTBLOCKJANO",format:0,grid:0,ctrltype:"textblock"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vJANO",gxz:"ZV27jAno",gxold:"OV27jAno",gxvar:"AV27jAno",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV27jAno=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV27jAno=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vJANO",gx.O.AV27jAno,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV27jAno=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vJANO",",")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"UNNAMEDTABLEJMES",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"TEXTBLOCKJMES",format:0,grid:0,ctrltype:"textblock"};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,lvl:0,type:"int",len:2,dec:0,sign:!1,pic:"Z9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vJMES",gxz:"ZV28jMes",gxold:"OV28jMes",gxvar:"AV28jMes",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV28jMes=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV28jMes=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("vJMES",gx.O.AV28jMes)},c2v:function(){this.val()!==undefined&&(gx.O.AV28jMes=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vJMES",",")},nac:gx.falseFn};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"BTNBTNIMPRIMIR",grid:0,evt:"e125h2_client"};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"BTNBTNEXCEL",grid:0,evt:"e135h2_client"};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"BTNBTNSALIR",grid:0,evt:"e145h2_client"};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};this.AV27jAno=0;this.ZV27jAno=0;this.OV27jAno=0;this.AV28jMes=0;this.ZV28jMes=0;this.OV28jMes=0;this.AV27jAno=0;this.AV28jMes=0;this.Events={e125h2_client:["'DOBTNIMPRIMIR'",!0],e135h2_client:["'DOBTNEXCEL'",!0],e145h2_client:["'DOBTNSALIR'",!0],e165h2_client:["ENTER",!0],e175h2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[],[]];this.EvtParms["'DOBTNIMPRIMIR'"]=[[{av:"AV27jAno",fld:"vJANO",pic:"ZZZ9"},{ctrl:"vJMES"},{av:"AV28jMes",fld:"vJMES",pic:"Z9"}],[{av:"this.INNEWWINDOWContainer.Target",ctrl:"INNEWWINDOW",prop:"Target"}]];this.EvtParms["'DOBTNEXCEL'"]=[[{av:"AV27jAno",fld:"vJANO",pic:"ZZZ9"},{ctrl:"vJMES"},{av:"AV28jMes",fld:"vJMES",pic:"Z9"}],[{ctrl:"vJMES"},{av:"AV28jMes",fld:"vJMES",pic:"Z9"},{av:"AV27jAno",fld:"vJANO",pic:"ZZZ9"}]];this.EvtParms["'DOBTNSALIR'"]=[[],[]];this.EvtParms.ENTER=[[],[]];this.Initialize();this.setSDTMapping("WWPBaseObjects\\DVB_SDTComboData.Item",{Title:{extr:"T"},Children:{extr:"C"}});this.setSDTMapping("WWPBaseObjects\\DVB_SDTDropDownOptionsTitleSettingsIcons",{Default_fi:{extr:"def"},Filtered_fi:{extr:"fil"},SortedASC_fi:{extr:"asc"},SortedDSC_fi:{extr:"dsc"},FilteredSortedASC_fi:{extr:"fasc"},FilteredSortedDSC_fi:{extr:"fdsc"},OptionSortASC_fi:{extr:"osasc"},OptionSortDSC_fi:{extr:"osdsc"},OptionApplyFilter_fi:{extr:"app"},OptionFilteringData_fi:{extr:"fildata"},OptionCleanFilters_fi:{extr:"cle"},SelectedOption_fi:{extr:"selo"},MultiselOption_fi:{extr:"mul"},MultiselSelOption_fi:{extr:"muls"},TreeviewCollapse_fi:{extr:"tcol"},TreeviewExpand_fi:{extr:"texp"},FixLeft_fi:{extr:"fixl"},FixRight_fi:{extr:"fixr"}})});gx.wi(function(){gx.createParentObj(this.ventas.r_registroventasoficial)})