gx.evt.autoSkip=!1;gx.define("generales.wwbusquedaproveedor",!1,function(){var i,r,u,t,n,f;this.ServerClass="generales.wwbusquedaproveedor";this.PackageName="GeneXus.Programs";this.ServerFullClass="generales.wwbusquedaproveedor.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV40Pgmname=gx.fn.getControlValue("vPGMNAME");this.AV13OrderedBy=gx.fn.getIntegerValue("vORDEREDBY",",");this.AV14OrderedDsc=gx.fn.getControlValue("vORDEREDDSC");this.AV30TFPrvCod=gx.fn.getControlValue("vTFPRVCOD");this.AV31TFPrvCod_Sel=gx.fn.getControlValue("vTFPRVCOD_SEL");this.AV32TFPrvDsc=gx.fn.getControlValue("vTFPRVDSC");this.AV33TFPrvDsc_Sel=gx.fn.getControlValue("vTFPRVDSC_SEL");this.AV34TFPrvDir=gx.fn.getControlValue("vTFPRVDIR");this.AV35TFPrvDir_Sel=gx.fn.getControlValue("vTFPRVDIR_SEL");this.AV37OutPrvCod=gx.fn.getControlValue("vOUTPRVCOD");this.AV36OutPrvDsc=gx.fn.getControlValue("vOUTPRVDSC");this.AV40Pgmname=gx.fn.getControlValue("vPGMNAME");this.AV13OrderedBy=gx.fn.getIntegerValue("vORDEREDBY",",");this.AV14OrderedDsc=gx.fn.getControlValue("vORDEREDDSC");this.AV30TFPrvCod=gx.fn.getControlValue("vTFPRVCOD");this.AV31TFPrvCod_Sel=gx.fn.getControlValue("vTFPRVCOD_SEL");this.AV32TFPrvDsc=gx.fn.getControlValue("vTFPRVDSC");this.AV33TFPrvDsc_Sel=gx.fn.getControlValue("vTFPRVDSC_SEL");this.AV34TFPrvDir=gx.fn.getControlValue("vTFPRVDIR");this.AV35TFPrvDir_Sel=gx.fn.getControlValue("vTFPRVDIR_SEL")};this.s132_client=function(){this.DDO_GRIDContainer.SortedStatus=gx.text.trim(gx.num.str(this.AV13OrderedBy,4,0))+":"+(this.AV14OrderedDsc?"DSC":"ASC")};this.e112q2_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEPAGE",!1,null,!0,!0)};this.e122q2_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!1,null,!0,!0)};this.e132q2_client=function(){return this.executeServerEvent("DDO_GRID.ONOPTIONCLICKED",!1,null,!0,!0)};this.e172q2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e182q2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];i=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,11,12,13,16,17,18,19,20,22,23,24,25,26,28,29,30,31,32,33,34,36,37,38];this.GXLastCtrlId=38;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",27,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"generales.wwbusquedaproveedor",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);r=this.GridContainer;r.addSingleLineEdit("Select",28,"vSELECT","","Seleccionar","Select","char",0,"px",20,20,"left","e172q2_client",[],"Select","Select",!0,0,!1,!1,"Attribute",1,"WWIconActionColumn");r.addSingleLineEdit(244,29,"PRVCOD","Codigo / R.U.C.","","PrvCod","char",0,"px",20,20,"left",null,[],244,"PrvCod",!0,0,!1,!1,"Attribute",1,"WWColumn");r.addSingleLineEdit(247,30,"PRVDSC","Codigo / R.U.C.","","PrvDsc","char",0,"px",100,80,"left",null,[],247,"PrvDsc",!0,0,!1,!1,"Attribute",1,"WWColumn");r.addSingleLineEdit(1763,31,"PRVDIR","Dirección","","PrvDir","char",0,"px",100,80,"left",null,[],1763,"PrvDir",!0,0,!1,!1,"Attribute",1,"WWColumn");r.addSingleLineEdit(1777,32,"PRVSTS","Situación","","PrvSts","int",0,"px",1,1,"right",null,[],1777,"PrvSts",!1,0,!1,!1,"Attribute",1,"WWColumn");this.GridContainer.emptyText="";this.setGrid(r);this.DVPANEL_TABLEHEADERContainer=gx.uc.getNew(this,9,0,"BootstrapPanel","DVPANEL_TABLEHEADERContainer","Dvpanel_tableheader","DVPANEL_TABLEHEADER");u=this.DVPANEL_TABLEHEADERContainer;u.setProp("Class","Class","","char");u.setProp("Enabled","Enabled",!0,"boolean");u.setProp("Width","Width","100%","str");u.setProp("Height","Height","100","str");u.setProp("AutoWidth","Autowidth",!1,"bool");u.setProp("AutoHeight","Autoheight",!0,"bool");u.setProp("Cls","Cls","PanelNoHeader","str");u.setProp("ShowHeader","Showheader",!0,"bool");u.setProp("Title","Title","Opciones","str");u.setProp("Collapsible","Collapsible",!0,"bool");u.setProp("Collapsed","Collapsed",!1,"bool");u.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");u.setProp("IconPosition","Iconposition","Right","str");u.setProp("AutoScroll","Autoscroll",!1,"bool");u.setProp("Visible","Visible",!0,"bool");u.setProp("Gx Control Type","Gxcontroltype","","int");u.setC2ShowFunction(function(n){n.show()});this.setUserControl(u);this.GRIDPAGINATIONBARContainer=gx.uc.getNew(this,35,18,"DVelop_DVPaginationBar","GRIDPAGINATIONBARContainer","Gridpaginationbar","GRIDPAGINATIONBAR");t=this.GRIDPAGINATIONBARContainer;t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Class","Class","PaginationBar","str");t.setProp("ShowFirst","Showfirst",!1,"bool");t.setProp("ShowPrevious","Showprevious",!0,"bool");t.setProp("ShowNext","Shownext",!0,"bool");t.setProp("ShowLast","Showlast",!1,"bool");t.setProp("PagesToShow","Pagestoshow",5,"num");t.setProp("PagingButtonsPosition","Pagingbuttonsposition","Right","str");t.setProp("PagingCaptionPosition","Pagingcaptionposition","Left","str");t.setProp("EmptyGridClass","Emptygridclass","PaginationBarEmptyGrid","str");t.setProp("SelectedPage","Selectedpage","","char");t.setProp("RowsPerPageSelector","Rowsperpageselector",!0,"bool");t.setDynProp("RowsPerPageSelectedValue","Rowsperpageselectedvalue",10,"num");t.setProp("RowsPerPageOptions","Rowsperpageoptions","5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50","str");t.setProp("First","First","First","str");t.setProp("Previous","Previous","WWP_PagingPreviousCaption","str");t.setProp("Next","Next","WWP_PagingNextCaption","str");t.setProp("Last","Last","Last","str");t.setProp("Caption","Caption","Página <CURRENT_PAGE> de <TOTAL_PAGES>","str");t.setProp("EmptyGridCaption","Emptygridcaption","WWP_PagingEmptyGridCaption","str");t.setProp("RowsPerPageCaption","Rowsperpagecaption","WWP_PagingRowsPerPage","str");t.addV2CFunction("AV8GridCurrentPage","vGRIDCURRENTPAGE","SetCurrentPage");t.addC2VFunction(function(n){n.ParentObject.AV8GridCurrentPage=n.GetCurrentPage();gx.fn.setControlValue("vGRIDCURRENTPAGE",n.ParentObject.AV8GridCurrentPage)});t.addV2CFunction("AV9GridPageCount","vGRIDPAGECOUNT","SetPageCount");t.addC2VFunction(function(n){n.ParentObject.AV9GridPageCount=n.GetPageCount();gx.fn.setControlValue("vGRIDPAGECOUNT",n.ParentObject.AV9GridPageCount)});t.setProp("RecordCount","Recordcount","","str");t.setProp("Page","Page","","str");t.addV2CFunction("AV7GridAppliedFilters","vGRIDAPPLIEDFILTERS","SetAppliedFilters");t.addC2VFunction(function(n){n.ParentObject.AV7GridAppliedFilters=n.GetAppliedFilters();gx.fn.setControlValue("vGRIDAPPLIEDFILTERS",n.ParentObject.AV7GridAppliedFilters)});t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("ChangePage",this.e112q2_client);t.addEventHandler("ChangeRowsPerPage",this.e122q2_client);this.setUserControl(t);this.DDO_GRIDContainer=gx.uc.getNew(this,39,18,"DDOGridTitleSettingsM","DDO_GRIDContainer","Ddo_grid","DDO_GRID");n=this.DDO_GRIDContainer;n.setProp("Class","Class","","char");n.setProp("Enabled","Enabled",!0,"boolean");n.setProp("IconType","Icontype","Image","str");n.setProp("Icon","Icon","","str");n.setProp("Caption","Caption","","str");n.setProp("Tooltip","Tooltip","","str");n.setProp("Cls","Cls","","str");n.setProp("ActiveEventKey","Activeeventkey","","char");n.setDynProp("FilteredText_set","Filteredtext_set","","char");n.setProp("FilteredText_get","Filteredtext_get","","char");n.setProp("FilteredTextTo_set","Filteredtextto_set","","char");n.setProp("FilteredTextTo_get","Filteredtextto_get","","char");n.setDynProp("SelectedValue_set","Selectedvalue_set","","char");n.setProp("SelectedValue_get","Selectedvalue_get","","char");n.setProp("SelectedText_set","Selectedtext_set","","char");n.setProp("SelectedText_get","Selectedtext_get","","char");n.setProp("SelectedColumn","Selectedcolumn","","char");n.setProp("SelectedColumnFixedFilter","Selectedcolumnfixedfilter","","char");n.setProp("GAMOAuthToken","Gamoauthtoken","","char");n.setProp("TitleControlAlign","Titlecontrolalign","","str");n.setProp("Visible","Visible","","str");n.setDynProp("GridInternalName","Gridinternalname","","str");n.setProp("ColumnIds","Columnids","1:PrvCod|2:PrvDsc|3:PrvDir","str");n.setProp("ColumnsSortValues","Columnssortvalues","2|1|3","str");n.setProp("IncludeSortASC","Includesortasc","T","str");n.setProp("IncludeSortDSC","Includesortdsc","","str");n.setProp("AllowGroup","Allowgroup","","str");n.setProp("Fixable","Fixable","","str");n.setDynProp("SortedStatus","Sortedstatus","","char");n.setProp("IncludeFilter","Includefilter","T","str");n.setProp("FilterType","Filtertype","Character|Character|Character","str");n.setProp("FilterIsRange","Filterisrange","","str");n.setProp("IncludeDataList","Includedatalist","T","str");n.setProp("DataListType","Datalisttype","Dynamic|Dynamic|Dynamic","str");n.setProp("AllowMultipleSelection","Allowmultipleselection","","str");n.setProp("DataListFixedValues","Datalistfixedvalues","","str");n.setProp("DataListProc","Datalistproc","Generales.WWBusquedaProveedorGetFilterData","str");n.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");n.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");n.setProp("FixedFilters","Fixedfilters","","str");n.setProp("SelectedFixedFilter","Selectedfixedfilter","","char");n.setProp("SortASC","Sortasc","","str");n.setProp("SortDSC","Sortdsc","","str");n.setProp("AllowGroupText","Allowgrouptext","","str");n.setProp("LoadingData","Loadingdata","","str");n.setProp("CleanFilter","Cleanfilter","","str");n.setProp("RangeFilterFrom","Rangefilterfrom","","str");n.setProp("RangeFilterTo","Rangefilterto","","str");n.setProp("NoResultsFound","Noresultsfound","","str");n.setProp("SearchButtonText","Searchbuttontext","","str");n.addV2CFunction("AV5DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");n.addC2VFunction(function(n){n.ParentObject.AV5DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV5DDO_TitleSettingsIcons)});n.setC2ShowFunction(function(n){n.show()});n.addEventHandler("OnOptionClicked",this.e132q2_client);this.setUserControl(n);this.GRID_EMPOWERERContainer=gx.uc.getNew(this,40,18,"WWP_GridEmpowerer","GRID_EMPOWERERContainer","Grid_empowerer","GRID_EMPOWERER");f=this.GRID_EMPOWERERContainer;f.setProp("Class","Class","","char");f.setProp("Enabled","Enabled",!0,"boolean");f.setDynProp("GridInternalName","Gridinternalname","","char");f.setProp("HasCategories","Hascategories",!1,"bool");f.setProp("InfiniteScrolling","Infinitescrolling","False","str");f.setProp("HasTitleSettings","Hastitlesettings",!0,"bool");f.setProp("HasColumnsSelector","Hascolumnsselector",!1,"bool");f.setProp("HasRowGroups","Hasrowgroups",!1,"bool");f.setProp("FixedColumns","Fixedcolumns","","str");f.setProp("PopoversInGrid","Popoversingrid","","str");f.setProp("Visible","Visible",!0,"bool");f.setC2ShowFunction(function(n){n.show()});this.setUserControl(f);i[2]={id:2,fld:"",grid:0};i[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};i[4]={id:4,fld:"",grid:0};i[5]={id:5,fld:"",grid:0};i[6]={id:6,fld:"TABLEMAIN",grid:0};i[7]={id:7,fld:"",grid:0};i[8]={id:8,fld:"",grid:0};i[11]={id:11,fld:"TABLEHEADER",grid:0};i[12]={id:12,fld:"",grid:0};i[13]={id:13,fld:"TABLEFILTERS",grid:0};i[16]={id:16,fld:"",grid:0};i[17]={id:17,fld:"",grid:0};i[18]={id:18,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.GridContainer],fld:"vFILTERFULLTEXT",gxz:"ZV6FilterFullText",gxold:"OV6FilterFullText",gxvar:"AV6FilterFullText",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6FilterFullText=n)},v2z:function(n){n!==undefined&&(gx.O.ZV6FilterFullText=n)},v2c:function(){gx.fn.setControlValue("vFILTERFULLTEXT",gx.O.AV6FilterFullText,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV6FilterFullText=this.val())},val:function(){return gx.fn.getControlValue("vFILTERFULLTEXT")},nac:gx.falseFn};this.declareDomainHdlr(18,function(){});i[19]={id:19,fld:"",grid:0};i[20]={id:20,fld:"",grid:0};i[22]={id:22,fld:"",grid:0};i[23]={id:23,fld:"",grid:0};i[24]={id:24,fld:"GRIDTABLEWITHPAGINATIONBAR",grid:0};i[25]={id:25,fld:"",grid:0};i[26]={id:26,fld:"",grid:0};i[28]={id:28,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSELECT",gxz:"ZV18Select",gxold:"OV18Select",gxvar:"AV18Select",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV18Select=n)},v2z:function(n){n!==undefined&&(gx.O.ZV18Select=n)},v2c:function(n){gx.fn.setGridControlValue("vSELECT",n||gx.fn.currentGridRowImpl(27),gx.O.AV18Select,1)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV18Select=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vSELECT",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn,evt:"e172q2_client",std:"ENTER"};i[29]={id:29,lvl:2,type:"char",len:20,dec:0,sign:!1,pic:"@!",ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRVCOD",gxz:"Z244PrvCod",gxold:"O244PrvCod",gxvar:"A244PrvCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A244PrvCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z244PrvCod=n)},v2c:function(n){gx.fn.setGridControlValue("PRVCOD",n||gx.fn.currentGridRowImpl(27),gx.O.A244PrvCod,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A244PrvCod=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PRVCOD",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};i[30]={id:30,lvl:2,type:"char",len:100,dec:0,sign:!1,ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRVDSC",gxz:"Z247PrvDsc",gxold:"O247PrvDsc",gxvar:"A247PrvDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A247PrvDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z247PrvDsc=n)},v2c:function(n){gx.fn.setGridControlValue("PRVDSC",n||gx.fn.currentGridRowImpl(27),gx.O.A247PrvDsc,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A247PrvDsc=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PRVDSC",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};i[31]={id:31,lvl:2,type:"char",len:100,dec:0,sign:!1,ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRVDIR",gxz:"Z1763PrvDir",gxold:"O1763PrvDir",gxvar:"A1763PrvDir",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A1763PrvDir=n)},v2z:function(n){n!==undefined&&(gx.O.Z1763PrvDir=n)},v2c:function(n){gx.fn.setGridControlValue("PRVDIR",n||gx.fn.currentGridRowImpl(27),gx.O.A1763PrvDir,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A1763PrvDir=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PRVDIR",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};i[32]={id:32,lvl:2,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRVSTS",gxz:"Z1777PrvSts",gxold:"O1777PrvSts",gxvar:"A1777PrvSts",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A1777PrvSts=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1777PrvSts=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PRVSTS",n||gx.fn.currentGridRowImpl(27),gx.O.A1777PrvSts,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A1777PrvSts=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PRVSTS",n||gx.fn.currentGridRowImpl(27),",")},nac:gx.falseFn};i[33]={id:33,fld:"",grid:0};i[34]={id:34,fld:"",grid:0};i[36]={id:36,fld:"",grid:0};i[37]={id:37,fld:"",grid:0};i[38]={id:38,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};this.AV6FilterFullText="";this.ZV6FilterFullText="";this.OV6FilterFullText="";this.ZV18Select="";this.OV18Select="";this.Z244PrvCod="";this.O244PrvCod="";this.Z247PrvDsc="";this.O247PrvDsc="";this.Z1763PrvDir="";this.O1763PrvDir="";this.Z1777PrvSts=0;this.O1777PrvSts=0;this.AV6FilterFullText="";this.AV8GridCurrentPage=0;this.AV5DDO_TitleSettingsIcons={Default_fi:"",Filtered_fi:"",SortedASC_fi:"",SortedDSC_fi:"",FilteredSortedASC_fi:"",FilteredSortedDSC_fi:"",OptionSortASC_fi:"",OptionSortDSC_fi:"",OptionApplyFilter_fi:"",OptionFilteringData_fi:"",OptionCleanFilters_fi:"",SelectedOption_fi:"",MultiselOption_fi:"",MultiselSelOption_fi:"",TreeviewCollapse_fi:"",TreeviewExpand_fi:"",FixLeft_fi:"",FixRight_fi:""};this.AV37OutPrvCod="";this.AV36OutPrvDsc="";this.AV18Select="";this.A244PrvCod="";this.A247PrvDsc="";this.A1763PrvDir="";this.A1777PrvSts=0;this.AV40Pgmname="";this.AV13OrderedBy=0;this.AV14OrderedDsc=!1;this.AV30TFPrvCod="";this.AV31TFPrvCod_Sel="";this.AV32TFPrvDsc="";this.AV33TFPrvDsc_Sel="";this.AV34TFPrvDir="";this.AV35TFPrvDir_Sel="";this.Events={e112q2_client:["GRIDPAGINATIONBAR.CHANGEPAGE",!0],e122q2_client:["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!0],e132q2_client:["DDO_GRID.ONOPTIONCLICKED",!0],e172q2_client:["ENTER",!0],e182q2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV40Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV13OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV14OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV30TFPrvCod",fld:"vTFPRVCOD",pic:"@!"},{av:"AV31TFPrvCod_Sel",fld:"vTFPRVCOD_SEL",pic:"@!"},{av:"AV32TFPrvDsc",fld:"vTFPRVDSC",pic:""},{av:"AV33TFPrvDsc_Sel",fld:"vTFPRVDSC_SEL",pic:""},{av:"AV34TFPrvDir",fld:"vTFPRVDIR",pic:""},{av:"AV35TFPrvDir_Sel",fld:"vTFPRVDIR_SEL",pic:""}],[{av:"AV8GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV9GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV7GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""}]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV40Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV13OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV14OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV30TFPrvCod",fld:"vTFPRVCOD",pic:"@!"},{av:"AV31TFPrvCod_Sel",fld:"vTFPRVCOD_SEL",pic:"@!"},{av:"AV32TFPrvDsc",fld:"vTFPRVDSC",pic:""},{av:"AV33TFPrvDsc_Sel",fld:"vTFPRVDSC_SEL",pic:""},{av:"AV34TFPrvDir",fld:"vTFPRVDIR",pic:""},{av:"AV35TFPrvDir_Sel",fld:"vTFPRVDIR_SEL",pic:""},{av:"this.GRIDPAGINATIONBARContainer.SelectedPage",ctrl:"GRIDPAGINATIONBAR",prop:"SelectedPage"}],[]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV40Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV13OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV14OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV30TFPrvCod",fld:"vTFPRVCOD",pic:"@!"},{av:"AV31TFPrvCod_Sel",fld:"vTFPRVCOD_SEL",pic:"@!"},{av:"AV32TFPrvDsc",fld:"vTFPRVDSC",pic:""},{av:"AV33TFPrvDsc_Sel",fld:"vTFPRVDSC_SEL",pic:""},{av:"AV34TFPrvDir",fld:"vTFPRVDIR",pic:""},{av:"AV35TFPrvDir_Sel",fld:"vTFPRVDIR_SEL",pic:""},{av:"this.GRIDPAGINATIONBARContainer.RowsPerPageSelectedValue",ctrl:"GRIDPAGINATIONBAR",prop:"RowsPerPageSelectedValue"}],[{ctrl:"GRID",prop:"Rows"}]];this.EvtParms["DDO_GRID.ONOPTIONCLICKED"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV40Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV13OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV14OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV30TFPrvCod",fld:"vTFPRVCOD",pic:"@!"},{av:"AV31TFPrvCod_Sel",fld:"vTFPRVCOD_SEL",pic:"@!"},{av:"AV32TFPrvDsc",fld:"vTFPRVDSC",pic:""},{av:"AV33TFPrvDsc_Sel",fld:"vTFPRVDSC_SEL",pic:""},{av:"AV34TFPrvDir",fld:"vTFPRVDIR",pic:""},{av:"AV35TFPrvDir_Sel",fld:"vTFPRVDIR_SEL",pic:""},{av:"this.DDO_GRIDContainer.ActiveEventKey",ctrl:"DDO_GRID",prop:"ActiveEventKey"},{av:"this.DDO_GRIDContainer.SelectedValue_get",ctrl:"DDO_GRID",prop:"SelectedValue_get"},{av:"this.DDO_GRIDContainer.SelectedColumn",ctrl:"DDO_GRID",prop:"SelectedColumn"},{av:"this.DDO_GRIDContainer.FilteredText_get",ctrl:"DDO_GRID",prop:"FilteredText_get"}],[{av:"AV13OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV14OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV30TFPrvCod",fld:"vTFPRVCOD",pic:"@!"},{av:"AV31TFPrvCod_Sel",fld:"vTFPRVCOD_SEL",pic:"@!"},{av:"AV32TFPrvDsc",fld:"vTFPRVDSC",pic:""},{av:"AV33TFPrvDsc_Sel",fld:"vTFPRVDSC_SEL",pic:""},{av:"AV34TFPrvDir",fld:"vTFPRVDIR",pic:""},{av:"AV35TFPrvDir_Sel",fld:"vTFPRVDIR_SEL",pic:""},{av:"this.DDO_GRIDContainer.SortedStatus",ctrl:"DDO_GRID",prop:"SortedStatus"}]];this.EvtParms["GRID.LOAD"]=[[],[{av:"AV18Select",fld:"vSELECT",pic:""}]];this.EvtParms.ENTER=[[{av:"A244PrvCod",fld:"PRVCOD",pic:"@!",hsh:!0},{av:"A247PrvDsc",fld:"PRVDSC",pic:"",hsh:!0}],[{av:"AV37OutPrvCod",fld:"vOUTPRVCOD",pic:"@!"},{av:"AV36OutPrvDsc",fld:"vOUTPRVDSC",pic:""}]];this.EnterCtrl=["vSELECT"];this.setVCMap("AV40Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV13OrderedBy","vORDEREDBY",0,"int",4,0);this.setVCMap("AV14OrderedDsc","vORDEREDDSC",0,"boolean",4,0);this.setVCMap("AV30TFPrvCod","vTFPRVCOD",0,"char",20,0);this.setVCMap("AV31TFPrvCod_Sel","vTFPRVCOD_SEL",0,"char",20,0);this.setVCMap("AV32TFPrvDsc","vTFPRVDSC",0,"char",100,0);this.setVCMap("AV33TFPrvDsc_Sel","vTFPRVDSC_SEL",0,"char",100,0);this.setVCMap("AV34TFPrvDir","vTFPRVDIR",0,"char",100,0);this.setVCMap("AV35TFPrvDir_Sel","vTFPRVDIR_SEL",0,"char",100,0);this.setVCMap("AV37OutPrvCod","vOUTPRVCOD",0,"char",20,0);this.setVCMap("AV36OutPrvDsc","vOUTPRVDSC",0,"char",100,0);this.setVCMap("AV40Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV13OrderedBy","vORDEREDBY",0,"int",4,0);this.setVCMap("AV14OrderedDsc","vORDEREDDSC",0,"boolean",4,0);this.setVCMap("AV30TFPrvCod","vTFPRVCOD",0,"char",20,0);this.setVCMap("AV31TFPrvCod_Sel","vTFPRVCOD_SEL",0,"char",20,0);this.setVCMap("AV32TFPrvDsc","vTFPRVDSC",0,"char",100,0);this.setVCMap("AV33TFPrvDsc_Sel","vTFPRVDSC_SEL",0,"char",100,0);this.setVCMap("AV34TFPrvDir","vTFPRVDIR",0,"char",100,0);this.setVCMap("AV35TFPrvDir_Sel","vTFPRVDIR_SEL",0,"char",100,0);this.setVCMap("AV40Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV13OrderedBy","vORDEREDBY",0,"int",4,0);this.setVCMap("AV14OrderedDsc","vORDEREDDSC",0,"boolean",4,0);this.setVCMap("AV30TFPrvCod","vTFPRVCOD",0,"char",20,0);this.setVCMap("AV31TFPrvCod_Sel","vTFPRVCOD_SEL",0,"char",20,0);this.setVCMap("AV32TFPrvDsc","vTFPRVDSC",0,"char",100,0);this.setVCMap("AV33TFPrvDsc_Sel","vTFPRVDSC_SEL",0,"char",100,0);this.setVCMap("AV34TFPrvDir","vTFPRVDIR",0,"char",100,0);this.setVCMap("AV35TFPrvDir_Sel","vTFPRVDIR_SEL",0,"char",100,0);r.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});r.addRefreshingVar(this.GXValidFnc[18]);r.addRefreshingVar({rfrVar:"AV40Pgmname"});r.addRefreshingVar({rfrVar:"AV13OrderedBy"});r.addRefreshingVar({rfrVar:"AV14OrderedDsc"});r.addRefreshingVar({rfrVar:"AV30TFPrvCod"});r.addRefreshingVar({rfrVar:"AV31TFPrvCod_Sel"});r.addRefreshingVar({rfrVar:"AV32TFPrvDsc"});r.addRefreshingVar({rfrVar:"AV33TFPrvDsc_Sel"});r.addRefreshingVar({rfrVar:"AV34TFPrvDir"});r.addRefreshingVar({rfrVar:"AV35TFPrvDir_Sel"});r.addRefreshingParm(this.GXValidFnc[18]);r.addRefreshingParm({rfrVar:"AV40Pgmname"});r.addRefreshingParm({rfrVar:"AV13OrderedBy"});r.addRefreshingParm({rfrVar:"AV14OrderedDsc"});r.addRefreshingParm({rfrVar:"AV30TFPrvCod"});r.addRefreshingParm({rfrVar:"AV31TFPrvCod_Sel"});r.addRefreshingParm({rfrVar:"AV32TFPrvDsc"});r.addRefreshingParm({rfrVar:"AV33TFPrvDsc_Sel"});r.addRefreshingParm({rfrVar:"AV34TFPrvDir"});r.addRefreshingParm({rfrVar:"AV35TFPrvDir_Sel"});this.Initialize();this.setSDTMapping("WWPBaseObjects\\WWPGridState",{FilterValues:{sdt:"WWPBaseObjects\\WWPGridState.FilterValue"},DynamicFilters:{sdt:"WWPBaseObjects\\WWPGridState.DynamicFilter"}});this.setSDTMapping("WWPBaseObjects\\WWPGridState.DynamicFilter",{Dsc:{extr:"d"}});this.setSDTMapping("WWPBaseObjects\\WWPTransactionContext",{Attributes:{sdt:"WWPBaseObjects\\WWPTransactionContext.Attribute"}});this.setSDTMapping("WWPBaseObjects\\DVB_SDTDropDownOptionsTitleSettingsIcons",{Default_fi:{extr:"def"},Filtered_fi:{extr:"fil"},SortedASC_fi:{extr:"asc"},SortedDSC_fi:{extr:"dsc"},FilteredSortedASC_fi:{extr:"fasc"},FilteredSortedDSC_fi:{extr:"fdsc"},OptionSortASC_fi:{extr:"osasc"},OptionSortDSC_fi:{extr:"osdsc"},OptionApplyFilter_fi:{extr:"app"},OptionFilteringData_fi:{extr:"fildata"},OptionCleanFilters_fi:{extr:"cle"},SelectedOption_fi:{extr:"selo"},MultiselOption_fi:{extr:"mul"},MultiselSelOption_fi:{extr:"muls"},TreeviewCollapse_fi:{extr:"tcol"},TreeviewExpand_fi:{extr:"texp"},FixLeft_fi:{extr:"fixl"},FixRight_fi:{extr:"fixr"}})});gx.wi(function(){gx.createParentObj(this.generales.wwbusquedaproveedor)})