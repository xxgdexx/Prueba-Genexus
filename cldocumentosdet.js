gx.evt.autoSkip = false;
gx.define('cldocumentosdet', false, function () {
   this.ServerClass =  "cldocumentosdet" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.ServerFullClass =  "cldocumentosdet.aspx" ;
   this.setObjectType("trn");
   this.hasEnterEvent = true;
   this.skipOnEnter = false;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
   };
   this.Valid_Impitem=function()
   {
      return this.validSrvEvt("Valid_Impitem", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Impditem=function()
   {
      return this.validSrvEvt("Valid_Impditem", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Impdprodcod=function()
   {
      return this.validSrvEvt("Valid_Impdprodcod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.e112m90_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e122m90_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,5,6,7,8,9,15,18,20,23,25,26,29,31,34,36,39,41,44,46,49,51,54,56,59,61,64,66,69,70,71,72,73];
   this.GXLastCtrlId =73;
   GXValidFnc[2]={ id: 2, fld:"TABLE1",grid:0};
   GXValidFnc[5]={ id: 5, fld:"BTN_FIRST",grid:0,evt:"e132m90_client",std:"FIRST"};
   GXValidFnc[6]={ id: 6, fld:"BTN_PREVIOUS",grid:0,evt:"e142m90_client",std:"PREVIOUS"};
   GXValidFnc[7]={ id: 7, fld:"BTN_NEXT",grid:0,evt:"e152m90_client",std:"NEXT"};
   GXValidFnc[8]={ id: 8, fld:"BTN_LAST",grid:0,evt:"e162m90_client",std:"LAST"};
   GXValidFnc[9]={ id: 9, fld:"BTN_SELECT",grid:0,evt:"e172m90_client",std:"SELECT"};
   GXValidFnc[15]={ id: 15, fld:"TABLE2",grid:0};
   GXValidFnc[18]={ id: 18, fld:"TEXTBLOCK1", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[20]={ id:20 ,lvl:0,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Impitem,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPITEM",gxz:"Z191ImpItem",gxold:"O191ImpItem",gxvar:"A191ImpItem",ucs:[],op:[],ip:[20],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A191ImpItem=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z191ImpItem=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("IMPITEM",gx.O.A191ImpItem,0)},c2v:function(){if(this.val()!==undefined)gx.O.A191ImpItem=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("IMPITEM",',')},nac:gx.falseFn};
   GXValidFnc[23]={ id: 23, fld:"TEXTBLOCK2", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[25]={ id:25 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Impditem,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPDITEM",gxz:"Z197ImpDItem",gxold:"O197ImpDItem",gxvar:"A197ImpDItem",ucs:[],op:[31,66,61,56,51,46,41,36],ip:[31,66,61,56,51,46,41,36,25,20],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A197ImpDItem=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z197ImpDItem=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("IMPDITEM",gx.O.A197ImpDItem,0)},c2v:function(){if(this.val()!==undefined)gx.O.A197ImpDItem=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("IMPDITEM",',')},nac:gx.falseFn};
   GXValidFnc[26]={ id: 26, fld:"BTN_GET",grid:0,evt:"e182m90_client",std:"GET"};
   GXValidFnc[29]={ id: 29, fld:"TEXTBLOCK3", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[31]={ id:31 ,lvl:0,type:"char",len:15,dec:0,sign:false,pic:"@!",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Impdprodcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPDPRODCOD",gxz:"Z198ImpDProdCod",gxold:"O198ImpDProdCod",gxvar:"A198ImpDProdCod",ucs:[],op:[],ip:[31],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A198ImpDProdCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z198ImpDProdCod=Value},v2c:function(){gx.fn.setControlValue("IMPDPRODCOD",gx.O.A198ImpDProdCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A198ImpDProdCod=this.val()},val:function(){return gx.fn.getControlValue("IMPDPRODCOD")},nac:gx.falseFn};
   GXValidFnc[34]={ id: 34, fld:"TEXTBLOCK4", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[36]={ id:36 ,lvl:0,type:"decimal",len:15,dec:4,sign:true,pic:"ZZZZ,ZZZ,ZZ9.9999",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPDCANT",gxz:"Z1025ImpDCant",gxold:"O1025ImpDCant",gxvar:"A1025ImpDCant",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1025ImpDCant=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z1025ImpDCant=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("IMPDCANT",gx.O.A1025ImpDCant,4,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A1025ImpDCant=this.val()},val:function(){return gx.fn.getDecimalValue("IMPDCANT",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 36 , function() {
   });
   GXValidFnc[39]={ id: 39, fld:"TEXTBLOCK5", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[41]={ id:41 ,lvl:0,type:"decimal",len:15,dec:4,sign:true,pic:"ZZZZ,ZZZ,ZZ9.9999",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPDPRE",gxz:"Z1032ImpDPre",gxold:"O1032ImpDPre",gxvar:"A1032ImpDPre",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1032ImpDPre=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z1032ImpDPre=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("IMPDPRE",gx.O.A1032ImpDPre,4,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A1032ImpDPre=this.val()},val:function(){return gx.fn.getDecimalValue("IMPDPRE",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 41 , function() {
   });
   GXValidFnc[44]={ id: 44, fld:"TEXTBLOCK6", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[46]={ id:46 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPDDCT",gxz:"Z1026ImpDDct",gxold:"O1026ImpDDct",gxvar:"A1026ImpDDct",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1026ImpDDct=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z1026ImpDDct=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("IMPDDCT",gx.O.A1026ImpDDct,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A1026ImpDDct=this.val()},val:function(){return gx.fn.getDecimalValue("IMPDDCT",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 46 , function() {
   });
   GXValidFnc[49]={ id: 49, fld:"TEXTBLOCK7", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[51]={ id:51 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPDDCT2",gxz:"Z1027ImpDDct2",gxold:"O1027ImpDDct2",gxvar:"A1027ImpDDct2",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1027ImpDDct2=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z1027ImpDDct2=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("IMPDDCT2",gx.O.A1027ImpDDct2,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A1027ImpDDct2=this.val()},val:function(){return gx.fn.getDecimalValue("IMPDDCT2",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 51 , function() {
   });
   GXValidFnc[54]={ id: 54, fld:"TEXTBLOCK8", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[56]={ id:56 ,lvl:0,type:"vchar",len:500,dec:0,sign:false,ro:0,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPDOBS",gxz:"Z1029ImpDObs",gxold:"O1029ImpDObs",gxvar:"A1029ImpDObs",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1029ImpDObs=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z1029ImpDObs=Value},v2c:function(){gx.fn.setControlValue("IMPDOBS",gx.O.A1029ImpDObs,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1029ImpDObs=this.val()},val:function(){return gx.fn.getControlValue("IMPDOBS")},nac:gx.falseFn};
   GXValidFnc[59]={ id: 59, fld:"TEXTBLOCK9", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[61]={ id:61 ,lvl:0,type:"int",len:1,dec:0,sign:false,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPDINA",gxz:"Z1028ImpDIna",gxold:"O1028ImpDIna",gxvar:"A1028ImpDIna",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1028ImpDIna=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1028ImpDIna=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("IMPDINA",gx.O.A1028ImpDIna,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1028ImpDIna=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("IMPDINA",',')},nac:gx.falseFn};
   GXValidFnc[64]={ id: 64, fld:"TEXTBLOCK10", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[66]={ id:66 ,lvl:0,type:"int",len:5,dec:0,sign:false,pic:"ZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPDPORSEL",gxz:"Z1031ImpDPorSel",gxold:"O1031ImpDPorSel",gxvar:"A1031ImpDPorSel",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1031ImpDPorSel=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1031ImpDPorSel=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("IMPDPORSEL",gx.O.A1031ImpDPorSel,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1031ImpDPorSel=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("IMPDPORSEL",',')},nac:gx.falseFn};
   GXValidFnc[69]={ id: 69, fld:"BTN_ENTER",grid:0,evt:"e112m90_client",std:"ENTER"};
   GXValidFnc[70]={ id: 70, fld:"BTN_CHECK",grid:0,evt:"e192m90_client",std:"CHECK"};
   GXValidFnc[71]={ id: 71, fld:"BTN_CANCEL",grid:0,evt:"e122m90_client"};
   GXValidFnc[72]={ id: 72, fld:"BTN_DELETE",grid:0,evt:"e202m90_client",std:"DELETE"};
   GXValidFnc[73]={ id: 73, fld:"BTN_HELP",grid:0,evt:"e212m90_client"};
   this.A191ImpItem = 0 ;
   this.Z191ImpItem = 0 ;
   this.O191ImpItem = 0 ;
   this.A197ImpDItem = 0 ;
   this.Z197ImpDItem = 0 ;
   this.O197ImpDItem = 0 ;
   this.A198ImpDProdCod = "" ;
   this.Z198ImpDProdCod = "" ;
   this.O198ImpDProdCod = "" ;
   this.A1025ImpDCant = 0 ;
   this.Z1025ImpDCant = 0 ;
   this.O1025ImpDCant = 0 ;
   this.A1032ImpDPre = 0 ;
   this.Z1032ImpDPre = 0 ;
   this.O1032ImpDPre = 0 ;
   this.A1026ImpDDct = 0 ;
   this.Z1026ImpDDct = 0 ;
   this.O1026ImpDDct = 0 ;
   this.A1027ImpDDct2 = 0 ;
   this.Z1027ImpDDct2 = 0 ;
   this.O1027ImpDDct2 = 0 ;
   this.A1029ImpDObs = "" ;
   this.Z1029ImpDObs = "" ;
   this.O1029ImpDObs = "" ;
   this.A1028ImpDIna = 0 ;
   this.Z1028ImpDIna = 0 ;
   this.O1028ImpDIna = 0 ;
   this.A1031ImpDPorSel = 0 ;
   this.Z1031ImpDPorSel = 0 ;
   this.O1031ImpDPorSel = 0 ;
   this.A191ImpItem = 0 ;
   this.A197ImpDItem = 0 ;
   this.A198ImpDProdCod = "" ;
   this.A1025ImpDCant = 0 ;
   this.A1032ImpDPre = 0 ;
   this.A1026ImpDDct = 0 ;
   this.A1027ImpDDct2 = 0 ;
   this.A1029ImpDObs = "" ;
   this.A1028ImpDIna = 0 ;
   this.A1031ImpDPorSel = 0 ;
   this.Events = {"e112m90_client": ["ENTER", true] ,"e122m90_client": ["CANCEL", true]};
   this.EvtParms["ENTER"] = [[{postForm:true}],[]];
   this.EvtParms["REFRESH"] = [[],[]];
   this.EvtParms["VALID_IMPITEM"] = [[{av:'A191ImpItem',fld:'IMPITEM',pic:'ZZZZZZZZZ9'}],[]];
   this.EvtParms["VALID_IMPDITEM"] = [[{av:'A191ImpItem',fld:'IMPITEM',pic:'ZZZZZZZZZ9'},{av:'A197ImpDItem',fld:'IMPDITEM',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}],[{av:'A198ImpDProdCod',fld:'IMPDPRODCOD',pic:'@!'},{av:'A1025ImpDCant',fld:'IMPDCANT',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1032ImpDPre',fld:'IMPDPRE',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1026ImpDDct',fld:'IMPDDCT',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1027ImpDDct2',fld:'IMPDDCT2',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1029ImpDObs',fld:'IMPDOBS',pic:''},{av:'A1028ImpDIna',fld:'IMPDINA',pic:'9'},{av:'A1031ImpDPorSel',fld:'IMPDPORSEL',pic:'ZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z191ImpItem'},{av:'Z197ImpDItem'},{av:'Z198ImpDProdCod'},{av:'Z1025ImpDCant'},{av:'Z1032ImpDPre'},{av:'Z1026ImpDDct'},{av:'Z1027ImpDDct2'},{av:'Z1029ImpDObs'},{av:'Z1028ImpDIna'},{av:'Z1031ImpDPorSel'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]];
   this.EvtParms["VALID_IMPDPRODCOD"] = [[{av:'A198ImpDProdCod',fld:'IMPDPRODCOD',pic:'@!'}],[]];
   this.EnterCtrl = ["BTN_ENTER"];
   this.CheckCtrl = ["BTN_CHECK"];
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(this.cldocumentosdet);});
