gx.evt.autoSkip=!1;gx.define("actmovactivo",!1,function(){this.ServerClass="actmovactivo";this.PackageName="GeneXus.Programs";this.ServerFullClass="actmovactivo.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Amovcod=function(){return this.validSrvEvt("Valid_Amovcod",0).then(function(n){return n}.closure(this))};this.Valid_Amovfec=function(){return this.validCliEvt("Valid_Amovfec",0,function(){try{var n=gx.util.balloon.getNew("AMOVFEC");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.A2200AMovFec)==0||new gx.date.gxdate(this.A2200AMovFec).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Fecha fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Actactcod=function(){return this.validSrvEvt("Valid_Actactcod",0).then(function(n){return n}.closure(this))};this.Valid_Actactitem=function(){return this.validSrvEvt("Valid_Actactitem",0).then(function(n){return n}.closure(this))};this.Valid_Amovareacod=function(){return this.validSrvEvt("Valid_Amovareacod",0).then(function(n){return n}.closure(this))};this.Valid_Amovcoscod=function(){return this.validSrvEvt("Valid_Amovcoscod",0).then(function(n){return n}.closure(this))};this.e116y192_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e126y192_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92];this.GXLastCtrlId=92;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"TABLEMAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"BTN_FIRST",grid:0,evt:"e136y192_client",std:"FIRST"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"BTN_PREVIOUS",grid:0,evt:"e146y192_client",std:"PREVIOUS"};n[15]={id:15,fld:"",grid:0};n[16]={id:16,fld:"BTN_NEXT",grid:0,evt:"e156y192_client",std:"NEXT"};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"BTN_LAST",grid:0,evt:"e166y192_client",std:"LAST"};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"BTN_SELECT",grid:0,evt:"e176y192_client",std:"SELECT"};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,lvl:0,type:"svchar",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Amovcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AMOVCOD",gxz:"Z2109AMovCod",gxold:"O2109AMovCod",gxvar:"A2109AMovCod",ucs:[],op:[63,53,48,38,83,78,73,33],ip:[63,53,48,38,83,78,73,33,28],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2109AMovCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z2109AMovCod=n)},v2c:function(){gx.fn.setControlValue("AMOVCOD",gx.O.A2109AMovCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2109AMovCod=this.val())},val:function(){return gx.fn.getControlValue("AMOVCOD")},nac:gx.falseFn};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Amovfec,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AMOVFEC",gxz:"Z2200AMovFec",gxold:"O2200AMovFec",gxvar:"A2200AMovFec",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[33],ip:[33],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2200AMovFec=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z2200AMovFec=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("AMOVFEC",gx.O.A2200AMovFec,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2200AMovFec=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("AMOVFEC")},nac:gx.falseFn};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,lvl:0,type:"svchar",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Actactcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTACTCOD",gxz:"Z2100ACTActCod",gxold:"O2100ACTActCod",gxvar:"A2100ACTActCod",ucs:[],op:[43],ip:[43,38],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2100ACTActCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z2100ACTActCod=n)},v2c:function(){gx.fn.setControlValue("ACTACTCOD",gx.O.A2100ACTActCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2100ACTActCod=this.val())},val:function(){return gx.fn.getControlValue("ACTACTCOD")},nac:gx.falseFn};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTACTDSC",gxz:"Z2122ACTActDsc",gxold:"O2122ACTActDsc",gxvar:"A2122ACTActDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2122ACTActDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z2122ACTActDsc=n)},v2c:function(){gx.fn.setControlValue("ACTACTDSC",gx.O.A2122ACTActDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2122ACTActDsc=this.val())},val:function(){return gx.fn.getControlValue("ACTACTDSC")},nac:gx.falseFn};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,lvl:0,type:"svchar",len:5,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Actactitem,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTACTITEM",gxz:"Z2104ActActItem",gxold:"O2104ActActItem",gxvar:"A2104ActActItem",ucs:[],op:[],ip:[48,38],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2104ActActItem=n)},v2z:function(n){n!==undefined&&(gx.O.Z2104ActActItem=n)},v2c:function(){gx.fn.setControlValue("ACTACTITEM",gx.O.A2104ActActItem,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2104ActActItem=this.val())},val:function(){return gx.fn.getControlValue("ACTACTITEM")},nac:gx.falseFn};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,lvl:0,type:"svchar",len:5,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Amovareacod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AMOVAREACOD",gxz:"Z2111AMovAreaCod",gxold:"O2111AMovAreaCod",gxvar:"A2111AMovAreaCod",ucs:[],op:[58],ip:[58,53],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2111AMovAreaCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z2111AMovAreaCod=n)},v2c:function(){gx.fn.setControlValue("AMOVAREACOD",gx.O.A2111AMovAreaCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2111AMovAreaCod=this.val())},val:function(){return gx.fn.getControlValue("AMOVAREACOD")},nac:gx.falseFn};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AMOVAREADSC",gxz:"Z2198AMovAreaDsc",gxold:"O2198AMovAreaDsc",gxvar:"A2198AMovAreaDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2198AMovAreaDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z2198AMovAreaDsc=n)},v2c:function(){gx.fn.setControlValue("AMOVAREADSC",gx.O.A2198AMovAreaDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2198AMovAreaDsc=this.val())},val:function(){return gx.fn.getControlValue("AMOVAREADSC")},nac:gx.falseFn};n[59]={id:59,fld:"",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,lvl:0,type:"char",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Amovcoscod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AMOVCOSCOD",gxz:"Z2110AMovCosCod",gxold:"O2110AMovCosCod",gxvar:"A2110AMovCosCod",ucs:[],op:[68],ip:[68,63],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2110AMovCosCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z2110AMovCosCod=n)},v2c:function(){gx.fn.setControlValue("AMOVCOSCOD",gx.O.A2110AMovCosCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2110AMovCosCod=this.val())},val:function(){return gx.fn.getControlValue("AMOVCOSCOD")},nac:gx.falseFn};n[64]={id:64,fld:"",grid:0};n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"",grid:0};n[67]={id:67,fld:"",grid:0};n[68]={id:68,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AMOVCOSDSC",gxz:"Z2199AMovCosDsc",gxold:"O2199AMovCosDsc",gxvar:"A2199AMovCosDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2199AMovCosDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z2199AMovCosDsc=n)},v2c:function(){gx.fn.setControlValue("AMOVCOSDSC",gx.O.A2199AMovCosDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2199AMovCosDsc=this.val())},val:function(){return gx.fn.getControlValue("AMOVCOSDSC")},nac:gx.falseFn};n[69]={id:69,fld:"",grid:0};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"",grid:0};n[73]={id:73,lvl:0,type:"svchar",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AMOVTIPO",gxz:"Z2203AMovTipo",gxold:"O2203AMovTipo",gxvar:"A2203AMovTipo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2203AMovTipo=n)},v2z:function(n){n!==undefined&&(gx.O.Z2203AMovTipo=n)},v2c:function(){gx.fn.setControlValue("AMOVTIPO",gx.O.A2203AMovTipo,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2203AMovTipo=this.val())},val:function(){return gx.fn.getControlValue("AMOVTIPO")},nac:gx.falseFn};n[74]={id:74,fld:"",grid:0};n[75]={id:75,fld:"",grid:0};n[76]={id:76,fld:"",grid:0};n[77]={id:77,fld:"",grid:0};n[78]={id:78,lvl:0,type:"svchar",len:500,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AMOVOBS",gxz:"Z2201AMovObs",gxold:"O2201AMovObs",gxvar:"A2201AMovObs",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2201AMovObs=n)},v2z:function(n){n!==undefined&&(gx.O.Z2201AMovObs=n)},v2c:function(){gx.fn.setControlValue("AMOVOBS",gx.O.A2201AMovObs,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2201AMovObs=this.val())},val:function(){return gx.fn.getControlValue("AMOVOBS")},nac:gx.falseFn};n[79]={id:79,fld:"",grid:0};n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"",grid:0};n[82]={id:82,fld:"",grid:0};n[83]={id:83,lvl:0,type:"svchar",len:5,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AMOVSUBGRUP",gxz:"Z2202AMovSubGrup",gxold:"O2202AMovSubGrup",gxvar:"A2202AMovSubGrup",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2202AMovSubGrup=n)},v2z:function(n){n!==undefined&&(gx.O.Z2202AMovSubGrup=n)},v2c:function(){gx.fn.setControlValue("AMOVSUBGRUP",gx.O.A2202AMovSubGrup,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2202AMovSubGrup=this.val())},val:function(){return gx.fn.getControlValue("AMOVSUBGRUP")},nac:gx.falseFn};n[84]={id:84,fld:"",grid:0};n[85]={id:85,fld:"",grid:0};n[86]={id:86,fld:"",grid:0};n[87]={id:87,fld:"",grid:0};n[88]={id:88,fld:"BTN_ENTER",grid:0,evt:"e116y192_client",std:"ENTER"};n[89]={id:89,fld:"",grid:0};n[90]={id:90,fld:"BTN_CANCEL",grid:0,evt:"e126y192_client"};n[91]={id:91,fld:"",grid:0};n[92]={id:92,fld:"BTN_DELETE",grid:0,evt:"e186y192_client",std:"DELETE"};this.A2109AMovCod="";this.Z2109AMovCod="";this.O2109AMovCod="";this.A2200AMovFec=gx.date.nullDate();this.Z2200AMovFec=gx.date.nullDate();this.O2200AMovFec=gx.date.nullDate();this.A2100ACTActCod="";this.Z2100ACTActCod="";this.O2100ACTActCod="";this.A2122ACTActDsc="";this.Z2122ACTActDsc="";this.O2122ACTActDsc="";this.A2104ActActItem="";this.Z2104ActActItem="";this.O2104ActActItem="";this.A2111AMovAreaCod="";this.Z2111AMovAreaCod="";this.O2111AMovAreaCod="";this.A2198AMovAreaDsc="";this.Z2198AMovAreaDsc="";this.O2198AMovAreaDsc="";this.A2110AMovCosCod="";this.Z2110AMovCosCod="";this.O2110AMovCosCod="";this.A2199AMovCosDsc="";this.Z2199AMovCosDsc="";this.O2199AMovCosDsc="";this.A2203AMovTipo="";this.Z2203AMovTipo="";this.O2203AMovTipo="";this.A2201AMovObs="";this.Z2201AMovObs="";this.O2201AMovObs="";this.A2202AMovSubGrup="";this.Z2202AMovSubGrup="";this.O2202AMovSubGrup="";this.A2109AMovCod="";this.A2200AMovFec=gx.date.nullDate();this.A2100ACTActCod="";this.A2122ACTActDsc="";this.A2104ActActItem="";this.A2111AMovAreaCod="";this.A2198AMovAreaDsc="";this.A2110AMovCosCod="";this.A2199AMovCosDsc="";this.A2203AMovTipo="";this.A2201AMovObs="";this.A2202AMovSubGrup="";this.Events={e116y192_client:["ENTER",!0],e126y192_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_AMOVCOD=[[{av:"A2109AMovCod",fld:"AMOVCOD",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A2200AMovFec",fld:"AMOVFEC",pic:""},{av:"A2100ACTActCod",fld:"ACTACTCOD",pic:""},{av:"A2104ActActItem",fld:"ACTACTITEM",pic:""},{av:"A2111AMovAreaCod",fld:"AMOVAREACOD",pic:""},{av:"A2110AMovCosCod",fld:"AMOVCOSCOD",pic:""},{av:"A2203AMovTipo",fld:"AMOVTIPO",pic:""},{av:"A2201AMovObs",fld:"AMOVOBS",pic:""},{av:"A2202AMovSubGrup",fld:"AMOVSUBGRUP",pic:""},{av:"A2122ACTActDsc",fld:"ACTACTDSC",pic:""},{av:"A2198AMovAreaDsc",fld:"AMOVAREADSC",pic:""},{av:"A2199AMovCosDsc",fld:"AMOVCOSDSC",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z2109AMovCod"},{av:"Z2200AMovFec"},{av:"Z2100ACTActCod"},{av:"Z2104ActActItem"},{av:"Z2111AMovAreaCod"},{av:"Z2110AMovCosCod"},{av:"Z2203AMovTipo"},{av:"Z2201AMovObs"},{av:"Z2202AMovSubGrup"},{av:"Z2122ACTActDsc"},{av:"Z2198AMovAreaDsc"},{av:"Z2199AMovCosDsc"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"}]];this.EvtParms.VALID_AMOVFEC=[[{av:"A2200AMovFec",fld:"AMOVFEC",pic:""}],[{av:"A2200AMovFec",fld:"AMOVFEC",pic:""}]];this.EvtParms.VALID_ACTACTCOD=[[{av:"A2100ACTActCod",fld:"ACTACTCOD",pic:""},{av:"A2122ACTActDsc",fld:"ACTACTDSC",pic:""}],[{av:"A2122ACTActDsc",fld:"ACTACTDSC",pic:""}]];this.EvtParms.VALID_ACTACTITEM=[[{av:"A2100ACTActCod",fld:"ACTACTCOD",pic:""},{av:"A2104ActActItem",fld:"ACTACTITEM",pic:""}],[]];this.EvtParms.VALID_AMOVAREACOD=[[{av:"A2111AMovAreaCod",fld:"AMOVAREACOD",pic:""},{av:"A2198AMovAreaDsc",fld:"AMOVAREADSC",pic:""}],[{av:"A2198AMovAreaDsc",fld:"AMOVAREADSC",pic:""}]];this.EvtParms.VALID_AMOVCOSCOD=[[{av:"A2110AMovCosCod",fld:"AMOVCOSCOD",pic:""},{av:"A2199AMovCosDsc",fld:"AMOVCOSDSC",pic:""}],[{av:"A2199AMovCosDsc",fld:"AMOVCOSDSC",pic:""}]];this.EnterCtrl=["BTN_ENTER"];this.Initialize()});gx.wi(function(){gx.createParentObj(this.actmovactivo)})