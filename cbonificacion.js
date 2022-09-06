gx.evt.autoSkip = false;
gx.define('cbonificacion', false, function () {
   this.ServerClass =  "cbonificacion" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.ServerFullClass =  "cbonificacion.aspx" ;
   this.setObjectType("trn");
   this.hasEnterEvent = true;
   this.skipOnEnter = false;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
   };
   this.Valid_Cbonprodcod=function()
   {
      return this.validSrvEvt("Valid_Cbonprodcod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Cbondprodcod=function()
   {
      return this.validSrvEvt("Valid_Cbondprodcod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.e11044_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e12044_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100,101,102];
   this.GXLastCtrlId =102;
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"TABLEMAIN",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"TITLE", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[9]={ id: 9, fld:"",grid:0};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[11]={ id: 11, fld:"",grid:0};
   GXValidFnc[12]={ id: 12, fld:"BTN_FIRST",grid:0,evt:"e13044_client",std:"FIRST"};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"BTN_PREVIOUS",grid:0,evt:"e14044_client",std:"PREVIOUS"};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id: 16, fld:"BTN_NEXT",grid:0,evt:"e15044_client",std:"NEXT"};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"BTN_LAST",grid:0,evt:"e16044_client",std:"LAST"};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"BTN_SELECT",grid:0,evt:"e17044_client",std:"SELECT"};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[26]={ id: 26, fld:"",grid:0};
   GXValidFnc[27]={ id: 27, fld:"",grid:0};
   GXValidFnc[28]={ id:28 ,lvl:0,type:"char",len:15,dec:0,sign:false,pic:"@!",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cbonprodcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CBONPRODCOD",gxz:"Z81CBonProdCod",gxold:"O81CBonProdCod",gxvar:"A81CBonProdCod",ucs:[],op:[33,38,93,88,83,78,73,68,63,58,53,48],ip:[33,38,93,88,83,78,73,68,63,58,53,48,28],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A81CBonProdCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z81CBonProdCod=Value},v2c:function(){gx.fn.setControlValue("CBONPRODCOD",gx.O.A81CBonProdCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A81CBonProdCod=this.val()},val:function(){return gx.fn.getControlValue("CBONPRODCOD")},nac:gx.falseFn};
   GXValidFnc[29]={ id: 29, fld:"",grid:0};
   GXValidFnc[30]={ id: 30, fld:"",grid:0};
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   GXValidFnc[32]={ id: 32, fld:"",grid:0};
   GXValidFnc[33]={ id:33 ,lvl:0,type:"char",len:100,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CBONPRODDSC",gxz:"Z503CBonProdDsc",gxold:"O503CBonProdDsc",gxvar:"A503CBonProdDsc",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A503CBonProdDsc=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z503CBonProdDsc=Value},v2c:function(){gx.fn.setControlValue("CBONPRODDSC",gx.O.A503CBonProdDsc,0)},c2v:function(){if(this.val()!==undefined)gx.O.A503CBonProdDsc=this.val()},val:function(){return gx.fn.getControlValue("CBONPRODDSC")},nac:gx.falseFn};
   GXValidFnc[34]={ id: 34, fld:"",grid:0};
   GXValidFnc[35]={ id: 35, fld:"",grid:0};
   GXValidFnc[36]={ id: 36, fld:"",grid:0};
   GXValidFnc[37]={ id: 37, fld:"",grid:0};
   GXValidFnc[38]={ id:38 ,lvl:0,type:"char",len:15,dec:0,sign:false,pic:"@!",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cbondprodcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CBONDPRODCOD",gxz:"Z82CBonDProdCod",gxold:"O82CBonDProdCod",gxvar:"A82CBonDProdCod",ucs:[],op:[43],ip:[43,38],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A82CBonDProdCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z82CBonDProdCod=Value},v2c:function(){gx.fn.setControlValue("CBONDPRODCOD",gx.O.A82CBonDProdCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A82CBonDProdCod=this.val()},val:function(){return gx.fn.getControlValue("CBONDPRODCOD")},nac:gx.falseFn};
   GXValidFnc[39]={ id: 39, fld:"",grid:0};
   GXValidFnc[40]={ id: 40, fld:"",grid:0};
   GXValidFnc[41]={ id: 41, fld:"",grid:0};
   GXValidFnc[42]={ id: 42, fld:"",grid:0};
   GXValidFnc[43]={ id:43 ,lvl:0,type:"char",len:100,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CBONDPRODDSC",gxz:"Z502CBonDProdDsc",gxold:"O502CBonDProdDsc",gxvar:"A502CBonDProdDsc",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A502CBonDProdDsc=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z502CBonDProdDsc=Value},v2c:function(){gx.fn.setControlValue("CBONDPRODDSC",gx.O.A502CBonDProdDsc,0)},c2v:function(){if(this.val()!==undefined)gx.O.A502CBonDProdDsc=this.val()},val:function(){return gx.fn.getControlValue("CBONDPRODDSC")},nac:gx.falseFn};
   GXValidFnc[44]={ id: 44, fld:"",grid:0};
   GXValidFnc[45]={ id: 45, fld:"",grid:0};
   GXValidFnc[46]={ id: 46, fld:"",grid:0};
   GXValidFnc[47]={ id: 47, fld:"",grid:0};
   GXValidFnc[48]={ id:48 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CBONCAN1",gxz:"Z497CBonCan1",gxold:"O497CBonCan1",gxvar:"A497CBonCan1",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A497CBonCan1=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z497CBonCan1=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("CBONCAN1",gx.O.A497CBonCan1,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A497CBonCan1=this.val()},val:function(){return gx.fn.getDecimalValue("CBONCAN1",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 48 , function() {
   });
   GXValidFnc[49]={ id: 49, fld:"",grid:0};
   GXValidFnc[50]={ id: 50, fld:"",grid:0};
   GXValidFnc[51]={ id: 51, fld:"",grid:0};
   GXValidFnc[52]={ id: 52, fld:"",grid:0};
   GXValidFnc[53]={ id:53 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CBONBON1",gxz:"Z492CBonBon1",gxold:"O492CBonBon1",gxvar:"A492CBonBon1",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A492CBonBon1=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z492CBonBon1=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("CBONBON1",gx.O.A492CBonBon1,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A492CBonBon1=this.val()},val:function(){return gx.fn.getDecimalValue("CBONBON1",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 53 , function() {
   });
   GXValidFnc[54]={ id: 54, fld:"",grid:0};
   GXValidFnc[55]={ id: 55, fld:"",grid:0};
   GXValidFnc[56]={ id: 56, fld:"",grid:0};
   GXValidFnc[57]={ id: 57, fld:"",grid:0};
   GXValidFnc[58]={ id:58 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CBONCAN2",gxz:"Z498CBonCan2",gxold:"O498CBonCan2",gxvar:"A498CBonCan2",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A498CBonCan2=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z498CBonCan2=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("CBONCAN2",gx.O.A498CBonCan2,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A498CBonCan2=this.val()},val:function(){return gx.fn.getDecimalValue("CBONCAN2",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 58 , function() {
   });
   GXValidFnc[59]={ id: 59, fld:"",grid:0};
   GXValidFnc[60]={ id: 60, fld:"",grid:0};
   GXValidFnc[61]={ id: 61, fld:"",grid:0};
   GXValidFnc[62]={ id: 62, fld:"",grid:0};
   GXValidFnc[63]={ id:63 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CBONBON2",gxz:"Z493CBonBon2",gxold:"O493CBonBon2",gxvar:"A493CBonBon2",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A493CBonBon2=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z493CBonBon2=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("CBONBON2",gx.O.A493CBonBon2,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A493CBonBon2=this.val()},val:function(){return gx.fn.getDecimalValue("CBONBON2",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 63 , function() {
   });
   GXValidFnc[64]={ id: 64, fld:"",grid:0};
   GXValidFnc[65]={ id: 65, fld:"",grid:0};
   GXValidFnc[66]={ id: 66, fld:"",grid:0};
   GXValidFnc[67]={ id: 67, fld:"",grid:0};
   GXValidFnc[68]={ id:68 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CBONCAN3",gxz:"Z499CBonCan3",gxold:"O499CBonCan3",gxvar:"A499CBonCan3",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A499CBonCan3=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z499CBonCan3=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("CBONCAN3",gx.O.A499CBonCan3,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A499CBonCan3=this.val()},val:function(){return gx.fn.getDecimalValue("CBONCAN3",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 68 , function() {
   });
   GXValidFnc[69]={ id: 69, fld:"",grid:0};
   GXValidFnc[70]={ id: 70, fld:"",grid:0};
   GXValidFnc[71]={ id: 71, fld:"",grid:0};
   GXValidFnc[72]={ id: 72, fld:"",grid:0};
   GXValidFnc[73]={ id:73 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CBONBON3",gxz:"Z494CBonBon3",gxold:"O494CBonBon3",gxvar:"A494CBonBon3",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A494CBonBon3=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z494CBonBon3=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("CBONBON3",gx.O.A494CBonBon3,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A494CBonBon3=this.val()},val:function(){return gx.fn.getDecimalValue("CBONBON3",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 73 , function() {
   });
   GXValidFnc[74]={ id: 74, fld:"",grid:0};
   GXValidFnc[75]={ id: 75, fld:"",grid:0};
   GXValidFnc[76]={ id: 76, fld:"",grid:0};
   GXValidFnc[77]={ id: 77, fld:"",grid:0};
   GXValidFnc[78]={ id:78 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CBONCAN4",gxz:"Z500CBonCan4",gxold:"O500CBonCan4",gxvar:"A500CBonCan4",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A500CBonCan4=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z500CBonCan4=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("CBONCAN4",gx.O.A500CBonCan4,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A500CBonCan4=this.val()},val:function(){return gx.fn.getDecimalValue("CBONCAN4",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 78 , function() {
   });
   GXValidFnc[79]={ id: 79, fld:"",grid:0};
   GXValidFnc[80]={ id: 80, fld:"",grid:0};
   GXValidFnc[81]={ id: 81, fld:"",grid:0};
   GXValidFnc[82]={ id: 82, fld:"",grid:0};
   GXValidFnc[83]={ id:83 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CBONBON4",gxz:"Z495CBonBon4",gxold:"O495CBonBon4",gxvar:"A495CBonBon4",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A495CBonBon4=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z495CBonBon4=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("CBONBON4",gx.O.A495CBonBon4,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A495CBonBon4=this.val()},val:function(){return gx.fn.getDecimalValue("CBONBON4",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 83 , function() {
   });
   GXValidFnc[84]={ id: 84, fld:"",grid:0};
   GXValidFnc[85]={ id: 85, fld:"",grid:0};
   GXValidFnc[86]={ id: 86, fld:"",grid:0};
   GXValidFnc[87]={ id: 87, fld:"",grid:0};
   GXValidFnc[88]={ id:88 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CBONCAN5",gxz:"Z501CBonCan5",gxold:"O501CBonCan5",gxvar:"A501CBonCan5",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A501CBonCan5=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z501CBonCan5=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("CBONCAN5",gx.O.A501CBonCan5,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A501CBonCan5=this.val()},val:function(){return gx.fn.getDecimalValue("CBONCAN5",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 88 , function() {
   });
   GXValidFnc[89]={ id: 89, fld:"",grid:0};
   GXValidFnc[90]={ id: 90, fld:"",grid:0};
   GXValidFnc[91]={ id: 91, fld:"",grid:0};
   GXValidFnc[92]={ id: 92, fld:"",grid:0};
   GXValidFnc[93]={ id:93 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CBONBON5",gxz:"Z496CBonBon5",gxold:"O496CBonBon5",gxvar:"A496CBonBon5",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A496CBonBon5=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z496CBonBon5=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("CBONBON5",gx.O.A496CBonBon5,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A496CBonBon5=this.val()},val:function(){return gx.fn.getDecimalValue("CBONBON5",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 93 , function() {
   });
   GXValidFnc[94]={ id: 94, fld:"",grid:0};
   GXValidFnc[95]={ id: 95, fld:"",grid:0};
   GXValidFnc[96]={ id: 96, fld:"",grid:0};
   GXValidFnc[97]={ id: 97, fld:"",grid:0};
   GXValidFnc[98]={ id: 98, fld:"BTN_ENTER",grid:0,evt:"e11044_client",std:"ENTER"};
   GXValidFnc[99]={ id: 99, fld:"",grid:0};
   GXValidFnc[100]={ id: 100, fld:"BTN_CANCEL",grid:0,evt:"e12044_client"};
   GXValidFnc[101]={ id: 101, fld:"",grid:0};
   GXValidFnc[102]={ id: 102, fld:"BTN_DELETE",grid:0,evt:"e18044_client",std:"DELETE"};
   this.A81CBonProdCod = "" ;
   this.Z81CBonProdCod = "" ;
   this.O81CBonProdCod = "" ;
   this.A503CBonProdDsc = "" ;
   this.Z503CBonProdDsc = "" ;
   this.O503CBonProdDsc = "" ;
   this.A82CBonDProdCod = "" ;
   this.Z82CBonDProdCod = "" ;
   this.O82CBonDProdCod = "" ;
   this.A502CBonDProdDsc = "" ;
   this.Z502CBonDProdDsc = "" ;
   this.O502CBonDProdDsc = "" ;
   this.A497CBonCan1 = 0 ;
   this.Z497CBonCan1 = 0 ;
   this.O497CBonCan1 = 0 ;
   this.A492CBonBon1 = 0 ;
   this.Z492CBonBon1 = 0 ;
   this.O492CBonBon1 = 0 ;
   this.A498CBonCan2 = 0 ;
   this.Z498CBonCan2 = 0 ;
   this.O498CBonCan2 = 0 ;
   this.A493CBonBon2 = 0 ;
   this.Z493CBonBon2 = 0 ;
   this.O493CBonBon2 = 0 ;
   this.A499CBonCan3 = 0 ;
   this.Z499CBonCan3 = 0 ;
   this.O499CBonCan3 = 0 ;
   this.A494CBonBon3 = 0 ;
   this.Z494CBonBon3 = 0 ;
   this.O494CBonBon3 = 0 ;
   this.A500CBonCan4 = 0 ;
   this.Z500CBonCan4 = 0 ;
   this.O500CBonCan4 = 0 ;
   this.A495CBonBon4 = 0 ;
   this.Z495CBonBon4 = 0 ;
   this.O495CBonBon4 = 0 ;
   this.A501CBonCan5 = 0 ;
   this.Z501CBonCan5 = 0 ;
   this.O501CBonCan5 = 0 ;
   this.A496CBonBon5 = 0 ;
   this.Z496CBonBon5 = 0 ;
   this.O496CBonBon5 = 0 ;
   this.A81CBonProdCod = "" ;
   this.A503CBonProdDsc = "" ;
   this.A82CBonDProdCod = "" ;
   this.A502CBonDProdDsc = "" ;
   this.A497CBonCan1 = 0 ;
   this.A492CBonBon1 = 0 ;
   this.A498CBonCan2 = 0 ;
   this.A493CBonBon2 = 0 ;
   this.A499CBonCan3 = 0 ;
   this.A494CBonBon3 = 0 ;
   this.A500CBonCan4 = 0 ;
   this.A495CBonBon4 = 0 ;
   this.A501CBonCan5 = 0 ;
   this.A496CBonBon5 = 0 ;
   this.Events = {"e11044_client": ["ENTER", true] ,"e12044_client": ["CANCEL", true]};
   this.EvtParms["ENTER"] = [[{postForm:true}],[]];
   this.EvtParms["REFRESH"] = [[],[]];
   this.EvtParms["VALID_CBONPRODCOD"] = [[{av:'A81CBonProdCod',fld:'CBONPRODCOD',pic:'@!'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}],[{av:'A82CBonDProdCod',fld:'CBONDPRODCOD',pic:'@!'},{av:'A497CBonCan1',fld:'CBONCAN1',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A492CBonBon1',fld:'CBONBON1',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A498CBonCan2',fld:'CBONCAN2',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A493CBonBon2',fld:'CBONBON2',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A499CBonCan3',fld:'CBONCAN3',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A494CBonBon3',fld:'CBONBON3',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A500CBonCan4',fld:'CBONCAN4',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A495CBonBon4',fld:'CBONBON4',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A501CBonCan5',fld:'CBONCAN5',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A496CBonBon5',fld:'CBONBON5',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A503CBonProdDsc',fld:'CBONPRODDSC',pic:''},{av:'A502CBonDProdDsc',fld:'CBONDPRODDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z81CBonProdCod'},{av:'Z82CBonDProdCod'},{av:'Z497CBonCan1'},{av:'Z492CBonBon1'},{av:'Z498CBonCan2'},{av:'Z493CBonBon2'},{av:'Z499CBonCan3'},{av:'Z494CBonBon3'},{av:'Z500CBonCan4'},{av:'Z495CBonBon4'},{av:'Z501CBonCan5'},{av:'Z496CBonBon5'},{av:'Z503CBonProdDsc'},{av:'Z502CBonDProdDsc'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]];
   this.EvtParms["VALID_CBONDPRODCOD"] = [[{av:'A82CBonDProdCod',fld:'CBONDPRODCOD',pic:'@!'},{av:'A502CBonDProdDsc',fld:'CBONDPRODDSC',pic:''}],[{av:'A502CBonDProdDsc',fld:'CBONDPRODDSC',pic:''}]];
   this.EnterCtrl = ["BTN_ENTER"];
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(this.cbonificacion);});
