gx.evt.autoSkip=!1;gx.define("cpordencron",!1,function(){this.ServerClass="cpordencron";this.PackageName="GeneXus.Programs";this.ServerFullClass="cpordencron.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Ordcod=function(){return this.validSrvEvt("Valid_Ordcod",0).then(function(n){return n}.closure(this))};this.Valid_Ordcron=function(){return this.validSrvEvt("Valid_Ordcron",0).then(function(n){return n}.closure(this))};this.Valid_Ordcronfec=function(){return this.validCliEvt("Valid_Ordcronfec",0,function(){try{var n=gx.util.balloon.getNew("ORDCRONFEC");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.A1428OrdCronFec)==0||new gx.date.gxdate(this.A1428OrdCronFec).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Fecha fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e117b122_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e127b122_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52];this.GXLastCtrlId=52;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"TABLEMAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"BTN_FIRST",grid:0,evt:"e137b122_client",std:"FIRST"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"BTN_PREVIOUS",grid:0,evt:"e147b122_client",std:"PREVIOUS"};n[15]={id:15,fld:"",grid:0};n[16]={id:16,fld:"BTN_NEXT",grid:0,evt:"e157b122_client",std:"NEXT"};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"BTN_LAST",grid:0,evt:"e167b122_client",std:"LAST"};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"BTN_SELECT",grid:0,evt:"e177b122_client",std:"SELECT"};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,lvl:0,type:"char",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Ordcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ORDCOD",gxz:"Z289OrdCod",gxold:"O289OrdCod",gxvar:"A289OrdCod",ucs:[],op:[],ip:[28],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A289OrdCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z289OrdCod=n)},v2c:function(){gx.fn.setControlValue("ORDCOD",gx.O.A289OrdCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A289OrdCod=this.val())},val:function(){return gx.fn.getControlValue("ORDCOD")},nac:gx.falseFn};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Ordcron,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ORDCRON",gxz:"Z294OrdCron",gxold:"O294OrdCron",gxvar:"A294OrdCron",ucs:[],op:[43,38],ip:[43,38,33,28],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A294OrdCron=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z294OrdCron=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("ORDCRON",gx.O.A294OrdCron,0)},c2v:function(){this.val()!==undefined&&(gx.O.A294OrdCron=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("ORDCRON",",")},nac:gx.falseFn};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Ordcronfec,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ORDCRONFEC",gxz:"Z1428OrdCronFec",gxold:"O1428OrdCronFec",gxvar:"A1428OrdCronFec",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[38],ip:[38],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1428OrdCronFec=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z1428OrdCronFec=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("ORDCRONFEC",gx.O.A1428OrdCronFec,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1428OrdCronFec=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("ORDCRONFEC")},nac:gx.falseFn};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ORDCRONREF",gxz:"Z1429OrdCronRef",gxold:"O1429OrdCronRef",gxvar:"A1429OrdCronRef",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1429OrdCronRef=n)},v2z:function(n){n!==undefined&&(gx.O.Z1429OrdCronRef=n)},v2c:function(){gx.fn.setControlValue("ORDCRONREF",gx.O.A1429OrdCronRef,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1429OrdCronRef=this.val())},val:function(){return gx.fn.getControlValue("ORDCRONREF")},nac:gx.falseFn};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"BTN_ENTER",grid:0,evt:"e117b122_client",std:"ENTER"};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"BTN_CANCEL",grid:0,evt:"e127b122_client"};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"BTN_DELETE",grid:0,evt:"e187b122_client",std:"DELETE"};this.A289OrdCod="";this.Z289OrdCod="";this.O289OrdCod="";this.A294OrdCron=0;this.Z294OrdCron=0;this.O294OrdCron=0;this.A1428OrdCronFec=gx.date.nullDate();this.Z1428OrdCronFec=gx.date.nullDate();this.O1428OrdCronFec=gx.date.nullDate();this.A1429OrdCronRef="";this.Z1429OrdCronRef="";this.O1429OrdCronRef="";this.A289OrdCod="";this.A294OrdCron=0;this.A1428OrdCronFec=gx.date.nullDate();this.A1429OrdCronRef="";this.Events={e117b122_client:["ENTER",!0],e127b122_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_ORDCOD=[[{av:"A289OrdCod",fld:"ORDCOD",pic:""}],[]];this.EvtParms.VALID_ORDCRON=[[{av:"A289OrdCod",fld:"ORDCOD",pic:""},{av:"A294OrdCron",fld:"ORDCRON",pic:"ZZZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A1428OrdCronFec",fld:"ORDCRONFEC",pic:""},{av:"A1429OrdCronRef",fld:"ORDCRONREF",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z289OrdCod"},{av:"Z294OrdCron"},{av:"Z1428OrdCronFec"},{av:"Z1429OrdCronRef"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"}]];this.EvtParms.VALID_ORDCRONFEC=[[{av:"A1428OrdCronFec",fld:"ORDCRONFEC",pic:""}],[{av:"A1428OrdCronFec",fld:"ORDCRONFEC",pic:""}]];this.EnterCtrl=["BTN_ENTER"];this.Initialize()});gx.wi(function(){gx.createParentObj(this.cpordencron)})