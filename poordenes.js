gx.evt.autoSkip=!1;gx.define("poordenes",!1,function(){this.ServerClass="poordenes";this.PackageName="GeneXus.Programs";this.ServerFullClass="poordenes.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.A1653ProCantFalta=gx.fn.getDecimalValue("PROCANTFALTA",",",".")};this.Valid_Procod=function(){return this.validSrvEvt("Valid_Procod",0).then(function(n){return n}.closure(this))};this.Valid_Profec=function(){return this.validCliEvt("Valid_Profec",0,function(){try{var n=gx.util.balloon.getNew("PROFEC");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.A325ProFec)==0||new gx.date.gxdate(this.A325ProFec).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Fecha Orden fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Proprodcod=function(){return this.validSrvEvt("Valid_Proprodcod",0).then(function(n){return n}.closure(this))};this.Valid_Procantprod=function(){return this.validCliEvt("Valid_Procantprod",0,function(){try{var n=gx.util.balloon.getNew("PROCANTPROD");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Procantproding=function(){return this.validCliEvt("Valid_Procantproding",0,function(){try{var n=gx.util.balloon.getNew("PROCANTPRODING");this.AnyError=0;try{this.A1653ProCantFalta=this.A1654ProCantProd-this.A1655ProCantProdIng}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Proplancod=function(){return this.validSrvEvt("Valid_Proplancod",0).then(function(n){return n}.closure(this))};this.e1148147_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e1248147_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,5,6,7,8,9,15,18,20,21,24,26,29,31,34,36,39,41,44,46,49,51,54,56,59,61,64,66,69,70,71,72,73];this.GXLastCtrlId=73;n[2]={id:2,fld:"TABLE1",grid:0};n[5]={id:5,fld:"BTN_FIRST",grid:0,evt:"e1348147_client",std:"FIRST"};n[6]={id:6,fld:"BTN_PREVIOUS",grid:0,evt:"e1448147_client",std:"PREVIOUS"};n[7]={id:7,fld:"BTN_NEXT",grid:0,evt:"e1548147_client",std:"NEXT"};n[8]={id:8,fld:"BTN_LAST",grid:0,evt:"e1648147_client",std:"LAST"};n[9]={id:9,fld:"BTN_SELECT",grid:0,evt:"e1748147_client",std:"SELECT"};n[15]={id:15,fld:"TABLE2",grid:0};n[18]={id:18,fld:"TEXTBLOCK1",format:0,grid:0,ctrltype:"textblock"};n[20]={id:20,lvl:0,type:"char",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Procod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PROCOD",gxz:"Z322ProCod",gxold:"O322ProCod",gxvar:"A322ProCod",ucs:[],op:[46,66,61,56,41,36,31,26],ip:[46,66,61,56,41,36,31,26,20],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A322ProCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z322ProCod=n)},v2c:function(){gx.fn.setControlValue("PROCOD",gx.O.A322ProCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A322ProCod=this.val())},val:function(){return gx.fn.getControlValue("PROCOD")},nac:gx.falseFn};n[21]={id:21,fld:"BTN_GET",grid:0,evt:"e1848147_client",std:"GET"};n[24]={id:24,fld:"TEXTBLOCK2",format:0,grid:0,ctrltype:"textblock"};n[26]={id:26,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Profec,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PROFEC",gxz:"Z325ProFec",gxold:"O325ProFec",gxvar:"A325ProFec",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[26],ip:[26],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A325ProFec=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z325ProFec=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("PROFEC",gx.O.A325ProFec,0)},c2v:function(){this.val()!==undefined&&(gx.O.A325ProFec=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("PROFEC")},nac:gx.falseFn};n[29]={id:29,fld:"TEXTBLOCK3",format:0,grid:0,ctrltype:"textblock"};n[31]={id:31,lvl:0,type:"char",len:50,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PROREF",gxz:"Z1739ProRef",gxold:"O1739ProRef",gxvar:"A1739ProRef",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1739ProRef=n)},v2z:function(n){n!==undefined&&(gx.O.Z1739ProRef=n)},v2c:function(){gx.fn.setControlValue("PROREF",gx.O.A1739ProRef,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1739ProRef=this.val())},val:function(){return gx.fn.getControlValue("PROREF")},nac:gx.falseFn};n[34]={id:34,fld:"TEXTBLOCK4",format:0,grid:0,ctrltype:"textblock"};n[36]={id:36,lvl:0,type:"char",len:1,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PROSTS",gxz:"Z1740ProSts",gxold:"O1740ProSts",gxvar:"A1740ProSts",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1740ProSts=n)},v2z:function(n){n!==undefined&&(gx.O.Z1740ProSts=n)},v2c:function(){gx.fn.setControlValue("PROSTS",gx.O.A1740ProSts,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1740ProSts=this.val())},val:function(){return gx.fn.getControlValue("PROSTS")},nac:gx.falseFn};n[39]={id:39,fld:"TEXTBLOCK5",format:0,grid:0,ctrltype:"textblock"};n[41]={id:41,lvl:0,type:"vchar",len:500,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PROOBS",gxz:"Z1730ProObs",gxold:"O1730ProObs",gxvar:"A1730ProObs",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1730ProObs=n)},v2z:function(n){n!==undefined&&(gx.O.Z1730ProObs=n)},v2c:function(){gx.fn.setControlValue("PROOBS",gx.O.A1730ProObs,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1730ProObs=this.val())},val:function(){return gx.fn.getControlValue("PROOBS")},nac:gx.falseFn};n[44]={id:44,fld:"TEXTBLOCK6",format:0,grid:0,ctrltype:"textblock"};n[46]={id:46,lvl:0,type:"char",len:15,dec:0,sign:!1,pic:"@!",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Proprodcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PROPRODCOD",gxz:"Z323ProProdCod",gxold:"O323ProProdCod",gxvar:"A323ProProdCod",ucs:[],op:[51],ip:[51,46],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A323ProProdCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z323ProProdCod=n)},v2c:function(){gx.fn.setControlValue("PROPRODCOD",gx.O.A323ProProdCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A323ProProdCod=this.val())},val:function(){return gx.fn.getControlValue("PROPRODCOD")},nac:gx.falseFn};n[49]={id:49,fld:"TEXTBLOCK7",format:0,grid:0,ctrltype:"textblock"};n[51]={id:51,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PROPRODDSC",gxz:"Z1738ProProdDsc",gxold:"O1738ProProdDsc",gxvar:"A1738ProProdDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1738ProProdDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z1738ProProdDsc=n)},v2c:function(){gx.fn.setControlValue("PROPRODDSC",gx.O.A1738ProProdDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1738ProProdDsc=this.val())},val:function(){return gx.fn.getControlValue("PROPRODDSC")},nac:gx.falseFn};n[54]={id:54,fld:"TEXTBLOCK8",format:0,grid:0,ctrltype:"textblock"};n[56]={id:56,lvl:0,type:"decimal",len:15,dec:4,sign:!0,pic:"ZZZZ,ZZZ,ZZ9.9999",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Procantprod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PROCANTPROD",gxz:"Z1654ProCantProd",gxold:"O1654ProCantProd",gxvar:"A1654ProCantProd",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1654ProCantProd=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z1654ProCantProd=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("PROCANTPROD",gx.O.A1654ProCantProd,4,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A1654ProCantProd=this.val())},val:function(){return gx.fn.getDecimalValue("PROCANTPROD",",",".")},nac:gx.falseFn};this.declareDomainHdlr(56,function(){});n[59]={id:59,fld:"TEXTBLOCK9",format:0,grid:0,ctrltype:"textblock"};n[61]={id:61,lvl:0,type:"decimal",len:15,dec:4,sign:!0,pic:"ZZZZ,ZZZ,ZZ9.9999",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Procantproding,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PROCANTPRODING",gxz:"Z1655ProCantProdIng",gxold:"O1655ProCantProdIng",gxvar:"A1655ProCantProdIng",ucs:[],op:[],ip:[61,56],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1655ProCantProdIng=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z1655ProCantProdIng=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("PROCANTPRODING",gx.O.A1655ProCantProdIng,4,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A1655ProCantProdIng=this.val())},val:function(){return gx.fn.getDecimalValue("PROCANTPRODING",",",".")},nac:gx.falseFn};this.declareDomainHdlr(61,function(){});n[64]={id:64,fld:"TEXTBLOCK10",format:0,grid:0,ctrltype:"textblock"};n[66]={id:66,lvl:0,type:"char",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Proplancod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PROPLANCOD",gxz:"Z324ProPlanCod",gxold:"O324ProPlanCod",gxvar:"A324ProPlanCod",ucs:[],op:[],ip:[66],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A324ProPlanCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z324ProPlanCod=n)},v2c:function(){gx.fn.setControlValue("PROPLANCOD",gx.O.A324ProPlanCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A324ProPlanCod=this.val())},val:function(){return gx.fn.getControlValue("PROPLANCOD")},nac:gx.falseFn};n[69]={id:69,fld:"BTN_ENTER",grid:0,evt:"e1148147_client",std:"ENTER"};n[70]={id:70,fld:"BTN_CHECK",grid:0,evt:"e1948147_client",std:"CHECK"};n[71]={id:71,fld:"BTN_CANCEL",grid:0,evt:"e1248147_client"};n[72]={id:72,fld:"BTN_DELETE",grid:0,evt:"e2048147_client",std:"DELETE"};n[73]={id:73,fld:"BTN_HELP",grid:0,evt:"e2148147_client"};this.A322ProCod="";this.Z322ProCod="";this.O322ProCod="";this.A325ProFec=gx.date.nullDate();this.Z325ProFec=gx.date.nullDate();this.O325ProFec=gx.date.nullDate();this.A1739ProRef="";this.Z1739ProRef="";this.O1739ProRef="";this.A1740ProSts="";this.Z1740ProSts="";this.O1740ProSts="";this.A1730ProObs="";this.Z1730ProObs="";this.O1730ProObs="";this.A323ProProdCod="";this.Z323ProProdCod="";this.O323ProProdCod="";this.A1738ProProdDsc="";this.Z1738ProProdDsc="";this.O1738ProProdDsc="";this.A1654ProCantProd=0;this.Z1654ProCantProd=0;this.O1654ProCantProd=0;this.A1655ProCantProdIng=0;this.Z1655ProCantProdIng=0;this.O1655ProCantProdIng=0;this.A324ProPlanCod="";this.Z324ProPlanCod="";this.O324ProPlanCod="";this.A322ProCod="";this.A1653ProCantFalta=0;this.A325ProFec=gx.date.nullDate();this.A1739ProRef="";this.A1740ProSts="";this.A1730ProObs="";this.A323ProProdCod="";this.A1738ProProdDsc="";this.A1654ProCantProd=0;this.A1655ProCantProdIng=0;this.A324ProPlanCod="";this.Events={e1148147_client:["ENTER",!0],e1248147_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_PROCOD=[[{av:"A322ProCod",fld:"PROCOD",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A325ProFec",fld:"PROFEC",pic:""},{av:"A1739ProRef",fld:"PROREF",pic:""},{av:"A1740ProSts",fld:"PROSTS",pic:""},{av:"A1730ProObs",fld:"PROOBS",pic:""},{av:"A323ProProdCod",fld:"PROPRODCOD",pic:"@!"},{av:"A1654ProCantProd",fld:"PROCANTPROD",pic:"ZZZZ,ZZZ,ZZ9.9999"},{av:"A1655ProCantProdIng",fld:"PROCANTPRODING",pic:"ZZZZ,ZZZ,ZZ9.9999"},{av:"A324ProPlanCod",fld:"PROPLANCOD",pic:""},{av:"A1738ProProdDsc",fld:"PROPRODDSC",pic:""},{av:"A1653ProCantFalta",fld:"PROCANTFALTA",pic:"ZZZZ,ZZZ,ZZ9.9999"},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z322ProCod"},{av:"Z325ProFec"},{av:"Z1739ProRef"},{av:"Z1740ProSts"},{av:"Z1730ProObs"},{av:"Z323ProProdCod"},{av:"Z1654ProCantProd"},{av:"Z1655ProCantProdIng"},{av:"Z324ProPlanCod"},{av:"Z1738ProProdDsc"},{av:"Z1653ProCantFalta"},{ctrl:"BTN_GET",prop:"Enabled"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"},{ctrl:"BTN_CHECK",prop:"Enabled"}]];this.EvtParms.VALID_PROFEC=[[{av:"A325ProFec",fld:"PROFEC",pic:""}],[{av:"A325ProFec",fld:"PROFEC",pic:""}]];this.EvtParms.VALID_PROPRODCOD=[[{av:"A323ProProdCod",fld:"PROPRODCOD",pic:"@!"},{av:"A1738ProProdDsc",fld:"PROPRODDSC",pic:""}],[{av:"A1738ProProdDsc",fld:"PROPRODDSC",pic:""}]];this.EvtParms.VALID_PROCANTPROD=[[],[]];this.EvtParms.VALID_PROCANTPRODING=[[{av:"A1655ProCantProdIng",fld:"PROCANTPRODING",pic:"ZZZZ,ZZZ,ZZ9.9999"},{av:"A1654ProCantProd",fld:"PROCANTPROD",pic:"ZZZZ,ZZZ,ZZ9.9999"}],[]];this.EvtParms.VALID_PROPLANCOD=[[{av:"A324ProPlanCod",fld:"PROPLANCOD",pic:""}],[]];this.EnterCtrl=["BTN_ENTER"];this.CheckCtrl=["BTN_CHECK"];this.setVCMap("A1653ProCantFalta","PROCANTFALTA",0,"decimal",15,4);this.Initialize()});gx.wi(function(){gx.createParentObj(this.poordenes)})