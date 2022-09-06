gx.evt.autoSkip = false;
gx.define('wwpbaseobjects.menuitem', false, function () {
   this.ServerClass =  "wwpbaseobjects.menuitem" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.ServerFullClass =  "wwpbaseobjects.menuitem.aspx" ;
   this.setObjectType("trn");
   this.hasEnterEvent = true;
   this.skipOnEnter = false;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
      this.AV7MenuItemId=gx.fn.getIntegerValue("vMENUITEMID",',') ;
      this.AV11Insert_MenuItemFatherId=gx.fn.getIntegerValue("vINSERT_MENUITEMFATHERID",',') ;
      this.AV13MenuItemFatherId=gx.fn.getIntegerValue("vMENUITEMFATHERID",',') ;
      this.AV14MenuItemCaption=gx.fn.getControlValue("vMENUITEMCAPTION") ;
      this.AV15MenuItemIconClass=gx.fn.getControlValue("vMENUITEMICONCLASS") ;
      this.Gx_BScreen=gx.fn.getIntegerValue("vGXBSCREEN",',') ;
      this.AV16MenuItemShowDeveloperMenuOption=gx.fn.getControlValue("vMENUITEMSHOWDEVELOPERMENUOPTION") ;
      this.Gx_mode=gx.fn.getControlValue("vMODE") ;
      this.A1223MenuItemFatherCaption=gx.fn.getControlValue("MENUITEMFATHERCAPTION") ;
      this.A1224MenuItemFatherType=gx.fn.getIntegerValue("MENUITEMFATHERTYPE",',') ;
      this.AV25Pgmname=gx.fn.getControlValue("vPGMNAME") ;
   };
   this.Valid_Menuitemid=function()
   {
      return this.validCliEvt("Valid_Menuitemid", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("MENUITEMID");
         this.AnyError  = 0;
         if ( ((0==this.A352MenuItemId)) )
         {
            try {
               gxballoon.setError(gx.text.format( "%1 es requerido.", "Id", "", "", "", "", "", "", "", ""));
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
   this.Valid_Menuitemorder=function()
   {
      return this.validCliEvt("Valid_Menuitemorder", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("MENUITEMORDER");
         this.AnyError  = 0;
         if ( ((0==this.A1229MenuItemOrder)) )
         {
            try {
               gxballoon.setError(gx.text.format( "%1 es requerido.", "Menu Item Order", "", "", "", "", "", "", "", ""));
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
   this.Valid_Menuitemfatherid=function()
   {
      return this.validSrvEvt("Valid_Menuitemfatherid", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Menuitemcaption=function()
   {
      return this.validSrvEvt("Valid_Menuitemcaption", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Menuitemtype=function()
   {
      return this.validCliEvt("Valid_Menuitemtype", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("MENUITEMTYPE");
         this.AnyError  = 0;
         if ( ! ( ( this.A1232MenuItemType == 1 ) || ( this.A1232MenuItemType == 2 ) ) )
         {
            try {
               gxballoon.setError("Campo Type fuera de rango");
               this.AnyError = gx.num.trunc( 1 ,0) ;
            }
            catch(e){}
         }
         try {
            gx.fn.setCtrlProperty("MENUITEMLINK","Visible", (this.AV13MenuItemFatherId>0)&&(this.A1232MenuItemType==1) );
         }
         catch(e){}
         try {
            if ( ! ( ( this.AV13MenuItemFatherId > 0 ) && ( this.A1232MenuItemType == 1 ) ) )
            {
               gx.fn.setCtrlProperty("MENUITEMLINK_CELL","Class", "Invisible" );
            }
            else
            {
               if ( ( this.AV13MenuItemFatherId > 0 ) && ( this.A1232MenuItemType == 1 ) )
               {
                  gx.fn.setCtrlProperty("MENUITEMLINK_CELL","Class", "col-xs-12 DataContentCell" );
               }
            }
         }
         catch(e){}
         try {
            gx.fn.setCtrlProperty("MENUITEMLINKPARAMETERS","Visible", (this.AV13MenuItemFatherId>0)&&(this.A1232MenuItemType==1) );
         }
         catch(e){}
         try {
            if ( ! ( ( this.AV13MenuItemFatherId > 0 ) && ( this.A1232MenuItemType == 1 ) ) )
            {
               gx.fn.setCtrlProperty("MENUITEMLINKPARAMETERS_CELL","Class", "Invisible" );
            }
            else
            {
               if ( ( this.AV13MenuItemFatherId > 0 ) && ( this.A1232MenuItemType == 1 ) )
               {
                  gx.fn.setCtrlProperty("MENUITEMLINKPARAMETERS_CELL","Class", "col-xs-12 DataContentCell" );
               }
            }
         }
         catch(e){}
         try {
            gx.fn.setCtrlProperty("MENUITEMLINKTARGET","Visible", (this.A1232MenuItemType==1) );
         }
         catch(e){}
         try {
            if ( ! ( ( this.A1232MenuItemType == 1 ) ) )
            {
               gx.fn.setCtrlProperty("MENUITEMLINKTARGET_CELL","Class", "Invisible" );
            }
            else
            {
               if ( this.A1232MenuItemType == 1 )
               {
                  gx.fn.setCtrlProperty("MENUITEMLINKTARGET_CELL","Class", "col-xs-12 DataContentCell" );
               }
            }
         }
         catch(e){}

      }
      catch(e){}
      try {
          if (gxballoon == null) return true; return gxballoon.show();
      }
      catch(e){}
      return true ;
      });
   }
   this.Validv_Combomenuitemfatherid=function()
   {
      return this.validCliEvt("Validv_Combomenuitemfatherid", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("vCOMBOMENUITEMFATHERID");
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
   this.s122_client=function()
   {
      if ( this.AV13MenuItemFatherId == 0 )
      {
         gx.fn.setCtrlProperty("MENUITEMID","Visible", false );
         gx.fn.setCtrlProperty("MENUITEMID_CELL","Class", "Invisible" );
         this.COMBO_MENUITEMFATHERIDContainer.Visible =  false  ;
         gx.fn.setCtrlProperty("COMBO_MENUITEMFATHERID_CELL","Class", "Invisible" );
         gx.fn.setCtrlProperty("MENUITEMTYPE","Visible", false );
         gx.fn.setCtrlProperty("MENUITEMTYPE_CELL","Class", "Invisible" );
         gx.fn.setCtrlProperty("MENUITEMICONCLASS","Visible", false );
         gx.fn.setCtrlProperty("MENUITEMICONCLASS_CELL","Class", "Invisible" );
         gx.fn.setCtrlProperty("MENUITEMLINK","Visible", false );
         gx.fn.setCtrlProperty("MENUITEMLINK_CELL","Class", "Invisible" );
         gx.fn.setCtrlProperty("MENUITEMLINKPARAMETERS","Visible", false );
         gx.fn.setCtrlProperty("MENUITEMLINKPARAMETERS_CELL","Class", "Invisible" );
         gx.fn.setCtrlProperty("MENUITEMLINKTARGET","Visible", false );
         gx.fn.setCtrlProperty("MENUITEMLINKTARGET_CELL","Class", "Invisible" );
         gx.fn.setCtrlProperty("MENUITEMSHOWDEVELOPERMENUOPTIO","Visible", false );
         gx.fn.setCtrlProperty("MENUITEMSHOWDEVELOPERMENUOPTION_CELL","Class", "Invisible" );
         gx.fn.setCtrlProperty("MENUITEMSHOWEDITMENUOPTIONS","Visible", false );
         gx.fn.setCtrlProperty("MENUITEMSHOWEDITMENUOPTIONS_CELL","Class", "Invisible" );
      }
   };
   this.e130i19_client=function()
   {
      this.clearMessages();
      this.AV22ComboMenuItemFatherId = gx.num.trunc( gx.num.val( this.COMBO_MENUITEMFATHERIDContainer.SelectedValue_get) ,0) ;
      this.refreshOutputs([{av:'AV22ComboMenuItemFatherId',fld:'vCOMBOMENUITEMFATHERID',pic:'ZZZ9'},{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}]);
      this.OnClientEventEnd();
      return gx.$.Deferred().resolve();
   };
   this.e120i2_client=function()
   {
      return this.executeServerEvent("AFTER TRN", true, null, false, false);
   };
   this.e140i19_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e150i19_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92];
   this.GXLastCtrlId =92;
   this.COMBO_MENUITEMFATHERIDContainer = gx.uc.getNew(this, 35, 22, "BootstrapDropDownOptions", "COMBO_MENUITEMFATHERIDContainer", "Combo_menuitemfatherid", "COMBO_MENUITEMFATHERID");
   var COMBO_MENUITEMFATHERIDContainer = this.COMBO_MENUITEMFATHERIDContainer;
   COMBO_MENUITEMFATHERIDContainer.setProp("Class", "Class", "", "char");
   COMBO_MENUITEMFATHERIDContainer.setProp("IconType", "Icontype", "Image", "str");
   COMBO_MENUITEMFATHERIDContainer.setProp("Icon", "Icon", "", "str");
   COMBO_MENUITEMFATHERIDContainer.setProp("Caption", "Caption", "", "str");
   COMBO_MENUITEMFATHERIDContainer.setProp("Tooltip", "Tooltip", "", "str");
   COMBO_MENUITEMFATHERIDContainer.setProp("Cls", "Cls", "ExtendedCombo Attribute", "str");
   COMBO_MENUITEMFATHERIDContainer.setDynProp("SelectedValue_set", "Selectedvalue_set", "", "char");
   COMBO_MENUITEMFATHERIDContainer.setProp("SelectedValue_get", "Selectedvalue_get", "", "char");
   COMBO_MENUITEMFATHERIDContainer.setDynProp("SelectedText_set", "Selectedtext_set", "", "char");
   COMBO_MENUITEMFATHERIDContainer.setProp("SelectedText_get", "Selectedtext_get", "", "char");
   COMBO_MENUITEMFATHERIDContainer.setProp("GAMOAuthToken", "Gamoauthtoken", "", "char");
   COMBO_MENUITEMFATHERIDContainer.setProp("DDOInternalName", "Ddointernalname", "", "char");
   COMBO_MENUITEMFATHERIDContainer.setProp("TitleControlAlign", "Titlecontrolalign", "Automatic", "str");
   COMBO_MENUITEMFATHERIDContainer.setProp("DropDownOptionsType", "Dropdownoptionstype", "ExtendedComboBox", "str");
   COMBO_MENUITEMFATHERIDContainer.setDynProp("Enabled", "Enabled", true, "bool");
   COMBO_MENUITEMFATHERIDContainer.setDynProp("Visible", "Visible", true, "bool");
   COMBO_MENUITEMFATHERIDContainer.setProp("TitleControlIdToReplace", "Titlecontrolidtoreplace", "", "str");
   COMBO_MENUITEMFATHERIDContainer.setProp("DataListType", "Datalisttype", "Dynamic", "str");
   COMBO_MENUITEMFATHERIDContainer.setProp("AllowMultipleSelection", "Allowmultipleselection", false, "bool");
   COMBO_MENUITEMFATHERIDContainer.setProp("DataListFixedValues", "Datalistfixedvalues", "", "char");
   COMBO_MENUITEMFATHERIDContainer.setProp("IsGridItem", "Isgriditem", false, "bool");
   COMBO_MENUITEMFATHERIDContainer.setProp("HasDescription", "Hasdescription", false, "bool");
   COMBO_MENUITEMFATHERIDContainer.setProp("DataListProc", "Datalistproc", "WWPBaseObjects.MenuItemLoadDVCombo", "str");
   COMBO_MENUITEMFATHERIDContainer.setProp("DataListProcParametersPrefix", "Datalistprocparametersprefix", " \"ComboName\": \"MenuItemFatherId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"MenuItemId\": 0", "str");
   COMBO_MENUITEMFATHERIDContainer.setProp("DataListUpdateMinimumCharacters", "Datalistupdateminimumcharacters", 0, "num");
   COMBO_MENUITEMFATHERIDContainer.setProp("IncludeOnlySelectedOption", "Includeonlyselectedoption", false, "boolean");
   COMBO_MENUITEMFATHERIDContainer.setProp("IncludeSelectAllOption", "Includeselectalloption", false, "boolean");
   COMBO_MENUITEMFATHERIDContainer.setProp("EmptyItem", "Emptyitem", true, "bool");
   COMBO_MENUITEMFATHERIDContainer.setProp("IncludeAddNewOption", "Includeaddnewoption", false, "bool");
   COMBO_MENUITEMFATHERIDContainer.setProp("HTMLTemplate", "Htmltemplate", "", "str");
   COMBO_MENUITEMFATHERIDContainer.setProp("MultipleValuesType", "Multiplevaluestype", "Text", "str");
   COMBO_MENUITEMFATHERIDContainer.setProp("LoadingData", "Loadingdata", "", "str");
   COMBO_MENUITEMFATHERIDContainer.setProp("NoResultsFound", "Noresultsfound", "", "str");
   COMBO_MENUITEMFATHERIDContainer.setProp("EmptyItemText", "Emptyitemtext", "GX_EmptyItemText", "str");
   COMBO_MENUITEMFATHERIDContainer.setProp("OnlySelectedValues", "Onlyselectedvalues", "", "char");
   COMBO_MENUITEMFATHERIDContainer.setProp("SelectAllText", "Selectalltext", "", "char");
   COMBO_MENUITEMFATHERIDContainer.setProp("MultipleValuesSeparator", "Multiplevaluesseparator", "", "char");
   COMBO_MENUITEMFATHERIDContainer.setProp("AddNewOptionText", "Addnewoptiontext", "", "str");
   COMBO_MENUITEMFATHERIDContainer.addV2CFunction('AV18DDO_TitleSettingsIcons', "vDDO_TITLESETTINGSICONS", 'SetDropDownOptionsTitleSettingsIcons');
   COMBO_MENUITEMFATHERIDContainer.addC2VFunction(function(UC) { UC.ParentObject.AV18DDO_TitleSettingsIcons=UC.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",UC.ParentObject.AV18DDO_TitleSettingsIcons); });
   COMBO_MENUITEMFATHERIDContainer.addV2CFunction('AV17MenuItemFatherId_Data', "vMENUITEMFATHERID_DATA", 'SetDropDownOptionsData');
   COMBO_MENUITEMFATHERIDContainer.addC2VFunction(function(UC) { UC.ParentObject.AV17MenuItemFatherId_Data=UC.GetDropDownOptionsData();gx.fn.setControlValue("vMENUITEMFATHERID_DATA",UC.ParentObject.AV17MenuItemFatherId_Data); });
   COMBO_MENUITEMFATHERIDContainer.setProp("Gx Control Type", "Gxcontroltype", '', "int");
   COMBO_MENUITEMFATHERIDContainer.setC2ShowFunction(function(UC) { UC.show(); });
   COMBO_MENUITEMFATHERIDContainer.addEventHandler("OnOptionClicked", this.e130i19_client);
   this.setUserControl(COMBO_MENUITEMFATHERIDContainer);
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
   DVPANEL_TABLEATTRIBUTESContainer.setProp("Title", "Title", "General Information", "str");
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
   GXValidFnc[19]={ id: 19, fld:"MENUITEMID_CELL",grid:0};
   GXValidFnc[20]={ id: 20, fld:"",grid:0};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[22]={ id:22 ,lvl:0,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Menuitemid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENUITEMID",gxz:"Z352MenuItemId",gxold:"O352MenuItemId",gxvar:"A352MenuItemId",ucs:[],op:[22],ip:[22],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A352MenuItemId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z352MenuItemId=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("MENUITEMID",gx.O.A352MenuItemId,0)},c2v:function(){if(this.val()!==undefined)gx.O.A352MenuItemId=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("MENUITEMID",',')},nac:gx.falseFn};
   GXValidFnc[23]={ id: 23, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[26]={ id: 26, fld:"",grid:0};
   GXValidFnc[27]={ id:27 ,lvl:0,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Menuitemorder,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENUITEMORDER",gxz:"Z1229MenuItemOrder",gxold:"O1229MenuItemOrder",gxvar:"A1229MenuItemOrder",ucs:[],op:[27],ip:[27],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1229MenuItemOrder=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1229MenuItemOrder=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("MENUITEMORDER",gx.O.A1229MenuItemOrder,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1229MenuItemOrder=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("MENUITEMORDER",',')},nac:gx.falseFn};
   GXValidFnc[28]={ id: 28, fld:"",grid:0};
   GXValidFnc[29]={ id: 29, fld:"COMBO_MENUITEMFATHERID_CELL",grid:0};
   GXValidFnc[30]={ id: 30, fld:"TABLESPLITTEDMENUITEMFATHERID",grid:0};
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   GXValidFnc[32]={ id: 32, fld:"",grid:0};
   GXValidFnc[33]={ id: 33, fld:"TEXTBLOCKMENUITEMFATHERID", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[34]={ id: 34, fld:"",grid:0};
   GXValidFnc[36]={ id: 36, fld:"",grid:0};
   GXValidFnc[37]={ id: 37, fld:"",grid:0};
   GXValidFnc[38]={ id:38 ,lvl:0,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Menuitemfatherid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENUITEMFATHERID",gxz:"Z353MenuItemFatherId",gxold:"O353MenuItemFatherId",gxvar:"A353MenuItemFatherId",ucs:[],op:[],ip:[38],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A353MenuItemFatherId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z353MenuItemFatherId=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("MENUITEMFATHERID",gx.O.A353MenuItemFatherId,0)},c2v:function(){if(this.val()!==undefined)gx.O.A353MenuItemFatherId=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("MENUITEMFATHERID",',')},nac:function(){return gx.text.compare(this.Gx_mode,"INS")==0&&!((0==this.AV11Insert_MenuItemFatherId))}};
   GXValidFnc[39]={ id: 39, fld:"",grid:0};
   GXValidFnc[40]={ id: 40, fld:"",grid:0};
   GXValidFnc[41]={ id: 41, fld:"",grid:0};
   GXValidFnc[42]={ id: 42, fld:"",grid:0};
   GXValidFnc[43]={ id:43 ,lvl:0,type:"svchar",len:40,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Menuitemcaption,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENUITEMCAPTION",gxz:"Z1222MenuItemCaption",gxold:"O1222MenuItemCaption",gxvar:"A1222MenuItemCaption",ucs:[],op:[43],ip:[43],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1222MenuItemCaption=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z1222MenuItemCaption=Value},v2c:function(){gx.fn.setControlValue("MENUITEMCAPTION",gx.O.A1222MenuItemCaption,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1222MenuItemCaption=this.val()},val:function(){return gx.fn.getControlValue("MENUITEMCAPTION")},nac:gx.falseFn};
   GXValidFnc[44]={ id: 44, fld:"",grid:0};
   GXValidFnc[45]={ id: 45, fld:"MENUITEMTYPE_CELL",grid:0};
   GXValidFnc[46]={ id: 46, fld:"",grid:0};
   GXValidFnc[47]={ id: 47, fld:"",grid:0};
   GXValidFnc[48]={ id:48 ,lvl:0,type:"int",len:1,dec:0,sign:false,pic:"9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Menuitemtype,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENUITEMTYPE",gxz:"Z1232MenuItemType",gxold:"O1232MenuItemType",gxvar:"A1232MenuItemType",ucs:[],op:[48],ip:[48],
						nacdep:[],ctrltype:"combo",v2v:function(Value){if(Value!==undefined)gx.O.A1232MenuItemType=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1232MenuItemType=gx.num.intval(Value)},v2c:function(){gx.fn.setComboBoxValue("MENUITEMTYPE",gx.O.A1232MenuItemType);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A1232MenuItemType=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("MENUITEMTYPE",',')},nac:gx.falseFn};
   this.declareDomainHdlr( 48 , function() {
   });
   GXValidFnc[49]={ id: 49, fld:"",grid:0};
   GXValidFnc[50]={ id: 50, fld:"MENUITEMICONCLASS_CELL",grid:0};
   GXValidFnc[51]={ id: 51, fld:"",grid:0};
   GXValidFnc[52]={ id: 52, fld:"",grid:0};
   GXValidFnc[53]={ id:53 ,lvl:0,type:"svchar",len:40,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENUITEMICONCLASS",gxz:"Z1225MenuItemIconClass",gxold:"O1225MenuItemIconClass",gxvar:"A1225MenuItemIconClass",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1225MenuItemIconClass=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z1225MenuItemIconClass=Value},v2c:function(){gx.fn.setControlValue("MENUITEMICONCLASS",gx.O.A1225MenuItemIconClass,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1225MenuItemIconClass=this.val()},val:function(){return gx.fn.getControlValue("MENUITEMICONCLASS")},nac:gx.falseFn};
   GXValidFnc[54]={ id: 54, fld:"",grid:0};
   GXValidFnc[55]={ id: 55, fld:"MENUITEMLINK_CELL",grid:0};
   GXValidFnc[56]={ id: 56, fld:"",grid:0};
   GXValidFnc[57]={ id: 57, fld:"",grid:0};
   GXValidFnc[58]={ id:58 ,lvl:0,type:"svchar",len:80,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENUITEMLINK",gxz:"Z1226MenuItemLink",gxold:"O1226MenuItemLink",gxvar:"A1226MenuItemLink",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1226MenuItemLink=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z1226MenuItemLink=Value},v2c:function(){gx.fn.setControlValue("MENUITEMLINK",gx.O.A1226MenuItemLink,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1226MenuItemLink=this.val()},val:function(){return gx.fn.getControlValue("MENUITEMLINK")},nac:gx.falseFn};
   GXValidFnc[59]={ id: 59, fld:"",grid:0};
   GXValidFnc[60]={ id: 60, fld:"MENUITEMLINKPARAMETERS_CELL",grid:0};
   GXValidFnc[61]={ id: 61, fld:"",grid:0};
   GXValidFnc[62]={ id: 62, fld:"",grid:0};
   GXValidFnc[63]={ id:63 ,lvl:0,type:"svchar",len:100,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENUITEMLINKPARAMETERS",gxz:"Z1227MenuItemLinkParameters",gxold:"O1227MenuItemLinkParameters",gxvar:"A1227MenuItemLinkParameters",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1227MenuItemLinkParameters=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z1227MenuItemLinkParameters=Value},v2c:function(){gx.fn.setControlValue("MENUITEMLINKPARAMETERS",gx.O.A1227MenuItemLinkParameters,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1227MenuItemLinkParameters=this.val()},val:function(){return gx.fn.getControlValue("MENUITEMLINKPARAMETERS")},nac:gx.falseFn};
   GXValidFnc[64]={ id: 64, fld:"",grid:0};
   GXValidFnc[65]={ id: 65, fld:"MENUITEMLINKTARGET_CELL",grid:0};
   GXValidFnc[66]={ id: 66, fld:"",grid:0};
   GXValidFnc[67]={ id: 67, fld:"",grid:0};
   GXValidFnc[68]={ id:68 ,lvl:0,type:"svchar",len:10,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENUITEMLINKTARGET",gxz:"Z1228MenuItemLinkTarget",gxold:"O1228MenuItemLinkTarget",gxvar:"A1228MenuItemLinkTarget",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"checkbox",v2v:function(Value){if(Value!==undefined)gx.O.A1228MenuItemLinkTarget=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z1228MenuItemLinkTarget=Value},v2c:function(){gx.fn.setCheckBoxValue("MENUITEMLINKTARGET",gx.O.A1228MenuItemLinkTarget,"_blank")},c2v:function(){if(this.val()!==undefined)gx.O.A1228MenuItemLinkTarget=this.val()},val:function(){return gx.fn.getControlValue("MENUITEMLINKTARGET")},nac:gx.falseFn,values:['_blank','_']};
   GXValidFnc[69]={ id: 69, fld:"",grid:0};
   GXValidFnc[70]={ id: 70, fld:"MENUITEMSHOWDEVELOPERMENUOPTION_CELL",grid:0};
   GXValidFnc[71]={ id: 71, fld:"",grid:0};
   GXValidFnc[72]={ id: 72, fld:"",grid:0};
   GXValidFnc[73]={ id:73 ,lvl:0,type:"boolean",len:4,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENUITEMSHOWDEVELOPERMENUOPTIO",gxz:"Z1230MenuItemShowDeveloperMenuOptio",gxold:"O1230MenuItemShowDeveloperMenuOptio",gxvar:"A1230MenuItemShowDeveloperMenuOptio",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"checkbox",v2v:function(Value){if(Value!==undefined)gx.O.A1230MenuItemShowDeveloperMenuOptio=gx.lang.booleanValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1230MenuItemShowDeveloperMenuOptio=gx.lang.booleanValue(Value)},v2c:function(){gx.fn.setCheckBoxValue("MENUITEMSHOWDEVELOPERMENUOPTIO",gx.O.A1230MenuItemShowDeveloperMenuOptio,true)},c2v:function(){if(this.val()!==undefined)gx.O.A1230MenuItemShowDeveloperMenuOptio=gx.lang.booleanValue(this.val())},val:function(){return gx.fn.getControlValue("MENUITEMSHOWDEVELOPERMENUOPTIO")},nac:gx.falseFn,values:['true','false']};
   GXValidFnc[74]={ id: 74, fld:"",grid:0};
   GXValidFnc[75]={ id: 75, fld:"MENUITEMSHOWEDITMENUOPTIONS_CELL",grid:0};
   GXValidFnc[76]={ id: 76, fld:"",grid:0};
   GXValidFnc[77]={ id: 77, fld:"",grid:0};
   GXValidFnc[78]={ id:78 ,lvl:0,type:"boolean",len:4,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MENUITEMSHOWEDITMENUOPTIONS",gxz:"Z1231MenuItemShowEditMenuOptions",gxold:"O1231MenuItemShowEditMenuOptions",gxvar:"A1231MenuItemShowEditMenuOptions",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"checkbox",v2v:function(Value){if(Value!==undefined)gx.O.A1231MenuItemShowEditMenuOptions=gx.lang.booleanValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1231MenuItemShowEditMenuOptions=gx.lang.booleanValue(Value)},v2c:function(){gx.fn.setCheckBoxValue("MENUITEMSHOWEDITMENUOPTIONS",gx.O.A1231MenuItemShowEditMenuOptions,true)},c2v:function(){if(this.val()!==undefined)gx.O.A1231MenuItemShowEditMenuOptions=gx.lang.booleanValue(this.val())},val:function(){return gx.fn.getControlValue("MENUITEMSHOWEDITMENUOPTIONS")},nac:gx.falseFn,values:['true','false']};
   GXValidFnc[79]={ id: 79, fld:"",grid:0};
   GXValidFnc[80]={ id: 80, fld:"",grid:0};
   GXValidFnc[81]={ id: 81, fld:"",grid:0};
   GXValidFnc[82]={ id: 82, fld:"",grid:0};
   GXValidFnc[83]={ id: 83, fld:"BTNTRN_ENTER",grid:0,evt:"e140i19_client",std:"ENTER"};
   GXValidFnc[84]={ id: 84, fld:"",grid:0};
   GXValidFnc[85]={ id: 85, fld:"BTNTRN_CANCEL",grid:0,evt:"e150i19_client"};
   GXValidFnc[86]={ id: 86, fld:"",grid:0};
   GXValidFnc[87]={ id: 87, fld:"BTNTRN_DELETE",grid:0,evt:"e160i19_client",std:"DELETE"};
   GXValidFnc[88]={ id: 88, fld:"",grid:0};
   GXValidFnc[89]={ id: 89, fld:"",grid:0};
   GXValidFnc[90]={ id: 90, fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};
   GXValidFnc[91]={ id: 91, fld:"SECTIONATTRIBUTE_MENUITEMFATHERID",grid:0};
   GXValidFnc[92]={ id:92 ,lvl:0,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Validv_Combomenuitemfatherid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCOMBOMENUITEMFATHERID",gxz:"ZV22ComboMenuItemFatherId",gxold:"OV22ComboMenuItemFatherId",gxvar:"AV22ComboMenuItemFatherId",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV22ComboMenuItemFatherId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV22ComboMenuItemFatherId=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("vCOMBOMENUITEMFATHERID",gx.O.AV22ComboMenuItemFatherId,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV22ComboMenuItemFatherId=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("vCOMBOMENUITEMFATHERID",',')},nac:gx.falseFn};
   this.A352MenuItemId = 0 ;
   this.Z352MenuItemId = 0 ;
   this.O352MenuItemId = 0 ;
   this.A1229MenuItemOrder = 0 ;
   this.Z1229MenuItemOrder = 0 ;
   this.O1229MenuItemOrder = 0 ;
   this.A353MenuItemFatherId = 0 ;
   this.Z353MenuItemFatherId = 0 ;
   this.O353MenuItemFatherId = 0 ;
   this.A1222MenuItemCaption = "" ;
   this.Z1222MenuItemCaption = "" ;
   this.O1222MenuItemCaption = "" ;
   this.A1232MenuItemType = 0 ;
   this.Z1232MenuItemType = 0 ;
   this.O1232MenuItemType = 0 ;
   this.A1225MenuItemIconClass = "" ;
   this.Z1225MenuItemIconClass = "" ;
   this.O1225MenuItemIconClass = "" ;
   this.A1226MenuItemLink = "" ;
   this.Z1226MenuItemLink = "" ;
   this.O1226MenuItemLink = "" ;
   this.A1227MenuItemLinkParameters = "" ;
   this.Z1227MenuItemLinkParameters = "" ;
   this.O1227MenuItemLinkParameters = "" ;
   this.A1228MenuItemLinkTarget = "" ;
   this.Z1228MenuItemLinkTarget = "" ;
   this.O1228MenuItemLinkTarget = "" ;
   this.A1230MenuItemShowDeveloperMenuOptio = false ;
   this.Z1230MenuItemShowDeveloperMenuOptio = false ;
   this.O1230MenuItemShowDeveloperMenuOptio = false ;
   this.A1231MenuItemShowEditMenuOptions = false ;
   this.Z1231MenuItemShowEditMenuOptions = false ;
   this.O1231MenuItemShowEditMenuOptions = false ;
   this.AV22ComboMenuItemFatherId = 0 ;
   this.ZV22ComboMenuItemFatherId = 0 ;
   this.OV22ComboMenuItemFatherId = 0 ;
   this.AV8WWPContext = {UserId:0,UserName:""} ;
   this.AV22ComboMenuItemFatherId = 0 ;
   this.AV9TrnContext = {CallerObject:"",CallerOnDelete:false,CallerURL:"",TransactionName:"",Attributes:[]} ;
   this.AV26GXV1 = 0 ;
   this.AV11Insert_MenuItemFatherId = 0 ;
   this.AV21Combo_DataJson = "" ;
   this.AV16MenuItemShowDeveloperMenuOption = false ;
   this.AV12TrnContextAtt = {AttributeName:"",AttributeValue:""} ;
   this.AV20ComboSelectedText = "" ;
   this.AV19ComboSelectedValue = "" ;
   this.AV7MenuItemId = 0 ;
   this.AV13MenuItemFatherId = 0 ;
   this.AV10WebSession = {} ;
   this.A352MenuItemId = 0 ;
   this.A353MenuItemFatherId = 0 ;
   this.A1232MenuItemType = 0 ;
   this.AV14MenuItemCaption = "" ;
   this.AV15MenuItemIconClass = "" ;
   this.A1222MenuItemCaption = "" ;
   this.AV25Pgmname = "" ;
   this.Gx_BScreen = 0 ;
   this.A1229MenuItemOrder = 0 ;
   this.A1223MenuItemFatherCaption = "" ;
   this.A1224MenuItemFatherType = 0 ;
   this.A1226MenuItemLink = "" ;
   this.A1227MenuItemLinkParameters = "" ;
   this.A1228MenuItemLinkTarget = "" ;
   this.A1225MenuItemIconClass = "" ;
   this.A1230MenuItemShowDeveloperMenuOptio = false ;
   this.A1231MenuItemShowEditMenuOptions = false ;
   this.AV18DDO_TitleSettingsIcons = {Default_fi:"",Filtered_fi:"",SortedASC_fi:"",SortedDSC_fi:"",FilteredSortedASC_fi:"",FilteredSortedDSC_fi:"",OptionSortASC_fi:"",OptionSortDSC_fi:"",OptionApplyFilter_fi:"",OptionFilteringData_fi:"",OptionCleanFilters_fi:"",SelectedOption_fi:"",MultiselOption_fi:"",MultiselSelOption_fi:"",TreeviewCollapse_fi:"",TreeviewExpand_fi:"",FixLeft_fi:"",FixRight_fi:""} ;
   this.AV17MenuItemFatherId_Data = [ ] ;
   this.Gx_mode = "" ;
   this.Events = {"e120i2_client": ["AFTER TRN", true] ,"e140i19_client": ["ENTER", true] ,"e150i19_client": ["CANCEL", true] ,"e130i19_client": ["COMBO_MENUITEMFATHERID.ONOPTIONCLICKED", false]};
   this.EvtParms["ENTER"] = [[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7MenuItemId',fld:'vMENUITEMID',pic:'ZZZ9',hsh:true},{av:'AV13MenuItemFatherId',fld:'vMENUITEMFATHERID',pic:'ZZZ9'},{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}],[{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}]];
   this.EvtParms["REFRESH"] = [[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7MenuItemId',fld:'vMENUITEMID',pic:'ZZZ9',hsh:true},{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}],[{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}]];
   this.EvtParms["AFTER TRN"] = [[{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}],[{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}]];
   this.EvtParms["COMBO_MENUITEMFATHERID.ONOPTIONCLICKED"] = [[{av:'this.COMBO_MENUITEMFATHERIDContainer.SelectedValue_get',ctrl:'COMBO_MENUITEMFATHERID',prop:'SelectedValue_get'},{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}],[{av:'AV22ComboMenuItemFatherId',fld:'vCOMBOMENUITEMFATHERID',pic:'ZZZ9'},{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}]];
   this.EvtParms["VALID_MENUITEMID"] = [[{av:'A352MenuItemId',fld:'MENUITEMID',pic:'ZZZ9'},{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}],[{av:'A352MenuItemId',fld:'MENUITEMID',pic:'ZZZ9'},{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}]];
   this.EvtParms["VALID_MENUITEMORDER"] = [[{av:'A1229MenuItemOrder',fld:'MENUITEMORDER',pic:'ZZZ9'},{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}],[{av:'A1229MenuItemOrder',fld:'MENUITEMORDER',pic:'ZZZ9'},{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}]];
   this.EvtParms["VALID_MENUITEMFATHERID"] = [[{av:'A353MenuItemFatherId',fld:'MENUITEMFATHERID',pic:'ZZZ9'},{av:'A1223MenuItemFatherCaption',fld:'MENUITEMFATHERCAPTION',pic:''},{av:'A1224MenuItemFatherType',fld:'MENUITEMFATHERTYPE',pic:'9'},{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}],[{av:'A1223MenuItemFatherCaption',fld:'MENUITEMFATHERCAPTION',pic:''},{av:'A1224MenuItemFatherType',fld:'MENUITEMFATHERTYPE',pic:'9'},{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}]];
   this.EvtParms["VALID_MENUITEMCAPTION"] = [[{av:'A1222MenuItemCaption',fld:'MENUITEMCAPTION',pic:''},{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}],[{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}]];
   this.EvtParms["VALID_MENUITEMTYPE"] = [[{ctrl:'MENUITEMTYPE'},{av:'A1232MenuItemType',fld:'MENUITEMTYPE',pic:'9'},{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}],[{ctrl:'MENUITEMTYPE'},{av:'A1232MenuItemType',fld:'MENUITEMTYPE',pic:'9'},{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}]];
   this.EvtParms["VALIDV_COMBOMENUITEMFATHERID"] = [[{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}],[{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}]];
   this.EnterCtrl = ["BTNTRN_ENTER"];
   this.setVCMap("AV7MenuItemId", "vMENUITEMID", 0, "int", 4, 0);
   this.setVCMap("AV11Insert_MenuItemFatherId", "vINSERT_MENUITEMFATHERID", 0, "int", 4, 0);
   this.setVCMap("AV13MenuItemFatherId", "vMENUITEMFATHERID", 0, "int", 4, 0);
   this.setVCMap("AV14MenuItemCaption", "vMENUITEMCAPTION", 0, "svchar", 40, 0);
   this.setVCMap("AV15MenuItemIconClass", "vMENUITEMICONCLASS", 0, "svchar", 40, 0);
   this.setVCMap("Gx_BScreen", "vGXBSCREEN", 0, "int", 1, 0);
   this.setVCMap("AV16MenuItemShowDeveloperMenuOption", "vMENUITEMSHOWDEVELOPERMENUOPTION", 0, "boolean", 4, 0);
   this.setVCMap("Gx_mode", "vMODE", 0, "char", 3, 0);
   this.setVCMap("A1223MenuItemFatherCaption", "MENUITEMFATHERCAPTION", 0, "svchar", 40, 0);
   this.setVCMap("A1224MenuItemFatherType", "MENUITEMFATHERTYPE", 0, "int", 1, 0);
   this.setVCMap("AV25Pgmname", "vPGMNAME", 0, "char", 129, 0);
   this.Initialize( );
   this.setSDTMapping( "WWPBaseObjects\\DVB_SDTComboData.Item" , {
      "Title":{extr:"T"},
      "Children":{extr:"C"}});
   this.setSDTMapping( "WWPBaseObjects\\DVB_SDTDropDownOptionsTitleSettingsIcons" , {
      "Default_fi":{extr:"def"},
      "Filtered_fi":{extr:"fil"},
      "SortedASC_fi":{extr:"asc"},
      "SortedDSC_fi":{extr:"dsc"},
      "FilteredSortedASC_fi":{extr:"fasc"},
      "FilteredSortedDSC_fi":{extr:"fdsc"},
      "OptionSortASC_fi":{extr:"osasc"},
      "OptionSortDSC_fi":{extr:"osdsc"},
      "OptionApplyFilter_fi":{extr:"app"},
      "OptionFilteringData_fi":{extr:"fildata"},
      "OptionCleanFilters_fi":{extr:"cle"},
      "SelectedOption_fi":{extr:"selo"},
      "MultiselOption_fi":{extr:"mul"},
      "MultiselSelOption_fi":{extr:"muls"},
      "TreeviewCollapse_fi":{extr:"tcol"},
      "TreeviewExpand_fi":{extr:"texp"},
      "FixLeft_fi":{extr:"fixl"},
      "FixRight_fi":{extr:"fixr"}});
   this.setSDTMapping( "WWPBaseObjects\\WWPTransactionContext" , {
      "Attributes":{sdt:"WWPBaseObjects\\WWPTransactionContext.Attribute"}});
});
gx.wi( function() { gx.createParentObj(this.wwpbaseobjects.menuitem);});
