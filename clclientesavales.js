gx.evt.autoSkip=!1;gx.define("clclientesavales",!1,function(){var n,t;this.ServerClass="clclientesavales";this.PackageName="GeneXus.Programs";this.ServerFullClass="clclientesavales.aspx";this.setObjectType("trn");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Clicod=function(){return this.validSrvEvt("Valid_Clicod",0).then(function(n){return n}.closure(this))};this.Valid_Clidaval=function(){var n=gx.fn.currentGridRowImpl(39);return this.validCliEvt("Valid_Clidaval",39,function(){try{if(gx.fn.currentGridRowImpl(39)===0)return!0;var n=gx.util.balloon.getNew("CLIDAVAL",gx.fn.currentGridRowImpl(39));this.AnyError=0;this.sMode12=this.Gx_mode;this.Gx_mode=gx.fn.getGridRowMode(12,39);this.standaloneModal0B12();this.standaloneNotModal0B12();gx.fn.gridDuplicateKey(40)&&(n.setError(gx.text.format(gx.getMessage("GXM_1004"),"Level1","","","","","","","","")),this.AnyError=gx.num.trunc(1,0))}catch(t){}try{return(this.Gx_mode=this.sMode12,n==null)?!0:n.show()}catch(t){}return!0})};this.standaloneModal0B12=function(){try{gx.text.compare(this.Gx_mode,"INS")!=0?gx.fn.setCtrlProperty("CLIDAVAL","Enabled",0):gx.fn.setCtrlProperty("CLIDAVAL","Enabled",1)}catch(n){}};this.standaloneNotModal0B12=function(){};this.e110b11_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e120b11_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,40,41,42,43,44,45,46,47,48,49,50,51,52,53];this.GXLastCtrlId=53;this.Gridclclientesavales_level1Container=new gx.grid.grid(this,12,"Level1",39,"Gridclclientesavales_level1","Gridclclientesavales_level1","Gridclclientesavales_level1Container",this.CmpContext,this.IsMasterPage,"clclientesavales",[162],!1,1,!1,!0,5,!1,!1,!1,"",0,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Gridclclientesavales_level1Container;t.addSingleLineEdit(162,40,"CLIDAVAL","Aval","","CliDAval","int",0,"px",6,6,"right",null,[],162,"CliDAval",!0,0,!1,!1,"Attribute",1,"");t.addSingleLineEdit(594,41,"CLIDAVALRUC","Aval","","CliDAValRUC","svchar",0,"px",11,11,"left",null,[],594,"CliDAValRUC",!0,0,!1,!1,"Attribute",1,"");t.addSingleLineEdit(593,42,"CLIDAVALDSC","Social","","CliDAvalDsc","svchar",0,"px",100,80,"left",null,[],593,"CliDAvalDsc",!0,0,!1,!1,"Attribute",1,"");t.addSingleLineEdit(592,43,"CLIDAVALDIR","Aval","","CliDAvalDir","svchar",0,"px",100,80,"left",null,[],592,"CliDAvalDir",!0,0,!1,!1,"Attribute",1,"");t.addSingleLineEdit(595,44,"CLIDAVALSTS","Default","","CliDAvalSts","int",0,"px",1,1,"right",null,[],595,"CliDAvalSts",!0,0,!1,!1,"Attribute",1,"");this.Gridclclientesavales_level1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"TABLEMAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"BTN_FIRST",grid:0,evt:"e130b11_client",std:"FIRST"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"BTN_PREVIOUS",grid:0,evt:"e140b11_client",std:"PREVIOUS"};n[15]={id:15,fld:"",grid:0};n[16]={id:16,fld:"BTN_NEXT",grid:0,evt:"e150b11_client",std:"NEXT"};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"BTN_LAST",grid:0,evt:"e160b11_client",std:"LAST"};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"BTN_SELECT",grid:0,evt:"e170b11_client",std:"SELECT"};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Clicod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Gridclclientesavales_level1Container],fld:"CLICOD",gxz:"Z45CliCod",gxold:"O45CliCod",gxvar:"A45CliCod",ucs:[],op:[33],ip:[33,28],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A45CliCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z45CliCod=n)},v2c:function(){gx.fn.setControlValue("CLICOD",gx.O.A45CliCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A45CliCod=this.val())},val:function(){return gx.fn.getControlValue("CLICOD")},nac:gx.falseFn};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIDTAVAL",gxz:"Z608CliDTAval",gxold:"O608CliDTAval",gxvar:"A608CliDTAval",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A608CliDTAval=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z608CliDTAval=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("CLIDTAVAL",gx.O.A608CliDTAval,0)},c2v:function(){this.val()!==undefined&&(gx.O.A608CliDTAval=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CLIDTAVAL",",")},nac:gx.falseFn};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"TITLELEVEL1",format:0,grid:0,ctrltype:"textblock"};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[40]={id:40,lvl:12,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,isacc:1,grid:39,gxgrid:this.Gridclclientesavales_level1Container,fnc:this.Valid_Clidaval,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIDAVAL",gxz:"Z162CliDAval",gxold:"O162CliDAval",gxvar:"A162CliDAval",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A162CliDAval=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z162CliDAval=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("CLIDAVAL",n||gx.fn.currentGridRowImpl(39),gx.O.A162CliDAval,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A162CliDAval=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("CLIDAVAL",n||gx.fn.currentGridRowImpl(39),",")},nac:gx.falseFn};n[41]={id:41,lvl:12,type:"svchar",len:11,dec:0,sign:!1,ro:0,isacc:1,grid:39,gxgrid:this.Gridclclientesavales_level1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIDAVALRUC",gxz:"Z594CliDAValRUC",gxold:"O594CliDAValRUC",gxvar:"A594CliDAValRUC",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A594CliDAValRUC=n)},v2z:function(n){n!==undefined&&(gx.O.Z594CliDAValRUC=n)},v2c:function(n){gx.fn.setGridControlValue("CLIDAVALRUC",n||gx.fn.currentGridRowImpl(39),gx.O.A594CliDAValRUC,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A594CliDAValRUC=this.val(n))},val:function(n){return gx.fn.getGridControlValue("CLIDAVALRUC",n||gx.fn.currentGridRowImpl(39))},nac:gx.falseFn};n[42]={id:42,lvl:12,type:"svchar",len:100,dec:0,sign:!1,ro:0,isacc:1,grid:39,gxgrid:this.Gridclclientesavales_level1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIDAVALDSC",gxz:"Z593CliDAvalDsc",gxold:"O593CliDAvalDsc",gxvar:"A593CliDAvalDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A593CliDAvalDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z593CliDAvalDsc=n)},v2c:function(n){gx.fn.setGridControlValue("CLIDAVALDSC",n||gx.fn.currentGridRowImpl(39),gx.O.A593CliDAvalDsc,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A593CliDAvalDsc=this.val(n))},val:function(n){return gx.fn.getGridControlValue("CLIDAVALDSC",n||gx.fn.currentGridRowImpl(39))},nac:gx.falseFn};n[43]={id:43,lvl:12,type:"svchar",len:100,dec:0,sign:!1,ro:0,isacc:1,grid:39,gxgrid:this.Gridclclientesavales_level1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIDAVALDIR",gxz:"Z592CliDAvalDir",gxold:"O592CliDAvalDir",gxvar:"A592CliDAvalDir",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A592CliDAvalDir=n)},v2z:function(n){n!==undefined&&(gx.O.Z592CliDAvalDir=n)},v2c:function(n){gx.fn.setGridControlValue("CLIDAVALDIR",n||gx.fn.currentGridRowImpl(39),gx.O.A592CliDAvalDir,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A592CliDAvalDir=this.val(n))},val:function(n){return gx.fn.getGridControlValue("CLIDAVALDIR",n||gx.fn.currentGridRowImpl(39))},nac:gx.falseFn};n[44]={id:44,lvl:12,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,isacc:1,grid:39,gxgrid:this.Gridclclientesavales_level1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIDAVALSTS",gxz:"Z595CliDAvalSts",gxold:"O595CliDAvalSts",gxvar:"A595CliDAvalSts",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A595CliDAvalSts=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z595CliDAvalSts=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("CLIDAVALSTS",n||gx.fn.currentGridRowImpl(39),gx.O.A595CliDAvalSts,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A595CliDAvalSts=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("CLIDAVALSTS",n||gx.fn.currentGridRowImpl(39),",")},nac:gx.falseFn};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"BTN_ENTER",grid:0,evt:"e110b11_client",std:"ENTER"};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"BTN_CANCEL",grid:0,evt:"e120b11_client"};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"BTN_DELETE",grid:0,evt:"e180b11_client",std:"DELETE"};this.A45CliCod="";this.Z45CliCod="";this.O45CliCod="";this.A608CliDTAval=0;this.Z608CliDTAval=0;this.O608CliDTAval=0;this.Z162CliDAval=0;this.O162CliDAval=0;this.Z594CliDAValRUC="";this.O594CliDAValRUC="";this.Z593CliDAvalDsc="";this.O593CliDAvalDsc="";this.Z592CliDAvalDir="";this.O592CliDAvalDir="";this.Z595CliDAvalSts=0;this.O595CliDAvalSts=0;this.A162CliDAval=0;this.A594CliDAValRUC="";this.A593CliDAvalDsc="";this.A592CliDAvalDir="";this.A595CliDAvalSts=0;this.A45CliCod="";this.A608CliDTAval=0;this.Events={e110b11_client:["ENTER",!0],e120b11_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_CLICOD=[[{av:"A45CliCod",fld:"CLICOD",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A608CliDTAval",fld:"CLIDTAVAL",pic:"ZZZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z45CliCod"},{av:"Z608CliDTAval"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"}]];this.EvtParms.VALID_CLIDAVAL=[[],[]];this.EnterCtrl=["BTN_ENTER"];t.addPostingVar({rfrVar:"Gx_mode"});this.Initialize()});gx.wi(function(){gx.createParentObj(this.clclientesavales)})