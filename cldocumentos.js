gx.evt.autoSkip = false;
gx.define('cldocumentos', false, function () {
   this.ServerClass =  "cldocumentos" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.ServerFullClass =  "cldocumentos.aspx" ;
   this.setObjectType("trn");
   this.hasEnterEvent = true;
   this.skipOnEnter = false;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
      this.A1045ImpTieCod=gx.fn.getIntegerValue("IMPTIECOD",',') ;
   };
   this.Valid_Impitem=function()
   {
      return this.validSrvEvt("Valid_Impitem", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Impfec=function()
   {
      return this.validCliEvt("Valid_Impfec", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("IMPFEC");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A1034ImpFec)==0) || new gx.date.gxdate( this.A1034ImpFec ).compare( gx.date.ymdtod( 1753, 1, 1) ) >= 0 ) )
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
   this.Valid_Impfecvcto=function()
   {
      return this.validCliEvt("Valid_Impfecvcto", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("IMPFECVCTO");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A1037ImpFecVcto)==0) || new gx.date.gxdate( this.A1037ImpFecVcto ).compare( gx.date.ymdtod( 1753, 1, 1) ) >= 0 ) )
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
   this.Valid_Impclicod=function()
   {
      return this.validSrvEvt("Valid_Impclicod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Impmoncod=function()
   {
      return this.validSrvEvt("Valid_Impmoncod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Impconpcod=function()
   {
      return this.validSrvEvt("Valid_Impconpcod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Impfecref=function()
   {
      return this.validCliEvt("Valid_Impfecref", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("IMPFECREF");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A1036ImpFecRef)==0) || new gx.date.gxdate( this.A1036ImpFecRef ).compare( gx.date.ymdtod( 1753, 1, 1) ) >= 0 ) )
         {
            try {
               gxballoon.setError("Campo Fecha Referencia fuera de rango");
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
   this.Valid_Impmovcod=function()
   {
      return this.validSrvEvt("Valid_Impmovcod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Impvendcod=function()
   {
      return this.validSrvEvt("Valid_Impvendcod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Impfecaten=function()
   {
      return this.validCliEvt("Valid_Impfecaten", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("IMPFECATEN");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A1035ImpFecAten)===0) || new gx.date.gxdate( this.A1035ImpFecAten ).compare( gx.date.ymdhmstot( 1753, 1, 1, 0, 0, 0) ) >= 0 ) )
         {
            try {
               gxballoon.setError("Campo Fecha Atención fuera de rango");
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
   this.e112l89_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e122l89_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,5,6,7,8,9,15,18,20,21,24,26,29,31,34,36,39,41,44,46,49,51,54,56,59,61,64,66,69,71,74,76,79,81,84,86,89,91,94,96,99,101,104,106,109,111,114,116,119,121,124,126,129,131,134,136,139,141,144,146,149,151,154,156,159,161,164,166,169,170,171,172,173];
   this.GXLastCtrlId =173;
   GXValidFnc[2]={ id: 2, fld:"TABLE1",grid:0};
   GXValidFnc[5]={ id: 5, fld:"BTN_FIRST",grid:0,evt:"e132l89_client",std:"FIRST"};
   GXValidFnc[6]={ id: 6, fld:"BTN_PREVIOUS",grid:0,evt:"e142l89_client",std:"PREVIOUS"};
   GXValidFnc[7]={ id: 7, fld:"BTN_NEXT",grid:0,evt:"e152l89_client",std:"NEXT"};
   GXValidFnc[8]={ id: 8, fld:"BTN_LAST",grid:0,evt:"e162l89_client",std:"LAST"};
   GXValidFnc[9]={ id: 9, fld:"BTN_SELECT",grid:0,evt:"e172l89_client",std:"SELECT"};
   GXValidFnc[15]={ id: 15, fld:"TABLE2",grid:0};
   GXValidFnc[18]={ id: 18, fld:"TEXTBLOCK1", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[20]={ id:20 ,lvl:0,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Impitem,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPITEM",gxz:"Z191ImpItem",gxold:"O191ImpItem",gxvar:"A191ImpItem",ucs:[],op:[136,121,61,56,46,166,161,156,151,146,141,131,126,116,111,106,101,96,91,86,81,76,51,41,36,31,26],ip:[136,121,61,56,46,166,161,156,151,146,141,131,126,116,111,106,101,96,91,86,81,76,51,41,36,31,26,20],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A191ImpItem=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z191ImpItem=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("IMPITEM",gx.O.A191ImpItem,0)},c2v:function(){if(this.val()!==undefined)gx.O.A191ImpItem=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("IMPITEM",',')},nac:gx.falseFn};
   GXValidFnc[21]={ id: 21, fld:"BTN_GET",grid:0,evt:"e182l89_client",std:"GET"};
   GXValidFnc[24]={ id: 24, fld:"TEXTBLOCK2", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[26]={ id:26 ,lvl:0,type:"char",len:3,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPTIPCOD",gxz:"Z1046ImpTipCod",gxold:"O1046ImpTipCod",gxvar:"A1046ImpTipCod",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1046ImpTipCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z1046ImpTipCod=Value},v2c:function(){gx.fn.setControlValue("IMPTIPCOD",gx.O.A1046ImpTipCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1046ImpTipCod=this.val()},val:function(){return gx.fn.getControlValue("IMPTIPCOD")},nac:gx.falseFn};
   GXValidFnc[29]={ id: 29, fld:"TEXTBLOCK3", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[31]={ id:31 ,lvl:0,type:"char",len:12,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPDOCNUM",gxz:"Z1030ImpDocNum",gxold:"O1030ImpDocNum",gxvar:"A1030ImpDocNum",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1030ImpDocNum=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z1030ImpDocNum=Value},v2c:function(){gx.fn.setControlValue("IMPDOCNUM",gx.O.A1030ImpDocNum,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1030ImpDocNum=this.val()},val:function(){return gx.fn.getControlValue("IMPDOCNUM")},nac:gx.falseFn};
   GXValidFnc[34]={ id: 34, fld:"TEXTBLOCK4", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[36]={ id:36 ,lvl:0,type:"date",len:8,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Impfec,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPFEC",gxz:"Z1034ImpFec",gxold:"O1034ImpFec",gxvar:"A1034ImpFec",dp:{f:0,st:false,wn:false,mf:false,pic:"99/99/99",dec:0},ucs:[],op:[36],ip:[36],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1034ImpFec=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1034ImpFec=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("IMPFEC",gx.O.A1034ImpFec,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1034ImpFec=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getControlValue("IMPFEC")},nac:gx.falseFn};
   GXValidFnc[39]={ id: 39, fld:"TEXTBLOCK5", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[41]={ id:41 ,lvl:0,type:"date",len:8,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Impfecvcto,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPFECVCTO",gxz:"Z1037ImpFecVcto",gxold:"O1037ImpFecVcto",gxvar:"A1037ImpFecVcto",dp:{f:0,st:false,wn:false,mf:false,pic:"99/99/99",dec:0},ucs:[],op:[41],ip:[41],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1037ImpFecVcto=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1037ImpFecVcto=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("IMPFECVCTO",gx.O.A1037ImpFecVcto,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1037ImpFecVcto=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getControlValue("IMPFECVCTO")},nac:gx.falseFn};
   GXValidFnc[44]={ id: 44, fld:"TEXTBLOCK6", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[46]={ id:46 ,lvl:0,type:"char",len:20,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Impclicod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPCLICOD",gxz:"Z196ImpCliCod",gxold:"O196ImpCliCod",gxvar:"A196ImpCliCod",ucs:[],op:[],ip:[46],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A196ImpCliCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z196ImpCliCod=Value},v2c:function(){gx.fn.setControlValue("IMPCLICOD",gx.O.A196ImpCliCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A196ImpCliCod=this.val()},val:function(){return gx.fn.getControlValue("IMPCLICOD")},nac:gx.falseFn};
   GXValidFnc[49]={ id: 49, fld:"TEXTBLOCK7", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[51]={ id:51 ,lvl:0,type:"char",len:100,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPCLIDSC",gxz:"Z1021ImpCliDsc",gxold:"O1021ImpCliDsc",gxvar:"A1021ImpCliDsc",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1021ImpCliDsc=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z1021ImpCliDsc=Value},v2c:function(){gx.fn.setControlValue("IMPCLIDSC",gx.O.A1021ImpCliDsc,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1021ImpCliDsc=this.val()},val:function(){return gx.fn.getControlValue("IMPCLIDSC")},nac:gx.falseFn};
   GXValidFnc[54]={ id: 54, fld:"TEXTBLOCK8", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[56]={ id:56 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Impmoncod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPMONCOD",gxz:"Z195ImpMonCod",gxold:"O195ImpMonCod",gxvar:"A195ImpMonCod",ucs:[],op:[],ip:[56],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A195ImpMonCod=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z195ImpMonCod=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("IMPMONCOD",gx.O.A195ImpMonCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A195ImpMonCod=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("IMPMONCOD",',')},nac:gx.falseFn};
   GXValidFnc[59]={ id: 59, fld:"TEXTBLOCK9", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[61]={ id:61 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Impconpcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPCONPCOD",gxz:"Z194ImpConpCod",gxold:"O194ImpConpCod",gxvar:"A194ImpConpCod",ucs:[],op:[71,66],ip:[71,66,61],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A194ImpConpCod=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z194ImpConpCod=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("IMPCONPCOD",gx.O.A194ImpConpCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A194ImpConpCod=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("IMPCONPCOD",',')},nac:gx.falseFn};
   GXValidFnc[64]={ id: 64, fld:"TEXTBLOCK10", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[66]={ id:66 ,lvl:0,type:"char",len:100,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPCONPDSC",gxz:"Z1024ImpConpDsc",gxold:"O1024ImpConpDsc",gxvar:"A1024ImpConpDsc",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1024ImpConpDsc=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z1024ImpConpDsc=Value},v2c:function(){gx.fn.setControlValue("IMPCONPDSC",gx.O.A1024ImpConpDsc,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1024ImpConpDsc=this.val()},val:function(){return gx.fn.getControlValue("IMPCONPDSC")},nac:gx.falseFn};
   GXValidFnc[69]={ id: 69, fld:"TEXTBLOCK11", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[71]={ id:71 ,lvl:0,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPCONPDIAS",gxz:"Z1023ImpConpDias",gxold:"O1023ImpConpDias",gxvar:"A1023ImpConpDias",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1023ImpConpDias=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1023ImpConpDias=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("IMPCONPDIAS",gx.O.A1023ImpConpDias,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1023ImpConpDias=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("IMPCONPDIAS",',')},nac:gx.falseFn};
   GXValidFnc[74]={ id: 74, fld:"TEXTBLOCK12", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[76]={ id:76 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPTLIS",gxz:"Z1048ImpTLis",gxold:"O1048ImpTLis",gxvar:"A1048ImpTLis",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1048ImpTLis=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1048ImpTLis=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("IMPTLIS",gx.O.A1048ImpTLis,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1048ImpTLis=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("IMPTLIS",',')},nac:gx.falseFn};
   GXValidFnc[79]={ id: 79, fld:"TEXTBLOCK13", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[81]={ id:81 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPPORDSCTO",gxz:"Z1040ImpPorDscto",gxold:"O1040ImpPorDscto",gxvar:"A1040ImpPorDscto",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1040ImpPorDscto=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z1040ImpPorDscto=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("IMPPORDSCTO",gx.O.A1040ImpPorDscto,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A1040ImpPorDscto=this.val()},val:function(){return gx.fn.getDecimalValue("IMPPORDSCTO",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 81 , function() {
   });
   GXValidFnc[84]={ id: 84, fld:"TEXTBLOCK14", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[86]={ id:86 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPPORIVA",gxz:"Z1041ImpPorIVA",gxold:"O1041ImpPorIVA",gxvar:"A1041ImpPorIVA",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1041ImpPorIVA=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z1041ImpPorIVA=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("IMPPORIVA",gx.O.A1041ImpPorIVA,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A1041ImpPorIVA=this.val()},val:function(){return gx.fn.getDecimalValue("IMPPORIVA",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 86 , function() {
   });
   GXValidFnc[89]={ id: 89, fld:"TEXTBLOCK15", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[91]={ id:91 ,lvl:0,type:"vchar",len:500,dec:0,sign:false,ro:0,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPOBS",gxz:"Z1039ImpObs",gxold:"O1039ImpObs",gxvar:"A1039ImpObs",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1039ImpObs=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z1039ImpObs=Value},v2c:function(){gx.fn.setControlValue("IMPOBS",gx.O.A1039ImpObs,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1039ImpObs=this.val()},val:function(){return gx.fn.getControlValue("IMPOBS")},nac:gx.falseFn};
   GXValidFnc[94]={ id: 94, fld:"TEXTBLOCK16", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[96]={ id:96 ,lvl:0,type:"char",len:3,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPTREF",gxz:"Z1050ImpTRef",gxold:"O1050ImpTRef",gxvar:"A1050ImpTRef",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1050ImpTRef=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z1050ImpTRef=Value},v2c:function(){gx.fn.setControlValue("IMPTREF",gx.O.A1050ImpTRef,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1050ImpTRef=this.val()},val:function(){return gx.fn.getControlValue("IMPTREF")},nac:gx.falseFn};
   GXValidFnc[99]={ id: 99, fld:"TEXTBLOCK17", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[101]={ id:101 ,lvl:0,type:"char",len:10,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPREF",gxz:"Z1043ImpRef",gxold:"O1043ImpRef",gxvar:"A1043ImpRef",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1043ImpRef=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z1043ImpRef=Value},v2c:function(){gx.fn.setControlValue("IMPREF",gx.O.A1043ImpRef,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1043ImpRef=this.val()},val:function(){return gx.fn.getControlValue("IMPREF")},nac:gx.falseFn};
   GXValidFnc[104]={ id: 104, fld:"TEXTBLOCK18", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[106]={ id:106 ,lvl:0,type:"char",len:1,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPSTS",gxz:"Z1044ImpSts",gxold:"O1044ImpSts",gxvar:"A1044ImpSts",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1044ImpSts=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z1044ImpSts=Value},v2c:function(){gx.fn.setControlValue("IMPSTS",gx.O.A1044ImpSts,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1044ImpSts=this.val()},val:function(){return gx.fn.getControlValue("IMPSTS")},nac:gx.falseFn};
   GXValidFnc[109]={ id: 109, fld:"TEXTBLOCK19", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[111]={ id:111 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPTITEM",gxz:"Z1047ImpTItem",gxold:"O1047ImpTItem",gxvar:"A1047ImpTItem",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1047ImpTItem=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z1047ImpTItem=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("IMPTITEM",gx.O.A1047ImpTItem,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A1047ImpTItem=this.val()},val:function(){return gx.fn.getDecimalValue("IMPTITEM",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 111 , function() {
   });
   GXValidFnc[114]={ id: 114, fld:"TEXTBLOCK20", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[116]={ id:116 ,lvl:0,type:"date",len:8,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Impfecref,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPFECREF",gxz:"Z1036ImpFecRef",gxold:"O1036ImpFecRef",gxvar:"A1036ImpFecRef",dp:{f:0,st:false,wn:false,mf:false,pic:"99/99/99",dec:0},ucs:[],op:[116],ip:[116],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1036ImpFecRef=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1036ImpFecRef=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("IMPFECREF",gx.O.A1036ImpFecRef,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1036ImpFecRef=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getControlValue("IMPFECREF")},nac:gx.falseFn};
   GXValidFnc[119]={ id: 119, fld:"TEXTBLOCK21", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[121]={ id:121 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Impmovcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPMOVCOD",gxz:"Z193ImpMovCod",gxold:"O193ImpMovCod",gxvar:"A193ImpMovCod",ucs:[],op:[],ip:[121],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A193ImpMovCod=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z193ImpMovCod=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("IMPMOVCOD",gx.O.A193ImpMovCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A193ImpMovCod=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("IMPMOVCOD",',')},nac:gx.falseFn};
   GXValidFnc[124]={ id: 124, fld:"TEXTBLOCK22", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[126]={ id:126 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPALMCOD",gxz:"Z1016ImpAlmCod",gxold:"O1016ImpAlmCod",gxvar:"A1016ImpAlmCod",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1016ImpAlmCod=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1016ImpAlmCod=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("IMPALMCOD",gx.O.A1016ImpAlmCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1016ImpAlmCod=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("IMPALMCOD",',')},nac:gx.falseFn};
   GXValidFnc[129]={ id: 129, fld:"TEXTBLOCK23", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[131]={ id:131 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPCLIDIRCOD",gxz:"Z1020ImpCliDirCod",gxold:"O1020ImpCliDirCod",gxvar:"A1020ImpCliDirCod",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1020ImpCliDirCod=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1020ImpCliDirCod=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("IMPCLIDIRCOD",gx.O.A1020ImpCliDirCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1020ImpCliDirCod=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("IMPCLIDIRCOD",',')},nac:gx.falseFn};
   GXValidFnc[134]={ id: 134, fld:"TEXTBLOCK24", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[136]={ id:136 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Impvendcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPVENDCOD",gxz:"Z192ImpVendCod",gxold:"O192ImpVendCod",gxvar:"A192ImpVendCod",ucs:[],op:[],ip:[136],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A192ImpVendCod=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z192ImpVendCod=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("IMPVENDCOD",gx.O.A192ImpVendCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A192ImpVendCod=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("IMPVENDCOD",',')},nac:gx.falseFn};
   GXValidFnc[139]={ id: 139, fld:"TEXTBLOCK25", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[141]={ id:141 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPFORCOD",gxz:"Z1038ImpForCod",gxold:"O1038ImpForCod",gxvar:"A1038ImpForCod",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1038ImpForCod=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1038ImpForCod=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("IMPFORCOD",gx.O.A1038ImpForCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1038ImpForCod=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("IMPFORCOD",',')},nac:gx.falseFn};
   GXValidFnc[144]={ id: 144, fld:"TEXTBLOCK26", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[146]={ id:146 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPBANCOD",gxz:"Z1017ImpBanCod",gxold:"O1017ImpBanCod",gxvar:"A1017ImpBanCod",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1017ImpBanCod=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1017ImpBanCod=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("IMPBANCOD",gx.O.A1017ImpBanCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1017ImpBanCod=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("IMPBANCOD",',')},nac:gx.falseFn};
   GXValidFnc[149]={ id: 149, fld:"TEXTBLOCK27", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[151]={ id:151 ,lvl:0,type:"char",len:10,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPCOBCOD",gxz:"Z1022ImpCobCod",gxold:"O1022ImpCobCod",gxvar:"A1022ImpCobCod",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1022ImpCobCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z1022ImpCobCod=Value},v2c:function(){gx.fn.setControlValue("IMPCOBCOD",gx.O.A1022ImpCobCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1022ImpCobCod=this.val()},val:function(){return gx.fn.getControlValue("IMPCOBCOD")},nac:gx.falseFn};
   GXValidFnc[154]={ id: 154, fld:"TEXTBLOCK28", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[156]={ id:156 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPCLIDESPACHO",gxz:"Z1018ImpCliDespacho",gxold:"O1018ImpCliDespacho",gxvar:"A1018ImpCliDespacho",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1018ImpCliDespacho=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1018ImpCliDespacho=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("IMPCLIDESPACHO",gx.O.A1018ImpCliDespacho,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1018ImpCliDespacho=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("IMPCLIDESPACHO",',')},nac:gx.falseFn};
   GXValidFnc[159]={ id: 159, fld:"TEXTBLOCK29", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[161]={ id:161 ,lvl:0,type:"dtime",len:8,dec:5,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Impfecaten,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPFECATEN",gxz:"Z1035ImpFecAten",gxold:"O1035ImpFecAten",gxvar:"A1035ImpFecAten",dp:{f:0,st:true,wn:false,mf:false,pic:"99/99/99 99:99",dec:5},ucs:[],op:[161],ip:[161],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1035ImpFecAten=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1035ImpFecAten=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("IMPFECATEN",gx.O.A1035ImpFecAten,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1035ImpFecAten=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getDateTimeValue("IMPFECATEN")},nac:gx.falseFn};
   GXValidFnc[164]={ id: 164, fld:"TEXTBLOCK30", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[166]={ id:166 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPTPEDCOD",gxz:"Z1049ImpTPedCod",gxold:"O1049ImpTPedCod",gxvar:"A1049ImpTPedCod",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1049ImpTPedCod=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1049ImpTPedCod=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("IMPTPEDCOD",gx.O.A1049ImpTPedCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1049ImpTPedCod=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("IMPTPEDCOD",',')},nac:gx.falseFn};
   GXValidFnc[169]={ id: 169, fld:"BTN_ENTER",grid:0,evt:"e112l89_client",std:"ENTER"};
   GXValidFnc[170]={ id: 170, fld:"BTN_CHECK",grid:0,evt:"e192l89_client",std:"CHECK"};
   GXValidFnc[171]={ id: 171, fld:"BTN_CANCEL",grid:0,evt:"e122l89_client"};
   GXValidFnc[172]={ id: 172, fld:"BTN_DELETE",grid:0,evt:"e202l89_client",std:"DELETE"};
   GXValidFnc[173]={ id: 173, fld:"BTN_HELP",grid:0,evt:"e212l89_client"};
   this.A191ImpItem = 0 ;
   this.Z191ImpItem = 0 ;
   this.O191ImpItem = 0 ;
   this.A1046ImpTipCod = "" ;
   this.Z1046ImpTipCod = "" ;
   this.O1046ImpTipCod = "" ;
   this.A1030ImpDocNum = "" ;
   this.Z1030ImpDocNum = "" ;
   this.O1030ImpDocNum = "" ;
   this.A1034ImpFec = gx.date.nullDate() ;
   this.Z1034ImpFec = gx.date.nullDate() ;
   this.O1034ImpFec = gx.date.nullDate() ;
   this.A1037ImpFecVcto = gx.date.nullDate() ;
   this.Z1037ImpFecVcto = gx.date.nullDate() ;
   this.O1037ImpFecVcto = gx.date.nullDate() ;
   this.A196ImpCliCod = "" ;
   this.Z196ImpCliCod = "" ;
   this.O196ImpCliCod = "" ;
   this.A1021ImpCliDsc = "" ;
   this.Z1021ImpCliDsc = "" ;
   this.O1021ImpCliDsc = "" ;
   this.A195ImpMonCod = 0 ;
   this.Z195ImpMonCod = 0 ;
   this.O195ImpMonCod = 0 ;
   this.A194ImpConpCod = 0 ;
   this.Z194ImpConpCod = 0 ;
   this.O194ImpConpCod = 0 ;
   this.A1024ImpConpDsc = "" ;
   this.Z1024ImpConpDsc = "" ;
   this.O1024ImpConpDsc = "" ;
   this.A1023ImpConpDias = 0 ;
   this.Z1023ImpConpDias = 0 ;
   this.O1023ImpConpDias = 0 ;
   this.A1048ImpTLis = 0 ;
   this.Z1048ImpTLis = 0 ;
   this.O1048ImpTLis = 0 ;
   this.A1040ImpPorDscto = 0 ;
   this.Z1040ImpPorDscto = 0 ;
   this.O1040ImpPorDscto = 0 ;
   this.A1041ImpPorIVA = 0 ;
   this.Z1041ImpPorIVA = 0 ;
   this.O1041ImpPorIVA = 0 ;
   this.A1039ImpObs = "" ;
   this.Z1039ImpObs = "" ;
   this.O1039ImpObs = "" ;
   this.A1050ImpTRef = "" ;
   this.Z1050ImpTRef = "" ;
   this.O1050ImpTRef = "" ;
   this.A1043ImpRef = "" ;
   this.Z1043ImpRef = "" ;
   this.O1043ImpRef = "" ;
   this.A1044ImpSts = "" ;
   this.Z1044ImpSts = "" ;
   this.O1044ImpSts = "" ;
   this.A1047ImpTItem = 0 ;
   this.Z1047ImpTItem = 0 ;
   this.O1047ImpTItem = 0 ;
   this.A1036ImpFecRef = gx.date.nullDate() ;
   this.Z1036ImpFecRef = gx.date.nullDate() ;
   this.O1036ImpFecRef = gx.date.nullDate() ;
   this.A193ImpMovCod = 0 ;
   this.Z193ImpMovCod = 0 ;
   this.O193ImpMovCod = 0 ;
   this.A1016ImpAlmCod = 0 ;
   this.Z1016ImpAlmCod = 0 ;
   this.O1016ImpAlmCod = 0 ;
   this.A1020ImpCliDirCod = 0 ;
   this.Z1020ImpCliDirCod = 0 ;
   this.O1020ImpCliDirCod = 0 ;
   this.A192ImpVendCod = 0 ;
   this.Z192ImpVendCod = 0 ;
   this.O192ImpVendCod = 0 ;
   this.A1038ImpForCod = 0 ;
   this.Z1038ImpForCod = 0 ;
   this.O1038ImpForCod = 0 ;
   this.A1017ImpBanCod = 0 ;
   this.Z1017ImpBanCod = 0 ;
   this.O1017ImpBanCod = 0 ;
   this.A1022ImpCobCod = "" ;
   this.Z1022ImpCobCod = "" ;
   this.O1022ImpCobCod = "" ;
   this.A1018ImpCliDespacho = 0 ;
   this.Z1018ImpCliDespacho = 0 ;
   this.O1018ImpCliDespacho = 0 ;
   this.A1035ImpFecAten = gx.date.nullDate() ;
   this.Z1035ImpFecAten = gx.date.nullDate() ;
   this.O1035ImpFecAten = gx.date.nullDate() ;
   this.A1049ImpTPedCod = 0 ;
   this.Z1049ImpTPedCod = 0 ;
   this.O1049ImpTPedCod = 0 ;
   this.A191ImpItem = 0 ;
   this.A1046ImpTipCod = "" ;
   this.A1030ImpDocNum = "" ;
   this.A1034ImpFec = gx.date.nullDate() ;
   this.A1037ImpFecVcto = gx.date.nullDate() ;
   this.A196ImpCliCod = "" ;
   this.A1021ImpCliDsc = "" ;
   this.A195ImpMonCod = 0 ;
   this.A194ImpConpCod = 0 ;
   this.A1024ImpConpDsc = "" ;
   this.A1023ImpConpDias = 0 ;
   this.A1048ImpTLis = 0 ;
   this.A1040ImpPorDscto = 0 ;
   this.A1041ImpPorIVA = 0 ;
   this.A1039ImpObs = "" ;
   this.A1050ImpTRef = "" ;
   this.A1043ImpRef = "" ;
   this.A1044ImpSts = "" ;
   this.A1047ImpTItem = 0 ;
   this.A1036ImpFecRef = gx.date.nullDate() ;
   this.A193ImpMovCod = 0 ;
   this.A1016ImpAlmCod = 0 ;
   this.A1020ImpCliDirCod = 0 ;
   this.A192ImpVendCod = 0 ;
   this.A1038ImpForCod = 0 ;
   this.A1017ImpBanCod = 0 ;
   this.A1022ImpCobCod = "" ;
   this.A1018ImpCliDespacho = 0 ;
   this.A1035ImpFecAten = gx.date.nullDate() ;
   this.A1049ImpTPedCod = 0 ;
   this.A1045ImpTieCod = 0 ;
   this.Events = {"e112l89_client": ["ENTER", true] ,"e122l89_client": ["CANCEL", true]};
   this.EvtParms["ENTER"] = [[{postForm:true}],[]];
   this.EvtParms["REFRESH"] = [[{av:'A1045ImpTieCod',fld:'IMPTIECOD',pic:'ZZZZZ9'}],[]];
   this.EvtParms["VALID_IMPITEM"] = [[{av:'A1045ImpTieCod',fld:'IMPTIECOD',pic:'ZZZZZ9'},{av:'A191ImpItem',fld:'IMPITEM',pic:'ZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}],[{av:'A1046ImpTipCod',fld:'IMPTIPCOD',pic:''},{av:'A1030ImpDocNum',fld:'IMPDOCNUM',pic:''},{av:'A1034ImpFec',fld:'IMPFEC',pic:''},{av:'A1037ImpFecVcto',fld:'IMPFECVCTO',pic:''},{av:'A196ImpCliCod',fld:'IMPCLICOD',pic:''},{av:'A1021ImpCliDsc',fld:'IMPCLIDSC',pic:''},{av:'A195ImpMonCod',fld:'IMPMONCOD',pic:'ZZZZZ9'},{av:'A194ImpConpCod',fld:'IMPCONPCOD',pic:'ZZZZZ9'},{av:'A1048ImpTLis',fld:'IMPTLIS',pic:'ZZZZZ9'},{av:'A1040ImpPorDscto',fld:'IMPPORDSCTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1041ImpPorIVA',fld:'IMPPORIVA',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1039ImpObs',fld:'IMPOBS',pic:''},{av:'A1050ImpTRef',fld:'IMPTREF',pic:''},{av:'A1043ImpRef',fld:'IMPREF',pic:''},{av:'A1044ImpSts',fld:'IMPSTS',pic:''},{av:'A1047ImpTItem',fld:'IMPTITEM',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1036ImpFecRef',fld:'IMPFECREF',pic:''},{av:'A193ImpMovCod',fld:'IMPMOVCOD',pic:'ZZZZZ9'},{av:'A1016ImpAlmCod',fld:'IMPALMCOD',pic:'ZZZZZ9'},{av:'A1020ImpCliDirCod',fld:'IMPCLIDIRCOD',pic:'ZZZZZ9'},{av:'A192ImpVendCod',fld:'IMPVENDCOD',pic:'ZZZZZ9'},{av:'A1038ImpForCod',fld:'IMPFORCOD',pic:'ZZZZZ9'},{av:'A1017ImpBanCod',fld:'IMPBANCOD',pic:'ZZZZZ9'},{av:'A1022ImpCobCod',fld:'IMPCOBCOD',pic:''},{av:'A1018ImpCliDespacho',fld:'IMPCLIDESPACHO',pic:'ZZZZZ9'},{av:'A1035ImpFecAten',fld:'IMPFECATEN',pic:'99/99/99 99:99'},{av:'A1049ImpTPedCod',fld:'IMPTPEDCOD',pic:'ZZZZZ9'},{av:'A1045ImpTieCod',fld:'IMPTIECOD',pic:'ZZZZZ9'},{av:'A1024ImpConpDsc',fld:'IMPCONPDSC',pic:''},{av:'A1023ImpConpDias',fld:'IMPCONPDIAS',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z191ImpItem'},{av:'Z1046ImpTipCod'},{av:'Z1030ImpDocNum'},{av:'Z1034ImpFec'},{av:'Z1037ImpFecVcto'},{av:'Z196ImpCliCod'},{av:'Z1021ImpCliDsc'},{av:'Z195ImpMonCod'},{av:'Z194ImpConpCod'},{av:'Z1048ImpTLis'},{av:'Z1040ImpPorDscto'},{av:'Z1041ImpPorIVA'},{av:'Z1039ImpObs'},{av:'Z1050ImpTRef'},{av:'Z1043ImpRef'},{av:'Z1044ImpSts'},{av:'Z1047ImpTItem'},{av:'Z1036ImpFecRef'},{av:'Z193ImpMovCod'},{av:'Z1016ImpAlmCod'},{av:'Z1020ImpCliDirCod'},{av:'Z192ImpVendCod'},{av:'Z1038ImpForCod'},{av:'Z1017ImpBanCod'},{av:'Z1022ImpCobCod'},{av:'Z1018ImpCliDespacho'},{av:'Z1035ImpFecAten'},{av:'Z1049ImpTPedCod'},{av:'Z1045ImpTieCod'},{av:'Z1024ImpConpDsc'},{av:'Z1023ImpConpDias'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]];
   this.EvtParms["VALID_IMPFEC"] = [[{av:'A1034ImpFec',fld:'IMPFEC',pic:''}],[{av:'A1034ImpFec',fld:'IMPFEC',pic:''}]];
   this.EvtParms["VALID_IMPFECVCTO"] = [[{av:'A1037ImpFecVcto',fld:'IMPFECVCTO',pic:''}],[{av:'A1037ImpFecVcto',fld:'IMPFECVCTO',pic:''}]];
   this.EvtParms["VALID_IMPCLICOD"] = [[{av:'A196ImpCliCod',fld:'IMPCLICOD',pic:''}],[]];
   this.EvtParms["VALID_IMPMONCOD"] = [[{av:'A195ImpMonCod',fld:'IMPMONCOD',pic:'ZZZZZ9'}],[]];
   this.EvtParms["VALID_IMPCONPCOD"] = [[{av:'A194ImpConpCod',fld:'IMPCONPCOD',pic:'ZZZZZ9'},{av:'A1024ImpConpDsc',fld:'IMPCONPDSC',pic:''},{av:'A1023ImpConpDias',fld:'IMPCONPDIAS',pic:'ZZZ9'}],[{av:'A1024ImpConpDsc',fld:'IMPCONPDSC',pic:''},{av:'A1023ImpConpDias',fld:'IMPCONPDIAS',pic:'ZZZ9'}]];
   this.EvtParms["VALID_IMPFECREF"] = [[{av:'A1036ImpFecRef',fld:'IMPFECREF',pic:''}],[{av:'A1036ImpFecRef',fld:'IMPFECREF',pic:''}]];
   this.EvtParms["VALID_IMPMOVCOD"] = [[{av:'A193ImpMovCod',fld:'IMPMOVCOD',pic:'ZZZZZ9'}],[]];
   this.EvtParms["VALID_IMPVENDCOD"] = [[{av:'A192ImpVendCod',fld:'IMPVENDCOD',pic:'ZZZZZ9'}],[]];
   this.EvtParms["VALID_IMPFECATEN"] = [[{av:'A1035ImpFecAten',fld:'IMPFECATEN',pic:'99/99/99 99:99'}],[{av:'A1035ImpFecAten',fld:'IMPFECATEN',pic:'99/99/99 99:99'}]];
   this.EnterCtrl = ["BTN_ENTER"];
   this.CheckCtrl = ["BTN_CHECK"];
   this.setVCMap("A1045ImpTieCod", "IMPTIECOD", 0, "int", 6, 0);
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(this.cldocumentos);});
