gx.evt.autoSkip=!1;gx.define("cpliquidaciondet",!1,function(){this.ServerClass="cpliquidaciondet";this.PackageName="GeneXus.Programs";this.ServerFullClass="cpliquidaciondet.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Liqcod=function(){return this.validCliEvt("Valid_Liqcod",0,function(){try{var n=gx.util.balloon.getNew("LIQCOD");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Liqprvcod=function(){return this.validSrvEvt("Valid_Liqprvcod",0).then(function(n){return n}.closure(this))};this.Valid_Liqmitem=function(){return this.validSrvEvt("Valid_Liqmitem",0).then(function(n){return n}.closure(this))};this.Valid_Liqmfech=function(){return this.validCliEvt("Valid_Liqmfech",0,function(){try{var n=gx.util.balloon.getNew("LIQMFECH");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.A1180LiqMFech)==0||new gx.date.gxdate(this.A1180LiqMFech).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Fecha fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Liqmprvcod=function(){return this.validSrvEvt("Valid_Liqmprvcod",0).then(function(n){return n}.closure(this))};this.Valid_Liqmtipcod=function(){return this.validCliEvt("Valid_Liqmtipcod",0,function(){try{var n=gx.util.balloon.getNew("LIQMTIPCOD");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Liqmcomcod=function(){return this.validSrvEvt("Valid_Liqmcomcod",0).then(function(n){return n}.closure(this))};this.Valid_Liqmtmovcod=function(){return this.validSrvEvt("Valid_Liqmtmovcod",0).then(function(n){return n}.closure(this))};this.Valid_Liqmusufec=function(){return this.validCliEvt("Valid_Liqmusufec",0,function(){try{var n=gx.util.balloon.getNew("LIQMUSUFEC");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.A1193LiqMUsuFec)==0||new gx.date.gxdate(this.A1193LiqMUsuFec).compare(gx.date.ymdhmstot(1753,1,1,0,0,0))>=0))try{n.setError("Campo Usuario Fecha fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e113d116_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e123d116_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100,101,102,103,104,105,106,107,108,109,110,111,112,113,114,115,116,117,118,119,120,121,122,123,124,125,126,127,128,129,130,131,132,133,134,135,136,137,138,139,140,141,142,143,144,145,146,147,148,149,150,151,152];this.GXLastCtrlId=152;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"TABLEMAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"BTN_FIRST",grid:0,evt:"e133d116_client",std:"FIRST"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"BTN_PREVIOUS",grid:0,evt:"e143d116_client",std:"PREVIOUS"};n[15]={id:15,fld:"",grid:0};n[16]={id:16,fld:"BTN_NEXT",grid:0,evt:"e153d116_client",std:"NEXT"};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"BTN_LAST",grid:0,evt:"e163d116_client",std:"LAST"};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"BTN_SELECT",grid:0,evt:"e173d116_client",std:"SELECT"};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,lvl:0,type:"svchar",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Liqcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LIQCOD",gxz:"Z270LiqCod",gxold:"O270LiqCod",gxvar:"A270LiqCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A270LiqCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z270LiqCod=n)},v2c:function(){gx.fn.setControlValue("LIQCOD",gx.O.A270LiqCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A270LiqCod=this.val())},val:function(){return gx.fn.getControlValue("LIQCOD")},nac:gx.falseFn};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Liqprvcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LIQPRVCOD",gxz:"Z236LiqPrvCod",gxold:"O236LiqPrvCod",gxvar:"A236LiqPrvCod",ucs:[],op:[],ip:[33],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A236LiqPrvCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z236LiqPrvCod=n)},v2c:function(){gx.fn.setControlValue("LIQPRVCOD",gx.O.A236LiqPrvCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A236LiqPrvCod=this.val())},val:function(){return gx.fn.getControlValue("LIQPRVCOD")},nac:gx.falseFn};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Liqmitem,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LIQMITEM",gxz:"Z277LiqMItem",gxold:"O277LiqMItem",gxvar:"A277LiqMItem",ucs:[],op:[118,53,68,63,138,133,128,113,108,103,98,93,88,83,73,48,43],ip:[118,53,68,63,138,133,128,113,108,103,98,93,88,83,73,48,43,38,33,28],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A277LiqMItem=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z277LiqMItem=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("LIQMITEM",gx.O.A277LiqMItem,0)},c2v:function(){this.val()!==undefined&&(gx.O.A277LiqMItem=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("LIQMITEM",",")},nac:gx.falseFn};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Liqmfech,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LIQMFECH",gxz:"Z1180LiqMFech",gxold:"O1180LiqMFech",gxvar:"A1180LiqMFech",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[43],ip:[43],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1180LiqMFech=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z1180LiqMFech=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("LIQMFECH",gx.O.A1180LiqMFech,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1180LiqMFech=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("LIQMFECH")},nac:gx.falseFn};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LIQMCONCEPTO",gxz:"Z1179LiqMConcepto",gxold:"O1179LiqMConcepto",gxvar:"A1179LiqMConcepto",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1179LiqMConcepto=n)},v2z:function(n){n!==undefined&&(gx.O.Z1179LiqMConcepto=n)},v2c:function(){gx.fn.setControlValue("LIQMCONCEPTO",gx.O.A1179LiqMConcepto,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1179LiqMConcepto=this.val())},val:function(){return gx.fn.getControlValue("LIQMCONCEPTO")},nac:gx.falseFn};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,lvl:0,type:"char",len:20,dec:0,sign:!1,pic:"@!",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Liqmprvcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LIQMPRVCOD",gxz:"Z281LiqMPrvCod",gxold:"O281LiqMPrvCod",gxvar:"A281LiqMPrvCod",ucs:[],op:[58],ip:[58,53],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A281LiqMPrvCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z281LiqMPrvCod=n)},v2c:function(){gx.fn.setControlValue("LIQMPRVCOD",gx.O.A281LiqMPrvCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A281LiqMPrvCod=this.val())},val:function(){return gx.fn.getControlValue("LIQMPRVCOD")},nac:gx.falseFn};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LIQMPRVDSC",gxz:"Z1187LiqMPrvDsc",gxold:"O1187LiqMPrvDsc",gxvar:"A1187LiqMPrvDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1187LiqMPrvDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z1187LiqMPrvDsc=n)},v2c:function(){gx.fn.setControlValue("LIQMPRVDSC",gx.O.A1187LiqMPrvDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1187LiqMPrvDsc=this.val())},val:function(){return gx.fn.getControlValue("LIQMPRVDSC")},nac:gx.falseFn};n[59]={id:59,fld:"",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,lvl:0,type:"char",len:3,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Liqmtipcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LIQMTIPCOD",gxz:"Z279LiqMTipCod",gxold:"O279LiqMTipCod",gxvar:"A279LiqMTipCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A279LiqMTipCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z279LiqMTipCod=n)},v2c:function(){gx.fn.setControlValue("LIQMTIPCOD",gx.O.A279LiqMTipCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A279LiqMTipCod=this.val())},val:function(){return gx.fn.getControlValue("LIQMTIPCOD")},nac:gx.falseFn};n[64]={id:64,fld:"",grid:0};n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"",grid:0};n[67]={id:67,fld:"",grid:0};n[68]={id:68,lvl:0,type:"char",len:15,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Liqmcomcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LIQMCOMCOD",gxz:"Z280LiqMComCod",gxold:"O280LiqMComCod",gxvar:"A280LiqMComCod",ucs:[],op:[78],ip:[78,53,68,63],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A280LiqMComCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z280LiqMComCod=n)},v2c:function(){gx.fn.setControlValue("LIQMCOMCOD",gx.O.A280LiqMComCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A280LiqMComCod=this.val())},val:function(){return gx.fn.getControlValue("LIQMCOMCOD")},nac:gx.falseFn};n[69]={id:69,fld:"",grid:0};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"",grid:0};n[73]={id:73,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LIQMFORCOD",gxz:"Z1181LiqMForCod",gxold:"O1181LiqMForCod",gxvar:"A1181LiqMForCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1181LiqMForCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1181LiqMForCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("LIQMFORCOD",gx.O.A1181LiqMForCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1181LiqMForCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("LIQMFORCOD",",")},nac:gx.falseFn};n[74]={id:74,fld:"",grid:0};n[75]={id:75,fld:"",grid:0};n[76]={id:76,fld:"",grid:0};n[77]={id:77,fld:"",grid:0};n[78]={id:78,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LIQMMONCOD",gxz:"Z1183LiqMMonCod",gxold:"O1183LiqMMonCod",gxvar:"A1183LiqMMonCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1183LiqMMonCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1183LiqMMonCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("LIQMMONCOD",gx.O.A1183LiqMMonCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1183LiqMMonCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("LIQMMONCOD",",")},nac:gx.falseFn};n[79]={id:79,fld:"",grid:0};n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"",grid:0};n[82]={id:82,fld:"",grid:0};n[83]={id:83,lvl:0,type:"decimal",len:10,dec:4,sign:!1,pic:"ZZZZ9.9999",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LIQMTIPCMB",gxz:"Z1189LiqMTipCmb",gxold:"O1189LiqMTipCmb",gxvar:"A1189LiqMTipCmb",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1189LiqMTipCmb=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z1189LiqMTipCmb=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("LIQMTIPCMB",gx.O.A1189LiqMTipCmb,4,".")},c2v:function(){this.val()!==undefined&&(gx.O.A1189LiqMTipCmb=this.val())},val:function(){return gx.fn.getDecimalValue("LIQMTIPCMB",",",".")},nac:gx.falseFn};n[84]={id:84,fld:"",grid:0};n[85]={id:85,fld:"",grid:0};n[86]={id:86,fld:"",grid:0};n[87]={id:87,fld:"",grid:0};n[88]={id:88,lvl:0,type:"decimal",len:15,dec:2,sign:!0,pic:"ZZZZZZZZZZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LIQMIMPORTE",gxz:"Z1182LiqMImporte",gxold:"O1182LiqMImporte",gxvar:"A1182LiqMImporte",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1182LiqMImporte=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z1182LiqMImporte=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("LIQMIMPORTE",gx.O.A1182LiqMImporte,2,".")},c2v:function(){this.val()!==undefined&&(gx.O.A1182LiqMImporte=this.val())},val:function(){return gx.fn.getDecimalValue("LIQMIMPORTE",",",".")},nac:gx.falseFn};n[89]={id:89,fld:"",grid:0};n[90]={id:90,fld:"",grid:0};n[91]={id:91,fld:"",grid:0};n[92]={id:92,fld:"",grid:0};n[93]={id:93,lvl:0,type:"decimal",len:15,dec:2,sign:!0,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LIQMPAGO",gxz:"Z1185LiqMPago",gxold:"O1185LiqMPago",gxvar:"A1185LiqMPago",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1185LiqMPago=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z1185LiqMPago=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("LIQMPAGO",gx.O.A1185LiqMPago,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A1185LiqMPago=this.val())},val:function(){return gx.fn.getDecimalValue("LIQMPAGO",",",".")},nac:gx.falseFn};this.declareDomainHdlr(93,function(){});n[94]={id:94,fld:"",grid:0};n[95]={id:95,fld:"",grid:0};n[96]={id:96,fld:"",grid:0};n[97]={id:97,fld:"",grid:0};n[98]={id:98,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LIQMVOUANO",gxz:"Z1194LiqMVouAno",gxold:"O1194LiqMVouAno",gxvar:"A1194LiqMVouAno",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1194LiqMVouAno=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1194LiqMVouAno=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("LIQMVOUANO",gx.O.A1194LiqMVouAno,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1194LiqMVouAno=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("LIQMVOUANO",",")},nac:gx.falseFn};n[99]={id:99,fld:"",grid:0};n[100]={id:100,fld:"",grid:0};n[101]={id:101,fld:"",grid:0};n[102]={id:102,fld:"",grid:0};n[103]={id:103,lvl:0,type:"int",len:2,dec:0,sign:!1,pic:"Z9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LIQMVOUMES",gxz:"Z1195LiqMVouMes",gxold:"O1195LiqMVouMes",gxvar:"A1195LiqMVouMes",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1195LiqMVouMes=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1195LiqMVouMes=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("LIQMVOUMES",gx.O.A1195LiqMVouMes,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1195LiqMVouMes=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("LIQMVOUMES",",")},nac:gx.falseFn};n[104]={id:104,fld:"",grid:0};n[105]={id:105,fld:"",grid:0};n[106]={id:106,fld:"",grid:0};n[107]={id:107,fld:"",grid:0};n[108]={id:108,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LIQMTASICOD",gxz:"Z1188LiqMTASICod",gxold:"O1188LiqMTASICod",gxvar:"A1188LiqMTASICod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1188LiqMTASICod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1188LiqMTASICod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("LIQMTASICOD",gx.O.A1188LiqMTASICod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1188LiqMTASICod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("LIQMTASICOD",",")},nac:gx.falseFn};n[109]={id:109,fld:"",grid:0};n[110]={id:110,fld:"",grid:0};n[111]={id:111,fld:"",grid:0};n[112]={id:112,fld:"",grid:0};n[113]={id:113,lvl:0,type:"char",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LIQMVOUNUM",gxz:"Z1196LiqMVouNum",gxold:"O1196LiqMVouNum",gxvar:"A1196LiqMVouNum",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1196LiqMVouNum=n)},v2z:function(n){n!==undefined&&(gx.O.Z1196LiqMVouNum=n)},v2c:function(){gx.fn.setControlValue("LIQMVOUNUM",gx.O.A1196LiqMVouNum,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1196LiqMVouNum=this.val())},val:function(){return gx.fn.getControlValue("LIQMVOUNUM")},nac:gx.falseFn};n[114]={id:114,fld:"",grid:0};n[115]={id:115,fld:"",grid:0};n[116]={id:116,fld:"",grid:0};n[117]={id:117,fld:"",grid:0};n[118]={id:118,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Liqmtmovcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LIQMTMOVCOD",gxz:"Z278LiqMTMovCod",gxold:"O278LiqMTMovCod",gxvar:"A278LiqMTMovCod",ucs:[],op:[143,123],ip:[143,123,118],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A278LiqMTMovCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z278LiqMTMovCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("LIQMTMOVCOD",gx.O.A278LiqMTMovCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A278LiqMTMovCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("LIQMTMOVCOD",",")},nac:gx.falseFn};n[119]={id:119,fld:"",grid:0};n[120]={id:120,fld:"",grid:0};n[121]={id:121,fld:"",grid:0};n[122]={id:122,fld:"",grid:0};n[123]={id:123,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LIQMTMOVDSC",gxz:"Z1191LiqMTMovDsc",gxold:"O1191LiqMTMovDsc",gxvar:"A1191LiqMTMovDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1191LiqMTMovDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z1191LiqMTMovDsc=n)},v2c:function(){gx.fn.setControlValue("LIQMTMOVDSC",gx.O.A1191LiqMTMovDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1191LiqMTMovDsc=this.val())},val:function(){return gx.fn.getControlValue("LIQMTMOVDSC")},nac:gx.falseFn};n[124]={id:124,fld:"",grid:0};n[125]={id:125,fld:"",grid:0};n[126]={id:126,fld:"",grid:0};n[127]={id:127,fld:"",grid:0};n[128]={id:128,lvl:0,type:"char",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LIQMUSUCOD",gxz:"Z1192LiqMUsuCod",gxold:"O1192LiqMUsuCod",gxvar:"A1192LiqMUsuCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1192LiqMUsuCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z1192LiqMUsuCod=n)},v2c:function(){gx.fn.setControlValue("LIQMUSUCOD",gx.O.A1192LiqMUsuCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1192LiqMUsuCod=this.val())},val:function(){return gx.fn.getControlValue("LIQMUSUCOD")},nac:gx.falseFn};n[129]={id:129,fld:"",grid:0};n[130]={id:130,fld:"",grid:0};n[131]={id:131,fld:"",grid:0};n[132]={id:132,fld:"",grid:0};n[133]={id:133,lvl:0,type:"dtime",len:8,dec:5,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Liqmusufec,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LIQMUSUFEC",gxz:"Z1193LiqMUsuFec",gxold:"O1193LiqMUsuFec",gxvar:"A1193LiqMUsuFec",dp:{f:0,st:!0,wn:!1,mf:!1,pic:"99/99/99 99:99",dec:5},ucs:[],op:[133],ip:[133],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1193LiqMUsuFec=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z1193LiqMUsuFec=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("LIQMUSUFEC",gx.O.A1193LiqMUsuFec,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1193LiqMUsuFec=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getDateTimeValue("LIQMUSUFEC")},nac:gx.falseFn};n[134]={id:134,fld:"",grid:0};n[135]={id:135,fld:"",grid:0};n[136]={id:136,fld:"",grid:0};n[137]={id:137,fld:"",grid:0};n[138]={id:138,lvl:0,type:"int",len:10,dec:0,sign:!1,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LIQMPAGREG",gxz:"Z1186LiqMPagReg",gxold:"O1186LiqMPagReg",gxvar:"A1186LiqMPagReg",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1186LiqMPagReg=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1186LiqMPagReg=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("LIQMPAGREG",gx.O.A1186LiqMPagReg,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1186LiqMPagReg=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("LIQMPAGREG",",")},nac:gx.falseFn};n[139]={id:139,fld:"",grid:0};n[140]={id:140,fld:"",grid:0};n[141]={id:141,fld:"",grid:0};n[142]={id:142,fld:"",grid:0};n[143]={id:143,lvl:0,type:"char",len:15,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LIQMTMOVCUECOD",gxz:"Z1190LiqMTMovCueCod",gxold:"O1190LiqMTMovCueCod",gxvar:"A1190LiqMTMovCueCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1190LiqMTMovCueCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z1190LiqMTMovCueCod=n)},v2c:function(){gx.fn.setControlValue("LIQMTMOVCUECOD",gx.O.A1190LiqMTMovCueCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1190LiqMTMovCueCod=this.val())},val:function(){return gx.fn.getControlValue("LIQMTMOVCUECOD")},nac:gx.falseFn};n[144]={id:144,fld:"",grid:0};n[145]={id:145,fld:"",grid:0};n[146]={id:146,fld:"",grid:0};n[147]={id:147,fld:"",grid:0};n[148]={id:148,fld:"BTN_ENTER",grid:0,evt:"e113d116_client",std:"ENTER"};n[149]={id:149,fld:"",grid:0};n[150]={id:150,fld:"BTN_CANCEL",grid:0,evt:"e123d116_client"};n[151]={id:151,fld:"",grid:0};n[152]={id:152,fld:"BTN_DELETE",grid:0,evt:"e183d116_client",std:"DELETE"};this.A270LiqCod="";this.Z270LiqCod="";this.O270LiqCod="";this.A236LiqPrvCod="";this.Z236LiqPrvCod="";this.O236LiqPrvCod="";this.A277LiqMItem=0;this.Z277LiqMItem=0;this.O277LiqMItem=0;this.A1180LiqMFech=gx.date.nullDate();this.Z1180LiqMFech=gx.date.nullDate();this.O1180LiqMFech=gx.date.nullDate();this.A1179LiqMConcepto="";this.Z1179LiqMConcepto="";this.O1179LiqMConcepto="";this.A281LiqMPrvCod="";this.Z281LiqMPrvCod="";this.O281LiqMPrvCod="";this.A1187LiqMPrvDsc="";this.Z1187LiqMPrvDsc="";this.O1187LiqMPrvDsc="";this.A279LiqMTipCod="";this.Z279LiqMTipCod="";this.O279LiqMTipCod="";this.A280LiqMComCod="";this.Z280LiqMComCod="";this.O280LiqMComCod="";this.A1181LiqMForCod=0;this.Z1181LiqMForCod=0;this.O1181LiqMForCod=0;this.A1183LiqMMonCod=0;this.Z1183LiqMMonCod=0;this.O1183LiqMMonCod=0;this.A1189LiqMTipCmb=0;this.Z1189LiqMTipCmb=0;this.O1189LiqMTipCmb=0;this.A1182LiqMImporte=0;this.Z1182LiqMImporte=0;this.O1182LiqMImporte=0;this.A1185LiqMPago=0;this.Z1185LiqMPago=0;this.O1185LiqMPago=0;this.A1194LiqMVouAno=0;this.Z1194LiqMVouAno=0;this.O1194LiqMVouAno=0;this.A1195LiqMVouMes=0;this.Z1195LiqMVouMes=0;this.O1195LiqMVouMes=0;this.A1188LiqMTASICod=0;this.Z1188LiqMTASICod=0;this.O1188LiqMTASICod=0;this.A1196LiqMVouNum="";this.Z1196LiqMVouNum="";this.O1196LiqMVouNum="";this.A278LiqMTMovCod=0;this.Z278LiqMTMovCod=0;this.O278LiqMTMovCod=0;this.A1191LiqMTMovDsc="";this.Z1191LiqMTMovDsc="";this.O1191LiqMTMovDsc="";this.A1192LiqMUsuCod="";this.Z1192LiqMUsuCod="";this.O1192LiqMUsuCod="";this.A1193LiqMUsuFec=gx.date.nullDate();this.Z1193LiqMUsuFec=gx.date.nullDate();this.O1193LiqMUsuFec=gx.date.nullDate();this.A1186LiqMPagReg=0;this.Z1186LiqMPagReg=0;this.O1186LiqMPagReg=0;this.A1190LiqMTMovCueCod="";this.Z1190LiqMTMovCueCod="";this.O1190LiqMTMovCueCod="";this.A270LiqCod="";this.A236LiqPrvCod="";this.A277LiqMItem=0;this.A1180LiqMFech=gx.date.nullDate();this.A1179LiqMConcepto="";this.A281LiqMPrvCod="";this.A1187LiqMPrvDsc="";this.A279LiqMTipCod="";this.A280LiqMComCod="";this.A1181LiqMForCod=0;this.A1183LiqMMonCod=0;this.A1189LiqMTipCmb=0;this.A1182LiqMImporte=0;this.A1185LiqMPago=0;this.A1194LiqMVouAno=0;this.A1195LiqMVouMes=0;this.A1188LiqMTASICod=0;this.A1196LiqMVouNum="";this.A278LiqMTMovCod=0;this.A1191LiqMTMovDsc="";this.A1192LiqMUsuCod="";this.A1193LiqMUsuFec=gx.date.nullDate();this.A1186LiqMPagReg=0;this.A1190LiqMTMovCueCod="";this.Events={e113d116_client:["ENTER",!0],e123d116_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_LIQCOD=[[],[]];this.EvtParms.VALID_LIQPRVCOD=[[{av:"A236LiqPrvCod",fld:"LIQPRVCOD",pic:""}],[]];this.EvtParms.VALID_LIQMITEM=[[{av:"A270LiqCod",fld:"LIQCOD",pic:""},{av:"A236LiqPrvCod",fld:"LIQPRVCOD",pic:""},{av:"A277LiqMItem",fld:"LIQMITEM",pic:"ZZZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A1180LiqMFech",fld:"LIQMFECH",pic:""},{av:"A1179LiqMConcepto",fld:"LIQMCONCEPTO",pic:""},{av:"A281LiqMPrvCod",fld:"LIQMPRVCOD",pic:"@!"},{av:"A279LiqMTipCod",fld:"LIQMTIPCOD",pic:""},{av:"A280LiqMComCod",fld:"LIQMCOMCOD",pic:""},{av:"A1181LiqMForCod",fld:"LIQMFORCOD",pic:"ZZZZZ9"},{av:"A1189LiqMTipCmb",fld:"LIQMTIPCMB",pic:"ZZZZ9.9999"},{av:"A1182LiqMImporte",fld:"LIQMIMPORTE",pic:"ZZZZZZZZZZZ9.99"},{av:"A1185LiqMPago",fld:"LIQMPAGO",pic:"ZZZZZZ,ZZZ,ZZ9.99"},{av:"A1194LiqMVouAno",fld:"LIQMVOUANO",pic:"ZZZ9"},{av:"A1195LiqMVouMes",fld:"LIQMVOUMES",pic:"Z9"},{av:"A1188LiqMTASICod",fld:"LIQMTASICOD",pic:"ZZZZZ9"},{av:"A1196LiqMVouNum",fld:"LIQMVOUNUM",pic:""},{av:"A278LiqMTMovCod",fld:"LIQMTMOVCOD",pic:"ZZZZZ9"},{av:"A1192LiqMUsuCod",fld:"LIQMUSUCOD",pic:""},{av:"A1193LiqMUsuFec",fld:"LIQMUSUFEC",pic:"99/99/99 99:99"},{av:"A1186LiqMPagReg",fld:"LIQMPAGREG",pic:"ZZZZZZZZZ9"},{av:"A1183LiqMMonCod",fld:"LIQMMONCOD",pic:"ZZZZZ9"},{av:"A1187LiqMPrvDsc",fld:"LIQMPRVDSC",pic:""},{av:"A1191LiqMTMovDsc",fld:"LIQMTMOVDSC",pic:""},{av:"A1190LiqMTMovCueCod",fld:"LIQMTMOVCUECOD",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z270LiqCod"},{av:"Z236LiqPrvCod"},{av:"Z277LiqMItem"},{av:"Z1180LiqMFech"},{av:"Z1179LiqMConcepto"},{av:"Z281LiqMPrvCod"},{av:"Z279LiqMTipCod"},{av:"Z280LiqMComCod"},{av:"Z1181LiqMForCod"},{av:"Z1189LiqMTipCmb"},{av:"Z1182LiqMImporte"},{av:"Z1185LiqMPago"},{av:"Z1194LiqMVouAno"},{av:"Z1195LiqMVouMes"},{av:"Z1188LiqMTASICod"},{av:"Z1196LiqMVouNum"},{av:"Z278LiqMTMovCod"},{av:"Z1192LiqMUsuCod"},{av:"Z1193LiqMUsuFec"},{av:"Z1186LiqMPagReg"},{av:"Z1183LiqMMonCod"},{av:"Z1187LiqMPrvDsc"},{av:"Z1191LiqMTMovDsc"},{av:"Z1190LiqMTMovCueCod"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"}]];this.EvtParms.VALID_LIQMFECH=[[{av:"A1180LiqMFech",fld:"LIQMFECH",pic:""}],[{av:"A1180LiqMFech",fld:"LIQMFECH",pic:""}]];this.EvtParms.VALID_LIQMPRVCOD=[[{av:"A281LiqMPrvCod",fld:"LIQMPRVCOD",pic:"@!"},{av:"A1187LiqMPrvDsc",fld:"LIQMPRVDSC",pic:""}],[{av:"A1187LiqMPrvDsc",fld:"LIQMPRVDSC",pic:""}]];this.EvtParms.VALID_LIQMTIPCOD=[[],[]];this.EvtParms.VALID_LIQMCOMCOD=[[{av:"A279LiqMTipCod",fld:"LIQMTIPCOD",pic:""},{av:"A280LiqMComCod",fld:"LIQMCOMCOD",pic:""},{av:"A281LiqMPrvCod",fld:"LIQMPRVCOD",pic:"@!"},{av:"A1183LiqMMonCod",fld:"LIQMMONCOD",pic:"ZZZZZ9"}],[{av:"A1183LiqMMonCod",fld:"LIQMMONCOD",pic:"ZZZZZ9"}]];this.EvtParms.VALID_LIQMTMOVCOD=[[{av:"A278LiqMTMovCod",fld:"LIQMTMOVCOD",pic:"ZZZZZ9"},{av:"A1191LiqMTMovDsc",fld:"LIQMTMOVDSC",pic:""},{av:"A1190LiqMTMovCueCod",fld:"LIQMTMOVCUECOD",pic:""}],[{av:"A1191LiqMTMovDsc",fld:"LIQMTMOVDSC",pic:""},{av:"A1190LiqMTMovCueCod",fld:"LIQMTMOVCUECOD",pic:""}]];this.EvtParms.VALID_LIQMUSUFEC=[[{av:"A1193LiqMUsuFec",fld:"LIQMUSUFEC",pic:"99/99/99 99:99"}],[{av:"A1193LiqMUsuFec",fld:"LIQMUSUFEC",pic:"99/99/99 99:99"}]];this.EnterCtrl=["BTN_ENTER"];this.Initialize()});gx.wi(function(){gx.createParentObj(this.cpliquidaciondet)})