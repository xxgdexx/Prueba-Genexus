gx.evt.autoSkip = false;
gx.define('cpchequediferido', false, function () {
   this.ServerClass =  "cpchequediferido" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.ServerFullClass =  "cpchequediferido.aspx" ;
   this.setObjectType("trn");
   this.hasEnterEvent = true;
   this.skipOnEnter = false;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
   };
   this.Valid_Cheqdcod=function()
   {
      return this.validSrvEvt("Valid_Cheqdcod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Cheqdprvcod=function()
   {
      return this.validSrvEvt("Valid_Cheqdprvcod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Cheqdfec=function()
   {
      return this.validCliEvt("Valid_Cheqdfec", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("CHEQDFEC");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A524CheqDFec)==0) || new gx.date.gxdate( this.A524CheqDFec ).compare( gx.date.ymdtod( 1753, 1, 1) ) >= 0 ) )
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
   this.Valid_Cheqdmoncod=function()
   {
      return this.validSrvEvt("Valid_Cheqdmoncod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Cheqdusufec=function()
   {
      return this.validCliEvt("Valid_Cheqdusufec", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("CHEQDUSUFEC");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A537CheqDUsuFec)==0) || new gx.date.gxdate( this.A537CheqDUsuFec ).compare( gx.date.ymdhmstot( 1753, 1, 1, 0, 0, 0) ) >= 0 ) )
         {
            try {
               gxballoon.setError("Campo Fecha Hora fuera de rango");
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
   this.e110d14_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e120d14_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100,101,102,103,104,105,106,107];
   this.GXLastCtrlId =107;
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
   GXValidFnc[12]={ id: 12, fld:"BTN_FIRST",grid:0,evt:"e130d14_client",std:"FIRST"};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"BTN_PREVIOUS",grid:0,evt:"e140d14_client",std:"PREVIOUS"};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id: 16, fld:"BTN_NEXT",grid:0,evt:"e150d14_client",std:"NEXT"};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"BTN_LAST",grid:0,evt:"e160d14_client",std:"LAST"};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"BTN_SELECT",grid:0,evt:"e170d14_client",std:"SELECT"};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[26]={ id: 26, fld:"",grid:0};
   GXValidFnc[27]={ id: 27, fld:"",grid:0};
   GXValidFnc[28]={ id:28 ,lvl:0,type:"char",len:10,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cheqdcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHEQDCOD",gxz:"Z238CheqDCod",gxold:"O238CheqDCod",gxvar:"A238CheqDCod",ucs:[],op:[63,33,98,93,88,83,78,73,68,58,53,48,43],ip:[63,33,98,93,88,83,78,73,68,58,53,48,43,28],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A238CheqDCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z238CheqDCod=Value},v2c:function(){gx.fn.setControlValue("CHEQDCOD",gx.O.A238CheqDCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A238CheqDCod=this.val()},val:function(){return gx.fn.getControlValue("CHEQDCOD")},nac:gx.falseFn};
   GXValidFnc[29]={ id: 29, fld:"",grid:0};
   GXValidFnc[30]={ id: 30, fld:"",grid:0};
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   GXValidFnc[32]={ id: 32, fld:"",grid:0};
   GXValidFnc[33]={ id:33 ,lvl:0,type:"char",len:20,dec:0,sign:false,pic:"@!",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cheqdprvcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHEQDPRVCOD",gxz:"Z240CheqDPrvCod",gxold:"O240CheqDPrvCod",gxvar:"A240CheqDPrvCod",ucs:[],op:[38],ip:[38,33],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A240CheqDPrvCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z240CheqDPrvCod=Value},v2c:function(){gx.fn.setControlValue("CHEQDPRVCOD",gx.O.A240CheqDPrvCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A240CheqDPrvCod=this.val()},val:function(){return gx.fn.getControlValue("CHEQDPRVCOD")},nac:gx.falseFn};
   GXValidFnc[34]={ id: 34, fld:"",grid:0};
   GXValidFnc[35]={ id: 35, fld:"",grid:0};
   GXValidFnc[36]={ id: 36, fld:"",grid:0};
   GXValidFnc[37]={ id: 37, fld:"",grid:0};
   GXValidFnc[38]={ id:38 ,lvl:0,type:"char",len:100,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHEQDPRVDSC",gxz:"Z531CheqDPrvDsc",gxold:"O531CheqDPrvDsc",gxvar:"A531CheqDPrvDsc",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A531CheqDPrvDsc=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z531CheqDPrvDsc=Value},v2c:function(){gx.fn.setControlValue("CHEQDPRVDSC",gx.O.A531CheqDPrvDsc,0)},c2v:function(){if(this.val()!==undefined)gx.O.A531CheqDPrvDsc=this.val()},val:function(){return gx.fn.getControlValue("CHEQDPRVDSC")},nac:gx.falseFn};
   GXValidFnc[39]={ id: 39, fld:"",grid:0};
   GXValidFnc[40]={ id: 40, fld:"",grid:0};
   GXValidFnc[41]={ id: 41, fld:"",grid:0};
   GXValidFnc[42]={ id: 42, fld:"",grid:0};
   GXValidFnc[43]={ id:43 ,lvl:0,type:"date",len:8,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cheqdfec,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHEQDFEC",gxz:"Z524CheqDFec",gxold:"O524CheqDFec",gxvar:"A524CheqDFec",dp:{f:0,st:false,wn:false,mf:false,pic:"99/99/99",dec:0},ucs:[],op:[43],ip:[43],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A524CheqDFec=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z524CheqDFec=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("CHEQDFEC",gx.O.A524CheqDFec,0)},c2v:function(){if(this.val()!==undefined)gx.O.A524CheqDFec=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getControlValue("CHEQDFEC")},nac:gx.falseFn};
   GXValidFnc[44]={ id: 44, fld:"",grid:0};
   GXValidFnc[45]={ id: 45, fld:"",grid:0};
   GXValidFnc[46]={ id: 46, fld:"",grid:0};
   GXValidFnc[47]={ id: 47, fld:"",grid:0};
   GXValidFnc[48]={ id:48 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHEQDFORCOD",gxz:"Z527CheqDForCod",gxold:"O527CheqDForCod",gxvar:"A527CheqDForCod",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A527CheqDForCod=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z527CheqDForCod=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("CHEQDFORCOD",gx.O.A527CheqDForCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A527CheqDForCod=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("CHEQDFORCOD",',')},nac:gx.falseFn};
   GXValidFnc[49]={ id: 49, fld:"",grid:0};
   GXValidFnc[50]={ id: 50, fld:"",grid:0};
   GXValidFnc[51]={ id: 51, fld:"",grid:0};
   GXValidFnc[52]={ id: 52, fld:"",grid:0};
   GXValidFnc[53]={ id:53 ,lvl:0,type:"decimal",len:15,dec:5,sign:false,pic:"ZZZZZZZZ9.99999",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHEQDTIPCMB",gxz:"Z534CheqDTipCmb",gxold:"O534CheqDTipCmb",gxvar:"A534CheqDTipCmb",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A534CheqDTipCmb=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z534CheqDTipCmb=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("CHEQDTIPCMB",gx.O.A534CheqDTipCmb,5,'.')},c2v:function(){if(this.val()!==undefined)gx.O.A534CheqDTipCmb=this.val()},val:function(){return gx.fn.getDecimalValue("CHEQDTIPCMB",',','.')},nac:gx.falseFn};
   GXValidFnc[54]={ id: 54, fld:"",grid:0};
   GXValidFnc[55]={ id: 55, fld:"",grid:0};
   GXValidFnc[56]={ id: 56, fld:"",grid:0};
   GXValidFnc[57]={ id: 57, fld:"",grid:0};
   GXValidFnc[58]={ id:58 ,lvl:0,type:"char",len:1,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHEQDSTS",gxz:"Z532CheqDSts",gxold:"O532CheqDSts",gxvar:"A532CheqDSts",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A532CheqDSts=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z532CheqDSts=Value},v2c:function(){gx.fn.setControlValue("CHEQDSTS",gx.O.A532CheqDSts,0)},c2v:function(){if(this.val()!==undefined)gx.O.A532CheqDSts=this.val()},val:function(){return gx.fn.getControlValue("CHEQDSTS")},nac:gx.falseFn};
   GXValidFnc[59]={ id: 59, fld:"",grid:0};
   GXValidFnc[60]={ id: 60, fld:"",grid:0};
   GXValidFnc[61]={ id: 61, fld:"",grid:0};
   GXValidFnc[62]={ id: 62, fld:"",grid:0};
   GXValidFnc[63]={ id:63 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cheqdmoncod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHEQDMONCOD",gxz:"Z239CheqDMonCod",gxold:"O239CheqDMonCod",gxvar:"A239CheqDMonCod",ucs:[],op:[],ip:[63],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A239CheqDMonCod=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z239CheqDMonCod=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("CHEQDMONCOD",gx.O.A239CheqDMonCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A239CheqDMonCod=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("CHEQDMONCOD",',')},nac:gx.falseFn};
   GXValidFnc[64]={ id: 64, fld:"",grid:0};
   GXValidFnc[65]={ id: 65, fld:"",grid:0};
   GXValidFnc[66]={ id: 66, fld:"",grid:0};
   GXValidFnc[67]={ id: 67, fld:"",grid:0};
   GXValidFnc[68]={ id:68 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHEQDIMPORTE",gxz:"Z529CheqDImporte",gxold:"O529CheqDImporte",gxvar:"A529CheqDImporte",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A529CheqDImporte=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z529CheqDImporte=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("CHEQDIMPORTE",gx.O.A529CheqDImporte,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A529CheqDImporte=this.val()},val:function(){return gx.fn.getDecimalValue("CHEQDIMPORTE",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 68 , function() {
   });
   GXValidFnc[69]={ id: 69, fld:"",grid:0};
   GXValidFnc[70]={ id: 70, fld:"",grid:0};
   GXValidFnc[71]={ id: 71, fld:"",grid:0};
   GXValidFnc[72]={ id: 72, fld:"",grid:0};
   GXValidFnc[73]={ id:73 ,lvl:0,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHEQDVOUANO",gxz:"Z538CheqDVouAno",gxold:"O538CheqDVouAno",gxvar:"A538CheqDVouAno",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A538CheqDVouAno=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z538CheqDVouAno=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("CHEQDVOUANO",gx.O.A538CheqDVouAno,0)},c2v:function(){if(this.val()!==undefined)gx.O.A538CheqDVouAno=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("CHEQDVOUANO",',')},nac:gx.falseFn};
   GXValidFnc[74]={ id: 74, fld:"",grid:0};
   GXValidFnc[75]={ id: 75, fld:"",grid:0};
   GXValidFnc[76]={ id: 76, fld:"",grid:0};
   GXValidFnc[77]={ id: 77, fld:"",grid:0};
   GXValidFnc[78]={ id:78 ,lvl:0,type:"int",len:2,dec:0,sign:false,pic:"Z9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHEQDVOUMES",gxz:"Z539CheqDVouMes",gxold:"O539CheqDVouMes",gxvar:"A539CheqDVouMes",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A539CheqDVouMes=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z539CheqDVouMes=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("CHEQDVOUMES",gx.O.A539CheqDVouMes,0)},c2v:function(){if(this.val()!==undefined)gx.O.A539CheqDVouMes=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("CHEQDVOUMES",',')},nac:gx.falseFn};
   GXValidFnc[79]={ id: 79, fld:"",grid:0};
   GXValidFnc[80]={ id: 80, fld:"",grid:0};
   GXValidFnc[81]={ id: 81, fld:"",grid:0};
   GXValidFnc[82]={ id: 82, fld:"",grid:0};
   GXValidFnc[83]={ id:83 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHEQDTASICOD",gxz:"Z533CheqDTasiCod",gxold:"O533CheqDTasiCod",gxvar:"A533CheqDTasiCod",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A533CheqDTasiCod=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z533CheqDTasiCod=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("CHEQDTASICOD",gx.O.A533CheqDTasiCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A533CheqDTasiCod=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("CHEQDTASICOD",',')},nac:gx.falseFn};
   GXValidFnc[84]={ id: 84, fld:"",grid:0};
   GXValidFnc[85]={ id: 85, fld:"",grid:0};
   GXValidFnc[86]={ id: 86, fld:"",grid:0};
   GXValidFnc[87]={ id: 87, fld:"",grid:0};
   GXValidFnc[88]={ id:88 ,lvl:0,type:"char",len:10,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHEQDVOUNUM",gxz:"Z540CheqDVouNum",gxold:"O540CheqDVouNum",gxvar:"A540CheqDVouNum",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A540CheqDVouNum=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z540CheqDVouNum=Value},v2c:function(){gx.fn.setControlValue("CHEQDVOUNUM",gx.O.A540CheqDVouNum,0)},c2v:function(){if(this.val()!==undefined)gx.O.A540CheqDVouNum=this.val()},val:function(){return gx.fn.getControlValue("CHEQDVOUNUM")},nac:gx.falseFn};
   GXValidFnc[89]={ id: 89, fld:"",grid:0};
   GXValidFnc[90]={ id: 90, fld:"",grid:0};
   GXValidFnc[91]={ id: 91, fld:"",grid:0};
   GXValidFnc[92]={ id: 92, fld:"",grid:0};
   GXValidFnc[93]={ id:93 ,lvl:0,type:"char",len:10,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHEQDUSUCOD",gxz:"Z536CheqDUsuCod",gxold:"O536CheqDUsuCod",gxvar:"A536CheqDUsuCod",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A536CheqDUsuCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z536CheqDUsuCod=Value},v2c:function(){gx.fn.setControlValue("CHEQDUSUCOD",gx.O.A536CheqDUsuCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A536CheqDUsuCod=this.val()},val:function(){return gx.fn.getControlValue("CHEQDUSUCOD")},nac:gx.falseFn};
   GXValidFnc[94]={ id: 94, fld:"",grid:0};
   GXValidFnc[95]={ id: 95, fld:"",grid:0};
   GXValidFnc[96]={ id: 96, fld:"",grid:0};
   GXValidFnc[97]={ id: 97, fld:"",grid:0};
   GXValidFnc[98]={ id:98 ,lvl:0,type:"dtime",len:8,dec:5,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cheqdusufec,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHEQDUSUFEC",gxz:"Z537CheqDUsuFec",gxold:"O537CheqDUsuFec",gxvar:"A537CheqDUsuFec",dp:{f:0,st:true,wn:false,mf:false,pic:"99/99/99 99:99",dec:5},ucs:[],op:[98],ip:[98],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A537CheqDUsuFec=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z537CheqDUsuFec=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("CHEQDUSUFEC",gx.O.A537CheqDUsuFec,0)},c2v:function(){if(this.val()!==undefined)gx.O.A537CheqDUsuFec=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getDateTimeValue("CHEQDUSUFEC")},nac:gx.falseFn};
   GXValidFnc[99]={ id: 99, fld:"",grid:0};
   GXValidFnc[100]={ id: 100, fld:"",grid:0};
   GXValidFnc[101]={ id: 101, fld:"",grid:0};
   GXValidFnc[102]={ id: 102, fld:"",grid:0};
   GXValidFnc[103]={ id: 103, fld:"BTN_ENTER",grid:0,evt:"e110d14_client",std:"ENTER"};
   GXValidFnc[104]={ id: 104, fld:"",grid:0};
   GXValidFnc[105]={ id: 105, fld:"BTN_CANCEL",grid:0,evt:"e120d14_client"};
   GXValidFnc[106]={ id: 106, fld:"",grid:0};
   GXValidFnc[107]={ id: 107, fld:"BTN_DELETE",grid:0,evt:"e180d14_client",std:"DELETE"};
   this.A238CheqDCod = "" ;
   this.Z238CheqDCod = "" ;
   this.O238CheqDCod = "" ;
   this.A240CheqDPrvCod = "" ;
   this.Z240CheqDPrvCod = "" ;
   this.O240CheqDPrvCod = "" ;
   this.A531CheqDPrvDsc = "" ;
   this.Z531CheqDPrvDsc = "" ;
   this.O531CheqDPrvDsc = "" ;
   this.A524CheqDFec = gx.date.nullDate() ;
   this.Z524CheqDFec = gx.date.nullDate() ;
   this.O524CheqDFec = gx.date.nullDate() ;
   this.A527CheqDForCod = 0 ;
   this.Z527CheqDForCod = 0 ;
   this.O527CheqDForCod = 0 ;
   this.A534CheqDTipCmb = 0 ;
   this.Z534CheqDTipCmb = 0 ;
   this.O534CheqDTipCmb = 0 ;
   this.A532CheqDSts = "" ;
   this.Z532CheqDSts = "" ;
   this.O532CheqDSts = "" ;
   this.A239CheqDMonCod = 0 ;
   this.Z239CheqDMonCod = 0 ;
   this.O239CheqDMonCod = 0 ;
   this.A529CheqDImporte = 0 ;
   this.Z529CheqDImporte = 0 ;
   this.O529CheqDImporte = 0 ;
   this.A538CheqDVouAno = 0 ;
   this.Z538CheqDVouAno = 0 ;
   this.O538CheqDVouAno = 0 ;
   this.A539CheqDVouMes = 0 ;
   this.Z539CheqDVouMes = 0 ;
   this.O539CheqDVouMes = 0 ;
   this.A533CheqDTasiCod = 0 ;
   this.Z533CheqDTasiCod = 0 ;
   this.O533CheqDTasiCod = 0 ;
   this.A540CheqDVouNum = "" ;
   this.Z540CheqDVouNum = "" ;
   this.O540CheqDVouNum = "" ;
   this.A536CheqDUsuCod = "" ;
   this.Z536CheqDUsuCod = "" ;
   this.O536CheqDUsuCod = "" ;
   this.A537CheqDUsuFec = gx.date.nullDate() ;
   this.Z537CheqDUsuFec = gx.date.nullDate() ;
   this.O537CheqDUsuFec = gx.date.nullDate() ;
   this.A238CheqDCod = "" ;
   this.A240CheqDPrvCod = "" ;
   this.A531CheqDPrvDsc = "" ;
   this.A524CheqDFec = gx.date.nullDate() ;
   this.A527CheqDForCod = 0 ;
   this.A534CheqDTipCmb = 0 ;
   this.A532CheqDSts = "" ;
   this.A239CheqDMonCod = 0 ;
   this.A529CheqDImporte = 0 ;
   this.A538CheqDVouAno = 0 ;
   this.A539CheqDVouMes = 0 ;
   this.A533CheqDTasiCod = 0 ;
   this.A540CheqDVouNum = "" ;
   this.A536CheqDUsuCod = "" ;
   this.A537CheqDUsuFec = gx.date.nullDate() ;
   this.Events = {"e110d14_client": ["ENTER", true] ,"e120d14_client": ["CANCEL", true]};
   this.EvtParms["ENTER"] = [[{postForm:true}],[]];
   this.EvtParms["REFRESH"] = [[],[]];
   this.EvtParms["VALID_CHEQDCOD"] = [[{av:'A238CheqDCod',fld:'CHEQDCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}],[{av:'A240CheqDPrvCod',fld:'CHEQDPRVCOD',pic:'@!'},{av:'A524CheqDFec',fld:'CHEQDFEC',pic:''},{av:'A527CheqDForCod',fld:'CHEQDFORCOD',pic:'ZZZZZ9'},{av:'A534CheqDTipCmb',fld:'CHEQDTIPCMB',pic:'ZZZZZZZZ9.99999'},{av:'A532CheqDSts',fld:'CHEQDSTS',pic:''},{av:'A239CheqDMonCod',fld:'CHEQDMONCOD',pic:'ZZZZZ9'},{av:'A529CheqDImporte',fld:'CHEQDIMPORTE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A538CheqDVouAno',fld:'CHEQDVOUANO',pic:'ZZZ9'},{av:'A539CheqDVouMes',fld:'CHEQDVOUMES',pic:'Z9'},{av:'A533CheqDTasiCod',fld:'CHEQDTASICOD',pic:'ZZZZZ9'},{av:'A540CheqDVouNum',fld:'CHEQDVOUNUM',pic:''},{av:'A536CheqDUsuCod',fld:'CHEQDUSUCOD',pic:''},{av:'A537CheqDUsuFec',fld:'CHEQDUSUFEC',pic:'99/99/99 99:99'},{av:'A531CheqDPrvDsc',fld:'CHEQDPRVDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z238CheqDCod'},{av:'Z240CheqDPrvCod'},{av:'Z524CheqDFec'},{av:'Z527CheqDForCod'},{av:'Z534CheqDTipCmb'},{av:'Z532CheqDSts'},{av:'Z239CheqDMonCod'},{av:'Z529CheqDImporte'},{av:'Z538CheqDVouAno'},{av:'Z539CheqDVouMes'},{av:'Z533CheqDTasiCod'},{av:'Z540CheqDVouNum'},{av:'Z536CheqDUsuCod'},{av:'Z537CheqDUsuFec'},{av:'Z531CheqDPrvDsc'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]];
   this.EvtParms["VALID_CHEQDPRVCOD"] = [[{av:'A240CheqDPrvCod',fld:'CHEQDPRVCOD',pic:'@!'},{av:'A531CheqDPrvDsc',fld:'CHEQDPRVDSC',pic:''}],[{av:'A531CheqDPrvDsc',fld:'CHEQDPRVDSC',pic:''}]];
   this.EvtParms["VALID_CHEQDFEC"] = [[{av:'A524CheqDFec',fld:'CHEQDFEC',pic:''}],[{av:'A524CheqDFec',fld:'CHEQDFEC',pic:''}]];
   this.EvtParms["VALID_CHEQDMONCOD"] = [[{av:'A239CheqDMonCod',fld:'CHEQDMONCOD',pic:'ZZZZZ9'}],[]];
   this.EvtParms["VALID_CHEQDUSUFEC"] = [[{av:'A537CheqDUsuFec',fld:'CHEQDUSUFEC',pic:'99/99/99 99:99'}],[{av:'A537CheqDUsuFec',fld:'CHEQDUSUFEC',pic:'99/99/99 99:99'}]];
   this.EnterCtrl = ["BTN_ENTER"];
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(this.cpchequediferido);});
