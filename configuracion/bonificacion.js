gx.evt.autoSkip=!1;gx.define("configuracion.bonificacion",!1,function(){var n,t,i,r;this.ServerClass="configuracion.bonificacion";this.PackageName="GeneXus.Programs";this.ServerFullClass="configuracion.bonificacion.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV7CBonProdCod=gx.fn.getControlValue("vCBONPRODCOD");this.AV11Insert_CBonDProdCod=gx.fn.getControlValue("vINSERT_CBONDPRODCOD");this.A498CBonCan2=gx.fn.getDecimalValue("CBONCAN2",",",".");this.A493CBonBon2=gx.fn.getDecimalValue("CBONBON2",",",".");this.A499CBonCan3=gx.fn.getDecimalValue("CBONCAN3",",",".");this.A494CBonBon3=gx.fn.getDecimalValue("CBONBON3",",",".");this.A500CBonCan4=gx.fn.getDecimalValue("CBONCAN4",",",".");this.A495CBonBon4=gx.fn.getDecimalValue("CBONBON4",",",".");this.A501CBonCan5=gx.fn.getDecimalValue("CBONCAN5",",",".");this.A496CBonBon5=gx.fn.getDecimalValue("CBONBON5",",",".");this.A503CBonProdDsc=gx.fn.getControlValue("CBONPRODDSC");this.A502CBonDProdDsc=gx.fn.getControlValue("CBONDPRODDSC");this.AV22Pgmname=gx.fn.getControlValue("vPGMNAME");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV9TrnContext=gx.fn.getControlValue("vTRNCONTEXT")};this.Valid_Cbonprodcod=function(){return this.validSrvEvt("Valid_Cbonprodcod",0).then(function(n){return n}.closure(this))};this.Valid_Cbondprodcod=function(){return this.validSrvEvt("Valid_Cbondprodcod",0).then(function(n){return n}.closure(this))};this.Valid_Cboncan1=function(){return this.validCliEvt("Valid_Cboncan1",0,function(){try{var n=gx.util.balloon.getNew("CBONCAN1");if(this.AnyError=0,0==this.A497CBonCan1)try{n.setError(gx.text.format("%1 es requerido.","Cantidad","","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Combocbonprodcod=function(){return this.validCliEvt("Validv_Combocbonprodcod",0,function(){try{var n=gx.util.balloon.getNew("vCOMBOCBONPRODCOD");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Combocbondprodcod=function(){return this.validCliEvt("Validv_Combocbondprodcod",0,function(){try{var n=gx.util.balloon.getNew("vCOMBOCBONDPRODCOD");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e13694_client=function(){return this.clearMessages(),this.AV21ComboCBonDProdCod=this.COMBO_CBONDPRODCODContainer.SelectedValue_get,this.refreshOutputs([{av:"AV21ComboCBonDProdCod",fld:"vCOMBOCBONDPRODCOD",pic:"@!"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e14694_client=function(){return this.clearMessages(),this.AV18ComboCBonProdCod=this.COMBO_CBONPRODCODContainer.SelectedValue_get,this.refreshOutputs([{av:"AV18ComboCBonProdCod",fld:"vCOMBOCBONPRODCOD",pic:"@!"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e12692_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e15694_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e16694_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,25,26,27,28,30,31,32,33,34,35,36,37,38,39,40,41,42,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71];this.GXLastCtrlId=71;this.COMBO_CBONPRODCODContainer=gx.uc.getNew(this,29,0,"BootstrapDropDownOptions","COMBO_CBONPRODCODContainer","Combo_cbonprodcod","COMBO_CBONPRODCOD");t=this.COMBO_CBONPRODCODContainer;t.setProp("Class","Class","","char");t.setProp("IconType","Icontype","Image","str");t.setProp("Icon","Icon","","str");t.setProp("Caption","Caption","","str");t.setProp("Tooltip","Tooltip","","str");t.setProp("Cls","Cls","ExtendedCombo AttributeRealWidth100With","str");t.setDynProp("SelectedValue_set","Selectedvalue_set","","char");t.setProp("SelectedValue_get","Selectedvalue_get","","char");t.setProp("SelectedText_set","Selectedtext_set","","char");t.setProp("SelectedText_get","Selectedtext_get","","char");t.setProp("GAMOAuthToken","Gamoauthtoken","","char");t.setProp("DDOInternalName","Ddointernalname","","char");t.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");t.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");t.setDynProp("Enabled","Enabled",!0,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");t.setProp("DataListType","Datalisttype","Dynamic","str");t.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");t.setProp("DataListFixedValues","Datalistfixedvalues","","char");t.setProp("IsGridItem","Isgriditem",!1,"bool");t.setProp("HasDescription","Hasdescription",!1,"bool");t.setProp("DataListProc","Datalistproc","","str");t.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");t.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");t.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");t.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");t.setProp("EmptyItem","Emptyitem",!0,"bool");t.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");t.setProp("HTMLTemplate","Htmltemplate","","str");t.setProp("MultipleValuesType","Multiplevaluestype","Text","str");t.setProp("LoadingData","Loadingdata","","char");t.setProp("NoResultsFound","Noresultsfound","","char");t.setProp("EmptyItemText","Emptyitemtext","GX_EmptyItemText","str");t.setProp("OnlySelectedValues","Onlyselectedvalues","","char");t.setProp("SelectAllText","Selectalltext","","char");t.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");t.setProp("AddNewOptionText","Addnewoptiontext","","str");t.setProp("DropDownOptionsTitleSettingsIcons","Dropdownoptionstitlesettingsicons","","str");t.addV2CFunction("AV13CBonProdCod_Data","vCBONPRODCOD_DATA","SetDropDownOptionsData");t.addC2VFunction(function(n){n.ParentObject.AV13CBonProdCod_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vCBONPRODCOD_DATA",n.ParentObject.AV13CBonProdCod_Data)});t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("OnOptionClicked",this.e14694_client);this.setUserControl(t);this.COMBO_CBONDPRODCODContainer=gx.uc.getNew(this,43,32,"BootstrapDropDownOptions","COMBO_CBONDPRODCODContainer","Combo_cbondprodcod","COMBO_CBONDPRODCOD");i=this.COMBO_CBONDPRODCODContainer;i.setProp("Class","Class","","char");i.setProp("IconType","Icontype","Image","str");i.setProp("Icon","Icon","","str");i.setProp("Caption","Caption","","str");i.setProp("Tooltip","Tooltip","","str");i.setProp("Cls","Cls","ExtendedCombo AttributeRealWidth100With","str");i.setDynProp("SelectedValue_set","Selectedvalue_set","","char");i.setProp("SelectedValue_get","Selectedvalue_get","","char");i.setProp("SelectedText_set","Selectedtext_set","","char");i.setProp("SelectedText_get","Selectedtext_get","","char");i.setProp("GAMOAuthToken","Gamoauthtoken","","char");i.setProp("DDOInternalName","Ddointernalname","","char");i.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");i.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");i.setDynProp("Enabled","Enabled",!0,"bool");i.setProp("Visible","Visible",!0,"bool");i.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");i.setProp("DataListType","Datalisttype","Dynamic","str");i.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");i.setProp("DataListFixedValues","Datalistfixedvalues","","char");i.setProp("IsGridItem","Isgriditem",!1,"bool");i.setProp("HasDescription","Hasdescription",!1,"bool");i.setProp("DataListProc","Datalistproc","","str");i.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");i.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");i.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");i.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");i.setProp("EmptyItem","Emptyitem",!0,"bool");i.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");i.setProp("HTMLTemplate","Htmltemplate","","str");i.setProp("MultipleValuesType","Multiplevaluestype","Text","str");i.setProp("LoadingData","Loadingdata","","char");i.setProp("NoResultsFound","Noresultsfound","","char");i.setProp("EmptyItemText","Emptyitemtext","GX_EmptyItemText","str");i.setProp("OnlySelectedValues","Onlyselectedvalues","","char");i.setProp("SelectAllText","Selectalltext","","char");i.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");i.setProp("AddNewOptionText","Addnewoptiontext","","str");i.setProp("DropDownOptionsTitleSettingsIcons","Dropdownoptionstitlesettingsicons","","str");i.addV2CFunction("AV20CBonDProdCod_Data","vCBONDPRODCOD_DATA","SetDropDownOptionsData");i.addC2VFunction(function(n){n.ParentObject.AV20CBonDProdCod_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vCBONDPRODCOD_DATA",n.ParentObject.AV20CBonDProdCod_Data)});i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});i.addEventHandler("OnOptionClicked",this.e13694_client);this.setUserControl(i);this.DVPANEL_TABLEATTRIBUTESContainer=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_TABLEATTRIBUTESContainer","Dvpanel_tableattributes","DVPANEL_TABLEATTRIBUTES");r=this.DVPANEL_TABLEATTRIBUTESContainer;r.setProp("Class","Class","","char");r.setProp("Enabled","Enabled",!0,"boolean");r.setProp("Width","Width","100%","str");r.setProp("Height","Height","100","str");r.setProp("AutoWidth","Autowidth",!1,"bool");r.setProp("AutoHeight","Autoheight",!0,"bool");r.setProp("Cls","Cls","PanelFilled Panel_BaseColor","str");r.setProp("ShowHeader","Showheader",!0,"bool");r.setProp("Title","Title","Información General","str");r.setProp("Collapsible","Collapsible",!1,"bool");r.setProp("Collapsed","Collapsed",!1,"bool");r.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");r.setProp("IconPosition","Iconposition","Right","str");r.setProp("AutoScroll","Autoscroll",!1,"bool");r.setProp("Visible","Visible",!0,"bool");r.setProp("Gx Control Type","Gxcontroltype","","int");r.setC2ShowFunction(function(n){n.show()});this.setUserControl(r);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"TABLEATTRIBUTES",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"UNNAMEDGROUP1",grid:0};n[21]={id:21,fld:"GRUP1",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"TABLESPLITTEDCBONPRODCOD",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"TEXTBLOCKCBONPRODCOD",format:0,grid:0,ctrltype:"textblock"};n[28]={id:28,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,lvl:0,type:"char",len:15,dec:0,sign:!1,pic:"@!",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cbonprodcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CBONPRODCOD",gxz:"Z81CBonProdCod",gxold:"O81CBonProdCod",gxvar:"A81CBonProdCod",ucs:[],op:[32],ip:[32],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A81CBonProdCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z81CBonProdCod=n)},v2c:function(){gx.fn.setControlValue("CBONPRODCOD",gx.O.A81CBonProdCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A81CBonProdCod=this.val())},val:function(){return gx.fn.getControlValue("CBONPRODCOD")},nac:function(){return!(gx.text.compare("",this.AV7CBonProdCod)==0)}};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"UNNAMEDGROUP2",grid:0};n[35]={id:35,fld:"GRUP2",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"TABLESPLITTEDCBONDPRODCOD",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"TEXTBLOCKCBONDPRODCOD",format:0,grid:0,ctrltype:"textblock"};n[42]={id:42,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,lvl:0,type:"char",len:15,dec:0,sign:!1,pic:"@!",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cbondprodcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CBONDPRODCOD",gxz:"Z82CBonDProdCod",gxold:"O82CBonDProdCod",gxvar:"A82CBonDProdCod",ucs:[],op:[46],ip:[46],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A82CBonDProdCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z82CBonDProdCod=n)},v2c:function(){gx.fn.setControlValue("CBONDPRODCOD",gx.O.A82CBonDProdCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A82CBonDProdCod=this.val())},val:function(){return gx.fn.getControlValue("CBONDPRODCOD")},nac:function(){return gx.text.compare(this.Gx_mode,"INS")==0&&!(gx.text.compare("",this.AV11Insert_CBonDProdCod)==0)}};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,lvl:0,type:"decimal",len:15,dec:2,sign:!0,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cboncan1,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CBONCAN1",gxz:"Z497CBonCan1",gxold:"O497CBonCan1",gxvar:"A497CBonCan1",ucs:[],op:[51],ip:[51],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A497CBonCan1=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z497CBonCan1=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("CBONCAN1",gx.O.A497CBonCan1,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A497CBonCan1=this.val())},val:function(){return gx.fn.getDecimalValue("CBONCAN1",",",".")},nac:gx.falseFn};this.declareDomainHdlr(51,function(){});n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,lvl:0,type:"decimal",len:15,dec:2,sign:!0,pic:"ZZZZZZ,ZZZ,ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CBONBON1",gxz:"Z492CBonBon1",gxold:"O492CBonBon1",gxvar:"A492CBonBon1",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A492CBonBon1=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z492CBonBon1=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("CBONBON1",gx.O.A492CBonBon1,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A492CBonBon1=this.val())},val:function(){return gx.fn.getDecimalValue("CBONBON1",",",".")},nac:gx.falseFn};this.declareDomainHdlr(55,function(){});n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,fld:"",grid:0};n[60]={id:60,fld:"BTNTRN_ENTER",grid:0,evt:"e15694_client",std:"ENTER"};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"BTNTRN_CANCEL",grid:0,evt:"e16694_client"};n[63]={id:63,fld:"",grid:0};n[64]={id:64,fld:"BTNTRN_DELETE",grid:0,evt:"e17694_client",std:"DELETE"};n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"",grid:0};n[67]={id:67,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[68]={id:68,fld:"SECTIONATTRIBUTE_CBONPRODCOD",grid:0};n[69]={id:69,lvl:0,type:"char",len:15,dec:0,sign:!1,pic:"@!",ro:1,grid:0,gxgrid:null,fnc:this.Validv_Combocbonprodcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCOMBOCBONPRODCOD",gxz:"ZV18ComboCBonProdCod",gxold:"OV18ComboCBonProdCod",gxvar:"AV18ComboCBonProdCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV18ComboCBonProdCod=n)},v2z:function(n){n!==undefined&&(gx.O.ZV18ComboCBonProdCod=n)},v2c:function(){gx.fn.setControlValue("vCOMBOCBONPRODCOD",gx.O.AV18ComboCBonProdCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV18ComboCBonProdCod=this.val())},val:function(){return gx.fn.getControlValue("vCOMBOCBONPRODCOD")},nac:gx.falseFn};n[70]={id:70,fld:"SECTIONATTRIBUTE_CBONDPRODCOD",grid:0};n[71]={id:71,lvl:0,type:"char",len:15,dec:0,sign:!1,pic:"@!",ro:1,grid:0,gxgrid:null,fnc:this.Validv_Combocbondprodcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCOMBOCBONDPRODCOD",gxz:"ZV21ComboCBonDProdCod",gxold:"OV21ComboCBonDProdCod",gxvar:"AV21ComboCBonDProdCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV21ComboCBonDProdCod=n)},v2z:function(n){n!==undefined&&(gx.O.ZV21ComboCBonDProdCod=n)},v2c:function(){gx.fn.setControlValue("vCOMBOCBONDPRODCOD",gx.O.AV21ComboCBonDProdCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV21ComboCBonDProdCod=this.val())},val:function(){return gx.fn.getControlValue("vCOMBOCBONDPRODCOD")},nac:gx.falseFn};this.A81CBonProdCod="";this.Z81CBonProdCod="";this.O81CBonProdCod="";this.A82CBonDProdCod="";this.Z82CBonDProdCod="";this.O82CBonDProdCod="";this.A497CBonCan1=0;this.Z497CBonCan1=0;this.O497CBonCan1=0;this.A492CBonBon1=0;this.Z492CBonBon1=0;this.O492CBonBon1=0;this.AV18ComboCBonProdCod="";this.ZV18ComboCBonProdCod="";this.OV18ComboCBonProdCod="";this.AV21ComboCBonDProdCod="";this.ZV21ComboCBonDProdCod="";this.OV21ComboCBonDProdCod="";this.AV8WWPContext={UserId:0,UserName:""};this.AV21ComboCBonDProdCod="";this.AV18ComboCBonProdCod="";this.AV9TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV23GXV1=0;this.AV11Insert_CBonDProdCod="";this.AV12TrnContextAtt={AttributeName:"",AttributeValue:""};this.AV7CBonProdCod="";this.AV10WebSession={};this.A81CBonProdCod="";this.A82CBonDProdCod="";this.AV22Pgmname="";this.A503CBonProdDsc="";this.A502CBonDProdDsc="";this.A497CBonCan1=0;this.A492CBonBon1=0;this.A498CBonCan2=0;this.A493CBonBon2=0;this.A499CBonCan3=0;this.A494CBonBon3=0;this.A500CBonCan4=0;this.A495CBonBon4=0;this.A501CBonCan5=0;this.A496CBonBon5=0;this.AV13CBonProdCod_Data=[];this.AV20CBonDProdCod_Data=[];this.Gx_mode="";this.Events={e12692_client:["AFTER TRN",!0],e15694_client:["ENTER",!0],e16694_client:["CANCEL",!0],e13694_client:["COMBO_CBONDPRODCOD.ONOPTIONCLICKED",!1],e14694_client:["COMBO_CBONPRODCOD.ONOPTIONCLICKED",!1]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV7CBonProdCod",fld:"vCBONPRODCOD",pic:"@!",hsh:!0}],[]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{av:"AV7CBonProdCod",fld:"vCBONPRODCOD",pic:"@!",hsh:!0},{av:"A498CBonCan2",fld:"CBONCAN2",pic:"ZZZZZZ,ZZZ,ZZ9.99"},{av:"A493CBonBon2",fld:"CBONBON2",pic:"ZZZZZZ,ZZZ,ZZ9.99"},{av:"A499CBonCan3",fld:"CBONCAN3",pic:"ZZZZZZ,ZZZ,ZZ9.99"},{av:"A494CBonBon3",fld:"CBONBON3",pic:"ZZZZZZ,ZZZ,ZZ9.99"},{av:"A500CBonCan4",fld:"CBONCAN4",pic:"ZZZZZZ,ZZZ,ZZ9.99"},{av:"A495CBonBon4",fld:"CBONBON4",pic:"ZZZZZZ,ZZZ,ZZ9.99"},{av:"A501CBonCan5",fld:"CBONCAN5",pic:"ZZZZZZ,ZZZ,ZZ9.99"},{av:"A496CBonBon5",fld:"CBONBON5",pic:"ZZZZZZ,ZZZ,ZZ9.99"}],[]];this.EvtParms["AFTER TRN"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0}],[]];this.EvtParms["COMBO_CBONDPRODCOD.ONOPTIONCLICKED"]=[[{av:"this.COMBO_CBONDPRODCODContainer.SelectedValue_get",ctrl:"COMBO_CBONDPRODCOD",prop:"SelectedValue_get"}],[{av:"AV21ComboCBonDProdCod",fld:"vCOMBOCBONDPRODCOD",pic:"@!"}]];this.EvtParms["COMBO_CBONPRODCOD.ONOPTIONCLICKED"]=[[{av:"this.COMBO_CBONPRODCODContainer.SelectedValue_get",ctrl:"COMBO_CBONPRODCOD",prop:"SelectedValue_get"}],[{av:"AV18ComboCBonProdCod",fld:"vCOMBOCBONPRODCOD",pic:"@!"}]];this.EvtParms.VALID_CBONPRODCOD=[[{av:"A81CBonProdCod",fld:"CBONPRODCOD",pic:"@!"},{av:"A503CBonProdDsc",fld:"CBONPRODDSC",pic:""}],[{av:"A503CBonProdDsc",fld:"CBONPRODDSC",pic:""}]];this.EvtParms.VALID_CBONDPRODCOD=[[{av:"A82CBonDProdCod",fld:"CBONDPRODCOD",pic:"@!"},{av:"A502CBonDProdDsc",fld:"CBONDPRODDSC",pic:""}],[{av:"A502CBonDProdDsc",fld:"CBONDPRODDSC",pic:""}]];this.EvtParms.VALID_CBONCAN1=[[{av:"A497CBonCan1",fld:"CBONCAN1",pic:"ZZZZZZ,ZZZ,ZZ9.99"}],[{av:"A497CBonCan1",fld:"CBONCAN1",pic:"ZZZZZZ,ZZZ,ZZ9.99"}]];this.EvtParms.VALIDV_COMBOCBONPRODCOD=[[],[]];this.EvtParms.VALIDV_COMBOCBONDPRODCOD=[[],[]];this.EnterCtrl=["BTNTRN_ENTER"];this.setVCMap("AV7CBonProdCod","vCBONPRODCOD",0,"char",15,0);this.setVCMap("AV11Insert_CBonDProdCod","vINSERT_CBONDPRODCOD",0,"char",15,0);this.setVCMap("A498CBonCan2","CBONCAN2",0,"decimal",15,2);this.setVCMap("A493CBonBon2","CBONBON2",0,"decimal",15,2);this.setVCMap("A499CBonCan3","CBONCAN3",0,"decimal",15,2);this.setVCMap("A494CBonBon3","CBONBON3",0,"decimal",15,2);this.setVCMap("A500CBonCan4","CBONCAN4",0,"decimal",15,2);this.setVCMap("A495CBonBon4","CBONBON4",0,"decimal",15,2);this.setVCMap("A501CBonCan5","CBONCAN5",0,"decimal",15,2);this.setVCMap("A496CBonBon5","CBONBON5",0,"decimal",15,2);this.setVCMap("A503CBonProdDsc","CBONPRODDSC",0,"char",100,0);this.setVCMap("A502CBonDProdDsc","CBONDPRODDSC",0,"char",100,0);this.setVCMap("AV22Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV9TrnContext","vTRNCONTEXT",0,"WWPBaseObjectsWWPTransactionContext",0,0);this.Initialize();this.setSDTMapping("WWPBaseObjects\\DVB_SDTDropDownOptionsTitleSettingsIcons",{Default_fi:{extr:"def"},Filtered_fi:{extr:"fil"},SortedASC_fi:{extr:"asc"},SortedDSC_fi:{extr:"dsc"},FilteredSortedASC_fi:{extr:"fasc"},FilteredSortedDSC_fi:{extr:"fdsc"},OptionSortASC_fi:{extr:"osasc"},OptionSortDSC_fi:{extr:"osdsc"},OptionApplyFilter_fi:{extr:"app"},OptionFilteringData_fi:{extr:"fildata"},OptionCleanFilters_fi:{extr:"cle"},SelectedOption_fi:{extr:"selo"},MultiselOption_fi:{extr:"mul"},MultiselSelOption_fi:{extr:"muls"},TreeviewCollapse_fi:{extr:"tcol"},TreeviewExpand_fi:{extr:"texp"},FixLeft_fi:{extr:"fixl"},FixRight_fi:{extr:"fixr"}});this.setSDTMapping("WWPBaseObjects\\DVB_SDTComboData.Item",{Title:{extr:"T"},Children:{extr:"C"}});this.setSDTMapping("WWPBaseObjects\\WWPTransactionContext",{Attributes:{sdt:"WWPBaseObjects\\WWPTransactionContext.Attribute"}})});gx.wi(function(){gx.createParentObj(this.configuracion.bonificacion)})