gx.evt.autoSkip=!1;gx.define("contabilidad.r_librodiario",!1,function(){var n,i,t;this.ServerClass="contabilidad.r_librodiario";this.PackageName="GeneXus.Programs";this.ServerFullClass="contabilidad.r_librodiario.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.e175z1_client=function(){return this.clearMessages(),this.popupOpenUrl(gx.http.formatLink("generales.wwbusquedaplancuenta.aspx",[this.AV7cCuenta1,""]),["AV7cCuenta1","AV6cCueDsc1"]),this.refreshOutputs([{av:"AV6cCueDsc1",fld:"vCCUEDSC1",pic:""},{av:"AV7cCuenta1",fld:"vCCUENTA1",pic:""},{ctrl:"vTASICOD"},{av:"AV13TASICod",fld:"vTASICOD",pic:"ZZZZZ9"},{ctrl:"vTIPO"},{av:"AV15Tipo",fld:"vTIPO",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e125z2_client=function(){return this.executeServerEvent("'DOBTNIMPRIMIR'",!1,null,!1,!1)};this.e135z2_client=function(){return this.executeServerEvent("'DOBTNEXCEL'",!1,null,!1,!1)};this.e145z2_client=function(){return this.executeServerEvent("'DOBTNEXCEL2'",!1,null,!1,!1)};this.e155z2_client=function(){return this.executeServerEvent("'DOBTNSALIR'",!1,null,!1,!1)};this.e185z2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e195z2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,62,63,65,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81];this.GXLastCtrlId=81;this.DVPANEL_PANEL1Container=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_PANEL1Container","Dvpanel_panel1","DVPANEL_PANEL1");i=this.DVPANEL_PANEL1Container;i.setProp("Class","Class","","char");i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("Width","Width","100%","str");i.setProp("Height","Height","100","str");i.setProp("AutoWidth","Autowidth",!1,"bool");i.setProp("AutoHeight","Autoheight",!0,"bool");i.setProp("Cls","Cls","PanelFilled Panel_BaseColor","str");i.setProp("ShowHeader","Showheader",!0,"bool");i.setProp("Title","Title","Libro Diario","str");i.setProp("Collapsible","Collapsible",!0,"bool");i.setProp("Collapsed","Collapsed",!1,"bool");i.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");i.setProp("IconPosition","Iconposition","Right","str");i.setProp("AutoScroll","Autoscroll",!1,"bool");i.setProp("Visible","Visible",!0,"bool");i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});this.setUserControl(i);this.INNEWWINDOWContainer=gx.uc.getNew(this,82,26,"InNewWindow","INNEWWINDOWContainer","Innewwindow","INNEWWINDOW");t=this.INNEWWINDOWContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Width","Width","50","str");t.setProp("Height","Height","50","str");t.setProp("Name","Name","","str");t.setDynProp("Target","Target","","str");t.setProp("Fullscreen","Fullscreen",!1,"bool");t.setProp("Location","Location",!0,"bool");t.setProp("MenuBar","Menubar",!0,"bool");t.setProp("Resizable","Resizable",!0,"bool");t.setProp("Scrollbars","Scrollbars",!0,"bool");t.setProp("TitleBar","Titlebar",!0,"bool");t.setProp("ToolBar","Toolbar",!0,"bool");t.setProp("directories","Directories",!0,"bool");t.setProp("status","Status",!0,"bool");t.setProp("copyhistory","Copyhistory",!0,"bool");t.setProp("top","Top","5","str");t.setProp("left","Left","5","str");t.setProp("fitscreen","Fitscreen",!1,"bool");t.setProp("RefreshParentOnClose","Refreshparentonclose",!1,"bool");t.setProp("Targets","Targets","","str");t.setProp("Visible","Visible",!0,"bool");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"PANEL1",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"UNNAMEDTABLEANO",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"TEXTBLOCKANO",format:0,grid:0,ctrltype:"textblock"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vANO",gxz:"ZV5Ano",gxold:"OV5Ano",gxvar:"AV5Ano",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV5Ano=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV5Ano=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vANO",gx.O.AV5Ano,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV5Ano=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vANO",",")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"UNNAMEDTABLEMES",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"TEXTBLOCKMES",format:0,grid:0,ctrltype:"textblock"};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"int",len:2,dec:0,sign:!1,pic:"Z9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vMES",gxz:"ZV12Mes",gxold:"OV12Mes",gxvar:"AV12Mes",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV12Mes=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV12Mes=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("vMES",gx.O.AV12Mes)},c2v:function(){this.val()!==undefined&&(gx.O.AV12Mes=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vMES",",")},nac:gx.falseFn};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"UNNAMEDTABLETASICOD",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"TEXTBLOCKTASICOD",format:0,grid:0,ctrltype:"textblock"};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTASICOD",gxz:"ZV13TASICod",gxold:"OV13TASICod",gxvar:"AV13TASICod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"dyncombo",v2v:function(n){n!==undefined&&(gx.O.AV13TASICod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV13TASICod=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("vTASICOD",gx.O.AV13TASICod)},c2v:function(){this.val()!==undefined&&(gx.O.AV13TASICod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vTASICOD",",")},nac:gx.falseFn};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"UNNAMEDTABLETIPO",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"TEXTBLOCKTIPO",format:0,grid:0,ctrltype:"textblock"};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,lvl:0,type:"char",len:1,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTIPO",gxz:"ZV15Tipo",gxold:"OV15Tipo",gxvar:"AV15Tipo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"radio",v2v:function(n){n!==undefined&&(gx.O.AV15Tipo=n)},v2z:function(n){n!==undefined&&(gx.O.ZV15Tipo=n)},v2c:function(){gx.fn.setRadioValue("vTIPO",gx.O.AV15Tipo)},c2v:function(){this.val()!==undefined&&(gx.O.AV15Tipo=this.val())},val:function(){return gx.fn.getControlValue("vTIPO")},nac:gx.falseFn};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"TABLESPLITTEDCCUENTA1",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"TEXTBLOCKCCUENTA1",format:0,grid:0,ctrltype:"textblock"};n[58]={id:58,fld:"",grid:0};n[59]={id:59,fld:"TABLEMERGEDCCUENTA1",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,lvl:0,type:"char",len:15,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCCUENTA1",gxz:"ZV7cCuenta1",gxold:"OV7cCuenta1",gxvar:"AV7cCuenta1",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7cCuenta1=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7cCuenta1=n)},v2c:function(){gx.fn.setControlValue("vCCUENTA1",gx.O.AV7cCuenta1,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7cCuenta1=this.val())},val:function(){return gx.fn.getControlValue("vCCUENTA1")},nac:gx.falseFn};n[65]={id:65,fld:"BTNBUSCARCUE",grid:0,evt:"e175z1_client"};n[67]={id:67,fld:"",grid:0};n[68]={id:68,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCCUEDSC1",gxz:"ZV6cCueDsc1",gxold:"OV6cCueDsc1",gxvar:"AV6cCueDsc1",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6cCueDsc1=n)},v2z:function(n){n!==undefined&&(gx.O.ZV6cCueDsc1=n)},v2c:function(){gx.fn.setControlValue("vCCUEDSC1",gx.O.AV6cCueDsc1,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6cCueDsc1=this.val())},val:function(){return gx.fn.getControlValue("vCCUEDSC1")},nac:gx.falseFn};n[69]={id:69,fld:"",grid:0};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"BTNBTNIMPRIMIR",grid:0,evt:"e125z2_client"};n[74]={id:74,fld:"",grid:0};n[75]={id:75,fld:"BTNBTNEXCEL",grid:0,evt:"e135z2_client"};n[76]={id:76,fld:"",grid:0};n[77]={id:77,fld:"BTNBTNEXCEL2",grid:0,evt:"e145z2_client"};n[78]={id:78,fld:"",grid:0};n[79]={id:79,fld:"BTNBTNSALIR",grid:0,evt:"e155z2_client"};n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"",grid:0};this.AV5Ano=0;this.ZV5Ano=0;this.OV5Ano=0;this.AV12Mes=0;this.ZV12Mes=0;this.OV12Mes=0;this.AV13TASICod=0;this.ZV13TASICod=0;this.OV13TASICod=0;this.AV15Tipo="";this.ZV15Tipo="";this.OV15Tipo="";this.AV7cCuenta1="";this.ZV7cCuenta1="";this.OV7cCuenta1="";this.AV6cCueDsc1="";this.ZV6cCueDsc1="";this.OV6cCueDsc1="";this.AV5Ano=0;this.AV12Mes=0;this.AV13TASICod=0;this.AV15Tipo="";this.AV7cCuenta1="";this.AV6cCueDsc1="";this.Events={e125z2_client:["'DOBTNIMPRIMIR'",!0],e135z2_client:["'DOBTNEXCEL'",!0],e145z2_client:["'DOBTNEXCEL2'",!0],e155z2_client:["'DOBTNSALIR'",!0],e185z2_client:["ENTER",!0],e195z2_client:["CANCEL",!0],e175z1_client:["'DOBTNBUSCARCUE'",!1]};this.EvtParms.REFRESH=[[{ctrl:"vTASICOD"},{av:"AV13TASICod",fld:"vTASICOD",pic:"ZZZZZ9"},{ctrl:"vTIPO"},{av:"AV15Tipo",fld:"vTIPO",pic:""}],[{ctrl:"vTASICOD"},{av:"AV13TASICod",fld:"vTASICOD",pic:"ZZZZZ9"},{ctrl:"vTIPO"},{av:"AV15Tipo",fld:"vTIPO",pic:""}]];this.EvtParms["'DOBTNIMPRIMIR'"]=[[{av:"AV5Ano",fld:"vANO",pic:"ZZZ9"},{ctrl:"vMES"},{av:"AV12Mes",fld:"vMES",pic:"Z9"},{av:"AV7cCuenta1",fld:"vCCUENTA1",pic:""},{ctrl:"vTASICOD"},{av:"AV13TASICod",fld:"vTASICOD",pic:"ZZZZZ9"},{ctrl:"vTIPO"},{av:"AV15Tipo",fld:"vTIPO",pic:""}],[{av:"this.INNEWWINDOWContainer.Target",ctrl:"INNEWWINDOW",prop:"Target"},{ctrl:"vTASICOD"},{av:"AV13TASICod",fld:"vTASICOD",pic:"ZZZZZ9"},{ctrl:"vTIPO"},{av:"AV15Tipo",fld:"vTIPO",pic:""}]];this.EvtParms["'DOBTNEXCEL'"]=[[{av:"AV5Ano",fld:"vANO",pic:"ZZZ9"},{ctrl:"vMES"},{av:"AV12Mes",fld:"vMES",pic:"Z9"},{ctrl:"vTASICOD"},{av:"AV13TASICod",fld:"vTASICOD",pic:"ZZZZZ9"},{ctrl:"vTIPO"},{av:"AV15Tipo",fld:"vTIPO",pic:""}],[{ctrl:"vMES"},{av:"AV12Mes",fld:"vMES",pic:"Z9"},{av:"AV5Ano",fld:"vANO",pic:"ZZZ9"},{ctrl:"vTASICOD"},{av:"AV13TASICod",fld:"vTASICOD",pic:"ZZZZZ9"},{ctrl:"vTIPO"},{av:"AV15Tipo",fld:"vTIPO",pic:""}]];this.EvtParms["'DOBTNEXCEL2'"]=[[{av:"AV5Ano",fld:"vANO",pic:"ZZZ9"},{ctrl:"vMES"},{av:"AV12Mes",fld:"vMES",pic:"Z9"},{ctrl:"vTASICOD"},{av:"AV13TASICod",fld:"vTASICOD",pic:"ZZZZZ9"},{ctrl:"vTIPO"},{av:"AV15Tipo",fld:"vTIPO",pic:""}],[{ctrl:"vMES"},{av:"AV12Mes",fld:"vMES",pic:"Z9"},{av:"AV5Ano",fld:"vANO",pic:"ZZZ9"},{ctrl:"vTASICOD"},{av:"AV13TASICod",fld:"vTASICOD",pic:"ZZZZZ9"},{ctrl:"vTIPO"},{av:"AV15Tipo",fld:"vTIPO",pic:""}]];this.EvtParms["'DOBTNSALIR'"]=[[{ctrl:"vTASICOD"},{av:"AV13TASICod",fld:"vTASICOD",pic:"ZZZZZ9"},{ctrl:"vTIPO"},{av:"AV15Tipo",fld:"vTIPO",pic:""}],[{ctrl:"vTASICOD"},{av:"AV13TASICod",fld:"vTASICOD",pic:"ZZZZZ9"},{ctrl:"vTIPO"},{av:"AV15Tipo",fld:"vTIPO",pic:""}]];this.EvtParms["'DOBTNBUSCARCUE'"]=[[{av:"AV7cCuenta1",fld:"vCCUENTA1",pic:""},{ctrl:"vTASICOD"},{av:"AV13TASICod",fld:"vTASICOD",pic:"ZZZZZ9"},{ctrl:"vTIPO"},{av:"AV15Tipo",fld:"vTIPO",pic:""}],[{av:"AV6cCueDsc1",fld:"vCCUEDSC1",pic:""},{av:"AV7cCuenta1",fld:"vCCUENTA1",pic:""},{ctrl:"vTASICOD"},{av:"AV13TASICod",fld:"vTASICOD",pic:"ZZZZZ9"},{ctrl:"vTIPO"},{av:"AV15Tipo",fld:"vTIPO",pic:""}]];this.EvtParms.ENTER=[[{ctrl:"vTASICOD"},{av:"AV13TASICod",fld:"vTASICOD",pic:"ZZZZZ9"},{ctrl:"vTIPO"},{av:"AV15Tipo",fld:"vTIPO",pic:""}],[{ctrl:"vTASICOD"},{av:"AV13TASICod",fld:"vTASICOD",pic:"ZZZZZ9"},{ctrl:"vTIPO"},{av:"AV15Tipo",fld:"vTIPO",pic:""}]];this.Initialize();this.setSDTMapping("WWPBaseObjects\\DVB_SDTComboData.Item",{Title:{extr:"T"},Children:{extr:"C"}})});gx.wi(function(){gx.createParentObj(this.contabilidad.r_librodiario)})