gx.evt.autoSkip=!1;gx.define("cvendedores",!1,function(){this.ServerClass="cvendedores";this.PackageName="GeneXus.Programs";this.ServerFullClass="cvendedores.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Vencod=function(){return this.validSrvEvt("Valid_Vencod",0).then(function(n){return n}.closure(this))};this.e113z138_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e123z138_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,5,6,7,8,9,15,18,20,21,24,26,29,31,34,36,39,41,44,46,49,51,54,56,59,60,61,62,63];this.GXLastCtrlId=63;n[2]={id:2,fld:"TABLE1",grid:0};n[5]={id:5,fld:"BTN_FIRST",grid:0,evt:"e133z138_client",std:"FIRST"};n[6]={id:6,fld:"BTN_PREVIOUS",grid:0,evt:"e143z138_client",std:"PREVIOUS"};n[7]={id:7,fld:"BTN_NEXT",grid:0,evt:"e153z138_client",std:"NEXT"};n[8]={id:8,fld:"BTN_LAST",grid:0,evt:"e163z138_client",std:"LAST"};n[9]={id:9,fld:"BTN_SELECT",grid:0,evt:"e173z138_client",std:"SELECT"};n[15]={id:15,fld:"TABLE2",grid:0};n[18]={id:18,fld:"TEXTBLOCK1",format:0,grid:0,ctrltype:"textblock"};n[20]={id:20,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Vencod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VENCOD",gxz:"Z309VenCod",gxold:"O309VenCod",gxvar:"A309VenCod",ucs:[],op:[56,51,46,41,36,31,26],ip:[56,51,46,41,36,31,26,20],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A309VenCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z309VenCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("VENCOD",gx.O.A309VenCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A309VenCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("VENCOD",",")},nac:gx.falseFn};n[21]={id:21,fld:"BTN_GET",grid:0,evt:"e183z138_client",std:"GET"};n[24]={id:24,fld:"TEXTBLOCK2",format:0,grid:0,ctrltype:"textblock"};n[26]={id:26,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VENDSC",gxz:"Z2045VenDsc",gxold:"O2045VenDsc",gxvar:"A2045VenDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2045VenDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z2045VenDsc=n)},v2c:function(){gx.fn.setControlValue("VENDSC",gx.O.A2045VenDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2045VenDsc=this.val())},val:function(){return gx.fn.getControlValue("VENDSC")},nac:gx.falseFn};n[29]={id:29,fld:"TEXTBLOCK3",format:0,grid:0,ctrltype:"textblock"};n[31]={id:31,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VENDIR",gxz:"Z2044VenDir",gxold:"O2044VenDir",gxvar:"A2044VenDir",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2044VenDir=n)},v2z:function(n){n!==undefined&&(gx.O.Z2044VenDir=n)},v2c:function(){gx.fn.setControlValue("VENDIR",gx.O.A2044VenDir,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2044VenDir=this.val())},val:function(){return gx.fn.getControlValue("VENDIR")},nac:gx.falseFn};n[34]={id:34,fld:"TEXTBLOCK4",format:0,grid:0,ctrltype:"textblock"};n[36]={id:36,lvl:0,type:"char",len:15,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VENTELF",gxz:"Z2048VenTelf",gxold:"O2048VenTelf",gxvar:"A2048VenTelf",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2048VenTelf=n)},v2z:function(n){n!==undefined&&(gx.O.Z2048VenTelf=n)},v2c:function(){gx.fn.setControlValue("VENTELF",gx.O.A2048VenTelf,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2048VenTelf=this.val())},val:function(){return gx.fn.getControlValue("VENTELF")},nac:gx.falseFn};n[39]={id:39,fld:"TEXTBLOCK5",format:0,grid:0,ctrltype:"textblock"};n[41]={id:41,lvl:0,type:"char",len:15,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VENCEL",gxz:"Z2043VenCel",gxold:"O2043VenCel",gxvar:"A2043VenCel",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2043VenCel=n)},v2z:function(n){n!==undefined&&(gx.O.Z2043VenCel=n)},v2c:function(){gx.fn.setControlValue("VENCEL",gx.O.A2043VenCel,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2043VenCel=this.val())},val:function(){return gx.fn.getControlValue("VENCEL")},nac:gx.falseFn};n[44]={id:44,fld:"TEXTBLOCK6",format:0,grid:0,ctrltype:"textblock"};n[46]={id:46,lvl:0,type:"char",len:15,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VENRUC",gxz:"Z2046VenRuc",gxold:"O2046VenRuc",gxvar:"A2046VenRuc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2046VenRuc=n)},v2z:function(n){n!==undefined&&(gx.O.Z2046VenRuc=n)},v2c:function(){gx.fn.setControlValue("VENRUC",gx.O.A2046VenRuc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2046VenRuc=this.val())},val:function(){return gx.fn.getControlValue("VENRUC")},nac:gx.falseFn};n[49]={id:49,fld:"TEXTBLOCK7",format:0,grid:0,ctrltype:"textblock"};n[51]={id:51,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VENSTS",gxz:"Z2047VenSts",gxold:"O2047VenSts",gxvar:"A2047VenSts",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.A2047VenSts=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z2047VenSts=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("VENSTS",gx.O.A2047VenSts)},c2v:function(){this.val()!==undefined&&(gx.O.A2047VenSts=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("VENSTS",",")},nac:gx.falseFn};n[54]={id:54,fld:"TEXTBLOCK8",format:0,grid:0,ctrltype:"textblock"};n[56]={id:56,lvl:0,type:"char",len:1,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VENTIPO",gxz:"Z2049VenTipo",gxold:"O2049VenTipo",gxvar:"A2049VenTipo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.A2049VenTipo=n)},v2z:function(n){n!==undefined&&(gx.O.Z2049VenTipo=n)},v2c:function(){gx.fn.setComboBoxValue("VENTIPO",gx.O.A2049VenTipo)},c2v:function(){this.val()!==undefined&&(gx.O.A2049VenTipo=this.val())},val:function(){return gx.fn.getControlValue("VENTIPO")},nac:gx.falseFn};n[59]={id:59,fld:"BTN_ENTER",grid:0,evt:"e113z138_client",std:"ENTER"};n[60]={id:60,fld:"BTN_CHECK",grid:0,evt:"e193z138_client",std:"CHECK"};n[61]={id:61,fld:"BTN_CANCEL",grid:0,evt:"e123z138_client"};n[62]={id:62,fld:"BTN_DELETE",grid:0,evt:"e203z138_client",std:"DELETE"};n[63]={id:63,fld:"BTN_HELP",grid:0,evt:"e213z138_client"};this.A309VenCod=0;this.Z309VenCod=0;this.O309VenCod=0;this.A2045VenDsc="";this.Z2045VenDsc="";this.O2045VenDsc="";this.A2044VenDir="";this.Z2044VenDir="";this.O2044VenDir="";this.A2048VenTelf="";this.Z2048VenTelf="";this.O2048VenTelf="";this.A2043VenCel="";this.Z2043VenCel="";this.O2043VenCel="";this.A2046VenRuc="";this.Z2046VenRuc="";this.O2046VenRuc="";this.A2047VenSts=0;this.Z2047VenSts=0;this.O2047VenSts=0;this.A2049VenTipo="";this.Z2049VenTipo="";this.O2049VenTipo="";this.A309VenCod=0;this.A2045VenDsc="";this.A2044VenDir="";this.A2048VenTelf="";this.A2043VenCel="";this.A2046VenRuc="";this.A2047VenSts=0;this.A2049VenTipo="";this.Events={e113z138_client:["ENTER",!0],e123z138_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_VENCOD=[[{ctrl:"VENTIPO"},{av:"A2049VenTipo",fld:"VENTIPO",pic:""},{ctrl:"VENSTS"},{av:"A2047VenSts",fld:"VENSTS",pic:"9"},{av:"A309VenCod",fld:"VENCOD",pic:"ZZZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A2045VenDsc",fld:"VENDSC",pic:""},{av:"A2044VenDir",fld:"VENDIR",pic:""},{av:"A2048VenTelf",fld:"VENTELF",pic:""},{av:"A2043VenCel",fld:"VENCEL",pic:""},{av:"A2046VenRuc",fld:"VENRUC",pic:""},{ctrl:"VENSTS"},{av:"A2047VenSts",fld:"VENSTS",pic:"9"},{ctrl:"VENTIPO"},{av:"A2049VenTipo",fld:"VENTIPO",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z309VenCod"},{av:"Z2045VenDsc"},{av:"Z2044VenDir"},{av:"Z2048VenTelf"},{av:"Z2043VenCel"},{av:"Z2046VenRuc"},{av:"Z2047VenSts"},{av:"Z2049VenTipo"},{ctrl:"BTN_GET",prop:"Enabled"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"},{ctrl:"BTN_CHECK",prop:"Enabled"}]];this.EnterCtrl=["BTN_ENTER"];this.CheckCtrl=["BTN_CHECK"];this.Initialize()});gx.wi(function(){gx.createParentObj(this.cvendedores)})