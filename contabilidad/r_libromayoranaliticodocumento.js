gx.evt.autoSkip=!1;gx.define("contabilidad.r_libromayoranaliticodocumento",!1,function(){var n,i,t;this.ServerClass="contabilidad.r_libromayoranaliticodocumento";this.PackageName="GeneXus.Programs";this.ServerFullClass="contabilidad.r_libromayoranaliticodocumento.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV11cCuenta2=gx.fn.getControlValue("vCCUENTA2")};this.Validv_Fdesde=function(){return this.validCliEvt("Validv_Fdesde",0,function(){try{var n=gx.util.balloon.getNew("vFDESDE");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV16FDesde)===0||new gx.date.gxdate(this.AV16FDesde).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo FDesde fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}this.refreshOutputs([{ctrl:"vCCOSTO"},{av:"AV6cCosto",fld:"vCCOSTO",pic:""}])}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Fhasta=function(){return this.validCliEvt("Validv_Fhasta",0,function(){try{var n=gx.util.balloon.getNew("vFHASTA");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV17FHasta)===0||new gx.date.gxdate(this.AV17FHasta).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo FHasta fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}this.refreshOutputs([{ctrl:"vCCOSTO"},{av:"AV6cCosto",fld:"vCCOSTO",pic:""}])}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e17621_client=function(){return this.clearMessages(),this.popupOpenUrl(gx.http.formatLink("generales.wwbusquedaplancuenta.aspx",[this.AV10cCuenta1,""]),["AV10cCuenta1","AV8cCueDsc1"]),this.refreshOutputs([{av:"AV8cCueDsc1",fld:"vCCUEDSC1",pic:""},{av:"AV10cCuenta1",fld:"vCCUENTA1",pic:""},{ctrl:"vCCOSTO"},{av:"AV6cCosto",fld:"vCCOSTO",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e16621_client=function(){return this.clearMessages(),this.popupOpenUrl(gx.http.formatLink("generales.wwbusquedaauxiliar.aspx",[this.AV22TipADCod,this.AV23TipADsc]),["AV22TipADCod","AV23TipADsc"]),this.refreshOutputs([{av:"AV23TipADsc",fld:"vTIPADSC",pic:""},{av:"AV22TipADCod",fld:"vTIPADCOD",pic:""},{ctrl:"vCCOSTO"},{av:"AV6cCosto",fld:"vCCOSTO",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e12622_client=function(){return this.executeServerEvent("'DOBTNIMPRIMIR'",!1,null,!1,!1)};this.e13622_client=function(){return this.executeServerEvent("'DOBTNEXCEL'",!1,null,!1,!1)};this.e14622_client=function(){return this.executeServerEvent("'DOBTNSALIR'",!1,null,!1,!1)};this.e18622_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e19622_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,53,54,56,58,59,60,61,62,63,64,65,66,67,70,71,73,75,76,77,78,79,80,81,82,83,84,85,86,87];this.GXLastCtrlId=87;this.DVPANEL_PANEL1Container=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_PANEL1Container","Dvpanel_panel1","DVPANEL_PANEL1");i=this.DVPANEL_PANEL1Container;i.setProp("Class","Class","","char");i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("Width","Width","100%","str");i.setProp("Height","Height","100","str");i.setProp("AutoWidth","Autowidth",!1,"bool");i.setProp("AutoHeight","Autoheight",!0,"bool");i.setProp("Cls","Cls","PanelFilled Panel_BaseColor","str");i.setProp("ShowHeader","Showheader",!0,"bool");i.setProp("Title","Title","Libro Mayor Analitico por Documento","str");i.setProp("Collapsible","Collapsible",!0,"bool");i.setProp("Collapsed","Collapsed",!1,"bool");i.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");i.setProp("IconPosition","Iconposition","Right","str");i.setProp("AutoScroll","Autoscroll",!1,"bool");i.setProp("Visible","Visible",!0,"bool");i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});this.setUserControl(i);this.INNEWWINDOWContainer=gx.uc.getNew(this,88,26,"InNewWindow","INNEWWINDOWContainer","Innewwindow","INNEWWINDOW");t=this.INNEWWINDOWContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Width","Width","50","str");t.setProp("Height","Height","50","str");t.setProp("Name","Name","","str");t.setDynProp("Target","Target","","str");t.setProp("Fullscreen","Fullscreen",!1,"bool");t.setProp("Location","Location",!0,"bool");t.setProp("MenuBar","Menubar",!0,"bool");t.setProp("Resizable","Resizable",!0,"bool");t.setProp("Scrollbars","Scrollbars",!0,"bool");t.setProp("TitleBar","Titlebar",!0,"bool");t.setProp("ToolBar","Toolbar",!0,"bool");t.setProp("directories","Directories",!0,"bool");t.setProp("status","Status",!0,"bool");t.setProp("copyhistory","Copyhistory",!0,"bool");t.setProp("top","Top","5","str");t.setProp("left","Left","5","str");t.setProp("fitscreen","Fitscreen",!1,"bool");t.setProp("RefreshParentOnClose","Refreshparentonclose",!1,"bool");t.setProp("Targets","Targets","","str");t.setProp("Visible","Visible",!0,"bool");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"PANEL1",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"UNNAMEDTABLEFDESDE",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"TEXTBLOCKFDESDE",format:0,grid:0,ctrltype:"textblock"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Fdesde,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFDESDE",gxz:"ZV16FDesde",gxold:"OV16FDesde",gxvar:"AV16FDesde",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[26],ip:[26],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV16FDesde=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV16FDesde=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vFDESDE",gx.O.AV16FDesde,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV16FDesde=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vFDESDE")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"UNNAMEDTABLEFHASTA",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"TEXTBLOCKFHASTA",format:0,grid:0,ctrltype:"textblock"};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Fhasta,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFHASTA",gxz:"ZV17FHasta",gxold:"OV17FHasta",gxvar:"AV17FHasta",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[34],ip:[34],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV17FHasta=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV17FHasta=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vFHASTA",gx.O.AV17FHasta,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV17FHasta=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vFHASTA")},nac:gx.falseFn};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"UNNAMEDTABLECCOSTO",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"TEXTBLOCKCCOSTO",format:0,grid:0,ctrltype:"textblock"};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,lvl:0,type:"char",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCCOSTO",gxz:"ZV6cCosto",gxold:"OV6cCosto",gxvar:"AV6cCosto",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"dyncombo",v2v:function(n){n!==undefined&&(gx.O.AV6cCosto=n)},v2z:function(n){n!==undefined&&(gx.O.ZV6cCosto=n)},v2c:function(){gx.fn.setComboBoxValue("vCCOSTO",gx.O.AV6cCosto)},c2v:function(){this.val()!==undefined&&(gx.O.AV6cCosto=this.val())},val:function(){return gx.fn.getControlValue("vCCOSTO")},nac:gx.falseFn};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"TABLESPLITTEDCCUENTA1",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"TEXTBLOCKCCUENTA1",format:0,grid:0,ctrltype:"textblock"};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"TABLEMERGEDCCUENTA1",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,lvl:0,type:"char",len:15,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCCUENTA1",gxz:"ZV10cCuenta1",gxold:"OV10cCuenta1",gxvar:"AV10cCuenta1",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV10cCuenta1=n)},v2z:function(n){n!==undefined&&(gx.O.ZV10cCuenta1=n)},v2c:function(){gx.fn.setControlValue("vCCUENTA1",gx.O.AV10cCuenta1,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV10cCuenta1=this.val())},val:function(){return gx.fn.getControlValue("vCCUENTA1")},nac:gx.falseFn};n[56]={id:56,fld:"BTNBUSCARCUE",grid:0,evt:"e17621_client"};n[58]={id:58,fld:"",grid:0};n[59]={id:59,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCCUEDSC1",gxz:"ZV8cCueDsc1",gxold:"OV8cCueDsc1",gxvar:"AV8cCueDsc1",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8cCueDsc1=n)},v2z:function(n){n!==undefined&&(gx.O.ZV8cCueDsc1=n)},v2c:function(){gx.fn.setControlValue("vCCUEDSC1",gx.O.AV8cCueDsc1,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8cCueDsc1=this.val())},val:function(){return gx.fn.getControlValue("vCCUEDSC1")},nac:gx.falseFn};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"TABLESPLITTEDTIPADCOD",grid:0};n[63]={id:63,fld:"",grid:0};n[64]={id:64,fld:"",grid:0};n[65]={id:65,fld:"TEXTBLOCKTIPADCOD",format:0,grid:0,ctrltype:"textblock"};n[66]={id:66,fld:"",grid:0};n[67]={id:67,fld:"TABLEMERGEDTIPADCOD",grid:0};n[70]={id:70,fld:"",grid:0};n[71]={id:71,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTIPADCOD",gxz:"ZV22TipADCod",gxold:"OV22TipADCod",gxvar:"AV22TipADCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV22TipADCod=n)},v2z:function(n){n!==undefined&&(gx.O.ZV22TipADCod=n)},v2c:function(){gx.fn.setControlValue("vTIPADCOD",gx.O.AV22TipADCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV22TipADCod=this.val())},val:function(){return gx.fn.getControlValue("vTIPADCOD")},nac:gx.falseFn};n[73]={id:73,fld:"BTNBUSCARAUX",grid:0,evt:"e16621_client"};n[75]={id:75,fld:"",grid:0};n[76]={id:76,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTIPADSC",gxz:"ZV23TipADsc",gxold:"OV23TipADsc",gxvar:"AV23TipADsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV23TipADsc=n)},v2z:function(n){n!==undefined&&(gx.O.ZV23TipADsc=n)},v2c:function(){gx.fn.setControlValue("vTIPADSC",gx.O.AV23TipADsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV23TipADsc=this.val())},val:function(){return gx.fn.getControlValue("vTIPADSC")},nac:gx.falseFn};n[77]={id:77,fld:"",grid:0};n[78]={id:78,fld:"",grid:0};n[79]={id:79,fld:"",grid:0};n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"BTNBTNIMPRIMIR",grid:0,evt:"e12622_client"};n[82]={id:82,fld:"",grid:0};n[83]={id:83,fld:"BTNBTNEXCEL",grid:0,evt:"e13622_client"};n[84]={id:84,fld:"",grid:0};n[85]={id:85,fld:"BTNBTNSALIR",grid:0,evt:"e14622_client"};n[86]={id:86,fld:"",grid:0};n[87]={id:87,fld:"",grid:0};this.AV16FDesde=gx.date.nullDate();this.ZV16FDesde=gx.date.nullDate();this.OV16FDesde=gx.date.nullDate();this.AV17FHasta=gx.date.nullDate();this.ZV17FHasta=gx.date.nullDate();this.OV17FHasta=gx.date.nullDate();this.AV6cCosto="";this.ZV6cCosto="";this.OV6cCosto="";this.AV10cCuenta1="";this.ZV10cCuenta1="";this.OV10cCuenta1="";this.AV8cCueDsc1="";this.ZV8cCueDsc1="";this.OV8cCueDsc1="";this.AV22TipADCod="";this.ZV22TipADCod="";this.OV22TipADCod="";this.AV23TipADsc="";this.ZV23TipADsc="";this.OV23TipADsc="";this.AV16FDesde=gx.date.nullDate();this.AV17FHasta=gx.date.nullDate();this.AV6cCosto="";this.AV10cCuenta1="";this.AV8cCueDsc1="";this.AV22TipADCod="";this.AV23TipADsc="";this.AV11cCuenta2="";this.Events={e12622_client:["'DOBTNIMPRIMIR'",!0],e13622_client:["'DOBTNEXCEL'",!0],e14622_client:["'DOBTNSALIR'",!0],e18622_client:["ENTER",!0],e19622_client:["CANCEL",!0],e17621_client:["'DOBTNBUSCARCUE'",!1],e16621_client:["'DOBTNBUSCARAUX'",!1]};this.EvtParms.REFRESH=[[{ctrl:"vCCOSTO"},{av:"AV6cCosto",fld:"vCCOSTO",pic:""}],[{ctrl:"vCCOSTO"},{av:"AV6cCosto",fld:"vCCOSTO",pic:""}]];this.EvtParms["'DOBTNIMPRIMIR'"]=[[{av:"AV10cCuenta1",fld:"vCCUENTA1",pic:""},{av:"AV16FDesde",fld:"vFDESDE",pic:""},{av:"AV17FHasta",fld:"vFHASTA",pic:""},{av:"AV11cCuenta2",fld:"vCCUENTA2",pic:""},{av:"AV22TipADCod",fld:"vTIPADCOD",pic:""},{ctrl:"vCCOSTO"},{av:"AV6cCosto",fld:"vCCOSTO",pic:""}],[{av:"this.INNEWWINDOWContainer.Target",ctrl:"INNEWWINDOW",prop:"Target"},{ctrl:"vCCOSTO"},{av:"AV6cCosto",fld:"vCCOSTO",pic:""}]];this.EvtParms["'DOBTNEXCEL'"]=[[{av:"AV10cCuenta1",fld:"vCCUENTA1",pic:""},{av:"AV16FDesde",fld:"vFDESDE",pic:""},{av:"AV17FHasta",fld:"vFHASTA",pic:""},{av:"AV11cCuenta2",fld:"vCCUENTA2",pic:""},{av:"AV22TipADCod",fld:"vTIPADCOD",pic:""},{ctrl:"vCCOSTO"},{av:"AV6cCosto",fld:"vCCOSTO",pic:""}],[{av:"AV22TipADCod",fld:"vTIPADCOD",pic:""},{av:"AV11cCuenta2",fld:"vCCUENTA2",pic:""},{av:"AV10cCuenta1",fld:"vCCUENTA1",pic:""},{av:"AV17FHasta",fld:"vFHASTA",pic:""},{av:"AV16FDesde",fld:"vFDESDE",pic:""},{ctrl:"vCCOSTO"},{av:"AV6cCosto",fld:"vCCOSTO",pic:""}]];this.EvtParms["'DOBTNSALIR'"]=[[{ctrl:"vCCOSTO"},{av:"AV6cCosto",fld:"vCCOSTO",pic:""}],[{ctrl:"vCCOSTO"},{av:"AV6cCosto",fld:"vCCOSTO",pic:""}]];this.EvtParms["'DOBTNBUSCARCUE'"]=[[{av:"AV10cCuenta1",fld:"vCCUENTA1",pic:""},{ctrl:"vCCOSTO"},{av:"AV6cCosto",fld:"vCCOSTO",pic:""}],[{av:"AV8cCueDsc1",fld:"vCCUEDSC1",pic:""},{av:"AV10cCuenta1",fld:"vCCUENTA1",pic:""},{ctrl:"vCCOSTO"},{av:"AV6cCosto",fld:"vCCOSTO",pic:""}]];this.EvtParms["'DOBTNBUSCARAUX'"]=[[{av:"AV22TipADCod",fld:"vTIPADCOD",pic:""},{av:"AV23TipADsc",fld:"vTIPADSC",pic:""},{ctrl:"vCCOSTO"},{av:"AV6cCosto",fld:"vCCOSTO",pic:""}],[{av:"AV23TipADsc",fld:"vTIPADSC",pic:""},{av:"AV22TipADCod",fld:"vTIPADCOD",pic:""},{ctrl:"vCCOSTO"},{av:"AV6cCosto",fld:"vCCOSTO",pic:""}]];this.EvtParms.ENTER=[[{ctrl:"vCCOSTO"},{av:"AV6cCosto",fld:"vCCOSTO",pic:""}],[{ctrl:"vCCOSTO"},{av:"AV6cCosto",fld:"vCCOSTO",pic:""}]];this.EvtParms.VALIDV_FDESDE=[[{ctrl:"vCCOSTO"},{av:"AV6cCosto",fld:"vCCOSTO",pic:""}],[{ctrl:"vCCOSTO"},{av:"AV6cCosto",fld:"vCCOSTO",pic:""}]];this.EvtParms.VALIDV_FHASTA=[[{ctrl:"vCCOSTO"},{av:"AV6cCosto",fld:"vCCOSTO",pic:""}],[{ctrl:"vCCOSTO"},{av:"AV6cCosto",fld:"vCCOSTO",pic:""}]];this.setVCMap("AV11cCuenta2","vCCUENTA2",0,"char",15,0);this.Initialize();this.setSDTMapping("WWPBaseObjects\\DVB_SDTComboData.Item",{Title:{extr:"T"},Children:{extr:"C"}})});gx.wi(function(){gx.createParentObj(this.contabilidad.r_libromayoranaliticodocumento)})