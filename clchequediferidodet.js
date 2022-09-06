gx.evt.autoSkip = false;
gx.define('clchequediferidodet', false, function () {
   this.ServerClass =  "clchequediferidodet" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.ServerFullClass =  "clchequediferidodet.aspx" ;
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
   this.Valid_Clcheqditem=function()
   {
      return this.validSrvEvt("Valid_Clcheqditem", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Clcheqdtipcod=function()
   {
      return this.validCliEvt("Valid_Clcheqdtipcod", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("CLCHEQDTIPCOD");
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
   this.Valid_Clcheqddocnum=function()
   {
      return this.validSrvEvt("Valid_Clcheqddocnum", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Clcheqdfecd=function()
   {
      return this.validCliEvt("Valid_Clcheqdfecd", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("CLCHEQDFECD");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A559CLCheqDFecD)==0) || new gx.date.gxdate( this.A559CLCheqDFecD ).compare( gx.date.ymdtod( 1753, 1, 1) ) >= 0 ) )
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
   this.Valid_Clcheqdfecv=function()
   {
      return this.validCliEvt("Valid_Clcheqdfecv", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("CLCHEQDFECV");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A560CLCheqDFecV)==0) || new gx.date.gxdate( this.A560CLCheqDFecV ).compare( gx.date.ymdtod( 1753, 1, 1) ) >= 0 ) )
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
   this.e110a10_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e120a10_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77];
   this.GXLastCtrlId =77;
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
   GXValidFnc[12]={ id: 12, fld:"BTN_FIRST",grid:0,evt:"e130a10_client",std:"FIRST"};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"BTN_PREVIOUS",grid:0,evt:"e140a10_client",std:"PREVIOUS"};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id: 16, fld:"BTN_NEXT",grid:0,evt:"e150a10_client",std:"NEXT"};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"BTN_LAST",grid:0,evt:"e160a10_client",std:"LAST"};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"BTN_SELECT",grid:0,evt:"e170a10_client",std:"SELECT"};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[26]={ id: 26, fld:"",grid:0};
   GXValidFnc[27]={ id: 27, fld:"",grid:0};
   GXValidFnc[28]={ id:28 ,lvl:0,type:"char",len:10,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Clcheqdcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLCHEQDCOD",gxz:"Z150CLCheqDCod",gxold:"O150CLCheqDCod",gxvar:"A150CLCheqDCod",ucs:[],op:[],ip:[28],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A150CLCheqDCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z150CLCheqDCod=Value},v2c:function(){gx.fn.setControlValue("CLCHEQDCOD",gx.O.A150CLCheqDCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A150CLCheqDCod=this.val()},val:function(){return gx.fn.getControlValue("CLCHEQDCOD")},nac:gx.falseFn};
   GXValidFnc[29]={ id: 29, fld:"",grid:0};
   GXValidFnc[30]={ id: 30, fld:"",grid:0};
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   GXValidFnc[32]={ id: 32, fld:"",grid:0};
   GXValidFnc[33]={ id:33 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Clcheqditem,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLCHEQDITEM",gxz:"Z153CLCheqDItem",gxold:"O153CLCheqDItem",gxvar:"A153CLCheqDItem",ucs:[],op:[48,43,68,63,58,53,38],ip:[48,43,68,63,58,53,38,33,28],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A153CLCheqDItem=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z153CLCheqDItem=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("CLCHEQDITEM",gx.O.A153CLCheqDItem,0)},c2v:function(){if(this.val()!==undefined)gx.O.A153CLCheqDItem=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("CLCHEQDITEM",',')},nac:gx.falseFn};
   GXValidFnc[34]={ id: 34, fld:"",grid:0};
   GXValidFnc[35]={ id: 35, fld:"",grid:0};
   GXValidFnc[36]={ id: 36, fld:"",grid:0};
   GXValidFnc[37]={ id: 37, fld:"",grid:0};
   GXValidFnc[38]={ id:38 ,lvl:0,type:"char",len:1,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLCHEQDTIPO",gxz:"Z567CLCheqDTipo",gxold:"O567CLCheqDTipo",gxvar:"A567CLCheqDTipo",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A567CLCheqDTipo=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z567CLCheqDTipo=Value},v2c:function(){gx.fn.setControlValue("CLCHEQDTIPO",gx.O.A567CLCheqDTipo,0)},c2v:function(){if(this.val()!==undefined)gx.O.A567CLCheqDTipo=this.val()},val:function(){return gx.fn.getControlValue("CLCHEQDTIPO")},nac:gx.falseFn};
   GXValidFnc[39]={ id: 39, fld:"",grid:0};
   GXValidFnc[40]={ id: 40, fld:"",grid:0};
   GXValidFnc[41]={ id: 41, fld:"",grid:0};
   GXValidFnc[42]={ id: 42, fld:"",grid:0};
   GXValidFnc[43]={ id:43 ,lvl:0,type:"char",len:3,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Clcheqdtipcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLCHEQDTIPCOD",gxz:"Z154CLCheqDTipCod",gxold:"O154CLCheqDTipCod",gxvar:"A154CLCheqDTipCod",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A154CLCheqDTipCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z154CLCheqDTipCod=Value},v2c:function(){gx.fn.setControlValue("CLCHEQDTIPCOD",gx.O.A154CLCheqDTipCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A154CLCheqDTipCod=this.val()},val:function(){return gx.fn.getControlValue("CLCHEQDTIPCOD")},nac:gx.falseFn};
   GXValidFnc[44]={ id: 44, fld:"",grid:0};
   GXValidFnc[45]={ id: 45, fld:"",grid:0};
   GXValidFnc[46]={ id: 46, fld:"",grid:0};
   GXValidFnc[47]={ id: 47, fld:"",grid:0};
   GXValidFnc[48]={ id:48 ,lvl:0,type:"char",len:12,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Clcheqddocnum,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLCHEQDDOCNUM",gxz:"Z155CLCheqDDocNum",gxold:"O155CLCheqDDocNum",gxvar:"A155CLCheqDDocNum",ucs:[],op:[],ip:[48,43],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A155CLCheqDDocNum=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z155CLCheqDDocNum=Value},v2c:function(){gx.fn.setControlValue("CLCHEQDDOCNUM",gx.O.A155CLCheqDDocNum,0)},c2v:function(){if(this.val()!==undefined)gx.O.A155CLCheqDDocNum=this.val()},val:function(){return gx.fn.getControlValue("CLCHEQDDOCNUM")},nac:gx.falseFn};
   GXValidFnc[49]={ id: 49, fld:"",grid:0};
   GXValidFnc[50]={ id: 50, fld:"",grid:0};
   GXValidFnc[51]={ id: 51, fld:"",grid:0};
   GXValidFnc[52]={ id: 52, fld:"",grid:0};
   GXValidFnc[53]={ id:53 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLCHEQDDIAS",gxz:"Z557CLCheqDDias",gxold:"O557CLCheqDDias",gxvar:"A557CLCheqDDias",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A557CLCheqDDias=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z557CLCheqDDias=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("CLCHEQDDIAS",gx.O.A557CLCheqDDias,0)},c2v:function(){if(this.val()!==undefined)gx.O.A557CLCheqDDias=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("CLCHEQDDIAS",',')},nac:gx.falseFn};
   GXValidFnc[54]={ id: 54, fld:"",grid:0};
   GXValidFnc[55]={ id: 55, fld:"",grid:0};
   GXValidFnc[56]={ id: 56, fld:"",grid:0};
   GXValidFnc[57]={ id: 57, fld:"",grid:0};
   GXValidFnc[58]={ id:58 ,lvl:0,type:"date",len:8,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Clcheqdfecd,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLCHEQDFECD",gxz:"Z559CLCheqDFecD",gxold:"O559CLCheqDFecD",gxvar:"A559CLCheqDFecD",dp:{f:0,st:false,wn:false,mf:false,pic:"99/99/99",dec:0},ucs:[],op:[58],ip:[58],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A559CLCheqDFecD=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z559CLCheqDFecD=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("CLCHEQDFECD",gx.O.A559CLCheqDFecD,0)},c2v:function(){if(this.val()!==undefined)gx.O.A559CLCheqDFecD=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getControlValue("CLCHEQDFECD")},nac:gx.falseFn};
   GXValidFnc[59]={ id: 59, fld:"",grid:0};
   GXValidFnc[60]={ id: 60, fld:"",grid:0};
   GXValidFnc[61]={ id: 61, fld:"",grid:0};
   GXValidFnc[62]={ id: 62, fld:"",grid:0};
   GXValidFnc[63]={ id:63 ,lvl:0,type:"date",len:8,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Clcheqdfecv,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLCHEQDFECV",gxz:"Z560CLCheqDFecV",gxold:"O560CLCheqDFecV",gxvar:"A560CLCheqDFecV",dp:{f:0,st:false,wn:false,mf:false,pic:"99/99/99",dec:0},ucs:[],op:[63],ip:[63],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A560CLCheqDFecV=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z560CLCheqDFecV=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("CLCHEQDFECV",gx.O.A560CLCheqDFecV,0)},c2v:function(){if(this.val()!==undefined)gx.O.A560CLCheqDFecV=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getControlValue("CLCHEQDFECV")},nac:gx.falseFn};
   GXValidFnc[64]={ id: 64, fld:"",grid:0};
   GXValidFnc[65]={ id: 65, fld:"",grid:0};
   GXValidFnc[66]={ id: 66, fld:"",grid:0};
   GXValidFnc[67]={ id: 67, fld:"",grid:0};
   GXValidFnc[68]={ id:68 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLCHEQDIMPD",gxz:"Z562CLCheqDImpD",gxold:"O562CLCheqDImpD",gxvar:"A562CLCheqDImpD",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A562CLCheqDImpD=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z562CLCheqDImpD=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("CLCHEQDIMPD",gx.O.A562CLCheqDImpD,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A562CLCheqDImpD=this.val()},val:function(){return gx.fn.getDecimalValue("CLCHEQDIMPD",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 68 , function() {
   });
   GXValidFnc[69]={ id: 69, fld:"",grid:0};
   GXValidFnc[70]={ id: 70, fld:"",grid:0};
   GXValidFnc[71]={ id: 71, fld:"",grid:0};
   GXValidFnc[72]={ id: 72, fld:"",grid:0};
   GXValidFnc[73]={ id: 73, fld:"BTN_ENTER",grid:0,evt:"e110a10_client",std:"ENTER"};
   GXValidFnc[74]={ id: 74, fld:"",grid:0};
   GXValidFnc[75]={ id: 75, fld:"BTN_CANCEL",grid:0,evt:"e120a10_client"};
   GXValidFnc[76]={ id: 76, fld:"",grid:0};
   GXValidFnc[77]={ id: 77, fld:"BTN_DELETE",grid:0,evt:"e180a10_client",std:"DELETE"};
   this.A150CLCheqDCod = "" ;
   this.Z150CLCheqDCod = "" ;
   this.O150CLCheqDCod = "" ;
   this.A153CLCheqDItem = 0 ;
   this.Z153CLCheqDItem = 0 ;
   this.O153CLCheqDItem = 0 ;
   this.A567CLCheqDTipo = "" ;
   this.Z567CLCheqDTipo = "" ;
   this.O567CLCheqDTipo = "" ;
   this.A154CLCheqDTipCod = "" ;
   this.Z154CLCheqDTipCod = "" ;
   this.O154CLCheqDTipCod = "" ;
   this.A155CLCheqDDocNum = "" ;
   this.Z155CLCheqDDocNum = "" ;
   this.O155CLCheqDDocNum = "" ;
   this.A557CLCheqDDias = 0 ;
   this.Z557CLCheqDDias = 0 ;
   this.O557CLCheqDDias = 0 ;
   this.A559CLCheqDFecD = gx.date.nullDate() ;
   this.Z559CLCheqDFecD = gx.date.nullDate() ;
   this.O559CLCheqDFecD = gx.date.nullDate() ;
   this.A560CLCheqDFecV = gx.date.nullDate() ;
   this.Z560CLCheqDFecV = gx.date.nullDate() ;
   this.O560CLCheqDFecV = gx.date.nullDate() ;
   this.A562CLCheqDImpD = 0 ;
   this.Z562CLCheqDImpD = 0 ;
   this.O562CLCheqDImpD = 0 ;
   this.A150CLCheqDCod = "" ;
   this.A153CLCheqDItem = 0 ;
   this.A567CLCheqDTipo = "" ;
   this.A154CLCheqDTipCod = "" ;
   this.A155CLCheqDDocNum = "" ;
   this.A557CLCheqDDias = 0 ;
   this.A559CLCheqDFecD = gx.date.nullDate() ;
   this.A560CLCheqDFecV = gx.date.nullDate() ;
   this.A562CLCheqDImpD = 0 ;
   this.Events = {"e110a10_client": ["ENTER", true] ,"e120a10_client": ["CANCEL", true]};
   this.EvtParms["ENTER"] = [[{postForm:true}],[]];
   this.EvtParms["REFRESH"] = [[],[]];
   this.EvtParms["VALID_CLCHEQDCOD"] = [[{av:'A150CLCheqDCod',fld:'CLCHEQDCOD',pic:''}],[]];
   this.EvtParms["VALID_CLCHEQDITEM"] = [[{av:'A150CLCheqDCod',fld:'CLCHEQDCOD',pic:''},{av:'A153CLCheqDItem',fld:'CLCHEQDITEM',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}],[{av:'A567CLCheqDTipo',fld:'CLCHEQDTIPO',pic:''},{av:'A154CLCheqDTipCod',fld:'CLCHEQDTIPCOD',pic:''},{av:'A155CLCheqDDocNum',fld:'CLCHEQDDOCNUM',pic:''},{av:'A557CLCheqDDias',fld:'CLCHEQDDIAS',pic:'ZZZZZ9'},{av:'A559CLCheqDFecD',fld:'CLCHEQDFECD',pic:''},{av:'A560CLCheqDFecV',fld:'CLCHEQDFECV',pic:''},{av:'A562CLCheqDImpD',fld:'CLCHEQDIMPD',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z150CLCheqDCod'},{av:'Z153CLCheqDItem'},{av:'Z567CLCheqDTipo'},{av:'Z154CLCheqDTipCod'},{av:'Z155CLCheqDDocNum'},{av:'Z557CLCheqDDias'},{av:'Z559CLCheqDFecD'},{av:'Z560CLCheqDFecV'},{av:'Z562CLCheqDImpD'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]];
   this.EvtParms["VALID_CLCHEQDTIPCOD"] = [[],[]];
   this.EvtParms["VALID_CLCHEQDDOCNUM"] = [[{av:'A154CLCheqDTipCod',fld:'CLCHEQDTIPCOD',pic:''},{av:'A155CLCheqDDocNum',fld:'CLCHEQDDOCNUM',pic:''}],[]];
   this.EvtParms["VALID_CLCHEQDFECD"] = [[{av:'A559CLCheqDFecD',fld:'CLCHEQDFECD',pic:''}],[{av:'A559CLCheqDFecD',fld:'CLCHEQDFECD',pic:''}]];
   this.EvtParms["VALID_CLCHEQDFECV"] = [[{av:'A560CLCheqDFecV',fld:'CLCHEQDFECV',pic:''}],[{av:'A560CLCheqDFecV',fld:'CLCHEQDFECV',pic:''}]];
   this.EnterCtrl = ["BTN_ENTER"];
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(this.clchequediferidodet);});
