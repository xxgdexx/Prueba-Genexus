gx.evt.autoSkip=!1;gx.define("cchoferes",!1,function(){this.ServerClass="cchoferes";this.PackageName="GeneXus.Programs";this.ServerFullClass="cchoferes.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.A541ChoCompleto=gx.fn.getControlValue("CHOCOMPLETO")};this.Valid_Chocod=function(){return this.validSrvEvt("Valid_Chocod",0).then(function(n){return n}.closure(this))};this.Valid_Chodsc=function(){return this.validCliEvt("Valid_Chodsc",0,function(){try{var n=gx.util.balloon.getNew("CHODSC");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Choplaca=function(){return this.validCliEvt("Valid_Choplaca",0,function(){try{var n=gx.util.balloon.getNew("CHOPLACA");this.AnyError=0;try{this.A541ChoCompleto=gx.text.trim(this.A542ChoDsc)+" "+gx.text.trim(this.A543ChoPlaca)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e112574_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e122574_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,5,6,7,8,9,15,18,20,21,24,26,29,31,34,36,39,41,44,46,49,51,54,56,59,61,64,66,69,70,71,72,73];this.GXLastCtrlId=73;n[2]={id:2,fld:"TABLE1",grid:0};n[5]={id:5,fld:"BTN_FIRST",grid:0,evt:"e132574_client",std:"FIRST"};n[6]={id:6,fld:"BTN_PREVIOUS",grid:0,evt:"e142574_client",std:"PREVIOUS"};n[7]={id:7,fld:"BTN_NEXT",grid:0,evt:"e152574_client",std:"NEXT"};n[8]={id:8,fld:"BTN_LAST",grid:0,evt:"e162574_client",std:"LAST"};n[9]={id:9,fld:"BTN_SELECT",grid:0,evt:"e172574_client",std:"SELECT"};n[15]={id:15,fld:"TABLE2",grid:0};n[18]={id:18,fld:"TEXTBLOCK1",format:0,grid:0,ctrltype:"textblock"};n[20]={id:20,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Chocod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHOCOD",gxz:"Z10ChoCod",gxold:"O10ChoCod",gxvar:"A10ChoCod",ucs:[],op:[66,61,56,51,46,41,36,31,26],ip:[66,61,56,51,46,41,36,31,26,20],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A10ChoCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z10ChoCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("CHOCOD",gx.O.A10ChoCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A10ChoCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CHOCOD",",")},nac:gx.falseFn};n[21]={id:21,fld:"BTN_GET",grid:0,evt:"e182574_client",std:"GET"};n[24]={id:24,fld:"TEXTBLOCK2",format:0,grid:0,ctrltype:"textblock"};n[26]={id:26,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Chodsc,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHODSC",gxz:"Z542ChoDsc",gxold:"O542ChoDsc",gxvar:"A542ChoDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A542ChoDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z542ChoDsc=n)},v2c:function(){gx.fn.setControlValue("CHODSC",gx.O.A542ChoDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A542ChoDsc=this.val())},val:function(){return gx.fn.getControlValue("CHODSC")},nac:gx.falseFn};n[29]={id:29,fld:"TEXTBLOCK3",format:0,grid:0,ctrltype:"textblock"};n[31]={id:31,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHODIR",gxz:"Z545ChoDir",gxold:"O545ChoDir",gxvar:"A545ChoDir",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A545ChoDir=n)},v2z:function(n){n!==undefined&&(gx.O.Z545ChoDir=n)},v2c:function(){gx.fn.setControlValue("CHODIR",gx.O.A545ChoDir,0)},c2v:function(){this.val()!==undefined&&(gx.O.A545ChoDir=this.val())},val:function(){return gx.fn.getControlValue("CHODIR")},nac:gx.falseFn};n[34]={id:34,fld:"TEXTBLOCK4",format:0,grid:0,ctrltype:"textblock"};n[36]={id:36,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHOTEL",gxz:"Z550ChoTel",gxold:"O550ChoTel",gxvar:"A550ChoTel",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A550ChoTel=n)},v2z:function(n){n!==undefined&&(gx.O.Z550ChoTel=n)},v2c:function(){gx.fn.setControlValue("CHOTEL",gx.O.A550ChoTel,0)},c2v:function(){this.val()!==undefined&&(gx.O.A550ChoTel=this.val())},val:function(){return gx.fn.getControlValue("CHOTEL")},nac:gx.falseFn};n[39]={id:39,fld:"TEXTBLOCK5",format:0,grid:0,ctrltype:"textblock"};n[41]={id:41,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHORUC",gxz:"Z548ChoRuc",gxold:"O548ChoRuc",gxvar:"A548ChoRuc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A548ChoRuc=n)},v2z:function(n){n!==undefined&&(gx.O.Z548ChoRuc=n)},v2c:function(){gx.fn.setControlValue("CHORUC",gx.O.A548ChoRuc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A548ChoRuc=this.val())},val:function(){return gx.fn.getControlValue("CHORUC")},nac:gx.falseFn};n[44]={id:44,fld:"TEXTBLOCK6",format:0,grid:0,ctrltype:"textblock"};n[46]={id:46,lvl:0,type:"char",len:30,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHOMARCA",gxz:"Z547ChoMarca",gxold:"O547ChoMarca",gxvar:"A547ChoMarca",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A547ChoMarca=n)},v2z:function(n){n!==undefined&&(gx.O.Z547ChoMarca=n)},v2c:function(){gx.fn.setControlValue("CHOMARCA",gx.O.A547ChoMarca,0)},c2v:function(){this.val()!==undefined&&(gx.O.A547ChoMarca=this.val())},val:function(){return gx.fn.getControlValue("CHOMARCA")},nac:gx.falseFn};n[49]={id:49,fld:"TEXTBLOCK7",format:0,grid:0,ctrltype:"textblock"};n[51]={id:51,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Choplaca,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHOPLACA",gxz:"Z543ChoPlaca",gxold:"O543ChoPlaca",gxvar:"A543ChoPlaca",ucs:[],op:[],ip:[51,26],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A543ChoPlaca=n)},v2z:function(n){n!==undefined&&(gx.O.Z543ChoPlaca=n)},v2c:function(){gx.fn.setControlValue("CHOPLACA",gx.O.A543ChoPlaca,0)},c2v:function(){this.val()!==undefined&&(gx.O.A543ChoPlaca=this.val())},val:function(){return gx.fn.getControlValue("CHOPLACA")},nac:gx.falseFn};n[54]={id:54,fld:"TEXTBLOCK8",format:0,grid:0,ctrltype:"textblock"};n[56]={id:56,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHOLICENCIA",gxz:"Z546ChoLicencia",gxold:"O546ChoLicencia",gxvar:"A546ChoLicencia",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A546ChoLicencia=n)},v2z:function(n){n!==undefined&&(gx.O.Z546ChoLicencia=n)},v2c:function(){gx.fn.setControlValue("CHOLICENCIA",gx.O.A546ChoLicencia,0)},c2v:function(){this.val()!==undefined&&(gx.O.A546ChoLicencia=this.val())},val:function(){return gx.fn.getControlValue("CHOLICENCIA")},nac:gx.falseFn};n[59]={id:59,fld:"TEXTBLOCK9",format:0,grid:0,ctrltype:"textblock"};n[61]={id:61,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHOCONSTA",gxz:"Z544ChoConsta",gxold:"O544ChoConsta",gxvar:"A544ChoConsta",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A544ChoConsta=n)},v2z:function(n){n!==undefined&&(gx.O.Z544ChoConsta=n)},v2c:function(){gx.fn.setControlValue("CHOCONSTA",gx.O.A544ChoConsta,0)},c2v:function(){this.val()!==undefined&&(gx.O.A544ChoConsta=this.val())},val:function(){return gx.fn.getControlValue("CHOCONSTA")},nac:gx.falseFn};n[64]={id:64,fld:"TEXTBLOCK10",format:0,grid:0,ctrltype:"textblock"};n[66]={id:66,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CHOSTS",gxz:"Z549ChoSts",gxold:"O549ChoSts",gxvar:"A549ChoSts",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.A549ChoSts=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z549ChoSts=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("CHOSTS",gx.O.A549ChoSts)},c2v:function(){this.val()!==undefined&&(gx.O.A549ChoSts=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CHOSTS",",")},nac:gx.falseFn};n[69]={id:69,fld:"BTN_ENTER",grid:0,evt:"e112574_client",std:"ENTER"};n[70]={id:70,fld:"BTN_CHECK",grid:0,evt:"e192574_client",std:"CHECK"};n[71]={id:71,fld:"BTN_CANCEL",grid:0,evt:"e122574_client"};n[72]={id:72,fld:"BTN_DELETE",grid:0,evt:"e202574_client",std:"DELETE"};n[73]={id:73,fld:"BTN_HELP",grid:0,evt:"e212574_client"};this.A10ChoCod=0;this.Z10ChoCod=0;this.O10ChoCod=0;this.A542ChoDsc="";this.Z542ChoDsc="";this.O542ChoDsc="";this.A545ChoDir="";this.Z545ChoDir="";this.O545ChoDir="";this.A550ChoTel="";this.Z550ChoTel="";this.O550ChoTel="";this.A548ChoRuc="";this.Z548ChoRuc="";this.O548ChoRuc="";this.A547ChoMarca="";this.Z547ChoMarca="";this.O547ChoMarca="";this.A543ChoPlaca="";this.Z543ChoPlaca="";this.O543ChoPlaca="";this.A546ChoLicencia="";this.Z546ChoLicencia="";this.O546ChoLicencia="";this.A544ChoConsta="";this.Z544ChoConsta="";this.O544ChoConsta="";this.A549ChoSts=0;this.Z549ChoSts=0;this.O549ChoSts=0;this.A10ChoCod=0;this.A541ChoCompleto="";this.A542ChoDsc="";this.A545ChoDir="";this.A550ChoTel="";this.A548ChoRuc="";this.A547ChoMarca="";this.A543ChoPlaca="";this.A546ChoLicencia="";this.A544ChoConsta="";this.A549ChoSts=0;this.Events={e112574_client:["ENTER",!0],e122574_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_CHOCOD=[[{ctrl:"CHOSTS"},{av:"A549ChoSts",fld:"CHOSTS",pic:"9"},{av:"A10ChoCod",fld:"CHOCOD",pic:"ZZZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A542ChoDsc",fld:"CHODSC",pic:""},{av:"A545ChoDir",fld:"CHODIR",pic:""},{av:"A550ChoTel",fld:"CHOTEL",pic:""},{av:"A548ChoRuc",fld:"CHORUC",pic:""},{av:"A547ChoMarca",fld:"CHOMARCA",pic:""},{av:"A543ChoPlaca",fld:"CHOPLACA",pic:""},{av:"A546ChoLicencia",fld:"CHOLICENCIA",pic:""},{av:"A544ChoConsta",fld:"CHOCONSTA",pic:""},{ctrl:"CHOSTS"},{av:"A549ChoSts",fld:"CHOSTS",pic:"9"},{av:"A541ChoCompleto",fld:"CHOCOMPLETO",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z10ChoCod"},{av:"Z542ChoDsc"},{av:"Z545ChoDir"},{av:"Z550ChoTel"},{av:"Z548ChoRuc"},{av:"Z547ChoMarca"},{av:"Z543ChoPlaca"},{av:"Z546ChoLicencia"},{av:"Z544ChoConsta"},{av:"Z549ChoSts"},{av:"Z541ChoCompleto"},{ctrl:"BTN_GET",prop:"Enabled"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"},{ctrl:"BTN_CHECK",prop:"Enabled"}]];this.EvtParms.VALID_CHODSC=[[],[]];this.EvtParms.VALID_CHOPLACA=[[{av:"A543ChoPlaca",fld:"CHOPLACA",pic:""},{av:"A542ChoDsc",fld:"CHODSC",pic:""}],[]];this.EnterCtrl=["BTN_ENTER"];this.CheckCtrl=["BTN_CHECK"];this.setVCMap("A541ChoCompleto","CHOCOMPLETO",0,"svchar",200,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.cchoferes)})