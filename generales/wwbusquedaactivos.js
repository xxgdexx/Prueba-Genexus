gx.evt.autoSkip=!1;gx.define("generales.wwbusquedaactivos",!1,function(){var i,f,r,t,n,u;this.ServerClass="generales.wwbusquedaactivos";this.PackageName="GeneXus.Programs";this.ServerFullClass="generales.wwbusquedaactivos.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV22Pgmname=gx.fn.getControlValue("vPGMNAME");this.AV10OrderedBy=gx.fn.getIntegerValue("vORDEREDBY",",");this.AV11OrderedDsc=gx.fn.getControlValue("vORDEREDDSC");this.AV7InOutACTActCod=gx.fn.getControlValue("vINOUTACTACTCOD");this.AV18InOutActActDsc=gx.fn.getControlValue("vINOUTACTACTDSC");this.AV22Pgmname=gx.fn.getControlValue("vPGMNAME")};this.s112_client=function(){this.DDO_GRIDContainer.SortedStatus=gx.text.trim(gx.num.str(this.AV10OrderedBy,4,0))+":"+(this.AV11OrderedDsc?"DSC":"ASC")};this.e116p2_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEPAGE",!1,null,!0,!0)};this.e126p2_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!1,null,!0,!0)};this.e136p2_client=function(){return this.executeServerEvent("DDO_GRID.ONOPTIONCLICKED",!1,null,!0,!0)};this.e176p2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e186p2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];i=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,11,12,13,16,17,18,19,20,21,22,23,25,26,27,28,29,30,31,33,34,35];this.GXLastCtrlId=35;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",24,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"generales.wwbusquedaactivos",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);f=this.GridContainer;f.addSingleLineEdit("Select",25,"vSELECT","","Seleccionar","Select","char",0,"px",20,20,"left","e176p2_client",[],"Select","Select",!0,0,!1,!1,"Attribute",1,"WWIconActionColumn");f.addSingleLineEdit(2100,26,"ACTACTCOD","Codigo Activo","","ACTActCod","svchar",0,"px",20,20,"left",null,[],2100,"ACTActCod",!0,0,!1,!1,"Attribute",1,"WWColumn hidden-xs");f.addSingleLineEdit(2118,27,"ACTACTCODEQV","Codigo Equipo","","ACTActCodEQV","svchar",0,"px",20,20,"left",null,[],2118,"ACTActCodEQV",!0,0,!1,!1,"Attribute",1,"WWColumn");f.addSingleLineEdit(2122,28,"ACTACTDSC","Descripción Activo","","ACTActDsc","svchar",0,"px",100,80,"left",null,[],2122,"ACTActDsc",!0,0,!1,!1,"Attribute",1,"WWColumn hidden-xs");f.addSingleLineEdit(2136,29,"ACTACTSTS","Estado Actual","","ACTActSts","svchar",0,"px",1,1,"left",null,[],2136,"ACTActSts",!1,0,!1,!1,"Attribute",1,"WWColumn hidden-xs");this.GridContainer.emptyText="";this.setGrid(f);this.DVPANEL_TABLEHEADERContainer=gx.uc.getNew(this,9,0,"BootstrapPanel","DVPANEL_TABLEHEADERContainer","Dvpanel_tableheader","DVPANEL_TABLEHEADER");r=this.DVPANEL_TABLEHEADERContainer;r.setProp("Class","Class","","char");r.setProp("Enabled","Enabled",!0,"boolean");r.setProp("Width","Width","100%","str");r.setProp("Height","Height","100","str");r.setProp("AutoWidth","Autowidth",!1,"bool");r.setProp("AutoHeight","Autoheight",!0,"bool");r.setProp("Cls","Cls","PanelNoHeader","str");r.setProp("ShowHeader","Showheader",!0,"bool");r.setProp("Title","Title","Opciones","str");r.setProp("Collapsible","Collapsible",!0,"bool");r.setProp("Collapsed","Collapsed",!1,"bool");r.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");r.setProp("IconPosition","Iconposition","Right","str");r.setProp("AutoScroll","Autoscroll",!1,"bool");r.setProp("Visible","Visible",!0,"bool");r.setProp("Gx Control Type","Gxcontroltype","","int");r.setC2ShowFunction(function(n){n.show()});this.setUserControl(r);this.GRIDPAGINATIONBARContainer=gx.uc.getNew(this,32,18,"DVelop_DVPaginationBar","GRIDPAGINATIONBARContainer","Gridpaginationbar","GRIDPAGINATIONBAR");t=this.GRIDPAGINATIONBARContainer;t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Class","Class","PaginationBar","str");t.setProp("ShowFirst","Showfirst",!1,"bool");t.setProp("ShowPrevious","Showprevious",!0,"bool");t.setProp("ShowNext","Shownext",!0,"bool");t.setProp("ShowLast","Showlast",!1,"bool");t.setProp("PagesToShow","Pagestoshow",5,"num");t.setProp("PagingButtonsPosition","Pagingbuttonsposition","Right","str");t.setProp("PagingCaptionPosition","Pagingcaptionposition","Left","str");t.setProp("EmptyGridClass","Emptygridclass","PaginationBarEmptyGrid","str");t.setProp("SelectedPage","Selectedpage","","char");t.setProp("RowsPerPageSelector","Rowsperpageselector",!0,"bool");t.setDynProp("RowsPerPageSelectedValue","Rowsperpageselectedvalue",10,"num");t.setProp("RowsPerPageOptions","Rowsperpageoptions","5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50","str");t.setProp("First","First","First","str");t.setProp("Previous","Previous","WWP_PagingPreviousCaption","str");t.setProp("Next","Next","WWP_PagingNextCaption","str");t.setProp("Last","Last","Last","str");t.setProp("Caption","Caption","Página <CURRENT_PAGE> de <TOTAL_PAGES>","str");t.setProp("EmptyGridCaption","Emptygridcaption","WWP_PagingEmptyGridCaption","str");t.setProp("RowsPerPageCaption","Rowsperpagecaption","WWP_PagingRowsPerPage","str");t.addV2CFunction("AV14GridCurrentPage","vGRIDCURRENTPAGE","SetCurrentPage");t.addC2VFunction(function(n){n.ParentObject.AV14GridCurrentPage=n.GetCurrentPage();gx.fn.setControlValue("vGRIDCURRENTPAGE",n.ParentObject.AV14GridCurrentPage)});t.addV2CFunction("AV15GridPageCount","vGRIDPAGECOUNT","SetPageCount");t.addC2VFunction(function(n){n.ParentObject.AV15GridPageCount=n.GetPageCount();gx.fn.setControlValue("vGRIDPAGECOUNT",n.ParentObject.AV15GridPageCount)});t.setProp("RecordCount","Recordcount","","str");t.setProp("Page","Page","","str");t.addV2CFunction("AV16GridAppliedFilters","vGRIDAPPLIEDFILTERS","SetAppliedFilters");t.addC2VFunction(function(n){n.ParentObject.AV16GridAppliedFilters=n.GetAppliedFilters();gx.fn.setControlValue("vGRIDAPPLIEDFILTERS",n.ParentObject.AV16GridAppliedFilters)});t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("ChangePage",this.e116p2_client);t.addEventHandler("ChangeRowsPerPage",this.e126p2_client);this.setUserControl(t);this.DDO_GRIDContainer=gx.uc.getNew(this,36,18,"DDOGridTitleSettingsM","DDO_GRIDContainer","Ddo_grid","DDO_GRID");n=this.DDO_GRIDContainer;n.setProp("Class","Class","","char");n.setProp("Enabled","Enabled",!0,"boolean");n.setProp("IconType","Icontype","Image","str");n.setProp("Icon","Icon","","str");n.setProp("Caption","Caption","","str");n.setProp("Tooltip","Tooltip","","str");n.setProp("Cls","Cls","","str");n.setProp("ActiveEventKey","Activeeventkey","","char");n.setProp("FilteredText_set","Filteredtext_set","","char");n.setProp("FilteredText_get","Filteredtext_get","","char");n.setProp("FilteredTextTo_set","Filteredtextto_set","","char");n.setProp("FilteredTextTo_get","Filteredtextto_get","","char");n.setProp("SelectedValue_set","Selectedvalue_set","","char");n.setProp("SelectedValue_get","Selectedvalue_get","","char");n.setProp("SelectedText_set","Selectedtext_set","","char");n.setProp("SelectedText_get","Selectedtext_get","","char");n.setProp("SelectedColumn","Selectedcolumn","","char");n.setProp("SelectedColumnFixedFilter","Selectedcolumnfixedfilter","","char");n.setProp("GAMOAuthToken","Gamoauthtoken","","char");n.setProp("TitleControlAlign","Titlecontrolalign","","str");n.setProp("Visible","Visible","","str");n.setDynProp("GridInternalName","Gridinternalname","","str");n.setProp("ColumnIds","Columnids","1:ACTActCod|2:ACTActCodEQV|3:ACTActDsc","str");n.setProp("ColumnsSortValues","Columnssortvalues","1|2|3","str");n.setProp("IncludeSortASC","Includesortasc","T","str");n.setProp("IncludeSortDSC","Includesortdsc","","str");n.setProp("AllowGroup","Allowgroup","","str");n.setProp("Fixable","Fixable","","str");n.setDynProp("SortedStatus","Sortedstatus","","char");n.setProp("IncludeFilter","Includefilter","","str");n.setProp("FilterType","Filtertype","","str");n.setProp("FilterIsRange","Filterisrange","","str");n.setProp("IncludeDataList","Includedatalist","","str");n.setProp("DataListType","Datalisttype","","str");n.setProp("AllowMultipleSelection","Allowmultipleselection","","str");n.setProp("DataListFixedValues","Datalistfixedvalues","","str");n.setProp("DataListProc","Datalistproc","","str");n.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");n.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");n.setProp("FixedFilters","Fixedfilters","","str");n.setProp("SelectedFixedFilter","Selectedfixedfilter","","char");n.setProp("SortASC","Sortasc","","str");n.setProp("SortDSC","Sortdsc","","str");n.setProp("AllowGroupText","Allowgrouptext","","str");n.setProp("LoadingData","Loadingdata","","str");n.setProp("CleanFilter","Cleanfilter","","str");n.setProp("RangeFilterFrom","Rangefilterfrom","","str");n.setProp("RangeFilterTo","Rangefilterto","","str");n.setProp("NoResultsFound","Noresultsfound","","str");n.setProp("SearchButtonText","Searchbuttontext","","str");n.addV2CFunction("AV12DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");n.addC2VFunction(function(n){n.ParentObject.AV12DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV12DDO_TitleSettingsIcons)});n.setC2ShowFunction(function(n){n.show()});n.addEventHandler("OnOptionClicked",this.e136p2_client);this.setUserControl(n);this.GRID_EMPOWERERContainer=gx.uc.getNew(this,37,18,"WWP_GridEmpowerer","GRID_EMPOWERERContainer","Grid_empowerer","GRID_EMPOWERER");u=this.GRID_EMPOWERERContainer;u.setProp("Class","Class","","char");u.setProp("Enabled","Enabled",!0,"boolean");u.setDynProp("GridInternalName","Gridinternalname","","char");u.setProp("HasCategories","Hascategories",!1,"bool");u.setProp("InfiniteScrolling","Infinitescrolling","False","str");u.setProp("HasTitleSettings","Hastitlesettings",!0,"bool");u.setProp("HasColumnsSelector","Hascolumnsselector",!1,"bool");u.setProp("HasRowGroups","Hasrowgroups",!1,"bool");u.setProp("FixedColumns","Fixedcolumns","","str");u.setProp("PopoversInGrid","Popoversingrid","","str");u.setProp("Visible","Visible",!0,"bool");u.setC2ShowFunction(function(n){n.show()});this.setUserControl(u);i[2]={id:2,fld:"",grid:0};i[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};i[4]={id:4,fld:"",grid:0};i[5]={id:5,fld:"",grid:0};i[6]={id:6,fld:"TABLEMAIN",grid:0};i[7]={id:7,fld:"",grid:0};i[8]={id:8,fld:"",grid:0};i[11]={id:11,fld:"TABLEHEADER",grid:0};i[12]={id:12,fld:"",grid:0};i[13]={id:13,fld:"TABLEFILTERS",grid:0};i[16]={id:16,fld:"",grid:0};i[17]={id:17,fld:"",grid:0};i[18]={id:18,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.GridContainer],fld:"vFILTERFULLTEXT",gxz:"ZV19FilterFullText",gxold:"OV19FilterFullText",gxvar:"AV19FilterFullText",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV19FilterFullText=n)},v2z:function(n){n!==undefined&&(gx.O.ZV19FilterFullText=n)},v2c:function(){gx.fn.setControlValue("vFILTERFULLTEXT",gx.O.AV19FilterFullText,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV19FilterFullText=this.val())},val:function(){return gx.fn.getControlValue("vFILTERFULLTEXT")},nac:gx.falseFn};this.declareDomainHdlr(18,function(){});i[19]={id:19,fld:"",grid:0};i[20]={id:20,fld:"",grid:0};i[21]={id:21,fld:"GRIDTABLEWITHPAGINATIONBAR",grid:0};i[22]={id:22,fld:"",grid:0};i[23]={id:23,fld:"",grid:0};i[25]={id:25,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:24,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSELECT",gxz:"ZV17Select",gxold:"OV17Select",gxvar:"AV17Select",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV17Select=n)},v2z:function(n){n!==undefined&&(gx.O.ZV17Select=n)},v2c:function(n){gx.fn.setGridControlValue("vSELECT",n||gx.fn.currentGridRowImpl(24),gx.O.AV17Select,1)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV17Select=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vSELECT",n||gx.fn.currentGridRowImpl(24))},nac:gx.falseFn,evt:"e176p2_client",std:"ENTER"};i[26]={id:26,lvl:2,type:"svchar",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:24,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTACTCOD",gxz:"Z2100ACTActCod",gxold:"O2100ACTActCod",gxvar:"A2100ACTActCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A2100ACTActCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z2100ACTActCod=n)},v2c:function(n){gx.fn.setGridControlValue("ACTACTCOD",n||gx.fn.currentGridRowImpl(24),gx.O.A2100ACTActCod,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A2100ACTActCod=this.val(n))},val:function(n){return gx.fn.getGridControlValue("ACTACTCOD",n||gx.fn.currentGridRowImpl(24))},nac:gx.falseFn};i[27]={id:27,lvl:2,type:"svchar",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:24,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTACTCODEQV",gxz:"Z2118ACTActCodEQV",gxold:"O2118ACTActCodEQV",gxvar:"A2118ACTActCodEQV",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A2118ACTActCodEQV=n)},v2z:function(n){n!==undefined&&(gx.O.Z2118ACTActCodEQV=n)},v2c:function(n){gx.fn.setGridControlValue("ACTACTCODEQV",n||gx.fn.currentGridRowImpl(24),gx.O.A2118ACTActCodEQV,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A2118ACTActCodEQV=this.val(n))},val:function(n){return gx.fn.getGridControlValue("ACTACTCODEQV",n||gx.fn.currentGridRowImpl(24))},nac:gx.falseFn};i[28]={id:28,lvl:2,type:"svchar",len:100,dec:0,sign:!1,ro:1,isacc:0,grid:24,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTACTDSC",gxz:"Z2122ACTActDsc",gxold:"O2122ACTActDsc",gxvar:"A2122ACTActDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A2122ACTActDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z2122ACTActDsc=n)},v2c:function(n){gx.fn.setGridControlValue("ACTACTDSC",n||gx.fn.currentGridRowImpl(24),gx.O.A2122ACTActDsc,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A2122ACTActDsc=this.val(n))},val:function(n){return gx.fn.getGridControlValue("ACTACTDSC",n||gx.fn.currentGridRowImpl(24))},nac:gx.falseFn};i[29]={id:29,lvl:2,type:"svchar",len:1,dec:0,sign:!1,ro:1,isacc:0,grid:24,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTACTSTS",gxz:"Z2136ACTActSts",gxold:"O2136ACTActSts",gxvar:"A2136ACTActSts",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A2136ACTActSts=n)},v2z:function(n){n!==undefined&&(gx.O.Z2136ACTActSts=n)},v2c:function(n){gx.fn.setGridControlValue("ACTACTSTS",n||gx.fn.currentGridRowImpl(24),gx.O.A2136ACTActSts,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A2136ACTActSts=this.val(n))},val:function(n){return gx.fn.getGridControlValue("ACTACTSTS",n||gx.fn.currentGridRowImpl(24))},nac:gx.falseFn};i[30]={id:30,fld:"",grid:0};i[31]={id:31,fld:"",grid:0};i[33]={id:33,fld:"",grid:0};i[34]={id:34,fld:"",grid:0};i[35]={id:35,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};this.AV19FilterFullText="";this.ZV19FilterFullText="";this.OV19FilterFullText="";this.ZV17Select="";this.OV17Select="";this.Z2100ACTActCod="";this.O2100ACTActCod="";this.Z2118ACTActCodEQV="";this.O2118ACTActCodEQV="";this.Z2122ACTActDsc="";this.O2122ACTActDsc="";this.Z2136ACTActSts="";this.O2136ACTActSts="";this.AV19FilterFullText="";this.AV14GridCurrentPage=0;this.AV12DDO_TitleSettingsIcons={Default_fi:"",Filtered_fi:"",SortedASC_fi:"",SortedDSC_fi:"",FilteredSortedASC_fi:"",FilteredSortedDSC_fi:"",OptionSortASC_fi:"",OptionSortDSC_fi:"",OptionApplyFilter_fi:"",OptionFilteringData_fi:"",OptionCleanFilters_fi:"",SelectedOption_fi:"",MultiselOption_fi:"",MultiselSelOption_fi:"",TreeviewCollapse_fi:"",TreeviewExpand_fi:"",FixLeft_fi:"",FixRight_fi:""};this.AV7InOutACTActCod="";this.AV18InOutActActDsc="";this.AV17Select="";this.A2100ACTActCod="";this.A2118ACTActCodEQV="";this.A2122ACTActDsc="";this.A2136ACTActSts="";this.AV22Pgmname="";this.AV10OrderedBy=0;this.AV11OrderedDsc=!1;this.Events={e116p2_client:["GRIDPAGINATIONBAR.CHANGEPAGE",!0],e126p2_client:["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!0],e136p2_client:["DDO_GRID.ONOPTIONCLICKED",!0],e176p2_client:["ENTER",!0],e186p2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV19FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV22Pgmname",fld:"vPGMNAME",pic:"",hsh:!0}],[{av:"AV14GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV15GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV16GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""}]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV19FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV22Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"this.GRIDPAGINATIONBARContainer.SelectedPage",ctrl:"GRIDPAGINATIONBAR",prop:"SelectedPage"}],[]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV19FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV22Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"this.GRIDPAGINATIONBARContainer.RowsPerPageSelectedValue",ctrl:"GRIDPAGINATIONBAR",prop:"RowsPerPageSelectedValue"}],[{ctrl:"GRID",prop:"Rows"}]];this.EvtParms["DDO_GRID.ONOPTIONCLICKED"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV19FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV22Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"this.DDO_GRIDContainer.ActiveEventKey",ctrl:"DDO_GRID",prop:"ActiveEventKey"},{av:"this.DDO_GRIDContainer.SelectedValue_get",ctrl:"DDO_GRID",prop:"SelectedValue_get"},{av:"AV10OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV11OrderedDsc",fld:"vORDEREDDSC",pic:""}],[{av:"AV10OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV11OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"this.DDO_GRIDContainer.SortedStatus",ctrl:"DDO_GRID",prop:"SortedStatus"}]];this.EvtParms["GRID.LOAD"]=[[],[{av:"AV17Select",fld:"vSELECT",pic:""}]];this.EvtParms.ENTER=[[{av:"A2100ACTActCod",fld:"ACTACTCOD",pic:"",hsh:!0},{av:"A2122ACTActDsc",fld:"ACTACTDSC",pic:"",hsh:!0}],[{av:"AV7InOutACTActCod",fld:"vINOUTACTACTCOD",pic:""},{av:"AV18InOutActActDsc",fld:"vINOUTACTACTDSC",pic:""}]];this.EnterCtrl=["vSELECT"];this.setVCMap("AV22Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV10OrderedBy","vORDEREDBY",0,"int",4,0);this.setVCMap("AV11OrderedDsc","vORDEREDDSC",0,"boolean",4,0);this.setVCMap("AV7InOutACTActCod","vINOUTACTACTCOD",0,"svchar",20,0);this.setVCMap("AV18InOutActActDsc","vINOUTACTACTDSC",0,"svchar",100,0);this.setVCMap("AV22Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV22Pgmname","vPGMNAME",0,"char",129,0);f.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});f.addRefreshingVar(this.GXValidFnc[18]);f.addRefreshingVar({rfrVar:"AV22Pgmname"});f.addRefreshingParm(this.GXValidFnc[18]);f.addRefreshingParm({rfrVar:"AV22Pgmname"});this.Initialize();this.setSDTMapping("WWPBaseObjects\\DVB_SDTDropDownOptionsTitleSettingsIcons",{Default_fi:{extr:"def"},Filtered_fi:{extr:"fil"},SortedASC_fi:{extr:"asc"},SortedDSC_fi:{extr:"dsc"},FilteredSortedASC_fi:{extr:"fasc"},FilteredSortedDSC_fi:{extr:"fdsc"},OptionSortASC_fi:{extr:"osasc"},OptionSortDSC_fi:{extr:"osdsc"},OptionApplyFilter_fi:{extr:"app"},OptionFilteringData_fi:{extr:"fildata"},OptionCleanFilters_fi:{extr:"cle"},SelectedOption_fi:{extr:"selo"},MultiselOption_fi:{extr:"mul"},MultiselSelOption_fi:{extr:"muls"},TreeviewCollapse_fi:{extr:"tcol"},TreeviewExpand_fi:{extr:"texp"},FixLeft_fi:{extr:"fixl"},FixRight_fi:{extr:"fixr"}})});gx.wi(function(){gx.createParentObj(this.generales.wwbusquedaactivos)})