gx.evt.autoSkip=!1;gx.define("sgusuariosseries",!1,function(){var n,t;this.ServerClass="sgusuariosseries";this.PackageName="GeneXus.Programs";this.ServerFullClass="sgusuariosseries.aspx";this.setObjectType("trn");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Usucod=function(){return this.validSrvEvt("Valid_Usucod",0).then(function(n){return n}.closure(this))};this.Valid_Tipcod=function(){var n=gx.fn.currentGridRowImpl(34);return this.validSrvEvt("Valid_Tipcod",34).then(function(n){try{this.sMode34=this.Gx_mode;this.Gx_mode=gx.fn.getGridRowMode(34,34);this.standaloneModal1034();this.standaloneNotModal1034()}finally{this.Gx_mode=this.sMode34}return n}.closure(this))};this.Valid_Ususerdet=function(){var n=gx.fn.currentGridRowImpl(34);return this.validCliEvt("Valid_Ususerdet",34,function(){try{if(gx.fn.currentGridRowImpl(34)===0)return!0;var n=gx.util.balloon.getNew("USUSERDET",gx.fn.currentGridRowImpl(34));this.AnyError=0;this.sMode34=this.Gx_mode;this.Gx_mode=gx.fn.getGridRowMode(34,34);gx.fn.gridDuplicateKey(36)&&(n.setError(gx.text.format(gx.getMessage("GXM_1004"),"Tip","","","","","","","","")),this.AnyError=gx.num.trunc(1,0))}catch(t){}try{return(this.Gx_mode=this.sMode34,n==null)?!0:n.show()}catch(t){}return!0})};this.standaloneModal1034=function(){try{gx.text.compare(this.Gx_mode,"INS")!=0?gx.fn.setCtrlProperty("TIPCOD","Enabled",0):gx.fn.setCtrlProperty("TIPCOD","Enabled",1)}catch(n){}try{gx.text.compare(this.Gx_mode,"INS")!=0?gx.fn.setCtrlProperty("USUSERDET","Enabled",0):gx.fn.setCtrlProperty("USUSERDET","Enabled",1)}catch(n){}};this.standaloneNotModal1034=function(){};this.e111032_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e121032_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,29,30,31,32,33,35,36,37,38,39,40,41,42,43,44,45];this.GXLastCtrlId=45;this.Gridsgusuariosseries_tipContainer=new gx.grid.grid(this,34,"Tip",34,"Gridsgusuariosseries_tip","Gridsgusuariosseries_tip","Gridsgusuariosseries_tipContainer",this.CmpContext,this.IsMasterPage,"sgusuariosseries",[149,351],!1,1,!1,!0,5,!1,!1,!1,"",0,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Gridsgusuariosseries_tipContainer;t.addSingleLineEdit(149,35,"TIPCOD","Codigo T. Documento","","TipCod","char",0,"px",3,3,"left",null,[],149,"TipCod",!0,0,!1,!1,"Attribute",1,"");t.addSingleLineEdit(351,36,"USUSERDET","Serie","","UsuSerDet","char",0,"px",4,4,"left",null,[],351,"UsuSerDet",!0,0,!1,!1,"Attribute",1,"");this.Gridsgusuariosseries_tipContainer.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"TABLEMAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"BTN_FIRST",grid:0,evt:"e131032_client",std:"FIRST"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"BTN_PREVIOUS",grid:0,evt:"e141032_client",std:"PREVIOUS"};n[15]={id:15,fld:"",grid:0};n[16]={id:16,fld:"BTN_NEXT",grid:0,evt:"e151032_client",std:"NEXT"};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"BTN_LAST",grid:0,evt:"e161032_client",std:"LAST"};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"BTN_SELECT",grid:0,evt:"e171032_client",std:"SELECT"};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,lvl:0,type:"char",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Usucod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Gridsgusuariosseries_tipContainer],fld:"USUCOD",gxz:"Z348UsuCod",gxold:"O348UsuCod",gxvar:"A348UsuCod",ucs:[],op:[],ip:[28],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A348UsuCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z348UsuCod=n)},v2c:function(){gx.fn.setControlValue("USUCOD",gx.O.A348UsuCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A348UsuCod=this.val())},val:function(){return gx.fn.getControlValue("USUCOD")},nac:gx.falseFn};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"TITLETIP",format:0,grid:0,ctrltype:"textblock"};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[35]={id:35,lvl:34,type:"char",len:3,dec:0,sign:!1,ro:0,isacc:1,grid:34,gxgrid:this.Gridsgusuariosseries_tipContainer,fnc:this.Valid_Tipcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TIPCOD",gxz:"Z149TipCod",gxold:"O149TipCod",gxvar:"A149TipCod",ucs:[],op:[],ip:[35],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A149TipCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z149TipCod=n)},v2c:function(n){gx.fn.setGridControlValue("TIPCOD",n||gx.fn.currentGridRowImpl(34),gx.O.A149TipCod,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A149TipCod=this.val(n))},val:function(n){return gx.fn.getGridControlValue("TIPCOD",n||gx.fn.currentGridRowImpl(34))},nac:gx.falseFn};n[36]={id:36,lvl:34,type:"char",len:4,dec:0,sign:!1,ro:0,isacc:1,grid:34,gxgrid:this.Gridsgusuariosseries_tipContainer,fnc:this.Valid_Ususerdet,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUSERDET",gxz:"Z351UsuSerDet",gxold:"O351UsuSerDet",gxvar:"A351UsuSerDet",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A351UsuSerDet=n)},v2z:function(n){n!==undefined&&(gx.O.Z351UsuSerDet=n)},v2c:function(n){gx.fn.setGridControlValue("USUSERDET",n||gx.fn.currentGridRowImpl(34),gx.O.A351UsuSerDet,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A351UsuSerDet=this.val(n))},val:function(n){return gx.fn.getGridControlValue("USUSERDET",n||gx.fn.currentGridRowImpl(34))},nac:gx.falseFn};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"BTN_ENTER",grid:0,evt:"e111032_client",std:"ENTER"};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"BTN_CANCEL",grid:0,evt:"e121032_client"};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"BTN_DELETE",grid:0,evt:"e181032_client",std:"DELETE"};this.A348UsuCod="";this.Z348UsuCod="";this.O348UsuCod="";this.Z149TipCod="";this.O149TipCod="";this.Z351UsuSerDet="";this.O351UsuSerDet="";this.A149TipCod="";this.A351UsuSerDet="";this.A348UsuCod="";this.Events={e111032_client:["ENTER",!0],e121032_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_USUCOD=[[{av:"A348UsuCod",fld:"USUCOD",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z348UsuCod"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"}]];this.EvtParms.VALID_TIPCOD=[[{av:"A149TipCod",fld:"TIPCOD",pic:""}],[]];this.EvtParms.VALID_USUSERDET=[[],[]];this.EnterCtrl=["BTN_ENTER"];t.addPostingVar({rfrVar:"Gx_mode"});this.Initialize()});gx.wi(function(){gx.createParentObj(this.sgusuariosseries)})