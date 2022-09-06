gx.evt.autoSkip = false;
gx.define('clcuentacobrar', false, function () {
   this.ServerClass =  "clcuentacobrar" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.ServerFullClass =  "clcuentacobrar.aspx" ;
   this.setObjectType("trn");
   this.hasEnterEvent = true;
   this.skipOnEnter = false;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
      this.A511TipSigno=gx.fn.getIntegerValue("TIPSIGNO",',') ;
      this.A515CCImpTotalSig=gx.fn.getDecimalValue("CCIMPTOTALSIG",',','.') ;
      this.A510CCImpPagoSig=gx.fn.getDecimalValue("CCIMPPAGOSIG",',','.') ;
      this.A507CCFecUltPago=gx.fn.getDateValue("CCFECULTPAGO") ;
   };
   this.Valid_Cctipcod=function()
   {
      return this.validSrvEvt("Valid_Cctipcod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Ccdocnum=function()
   {
      return this.validSrvEvt("Valid_Ccdocnum", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Ccclicod=function()
   {
      return this.validSrvEvt("Valid_Ccclicod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Ccfech=function()
   {
      return this.validCliEvt("Valid_Ccfech", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("CCFECH");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A190CCFech)==0) || new gx.date.gxdate( this.A190CCFech ).compare( gx.date.ymdtod( 1753, 1, 1) ) >= 0 ) )
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
   this.Valid_Ccfvcto=function()
   {
      return this.validCliEvt("Valid_Ccfvcto", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("CCFVCTO");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A508CCFVcto)==0) || new gx.date.gxdate( this.A508CCFVcto ).compare( gx.date.ymdtod( 1753, 1, 1) ) >= 0 ) )
         {
            try {
               gxballoon.setError("Campo Fecha Vcto fuera de rango");
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
   this.Valid_Ccmoncod=function()
   {
      return this.validSrvEvt("Valid_Ccmoncod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Ccimptotal=function()
   {
      return this.validCliEvt("Valid_Ccimptotal", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("CCIMPTOTAL");
         this.AnyError  = 0;
         try {
            this.A515CCImpTotalSig =  this.A513CCImpTotal * this.A511TipSigno  ;
         }
         catch(e){}

      }
      catch(e){}
      try {
          if (gxballoon == null) return true; return gxballoon.show();
      }
      catch(e){}
      return true ;
      });
   }
   this.Valid_Ccimppago=function()
   {
      return this.validCliEvt("Valid_Ccimppago", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("CCIMPPAGO");
         this.AnyError  = 0;
         try {
            this.A512CCImpSaldo =  this.A513CCImpTotal - this.A509CCImpPago  ;
         }
         catch(e){}
         try {
            this.A514CCImpSaldoSig =  this.A512CCImpSaldo * this.A511TipSigno  ;
         }
         catch(e){}
         try {
            this.A510CCImpPagoSig =  this.A509CCImpPago * this.A511TipSigno  ;
         }
         catch(e){}

      }
      catch(e){}
      try {
          if (gxballoon == null) return true; return gxballoon.show();
      }
      catch(e){}
      return true ;
      });
   }
   this.Valid_Ccvendcod=function()
   {
      return this.validSrvEvt("Valid_Ccvendcod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Ccimpsaldo=function()
   {
      return this.validCliEvt("Valid_Ccimpsaldo", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("CCIMPSALDO");
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
   this.e112k88_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e122k88_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,5,6,7,8,9,15,18,20,23,25,26,29,31,34,36,39,41,44,46,49,51,54,56,59,61,64,66,69,71,74,76,79,81,84,85,86,87,88];
   this.GXLastCtrlId =88;
   GXValidFnc[2]={ id: 2, fld:"TABLE1",grid:0};
   GXValidFnc[5]={ id: 5, fld:"BTN_FIRST",grid:0,evt:"e132k88_client",std:"FIRST"};
   GXValidFnc[6]={ id: 6, fld:"BTN_PREVIOUS",grid:0,evt:"e142k88_client",std:"PREVIOUS"};
   GXValidFnc[7]={ id: 7, fld:"BTN_NEXT",grid:0,evt:"e152k88_client",std:"NEXT"};
   GXValidFnc[8]={ id: 8, fld:"BTN_LAST",grid:0,evt:"e162k88_client",std:"LAST"};
   GXValidFnc[9]={ id: 9, fld:"BTN_SELECT",grid:0,evt:"e172k88_client",std:"SELECT"};
   GXValidFnc[15]={ id: 15, fld:"TABLE2",grid:0};
   GXValidFnc[18]={ id: 18, fld:"TEXTBLOCK1", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[20]={ id:20 ,lvl:0,type:"char",len:3,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cctipcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CCTIPCOD",gxz:"Z184CCTipCod",gxold:"O184CCTipCod",gxvar:"A184CCTipCod",ucs:[],op:[],ip:[20],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A184CCTipCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z184CCTipCod=Value},v2c:function(){gx.fn.setControlValue("CCTIPCOD",gx.O.A184CCTipCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A184CCTipCod=this.val()},val:function(){return gx.fn.getControlValue("CCTIPCOD")},nac:gx.falseFn};
   GXValidFnc[23]={ id: 23, fld:"TEXTBLOCK2", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[25]={ id:25 ,lvl:0,type:"char",len:12,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Ccdocnum,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CCDOCNUM",gxz:"Z185CCDocNum",gxold:"O185CCDocNum",gxvar:"A185CCDocNum",ucs:[],op:[71,46,31,66,61,56,51,41,36],ip:[71,46,31,66,61,56,51,41,36,25,20],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A185CCDocNum=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z185CCDocNum=Value},v2c:function(){gx.fn.setControlValue("CCDOCNUM",gx.O.A185CCDocNum,0)},c2v:function(){if(this.val()!==undefined)gx.O.A185CCDocNum=this.val()},val:function(){return gx.fn.getControlValue("CCDOCNUM")},nac:gx.falseFn};
   GXValidFnc[26]={ id: 26, fld:"BTN_GET",grid:0,evt:"e182k88_client",std:"GET"};
   GXValidFnc[29]={ id: 29, fld:"TEXTBLOCK3", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[31]={ id:31 ,lvl:0,type:"char",len:20,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Ccclicod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CCCLICOD",gxz:"Z188CCCliCod",gxold:"O188CCCliCod",gxvar:"A188CCCliCod",ucs:[],op:[],ip:[31],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A188CCCliCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z188CCCliCod=Value},v2c:function(){gx.fn.setControlValue("CCCLICOD",gx.O.A188CCCliCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A188CCCliCod=this.val()},val:function(){return gx.fn.getControlValue("CCCLICOD")},nac:gx.falseFn};
   GXValidFnc[34]={ id: 34, fld:"TEXTBLOCK4", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[36]={ id:36 ,lvl:0,type:"date",len:8,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Ccfech,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CCFECH",gxz:"Z190CCFech",gxold:"O190CCFech",gxvar:"A190CCFech",dp:{f:0,st:false,wn:false,mf:false,pic:"99/99/99",dec:0},ucs:[],op:[36],ip:[36],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A190CCFech=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z190CCFech=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("CCFECH",gx.O.A190CCFech,0)},c2v:function(){if(this.val()!==undefined)gx.O.A190CCFech=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getControlValue("CCFECH")},nac:gx.falseFn};
   GXValidFnc[39]={ id: 39, fld:"TEXTBLOCK5", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[41]={ id:41 ,lvl:0,type:"date",len:8,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Ccfvcto,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CCFVCTO",gxz:"Z508CCFVcto",gxold:"O508CCFVcto",gxvar:"A508CCFVcto",dp:{f:0,st:false,wn:false,mf:false,pic:"99/99/99",dec:0},ucs:[],op:[41],ip:[41],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A508CCFVcto=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z508CCFVcto=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("CCFVCTO",gx.O.A508CCFVcto,0)},c2v:function(){if(this.val()!==undefined)gx.O.A508CCFVcto=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getControlValue("CCFVCTO")},nac:gx.falseFn};
   GXValidFnc[44]={ id: 44, fld:"TEXTBLOCK6", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[46]={ id:46 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Ccmoncod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CCMONCOD",gxz:"Z187CCmonCod",gxold:"O187CCmonCod",gxvar:"A187CCmonCod",ucs:[],op:[],ip:[46],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A187CCmonCod=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z187CCmonCod=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("CCMONCOD",gx.O.A187CCmonCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A187CCmonCod=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("CCMONCOD",',')},nac:gx.falseFn};
   GXValidFnc[49]={ id: 49, fld:"TEXTBLOCK7", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[51]={ id:51 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Ccimptotal,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CCIMPTOTAL",gxz:"Z513CCImpTotal",gxold:"O513CCImpTotal",gxvar:"A513CCImpTotal",ucs:[],op:[],ip:[51],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A513CCImpTotal=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z513CCImpTotal=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("CCIMPTOTAL",gx.O.A513CCImpTotal,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A513CCImpTotal=this.val()},val:function(){return gx.fn.getDecimalValue("CCIMPTOTAL",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 51 , function() {
   });
   GXValidFnc[54]={ id: 54, fld:"TEXTBLOCK8", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[56]={ id:56 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Ccimppago,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CCIMPPAGO",gxz:"Z509CCImpPago",gxold:"O509CCImpPago",gxvar:"A509CCImpPago",ucs:[],op:[81,76],ip:[81,76,56,51],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A509CCImpPago=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z509CCImpPago=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("CCIMPPAGO",gx.O.A509CCImpPago,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A509CCImpPago=this.val()},val:function(){return gx.fn.getDecimalValue("CCIMPPAGO",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 56 , function() {
   });
   GXValidFnc[59]={ id: 59, fld:"TEXTBLOCK9", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[61]={ id:61 ,lvl:0,type:"char",len:1,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CCESTADO",gxz:"Z506CCEstado",gxold:"O506CCEstado",gxvar:"A506CCEstado",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A506CCEstado=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z506CCEstado=Value},v2c:function(){gx.fn.setControlValue("CCESTADO",gx.O.A506CCEstado,0)},c2v:function(){if(this.val()!==undefined)gx.O.A506CCEstado=this.val()},val:function(){return gx.fn.getControlValue("CCESTADO")},nac:gx.falseFn};
   GXValidFnc[64]={ id: 64, fld:"TEXTBLOCK10", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[66]={ id:66 ,lvl:0,type:"char",len:100,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CCCLIDSC",gxz:"Z189CCCliDsc",gxold:"O189CCCliDsc",gxvar:"A189CCCliDsc",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A189CCCliDsc=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z189CCCliDsc=Value},v2c:function(){gx.fn.setControlValue("CCCLIDSC",gx.O.A189CCCliDsc,0)},c2v:function(){if(this.val()!==undefined)gx.O.A189CCCliDsc=this.val()},val:function(){return gx.fn.getControlValue("CCCLIDSC")},nac:gx.falseFn};
   GXValidFnc[69]={ id: 69, fld:"TEXTBLOCK11", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[71]={ id:71 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Ccvendcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CCVENDCOD",gxz:"Z186CCVendCod",gxold:"O186CCVendCod",gxvar:"A186CCVendCod",ucs:[],op:[],ip:[71],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A186CCVendCod=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z186CCVendCod=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("CCVENDCOD",gx.O.A186CCVendCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A186CCVendCod=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("CCVENDCOD",',')},nac:gx.falseFn};
   GXValidFnc[74]={ id: 74, fld:"TEXTBLOCK12", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[76]={ id:76 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Ccimpsaldo,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CCIMPSALDO",gxz:"Z512CCImpSaldo",gxold:"O512CCImpSaldo",gxvar:"A512CCImpSaldo",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A512CCImpSaldo=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z512CCImpSaldo=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("CCIMPSALDO",gx.O.A512CCImpSaldo,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A512CCImpSaldo=this.val()},val:function(){return gx.fn.getDecimalValue("CCIMPSALDO",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 76 , function() {
   });
   GXValidFnc[79]={ id: 79, fld:"TEXTBLOCK13", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[81]={ id:81 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CCIMPSALDOSIG",gxz:"Z514CCImpSaldoSig",gxold:"O514CCImpSaldoSig",gxvar:"A514CCImpSaldoSig",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A514CCImpSaldoSig=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z514CCImpSaldoSig=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("CCIMPSALDOSIG",gx.O.A514CCImpSaldoSig,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A514CCImpSaldoSig=this.val()},val:function(){return gx.fn.getDecimalValue("CCIMPSALDOSIG",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 81 , function() {
   });
   GXValidFnc[84]={ id: 84, fld:"BTN_ENTER",grid:0,evt:"e112k88_client",std:"ENTER"};
   GXValidFnc[85]={ id: 85, fld:"BTN_CHECK",grid:0,evt:"e192k88_client",std:"CHECK"};
   GXValidFnc[86]={ id: 86, fld:"BTN_CANCEL",grid:0,evt:"e122k88_client"};
   GXValidFnc[87]={ id: 87, fld:"BTN_DELETE",grid:0,evt:"e202k88_client",std:"DELETE"};
   GXValidFnc[88]={ id: 88, fld:"BTN_HELP",grid:0,evt:"e212k88_client"};
   this.A184CCTipCod = "" ;
   this.Z184CCTipCod = "" ;
   this.O184CCTipCod = "" ;
   this.A185CCDocNum = "" ;
   this.Z185CCDocNum = "" ;
   this.O185CCDocNum = "" ;
   this.A188CCCliCod = "" ;
   this.Z188CCCliCod = "" ;
   this.O188CCCliCod = "" ;
   this.A190CCFech = gx.date.nullDate() ;
   this.Z190CCFech = gx.date.nullDate() ;
   this.O190CCFech = gx.date.nullDate() ;
   this.A508CCFVcto = gx.date.nullDate() ;
   this.Z508CCFVcto = gx.date.nullDate() ;
   this.O508CCFVcto = gx.date.nullDate() ;
   this.A187CCmonCod = 0 ;
   this.Z187CCmonCod = 0 ;
   this.O187CCmonCod = 0 ;
   this.A513CCImpTotal = 0 ;
   this.Z513CCImpTotal = 0 ;
   this.O513CCImpTotal = 0 ;
   this.A509CCImpPago = 0 ;
   this.Z509CCImpPago = 0 ;
   this.O509CCImpPago = 0 ;
   this.A506CCEstado = "" ;
   this.Z506CCEstado = "" ;
   this.O506CCEstado = "" ;
   this.A189CCCliDsc = "" ;
   this.Z189CCCliDsc = "" ;
   this.O189CCCliDsc = "" ;
   this.A186CCVendCod = 0 ;
   this.Z186CCVendCod = 0 ;
   this.O186CCVendCod = 0 ;
   this.A512CCImpSaldo = 0 ;
   this.Z512CCImpSaldo = 0 ;
   this.O512CCImpSaldo = 0 ;
   this.A514CCImpSaldoSig = 0 ;
   this.Z514CCImpSaldoSig = 0 ;
   this.O514CCImpSaldoSig = 0 ;
   this.A184CCTipCod = "" ;
   this.A185CCDocNum = "" ;
   this.A514CCImpSaldoSig = 0 ;
   this.A510CCImpPagoSig = 0 ;
   this.A512CCImpSaldo = 0 ;
   this.A515CCImpTotalSig = 0 ;
   this.A188CCCliCod = "" ;
   this.A190CCFech = gx.date.nullDate() ;
   this.A508CCFVcto = gx.date.nullDate() ;
   this.A187CCmonCod = 0 ;
   this.A513CCImpTotal = 0 ;
   this.A509CCImpPago = 0 ;
   this.A506CCEstado = "" ;
   this.A189CCCliDsc = "" ;
   this.A186CCVendCod = 0 ;
   this.A507CCFecUltPago = gx.date.nullDate() ;
   this.A511TipSigno = 0 ;
   this.Events = {"e112k88_client": ["ENTER", true] ,"e122k88_client": ["CANCEL", true]};
   this.EvtParms["ENTER"] = [[{postForm:true}],[]];
   this.EvtParms["REFRESH"] = [[{av:'A507CCFecUltPago',fld:'CCFECULTPAGO',pic:''}],[]];
   this.EvtParms["VALID_CCTIPCOD"] = [[{av:'A184CCTipCod',fld:'CCTIPCOD',pic:''},{av:'A511TipSigno',fld:'TIPSIGNO',pic:'Z9'}],[{av:'A511TipSigno',fld:'TIPSIGNO',pic:'Z9'}]];
   this.EvtParms["VALID_CCDOCNUM"] = [[{av:'A507CCFecUltPago',fld:'CCFECULTPAGO',pic:''},{av:'A184CCTipCod',fld:'CCTIPCOD',pic:''},{av:'A185CCDocNum',fld:'CCDOCNUM',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}],[{av:'A188CCCliCod',fld:'CCCLICOD',pic:''},{av:'A190CCFech',fld:'CCFECH',pic:''},{av:'A508CCFVcto',fld:'CCFVCTO',pic:''},{av:'A187CCmonCod',fld:'CCMONCOD',pic:'ZZZZZ9'},{av:'A513CCImpTotal',fld:'CCIMPTOTAL',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A509CCImpPago',fld:'CCIMPPAGO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A506CCEstado',fld:'CCESTADO',pic:''},{av:'A189CCCliDsc',fld:'CCCLIDSC',pic:''},{av:'A186CCVendCod',fld:'CCVENDCOD',pic:'ZZZZZ9'},{av:'A507CCFecUltPago',fld:'CCFECULTPAGO',pic:''},{av:'A511TipSigno',fld:'TIPSIGNO',pic:'Z9'},{av:'A515CCImpTotalSig',fld:'CCIMPTOTALSIG',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A510CCImpPagoSig',fld:'CCIMPPAGOSIG',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A512CCImpSaldo',fld:'CCIMPSALDO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A514CCImpSaldoSig',fld:'CCIMPSALDOSIG',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z184CCTipCod'},{av:'Z185CCDocNum'},{av:'Z188CCCliCod'},{av:'Z190CCFech'},{av:'Z508CCFVcto'},{av:'Z187CCmonCod'},{av:'Z513CCImpTotal'},{av:'Z509CCImpPago'},{av:'Z506CCEstado'},{av:'Z189CCCliDsc'},{av:'Z186CCVendCod'},{av:'Z507CCFecUltPago'},{av:'Z511TipSigno'},{av:'Z515CCImpTotalSig'},{av:'Z510CCImpPagoSig'},{av:'Z512CCImpSaldo'},{av:'Z514CCImpSaldoSig'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]];
   this.EvtParms["VALID_CCCLICOD"] = [[{av:'A188CCCliCod',fld:'CCCLICOD',pic:''}],[]];
   this.EvtParms["VALID_CCFECH"] = [[{av:'A190CCFech',fld:'CCFECH',pic:''}],[{av:'A190CCFech',fld:'CCFECH',pic:''}]];
   this.EvtParms["VALID_CCFVCTO"] = [[{av:'A508CCFVcto',fld:'CCFVCTO',pic:''}],[{av:'A508CCFVcto',fld:'CCFVCTO',pic:''}]];
   this.EvtParms["VALID_CCMONCOD"] = [[{av:'A187CCmonCod',fld:'CCMONCOD',pic:'ZZZZZ9'}],[]];
   this.EvtParms["VALID_CCIMPTOTAL"] = [[{av:'A513CCImpTotal',fld:'CCIMPTOTAL',pic:'ZZZZZZ,ZZZ,ZZ9.99'}],[]];
   this.EvtParms["VALID_CCIMPPAGO"] = [[{av:'A514CCImpSaldoSig',fld:'CCIMPSALDOSIG',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A512CCImpSaldo',fld:'CCIMPSALDO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A509CCImpPago',fld:'CCIMPPAGO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A513CCImpTotal',fld:'CCIMPTOTAL',pic:'ZZZZZZ,ZZZ,ZZ9.99'}],[{av:'A514CCImpSaldoSig',fld:'CCIMPSALDOSIG',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A512CCImpSaldo',fld:'CCIMPSALDO',pic:'ZZZZZZ,ZZZ,ZZ9.99'}]];
   this.EvtParms["VALID_CCVENDCOD"] = [[{av:'A186CCVendCod',fld:'CCVENDCOD',pic:'ZZZZZ9'}],[]];
   this.EvtParms["VALID_CCIMPSALDO"] = [[],[]];
   this.EnterCtrl = ["BTN_ENTER"];
   this.CheckCtrl = ["BTN_CHECK"];
   this.setVCMap("A511TipSigno", "TIPSIGNO", 0, "int", 2, 0);
   this.setVCMap("A515CCImpTotalSig", "CCIMPTOTALSIG", 0, "decimal", 15, 2);
   this.setVCMap("A510CCImpPagoSig", "CCIMPPAGOSIG", 0, "decimal", 15, 2);
   this.setVCMap("A507CCFecUltPago", "CCFECULTPAGO", 0, "date", 8, 0);
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(this.clcuentacobrar);});
