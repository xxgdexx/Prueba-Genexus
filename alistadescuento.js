gx.evt.autoSkip = false;
gx.define('alistadescuento', false, function () {
   this.ServerClass =  "alistadescuento" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.ServerFullClass =  "alistadescuento.aspx" ;
   this.setObjectType("trn");
   this.hasEnterEvent = true;
   this.skipOnEnter = false;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
      this.A2262ListSubLCod=gx.fn.getIntegerValue("LISTSUBLCOD",',') ;
      this.A1206ListCantDesde=gx.fn.getDecimalValue("LISTCANTDESDE",',','.') ;
      this.A1207ListCantHasta=gx.fn.getDecimalValue("LISTCANTHASTA",',','.') ;
   };
   this.Valid_Listitem=function()
   {
      return this.validSrvEvt("Valid_Listitem", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Listprodcod=function()
   {
      return this.validSrvEvt("Valid_Listprodcod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Listclicod=function()
   {
      return this.validSrvEvt("Valid_Listclicod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Listdesde=function()
   {
      return this.validCliEvt("Valid_Listdesde", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("LISTDESDE");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A1209ListDesde)==0) || new gx.date.gxdate( this.A1209ListDesde ).compare( gx.date.ymdtod( 1753, 1, 1) ) >= 0 ) )
         {
            try {
               gxballoon.setError("Campo Fecha Desde fuera de rango");
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
   this.Valid_Listhasta=function()
   {
      return this.validCliEvt("Valid_Listhasta", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("LISTHASTA");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A1210ListHasta)==0) || new gx.date.gxdate( this.A1210ListHasta ).compare( gx.date.ymdtod( 1753, 1, 1) ) >= 0 ) )
         {
            try {
               gxballoon.setError("Campo Fecha Hasta fuera de rango");
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
   this.e111842_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e121842_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,5,6,7,8,9,15,18,20,21,24,26,29,31,34,36,39,41,44,46,49,51,54,56,59,61,64,66,69,71,74,75,76,77,78];
   this.GXLastCtrlId =78;
   GXValidFnc[2]={ id: 2, fld:"TABLE1",grid:0};
   GXValidFnc[5]={ id: 5, fld:"BTN_FIRST",grid:0,evt:"e131842_client",std:"FIRST"};
   GXValidFnc[6]={ id: 6, fld:"BTN_PREVIOUS",grid:0,evt:"e141842_client",std:"PREVIOUS"};
   GXValidFnc[7]={ id: 7, fld:"BTN_NEXT",grid:0,evt:"e151842_client",std:"NEXT"};
   GXValidFnc[8]={ id: 8, fld:"BTN_LAST",grid:0,evt:"e161842_client",std:"LAST"};
   GXValidFnc[9]={ id: 9, fld:"BTN_SELECT",grid:0,evt:"e171842_client",std:"SELECT"};
   GXValidFnc[15]={ id: 15, fld:"TABLE2",grid:0};
   GXValidFnc[18]={ id: 18, fld:"TEXTBLOCK1", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[20]={ id:20 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Listitem,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LISTITEM",gxz:"Z37ListItem",gxold:"O37ListItem",gxvar:"A37ListItem",ucs:[],op:[41,36,61,56,51,46,31,26],ip:[41,36,61,56,51,46,31,26,20],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A37ListItem=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z37ListItem=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("LISTITEM",gx.O.A37ListItem,0)},c2v:function(){if(this.val()!==undefined)gx.O.A37ListItem=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("LISTITEM",',')},nac:gx.falseFn};
   GXValidFnc[21]={ id: 21, fld:"BTN_GET",grid:0,evt:"e181842_client",std:"GET"};
   GXValidFnc[24]={ id: 24, fld:"TEXTBLOCK2", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[26]={ id:26 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LISTTIPCLI",gxz:"Z1214ListTipCli",gxold:"O1214ListTipCli",gxvar:"A1214ListTipCli",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1214ListTipCli=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1214ListTipCli=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("LISTTIPCLI",gx.O.A1214ListTipCli,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1214ListTipCli=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("LISTTIPCLI",',')},nac:gx.falseFn};
   GXValidFnc[29]={ id: 29, fld:"TEXTBLOCK3", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[31]={ id:31 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LISTLINCOD",gxz:"Z1211ListLinCod",gxold:"O1211ListLinCod",gxvar:"A1211ListLinCod",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1211ListLinCod=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1211ListLinCod=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("LISTLINCOD",gx.O.A1211ListLinCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1211ListLinCod=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("LISTLINCOD",',')},nac:gx.falseFn};
   GXValidFnc[34]={ id: 34, fld:"TEXTBLOCK4", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[36]={ id:36 ,lvl:0,type:"char",len:15,dec:0,sign:false,pic:"@!",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Listprodcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LISTPRODCOD",gxz:"Z39ListProdCod",gxold:"O39ListProdCod",gxvar:"A39ListProdCod",ucs:[],op:[66],ip:[66,36],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A39ListProdCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z39ListProdCod=Value},v2c:function(){gx.fn.setControlValue("LISTPRODCOD",gx.O.A39ListProdCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A39ListProdCod=this.val()},val:function(){return gx.fn.getControlValue("LISTPRODCOD")},nac:gx.falseFn};
   GXValidFnc[39]={ id: 39, fld:"TEXTBLOCK5", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[41]={ id:41 ,lvl:0,type:"char",len:20,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Listclicod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LISTCLICOD",gxz:"Z38ListCliCod",gxold:"O38ListCliCod",gxvar:"A38ListCliCod",ucs:[],op:[71],ip:[71,41],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A38ListCliCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z38ListCliCod=Value},v2c:function(){gx.fn.setControlValue("LISTCLICOD",gx.O.A38ListCliCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A38ListCliCod=this.val()},val:function(){return gx.fn.getControlValue("LISTCLICOD")},nac:gx.falseFn};
   GXValidFnc[44]={ id: 44, fld:"TEXTBLOCK6", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[46]={ id:46 ,lvl:0,type:"decimal",len:6,dec:2,sign:false,pic:"ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LISTPORCENTAJE",gxz:"Z1212ListPorcentaje",gxold:"O1212ListPorcentaje",gxvar:"A1212ListPorcentaje",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1212ListPorcentaje=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z1212ListPorcentaje=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("LISTPORCENTAJE",gx.O.A1212ListPorcentaje,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A1212ListPorcentaje=this.val()},val:function(){return gx.fn.getDecimalValue("LISTPORCENTAJE",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 46 , function() {
   });
   GXValidFnc[49]={ id: 49, fld:"TEXTBLOCK7", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[51]={ id:51 ,lvl:0,type:"date",len:8,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Listdesde,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LISTDESDE",gxz:"Z1209ListDesde",gxold:"O1209ListDesde",gxvar:"A1209ListDesde",dp:{f:0,st:false,wn:false,mf:false,pic:"99/99/99",dec:0},ucs:[],op:[51],ip:[51],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1209ListDesde=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1209ListDesde=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("LISTDESDE",gx.O.A1209ListDesde,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1209ListDesde=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getControlValue("LISTDESDE")},nac:gx.falseFn};
   GXValidFnc[54]={ id: 54, fld:"TEXTBLOCK8", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[56]={ id:56 ,lvl:0,type:"date",len:8,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Listhasta,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LISTHASTA",gxz:"Z1210ListHasta",gxold:"O1210ListHasta",gxvar:"A1210ListHasta",dp:{f:0,st:false,wn:false,mf:false,pic:"99/99/99",dec:0},ucs:[],op:[56],ip:[56],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1210ListHasta=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1210ListHasta=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("LISTHASTA",gx.O.A1210ListHasta,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1210ListHasta=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getControlValue("LISTHASTA")},nac:gx.falseFn};
   GXValidFnc[59]={ id: 59, fld:"TEXTBLOCK9", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[61]={ id:61 ,lvl:0,type:"char",len:1,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LISTTIPO",gxz:"Z1215ListTipo",gxold:"O1215ListTipo",gxvar:"A1215ListTipo",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1215ListTipo=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z1215ListTipo=Value},v2c:function(){gx.fn.setControlValue("LISTTIPO",gx.O.A1215ListTipo,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1215ListTipo=this.val()},val:function(){return gx.fn.getControlValue("LISTTIPO")},nac:gx.falseFn};
   GXValidFnc[64]={ id: 64, fld:"TEXTBLOCK10", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[66]={ id:66 ,lvl:0,type:"char",len:100,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LISTPRODDSC",gxz:"Z1213ListProdDsc",gxold:"O1213ListProdDsc",gxvar:"A1213ListProdDsc",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1213ListProdDsc=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z1213ListProdDsc=Value},v2c:function(){gx.fn.setControlValue("LISTPRODDSC",gx.O.A1213ListProdDsc,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1213ListProdDsc=this.val()},val:function(){return gx.fn.getControlValue("LISTPRODDSC")},nac:gx.falseFn};
   GXValidFnc[69]={ id: 69, fld:"TEXTBLOCK11", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[71]={ id:71 ,lvl:0,type:"char",len:100,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LISTCLIDSC",gxz:"Z1208ListCliDsc",gxold:"O1208ListCliDsc",gxvar:"A1208ListCliDsc",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1208ListCliDsc=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z1208ListCliDsc=Value},v2c:function(){gx.fn.setControlValue("LISTCLIDSC",gx.O.A1208ListCliDsc,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1208ListCliDsc=this.val()},val:function(){return gx.fn.getControlValue("LISTCLIDSC")},nac:gx.falseFn};
   GXValidFnc[74]={ id: 74, fld:"BTN_ENTER",grid:0,evt:"e111842_client",std:"ENTER"};
   GXValidFnc[75]={ id: 75, fld:"BTN_CHECK",grid:0,evt:"e191842_client",std:"CHECK"};
   GXValidFnc[76]={ id: 76, fld:"BTN_CANCEL",grid:0,evt:"e121842_client"};
   GXValidFnc[77]={ id: 77, fld:"BTN_DELETE",grid:0,evt:"e201842_client",std:"DELETE"};
   GXValidFnc[78]={ id: 78, fld:"BTN_HELP",grid:0,evt:"e211842_client"};
   this.A37ListItem = 0 ;
   this.Z37ListItem = 0 ;
   this.O37ListItem = 0 ;
   this.A1214ListTipCli = 0 ;
   this.Z1214ListTipCli = 0 ;
   this.O1214ListTipCli = 0 ;
   this.A1211ListLinCod = 0 ;
   this.Z1211ListLinCod = 0 ;
   this.O1211ListLinCod = 0 ;
   this.A39ListProdCod = "" ;
   this.Z39ListProdCod = "" ;
   this.O39ListProdCod = "" ;
   this.A38ListCliCod = "" ;
   this.Z38ListCliCod = "" ;
   this.O38ListCliCod = "" ;
   this.A1212ListPorcentaje = 0 ;
   this.Z1212ListPorcentaje = 0 ;
   this.O1212ListPorcentaje = 0 ;
   this.A1209ListDesde = gx.date.nullDate() ;
   this.Z1209ListDesde = gx.date.nullDate() ;
   this.O1209ListDesde = gx.date.nullDate() ;
   this.A1210ListHasta = gx.date.nullDate() ;
   this.Z1210ListHasta = gx.date.nullDate() ;
   this.O1210ListHasta = gx.date.nullDate() ;
   this.A1215ListTipo = "" ;
   this.Z1215ListTipo = "" ;
   this.O1215ListTipo = "" ;
   this.A1213ListProdDsc = "" ;
   this.Z1213ListProdDsc = "" ;
   this.O1213ListProdDsc = "" ;
   this.A1208ListCliDsc = "" ;
   this.Z1208ListCliDsc = "" ;
   this.O1208ListCliDsc = "" ;
   this.A37ListItem = 0 ;
   this.A1214ListTipCli = 0 ;
   this.A1211ListLinCod = 0 ;
   this.A2262ListSubLCod = 0 ;
   this.A39ListProdCod = "" ;
   this.A38ListCliCod = "" ;
   this.A1212ListPorcentaje = 0 ;
   this.A1209ListDesde = gx.date.nullDate() ;
   this.A1210ListHasta = gx.date.nullDate() ;
   this.A1215ListTipo = "" ;
   this.A1213ListProdDsc = "" ;
   this.A1208ListCliDsc = "" ;
   this.A1206ListCantDesde = 0 ;
   this.A1207ListCantHasta = 0 ;
   this.Events = {"e111842_client": ["ENTER", true] ,"e121842_client": ["CANCEL", true]};
   this.EvtParms["ENTER"] = [[{postForm:true}],[]];
   this.EvtParms["REFRESH"] = [[{av:'A2262ListSubLCod',fld:'LISTSUBLCOD',pic:'ZZZZZ9'},{av:'A1206ListCantDesde',fld:'LISTCANTDESDE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1207ListCantHasta',fld:'LISTCANTHASTA',pic:'ZZZZZZ,ZZZ,ZZ9.99'}],[]];
   this.EvtParms["VALID_LISTITEM"] = [[{av:'A1207ListCantHasta',fld:'LISTCANTHASTA',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1206ListCantDesde',fld:'LISTCANTDESDE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A2262ListSubLCod',fld:'LISTSUBLCOD',pic:'ZZZZZ9'},{av:'A37ListItem',fld:'LISTITEM',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}],[{av:'A1214ListTipCli',fld:'LISTTIPCLI',pic:'ZZZZZ9'},{av:'A1211ListLinCod',fld:'LISTLINCOD',pic:'ZZZZZ9'},{av:'A2262ListSubLCod',fld:'LISTSUBLCOD',pic:'ZZZZZ9'},{av:'A39ListProdCod',fld:'LISTPRODCOD',pic:'@!'},{av:'A38ListCliCod',fld:'LISTCLICOD',pic:''},{av:'A1212ListPorcentaje',fld:'LISTPORCENTAJE',pic:'ZZ9.99'},{av:'A1209ListDesde',fld:'LISTDESDE',pic:''},{av:'A1210ListHasta',fld:'LISTHASTA',pic:''},{av:'A1215ListTipo',fld:'LISTTIPO',pic:''},{av:'A1206ListCantDesde',fld:'LISTCANTDESDE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1207ListCantHasta',fld:'LISTCANTHASTA',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1213ListProdDsc',fld:'LISTPRODDSC',pic:''},{av:'A1208ListCliDsc',fld:'LISTCLIDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z37ListItem'},{av:'Z1214ListTipCli'},{av:'Z1211ListLinCod'},{av:'Z2262ListSubLCod'},{av:'Z39ListProdCod'},{av:'Z38ListCliCod'},{av:'Z1212ListPorcentaje'},{av:'Z1209ListDesde'},{av:'Z1210ListHasta'},{av:'Z1215ListTipo'},{av:'Z1206ListCantDesde'},{av:'Z1207ListCantHasta'},{av:'Z1213ListProdDsc'},{av:'Z1208ListCliDsc'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]];
   this.EvtParms["VALID_LISTPRODCOD"] = [[{av:'A39ListProdCod',fld:'LISTPRODCOD',pic:'@!'},{av:'A1213ListProdDsc',fld:'LISTPRODDSC',pic:''}],[{av:'A1213ListProdDsc',fld:'LISTPRODDSC',pic:''}]];
   this.EvtParms["VALID_LISTCLICOD"] = [[{av:'A38ListCliCod',fld:'LISTCLICOD',pic:''},{av:'A1208ListCliDsc',fld:'LISTCLIDSC',pic:''}],[{av:'A1208ListCliDsc',fld:'LISTCLIDSC',pic:''}]];
   this.EvtParms["VALID_LISTDESDE"] = [[{av:'A1209ListDesde',fld:'LISTDESDE',pic:''}],[{av:'A1209ListDesde',fld:'LISTDESDE',pic:''}]];
   this.EvtParms["VALID_LISTHASTA"] = [[{av:'A1210ListHasta',fld:'LISTHASTA',pic:''}],[{av:'A1210ListHasta',fld:'LISTHASTA',pic:''}]];
   this.EnterCtrl = ["BTN_ENTER"];
   this.CheckCtrl = ["BTN_CHECK"];
   this.setVCMap("A2262ListSubLCod", "LISTSUBLCOD", 0, "int", 6, 0);
   this.setVCMap("A1206ListCantDesde", "LISTCANTDESDE", 0, "decimal", 15, 2);
   this.setVCMap("A1207ListCantHasta", "LISTCANTHASTA", 0, "decimal", 15, 2);
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(this.alistadescuento);});
