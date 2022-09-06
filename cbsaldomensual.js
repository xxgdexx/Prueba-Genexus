gx.evt.autoSkip = false;
gx.define('cbsaldomensual', false, function () {
   this.ServerClass =  "cbsaldomensual" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.ServerFullClass =  "cbsaldomensual.aspx" ;
   this.setObjectType("trn");
   this.hasEnterEvent = true;
   this.skipOnEnter = false;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
   };
   this.Valid_Salvouano=function()
   {
      return this.validCliEvt("Valid_Salvouano", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("SALVOUANO");
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
   this.Valid_Salvoumes=function()
   {
      return this.validCliEvt("Valid_Salvoumes", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("SALVOUMES");
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
   this.Valid_Salcuecod=function()
   {
      return this.validSrvEvt("Valid_Salcuecod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Salmoncod=function()
   {
      return this.validCliEvt("Valid_Salmoncod", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("SALMONCOD");
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
   this.Valid_Salcueaux=function()
   {
      return this.validSrvEvt("Valid_Salcueaux", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.e112069_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e122069_client=function()
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
   GXValidFnc[12]={ id: 12, fld:"BTN_FIRST",grid:0,evt:"e132069_client",std:"FIRST"};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"BTN_PREVIOUS",grid:0,evt:"e142069_client",std:"PREVIOUS"};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id: 16, fld:"BTN_NEXT",grid:0,evt:"e152069_client",std:"NEXT"};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"BTN_LAST",grid:0,evt:"e162069_client",std:"LAST"};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"BTN_SELECT",grid:0,evt:"e172069_client",std:"SELECT"};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[26]={ id: 26, fld:"",grid:0};
   GXValidFnc[27]={ id: 27, fld:"",grid:0};
   GXValidFnc[28]={ id:28 ,lvl:0,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Salvouano,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SALVOUANO",gxz:"Z121SalVouAno",gxold:"O121SalVouAno",gxvar:"A121SalVouAno",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A121SalVouAno=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z121SalVouAno=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("SALVOUANO",gx.O.A121SalVouAno,0)},c2v:function(){if(this.val()!==undefined)gx.O.A121SalVouAno=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("SALVOUANO",',')},nac:gx.falseFn};
   GXValidFnc[29]={ id: 29, fld:"",grid:0};
   GXValidFnc[30]={ id: 30, fld:"",grid:0};
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   GXValidFnc[32]={ id: 32, fld:"",grid:0};
   GXValidFnc[33]={ id:33 ,lvl:0,type:"int",len:2,dec:0,sign:false,pic:"Z9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Salvoumes,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SALVOUMES",gxz:"Z122SalVouMes",gxold:"O122SalVouMes",gxvar:"A122SalVouMes",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A122SalVouMes=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z122SalVouMes=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("SALVOUMES",gx.O.A122SalVouMes,0)},c2v:function(){if(this.val()!==undefined)gx.O.A122SalVouMes=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("SALVOUMES",',')},nac:gx.falseFn};
   GXValidFnc[34]={ id: 34, fld:"",grid:0};
   GXValidFnc[35]={ id: 35, fld:"",grid:0};
   GXValidFnc[36]={ id: 36, fld:"",grid:0};
   GXValidFnc[37]={ id: 37, fld:"",grid:0};
   GXValidFnc[38]={ id:38 ,lvl:0,type:"char",len:15,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Salcuecod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SALCUECOD",gxz:"Z123SalCueCod",gxold:"O123SalCueCod",gxvar:"A123SalCueCod",ucs:[],op:[],ip:[38],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A123SalCueCod=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z123SalCueCod=Value},v2c:function(){gx.fn.setControlValue("SALCUECOD",gx.O.A123SalCueCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A123SalCueCod=this.val()},val:function(){return gx.fn.getControlValue("SALCUECOD")},nac:gx.falseFn};
   GXValidFnc[39]={ id: 39, fld:"",grid:0};
   GXValidFnc[40]={ id: 40, fld:"",grid:0};
   GXValidFnc[41]={ id: 41, fld:"",grid:0};
   GXValidFnc[42]={ id: 42, fld:"",grid:0};
   GXValidFnc[43]={ id:43 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Salmoncod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SALMONCOD",gxz:"Z124SalMonCod",gxold:"O124SalMonCod",gxvar:"A124SalMonCod",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A124SalMonCod=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z124SalMonCod=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("SALMONCOD",gx.O.A124SalMonCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A124SalMonCod=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("SALMONCOD",',')},nac:gx.falseFn};
   GXValidFnc[44]={ id: 44, fld:"",grid:0};
   GXValidFnc[45]={ id: 45, fld:"",grid:0};
   GXValidFnc[46]={ id: 46, fld:"",grid:0};
   GXValidFnc[47]={ id: 47, fld:"",grid:0};
   GXValidFnc[48]={ id:48 ,lvl:0,type:"char",len:20,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Salcueaux,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SALCUEAUX",gxz:"Z125SalCueAux",gxold:"O125SalCueAux",gxvar:"A125SalCueAux",ucs:[],op:[73,68,63,58,53],ip:[73,68,63,58,53,48,43,38,33,28],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A125SalCueAux=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z125SalCueAux=Value},v2c:function(){gx.fn.setControlValue("SALCUEAUX",gx.O.A125SalCueAux,0)},c2v:function(){if(this.val()!==undefined)gx.O.A125SalCueAux=this.val()},val:function(){return gx.fn.getControlValue("SALCUEAUX")},nac:gx.falseFn};
   GXValidFnc[49]={ id: 49, fld:"",grid:0};
   GXValidFnc[50]={ id: 50, fld:"",grid:0};
   GXValidFnc[51]={ id: 51, fld:"",grid:0};
   GXValidFnc[52]={ id: 52, fld:"",grid:0};
   GXValidFnc[53]={ id:53 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SALVOUDEBE",gxz:"Z1839SalVouDebe",gxold:"O1839SalVouDebe",gxvar:"A1839SalVouDebe",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1839SalVouDebe=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z1839SalVouDebe=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("SALVOUDEBE",gx.O.A1839SalVouDebe,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A1839SalVouDebe=this.val()},val:function(){return gx.fn.getDecimalValue("SALVOUDEBE",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 53 , function() {
   });
   GXValidFnc[54]={ id: 54, fld:"",grid:0};
   GXValidFnc[55]={ id: 55, fld:"",grid:0};
   GXValidFnc[56]={ id: 56, fld:"",grid:0};
   GXValidFnc[57]={ id: 57, fld:"",grid:0};
   GXValidFnc[58]={ id:58 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SALVOUHABER",gxz:"Z1841SalVouHaber",gxold:"O1841SalVouHaber",gxvar:"A1841SalVouHaber",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1841SalVouHaber=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z1841SalVouHaber=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("SALVOUHABER",gx.O.A1841SalVouHaber,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A1841SalVouHaber=this.val()},val:function(){return gx.fn.getDecimalValue("SALVOUHABER",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 58 , function() {
   });
   GXValidFnc[59]={ id: 59, fld:"",grid:0};
   GXValidFnc[60]={ id: 60, fld:"",grid:0};
   GXValidFnc[61]={ id: 61, fld:"",grid:0};
   GXValidFnc[62]={ id: 62, fld:"",grid:0};
   GXValidFnc[63]={ id:63 ,lvl:0,type:"decimal",len:15,dec:4,sign:true,pic:"ZZZZ,ZZZ,ZZ9.9999",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SALTIPCMB",gxz:"Z1838SalTipCmb",gxold:"O1838SalTipCmb",gxvar:"A1838SalTipCmb",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1838SalTipCmb=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z1838SalTipCmb=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("SALTIPCMB",gx.O.A1838SalTipCmb,4,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A1838SalTipCmb=this.val()},val:function(){return gx.fn.getDecimalValue("SALTIPCMB",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 63 , function() {
   });
   GXValidFnc[64]={ id: 64, fld:"",grid:0};
   GXValidFnc[65]={ id: 65, fld:"",grid:0};
   GXValidFnc[66]={ id: 66, fld:"",grid:0};
   GXValidFnc[67]={ id: 67, fld:"",grid:0};
   GXValidFnc[68]={ id:68 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SALVOUDEBED",gxz:"Z1840SalVouDebeD",gxold:"O1840SalVouDebeD",gxvar:"A1840SalVouDebeD",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1840SalVouDebeD=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z1840SalVouDebeD=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("SALVOUDEBED",gx.O.A1840SalVouDebeD,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A1840SalVouDebeD=this.val()},val:function(){return gx.fn.getDecimalValue("SALVOUDEBED",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 68 , function() {
   });
   GXValidFnc[69]={ id: 69, fld:"",grid:0};
   GXValidFnc[70]={ id: 70, fld:"",grid:0};
   GXValidFnc[71]={ id: 71, fld:"",grid:0};
   GXValidFnc[72]={ id: 72, fld:"",grid:0};
   GXValidFnc[73]={ id:73 ,lvl:0,type:"decimal",len:15,dec:2,sign:true,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SALVOUHABERD",gxz:"Z1842SalVouHaberD",gxold:"O1842SalVouHaberD",gxvar:"A1842SalVouHaberD",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1842SalVouHaberD=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z1842SalVouHaberD=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("SALVOUHABERD",gx.O.A1842SalVouHaberD,2,'.');if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A1842SalVouHaberD=this.val()},val:function(){return gx.fn.getDecimalValue("SALVOUHABERD",',','.')},nac:gx.falseFn};
   this.declareDomainHdlr( 73 , function() {
   });
   GXValidFnc[74]={ id: 74, fld:"",grid:0};
   GXValidFnc[75]={ id: 75, fld:"",grid:0};
   GXValidFnc[76]={ id: 76, fld:"",grid:0};
   GXValidFnc[77]={ id: 77, fld:"",grid:0};
   GXValidFnc[78]={ id: 78, fld:"BTN_ENTER",grid:0,evt:"e112069_client",std:"ENTER"};
   GXValidFnc[79]={ id: 79, fld:"",grid:0};
   GXValidFnc[80]={ id: 80, fld:"BTN_CANCEL",grid:0,evt:"e122069_client"};
   GXValidFnc[81]={ id: 81, fld:"",grid:0};
   GXValidFnc[82]={ id: 82, fld:"BTN_DELETE",grid:0,evt:"e182069_client",std:"DELETE"};
   this.A121SalVouAno = 0 ;
   this.Z121SalVouAno = 0 ;
   this.O121SalVouAno = 0 ;
   this.A122SalVouMes = 0 ;
   this.Z122SalVouMes = 0 ;
   this.O122SalVouMes = 0 ;
   this.A123SalCueCod = "" ;
   this.Z123SalCueCod = "" ;
   this.O123SalCueCod = "" ;
   this.A124SalMonCod = 0 ;
   this.Z124SalMonCod = 0 ;
   this.O124SalMonCod = 0 ;
   this.A125SalCueAux = "" ;
   this.Z125SalCueAux = "" ;
   this.O125SalCueAux = "" ;
   this.A1839SalVouDebe = 0 ;
   this.Z1839SalVouDebe = 0 ;
   this.O1839SalVouDebe = 0 ;
   this.A1841SalVouHaber = 0 ;
   this.Z1841SalVouHaber = 0 ;
   this.O1841SalVouHaber = 0 ;
   this.A1838SalTipCmb = 0 ;
   this.Z1838SalTipCmb = 0 ;
   this.O1838SalTipCmb = 0 ;
   this.A1840SalVouDebeD = 0 ;
   this.Z1840SalVouDebeD = 0 ;
   this.O1840SalVouDebeD = 0 ;
   this.A1842SalVouHaberD = 0 ;
   this.Z1842SalVouHaberD = 0 ;
   this.O1842SalVouHaberD = 0 ;
   this.A121SalVouAno = 0 ;
   this.A122SalVouMes = 0 ;
   this.A123SalCueCod = "" ;
   this.A124SalMonCod = 0 ;
   this.A125SalCueAux = "" ;
   this.A1839SalVouDebe = 0 ;
   this.A1841SalVouHaber = 0 ;
   this.A1838SalTipCmb = 0 ;
   this.A1840SalVouDebeD = 0 ;
   this.A1842SalVouHaberD = 0 ;
   this.Events = {"e112069_client": ["ENTER", true] ,"e122069_client": ["CANCEL", true]};
   this.EvtParms["ENTER"] = [[{postForm:true}],[]];
   this.EvtParms["REFRESH"] = [[],[]];
   this.EvtParms["VALID_SALVOUANO"] = [[],[]];
   this.EvtParms["VALID_SALVOUMES"] = [[],[]];
   this.EvtParms["VALID_SALCUECOD"] = [[{av:'A123SalCueCod',fld:'SALCUECOD',pic:''}],[]];
   this.EvtParms["VALID_SALMONCOD"] = [[],[]];
   this.EvtParms["VALID_SALCUEAUX"] = [[{av:'A121SalVouAno',fld:'SALVOUANO',pic:'ZZZ9'},{av:'A122SalVouMes',fld:'SALVOUMES',pic:'Z9'},{av:'A123SalCueCod',fld:'SALCUECOD',pic:''},{av:'A124SalMonCod',fld:'SALMONCOD',pic:'ZZZZZ9'},{av:'A125SalCueAux',fld:'SALCUEAUX',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}],[{av:'A1839SalVouDebe',fld:'SALVOUDEBE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1841SalVouHaber',fld:'SALVOUHABER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1838SalTipCmb',fld:'SALTIPCMB',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1840SalVouDebeD',fld:'SALVOUDEBED',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1842SalVouHaberD',fld:'SALVOUHABERD',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z121SalVouAno'},{av:'Z122SalVouMes'},{av:'Z123SalCueCod'},{av:'Z124SalMonCod'},{av:'Z125SalCueAux'},{av:'Z1839SalVouDebe'},{av:'Z1841SalVouHaber'},{av:'Z1838SalTipCmb'},{av:'Z1840SalVouDebeD'},{av:'Z1842SalVouHaberD'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]];
   this.EnterCtrl = ["BTN_ENTER"];
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(this.cbsaldomensual);});
