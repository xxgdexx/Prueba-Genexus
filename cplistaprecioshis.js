gx.evt.autoSkip=!1;gx.define("cplistaprecioshis",!1,function(){this.ServerClass="cplistaprecioshis";this.PackageName="GeneXus.Programs";this.ServerFullClass="cplistaprecioshis.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Cplishisprodcod=function(){return this.validSrvEvt("Valid_Cplishisprodcod",0).then(function(n){return n}.closure(this))};this.Valid_Cplishisprvcod=function(){return this.validSrvEvt("Valid_Cplishisprvcod",0).then(function(n){return n}.closure(this))};this.Valid_Cplishisfecha=function(){return this.validSrvEvt("Valid_Cplishisfecha",0).then(function(n){return n}.closure(this))};this.e113h120_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e123h120_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,5,6,7,8,9,15,18,20,23,25,28,30,31,34,36,39,41,44,46,49,51,54,55,56,57,58];this.GXLastCtrlId=58;n[2]={id:2,fld:"TABLE1",grid:0};n[5]={id:5,fld:"BTN_FIRST",grid:0,evt:"e133h120_client",std:"FIRST"};n[6]={id:6,fld:"BTN_PREVIOUS",grid:0,evt:"e143h120_client",std:"PREVIOUS"};n[7]={id:7,fld:"BTN_NEXT",grid:0,evt:"e153h120_client",std:"NEXT"};n[8]={id:8,fld:"BTN_LAST",grid:0,evt:"e163h120_client",std:"LAST"};n[9]={id:9,fld:"BTN_SELECT",grid:0,evt:"e173h120_client",std:"SELECT"};n[15]={id:15,fld:"TABLE2",grid:0};n[18]={id:18,fld:"TEXTBLOCK1",format:0,grid:0,ctrltype:"textblock"};n[20]={id:20,lvl:0,type:"char",len:15,dec:0,sign:!1,pic:"@!",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cplishisprodcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CPLISHISPRODCOD",gxz:"Z286CPLisHisProdCod",gxold:"O286CPLisHisProdCod",gxvar:"A286CPLisHisProdCod",ucs:[],op:[36],ip:[36,20],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A286CPLisHisProdCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z286CPLisHisProdCod=n)},v2c:function(){gx.fn.setControlValue("CPLISHISPRODCOD",gx.O.A286CPLisHisProdCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A286CPLisHisProdCod=this.val())},val:function(){return gx.fn.getControlValue("CPLISHISPRODCOD")},nac:gx.falseFn};n[23]={id:23,fld:"TEXTBLOCK2",format:0,grid:0,ctrltype:"textblock"};n[25]={id:25,lvl:0,type:"char",len:20,dec:0,sign:!1,pic:"@!",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cplishisprvcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CPLISHISPRVCOD",gxz:"Z287CPLisHisPrvCod",gxold:"O287CPLisHisPrvCod",gxvar:"A287CPLisHisPrvCod",ucs:[],op:[41],ip:[41,25],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A287CPLisHisPrvCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z287CPLisHisPrvCod=n)},v2c:function(){gx.fn.setControlValue("CPLISHISPRVCOD",gx.O.A287CPLisHisPrvCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A287CPLisHisPrvCod=this.val())},val:function(){return gx.fn.getControlValue("CPLISHISPRVCOD")},nac:gx.falseFn};n[28]={id:28,fld:"TEXTBLOCK3",format:0,grid:0,ctrltype:"textblock"};n[30]={id:30,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cplishisfecha,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CPLISHISFECHA",gxz:"Z288CPLisHisFecha",gxold:"O288CPLisHisFecha",gxvar:"A288CPLisHisFecha",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[30,51,46],ip:[51,46,30,25,20],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A288CPLisHisFecha=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z288CPLisHisFecha=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("CPLISHISFECHA",gx.O.A288CPLisHisFecha,0)},c2v:function(){this.val()!==undefined&&(gx.O.A288CPLisHisFecha=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("CPLISHISFECHA")},nac:gx.falseFn};n[31]={id:31,fld:"BTN_GET",grid:0,evt:"e183h120_client",std:"GET"};n[34]={id:34,fld:"TEXTBLOCK4",format:0,grid:0,ctrltype:"textblock"};n[36]={id:36,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CPLISHISPRODDSC",gxz:"Z825CPLisHisProdDsc",gxold:"O825CPLisHisProdDsc",gxvar:"A825CPLisHisProdDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A825CPLisHisProdDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z825CPLisHisProdDsc=n)},v2c:function(){gx.fn.setControlValue("CPLISHISPRODDSC",gx.O.A825CPLisHisProdDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A825CPLisHisProdDsc=this.val())},val:function(){return gx.fn.getControlValue("CPLISHISPRODDSC")},nac:gx.falseFn};n[39]={id:39,fld:"TEXTBLOCK5",format:0,grid:0,ctrltype:"textblock"};n[41]={id:41,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CPLISHISPRVDSC",gxz:"Z826CPLisHisPrvDsc",gxold:"O826CPLisHisPrvDsc",gxvar:"A826CPLisHisPrvDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A826CPLisHisPrvDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z826CPLisHisPrvDsc=n)},v2c:function(){gx.fn.setControlValue("CPLISHISPRVDSC",gx.O.A826CPLisHisPrvDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A826CPLisHisPrvDsc=this.val())},val:function(){return gx.fn.getControlValue("CPLISHISPRVDSC")},nac:gx.falseFn};n[44]={id:44,fld:"TEXTBLOCK6",format:0,grid:0,ctrltype:"textblock"};n[46]={id:46,lvl:0,type:"decimal",len:15,dec:4,sign:!0,pic:"ZZZZ,ZZZ,ZZ9.9999",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CPLISHISIMPMN",gxz:"Z824CPLisHisImpMN",gxold:"O824CPLisHisImpMN",gxvar:"A824CPLisHisImpMN",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A824CPLisHisImpMN=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z824CPLisHisImpMN=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("CPLISHISIMPMN",gx.O.A824CPLisHisImpMN,4,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A824CPLisHisImpMN=this.val())},val:function(){return gx.fn.getDecimalValue("CPLISHISIMPMN",",",".")},nac:gx.falseFn};this.declareDomainHdlr(46,function(){});n[49]={id:49,fld:"TEXTBLOCK7",format:0,grid:0,ctrltype:"textblock"};n[51]={id:51,lvl:0,type:"decimal",len:15,dec:4,sign:!0,pic:"ZZZZ,ZZZ,ZZ9.9999",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CPLISHISIMPME",gxz:"Z823CPLisHisImpME",gxold:"O823CPLisHisImpME",gxvar:"A823CPLisHisImpME",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A823CPLisHisImpME=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z823CPLisHisImpME=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("CPLISHISIMPME",gx.O.A823CPLisHisImpME,4,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A823CPLisHisImpME=this.val())},val:function(){return gx.fn.getDecimalValue("CPLISHISIMPME",",",".")},nac:gx.falseFn};this.declareDomainHdlr(51,function(){});n[54]={id:54,fld:"BTN_ENTER",grid:0,evt:"e113h120_client",std:"ENTER"};n[55]={id:55,fld:"BTN_CHECK",grid:0,evt:"e193h120_client",std:"CHECK"};n[56]={id:56,fld:"BTN_CANCEL",grid:0,evt:"e123h120_client"};n[57]={id:57,fld:"BTN_DELETE",grid:0,evt:"e203h120_client",std:"DELETE"};n[58]={id:58,fld:"BTN_HELP",grid:0,evt:"e213h120_client"};this.A286CPLisHisProdCod="";this.Z286CPLisHisProdCod="";this.O286CPLisHisProdCod="";this.A287CPLisHisPrvCod="";this.Z287CPLisHisPrvCod="";this.O287CPLisHisPrvCod="";this.A288CPLisHisFecha=gx.date.nullDate();this.Z288CPLisHisFecha=gx.date.nullDate();this.O288CPLisHisFecha=gx.date.nullDate();this.A825CPLisHisProdDsc="";this.Z825CPLisHisProdDsc="";this.O825CPLisHisProdDsc="";this.A826CPLisHisPrvDsc="";this.Z826CPLisHisPrvDsc="";this.O826CPLisHisPrvDsc="";this.A824CPLisHisImpMN=0;this.Z824CPLisHisImpMN=0;this.O824CPLisHisImpMN=0;this.A823CPLisHisImpME=0;this.Z823CPLisHisImpME=0;this.O823CPLisHisImpME=0;this.A286CPLisHisProdCod="";this.A287CPLisHisPrvCod="";this.A288CPLisHisFecha=gx.date.nullDate();this.A825CPLisHisProdDsc="";this.A826CPLisHisPrvDsc="";this.A824CPLisHisImpMN=0;this.A823CPLisHisImpME=0;this.Events={e113h120_client:["ENTER",!0],e123h120_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_CPLISHISPRODCOD=[[{av:"A286CPLisHisProdCod",fld:"CPLISHISPRODCOD",pic:"@!"},{av:"A825CPLisHisProdDsc",fld:"CPLISHISPRODDSC",pic:""}],[{av:"A825CPLisHisProdDsc",fld:"CPLISHISPRODDSC",pic:""}]];this.EvtParms.VALID_CPLISHISPRVCOD=[[{av:"A287CPLisHisPrvCod",fld:"CPLISHISPRVCOD",pic:"@!"},{av:"A826CPLisHisPrvDsc",fld:"CPLISHISPRVDSC",pic:""}],[{av:"A826CPLisHisPrvDsc",fld:"CPLISHISPRVDSC",pic:""}]];this.EvtParms.VALID_CPLISHISFECHA=[[{av:"A286CPLisHisProdCod",fld:"CPLISHISPRODCOD",pic:"@!"},{av:"A287CPLisHisPrvCod",fld:"CPLISHISPRVCOD",pic:"@!"},{av:"A288CPLisHisFecha",fld:"CPLISHISFECHA",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A824CPLisHisImpMN",fld:"CPLISHISIMPMN",pic:"ZZZZ,ZZZ,ZZ9.9999"},{av:"A823CPLisHisImpME",fld:"CPLISHISIMPME",pic:"ZZZZ,ZZZ,ZZ9.9999"},{av:"A825CPLisHisProdDsc",fld:"CPLISHISPRODDSC",pic:""},{av:"A826CPLisHisPrvDsc",fld:"CPLISHISPRVDSC",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z286CPLisHisProdCod"},{av:"Z287CPLisHisPrvCod"},{av:"Z288CPLisHisFecha"},{av:"Z824CPLisHisImpMN"},{av:"Z823CPLisHisImpME"},{av:"Z825CPLisHisProdDsc"},{av:"Z826CPLisHisPrvDsc"},{ctrl:"BTN_GET",prop:"Enabled"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"},{ctrl:"BTN_CHECK",prop:"Enabled"}]];this.EnterCtrl=["BTN_ENTER"];this.CheckCtrl=["BTN_CHECK"];this.Initialize()});gx.wi(function(){gx.createParentObj(this.cplistaprecioshis)})