gx.evt.autoSkip = false;
gx.define('clcobranza', false, function () {
   this.ServerClass =  "clcobranza" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.ServerFullClass =  "clcobranza.aspx" ;
   this.setObjectType("trn");
   this.hasEnterEvent = true;
   this.skipOnEnter = false;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
   };
   this.Valid_Cobtip=function()
   {
      return this.validCliEvt("Valid_Cobtip", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("COBTIP");
         this.AnyError  = 0;

      }
      catch(e){}
      try {
          if (gxballoon == null) return true; return gxballoon.show();
      }
      catch(e){}
      return true ;
      });
   }
   this.Valid_Cobcod=function()
   {
      return this.validSrvEvt("Valid_Cobcod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Cobfec=function()
   {
      return this.validCliEvt("Valid_Cobfec", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("COBFEC");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A655CobFec)==0) || new gx.date.gxdate( this.A655CobFec ).compare( gx.date.ymdtod( 1753, 1, 1) ) >= 0 ) )
         {
            try {
               gxballoon.setError("Campo Fecha fuera de rango");
               this.AnyError = gx.num.trunc( 1 ,0) ;
            }
            catch(e){}
         }

      }
      catch(e){}
      try {
          if (gxballoon == null) return true; return gxballoon.show();
      }
      catch(e){}
      return true ;
      });
   }
   this.Valid_Cobmon=function()
   {
      return this.validSrvEvt("Valid_Cobmon", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Cobvendcod=function()
   {
      return this.validSrvEvt("Valid_Cobvendcod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Cobbancod=function()
   {
      return this.validCliEvt("Valid_Cobbancod", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("COBBANCOD");
         this.AnyError  = 0;

      }
      catch(e){}
      try {
          if (gxballoon == null) return true; return gxballoon.show();
      }
      catch(e){}
      return true ;
      });
   }
   this.Valid_Cobcbcod=function()
   {
      return this.validSrvEvt("Valid_Cobcbcod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Cobconbcod=function()
   {
      return this.validSrvEvt("Valid_Cobconbcod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Cobusufec=function()
   {
      return this.validCliEvt("Valid_Cobusufec", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("COBUSUFEC");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A666CobUsuFec)==0) || new gx.date.gxdate( this.A666CobUsuFec ).compare( gx.date.ymdhmstot( 1753, 1, 1, 0, 0, 0) ) >= 0 ) )
         {
            try {
               gxballoon.setError("Campo Usuario Fecha fuera de rango");
               this.AnyError = gx.num.trunc( 1 ,0) ;
            }
            catch(e){}
         }

      }
      catch(e){}
      try {
          if (gxballoon == null) return true; return gxballoon.show();
      }
      catch(e){}
      return true ;
      });
   }
   this.e112g84_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e122g84_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,5,6,7,8,9,15,18,20,23,25,26,29,31,34,36,39,41,44,46,49,51,54,56,59,61,64,66,69,71,74,76,79,81,84,86,89,91,94,96,99,101,104,106,109,111,114,116,119,121,124,126,129,131,134,135,136,137,138];
   this.GXLastCtrlId =138;
   GXValidFnc[2]={ id: 2, fld:"TABLE1",grid:0};
   GXValidFnc[5]={ id: 5, fld:"BTN_FIRST",grid:0,evt:"e132g84_client",std:"FIRST"};
   GXValidFnc[6]={ id: 6, fld:"BTN_PREVIOUS",grid:0,evt:"e142g84_client",std:"PREVIOUS"};
   GXValidFnc[7]={ id: 7, fld:"BTN_NEXT",grid:0,evt:"e152g84_client",std:"NEXT"};
   GXValidFnc[8]={ id: 8, fld:"BTN_LAST",grid:0,evt:"e162g84_client",std:"LAST"};
   GXValidFnc[9]={ id: 9, fld:"BTN_SELECT",grid:0,evt:"e172g84_client",std:"SELECT"};
   GXValidFnc[15]={ id: 15, fld:"TABLE2",grid:0};
   GXValidFnc[18]={ id: 18, fld:"TEXTBLOCK1", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[20]={ id:20 ,lvl:0,type:"char",len:1,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cobtip,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBTIP",gxz:"Z166CobTip",gxold:"O166CobTip",gxvar:"A166CobTip",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A166CobTip=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z166CobTip=Value},v2c:function(){gx.fn.setControlValue("COBTIP",gx.O.A166CobTip,0)},c2v:function(){if(this.val()!==undefined)gx.O.A166CobTip=this.val()},val:function(){return gx.fn.getControlValue("COBTIP")},nac:gx.falseFn};
   GXValidFnc[23]={ id: 23, fld:"TEXTBLOCK2", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[25]={ id:25 ,lvl:0,type:"char",len:12,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cobcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBCOD",gxz:"Z167CobCod",gxold:"O167CobCod",gxvar:"A167CobCod",ucs:[],op:[121,76,71,66,51,36,131,126,116,111,106,101,96,91,86,81,61,31],ip:[121,76,71,66,51,36,131,126,116,111,106,101,96,91,86,81,61,31,25,20],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A167CobCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z167CobCod=Value},v2c:function(){gx.fn.setControlValue("COBCOD",gx.O.A167CobCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A167CobCod=this.val()},val:function(){return gx.fn.getControlValue("COBCOD")},nac:gx.falseFn};
   GXValidFnc[26]={ id: 26, fld:"BTN_GET",grid:0,evt:"e182g84_client",std:"GET"};
   GXValidFnc[29]={ id: 29, fld:"TEXTBLOCK3", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[31]={ id:31 ,lvl:0,type:"date",len:8,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cobfec,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBFEC",gxz:"Z655CobFec",gxold:"O655CobFec",gxvar:"A655CobFec",dp:{f:0,st:false,wn:false,mf:false,pic:"99/99/99",dec:0},ucs:[],op:[31],ip:[31],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A655CobFec=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z655CobFec=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("COBFEC",gx.O.A655CobFec,0)},c2v:function(){if(this.val()!==undefined)gx.O.A655CobFec=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getControlValue("COBFEC")},nac:gx.falseFn};
   GXValidFnc[34]={ id: 34, fld:"TEXTBLOCK4", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[36]={ id:36 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cobmon,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBMON",gxz:"Z172CobMon",gxold:"O172CobMon",gxvar:"A172CobMon",ucs:[],op:[46,41],ip:[46,41,36],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A172CobMon=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z172CobMon=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("COBMON",gx.O.A172CobMon,0)},c2v:function(){if(this.val()!==undefined)gx.O.A172CobMon=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("COBMON",',')},nac:gx.falseFn};
   GXValidFnc[39]={ id: 39, fld:"TEXTBLOCK5", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[41]={ id:41 ,lvl:0,type:"char",len:100,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBMONDSC",gxz:"Z657CobMonDsc",gxold:"O657CobMonDsc",gxvar:"A657CobMonDsc",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A657CobMonDsc=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z657CobMonDsc=Value},v2c:function(){gx.fn.setControlValue("COBMONDSC",gx.O.A657CobMonDsc,0)},c2v:function(){if(this.val()!==undefined)gx.O.A657CobMonDsc=this.val()},val:function(){return gx.fn.getControlValue("COBMONDSC")},nac:gx.falseFn};
   GXValidFnc[44]={ id: 44, fld:"TEXTBLOCK6", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[46]={ id:46 ,lvl:0,type:"char",len:5,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBMONABR",gxz:"Z656CobMonAbr",gxold:"O656CobMonAbr",gxvar:"A656CobMonAbr",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A656CobMonAbr=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z656CobMonAbr=Value},v2c:function(){gx.fn.setControlValue("COBMONABR",gx.O.A656CobMonAbr,0)},c2v:function(){if(this.val()!==undefined)gx.O.A656CobMonAbr=this.val()},val:function(){return gx.fn.getControlValue("COBMONABR")},nac:gx.falseFn};
   GXValidFnc[49]={ id: 49, fld:"TEXTBLOCK7", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[51]={ id:51 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cobvendcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBVENDCOD",gxz:"Z171CobVendCod",gxold:"O171CobVendCod",gxvar:"A171CobVendCod",ucs:[],op:[56],ip:[56,51],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A171CobVendCod=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z171CobVendCod=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("COBVENDCOD",gx.O.A171CobVendCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A171CobVendCod=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("COBVENDCOD",',')},nac:gx.falseFn};
   GXValidFnc[54]={ id: 54, fld:"TEXTBLOCK8", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[56]={ id:56 ,lvl:0,type:"char",len:100,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBVENDDSC",gxz:"Z667CobVendDsc",gxold:"O667CobVendDsc",gxvar:"A667CobVendDsc",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A667CobVendDsc=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z667CobVendDsc=Value},v2c:function(){gx.fn.setControlValue("COBVENDDSC",gx.O.A667CobVendDsc,0)},c2v:function(){if(this.val()!==undefined)gx.O.A667CobVendDsc=this.val()},val:function(){return gx.fn.getControlValue("COBVENDDSC")},nac:gx.falseFn};
   GXValidFnc[59]={ id: 59, fld:"TEXTBLOCK9", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[61]={ id:61 ,lvl:0,type:"int",len:5,dec:0,sign:false,pic:"ZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TOTALITEM",gxz:"Z1927TotalItem",gxold:"O1927TotalItem",gxvar:"A1927TotalItem",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1927TotalItem=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1927TotalItem=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("TOTALITEM",gx.O.A1927TotalItem,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1927TotalItem=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("TOTALITEM",',')},nac:gx.falseFn};
   GXValidFnc[64]={ id: 64, fld:"TEXTBLOCK10", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[66]={ id:66 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cobbancod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBBANCOD",gxz:"Z169CobBanCod",gxold:"O169CobBanCod",gxvar:"A169CobBanCod",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A169CobBanCod=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z169CobBanCod=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("COBBANCOD",gx.O.A169CobBanCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A169CobBanCod=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("COBBANCOD",',')},nac:gx.falseFn};
   GXValidFnc[69]={ id: 69, fld:"TEXTBLOCK11", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[71]={ id:71 ,lvl:0,type:"char",len:20,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cobcbcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBCBCOD",gxz:"Z170CobCbCod",gxold:"O170CobCbCod",gxvar:"A170CobCbCod",ucs:[],op:[],ip:[71,66],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A170CobCbCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z170CobCbCod=Value},v2c:function(){gx.fn.setControlValue("COBCBCOD",gx.O.A170CobCbCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A170CobCbCod=this.val()},val:function(){return gx.fn.getControlValue("COBCBCOD")},nac:gx.falseFn};
   GXValidFnc[74]={ id: 74, fld:"TEXTBLOCK12", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[76]={ id:76 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cobconbcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBCONBCOD",gxz:"Z168CobConBCod",gxold:"O168CobConBCod",gxvar:"A168CobConBCod",ucs:[],op:[],ip:[76],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A168CobConBCod=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z168CobConBCod=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("COBCONBCOD",gx.O.A168CobConBCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A168CobConBCod=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("COBCONBCOD",',')},nac:gx.falseFn};
   GXValidFnc[79]={ id: 79, fld:"TEXTBLOCK13", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[81]={ id:81 ,lvl:0,type:"char",len:10,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBREGISTRO",gxz:"Z660CobRegistro",gxold:"O660CobRegistro",gxvar:"A660CobRegistro",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A660CobRegistro=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z660CobRegistro=Value},v2c:function(){gx.fn.setControlValue("COBREGISTRO",gx.O.A660CobRegistro,0)},c2v:function(){if(this.val()!==undefined)gx.O.A660CobRegistro=this.val()},val:function(){return gx.fn.getControlValue("COBREGISTRO")},nac:gx.falseFn};
   GXValidFnc[84]={ id: 84, fld:"TEXTBLOCK14", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[86]={ id:86 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBBANIMP",gxz:"Z644CobBanImp",gxold:"O644CobBanImp",gxvar:"A644CobBanImp",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A644CobBanImp=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z644CobBanImp=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("COBBANIMP",gx.O.A644CobBanImp,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A644CobBanImp=this.val()},val:function(){return gx.fn.getDecimalValue("COBBANIMP",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 86 , function() {
   });
   GXValidFnc[89]={ id: 89, fld:"TEXTBLOCK15", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[91]={ id:91 ,lvl:0,type:"int",len:1,dec:0,sign:false,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBAFECTA",gxz:"Z643CobAfecta",gxold:"O643CobAfecta",gxvar:"A643CobAfecta",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A643CobAfecta=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z643CobAfecta=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("COBAFECTA",gx.O.A643CobAfecta,0)},c2v:function(){if(this.val()!==undefined)gx.O.A643CobAfecta=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("COBAFECTA",',')},nac:gx.falseFn};
   GXValidFnc[94]={ id: 94, fld:"TEXTBLOCK16", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[96]={ id:96 ,lvl:0,type:"char",len:1,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBSTS",gxz:"Z661CobSts",gxold:"O661CobSts",gxvar:"A661CobSts",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A661CobSts=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z661CobSts=Value},v2c:function(){gx.fn.setControlValue("COBSTS",gx.O.A661CobSts,0)},c2v:function(){if(this.val()!==undefined)gx.O.A661CobSts=this.val()},val:function(){return gx.fn.getControlValue("COBSTS")},nac:gx.falseFn};
   GXValidFnc[99]={ id: 99, fld:"TEXTBLOCK17", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[101]={ id:101 ,lvl:0,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBVOUANO",gxz:"Z668CobVouAno",gxold:"O668CobVouAno",gxvar:"A668CobVouAno",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A668CobVouAno=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z668CobVouAno=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("COBVOUANO",gx.O.A668CobVouAno,0)},c2v:function(){if(this.val()!==undefined)gx.O.A668CobVouAno=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("COBVOUANO",',')},nac:gx.falseFn};
   GXValidFnc[104]={ id: 104, fld:"TEXTBLOCK18", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[106]={ id:106 ,lvl:0,type:"int",len:2,dec:0,sign:false,pic:"Z9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBVOUMES",gxz:"Z669CobVouMes",gxold:"O669CobVouMes",gxvar:"A669CobVouMes",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A669CobVouMes=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z669CobVouMes=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("COBVOUMES",gx.O.A669CobVouMes,0)},c2v:function(){if(this.val()!==undefined)gx.O.A669CobVouMes=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("COBVOUMES",',')},nac:gx.falseFn};
   GXValidFnc[109]={ id: 109, fld:"TEXTBLOCK19", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[111]={ id:111 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBTASICOD",gxz:"Z662CobTAsiCod",gxold:"O662CobTAsiCod",gxvar:"A662CobTAsiCod",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A662CobTAsiCod=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z662CobTAsiCod=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("COBTASICOD",gx.O.A662CobTAsiCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A662CobTAsiCod=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("COBTASICOD",',')},nac:gx.falseFn};
   GXValidFnc[114]={ id: 114, fld:"TEXTBLOCK20", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[116]={ id:116 ,lvl:0,type:"char",len:10,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBVOUNUM",gxz:"Z670CobVouNum",gxold:"O670CobVouNum",gxvar:"A670CobVouNum",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A670CobVouNum=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z670CobVouNum=Value},v2c:function(){gx.fn.setControlValue("COBVOUNUM",gx.O.A670CobVouNum,0)},c2v:function(){if(this.val()!==undefined)gx.O.A670CobVouNum=this.val()},val:function(){return gx.fn.getControlValue("COBVOUNUM")},nac:gx.falseFn};
   GXValidFnc[119]={ id: 119, fld:"TEXTBLOCK21", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[121]={ id:121 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBTOT",gxz:"Z664CobTot",gxold:"O664CobTot",gxvar:"A664CobTot",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A664CobTot=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z664CobTot=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("COBTOT",gx.O.A664CobTot,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A664CobTot=this.val()},val:function(){return gx.fn.getDecimalValue("COBTOT",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 121 , function() {
   });
   GXValidFnc[124]={ id: 124, fld:"TEXTBLOCK22", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[126]={ id:126 ,lvl:0,type:"char",len:10,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBUSUCOD",gxz:"Z665CobUsuCod",gxold:"O665CobUsuCod",gxvar:"A665CobUsuCod",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A665CobUsuCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z665CobUsuCod=Value},v2c:function(){gx.fn.setControlValue("COBUSUCOD",gx.O.A665CobUsuCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A665CobUsuCod=this.val()},val:function(){return gx.fn.getControlValue("COBUSUCOD")},nac:gx.falseFn};
   GXValidFnc[129]={ id: 129, fld:"TEXTBLOCK23", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[131]={ id:131 ,lvl:0,type:"dtime",len:8,dec:5,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cobusufec,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBUSUFEC",gxz:"Z666CobUsuFec",gxold:"O666CobUsuFec",gxvar:"A666CobUsuFec",dp:{f:0,st:true,wn:false,mf:false,pic:"99/99/99 99:99",dec:5},ucs:[],op:[131],ip:[131],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A666CobUsuFec=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z666CobUsuFec=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("COBUSUFEC",gx.O.A666CobUsuFec,0)},c2v:function(){if(this.val()!==undefined)gx.O.A666CobUsuFec=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getDateTimeValue("COBUSUFEC")},nac:gx.falseFn};
   GXValidFnc[134]={ id: 134, fld:"BTN_ENTER",grid:0,evt:"e112g84_client",std:"ENTER"};
   GXValidFnc[135]={ id: 135, fld:"BTN_CHECK",grid:0,evt:"e192g84_client",std:"CHECK"};
   GXValidFnc[136]={ id: 136, fld:"BTN_CANCEL",grid:0,evt:"e122g84_client"};
   GXValidFnc[137]={ id: 137, fld:"BTN_DELETE",grid:0,evt:"e202g84_client",std:"DELETE"};
   GXValidFnc[138]={ id: 138, fld:"BTN_HELP",grid:0,evt:"e212g84_client"};
   this.A166CobTip = "" ;
   this.Z166CobTip = "" ;
   this.O166CobTip = "" ;
   this.A167CobCod = "" ;
   this.Z167CobCod = "" ;
   this.O167CobCod = "" ;
   this.A655CobFec = gx.date.nullDate() ;
   this.Z655CobFec = gx.date.nullDate() ;
   this.O655CobFec = gx.date.nullDate() ;
   this.A172CobMon = 0 ;
   this.Z172CobMon = 0 ;
   this.O172CobMon = 0 ;
   this.A657CobMonDsc = "" ;
   this.Z657CobMonDsc = "" ;
   this.O657CobMonDsc = "" ;
   this.A656CobMonAbr = "" ;
   this.Z656CobMonAbr = "" ;
   this.O656CobMonAbr = "" ;
   this.A171CobVendCod = 0 ;
   this.Z171CobVendCod = 0 ;
   this.O171CobVendCod = 0 ;
   this.A667CobVendDsc = "" ;
   this.Z667CobVendDsc = "" ;
   this.O667CobVendDsc = "" ;
   this.A1927TotalItem = 0 ;
   this.Z1927TotalItem = 0 ;
   this.O1927TotalItem = 0 ;
   this.A169CobBanCod = 0 ;
   this.Z169CobBanCod = 0 ;
   this.O169CobBanCod = 0 ;
   this.A170CobCbCod = "" ;
   this.Z170CobCbCod = "" ;
   this.O170CobCbCod = "" ;
   this.A168CobConBCod = 0 ;
   this.Z168CobConBCod = 0 ;
   this.O168CobConBCod = 0 ;
   this.A660CobRegistro = "" ;
   this.Z660CobRegistro = "" ;
   this.O660CobRegistro = "" ;
   this.A644CobBanImp = 0 ;
   this.Z644CobBanImp = 0 ;
   this.O644CobBanImp = 0 ;
   this.A643CobAfecta = 0 ;
   this.Z643CobAfecta = 0 ;
   this.O643CobAfecta = 0 ;
   this.A661CobSts = "" ;
   this.Z661CobSts = "" ;
   this.O661CobSts = "" ;
   this.A668CobVouAno = 0 ;
   this.Z668CobVouAno = 0 ;
   this.O668CobVouAno = 0 ;
   this.A669CobVouMes = 0 ;
   this.Z669CobVouMes = 0 ;
   this.O669CobVouMes = 0 ;
   this.A662CobTAsiCod = 0 ;
   this.Z662CobTAsiCod = 0 ;
   this.O662CobTAsiCod = 0 ;
   this.A670CobVouNum = "" ;
   this.Z670CobVouNum = "" ;
   this.O670CobVouNum = "" ;
   this.A664CobTot = 0 ;
   this.Z664CobTot = 0 ;
   this.O664CobTot = 0 ;
   this.A665CobUsuCod = "" ;
   this.Z665CobUsuCod = "" ;
   this.O665CobUsuCod = "" ;
   this.A666CobUsuFec = gx.date.nullDate() ;
   this.Z666CobUsuFec = gx.date.nullDate() ;
   this.O666CobUsuFec = gx.date.nullDate() ;
   this.A166CobTip = "" ;
   this.A167CobCod = "" ;
   this.A655CobFec = gx.date.nullDate() ;
   this.A172CobMon = 0 ;
   this.A657CobMonDsc = "" ;
   this.A656CobMonAbr = "" ;
   this.A171CobVendCod = 0 ;
   this.A667CobVendDsc = "" ;
   this.A1927TotalItem = 0 ;
   this.A169CobBanCod = 0 ;
   this.A170CobCbCod = "" ;
   this.A168CobConBCod = 0 ;
   this.A660CobRegistro = "" ;
   this.A644CobBanImp = 0 ;
   this.A643CobAfecta = 0 ;
   this.A661CobSts = "" ;
   this.A668CobVouAno = 0 ;
   this.A669CobVouMes = 0 ;
   this.A662CobTAsiCod = 0 ;
   this.A670CobVouNum = "" ;
   this.A664CobTot = 0 ;
   this.A665CobUsuCod = "" ;
   this.A666CobUsuFec = gx.date.nullDate() ;
   this.Events = {"e112g84_client": ["ENTER", true] ,"e122g84_client": ["CANCEL", true]};
   this.EvtParms["ENTER"] = [[{postForm:true}],[]];
   this.EvtParms["REFRESH"] = [[],[]];
   this.EvtParms["VALID_COBTIP"] = [[],[]];
   this.EvtParms["VALID_COBCOD"] = [[{av:'A166CobTip',fld:'COBTIP',pic:''},{av:'A167CobCod',fld:'COBCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}],[{av:'A655CobFec',fld:'COBFEC',pic:''},{av:'A172CobMon',fld:'COBMON',pic:'ZZZZZ9'},{av:'A171CobVendCod',fld:'COBVENDCOD',pic:'ZZZZZ9'},{av:'A1927TotalItem',fld:'TOTALITEM',pic:'ZZZZ9'},{av:'A169CobBanCod',fld:'COBBANCOD',pic:'ZZZZZ9'},{av:'A170CobCbCod',fld:'COBCBCOD',pic:''},{av:'A168CobConBCod',fld:'COBCONBCOD',pic:'ZZZZZ9'},{av:'A660CobRegistro',fld:'COBREGISTRO',pic:''},{av:'A644CobBanImp',fld:'COBBANIMP',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A643CobAfecta',fld:'COBAFECTA',pic:'9'},{av:'A661CobSts',fld:'COBSTS',pic:''},{av:'A668CobVouAno',fld:'COBVOUANO',pic:'ZZZ9'},{av:'A669CobVouMes',fld:'COBVOUMES',pic:'Z9'},{av:'A662CobTAsiCod',fld:'COBTASICOD',pic:'ZZZZZ9'},{av:'A670CobVouNum',fld:'COBVOUNUM',pic:''},{av:'A665CobUsuCod',fld:'COBUSUCOD',pic:''},{av:'A666CobUsuFec',fld:'COBUSUFEC',pic:'99/99/99 99:99'},{av:'A664CobTot',fld:'COBTOT',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A657CobMonDsc',fld:'COBMONDSC',pic:''},{av:'A656CobMonAbr',fld:'COBMONABR',pic:''},{av:'A667CobVendDsc',fld:'COBVENDDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z166CobTip'},{av:'Z167CobCod'},{av:'Z655CobFec'},{av:'Z172CobMon'},{av:'Z171CobVendCod'},{av:'Z1927TotalItem'},{av:'Z169CobBanCod'},{av:'Z170CobCbCod'},{av:'Z168CobConBCod'},{av:'Z660CobRegistro'},{av:'Z644CobBanImp'},{av:'Z643CobAfecta'},{av:'Z661CobSts'},{av:'Z668CobVouAno'},{av:'Z669CobVouMes'},{av:'Z662CobTAsiCod'},{av:'Z670CobVouNum'},{av:'Z665CobUsuCod'},{av:'Z666CobUsuFec'},{av:'Z664CobTot'},{av:'Z657CobMonDsc'},{av:'Z656CobMonAbr'},{av:'Z667CobVendDsc'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]];
   this.EvtParms["VALID_COBFEC"] = [[{av:'A655CobFec',fld:'COBFEC',pic:''}],[{av:'A655CobFec',fld:'COBFEC',pic:''}]];
   this.EvtParms["VALID_COBMON"] = [[{av:'A172CobMon',fld:'COBMON',pic:'ZZZZZ9'},{av:'A657CobMonDsc',fld:'COBMONDSC',pic:''},{av:'A656CobMonAbr',fld:'COBMONABR',pic:''}],[{av:'A657CobMonDsc',fld:'COBMONDSC',pic:''},{av:'A656CobMonAbr',fld:'COBMONABR',pic:''}]];
   this.EvtParms["VALID_COBVENDCOD"] = [[{av:'A171CobVendCod',fld:'COBVENDCOD',pic:'ZZZZZ9'},{av:'A667CobVendDsc',fld:'COBVENDDSC',pic:''}],[{av:'A667CobVendDsc',fld:'COBVENDDSC',pic:''}]];
   this.EvtParms["VALID_COBBANCOD"] = [[],[]];
   this.EvtParms["VALID_COBCBCOD"] = [[{av:'A169CobBanCod',fld:'COBBANCOD',pic:'ZZZZZ9'},{av:'A170CobCbCod',fld:'COBCBCOD',pic:''}],[]];
   this.EvtParms["VALID_COBCONBCOD"] = [[{av:'A168CobConBCod',fld:'COBCONBCOD',pic:'ZZZZZ9'}],[]];
   this.EvtParms["VALID_COBUSUFEC"] = [[{av:'A666CobUsuFec',fld:'COBUSUFEC',pic:'99/99/99 99:99'}],[{av:'A666CobUsuFec',fld:'COBUSUFEC',pic:'99/99/99 99:99'}]];
   this.EnterCtrl = ["BTN_ENTER"];
   this.CheckCtrl = ["BTN_CHECK"];
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(this.clcobranza);});
