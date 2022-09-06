gx.evt.autoSkip = false;
gx.define('wwpbaseobjects.wwp_masterpagetopactionswc', true, function (CmpContext) {
   this.ServerClass =  "wwpbaseobjects.wwp_masterpagetopactionswc" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.ServerFullClass =  "wwpbaseobjects.wwp_masterpagetopactionswc.aspx" ;
   this.setObjectType("web");
   this.setCmpContext(CmpContext);
   this.ReadonlyForm = true;
   this.hasEnterEvent = false;
   this.skipOnEnter = false;
   this.autoRefresh = true;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
   };
   this.e140y1_client=function()
   {
      this.clearMessages();
      this.refreshOutputs([]);
      this.OnClientEventEnd();
      return gx.$.Deferred().resolve();
   };
   this.e120y2_client=function()
   {
      return this.executeServerEvent("'DOACTION'", true, null, false, false);
   };
   this.e150y2_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e160y2_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,10,11];
   this.GXLastCtrlId =11;
   this.BTNCAMBIOPASSWORDContainer = gx.uc.getNew(this, 9, 0, "WWP_IconButton", this.CmpContext + "BTNCAMBIOPASSWORDContainer", "Btncambiopassword", "BTNCAMBIOPASSWORD");
   var BTNCAMBIOPASSWORDContainer = this.BTNCAMBIOPASSWORDContainer;
   BTNCAMBIOPASSWORDContainer.setProp("Enabled", "Enabled", true, "boolean");
   BTNCAMBIOPASSWORDContainer.setProp("BeforeIconClass", "Beforeiconclass", "fa fa-key FontIconTopRightActions", "str");
   BTNCAMBIOPASSWORDContainer.setProp("AfterIconClass", "Aftericonclass", "", "str");
   BTNCAMBIOPASSWORDContainer.addEventHandler("Event", this.e140y1_client);
   BTNCAMBIOPASSWORDContainer.setProp("Caption", "Caption", "Cambio de Password", "str");
   BTNCAMBIOPASSWORDContainer.setProp("Class", "Class", "MasterPageTopActionsOption", "str");
   BTNCAMBIOPASSWORDContainer.setProp("Visible", "Visible", true, "bool");
   BTNCAMBIOPASSWORDContainer.setC2ShowFunction(function(UC) { UC.show(); });
   this.setUserControl(BTNCAMBIOPASSWORDContainer);
   this.BTNACTIONContainer = gx.uc.getNew(this, 12, 0, "WWP_IconButton", this.CmpContext + "BTNACTIONContainer", "Btnaction", "BTNACTION");
   var BTNACTIONContainer = this.BTNACTIONContainer;
   BTNACTIONContainer.setProp("Enabled", "Enabled", true, "boolean");
   BTNACTIONContainer.setProp("BeforeIconClass", "Beforeiconclass", "fa fa-window-close FontIconTopRightActions", "str");
   BTNACTIONContainer.setProp("AfterIconClass", "Aftericonclass", "", "str");
   BTNACTIONContainer.addEventHandler("Event", this.e120y2_client);
   BTNACTIONContainer.setProp("Caption", "Caption", "Salir del Sistema", "str");
   BTNACTIONContainer.setProp("Class", "Class", "MasterPageTopActionsOption", "str");
   BTNACTIONContainer.setProp("Visible", "Visible", true, "bool");
   BTNACTIONContainer.setC2ShowFunction(function(UC) { UC.show(); });
   this.setUserControl(BTNACTIONContainer);
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"LAYOUTMAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"TABLEMAIN",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[11]={ id: 11, fld:"",grid:0};
   this.Events = {"e120y2_client": ["'DOACTION'", true] ,"e150y2_client": ["ENTER", true] ,"e160y2_client": ["CANCEL", true] ,"e140y1_client": ["'DOCAMBIOPASSWORD'", false]};
   this.EvtParms["REFRESH"] = [[],[]];
   this.EvtParms["'DOCAMBIOPASSWORD'"] = [[],[]];
   this.EvtParms["'DOACTION'"] = [[],[]];
   this.EvtParms["ENTER"] = [[],[]];
   this.Initialize( );
});
