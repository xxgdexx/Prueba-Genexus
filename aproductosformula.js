gx.evt.autoSkip=!1;gx.define("aproductosformula",!1,function(){var n,t;this.ServerClass="aproductosformula";this.PackageName="GeneXus.Programs";this.ServerFullClass="aproductosformula.aspx";this.setObjectType("trn");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.A906ProdAfecICBPER=gx.fn.getIntegerValue("PRODAFECICBPER",",");this.A907ProdValICBPER=gx.fn.getDecimalValue("PRODVALICBPER",",",".");this.A908ProdValICBPERD=gx.fn.getDecimalValue("PRODVALICBPERD",",",".");this.A1692ProdForSub=gx.fn.getIntegerValue("PRODFORSUB",",")};this.Valid_Prodcod=function(){return this.validSrvEvt("Valid_Prodcod",0).then(function(n){return n}.closure(this))};this.Valid_Prodforprodcod=function(){var t=gx.fn.currentGridRowImpl(25),n;return gx.fn.currentGridRowImpl(25)===0?!0:(n=gx.util.balloon.getNew("PRODFORPRODCOD",gx.fn.currentGridRowImpl(25)),gx.fn.gridDuplicateKey(27))?(n.setError(gx.text.format(gx.getMessage("GXM_1004"),"Level1","","","","","","","","")),this.AnyError=gx.num.trunc(1,0),n.show()):this.validSrvEvt("Valid_Prodforprodcod",25).then(function(n){try{this.sMode46=this.Gx_mode;this.Gx_mode=gx.fn.getGridRowMode(46,25);this.standaloneModal1C46();this.standaloneNotModal1C46()}finally{this.Gx_mode=this.sMode46}return n}.closure(this))};this.standaloneModal1C46=function(){try{gx.text.compare(this.Gx_mode,"INS")!=0?gx.fn.setCtrlProperty("PRODFORPRODCOD","Enabled",0):gx.fn.setCtrlProperty("PRODFORPRODCOD","Enabled",1)}catch(n){}};this.standaloneNotModal1C46=function(){};this.e111c44_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e121c44_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,5,6,7,8,9,15,18,20,21,26,27,28,29,32,33,34,35,36];this.GXLastCtrlId=36;this.Grid1Container=new gx.grid.grid(this,46,"Level1",25,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"aproductosformula",[57],!1,1,!1,!0,5,!1,!1,!1,"",0,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!1,!1);t=this.Grid1Container;t.addSingleLineEdit("nRcdDeleted_46",26,"vNRCDDELETED_46","","","nRcdDeleted_46","int",0,"px",4,1,"right",null,[],"nRcdDeleted_46","nRcdDeleted_46",!0,0,!1,!1,"Attribute",1,"");t.addSingleLineEdit(57,27,"PRODFORPRODCOD","Codigo Producto","","ProdForProdCod","char",0,"px",15,15,"left",null,[],57,"ProdForProdCod",!0,0,!1,!1,"Attribute",1,"");t.addSingleLineEdit(1691,28,"PRODFORPRODDSC","producto","","ProdForProdDsc","char",0,"px",100,80,"left",null,[],1691,"ProdForProdDsc",!0,0,!1,!1,"Attribute",1,"");t.addSingleLineEdit(1690,29,"PRODFORCANT","Cantidad","","ProdForCant","decimal",0,"px",18,18,"right",null,[],1690,"ProdForCant",!0,6,!1,!1,"Attribute",1,"");this.Grid1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"TABLE1",grid:0};n[5]={id:5,fld:"BTN_FIRST",grid:0,evt:"e131c44_client",std:"FIRST"};n[6]={id:6,fld:"BTN_PREVIOUS",grid:0,evt:"e141c44_client",std:"PREVIOUS"};n[7]={id:7,fld:"BTN_NEXT",grid:0,evt:"e151c44_client",std:"NEXT"};n[8]={id:8,fld:"BTN_LAST",grid:0,evt:"e161c44_client",std:"LAST"};n[9]={id:9,fld:"BTN_SELECT",grid:0,evt:"e171c44_client",std:"SELECT"};n[15]={id:15,fld:"TABLE2",grid:0};n[18]={id:18,fld:"TEXTBLOCK1",format:0,grid:0,ctrltype:"textblock"};n[20]={id:20,lvl:0,type:"char",len:15,dec:0,sign:!1,pic:"@!",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Prodcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"PRODCOD",gxz:"Z28ProdCod",gxold:"O28ProdCod",gxvar:"A28ProdCod",ucs:[],op:[],ip:[20],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A28ProdCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z28ProdCod=n)},v2c:function(){gx.fn.setControlValue("PRODCOD",gx.O.A28ProdCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A28ProdCod=this.val())},val:function(){return gx.fn.getControlValue("PRODCOD")},nac:gx.falseFn};n[21]={id:21,fld:"BTN_GET",grid:0,evt:"e181c44_client",std:"GET"};n[26]={id:26,lvl:46,type:"int",len:4,dec:0,sign:!1,pic:"9999",ro:0,isacc:0,grid:25,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNRCDDELETED_46",gxz:"ZnRcdDeleted_46",gxold:"OnRcdDeleted_46",gxvar:"nRcdDeleted_46",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.nRcdDeleted_46=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZnRcdDeleted_46=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("vNRCDDELETED_46",n||gx.fn.currentGridRowImpl(25),gx.O.nRcdDeleted_46,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.nRcdDeleted_46=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vNRCDDELETED_46",n||gx.fn.currentGridRowImpl(25),",")},nac:gx.falseFn};n[27]={id:27,lvl:46,type:"char",len:15,dec:0,sign:!1,pic:"@!",ro:0,isacc:1,grid:25,gxgrid:this.Grid1Container,fnc:this.Valid_Prodforprodcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODFORPRODCOD",gxz:"Z57ProdForProdCod",gxold:"O57ProdForProdCod",gxvar:"A57ProdForProdCod",ucs:[],op:[28],ip:[28,27],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A57ProdForProdCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z57ProdForProdCod=n)},v2c:function(n){gx.fn.setGridControlValue("PRODFORPRODCOD",n||gx.fn.currentGridRowImpl(25),gx.O.A57ProdForProdCod,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A57ProdForProdCod=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PRODFORPRODCOD",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[28]={id:28,lvl:46,type:"char",len:100,dec:0,sign:!1,ro:1,isacc:1,grid:25,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODFORPRODDSC",gxz:"Z1691ProdForProdDsc",gxold:"O1691ProdForProdDsc",gxvar:"A1691ProdForProdDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A1691ProdForProdDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z1691ProdForProdDsc=n)},v2c:function(n){gx.fn.setGridControlValue("PRODFORPRODDSC",n||gx.fn.currentGridRowImpl(25),gx.O.A1691ProdForProdDsc,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A1691ProdForProdDsc=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PRODFORPRODDSC",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[29]={id:29,lvl:46,type:"decimal",len:18,dec:6,sign:!1,pic:"ZZZZZZZZZZ9.999999",ro:0,isacc:1,grid:25,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODFORCANT",gxz:"Z1690ProdForCant",gxold:"O1690ProdForCant",gxvar:"A1690ProdForCant",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A1690ProdForCant=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z1690ProdForCant=gx.fn.toDecimalValue(n,",","."))},v2c:function(n){gx.fn.setGridDecimalValue("PRODFORCANT",n||gx.fn.currentGridRowImpl(25),gx.O.A1690ProdForCant,6,".")},c2v:function(n){this.val(n)!==undefined&&(gx.O.A1690ProdForCant=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("PRODFORCANT",n||gx.fn.currentGridRowImpl(25),",",".")},nac:gx.falseFn};n[32]={id:32,fld:"BTN_ENTER",grid:0,evt:"e111c44_client",std:"ENTER"};n[33]={id:33,fld:"BTN_CHECK",grid:0,evt:"e191c44_client",std:"CHECK"};n[34]={id:34,fld:"BTN_CANCEL",grid:0,evt:"e121c44_client"};n[35]={id:35,fld:"BTN_DELETE",grid:0,evt:"e201c44_client",std:"DELETE"};n[36]={id:36,fld:"BTN_HELP",grid:0,evt:"e211c44_client"};this.A28ProdCod="";this.Z28ProdCod="";this.O28ProdCod="";this.ZnRcdDeleted_46=0;this.OnRcdDeleted_46=0;this.Z57ProdForProdCod="";this.O57ProdForProdCod="";this.Z1691ProdForProdDsc="";this.O1691ProdForProdDsc="";this.Z1690ProdForCant=0;this.O1690ProdForCant=0;this.A57ProdForProdCod="";this.A1691ProdForProdDsc="";this.A1690ProdForCant=0;this.A1692ProdForSub=0;this.A28ProdCod="";this.A906ProdAfecICBPER=0;this.A907ProdValICBPER=0;this.A908ProdValICBPERD=0;this.Events={e111c44_client:["ENTER",!0],e121c44_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[{av:"A906ProdAfecICBPER",fld:"PRODAFECICBPER",pic:"9"},{av:"A907ProdValICBPER",fld:"PRODVALICBPER",pic:"ZZZZZZ,ZZZ,ZZ9.99"},{av:"A908ProdValICBPERD",fld:"PRODVALICBPERD",pic:"ZZZZZZ,ZZZ,ZZ9.99"}],[]];this.EvtParms.VALID_PRODCOD=[[{av:"A908ProdValICBPERD",fld:"PRODVALICBPERD",pic:"ZZZZZZ,ZZZ,ZZ9.99"},{av:"A907ProdValICBPER",fld:"PRODVALICBPER",pic:"ZZZZZZ,ZZZ,ZZ9.99"},{av:"A906ProdAfecICBPER",fld:"PRODAFECICBPER",pic:"9"},{av:"A28ProdCod",fld:"PRODCOD",pic:"@!"},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A906ProdAfecICBPER",fld:"PRODAFECICBPER",pic:"9"},{av:"A907ProdValICBPER",fld:"PRODVALICBPER",pic:"ZZZZZZ,ZZZ,ZZ9.99"},{av:"A908ProdValICBPERD",fld:"PRODVALICBPERD",pic:"ZZZZZZ,ZZZ,ZZ9.99"},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z28ProdCod"},{av:"Z906ProdAfecICBPER"},{av:"Z907ProdValICBPER"},{av:"Z908ProdValICBPERD"},{ctrl:"BTN_GET",prop:"Enabled"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"},{ctrl:"BTN_CHECK",prop:"Enabled"}]];this.EvtParms.VALID_PRODFORPRODCOD=[[{av:"A57ProdForProdCod",fld:"PRODFORPRODCOD",pic:"@!"},{av:"A1691ProdForProdDsc",fld:"PRODFORPRODDSC",pic:""}],[{av:"A1691ProdForProdDsc",fld:"PRODFORPRODDSC",pic:""}]];this.EnterCtrl=["BTN_ENTER"];this.CheckCtrl=["BTN_CHECK"];this.setVCMap("A906ProdAfecICBPER","PRODAFECICBPER",0,"int",1,0);this.setVCMap("A907ProdValICBPER","PRODVALICBPER",0,"decimal",15,2);this.setVCMap("A908ProdValICBPERD","PRODVALICBPERD",0,"decimal",15,2);this.setVCMap("A1692ProdForSub","PRODFORSUB",25,"int",1,0);t.addPostingVar({rfrVar:"Gx_mode"});this.Initialize()});gx.wi(function(){gx.createParentObj(this.aproductosformula)})