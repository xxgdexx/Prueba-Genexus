gx.evt.autoSkip=!1;gx.define("reloj_interface.reloj_codigoid",!1,function(){var n,t,i,r,u,f;this.ServerClass="reloj_interface.reloj_codigoid";this.PackageName="GeneXus.Programs";this.ServerFullClass="reloj_interface.reloj_codigoid.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.A2525TrabApePat=gx.fn.getControlValue("TRABAPEPAT");this.A2526TrabApeMat=gx.fn.getControlValue("TRABAPEMAT");this.A2527TrabNombres=gx.fn.getControlValue("TRABNOMBRES");this.AV29CodigoId=gx.fn.getControlValue("vCODIGOID");this.AV23Insert_Reloj_ID=gx.fn.getIntegerValue("vINSERT_RELOJ_ID",",");this.AV24Insert_RHTrabajadorCodigo=gx.fn.getControlValue("vINSERT_RHTRABAJADORCODIGO");this.AV25Insert_HorarioID=gx.fn.getIntegerValue("vINSERT_HORARIOID",",");this.Gx_BScreen=gx.fn.getIntegerValue("vGXBSCREEN",",");this.AV39Pgmname=gx.fn.getControlValue("vPGMNAME");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV9TrnContext=gx.fn.getControlValue("vTRNCONTEXT")};this.Valid_Codigoid=function(){return this.validCliEvt("Valid_Codigoid",0,function(){try{var n=gx.util.balloon.getNew("CODIGOID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Reloj_id=function(){return this.validSrvEvt("Valid_Reloj_id",0).then(function(n){return n}.closure(this))};this.Valid_Horarioid=function(){return this.validSrvEvt("Valid_Horarioid",0).then(function(n){return n}.closure(this))};this.Valid_Rhtrabajadorcodigo=function(){return this.validSrvEvt("Valid_Rhtrabajadorcodigo",0).then(function(n){return n}.closure(this))};this.Valid_Lectura_ini=function(){return this.validCliEvt("Valid_Lectura_ini",0,function(){try{var n=gx.util.balloon.getNew("LECTURA_INI");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.A2415Lectura_Ini)==0||new gx.date.gxdate(this.A2415Lectura_Ini).compare(gx.date.ymdhmstot(1753,1,1,0,0,0))>=0))try{n.setError("Campo Lectura_Ini fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Lectura_fin=function(){return this.validCliEvt("Valid_Lectura_fin",0,function(){try{var n=gx.util.balloon.getNew("LECTURA_FIN");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.A2416Lectura_Fin)===0||new gx.date.gxdate(this.A2416Lectura_Fin).compare(gx.date.ymdhmstot(1753,1,1,0,0,0))>=0))try{n.setError("Campo Lectura_Fin fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Combocodigoid=function(){return this.validCliEvt("Validv_Combocodigoid",0,function(){try{var n=gx.util.balloon.getNew("vCOMBOCODIGOID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Comboreloj_id=function(){return this.validCliEvt("Validv_Comboreloj_id",0,function(){try{var n=gx.util.balloon.getNew("vCOMBORELOJ_ID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Combohorarioid=function(){return this.validCliEvt("Validv_Combohorarioid",0,function(){try{var n=gx.util.balloon.getNew("vCOMBOHORARIOID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Comborhtrabajadorcodigo=function(){return this.validCliEvt("Validv_Comborhtrabajadorcodigo",0,function(){try{var n=gx.util.balloon.getNew("vCOMBORHTRABAJADORCODIGO");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e137z222_client=function(){return this.clearMessages(),this.AV27ComboRHTrabajadorCodigo=this.COMBO_RHTRABAJADORCODIGOContainer.SelectedValue_get,this.refreshOutputs([{av:"AV27ComboRHTrabajadorCodigo",fld:"vCOMBORHTRABAJADORCODIGO",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e147z222_client=function(){return this.clearMessages(),this.AV34ComboHorarioID=gx.num.trunc(gx.num.val(this.COMBO_HORARIOIDContainer.SelectedValue_get),0),this.refreshOutputs([{av:"AV34ComboHorarioID",fld:"vCOMBOHORARIOID",pic:"ZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e157z222_client=function(){return this.clearMessages(),this.AV31ComboReloj_ID=gx.num.trunc(gx.num.val(this.COMBO_RELOJ_IDContainer.SelectedValue_get),0),this.refreshOutputs([{av:"AV31ComboReloj_ID",fld:"vCOMBORELOJ_ID",pic:"ZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e167z222_client=function(){return this.clearMessages(),this.AV37ComboCodigoId=this.COMBO_CODIGOIDContainer.SelectedValue_get,this.refreshOutputs([{av:"AV37ComboCodigoId",fld:"vCOMBOCODIGOID",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e127z2_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e177z222_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e187z222_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,26,27,28,29,30,31,32,33,34,35,37,38,39,40,41,42,43,44,45,46,47,48,49,50,52,53,54,55,56,57,58,59,60,61,62,63,64,65,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100,101,102];this.GXLastCtrlId=102;this.COMBO_CODIGOIDContainer=gx.uc.getNew(this,25,0,"BootstrapDropDownOptions","COMBO_CODIGOIDContainer","Combo_codigoid","COMBO_CODIGOID");t=this.COMBO_CODIGOIDContainer;t.setProp("Class","Class","","char");t.setProp("IconType","Icontype","Image","str");t.setProp("Icon","Icon","","str");t.setProp("Caption","Caption","","str");t.setProp("Tooltip","Tooltip","","str");t.setProp("Cls","Cls","ExtendedCombo Attribute","str");t.setDynProp("SelectedValue_set","Selectedvalue_set","","char");t.setProp("SelectedValue_get","Selectedvalue_get","","char");t.setProp("SelectedText_set","Selectedtext_set","","char");t.setProp("SelectedText_get","Selectedtext_get","","char");t.setProp("GAMOAuthToken","Gamoauthtoken","","char");t.setProp("DDOInternalName","Ddointernalname","","char");t.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");t.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");t.setDynProp("Enabled","Enabled",!0,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");t.setProp("DataListType","Datalisttype","Dynamic","str");t.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");t.setProp("DataListFixedValues","Datalistfixedvalues","","char");t.setProp("IsGridItem","Isgriditem",!1,"bool");t.setProp("HasDescription","Hasdescription",!1,"bool");t.setProp("DataListProc","Datalistproc","","str");t.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");t.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");t.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");t.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");t.setProp("EmptyItem","Emptyitem",!1,"bool");t.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");t.setProp("HTMLTemplate","Htmltemplate","","str");t.setProp("MultipleValuesType","Multiplevaluestype","Text","str");t.setProp("LoadingData","Loadingdata","","char");t.setProp("NoResultsFound","Noresultsfound","","char");t.setProp("EmptyItemText","Emptyitemtext","","char");t.setProp("OnlySelectedValues","Onlyselectedvalues","","char");t.setProp("SelectAllText","Selectalltext","","char");t.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");t.setProp("AddNewOptionText","Addnewoptiontext","","str");t.addV2CFunction("AV15DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");t.addC2VFunction(function(n){n.ParentObject.AV15DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV15DDO_TitleSettingsIcons)});t.addV2CFunction("AV36CodigoId_Data","vCODIGOID_DATA","SetDropDownOptionsData");t.addC2VFunction(function(n){n.ParentObject.AV36CodigoId_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vCODIGOID_DATA",n.ParentObject.AV36CodigoId_Data)});t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("OnOptionClicked",this.e167z222_client);this.setUserControl(t);this.COMBO_RELOJ_IDContainer=gx.uc.getNew(this,36,28,"BootstrapDropDownOptions","COMBO_RELOJ_IDContainer","Combo_reloj_id","COMBO_RELOJ_ID");i=this.COMBO_RELOJ_IDContainer;i.setProp("Class","Class","","char");i.setProp("IconType","Icontype","Image","str");i.setProp("Icon","Icon","","str");i.setProp("Caption","Caption","","str");i.setProp("Tooltip","Tooltip","","str");i.setProp("Cls","Cls","ExtendedCombo Attribute","str");i.setDynProp("SelectedValue_set","Selectedvalue_set","","char");i.setProp("SelectedValue_get","Selectedvalue_get","","char");i.setDynProp("SelectedText_set","Selectedtext_set","","char");i.setProp("SelectedText_get","Selectedtext_get","","char");i.setProp("GAMOAuthToken","Gamoauthtoken","","char");i.setProp("DDOInternalName","Ddointernalname","","char");i.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");i.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");i.setDynProp("Enabled","Enabled",!0,"bool");i.setProp("Visible","Visible",!0,"bool");i.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");i.setProp("DataListType","Datalisttype","Dynamic","str");i.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");i.setProp("DataListFixedValues","Datalistfixedvalues","","char");i.setProp("IsGridItem","Isgriditem",!1,"bool");i.setProp("HasDescription","Hasdescription",!1,"bool");i.setProp("DataListProc","Datalistproc","Reloj_Interface.Reloj_CodigoIDLoadDVCombo","str");i.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix",' "ComboName": "Reloj_ID", "TrnMode": "INS", "IsDynamicCall": true, "CodigoId": ""',"str");i.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");i.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");i.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");i.setProp("EmptyItem","Emptyitem",!1,"bool");i.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");i.setProp("HTMLTemplate","Htmltemplate","","str");i.setProp("MultipleValuesType","Multiplevaluestype","Text","str");i.setProp("LoadingData","Loadingdata","","str");i.setProp("NoResultsFound","Noresultsfound","","str");i.setProp("EmptyItemText","Emptyitemtext","","char");i.setProp("OnlySelectedValues","Onlyselectedvalues","","char");i.setProp("SelectAllText","Selectalltext","","char");i.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");i.setProp("AddNewOptionText","Addnewoptiontext","","str");i.addV2CFunction("AV15DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");i.addC2VFunction(function(n){n.ParentObject.AV15DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV15DDO_TitleSettingsIcons)});i.addV2CFunction("AV30Reloj_ID_Data","vRELOJ_ID_DATA","SetDropDownOptionsData");i.addC2VFunction(function(n){n.ParentObject.AV30Reloj_ID_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vRELOJ_ID_DATA",n.ParentObject.AV30Reloj_ID_Data)});i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});i.addEventHandler("OnOptionClicked",this.e157z222_client);this.setUserControl(i);this.COMBO_HORARIOIDContainer=gx.uc.getNew(this,51,28,"BootstrapDropDownOptions","COMBO_HORARIOIDContainer","Combo_horarioid","COMBO_HORARIOID");r=this.COMBO_HORARIOIDContainer;r.setProp("Class","Class","","char");r.setProp("IconType","Icontype","Image","str");r.setProp("Icon","Icon","","str");r.setProp("Caption","Caption","","str");r.setProp("Tooltip","Tooltip","","str");r.setProp("Cls","Cls","ExtendedCombo Attribute","str");r.setDynProp("SelectedValue_set","Selectedvalue_set","","char");r.setProp("SelectedValue_get","Selectedvalue_get","","char");r.setDynProp("SelectedText_set","Selectedtext_set","","char");r.setProp("SelectedText_get","Selectedtext_get","","char");r.setProp("GAMOAuthToken","Gamoauthtoken","","char");r.setProp("DDOInternalName","Ddointernalname","","char");r.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");r.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");r.setDynProp("Enabled","Enabled",!0,"bool");r.setProp("Visible","Visible",!0,"bool");r.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");r.setProp("DataListType","Datalisttype","Dynamic","str");r.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");r.setProp("DataListFixedValues","Datalistfixedvalues","","char");r.setProp("IsGridItem","Isgriditem",!1,"bool");r.setProp("HasDescription","Hasdescription",!1,"bool");r.setProp("DataListProc","Datalistproc","Reloj_Interface.Reloj_CodigoIDLoadDVCombo","str");r.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix",' "ComboName": "HorarioID", "TrnMode": "INS", "IsDynamicCall": true, "CodigoId": ""',"str");r.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");r.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");r.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");r.setProp("EmptyItem","Emptyitem",!1,"bool");r.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");r.setProp("HTMLTemplate","Htmltemplate","","str");r.setProp("MultipleValuesType","Multiplevaluestype","Text","str");r.setProp("LoadingData","Loadingdata","","str");r.setProp("NoResultsFound","Noresultsfound","","str");r.setProp("EmptyItemText","Emptyitemtext","","char");r.setProp("OnlySelectedValues","Onlyselectedvalues","","char");r.setProp("SelectAllText","Selectalltext","","char");r.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");r.setProp("AddNewOptionText","Addnewoptiontext","","str");r.addV2CFunction("AV15DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");r.addC2VFunction(function(n){n.ParentObject.AV15DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV15DDO_TitleSettingsIcons)});r.addV2CFunction("AV33HorarioID_Data","vHORARIOID_DATA","SetDropDownOptionsData");r.addC2VFunction(function(n){n.ParentObject.AV33HorarioID_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vHORARIOID_DATA",n.ParentObject.AV33HorarioID_Data)});r.setProp("Gx Control Type","Gxcontroltype","","int");r.setC2ShowFunction(function(n){n.show()});r.addEventHandler("OnOptionClicked",this.e147z222_client);this.setUserControl(r);this.COMBO_RHTRABAJADORCODIGOContainer=gx.uc.getNew(this,66,28,"BootstrapDropDownOptions","COMBO_RHTRABAJADORCODIGOContainer","Combo_rhtrabajadorcodigo","COMBO_RHTRABAJADORCODIGO");u=this.COMBO_RHTRABAJADORCODIGOContainer;u.setProp("Class","Class","","char");u.setProp("IconType","Icontype","Image","str");u.setProp("Icon","Icon","","str");u.setProp("Caption","Caption","","str");u.setProp("Tooltip","Tooltip","","str");u.setProp("Cls","Cls","ExtendedCombo Attribute","str");u.setDynProp("SelectedValue_set","Selectedvalue_set","","char");u.setProp("SelectedValue_get","Selectedvalue_get","","char");u.setDynProp("SelectedText_set","Selectedtext_set","","char");u.setProp("SelectedText_get","Selectedtext_get","","char");u.setProp("GAMOAuthToken","Gamoauthtoken","","char");u.setProp("DDOInternalName","Ddointernalname","","char");u.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");u.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");u.setDynProp("Enabled","Enabled",!0,"bool");u.setProp("Visible","Visible",!0,"bool");u.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");u.setProp("DataListType","Datalisttype","Dynamic","str");u.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");u.setProp("DataListFixedValues","Datalistfixedvalues","","char");u.setProp("IsGridItem","Isgriditem",!1,"bool");u.setProp("HasDescription","Hasdescription",!1,"bool");u.setProp("DataListProc","Datalistproc","Reloj_Interface.Reloj_CodigoIDLoadDVCombo","str");u.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix",' "ComboName": "RHTrabajadorCodigo", "TrnMode": "INS", "IsDynamicCall": true, "CodigoId": ""',"str");u.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");u.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");u.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");u.setProp("EmptyItem","Emptyitem",!1,"bool");u.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");u.setProp("HTMLTemplate","Htmltemplate","","str");u.setProp("MultipleValuesType","Multiplevaluestype","Text","str");u.setProp("LoadingData","Loadingdata","","str");u.setProp("NoResultsFound","Noresultsfound","","str");u.setProp("EmptyItemText","Emptyitemtext","","char");u.setProp("OnlySelectedValues","Onlyselectedvalues","","char");u.setProp("SelectAllText","Selectalltext","","char");u.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");u.setProp("AddNewOptionText","Addnewoptiontext","","str");u.addV2CFunction("AV15DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");u.addC2VFunction(function(n){n.ParentObject.AV15DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV15DDO_TitleSettingsIcons)});u.addV2CFunction("AV26RHTrabajadorCodigo_Data","vRHTRABAJADORCODIGO_DATA","SetDropDownOptionsData");u.addC2VFunction(function(n){n.ParentObject.AV26RHTrabajadorCodigo_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vRHTRABAJADORCODIGO_DATA",n.ParentObject.AV26RHTrabajadorCodigo_Data)});u.setProp("Gx Control Type","Gxcontroltype","","int");u.setC2ShowFunction(function(n){n.show()});u.addEventHandler("OnOptionClicked",this.e137z222_client);this.setUserControl(u);this.DVPANEL_TABLEATTRIBUTESContainer=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_TABLEATTRIBUTESContainer","Dvpanel_tableattributes","DVPANEL_TABLEATTRIBUTES");f=this.DVPANEL_TABLEATTRIBUTESContainer;f.setProp("Class","Class","","char");f.setProp("Enabled","Enabled",!0,"boolean");f.setProp("Width","Width","100%","str");f.setProp("Height","Height","100","str");f.setProp("AutoWidth","Autowidth",!1,"bool");f.setProp("AutoHeight","Autoheight",!0,"bool");f.setProp("Cls","Cls","PanelFilled Panel_BaseColor","str");f.setProp("ShowHeader","Showheader",!0,"bool");f.setProp("Title","Title","Información General","str");f.setProp("Collapsible","Collapsible",!1,"bool");f.setProp("Collapsed","Collapsed",!1,"bool");f.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");f.setProp("IconPosition","Iconposition","Right","str");f.setProp("AutoScroll","Autoscroll",!1,"bool");f.setProp("Visible","Visible",!0,"bool");f.setProp("Gx Control Type","Gxcontroltype","","int");f.setC2ShowFunction(function(n){n.show()});this.setUserControl(f);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"TABLEATTRIBUTES",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"TABLESPLITTEDCODIGOID",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"TEXTBLOCKCODIGOID",format:0,grid:0,ctrltype:"textblock"};n[24]={id:24,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,lvl:0,type:"svchar",len:25,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Codigoid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CODIGOID",gxz:"Z2431CodigoId",gxold:"O2431CodigoId",gxvar:"A2431CodigoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2431CodigoId=n)},v2z:function(n){n!==undefined&&(gx.O.Z2431CodigoId=n)},v2c:function(){gx.fn.setControlValue("CODIGOID",gx.O.A2431CodigoId,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2431CodigoId=this.val())},val:function(){return gx.fn.getControlValue("CODIGOID")},nac:function(){return!(gx.text.compare("",this.AV29CodigoId)==0)}};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"TABLESPLITTEDRELOJ_ID",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"TEXTBLOCKRELOJ_ID",format:0,grid:0,ctrltype:"textblock"};n[35]={id:35,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Reloj_id,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RELOJ_ID",gxz:"Z2498Reloj_ID",gxold:"O2498Reloj_ID",gxvar:"A2498Reloj_ID",ucs:[],op:[43],ip:[43,39],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2498Reloj_ID=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z2498Reloj_ID=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("RELOJ_ID",gx.O.A2498Reloj_ID,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2498Reloj_ID=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("RELOJ_ID",",")},nac:function(){return gx.text.compare(this.Gx_mode,"INS")==0&&!(0==this.AV23Insert_Reloj_ID)}};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,lvl:0,type:"svchar",len:50,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RELOJ_NOMBRE",gxz:"Z2592Reloj_Nombre",gxold:"O2592Reloj_Nombre",gxvar:"A2592Reloj_Nombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2592Reloj_Nombre=n)},v2z:function(n){n!==undefined&&(gx.O.Z2592Reloj_Nombre=n)},v2c:function(){gx.fn.setControlValue("RELOJ_NOMBRE",gx.O.A2592Reloj_Nombre,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2592Reloj_Nombre=this.val())},val:function(){return gx.fn.getControlValue("RELOJ_NOMBRE")},nac:gx.falseFn};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"TABLESPLITTEDHORARIOID",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"TEXTBLOCKHORARIOID",format:0,grid:0,ctrltype:"textblock"};n[50]={id:50,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Horarioid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"HORARIOID",gxz:"Z2591HorarioID",gxold:"O2591HorarioID",gxvar:"A2591HorarioID",ucs:[],op:[58],ip:[58,54],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2591HorarioID=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z2591HorarioID=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("HORARIOID",gx.O.A2591HorarioID,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2591HorarioID=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("HORARIOID",",")},nac:function(){return gx.text.compare(this.Gx_mode,"INS")==0&&!(0==this.AV25Insert_HorarioID)}};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,lvl:0,type:"svchar",len:100,dec:5,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"HORARIODESCRIPCION",gxz:"Z2593HorarioDescripcion",gxold:"O2593HorarioDescripcion",gxvar:"A2593HorarioDescripcion",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2593HorarioDescripcion=n)},v2z:function(n){n!==undefined&&(gx.O.Z2593HorarioDescripcion=n)},v2c:function(){gx.fn.setControlValue("HORARIODESCRIPCION",gx.O.A2593HorarioDescripcion,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2593HorarioDescripcion=this.val())},val:function(){return gx.fn.getControlValue("HORARIODESCRIPCION")},nac:gx.falseFn};n[59]={id:59,fld:"",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"TABLESPLITTEDRHTRABAJADORCODIGO",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"",grid:0};n[64]={id:64,fld:"TEXTBLOCKRHTRABAJADORCODIGO",format:0,grid:0,ctrltype:"textblock"};n[65]={id:65,fld:"",grid:0};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,lvl:0,type:"svchar",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Rhtrabajadorcodigo,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RHTRABAJADORCODIGO",gxz:"Z2589RHTrabajadorCodigo",gxold:"O2589RHTrabajadorCodigo",gxvar:"A2589RHTrabajadorCodigo",ucs:[],op:[73],ip:[73,69],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2589RHTrabajadorCodigo=n)},v2z:function(n){n!==undefined&&(gx.O.Z2589RHTrabajadorCodigo=n)},v2c:function(){gx.fn.setControlValue("RHTRABAJADORCODIGO",gx.O.A2589RHTrabajadorCodigo,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2589RHTrabajadorCodigo=this.val())},val:function(){return gx.fn.getControlValue("RHTRABAJADORCODIGO")},nac:function(){return gx.text.compare(this.Gx_mode,"INS")==0&&!(gx.text.compare("",this.AV24Insert_RHTrabajadorCodigo)==0)}};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"",grid:0};n[73]={id:73,lvl:0,type:"svchar",len:300,dec:0,sign:!1,ro:1,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RHTRABAJADORNOMBRES",gxz:"Z2590RHTrabajadorNombres",gxold:"O2590RHTrabajadorNombres",gxvar:"A2590RHTrabajadorNombres",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2590RHTrabajadorNombres=n)},v2z:function(n){n!==undefined&&(gx.O.Z2590RHTrabajadorNombres=n)},v2c:function(){gx.fn.setControlValue("RHTRABAJADORNOMBRES",gx.O.A2590RHTrabajadorNombres,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2590RHTrabajadorNombres=this.val())},val:function(){return gx.fn.getControlValue("RHTRABAJADORNOMBRES")},nac:gx.falseFn};n[74]={id:74,fld:"",grid:0};n[75]={id:75,fld:"",grid:0};n[76]={id:76,fld:"",grid:0};n[77]={id:77,fld:"",grid:0};n[78]={id:78,lvl:0,type:"dtime",len:10,dec:8,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Lectura_ini,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LECTURA_INI",gxz:"Z2415Lectura_Ini",gxold:"O2415Lectura_Ini",gxvar:"A2415Lectura_Ini",dp:{f:0,st:!0,wn:!1,mf:!1,pic:"99/99/9999 99:99:99",dec:8},ucs:[],op:[78],ip:[78],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2415Lectura_Ini=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z2415Lectura_Ini=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("LECTURA_INI",gx.O.A2415Lectura_Ini,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2415Lectura_Ini=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getDateTimeValue("LECTURA_INI")},nac:gx.falseFn};n[79]={id:79,fld:"",grid:0};n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"",grid:0};n[82]={id:82,lvl:0,type:"dtime",len:10,dec:8,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Lectura_fin,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LECTURA_FIN",gxz:"Z2416Lectura_Fin",gxold:"O2416Lectura_Fin",gxvar:"A2416Lectura_Fin",dp:{f:0,st:!0,wn:!1,mf:!1,pic:"99/99/9999 99:99:99",dec:8},ucs:[],op:[82],ip:[82],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2416Lectura_Fin=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z2416Lectura_Fin=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("LECTURA_FIN",gx.O.A2416Lectura_Fin,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2416Lectura_Fin=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getDateTimeValue("LECTURA_FIN")},nac:gx.falseFn};n[83]={id:83,fld:"",grid:0};n[84]={id:84,fld:"",grid:0};n[85]={id:85,fld:"",grid:0};n[86]={id:86,fld:"",grid:0};n[87]={id:87,fld:"BTNTRN_ENTER",grid:0,evt:"e177z222_client",std:"ENTER"};n[88]={id:88,fld:"",grid:0};n[89]={id:89,fld:"BTNTRN_CANCEL",grid:0,evt:"e187z222_client"};n[90]={id:90,fld:"",grid:0};n[91]={id:91,fld:"BTNTRN_DELETE",grid:0,evt:"e197z222_client",std:"DELETE"};n[92]={id:92,fld:"",grid:0};n[93]={id:93,fld:"",grid:0};n[94]={id:94,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[95]={id:95,fld:"SECTIONATTRIBUTE_CODIGOID",grid:0};n[96]={id:96,lvl:0,type:"svchar",len:25,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:this.Validv_Combocodigoid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCOMBOCODIGOID",gxz:"ZV37ComboCodigoId",gxold:"OV37ComboCodigoId",gxvar:"AV37ComboCodigoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV37ComboCodigoId=n)},v2z:function(n){n!==undefined&&(gx.O.ZV37ComboCodigoId=n)},v2c:function(){gx.fn.setControlValue("vCOMBOCODIGOID",gx.O.AV37ComboCodigoId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV37ComboCodigoId=this.val())},val:function(){return gx.fn.getControlValue("vCOMBOCODIGOID")},nac:gx.falseFn};n[97]={id:97,fld:"SECTIONATTRIBUTE_RELOJ_ID",grid:0};n[98]={id:98,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Validv_Comboreloj_id,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCOMBORELOJ_ID",gxz:"ZV31ComboReloj_ID",gxold:"OV31ComboReloj_ID",gxvar:"AV31ComboReloj_ID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV31ComboReloj_ID=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV31ComboReloj_ID=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCOMBORELOJ_ID",gx.O.AV31ComboReloj_ID,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV31ComboReloj_ID=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCOMBORELOJ_ID",",")},nac:gx.falseFn};n[99]={id:99,fld:"SECTIONATTRIBUTE_HORARIOID",grid:0};n[100]={id:100,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Validv_Combohorarioid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCOMBOHORARIOID",gxz:"ZV34ComboHorarioID",gxold:"OV34ComboHorarioID",gxvar:"AV34ComboHorarioID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV34ComboHorarioID=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV34ComboHorarioID=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCOMBOHORARIOID",gx.O.AV34ComboHorarioID,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV34ComboHorarioID=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCOMBOHORARIOID",",")},nac:gx.falseFn};n[101]={id:101,fld:"SECTIONATTRIBUTE_RHTRABAJADORCODIGO",grid:0};n[102]={id:102,lvl:0,type:"svchar",len:20,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:this.Validv_Comborhtrabajadorcodigo,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCOMBORHTRABAJADORCODIGO",gxz:"ZV27ComboRHTrabajadorCodigo",gxold:"OV27ComboRHTrabajadorCodigo",gxvar:"AV27ComboRHTrabajadorCodigo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV27ComboRHTrabajadorCodigo=n)},v2z:function(n){n!==undefined&&(gx.O.ZV27ComboRHTrabajadorCodigo=n)},v2c:function(){gx.fn.setControlValue("vCOMBORHTRABAJADORCODIGO",gx.O.AV27ComboRHTrabajadorCodigo,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV27ComboRHTrabajadorCodigo=this.val())},val:function(){return gx.fn.getControlValue("vCOMBORHTRABAJADORCODIGO")},nac:gx.falseFn};this.A2431CodigoId="";this.Z2431CodigoId="";this.O2431CodigoId="";this.A2498Reloj_ID=0;this.Z2498Reloj_ID=0;this.O2498Reloj_ID=0;this.A2592Reloj_Nombre="";this.Z2592Reloj_Nombre="";this.O2592Reloj_Nombre="";this.A2591HorarioID=0;this.Z2591HorarioID=0;this.O2591HorarioID=0;this.A2593HorarioDescripcion="";this.Z2593HorarioDescripcion="";this.O2593HorarioDescripcion="";this.A2589RHTrabajadorCodigo="";this.Z2589RHTrabajadorCodigo="";this.O2589RHTrabajadorCodigo="";this.A2590RHTrabajadorNombres="";this.Z2590RHTrabajadorNombres="";this.O2590RHTrabajadorNombres="";this.A2415Lectura_Ini=gx.date.nullDate();this.Z2415Lectura_Ini=gx.date.nullDate();this.O2415Lectura_Ini=gx.date.nullDate();this.A2416Lectura_Fin=gx.date.nullDate();this.Z2416Lectura_Fin=gx.date.nullDate();this.O2416Lectura_Fin=gx.date.nullDate();this.AV37ComboCodigoId="";this.ZV37ComboCodigoId="";this.OV37ComboCodigoId="";this.AV31ComboReloj_ID=0;this.ZV31ComboReloj_ID=0;this.OV31ComboReloj_ID=0;this.AV34ComboHorarioID=0;this.ZV34ComboHorarioID=0;this.OV34ComboHorarioID=0;this.AV27ComboRHTrabajadorCodigo="";this.ZV27ComboRHTrabajadorCodigo="";this.OV27ComboRHTrabajadorCodigo="";this.AV8WWPContext={UserId:0,UserName:""};this.AV27ComboRHTrabajadorCodigo="";this.AV34ComboHorarioID=0;this.AV31ComboReloj_ID=0;this.AV37ComboCodigoId="";this.AV9TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV40GXV1=0;this.AV23Insert_Reloj_ID=0;this.AV18Combo_DataJson="";this.AV24Insert_RHTrabajadorCodigo="";this.AV25Insert_HorarioID=0;this.AV13TrnContextAtt={AttributeName:"",AttributeValue:""};this.AV17ComboSelectedText="";this.AV16ComboSelectedValue="";this.AV29CodigoId="";this.AV10WebSession={};this.A2431CodigoId="";this.A2498Reloj_ID=0;this.A2589RHTrabajadorCodigo="";this.A2591HorarioID=0;this.AV39Pgmname="";this.Gx_BScreen=0;this.A2592Reloj_Nombre="";this.A2415Lectura_Ini=gx.date.nullDate();this.A2416Lectura_Fin=gx.date.nullDate();this.A2590RHTrabajadorNombres="";this.A2593HorarioDescripcion="";this.A2525TrabApePat="";this.A2526TrabApeMat="";this.A2527TrabNombres="";this.AV15DDO_TitleSettingsIcons={Default_fi:"",Filtered_fi:"",SortedASC_fi:"",SortedDSC_fi:"",FilteredSortedASC_fi:"",FilteredSortedDSC_fi:"",OptionSortASC_fi:"",OptionSortDSC_fi:"",OptionApplyFilter_fi:"",OptionFilteringData_fi:"",OptionCleanFilters_fi:"",SelectedOption_fi:"",MultiselOption_fi:"",MultiselSelOption_fi:"",TreeviewCollapse_fi:"",TreeviewExpand_fi:"",FixLeft_fi:"",FixRight_fi:""};this.AV36CodigoId_Data=[];this.AV30Reloj_ID_Data=[];this.AV33HorarioID_Data=[];this.AV26RHTrabajadorCodigo_Data=[];this.Gx_mode="";this.Events={e127z2_client:["AFTER TRN",!0],e177z222_client:["ENTER",!0],e187z222_client:["CANCEL",!0],e137z222_client:["COMBO_RHTRABAJADORCODIGO.ONOPTIONCLICKED",!1],e147z222_client:["COMBO_HORARIOID.ONOPTIONCLICKED",!1],e157z222_client:["COMBO_RELOJ_ID.ONOPTIONCLICKED",!1],e167z222_client:["COMBO_CODIGOID.ONOPTIONCLICKED",!1]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV29CodigoId",fld:"vCODIGOID",pic:"",hsh:!0}],[]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{av:"AV29CodigoId",fld:"vCODIGOID",pic:"",hsh:!0}],[]];this.EvtParms["AFTER TRN"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0}],[]];this.EvtParms["COMBO_RHTRABAJADORCODIGO.ONOPTIONCLICKED"]=[[{av:"this.COMBO_RHTRABAJADORCODIGOContainer.SelectedValue_get",ctrl:"COMBO_RHTRABAJADORCODIGO",prop:"SelectedValue_get"}],[{av:"AV27ComboRHTrabajadorCodigo",fld:"vCOMBORHTRABAJADORCODIGO",pic:""}]];this.EvtParms["COMBO_HORARIOID.ONOPTIONCLICKED"]=[[{av:"this.COMBO_HORARIOIDContainer.SelectedValue_get",ctrl:"COMBO_HORARIOID",prop:"SelectedValue_get"}],[{av:"AV34ComboHorarioID",fld:"vCOMBOHORARIOID",pic:"ZZZ9"}]];this.EvtParms["COMBO_RELOJ_ID.ONOPTIONCLICKED"]=[[{av:"this.COMBO_RELOJ_IDContainer.SelectedValue_get",ctrl:"COMBO_RELOJ_ID",prop:"SelectedValue_get"}],[{av:"AV31ComboReloj_ID",fld:"vCOMBORELOJ_ID",pic:"ZZZ9"}]];this.EvtParms["COMBO_CODIGOID.ONOPTIONCLICKED"]=[[{av:"this.COMBO_CODIGOIDContainer.SelectedValue_get",ctrl:"COMBO_CODIGOID",prop:"SelectedValue_get"}],[{av:"AV37ComboCodigoId",fld:"vCOMBOCODIGOID",pic:""}]];this.EvtParms.VALID_CODIGOID=[[],[]];this.EvtParms.VALID_RELOJ_ID=[[{av:"A2498Reloj_ID",fld:"RELOJ_ID",pic:"ZZZ9"},{av:"A2592Reloj_Nombre",fld:"RELOJ_NOMBRE",pic:""}],[{av:"A2592Reloj_Nombre",fld:"RELOJ_NOMBRE",pic:""}]];this.EvtParms.VALID_HORARIOID=[[{av:"A2591HorarioID",fld:"HORARIOID",pic:"ZZZ9"},{av:"A2593HorarioDescripcion",fld:"HORARIODESCRIPCION",pic:""}],[{av:"A2593HorarioDescripcion",fld:"HORARIODESCRIPCION",pic:""}]];this.EvtParms.VALID_RHTRABAJADORCODIGO=[[{av:"A2589RHTrabajadorCodigo",fld:"RHTRABAJADORCODIGO",pic:""},{av:"A2525TrabApePat",fld:"TRABAPEPAT",pic:""},{av:"A2526TrabApeMat",fld:"TRABAPEMAT",pic:""},{av:"A2527TrabNombres",fld:"TRABNOMBRES",pic:""},{av:"A2590RHTrabajadorNombres",fld:"RHTRABAJADORNOMBRES",pic:""}],[{av:"A2525TrabApePat",fld:"TRABAPEPAT",pic:""},{av:"A2526TrabApeMat",fld:"TRABAPEMAT",pic:""},{av:"A2527TrabNombres",fld:"TRABNOMBRES",pic:""},{av:"A2590RHTrabajadorNombres",fld:"RHTRABAJADORNOMBRES",pic:""}]];this.EvtParms.VALID_LECTURA_INI=[[{av:"A2415Lectura_Ini",fld:"LECTURA_INI",pic:"99/99/9999 99:99:99"}],[{av:"A2415Lectura_Ini",fld:"LECTURA_INI",pic:"99/99/9999 99:99:99"}]];this.EvtParms.VALID_LECTURA_FIN=[[{av:"A2416Lectura_Fin",fld:"LECTURA_FIN",pic:"99/99/9999 99:99:99"}],[{av:"A2416Lectura_Fin",fld:"LECTURA_FIN",pic:"99/99/9999 99:99:99"}]];this.EvtParms.VALIDV_COMBOCODIGOID=[[],[]];this.EvtParms.VALIDV_COMBORELOJ_ID=[[],[]];this.EvtParms.VALIDV_COMBOHORARIOID=[[],[]];this.EvtParms.VALIDV_COMBORHTRABAJADORCODIGO=[[],[]];this.EnterCtrl=["BTNTRN_ENTER"];this.setVCMap("A2525TrabApePat","TRABAPEPAT",0,"svchar",100,0);this.setVCMap("A2526TrabApeMat","TRABAPEMAT",0,"svchar",100,0);this.setVCMap("A2527TrabNombres","TRABNOMBRES",0,"svchar",100,0);this.setVCMap("AV29CodigoId","vCODIGOID",0,"svchar",25,0);this.setVCMap("AV23Insert_Reloj_ID","vINSERT_RELOJ_ID",0,"int",4,0);this.setVCMap("AV24Insert_RHTrabajadorCodigo","vINSERT_RHTRABAJADORCODIGO",0,"svchar",20,0);this.setVCMap("AV25Insert_HorarioID","vINSERT_HORARIOID",0,"int",4,0);this.setVCMap("Gx_BScreen","vGXBSCREEN",0,"int",1,0);this.setVCMap("AV39Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV9TrnContext","vTRNCONTEXT",0,"WWPBaseObjectsWWPTransactionContext",0,0);this.Initialize();this.setSDTMapping("WWPBaseObjects\\DVB_SDTDropDownOptionsTitleSettingsIcons",{Default_fi:{extr:"def"},Filtered_fi:{extr:"fil"},SortedASC_fi:{extr:"asc"},SortedDSC_fi:{extr:"dsc"},FilteredSortedASC_fi:{extr:"fasc"},FilteredSortedDSC_fi:{extr:"fdsc"},OptionSortASC_fi:{extr:"osasc"},OptionSortDSC_fi:{extr:"osdsc"},OptionApplyFilter_fi:{extr:"app"},OptionFilteringData_fi:{extr:"fildata"},OptionCleanFilters_fi:{extr:"cle"},SelectedOption_fi:{extr:"selo"},MultiselOption_fi:{extr:"mul"},MultiselSelOption_fi:{extr:"muls"},TreeviewCollapse_fi:{extr:"tcol"},TreeviewExpand_fi:{extr:"texp"},FixLeft_fi:{extr:"fixl"},FixRight_fi:{extr:"fixr"}});this.setSDTMapping("WWPBaseObjects\\WWPTransactionContext",{Attributes:{sdt:"WWPBaseObjects\\WWPTransactionContext.Attribute"}});this.setSDTMapping("WWPBaseObjects\\DVB_SDTComboData.Item",{Title:{extr:"T"},Children:{extr:"C"}})});gx.wi(function(){gx.createParentObj(this.reloj_interface.reloj_codigoid)})