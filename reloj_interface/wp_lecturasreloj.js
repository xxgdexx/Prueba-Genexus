gx.evt.autoSkip=!1;gx.define("reloj_interface.wp_lecturasreloj",!1,function(){var n,u,i,t,r;this.ServerClass="reloj_interface.wp_lecturasreloj";this.PackageName="GeneXus.Programs";this.ServerFullClass="reloj_interface.wp_lecturasreloj.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV23message=gx.fn.getControlValue("vMESSAGE")};this.e117e2_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEPAGE",!1,null,!0,!0)};this.e127e2_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!1,null,!0,!0)};this.e137e2_client=function(){return this.executeServerEvent("'DOGRABAR'",!1,null,!1,!1)};this.e177e2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e187e2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,33,34,35,36,37,38,39,41,42,43,44,45,46,47];this.GXLastCtrlId=47;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",32,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"reloj_interface.wp_lecturasreloj",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);u=this.GridContainer;u.addSingleLineEdit(2468,33,"COD_EMPRELOJ","Codigo ID","","Cod_EmpReloj","svchar",0,"px",20,20,"left",null,[],2468,"Cod_EmpReloj",!0,0,!1,!1,"Attribute",1,"WWColumn");u.addSingleLineEdit(2380,34,"NOMBRE","Nombre","","Nombre","svchar",0,"px",25,25,"left",null,[],2380,"Nombre",!0,0,!1,!1,"Attribute",1,"WWColumn");u.addSingleLineEdit(2470,35,"MARCACION","Fecha y Hora","","Marcacion","svchar",0,"px",30,30,"left",null,[],2470,"Marcacion",!0,0,!1,!1,"Attribute",1,"WWColumn");u.addSingleLineEdit(2471,36,"FEC_MARCACION","Fecha","","Fec_Marcacion","svchar",0,"px",30,30,"left",null,[],2471,"Fec_Marcacion",!0,0,!1,!1,"Attribute",1,"WWColumn");u.addSingleLineEdit(2472,37,"HOR_MARCACION","Hora","","Hor_Marcacion","svchar",0,"px",30,30,"left",null,[],2472,"Hor_Marcacion",!0,0,!1,!1,"Attribute",1,"WWColumn");this.GridContainer.emptyText="";this.setGrid(u);this.DVPANEL_TABLE2Container=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_TABLE2Container","Dvpanel_table2","DVPANEL_TABLE2");i=this.DVPANEL_TABLE2Container;i.setProp("Class","Class","","char");i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("Width","Width","100%","str");i.setProp("Height","Height","100","str");i.setProp("AutoWidth","Autowidth",!1,"bool");i.setProp("AutoHeight","Autoheight",!0,"bool");i.setProp("Cls","Cls","PanelFilled Panel_BaseColor","str");i.setProp("ShowHeader","Showheader",!0,"bool");i.setProp("Title","Title","Busqueda de Lecturas","str");i.setProp("Collapsible","Collapsible",!1,"bool");i.setProp("Collapsed","Collapsed",!1,"bool");i.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");i.setProp("IconPosition","Iconposition","Right","str");i.setProp("AutoScroll","Autoscroll",!1,"bool");i.setProp("Visible","Visible",!0,"bool");i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});this.setUserControl(i);this.GRIDPAGINATIONBARContainer=gx.uc.getNew(this,40,24,"DVelop_DVPaginationBar","GRIDPAGINATIONBARContainer","Gridpaginationbar","GRIDPAGINATIONBAR");t=this.GRIDPAGINATIONBARContainer;t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Class","Class","PaginationBar","str");t.setProp("ShowFirst","Showfirst",!1,"bool");t.setProp("ShowPrevious","Showprevious",!0,"bool");t.setProp("ShowNext","Shownext",!0,"bool");t.setProp("ShowLast","Showlast",!1,"bool");t.setProp("PagesToShow","Pagestoshow",5,"num");t.setProp("PagingButtonsPosition","Pagingbuttonsposition","Right","str");t.setProp("PagingCaptionPosition","Pagingcaptionposition","Left","str");t.setProp("EmptyGridClass","Emptygridclass","PaginationBarEmptyGrid","str");t.setProp("SelectedPage","Selectedpage","","char");t.setProp("RowsPerPageSelector","Rowsperpageselector",!0,"bool");t.setDynProp("RowsPerPageSelectedValue","Rowsperpageselectedvalue",10,"num");t.setProp("RowsPerPageOptions","Rowsperpageoptions","5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50","str");t.setProp("First","First","First","str");t.setProp("Previous","Previous","WWP_PagingPreviousCaption","str");t.setProp("Next","Next","WWP_PagingNextCaption","str");t.setProp("Last","Last","Last","str");t.setProp("Caption","Caption","Página <CURRENT_PAGE> de <TOTAL_PAGES>","str");t.setProp("EmptyGridCaption","Emptygridcaption","WWP_PagingEmptyGridCaption","str");t.setProp("RowsPerPageCaption","Rowsperpagecaption","WWP_PagingRowsPerPage","str");t.addV2CFunction("AV17GridCurrentPage","vGRIDCURRENTPAGE","SetCurrentPage");t.addC2VFunction(function(t){t.ParentObject.AV17GridCurrentPage=t.GetCurrentPage();n[44].c2v()});t.addV2CFunction("AV18GridPageCount","vGRIDPAGECOUNT","SetPageCount");t.addC2VFunction(function(n){n.ParentObject.AV18GridPageCount=n.GetPageCount();gx.fn.setControlValue("vGRIDPAGECOUNT",n.ParentObject.AV18GridPageCount)});t.setProp("RecordCount","Recordcount","","str");t.setProp("Page","Page","","str");t.addV2CFunction("AV19GridAppliedFilters","vGRIDAPPLIEDFILTERS","SetAppliedFilters");t.addC2VFunction(function(n){n.ParentObject.AV19GridAppliedFilters=n.GetAppliedFilters();gx.fn.setControlValue("vGRIDAPPLIEDFILTERS",n.ParentObject.AV19GridAppliedFilters)});t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("ChangePage",this.e117e2_client);t.addEventHandler("ChangeRowsPerPage",this.e127e2_client);this.setUserControl(t);this.GRID_EMPOWERERContainer=gx.uc.getNew(this,48,24,"WWP_GridEmpowerer","GRID_EMPOWERERContainer","Grid_empowerer","GRID_EMPOWERER");r=this.GRID_EMPOWERERContainer;r.setProp("Class","Class","","char");r.setProp("Enabled","Enabled",!0,"boolean");r.setDynProp("GridInternalName","Gridinternalname","","char");r.setProp("HasCategories","Hascategories",!1,"bool");r.setProp("InfiniteScrolling","Infinitescrolling","False","str");r.setProp("HasTitleSettings","Hastitlesettings",!1,"bool");r.setProp("HasColumnsSelector","Hascolumnsselector",!1,"bool");r.setProp("HasRowGroups","Hasrowgroups",!1,"bool");r.setProp("FixedColumns","Fixedcolumns","","str");r.setProp("PopoversInGrid","Popoversingrid","","str");r.setProp("Visible","Visible",!0,"bool");r.setC2ShowFunction(function(n){n.show()});this.setUserControl(r);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"TABLE2",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"ADVANCEDFILTERSCONTAINER",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.GridContainer],fld:"vNOMBRE",gxz:"ZV7Nombre",gxold:"OV7Nombre",gxvar:"AV7Nombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7Nombre=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7Nombre=n)},v2c:function(){gx.fn.setControlValue("vNOMBRE",gx.O.AV7Nombre,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7Nombre=this.val())},val:function(){return gx.fn.getControlValue("vNOMBRE")},nac:gx.falseFn};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"BTNGRABAR",grid:0,evt:"e137e2_client"};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"GRIDTABLEWITHPAGINATIONBAR",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[33]={id:33,lvl:2,type:"svchar",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:32,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COD_EMPRELOJ",gxz:"Z2468Cod_EmpReloj",gxold:"O2468Cod_EmpReloj",gxvar:"A2468Cod_EmpReloj",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A2468Cod_EmpReloj=n)},v2z:function(n){n!==undefined&&(gx.O.Z2468Cod_EmpReloj=n)},v2c:function(n){gx.fn.setGridControlValue("COD_EMPRELOJ",n||gx.fn.currentGridRowImpl(32),gx.O.A2468Cod_EmpReloj,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A2468Cod_EmpReloj=this.val(n))},val:function(n){return gx.fn.getGridControlValue("COD_EMPRELOJ",n||gx.fn.currentGridRowImpl(32))},nac:gx.falseFn};n[34]={id:34,lvl:2,type:"svchar",len:25,dec:0,sign:!1,ro:1,isacc:0,grid:32,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"NOMBRE",gxz:"Z2380Nombre",gxold:"O2380Nombre",gxvar:"A2380Nombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A2380Nombre=n)},v2z:function(n){n!==undefined&&(gx.O.Z2380Nombre=n)},v2c:function(n){gx.fn.setGridControlValue("NOMBRE",n||gx.fn.currentGridRowImpl(32),gx.O.A2380Nombre,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A2380Nombre=this.val(n))},val:function(n){return gx.fn.getGridControlValue("NOMBRE",n||gx.fn.currentGridRowImpl(32))},nac:gx.falseFn};n[35]={id:35,lvl:2,type:"svchar",len:30,dec:0,sign:!1,ro:1,isacc:0,grid:32,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MARCACION",gxz:"Z2470Marcacion",gxold:"O2470Marcacion",gxvar:"A2470Marcacion",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A2470Marcacion=n)},v2z:function(n){n!==undefined&&(gx.O.Z2470Marcacion=n)},v2c:function(n){gx.fn.setGridControlValue("MARCACION",n||gx.fn.currentGridRowImpl(32),gx.O.A2470Marcacion,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A2470Marcacion=this.val(n))},val:function(n){return gx.fn.getGridControlValue("MARCACION",n||gx.fn.currentGridRowImpl(32))},nac:gx.falseFn};n[36]={id:36,lvl:2,type:"svchar",len:30,dec:0,sign:!1,ro:1,isacc:0,grid:32,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FEC_MARCACION",gxz:"Z2471Fec_Marcacion",gxold:"O2471Fec_Marcacion",gxvar:"A2471Fec_Marcacion",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A2471Fec_Marcacion=n)},v2z:function(n){n!==undefined&&(gx.O.Z2471Fec_Marcacion=n)},v2c:function(n){gx.fn.setGridControlValue("FEC_MARCACION",n||gx.fn.currentGridRowImpl(32),gx.O.A2471Fec_Marcacion,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A2471Fec_Marcacion=this.val(n))},val:function(n){return gx.fn.getGridControlValue("FEC_MARCACION",n||gx.fn.currentGridRowImpl(32))},nac:gx.falseFn};n[37]={id:37,lvl:2,type:"svchar",len:30,dec:0,sign:!1,ro:1,isacc:0,grid:32,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"HOR_MARCACION",gxz:"Z2472Hor_Marcacion",gxold:"O2472Hor_Marcacion",gxvar:"A2472Hor_Marcacion",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A2472Hor_Marcacion=n)},v2z:function(n){n!==undefined&&(gx.O.Z2472Hor_Marcacion=n)},v2c:function(n){gx.fn.setGridControlValue("HOR_MARCACION",n||gx.fn.currentGridRowImpl(32),gx.O.A2472Hor_Marcacion,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A2472Hor_Marcacion=this.val(n))},val:function(n){return gx.fn.getGridControlValue("HOR_MARCACION",n||gx.fn.currentGridRowImpl(32))},nac:gx.falseFn};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[44]={id:44,lvl:0,type:"int",len:10,dec:0,sign:!1,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vGRIDCURRENTPAGE",gxz:"ZV17GridCurrentPage",gxold:"OV17GridCurrentPage",gxvar:"AV17GridCurrentPage",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV17GridCurrentPage=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV17GridCurrentPage=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vGRIDCURRENTPAGE",gx.O.AV17GridCurrentPage,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV17GridCurrentPage=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vGRIDCURRENTPAGE",",")},nac:gx.falseFn};n[45]={id:45,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vANIO",gxz:"ZV12Anio",gxold:"OV12Anio",gxvar:"AV12Anio",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV12Anio=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV12Anio=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vANIO",gx.O.AV12Anio,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV12Anio=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vANIO",",")},nac:gx.falseFn};n[46]={id:46,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vMES",gxz:"ZV13Mes",gxold:"OV13Mes",gxvar:"AV13Mes",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV13Mes=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV13Mes=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vMES",gx.O.AV13Mes,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV13Mes=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vMES",",")},nac:gx.falseFn};n[47]={id:47,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vHORA",gxz:"ZV22Hora",gxold:"OV22Hora",gxvar:"AV22Hora",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV22Hora=n)},v2z:function(n){n!==undefined&&(gx.O.ZV22Hora=n)},v2c:function(){gx.fn.setControlValue("vHORA",gx.O.AV22Hora,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV22Hora=this.val())},val:function(){return gx.fn.getControlValue("vHORA")},nac:gx.falseFn};this.AV7Nombre="";this.ZV7Nombre="";this.OV7Nombre="";this.Z2468Cod_EmpReloj="";this.O2468Cod_EmpReloj="";this.Z2380Nombre="";this.O2380Nombre="";this.Z2470Marcacion="";this.O2470Marcacion="";this.Z2471Fec_Marcacion="";this.O2471Fec_Marcacion="";this.Z2472Hor_Marcacion="";this.O2472Hor_Marcacion="";this.AV17GridCurrentPage=0;this.ZV17GridCurrentPage=0;this.OV17GridCurrentPage=0;this.AV12Anio=0;this.ZV12Anio=0;this.OV12Anio=0;this.AV13Mes=0;this.ZV13Mes=0;this.OV13Mes=0;this.AV22Hora="";this.ZV22Hora="";this.OV22Hora="";this.AV7Nombre="";this.AV17GridCurrentPage=0;this.AV12Anio=0;this.AV13Mes=0;this.AV22Hora="";this.A2468Cod_EmpReloj="";this.A2380Nombre="";this.A2470Marcacion="";this.A2471Fec_Marcacion="";this.A2472Hor_Marcacion="";this.AV23message="";this.Events={e117e2_client:["GRIDPAGINATIONBAR.CHANGEPAGE",!0],e127e2_client:["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!0],e137e2_client:["'DOGRABAR'",!0],e177e2_client:["ENTER",!0],e187e2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV7Nombre",fld:"vNOMBRE",pic:""}],[]];this.EvtParms["GRID.LOAD"]=[[],[]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV7Nombre",fld:"vNOMBRE",pic:""},{av:"this.GRIDPAGINATIONBARContainer.SelectedPage",ctrl:"GRIDPAGINATIONBAR",prop:"SelectedPage"},{av:"AV17GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"}],[{av:"AV17GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"}]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV7Nombre",fld:"vNOMBRE",pic:""},{av:"this.GRIDPAGINATIONBARContainer.RowsPerPageSelectedValue",ctrl:"GRIDPAGINATIONBAR",prop:"RowsPerPageSelectedValue"}],[{ctrl:"GRID",prop:"Rows"},{av:"AV17GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"}]];this.EvtParms["'DOGRABAR'"]=[[{av:"AV23message",fld:"vMESSAGE",pic:""}],[{av:"AV23message",fld:"vMESSAGE",pic:""}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV23message","vMESSAGE",0,"svchar",40,0);u.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});u.addRefreshingVar(this.GXValidFnc[24]);u.addRefreshingParm(this.GXValidFnc[24]);this.Initialize()});gx.wi(function(){gx.createParentObj(this.reloj_interface.wp_lecturasreloj)})