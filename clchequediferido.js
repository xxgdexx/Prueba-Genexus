gx.evt.autoSkip = false;
gx.define('clchequediferido', false, function () {
   this.ServerClass =  "clchequediferido" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.ServerFullClass =  "clchequediferido.aspx" ;
   this.setObjectType("trn");
   this.hasEnterEvent = true;
   this.skipOnEnter = false;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
   };
   this.Valid_Clcheqdcod=function()
   {
      return this.validSrvEvt("Valid_Clcheqdcod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Clcheqdclicod=function()
   {
      return this.validSrvEvt("Valid_Clcheqdclicod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Clcheqdfec=function()
   {
      return this.validCliEvt("Valid_Clcheqdfec", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("CLCHEQDFEC");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A558CLCheqDFec)==0) || new gx.date.gxdate( this.A558CLCheqDFec ).compare( gx.date.ymdtod( 1753, 1, 1) ) >= 0 ) )
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
   this.Valid_Clcheqdmoncod=function()
   {
      return this.validSrvEvt("Valid_Clcheqdmoncod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Clcheqdusufec=function()
   {
      return this.validCliEvt("Valid_Clcheqdusufec", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("CLCHEQDUSUFEC");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A569CLCheqDUsuFec)==0) || new gx.date.gxdate( this.A569CLCheqDUsuFec ).compare( gx.date.ymdhmstot( 1753, 1, 1, 0, 0, 0) ) >= 0 ) )
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
   this.e11099_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e12099_client=function()
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
   GXValidFnc[12]={ id: 12, fld:"BTN_FIRST",grid:0,evt:"e13099_client",std:"FIRST"};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"BTN_PREVIOUS",grid:0,evt:"e14099_client",std:"PREVIOUS"};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id: 16, fld:"BTN_NEXT",grid:0,evt:"e15099_client",std:"NEXT"};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"BTN_LAST",grid:0,evt:"e16099_client",std:"LAST"};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"BTN_SELECT",grid:0,evt:"e17099_client",std:"SELECT"};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[26]={ id: 26, fld:"",grid:0};
   GXValidFnc[27]={ id: 27, fld:"",grid:0};
   GXValidFnc[28]={ id:28 ,lvl:0,type:"char",len:10,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Clcheqdcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLCHEQDCOD",gxz:"Z150CLCheqDCod",gxold:"O150CLCheqDCod",gxvar:"A150CLCheqDCod",ucs:[],op:[63,33,98,93,88,83,78,73,68,58,53,48,43],ip:[63,33,98,93,88,83,78,73,68,58,53,48,43,28],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A150CLCheqDCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z150CLCheqDCod=Value},v2c:function(){gx.fn.setControlValue("CLCHEQDCOD",gx.O.A150CLCheqDCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A150CLCheqDCod=this.val()},val:function(){return gx.fn.getControlValue("CLCHEQDCOD")},nac:gx.falseFn};
   GXValidFnc[29]={ id: 29, fld:"",grid:0};
   GXValidFnc[30]={ id: 30, fld:"",grid:0};
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   GXValidFnc[32]={ id: 32, fld:"",grid:0};
   GXValidFnc[33]={ id:33 ,lvl:0,type:"char",len:20,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Clcheqdclicod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLCHEQDCLICOD",gxz:"Z152CLCheqDCliCod",gxold:"O152CLCheqDCliCod",gxvar:"A152CLCheqDCliCod",ucs:[],op:[38],ip:[38,33],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A152CLCheqDCliCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z152CLCheqDCliCod=Value},v2c:function(){gx.fn.setControlValue("CLCHEQDCLICOD",gx.O.A152CLCheqDCliCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A152CLCheqDCliCod=this.val()},val:function(){return gx.fn.getControlValue("CLCHEQDCLICOD")},nac:gx.falseFn};
   GXValidFnc[34]={ id: 34, fld:"",grid:0};
   GXValidFnc[35]={ id: 35, fld:"",grid:0};
   GXValidFnc[36]={ id: 36, fld:"",grid:0};
   GXValidFnc[37]={ id: 37, fld:"",grid:0};
   GXValidFnc[38]={ id:38 ,lvl:0,type:"char",len:100,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLCHEQDCLIDSC",gxz:"Z556CLCheqDCliDsc",gxold:"O556CLCheqDCliDsc",gxvar:"A556CLCheqDCliDsc",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A556CLCheqDCliDsc=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z556CLCheqDCliDsc=Value},v2c:function(){gx.fn.setControlValue("CLCHEQDCLIDSC",gx.O.A556CLCheqDCliDsc,0)},c2v:function(){if(this.val()!==undefined)gx.O.A556CLCheqDCliDsc=this.val()},val:function(){return gx.fn.getControlValue("CLCHEQDCLIDSC")},nac:gx.falseFn};
   GXValidFnc[39]={ id: 39, fld:"",grid:0};
   GXValidFnc[40]={ id: 40, fld:"",grid:0};
   GXValidFnc[41]={ id: 41, fld:"",grid:0};
   GXValidFnc[42]={ id: 42, fld:"",grid:0};
   GXValidFnc[43]={ id:43 ,lvl:0,type:"date",len:8,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Clcheqdfec,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLCHEQDFEC",gxz:"Z558CLCheqDFec",gxold:"O558CLCheqDFec",gxvar:"A558CLCheqDFec",dp:{f:0,st:false,wn:false,mf:false,pic:"99/99/99",dec:0},ucs:[],op:[43],ip:[43],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A558CLCheqDFec=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z558CLCheqDFec=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("CLCHEQDFEC",gx.O.A558CLCheqDFec,0)},c2v:function(){if(this.val()!==undefined)gx.O.A558CLCheqDFec=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getControlValue("CLCHEQDFEC")},nac:gx.falseFn};
   GXValidFnc[44]={ id: 44, fld:"",grid:0};
   GXValidFnc[45]={ id: 45, fld:"",grid:0};
   GXValidFnc[46]={ id: 46, fld:"",grid:0};
   GXValidFnc[47]={ id: 47, fld:"",grid:0};
   GXValidFnc[48]={ id:48 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLCHEQDFORCOD",gxz:"Z561CLCheqDForCod",gxold:"O561CLCheqDForCod",gxvar:"A561CLCheqDForCod",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A561CLCheqDForCod=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z561CLCheqDForCod=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("CLCHEQDFORCOD",gx.O.A561CLCheqDForCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A561CLCheqDForCod=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("CLCHEQDFORCOD",',')},nac:gx.falseFn};
   GXValidFnc[49]={ id: 49, fld:"",grid:0};
   GXValidFnc[50]={ id: 50, fld:"",grid:0};
   GXValidFnc[51]={ id: 51, fld:"",grid:0};
   GXValidFnc[52]={ id: 52, fld:"",grid:0};
   GXValidFnc[53]={ id:53 ,lvl:0,type:"decimal",len:15,dec:5,sign:false,pic:"ZZZZZZZZ9.99999",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLCHEQDTIPCMB",gxz:"Z566CLCheqDTipCmb",gxold:"O566CLCheqDTipCmb",gxvar:"A566CLCheqDTipCmb",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A566CLCheqDTipCmb=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z566CLCheqDTipCmb=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("CLCHEQDTIPCMB",gx.O.A566CLCheqDTipCmb,5,'.')},c2v:function(){if(this.val()!==undefined)gx.O.A566CLCheqDTipCmb=this.val()},val:function(){return gx.fn.getDecimalValue("CLCHEQDTIPCMB",',','.')},nac:gx.falseFn};
   GXValidFnc[54]={ id: 54, fld:"",grid:0};
   GXValidFnc[55]={ id: 55, fld:"",grid:0};
   GXValidFnc[56]={ id: 56, fld:"",grid:0};
   GXValidFnc[57]={ id: 57, fld:"",grid:0};
   GXValidFnc[58]={ id:58 ,lvl:0,type:"char",len:1,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLCHEQDSTS",gxz:"Z564CLCheqDSts",gxold:"O564CLCheqDSts",gxvar:"A564CLCheqDSts",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A564CLCheqDSts=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z564CLCheqDSts=Value},v2c:function(){gx.fn.setControlValue("CLCHEQDSTS",gx.O.A564CLCheqDSts,0)},c2v:function(){if(this.val()!==undefined)gx.O.A564CLCheqDSts=this.val()},val:function(){return gx.fn.getControlValue("CLCHEQDSTS")},nac:gx.falseFn};
   GXValidFnc[59]={ id: 59, fld:"",grid:0};
   GXValidFnc[60]={ id: 60, fld:"",grid:0};
   GXValidFnc[61]={ id: 61, fld:"",grid:0};
   GXValidFnc[62]={ id: 62, fld:"",grid:0};
   GXValidFnc[63]={ id:63 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Clcheqdmoncod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLCHEQDMONCOD",gxz:"Z151CLCheqDMonCod",gxold:"O151CLCheqDMonCod",gxvar:"A151CLCheqDMonCod",ucs:[],op:[],ip:[63],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A151CLCheqDMonCod=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z151CLCheqDMonCod=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("CLCHEQDMONCOD",gx.O.A151CLCheqDMonCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A151CLCheqDMonCod=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("CLCHEQDMONCOD",',')},nac:gx.falseFn};
   GXValidFnc[64]={ id: 64, fld:"",grid:0};
   GXValidFnc[65]={ id: 65, fld:"",grid:0};
   GXValidFnc[66]={ id: 66, fld:"",grid:0};
   GXValidFnc[67]={ id: 67, fld:"",grid:0};
   GXValidFnc[68]={ id:68 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLCHEQDIMPORTE",gxz:"Z563CLCheqDImporte",gxold:"O563CLCheqDImporte",gxvar:"A563CLCheqDImporte",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A563CLCheqDImporte=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z563CLCheqDImporte=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("CLCHEQDIMPORTE",gx.O.A563CLCheqDImporte,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A563CLCheqDImporte=this.val()},val:function(){return gx.fn.getDecimalValue("CLCHEQDIMPORTE",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 68 , function() {
   });
   GXValidFnc[69]={ id: 69, fld:"",grid:0};
   GXValidFnc[70]={ id: 70, fld:"",grid:0};
   GXValidFnc[71]={ id: 71, fld:"",grid:0};
   GXValidFnc[72]={ id: 72, fld:"",grid:0};
   GXValidFnc[73]={ id:73 ,lvl:0,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLCHEQDVOUANO",gxz:"Z570CLCheqDVouAno",gxold:"O570CLCheqDVouAno",gxvar:"A570CLCheqDVouAno",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A570CLCheqDVouAno=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z570CLCheqDVouAno=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("CLCHEQDVOUANO",gx.O.A570CLCheqDVouAno,0)},c2v:function(){if(this.val()!==undefined)gx.O.A570CLCheqDVouAno=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("CLCHEQDVOUANO",',')},nac:gx.falseFn};
   GXValidFnc[74]={ id: 74, fld:"",grid:0};
   GXValidFnc[75]={ id: 75, fld:"",grid:0};
   GXValidFnc[76]={ id: 76, fld:"",grid:0};
   GXValidFnc[77]={ id: 77, fld:"",grid:0};
   GXValidFnc[78]={ id:78 ,lvl:0,type:"int",len:2,dec:0,sign:false,pic:"Z9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLCHEQDVOUMES",gxz:"Z571CLCheqDVouMes",gxold:"O571CLCheqDVouMes",gxvar:"A571CLCheqDVouMes",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A571CLCheqDVouMes=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z571CLCheqDVouMes=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("CLCHEQDVOUMES",gx.O.A571CLCheqDVouMes,0)},c2v:function(){if(this.val()!==undefined)gx.O.A571CLCheqDVouMes=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("CLCHEQDVOUMES",',')},nac:gx.falseFn};
   GXValidFnc[79]={ id: 79, fld:"",grid:0};
   GXValidFnc[80]={ id: 80, fld:"",grid:0};
   GXValidFnc[81]={ id: 81, fld:"",grid:0};
   GXValidFnc[82]={ id: 82, fld:"",grid:0};
   GXValidFnc[83]={ id:83 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLCHEQDTASICOD",gxz:"Z565CLCheqDTasiCod",gxold:"O565CLCheqDTasiCod",gxvar:"A565CLCheqDTasiCod",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A565CLCheqDTasiCod=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z565CLCheqDTasiCod=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("CLCHEQDTASICOD",gx.O.A565CLCheqDTasiCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A565CLCheqDTasiCod=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("CLCHEQDTASICOD",',')},nac:gx.falseFn};
   GXValidFnc[84]={ id: 84, fld:"",grid:0};
   GXValidFnc[85]={ id: 85, fld:"",grid:0};
   GXValidFnc[86]={ id: 86, fld:"",grid:0};
   GXValidFnc[87]={ id: 87, fld:"",grid:0};
   GXValidFnc[88]={ id:88 ,lvl:0,type:"char",len:10,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLCHEQDVOUNUM",gxz:"Z572CLCheqDVouNum",gxold:"O572CLCheqDVouNum",gxvar:"A572CLCheqDVouNum",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A572CLCheqDVouNum=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z572CLCheqDVouNum=Value},v2c:function(){gx.fn.setControlValue("CLCHEQDVOUNUM",gx.O.A572CLCheqDVouNum,0)},c2v:function(){if(this.val()!==undefined)gx.O.A572CLCheqDVouNum=this.val()},val:function(){return gx.fn.getControlValue("CLCHEQDVOUNUM")},nac:gx.falseFn};
   GXValidFnc[89]={ id: 89, fld:"",grid:0};
   GXValidFnc[90]={ id: 90, fld:"",grid:0};
   GXValidFnc[91]={ id: 91, fld:"",grid:0};
   GXValidFnc[92]={ id: 92, fld:"",grid:0};
   GXValidFnc[93]={ id:93 ,lvl:0,type:"char",len:10,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLCHEQDUSUCOD",gxz:"Z568CLCheqDUsuCod",gxold:"O568CLCheqDUsuCod",gxvar:"A568CLCheqDUsuCod",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A568CLCheqDUsuCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z568CLCheqDUsuCod=Value},v2c:function(){gx.fn.setControlValue("CLCHEQDUSUCOD",gx.O.A568CLCheqDUsuCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A568CLCheqDUsuCod=this.val()},val:function(){return gx.fn.getControlValue("CLCHEQDUSUCOD")},nac:gx.falseFn};
   GXValidFnc[94]={ id: 94, fld:"",grid:0};
   GXValidFnc[95]={ id: 95, fld:"",grid:0};
   GXValidFnc[96]={ id: 96, fld:"",grid:0};
   GXValidFnc[97]={ id: 97, fld:"",grid:0};
   GXValidFnc[98]={ id:98 ,lvl:0,type:"dtime",len:8,dec:5,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Clcheqdusufec,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLCHEQDUSUFEC",gxz:"Z569CLCheqDUsuFec",gxold:"O569CLCheqDUsuFec",gxvar:"A569CLCheqDUsuFec",dp:{f:0,st:true,wn:false,mf:false,pic:"99/99/99 99:99",dec:5},ucs:[],op:[98],ip:[98],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A569CLCheqDUsuFec=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z569CLCheqDUsuFec=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("CLCHEQDUSUFEC",gx.O.A569CLCheqDUsuFec,0)},c2v:function(){if(this.val()!==undefined)gx.O.A569CLCheqDUsuFec=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getDateTimeValue("CLCHEQDUSUFEC")},nac:gx.falseFn};
   GXValidFnc[99]={ id: 99, fld:"",grid:0};
   GXValidFnc[100]={ id: 100, fld:"",grid:0};
   GXValidFnc[101]={ id: 101, fld:"",grid:0};
   GXValidFnc[102]={ id: 102, fld:"",grid:0};
   GXValidFnc[103]={ id: 103, fld:"BTN_ENTER",grid:0,evt:"e11099_client",std:"ENTER"};
   GXValidFnc[104]={ id: 104, fld:"",grid:0};
   GXValidFnc[105]={ id: 105, fld:"BTN_CANCEL",grid:0,evt:"e12099_client"};
   GXValidFnc[106]={ id: 106, fld:"",grid:0};
   GXValidFnc[107]={ id: 107, fld:"BTN_DELETE",grid:0,evt:"e18099_client",std:"DELETE"};
   this.A150CLCheqDCod = "" ;
   this.Z150CLCheqDCod = "" ;
   this.O150CLCheqDCod = "" ;
   this.A152CLCheqDCliCod = "" ;
   this.Z152CLCheqDCliCod = "" ;
   this.O152CLCheqDCliCod = "" ;
   this.A556CLCheqDCliDsc = "" ;
   this.Z556CLCheqDCliDsc = "" ;
   this.O556CLCheqDCliDsc = "" ;
   this.A558CLCheqDFec = gx.date.nullDate() ;
   this.Z558CLCheqDFec = gx.date.nullDate() ;
   this.O558CLCheqDFec = gx.date.nullDate() ;
   this.A561CLCheqDForCod = 0 ;
   this.Z561CLCheqDForCod = 0 ;
   this.O561CLCheqDForCod = 0 ;
   this.A566CLCheqDTipCmb = 0 ;
   this.Z566CLCheqDTipCmb = 0 ;
   this.O566CLCheqDTipCmb = 0 ;
   this.A564CLCheqDSts = "" ;
   this.Z564CLCheqDSts = "" ;
   this.O564CLCheqDSts = "" ;
   this.A151CLCheqDMonCod = 0 ;
   this.Z151CLCheqDMonCod = 0 ;
   this.O151CLCheqDMonCod = 0 ;
   this.A563CLCheqDImporte = 0 ;
   this.Z563CLCheqDImporte = 0 ;
   this.O563CLCheqDImporte = 0 ;
   this.A570CLCheqDVouAno = 0 ;
   this.Z570CLCheqDVouAno = 0 ;
   this.O570CLCheqDVouAno = 0 ;
   this.A571CLCheqDVouMes = 0 ;
   this.Z571CLCheqDVouMes = 0 ;
   this.O571CLCheqDVouMes = 0 ;
   this.A565CLCheqDTasiCod = 0 ;
   this.Z565CLCheqDTasiCod = 0 ;
   this.O565CLCheqDTasiCod = 0 ;
   this.A572CLCheqDVouNum = "" ;
   this.Z572CLCheqDVouNum = "" ;
   this.O572CLCheqDVouNum = "" ;
   this.A568CLCheqDUsuCod = "" ;
   this.Z568CLCheqDUsuCod = "" ;
   this.O568CLCheqDUsuCod = "" ;
   this.A569CLCheqDUsuFec = gx.date.nullDate() ;
   this.Z569CLCheqDUsuFec = gx.date.nullDate() ;
   this.O569CLCheqDUsuFec = gx.date.nullDate() ;
   this.A150CLCheqDCod = "" ;
   this.A152CLCheqDCliCod = "" ;
   this.A556CLCheqDCliDsc = "" ;
   this.A558CLCheqDFec = gx.date.nullDate() ;
   this.A561CLCheqDForCod = 0 ;
   this.A566CLCheqDTipCmb = 0 ;
   this.A564CLCheqDSts = "" ;
   this.A151CLCheqDMonCod = 0 ;
   this.A563CLCheqDImporte = 0 ;
   this.A570CLCheqDVouAno = 0 ;
   this.A571CLCheqDVouMes = 0 ;
   this.A565CLCheqDTasiCod = 0 ;
   this.A572CLCheqDVouNum = "" ;
   this.A568CLCheqDUsuCod = "" ;
   this.A569CLCheqDUsuFec = gx.date.nullDate() ;
   this.Events = {"e11099_client": ["ENTER", true] ,"e12099_client": ["CANCEL", true]};
   this.EvtParms["ENTER"] = [[{postForm:true}],[]];
   this.EvtParms["REFRESH"] = [[],[]];
   this.EvtParms["VALID_CLCHEQDCOD"] = [[{av:'A150CLCheqDCod',fld:'CLCHEQDCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}],[{av:'A152CLCheqDCliCod',fld:'CLCHEQDCLICOD',pic:''},{av:'A558CLCheqDFec',fld:'CLCHEQDFEC',pic:''},{av:'A561CLCheqDForCod',fld:'CLCHEQDFORCOD',pic:'ZZZZZ9'},{av:'A566CLCheqDTipCmb',fld:'CLCHEQDTIPCMB',pic:'ZZZZZZZZ9.99999'},{av:'A564CLCheqDSts',fld:'CLCHEQDSTS',pic:''},{av:'A151CLCheqDMonCod',fld:'CLCHEQDMONCOD',pic:'ZZZZZ9'},{av:'A563CLCheqDImporte',fld:'CLCHEQDIMPORTE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A570CLCheqDVouAno',fld:'CLCHEQDVOUANO',pic:'ZZZ9'},{av:'A571CLCheqDVouMes',fld:'CLCHEQDVOUMES',pic:'Z9'},{av:'A565CLCheqDTasiCod',fld:'CLCHEQDTASICOD',pic:'ZZZZZ9'},{av:'A572CLCheqDVouNum',fld:'CLCHEQDVOUNUM',pic:''},{av:'A568CLCheqDUsuCod',fld:'CLCHEQDUSUCOD',pic:''},{av:'A569CLCheqDUsuFec',fld:'CLCHEQDUSUFEC',pic:'99/99/99 99:99'},{av:'A556CLCheqDCliDsc',fld:'CLCHEQDCLIDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z150CLCheqDCod'},{av:'Z152CLCheqDCliCod'},{av:'Z558CLCheqDFec'},{av:'Z561CLCheqDForCod'},{av:'Z566CLCheqDTipCmb'},{av:'Z564CLCheqDSts'},{av:'Z151CLCheqDMonCod'},{av:'Z563CLCheqDImporte'},{av:'Z570CLCheqDVouAno'},{av:'Z571CLCheqDVouMes'},{av:'Z565CLCheqDTasiCod'},{av:'Z572CLCheqDVouNum'},{av:'Z568CLCheqDUsuCod'},{av:'Z569CLCheqDUsuFec'},{av:'Z556CLCheqDCliDsc'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]];
   this.EvtParms["VALID_CLCHEQDCLICOD"] = [[{av:'A152CLCheqDCliCod',fld:'CLCHEQDCLICOD',pic:''},{av:'A556CLCheqDCliDsc',fld:'CLCHEQDCLIDSC',pic:''}],[{av:'A556CLCheqDCliDsc',fld:'CLCHEQDCLIDSC',pic:''}]];
   this.EvtParms["VALID_CLCHEQDFEC"] = [[{av:'A558CLCheqDFec',fld:'CLCHEQDFEC',pic:''}],[{av:'A558CLCheqDFec',fld:'CLCHEQDFEC',pic:''}]];
   this.EvtParms["VALID_CLCHEQDMONCOD"] = [[{av:'A151CLCheqDMonCod',fld:'CLCHEQDMONCOD',pic:'ZZZZZ9'}],[]];
   this.EvtParms["VALID_CLCHEQDUSUFEC"] = [[{av:'A569CLCheqDUsuFec',fld:'CLCHEQDUSUFEC',pic:'99/99/99 99:99'}],[{av:'A569CLCheqDUsuFec',fld:'CLCHEQDUSUFEC',pic:'99/99/99 99:99'}]];
   this.EnterCtrl = ["BTN_ENTER"];
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(this.clchequediferido);});
