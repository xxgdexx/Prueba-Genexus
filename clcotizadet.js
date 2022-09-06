gx.evt.autoSkip = false;
gx.define('clcotizadet', false, function () {
   this.ServerClass =  "clcotizadet" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.ServerFullClass =  "clcotizadet.aspx" ;
   this.setObjectType("trn");
   this.hasEnterEvent = true;
   this.skipOnEnter = false;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
      this.A780CotDPreInc=gx.fn.getDecimalValue("COTDPREINC",',','.') ;
      this.A795CotDTotInc=gx.fn.getDecimalValue("COTDTOTINC",',','.') ;
      this.A769CotDSub=gx.fn.getDecimalValue("COTDSUB",',','.') ;
      this.A778CotDInafecto=gx.fn.getDecimalValue("COTDINAFECTO",',','.') ;
      this.A777CotDGratuito=gx.fn.getDecimalValue("COTDGRATUITO",',','.') ;
      this.A776CotDExonerado=gx.fn.getDecimalValue("COTDEXONERADO",',','.') ;
      this.A767CotDAfecto=gx.fn.getDecimalValue("COTDAFECTO",',','.') ;
      this.A791CotDSelectivo=gx.fn.getDecimalValue("COTDSELECTIVO",',','.') ;
      this.A775CotDDscto=gx.fn.getDecimalValue("COTDDSCTO",',','.') ;
      this.A781CotDRef1=gx.fn.getControlValue("COTDREF1") ;
      this.A782CotDRef2=gx.fn.getControlValue("COTDREF2") ;
      this.A783CotDRef3=gx.fn.getControlValue("COTDREF3") ;
      this.A784CotDRef4=gx.fn.getControlValue("COTDREF4") ;
      this.A785CotDRef5=gx.fn.getControlValue("COTDREF5") ;
   };
   this.Valid_Cotcod=function()
   {
      return this.validSrvEvt("Valid_Cotcod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Cotditem=function()
   {
      return this.validSrvEvt("Valid_Cotditem", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Prodcod=function()
   {
      return this.validSrvEvt("Valid_Prodcod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Cotdcan=function()
   {
      return this.validCliEvt("Valid_Cotdcan", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("COTDCAN");
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
   this.Valid_Cotdpre=function()
   {
      return this.validCliEvt("Valid_Cotdpre", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("COTDPRE");
         this.AnyError  = 0;
         try {
            this.A769CotDSub =  gx.num.round( this.A770CotDCan*this.A771CotDPre, 4)  ;
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
   this.Valid_Cotddsct1=function()
   {
      return this.validCliEvt("Valid_Cotddsct1", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("COTDDSCT1");
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
   this.Valid_Cotddsct2=function()
   {
      return this.validCliEvt("Valid_Cotddsct2", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("COTDDSCT2");
         this.AnyError  = 0;
         try {
            this.A795CotDTotInc =  gx.num.round( (this.A780CotDPreInc*this.A770CotDCan)*(1-(this.A772CotDDsct1/100))*(1-(this.A773CotDDsct2/100)), 2)  ;
         }
         catch(e){}
         try {
            this.A768CotDTot =  gx.num.round( (this.A769CotDSub)*(1-(this.A772CotDDsct1/100))*(1-(this.A773CotDDsct2/100)), 2)  ;
         }
         catch(e){}
         try {
            this.A775CotDDscto =  gx.num.round( gx.num.subtract(this.A768CotDTot,this.A769CotDSub), 2)  ;
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
   this.Valid_Cotdina=function()
   {
      return this.validCliEvt("Valid_Cotdina", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("COTDINA");
         this.AnyError  = 0;
         try {
            if ( ( this.A774CotDIna == 1 ) || ( this.A774CotDIna == 4 ) )
            {
               this.A778CotDInafecto =  this.A768CotDTot  ;
            }
            else
            {
               this.A778CotDInafecto =  0  ;
            }
         }
         catch(e){}
         try {
            if ( this.A774CotDIna == 3 )
            {
               this.A777CotDGratuito =  this.A768CotDTot  ;
            }
            else
            {
               this.A777CotDGratuito =  0  ;
            }
         }
         catch(e){}
         try {
            if ( this.A774CotDIna == 2 )
            {
               this.A776CotDExonerado =  this.A768CotDTot  ;
            }
            else
            {
               this.A776CotDExonerado =  0  ;
            }
         }
         catch(e){}
         try {
            if ( this.A774CotDIna == 0 )
            {
               this.A767CotDAfecto =  this.A768CotDTot  ;
            }
            else
            {
               this.A767CotDAfecto =  0  ;
            }
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
   this.Valid_Cotdsel=function()
   {
      return this.validCliEvt("Valid_Cotdsel", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("COTDSEL");
         this.AnyError  = 0;
         try {
            this.A791CotDSelectivo =  gx.num.round( gx.num.divide((gx.num.multiply(this.A768CotDTot,this.A792CotDSel)),100), 2)  ;
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
   this.Valid_Cotdtot=function()
   {
      return this.validCliEvt("Valid_Cotdtot", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("COTDTOT");
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
   this.e112j87_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e122j87_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,5,6,7,8,9,15,18,20,23,25,26,29,31,34,36,39,41,44,46,49,51,54,56,59,61,64,66,69,71,74,75,76,77,78];
   this.GXLastCtrlId =78;
   GXValidFnc[2]={ id: 2, fld:"TABLE1",grid:0};
   GXValidFnc[5]={ id: 5, fld:"BTN_FIRST",grid:0,evt:"e132j87_client",std:"FIRST"};
   GXValidFnc[6]={ id: 6, fld:"BTN_PREVIOUS",grid:0,evt:"e142j87_client",std:"PREVIOUS"};
   GXValidFnc[7]={ id: 7, fld:"BTN_NEXT",grid:0,evt:"e152j87_client",std:"NEXT"};
   GXValidFnc[8]={ id: 8, fld:"BTN_LAST",grid:0,evt:"e162j87_client",std:"LAST"};
   GXValidFnc[9]={ id: 9, fld:"BTN_SELECT",grid:0,evt:"e172j87_client",std:"SELECT"};
   GXValidFnc[15]={ id: 15, fld:"TABLE2",grid:0};
   GXValidFnc[18]={ id: 18, fld:"TEXTBLOCK1", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[20]={ id:20 ,lvl:0,type:"char",len:10,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cotcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COTCOD",gxz:"Z177CotCod",gxold:"O177CotCod",gxvar:"A177CotCod",ucs:[],op:[],ip:[20],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A177CotCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z177CotCod=Value},v2c:function(){gx.fn.setControlValue("COTCOD",gx.O.A177CotCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A177CotCod=this.val()},val:function(){return gx.fn.getControlValue("COTCOD")},nac:gx.falseFn};
   GXValidFnc[23]={ id: 23, fld:"TEXTBLOCK2", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[25]={ id:25 ,lvl:0,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cotditem,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COTDITEM",gxz:"Z183CotDItem",gxold:"O183CotDItem",gxvar:"A183CotDItem",ucs:[],op:[31,66,61,56,51,46,41,36,71],ip:[31,66,61,56,51,46,41,36,71,25,20],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A183CotDItem=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z183CotDItem=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("COTDITEM",gx.O.A183CotDItem,0)},c2v:function(){if(this.val()!==undefined)gx.O.A183CotDItem=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("COTDITEM",',')},nac:gx.falseFn};
   GXValidFnc[26]={ id: 26, fld:"BTN_GET",grid:0,evt:"e182j87_client",std:"GET"};
   GXValidFnc[29]={ id: 29, fld:"TEXTBLOCK3", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[31]={ id:31 ,lvl:0,type:"char",len:15,dec:0,sign:false,pic:"@!",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Prodcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODCOD",gxz:"Z28ProdCod",gxold:"O28ProdCod",gxvar:"A28ProdCod",ucs:[],op:[],ip:[31],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A28ProdCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z28ProdCod=Value},v2c:function(){gx.fn.setControlValue("PRODCOD",gx.O.A28ProdCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A28ProdCod=this.val()},val:function(){return gx.fn.getControlValue("PRODCOD")},nac:gx.falseFn};
   GXValidFnc[34]={ id: 34, fld:"TEXTBLOCK4", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[36]={ id:36 ,lvl:0,type:"decimal",len:15,dec:4,sign:true,pic:"ZZZZ,ZZZ,ZZ9.9999",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cotdcan,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COTDCAN",gxz:"Z770CotDCan",gxold:"O770CotDCan",gxvar:"A770CotDCan",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A770CotDCan=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z770CotDCan=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("COTDCAN",gx.O.A770CotDCan,4,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A770CotDCan=this.val()},val:function(){return gx.fn.getDecimalValue("COTDCAN",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 36 , function() {
   });
   GXValidFnc[39]={ id: 39, fld:"TEXTBLOCK5", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[41]={ id:41 ,lvl:0,type:"decimal",len:15,dec:4,sign:true,pic:"ZZZ,ZZZ,ZZ9.9999",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cotdpre,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COTDPRE",gxz:"Z771CotDPre",gxold:"O771CotDPre",gxvar:"A771CotDPre",ucs:[],op:[],ip:[41,36],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A771CotDPre=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z771CotDPre=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("COTDPRE",gx.O.A771CotDPre,4,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A771CotDPre=this.val()},val:function(){return gx.fn.getDecimalValue("COTDPRE",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 41 , function() {
   });
   GXValidFnc[44]={ id: 44, fld:"TEXTBLOCK6", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[46]={ id:46 ,lvl:0,type:"decimal",len:6,dec:2,sign:false,pic:"ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cotddsct1,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COTDDSCT1",gxz:"Z772CotDDsct1",gxold:"O772CotDDsct1",gxvar:"A772CotDDsct1",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A772CotDDsct1=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z772CotDDsct1=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("COTDDSCT1",gx.O.A772CotDDsct1,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A772CotDDsct1=this.val()},val:function(){return gx.fn.getDecimalValue("COTDDSCT1",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 46 , function() {
   });
   GXValidFnc[49]={ id: 49, fld:"TEXTBLOCK7", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[51]={ id:51 ,lvl:0,type:"decimal",len:6,dec:2,sign:false,pic:"ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cotddsct2,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COTDDSCT2",gxz:"Z773CotDDsct2",gxold:"O773CotDDsct2",gxvar:"A773CotDDsct2",ucs:[],op:[71],ip:[71,51,46,36],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A773CotDDsct2=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z773CotDDsct2=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("COTDDSCT2",gx.O.A773CotDDsct2,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A773CotDDsct2=this.val()},val:function(){return gx.fn.getDecimalValue("COTDDSCT2",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 51 , function() {
   });
   GXValidFnc[54]={ id: 54, fld:"TEXTBLOCK8", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[56]={ id:56 ,lvl:0,type:"int",len:1,dec:0,sign:false,pic:"9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cotdina,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COTDINA",gxz:"Z774CotDIna",gxold:"O774CotDIna",gxvar:"A774CotDIna",ucs:[],op:[],ip:[56,71],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A774CotDIna=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z774CotDIna=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("COTDINA",gx.O.A774CotDIna,0)},c2v:function(){if(this.val()!==undefined)gx.O.A774CotDIna=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("COTDINA",',')},nac:gx.falseFn};
   GXValidFnc[59]={ id: 59, fld:"TEXTBLOCK9", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[61]={ id:61 ,lvl:0,type:"decimal",len:6,dec:2,sign:false,pic:"ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cotdsel,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COTDSEL",gxz:"Z792CotDSel",gxold:"O792CotDSel",gxvar:"A792CotDSel",ucs:[],op:[],ip:[61,71],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A792CotDSel=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z792CotDSel=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("COTDSEL",gx.O.A792CotDSel,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A792CotDSel=this.val()},val:function(){return gx.fn.getDecimalValue("COTDSEL",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 61 , function() {
   });
   GXValidFnc[64]={ id: 64, fld:"TEXTBLOCK10", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[66]={ id:66 ,lvl:0,type:"vchar",len:500,dec:0,sign:false,ro:0,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COTDOBS",gxz:"Z779CotDObs",gxold:"O779CotDObs",gxvar:"A779CotDObs",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A779CotDObs=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z779CotDObs=Value},v2c:function(){gx.fn.setControlValue("COTDOBS",gx.O.A779CotDObs,0)},c2v:function(){if(this.val()!==undefined)gx.O.A779CotDObs=this.val()},val:function(){return gx.fn.getControlValue("COTDOBS")},nac:gx.falseFn};
   GXValidFnc[69]={ id: 69, fld:"TEXTBLOCK11", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[71]={ id:71 ,lvl:0,type:"decimal",len:18,dec:8,sign:true,pic:"ZZZZ,ZZZ,ZZ9.99",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Cotdtot,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COTDTOT",gxz:"Z768CotDTot",gxold:"O768CotDTot",gxvar:"A768CotDTot",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A768CotDTot=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z768CotDTot=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("COTDTOT",gx.O.A768CotDTot,8,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A768CotDTot=this.val()},val:function(){return gx.fn.getDecimalValue("COTDTOT",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 71 , function() {
   });
   GXValidFnc[74]={ id: 74, fld:"BTN_ENTER",grid:0,evt:"e112j87_client",std:"ENTER"};
   GXValidFnc[75]={ id: 75, fld:"BTN_CHECK",grid:0,evt:"e192j87_client",std:"CHECK"};
   GXValidFnc[76]={ id: 76, fld:"BTN_CANCEL",grid:0,evt:"e122j87_client"};
   GXValidFnc[77]={ id: 77, fld:"BTN_DELETE",grid:0,evt:"e202j87_client",std:"DELETE"};
   GXValidFnc[78]={ id: 78, fld:"BTN_HELP",grid:0,evt:"e212j87_client"};
   this.A177CotCod = "" ;
   this.Z177CotCod = "" ;
   this.O177CotCod = "" ;
   this.A183CotDItem = 0 ;
   this.Z183CotDItem = 0 ;
   this.O183CotDItem = 0 ;
   this.A28ProdCod = "" ;
   this.Z28ProdCod = "" ;
   this.O28ProdCod = "" ;
   this.A770CotDCan = 0 ;
   this.Z770CotDCan = 0 ;
   this.O770CotDCan = 0 ;
   this.A771CotDPre = 0 ;
   this.Z771CotDPre = 0 ;
   this.O771CotDPre = 0 ;
   this.A772CotDDsct1 = 0 ;
   this.Z772CotDDsct1 = 0 ;
   this.O772CotDDsct1 = 0 ;
   this.A773CotDDsct2 = 0 ;
   this.Z773CotDDsct2 = 0 ;
   this.O773CotDDsct2 = 0 ;
   this.A774CotDIna = 0 ;
   this.Z774CotDIna = 0 ;
   this.O774CotDIna = 0 ;
   this.A792CotDSel = 0 ;
   this.Z792CotDSel = 0 ;
   this.O792CotDSel = 0 ;
   this.A779CotDObs = "" ;
   this.Z779CotDObs = "" ;
   this.O779CotDObs = "" ;
   this.A768CotDTot = 0 ;
   this.Z768CotDTot = 0 ;
   this.O768CotDTot = 0 ;
   this.A177CotCod = "" ;
   this.A183CotDItem = 0 ;
   this.A775CotDDscto = 0 ;
   this.A791CotDSelectivo = 0 ;
   this.A767CotDAfecto = 0 ;
   this.A776CotDExonerado = 0 ;
   this.A777CotDGratuito = 0 ;
   this.A778CotDInafecto = 0 ;
   this.A768CotDTot = 0 ;
   this.A769CotDSub = 0 ;
   this.A795CotDTotInc = 0 ;
   this.A28ProdCod = "" ;
   this.A770CotDCan = 0 ;
   this.A771CotDPre = 0 ;
   this.A772CotDDsct1 = 0 ;
   this.A773CotDDsct2 = 0 ;
   this.A774CotDIna = 0 ;
   this.A792CotDSel = 0 ;
   this.A779CotDObs = "" ;
   this.A780CotDPreInc = 0 ;
   this.A781CotDRef1 = "" ;
   this.A782CotDRef2 = "" ;
   this.A783CotDRef3 = "" ;
   this.A784CotDRef4 = "" ;
   this.A785CotDRef5 = "" ;
   this.Events = {"e112j87_client": ["ENTER", true] ,"e122j87_client": ["CANCEL", true]};
   this.EvtParms["ENTER"] = [[{postForm:true}],[]];
   this.EvtParms["REFRESH"] = [[{av:'A780CotDPreInc',fld:'COTDPREINC',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A781CotDRef1',fld:'COTDREF1',pic:''},{av:'A782CotDRef2',fld:'COTDREF2',pic:''},{av:'A783CotDRef3',fld:'COTDREF3',pic:''},{av:'A784CotDRef4',fld:'COTDREF4',pic:''},{av:'A785CotDRef5',fld:'COTDREF5',pic:''}],[]];
   this.EvtParms["VALID_COTCOD"] = [[{av:'A177CotCod',fld:'COTCOD',pic:''}],[]];
   this.EvtParms["VALID_COTDITEM"] = [[{av:'A785CotDRef5',fld:'COTDREF5',pic:''},{av:'A784CotDRef4',fld:'COTDREF4',pic:''},{av:'A783CotDRef3',fld:'COTDREF3',pic:''},{av:'A782CotDRef2',fld:'COTDREF2',pic:''},{av:'A781CotDRef1',fld:'COTDREF1',pic:''},{av:'A780CotDPreInc',fld:'COTDPREINC',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A177CotCod',fld:'COTCOD',pic:''},{av:'A183CotDItem',fld:'COTDITEM',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}],[{av:'A28ProdCod',fld:'PRODCOD',pic:'@!'},{av:'A770CotDCan',fld:'COTDCAN',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A771CotDPre',fld:'COTDPRE',pic:'ZZZ,ZZZ,ZZ9.9999'},{av:'A772CotDDsct1',fld:'COTDDSCT1',pic:'ZZ9.99'},{av:'A773CotDDsct2',fld:'COTDDSCT2',pic:'ZZ9.99'},{av:'A774CotDIna',fld:'COTDINA',pic:'9'},{av:'A792CotDSel',fld:'COTDSEL',pic:'ZZ9.99'},{av:'A779CotDObs',fld:'COTDOBS',pic:''},{av:'A780CotDPreInc',fld:'COTDPREINC',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A781CotDRef1',fld:'COTDREF1',pic:''},{av:'A782CotDRef2',fld:'COTDREF2',pic:''},{av:'A783CotDRef3',fld:'COTDREF3',pic:''},{av:'A784CotDRef4',fld:'COTDREF4',pic:''},{av:'A785CotDRef5',fld:'COTDREF5',pic:''},{av:'A795CotDTotInc',fld:'COTDTOTINC',pic:'ZZZZ,ZZZ,ZZ9.99'},{av:'A769CotDSub',fld:'COTDSUB',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A768CotDTot',fld:'COTDTOT',pic:'ZZZZ,ZZZ,ZZ9.99'},{av:'A775CotDDscto',fld:'COTDDSCTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A778CotDInafecto',fld:'COTDINAFECTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A777CotDGratuito',fld:'COTDGRATUITO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A776CotDExonerado',fld:'COTDEXONERADO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A767CotDAfecto',fld:'COTDAFECTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A791CotDSelectivo',fld:'COTDSELECTIVO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z177CotCod'},{av:'Z183CotDItem'},{av:'Z28ProdCod'},{av:'Z770CotDCan'},{av:'Z771CotDPre'},{av:'Z772CotDDsct1'},{av:'Z773CotDDsct2'},{av:'Z774CotDIna'},{av:'Z792CotDSel'},{av:'Z779CotDObs'},{av:'Z780CotDPreInc'},{av:'Z781CotDRef1'},{av:'Z782CotDRef2'},{av:'Z783CotDRef3'},{av:'Z784CotDRef4'},{av:'Z785CotDRef5'},{av:'Z795CotDTotInc'},{av:'Z769CotDSub'},{av:'Z768CotDTot'},{av:'Z775CotDDscto'},{av:'Z778CotDInafecto'},{av:'Z777CotDGratuito'},{av:'Z776CotDExonerado'},{av:'Z767CotDAfecto'},{av:'Z791CotDSelectivo'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]];
   this.EvtParms["VALID_PRODCOD"] = [[{av:'A28ProdCod',fld:'PRODCOD',pic:'@!'}],[]];
   this.EvtParms["VALID_COTDCAN"] = [[],[]];
   this.EvtParms["VALID_COTDPRE"] = [[{av:'A771CotDPre',fld:'COTDPRE',pic:'ZZZ,ZZZ,ZZ9.9999'},{av:'A770CotDCan',fld:'COTDCAN',pic:'ZZZZ,ZZZ,ZZ9.9999'}],[]];
   this.EvtParms["VALID_COTDDSCT1"] = [[],[]];
   this.EvtParms["VALID_COTDDSCT2"] = [[{av:'A768CotDTot',fld:'COTDTOT',pic:'ZZZZ,ZZZ,ZZ9.99'},{av:'A773CotDDsct2',fld:'COTDDSCT2',pic:'ZZ9.99'},{av:'A772CotDDsct1',fld:'COTDDSCT1',pic:'ZZ9.99'},{av:'A770CotDCan',fld:'COTDCAN',pic:'ZZZZ,ZZZ,ZZ9.9999'}],[{av:'A768CotDTot',fld:'COTDTOT',pic:'ZZZZ,ZZZ,ZZ9.99'}]];
   this.EvtParms["VALID_COTDINA"] = [[{av:'A774CotDIna',fld:'COTDINA',pic:'9'},{av:'A768CotDTot',fld:'COTDTOT',pic:'ZZZZ,ZZZ,ZZ9.99'}],[]];
   this.EvtParms["VALID_COTDSEL"] = [[{av:'A792CotDSel',fld:'COTDSEL',pic:'ZZ9.99'},{av:'A768CotDTot',fld:'COTDTOT',pic:'ZZZZ,ZZZ,ZZ9.99'}],[]];
   this.EvtParms["VALID_COTDTOT"] = [[],[]];
   this.EnterCtrl = ["BTN_ENTER"];
   this.CheckCtrl = ["BTN_CHECK"];
   this.setVCMap("A780CotDPreInc", "COTDPREINC", 0, "decimal", 15, 4);
   this.setVCMap("A795CotDTotInc", "COTDTOTINC", 0, "decimal", 15, 4);
   this.setVCMap("A769CotDSub", "COTDSUB", 0, "decimal", 15, 4);
   this.setVCMap("A778CotDInafecto", "COTDINAFECTO", 0, "decimal", 15, 2);
   this.setVCMap("A777CotDGratuito", "COTDGRATUITO", 0, "decimal", 15, 2);
   this.setVCMap("A776CotDExonerado", "COTDEXONERADO", 0, "decimal", 15, 2);
   this.setVCMap("A767CotDAfecto", "COTDAFECTO", 0, "decimal", 15, 2);
   this.setVCMap("A791CotDSelectivo", "COTDSELECTIVO", 0, "decimal", 15, 2);
   this.setVCMap("A775CotDDscto", "COTDDSCTO", 0, "decimal", 15, 2);
   this.setVCMap("A781CotDRef1", "COTDREF1", 0, "svchar", 20, 0);
   this.setVCMap("A782CotDRef2", "COTDREF2", 0, "svchar", 20, 0);
   this.setVCMap("A783CotDRef3", "COTDREF3", 0, "svchar", 20, 0);
   this.setVCMap("A784CotDRef4", "COTDREF4", 0, "svchar", 20, 0);
   this.setVCMap("A785CotDRef5", "COTDREF5", 0, "svchar", 20, 0);
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(this.clcotizadet);});
