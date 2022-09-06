gx.evt.autoSkip = false;
gx.define('clanticipos', false, function () {
   this.ServerClass =  "clanticipos" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.ServerFullClass =  "clanticipos.aspx" ;
   this.setObjectType("trn");
   this.anyGridBaseTable = true;
   this.hasEnterEvent = true;
   this.skipOnEnter = false;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
   };
   this.Valid_Clanttipcod=function()
   {
      return this.validCliEvt("Valid_Clanttipcod", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("CLANTTIPCOD");
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
   this.Valid_Clantdocnum=function()
   {
      return this.validSrvEvt("Valid_Clantdocnum", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Clantclicod=function()
   {
      return this.validSrvEvt("Valid_Clantclicod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Clantmoncod=function()
   {
      return this.validSrvEvt("Valid_Clantmoncod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Clantfecha=function()
   {
      return this.validCliEvt("Valid_Clantfecha", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("CLANTFECHA");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A553ClAntFecha)==0) || new gx.date.gxdate( this.A553ClAntFecha ).compare( gx.date.ymdtod( 1753, 1, 1) ) >= 0 ) )
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
   this.Valid_Clantvencod=function()
   {
      return this.validSrvEvt("Valid_Clantvencod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Tipcod=function()
   {
      var currentRow = gx.fn.currentGridRowImpl(74);
      return this.validCliEvt("Valid_Tipcod", 74, function () {
      try {
         if(  gx.fn.currentGridRowImpl(74) ===0) {
            return true;
         }
         var gxballoon = gx.util.balloon.getNew("TIPCOD", gx.fn.currentGridRowImpl(74));
         this.AnyError  = 0;
         this.sMode8 =  this.Gx_mode  ;
         this.Gx_mode =  gx.fn.getGridRowMode(8,74)  ;
         this.standaloneModal2D8( );
         this.standaloneNotModal2D8( );

      }
      catch(e){}
      try {
          this.Gx_mode =  this.sMode8  ;
          if (gxballoon == null) return true; return gxballoon.show();
      }
      catch(e){}
      return true ;
      });
   }
   this.Valid_Docnum=function()
   {
      var currentRow = gx.fn.currentGridRowImpl(74);
      if(  gx.fn.currentGridRowImpl(74) ===0) {
         return true;
      }
      var gxballoon = gx.util.balloon.getNew("DOCNUM", gx.fn.currentGridRowImpl(74));
      if ( gx.fn.gridDuplicateKey(76) )
      {
         gxballoon.setError(gx.text.format( gx.getMessage( "GXM_1004"), "Level1", "", "", "", "", "", "", "", ""));
         this.AnyError = gx.num.trunc( 1 ,0) ;
         return gxballoon.show();
      }
      return this.validSrvEvt("Valid_Docnum", 74).then((function (ret) {
      try {
         this.sMode8 =  this.Gx_mode  ;
         this.Gx_mode =  gx.fn.getGridRowMode(8,74)  ;
      } finally {
         this.Gx_mode =  this.sMode8  ;
      }
      return ret;
      }).closure(this));
   }
   this.standaloneModal2D8=function()
   {
      try {
         if ( gx.text.compare( this.Gx_mode , "INS" ) != 0 )
         {
            gx.fn.setCtrlProperty("TIPCOD","Enabled", 0 );
         }
         else
         {
            gx.fn.setCtrlProperty("TIPCOD","Enabled", 1 );
         }
      }
      catch(e){}
      try {
         if ( gx.text.compare( this.Gx_mode , "INS" ) != 0 )
         {
            gx.fn.setCtrlProperty("DOCNUM","Enabled", 0 );
         }
         else
         {
            gx.fn.setCtrlProperty("DOCNUM","Enabled", 1 );
         }
      }
      catch(e){}
   }
   this.standaloneNotModal2D8=function()
   {
   }
   this.e112d82_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e122d82_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,75,76,77,78,79,80,81,82,83,84,85,86];
   this.GXLastCtrlId =86;
   this.Gridclanticipos_level1Container = new gx.grid.grid(this, 8,"Level1",74,"Gridclanticipos_level1","Gridclanticipos_level1","Gridclanticipos_level1Container",this.CmpContext,this.IsMasterPage,"clanticipos",[149,24],false,1,false,true,5,false,false,false,"",0,"px",0,"px","Nueva fila",true,false,false,null,null,false,"",false,[1,1,1,1],false,0,true,false);
   var Gridclanticipos_level1Container = this.Gridclanticipos_level1Container;
   Gridclanticipos_level1Container.addSingleLineEdit(149,75,"TIPCOD","Codigo T. Documento","","TipCod","char",0,"px",3,3,"left",null,[],149,"TipCod",true,0,false,false,"Attribute",1,"");
   Gridclanticipos_level1Container.addSingleLineEdit(24,76,"DOCNUM","Numero Doc.","","DocNum","char",0,"px",12,12,"left",null,[],24,"DocNum",true,0,false,false,"Attribute",1,"");
   Gridclanticipos_level1Container.addSingleLineEdit(552,77,"CLANTDIMPORTE","Aplicado","","CLAntDImporte","decimal",0,"px",17,17,"right",null,[],552,"CLAntDImporte",true,2,false,false,"Attribute",1,"");
   this.Gridclanticipos_level1Container.emptyText = "";
   this.setGrid(Gridclanticipos_level1Container);
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
   GXValidFnc[12]={ id: 12, fld:"BTN_FIRST",grid:0,evt:"e132d82_client",std:"FIRST"};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"BTN_PREVIOUS",grid:0,evt:"e142d82_client",std:"PREVIOUS"};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id: 16, fld:"BTN_NEXT",grid:0,evt:"e152d82_client",std:"NEXT"};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"BTN_LAST",grid:0,evt:"e162d82_client",std:"LAST"};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"BTN_SELECT",grid:0,evt:"e172d82_client",std:"SELECT"};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[26]={ id: 26, fld:"",grid:0};
   GXValidFnc[27]={ id: 27, fld:"",grid:0};
   GXValidFnc[28]={ id:28 ,lvl:0,type:"char",len:3,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Clanttipcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Gridclanticipos_level1Container],fld:"CLANTTIPCOD",gxz:"Z144CLAntTipCod",gxold:"O144CLAntTipCod",gxvar:"A144CLAntTipCod",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A144CLAntTipCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z144CLAntTipCod=Value},v2c:function(){gx.fn.setControlValue("CLANTTIPCOD",gx.O.A144CLAntTipCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A144CLAntTipCod=this.val()},val:function(){return gx.fn.getControlValue("CLANTTIPCOD")},nac:gx.falseFn};
   GXValidFnc[29]={ id: 29, fld:"",grid:0};
   GXValidFnc[30]={ id: 30, fld:"",grid:0};
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   GXValidFnc[32]={ id: 32, fld:"",grid:0};
   GXValidFnc[33]={ id:33 ,lvl:0,type:"char",len:12,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Clantdocnum,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Gridclanticipos_level1Container],fld:"CLANTDOCNUM",gxz:"Z145CLAntDocNum",gxold:"O145CLAntDocNum",gxvar:"A145CLAntDocNum",ucs:[],op:[68,48,38,63,58,53],ip:[68,48,38,63,58,53,33,28],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A145CLAntDocNum=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z145CLAntDocNum=Value},v2c:function(){gx.fn.setControlValue("CLANTDOCNUM",gx.O.A145CLAntDocNum,0)},c2v:function(){if(this.val()!==undefined)gx.O.A145CLAntDocNum=this.val()},val:function(){return gx.fn.getControlValue("CLANTDOCNUM")},nac:gx.falseFn};
   GXValidFnc[34]={ id: 34, fld:"",grid:0};
   GXValidFnc[35]={ id: 35, fld:"",grid:0};
   GXValidFnc[36]={ id: 36, fld:"",grid:0};
   GXValidFnc[37]={ id: 37, fld:"",grid:0};
   GXValidFnc[38]={ id:38 ,lvl:0,type:"char",len:20,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Clantclicod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLANTCLICOD",gxz:"Z148CLAntCliCod",gxold:"O148CLAntCliCod",gxvar:"A148CLAntCliCod",ucs:[],op:[43],ip:[43,38],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A148CLAntCliCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z148CLAntCliCod=Value},v2c:function(){gx.fn.setControlValue("CLANTCLICOD",gx.O.A148CLAntCliCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A148CLAntCliCod=this.val()},val:function(){return gx.fn.getControlValue("CLANTCLICOD")},nac:gx.falseFn};
   GXValidFnc[39]={ id: 39, fld:"",grid:0};
   GXValidFnc[40]={ id: 40, fld:"",grid:0};
   GXValidFnc[41]={ id: 41, fld:"",grid:0};
   GXValidFnc[42]={ id: 42, fld:"",grid:0};
   GXValidFnc[43]={ id:43 ,lvl:0,type:"char",len:100,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLANTCLIDSC",gxz:"Z551CLAntCliDsc",gxold:"O551CLAntCliDsc",gxvar:"A551CLAntCliDsc",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A551CLAntCliDsc=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z551CLAntCliDsc=Value},v2c:function(){gx.fn.setControlValue("CLANTCLIDSC",gx.O.A551CLAntCliDsc,0)},c2v:function(){if(this.val()!==undefined)gx.O.A551CLAntCliDsc=this.val()},val:function(){return gx.fn.getControlValue("CLANTCLIDSC")},nac:gx.falseFn};
   GXValidFnc[44]={ id: 44, fld:"",grid:0};
   GXValidFnc[45]={ id: 45, fld:"",grid:0};
   GXValidFnc[46]={ id: 46, fld:"",grid:0};
   GXValidFnc[47]={ id: 47, fld:"",grid:0};
   GXValidFnc[48]={ id:48 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Clantmoncod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLANTMONCOD",gxz:"Z147CLAntMonCod",gxold:"O147CLAntMonCod",gxvar:"A147CLAntMonCod",ucs:[],op:[],ip:[48],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A147CLAntMonCod=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z147CLAntMonCod=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("CLANTMONCOD",gx.O.A147CLAntMonCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A147CLAntMonCod=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("CLANTMONCOD",',')},nac:gx.falseFn};
   GXValidFnc[49]={ id: 49, fld:"",grid:0};
   GXValidFnc[50]={ id: 50, fld:"",grid:0};
   GXValidFnc[51]={ id: 51, fld:"",grid:0};
   GXValidFnc[52]={ id: 52, fld:"",grid:0};
   GXValidFnc[53]={ id:53 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLANTIMPORTE",gxz:"Z554CLAntImporte",gxold:"O554CLAntImporte",gxvar:"A554CLAntImporte",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A554CLAntImporte=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z554CLAntImporte=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("CLANTIMPORTE",gx.O.A554CLAntImporte,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A554CLAntImporte=this.val()},val:function(){return gx.fn.getDecimalValue("CLANTIMPORTE",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 53 , function() {
   });
   GXValidFnc[54]={ id: 54, fld:"",grid:0};
   GXValidFnc[55]={ id: 55, fld:"",grid:0};
   GXValidFnc[56]={ id: 56, fld:"",grid:0};
   GXValidFnc[57]={ id: 57, fld:"",grid:0};
   GXValidFnc[58]={ id:58 ,lvl:0,type:"date",len:8,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Clantfecha,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLANTFECHA",gxz:"Z553ClAntFecha",gxold:"O553ClAntFecha",gxvar:"A553ClAntFecha",dp:{f:0,st:false,wn:false,mf:false,pic:"99/99/99",dec:0},ucs:[],op:[58],ip:[58],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A553ClAntFecha=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z553ClAntFecha=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("CLANTFECHA",gx.O.A553ClAntFecha,0)},c2v:function(){if(this.val()!==undefined)gx.O.A553ClAntFecha=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getControlValue("CLANTFECHA")},nac:gx.falseFn};
   GXValidFnc[59]={ id: 59, fld:"",grid:0};
   GXValidFnc[60]={ id: 60, fld:"",grid:0};
   GXValidFnc[61]={ id: 61, fld:"",grid:0};
   GXValidFnc[62]={ id: 62, fld:"",grid:0};
   GXValidFnc[63]={ id:63 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLANTIMPPAGO",gxz:"Z555CLAntImpPago",gxold:"O555CLAntImpPago",gxvar:"A555CLAntImpPago",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A555CLAntImpPago=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z555CLAntImpPago=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("CLANTIMPPAGO",gx.O.A555CLAntImpPago,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A555CLAntImpPago=this.val()},val:function(){return gx.fn.getDecimalValue("CLANTIMPPAGO",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 63 , function() {
   });
   GXValidFnc[64]={ id: 64, fld:"",grid:0};
   GXValidFnc[65]={ id: 65, fld:"",grid:0};
   GXValidFnc[66]={ id: 66, fld:"",grid:0};
   GXValidFnc[67]={ id: 67, fld:"",grid:0};
   GXValidFnc[68]={ id:68 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Clantvencod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLANTVENCOD",gxz:"Z146CLAntVenCod",gxold:"O146CLAntVenCod",gxvar:"A146CLAntVenCod",ucs:[],op:[],ip:[68],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A146CLAntVenCod=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z146CLAntVenCod=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("CLANTVENCOD",gx.O.A146CLAntVenCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A146CLAntVenCod=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("CLANTVENCOD",',')},nac:gx.falseFn};
   GXValidFnc[69]={ id: 69, fld:"",grid:0};
   GXValidFnc[70]={ id: 70, fld:"",grid:0};
   GXValidFnc[71]={ id: 71, fld:"TITLELEVEL1", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[72]={ id: 72, fld:"",grid:0};
   GXValidFnc[73]={ id: 73, fld:"",grid:0};
   GXValidFnc[75]={ id:75 ,lvl:8,type:"char",len:3,dec:0,sign:false,ro:0,isacc:1,grid:74,gxgrid:this.Gridclanticipos_level1Container,fnc:this.Valid_Tipcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TIPCOD",gxz:"Z149TipCod",gxold:"O149TipCod",gxvar:"A149TipCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.A149TipCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z149TipCod=Value},v2c:function(row){gx.fn.setGridControlValue("TIPCOD",row || gx.fn.currentGridRowImpl(74),gx.O.A149TipCod,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A149TipCod=this.val(row)},val:function(row){return gx.fn.getGridControlValue("TIPCOD",row || gx.fn.currentGridRowImpl(74))},nac:gx.falseFn};
   GXValidFnc[76]={ id:76 ,lvl:8,type:"char",len:12,dec:0,sign:false,ro:0,isacc:1,grid:74,gxgrid:this.Gridclanticipos_level1Container,fnc:this.Valid_Docnum,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DOCNUM",gxz:"Z24DocNum",gxold:"O24DocNum",gxvar:"A24DocNum",ucs:[],op:[],ip:[76,75],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.A24DocNum=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z24DocNum=Value},v2c:function(row){gx.fn.setGridControlValue("DOCNUM",row || gx.fn.currentGridRowImpl(74),gx.O.A24DocNum,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A24DocNum=this.val(row)},val:function(row){return gx.fn.getGridControlValue("DOCNUM",row || gx.fn.currentGridRowImpl(74))},nac:gx.falseFn};
   GXValidFnc[77]={ id:77 ,lvl:8,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,isacc:1,grid:74,gxgrid:this.Gridclanticipos_level1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLANTDIMPORTE",gxz:"Z552CLAntDImporte",gxold:"O552CLAntDImporte",gxvar:"A552CLAntDImporte",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',v2v:function(Value){if(Value!==undefined)gx.O.A552CLAntDImporte=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z552CLAntDImporte=gx.fn.toDecimalValue(Value,',','.')},v2c:function(row){gx.fn.setGridDecimalValue("CLANTDIMPORTE",row || gx.fn.currentGridRowImpl(74),gx.O.A552CLAntDImporte,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(row){if(this.val(row)!==undefined)gx.O.A552CLAntDImporte=this.val(row)},val:function(row){return gx.fn.getGridDecimalValue("CLANTDIMPORTE",row || gx.fn.currentGridRowImpl(74),',','.')},nac:gx.falseFn};
   GXValidFnc[78]={ id: 78, fld:"",grid:0};
   GXValidFnc[79]={ id: 79, fld:"",grid:0};
   GXValidFnc[80]={ id: 80, fld:"",grid:0};
   GXValidFnc[81]={ id: 81, fld:"",grid:0};
   GXValidFnc[82]={ id: 82, fld:"BTN_ENTER",grid:0,evt:"e112d82_client",std:"ENTER"};
   GXValidFnc[83]={ id: 83, fld:"",grid:0};
   GXValidFnc[84]={ id: 84, fld:"BTN_CANCEL",grid:0,evt:"e122d82_client"};
   GXValidFnc[85]={ id: 85, fld:"",grid:0};
   GXValidFnc[86]={ id: 86, fld:"BTN_DELETE",grid:0,evt:"e182d82_client",std:"DELETE"};
   this.A144CLAntTipCod = "" ;
   this.Z144CLAntTipCod = "" ;
   this.O144CLAntTipCod = "" ;
   this.A145CLAntDocNum = "" ;
   this.Z145CLAntDocNum = "" ;
   this.O145CLAntDocNum = "" ;
   this.A148CLAntCliCod = "" ;
   this.Z148CLAntCliCod = "" ;
   this.O148CLAntCliCod = "" ;
   this.A551CLAntCliDsc = "" ;
   this.Z551CLAntCliDsc = "" ;
   this.O551CLAntCliDsc = "" ;
   this.A147CLAntMonCod = 0 ;
   this.Z147CLAntMonCod = 0 ;
   this.O147CLAntMonCod = 0 ;
   this.A554CLAntImporte = 0 ;
   this.Z554CLAntImporte = 0 ;
   this.O554CLAntImporte = 0 ;
   this.A553ClAntFecha = gx.date.nullDate() ;
   this.Z553ClAntFecha = gx.date.nullDate() ;
   this.O553ClAntFecha = gx.date.nullDate() ;
   this.A555CLAntImpPago = 0 ;
   this.Z555CLAntImpPago = 0 ;
   this.O555CLAntImpPago = 0 ;
   this.A146CLAntVenCod = 0 ;
   this.Z146CLAntVenCod = 0 ;
   this.O146CLAntVenCod = 0 ;
   this.Z149TipCod = "" ;
   this.O149TipCod = "" ;
   this.Z24DocNum = "" ;
   this.O24DocNum = "" ;
   this.Z552CLAntDImporte = 0 ;
   this.O552CLAntDImporte = 0 ;
   this.A149TipCod = "" ;
   this.A24DocNum = "" ;
   this.A552CLAntDImporte = 0 ;
   this.A144CLAntTipCod = "" ;
   this.A145CLAntDocNum = "" ;
   this.A148CLAntCliCod = "" ;
   this.A551CLAntCliDsc = "" ;
   this.A147CLAntMonCod = 0 ;
   this.A554CLAntImporte = 0 ;
   this.A553ClAntFecha = gx.date.nullDate() ;
   this.A555CLAntImpPago = 0 ;
   this.A146CLAntVenCod = 0 ;
   this.Events = {"e112d82_client": ["ENTER", true] ,"e122d82_client": ["CANCEL", true]};
   this.EvtParms["ENTER"] = [[{postForm:true}],[]];
   this.EvtParms["REFRESH"] = [[],[]];
   this.EvtParms["VALID_CLANTTIPCOD"] = [[],[]];
   this.EvtParms["VALID_CLANTDOCNUM"] = [[{av:'A144CLAntTipCod',fld:'CLANTTIPCOD',pic:''},{av:'A145CLAntDocNum',fld:'CLANTDOCNUM',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}],[{av:'A148CLAntCliCod',fld:'CLANTCLICOD',pic:''},{av:'A147CLAntMonCod',fld:'CLANTMONCOD',pic:'ZZZZZ9'},{av:'A554CLAntImporte',fld:'CLANTIMPORTE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A553ClAntFecha',fld:'CLANTFECHA',pic:''},{av:'A555CLAntImpPago',fld:'CLANTIMPPAGO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A146CLAntVenCod',fld:'CLANTVENCOD',pic:'ZZZZZ9'},{av:'A551CLAntCliDsc',fld:'CLANTCLIDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z144CLAntTipCod'},{av:'Z145CLAntDocNum'},{av:'Z148CLAntCliCod'},{av:'Z147CLAntMonCod'},{av:'Z554CLAntImporte'},{av:'Z553ClAntFecha'},{av:'Z555CLAntImpPago'},{av:'Z146CLAntVenCod'},{av:'Z551CLAntCliDsc'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]];
   this.EvtParms["VALID_CLANTCLICOD"] = [[{av:'A148CLAntCliCod',fld:'CLANTCLICOD',pic:''},{av:'A551CLAntCliDsc',fld:'CLANTCLIDSC',pic:''}],[{av:'A551CLAntCliDsc',fld:'CLANTCLIDSC',pic:''}]];
   this.EvtParms["VALID_CLANTMONCOD"] = [[{av:'A147CLAntMonCod',fld:'CLANTMONCOD',pic:'ZZZZZ9'}],[]];
   this.EvtParms["VALID_CLANTFECHA"] = [[{av:'A553ClAntFecha',fld:'CLANTFECHA',pic:''}],[{av:'A553ClAntFecha',fld:'CLANTFECHA',pic:''}]];
   this.EvtParms["VALID_CLANTVENCOD"] = [[{av:'A146CLAntVenCod',fld:'CLANTVENCOD',pic:'ZZZZZ9'}],[]];
   this.EvtParms["VALID_TIPCOD"] = [[],[]];
   this.EvtParms["VALID_DOCNUM"] = [[{av:'A149TipCod',fld:'TIPCOD',pic:''},{av:'A24DocNum',fld:'DOCNUM',pic:''}],[]];
   this.EnterCtrl = ["BTN_ENTER"];
   Gridclanticipos_level1Container.addPostingVar({rfrVar:"Gx_mode"});
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(this.clanticipos);});
