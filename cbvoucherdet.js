gx.evt.autoSkip = false;
gx.define('cbvoucherdet', false, function () {
   this.ServerClass =  "cbvoucherdet" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.ServerFullClass =  "cbvoucherdet.aspx" ;
   this.setObjectType("trn");
   this.hasEnterEvent = true;
   this.skipOnEnter = false;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
      this.A2059VouDRef1=gx.fn.getControlValue("VOUDREF1") ;
      this.A2061VouDRef2=gx.fn.getControlValue("VOUDREF2") ;
      this.A2062VouDRef3=gx.fn.getControlValue("VOUDREF3") ;
      this.A2063VouDRef4=gx.fn.getControlValue("VOUDREF4") ;
      this.A2064VouDRef5=gx.fn.getControlValue("VOUDREF5") ;
      this.A2065VouDRef6=gx.fn.getControlValue("VOUDREF6") ;
      this.A2066VouDRef7=gx.fn.getControlValue("VOUDREF7") ;
      this.A2067VouDRef8=gx.fn.getControlValue("VOUDREF8") ;
      this.A2068VouDRef9=gx.fn.getControlValue("VOUDREF9") ;
      this.A2060VouDRef10=gx.fn.getControlValue("VOUDREF10") ;
   };
   this.Valid_Vouano=function()
   {
      return this.validCliEvt("Valid_Vouano", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("VOUANO");
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
   this.Valid_Voumes=function()
   {
      return this.validCliEvt("Valid_Voumes", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("VOUMES");
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
   this.Valid_Tasicod=function()
   {
      return this.validCliEvt("Valid_Tasicod", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("TASICOD");
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
   this.Valid_Vounum=function()
   {
      return this.validSrvEvt("Valid_Vounum", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Voudsec=function()
   {
      return this.validSrvEvt("Valid_Voudsec", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Cuecod=function()
   {
      return this.validSrvEvt("Valid_Cuecod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Coscod=function()
   {
      return this.validSrvEvt("Valid_Coscod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Voudfec=function()
   {
      return this.validCliEvt("Valid_Voudfec", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("VOUDFEC");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A135VouDFec)==0) || new gx.date.gxdate( this.A135VouDFec ).compare( gx.date.ymdtod( 1753, 1, 1) ) >= 0 ) )
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
   this.Valid_Voudtipcod=function()
   {
      return this.validSrvEvt("Valid_Voudtipcod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Voudmon=function()
   {
      return this.validSrvEvt("Valid_Voudmon", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Voudusufecc=function()
   {
      return this.validCliEvt("Valid_Voudusufecc", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("VOUDUSUFECC");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A2072VouDUsuFecC)==0) || new gx.date.gxdate( this.A2072VouDUsuFecC ).compare( gx.date.ymdhmstot( 1753, 1, 1, 0, 0, 0) ) >= 0 ) )
         {
            try {
               gxballoon.setError("Campo Usuario Fecha C fuera de rango");
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
   this.Valid_Voudusufecm=function()
   {
      return this.validCliEvt("Valid_Voudusufecm", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("VOUDUSUFECM");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A2073VouDUsuFecM)==0) || new gx.date.gxdate( this.A2073VouDUsuFecM ).compare( gx.date.ymdhmstot( 1753, 1, 1, 0, 0, 0) ) >= 0 ) )
         {
            try {
               gxballoon.setError("Campo Usuario Fecha M fuera de rango");
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
   this.e112473_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e122473_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,5,6,7,8,9,15,18,20,23,25,28,30,33,35,38,40,41,44,46,49,51,54,56,59,61,64,66,69,71,74,76,79,81,84,86,89,91,94,96,99,101,104,106,109,111,114,116,119,121,124,126,129,131,134,136,139,141,144,146,149,151,154,156,159,160,161,162,163];
   this.GXLastCtrlId =163;
   GXValidFnc[2]={ id: 2, fld:"TABLE1",grid:0};
   GXValidFnc[5]={ id: 5, fld:"BTN_FIRST",grid:0,evt:"e132473_client",std:"FIRST"};
   GXValidFnc[6]={ id: 6, fld:"BTN_PREVIOUS",grid:0,evt:"e142473_client",std:"PREVIOUS"};
   GXValidFnc[7]={ id: 7, fld:"BTN_NEXT",grid:0,evt:"e152473_client",std:"NEXT"};
   GXValidFnc[8]={ id: 8, fld:"BTN_LAST",grid:0,evt:"e162473_client",std:"LAST"};
   GXValidFnc[9]={ id: 9, fld:"BTN_SELECT",grid:0,evt:"e172473_client",std:"SELECT"};
   GXValidFnc[15]={ id: 15, fld:"TABLE2",grid:0};
   GXValidFnc[18]={ id: 18, fld:"TEXTBLOCK1", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[20]={ id:20 ,lvl:0,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Vouano,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VOUANO",gxz:"Z127VouAno",gxold:"O127VouAno",gxvar:"A127VouAno",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A127VouAno=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z127VouAno=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("VOUANO",gx.O.A127VouAno,0)},c2v:function(){if(this.val()!==undefined)gx.O.A127VouAno=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("VOUANO",',')},nac:gx.falseFn};
   GXValidFnc[23]={ id: 23, fld:"TEXTBLOCK2", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[25]={ id:25 ,lvl:0,type:"int",len:2,dec:0,sign:false,pic:"Z9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Voumes,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VOUMES",gxz:"Z128VouMes",gxold:"O128VouMes",gxvar:"A128VouMes",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A128VouMes=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z128VouMes=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("VOUMES",gx.O.A128VouMes,0)},c2v:function(){if(this.val()!==undefined)gx.O.A128VouMes=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("VOUMES",',')},nac:gx.falseFn};
   GXValidFnc[28]={ id: 28, fld:"TEXTBLOCK3", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[30]={ id:30 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Tasicod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TASICOD",gxz:"Z126TASICod",gxold:"O126TASICod",gxvar:"A126TASICod",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A126TASICod=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z126TASICod=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("TASICOD",gx.O.A126TASICod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A126TASICod=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("TASICOD",',')},nac:gx.falseFn};
   GXValidFnc[33]={ id: 33, fld:"TEXTBLOCK4", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[35]={ id:35 ,lvl:0,type:"char",len:10,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Vounum,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VOUNUM",gxz:"Z129VouNum",gxold:"O129VouNum",gxvar:"A129VouNum",ucs:[],op:[],ip:[35,30,25,20],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A129VouNum=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z129VouNum=Value},v2c:function(){gx.fn.setControlValue("VOUNUM",gx.O.A129VouNum,0)},c2v:function(){if(this.val()!==undefined)gx.O.A129VouNum=this.val()},val:function(){return gx.fn.getControlValue("VOUNUM")},nac:gx.falseFn};
   GXValidFnc[38]={ id: 38, fld:"TEXTBLOCK5", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[40]={ id:40 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Voudsec,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VOUDSEC",gxz:"Z130VouDSec",gxold:"O130VouDSec",gxvar:"A130VouDSec",ucs:[],op:[76,61,51,46,156,151,146,141,136,131,126,121,116,111,106,101,96,91,86,81,71,66,56],ip:[76,61,51,46,156,151,146,141,136,131,126,121,116,111,106,101,96,91,86,81,71,66,56,40,35,30,25,20],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A130VouDSec=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z130VouDSec=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("VOUDSEC",gx.O.A130VouDSec,0)},c2v:function(){if(this.val()!==undefined)gx.O.A130VouDSec=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("VOUDSEC",',')},nac:gx.falseFn};
   GXValidFnc[41]={ id: 41, fld:"BTN_GET",grid:0,evt:"e182473_client",std:"GET"};
   GXValidFnc[44]={ id: 44, fld:"TEXTBLOCK6", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[46]={ id:46 ,lvl:0,type:"char",len:15,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cuecod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUECOD",gxz:"Z91CueCod",gxold:"O91CueCod",gxvar:"A91CueCod",ucs:[],op:[],ip:[46],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A91CueCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z91CueCod=Value},v2c:function(){gx.fn.setControlValue("CUECOD",gx.O.A91CueCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A91CueCod=this.val()},val:function(){return gx.fn.getControlValue("CUECOD")},nac:gx.falseFn};
   GXValidFnc[49]={ id: 49, fld:"TEXTBLOCK7", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[51]={ id:51 ,lvl:0,type:"char",len:10,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Coscod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COSCOD",gxz:"Z79COSCod",gxold:"O79COSCod",gxvar:"A79COSCod",ucs:[],op:[],ip:[51],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A79COSCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z79COSCod=Value},v2c:function(){gx.fn.setControlValue("COSCOD",gx.O.A79COSCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A79COSCod=this.val()},val:function(){return gx.fn.getControlValue("COSCOD")},nac:gx.falseFn};
   GXValidFnc[54]={ id: 54, fld:"TEXTBLOCK8", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[56]={ id:56 ,lvl:0,type:"date",len:8,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Voudfec,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VOUDFEC",gxz:"Z135VouDFec",gxold:"O135VouDFec",gxvar:"A135VouDFec",dp:{f:0,st:false,wn:false,mf:false,pic:"99/99/99",dec:0},ucs:[],op:[56],ip:[56],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A135VouDFec=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z135VouDFec=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("VOUDFEC",gx.O.A135VouDFec,0)},c2v:function(){if(this.val()!==undefined)gx.O.A135VouDFec=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getControlValue("VOUDFEC")},nac:gx.falseFn};
   GXValidFnc[59]={ id: 59, fld:"TEXTBLOCK9", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[61]={ id:61 ,lvl:0,type:"char",len:3,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Voudtipcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VOUDTIPCOD",gxz:"Z132VouDTipCod",gxold:"O132VouDTipCod",gxvar:"A132VouDTipCod",ucs:[],op:[],ip:[61],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A132VouDTipCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z132VouDTipCod=Value},v2c:function(){gx.fn.setControlValue("VOUDTIPCOD",gx.O.A132VouDTipCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A132VouDTipCod=this.val()},val:function(){return gx.fn.getControlValue("VOUDTIPCOD")},nac:gx.falseFn};
   GXValidFnc[64]={ id: 64, fld:"TEXTBLOCK10", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[66]={ id:66 ,lvl:0,type:"char",len:20,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VOUDDOC",gxz:"Z2053VouDDoc",gxold:"O2053VouDDoc",gxvar:"A2053VouDDoc",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A2053VouDDoc=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z2053VouDDoc=Value},v2c:function(){gx.fn.setControlValue("VOUDDOC",gx.O.A2053VouDDoc,0)},c2v:function(){if(this.val()!==undefined)gx.O.A2053VouDDoc=this.val()},val:function(){return gx.fn.getControlValue("VOUDDOC")},nac:gx.falseFn};
   GXValidFnc[69]={ id: 69, fld:"TEXTBLOCK11", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[71]={ id:71 ,lvl:0,type:"char",len:100,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VOUDGLS",gxz:"Z2054VouDGls",gxold:"O2054VouDGls",gxvar:"A2054VouDGls",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A2054VouDGls=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z2054VouDGls=Value},v2c:function(){gx.fn.setControlValue("VOUDGLS",gx.O.A2054VouDGls,0)},c2v:function(){if(this.val()!==undefined)gx.O.A2054VouDGls=this.val()},val:function(){return gx.fn.getControlValue("VOUDGLS")},nac:gx.falseFn};
   GXValidFnc[74]={ id: 74, fld:"TEXTBLOCK12", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[76]={ id:76 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Voudmon,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VOUDMON",gxz:"Z131VouDMon",gxold:"O131VouDMon",gxvar:"A131VouDMon",ucs:[],op:[],ip:[76],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A131VouDMon=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z131VouDMon=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("VOUDMON",gx.O.A131VouDMon,0)},c2v:function(){if(this.val()!==undefined)gx.O.A131VouDMon=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("VOUDMON",',')},nac:gx.falseFn};
   GXValidFnc[79]={ id: 79, fld:"TEXTBLOCK13", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[81]={ id:81 ,lvl:0,type:"decimal",len:15,dec:5,sign:false,pic:"ZZZZZZZZ9.99999",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VOUDTCMB",gxz:"Z2069VouDTcmb",gxold:"O2069VouDTcmb",gxvar:"A2069VouDTcmb",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A2069VouDTcmb=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z2069VouDTcmb=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("VOUDTCMB",gx.O.A2069VouDTcmb,5,'.')},c2v:function(){if(this.val()!==undefined)gx.O.A2069VouDTcmb=this.val()},val:function(){return gx.fn.getDecimalValue("VOUDTCMB",',','.')},nac:gx.falseFn};
   GXValidFnc[84]={ id: 84, fld:"TEXTBLOCK14", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[86]={ id:86 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VOUDDEBO",gxz:"Z2052VouDDebO",gxold:"O2052VouDDebO",gxvar:"A2052VouDDebO",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A2052VouDDebO=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z2052VouDDebO=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("VOUDDEBO",gx.O.A2052VouDDebO,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A2052VouDDebO=this.val()},val:function(){return gx.fn.getDecimalValue("VOUDDEBO",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 86 , function() {
   });
   GXValidFnc[89]={ id: 89, fld:"TEXTBLOCK15", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[91]={ id:91 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VOUDHABO",gxz:"Z2056VouDHabO",gxold:"O2056VouDHabO",gxvar:"A2056VouDHabO",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A2056VouDHabO=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z2056VouDHabO=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("VOUDHABO",gx.O.A2056VouDHabO,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A2056VouDHabO=this.val()},val:function(){return gx.fn.getDecimalValue("VOUDHABO",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 91 , function() {
   });
   GXValidFnc[94]={ id: 94, fld:"TEXTBLOCK16", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[96]={ id:96 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VOUDDEB",gxz:"Z2051VouDDeb",gxold:"O2051VouDDeb",gxvar:"A2051VouDDeb",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A2051VouDDeb=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z2051VouDDeb=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("VOUDDEB",gx.O.A2051VouDDeb,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A2051VouDDeb=this.val()},val:function(){return gx.fn.getDecimalValue("VOUDDEB",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 96 , function() {
   });
   GXValidFnc[99]={ id: 99, fld:"TEXTBLOCK17", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[101]={ id:101 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VOUDHAB",gxz:"Z2055VouDHab",gxold:"O2055VouDHab",gxvar:"A2055VouDHab",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A2055VouDHab=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z2055VouDHab=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("VOUDHAB",gx.O.A2055VouDHab,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A2055VouDHab=this.val()},val:function(){return gx.fn.getDecimalValue("VOUDHAB",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 101 , function() {
   });
   GXValidFnc[104]={ id: 104, fld:"TEXTBLOCK18", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[106]={ id:106 ,lvl:0,type:"char",len:15,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VOUREG",gxz:"Z136VouReg",gxold:"O136VouReg",gxvar:"A136VouReg",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A136VouReg=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z136VouReg=Value},v2c:function(){gx.fn.setControlValue("VOUREG",gx.O.A136VouReg,0)},c2v:function(){if(this.val()!==undefined)gx.O.A136VouReg=this.val()},val:function(){return gx.fn.getControlValue("VOUREG")},nac:gx.falseFn};
   GXValidFnc[109]={ id: 109, fld:"TEXTBLOCK19", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[111]={ id:111 ,lvl:0,type:"char",len:15,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUEAUXCOD",gxz:"Z134CueAuxCod",gxold:"O134CueAuxCod",gxvar:"A134CueAuxCod",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A134CueAuxCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z134CueAuxCod=Value},v2c:function(){gx.fn.setControlValue("CUEAUXCOD",gx.O.A134CueAuxCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A134CueAuxCod=this.val()},val:function(){return gx.fn.getControlValue("CUEAUXCOD")},nac:gx.falseFn};
   GXValidFnc[114]={ id: 114, fld:"TEXTBLOCK20", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[116]={ id:116 ,lvl:0,type:"char",len:20,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUECODAUX",gxz:"Z133CueCodAux",gxold:"O133CueCodAux",gxvar:"A133CueCodAux",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A133CueCodAux=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z133CueCodAux=Value},v2c:function(){gx.fn.setControlValue("CUECODAUX",gx.O.A133CueCodAux,0)},c2v:function(){if(this.val()!==undefined)gx.O.A133CueCodAux=this.val()},val:function(){return gx.fn.getControlValue("CUECODAUX")},nac:gx.falseFn};
   GXValidFnc[119]={ id: 119, fld:"TEXTBLOCK21", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[121]={ id:121 ,lvl:0,type:"char",len:1,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VOUMOVADIC",gxz:"Z2076VouMovAdic",gxold:"O2076VouMovAdic",gxvar:"A2076VouMovAdic",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A2076VouMovAdic=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z2076VouMovAdic=Value},v2c:function(){gx.fn.setControlValue("VOUMOVADIC",gx.O.A2076VouMovAdic,0)},c2v:function(){if(this.val()!==undefined)gx.O.A2076VouMovAdic=this.val()},val:function(){return gx.fn.getControlValue("VOUMOVADIC")},nac:gx.falseFn};
   GXValidFnc[124]={ id: 124, fld:"TEXTBLOCK22", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[126]={ id:126 ,lvl:0,type:"char",len:10,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VOUDUSUCODC",gxz:"Z2070VouDUsuCodC",gxold:"O2070VouDUsuCodC",gxvar:"A2070VouDUsuCodC",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A2070VouDUsuCodC=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z2070VouDUsuCodC=Value},v2c:function(){gx.fn.setControlValue("VOUDUSUCODC",gx.O.A2070VouDUsuCodC,0)},c2v:function(){if(this.val()!==undefined)gx.O.A2070VouDUsuCodC=this.val()},val:function(){return gx.fn.getControlValue("VOUDUSUCODC")},nac:gx.falseFn};
   GXValidFnc[129]={ id: 129, fld:"TEXTBLOCK23", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[131]={ id:131 ,lvl:0,type:"dtime",len:8,dec:5,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Voudusufecc,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VOUDUSUFECC",gxz:"Z2072VouDUsuFecC",gxold:"O2072VouDUsuFecC",gxvar:"A2072VouDUsuFecC",dp:{f:0,st:true,wn:false,mf:false,pic:"99/99/99 99:99",dec:5},ucs:[],op:[131],ip:[131],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A2072VouDUsuFecC=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z2072VouDUsuFecC=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("VOUDUSUFECC",gx.O.A2072VouDUsuFecC,0)},c2v:function(){if(this.val()!==undefined)gx.O.A2072VouDUsuFecC=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getDateTimeValue("VOUDUSUFECC")},nac:gx.falseFn};
   GXValidFnc[134]={ id: 134, fld:"TEXTBLOCK24", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[136]={ id:136 ,lvl:0,type:"char",len:10,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VOUDUSUCODM",gxz:"Z2071VouDUsuCodM",gxold:"O2071VouDUsuCodM",gxvar:"A2071VouDUsuCodM",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A2071VouDUsuCodM=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z2071VouDUsuCodM=Value},v2c:function(){gx.fn.setControlValue("VOUDUSUCODM",gx.O.A2071VouDUsuCodM,0)},c2v:function(){if(this.val()!==undefined)gx.O.A2071VouDUsuCodM=this.val()},val:function(){return gx.fn.getControlValue("VOUDUSUCODM")},nac:gx.falseFn};
   GXValidFnc[139]={ id: 139, fld:"TEXTBLOCK25", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[141]={ id:141 ,lvl:0,type:"dtime",len:8,dec:5,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Voudusufecm,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VOUDUSUFECM",gxz:"Z2073VouDUsuFecM",gxold:"O2073VouDUsuFecM",gxvar:"A2073VouDUsuFecM",dp:{f:0,st:true,wn:false,mf:false,pic:"99/99/99 99:99",dec:5},ucs:[],op:[141],ip:[141],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A2073VouDUsuFecM=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z2073VouDUsuFecM=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("VOUDUSUFECM",gx.O.A2073VouDUsuFecM,0)},c2v:function(){if(this.val()!==undefined)gx.O.A2073VouDUsuFecM=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getDateTimeValue("VOUDUSUFECM")},nac:gx.falseFn};
   GXValidFnc[144]={ id: 144, fld:"TEXTBLOCK26", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[146]={ id:146 ,lvl:0,type:"char",len:15,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VOUDPRODCOD",gxz:"Z2058VouDProdCod",gxold:"O2058VouDProdCod",gxvar:"A2058VouDProdCod",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A2058VouDProdCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z2058VouDProdCod=Value},v2c:function(){gx.fn.setControlValue("VOUDPRODCOD",gx.O.A2058VouDProdCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A2058VouDProdCod=this.val()},val:function(){return gx.fn.getControlValue("VOUDPRODCOD")},nac:gx.falseFn};
   GXValidFnc[149]={ id: 149, fld:"TEXTBLOCK27", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[151]={ id:151 ,lvl:0,type:"char",len:10,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VOUDORDCOD",gxz:"Z2057VouDordCod",gxold:"O2057VouDordCod",gxvar:"A2057VouDordCod",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A2057VouDordCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z2057VouDordCod=Value},v2c:function(){gx.fn.setControlValue("VOUDORDCOD",gx.O.A2057VouDordCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A2057VouDordCod=this.val()},val:function(){return gx.fn.getControlValue("VOUDORDCOD")},nac:gx.falseFn};
   GXValidFnc[154]={ id: 154, fld:"TEXTBLOCK28", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[156]={ id:156 ,lvl:0,type:"decimal",len:15,dec:4,sign:true,pic:"ZZZZ,ZZZ,ZZ9.9999",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VOUDCANT",gxz:"Z2050VouDCant",gxold:"O2050VouDCant",gxvar:"A2050VouDCant",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A2050VouDCant=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z2050VouDCant=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("VOUDCANT",gx.O.A2050VouDCant,4,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A2050VouDCant=this.val()},val:function(){return gx.fn.getDecimalValue("VOUDCANT",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 156 , function() {
   });
   GXValidFnc[159]={ id: 159, fld:"BTN_ENTER",grid:0,evt:"e112473_client",std:"ENTER"};
   GXValidFnc[160]={ id: 160, fld:"BTN_CHECK",grid:0,evt:"e192473_client",std:"CHECK"};
   GXValidFnc[161]={ id: 161, fld:"BTN_CANCEL",grid:0,evt:"e122473_client"};
   GXValidFnc[162]={ id: 162, fld:"BTN_DELETE",grid:0,evt:"e202473_client",std:"DELETE"};
   GXValidFnc[163]={ id: 163, fld:"BTN_HELP",grid:0,evt:"e212473_client"};
   this.A127VouAno = 0 ;
   this.Z127VouAno = 0 ;
   this.O127VouAno = 0 ;
   this.A128VouMes = 0 ;
   this.Z128VouMes = 0 ;
   this.O128VouMes = 0 ;
   this.A126TASICod = 0 ;
   this.Z126TASICod = 0 ;
   this.O126TASICod = 0 ;
   this.A129VouNum = "" ;
   this.Z129VouNum = "" ;
   this.O129VouNum = "" ;
   this.A130VouDSec = 0 ;
   this.Z130VouDSec = 0 ;
   this.O130VouDSec = 0 ;
   this.A91CueCod = "" ;
   this.Z91CueCod = "" ;
   this.O91CueCod = "" ;
   this.A79COSCod = "" ;
   this.Z79COSCod = "" ;
   this.O79COSCod = "" ;
   this.A135VouDFec = gx.date.nullDate() ;
   this.Z135VouDFec = gx.date.nullDate() ;
   this.O135VouDFec = gx.date.nullDate() ;
   this.A132VouDTipCod = "" ;
   this.Z132VouDTipCod = "" ;
   this.O132VouDTipCod = "" ;
   this.A2053VouDDoc = "" ;
   this.Z2053VouDDoc = "" ;
   this.O2053VouDDoc = "" ;
   this.A2054VouDGls = "" ;
   this.Z2054VouDGls = "" ;
   this.O2054VouDGls = "" ;
   this.A131VouDMon = 0 ;
   this.Z131VouDMon = 0 ;
   this.O131VouDMon = 0 ;
   this.A2069VouDTcmb = 0 ;
   this.Z2069VouDTcmb = 0 ;
   this.O2069VouDTcmb = 0 ;
   this.A2052VouDDebO = 0 ;
   this.Z2052VouDDebO = 0 ;
   this.O2052VouDDebO = 0 ;
   this.A2056VouDHabO = 0 ;
   this.Z2056VouDHabO = 0 ;
   this.O2056VouDHabO = 0 ;
   this.A2051VouDDeb = 0 ;
   this.Z2051VouDDeb = 0 ;
   this.O2051VouDDeb = 0 ;
   this.A2055VouDHab = 0 ;
   this.Z2055VouDHab = 0 ;
   this.O2055VouDHab = 0 ;
   this.A136VouReg = "" ;
   this.Z136VouReg = "" ;
   this.O136VouReg = "" ;
   this.A134CueAuxCod = "" ;
   this.Z134CueAuxCod = "" ;
   this.O134CueAuxCod = "" ;
   this.A133CueCodAux = "" ;
   this.Z133CueCodAux = "" ;
   this.O133CueCodAux = "" ;
   this.A2076VouMovAdic = "" ;
   this.Z2076VouMovAdic = "" ;
   this.O2076VouMovAdic = "" ;
   this.A2070VouDUsuCodC = "" ;
   this.Z2070VouDUsuCodC = "" ;
   this.O2070VouDUsuCodC = "" ;
   this.A2072VouDUsuFecC = gx.date.nullDate() ;
   this.Z2072VouDUsuFecC = gx.date.nullDate() ;
   this.O2072VouDUsuFecC = gx.date.nullDate() ;
   this.A2071VouDUsuCodM = "" ;
   this.Z2071VouDUsuCodM = "" ;
   this.O2071VouDUsuCodM = "" ;
   this.A2073VouDUsuFecM = gx.date.nullDate() ;
   this.Z2073VouDUsuFecM = gx.date.nullDate() ;
   this.O2073VouDUsuFecM = gx.date.nullDate() ;
   this.A2058VouDProdCod = "" ;
   this.Z2058VouDProdCod = "" ;
   this.O2058VouDProdCod = "" ;
   this.A2057VouDordCod = "" ;
   this.Z2057VouDordCod = "" ;
   this.O2057VouDordCod = "" ;
   this.A2050VouDCant = 0 ;
   this.Z2050VouDCant = 0 ;
   this.O2050VouDCant = 0 ;
   this.A127VouAno = 0 ;
   this.A128VouMes = 0 ;
   this.A126TASICod = 0 ;
   this.A129VouNum = "" ;
   this.A130VouDSec = 0 ;
   this.A91CueCod = "" ;
   this.A79COSCod = "" ;
   this.A135VouDFec = gx.date.nullDate() ;
   this.A132VouDTipCod = "" ;
   this.A2053VouDDoc = "" ;
   this.A2054VouDGls = "" ;
   this.A131VouDMon = 0 ;
   this.A2069VouDTcmb = 0 ;
   this.A2052VouDDebO = 0 ;
   this.A2056VouDHabO = 0 ;
   this.A2051VouDDeb = 0 ;
   this.A2055VouDHab = 0 ;
   this.A136VouReg = "" ;
   this.A134CueAuxCod = "" ;
   this.A133CueCodAux = "" ;
   this.A2076VouMovAdic = "" ;
   this.A2070VouDUsuCodC = "" ;
   this.A2072VouDUsuFecC = gx.date.nullDate() ;
   this.A2071VouDUsuCodM = "" ;
   this.A2073VouDUsuFecM = gx.date.nullDate() ;
   this.A2058VouDProdCod = "" ;
   this.A2057VouDordCod = "" ;
   this.A2050VouDCant = 0 ;
   this.A2059VouDRef1 = "" ;
   this.A2061VouDRef2 = "" ;
   this.A2062VouDRef3 = "" ;
   this.A2063VouDRef4 = "" ;
   this.A2064VouDRef5 = "" ;
   this.A2065VouDRef6 = "" ;
   this.A2066VouDRef7 = "" ;
   this.A2067VouDRef8 = "" ;
   this.A2068VouDRef9 = "" ;
   this.A2060VouDRef10 = "" ;
   this.Events = {"e112473_client": ["ENTER", true] ,"e122473_client": ["CANCEL", true]};
   this.EvtParms["ENTER"] = [[{postForm:true}],[]];
   this.EvtParms["REFRESH"] = [[{av:'A2059VouDRef1',fld:'VOUDREF1',pic:''},{av:'A2061VouDRef2',fld:'VOUDREF2',pic:''},{av:'A2062VouDRef3',fld:'VOUDREF3',pic:''},{av:'A2063VouDRef4',fld:'VOUDREF4',pic:''},{av:'A2064VouDRef5',fld:'VOUDREF5',pic:''},{av:'A2065VouDRef6',fld:'VOUDREF6',pic:''},{av:'A2066VouDRef7',fld:'VOUDREF7',pic:''},{av:'A2067VouDRef8',fld:'VOUDREF8',pic:''},{av:'A2068VouDRef9',fld:'VOUDREF9',pic:''},{av:'A2060VouDRef10',fld:'VOUDREF10',pic:''}],[]];
   this.EvtParms["VALID_VOUANO"] = [[],[]];
   this.EvtParms["VALID_VOUMES"] = [[],[]];
   this.EvtParms["VALID_TASICOD"] = [[],[]];
   this.EvtParms["VALID_VOUNUM"] = [[{av:'A127VouAno',fld:'VOUANO',pic:'ZZZ9'},{av:'A128VouMes',fld:'VOUMES',pic:'Z9'},{av:'A126TASICod',fld:'TASICOD',pic:'ZZZZZ9'},{av:'A129VouNum',fld:'VOUNUM',pic:''}],[]];
   this.EvtParms["VALID_VOUDSEC"] = [[{av:'A2060VouDRef10',fld:'VOUDREF10',pic:''},{av:'A2068VouDRef9',fld:'VOUDREF9',pic:''},{av:'A2067VouDRef8',fld:'VOUDREF8',pic:''},{av:'A2066VouDRef7',fld:'VOUDREF7',pic:''},{av:'A2065VouDRef6',fld:'VOUDREF6',pic:''},{av:'A2064VouDRef5',fld:'VOUDREF5',pic:''},{av:'A2063VouDRef4',fld:'VOUDREF4',pic:''},{av:'A2062VouDRef3',fld:'VOUDREF3',pic:''},{av:'A2061VouDRef2',fld:'VOUDREF2',pic:''},{av:'A2059VouDRef1',fld:'VOUDREF1',pic:''},{av:'A127VouAno',fld:'VOUANO',pic:'ZZZ9'},{av:'A128VouMes',fld:'VOUMES',pic:'Z9'},{av:'A126TASICod',fld:'TASICOD',pic:'ZZZZZ9'},{av:'A129VouNum',fld:'VOUNUM',pic:''},{av:'A130VouDSec',fld:'VOUDSEC',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}],[{av:'A91CueCod',fld:'CUECOD',pic:''},{av:'A79COSCod',fld:'COSCOD',pic:''},{av:'A135VouDFec',fld:'VOUDFEC',pic:''},{av:'A132VouDTipCod',fld:'VOUDTIPCOD',pic:''},{av:'A2053VouDDoc',fld:'VOUDDOC',pic:''},{av:'A2054VouDGls',fld:'VOUDGLS',pic:''},{av:'A131VouDMon',fld:'VOUDMON',pic:'ZZZZZ9'},{av:'A2069VouDTcmb',fld:'VOUDTCMB',pic:'ZZZZZZZZ9.99999'},{av:'A2052VouDDebO',fld:'VOUDDEBO',pic:'ZZZ,ZZZ,ZZ9.99'},{av:'A2056VouDHabO',fld:'VOUDHABO',pic:'ZZZ,ZZZ,ZZ9.99'},{av:'A2051VouDDeb',fld:'VOUDDEB',pic:'ZZZ,ZZZ,ZZ9.99'},{av:'A2055VouDHab',fld:'VOUDHAB',pic:'ZZZ,ZZZ,ZZ9.99'},{av:'A136VouReg',fld:'VOUREG',pic:''},{av:'A134CueAuxCod',fld:'CUEAUXCOD',pic:''},{av:'A133CueCodAux',fld:'CUECODAUX',pic:''},{av:'A2076VouMovAdic',fld:'VOUMOVADIC',pic:''},{av:'A2070VouDUsuCodC',fld:'VOUDUSUCODC',pic:''},{av:'A2072VouDUsuFecC',fld:'VOUDUSUFECC',pic:'99/99/99 99:99'},{av:'A2071VouDUsuCodM',fld:'VOUDUSUCODM',pic:''},{av:'A2073VouDUsuFecM',fld:'VOUDUSUFECM',pic:'99/99/99 99:99'},{av:'A2058VouDProdCod',fld:'VOUDPRODCOD',pic:''},{av:'A2057VouDordCod',fld:'VOUDORDCOD',pic:''},{av:'A2050VouDCant',fld:'VOUDCANT',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A2059VouDRef1',fld:'VOUDREF1',pic:''},{av:'A2061VouDRef2',fld:'VOUDREF2',pic:''},{av:'A2062VouDRef3',fld:'VOUDREF3',pic:''},{av:'A2063VouDRef4',fld:'VOUDREF4',pic:''},{av:'A2064VouDRef5',fld:'VOUDREF5',pic:''},{av:'A2065VouDRef6',fld:'VOUDREF6',pic:''},{av:'A2066VouDRef7',fld:'VOUDREF7',pic:''},{av:'A2067VouDRef8',fld:'VOUDREF8',pic:''},{av:'A2068VouDRef9',fld:'VOUDREF9',pic:''},{av:'A2060VouDRef10',fld:'VOUDREF10',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z127VouAno'},{av:'Z128VouMes'},{av:'Z126TASICod'},{av:'Z129VouNum'},{av:'Z130VouDSec'},{av:'Z91CueCod'},{av:'Z79COSCod'},{av:'Z135VouDFec'},{av:'Z132VouDTipCod'},{av:'Z2053VouDDoc'},{av:'Z2054VouDGls'},{av:'Z131VouDMon'},{av:'Z2069VouDTcmb'},{av:'Z2052VouDDebO'},{av:'Z2056VouDHabO'},{av:'Z2051VouDDeb'},{av:'Z2055VouDHab'},{av:'Z136VouReg'},{av:'Z134CueAuxCod'},{av:'Z133CueCodAux'},{av:'Z2076VouMovAdic'},{av:'Z2070VouDUsuCodC'},{av:'Z2072VouDUsuFecC'},{av:'Z2071VouDUsuCodM'},{av:'Z2073VouDUsuFecM'},{av:'Z2058VouDProdCod'},{av:'Z2057VouDordCod'},{av:'Z2050VouDCant'},{av:'Z2059VouDRef1'},{av:'Z2061VouDRef2'},{av:'Z2062VouDRef3'},{av:'Z2063VouDRef4'},{av:'Z2064VouDRef5'},{av:'Z2065VouDRef6'},{av:'Z2066VouDRef7'},{av:'Z2067VouDRef8'},{av:'Z2068VouDRef9'},{av:'Z2060VouDRef10'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]];
   this.EvtParms["VALID_CUECOD"] = [[{av:'A91CueCod',fld:'CUECOD',pic:''}],[]];
   this.EvtParms["VALID_COSCOD"] = [[{av:'A79COSCod',fld:'COSCOD',pic:''}],[]];
   this.EvtParms["VALID_VOUDFEC"] = [[{av:'A135VouDFec',fld:'VOUDFEC',pic:''}],[{av:'A135VouDFec',fld:'VOUDFEC',pic:''}]];
   this.EvtParms["VALID_VOUDTIPCOD"] = [[{av:'A132VouDTipCod',fld:'VOUDTIPCOD',pic:''}],[]];
   this.EvtParms["VALID_VOUDMON"] = [[{av:'A131VouDMon',fld:'VOUDMON',pic:'ZZZZZ9'}],[]];
   this.EvtParms["VALID_VOUDUSUFECC"] = [[{av:'A2072VouDUsuFecC',fld:'VOUDUSUFECC',pic:'99/99/99 99:99'}],[{av:'A2072VouDUsuFecC',fld:'VOUDUSUFECC',pic:'99/99/99 99:99'}]];
   this.EvtParms["VALID_VOUDUSUFECM"] = [[{av:'A2073VouDUsuFecM',fld:'VOUDUSUFECM',pic:'99/99/99 99:99'}],[{av:'A2073VouDUsuFecM',fld:'VOUDUSUFECM',pic:'99/99/99 99:99'}]];
   this.EnterCtrl = ["BTN_ENTER"];
   this.CheckCtrl = ["BTN_CHECK"];
   this.setVCMap("A2059VouDRef1", "VOUDREF1", 0, "svchar", 100, 0);
   this.setVCMap("A2061VouDRef2", "VOUDREF2", 0, "svchar", 100, 0);
   this.setVCMap("A2062VouDRef3", "VOUDREF3", 0, "svchar", 100, 0);
   this.setVCMap("A2063VouDRef4", "VOUDREF4", 0, "svchar", 100, 0);
   this.setVCMap("A2064VouDRef5", "VOUDREF5", 0, "svchar", 100, 0);
   this.setVCMap("A2065VouDRef6", "VOUDREF6", 0, "svchar", 100, 0);
   this.setVCMap("A2066VouDRef7", "VOUDREF7", 0, "svchar", 100, 0);
   this.setVCMap("A2067VouDRef8", "VOUDREF8", 0, "svchar", 100, 0);
   this.setVCMap("A2068VouDRef9", "VOUDREF9", 0, "svchar", 100, 0);
   this.setVCMap("A2060VouDRef10", "VOUDREF10", 0, "svchar", 100, 0);
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(this.cbvoucherdet);});
