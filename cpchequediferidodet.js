gx.evt.autoSkip = false;
gx.define('cpchequediferidodet', false, function () {
   this.ServerClass =  "cpchequediferidodet" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.ServerFullClass =  "cpchequediferidodet.aspx" ;
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
   this.Valid_Cheqditem=function()
   {
      return this.validSrvEvt("Valid_Cheqditem", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Cheqdtipcod=function()
   {
      return this.validSrvEvt("Valid_Cheqdtipcod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Cheqdfecd=function()
   {
      return this.validCliEvt("Valid_Cheqdfecd", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("CHEQDFECD");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A525CheqDFecD)==0) || new gx.date.gxdate( this.A525CheqDFecD ).compare( gx.date.ymdtod( 1753, 1, 1) ) >= 0 ) )
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
   this.Valid_Cheqdfecv=function()
   {
      return this.validCliEvt("Valid_Cheqdfecv", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("CHEQDFECV");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A526CheqDFecV)==0) || new gx.date.gxdate( this.A526CheqDFecV ).compare( gx.date.ymdtod( 1753, 1, 1) ) >= 0 ) )
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
   this.e110e15_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e120e15_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82];
   this.GXLastCtrlId =82;
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
   GXValidFnc[12]={ id: 12, fld:"BTN_FIRST",grid:0,evt:"e130e15_client",std:"FIRST"};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"BTN_PREVIOUS",grid:0,evt:"e140e15_client",std:"PREVIOUS"};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id: 16, fld:"BTN_NEXT",grid:0,evt:"e150e15_client",std:"NEXT"};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"BTN_LAST",grid:0,evt:"e160e15_client",std:"LAST"};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"BTN_SELECT",grid:0,evt:"e170e15_client",std:"SELECT"};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[26]={ id: 26, fld:"",grid:0};
   GXValidFnc[27]={ id: 27, fld:"",grid:0};
   GXValidFnc[28]={ id:28 ,lvl:0,type:"char",len:10,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cheqdcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHEQDCOD",gxz:"Z238CheqDCod",gxold:"O238CheqDCod",gxvar:"A238CheqDCod",ucs:[],op:[],ip:[28],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A238CheqDCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z238CheqDCod=Value},v2c:function(){gx.fn.setControlValue("CHEQDCOD",gx.O.A238CheqDCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A238CheqDCod=this.val()},val:function(){return gx.fn.getControlValue("CHEQDCOD")},nac:gx.falseFn};
   GXValidFnc[29]={ id: 29, fld:"",grid:0};
   GXValidFnc[30]={ id: 30, fld:"",grid:0};
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   GXValidFnc[32]={ id: 32, fld:"",grid:0};
   GXValidFnc[33]={ id:33 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cheqditem,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHEQDITEM",gxz:"Z241CheqDItem",gxold:"O241CheqDItem",gxvar:"A241CheqDItem",ucs:[],op:[43,73,68,63,58,53,48,38],ip:[43,73,68,63,58,53,48,38,33,28],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A241CheqDItem=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z241CheqDItem=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("CHEQDITEM",gx.O.A241CheqDItem,0)},c2v:function(){if(this.val()!==undefined)gx.O.A241CheqDItem=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("CHEQDITEM",',')},nac:gx.falseFn};
   GXValidFnc[34]={ id: 34, fld:"",grid:0};
   GXValidFnc[35]={ id: 35, fld:"",grid:0};
   GXValidFnc[36]={ id: 36, fld:"",grid:0};
   GXValidFnc[37]={ id: 37, fld:"",grid:0};
   GXValidFnc[38]={ id:38 ,lvl:0,type:"char",len:1,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHEQDTIPO",gxz:"Z535CheqDTipo",gxold:"O535CheqDTipo",gxvar:"A535CheqDTipo",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A535CheqDTipo=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z535CheqDTipo=Value},v2c:function(){gx.fn.setControlValue("CHEQDTIPO",gx.O.A535CheqDTipo,0)},c2v:function(){if(this.val()!==undefined)gx.O.A535CheqDTipo=this.val()},val:function(){return gx.fn.getControlValue("CHEQDTIPO")},nac:gx.falseFn};
   GXValidFnc[39]={ id: 39, fld:"",grid:0};
   GXValidFnc[40]={ id: 40, fld:"",grid:0};
   GXValidFnc[41]={ id: 41, fld:"",grid:0};
   GXValidFnc[42]={ id: 42, fld:"",grid:0};
   GXValidFnc[43]={ id:43 ,lvl:0,type:"char",len:3,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cheqdtipcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHEQDTIPCOD",gxz:"Z242CheqDTipCod",gxold:"O242CheqDTipCod",gxvar:"A242CheqDTipCod",ucs:[],op:[],ip:[43],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A242CheqDTipCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z242CheqDTipCod=Value},v2c:function(){gx.fn.setControlValue("CHEQDTIPCOD",gx.O.A242CheqDTipCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A242CheqDTipCod=this.val()},val:function(){return gx.fn.getControlValue("CHEQDTIPCOD")},nac:gx.falseFn};
   GXValidFnc[44]={ id: 44, fld:"",grid:0};
   GXValidFnc[45]={ id: 45, fld:"",grid:0};
   GXValidFnc[46]={ id: 46, fld:"",grid:0};
   GXValidFnc[47]={ id: 47, fld:"",grid:0};
   GXValidFnc[48]={ id:48 ,lvl:0,type:"char",len:15,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHEQDDOCNUM",gxz:"Z523CheqDDocNum",gxold:"O523CheqDDocNum",gxvar:"A523CheqDDocNum",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A523CheqDDocNum=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z523CheqDDocNum=Value},v2c:function(){gx.fn.setControlValue("CHEQDDOCNUM",gx.O.A523CheqDDocNum,0)},c2v:function(){if(this.val()!==undefined)gx.O.A523CheqDDocNum=this.val()},val:function(){return gx.fn.getControlValue("CHEQDDOCNUM")},nac:gx.falseFn};
   GXValidFnc[49]={ id: 49, fld:"",grid:0};
   GXValidFnc[50]={ id: 50, fld:"",grid:0};
   GXValidFnc[51]={ id: 51, fld:"",grid:0};
   GXValidFnc[52]={ id: 52, fld:"",grid:0};
   GXValidFnc[53]={ id:53 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHEQDDIAS",gxz:"Z522CheqDDias",gxold:"O522CheqDDias",gxvar:"A522CheqDDias",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A522CheqDDias=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z522CheqDDias=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("CHEQDDIAS",gx.O.A522CheqDDias,0)},c2v:function(){if(this.val()!==undefined)gx.O.A522CheqDDias=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("CHEQDDIAS",',')},nac:gx.falseFn};
   GXValidFnc[54]={ id: 54, fld:"",grid:0};
   GXValidFnc[55]={ id: 55, fld:"",grid:0};
   GXValidFnc[56]={ id: 56, fld:"",grid:0};
   GXValidFnc[57]={ id: 57, fld:"",grid:0};
   GXValidFnc[58]={ id:58 ,lvl:0,type:"date",len:8,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cheqdfecd,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHEQDFECD",gxz:"Z525CheqDFecD",gxold:"O525CheqDFecD",gxvar:"A525CheqDFecD",dp:{f:0,st:false,wn:false,mf:false,pic:"99/99/99",dec:0},ucs:[],op:[58],ip:[58],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A525CheqDFecD=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z525CheqDFecD=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("CHEQDFECD",gx.O.A525CheqDFecD,0)},c2v:function(){if(this.val()!==undefined)gx.O.A525CheqDFecD=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getControlValue("CHEQDFECD")},nac:gx.falseFn};
   GXValidFnc[59]={ id: 59, fld:"",grid:0};
   GXValidFnc[60]={ id: 60, fld:"",grid:0};
   GXValidFnc[61]={ id: 61, fld:"",grid:0};
   GXValidFnc[62]={ id: 62, fld:"",grid:0};
   GXValidFnc[63]={ id:63 ,lvl:0,type:"date",len:8,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cheqdfecv,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHEQDFECV",gxz:"Z526CheqDFecV",gxold:"O526CheqDFecV",gxvar:"A526CheqDFecV",dp:{f:0,st:false,wn:false,mf:false,pic:"99/99/99",dec:0},ucs:[],op:[63],ip:[63],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A526CheqDFecV=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z526CheqDFecV=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("CHEQDFECV",gx.O.A526CheqDFecV,0)},c2v:function(){if(this.val()!==undefined)gx.O.A526CheqDFecV=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getControlValue("CHEQDFECV")},nac:gx.falseFn};
   GXValidFnc[64]={ id: 64, fld:"",grid:0};
   GXValidFnc[65]={ id: 65, fld:"",grid:0};
   GXValidFnc[66]={ id: 66, fld:"",grid:0};
   GXValidFnc[67]={ id: 67, fld:"",grid:0};
   GXValidFnc[68]={ id:68 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHEQDIMPD",gxz:"Z528CheqDimpD",gxold:"O528CheqDimpD",gxvar:"A528CheqDimpD",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A528CheqDimpD=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z528CheqDimpD=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("CHEQDIMPD",gx.O.A528CheqDimpD,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A528CheqDimpD=this.val()},val:function(){return gx.fn.getDecimalValue("CHEQDIMPD",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 68 , function() {
   });
   GXValidFnc[69]={ id: 69, fld:"",grid:0};
   GXValidFnc[70]={ id: 70, fld:"",grid:0};
   GXValidFnc[71]={ id: 71, fld:"",grid:0};
   GXValidFnc[72]={ id: 72, fld:"",grid:0};
   GXValidFnc[73]={ id:73 ,lvl:0,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHEQDPAGCOD",gxz:"Z530CheqDPagCod",gxold:"O530CheqDPagCod",gxvar:"A530CheqDPagCod",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A530CheqDPagCod=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z530CheqDPagCod=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("CHEQDPAGCOD",gx.O.A530CheqDPagCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A530CheqDPagCod=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("CHEQDPAGCOD",',')},nac:gx.falseFn};
   GXValidFnc[74]={ id: 74, fld:"",grid:0};
   GXValidFnc[75]={ id: 75, fld:"",grid:0};
   GXValidFnc[76]={ id: 76, fld:"",grid:0};
   GXValidFnc[77]={ id: 77, fld:"",grid:0};
   GXValidFnc[78]={ id: 78, fld:"BTN_ENTER",grid:0,evt:"e110e15_client",std:"ENTER"};
   GXValidFnc[79]={ id: 79, fld:"",grid:0};
   GXValidFnc[80]={ id: 80, fld:"BTN_CANCEL",grid:0,evt:"e120e15_client"};
   GXValidFnc[81]={ id: 81, fld:"",grid:0};
   GXValidFnc[82]={ id: 82, fld:"BTN_DELETE",grid:0,evt:"e180e15_client",std:"DELETE"};
   this.A238CheqDCod = "" ;
   this.Z238CheqDCod = "" ;
   this.O238CheqDCod = "" ;
   this.A241CheqDItem = 0 ;
   this.Z241CheqDItem = 0 ;
   this.O241CheqDItem = 0 ;
   this.A535CheqDTipo = "" ;
   this.Z535CheqDTipo = "" ;
   this.O535CheqDTipo = "" ;
   this.A242CheqDTipCod = "" ;
   this.Z242CheqDTipCod = "" ;
   this.O242CheqDTipCod = "" ;
   this.A523CheqDDocNum = "" ;
   this.Z523CheqDDocNum = "" ;
   this.O523CheqDDocNum = "" ;
   this.A522CheqDDias = 0 ;
   this.Z522CheqDDias = 0 ;
   this.O522CheqDDias = 0 ;
   this.A525CheqDFecD = gx.date.nullDate() ;
   this.Z525CheqDFecD = gx.date.nullDate() ;
   this.O525CheqDFecD = gx.date.nullDate() ;
   this.A526CheqDFecV = gx.date.nullDate() ;
   this.Z526CheqDFecV = gx.date.nullDate() ;
   this.O526CheqDFecV = gx.date.nullDate() ;
   this.A528CheqDimpD = 0 ;
   this.Z528CheqDimpD = 0 ;
   this.O528CheqDimpD = 0 ;
   this.A530CheqDPagCod = 0 ;
   this.Z530CheqDPagCod = 0 ;
   this.O530CheqDPagCod = 0 ;
   this.A238CheqDCod = "" ;
   this.A241CheqDItem = 0 ;
   this.A535CheqDTipo = "" ;
   this.A242CheqDTipCod = "" ;
   this.A523CheqDDocNum = "" ;
   this.A522CheqDDias = 0 ;
   this.A525CheqDFecD = gx.date.nullDate() ;
   this.A526CheqDFecV = gx.date.nullDate() ;
   this.A528CheqDimpD = 0 ;
   this.A530CheqDPagCod = 0 ;
   this.Events = {"e110e15_client": ["ENTER", true] ,"e120e15_client": ["CANCEL", true]};
   this.EvtParms["ENTER"] = [[{postForm:true}],[]];
   this.EvtParms["REFRESH"] = [[],[]];
   this.EvtParms["VALID_CHEQDCOD"] = [[{av:'A238CheqDCod',fld:'CHEQDCOD',pic:''}],[]];
   this.EvtParms["VALID_CHEQDITEM"] = [[{av:'A238CheqDCod',fld:'CHEQDCOD',pic:''},{av:'A241CheqDItem',fld:'CHEQDITEM',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}],[{av:'A535CheqDTipo',fld:'CHEQDTIPO',pic:''},{av:'A242CheqDTipCod',fld:'CHEQDTIPCOD',pic:''},{av:'A523CheqDDocNum',fld:'CHEQDDOCNUM',pic:''},{av:'A522CheqDDias',fld:'CHEQDDIAS',pic:'ZZZZZ9'},{av:'A525CheqDFecD',fld:'CHEQDFECD',pic:''},{av:'A526CheqDFecV',fld:'CHEQDFECV',pic:''},{av:'A528CheqDimpD',fld:'CHEQDIMPD',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A530CheqDPagCod',fld:'CHEQDPAGCOD',pic:'ZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z238CheqDCod'},{av:'Z241CheqDItem'},{av:'Z535CheqDTipo'},{av:'Z242CheqDTipCod'},{av:'Z523CheqDDocNum'},{av:'Z522CheqDDias'},{av:'Z525CheqDFecD'},{av:'Z526CheqDFecV'},{av:'Z528CheqDimpD'},{av:'Z530CheqDPagCod'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]];
   this.EvtParms["VALID_CHEQDTIPCOD"] = [[{av:'A242CheqDTipCod',fld:'CHEQDTIPCOD',pic:''}],[]];
   this.EvtParms["VALID_CHEQDFECD"] = [[{av:'A525CheqDFecD',fld:'CHEQDFECD',pic:''}],[{av:'A525CheqDFecD',fld:'CHEQDFECD',pic:''}]];
   this.EvtParms["VALID_CHEQDFECV"] = [[{av:'A526CheqDFecV',fld:'CHEQDFECV',pic:''}],[{av:'A526CheqDFecV',fld:'CHEQDFECV',pic:''}]];
   this.EnterCtrl = ["BTN_ENTER"];
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(this.cpchequediferidodet);});
