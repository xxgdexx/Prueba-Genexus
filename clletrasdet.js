gx.evt.autoSkip=!1;gx.define("clletrasdet",!1,function(){this.ServerClass="clletrasdet";this.PackageName="GeneXus.Programs";this.ServerFullClass="clletrasdet.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.A1123LetCVendCod=gx.fn.getIntegerValue("LETCVENDCOD",",")};this.Valid_Letcletcod=function(){return this.validSrvEvt("Valid_Letcletcod",0).then(function(n){return n}.closure(this))};this.Valid_Letcitem=function(){return this.validSrvEvt("Valid_Letcitem",0).then(function(n){return n}.closure(this))};this.Valid_Letctipcod=function(){return this.validCliEvt("Valid_Letctipcod",0,function(){try{var n=gx.util.balloon.getNew("LETCTIPCOD");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Letcdocnum=function(){return this.validSrvEvt("Valid_Letcdocnum",0).then(function(n){return n}.closure(this))};this.Valid_Letcfeclet=function(){return this.validCliEvt("Valid_Letcfeclet",0,function(){try{var n=gx.util.balloon.getNew("LETCFECLET");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.A1108LetCFecLet)==0||new gx.date.gxdate(this.A1108LetCFecLet).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Fecha fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Letcfecvcto=function(){return this.validCliEvt("Valid_Letcfecvcto",0,function(){try{var n=gx.util.balloon.getNew("LETCFECVCTO");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.A1109LetCFecVcto)==0||new gx.date.gxdate(this.A1109LetCFecVcto).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Fecha Vcto fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e112r94_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e122r94_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,5,6,7,8,9,15,18,20,23,25,26,29,31,34,36,39,41,44,46,49,51,54,56,59,61,64,66,69,71,74,76,79,81,84,86,89,91,94,96,99,101,104,106,109,111,114,115,116,117,118];this.GXLastCtrlId=118;n[2]={id:2,fld:"TABLE1",grid:0};n[5]={id:5,fld:"BTN_FIRST",grid:0,evt:"e132r94_client",std:"FIRST"};n[6]={id:6,fld:"BTN_PREVIOUS",grid:0,evt:"e142r94_client",std:"PREVIOUS"};n[7]={id:7,fld:"BTN_NEXT",grid:0,evt:"e152r94_client",std:"NEXT"};n[8]={id:8,fld:"BTN_LAST",grid:0,evt:"e162r94_client",std:"LAST"};n[9]={id:9,fld:"BTN_SELECT",grid:0,evt:"e172r94_client",std:"SELECT"};n[15]={id:15,fld:"TABLE2",grid:0};n[18]={id:18,fld:"TEXTBLOCK1",format:0,grid:0,ctrltype:"textblock"};n[20]={id:20,lvl:0,type:"char",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Letcletcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LETCLETCOD",gxz:"Z204LetCLetCod",gxold:"O204LetCLetCod",gxvar:"A204LetCLetCod",ucs:[],op:[],ip:[20],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A204LetCLetCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z204LetCLetCod=n)},v2c:function(){gx.fn.setControlValue("LETCLETCOD",gx.O.A204LetCLetCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A204LetCLetCod=this.val())},val:function(){return gx.fn.getControlValue("LETCLETCOD")},nac:gx.falseFn};n[23]={id:23,fld:"TEXTBLOCK2",format:0,grid:0,ctrltype:"textblock"};n[25]={id:25,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Letcitem,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LETCITEM",gxz:"Z207LetCItem",gxold:"O207LetCItem",gxvar:"A207LetCItem",ucs:[],op:[41,36,111,106,101,96,91,86,81,76,71,66,61,56,51,46,31],ip:[41,36,111,106,101,96,91,86,81,76,71,66,61,56,51,46,31,25,20],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A207LetCItem=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z207LetCItem=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("LETCITEM",gx.O.A207LetCItem,0)},c2v:function(){this.val()!==undefined&&(gx.O.A207LetCItem=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("LETCITEM",",")},nac:gx.falseFn};n[26]={id:26,fld:"BTN_GET",grid:0,evt:"e182r94_client",std:"GET"};n[29]={id:29,fld:"TEXTBLOCK3",format:0,grid:0,ctrltype:"textblock"};n[31]={id:31,lvl:0,type:"char",len:1,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LETCTIPO",gxz:"Z1120LetCTipo",gxold:"O1120LetCTipo",gxvar:"A1120LetCTipo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1120LetCTipo=n)},v2z:function(n){n!==undefined&&(gx.O.Z1120LetCTipo=n)},v2c:function(){gx.fn.setControlValue("LETCTIPO",gx.O.A1120LetCTipo,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1120LetCTipo=this.val())},val:function(){return gx.fn.getControlValue("LETCTIPO")},nac:gx.falseFn};n[34]={id:34,fld:"TEXTBLOCK4",format:0,grid:0,ctrltype:"textblock"};n[36]={id:36,lvl:0,type:"char",len:3,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Letctipcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LETCTIPCOD",gxz:"Z208LetCTipCod",gxold:"O208LetCTipCod",gxvar:"A208LetCTipCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A208LetCTipCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z208LetCTipCod=n)},v2c:function(){gx.fn.setControlValue("LETCTIPCOD",gx.O.A208LetCTipCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A208LetCTipCod=this.val())},val:function(){return gx.fn.getControlValue("LETCTIPCOD")},nac:gx.falseFn};n[39]={id:39,fld:"TEXTBLOCK5",format:0,grid:0,ctrltype:"textblock"};n[41]={id:41,lvl:0,type:"char",len:12,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Letcdocnum,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LETCDOCNUM",gxz:"Z209LetCDocNum",gxold:"O209LetCDocNum",gxvar:"A209LetCDocNum",ucs:[],op:[],ip:[41,36],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A209LetCDocNum=n)},v2z:function(n){n!==undefined&&(gx.O.Z209LetCDocNum=n)},v2c:function(){gx.fn.setControlValue("LETCDOCNUM",gx.O.A209LetCDocNum,0)},c2v:function(){this.val()!==undefined&&(gx.O.A209LetCDocNum=this.val())},val:function(){return gx.fn.getControlValue("LETCDOCNUM")},nac:gx.falseFn};n[44]={id:44,fld:"TEXTBLOCK6",format:0,grid:0,ctrltype:"textblock"};n[46]={id:46,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LETCDIAS",gxz:"Z1107LetCDias",gxold:"O1107LetCDias",gxvar:"A1107LetCDias",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1107LetCDias=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1107LetCDias=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("LETCDIAS",gx.O.A1107LetCDias,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1107LetCDias=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("LETCDIAS",",")},nac:gx.falseFn};n[49]={id:49,fld:"TEXTBLOCK7",format:0,grid:0,ctrltype:"textblock"};n[51]={id:51,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Letcfeclet,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LETCFECLET",gxz:"Z1108LetCFecLet",gxold:"O1108LetCFecLet",gxvar:"A1108LetCFecLet",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[51],ip:[51],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1108LetCFecLet=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z1108LetCFecLet=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("LETCFECLET",gx.O.A1108LetCFecLet,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1108LetCFecLet=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("LETCFECLET")},nac:gx.falseFn};n[54]={id:54,fld:"TEXTBLOCK8",format:0,grid:0,ctrltype:"textblock"};n[56]={id:56,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Letcfecvcto,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LETCFECVCTO",gxz:"Z1109LetCFecVcto",gxold:"O1109LetCFecVcto",gxvar:"A1109LetCFecVcto",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[56],ip:[56],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1109LetCFecVcto=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z1109LetCFecVcto=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("LETCFECVCTO",gx.O.A1109LetCFecVcto,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1109LetCFecVcto=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("LETCFECVCTO")},nac:gx.falseFn};n[59]={id:59,fld:"TEXTBLOCK9",format:0,grid:0,ctrltype:"textblock"};n[61]={id:61,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LETCGIRADOR",gxz:"Z1111LetCGirador",gxold:"O1111LetCGirador",gxvar:"A1111LetCGirador",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1111LetCGirador=n)},v2z:function(n){n!==undefined&&(gx.O.Z1111LetCGirador=n)},v2c:function(){gx.fn.setControlValue("LETCGIRADOR",gx.O.A1111LetCGirador,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1111LetCGirador=this.val())},val:function(){return gx.fn.getControlValue("LETCGIRADOR")},nac:gx.falseFn};n[64]={id:64,fld:"TEXTBLOCK10",format:0,grid:0,ctrltype:"textblock"};n[66]={id:66,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LETCLUGAR",gxz:"Z1115LetCLugar",gxold:"O1115LetCLugar",gxvar:"A1115LetCLugar",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1115LetCLugar=n)},v2z:function(n){n!==undefined&&(gx.O.Z1115LetCLugar=n)},v2c:function(){gx.fn.setControlValue("LETCLUGAR",gx.O.A1115LetCLugar,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1115LetCLugar=this.val())},val:function(){return gx.fn.getControlValue("LETCLUGAR")},nac:gx.falseFn};n[69]={id:69,fld:"TEXTBLOCK11",format:0,grid:0,ctrltype:"textblock"};n[71]={id:71,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LETCAVAL",gxz:"Z1100LetCAval",gxold:"O1100LetCAval",gxvar:"A1100LetCAval",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1100LetCAval=n)},v2z:function(n){n!==undefined&&(gx.O.Z1100LetCAval=n)},v2c:function(){gx.fn.setControlValue("LETCAVAL",gx.O.A1100LetCAval,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1100LetCAval=this.val())},val:function(){return gx.fn.getControlValue("LETCAVAL")},nac:gx.falseFn};n[74]={id:74,fld:"TEXTBLOCK12",format:0,grid:0,ctrltype:"textblock"};n[76]={id:76,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LETCAVALDIR",gxz:"Z1101LetCAvalDir",gxold:"O1101LetCAvalDir",gxvar:"A1101LetCAvalDir",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1101LetCAvalDir=n)},v2z:function(n){n!==undefined&&(gx.O.Z1101LetCAvalDir=n)},v2c:function(){gx.fn.setControlValue("LETCAVALDIR",gx.O.A1101LetCAvalDir,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1101LetCAvalDir=this.val())},val:function(){return gx.fn.getControlValue("LETCAVALDIR")},nac:gx.falseFn};n[79]={id:79,fld:"TEXTBLOCK13",format:0,grid:0,ctrltype:"textblock"};n[81]={id:81,lvl:0,type:"svchar",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LETCAVALRUC",gxz:"Z1102LetCAvalRUC",gxold:"O1102LetCAvalRUC",gxvar:"A1102LetCAvalRUC",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1102LetCAvalRUC=n)},v2z:function(n){n!==undefined&&(gx.O.Z1102LetCAvalRUC=n)},v2c:function(){gx.fn.setControlValue("LETCAVALRUC",gx.O.A1102LetCAvalRUC,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1102LetCAvalRUC=this.val())},val:function(){return gx.fn.getControlValue("LETCAVALRUC")},nac:gx.falseFn};n[84]={id:84,fld:"TEXTBLOCK14",format:0,grid:0,ctrltype:"textblock"};n[86]={id:86,lvl:0,type:"svchar",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LETCAVALTELF",gxz:"Z1103LetCAvalTelf",gxold:"O1103LetCAvalTelf",gxvar:"A1103LetCAvalTelf",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1103LetCAvalTelf=n)},v2z:function(n){n!==undefined&&(gx.O.Z1103LetCAvalTelf=n)},v2c:function(){gx.fn.setControlValue("LETCAVALTELF",gx.O.A1103LetCAvalTelf,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1103LetCAvalTelf=this.val())},val:function(){return gx.fn.getControlValue("LETCAVALTELF")},nac:gx.falseFn};n[89]={id:89,fld:"TEXTBLOCK15",format:0,grid:0,ctrltype:"textblock"};n[91]={id:91,lvl:0,type:"decimal",len:15,dec:2,sign:!0,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LETCIMPDET",gxz:"Z1112LetCImpDet",gxold:"O1112LetCImpDet",gxvar:"A1112LetCImpDet",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1112LetCImpDet=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z1112LetCImpDet=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("LETCIMPDET",gx.O.A1112LetCImpDet,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A1112LetCImpDet=this.val())},val:function(){return gx.fn.getDecimalValue("LETCIMPDET",",",".")},nac:gx.falseFn};this.declareDomainHdlr(91,function(){});n[94]={id:94,fld:"TEXTBLOCK16",format:0,grid:0,ctrltype:"textblock"};n[96]={id:96,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LETCBANCOD",gxz:"Z1104LetCBanCod",gxold:"O1104LetCBanCod",gxvar:"A1104LetCBanCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1104LetCBanCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1104LetCBanCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("LETCBANCOD",gx.O.A1104LetCBanCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1104LetCBanCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("LETCBANCOD",",")},nac:gx.falseFn};n[99]={id:99,fld:"TEXTBLOCK17",format:0,grid:0,ctrltype:"textblock"};n[101]={id:101,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LETCCBCOD",gxz:"Z1106LetCCBCod",gxold:"O1106LetCCBCod",gxvar:"A1106LetCCBCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1106LetCCBCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z1106LetCCBCod=n)},v2c:function(){gx.fn.setControlValue("LETCCBCOD",gx.O.A1106LetCCBCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1106LetCCBCod=this.val())},val:function(){return gx.fn.getControlValue("LETCCBCOD")},nac:gx.falseFn};n[104]={id:104,fld:"TEXTBLOCK18",format:0,grid:0,ctrltype:"textblock"};n[106]={id:106,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LETCSEC",gxz:"Z1116LetCSec",gxold:"O1116LetCSec",gxvar:"A1116LetCSec",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1116LetCSec=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1116LetCSec=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("LETCSEC",gx.O.A1116LetCSec,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1116LetCSec=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("LETCSEC",",")},nac:gx.falseFn};n[109]={id:109,fld:"TEXTBLOCK19",format:0,grid:0,ctrltype:"textblock"};n[111]={id:111,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LETCBANNUM",gxz:"Z1105LetCBanNum",gxold:"O1105LetCBanNum",gxvar:"A1105LetCBanNum",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1105LetCBanNum=n)},v2z:function(n){n!==undefined&&(gx.O.Z1105LetCBanNum=n)},v2c:function(){gx.fn.setControlValue("LETCBANNUM",gx.O.A1105LetCBanNum,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1105LetCBanNum=this.val())},val:function(){return gx.fn.getControlValue("LETCBANNUM")},nac:gx.falseFn};n[114]={id:114,fld:"BTN_ENTER",grid:0,evt:"e112r94_client",std:"ENTER"};n[115]={id:115,fld:"BTN_CHECK",grid:0,evt:"e192r94_client",std:"CHECK"};n[116]={id:116,fld:"BTN_CANCEL",grid:0,evt:"e122r94_client"};n[117]={id:117,fld:"BTN_DELETE",grid:0,evt:"e202r94_client",std:"DELETE"};n[118]={id:118,fld:"BTN_HELP",grid:0,evt:"e212r94_client"};this.A204LetCLetCod="";this.Z204LetCLetCod="";this.O204LetCLetCod="";this.A207LetCItem=0;this.Z207LetCItem=0;this.O207LetCItem=0;this.A1120LetCTipo="";this.Z1120LetCTipo="";this.O1120LetCTipo="";this.A208LetCTipCod="";this.Z208LetCTipCod="";this.O208LetCTipCod="";this.A209LetCDocNum="";this.Z209LetCDocNum="";this.O209LetCDocNum="";this.A1107LetCDias=0;this.Z1107LetCDias=0;this.O1107LetCDias=0;this.A1108LetCFecLet=gx.date.nullDate();this.Z1108LetCFecLet=gx.date.nullDate();this.O1108LetCFecLet=gx.date.nullDate();this.A1109LetCFecVcto=gx.date.nullDate();this.Z1109LetCFecVcto=gx.date.nullDate();this.O1109LetCFecVcto=gx.date.nullDate();this.A1111LetCGirador="";this.Z1111LetCGirador="";this.O1111LetCGirador="";this.A1115LetCLugar="";this.Z1115LetCLugar="";this.O1115LetCLugar="";this.A1100LetCAval="";this.Z1100LetCAval="";this.O1100LetCAval="";this.A1101LetCAvalDir="";this.Z1101LetCAvalDir="";this.O1101LetCAvalDir="";this.A1102LetCAvalRUC="";this.Z1102LetCAvalRUC="";this.O1102LetCAvalRUC="";this.A1103LetCAvalTelf="";this.Z1103LetCAvalTelf="";this.O1103LetCAvalTelf="";this.A1112LetCImpDet=0;this.Z1112LetCImpDet=0;this.O1112LetCImpDet=0;this.A1104LetCBanCod=0;this.Z1104LetCBanCod=0;this.O1104LetCBanCod=0;this.A1106LetCCBCod="";this.Z1106LetCCBCod="";this.O1106LetCCBCod="";this.A1116LetCSec=0;this.Z1116LetCSec=0;this.O1116LetCSec=0;this.A1105LetCBanNum="";this.Z1105LetCBanNum="";this.O1105LetCBanNum="";this.A204LetCLetCod="";this.A207LetCItem=0;this.A1120LetCTipo="";this.A208LetCTipCod="";this.A209LetCDocNum="";this.A1107LetCDias=0;this.A1108LetCFecLet=gx.date.nullDate();this.A1109LetCFecVcto=gx.date.nullDate();this.A1111LetCGirador="";this.A1115LetCLugar="";this.A1100LetCAval="";this.A1101LetCAvalDir="";this.A1102LetCAvalRUC="";this.A1103LetCAvalTelf="";this.A1112LetCImpDet=0;this.A1104LetCBanCod=0;this.A1106LetCCBCod="";this.A1116LetCSec=0;this.A1105LetCBanNum="";this.A1123LetCVendCod=0;this.Events={e112r94_client:["ENTER",!0],e122r94_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_LETCLETCOD=[[{av:"A204LetCLetCod",fld:"LETCLETCOD",pic:""}],[]];this.EvtParms.VALID_LETCITEM=[[{av:"A204LetCLetCod",fld:"LETCLETCOD",pic:""},{av:"A207LetCItem",fld:"LETCITEM",pic:"ZZZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A1120LetCTipo",fld:"LETCTIPO",pic:""},{av:"A208LetCTipCod",fld:"LETCTIPCOD",pic:""},{av:"A209LetCDocNum",fld:"LETCDOCNUM",pic:""},{av:"A1107LetCDias",fld:"LETCDIAS",pic:"ZZZ9"},{av:"A1108LetCFecLet",fld:"LETCFECLET",pic:""},{av:"A1109LetCFecVcto",fld:"LETCFECVCTO",pic:""},{av:"A1111LetCGirador",fld:"LETCGIRADOR",pic:""},{av:"A1115LetCLugar",fld:"LETCLUGAR",pic:""},{av:"A1100LetCAval",fld:"LETCAVAL",pic:""},{av:"A1101LetCAvalDir",fld:"LETCAVALDIR",pic:""},{av:"A1102LetCAvalRUC",fld:"LETCAVALRUC",pic:""},{av:"A1103LetCAvalTelf",fld:"LETCAVALTELF",pic:""},{av:"A1112LetCImpDet",fld:"LETCIMPDET",pic:"ZZZZZZ,ZZZ,ZZ9.99"},{av:"A1104LetCBanCod",fld:"LETCBANCOD",pic:"ZZZZZ9"},{av:"A1106LetCCBCod",fld:"LETCCBCOD",pic:""},{av:"A1116LetCSec",fld:"LETCSEC",pic:"ZZZZZ9"},{av:"A1105LetCBanNum",fld:"LETCBANNUM",pic:""},{av:"A1123LetCVendCod",fld:"LETCVENDCOD",pic:"ZZZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z204LetCLetCod"},{av:"Z207LetCItem"},{av:"Z1120LetCTipo"},{av:"Z208LetCTipCod"},{av:"Z209LetCDocNum"},{av:"Z1107LetCDias"},{av:"Z1108LetCFecLet"},{av:"Z1109LetCFecVcto"},{av:"Z1111LetCGirador"},{av:"Z1115LetCLugar"},{av:"Z1100LetCAval"},{av:"Z1101LetCAvalDir"},{av:"Z1102LetCAvalRUC"},{av:"Z1103LetCAvalTelf"},{av:"Z1112LetCImpDet"},{av:"Z1104LetCBanCod"},{av:"Z1106LetCCBCod"},{av:"Z1116LetCSec"},{av:"Z1105LetCBanNum"},{av:"Z1123LetCVendCod"},{ctrl:"BTN_GET",prop:"Enabled"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"},{ctrl:"BTN_CHECK",prop:"Enabled"}]];this.EvtParms.VALID_LETCTIPCOD=[[],[]];this.EvtParms.VALID_LETCDOCNUM=[[{av:"A208LetCTipCod",fld:"LETCTIPCOD",pic:""},{av:"A209LetCDocNum",fld:"LETCDOCNUM",pic:""},{av:"A1123LetCVendCod",fld:"LETCVENDCOD",pic:"ZZZZZ9"}],[{av:"A1123LetCVendCod",fld:"LETCVENDCOD",pic:"ZZZZZ9"}]];this.EvtParms.VALID_LETCFECLET=[[{av:"A1108LetCFecLet",fld:"LETCFECLET",pic:""}],[{av:"A1108LetCFecLet",fld:"LETCFECLET",pic:""}]];this.EvtParms.VALID_LETCFECVCTO=[[{av:"A1109LetCFecVcto",fld:"LETCFECVCTO",pic:""}],[{av:"A1109LetCFecVcto",fld:"LETCFECVCTO",pic:""}]];this.EnterCtrl=["BTN_ENTER"];this.CheckCtrl=["BTN_CHECK"];this.setVCMap("A1123LetCVendCod","LETCVENDCOD",0,"int",6,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.clletrasdet)})