gx.evt.autoSkip=!1;gx.define("aguiasdetlote",!1,function(){this.ServerClass="aguiasdetlote";this.PackageName="GeneXus.Programs";this.ServerFullClass="aguiasdetlote.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Mvatip=function(){return this.validCliEvt("Valid_Mvatip",0,function(){try{var n=gx.util.balloon.getNew("MVATIP");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Mvacod=function(){return this.validCliEvt("Valid_Mvacod",0,function(){try{var n=gx.util.balloon.getNew("MVACOD");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Mvaditem=function(){return this.validSrvEvt("Valid_Mvaditem",0).then(function(n){return n}.closure(this))};this.Valid_Mvadlref1=function(){return this.validSrvEvt("Valid_Mvadlref1",0).then(function(n){return n}.closure(this))};this.Valid_Mvadlfec=function(){return this.validCliEvt("Valid_Mvadlfec",0,function(){try{var n=gx.util.balloon.getNew("MVADLFEC");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.A1252MVADLFec)==0||new gx.date.gxdate(this.A1252MVADLFec).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Fecha fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e111741_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e121741_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,5,6,7,8,9,15,18,20,23,25,28,30,33,35,38,40,41,44,46,49,51,54,56,59,61,64,66,69,70,71,72,73];this.GXLastCtrlId=73;n[2]={id:2,fld:"TABLE1",grid:0};n[5]={id:5,fld:"BTN_FIRST",grid:0,evt:"e131741_client",std:"FIRST"};n[6]={id:6,fld:"BTN_PREVIOUS",grid:0,evt:"e141741_client",std:"PREVIOUS"};n[7]={id:7,fld:"BTN_NEXT",grid:0,evt:"e151741_client",std:"NEXT"};n[8]={id:8,fld:"BTN_LAST",grid:0,evt:"e161741_client",std:"LAST"};n[9]={id:9,fld:"BTN_SELECT",grid:0,evt:"e171741_client",std:"SELECT"};n[15]={id:15,fld:"TABLE2",grid:0};n[18]={id:18,fld:"TEXTBLOCK1",format:0,grid:0,ctrltype:"textblock"};n[20]={id:20,lvl:0,type:"char",len:3,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Mvatip,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MVATIP",gxz:"Z13MvATip",gxold:"O13MvATip",gxvar:"A13MvATip",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A13MvATip=n)},v2z:function(n){n!==undefined&&(gx.O.Z13MvATip=n)},v2c:function(){gx.fn.setControlValue("MVATIP",gx.O.A13MvATip,0)},c2v:function(){this.val()!==undefined&&(gx.O.A13MvATip=this.val())},val:function(){return gx.fn.getControlValue("MVATIP")},nac:gx.falseFn};n[23]={id:23,fld:"TEXTBLOCK2",format:0,grid:0,ctrltype:"textblock"};n[25]={id:25,lvl:0,type:"char",len:12,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Mvacod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MVACOD",gxz:"Z14MvACod",gxold:"O14MvACod",gxvar:"A14MvACod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A14MvACod=n)},v2z:function(n){n!==undefined&&(gx.O.Z14MvACod=n)},v2c:function(){gx.fn.setControlValue("MVACOD",gx.O.A14MvACod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A14MvACod=this.val())},val:function(){return gx.fn.getControlValue("MVACOD")},nac:gx.falseFn};n[28]={id:28,fld:"TEXTBLOCK3",format:0,grid:0,ctrltype:"textblock"};n[30]={id:30,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Mvaditem,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MVADITEM",gxz:"Z30MvADItem",gxold:"O30MvADItem",gxvar:"A30MvADItem",ucs:[],op:[35],ip:[35,30,25,20],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A30MvADItem=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z30MvADItem=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("MVADITEM",gx.O.A30MvADItem,0)},c2v:function(){this.val()!==undefined&&(gx.O.A30MvADItem=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("MVADITEM",",")},nac:gx.falseFn};n[33]={id:33,fld:"TEXTBLOCK4",format:0,grid:0,ctrltype:"textblock"};n[35]={id:35,lvl:0,type:"char",len:15,dec:0,sign:!1,pic:"@!",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODCOD",gxz:"Z28ProdCod",gxold:"O28ProdCod",gxvar:"A28ProdCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A28ProdCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z28ProdCod=n)},v2c:function(){gx.fn.setControlValue("PRODCOD",gx.O.A28ProdCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A28ProdCod=this.val())},val:function(){return gx.fn.getControlValue("PRODCOD")},nac:gx.falseFn};n[38]={id:38,fld:"TEXTBLOCK5",format:0,grid:0,ctrltype:"textblock"};n[40]={id:40,lvl:0,type:"svchar",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Mvadlref1,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MVADLREF1",gxz:"Z31MVADLRef1",gxold:"O31MVADLRef1",gxvar:"A31MVADLRef1",ucs:[],op:[66,61,56,51,46],ip:[66,61,56,51,46,40,30,25,20],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A31MVADLRef1=n)},v2z:function(n){n!==undefined&&(gx.O.Z31MVADLRef1=n)},v2c:function(){gx.fn.setControlValue("MVADLREF1",gx.O.A31MVADLRef1,0)},c2v:function(){this.val()!==undefined&&(gx.O.A31MVADLRef1=this.val())},val:function(){return gx.fn.getControlValue("MVADLREF1")},nac:gx.falseFn};n[41]={id:41,fld:"BTN_GET",grid:0,evt:"e181741_client",std:"GET"};n[44]={id:44,fld:"TEXTBLOCK6",format:0,grid:0,ctrltype:"textblock"};n[46]={id:46,lvl:0,type:"svchar",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MVADLREF2",gxz:"Z1254MVADLRef2",gxold:"O1254MVADLRef2",gxvar:"A1254MVADLRef2",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1254MVADLRef2=n)},v2z:function(n){n!==undefined&&(gx.O.Z1254MVADLRef2=n)},v2c:function(){gx.fn.setControlValue("MVADLREF2",gx.O.A1254MVADLRef2,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1254MVADLRef2=this.val())},val:function(){return gx.fn.getControlValue("MVADLREF2")},nac:gx.falseFn};n[49]={id:49,fld:"TEXTBLOCK7",format:0,grid:0,ctrltype:"textblock"};n[51]={id:51,lvl:0,type:"svchar",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MVADLREF3",gxz:"Z1255MVADLRef3",gxold:"O1255MVADLRef3",gxvar:"A1255MVADLRef3",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1255MVADLRef3=n)},v2z:function(n){n!==undefined&&(gx.O.Z1255MVADLRef3=n)},v2c:function(){gx.fn.setControlValue("MVADLREF3",gx.O.A1255MVADLRef3,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1255MVADLRef3=this.val())},val:function(){return gx.fn.getControlValue("MVADLREF3")},nac:gx.falseFn};n[54]={id:54,fld:"TEXTBLOCK8",format:0,grid:0,ctrltype:"textblock"};n[56]={id:56,lvl:0,type:"svchar",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MVADLREF4",gxz:"Z1256MVADLRef4",gxold:"O1256MVADLRef4",gxvar:"A1256MVADLRef4",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1256MVADLRef4=n)},v2z:function(n){n!==undefined&&(gx.O.Z1256MVADLRef4=n)},v2c:function(){gx.fn.setControlValue("MVADLREF4",gx.O.A1256MVADLRef4,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1256MVADLRef4=this.val())},val:function(){return gx.fn.getControlValue("MVADLREF4")},nac:gx.falseFn};n[59]={id:59,fld:"TEXTBLOCK9",format:0,grid:0,ctrltype:"textblock"};n[61]={id:61,lvl:0,type:"decimal",len:15,dec:4,sign:!0,pic:"ZZZZ,ZZZ,ZZ9.9999",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MVADLCANT",gxz:"Z1251MVADLCant",gxold:"O1251MVADLCant",gxvar:"A1251MVADLCant",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1251MVADLCant=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z1251MVADLCant=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("MVADLCANT",gx.O.A1251MVADLCant,4,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A1251MVADLCant=this.val())},val:function(){return gx.fn.getDecimalValue("MVADLCANT",",",".")},nac:gx.falseFn};this.declareDomainHdlr(61,function(){});n[64]={id:64,fld:"TEXTBLOCK10",format:0,grid:0,ctrltype:"textblock"};n[66]={id:66,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Mvadlfec,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MVADLFEC",gxz:"Z1252MVADLFec",gxold:"O1252MVADLFec",gxvar:"A1252MVADLFec",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[66],ip:[66],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1252MVADLFec=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z1252MVADLFec=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("MVADLFEC",gx.O.A1252MVADLFec,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1252MVADLFec=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("MVADLFEC")},nac:gx.falseFn};n[69]={id:69,fld:"BTN_ENTER",grid:0,evt:"e111741_client",std:"ENTER"};n[70]={id:70,fld:"BTN_CHECK",grid:0,evt:"e191741_client",std:"CHECK"};n[71]={id:71,fld:"BTN_CANCEL",grid:0,evt:"e121741_client"};n[72]={id:72,fld:"BTN_DELETE",grid:0,evt:"e201741_client",std:"DELETE"};n[73]={id:73,fld:"BTN_HELP",grid:0,evt:"e211741_client"};this.A13MvATip="";this.Z13MvATip="";this.O13MvATip="";this.A14MvACod="";this.Z14MvACod="";this.O14MvACod="";this.A30MvADItem=0;this.Z30MvADItem=0;this.O30MvADItem=0;this.A28ProdCod="";this.Z28ProdCod="";this.O28ProdCod="";this.A31MVADLRef1="";this.Z31MVADLRef1="";this.O31MVADLRef1="";this.A1254MVADLRef2="";this.Z1254MVADLRef2="";this.O1254MVADLRef2="";this.A1255MVADLRef3="";this.Z1255MVADLRef3="";this.O1255MVADLRef3="";this.A1256MVADLRef4="";this.Z1256MVADLRef4="";this.O1256MVADLRef4="";this.A1251MVADLCant=0;this.Z1251MVADLCant=0;this.O1251MVADLCant=0;this.A1252MVADLFec=gx.date.nullDate();this.Z1252MVADLFec=gx.date.nullDate();this.O1252MVADLFec=gx.date.nullDate();this.A13MvATip="";this.A14MvACod="";this.A30MvADItem=0;this.A31MVADLRef1="";this.A28ProdCod="";this.A1254MVADLRef2="";this.A1255MVADLRef3="";this.A1256MVADLRef4="";this.A1251MVADLCant=0;this.A1252MVADLFec=gx.date.nullDate();this.Events={e111741_client:["ENTER",!0],e121741_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_MVATIP=[[],[]];this.EvtParms.VALID_MVACOD=[[],[]];this.EvtParms.VALID_MVADITEM=[[{av:"A13MvATip",fld:"MVATIP",pic:""},{av:"A14MvACod",fld:"MVACOD",pic:""},{av:"A30MvADItem",fld:"MVADITEM",pic:"ZZZZZ9"},{av:"A28ProdCod",fld:"PRODCOD",pic:"@!"}],[{av:"A28ProdCod",fld:"PRODCOD",pic:"@!"}]];this.EvtParms.VALID_MVADLREF1=[[{av:"A13MvATip",fld:"MVATIP",pic:""},{av:"A14MvACod",fld:"MVACOD",pic:""},{av:"A30MvADItem",fld:"MVADITEM",pic:"ZZZZZ9"},{av:"A31MVADLRef1",fld:"MVADLREF1",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A1254MVADLRef2",fld:"MVADLREF2",pic:""},{av:"A1255MVADLRef3",fld:"MVADLREF3",pic:""},{av:"A1256MVADLRef4",fld:"MVADLREF4",pic:""},{av:"A1251MVADLCant",fld:"MVADLCANT",pic:"ZZZZ,ZZZ,ZZ9.9999"},{av:"A1252MVADLFec",fld:"MVADLFEC",pic:""},{av:"A28ProdCod",fld:"PRODCOD",pic:"@!"},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z13MvATip"},{av:"Z14MvACod"},{av:"Z30MvADItem"},{av:"Z31MVADLRef1"},{av:"Z1254MVADLRef2"},{av:"Z1255MVADLRef3"},{av:"Z1256MVADLRef4"},{av:"Z1251MVADLCant"},{av:"Z1252MVADLFec"},{av:"Z28ProdCod"},{ctrl:"BTN_GET",prop:"Enabled"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"},{ctrl:"BTN_CHECK",prop:"Enabled"}]];this.EvtParms.VALID_MVADLFEC=[[{av:"A1252MVADLFec",fld:"MVADLFEC",pic:""}],[{av:"A1252MVADLFec",fld:"MVADLFEC",pic:""}]];this.EnterCtrl=["BTN_ENTER"];this.CheckCtrl=["BTN_CHECK"];this.Initialize()});gx.wi(function(){gx.createParentObj(this.aguiasdetlote)})