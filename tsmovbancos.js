gx.evt.autoSkip=!1;gx.define("tsmovbancos",!1,function(){this.ServerClass="tsmovbancos";this.PackageName="GeneXus.Programs";this.ServerFullClass="tsmovbancos.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Tsmovcod=function(){return this.validSrvEvt("Valid_Tsmovcod",0).then(function(n){return n}.closure(this))};this.Valid_Tsmovfec=function(){return this.validCliEvt("Valid_Tsmovfec",0,function(){try{var n=gx.util.balloon.getNew("TSMOVFEC");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.A1970TSMovFec)==0||new gx.date.gxdate(this.A1970TSMovFec).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Fecha fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Forcod=function(){return this.validSrvEvt("Valid_Forcod",0).then(function(n){return n}.closure(this))};this.Valid_Prvcod=function(){return this.validSrvEvt("Valid_Prvcod",0).then(function(n){return n}.closure(this))};this.Valid_Tipcod=function(){return this.validSrvEvt("Valid_Tipcod",0).then(function(n){return n}.closure(this))};this.Valid_Tsmovbancod=function(){return this.validCliEvt("Valid_Tsmovbancod",0,function(){try{var n=gx.util.balloon.getNew("TSMOVBANCOD");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Tsmovcbcod=function(){return this.validSrvEvt("Valid_Tsmovcbcod",0).then(function(n){return n}.closure(this))};this.e114u161_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e124u161_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100,101,102];this.GXLastCtrlId=102;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"TABLEMAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"BTN_FIRST",grid:0,evt:"e134u161_client",std:"FIRST"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"BTN_PREVIOUS",grid:0,evt:"e144u161_client",std:"PREVIOUS"};n[15]={id:15,fld:"",grid:0};n[16]={id:16,fld:"BTN_NEXT",grid:0,evt:"e154u161_client",std:"NEXT"};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"BTN_LAST",grid:0,evt:"e164u161_client",std:"LAST"};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"BTN_SELECT",grid:0,evt:"e174u161_client",std:"SELECT"};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,lvl:0,type:"svchar",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Tsmovcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TSMOVCOD",gxz:"Z387TSMovCod",gxold:"O387TSMovCod",gxvar:"A387TSMovCod",ucs:[],op:[78,73,58,43,38,93,88,83,63,53,33],ip:[78,73,58,43,38,93,88,83,63,53,33,28],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A387TSMovCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z387TSMovCod=n)},v2c:function(){gx.fn.setControlValue("TSMOVCOD",gx.O.A387TSMovCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A387TSMovCod=this.val())},val:function(){return gx.fn.getControlValue("TSMOVCOD")},nac:gx.falseFn};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Tsmovfec,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TSMOVFEC",gxz:"Z1970TSMovFec",gxold:"O1970TSMovFec",gxvar:"A1970TSMovFec",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[33],ip:[33],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1970TSMovFec=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z1970TSMovFec=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("TSMOVFEC",gx.O.A1970TSMovFec,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1970TSMovFec=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("TSMOVFEC")},nac:gx.falseFn};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Forcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FORCOD",gxz:"Z143ForCod",gxold:"O143ForCod",gxvar:"A143ForCod",ucs:[],op:[],ip:[38],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A143ForCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z143ForCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("FORCOD",gx.O.A143ForCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A143ForCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("FORCOD",",")},nac:gx.falseFn};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,lvl:0,type:"char",len:20,dec:0,sign:!1,pic:"@!",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Prvcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRVCOD",gxz:"Z244PrvCod",gxold:"O244PrvCod",gxvar:"A244PrvCod",ucs:[],op:[48],ip:[48,43],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A244PrvCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z244PrvCod=n)},v2c:function(){gx.fn.setControlValue("PRVCOD",gx.O.A244PrvCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A244PrvCod=this.val())},val:function(){return gx.fn.getControlValue("PRVCOD")},nac:gx.falseFn};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRVDSC",gxz:"Z247PrvDsc",gxold:"O247PrvDsc",gxvar:"A247PrvDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A247PrvDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z247PrvDsc=n)},v2c:function(){gx.fn.setControlValue("PRVDSC",gx.O.A247PrvDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A247PrvDsc=this.val())},val:function(){return gx.fn.getControlValue("PRVDSC")},nac:gx.falseFn};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TSMOVGLS",gxz:"Z1971TSMovGls",gxold:"O1971TSMovGls",gxvar:"A1971TSMovGls",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1971TSMovGls=n)},v2z:function(n){n!==undefined&&(gx.O.Z1971TSMovGls=n)},v2c:function(){gx.fn.setControlValue("TSMOVGLS",gx.O.A1971TSMovGls,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1971TSMovGls=this.val())},val:function(){return gx.fn.getControlValue("TSMOVGLS")},nac:gx.falseFn};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,lvl:0,type:"char",len:3,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Tipcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TIPCOD",gxz:"Z149TipCod",gxold:"O149TipCod",gxvar:"A149TipCod",ucs:[],op:[],ip:[58],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A149TipCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z149TipCod=n)},v2c:function(){gx.fn.setControlValue("TIPCOD",gx.O.A149TipCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A149TipCod=this.val())},val:function(){return gx.fn.getControlValue("TIPCOD")},nac:gx.falseFn};n[59]={id:59,fld:"",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,lvl:0,type:"decimal",len:15,dec:2,sign:!0,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TSMOVIMP",gxz:"Z1972TSMovImp",gxold:"O1972TSMovImp",gxvar:"A1972TSMovImp",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1972TSMovImp=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z1972TSMovImp=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("TSMOVIMP",gx.O.A1972TSMovImp,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A1972TSMovImp=this.val())},val:function(){return gx.fn.getDecimalValue("TSMOVIMP",",",".")},nac:gx.falseFn};this.declareDomainHdlr(63,function(){});n[64]={id:64,fld:"",grid:0};n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"",grid:0};n[67]={id:67,fld:"",grid:0};n[68]={id:68,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TSMOVMONCOD",gxz:"Z1975TSMovMonCod",gxold:"O1975TSMovMonCod",gxvar:"A1975TSMovMonCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1975TSMovMonCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1975TSMovMonCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("TSMOVMONCOD",gx.O.A1975TSMovMonCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1975TSMovMonCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("TSMOVMONCOD",",")},nac:gx.falseFn};n[69]={id:69,fld:"",grid:0};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"",grid:0};n[73]={id:73,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Tsmovbancod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TSMOVBANCOD",gxz:"Z388TSMovBanCod",gxold:"O388TSMovBanCod",gxvar:"A388TSMovBanCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A388TSMovBanCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z388TSMovBanCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("TSMOVBANCOD",gx.O.A388TSMovBanCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A388TSMovBanCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("TSMOVBANCOD",",")},nac:gx.falseFn};n[74]={id:74,fld:"",grid:0};n[75]={id:75,fld:"",grid:0};n[76]={id:76,fld:"",grid:0};n[77]={id:77,fld:"",grid:0};n[78]={id:78,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Tsmovcbcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TSMOVCBCOD",gxz:"Z389TSMovCBCod",gxold:"O389TSMovCBCod",gxvar:"A389TSMovCBCod",ucs:[],op:[68],ip:[68,78,73],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A389TSMovCBCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z389TSMovCBCod=n)},v2c:function(){gx.fn.setControlValue("TSMOVCBCOD",gx.O.A389TSMovCBCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A389TSMovCBCod=this.val())},val:function(){return gx.fn.getControlValue("TSMOVCBCOD")},nac:gx.falseFn};n[79]={id:79,fld:"",grid:0};n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"",grid:0};n[82]={id:82,fld:"",grid:0};n[83]={id:83,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TSMOVNCUOTAS",gxz:"Z1976TSMovNCuotas",gxold:"O1976TSMovNCuotas",gxvar:"A1976TSMovNCuotas",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1976TSMovNCuotas=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1976TSMovNCuotas=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("TSMOVNCUOTAS",gx.O.A1976TSMovNCuotas,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1976TSMovNCuotas=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("TSMOVNCUOTAS",",")},nac:gx.falseFn};n[84]={id:84,fld:"",grid:0};n[85]={id:85,fld:"",grid:0};n[86]={id:86,fld:"",grid:0};n[87]={id:87,fld:"",grid:0};n[88]={id:88,lvl:0,type:"decimal",len:15,dec:2,sign:!0,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TSMOVIMPCUOTA",gxz:"Z1973TSMovImpCuota",gxold:"O1973TSMovImpCuota",gxvar:"A1973TSMovImpCuota",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1973TSMovImpCuota=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z1973TSMovImpCuota=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("TSMOVIMPCUOTA",gx.O.A1973TSMovImpCuota,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A1973TSMovImpCuota=this.val())},val:function(){return gx.fn.getDecimalValue("TSMOVIMPCUOTA",",",".")},nac:gx.falseFn};this.declareDomainHdlr(88,function(){});n[89]={id:89,fld:"",grid:0};n[90]={id:90,fld:"",grid:0};n[91]={id:91,fld:"",grid:0};n[92]={id:92,fld:"",grid:0};n[93]={id:93,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TSMOVTITEM",gxz:"Z1977TSMovTItem",gxold:"O1977TSMovTItem",gxvar:"A1977TSMovTItem",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1977TSMovTItem=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1977TSMovTItem=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("TSMOVTITEM",gx.O.A1977TSMovTItem,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1977TSMovTItem=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("TSMOVTITEM",",")},nac:gx.falseFn};n[94]={id:94,fld:"",grid:0};n[95]={id:95,fld:"",grid:0};n[96]={id:96,fld:"",grid:0};n[97]={id:97,fld:"",grid:0};n[98]={id:98,fld:"BTN_ENTER",grid:0,evt:"e114u161_client",std:"ENTER"};n[99]={id:99,fld:"",grid:0};n[100]={id:100,fld:"BTN_CANCEL",grid:0,evt:"e124u161_client"};n[101]={id:101,fld:"",grid:0};n[102]={id:102,fld:"BTN_DELETE",grid:0,evt:"e184u161_client",std:"DELETE"};this.A387TSMovCod="";this.Z387TSMovCod="";this.O387TSMovCod="";this.A1970TSMovFec=gx.date.nullDate();this.Z1970TSMovFec=gx.date.nullDate();this.O1970TSMovFec=gx.date.nullDate();this.A143ForCod=0;this.Z143ForCod=0;this.O143ForCod=0;this.A244PrvCod="";this.Z244PrvCod="";this.O244PrvCod="";this.A247PrvDsc="";this.Z247PrvDsc="";this.O247PrvDsc="";this.A1971TSMovGls="";this.Z1971TSMovGls="";this.O1971TSMovGls="";this.A149TipCod="";this.Z149TipCod="";this.O149TipCod="";this.A1972TSMovImp=0;this.Z1972TSMovImp=0;this.O1972TSMovImp=0;this.A1975TSMovMonCod=0;this.Z1975TSMovMonCod=0;this.O1975TSMovMonCod=0;this.A388TSMovBanCod=0;this.Z388TSMovBanCod=0;this.O388TSMovBanCod=0;this.A389TSMovCBCod="";this.Z389TSMovCBCod="";this.O389TSMovCBCod="";this.A1976TSMovNCuotas=0;this.Z1976TSMovNCuotas=0;this.O1976TSMovNCuotas=0;this.A1973TSMovImpCuota=0;this.Z1973TSMovImpCuota=0;this.O1973TSMovImpCuota=0;this.A1977TSMovTItem=0;this.Z1977TSMovTItem=0;this.O1977TSMovTItem=0;this.A387TSMovCod="";this.A1970TSMovFec=gx.date.nullDate();this.A143ForCod=0;this.A244PrvCod="";this.A247PrvDsc="";this.A1971TSMovGls="";this.A149TipCod="";this.A1972TSMovImp=0;this.A1975TSMovMonCod=0;this.A388TSMovBanCod=0;this.A389TSMovCBCod="";this.A1976TSMovNCuotas=0;this.A1973TSMovImpCuota=0;this.A1977TSMovTItem=0;this.Events={e114u161_client:["ENTER",!0],e124u161_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_TSMOVCOD=[[{av:"A387TSMovCod",fld:"TSMOVCOD",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A1970TSMovFec",fld:"TSMOVFEC",pic:""},{av:"A143ForCod",fld:"FORCOD",pic:"ZZZZZ9"},{av:"A244PrvCod",fld:"PRVCOD",pic:"@!"},{av:"A1971TSMovGls",fld:"TSMOVGLS",pic:""},{av:"A149TipCod",fld:"TIPCOD",pic:""},{av:"A1972TSMovImp",fld:"TSMOVIMP",pic:"ZZZZZZ,ZZZ,ZZ9.99"},{av:"A388TSMovBanCod",fld:"TSMOVBANCOD",pic:"ZZZZZ9"},{av:"A389TSMovCBCod",fld:"TSMOVCBCOD",pic:""},{av:"A1976TSMovNCuotas",fld:"TSMOVNCUOTAS",pic:"ZZZ9"},{av:"A1973TSMovImpCuota",fld:"TSMOVIMPCUOTA",pic:"ZZZZZZ,ZZZ,ZZ9.99"},{av:"A1977TSMovTItem",fld:"TSMOVTITEM",pic:"ZZZZZ9"},{av:"A247PrvDsc",fld:"PRVDSC",pic:""},{av:"A1975TSMovMonCod",fld:"TSMOVMONCOD",pic:"ZZZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z387TSMovCod"},{av:"Z1970TSMovFec"},{av:"Z143ForCod"},{av:"Z244PrvCod"},{av:"Z1971TSMovGls"},{av:"Z149TipCod"},{av:"Z1972TSMovImp"},{av:"Z388TSMovBanCod"},{av:"Z389TSMovCBCod"},{av:"Z1976TSMovNCuotas"},{av:"Z1973TSMovImpCuota"},{av:"Z1977TSMovTItem"},{av:"Z247PrvDsc"},{av:"Z1975TSMovMonCod"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"}]];this.EvtParms.VALID_TSMOVFEC=[[{av:"A1970TSMovFec",fld:"TSMOVFEC",pic:""}],[{av:"A1970TSMovFec",fld:"TSMOVFEC",pic:""}]];this.EvtParms.VALID_FORCOD=[[{av:"A143ForCod",fld:"FORCOD",pic:"ZZZZZ9"}],[]];this.EvtParms.VALID_PRVCOD=[[{av:"A244PrvCod",fld:"PRVCOD",pic:"@!"},{av:"A247PrvDsc",fld:"PRVDSC",pic:""}],[{av:"A247PrvDsc",fld:"PRVDSC",pic:""}]];this.EvtParms.VALID_TIPCOD=[[{av:"A149TipCod",fld:"TIPCOD",pic:""}],[]];this.EvtParms.VALID_TSMOVBANCOD=[[],[]];this.EvtParms.VALID_TSMOVCBCOD=[[{av:"A388TSMovBanCod",fld:"TSMOVBANCOD",pic:"ZZZZZ9"},{av:"A389TSMovCBCod",fld:"TSMOVCBCOD",pic:""},{av:"A1975TSMovMonCod",fld:"TSMOVMONCOD",pic:"ZZZZZ9"}],[{av:"A1975TSMovMonCod",fld:"TSMOVMONCOD",pic:"ZZZZZ9"}]];this.EnterCtrl=["BTN_ENTER"];this.Initialize()});gx.wi(function(){gx.createParentObj(this.tsmovbancos)})