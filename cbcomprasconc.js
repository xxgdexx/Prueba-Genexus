gx.evt.autoSkip=!1;gx.define("cbcomprasconc",!1,function(){this.ServerClass="cbcomprasconc";this.PackageName="GeneXus.Programs";this.ServerFullClass="cbcomprasconc.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Cconpcod=function(){return this.validSrvEvt("Valid_Cconpcod",0).then(function(n){return n}.closure(this))};this.Valid_Cconpcuecod=function(){return this.validSrvEvt("Valid_Cconpcuecod",0).then(function(n){return n}.closure(this))};this.e111o57_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e121o57_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,5,6,7,8,9,15,18,20,21,24,26,29,31,34,36,39,41,44,45,46,47,48];this.GXLastCtrlId=48;n[2]={id:2,fld:"TABLE1",grid:0};n[5]={id:5,fld:"BTN_FIRST",grid:0,evt:"e131o57_client",std:"FIRST"};n[6]={id:6,fld:"BTN_PREVIOUS",grid:0,evt:"e141o57_client",std:"PREVIOUS"};n[7]={id:7,fld:"BTN_NEXT",grid:0,evt:"e151o57_client",std:"NEXT"};n[8]={id:8,fld:"BTN_LAST",grid:0,evt:"e161o57_client",std:"LAST"};n[9]={id:9,fld:"BTN_SELECT",grid:0,evt:"e171o57_client",std:"SELECT"};n[15]={id:15,fld:"TABLE2",grid:0};n[18]={id:18,fld:"TEXTBLOCK1",format:0,grid:0,ctrltype:"textblock"};n[20]={id:20,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cconpcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CCONPCOD",gxz:"Z76CConpCod",gxold:"O76CConpCod",gxvar:"A76CConpCod",ucs:[],op:[31,41,26],ip:[31,41,26,20],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A76CConpCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z76CConpCod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("CCONPCOD",gx.O.A76CConpCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A76CConpCod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CCONPCOD",",")},nac:gx.falseFn};n[21]={id:21,fld:"BTN_GET",grid:0,evt:"e181o57_client",std:"GET"};n[24]={id:24,fld:"TEXTBLOCK2",format:0,grid:0,ctrltype:"textblock"};n[26]={id:26,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CCONPDSC",gxz:"Z78CConpDsc",gxold:"O78CConpDsc",gxvar:"A78CConpDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A78CConpDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z78CConpDsc=n)},v2c:function(){gx.fn.setControlValue("CCONPDSC",gx.O.A78CConpDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A78CConpDsc=this.val())},val:function(){return gx.fn.getControlValue("CCONPDSC")},nac:gx.falseFn};n[29]={id:29,fld:"TEXTBLOCK3",format:0,grid:0,ctrltype:"textblock"};n[31]={id:31,lvl:0,type:"char",len:15,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cconpcuecod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CCONPCUECOD",gxz:"Z77CConpCueCod",gxold:"O77CConpCueCod",gxvar:"A77CConpCueCod",ucs:[],op:[36],ip:[36,31],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A77CConpCueCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z77CConpCueCod=n)},v2c:function(){gx.fn.setControlValue("CCONPCUECOD",gx.O.A77CConpCueCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A77CConpCueCod=this.val())},val:function(){return gx.fn.getControlValue("CCONPCUECOD")},nac:gx.falseFn};n[34]={id:34,fld:"TEXTBLOCK4",format:0,grid:0,ctrltype:"textblock"};n[36]={id:36,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CCONPCUEDSC",gxz:"Z516CConpCueDsc",gxold:"O516CConpCueDsc",gxvar:"A516CConpCueDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A516CConpCueDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z516CConpCueDsc=n)},v2c:function(){gx.fn.setControlValue("CCONPCUEDSC",gx.O.A516CConpCueDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A516CConpCueDsc=this.val())},val:function(){return gx.fn.getControlValue("CCONPCUEDSC")},nac:gx.falseFn};n[39]={id:39,fld:"TEXTBLOCK5",format:0,grid:0,ctrltype:"textblock"};n[41]={id:41,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CCONPSTS",gxz:"Z517CConpSts",gxold:"O517CConpSts",gxvar:"A517CConpSts",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.A517CConpSts=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z517CConpSts=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("CCONPSTS",gx.O.A517CConpSts)},c2v:function(){this.val()!==undefined&&(gx.O.A517CConpSts=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CCONPSTS",",")},nac:gx.falseFn};n[44]={id:44,fld:"BTN_ENTER",grid:0,evt:"e111o57_client",std:"ENTER"};n[45]={id:45,fld:"BTN_CHECK",grid:0,evt:"e191o57_client",std:"CHECK"};n[46]={id:46,fld:"BTN_CANCEL",grid:0,evt:"e121o57_client"};n[47]={id:47,fld:"BTN_DELETE",grid:0,evt:"e201o57_client",std:"DELETE"};n[48]={id:48,fld:"BTN_HELP",grid:0,evt:"e211o57_client"};this.A76CConpCod=0;this.Z76CConpCod=0;this.O76CConpCod=0;this.A78CConpDsc="";this.Z78CConpDsc="";this.O78CConpDsc="";this.A77CConpCueCod="";this.Z77CConpCueCod="";this.O77CConpCueCod="";this.A516CConpCueDsc="";this.Z516CConpCueDsc="";this.O516CConpCueDsc="";this.A517CConpSts=0;this.Z517CConpSts=0;this.O517CConpSts=0;this.A76CConpCod=0;this.A78CConpDsc="";this.A77CConpCueCod="";this.A516CConpCueDsc="";this.A517CConpSts=0;this.Events={e111o57_client:["ENTER",!0],e121o57_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_CCONPCOD=[[{ctrl:"CCONPSTS"},{av:"A517CConpSts",fld:"CCONPSTS",pic:"9"},{av:"A76CConpCod",fld:"CCONPCOD",pic:"ZZZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A78CConpDsc",fld:"CCONPDSC",pic:""},{av:"A77CConpCueCod",fld:"CCONPCUECOD",pic:""},{ctrl:"CCONPSTS"},{av:"A517CConpSts",fld:"CCONPSTS",pic:"9"},{av:"A516CConpCueDsc",fld:"CCONPCUEDSC",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z76CConpCod"},{av:"Z78CConpDsc"},{av:"Z77CConpCueCod"},{av:"Z517CConpSts"},{av:"Z516CConpCueDsc"},{ctrl:"BTN_GET",prop:"Enabled"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"},{ctrl:"BTN_CHECK",prop:"Enabled"}]];this.EvtParms.VALID_CCONPCUECOD=[[{av:"A77CConpCueCod",fld:"CCONPCUECOD",pic:""},{av:"A516CConpCueDsc",fld:"CCONPCUEDSC",pic:""}],[{av:"A516CConpCueDsc",fld:"CCONPCUEDSC",pic:""}]];this.EnterCtrl=["BTN_ENTER"];this.CheckCtrl=["BTN_CHECK"];this.Initialize()});gx.wi(function(){gx.createParentObj(this.cbcomprasconc)})