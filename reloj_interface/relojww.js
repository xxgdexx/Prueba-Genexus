gx.evt.autoSkip=!1;gx.define("reloj_interface.relojww",!1,function(){var t,i,f,r,e,n,u,o;this.ServerClass="reloj_interface.relojww";this.PackageName="GeneXus.Programs";this.ServerFullClass="reloj_interface.relojww.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV53Pgmname=gx.fn.getControlValue("vPGMNAME");this.AV31TFRelojID=gx.fn.getIntegerValue("vTFRELOJID",",");this.AV32TFRelojID_To=gx.fn.getIntegerValue("vTFRELOJID_TO",",");this.AV33TFReloj_Nom=gx.fn.getControlValue("vTFRELOJ_NOM");this.AV34TFReloj_Nom_Sel=gx.fn.getControlValue("vTFRELOJ_NOM_SEL");this.AV35TFReloj_Dsc=gx.fn.getControlValue("vTFRELOJ_DSC");this.AV36TFReloj_Dsc_Sel=gx.fn.getControlValue("vTFRELOJ_DSC_SEL");this.AV37TFReloj_IP=gx.fn.getControlValue("vTFRELOJ_IP");this.AV38TFReloj_IP_Sel=gx.fn.getControlValue("vTFRELOJ_IP_SEL");this.AV39TFReloj_Puerto=gx.fn.getControlValue("vTFRELOJ_PUERTO");this.AV40TFReloj_Puerto_Sel=gx.fn.getControlValue("vTFRELOJ_PUERTO_SEL");this.AV41TFReloj_Estado=gx.fn.getIntegerValue("vTFRELOJ_ESTADO",",");this.AV42TFReloj_Estado_To=gx.fn.getIntegerValue("vTFRELOJ_ESTADO_TO",",");this.AV13OrderedBy=gx.fn.getIntegerValue("vORDEREDBY",",");this.AV14OrderedDsc=gx.fn.getControlValue("vORDEREDDSC");this.AV53Pgmname=gx.fn.getControlValue("vPGMNAME");this.AV31TFRelojID=gx.fn.getIntegerValue("vTFRELOJID",",");this.AV32TFRelojID_To=gx.fn.getIntegerValue("vTFRELOJID_TO",",");this.AV33TFReloj_Nom=gx.fn.getControlValue("vTFRELOJ_NOM");this.AV34TFReloj_Nom_Sel=gx.fn.getControlValue("vTFRELOJ_NOM_SEL");this.AV35TFReloj_Dsc=gx.fn.getControlValue("vTFRELOJ_DSC");this.AV36TFReloj_Dsc_Sel=gx.fn.getControlValue("vTFRELOJ_DSC_SEL");this.AV37TFReloj_IP=gx.fn.getControlValue("vTFRELOJ_IP");this.AV38TFReloj_IP_Sel=gx.fn.getControlValue("vTFRELOJ_IP_SEL");this.AV39TFReloj_Puerto=gx.fn.getControlValue("vTFRELOJ_PUERTO");this.AV40TFReloj_Puerto_Sel=gx.fn.getControlValue("vTFRELOJ_PUERTO_SEL");this.AV41TFReloj_Estado=gx.fn.getIntegerValue("vTFRELOJ_ESTADO",",");this.AV42TFReloj_Estado_To=gx.fn.getIntegerValue("vTFRELOJ_ESTADO_TO",",");this.AV13OrderedBy=gx.fn.getIntegerValue("vORDEREDBY",",");this.AV14OrderedDsc=gx.fn.getControlValue("vORDEREDDSC")};this.s132_client=function(){this.DDO_GRIDContainer.SortedStatus=gx.text.trim(gx.num.str(this.AV13OrderedBy,4,0))+":"+(this.AV14OrderedDsc?"DSC":"ASC")};this.e117b2_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEPAGE",!1,null,!0,!0)};this.e127b2_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!1,null,!0,!0)};this.e147b2_client=function(){return this.executeServerEvent("DDO_GRID.ONOPTIONCLICKED",!1,null,!0,!0)};this.e197b2_client=function(){return this.executeServerEvent("VGRIDACTIONS.CLICK",!0,arguments[0],!1,!1)};this.e157b2_client=function(){return this.executeServerEvent("'DOINSERT'",!1,null,!1,!1)};this.e137b2_client=function(){return this.executeServerEvent("DDO_AGEXPORT.ONOPTIONCLICKED",!1,null,!0,!0)};this.e207b2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e217b2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,27,28,29,30,31,33,34,35,36,37,38,39,40,41,43,44,45];this.GXLastCtrlId=45;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",32,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"reloj_interface.relojww",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);i=this.GridContainer;i.addComboBox("Gridactions",33,"vGRIDACTIONS","","GridActions","int","e197b2_client",0,!0,!1,0,"px","WWActionGroupColumn");i.addSingleLineEdit(2430,34,"RELOJID","Código","","RelojID","int",0,"px",4,4,"right",null,[],2430,"RelojID",!0,0,!1,!1,"Attribute",1,"WWColumn hidden-xs");i.addSingleLineEdit(2425,35,"RELOJ_NOM","Reloj_Nom","","Reloj_Nom","svchar",0,"px",50,50,"left",null,[],2425,"Reloj_Nom",!0,0,!1,!1,"Attribute",1,"WWColumn");i.addSingleLineEdit(2426,36,"RELOJ_DSC","Reloj_Dsc","","Reloj_Dsc","svchar",0,"px",100,80,"left",null,[],2426,"Reloj_Dsc",!0,0,!1,!1,"Attribute",1,"WWColumn hidden-xs");i.addSingleLineEdit(2427,37,"RELOJ_IP","Reloj_IP","","Reloj_IP","svchar",0,"px",50,50,"left",null,[],2427,"Reloj_IP",!0,0,!1,!1,"Attribute",1,"WWColumn hidden-xs");i.addSingleLineEdit(2428,38,"RELOJ_PUERTO","Reloj_Puerto","","Reloj_Puerto","svchar",0,"px",50,50,"left",null,[],2428,"Reloj_Puerto",!0,0,!1,!1,"Attribute",1,"WWColumn hidden-xs");i.addSingleLineEdit(2429,39,"RELOJ_ESTADO","Reloj_Estado","","Reloj_Estado","int",0,"px",1,1,"right",null,[],2429,"Reloj_Estado",!0,0,!1,!1,"Attribute",1,"WWColumn hidden-xs");this.GridContainer.emptyText="";this.setGrid(i);this.DVPANEL_TABLEHEADERContainer=gx.uc.getNew(this,9,0,"BootstrapPanel","DVPANEL_TABLEHEADERContainer","Dvpanel_tableheader","DVPANEL_TABLEHEADER");f=this.DVPANEL_TABLEHEADERContainer;f.setProp("Class","Class","","char");f.setProp("Enabled","Enabled",!0,"boolean");f.setProp("Width","Width","100%","str");f.setProp("Height","Height","100","str");f.setProp("AutoWidth","Autowidth",!1,"bool");f.setProp("AutoHeight","Autoheight",!0,"bool");f.setProp("Cls","Cls","PanelNoHeader","str");f.setProp("ShowHeader","Showheader",!0,"bool");f.setProp("Title","Title","Opciones","str");f.setProp("Collapsible","Collapsible",!0,"bool");f.setProp("Collapsed","Collapsed",!1,"bool");f.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");f.setProp("IconPosition","Iconposition","Right","str");f.setProp("AutoScroll","Autoscroll",!1,"bool");f.setProp("Visible","Visible",!0,"bool");f.setProp("Gx Control Type","Gxcontroltype","","int");f.setC2ShowFunction(function(n){n.show()});this.setUserControl(f);this.GRIDPAGINATIONBARContainer=gx.uc.getNew(this,42,33,"DVelop_DVPaginationBar","GRIDPAGINATIONBARContainer","Gridpaginationbar","GRIDPAGINATIONBAR");r=this.GRIDPAGINATIONBARContainer;r.setProp("Enabled","Enabled",!0,"boolean");r.setProp("Class","Class","PaginationBar","str");r.setProp("ShowFirst","Showfirst",!1,"bool");r.setProp("ShowPrevious","Showprevious",!0,"bool");r.setProp("ShowNext","Shownext",!0,"bool");r.setProp("ShowLast","Showlast",!1,"bool");r.setProp("PagesToShow","Pagestoshow",5,"num");r.setProp("PagingButtonsPosition","Pagingbuttonsposition","Right","str");r.setProp("PagingCaptionPosition","Pagingcaptionposition","Left","str");r.setProp("EmptyGridClass","Emptygridclass","PaginationBarEmptyGrid","str");r.setProp("SelectedPage","Selectedpage","","char");r.setProp("RowsPerPageSelector","Rowsperpageselector",!0,"bool");r.setDynProp("RowsPerPageSelectedValue","Rowsperpageselectedvalue",10,"num");r.setProp("RowsPerPageOptions","Rowsperpageoptions","5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50","str");r.setProp("First","First","First","str");r.setProp("Previous","Previous","WWP_PagingPreviousCaption","str");r.setProp("Next","Next","WWP_PagingNextCaption","str");r.setProp("Last","Last","Last","str");r.setProp("Caption","Caption","Página <CURRENT_PAGE> de <TOTAL_PAGES>","str");r.setProp("EmptyGridCaption","Emptygridcaption","WWP_PagingEmptyGridCaption","str");r.setProp("RowsPerPageCaption","Rowsperpagecaption","WWP_PagingRowsPerPage","str");r.addV2CFunction("AV45GridCurrentPage","vGRIDCURRENTPAGE","SetCurrentPage");r.addC2VFunction(function(n){n.ParentObject.AV45GridCurrentPage=n.GetCurrentPage();gx.fn.setControlValue("vGRIDCURRENTPAGE",n.ParentObject.AV45GridCurrentPage)});r.addV2CFunction("AV46GridPageCount","vGRIDPAGECOUNT","SetPageCount");r.addC2VFunction(function(n){n.ParentObject.AV46GridPageCount=n.GetPageCount();gx.fn.setControlValue("vGRIDPAGECOUNT",n.ParentObject.AV46GridPageCount)});r.setProp("RecordCount","Recordcount","","str");r.setProp("Page","Page","","str");r.addV2CFunction("AV47GridAppliedFilters","vGRIDAPPLIEDFILTERS","SetAppliedFilters");r.addC2VFunction(function(n){n.ParentObject.AV47GridAppliedFilters=n.GetAppliedFilters();gx.fn.setControlValue("vGRIDAPPLIEDFILTERS",n.ParentObject.AV47GridAppliedFilters)});r.setProp("Visible","Visible",!0,"bool");r.setProp("Gx Control Type","Gxcontroltype","","int");r.setC2ShowFunction(function(n){n.show()});r.addEventHandler("ChangePage",this.e117b2_client);r.addEventHandler("ChangeRowsPerPage",this.e127b2_client);this.setUserControl(r);this.DDO_AGEXPORTContainer=gx.uc.getNew(this,46,33,"BootstrapDropDownOptions","DDO_AGEXPORTContainer","Ddo_agexport","DDO_AGEXPORT");e=this.DDO_AGEXPORTContainer;e.setProp("Class","Class","","char");e.setProp("Enabled","Enabled",!0,"boolean");e.setProp("IconType","Icontype","FontIcon","str");e.setProp("Icon","Icon","fas fa-download","str");e.setProp("Caption","Caption","Reportes","str");e.setProp("Tooltip","Tooltip","","str");e.setProp("Cls","Cls","ColumnsSelector","str");e.setProp("ActiveEventKey","Activeeventkey","","char");e.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");e.setProp("DropDownOptionsType","Dropdownoptionstype","Regular","str");e.setProp("Visible","Visible",!0,"bool");e.setDynProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");e.addV2CFunction("AV49AGExportData","vAGEXPORTDATA","SetDropDownOptionsData");e.addC2VFunction(function(n){n.ParentObject.AV49AGExportData=n.GetDropDownOptionsData();gx.fn.setControlValue("vAGEXPORTDATA",n.ParentObject.AV49AGExportData)});e.setProp("Gx Control Type","Gxcontroltype","","int");e.setC2ShowFunction(function(n){n.show()});e.addEventHandler("OnOptionClicked",this.e137b2_client);this.setUserControl(e);this.DDO_GRIDContainer=gx.uc.getNew(this,47,33,"DDOGridTitleSettingsM","DDO_GRIDContainer","Ddo_grid","DDO_GRID");n=this.DDO_GRIDContainer;n.setProp("Class","Class","","char");n.setProp("Enabled","Enabled",!0,"boolean");n.setProp("IconType","Icontype","Image","str");n.setProp("Icon","Icon","","str");n.setProp("Caption","Caption","","str");n.setProp("Tooltip","Tooltip","","str");n.setProp("Cls","Cls","","str");n.setProp("ActiveEventKey","Activeeventkey","","char");n.setDynProp("FilteredText_set","Filteredtext_set","","char");n.setProp("FilteredText_get","Filteredtext_get","","char");n.setDynProp("FilteredTextTo_set","Filteredtextto_set","","char");n.setProp("FilteredTextTo_get","Filteredtextto_get","","char");n.setDynProp("SelectedValue_set","Selectedvalue_set","","char");n.setProp("SelectedValue_get","Selectedvalue_get","","char");n.setProp("SelectedText_set","Selectedtext_set","","char");n.setProp("SelectedText_get","Selectedtext_get","","char");n.setProp("SelectedColumn","Selectedcolumn","","char");n.setProp("SelectedColumnFixedFilter","Selectedcolumnfixedfilter","","char");n.setProp("GAMOAuthToken","Gamoauthtoken","","char");n.setProp("TitleControlAlign","Titlecontrolalign","","str");n.setProp("Visible","Visible","","str");n.setDynProp("GridInternalName","Gridinternalname","","str");n.setProp("ColumnIds","Columnids","1:RelojID|2:Reloj_Nom|3:Reloj_Dsc|4:Reloj_IP|5:Reloj_Puerto|6:Reloj_Estado","str");n.setProp("ColumnsSortValues","Columnssortvalues","1|2|3|4|5|6","str");n.setProp("IncludeSortASC","Includesortasc","T","str");n.setProp("IncludeSortDSC","Includesortdsc","","str");n.setProp("AllowGroup","Allowgroup","","str");n.setProp("Fixable","Fixable","","str");n.setDynProp("SortedStatus","Sortedstatus","","char");n.setProp("IncludeFilter","Includefilter","T","str");n.setProp("FilterType","Filtertype","Numeric|Character|Character|Character|Character|Numeric","str");n.setProp("FilterIsRange","Filterisrange","T|||||T","str");n.setProp("IncludeDataList","Includedatalist","|T|T|T|T|","str");n.setProp("DataListType","Datalisttype","|Dynamic|Dynamic|Dynamic|Dynamic|","str");n.setProp("AllowMultipleSelection","Allowmultipleselection","","str");n.setProp("DataListFixedValues","Datalistfixedvalues","","str");n.setProp("DataListProc","Datalistproc","Reloj_Interface.RelojWWGetFilterData","str");n.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");n.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");n.setProp("FixedFilters","Fixedfilters","","str");n.setProp("SelectedFixedFilter","Selectedfixedfilter","","char");n.setProp("SortASC","Sortasc","","str");n.setProp("SortDSC","Sortdsc","","str");n.setProp("AllowGroupText","Allowgrouptext","","str");n.setProp("LoadingData","Loadingdata","","str");n.setProp("CleanFilter","Cleanfilter","","str");n.setProp("RangeFilterFrom","Rangefilterfrom","","str");n.setProp("RangeFilterTo","Rangefilterto","","str");n.setProp("NoResultsFound","Noresultsfound","","str");n.setProp("SearchButtonText","Searchbuttontext","","str");n.addV2CFunction("AV43DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");n.addC2VFunction(function(n){n.ParentObject.AV43DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV43DDO_TitleSettingsIcons)});n.setC2ShowFunction(function(n){n.show()});n.addEventHandler("OnOptionClicked",this.e147b2_client);this.setUserControl(n);this.INNEWWINDOW1Container=gx.uc.getNew(this,48,33,"InNewWindow","INNEWWINDOW1Container","Innewwindow1","INNEWWINDOW1");u=this.INNEWWINDOW1Container;u.setProp("Class","Class","","char");u.setProp("Enabled","Enabled",!0,"boolean");u.setDynProp("Width","Width","50","str");u.setDynProp("Height","Height","50","str");u.setProp("Name","Name","","str");u.setDynProp("Target","Target","","str");u.setProp("Fullscreen","Fullscreen",!1,"bool");u.setProp("Location","Location",!0,"bool");u.setProp("MenuBar","Menubar",!0,"bool");u.setProp("Resizable","Resizable",!0,"bool");u.setProp("Scrollbars","Scrollbars",!0,"bool");u.setProp("TitleBar","Titlebar",!0,"bool");u.setProp("ToolBar","Toolbar",!0,"bool");u.setProp("directories","Directories",!0,"bool");u.setProp("status","Status",!0,"bool");u.setProp("copyhistory","Copyhistory",!0,"bool");u.setProp("top","Top","5","str");u.setProp("left","Left","5","str");u.setProp("fitscreen","Fitscreen",!1,"bool");u.setProp("RefreshParentOnClose","Refreshparentonclose",!1,"bool");u.setProp("Targets","Targets","","str");u.setProp("Visible","Visible",!0,"bool");u.setC2ShowFunction(function(n){n.show()});this.setUserControl(u);this.GRID_EMPOWERERContainer=gx.uc.getNew(this,49,33,"WWP_GridEmpowerer","GRID_EMPOWERERContainer","Grid_empowerer","GRID_EMPOWERER");o=this.GRID_EMPOWERERContainer;o.setProp("Class","Class","","char");o.setProp("Enabled","Enabled",!0,"boolean");o.setDynProp("GridInternalName","Gridinternalname","","char");o.setProp("HasCategories","Hascategories",!1,"bool");o.setProp("InfiniteScrolling","Infinitescrolling","False","str");o.setProp("HasTitleSettings","Hastitlesettings",!0,"bool");o.setProp("HasColumnsSelector","Hascolumnsselector",!1,"bool");o.setProp("HasRowGroups","Hasrowgroups",!1,"bool");o.setProp("FixedColumns","Fixedcolumns","","str");o.setProp("PopoversInGrid","Popoversingrid","","str");o.setProp("Visible","Visible",!0,"bool");o.setC2ShowFunction(function(n){n.show()});this.setUserControl(o);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLEMAIN",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[11]={id:11,fld:"TABLEHEADER",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"TABLEHEADERCONTENT",grid:0};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"TABLEACTIONS",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"BTNINSERT",grid:0,evt:"e157b2_client"};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"BTNAGEXPORT",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,fld:"TABLERIGHTHEADER",grid:0};t[24]={id:24,fld:"",grid:0};t[25]={id:25,fld:"",grid:0};t[27]={id:27,fld:"",grid:0};t[28]={id:28,fld:"",grid:0};t[29]={id:29,fld:"GRIDTABLEWITHPAGINATIONBAR",grid:0};t[30]={id:30,fld:"",grid:0};t[31]={id:31,fld:"",grid:0};t[33]={id:33,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,isacc:0,grid:32,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vGRIDACTIONS",gxz:"ZV48GridActions",gxold:"OV48GridActions",gxvar:"AV48GridActions",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV48GridActions=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV48GridActions=gx.num.intval(n))},v2c:function(n){gx.fn.setGridComboBoxValue("vGRIDACTIONS",n||gx.fn.currentGridRowImpl(32),gx.O.AV48GridActions)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV48GridActions=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vGRIDACTIONS",n||gx.fn.currentGridRowImpl(32),",")},nac:gx.falseFn,evt:"e197b2_client"};t[34]={id:34,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:32,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RELOJID",gxz:"Z2430RelojID",gxold:"O2430RelojID",gxvar:"A2430RelojID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A2430RelojID=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z2430RelojID=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("RELOJID",n||gx.fn.currentGridRowImpl(32),gx.O.A2430RelojID,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A2430RelojID=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("RELOJID",n||gx.fn.currentGridRowImpl(32),",")},nac:gx.falseFn};t[35]={id:35,lvl:2,type:"svchar",len:50,dec:0,sign:!1,ro:1,isacc:0,grid:32,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RELOJ_NOM",gxz:"Z2425Reloj_Nom",gxold:"O2425Reloj_Nom",gxvar:"A2425Reloj_Nom",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A2425Reloj_Nom=n)},v2z:function(n){n!==undefined&&(gx.O.Z2425Reloj_Nom=n)},v2c:function(n){gx.fn.setGridControlValue("RELOJ_NOM",n||gx.fn.currentGridRowImpl(32),gx.O.A2425Reloj_Nom,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A2425Reloj_Nom=this.val(n))},val:function(n){return gx.fn.getGridControlValue("RELOJ_NOM",n||gx.fn.currentGridRowImpl(32))},nac:gx.falseFn};t[36]={id:36,lvl:2,type:"svchar",len:100,dec:0,sign:!1,ro:1,isacc:0,grid:32,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RELOJ_DSC",gxz:"Z2426Reloj_Dsc",gxold:"O2426Reloj_Dsc",gxvar:"A2426Reloj_Dsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A2426Reloj_Dsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z2426Reloj_Dsc=n)},v2c:function(n){gx.fn.setGridControlValue("RELOJ_DSC",n||gx.fn.currentGridRowImpl(32),gx.O.A2426Reloj_Dsc,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A2426Reloj_Dsc=this.val(n))},val:function(n){return gx.fn.getGridControlValue("RELOJ_DSC",n||gx.fn.currentGridRowImpl(32))},nac:gx.falseFn};t[37]={id:37,lvl:2,type:"svchar",len:50,dec:0,sign:!1,ro:1,isacc:0,grid:32,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RELOJ_IP",gxz:"Z2427Reloj_IP",gxold:"O2427Reloj_IP",gxvar:"A2427Reloj_IP",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A2427Reloj_IP=n)},v2z:function(n){n!==undefined&&(gx.O.Z2427Reloj_IP=n)},v2c:function(n){gx.fn.setGridControlValue("RELOJ_IP",n||gx.fn.currentGridRowImpl(32),gx.O.A2427Reloj_IP,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A2427Reloj_IP=this.val(n))},val:function(n){return gx.fn.getGridControlValue("RELOJ_IP",n||gx.fn.currentGridRowImpl(32))},nac:gx.falseFn};t[38]={id:38,lvl:2,type:"svchar",len:50,dec:0,sign:!1,ro:1,isacc:0,grid:32,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RELOJ_PUERTO",gxz:"Z2428Reloj_Puerto",gxold:"O2428Reloj_Puerto",gxvar:"A2428Reloj_Puerto",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A2428Reloj_Puerto=n)},v2z:function(n){n!==undefined&&(gx.O.Z2428Reloj_Puerto=n)},v2c:function(n){gx.fn.setGridControlValue("RELOJ_PUERTO",n||gx.fn.currentGridRowImpl(32),gx.O.A2428Reloj_Puerto,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A2428Reloj_Puerto=this.val(n))},val:function(n){return gx.fn.getGridControlValue("RELOJ_PUERTO",n||gx.fn.currentGridRowImpl(32))},nac:gx.falseFn};t[39]={id:39,lvl:2,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:1,isacc:0,grid:32,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RELOJ_ESTADO",gxz:"Z2429Reloj_Estado",gxold:"O2429Reloj_Estado",gxvar:"A2429Reloj_Estado",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A2429Reloj_Estado=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z2429Reloj_Estado=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("RELOJ_ESTADO",n||gx.fn.currentGridRowImpl(32),gx.O.A2429Reloj_Estado,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A2429Reloj_Estado=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("RELOJ_ESTADO",n||gx.fn.currentGridRowImpl(32),",")},nac:gx.falseFn};t[40]={id:40,fld:"",grid:0};t[41]={id:41,fld:"",grid:0};t[43]={id:43,fld:"",grid:0};t[44]={id:44,fld:"",grid:0};t[45]={id:45,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};this.ZV48GridActions=0;this.OV48GridActions=0;this.Z2430RelojID=0;this.O2430RelojID=0;this.Z2425Reloj_Nom="";this.O2425Reloj_Nom="";this.Z2426Reloj_Dsc="";this.O2426Reloj_Dsc="";this.Z2427Reloj_IP="";this.O2427Reloj_IP="";this.Z2428Reloj_Puerto="";this.O2428Reloj_Puerto="";this.Z2429Reloj_Estado=0;this.O2429Reloj_Estado=0;this.AV45GridCurrentPage=0;this.AV49AGExportData=[];this.AV43DDO_TitleSettingsIcons={Default_fi:"",Filtered_fi:"",SortedASC_fi:"",SortedDSC_fi:"",FilteredSortedASC_fi:"",FilteredSortedDSC_fi:"",OptionSortASC_fi:"",OptionSortDSC_fi:"",OptionApplyFilter_fi:"",OptionFilteringData_fi:"",OptionCleanFilters_fi:"",SelectedOption_fi:"",MultiselOption_fi:"",MultiselSelOption_fi:"",TreeviewCollapse_fi:"",TreeviewExpand_fi:"",FixLeft_fi:"",FixRight_fi:""};this.AV48GridActions=0;this.A2430RelojID=0;this.A2425Reloj_Nom="";this.A2426Reloj_Dsc="";this.A2427Reloj_IP="";this.A2428Reloj_Puerto="";this.A2429Reloj_Estado=0;this.AV53Pgmname="";this.AV31TFRelojID=0;this.AV32TFRelojID_To=0;this.AV33TFReloj_Nom="";this.AV34TFReloj_Nom_Sel="";this.AV35TFReloj_Dsc="";this.AV36TFReloj_Dsc_Sel="";this.AV37TFReloj_IP="";this.AV38TFReloj_IP_Sel="";this.AV39TFReloj_Puerto="";this.AV40TFReloj_Puerto_Sel="";this.AV41TFReloj_Estado=0;this.AV42TFReloj_Estado_To=0;this.AV13OrderedBy=0;this.AV14OrderedDsc=!1;this.Events={e117b2_client:["GRIDPAGINATIONBAR.CHANGEPAGE",!0],e127b2_client:["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!0],e147b2_client:["DDO_GRID.ONOPTIONCLICKED",!0],e197b2_client:["VGRIDACTIONS.CLICK",!0],e157b2_client:["'DOINSERT'",!0],e137b2_client:["DDO_AGEXPORT.ONOPTIONCLICKED",!0],e207b2_client:["ENTER",!0],e217b2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV53Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV31TFRelojID",fld:"vTFRELOJID",pic:"ZZZ9"},{av:"AV32TFRelojID_To",fld:"vTFRELOJID_TO",pic:"ZZZ9"},{av:"AV33TFReloj_Nom",fld:"vTFRELOJ_NOM",pic:""},{av:"AV34TFReloj_Nom_Sel",fld:"vTFRELOJ_NOM_SEL",pic:""},{av:"AV35TFReloj_Dsc",fld:"vTFRELOJ_DSC",pic:""},{av:"AV36TFReloj_Dsc_Sel",fld:"vTFRELOJ_DSC_SEL",pic:""},{av:"AV37TFReloj_IP",fld:"vTFRELOJ_IP",pic:""},{av:"AV38TFReloj_IP_Sel",fld:"vTFRELOJ_IP_SEL",pic:""},{av:"AV39TFReloj_Puerto",fld:"vTFRELOJ_PUERTO",pic:""},{av:"AV40TFReloj_Puerto_Sel",fld:"vTFRELOJ_PUERTO_SEL",pic:""},{av:"AV41TFReloj_Estado",fld:"vTFRELOJ_ESTADO",pic:"9"},{av:"AV42TFReloj_Estado_To",fld:"vTFRELOJ_ESTADO_TO",pic:"9"},{av:"AV13OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV14OrderedDsc",fld:"vORDEREDDSC",pic:""}],[{av:"AV45GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV46GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV47GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""}]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV53Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV31TFRelojID",fld:"vTFRELOJID",pic:"ZZZ9"},{av:"AV32TFRelojID_To",fld:"vTFRELOJID_TO",pic:"ZZZ9"},{av:"AV33TFReloj_Nom",fld:"vTFRELOJ_NOM",pic:""},{av:"AV34TFReloj_Nom_Sel",fld:"vTFRELOJ_NOM_SEL",pic:""},{av:"AV35TFReloj_Dsc",fld:"vTFRELOJ_DSC",pic:""},{av:"AV36TFReloj_Dsc_Sel",fld:"vTFRELOJ_DSC_SEL",pic:""},{av:"AV37TFReloj_IP",fld:"vTFRELOJ_IP",pic:""},{av:"AV38TFReloj_IP_Sel",fld:"vTFRELOJ_IP_SEL",pic:""},{av:"AV39TFReloj_Puerto",fld:"vTFRELOJ_PUERTO",pic:""},{av:"AV40TFReloj_Puerto_Sel",fld:"vTFRELOJ_PUERTO_SEL",pic:""},{av:"AV41TFReloj_Estado",fld:"vTFRELOJ_ESTADO",pic:"9"},{av:"AV42TFReloj_Estado_To",fld:"vTFRELOJ_ESTADO_TO",pic:"9"},{av:"AV13OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV14OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"this.GRIDPAGINATIONBARContainer.SelectedPage",ctrl:"GRIDPAGINATIONBAR",prop:"SelectedPage"}],[]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV53Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV31TFRelojID",fld:"vTFRELOJID",pic:"ZZZ9"},{av:"AV32TFRelojID_To",fld:"vTFRELOJID_TO",pic:"ZZZ9"},{av:"AV33TFReloj_Nom",fld:"vTFRELOJ_NOM",pic:""},{av:"AV34TFReloj_Nom_Sel",fld:"vTFRELOJ_NOM_SEL",pic:""},{av:"AV35TFReloj_Dsc",fld:"vTFRELOJ_DSC",pic:""},{av:"AV36TFReloj_Dsc_Sel",fld:"vTFRELOJ_DSC_SEL",pic:""},{av:"AV37TFReloj_IP",fld:"vTFRELOJ_IP",pic:""},{av:"AV38TFReloj_IP_Sel",fld:"vTFRELOJ_IP_SEL",pic:""},{av:"AV39TFReloj_Puerto",fld:"vTFRELOJ_PUERTO",pic:""},{av:"AV40TFReloj_Puerto_Sel",fld:"vTFRELOJ_PUERTO_SEL",pic:""},{av:"AV41TFReloj_Estado",fld:"vTFRELOJ_ESTADO",pic:"9"},{av:"AV42TFReloj_Estado_To",fld:"vTFRELOJ_ESTADO_TO",pic:"9"},{av:"AV13OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV14OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"this.GRIDPAGINATIONBARContainer.RowsPerPageSelectedValue",ctrl:"GRIDPAGINATIONBAR",prop:"RowsPerPageSelectedValue"}],[{ctrl:"GRID",prop:"Rows"}]];this.EvtParms["DDO_GRID.ONOPTIONCLICKED"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV53Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV31TFRelojID",fld:"vTFRELOJID",pic:"ZZZ9"},{av:"AV32TFRelojID_To",fld:"vTFRELOJID_TO",pic:"ZZZ9"},{av:"AV33TFReloj_Nom",fld:"vTFRELOJ_NOM",pic:""},{av:"AV34TFReloj_Nom_Sel",fld:"vTFRELOJ_NOM_SEL",pic:""},{av:"AV35TFReloj_Dsc",fld:"vTFRELOJ_DSC",pic:""},{av:"AV36TFReloj_Dsc_Sel",fld:"vTFRELOJ_DSC_SEL",pic:""},{av:"AV37TFReloj_IP",fld:"vTFRELOJ_IP",pic:""},{av:"AV38TFReloj_IP_Sel",fld:"vTFRELOJ_IP_SEL",pic:""},{av:"AV39TFReloj_Puerto",fld:"vTFRELOJ_PUERTO",pic:""},{av:"AV40TFReloj_Puerto_Sel",fld:"vTFRELOJ_PUERTO_SEL",pic:""},{av:"AV41TFReloj_Estado",fld:"vTFRELOJ_ESTADO",pic:"9"},{av:"AV42TFReloj_Estado_To",fld:"vTFRELOJ_ESTADO_TO",pic:"9"},{av:"AV13OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV14OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"this.DDO_GRIDContainer.ActiveEventKey",ctrl:"DDO_GRID",prop:"ActiveEventKey"},{av:"this.DDO_GRIDContainer.SelectedValue_get",ctrl:"DDO_GRID",prop:"SelectedValue_get"},{av:"this.DDO_GRIDContainer.FilteredTextTo_get",ctrl:"DDO_GRID",prop:"FilteredTextTo_get"},{av:"this.DDO_GRIDContainer.FilteredText_get",ctrl:"DDO_GRID",prop:"FilteredText_get"},{av:"this.DDO_GRIDContainer.SelectedColumn",ctrl:"DDO_GRID",prop:"SelectedColumn"}],[{av:"AV13OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV14OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV41TFReloj_Estado",fld:"vTFRELOJ_ESTADO",pic:"9"},{av:"AV42TFReloj_Estado_To",fld:"vTFRELOJ_ESTADO_TO",pic:"9"},{av:"AV39TFReloj_Puerto",fld:"vTFRELOJ_PUERTO",pic:""},{av:"AV40TFReloj_Puerto_Sel",fld:"vTFRELOJ_PUERTO_SEL",pic:""},{av:"AV37TFReloj_IP",fld:"vTFRELOJ_IP",pic:""},{av:"AV38TFReloj_IP_Sel",fld:"vTFRELOJ_IP_SEL",pic:""},{av:"AV35TFReloj_Dsc",fld:"vTFRELOJ_DSC",pic:""},{av:"AV36TFReloj_Dsc_Sel",fld:"vTFRELOJ_DSC_SEL",pic:""},{av:"AV33TFReloj_Nom",fld:"vTFRELOJ_NOM",pic:""},{av:"AV34TFReloj_Nom_Sel",fld:"vTFRELOJ_NOM_SEL",pic:""},{av:"AV31TFRelojID",fld:"vTFRELOJID",pic:"ZZZ9"},{av:"AV32TFRelojID_To",fld:"vTFRELOJID_TO",pic:"ZZZ9"},{av:"this.DDO_GRIDContainer.SortedStatus",ctrl:"DDO_GRID",prop:"SortedStatus"}]];this.EvtParms["GRID.LOAD"]=[[{av:"A2430RelojID",fld:"RELOJID",pic:"ZZZ9",hsh:!0}],[{ctrl:"vGRIDACTIONS"},{av:"AV48GridActions",fld:"vGRIDACTIONS",pic:"ZZZ9"},{av:'gx.fn.getCtrlProperty("RELOJ_NOM","Link")',ctrl:"RELOJ_NOM",prop:"Link"}]];this.EvtParms["VGRIDACTIONS.CLICK"]=[[{ctrl:"vGRIDACTIONS"},{av:"AV48GridActions",fld:"vGRIDACTIONS",pic:"ZZZ9"},{av:"A2430RelojID",fld:"RELOJID",pic:"ZZZ9",hsh:!0}],[{ctrl:"vGRIDACTIONS"},{av:"AV48GridActions",fld:"vGRIDACTIONS",pic:"ZZZ9"}]];this.EvtParms["'DOINSERT'"]=[[{av:"A2430RelojID",fld:"RELOJID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms["DDO_AGEXPORT.ONOPTIONCLICKED"]=[[{av:"this.DDO_AGEXPORTContainer.ActiveEventKey",ctrl:"DDO_AGEXPORT",prop:"ActiveEventKey"},{av:"AV53Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV34TFReloj_Nom_Sel",fld:"vTFRELOJ_NOM_SEL",pic:""},{av:"AV36TFReloj_Dsc_Sel",fld:"vTFRELOJ_DSC_SEL",pic:""},{av:"AV38TFReloj_IP_Sel",fld:"vTFRELOJ_IP_SEL",pic:""},{av:"AV40TFReloj_Puerto_Sel",fld:"vTFRELOJ_PUERTO_SEL",pic:""},{av:"AV31TFRelojID",fld:"vTFRELOJID",pic:"ZZZ9"},{av:"AV33TFReloj_Nom",fld:"vTFRELOJ_NOM",pic:""},{av:"AV35TFReloj_Dsc",fld:"vTFRELOJ_DSC",pic:""},{av:"AV37TFReloj_IP",fld:"vTFRELOJ_IP",pic:""},{av:"AV39TFReloj_Puerto",fld:"vTFRELOJ_PUERTO",pic:""},{av:"AV41TFReloj_Estado",fld:"vTFRELOJ_ESTADO",pic:"9"},{av:"AV32TFRelojID_To",fld:"vTFRELOJID_TO",pic:"ZZZ9"},{av:"AV42TFReloj_Estado_To",fld:"vTFRELOJ_ESTADO_TO",pic:"9"},{av:"AV13OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV14OrderedDsc",fld:"vORDEREDDSC",pic:""}],[{av:"this.INNEWWINDOW1Container.Target",ctrl:"INNEWWINDOW1",prop:"Target"},{av:"this.INNEWWINDOW1Container.Height",ctrl:"INNEWWINDOW1",prop:"Height"},{av:"this.INNEWWINDOW1Container.Width",ctrl:"INNEWWINDOW1",prop:"Width"},{av:"AV13OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV14OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV41TFReloj_Estado",fld:"vTFRELOJ_ESTADO",pic:"9"},{av:"AV42TFReloj_Estado_To",fld:"vTFRELOJ_ESTADO_TO",pic:"9"},{av:"AV40TFReloj_Puerto_Sel",fld:"vTFRELOJ_PUERTO_SEL",pic:""},{av:"AV39TFReloj_Puerto",fld:"vTFRELOJ_PUERTO",pic:""},{av:"AV38TFReloj_IP_Sel",fld:"vTFRELOJ_IP_SEL",pic:""},{av:"AV37TFReloj_IP",fld:"vTFRELOJ_IP",pic:""},{av:"AV36TFReloj_Dsc_Sel",fld:"vTFRELOJ_DSC_SEL",pic:""},{av:"AV35TFReloj_Dsc",fld:"vTFRELOJ_DSC",pic:""},{av:"AV34TFReloj_Nom_Sel",fld:"vTFRELOJ_NOM_SEL",pic:""},{av:"AV33TFReloj_Nom",fld:"vTFRELOJ_NOM",pic:""},{av:"AV31TFRelojID",fld:"vTFRELOJID",pic:"ZZZ9"},{av:"AV32TFRelojID_To",fld:"vTFRELOJID_TO",pic:"ZZZ9"},{av:"this.DDO_GRIDContainer.SelectedValue_set",ctrl:"DDO_GRID",prop:"SelectedValue_set"},{av:"this.DDO_GRIDContainer.FilteredText_set",ctrl:"DDO_GRID",prop:"FilteredText_set"},{av:"this.DDO_GRIDContainer.FilteredTextTo_set",ctrl:"DDO_GRID",prop:"FilteredTextTo_set"},{ctrl:"GRID",prop:"Rows"},{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV53Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"this.DDO_GRIDContainer.SortedStatus",ctrl:"DDO_GRID",prop:"SortedStatus"}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV53Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV31TFRelojID","vTFRELOJID",0,"int",4,0);this.setVCMap("AV32TFRelojID_To","vTFRELOJID_TO",0,"int",4,0);this.setVCMap("AV33TFReloj_Nom","vTFRELOJ_NOM",0,"svchar",50,0);this.setVCMap("AV34TFReloj_Nom_Sel","vTFRELOJ_NOM_SEL",0,"svchar",50,0);this.setVCMap("AV35TFReloj_Dsc","vTFRELOJ_DSC",0,"svchar",100,0);this.setVCMap("AV36TFReloj_Dsc_Sel","vTFRELOJ_DSC_SEL",0,"svchar",100,0);this.setVCMap("AV37TFReloj_IP","vTFRELOJ_IP",0,"svchar",50,0);this.setVCMap("AV38TFReloj_IP_Sel","vTFRELOJ_IP_SEL",0,"svchar",50,0);this.setVCMap("AV39TFReloj_Puerto","vTFRELOJ_PUERTO",0,"svchar",50,0);this.setVCMap("AV40TFReloj_Puerto_Sel","vTFRELOJ_PUERTO_SEL",0,"svchar",50,0);this.setVCMap("AV41TFReloj_Estado","vTFRELOJ_ESTADO",0,"int",1,0);this.setVCMap("AV42TFReloj_Estado_To","vTFRELOJ_ESTADO_TO",0,"int",1,0);this.setVCMap("AV13OrderedBy","vORDEREDBY",0,"int",4,0);this.setVCMap("AV14OrderedDsc","vORDEREDDSC",0,"boolean",4,0);this.setVCMap("AV53Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV31TFRelojID","vTFRELOJID",0,"int",4,0);this.setVCMap("AV32TFRelojID_To","vTFRELOJID_TO",0,"int",4,0);this.setVCMap("AV33TFReloj_Nom","vTFRELOJ_NOM",0,"svchar",50,0);this.setVCMap("AV34TFReloj_Nom_Sel","vTFRELOJ_NOM_SEL",0,"svchar",50,0);this.setVCMap("AV35TFReloj_Dsc","vTFRELOJ_DSC",0,"svchar",100,0);this.setVCMap("AV36TFReloj_Dsc_Sel","vTFRELOJ_DSC_SEL",0,"svchar",100,0);this.setVCMap("AV37TFReloj_IP","vTFRELOJ_IP",0,"svchar",50,0);this.setVCMap("AV38TFReloj_IP_Sel","vTFRELOJ_IP_SEL",0,"svchar",50,0);this.setVCMap("AV39TFReloj_Puerto","vTFRELOJ_PUERTO",0,"svchar",50,0);this.setVCMap("AV40TFReloj_Puerto_Sel","vTFRELOJ_PUERTO_SEL",0,"svchar",50,0);this.setVCMap("AV41TFReloj_Estado","vTFRELOJ_ESTADO",0,"int",1,0);this.setVCMap("AV42TFReloj_Estado_To","vTFRELOJ_ESTADO_TO",0,"int",1,0);this.setVCMap("AV13OrderedBy","vORDEREDBY",0,"int",4,0);this.setVCMap("AV14OrderedDsc","vORDEREDDSC",0,"boolean",4,0);this.setVCMap("AV53Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV31TFRelojID","vTFRELOJID",0,"int",4,0);this.setVCMap("AV32TFRelojID_To","vTFRELOJID_TO",0,"int",4,0);this.setVCMap("AV33TFReloj_Nom","vTFRELOJ_NOM",0,"svchar",50,0);this.setVCMap("AV34TFReloj_Nom_Sel","vTFRELOJ_NOM_SEL",0,"svchar",50,0);this.setVCMap("AV35TFReloj_Dsc","vTFRELOJ_DSC",0,"svchar",100,0);this.setVCMap("AV36TFReloj_Dsc_Sel","vTFRELOJ_DSC_SEL",0,"svchar",100,0);this.setVCMap("AV37TFReloj_IP","vTFRELOJ_IP",0,"svchar",50,0);this.setVCMap("AV38TFReloj_IP_Sel","vTFRELOJ_IP_SEL",0,"svchar",50,0);this.setVCMap("AV39TFReloj_Puerto","vTFRELOJ_PUERTO",0,"svchar",50,0);this.setVCMap("AV40TFReloj_Puerto_Sel","vTFRELOJ_PUERTO_SEL",0,"svchar",50,0);this.setVCMap("AV41TFReloj_Estado","vTFRELOJ_ESTADO",0,"int",1,0);this.setVCMap("AV42TFReloj_Estado_To","vTFRELOJ_ESTADO_TO",0,"int",1,0);this.setVCMap("AV13OrderedBy","vORDEREDBY",0,"int",4,0);this.setVCMap("AV14OrderedDsc","vORDEREDDSC",0,"boolean",4,0);i.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});i.addRefreshingVar({rfrVar:"AV53Pgmname"});i.addRefreshingVar({rfrVar:"AV31TFRelojID"});i.addRefreshingVar({rfrVar:"AV32TFRelojID_To"});i.addRefreshingVar({rfrVar:"AV33TFReloj_Nom"});i.addRefreshingVar({rfrVar:"AV34TFReloj_Nom_Sel"});i.addRefreshingVar({rfrVar:"AV35TFReloj_Dsc"});i.addRefreshingVar({rfrVar:"AV36TFReloj_Dsc_Sel"});i.addRefreshingVar({rfrVar:"AV37TFReloj_IP"});i.addRefreshingVar({rfrVar:"AV38TFReloj_IP_Sel"});i.addRefreshingVar({rfrVar:"AV39TFReloj_Puerto"});i.addRefreshingVar({rfrVar:"AV40TFReloj_Puerto_Sel"});i.addRefreshingVar({rfrVar:"AV41TFReloj_Estado"});i.addRefreshingVar({rfrVar:"AV42TFReloj_Estado_To"});i.addRefreshingVar({rfrVar:"AV13OrderedBy"});i.addRefreshingVar({rfrVar:"AV14OrderedDsc"});i.addRefreshingParm({rfrVar:"AV53Pgmname"});i.addRefreshingParm({rfrVar:"AV31TFRelojID"});i.addRefreshingParm({rfrVar:"AV32TFRelojID_To"});i.addRefreshingParm({rfrVar:"AV33TFReloj_Nom"});i.addRefreshingParm({rfrVar:"AV34TFReloj_Nom_Sel"});i.addRefreshingParm({rfrVar:"AV35TFReloj_Dsc"});i.addRefreshingParm({rfrVar:"AV36TFReloj_Dsc_Sel"});i.addRefreshingParm({rfrVar:"AV37TFReloj_IP"});i.addRefreshingParm({rfrVar:"AV38TFReloj_IP_Sel"});i.addRefreshingParm({rfrVar:"AV39TFReloj_Puerto"});i.addRefreshingParm({rfrVar:"AV40TFReloj_Puerto_Sel"});i.addRefreshingParm({rfrVar:"AV41TFReloj_Estado"});i.addRefreshingParm({rfrVar:"AV42TFReloj_Estado_To"});i.addRefreshingParm({rfrVar:"AV13OrderedBy"});i.addRefreshingParm({rfrVar:"AV14OrderedDsc"});this.Initialize();this.setSDTMapping("WWPBaseObjects\\DVB_SDTDropDownOptionsTitleSettingsIcons",{Default_fi:{extr:"def"},Filtered_fi:{extr:"fil"},SortedASC_fi:{extr:"asc"},SortedDSC_fi:{extr:"dsc"},FilteredSortedASC_fi:{extr:"fasc"},FilteredSortedDSC_fi:{extr:"fdsc"},OptionSortASC_fi:{extr:"osasc"},OptionSortDSC_fi:{extr:"osdsc"},OptionApplyFilter_fi:{extr:"app"},OptionFilteringData_fi:{extr:"fildata"},OptionCleanFilters_fi:{extr:"cle"},SelectedOption_fi:{extr:"selo"},MultiselOption_fi:{extr:"mul"},MultiselSelOption_fi:{extr:"muls"},TreeviewCollapse_fi:{extr:"tcol"},TreeviewExpand_fi:{extr:"texp"},FixLeft_fi:{extr:"fixl"},FixRight_fi:{extr:"fixr"}});this.setSDTMapping("WWPBaseObjects\\WWPTransactionContext",{Attributes:{sdt:"WWPBaseObjects\\WWPTransactionContext.Attribute"}});this.setSDTMapping("WWPBaseObjects\\WWPGridState",{FilterValues:{sdt:"WWPBaseObjects\\WWPGridState.FilterValue"},DynamicFilters:{sdt:"WWPBaseObjects\\WWPGridState.DynamicFilter"}});this.setSDTMapping("WWPBaseObjects\\WWPGridState.DynamicFilter",{Dsc:{extr:"d"}})});gx.wi(function(){gx.createParentObj(this.reloj_interface.relojww)})