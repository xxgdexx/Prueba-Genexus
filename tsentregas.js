gx.evt.autoSkip=!1;gx.define("tsentregas",!1,function(){this.ServerClass="tsentregas";this.PackageName="GeneXus.Programs";this.ServerFullClass="tsentregas.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Entcod=function(){return this.validSrvEvt("Valid_Entcod",0).then(function(n){return n}.closure(this))};this.Valid_Cuecod=function(){return this.validSrvEvt("Valid_Cuecod",0).then(function(n){return n}.closure(this))};this.Valid_Tipacod=function(){return this.validCliEvt("Valid_Tipacod",0,function(){try{var n=gx.util.balloon.getNew("TIPACOD");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Entcodaux=function(){return this.validSrvEvt("Valid_Entcodaux",0).then(function(n){return n}.closure(this))};this.e1158175_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e1258175_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,5,6,7,8,9,15,18,20,21,24,26,29,31,34,36,39,41,44,46,49,51,54,56,59,61,64,65,66,67,68];this.GXLastCtrlId=68;n[2]={id:2,fld:"TABLE1",grid:0};n[5]={id:5,fld:"BTN_FIRST",grid:0,evt:"e1358175_client",std:"FIRST"};n[6]={id:6,fld:"BTN_PREVIOUS",grid:0,evt:"e1458175_client",std:"PREVIOUS"};n[7]={id:7,fld:"BTN_NEXT",grid:0,evt:"e1558175_client",std:"NEXT"};n[8]={id:8,fld:"BTN_LAST",grid:0,evt:"e1658175_client",std:"LAST"};n[9]={id:9,fld:"BTN_SELECT",grid:0,evt:"e1758175_client",std:"SELECT"};n[15]={id:15,fld:"TABLE2",grid:0};n[18]={id:18,fld:"TEXTBLOCK1",format:0,grid:0,ctrltype:"textblock"};n[20]={id:20,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Entcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ENTCOD",gxz:"Z365EntCod",gxold:"O365EntCod",gxvar:"A365EntCod",ucs:[],op:[51,36,61,31,26],ip:[51,36,61,31,26,20],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A365EntCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z365EntCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("ENTCOD",gx.O.A365EntCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A365EntCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("ENTCOD",",")},nac:gx.falseFn};n[21]={id:21,fld:"BTN_GET",grid:0,evt:"e1858175_client",std:"GET"};n[24]={id:24,fld:"TEXTBLOCK2",format:0,grid:0,ctrltype:"textblock"};n[26]={id:26,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ENTDSC",gxz:"Z972EntDsc",gxold:"O972EntDsc",gxvar:"A972EntDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A972EntDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z972EntDsc=n)},v2c:function(){gx.fn.setControlValue("ENTDSC",gx.O.A972EntDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A972EntDsc=this.val())},val:function(){return gx.fn.getControlValue("ENTDSC")},nac:gx.falseFn};n[29]={id:29,fld:"TEXTBLOCK3",format:0,grid:0,ctrltype:"textblock"};n[31]={id:31,lvl:0,type:"char",len:5,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ENTABR",gxz:"Z969EntAbr",gxold:"O969EntAbr",gxvar:"A969EntAbr",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A969EntAbr=n)},v2z:function(n){n!==undefined&&(gx.O.Z969EntAbr=n)},v2c:function(){gx.fn.setControlValue("ENTABR",gx.O.A969EntAbr,0)},c2v:function(){this.val()!==undefined&&(gx.O.A969EntAbr=this.val())},val:function(){return gx.fn.getControlValue("ENTABR")},nac:gx.falseFn};n[34]={id:34,fld:"TEXTBLOCK4",format:0,grid:0,ctrltype:"textblock"};n[36]={id:36,lvl:0,type:"char",len:15,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cuecod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUECOD",gxz:"Z91CueCod",gxold:"O91CueCod",gxvar:"A91CueCod",ucs:[],op:[46,41],ip:[46,41,36],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A91CueCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z91CueCod=n)},v2c:function(){gx.fn.setControlValue("CUECOD",gx.O.A91CueCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A91CueCod=this.val())},val:function(){return gx.fn.getControlValue("CUECOD")},nac:gx.falseFn};n[39]={id:39,fld:"TEXTBLOCK5",format:0,grid:0,ctrltype:"textblock"};n[41]={id:41,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUEDSC",gxz:"Z860CueDsc",gxold:"O860CueDsc",gxvar:"A860CueDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A860CueDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z860CueDsc=n)},v2c:function(){gx.fn.setControlValue("CUEDSC",gx.O.A860CueDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A860CueDsc=this.val())},val:function(){return gx.fn.getControlValue("CUEDSC")},nac:gx.falseFn};n[44]={id:44,fld:"TEXTBLOCK6",format:0,grid:0,ctrltype:"textblock"};n[46]={id:46,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Tipacod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TIPACOD",gxz:"Z70TipACod",gxold:"O70TipACod",gxvar:"A70TipACod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A70TipACod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z70TipACod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("TIPACOD",gx.O.A70TipACod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A70TipACod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("TIPACOD",",")},nac:gx.falseFn};n[49]={id:49,fld:"TEXTBLOCK7",format:0,grid:0,ctrltype:"textblock"};n[51]={id:51,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Entcodaux,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ENTCODAUX",gxz:"Z970EntCodAux",gxold:"O970EntCodAux",gxvar:"A970EntCodAux",ucs:[],op:[56],ip:[56,51,46],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A970EntCodAux=n)},v2z:function(n){n!==undefined&&(gx.O.Z970EntCodAux=n)},v2c:function(){gx.fn.setControlValue("ENTCODAUX",gx.O.A970EntCodAux,0)},c2v:function(){this.val()!==undefined&&(gx.O.A970EntCodAux=this.val())},val:function(){return gx.fn.getControlValue("ENTCODAUX")},nac:gx.falseFn};n[54]={id:54,fld:"TEXTBLOCK8",format:0,grid:0,ctrltype:"textblock"};n[56]={id:56,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ENTCODAUXDSC",gxz:"Z971EntCodAuxDsc",gxold:"O971EntCodAuxDsc",gxvar:"A971EntCodAuxDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A971EntCodAuxDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z971EntCodAuxDsc=n)},v2c:function(){gx.fn.setControlValue("ENTCODAUXDSC",gx.O.A971EntCodAuxDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A971EntCodAuxDsc=this.val())},val:function(){return gx.fn.getControlValue("ENTCODAUXDSC")},nac:gx.falseFn};n[59]={id:59,fld:"TEXTBLOCK9",format:0,grid:0,ctrltype:"textblock"};n[61]={id:61,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ENTSTS",gxz:"Z973EntSts",gxold:"O973EntSts",gxvar:"A973EntSts",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.A973EntSts=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z973EntSts=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("ENTSTS",gx.O.A973EntSts)},c2v:function(){this.val()!==undefined&&(gx.O.A973EntSts=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("ENTSTS",",")},nac:gx.falseFn};n[64]={id:64,fld:"BTN_ENTER",grid:0,evt:"e1158175_client",std:"ENTER"};n[65]={id:65,fld:"BTN_CHECK",grid:0,evt:"e1958175_client",std:"CHECK"};n[66]={id:66,fld:"BTN_CANCEL",grid:0,evt:"e1258175_client"};n[67]={id:67,fld:"BTN_DELETE",grid:0,evt:"e2058175_client",std:"DELETE"};n[68]={id:68,fld:"BTN_HELP",grid:0,evt:"e2158175_client"};this.A365EntCod=0;this.Z365EntCod=0;this.O365EntCod=0;this.A972EntDsc="";this.Z972EntDsc="";this.O972EntDsc="";this.A969EntAbr="";this.Z969EntAbr="";this.O969EntAbr="";this.A91CueCod="";this.Z91CueCod="";this.O91CueCod="";this.A860CueDsc="";this.Z860CueDsc="";this.O860CueDsc="";this.A70TipACod=0;this.Z70TipACod=0;this.O70TipACod=0;this.A970EntCodAux="";this.Z970EntCodAux="";this.O970EntCodAux="";this.A971EntCodAuxDsc="";this.Z971EntCodAuxDsc="";this.O971EntCodAuxDsc="";this.A973EntSts=0;this.Z973EntSts=0;this.O973EntSts=0;this.A365EntCod=0;this.A972EntDsc="";this.A969EntAbr="";this.A91CueCod="";this.A860CueDsc="";this.A70TipACod=0;this.A970EntCodAux="";this.A971EntCodAuxDsc="";this.A973EntSts=0;this.Events={e1158175_client:["ENTER",!0],e1258175_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_ENTCOD=[[{ctrl:"ENTSTS"},{av:"A973EntSts",fld:"ENTSTS",pic:"9"},{av:"A365EntCod",fld:"ENTCOD",pic:"ZZZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A972EntDsc",fld:"ENTDSC",pic:""},{av:"A969EntAbr",fld:"ENTABR",pic:""},{av:"A91CueCod",fld:"CUECOD",pic:""},{av:"A970EntCodAux",fld:"ENTCODAUX",pic:""},{ctrl:"ENTSTS"},{av:"A973EntSts",fld:"ENTSTS",pic:"9"},{av:"A860CueDsc",fld:"CUEDSC",pic:""},{av:"A70TipACod",fld:"TIPACOD",pic:"ZZZZZ9"},{av:"A971EntCodAuxDsc",fld:"ENTCODAUXDSC",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z365EntCod"},{av:"Z972EntDsc"},{av:"Z969EntAbr"},{av:"Z91CueCod"},{av:"Z970EntCodAux"},{av:"Z973EntSts"},{av:"Z860CueDsc"},{av:"Z70TipACod"},{av:"Z971EntCodAuxDsc"},{ctrl:"BTN_GET",prop:"Enabled"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"},{ctrl:"BTN_CHECK",prop:"Enabled"}]];this.EvtParms.VALID_CUECOD=[[{av:"A91CueCod",fld:"CUECOD",pic:""},{av:"A860CueDsc",fld:"CUEDSC",pic:""},{av:"A70TipACod",fld:"TIPACOD",pic:"ZZZZZ9"}],[{av:"A860CueDsc",fld:"CUEDSC",pic:""},{av:"A70TipACod",fld:"TIPACOD",pic:"ZZZZZ9"}]];this.EvtParms.VALID_TIPACOD=[[],[]];this.EvtParms.VALID_ENTCODAUX=[[{av:"A70TipACod",fld:"TIPACOD",pic:"ZZZZZ9"},{av:"A970EntCodAux",fld:"ENTCODAUX",pic:""},{av:"A971EntCodAuxDsc",fld:"ENTCODAUXDSC",pic:""}],[{av:"A971EntCodAuxDsc",fld:"ENTCODAUXDSC",pic:""}]];this.EnterCtrl=["BTN_ENTER"];this.CheckCtrl=["BTN_CHECK"];this.Initialize()});gx.wi(function(){gx.createParentObj(this.tsentregas)})