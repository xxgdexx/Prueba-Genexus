gx.evt.autoSkip=!1;gx.define("aguiasconsigna",!1,function(){this.ServerClass="aguiasconsigna";this.PackageName="GeneXus.Programs";this.ServerFullClass="aguiasconsigna.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Agmvatip=function(){return this.validCliEvt("Valid_Agmvatip",0,function(){try{var n=gx.util.balloon.getNew("AGMVATIP");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Agmvacod=function(){return this.validCliEvt("Valid_Agmvacod",0,function(){try{var n=gx.util.balloon.getNew("AGMVACOD");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Prodcod=function(){return this.validSrvEvt("Valid_Prodcod",0).then(function(n){return n}.closure(this))};this.Valid_Agmvafec=function(){return this.validCliEvt("Valid_Agmvafec",0,function(){try{var n=gx.util.balloon.getNew("AGMVAFEC");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.A431AGMVAFec)==0||new gx.date.gxdate(this.A431AGMVAFec).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Fecha fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Agclicod=function(){return this.validSrvEvt("Valid_Agclicod",0).then(function(n){return n}.closure(this))};this.Valid_Agmvadcant=function(){return this.validCliEvt("Valid_Agmvadcant",0,function(){try{var n=gx.util.balloon.getNew("AGMVADCANT");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Agmvadcantf=function(){return this.validCliEvt("Valid_Agmvadcantf",0,function(){try{var n=gx.util.balloon.getNew("AGMVADCANTF");this.AnyError=0;try{this.A430AGMVADCantP=this.A428AGMVADCant-this.A429AGMVADCantF}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e111539_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e121539_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,5,6,7,8,9,15,18,20,23,25,28,30,33,35,38,40,43,45,48,50,51,54,56,59,61,64,66,69,71,74,75,76,77,78];this.GXLastCtrlId=78;n[2]={id:2,fld:"TABLE1",grid:0};n[5]={id:5,fld:"BTN_FIRST",grid:0,evt:"e131539_client",std:"FIRST"};n[6]={id:6,fld:"BTN_PREVIOUS",grid:0,evt:"e141539_client",std:"PREVIOUS"};n[7]={id:7,fld:"BTN_NEXT",grid:0,evt:"e151539_client",std:"NEXT"};n[8]={id:8,fld:"BTN_LAST",grid:0,evt:"e161539_client",std:"LAST"};n[9]={id:9,fld:"BTN_SELECT",grid:0,evt:"e171539_client",std:"SELECT"};n[15]={id:15,fld:"TABLE2",grid:0};n[18]={id:18,fld:"TEXTBLOCK1",format:0,grid:0,ctrltype:"textblock"};n[20]={id:20,lvl:0,type:"char",len:3,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Agmvatip,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AGMVATIP",gxz:"Z26AGMVATip",gxold:"O26AGMVATip",gxvar:"A26AGMVATip",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A26AGMVATip=n)},v2z:function(n){n!==undefined&&(gx.O.Z26AGMVATip=n)},v2c:function(){gx.fn.setControlValue("AGMVATIP",gx.O.A26AGMVATip,0)},c2v:function(){this.val()!==undefined&&(gx.O.A26AGMVATip=this.val())},val:function(){return gx.fn.getControlValue("AGMVATIP")},nac:gx.falseFn};n[23]={id:23,fld:"TEXTBLOCK2",format:0,grid:0,ctrltype:"textblock"};n[25]={id:25,lvl:0,type:"char",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Agmvacod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AGMVACOD",gxz:"Z27AGMVACod",gxold:"O27AGMVACod",gxvar:"A27AGMVACod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A27AGMVACod=n)},v2z:function(n){n!==undefined&&(gx.O.Z27AGMVACod=n)},v2c:function(){gx.fn.setControlValue("AGMVACOD",gx.O.A27AGMVACod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A27AGMVACod=this.val())},val:function(){return gx.fn.getControlValue("AGMVACOD")},nac:gx.falseFn};n[28]={id:28,fld:"TEXTBLOCK3",format:0,grid:0,ctrltype:"textblock"};n[30]={id:30,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Agmvafec,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AGMVAFEC",gxz:"Z431AGMVAFec",gxold:"O431AGMVAFec",gxvar:"A431AGMVAFec",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[30],ip:[30],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A431AGMVAFec=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z431AGMVAFec=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("AGMVAFEC",gx.O.A431AGMVAFec,0)},c2v:function(){this.val()!==undefined&&(gx.O.A431AGMVAFec=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("AGMVAFEC")},nac:gx.falseFn};n[33]={id:33,fld:"TEXTBLOCK4",format:0,grid:0,ctrltype:"textblock"};n[35]={id:35,lvl:0,type:"char",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AGPEDCOD",gxz:"Z432AGPedCod",gxold:"O432AGPedCod",gxvar:"A432AGPedCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A432AGPedCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z432AGPedCod=n)},v2c:function(){gx.fn.setControlValue("AGPEDCOD",gx.O.A432AGPedCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A432AGPedCod=this.val())},val:function(){return gx.fn.getControlValue("AGPEDCOD")},nac:gx.falseFn};n[38]={id:38,fld:"TEXTBLOCK5",format:0,grid:0,ctrltype:"textblock"};n[40]={id:40,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Agclicod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AGCLICOD",gxz:"Z29AGCliCod",gxold:"O29AGCliCod",gxvar:"A29AGCliCod",ucs:[],op:[45],ip:[45,40],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A29AGCliCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z29AGCliCod=n)},v2c:function(){gx.fn.setControlValue("AGCLICOD",gx.O.A29AGCliCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A29AGCliCod=this.val())},val:function(){return gx.fn.getControlValue("AGCLICOD")},nac:gx.falseFn};n[43]={id:43,fld:"TEXTBLOCK6",format:0,grid:0,ctrltype:"textblock"};n[45]={id:45,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AGCLIDSC",gxz:"Z427AGCliDsc",gxold:"O427AGCliDsc",gxvar:"A427AGCliDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A427AGCliDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z427AGCliDsc=n)},v2c:function(){gx.fn.setControlValue("AGCLIDSC",gx.O.A427AGCliDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A427AGCliDsc=this.val())},val:function(){return gx.fn.getControlValue("AGCLIDSC")},nac:gx.falseFn};n[48]={id:48,fld:"TEXTBLOCK7",format:0,grid:0,ctrltype:"textblock"};n[50]={id:50,lvl:0,type:"char",len:15,dec:0,sign:!1,pic:"@!",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Prodcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODCOD",gxz:"Z28ProdCod",gxold:"O28ProdCod",gxvar:"A28ProdCod",ucs:[],op:[56,40,66,61,35,30],ip:[56,40,66,61,35,30,50,25,20],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A28ProdCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z28ProdCod=n)},v2c:function(){gx.fn.setControlValue("PRODCOD",gx.O.A28ProdCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A28ProdCod=this.val())},val:function(){return gx.fn.getControlValue("PRODCOD")},nac:gx.falseFn};n[51]={id:51,fld:"BTN_GET",grid:0,evt:"e181539_client",std:"GET"};n[54]={id:54,fld:"TEXTBLOCK8",format:0,grid:0,ctrltype:"textblock"};n[56]={id:56,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODDSC",gxz:"Z55ProdDsc",gxold:"O55ProdDsc",gxvar:"A55ProdDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A55ProdDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z55ProdDsc=n)},v2c:function(){gx.fn.setControlValue("PRODDSC",gx.O.A55ProdDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A55ProdDsc=this.val())},val:function(){return gx.fn.getControlValue("PRODDSC")},nac:gx.falseFn};n[59]={id:59,fld:"TEXTBLOCK9",format:0,grid:0,ctrltype:"textblock"};n[61]={id:61,lvl:0,type:"decimal",len:15,dec:4,sign:!0,pic:"ZZZZ,ZZZ,ZZ9.9999",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Agmvadcant,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AGMVADCANT",gxz:"Z428AGMVADCant",gxold:"O428AGMVADCant",gxvar:"A428AGMVADCant",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A428AGMVADCant=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z428AGMVADCant=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("AGMVADCANT",gx.O.A428AGMVADCant,4,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A428AGMVADCant=this.val())},val:function(){return gx.fn.getDecimalValue("AGMVADCANT",",",".")},nac:gx.falseFn};this.declareDomainHdlr(61,function(){});n[64]={id:64,fld:"TEXTBLOCK10",format:0,grid:0,ctrltype:"textblock"};n[66]={id:66,lvl:0,type:"decimal",len:15,dec:4,sign:!0,pic:"ZZZZ,ZZZ,ZZ9.9999",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Agmvadcantf,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AGMVADCANTF",gxz:"Z429AGMVADCantF",gxold:"O429AGMVADCantF",gxvar:"A429AGMVADCantF",ucs:[],op:[71],ip:[71,66,61],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A429AGMVADCantF=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z429AGMVADCantF=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("AGMVADCANTF",gx.O.A429AGMVADCantF,4,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A429AGMVADCantF=this.val())},val:function(){return gx.fn.getDecimalValue("AGMVADCANTF",",",".")},nac:gx.falseFn};this.declareDomainHdlr(66,function(){});n[69]={id:69,fld:"TEXTBLOCK11",format:0,grid:0,ctrltype:"textblock"};n[71]={id:71,lvl:0,type:"decimal",len:15,dec:4,sign:!0,pic:"ZZZZ,ZZZ,ZZ9.9999",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AGMVADCANTP",gxz:"Z430AGMVADCantP",gxold:"O430AGMVADCantP",gxvar:"A430AGMVADCantP",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A430AGMVADCantP=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z430AGMVADCantP=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("AGMVADCANTP",gx.O.A430AGMVADCantP,4,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A430AGMVADCantP=this.val())},val:function(){return gx.fn.getDecimalValue("AGMVADCANTP",",",".")},nac:gx.falseFn};this.declareDomainHdlr(71,function(){});n[74]={id:74,fld:"BTN_ENTER",grid:0,evt:"e111539_client",std:"ENTER"};n[75]={id:75,fld:"BTN_CHECK",grid:0,evt:"e191539_client",std:"CHECK"};n[76]={id:76,fld:"BTN_CANCEL",grid:0,evt:"e121539_client"};n[77]={id:77,fld:"BTN_DELETE",grid:0,evt:"e201539_client",std:"DELETE"};n[78]={id:78,fld:"BTN_HELP",grid:0,evt:"e211539_client"};this.A26AGMVATip="";this.Z26AGMVATip="";this.O26AGMVATip="";this.A27AGMVACod="";this.Z27AGMVACod="";this.O27AGMVACod="";this.A431AGMVAFec=gx.date.nullDate();this.Z431AGMVAFec=gx.date.nullDate();this.O431AGMVAFec=gx.date.nullDate();this.A432AGPedCod="";this.Z432AGPedCod="";this.O432AGPedCod="";this.A29AGCliCod="";this.Z29AGCliCod="";this.O29AGCliCod="";this.A427AGCliDsc="";this.Z427AGCliDsc="";this.O427AGCliDsc="";this.A28ProdCod="";this.Z28ProdCod="";this.O28ProdCod="";this.A55ProdDsc="";this.Z55ProdDsc="";this.O55ProdDsc="";this.A428AGMVADCant=0;this.Z428AGMVADCant=0;this.O428AGMVADCant=0;this.A429AGMVADCantF=0;this.Z429AGMVADCantF=0;this.O429AGMVADCantF=0;this.A430AGMVADCantP=0;this.Z430AGMVADCantP=0;this.O430AGMVADCantP=0;this.A26AGMVATip="";this.A27AGMVACod="";this.A28ProdCod="";this.A430AGMVADCantP=0;this.A431AGMVAFec=gx.date.nullDate();this.A432AGPedCod="";this.A29AGCliCod="";this.A427AGCliDsc="";this.A55ProdDsc="";this.A428AGMVADCant=0;this.A429AGMVADCantF=0;this.Events={e111539_client:["ENTER",!0],e121539_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_AGMVATIP=[[],[]];this.EvtParms.VALID_AGMVACOD=[[],[]];this.EvtParms.VALID_AGMVAFEC=[[{av:"A431AGMVAFec",fld:"AGMVAFEC",pic:""}],[{av:"A431AGMVAFec",fld:"AGMVAFEC",pic:""}]];this.EvtParms.VALID_AGCLICOD=[[{av:"A29AGCliCod",fld:"AGCLICOD",pic:""},{av:"A427AGCliDsc",fld:"AGCLIDSC",pic:""}],[{av:"A427AGCliDsc",fld:"AGCLIDSC",pic:""}]];this.EvtParms.VALID_PRODCOD=[[{av:"A26AGMVATip",fld:"AGMVATIP",pic:""},{av:"A27AGMVACod",fld:"AGMVACOD",pic:""},{av:"A28ProdCod",fld:"PRODCOD",pic:"@!"},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A431AGMVAFec",fld:"AGMVAFEC",pic:""},{av:"A432AGPedCod",fld:"AGPEDCOD",pic:""},{av:"A29AGCliCod",fld:"AGCLICOD",pic:""},{av:"A428AGMVADCant",fld:"AGMVADCANT",pic:"ZZZZ,ZZZ,ZZ9.9999"},{av:"A429AGMVADCantF",fld:"AGMVADCANTF",pic:"ZZZZ,ZZZ,ZZ9.9999"},{av:"A427AGCliDsc",fld:"AGCLIDSC",pic:""},{av:"A55ProdDsc",fld:"PRODDSC",pic:""},{av:"A430AGMVADCantP",fld:"AGMVADCANTP",pic:"ZZZZ,ZZZ,ZZ9.9999"},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z26AGMVATip"},{av:"Z27AGMVACod"},{av:"Z28ProdCod"},{av:"Z431AGMVAFec"},{av:"Z432AGPedCod"},{av:"Z29AGCliCod"},{av:"Z428AGMVADCant"},{av:"Z429AGMVADCantF"},{av:"Z427AGCliDsc"},{av:"Z55ProdDsc"},{av:"Z430AGMVADCantP"},{ctrl:"BTN_GET",prop:"Enabled"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"},{ctrl:"BTN_CHECK",prop:"Enabled"}]];this.EvtParms.VALID_AGMVADCANT=[[],[]];this.EvtParms.VALID_AGMVADCANTF=[[{av:"A430AGMVADCantP",fld:"AGMVADCANTP",pic:"ZZZZ,ZZZ,ZZ9.9999"},{av:"A429AGMVADCantF",fld:"AGMVADCANTF",pic:"ZZZZ,ZZZ,ZZ9.9999"},{av:"A428AGMVADCant",fld:"AGMVADCANT",pic:"ZZZZ,ZZZ,ZZ9.9999"}],[{av:"A430AGMVADCantP",fld:"AGMVADCANTP",pic:"ZZZZ,ZZZ,ZZ9.9999"}]];this.EnterCtrl=["BTN_ENTER"];this.CheckCtrl=["BTN_CHECK"];this.Initialize()});gx.wi(function(){gx.createParentObj(this.aguiasconsigna)})