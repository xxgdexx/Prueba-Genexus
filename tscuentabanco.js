gx.evt.autoSkip=!1;gx.define("tscuentabanco",!1,function(){this.ServerClass="tscuentabanco";this.PackageName="GeneXus.Programs";this.ServerFullClass="tscuentabanco.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Bancod=function(){return this.validSrvEvt("Valid_Bancod",0).then(function(n){return n}.closure(this))};this.Valid_Cbcod=function(){return this.validSrvEvt("Valid_Cbcod",0).then(function(n){return n}.closure(this))};this.Valid_Moncod=function(){return this.validSrvEvt("Valid_Moncod",0).then(function(n){return n}.closure(this))};this.Valid_Cbcuecod=function(){return this.validSrvEvt("Valid_Cbcuecod",0).then(function(n){return n}.closure(this))};this.e1157174_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e1257174_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,5,6,7,8,9,15,18,20,23,25,26,29,31,34,36,39,41,44,46,49,51,54,56,59,61,64,65,66,67,68];this.GXLastCtrlId=68;n[2]={id:2,fld:"TABLE1",grid:0};n[5]={id:5,fld:"BTN_FIRST",grid:0,evt:"e1357174_client",std:"FIRST"};n[6]={id:6,fld:"BTN_PREVIOUS",grid:0,evt:"e1457174_client",std:"PREVIOUS"};n[7]={id:7,fld:"BTN_NEXT",grid:0,evt:"e1557174_client",std:"NEXT"};n[8]={id:8,fld:"BTN_LAST",grid:0,evt:"e1657174_client",std:"LAST"};n[9]={id:9,fld:"BTN_SELECT",grid:0,evt:"e1757174_client",std:"SELECT"};n[15]={id:15,fld:"TABLE2",grid:0};n[18]={id:18,fld:"TEXTBLOCK1",format:0,grid:0,ctrltype:"textblock"};n[20]={id:20,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Bancod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"BANCOD",gxz:"Z372BanCod",gxold:"O372BanCod",gxvar:"A372BanCod",ucs:[],op:[],ip:[20],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A372BanCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z372BanCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("BANCOD",gx.O.A372BanCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A372BanCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("BANCOD",",")},nac:gx.falseFn};n[23]={id:23,fld:"TEXTBLOCK2",format:0,grid:0,ctrltype:"textblock"};n[25]={id:25,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cbcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CBCOD",gxz:"Z377CBCod",gxold:"O377CBCod",gxvar:"A377CBCod",ucs:[],op:[36,31,56,51,46,41],ip:[36,31,56,51,46,41,25,20],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A377CBCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z377CBCod=n)},v2c:function(){gx.fn.setControlValue("CBCOD",gx.O.A377CBCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A377CBCod=this.val())},val:function(){return gx.fn.getControlValue("CBCOD")},nac:gx.falseFn};n[26]={id:26,fld:"BTN_GET",grid:0,evt:"e1857174_client",std:"GET"};n[29]={id:29,fld:"TEXTBLOCK3",format:0,grid:0,ctrltype:"textblock"};n[31]={id:31,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Moncod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MONCOD",gxz:"Z180MonCod",gxold:"O180MonCod",gxvar:"A180MonCod",ucs:[],op:[],ip:[31],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A180MonCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z180MonCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("MONCOD",gx.O.A180MonCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A180MonCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("MONCOD",",")},nac:gx.falseFn};n[34]={id:34,fld:"TEXTBLOCK4",format:0,grid:0,ctrltype:"textblock"};n[36]={id:36,lvl:0,type:"char",len:15,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cbcuecod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CBCUECOD",gxz:"Z378CBCueCod",gxold:"O378CBCueCod",gxvar:"A378CBCueCod",ucs:[],op:[61],ip:[61,36],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A378CBCueCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z378CBCueCod=n)},v2c:function(){gx.fn.setControlValue("CBCUECOD",gx.O.A378CBCueCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A378CBCueCod=this.val())},val:function(){return gx.fn.getControlValue("CBCUECOD")},nac:gx.falseFn};n[39]={id:39,fld:"TEXTBLOCK5",format:0,grid:0,ctrltype:"textblock"};n[41]={id:41,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CBSTS",gxz:"Z504CBSts",gxold:"O504CBSts",gxvar:"A504CBSts",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A504CBSts=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z504CBSts=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("CBSTS",gx.O.A504CBSts,0)},c2v:function(){this.val()!==undefined&&(gx.O.A504CBSts=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CBSTS",",")},nac:gx.falseFn};n[44]={id:44,fld:"TEXTBLOCK6",format:0,grid:0,ctrltype:"textblock"};n[46]={id:46,lvl:0,type:"int",len:10,dec:0,sign:!1,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CBCHEQINICIO",gxz:"Z490CBCheqInicio",gxold:"O490CBCheqInicio",gxvar:"A490CBCheqInicio",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A490CBCheqInicio=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z490CBCheqInicio=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("CBCHEQINICIO",gx.O.A490CBCheqInicio,0)},c2v:function(){this.val()!==undefined&&(gx.O.A490CBCheqInicio=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CBCHEQINICIO",",")},nac:gx.falseFn};n[49]={id:49,fld:"TEXTBLOCK7",format:0,grid:0,ctrltype:"textblock"};n[51]={id:51,lvl:0,type:"int",len:10,dec:0,sign:!1,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CBCHEQFINAL",gxz:"Z489CBCheqFinal",gxold:"O489CBCheqFinal",gxvar:"A489CBCheqFinal",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A489CBCheqFinal=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z489CBCheqFinal=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("CBCHEQFINAL",gx.O.A489CBCheqFinal,0)},c2v:function(){this.val()!==undefined&&(gx.O.A489CBCheqFinal=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CBCHEQFINAL",",")},nac:gx.falseFn};n[54]={id:54,fld:"TEXTBLOCK8",format:0,grid:0,ctrltype:"textblock"};n[56]={id:56,lvl:0,type:"int",len:10,dec:0,sign:!1,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CBCHEQACTUAL",gxz:"Z488CBCheqActual",gxold:"O488CBCheqActual",gxvar:"A488CBCheqActual",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A488CBCheqActual=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z488CBCheqActual=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("CBCHEQACTUAL",gx.O.A488CBCheqActual,0)},c2v:function(){this.val()!==undefined&&(gx.O.A488CBCheqActual=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CBCHEQACTUAL",",")},nac:gx.falseFn};n[59]={id:59,fld:"TEXTBLOCK9",format:0,grid:0,ctrltype:"textblock"};n[61]={id:61,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CBCUEDSC",gxz:"Z491CBCueDsc",gxold:"O491CBCueDsc",gxvar:"A491CBCueDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A491CBCueDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z491CBCueDsc=n)},v2c:function(){gx.fn.setControlValue("CBCUEDSC",gx.O.A491CBCueDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A491CBCueDsc=this.val())},val:function(){return gx.fn.getControlValue("CBCUEDSC")},nac:gx.falseFn};n[64]={id:64,fld:"BTN_ENTER",grid:0,evt:"e1157174_client",std:"ENTER"};n[65]={id:65,fld:"BTN_CHECK",grid:0,evt:"e1957174_client",std:"CHECK"};n[66]={id:66,fld:"BTN_CANCEL",grid:0,evt:"e1257174_client"};n[67]={id:67,fld:"BTN_DELETE",grid:0,evt:"e2057174_client",std:"DELETE"};n[68]={id:68,fld:"BTN_HELP",grid:0,evt:"e2157174_client"};this.A372BanCod=0;this.Z372BanCod=0;this.O372BanCod=0;this.A377CBCod="";this.Z377CBCod="";this.O377CBCod="";this.A180MonCod=0;this.Z180MonCod=0;this.O180MonCod=0;this.A378CBCueCod="";this.Z378CBCueCod="";this.O378CBCueCod="";this.A504CBSts=0;this.Z504CBSts=0;this.O504CBSts=0;this.A490CBCheqInicio=0;this.Z490CBCheqInicio=0;this.O490CBCheqInicio=0;this.A489CBCheqFinal=0;this.Z489CBCheqFinal=0;this.O489CBCheqFinal=0;this.A488CBCheqActual=0;this.Z488CBCheqActual=0;this.O488CBCheqActual=0;this.A491CBCueDsc="";this.Z491CBCueDsc="";this.O491CBCueDsc="";this.A372BanCod=0;this.A377CBCod="";this.A180MonCod=0;this.A378CBCueCod="";this.A504CBSts=0;this.A490CBCheqInicio=0;this.A489CBCheqFinal=0;this.A488CBCheqActual=0;this.A491CBCueDsc="";this.Events={e1157174_client:["ENTER",!0],e1257174_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_BANCOD=[[{av:"A372BanCod",fld:"BANCOD",pic:"ZZZZZ9"}],[]];this.EvtParms.VALID_CBCOD=[[{av:"A372BanCod",fld:"BANCOD",pic:"ZZZZZ9"},{av:"A377CBCod",fld:"CBCOD",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A180MonCod",fld:"MONCOD",pic:"ZZZZZ9"},{av:"A378CBCueCod",fld:"CBCUECOD",pic:""},{av:"A504CBSts",fld:"CBSTS",pic:"9"},{av:"A490CBCheqInicio",fld:"CBCHEQINICIO",pic:"ZZZZZZZZZ9"},{av:"A489CBCheqFinal",fld:"CBCHEQFINAL",pic:"ZZZZZZZZZ9"},{av:"A488CBCheqActual",fld:"CBCHEQACTUAL",pic:"ZZZZZZZZZ9"},{av:"A491CBCueDsc",fld:"CBCUEDSC",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z372BanCod"},{av:"Z377CBCod"},{av:"Z180MonCod"},{av:"Z378CBCueCod"},{av:"Z504CBSts"},{av:"Z490CBCheqInicio"},{av:"Z489CBCheqFinal"},{av:"Z488CBCheqActual"},{av:"Z491CBCueDsc"},{ctrl:"BTN_GET",prop:"Enabled"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"},{ctrl:"BTN_CHECK",prop:"Enabled"}]];this.EvtParms.VALID_MONCOD=[[{av:"A180MonCod",fld:"MONCOD",pic:"ZZZZZ9"}],[]];this.EvtParms.VALID_CBCUECOD=[[{av:"A378CBCueCod",fld:"CBCUECOD",pic:""},{av:"A491CBCueDsc",fld:"CBCUEDSC",pic:""}],[{av:"A491CBCueDsc",fld:"CBCUEDSC",pic:""}]];this.EnterCtrl=["BTN_ENTER"];this.CheckCtrl=["BTN_CHECK"];this.Initialize()});gx.wi(function(){gx.createParentObj(this.tscuentabanco)})