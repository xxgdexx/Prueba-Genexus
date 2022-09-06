gx.evt.autoSkip = false;
gx.define('cbvoucher', false, function () {
   this.ServerClass =  "cbvoucher" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.ServerFullClass =  "cbvoucher.aspx" ;
   this.setObjectType("trn");
   this.hasEnterEvent = true;
   this.skipOnEnter = false;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
      this.A2079VouTotD=gx.fn.getDecimalValue("VOUTOTD",',','.') ;
      this.A2080VouTotH=gx.fn.getDecimalValue("VOUTOTH",',','.') ;
   };
   this.Valid_Vouano=function()
   {
      return this.validCliEvt("Valid_Vouano", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("VOUANO");
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
   this.Valid_Voumes=function()
   {
      return this.validCliEvt("Valid_Voumes", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("VOUMES");
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
   this.Valid_Tasicod=function()
   {
      return this.validSrvEvt("Valid_Tasicod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Vounum=function()
   {
      return this.validSrvEvt("Valid_Vounum", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Voufec=function()
   {
      return this.validCliEvt("Valid_Voufec", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("VOUFEC");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A2074VouFec)==0) || new gx.date.gxdate( this.A2074VouFec ).compare( gx.date.ymdtod( 1753, 1, 1) ) >= 0 ) )
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
   this.e112372_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e122372_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,5,6,7,8,9,15,18,20,23,25,28,30,33,35,36,39,41,44,46,49,51,54,56,59,61,64,65,66,67,68];
   this.GXLastCtrlId =68;
   GXValidFnc[2]={ id: 2, fld:"TABLE1",grid:0};
   GXValidFnc[5]={ id: 5, fld:"BTN_FIRST",grid:0,evt:"e132372_client",std:"FIRST"};
   GXValidFnc[6]={ id: 6, fld:"BTN_PREVIOUS",grid:0,evt:"e142372_client",std:"PREVIOUS"};
   GXValidFnc[7]={ id: 7, fld:"BTN_NEXT",grid:0,evt:"e152372_client",std:"NEXT"};
   GXValidFnc[8]={ id: 8, fld:"BTN_LAST",grid:0,evt:"e162372_client",std:"LAST"};
   GXValidFnc[9]={ id: 9, fld:"BTN_SELECT",grid:0,evt:"e172372_client",std:"SELECT"};
   GXValidFnc[15]={ id: 15, fld:"TABLE2",grid:0};
   GXValidFnc[18]={ id: 18, fld:"TEXTBLOCK1", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[20]={ id:20 ,lvl:0,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Vouano,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VOUANO",gxz:"Z127VouAno",gxold:"O127VouAno",gxvar:"A127VouAno",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A127VouAno=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z127VouAno=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("VOUANO",gx.O.A127VouAno,0)},c2v:function(){if(this.val()!==undefined)gx.O.A127VouAno=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("VOUANO",',')},nac:gx.falseFn};
   GXValidFnc[23]={ id: 23, fld:"TEXTBLOCK2", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[25]={ id:25 ,lvl:0,type:"int",len:2,dec:0,sign:false,pic:"Z9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Voumes,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VOUMES",gxz:"Z128VouMes",gxold:"O128VouMes",gxvar:"A128VouMes",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A128VouMes=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z128VouMes=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("VOUMES",gx.O.A128VouMes,0)},c2v:function(){if(this.val()!==undefined)gx.O.A128VouMes=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("VOUMES",',')},nac:gx.falseFn};
   GXValidFnc[28]={ id: 28, fld:"TEXTBLOCK3", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[30]={ id:30 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Tasicod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TASICOD",gxz:"Z126TASICod",gxold:"O126TASICod",gxvar:"A126TASICod",ucs:[],op:[],ip:[30],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A126TASICod=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z126TASICod=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("TASICOD",gx.O.A126TASICod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A126TASICod=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("TASICOD",',')},nac:gx.falseFn};
   GXValidFnc[33]={ id: 33, fld:"TEXTBLOCK4", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[35]={ id:35 ,lvl:0,type:"char",len:10,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Vounum,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VOUNUM",gxz:"Z129VouNum",gxold:"O129VouNum",gxvar:"A129VouNum",ucs:[],op:[61,56,51,46,41],ip:[61,56,51,46,41,35,30,25,20],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A129VouNum=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z129VouNum=Value},v2c:function(){gx.fn.setControlValue("VOUNUM",gx.O.A129VouNum,0)},c2v:function(){if(this.val()!==undefined)gx.O.A129VouNum=this.val()},val:function(){return gx.fn.getControlValue("VOUNUM")},nac:gx.falseFn};
   GXValidFnc[36]={ id: 36, fld:"BTN_GET",grid:0,evt:"e182372_client",std:"GET"};
   GXValidFnc[39]={ id: 39, fld:"TEXTBLOCK5", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[41]={ id:41 ,lvl:0,type:"date",len:8,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Voufec,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VOUFEC",gxz:"Z2074VouFec",gxold:"O2074VouFec",gxvar:"A2074VouFec",dp:{f:0,st:false,wn:false,mf:false,pic:"99/99/99",dec:0},ucs:[],op:[41],ip:[41],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A2074VouFec=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z2074VouFec=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("VOUFEC",gx.O.A2074VouFec,0)},c2v:function(){if(this.val()!==undefined)gx.O.A2074VouFec=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getControlValue("VOUFEC")},nac:gx.falseFn};
   GXValidFnc[44]={ id: 44, fld:"TEXTBLOCK6", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[46]={ id:46 ,lvl:0,type:"char",len:100,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VOUGLS",gxz:"Z2075VouGls",gxold:"O2075VouGls",gxvar:"A2075VouGls",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A2075VouGls=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z2075VouGls=Value},v2c:function(){gx.fn.setControlValue("VOUGLS",gx.O.A2075VouGls,0)},c2v:function(){if(this.val()!==undefined)gx.O.A2075VouGls=this.val()},val:function(){return gx.fn.getControlValue("VOUGLS")},nac:gx.falseFn};
   GXValidFnc[49]={ id: 49, fld:"TEXTBLOCK7", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[51]={ id:51 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VOUTSEC",gxz:"Z2081VouTSec",gxold:"O2081VouTSec",gxvar:"A2081VouTSec",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A2081VouTSec=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z2081VouTSec=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("VOUTSEC",gx.O.A2081VouTSec,0)},c2v:function(){if(this.val()!==undefined)gx.O.A2081VouTSec=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("VOUTSEC",',')},nac:gx.falseFn};
   GXValidFnc[54]={ id: 54, fld:"TEXTBLOCK8", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[56]={ id:56 ,lvl:0,type:"int",len:1,dec:0,sign:false,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VOUSTS",gxz:"Z2077VouSts",gxold:"O2077VouSts",gxvar:"A2077VouSts",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A2077VouSts=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z2077VouSts=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("VOUSTS",gx.O.A2077VouSts,0)},c2v:function(){if(this.val()!==undefined)gx.O.A2077VouSts=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("VOUSTS",',')},nac:gx.falseFn};
   GXValidFnc[59]={ id: 59, fld:"TEXTBLOCK9", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[61]={ id:61 ,lvl:0,type:"char",len:3,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VOUTIP",gxz:"Z2078VouTip",gxold:"O2078VouTip",gxvar:"A2078VouTip",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A2078VouTip=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z2078VouTip=Value},v2c:function(){gx.fn.setControlValue("VOUTIP",gx.O.A2078VouTip,0)},c2v:function(){if(this.val()!==undefined)gx.O.A2078VouTip=this.val()},val:function(){return gx.fn.getControlValue("VOUTIP")},nac:gx.falseFn};
   GXValidFnc[64]={ id: 64, fld:"BTN_ENTER",grid:0,evt:"e112372_client",std:"ENTER"};
   GXValidFnc[65]={ id: 65, fld:"BTN_CHECK",grid:0,evt:"e192372_client",std:"CHECK"};
   GXValidFnc[66]={ id: 66, fld:"BTN_CANCEL",grid:0,evt:"e122372_client"};
   GXValidFnc[67]={ id: 67, fld:"BTN_DELETE",grid:0,evt:"e202372_client",std:"DELETE"};
   GXValidFnc[68]={ id: 68, fld:"BTN_HELP",grid:0,evt:"e212372_client"};
   this.A127VouAno = 0 ;
   this.Z127VouAno = 0 ;
   this.O127VouAno = 0 ;
   this.A128VouMes = 0 ;
   this.Z128VouMes = 0 ;
   this.O128VouMes = 0 ;
   this.A126TASICod = 0 ;
   this.Z126TASICod = 0 ;
   this.O126TASICod = 0 ;
   this.A129VouNum = "" ;
   this.Z129VouNum = "" ;
   this.O129VouNum = "" ;
   this.A2074VouFec = gx.date.nullDate() ;
   this.Z2074VouFec = gx.date.nullDate() ;
   this.O2074VouFec = gx.date.nullDate() ;
   this.A2075VouGls = "" ;
   this.Z2075VouGls = "" ;
   this.O2075VouGls = "" ;
   this.A2081VouTSec = 0 ;
   this.Z2081VouTSec = 0 ;
   this.O2081VouTSec = 0 ;
   this.A2077VouSts = 0 ;
   this.Z2077VouSts = 0 ;
   this.O2077VouSts = 0 ;
   this.A2078VouTip = "" ;
   this.Z2078VouTip = "" ;
   this.O2078VouTip = "" ;
   this.A127VouAno = 0 ;
   this.A128VouMes = 0 ;
   this.A126TASICod = 0 ;
   this.A129VouNum = "" ;
   this.A2074VouFec = gx.date.nullDate() ;
   this.A2075VouGls = "" ;
   this.A2081VouTSec = 0 ;
   this.A2077VouSts = 0 ;
   this.A2078VouTip = "" ;
   this.A2079VouTotD = 0 ;
   this.A2080VouTotH = 0 ;
   this.Events = {"e112372_client": ["ENTER", true] ,"e122372_client": ["CANCEL", true]};
   this.EvtParms["ENTER"] = [[{postForm:true}],[]];
   this.EvtParms["REFRESH"] = [[],[]];
   this.EvtParms["VALID_VOUANO"] = [[],[]];
   this.EvtParms["VALID_VOUMES"] = [[],[]];
   this.EvtParms["VALID_TASICOD"] = [[{av:'A126TASICod',fld:'TASICOD',pic:'ZZZZZ9'}],[]];
   this.EvtParms["VALID_VOUNUM"] = [[{av:'A127VouAno',fld:'VOUANO',pic:'ZZZ9'},{av:'A128VouMes',fld:'VOUMES',pic:'Z9'},{av:'A126TASICod',fld:'TASICOD',pic:'ZZZZZ9'},{av:'A129VouNum',fld:'VOUNUM',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}],[{av:'A2074VouFec',fld:'VOUFEC',pic:''},{av:'A2075VouGls',fld:'VOUGLS',pic:''},{av:'A2081VouTSec',fld:'VOUTSEC',pic:'ZZZZZ9'},{av:'A2077VouSts',fld:'VOUSTS',pic:'9'},{av:'A2078VouTip',fld:'VOUTIP',pic:''},{av:'A2079VouTotD',fld:'VOUTOTD',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A2080VouTotH',fld:'VOUTOTH',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z127VouAno'},{av:'Z128VouMes'},{av:'Z126TASICod'},{av:'Z129VouNum'},{av:'Z2074VouFec'},{av:'Z2075VouGls'},{av:'Z2081VouTSec'},{av:'Z2077VouSts'},{av:'Z2078VouTip'},{av:'Z2079VouTotD'},{av:'Z2080VouTotH'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]];
   this.EvtParms["VALID_VOUFEC"] = [[{av:'A2074VouFec',fld:'VOUFEC',pic:''}],[{av:'A2074VouFec',fld:'VOUFEC',pic:''}]];
   this.EnterCtrl = ["BTN_ENTER"];
   this.CheckCtrl = ["BTN_CHECK"];
   this.setVCMap("A2079VouTotD", "VOUTOTD", 0, "decimal", 15, 2);
   this.setVCMap("A2080VouTotH", "VOUTOTH", 0, "decimal", 15, 2);
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(this.cbvoucher);});
