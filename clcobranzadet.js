gx.evt.autoSkip = false;
gx.define('clcobranzadet', false, function () {
   this.ServerClass =  "clcobranzadet" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.ServerFullClass =  "clcobranzadet.aspx" ;
   this.setObjectType("trn");
   this.hasEnterEvent = true;
   this.skipOnEnter = false;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
      this.A650CobDRef1=gx.fn.getControlValue("COBDREF1") ;
      this.A651CobDRef2=gx.fn.getControlValue("COBDREF2") ;
      this.A652CobDRef3=gx.fn.getControlValue("COBDREF3") ;
      this.A653CobDRef4=gx.fn.getControlValue("COBDREF4") ;
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
   this.Valid_Item=function()
   {
      return this.validSrvEvt("Valid_Item", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Cobtipcod=function()
   {
      return this.validCliEvt("Valid_Cobtipcod", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("COBTIPCOD");
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
   this.Valid_Cobdocnum=function()
   {
      return this.validSrvEvt("Valid_Cobdocnum", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Forcod=function()
   {
      return this.validSrvEvt("Valid_Forcod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Cobdfdif=function()
   {
      return this.validCliEvt("Valid_Cobdfdif", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("COBDFDIF");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A648CobDFDif)==0) || new gx.date.gxdate( this.A648CobDFDif ).compare( gx.date.ymdtod( 1753, 1, 1) ) >= 0 ) )
         {
            try {
               gxballoon.setError("Campo Fecha Diferido fuera de rango");
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
   this.Valid_Cobdbancod=function()
   {
      return this.validSrvEvt("Valid_Cobdbancod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.e112h85_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e122h85_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,5,6,7,8,9,15,18,20,23,25,28,30,31,34,36,39,41,44,46,49,51,54,56,59,61,64,66,69,71,74,76,79,81,84,86,89,91,94,96,99,101,104,105,106,107,108];
   this.GXLastCtrlId =108;
   GXValidFnc[2]={ id: 2, fld:"TABLE1",grid:0};
   GXValidFnc[5]={ id: 5, fld:"BTN_FIRST",grid:0,evt:"e132h85_client",std:"FIRST"};
   GXValidFnc[6]={ id: 6, fld:"BTN_PREVIOUS",grid:0,evt:"e142h85_client",std:"PREVIOUS"};
   GXValidFnc[7]={ id: 7, fld:"BTN_NEXT",grid:0,evt:"e152h85_client",std:"NEXT"};
   GXValidFnc[8]={ id: 8, fld:"BTN_LAST",grid:0,evt:"e162h85_client",std:"LAST"};
   GXValidFnc[9]={ id: 9, fld:"BTN_SELECT",grid:0,evt:"e172h85_client",std:"SELECT"};
   GXValidFnc[15]={ id: 15, fld:"TABLE2",grid:0};
   GXValidFnc[18]={ id: 18, fld:"TEXTBLOCK1", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[20]={ id:20 ,lvl:0,type:"char",len:1,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cobtip,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBTIP",gxz:"Z166CobTip",gxold:"O166CobTip",gxvar:"A166CobTip",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A166CobTip=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z166CobTip=Value},v2c:function(){gx.fn.setControlValue("COBTIP",gx.O.A166CobTip,0)},c2v:function(){if(this.val()!==undefined)gx.O.A166CobTip=this.val()},val:function(){return gx.fn.getControlValue("COBTIP")},nac:gx.falseFn};
   GXValidFnc[23]={ id: 23, fld:"TEXTBLOCK2", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[25]={ id:25 ,lvl:0,type:"char",len:12,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cobcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBCOD",gxz:"Z167CobCod",gxold:"O167CobCod",gxvar:"A167CobCod",ucs:[],op:[86],ip:[86,25,20],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A167CobCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z167CobCod=Value},v2c:function(){gx.fn.setControlValue("COBCOD",gx.O.A167CobCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A167CobCod=this.val()},val:function(){return gx.fn.getControlValue("COBCOD")},nac:gx.falseFn};
   GXValidFnc[28]={ id: 28, fld:"TEXTBLOCK3", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[30]={ id:30 ,lvl:0,type:"int",len:5,dec:0,sign:false,pic:"ZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Item,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ITEM",gxz:"Z173Item",gxold:"O173Item",gxvar:"A173Item",ucs:[],op:[101,51,46,61,96,91,81,76,71,66],ip:[101,51,46,61,96,91,81,76,71,66,30,25,20],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A173Item=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z173Item=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("ITEM",gx.O.A173Item,0)},c2v:function(){if(this.val()!==undefined)gx.O.A173Item=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("ITEM",',')},nac:gx.falseFn};
   GXValidFnc[31]={ id: 31, fld:"BTN_GET",grid:0,evt:"e182h85_client",std:"GET"};
   GXValidFnc[34]={ id: 34, fld:"TEXTBLOCK4", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[36]={ id:36 ,lvl:0,type:"char",len:20,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBCLICOD",gxz:"Z645CobCliCod",gxold:"O645CobCliCod",gxvar:"A645CobCliCod",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A645CobCliCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z645CobCliCod=Value},v2c:function(){gx.fn.setControlValue("COBCLICOD",gx.O.A645CobCliCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A645CobCliCod=this.val()},val:function(){return gx.fn.getControlValue("COBCLICOD")},nac:gx.falseFn};
   GXValidFnc[39]={ id: 39, fld:"TEXTBLOCK5", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[41]={ id:41 ,lvl:0,type:"char",len:100,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBCLIDSC",gxz:"Z646CobCliDsc",gxold:"O646CobCliDsc",gxvar:"A646CobCliDsc",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A646CobCliDsc=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z646CobCliDsc=Value},v2c:function(){gx.fn.setControlValue("COBCLIDSC",gx.O.A646CobCliDsc,0)},c2v:function(){if(this.val()!==undefined)gx.O.A646CobCliDsc=this.val()},val:function(){return gx.fn.getControlValue("COBCLIDSC")},nac:gx.falseFn};
   GXValidFnc[44]={ id: 44, fld:"TEXTBLOCK6", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[46]={ id:46 ,lvl:0,type:"char",len:3,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cobtipcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBTIPCOD",gxz:"Z175CobTipCod",gxold:"O175CobTipCod",gxvar:"A175CobTipCod",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A175CobTipCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z175CobTipCod=Value},v2c:function(){gx.fn.setControlValue("COBTIPCOD",gx.O.A175CobTipCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A175CobTipCod=this.val()},val:function(){return gx.fn.getControlValue("COBTIPCOD")},nac:gx.falseFn};
   GXValidFnc[49]={ id: 49, fld:"TEXTBLOCK7", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[51]={ id:51 ,lvl:0,type:"char",len:12,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cobdocnum,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBDOCNUM",gxz:"Z176CobDocNum",gxold:"O176CobDocNum",gxvar:"A176CobDocNum",ucs:[],op:[56,36,41],ip:[56,36,41,51,46],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A176CobDocNum=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z176CobDocNum=Value},v2c:function(){gx.fn.setControlValue("COBDOCNUM",gx.O.A176CobDocNum,0)},c2v:function(){if(this.val()!==undefined)gx.O.A176CobDocNum=this.val()},val:function(){return gx.fn.getControlValue("COBDOCNUM")},nac:gx.falseFn};
   GXValidFnc[54]={ id: 54, fld:"TEXTBLOCK8", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[56]={ id:56 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBMONORIGEN",gxz:"Z658CobMonOrigen",gxold:"O658CobMonOrigen",gxvar:"A658CobMonOrigen",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A658CobMonOrigen=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z658CobMonOrigen=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("COBMONORIGEN",gx.O.A658CobMonOrigen,0)},c2v:function(){if(this.val()!==undefined)gx.O.A658CobMonOrigen=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("COBMONORIGEN",',')},nac:gx.falseFn};
   GXValidFnc[59]={ id: 59, fld:"TEXTBLOCK9", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[61]={ id:61 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Forcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FORCOD",gxz:"Z143ForCod",gxold:"O143ForCod",gxvar:"A143ForCod",ucs:[],op:[],ip:[61],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A143ForCod=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z143ForCod=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("FORCOD",gx.O.A143ForCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A143ForCod=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("FORCOD",',')},nac:gx.falseFn};
   GXValidFnc[64]={ id: 64, fld:"TEXTBLOCK10", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[66]={ id:66 ,lvl:0,type:"char",len:20,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBREF",gxz:"Z659CobRef",gxold:"O659CobRef",gxvar:"A659CobRef",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A659CobRef=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z659CobRef=Value},v2c:function(){gx.fn.setControlValue("COBREF",gx.O.A659CobRef,0)},c2v:function(){if(this.val()!==undefined)gx.O.A659CobRef=this.val()},val:function(){return gx.fn.getControlValue("COBREF")},nac:gx.falseFn};
   GXValidFnc[69]={ id: 69, fld:"TEXTBLOCK11", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[71]={ id:71 ,lvl:0,type:"decimal",len:15,dec:5,sign:false,pic:"ZZZZZZZZ9.99999",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBTIPCAM",gxz:"Z663CobTipCam",gxold:"O663CobTipCam",gxvar:"A663CobTipCam",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A663CobTipCam=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z663CobTipCam=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("COBTIPCAM",gx.O.A663CobTipCam,5,'.')},c2v:function(){if(this.val()!==undefined)gx.O.A663CobTipCam=this.val()},val:function(){return gx.fn.getDecimalValue("COBTIPCAM",',','.')},nac:gx.falseFn};
   GXValidFnc[74]={ id: 74, fld:"TEXTBLOCK12", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[76]={ id:76 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBDTOT",gxz:"Z654CobDTot",gxold:"O654CobDTot",gxvar:"A654CobDTot",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A654CobDTot=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z654CobDTot=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("COBDTOT",gx.O.A654CobDTot,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A654CobDTot=this.val()},val:function(){return gx.fn.getDecimalValue("COBDTOT",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 76 , function() {
   });
   GXValidFnc[79]={ id: 79, fld:"TEXTBLOCK13", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[81]={ id:81 ,lvl:0,type:"char",len:10,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBDCANJE",gxz:"Z647CobDCanje",gxold:"O647CobDCanje",gxvar:"A647CobDCanje",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A647CobDCanje=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z647CobDCanje=Value},v2c:function(){gx.fn.setControlValue("COBDCANJE",gx.O.A647CobDCanje,0)},c2v:function(){if(this.val()!==undefined)gx.O.A647CobDCanje=this.val()},val:function(){return gx.fn.getControlValue("COBDCANJE")},nac:gx.falseFn};
   GXValidFnc[84]={ id: 84, fld:"TEXTBLOCK14", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[86]={ id:86 ,lvl:0,type:"int",len:1,dec:0,sign:false,pic:"9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBAFECTA",gxz:"Z643CobAfecta",gxold:"O643CobAfecta",gxvar:"A643CobAfecta",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A643CobAfecta=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z643CobAfecta=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("COBAFECTA",gx.O.A643CobAfecta,0)},c2v:function(){if(this.val()!==undefined)gx.O.A643CobAfecta=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("COBAFECTA",',')},nac:gx.falseFn};
   GXValidFnc[89]={ id: 89, fld:"TEXTBLOCK15", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[91]={ id:91 ,lvl:0,type:"char",len:20,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBDRECIBO",gxz:"Z649CobDRecibo",gxold:"O649CobDRecibo",gxvar:"A649CobDRecibo",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A649CobDRecibo=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z649CobDRecibo=Value},v2c:function(){gx.fn.setControlValue("COBDRECIBO",gx.O.A649CobDRecibo,0)},c2v:function(){if(this.val()!==undefined)gx.O.A649CobDRecibo=this.val()},val:function(){return gx.fn.getControlValue("COBDRECIBO")},nac:gx.falseFn};
   GXValidFnc[94]={ id: 94, fld:"TEXTBLOCK16", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[96]={ id:96 ,lvl:0,type:"date",len:8,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cobdfdif,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBDFDIF",gxz:"Z648CobDFDif",gxold:"O648CobDFDif",gxvar:"A648CobDFDif",dp:{f:0,st:false,wn:false,mf:false,pic:"99/99/99",dec:0},ucs:[],op:[96],ip:[96],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A648CobDFDif=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z648CobDFDif=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("COBDFDIF",gx.O.A648CobDFDif,0)},c2v:function(){if(this.val()!==undefined)gx.O.A648CobDFDif=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getControlValue("COBDFDIF")},nac:gx.falseFn};
   GXValidFnc[99]={ id: 99, fld:"TEXTBLOCK17", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[101]={ id:101 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cobdbancod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COBDBANCOD",gxz:"Z174CobDBanCod",gxold:"O174CobDBanCod",gxvar:"A174CobDBanCod",ucs:[],op:[],ip:[101],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A174CobDBanCod=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z174CobDBanCod=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("COBDBANCOD",gx.O.A174CobDBanCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A174CobDBanCod=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("COBDBANCOD",',')},nac:gx.falseFn};
   GXValidFnc[104]={ id: 104, fld:"BTN_ENTER",grid:0,evt:"e112h85_client",std:"ENTER"};
   GXValidFnc[105]={ id: 105, fld:"BTN_CHECK",grid:0,evt:"e192h85_client",std:"CHECK"};
   GXValidFnc[106]={ id: 106, fld:"BTN_CANCEL",grid:0,evt:"e122h85_client"};
   GXValidFnc[107]={ id: 107, fld:"BTN_DELETE",grid:0,evt:"e202h85_client",std:"DELETE"};
   GXValidFnc[108]={ id: 108, fld:"BTN_HELP",grid:0,evt:"e212h85_client"};
   this.A166CobTip = "" ;
   this.Z166CobTip = "" ;
   this.O166CobTip = "" ;
   this.A167CobCod = "" ;
   this.Z167CobCod = "" ;
   this.O167CobCod = "" ;
   this.A173Item = 0 ;
   this.Z173Item = 0 ;
   this.O173Item = 0 ;
   this.A645CobCliCod = "" ;
   this.Z645CobCliCod = "" ;
   this.O645CobCliCod = "" ;
   this.A646CobCliDsc = "" ;
   this.Z646CobCliDsc = "" ;
   this.O646CobCliDsc = "" ;
   this.A175CobTipCod = "" ;
   this.Z175CobTipCod = "" ;
   this.O175CobTipCod = "" ;
   this.A176CobDocNum = "" ;
   this.Z176CobDocNum = "" ;
   this.O176CobDocNum = "" ;
   this.A658CobMonOrigen = 0 ;
   this.Z658CobMonOrigen = 0 ;
   this.O658CobMonOrigen = 0 ;
   this.A143ForCod = 0 ;
   this.Z143ForCod = 0 ;
   this.O143ForCod = 0 ;
   this.A659CobRef = "" ;
   this.Z659CobRef = "" ;
   this.O659CobRef = "" ;
   this.A663CobTipCam = 0 ;
   this.Z663CobTipCam = 0 ;
   this.O663CobTipCam = 0 ;
   this.A654CobDTot = 0 ;
   this.Z654CobDTot = 0 ;
   this.O654CobDTot = 0 ;
   this.A647CobDCanje = "" ;
   this.Z647CobDCanje = "" ;
   this.O647CobDCanje = "" ;
   this.A643CobAfecta = 0 ;
   this.Z643CobAfecta = 0 ;
   this.O643CobAfecta = 0 ;
   this.A649CobDRecibo = "" ;
   this.Z649CobDRecibo = "" ;
   this.O649CobDRecibo = "" ;
   this.A648CobDFDif = gx.date.nullDate() ;
   this.Z648CobDFDif = gx.date.nullDate() ;
   this.O648CobDFDif = gx.date.nullDate() ;
   this.A174CobDBanCod = 0 ;
   this.Z174CobDBanCod = 0 ;
   this.O174CobDBanCod = 0 ;
   this.A166CobTip = "" ;
   this.A167CobCod = "" ;
   this.A173Item = 0 ;
   this.A645CobCliCod = "" ;
   this.A646CobCliDsc = "" ;
   this.A175CobTipCod = "" ;
   this.A176CobDocNum = "" ;
   this.A658CobMonOrigen = 0 ;
   this.A143ForCod = 0 ;
   this.A659CobRef = "" ;
   this.A663CobTipCam = 0 ;
   this.A654CobDTot = 0 ;
   this.A647CobDCanje = "" ;
   this.A643CobAfecta = 0 ;
   this.A649CobDRecibo = "" ;
   this.A648CobDFDif = gx.date.nullDate() ;
   this.A174CobDBanCod = 0 ;
   this.A650CobDRef1 = "" ;
   this.A651CobDRef2 = "" ;
   this.A652CobDRef3 = "" ;
   this.A653CobDRef4 = "" ;
   this.Events = {"e112h85_client": ["ENTER", true] ,"e122h85_client": ["CANCEL", true]};
   this.EvtParms["ENTER"] = [[{postForm:true}],[]];
   this.EvtParms["REFRESH"] = [[{av:'A650CobDRef1',fld:'COBDREF1',pic:''},{av:'A651CobDRef2',fld:'COBDREF2',pic:''},{av:'A652CobDRef3',fld:'COBDREF3',pic:''},{av:'A653CobDRef4',fld:'COBDREF4',pic:''}],[]];
   this.EvtParms["VALID_COBTIP"] = [[],[]];
   this.EvtParms["VALID_COBCOD"] = [[{av:'A166CobTip',fld:'COBTIP',pic:''},{av:'A167CobCod',fld:'COBCOD',pic:''},{av:'A643CobAfecta',fld:'COBAFECTA',pic:'9'}],[{av:'A643CobAfecta',fld:'COBAFECTA',pic:'9'}]];
   this.EvtParms["VALID_ITEM"] = [[{av:'A653CobDRef4',fld:'COBDREF4',pic:''},{av:'A652CobDRef3',fld:'COBDREF3',pic:''},{av:'A651CobDRef2',fld:'COBDREF2',pic:''},{av:'A650CobDRef1',fld:'COBDREF1',pic:''},{av:'A166CobTip',fld:'COBTIP',pic:''},{av:'A167CobCod',fld:'COBCOD',pic:''},{av:'A173Item',fld:'ITEM',pic:'ZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}],[{av:'A175CobTipCod',fld:'COBTIPCOD',pic:''},{av:'A176CobDocNum',fld:'COBDOCNUM',pic:''},{av:'A143ForCod',fld:'FORCOD',pic:'ZZZZZ9'},{av:'A659CobRef',fld:'COBREF',pic:''},{av:'A663CobTipCam',fld:'COBTIPCAM',pic:'ZZZZZZZZ9.99999'},{av:'A654CobDTot',fld:'COBDTOT',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A647CobDCanje',fld:'COBDCANJE',pic:''},{av:'A649CobDRecibo',fld:'COBDRECIBO',pic:''},{av:'A648CobDFDif',fld:'COBDFDIF',pic:''},{av:'A174CobDBanCod',fld:'COBDBANCOD',pic:'ZZZZZ9'},{av:'A650CobDRef1',fld:'COBDREF1',pic:''},{av:'A651CobDRef2',fld:'COBDREF2',pic:''},{av:'A652CobDRef3',fld:'COBDREF3',pic:''},{av:'A653CobDRef4',fld:'COBDREF4',pic:''},{av:'A643CobAfecta',fld:'COBAFECTA',pic:'9'},{av:'A646CobCliDsc',fld:'COBCLIDSC',pic:''},{av:'A645CobCliCod',fld:'COBCLICOD',pic:''},{av:'A658CobMonOrigen',fld:'COBMONORIGEN',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z166CobTip'},{av:'Z167CobCod'},{av:'Z173Item'},{av:'Z175CobTipCod'},{av:'Z176CobDocNum'},{av:'Z143ForCod'},{av:'Z659CobRef'},{av:'Z663CobTipCam'},{av:'Z654CobDTot'},{av:'Z647CobDCanje'},{av:'Z649CobDRecibo'},{av:'Z648CobDFDif'},{av:'Z174CobDBanCod'},{av:'Z650CobDRef1'},{av:'Z651CobDRef2'},{av:'Z652CobDRef3'},{av:'Z653CobDRef4'},{av:'Z643CobAfecta'},{av:'Z646CobCliDsc'},{av:'Z645CobCliCod'},{av:'Z658CobMonOrigen'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]];
   this.EvtParms["VALID_COBTIPCOD"] = [[],[]];
   this.EvtParms["VALID_COBDOCNUM"] = [[{av:'A175CobTipCod',fld:'COBTIPCOD',pic:''},{av:'A176CobDocNum',fld:'COBDOCNUM',pic:''},{av:'A646CobCliDsc',fld:'COBCLIDSC',pic:''},{av:'A645CobCliCod',fld:'COBCLICOD',pic:''},{av:'A658CobMonOrigen',fld:'COBMONORIGEN',pic:'ZZZZZ9'}],[{av:'A646CobCliDsc',fld:'COBCLIDSC',pic:''},{av:'A645CobCliCod',fld:'COBCLICOD',pic:''},{av:'A658CobMonOrigen',fld:'COBMONORIGEN',pic:'ZZZZZ9'}]];
   this.EvtParms["VALID_FORCOD"] = [[{av:'A143ForCod',fld:'FORCOD',pic:'ZZZZZ9'}],[]];
   this.EvtParms["VALID_COBDFDIF"] = [[{av:'A648CobDFDif',fld:'COBDFDIF',pic:''}],[{av:'A648CobDFDif',fld:'COBDFDIF',pic:''}]];
   this.EvtParms["VALID_COBDBANCOD"] = [[{av:'A174CobDBanCod',fld:'COBDBANCOD',pic:'ZZZZZ9'}],[]];
   this.EnterCtrl = ["BTN_ENTER"];
   this.CheckCtrl = ["BTN_CHECK"];
   this.setVCMap("A650CobDRef1", "COBDREF1", 0, "svchar", 20, 0);
   this.setVCMap("A651CobDRef2", "COBDREF2", 0, "svchar", 20, 0);
   this.setVCMap("A652CobDRef3", "COBDREF3", 0, "svchar", 20, 0);
   this.setVCMap("A653CobDRef4", "COBDREF4", 0, "svchar", 20, 0);
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(this.clcobranzadet);});
