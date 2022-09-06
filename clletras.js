gx.evt.autoSkip = false;
gx.define('clletras', false, function () {
   this.ServerClass =  "clletras" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.ServerFullClass =  "clletras.aspx" ;
   this.setObjectType("trn");
   this.hasEnterEvent = true;
   this.skipOnEnter = false;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
   };
   this.Valid_Letcletcod=function()
   {
      return this.validSrvEvt("Valid_Letcletcod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Letcclicod=function()
   {
      return this.validSrvEvt("Valid_Letcclicod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Letcletfec=function()
   {
      return this.validCliEvt("Valid_Letcletfec", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("LETCLETFEC");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A1114LetCLetFec)==0) || new gx.date.gxdate( this.A1114LetCLetFec ).compare( gx.date.ymdtod( 1753, 1, 1) ) >= 0 ) )
         {
            try {
               gxballoon.setError("Campo Fecha Canje fuera de rango");
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
   this.Valid_Letcmoncod=function()
   {
      return this.validSrvEvt("Valid_Letcmoncod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Letcusufec=function()
   {
      return this.validCliEvt("Valid_Letcusufec", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("LETCUSUFEC");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A1122LetCUsuFec)==0) || new gx.date.gxdate( this.A1122LetCUsuFec ).compare( gx.date.ymdhmstot( 1753, 1, 1, 0, 0, 0) ) >= 0 ) )
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
   this.e112q93_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e122q93_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,5,6,7,8,9,15,18,20,21,24,26,29,31,34,36,39,41,44,46,49,51,54,56,59,61,64,66,69,71,74,76,79,81,84,86,89,90,91,92,93];
   this.GXLastCtrlId =93;
   GXValidFnc[2]={ id: 2, fld:"TABLE1",grid:0};
   GXValidFnc[5]={ id: 5, fld:"BTN_FIRST",grid:0,evt:"e132q93_client",std:"FIRST"};
   GXValidFnc[6]={ id: 6, fld:"BTN_PREVIOUS",grid:0,evt:"e142q93_client",std:"PREVIOUS"};
   GXValidFnc[7]={ id: 7, fld:"BTN_NEXT",grid:0,evt:"e152q93_client",std:"NEXT"};
   GXValidFnc[8]={ id: 8, fld:"BTN_LAST",grid:0,evt:"e162q93_client",std:"LAST"};
   GXValidFnc[9]={ id: 9, fld:"BTN_SELECT",grid:0,evt:"e172q93_client",std:"SELECT"};
   GXValidFnc[15]={ id: 15, fld:"TABLE2",grid:0};
   GXValidFnc[18]={ id: 18, fld:"TEXTBLOCK1", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[20]={ id:20 ,lvl:0,type:"char",len:10,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Letcletcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LETCLETCOD",gxz:"Z204LetCLetCod",gxold:"O204LetCLetCod",gxvar:"A204LetCLetCod",ucs:[],op:[51,26,86,81,76,71,66,61,56,46,41,36,31],ip:[51,26,86,81,76,71,66,61,56,46,41,36,31,20],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A204LetCLetCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z204LetCLetCod=Value},v2c:function(){gx.fn.setControlValue("LETCLETCOD",gx.O.A204LetCLetCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A204LetCLetCod=this.val()},val:function(){return gx.fn.getControlValue("LETCLETCOD")},nac:gx.falseFn};
   GXValidFnc[21]={ id: 21, fld:"BTN_GET",grid:0,evt:"e182q93_client",std:"GET"};
   GXValidFnc[24]={ id: 24, fld:"TEXTBLOCK2", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[26]={ id:26 ,lvl:0,type:"char",len:20,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Letcclicod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LETCCLICOD",gxz:"Z206LetCCliCod",gxold:"O206LetCCliCod",gxvar:"A206LetCCliCod",ucs:[],op:[],ip:[26],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A206LetCCliCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z206LetCCliCod=Value},v2c:function(){gx.fn.setControlValue("LETCCLICOD",gx.O.A206LetCCliCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A206LetCCliCod=this.val()},val:function(){return gx.fn.getControlValue("LETCCLICOD")},nac:gx.falseFn};
   GXValidFnc[29]={ id: 29, fld:"TEXTBLOCK3", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[31]={ id:31 ,lvl:0,type:"date",len:8,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Letcletfec,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LETCLETFEC",gxz:"Z1114LetCLetFec",gxold:"O1114LetCLetFec",gxvar:"A1114LetCLetFec",dp:{f:0,st:false,wn:false,mf:false,pic:"99/99/99",dec:0},ucs:[],op:[31],ip:[31],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1114LetCLetFec=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1114LetCLetFec=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("LETCLETFEC",gx.O.A1114LetCLetFec,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1114LetCLetFec=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getControlValue("LETCLETFEC")},nac:gx.falseFn};
   GXValidFnc[34]={ id: 34, fld:"TEXTBLOCK4", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[36]={ id:36 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LETCFORCOD",gxz:"Z1110LetCForCod",gxold:"O1110LetCForCod",gxvar:"A1110LetCForCod",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1110LetCForCod=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1110LetCForCod=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("LETCFORCOD",gx.O.A1110LetCForCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1110LetCForCod=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("LETCFORCOD",',')},nac:gx.falseFn};
   GXValidFnc[39]={ id: 39, fld:"TEXTBLOCK5", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[41]={ id:41 ,lvl:0,type:"decimal",len:15,dec:5,sign:false,pic:"ZZZZZZZZ9.99999",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LETCTIPCMB",gxz:"Z1119LetCTipCmb",gxold:"O1119LetCTipCmb",gxvar:"A1119LetCTipCmb",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1119LetCTipCmb=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z1119LetCTipCmb=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("LETCTIPCMB",gx.O.A1119LetCTipCmb,5,'.')},c2v:function(){if(this.val()!==undefined)gx.O.A1119LetCTipCmb=this.val()},val:function(){return gx.fn.getDecimalValue("LETCTIPCMB",',','.')},nac:gx.falseFn};
   GXValidFnc[44]={ id: 44, fld:"TEXTBLOCK6", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[46]={ id:46 ,lvl:0,type:"char",len:1,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LETCSTS",gxz:"Z1117LetCSts",gxold:"O1117LetCSts",gxvar:"A1117LetCSts",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1117LetCSts=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z1117LetCSts=Value},v2c:function(){gx.fn.setControlValue("LETCSTS",gx.O.A1117LetCSts,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1117LetCSts=this.val()},val:function(){return gx.fn.getControlValue("LETCSTS")},nac:gx.falseFn};
   GXValidFnc[49]={ id: 49, fld:"TEXTBLOCK7", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[51]={ id:51 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Letcmoncod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LETCMONCOD",gxz:"Z205LetCMonCod",gxold:"O205LetCMonCod",gxvar:"A205LetCMonCod",ucs:[],op:[],ip:[51],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A205LetCMonCod=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z205LetCMonCod=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("LETCMONCOD",gx.O.A205LetCMonCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A205LetCMonCod=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("LETCMONCOD",',')},nac:gx.falseFn};
   GXValidFnc[54]={ id: 54, fld:"TEXTBLOCK8", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[56]={ id:56 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LETCIMPORTE",gxz:"Z1113LetCImporte",gxold:"O1113LetCImporte",gxvar:"A1113LetCImporte",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1113LetCImporte=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z1113LetCImporte=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("LETCIMPORTE",gx.O.A1113LetCImporte,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A1113LetCImporte=this.val()},val:function(){return gx.fn.getDecimalValue("LETCIMPORTE",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 56 , function() {
   });
   GXValidFnc[59]={ id: 59, fld:"TEXTBLOCK9", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[61]={ id:61 ,lvl:0,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LETCVOUANO",gxz:"Z1124LetCVouAno",gxold:"O1124LetCVouAno",gxvar:"A1124LetCVouAno",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1124LetCVouAno=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1124LetCVouAno=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("LETCVOUANO",gx.O.A1124LetCVouAno,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1124LetCVouAno=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("LETCVOUANO",',')},nac:gx.falseFn};
   GXValidFnc[64]={ id: 64, fld:"TEXTBLOCK10", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[66]={ id:66 ,lvl:0,type:"int",len:2,dec:0,sign:false,pic:"Z9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LETCVOUMES",gxz:"Z1125LetCVouMes",gxold:"O1125LetCVouMes",gxvar:"A1125LetCVouMes",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1125LetCVouMes=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1125LetCVouMes=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("LETCVOUMES",gx.O.A1125LetCVouMes,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1125LetCVouMes=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("LETCVOUMES",',')},nac:gx.falseFn};
   GXValidFnc[69]={ id: 69, fld:"TEXTBLOCK11", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[71]={ id:71 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LETCTASICOD",gxz:"Z1118LetCTasiCod",gxold:"O1118LetCTasiCod",gxvar:"A1118LetCTasiCod",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1118LetCTasiCod=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1118LetCTasiCod=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("LETCTASICOD",gx.O.A1118LetCTasiCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1118LetCTasiCod=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("LETCTASICOD",',')},nac:gx.falseFn};
   GXValidFnc[74]={ id: 74, fld:"TEXTBLOCK12", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[76]={ id:76 ,lvl:0,type:"char",len:10,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LETCVOUNUM",gxz:"Z1126LetCVouNum",gxold:"O1126LetCVouNum",gxvar:"A1126LetCVouNum",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1126LetCVouNum=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z1126LetCVouNum=Value},v2c:function(){gx.fn.setControlValue("LETCVOUNUM",gx.O.A1126LetCVouNum,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1126LetCVouNum=this.val()},val:function(){return gx.fn.getControlValue("LETCVOUNUM")},nac:gx.falseFn};
   GXValidFnc[79]={ id: 79, fld:"TEXTBLOCK13", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[81]={ id:81 ,lvl:0,type:"char",len:10,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LETCUSUCOD",gxz:"Z1121LetCUsuCod",gxold:"O1121LetCUsuCod",gxvar:"A1121LetCUsuCod",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1121LetCUsuCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z1121LetCUsuCod=Value},v2c:function(){gx.fn.setControlValue("LETCUSUCOD",gx.O.A1121LetCUsuCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1121LetCUsuCod=this.val()},val:function(){return gx.fn.getControlValue("LETCUSUCOD")},nac:gx.falseFn};
   GXValidFnc[84]={ id: 84, fld:"TEXTBLOCK14", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[86]={ id:86 ,lvl:0,type:"dtime",len:8,dec:5,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Letcusufec,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LETCUSUFEC",gxz:"Z1122LetCUsuFec",gxold:"O1122LetCUsuFec",gxvar:"A1122LetCUsuFec",dp:{f:0,st:true,wn:false,mf:false,pic:"99/99/99 99:99",dec:5},ucs:[],op:[86],ip:[86],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1122LetCUsuFec=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1122LetCUsuFec=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("LETCUSUFEC",gx.O.A1122LetCUsuFec,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1122LetCUsuFec=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getDateTimeValue("LETCUSUFEC")},nac:gx.falseFn};
   GXValidFnc[89]={ id: 89, fld:"BTN_ENTER",grid:0,evt:"e112q93_client",std:"ENTER"};
   GXValidFnc[90]={ id: 90, fld:"BTN_CHECK",grid:0,evt:"e192q93_client",std:"CHECK"};
   GXValidFnc[91]={ id: 91, fld:"BTN_CANCEL",grid:0,evt:"e122q93_client"};
   GXValidFnc[92]={ id: 92, fld:"BTN_DELETE",grid:0,evt:"e202q93_client",std:"DELETE"};
   GXValidFnc[93]={ id: 93, fld:"BTN_HELP",grid:0,evt:"e212q93_client"};
   this.A204LetCLetCod = "" ;
   this.Z204LetCLetCod = "" ;
   this.O204LetCLetCod = "" ;
   this.A206LetCCliCod = "" ;
   this.Z206LetCCliCod = "" ;
   this.O206LetCCliCod = "" ;
   this.A1114LetCLetFec = gx.date.nullDate() ;
   this.Z1114LetCLetFec = gx.date.nullDate() ;
   this.O1114LetCLetFec = gx.date.nullDate() ;
   this.A1110LetCForCod = 0 ;
   this.Z1110LetCForCod = 0 ;
   this.O1110LetCForCod = 0 ;
   this.A1119LetCTipCmb = 0 ;
   this.Z1119LetCTipCmb = 0 ;
   this.O1119LetCTipCmb = 0 ;
   this.A1117LetCSts = "" ;
   this.Z1117LetCSts = "" ;
   this.O1117LetCSts = "" ;
   this.A205LetCMonCod = 0 ;
   this.Z205LetCMonCod = 0 ;
   this.O205LetCMonCod = 0 ;
   this.A1113LetCImporte = 0 ;
   this.Z1113LetCImporte = 0 ;
   this.O1113LetCImporte = 0 ;
   this.A1124LetCVouAno = 0 ;
   this.Z1124LetCVouAno = 0 ;
   this.O1124LetCVouAno = 0 ;
   this.A1125LetCVouMes = 0 ;
   this.Z1125LetCVouMes = 0 ;
   this.O1125LetCVouMes = 0 ;
   this.A1118LetCTasiCod = 0 ;
   this.Z1118LetCTasiCod = 0 ;
   this.O1118LetCTasiCod = 0 ;
   this.A1126LetCVouNum = "" ;
   this.Z1126LetCVouNum = "" ;
   this.O1126LetCVouNum = "" ;
   this.A1121LetCUsuCod = "" ;
   this.Z1121LetCUsuCod = "" ;
   this.O1121LetCUsuCod = "" ;
   this.A1122LetCUsuFec = gx.date.nullDate() ;
   this.Z1122LetCUsuFec = gx.date.nullDate() ;
   this.O1122LetCUsuFec = gx.date.nullDate() ;
   this.A204LetCLetCod = "" ;
   this.A206LetCCliCod = "" ;
   this.A1114LetCLetFec = gx.date.nullDate() ;
   this.A1110LetCForCod = 0 ;
   this.A1119LetCTipCmb = 0 ;
   this.A1117LetCSts = "" ;
   this.A205LetCMonCod = 0 ;
   this.A1113LetCImporte = 0 ;
   this.A1124LetCVouAno = 0 ;
   this.A1125LetCVouMes = 0 ;
   this.A1118LetCTasiCod = 0 ;
   this.A1126LetCVouNum = "" ;
   this.A1121LetCUsuCod = "" ;
   this.A1122LetCUsuFec = gx.date.nullDate() ;
   this.Events = {"e112q93_client": ["ENTER", true] ,"e122q93_client": ["CANCEL", true]};
   this.EvtParms["ENTER"] = [[{postForm:true}],[]];
   this.EvtParms["REFRESH"] = [[],[]];
   this.EvtParms["VALID_LETCLETCOD"] = [[{av:'A204LetCLetCod',fld:'LETCLETCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}],[{av:'A206LetCCliCod',fld:'LETCCLICOD',pic:''},{av:'A1114LetCLetFec',fld:'LETCLETFEC',pic:''},{av:'A1110LetCForCod',fld:'LETCFORCOD',pic:'ZZZZZ9'},{av:'A1119LetCTipCmb',fld:'LETCTIPCMB',pic:'ZZZZZZZZ9.99999'},{av:'A1117LetCSts',fld:'LETCSTS',pic:''},{av:'A205LetCMonCod',fld:'LETCMONCOD',pic:'ZZZZZ9'},{av:'A1113LetCImporte',fld:'LETCIMPORTE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1124LetCVouAno',fld:'LETCVOUANO',pic:'ZZZ9'},{av:'A1125LetCVouMes',fld:'LETCVOUMES',pic:'Z9'},{av:'A1118LetCTasiCod',fld:'LETCTASICOD',pic:'ZZZZZ9'},{av:'A1126LetCVouNum',fld:'LETCVOUNUM',pic:''},{av:'A1121LetCUsuCod',fld:'LETCUSUCOD',pic:''},{av:'A1122LetCUsuFec',fld:'LETCUSUFEC',pic:'99/99/99 99:99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z204LetCLetCod'},{av:'Z206LetCCliCod'},{av:'Z1114LetCLetFec'},{av:'Z1110LetCForCod'},{av:'Z1119LetCTipCmb'},{av:'Z1117LetCSts'},{av:'Z205LetCMonCod'},{av:'Z1113LetCImporte'},{av:'Z1124LetCVouAno'},{av:'Z1125LetCVouMes'},{av:'Z1118LetCTasiCod'},{av:'Z1126LetCVouNum'},{av:'Z1121LetCUsuCod'},{av:'Z1122LetCUsuFec'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]];
   this.EvtParms["VALID_LETCCLICOD"] = [[{av:'A206LetCCliCod',fld:'LETCCLICOD',pic:''}],[]];
   this.EvtParms["VALID_LETCLETFEC"] = [[{av:'A1114LetCLetFec',fld:'LETCLETFEC',pic:''}],[{av:'A1114LetCLetFec',fld:'LETCLETFEC',pic:''}]];
   this.EvtParms["VALID_LETCMONCOD"] = [[{av:'A205LetCMonCod',fld:'LETCMONCOD',pic:'ZZZZZ9'}],[]];
   this.EvtParms["VALID_LETCUSUFEC"] = [[{av:'A1122LetCUsuFec',fld:'LETCUSUFEC',pic:'99/99/99 99:99'}],[{av:'A1122LetCUsuFec',fld:'LETCUSUFEC',pic:'99/99/99 99:99'}]];
   this.EnterCtrl = ["BTN_ENTER"];
   this.CheckCtrl = ["BTN_CHECK"];
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(this.clletras);});
