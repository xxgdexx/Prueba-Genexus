gx.evt.autoSkip=!1;gx.define("contabilidad.r_libromayoranalitico",!1,function(){var n,i,t;this.ServerClass="contabilidad.r_libromayoranalitico";this.PackageName="GeneXus.Programs";this.ServerFullClass="contabilidad.r_libromayoranalitico.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV6cCosto=gx.fn.getControlValue("vCCOSTO")};this.e17611_client=function(){return this.clearMessages(),this.popupOpenUrl(gx.http.formatLink("generales.wwbusquedaplancuenta.aspx",[this.AV9cCuenta1,""]),["AV9cCuenta1","AV7cCueDsc1"]),this.refreshOutputs([{av:"AV7cCueDsc1",fld:"vCCUEDSC1",pic:""},{av:"AV9cCuenta1",fld:"vCCUENTA1",pic:""},{ctrl:"vTIPO"},{av:"AV20Tipo",fld:"vTIPO",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e16611_client=function(){return this.clearMessages(),this.popupOpenUrl(gx.http.formatLink("generales.wwbusquedaplancuenta.aspx",[this.AV10cCuenta2,""]),["AV10cCuenta2","AV8cCueDsc2"]),this.refreshOutputs([{av:"AV8cCueDsc2",fld:"vCCUEDSC2",pic:""},{av:"AV10cCuenta2",fld:"vCCUENTA2",pic:""},{ctrl:"vTIPO"},{av:"AV20Tipo",fld:"vTIPO",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e15611_client=function(){return this.clearMessages(),this.popupOpenUrl(gx.http.formatLink("generales.wwbusquedaauxiliar.aspx",[this.AV18TipADCod,this.AV19TipADsc]),["AV18TipADCod","AV19TipADsc"]),this.refreshOutputs([{av:"AV19TipADsc",fld:"vTIPADSC",pic:""},{av:"AV18TipADCod",fld:"vTIPADCOD",pic:""},{ctrl:"vTIPO"},{av:"AV20Tipo",fld:"vTIPO",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e12612_client=function(){return this.executeServerEvent("'DOBTNIMPRIMIR'",!1,null,!1,!1)};this.e13612_client=function(){return this.executeServerEvent("'DOBTNSALIR'",!1,null,!1,!1)};this.e18612_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e19612_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,45,46,48,50,51,52,53,54,55,56,57,58,61,62,64,66,67,68,69,70,71,72,73,74,75,78,79,81,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100,101];this.GXLastCtrlId=101;this.DVPANEL_PANEL1Container=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_PANEL1Container","Dvpanel_panel1","DVPANEL_PANEL1");i=this.DVPANEL_PANEL1Container;i.setProp("Class","Class","","char");i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("Width","Width","100%","str");i.setProp("Height","Height","100","str");i.setProp("AutoWidth","Autowidth",!1,"bool");i.setProp("AutoHeight","Autoheight",!0,"bool");i.setProp("Cls","Cls","PanelFilled Panel_BaseColor","str");i.setProp("ShowHeader","Showheader",!0,"bool");i.setProp("Title","Title","Libro Mayor Analitico","str");i.setProp("Collapsible","Collapsible",!0,"bool");i.setProp("Collapsed","Collapsed",!1,"bool");i.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");i.setProp("IconPosition","Iconposition","Right","str");i.setProp("AutoScroll","Autoscroll",!1,"bool");i.setProp("Visible","Visible",!0,"bool");i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});this.setUserControl(i);this.INNEWWINDOWContainer=gx.uc.getNew(this,102,26,"InNewWindow","INNEWWINDOWContainer","Innewwindow","INNEWWINDOW");t=this.INNEWWINDOWContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Width","Width","50","str");t.setProp("Height","Height","50","str");t.setProp("Name","Name","","str");t.setDynProp("Target","Target","","str");t.setProp("Fullscreen","Fullscreen",!1,"bool");t.setProp("Location","Location",!0,"bool");t.setProp("MenuBar","Menubar",!0,"bool");t.setProp("Resizable","Resizable",!0,"bool");t.setProp("Scrollbars","Scrollbars",!0,"bool");t.setProp("TitleBar","Titlebar",!0,"bool");t.setProp("ToolBar","Toolbar",!0,"bool");t.setProp("directories","Directories",!0,"bool");t.setProp("status","Status",!0,"bool");t.setProp("copyhistory","Copyhistory",!0,"bool");t.setProp("top","Top","5","str");t.setProp("left","Left","5","str");t.setProp("fitscreen","Fitscreen",!1,"bool");t.setProp("RefreshParentOnClose","Refreshparentonclose",!1,"bool");t.setProp("Targets","Targets","","str");t.setProp("Visible","Visible",!0,"bool");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"PANEL1",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"UNNAMEDTABLEANO",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"TEXTBLOCKANO",format:0,grid:0,ctrltype:"textblock"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vANO",gxz:"ZV5Ano",gxold:"OV5Ano",gxvar:"AV5Ano",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV5Ano=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV5Ano=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vANO",gx.O.AV5Ano,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV5Ano=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vANO",",")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"UNNAMEDTABLEMES",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"TEXTBLOCKMES",format:0,grid:0,ctrltype:"textblock"};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"int",len:2,dec:0,sign:!1,pic:"Z9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vMES",gxz:"ZV15Mes",gxold:"OV15Mes",gxvar:"AV15Mes",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV15Mes=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV15Mes=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("vMES",gx.O.AV15Mes)},c2v:function(){this.val()!==undefined&&(gx.O.AV15Mes=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vMES",",")},nac:gx.falseFn};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"TABLESPLITTEDCCUENTA1",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"TEXTBLOCKCCUENTA1",format:0,grid:0,ctrltype:"textblock"};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"TABLEMERGEDCCUENTA1",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,lvl:0,type:"char",len:15,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCCUENTA1",gxz:"ZV9cCuenta1",gxold:"OV9cCuenta1",gxvar:"AV9cCuenta1",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV9cCuenta1=n)},v2z:function(n){n!==undefined&&(gx.O.ZV9cCuenta1=n)},v2c:function(){gx.fn.setControlValue("vCCUENTA1",gx.O.AV9cCuenta1,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV9cCuenta1=this.val())},val:function(){return gx.fn.getControlValue("vCCUENTA1")},nac:gx.falseFn};n[48]={id:48,fld:"BTNBUSCARCUE",grid:0,evt:"e17611_client"};n[50]={id:50,fld:"",grid:0};n[51]={id:51,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCCUEDSC1",gxz:"ZV7cCueDsc1",gxold:"OV7cCueDsc1",gxvar:"AV7cCueDsc1",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7cCueDsc1=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7cCueDsc1=n)},v2c:function(){gx.fn.setControlValue("vCCUEDSC1",gx.O.AV7cCueDsc1,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7cCueDsc1=this.val())},val:function(){return gx.fn.getControlValue("vCCUEDSC1")},nac:gx.falseFn};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"TABLESPLITTEDCCUENTA2",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"TEXTBLOCKCCUENTA2",format:0,grid:0,ctrltype:"textblock"};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"TABLEMERGEDCCUENTA2",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,lvl:0,type:"char",len:15,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCCUENTA2",gxz:"ZV10cCuenta2",gxold:"OV10cCuenta2",gxvar:"AV10cCuenta2",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV10cCuenta2=n)},v2z:function(n){n!==undefined&&(gx.O.ZV10cCuenta2=n)},v2c:function(){gx.fn.setControlValue("vCCUENTA2",gx.O.AV10cCuenta2,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV10cCuenta2=this.val())},val:function(){return gx.fn.getControlValue("vCCUENTA2")},nac:gx.falseFn};n[64]={id:64,fld:"BTNBUSCARCUE2",grid:0,evt:"e16611_client"};n[66]={id:66,fld:"",grid:0};n[67]={id:67,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCCUEDSC2",gxz:"ZV8cCueDsc2",gxold:"OV8cCueDsc2",gxvar:"AV8cCueDsc2",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8cCueDsc2=n)},v2z:function(n){n!==undefined&&(gx.O.ZV8cCueDsc2=n)},v2c:function(){gx.fn.setControlValue("vCCUEDSC2",gx.O.AV8cCueDsc2,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8cCueDsc2=this.val())},val:function(){return gx.fn.getControlValue("vCCUEDSC2")},nac:gx.falseFn};n[68]={id:68,fld:"",grid:0};n[69]={id:69,fld:"",grid:0};n[70]={id:70,fld:"TABLESPLITTEDTIPADCOD",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"TEXTBLOCKTIPADCOD",format:0,grid:0,ctrltype:"textblock"};n[74]={id:74,fld:"",grid:0};n[75]={id:75,fld:"TABLEMERGEDTIPADCOD",grid:0};n[78]={id:78,fld:"",grid:0};n[79]={id:79,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTIPADCOD",gxz:"ZV18TipADCod",gxold:"OV18TipADCod",gxvar:"AV18TipADCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV18TipADCod=n)},v2z:function(n){n!==undefined&&(gx.O.ZV18TipADCod=n)},v2c:function(){gx.fn.setControlValue("vTIPADCOD",gx.O.AV18TipADCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV18TipADCod=this.val())},val:function(){return gx.fn.getControlValue("vTIPADCOD")},nac:gx.falseFn};n[81]={id:81,fld:"BTNBUSCARAUX",grid:0,evt:"e15611_client"};n[83]={id:83,fld:"",grid:0};n[84]={id:84,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTIPADSC",gxz:"ZV19TipADsc",gxold:"OV19TipADsc",gxvar:"AV19TipADsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV19TipADsc=n)},v2z:function(n){n!==undefined&&(gx.O.ZV19TipADsc=n)},v2c:function(){gx.fn.setControlValue("vTIPADSC",gx.O.AV19TipADsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV19TipADsc=this.val())},val:function(){return gx.fn.getControlValue("vTIPADSC")},nac:gx.falseFn};n[85]={id:85,fld:"",grid:0};n[86]={id:86,fld:"UNNAMEDTABLETIPO",grid:0};n[87]={id:87,fld:"",grid:0};n[88]={id:88,fld:"",grid:0};n[89]={id:89,fld:"TEXTBLOCKTIPO",format:0,grid:0,ctrltype:"textblock"};n[90]={id:90,fld:"",grid:0};n[91]={id:91,fld:"",grid:0};n[92]={id:92,lvl:0,type:"char",len:1,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTIPO",gxz:"ZV20Tipo",gxold:"OV20Tipo",gxvar:"AV20Tipo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"radio",v2v:function(n){n!==undefined&&(gx.O.AV20Tipo=n)},v2z:function(n){n!==undefined&&(gx.O.ZV20Tipo=n)},v2c:function(){gx.fn.setRadioValue("vTIPO",gx.O.AV20Tipo)},c2v:function(){this.val()!==undefined&&(gx.O.AV20Tipo=this.val())},val:function(){return gx.fn.getControlValue("vTIPO")},nac:gx.falseFn};n[93]={id:93,fld:"",grid:0};n[94]={id:94,fld:"",grid:0};n[95]={id:95,fld:"",grid:0};n[96]={id:96,fld:"",grid:0};n[97]={id:97,fld:"BTNBTNIMPRIMIR",grid:0,evt:"e12612_client"};n[98]={id:98,fld:"",grid:0};n[99]={id:99,fld:"BTNBTNSALIR",grid:0,evt:"e13612_client"};n[100]={id:100,fld:"",grid:0};n[101]={id:101,fld:"",grid:0};this.AV5Ano=0;this.ZV5Ano=0;this.OV5Ano=0;this.AV15Mes=0;this.ZV15Mes=0;this.OV15Mes=0;this.AV9cCuenta1="";this.ZV9cCuenta1="";this.OV9cCuenta1="";this.AV7cCueDsc1="";this.ZV7cCueDsc1="";this.OV7cCueDsc1="";this.AV10cCuenta2="";this.ZV10cCuenta2="";this.OV10cCuenta2="";this.AV8cCueDsc2="";this.ZV8cCueDsc2="";this.OV8cCueDsc2="";this.AV18TipADCod="";this.ZV18TipADCod="";this.OV18TipADCod="";this.AV19TipADsc="";this.ZV19TipADsc="";this.OV19TipADsc="";this.AV20Tipo="";this.ZV20Tipo="";this.OV20Tipo="";this.AV5Ano=0;this.AV15Mes=0;this.AV9cCuenta1="";this.AV7cCueDsc1="";this.AV10cCuenta2="";this.AV8cCueDsc2="";this.AV18TipADCod="";this.AV19TipADsc="";this.AV20Tipo="";this.AV6cCosto="";this.Events={e12612_client:["'DOBTNIMPRIMIR'",!0],e13612_client:["'DOBTNSALIR'",!0],e18612_client:["ENTER",!0],e19612_client:["CANCEL",!0],e17611_client:["'DOBTNBUSCARCUE'",!1],e16611_client:["'DOBTNBUSCARCUE2'",!1],e15611_client:["'DOBTNBUSCARAUX'",!1]};this.EvtParms.REFRESH=[[{av:"AV6cCosto",fld:"vCCOSTO",pic:"",hsh:!0},{ctrl:"vTIPO"},{av:"AV20Tipo",fld:"vTIPO",pic:""}],[{ctrl:"vTIPO"},{av:"AV20Tipo",fld:"vTIPO",pic:""}]];this.EvtParms["'DOBTNIMPRIMIR'"]=[[{av:"AV5Ano",fld:"vANO",pic:"ZZZ9"},{ctrl:"vMES"},{av:"AV15Mes",fld:"vMES",pic:"Z9"},{av:"AV6cCosto",fld:"vCCOSTO",pic:"",hsh:!0},{av:"AV9cCuenta1",fld:"vCCUENTA1",pic:""},{av:"AV10cCuenta2",fld:"vCCUENTA2",pic:""},{av:"AV18TipADCod",fld:"vTIPADCOD",pic:""},{ctrl:"vTIPO"},{av:"AV20Tipo",fld:"vTIPO",pic:""}],[{av:"this.INNEWWINDOWContainer.Target",ctrl:"INNEWWINDOW",prop:"Target"},{ctrl:"vTIPO"},{av:"AV20Tipo",fld:"vTIPO",pic:""}]];this.EvtParms["'DOBTNSALIR'"]=[[{ctrl:"vTIPO"},{av:"AV20Tipo",fld:"vTIPO",pic:""}],[{ctrl:"vTIPO"},{av:"AV20Tipo",fld:"vTIPO",pic:""}]];this.EvtParms["'DOBTNBUSCARCUE'"]=[[{av:"AV9cCuenta1",fld:"vCCUENTA1",pic:""},{ctrl:"vTIPO"},{av:"AV20Tipo",fld:"vTIPO",pic:""}],[{av:"AV7cCueDsc1",fld:"vCCUEDSC1",pic:""},{av:"AV9cCuenta1",fld:"vCCUENTA1",pic:""},{ctrl:"vTIPO"},{av:"AV20Tipo",fld:"vTIPO",pic:""}]];this.EvtParms["'DOBTNBUSCARCUE2'"]=[[{av:"AV10cCuenta2",fld:"vCCUENTA2",pic:""},{ctrl:"vTIPO"},{av:"AV20Tipo",fld:"vTIPO",pic:""}],[{av:"AV8cCueDsc2",fld:"vCCUEDSC2",pic:""},{av:"AV10cCuenta2",fld:"vCCUENTA2",pic:""},{ctrl:"vTIPO"},{av:"AV20Tipo",fld:"vTIPO",pic:""}]];this.EvtParms["'DOBTNBUSCARAUX'"]=[[{av:"AV18TipADCod",fld:"vTIPADCOD",pic:""},{av:"AV19TipADsc",fld:"vTIPADSC",pic:""},{ctrl:"vTIPO"},{av:"AV20Tipo",fld:"vTIPO",pic:""}],[{av:"AV19TipADsc",fld:"vTIPADSC",pic:""},{av:"AV18TipADCod",fld:"vTIPADCOD",pic:""},{ctrl:"vTIPO"},{av:"AV20Tipo",fld:"vTIPO",pic:""}]];this.EvtParms.ENTER=[[{ctrl:"vTIPO"},{av:"AV20Tipo",fld:"vTIPO",pic:""}],[{ctrl:"vTIPO"},{av:"AV20Tipo",fld:"vTIPO",pic:""}]];this.setVCMap("AV6cCosto","vCCOSTO",0,"char",10,0);this.Initialize();this.setSDTMapping("WWPBaseObjects\\DVB_SDTComboData.Item",{Title:{extr:"T"},Children:{extr:"C"}})});gx.wi(function(){gx.createParentObj(this.contabilidad.r_libromayoranalitico)})