gx.evt.autoSkip=!1;gx.define("contabilidad.r_inventariosbalances",!1,function(){var n,i,t;this.ServerClass="contabilidad.r_inventariosbalances";this.PackageName="GeneXus.Programs";this.ServerFullClass="contabilidad.r_inventariosbalances.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.e12692_client=function(){return this.executeServerEvent("'DOBTNIMPRIMIR'",!1,null,!1,!1)};this.e13692_client=function(){return this.executeServerEvent("'DOBTNEXCEL'",!1,null,!1,!1)};this.e14692_client=function(){return this.executeServerEvent("'DOBTNSALIR'",!1,null,!1,!1)};this.e16692_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e17692_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62];this.GXLastCtrlId=62;this.DVPANEL_PANEL1Container=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_PANEL1Container","Dvpanel_panel1","DVPANEL_PANEL1");i=this.DVPANEL_PANEL1Container;i.setProp("Class","Class","","char");i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("Width","Width","100%","str");i.setProp("Height","Height","100","str");i.setProp("AutoWidth","Autowidth",!1,"bool");i.setProp("AutoHeight","Autoheight",!0,"bool");i.setProp("Cls","Cls","PanelFilled Panel_BaseColor","str");i.setProp("ShowHeader","Showheader",!0,"bool");i.setProp("Title","Title","Libro de Inventarios y Balances","str");i.setProp("Collapsible","Collapsible",!0,"bool");i.setProp("Collapsed","Collapsed",!1,"bool");i.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");i.setProp("IconPosition","Iconposition","Right","str");i.setProp("AutoScroll","Autoscroll",!1,"bool");i.setProp("Visible","Visible",!0,"bool");i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});this.setUserControl(i);this.INNEWWINDOWContainer=gx.uc.getNew(this,63,26,"InNewWindow","INNEWWINDOWContainer","Innewwindow","INNEWWINDOW");t=this.INNEWWINDOWContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Width","Width","50","str");t.setProp("Height","Height","50","str");t.setProp("Name","Name","","str");t.setDynProp("Target","Target","","str");t.setProp("Fullscreen","Fullscreen",!1,"bool");t.setProp("Location","Location",!0,"bool");t.setProp("MenuBar","Menubar",!0,"bool");t.setProp("Resizable","Resizable",!0,"bool");t.setProp("Scrollbars","Scrollbars",!0,"bool");t.setProp("TitleBar","Titlebar",!0,"bool");t.setProp("ToolBar","Toolbar",!0,"bool");t.setProp("directories","Directories",!0,"bool");t.setProp("status","Status",!0,"bool");t.setProp("copyhistory","Copyhistory",!0,"bool");t.setProp("top","Top","5","str");t.setProp("left","Left","5","str");t.setProp("fitscreen","Fitscreen",!1,"bool");t.setProp("RefreshParentOnClose","Refreshparentonclose",!1,"bool");t.setProp("Targets","Targets","","str");t.setProp("Visible","Visible",!0,"bool");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"PANEL1",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"UNNAMEDTABLEANO",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"TEXTBLOCKANO",format:0,grid:0,ctrltype:"textblock"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vANO",gxz:"ZV5Ano",gxold:"OV5Ano",gxvar:"AV5Ano",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV5Ano=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV5Ano=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vANO",gx.O.AV5Ano,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV5Ano=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vANO",",")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"UNNAMEDTABLEMES",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"TEXTBLOCKMES",format:0,grid:0,ctrltype:"textblock"};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"int",len:2,dec:0,sign:!1,pic:"Z9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vMES",gxz:"ZV7Mes",gxold:"OV7Mes",gxvar:"AV7Mes",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV7Mes=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV7Mes=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("vMES",gx.O.AV7Mes)},c2v:function(){this.val()!==undefined&&(gx.O.AV7Mes=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vMES",",")},nac:gx.falseFn};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"UNNAMEDTABLENDIG",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"TEXTBLOCKNDIG",format:0,grid:0,ctrltype:"textblock"};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,lvl:0,type:"int",len:2,dec:0,sign:!1,pic:"Z9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNDIG",gxz:"ZV8nDig",gxold:"OV8nDig",gxvar:"AV8nDig",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV8nDig=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV8nDig=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("vNDIG",gx.O.AV8nDig)},c2v:function(){this.val()!==undefined&&(gx.O.AV8nDig=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vNDIG",",")},nac:gx.falseFn};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"UNNAMEDTABLECDETALLES",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"TEXTBLOCKCDETALLES",format:0,grid:0,ctrltype:"textblock"};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCDETALLES",gxz:"ZV6CDetalles",gxold:"OV6CDetalles",gxvar:"AV6CDetalles",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.AV6CDetalles=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6CDetalles=gx.num.intval(n))},v2c:function(){gx.fn.setCheckBoxValue("vCDETALLES",gx.O.AV6CDetalles,"1")},c2v:function(){this.val()!==undefined&&(gx.O.AV6CDetalles=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCDETALLES",",")},nac:gx.falseFn,values:[1,0]};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"BTNBTNIMPRIMIR",grid:0,evt:"e12692_client"};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"BTNBTNEXCEL",grid:0,evt:"e13692_client"};n[59]={id:59,fld:"",grid:0};n[60]={id:60,fld:"BTNBTNSALIR",grid:0,evt:"e14692_client"};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};this.AV5Ano=0;this.ZV5Ano=0;this.OV5Ano=0;this.AV7Mes=0;this.ZV7Mes=0;this.OV7Mes=0;this.AV8nDig=0;this.ZV8nDig=0;this.OV8nDig=0;this.AV6CDetalles=0;this.ZV6CDetalles=0;this.OV6CDetalles=0;this.AV5Ano=0;this.AV7Mes=0;this.AV8nDig=0;this.AV6CDetalles=0;this.Events={e12692_client:["'DOBTNIMPRIMIR'",!0],e13692_client:["'DOBTNEXCEL'",!0],e14692_client:["'DOBTNSALIR'",!0],e16692_client:["ENTER",!0],e17692_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV6CDetalles",fld:"vCDETALLES",pic:"9"}],[{av:"AV6CDetalles",fld:"vCDETALLES",pic:"9"}]];this.EvtParms["'DOBTNIMPRIMIR'"]=[[{av:"AV5Ano",fld:"vANO",pic:"ZZZ9"},{ctrl:"vMES"},{av:"AV7Mes",fld:"vMES",pic:"Z9"},{ctrl:"vNDIG"},{av:"AV8nDig",fld:"vNDIG",pic:"Z9"},{av:"AV6CDetalles",fld:"vCDETALLES",pic:"9"}],[{av:"this.INNEWWINDOWContainer.Target",ctrl:"INNEWWINDOW",prop:"Target"},{av:"AV6CDetalles",fld:"vCDETALLES",pic:"9"}]];this.EvtParms["'DOBTNEXCEL'"]=[[{av:"AV5Ano",fld:"vANO",pic:"ZZZ9"},{ctrl:"vMES"},{av:"AV7Mes",fld:"vMES",pic:"Z9"},{av:"AV6CDetalles",fld:"vCDETALLES",pic:"9"}],[{ctrl:"vMES"},{av:"AV7Mes",fld:"vMES",pic:"Z9"},{av:"AV5Ano",fld:"vANO",pic:"ZZZ9"},{av:"AV6CDetalles",fld:"vCDETALLES",pic:"9"}]];this.EvtParms["'DOBTNSALIR'"]=[[{av:"AV6CDetalles",fld:"vCDETALLES",pic:"9"}],[{av:"AV6CDetalles",fld:"vCDETALLES",pic:"9"}]];this.EvtParms.ENTER=[[{av:"AV6CDetalles",fld:"vCDETALLES",pic:"9"}],[{av:"AV6CDetalles",fld:"vCDETALLES",pic:"9"}]];this.Initialize()});gx.wi(function(){gx.createParentObj(this.contabilidad.r_inventariosbalances)})