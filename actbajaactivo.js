gx.evt.autoSkip=!1;gx.define("actbajaactivo",!1,function(){this.ServerClass="actbajaactivo";this.PackageName="GeneXus.Programs";this.ServerFullClass="actbajaactivo.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Actabajcod=function(){return this.validSrvEvt("Valid_Actabajcod",0).then(function(n){return n}.closure(this))};this.Valid_Actabajfec=function(){return this.validCliEvt("Valid_Actabajfec",0,function(){try{var n=gx.util.balloon.getNew("ACTABAJFEC");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.A2175ACTABajFec)==0||new gx.date.gxdate(this.A2175ACTABajFec).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Fecha fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Actactcod=function(){return this.validSrvEvt("Valid_Actactcod",0).then(function(n){return n}.closure(this))};this.Valid_Actactitem=function(){return this.validSrvEvt("Valid_Actactitem",0).then(function(n){return n}.closure(this))};this.e116u188_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e126u188_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100,101,102,103,104,105,106,107,108,109,110,111,112,113,114,115,116,117];this.GXLastCtrlId=117;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"TABLEMAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"BTN_FIRST",grid:0,evt:"e136u188_client",std:"FIRST"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"BTN_PREVIOUS",grid:0,evt:"e146u188_client",std:"PREVIOUS"};n[15]={id:15,fld:"",grid:0};n[16]={id:16,fld:"BTN_NEXT",grid:0,evt:"e156u188_client",std:"NEXT"};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"BTN_LAST",grid:0,evt:"e166u188_client",std:"LAST"};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"BTN_SELECT",grid:0,evt:"e176u188_client",std:"SELECT"};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,lvl:0,type:"svchar",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Actabajcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTABAJCOD",gxz:"Z2106ACTABajCod",gxold:"O2106ACTABajCod",gxvar:"A2106ACTABajCod",ucs:[],op:[48,38,108,103,98,93,88,83,78,58,53,33],ip:[48,38,108,103,98,93,88,83,78,58,53,33,28],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2106ACTABajCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z2106ACTABajCod=n)},v2c:function(){gx.fn.setControlValue("ACTABAJCOD",gx.O.A2106ACTABajCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2106ACTABajCod=this.val())},val:function(){return gx.fn.getControlValue("ACTABAJCOD")},nac:gx.falseFn};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Actabajfec,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTABAJFEC",gxz:"Z2175ACTABajFec",gxold:"O2175ACTABajFec",gxvar:"A2175ACTABajFec",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[33],ip:[33],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2175ACTABajFec=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z2175ACTABajFec=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("ACTABAJFEC",gx.O.A2175ACTABajFec,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2175ACTABajFec=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("ACTABAJFEC")},nac:gx.falseFn};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,lvl:0,type:"svchar",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Actactcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTACTCOD",gxz:"Z2100ACTActCod",gxold:"O2100ACTActCod",gxvar:"A2100ACTActCod",ucs:[],op:[68,63,43],ip:[68,63,43,38],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2100ACTActCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z2100ACTActCod=n)},v2c:function(){gx.fn.setControlValue("ACTACTCOD",gx.O.A2100ACTActCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2100ACTActCod=this.val())},val:function(){return gx.fn.getControlValue("ACTACTCOD")},nac:gx.falseFn};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTACTDSC",gxz:"Z2122ACTActDsc",gxold:"O2122ACTActDsc",gxvar:"A2122ACTActDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2122ACTActDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z2122ACTActDsc=n)},v2c:function(){gx.fn.setControlValue("ACTACTDSC",gx.O.A2122ACTActDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2122ACTActDsc=this.val())},val:function(){return gx.fn.getControlValue("ACTACTDSC")},nac:gx.falseFn};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,lvl:0,type:"svchar",len:5,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Actactitem,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTACTITEM",gxz:"Z2104ActActItem",gxold:"O2104ActActItem",gxvar:"A2104ActActItem",ucs:[],op:[73],ip:[73,48,38],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2104ActActItem=n)},v2z:function(n){n!==undefined&&(gx.O.Z2104ActActItem=n)},v2c:function(){gx.fn.setControlValue("ACTACTITEM",gx.O.A2104ActActItem,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2104ActActItem=this.val())},val:function(){return gx.fn.getControlValue("ACTACTITEM")},nac:gx.falseFn};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTABAJDSC",gxz:"Z2174ACTABajDsc",gxold:"O2174ACTABajDsc",gxvar:"A2174ACTABajDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2174ACTABajDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z2174ACTABajDsc=n)},v2c:function(){gx.fn.setControlValue("ACTABAJDSC",gx.O.A2174ACTABajDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2174ACTABajDsc=this.val())},val:function(){return gx.fn.getControlValue("ACTABAJDSC")},nac:gx.falseFn};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,lvl:0,type:"int",len:5,dec:0,sign:!1,pic:"ZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTBAJGRUPCOD",gxz:"Z2179ACTBajGrupCod",gxold:"O2179ACTBajGrupCod",gxvar:"A2179ACTBajGrupCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2179ACTBajGrupCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z2179ACTBajGrupCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("ACTBAJGRUPCOD",gx.O.A2179ACTBajGrupCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2179ACTBajGrupCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("ACTBAJGRUPCOD",",")},nac:gx.falseFn};n[59]={id:59,fld:"",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,lvl:0,type:"svchar",len:5,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTCLACOD",gxz:"Z426ACTClaCod",gxold:"O426ACTClaCod",gxvar:"A426ACTClaCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A426ACTClaCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z426ACTClaCod=n)},v2c:function(){gx.fn.setControlValue("ACTCLACOD",gx.O.A426ACTClaCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A426ACTClaCod=this.val())},val:function(){return gx.fn.getControlValue("ACTCLACOD")},nac:gx.falseFn};n[64]={id:64,fld:"",grid:0};n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"",grid:0};n[67]={id:67,fld:"",grid:0};n[68]={id:68,lvl:0,type:"svchar",len:5,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTGRUPCOD",gxz:"Z2103ACTGrupCod",gxold:"O2103ACTGrupCod",gxvar:"A2103ACTGrupCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2103ACTGrupCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z2103ACTGrupCod=n)},v2c:function(){gx.fn.setControlValue("ACTGRUPCOD",gx.O.A2103ACTGrupCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2103ACTGrupCod=this.val())},val:function(){return gx.fn.getControlValue("ACTGRUPCOD")},nac:gx.falseFn};n[69]={id:69,fld:"",grid:0};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"",grid:0};n[73]={id:73,lvl:0,type:"svchar",len:5,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTSGRUPCOD",gxz:"Z2114ACTSGrupCod",gxold:"O2114ACTSGrupCod",gxvar:"A2114ACTSGrupCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2114ACTSGrupCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z2114ACTSGrupCod=n)},v2c:function(){gx.fn.setControlValue("ACTSGRUPCOD",gx.O.A2114ACTSGrupCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2114ACTSGrupCod=this.val())},val:function(){return gx.fn.getControlValue("ACTSGRUPCOD")},nac:gx.falseFn};n[74]={id:74,fld:"",grid:0};n[75]={id:75,fld:"",grid:0};n[76]={id:76,fld:"",grid:0};n[77]={id:77,fld:"",grid:0};n[78]={id:78,lvl:0,type:"vchar",len:500,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTABAJOBS",gxz:"Z2176ACTABajObs",gxold:"O2176ACTABajObs",gxvar:"A2176ACTABajObs",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2176ACTABajObs=n)},v2z:function(n){n!==undefined&&(gx.O.Z2176ACTABajObs=n)},v2c:function(){gx.fn.setControlValue("ACTABAJOBS",gx.O.A2176ACTABajObs,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2176ACTABajObs=this.val())},val:function(){return gx.fn.getControlValue("ACTABAJOBS")},nac:gx.falseFn};n[79]={id:79,fld:"",grid:0};n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"",grid:0};n[82]={id:82,fld:"",grid:0};n[83]={id:83,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTVOUANO",gxz:"Z2181ACTVouAno",gxold:"O2181ACTVouAno",gxvar:"A2181ACTVouAno",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2181ACTVouAno=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z2181ACTVouAno=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("ACTVOUANO",gx.O.A2181ACTVouAno,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2181ACTVouAno=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("ACTVOUANO",",")},nac:gx.falseFn};n[84]={id:84,fld:"",grid:0};n[85]={id:85,fld:"",grid:0};n[86]={id:86,fld:"",grid:0};n[87]={id:87,fld:"",grid:0};n[88]={id:88,lvl:0,type:"int",len:2,dec:0,sign:!1,pic:"Z9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTVOUMES",gxz:"Z2182ACTVouMes",gxold:"O2182ACTVouMes",gxvar:"A2182ACTVouMes",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2182ACTVouMes=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z2182ACTVouMes=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("ACTVOUMES",gx.O.A2182ACTVouMes,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2182ACTVouMes=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("ACTVOUMES",",")},nac:gx.falseFn};n[89]={id:89,fld:"",grid:0};n[90]={id:90,fld:"",grid:0};n[91]={id:91,fld:"",grid:0};n[92]={id:92,fld:"",grid:0};n[93]={id:93,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTTASICOD",gxz:"Z2180ACTTasiCod",gxold:"O2180ACTTasiCod",gxvar:"A2180ACTTasiCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2180ACTTasiCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z2180ACTTasiCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("ACTTASICOD",gx.O.A2180ACTTasiCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2180ACTTasiCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("ACTTASICOD",",")},nac:gx.falseFn};n[94]={id:94,fld:"",grid:0};n[95]={id:95,fld:"",grid:0};n[96]={id:96,fld:"",grid:0};n[97]={id:97,fld:"",grid:0};n[98]={id:98,lvl:0,type:"char",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTVOUNUM",gxz:"Z2183ACTVouNum",gxold:"O2183ACTVouNum",gxvar:"A2183ACTVouNum",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2183ACTVouNum=n)},v2z:function(n){n!==undefined&&(gx.O.Z2183ACTVouNum=n)},v2c:function(){gx.fn.setControlValue("ACTVOUNUM",gx.O.A2183ACTVouNum,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2183ACTVouNum=this.val())},val:function(){return gx.fn.getControlValue("ACTVOUNUM")},nac:gx.falseFn};n[99]={id:99,fld:"",grid:0};n[100]={id:100,fld:"",grid:0};n[101]={id:101,fld:"",grid:0};n[102]={id:102,fld:"",grid:0};n[103]={id:103,lvl:0,type:"decimal",len:15,dec:2,sign:!0,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTBAJCOSTO",gxz:"Z2177ACTBajCosto",gxold:"O2177ACTBajCosto",gxvar:"A2177ACTBajCosto",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2177ACTBajCosto=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z2177ACTBajCosto=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("ACTBAJCOSTO",gx.O.A2177ACTBajCosto,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A2177ACTBajCosto=this.val())},val:function(){return gx.fn.getDecimalValue("ACTBAJCOSTO",",",".")},nac:gx.falseFn};this.declareDomainHdlr(103,function(){});n[104]={id:104,fld:"",grid:0};n[105]={id:105,fld:"",grid:0};n[106]={id:106,fld:"",grid:0};n[107]={id:107,fld:"",grid:0};n[108]={id:108,lvl:0,type:"decimal",len:15,dec:2,sign:!0,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTBAJDEPRE",gxz:"Z2178ACTBajDepre",gxold:"O2178ACTBajDepre",gxvar:"A2178ACTBajDepre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2178ACTBajDepre=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z2178ACTBajDepre=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("ACTBAJDEPRE",gx.O.A2178ACTBajDepre,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A2178ACTBajDepre=this.val())},val:function(){return gx.fn.getDecimalValue("ACTBAJDEPRE",",",".")},nac:gx.falseFn};this.declareDomainHdlr(108,function(){});n[109]={id:109,fld:"",grid:0};n[110]={id:110,fld:"",grid:0};n[111]={id:111,fld:"",grid:0};n[112]={id:112,fld:"",grid:0};n[113]={id:113,fld:"BTN_ENTER",grid:0,evt:"e116u188_client",std:"ENTER"};n[114]={id:114,fld:"",grid:0};n[115]={id:115,fld:"BTN_CANCEL",grid:0,evt:"e126u188_client"};n[116]={id:116,fld:"",grid:0};n[117]={id:117,fld:"BTN_DELETE",grid:0,evt:"e186u188_client",std:"DELETE"};this.A2106ACTABajCod="";this.Z2106ACTABajCod="";this.O2106ACTABajCod="";this.A2175ACTABajFec=gx.date.nullDate();this.Z2175ACTABajFec=gx.date.nullDate();this.O2175ACTABajFec=gx.date.nullDate();this.A2100ACTActCod="";this.Z2100ACTActCod="";this.O2100ACTActCod="";this.A2122ACTActDsc="";this.Z2122ACTActDsc="";this.O2122ACTActDsc="";this.A2104ActActItem="";this.Z2104ActActItem="";this.O2104ActActItem="";this.A2174ACTABajDsc="";this.Z2174ACTABajDsc="";this.O2174ACTABajDsc="";this.A2179ACTBajGrupCod=0;this.Z2179ACTBajGrupCod=0;this.O2179ACTBajGrupCod=0;this.A426ACTClaCod="";this.Z426ACTClaCod="";this.O426ACTClaCod="";this.A2103ACTGrupCod="";this.Z2103ACTGrupCod="";this.O2103ACTGrupCod="";this.A2114ACTSGrupCod="";this.Z2114ACTSGrupCod="";this.O2114ACTSGrupCod="";this.A2176ACTABajObs="";this.Z2176ACTABajObs="";this.O2176ACTABajObs="";this.A2181ACTVouAno=0;this.Z2181ACTVouAno=0;this.O2181ACTVouAno=0;this.A2182ACTVouMes=0;this.Z2182ACTVouMes=0;this.O2182ACTVouMes=0;this.A2180ACTTasiCod=0;this.Z2180ACTTasiCod=0;this.O2180ACTTasiCod=0;this.A2183ACTVouNum="";this.Z2183ACTVouNum="";this.O2183ACTVouNum="";this.A2177ACTBajCosto=0;this.Z2177ACTBajCosto=0;this.O2177ACTBajCosto=0;this.A2178ACTBajDepre=0;this.Z2178ACTBajDepre=0;this.O2178ACTBajDepre=0;this.A2106ACTABajCod="";this.A2175ACTABajFec=gx.date.nullDate();this.A2100ACTActCod="";this.A2122ACTActDsc="";this.A2104ActActItem="";this.A2174ACTABajDsc="";this.A2179ACTBajGrupCod=0;this.A426ACTClaCod="";this.A2103ACTGrupCod="";this.A2114ACTSGrupCod="";this.A2176ACTABajObs="";this.A2181ACTVouAno=0;this.A2182ACTVouMes=0;this.A2180ACTTasiCod=0;this.A2183ACTVouNum="";this.A2177ACTBajCosto=0;this.A2178ACTBajDepre=0;this.Events={e116u188_client:["ENTER",!0],e126u188_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_ACTABAJCOD=[[{av:"A2106ACTABajCod",fld:"ACTABAJCOD",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A2175ACTABajFec",fld:"ACTABAJFEC",pic:""},{av:"A2100ACTActCod",fld:"ACTACTCOD",pic:""},{av:"A2104ActActItem",fld:"ACTACTITEM",pic:""},{av:"A2174ACTABajDsc",fld:"ACTABAJDSC",pic:""},{av:"A2179ACTBajGrupCod",fld:"ACTBAJGRUPCOD",pic:"ZZZZ9"},{av:"A2176ACTABajObs",fld:"ACTABAJOBS",pic:""},{av:"A2181ACTVouAno",fld:"ACTVOUANO",pic:"ZZZ9"},{av:"A2182ACTVouMes",fld:"ACTVOUMES",pic:"Z9"},{av:"A2180ACTTasiCod",fld:"ACTTASICOD",pic:"ZZZZZ9"},{av:"A2183ACTVouNum",fld:"ACTVOUNUM",pic:""},{av:"A2177ACTBajCosto",fld:"ACTBAJCOSTO",pic:"ZZZZZZ,ZZZ,ZZ9.99"},{av:"A2178ACTBajDepre",fld:"ACTBAJDEPRE",pic:"ZZZZZZ,ZZZ,ZZ9.99"},{av:"A2122ACTActDsc",fld:"ACTACTDSC",pic:""},{av:"A426ACTClaCod",fld:"ACTCLACOD",pic:""},{av:"A2103ACTGrupCod",fld:"ACTGRUPCOD",pic:""},{av:"A2114ACTSGrupCod",fld:"ACTSGRUPCOD",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z2106ACTABajCod"},{av:"Z2175ACTABajFec"},{av:"Z2100ACTActCod"},{av:"Z2104ActActItem"},{av:"Z2174ACTABajDsc"},{av:"Z2179ACTBajGrupCod"},{av:"Z2176ACTABajObs"},{av:"Z2181ACTVouAno"},{av:"Z2182ACTVouMes"},{av:"Z2180ACTTasiCod"},{av:"Z2183ACTVouNum"},{av:"Z2177ACTBajCosto"},{av:"Z2178ACTBajDepre"},{av:"Z2122ACTActDsc"},{av:"Z426ACTClaCod"},{av:"Z2103ACTGrupCod"},{av:"Z2114ACTSGrupCod"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"}]];this.EvtParms.VALID_ACTABAJFEC=[[{av:"A2175ACTABajFec",fld:"ACTABAJFEC",pic:""}],[{av:"A2175ACTABajFec",fld:"ACTABAJFEC",pic:""}]];this.EvtParms.VALID_ACTACTCOD=[[{av:"A2100ACTActCod",fld:"ACTACTCOD",pic:""},{av:"A2122ACTActDsc",fld:"ACTACTDSC",pic:""},{av:"A426ACTClaCod",fld:"ACTCLACOD",pic:""},{av:"A2103ACTGrupCod",fld:"ACTGRUPCOD",pic:""}],[{av:"A2122ACTActDsc",fld:"ACTACTDSC",pic:""},{av:"A426ACTClaCod",fld:"ACTCLACOD",pic:""},{av:"A2103ACTGrupCod",fld:"ACTGRUPCOD",pic:""}]];this.EvtParms.VALID_ACTACTITEM=[[{av:"A2100ACTActCod",fld:"ACTACTCOD",pic:""},{av:"A2104ActActItem",fld:"ACTACTITEM",pic:""},{av:"A2114ACTSGrupCod",fld:"ACTSGRUPCOD",pic:""}],[{av:"A2114ACTSGrupCod",fld:"ACTSGRUPCOD",pic:""}]];this.EnterCtrl=["BTN_ENTER"];this.Initialize()});gx.wi(function(){gx.createParentObj(this.actbajaactivo)})