gx.evt.autoSkip=!1;gx.define("almacen.r_consultastockactual",!1,function(){var n,r,i,t,u;this.ServerClass="almacen.r_consultastockactual";this.PackageName="GeneXus.Programs";this.ServerFullClass="almacen.r_consultastockactual.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV31cLinCod=gx.fn.getIntegerValue("vCLINCOD",",");this.AV33cSubLCod=gx.fn.getIntegerValue("vCSUBLCOD",",");this.A28ProdCod=gx.fn.getControlValue("PRODCOD")};this.e112x2_client=function(){return this.executeServerEvent("GRID2PAGINATIONBAR.CHANGEPAGE",!1,null,!0,!0)};this.e122x2_client=function(){return this.executeServerEvent("GRID2PAGINATIONBAR.CHANGEROWSPERPAGE",!1,null,!0,!0)};this.e132x2_client=function(){return this.executeServerEvent("'DOBTNEXCEL'",!1,null,!1,!1)};this.e142x2_client=function(){return this.executeServerEvent("'DOBTNSALIR'",!1,null,!1,!1)};this.e152x2_client=function(){return this.executeServerEvent("'DOBTNBUSCAR'",!0,null,!1,!1)};this.e192x2_client=function(){return this.executeServerEvent("VCOMEN.CLICK",!0,arguments[0],!1,!1)};this.e202x2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e212x2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,35,36,38,40,41,42,43,44,45,46,48,49,50,51,52,53,54,56,57,58,59,61];this.GXLastCtrlId=61;this.Grid2Container=new gx.grid.grid(this,2,"WbpLvl2",47,"Grid2","Grid2","Grid2Container",this.CmpContext,this.IsMasterPage,"almacen.r_consultastockactual",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);r=this.Grid2Container;r.addSingleLineEdit("Almdsc",48,"vALMDSC","Almacen","","AlmDsc","int",0,"px",4,4,"right",null,[],"Almdsc","AlmDsc",!0,0,!1,!1,"Attribute",1,"WWColumn");r.addSingleLineEdit("Prodcode",49,"vPRODCODE","Codigo","","ProdCode","int",0,"px",4,4,"right",null,[],"Prodcode","ProdCode",!0,0,!1,!1,"Attribute",1,"WWColumn");r.addSingleLineEdit("Proddsce",50,"vPRODDSCE","Producto","","ProdDsce","int",0,"px",4,4,"right",null,[],"Proddsce","ProdDsce",!0,0,!1,!1,"Attribute",1,"WWColumn");r.addSingleLineEdit("Stkact",51,"vSTKACT","Stock","","StkAct","decimal",0,"px",17,17,"right",null,[],"Stkact","StkAct",!0,4,!1,!1,"Attribute",1,"WWColumn");r.addBitmap("&Comen","vCOMEN",52,36,"px",17,"px","e192x2_client","","","Attribute","WWColumn");this.Grid2Container.emptyText="";this.setGrid(r);this.DVPANEL_PANEL1Container=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_PANEL1Container","Dvpanel_panel1","DVPANEL_PANEL1");i=this.DVPANEL_PANEL1Container;i.setProp("Class","Class","","char");i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("Width","Width","100%","str");i.setProp("Height","Height","100","str");i.setProp("AutoWidth","Autowidth",!1,"bool");i.setProp("AutoHeight","Autoheight",!0,"bool");i.setProp("Cls","Cls","PanelFilled Panel_BaseColor","str");i.setProp("ShowHeader","Showheader",!0,"bool");i.setProp("Title","Title","Reporte de Consulta de Stock Actual","str");i.setProp("Collapsible","Collapsible",!0,"bool");i.setProp("Collapsed","Collapsed",!1,"bool");i.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");i.setProp("IconPosition","Iconposition","Right","str");i.setProp("AutoScroll","Autoscroll",!1,"bool");i.setProp("Visible","Visible",!0,"bool");i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});this.setUserControl(i);this.GRID2PAGINATIONBARContainer=gx.uc.getNew(this,55,36,"DVelop_DVPaginationBar","GRID2PAGINATIONBARContainer","Grid2paginationbar","GRID2PAGINATIONBAR");t=this.GRID2PAGINATIONBARContainer;t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Class","Class","PaginationBar","str");t.setProp("ShowFirst","Showfirst",!1,"bool");t.setProp("ShowPrevious","Showprevious",!0,"bool");t.setProp("ShowNext","Shownext",!0,"bool");t.setProp("ShowLast","Showlast",!1,"bool");t.setProp("PagesToShow","Pagestoshow",5,"num");t.setProp("PagingButtonsPosition","Pagingbuttonsposition","Right","str");t.setProp("PagingCaptionPosition","Pagingcaptionposition","Left","str");t.setProp("EmptyGridClass","Emptygridclass","PaginationBarEmptyGrid","str");t.setProp("SelectedPage","Selectedpage","","char");t.setProp("RowsPerPageSelector","Rowsperpageselector",!0,"bool");t.setDynProp("RowsPerPageSelectedValue","Rowsperpageselectedvalue",10,"num");t.setProp("RowsPerPageOptions","Rowsperpageoptions","5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50","str");t.setProp("First","First","First","str");t.setProp("Previous","Previous","WWP_PagingPreviousCaption","str");t.setProp("Next","Next","WWP_PagingNextCaption","str");t.setProp("Last","Last","Last","str");t.setProp("Caption","Caption","Página <CURRENT_PAGE> de <TOTAL_PAGES>","str");t.setProp("EmptyGridCaption","Emptygridcaption","WWP_PagingEmptyGridCaption","str");t.setProp("RowsPerPageCaption","Rowsperpagecaption","WWP_PagingRowsPerPage","str");t.addV2CFunction("AV34Grid2CurrentPage","vGRID2CURRENTPAGE","SetCurrentPage");t.addC2VFunction(function(t){t.ParentObject.AV34Grid2CurrentPage=t.GetCurrentPage();n[59].c2v()});t.addV2CFunction("AV35Grid2PageCount","vGRID2PAGECOUNT","SetPageCount");t.addC2VFunction(function(n){n.ParentObject.AV35Grid2PageCount=n.GetPageCount();gx.fn.setControlValue("vGRID2PAGECOUNT",n.ParentObject.AV35Grid2PageCount)});t.setProp("RecordCount","Recordcount","","str");t.setProp("Page","Page","","str");t.addV2CFunction("AV36Grid2AppliedFilters","vGRID2APPLIEDFILTERS","SetAppliedFilters");t.addC2VFunction(function(n){n.ParentObject.AV36Grid2AppliedFilters=n.GetAppliedFilters();gx.fn.setControlValue("vGRID2APPLIEDFILTERS",n.ParentObject.AV36Grid2AppliedFilters)});t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("ChangePage",this.e112x2_client);t.addEventHandler("ChangeRowsPerPage",this.e122x2_client);this.setUserControl(t);this.GRID2_EMPOWERERContainer=gx.uc.getNew(this,60,36,"WWP_GridEmpowerer","GRID2_EMPOWERERContainer","Grid2_empowerer","GRID2_EMPOWERER");u=this.GRID2_EMPOWERERContainer;u.setProp("Class","Class","","char");u.setProp("Enabled","Enabled",!0,"boolean");u.setDynProp("GridInternalName","Gridinternalname","","char");u.setProp("HasCategories","Hascategories",!1,"bool");u.setProp("InfiniteScrolling","Infinitescrolling","False","str");u.setProp("HasTitleSettings","Hastitlesettings",!1,"bool");u.setProp("HasColumnsSelector","Hascolumnsselector",!1,"bool");u.setProp("HasRowGroups","Hasrowgroups",!1,"bool");u.setProp("FixedColumns","Fixedcolumns","","str");u.setProp("PopoversInGrid","Popoversingrid","","str");u.setProp("Visible","Visible",!0,"bool");u.setC2ShowFunction(function(n){n.show()});this.setUserControl(u);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"PANEL1",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"BTNBTNEXCEL",grid:0,evt:"e132x2_client"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"BTNBTNSALIR",grid:0,evt:"e142x2_client"};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"TABLESPLITTEDPRODCOD",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"TEXTBLOCKPRODCOD",format:0,grid:0,ctrltype:"textblock"};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"TABLEMERGEDPRODCOD",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,lvl:0,type:"char",len:15,dec:0,sign:!1,pic:"@!",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid2Container],fld:"vPRODCOD",gxz:"ZV15ProdCod",gxold:"OV15ProdCod",gxvar:"AV15ProdCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV15ProdCod=n)},v2z:function(n){n!==undefined&&(gx.O.ZV15ProdCod=n)},v2c:function(){gx.fn.setControlValue("vPRODCOD",gx.O.AV15ProdCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV15ProdCod=this.val())},val:function(){return gx.fn.getControlValue("vPRODCOD")},nac:gx.falseFn};n[38]={id:38,fld:"BTNBUSCAR",grid:0,evt:"e152x2_client"};n[40]={id:40,fld:"",grid:0};n[41]={id:41,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid2Container],fld:"vPRODDSC",gxz:"ZV16ProdDsc",gxold:"OV16ProdDsc",gxvar:"AV16ProdDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV16ProdDsc=n)},v2z:function(n){n!==undefined&&(gx.O.ZV16ProdDsc=n)},v2c:function(){gx.fn.setControlValue("vPRODDSC",gx.O.AV16ProdDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV16ProdDsc=this.val())},val:function(){return gx.fn.getControlValue("vPRODDSC")},nac:gx.falseFn};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"GRID2TABLEWITHPAGINATIONBAR",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[48]={id:48,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,isacc:0,grid:47,gxgrid:this.Grid2Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vALMDSC",gxz:"ZV22AlmDsc",gxold:"OV22AlmDsc",gxvar:"AV22AlmDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV22AlmDsc=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV22AlmDsc=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("vALMDSC",n||gx.fn.currentGridRowImpl(47),gx.O.AV22AlmDsc,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV22AlmDsc=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vALMDSC",n||gx.fn.currentGridRowImpl(47),",")},nac:gx.falseFn};n[49]={id:49,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,isacc:0,grid:47,gxgrid:this.Grid2Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPRODCODE",gxz:"ZV23ProdCode",gxold:"OV23ProdCode",gxvar:"AV23ProdCode",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV23ProdCode=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV23ProdCode=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("vPRODCODE",n||gx.fn.currentGridRowImpl(47),gx.O.AV23ProdCode,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV23ProdCode=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vPRODCODE",n||gx.fn.currentGridRowImpl(47),",")},nac:gx.falseFn};n[50]={id:50,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,isacc:0,grid:47,gxgrid:this.Grid2Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPRODDSCE",gxz:"ZV24ProdDsce",gxold:"OV24ProdDsce",gxvar:"AV24ProdDsce",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV24ProdDsce=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV24ProdDsce=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("vPRODDSCE",n||gx.fn.currentGridRowImpl(47),gx.O.AV24ProdDsce,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV24ProdDsce=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vPRODDSCE",n||gx.fn.currentGridRowImpl(47),",")},nac:gx.falseFn};n[51]={id:51,lvl:2,type:"decimal",len:15,dec:4,sign:!0,pic:"ZZZZ,ZZZ,ZZ9.9999",ro:0,isacc:0,grid:47,gxgrid:this.Grid2Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSTKACT",gxz:"ZV25StkAct",gxold:"OV25StkAct",gxvar:"AV25StkAct",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV25StkAct=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.ZV25StkAct=gx.fn.toDecimalValue(n,",","."))},v2c:function(n){gx.fn.setGridDecimalValue("vSTKACT",n||gx.fn.currentGridRowImpl(47),gx.O.AV25StkAct,4,".")},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV25StkAct=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("vSTKACT",n||gx.fn.currentGridRowImpl(47),",",".")},nac:gx.falseFn};n[52]={id:52,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:47,gxgrid:this.Grid2Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCOMEN",gxz:"ZV32Comen",gxold:"OV32Comen",gxvar:"AV32Comen",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV32Comen=n)},v2z:function(n){n!==undefined&&(gx.O.ZV32Comen=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vCOMEN",n||gx.fn.currentGridRowImpl(47),gx.O.AV32Comen,gx.O.AV41Comen_GXI)},c2v:function(n){gx.O.AV41Comen_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV32Comen=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vCOMEN",n||gx.fn.currentGridRowImpl(47))},val_GXI:function(n){return gx.fn.getGridControlValue("vCOMEN_GXI",n||gx.fn.currentGridRowImpl(47))},gxvar_GXI:"AV41Comen_GXI",nac:gx.falseFn,evt:"e192x2_client"};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[59]={id:59,lvl:0,type:"int",len:10,dec:0,sign:!1,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vGRID2CURRENTPAGE",gxz:"ZV34Grid2CurrentPage",gxold:"OV34Grid2CurrentPage",gxvar:"AV34Grid2CurrentPage",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV34Grid2CurrentPage=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV34Grid2CurrentPage=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vGRID2CURRENTPAGE",gx.O.AV34Grid2CurrentPage,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV34Grid2CurrentPage=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vGRID2CURRENTPAGE",",")},nac:gx.falseFn};n[61]={id:61,fld:"PROMPT_PRODCOD_PRODDSC",grid:0};this.AV15ProdCod="";this.ZV15ProdCod="";this.OV15ProdCod="";this.AV16ProdDsc="";this.ZV16ProdDsc="";this.OV16ProdDsc="";this.ZV22AlmDsc=0;this.OV22AlmDsc=0;this.ZV23ProdCode=0;this.OV23ProdCode=0;this.ZV24ProdDsce=0;this.OV24ProdDsce=0;this.ZV25StkAct=0;this.OV25StkAct=0;this.ZV32Comen="";this.OV32Comen="";this.AV34Grid2CurrentPage=0;this.ZV34Grid2CurrentPage=0;this.OV34Grid2CurrentPage=0;this.AV15ProdCod="";this.AV16ProdDsc="";this.AV34Grid2CurrentPage=0;this.A55ProdDsc="";this.A28ProdCod="";this.AV22AlmDsc=0;this.AV23ProdCode=0;this.AV24ProdDsce=0;this.AV25StkAct=0;this.AV32Comen="";this.AV31cLinCod=0;this.AV33cSubLCod=0;this.Events={e112x2_client:["GRID2PAGINATIONBAR.CHANGEPAGE",!0],e122x2_client:["GRID2PAGINATIONBAR.CHANGEROWSPERPAGE",!0],e132x2_client:["'DOBTNEXCEL'",!0],e142x2_client:["'DOBTNSALIR'",!0],e152x2_client:["'DOBTNBUSCAR'",!0],e192x2_client:["VCOMEN.CLICK",!0],e202x2_client:["ENTER",!0],e212x2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID2_nFirstRecordOnPage"},{av:"GRID2_nEOF"},{ctrl:"GRID2",prop:"Rows"},{av:"AV15ProdCod",fld:"vPRODCOD",pic:"@!"},{av:"AV16ProdDsc",fld:"vPRODDSC",pic:""},{av:"AV32Comen",fld:"vCOMEN",pic:""}],[]];this.EvtParms["GRID2.LOAD"]=[[],[]];this.EvtParms["GRID2PAGINATIONBAR.CHANGEPAGE"]=[[{av:"GRID2_nFirstRecordOnPage"},{av:"GRID2_nEOF"},{ctrl:"GRID2",prop:"Rows"},{av:"AV15ProdCod",fld:"vPRODCOD",pic:"@!"},{av:"AV16ProdDsc",fld:"vPRODDSC",pic:""},{av:"AV32Comen",fld:"vCOMEN",pic:""},{av:"this.GRID2PAGINATIONBARContainer.SelectedPage",ctrl:"GRID2PAGINATIONBAR",prop:"SelectedPage"},{av:"AV34Grid2CurrentPage",fld:"vGRID2CURRENTPAGE",pic:"ZZZZZZZZZ9"}],[{av:"AV34Grid2CurrentPage",fld:"vGRID2CURRENTPAGE",pic:"ZZZZZZZZZ9"}]];this.EvtParms["GRID2PAGINATIONBAR.CHANGEROWSPERPAGE"]=[[{av:"GRID2_nFirstRecordOnPage"},{av:"GRID2_nEOF"},{ctrl:"GRID2",prop:"Rows"},{av:"AV15ProdCod",fld:"vPRODCOD",pic:"@!"},{av:"AV16ProdDsc",fld:"vPRODDSC",pic:""},{av:"AV32Comen",fld:"vCOMEN",pic:""},{av:"this.GRID2PAGINATIONBARContainer.RowsPerPageSelectedValue",ctrl:"GRID2PAGINATIONBAR",prop:"RowsPerPageSelectedValue"}],[{ctrl:"GRID2",prop:"Rows"},{av:"AV34Grid2CurrentPage",fld:"vGRID2CURRENTPAGE",pic:"ZZZZZZZZZ9"}]];this.EvtParms["'DOBTNEXCEL'"]=[[{av:"GRID2_nFirstRecordOnPage"},{av:"GRID2_nEOF"},{ctrl:"GRID2",prop:"Rows"},{av:"AV15ProdCod",fld:"vPRODCOD",pic:"@!"},{av:"AV16ProdDsc",fld:"vPRODDSC",pic:""},{av:"AV32Comen",fld:"vCOMEN",pic:""},{av:"AV31cLinCod",fld:"vCLINCOD",pic:"ZZZZZ9"},{av:"AV33cSubLCod",fld:"vCSUBLCOD",pic:"ZZZZZ9"}],[{av:"AV33cSubLCod",fld:"vCSUBLCOD",pic:"ZZZZZ9"},{av:"AV31cLinCod",fld:"vCLINCOD",pic:"ZZZZZ9"},{av:"AV16ProdDsc",fld:"vPRODDSC",pic:""},{av:"AV15ProdCod",fld:"vPRODCOD",pic:"@!"}]];this.EvtParms["'DOBTNSALIR'"]=[[],[]];this.EvtParms["'DOBTNBUSCAR'"]=[[{av:"GRID2_nFirstRecordOnPage"},{av:"GRID2_nEOF"},{ctrl:"GRID2",prop:"Rows"},{av:"AV15ProdCod",fld:"vPRODCOD",pic:"@!"},{av:"AV16ProdDsc",fld:"vPRODDSC",pic:""},{av:"AV32Comen",fld:"vCOMEN",pic:""}],[{av:"AV16ProdDsc",fld:"vPRODDSC",pic:""},{av:"AV15ProdCod",fld:"vPRODCOD",pic:"@!"}]];this.EvtParms["VCOMEN.CLICK"]=[[{av:"A28ProdCod",fld:"PRODCOD",pic:"@!"}],[{av:"A28ProdCod",fld:"PRODCOD",pic:"@!"}]];this.EvtParms.ENTER=[[],[]];this.setPrompt("PROMPT_PRODCOD_PRODDSC",[36,41]);this.setVCMap("AV31cLinCod","vCLINCOD",0,"int",6,0);this.setVCMap("AV33cSubLCod","vCSUBLCOD",0,"int",6,0);this.setVCMap("A28ProdCod","PRODCOD",0,"char",15,0);r.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid2"});r.addRefreshingVar(this.GXValidFnc[36]);r.addRefreshingVar(this.GXValidFnc[41]);r.addRefreshingVar({rfrVar:"AV32Comen",rfrProp:"Value",gxAttId:"Comen"});r.addRefreshingParm(this.GXValidFnc[36]);r.addRefreshingParm(this.GXValidFnc[41]);r.addRefreshingParm({rfrVar:"AV32Comen",rfrProp:"Value",gxAttId:"Comen"});this.Initialize();this.setSDTMapping("WWPBaseObjects\\DVB_SDTComboData.Item",{Title:{extr:"T"},Children:{extr:"C"}})});gx.wi(function(){gx.createParentObj(this.almacen.r_consultastockactual)})