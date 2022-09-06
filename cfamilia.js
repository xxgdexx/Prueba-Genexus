gx.evt.autoSkip = false;
gx.define('cfamilia', false, function () {
   this.ServerClass =  "cfamilia" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.ServerFullClass =  "cfamilia.aspx" ;
   this.setObjectType("trn");
   this.hasEnterEvent = true;
   this.skipOnEnter = false;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
      this.A40000FamFoto_GXI=gx.fn.getControlValue("FAMFOTO_GXI") ;
   };
   this.Valid_Famcod=function()
   {
      return this.validSrvEvt("Valid_Famcod", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.e122b2_client=function()
   {
      return this.executeServerEvent("AFTER TRN", true, null, false, false);
   };
   this.e132b80_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e142b80_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51];
   this.GXLastCtrlId =51;
   this.DVPANEL_TABLEATTRIBUTESContainer = gx.uc.getNew(this, 15, 0, "BootstrapPanel", "DVPANEL_TABLEATTRIBUTESContainer", "Dvpanel_tableattributes", "DVPANEL_TABLEATTRIBUTES");
   var DVPANEL_TABLEATTRIBUTESContainer = this.DVPANEL_TABLEATTRIBUTESContainer;
   DVPANEL_TABLEATTRIBUTESContainer.setProp("Class", "Class", "", "char");
   DVPANEL_TABLEATTRIBUTESContainer.setProp("Enabled", "Enabled", true, "boolean");
   DVPANEL_TABLEATTRIBUTESContainer.setProp("Width", "Width", "100%", "str");
   DVPANEL_TABLEATTRIBUTESContainer.setProp("Height", "Height", "100", "str");
   DVPANEL_TABLEATTRIBUTESContainer.setProp("AutoWidth", "Autowidth", false, "bool");
   DVPANEL_TABLEATTRIBUTESContainer.setProp("AutoHeight", "Autoheight", true, "bool");
   DVPANEL_TABLEATTRIBUTESContainer.setProp("Cls", "Cls", "PanelFilled Panel_BaseColor", "str");
   DVPANEL_TABLEATTRIBUTESContainer.setProp("ShowHeader", "Showheader", true, "bool");
   DVPANEL_TABLEATTRIBUTESContainer.setProp("Title", "Title", "Información General", "str");
   DVPANEL_TABLEATTRIBUTESContainer.setProp("Collapsible", "Collapsible", false, "bool");
   DVPANEL_TABLEATTRIBUTESContainer.setProp("Collapsed", "Collapsed", false, "bool");
   DVPANEL_TABLEATTRIBUTESContainer.setProp("ShowCollapseIcon", "Showcollapseicon", false, "bool");
   DVPANEL_TABLEATTRIBUTESContainer.setProp("IconPosition", "Iconposition", "Right", "str");
   DVPANEL_TABLEATTRIBUTESContainer.setProp("AutoScroll", "Autoscroll", false, "bool");
   DVPANEL_TABLEATTRIBUTESContainer.setProp("Visible", "Visible", true, "bool");
   DVPANEL_TABLEATTRIBUTESContainer.setProp("Gx Control Type", "Gxcontroltype", '', "int");
   DVPANEL_TABLEATTRIBUTESContainer.setC2ShowFunction(function(UC) { UC.show(); });
   this.setUserControl(DVPANEL_TABLEATTRIBUTESContainer);
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"LAYOUTMAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"TABLEMAIN",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[11]={ id: 11, fld:"",grid:0};
   GXValidFnc[12]={ id: 12, fld:"TABLECONTENT",grid:0};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"",grid:0};
   GXValidFnc[17]={ id: 17, fld:"TABLEATTRIBUTES",grid:0};
   GXValidFnc[18]={ id: 18, fld:"",grid:0};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"",grid:0};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[22]={ id:22 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Famcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FAMCOD",gxz:"Z50FamCod",gxold:"O50FamCod",gxvar:"A50FamCod",ucs:[],op:[42,37,32,27],ip:[42,37,32,27,22],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A50FamCod=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z50FamCod=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("FAMCOD",gx.O.A50FamCod,0)},c2v:function(){if(this.val()!==undefined)gx.O.A50FamCod=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("FAMCOD",',')},nac:gx.falseFn};
   GXValidFnc[23]={ id: 23, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[26]={ id: 26, fld:"",grid:0};
   GXValidFnc[27]={ id:27 ,lvl:0,type:"char",len:100,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FAMDSC",gxz:"Z977FamDsc",gxold:"O977FamDsc",gxvar:"A977FamDsc",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A977FamDsc=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z977FamDsc=Value},v2c:function(){gx.fn.setControlValue("FAMDSC",gx.O.A977FamDsc,0)},c2v:function(){if(this.val()!==undefined)gx.O.A977FamDsc=this.val()},val:function(){return gx.fn.getControlValue("FAMDSC")},nac:gx.falseFn};
   GXValidFnc[28]={ id: 28, fld:"",grid:0};
   GXValidFnc[29]={ id: 29, fld:"",grid:0};
   GXValidFnc[30]={ id: 30, fld:"",grid:0};
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   GXValidFnc[32]={ id:32 ,lvl:0,type:"char",len:5,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FAMABR",gxz:"Z976FamAbr",gxold:"O976FamAbr",gxvar:"A976FamAbr",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A976FamAbr=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z976FamAbr=Value},v2c:function(){gx.fn.setControlValue("FAMABR",gx.O.A976FamAbr,0)},c2v:function(){if(this.val()!==undefined)gx.O.A976FamAbr=this.val()},val:function(){return gx.fn.getControlValue("FAMABR")},nac:gx.falseFn};
   GXValidFnc[33]={ id: 33, fld:"",grid:0};
   GXValidFnc[34]={ id: 34, fld:"",grid:0};
   GXValidFnc[35]={ id: 35, fld:"",grid:0};
   GXValidFnc[36]={ id: 36, fld:"",grid:0};
   GXValidFnc[37]={ id:37 ,lvl:0,type:"int",len:1,dec:0,sign:false,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FAMSTS",gxz:"Z979FamSts",gxold:"O979FamSts",gxvar:"A979FamSts",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"combo",v2v:function(Value){if(Value!==undefined)gx.O.A979FamSts=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z979FamSts=gx.num.intval(Value)},v2c:function(){gx.fn.setComboBoxValue("FAMSTS",gx.O.A979FamSts)},c2v:function(){if(this.val()!==undefined)gx.O.A979FamSts=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("FAMSTS",',')},nac:gx.falseFn};
   GXValidFnc[38]={ id: 38, fld:"",grid:0};
   GXValidFnc[39]={ id: 39, fld:"",grid:0};
   GXValidFnc[40]={ id: 40, fld:"",grid:0};
   GXValidFnc[41]={ id: 41, fld:"",grid:0};
   GXValidFnc[42]={ id:42 ,lvl:0,type:"bits",len:1024,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FAMFOTO",gxz:"Z978FamFoto",gxold:"O978FamFoto",gxvar:"A978FamFoto",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A978FamFoto=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z978FamFoto=Value},v2c:function(){gx.fn.setMultimediaValue("FAMFOTO",gx.O.A978FamFoto,gx.O.A40000FamFoto_GXI)},c2v:function(){gx.O.A40000FamFoto_GXI=this.val_GXI();if(this.val()!==undefined)gx.O.A978FamFoto=this.val()},val:function(){return gx.fn.getBlobValue("FAMFOTO")},val_GXI:function(){return gx.fn.getControlValue("FAMFOTO_GXI")}, gxvar_GXI:'A40000FamFoto_GXI',nac:gx.falseFn};
   GXValidFnc[43]={ id: 43, fld:"",grid:0};
   GXValidFnc[44]={ id: 44, fld:"",grid:0};
   GXValidFnc[45]={ id: 45, fld:"",grid:0};
   GXValidFnc[46]={ id: 46, fld:"",grid:0};
   GXValidFnc[47]={ id: 47, fld:"BTNTRN_ENTER",grid:0,evt:"e132b80_client",std:"ENTER"};
   GXValidFnc[48]={ id: 48, fld:"",grid:0};
   GXValidFnc[49]={ id: 49, fld:"BTNTRN_CANCEL",grid:0,evt:"e142b80_client"};
   GXValidFnc[50]={ id: 50, fld:"",grid:0};
   GXValidFnc[51]={ id: 51, fld:"BTNTRN_DELETE",grid:0,evt:"e152b80_client",std:"DELETE"};
   this.A50FamCod = 0 ;
   this.Z50FamCod = 0 ;
   this.O50FamCod = 0 ;
   this.A977FamDsc = "" ;
   this.Z977FamDsc = "" ;
   this.O977FamDsc = "" ;
   this.A976FamAbr = "" ;
   this.Z976FamAbr = "" ;
   this.O976FamAbr = "" ;
   this.A979FamSts = 0 ;
   this.Z979FamSts = 0 ;
   this.O979FamSts = 0 ;
   this.A40000FamFoto_GXI = "" ;
   this.A978FamFoto = "" ;
   this.Z978FamFoto = "" ;
   this.O978FamFoto = "" ;
   this.A40000FamFoto_GXI = "" ;
   this.AV10WebSession = {} ;
   this.A50FamCod = 0 ;
   this.A977FamDsc = "" ;
   this.A976FamAbr = "" ;
   this.A979FamSts = 0 ;
   this.A978FamFoto = "" ;
   this.Events = {"e122b2_client": ["AFTER TRN", true] ,"e132b80_client": ["ENTER", true] ,"e142b80_client": ["CANCEL", true]};
   this.EvtParms["ENTER"] = [[{postForm:true}],[]];
   this.EvtParms["REFRESH"] = [[],[]];
   this.EvtParms["AFTER TRN"] = [[],[]];
   this.EvtParms["VALID_FAMCOD"] = [[{ctrl:'FAMSTS'},{av:'A979FamSts',fld:'FAMSTS',pic:'9'},{av:'A50FamCod',fld:'FAMCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}],[{av:'A977FamDsc',fld:'FAMDSC',pic:''},{av:'A976FamAbr',fld:'FAMABR',pic:''},{ctrl:'FAMSTS'},{av:'A979FamSts',fld:'FAMSTS',pic:'9'},{av:'A978FamFoto',fld:'FAMFOTO',pic:''},{av:'A40000FamFoto_GXI',fld:'FAMFOTO_GXI',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z50FamCod'},{av:'Z977FamDsc'},{av:'Z976FamAbr'},{av:'Z979FamSts'},{av:'Z978FamFoto'},{av:'Z40000FamFoto_GXI'},{ctrl:'BTNTRN_DELETE',prop:'Enabled'},{ctrl:'BTNTRN_ENTER',prop:'Enabled'}]];
   this.EnterCtrl = ["BTNTRN_ENTER"];
   this.setVCMap("A40000FamFoto_GXI", "FAMFOTO_GXI", 0, "svchar", 2048, 0);
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(this.cfamilia);});
