gx.evt.autoSkip=!1;gx.define("actsubgrupo",!1,function(){var n,t;this.ServerClass="actsubgrupo";this.PackageName="GeneXus.Programs";this.ServerFullClass="actsubgrupo.aspx";this.setObjectType("trn");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.A2228ACTSGrupTot=gx.fn.getIntegerValue("ACTSGRUPTOT",",")};this.Valid_Actclacod=function(){return this.validSrvEvt("Valid_Actclacod",0).then(function(n){return n}.closure(this))};this.Valid_Actgrupcod=function(){return this.validSrvEvt("Valid_Actgrupcod",0).then(function(n){return n}.closure(this))};this.Valid_Actsgrupcod=function(){return this.validSrvEvt("Valid_Actsgrupcod",0).then(function(n){return n}.closure(this))};this.Valid_Actssgrupcod=function(){var n=gx.fn.currentGridRowImpl(43);return this.validCliEvt("Valid_Actssgrupcod",43,function(){try{if(gx.fn.currentGridRowImpl(43)===0)return!0;var n=gx.util.balloon.getNew("ACTSSGRUPCOD",gx.fn.currentGridRowImpl(43));this.AnyError=0;this.sMode196=this.Gx_mode;this.Gx_mode=gx.fn.getGridRowMode(196,43);this.standaloneModal71196();this.standaloneNotModal71196();gx.fn.gridDuplicateKey(44)&&(n.setError(gx.text.format(gx.getMessage("GXM_1004"),"Level1","","","","","","","","")),this.AnyError=gx.num.trunc(1,0));this.refreshOutputs([{ctrl:"ACTCLACOD"},{av:"A426ACTClaCod",fld:"ACTCLACOD",pic:""},{ctrl:"ACTGRUPCOD"},{av:"A2103ACTGrupCod",fld:"ACTGRUPCOD",pic:""}])}catch(t){}try{return(this.Gx_mode=this.sMode196,n==null)?!0:n.show()}catch(t){}return!0})};this.standaloneModal71196=function(){};this.standaloneNotModal71196=function(){try{gx.fn.setCtrlProperty("ACTSSGRUPCOD","Enabled",0)}catch(n){}};this.e1171195_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e1271195_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,6,7,13,15,18,20,23,25,28,30,33,35,38,40,44,45,46,49,51];this.GXLastCtrlId=51;this.Grid1Container=new gx.grid.grid(this,196,"Level1",43,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"actsubgrupo",[2115],!1,1,!1,!0,5,!1,!1,!1,"",400,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!1,!1);t=this.Grid1Container;t.addSingleLineEdit(2115,44,"ACTSSGRUPCOD","Codigo","","ACTSSGrupCod","int",54,"px",5,5,"right",null,[],2115,"ACTSSGrupCod",!1,0,!1,!1,"Attribute",1,"");t.addSingleLineEdit(2230,45,"ACTSSGRUPDSC","Sub - Componente","","ACTSSGrupDsc","svchar",400,"px",100,80,"left",null,[],2230,"ACTSSGrupDsc",!0,0,!1,!1,"Attribute",1,"");t.addSingleLineEdit(2229,46,"ACTSSGRUPPOR","% Porcentaje","","ACTSSGrupPor","decimal",120,"px",6,6,"right",null,[],2229,"ACTSSGrupPor",!0,2,!1,!1,"Attribute",1,"");this.Grid1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"GROUP1",grid:0};n[3]={id:3,fld:"TABLE2",grid:0};n[6]={id:6,fld:"IMAGE1",grid:0,evt:"e1171195_client",std:"ENTER"};n[7]={id:7,fld:"IMAGE2",grid:0,evt:"e1371195_client"};n[13]={id:13,fld:"TEXTBLOCK4",format:0,grid:0,ctrltype:"textblock"};n[15]={id:15,lvl:0,type:"svchar",len:5,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Actclacod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"ACTCLACOD",gxz:"Z426ACTClaCod",gxold:"O426ACTClaCod",gxvar:"A426ACTClaCod",ucs:[],op:[20],ip:[20,15],nacdep:[],ctrltype:"dyncombo",v2v:function(n){n!==undefined&&(gx.O.A426ACTClaCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z426ACTClaCod=n)},v2c:function(){gx.fn.setComboBoxValue("ACTCLACOD",gx.O.A426ACTClaCod)},c2v:function(){this.val()!==undefined&&(gx.O.A426ACTClaCod=this.val())},val:function(){return gx.fn.getControlValue("ACTCLACOD")},nac:gx.falseFn};n[18]={id:18,fld:"TEXTBLOCK7",format:0,grid:0,ctrltype:"textblock"};n[20]={id:20,lvl:0,type:"svchar",len:5,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Actgrupcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"ACTGRUPCOD",gxz:"Z2103ACTGrupCod",gxold:"O2103ACTGrupCod",gxvar:"A2103ACTGrupCod",ucs:[],op:[],ip:[20,15],nacdep:[],ctrltype:"dyncombo",v2v:function(n){n!==undefined&&(gx.O.A2103ACTGrupCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z2103ACTGrupCod=n)},v2c:function(){gx.fn.setComboBoxValue("ACTGRUPCOD",gx.O.A2103ACTGrupCod)},c2v:function(){this.val()!==undefined&&(gx.O.A2103ACTGrupCod=this.val())},val:function(){return gx.fn.getControlValue("ACTGRUPCOD")},nac:gx.falseFn};n[23]={id:23,fld:"TEXTBLOCK1",format:0,grid:0,ctrltype:"textblock"};n[25]={id:25,lvl:0,type:"svchar",len:5,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Actsgrupcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"ACTSGRUPCOD",gxz:"Z2114ACTSGrupCod",gxold:"O2114ACTSGrupCod",gxvar:"A2114ACTSGrupCod",ucs:[],op:[40,35,51,30],ip:[40,35,51,30,25,20,15],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2114ACTSGrupCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z2114ACTSGrupCod=n)},v2c:function(){gx.fn.setControlValue("ACTSGRUPCOD",gx.O.A2114ACTSGrupCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2114ACTSGrupCod=this.val())},val:function(){return gx.fn.getControlValue("ACTSGRUPCOD")},nac:gx.falseFn};n[28]={id:28,fld:"TEXTBLOCK2",format:0,grid:0,ctrltype:"textblock"};n[30]={id:30,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTSGRUPDSC",gxz:"Z2155ACTSGrupDsc",gxold:"O2155ACTSGrupDsc",gxvar:"A2155ACTSGrupDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2155ACTSGrupDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z2155ACTSGrupDsc=n)},v2c:function(){gx.fn.setControlValue("ACTSGRUPDSC",gx.O.A2155ACTSGrupDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2155ACTSGrupDsc=this.val())},val:function(){return gx.fn.getControlValue("ACTSGRUPDSC")},nac:gx.falseFn};n[33]={id:33,fld:"TEXTBLOCK5",format:0,grid:0,ctrltype:"textblock"};n[35]={id:35,lvl:0,type:"decimal",len:6,dec:2,sign:!1,pic:"ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTSGRUPPOR",gxz:"Z2156ACTSGrupPor",gxold:"O2156ACTSGrupPor",gxvar:"A2156ACTSGrupPor",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2156ACTSGrupPor=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z2156ACTSGrupPor=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("ACTSGRUPPOR",gx.O.A2156ACTSGrupPor,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A2156ACTSGrupPor=this.val())},val:function(){return gx.fn.getDecimalValue("ACTSGRUPPOR",",",".")},nac:gx.falseFn};this.declareDomainHdlr(35,function(){});n[38]={id:38,fld:"TEXTBLOCK6",format:0,grid:0,ctrltype:"textblock"};n[40]={id:40,lvl:0,type:"decimal",len:6,dec:2,sign:!1,pic:"ZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTSGRUPANO",gxz:"Z2226ACTSGrupAno",gxold:"O2226ACTSGrupAno",gxvar:"A2226ACTSGrupAno",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2226ACTSGrupAno=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z2226ACTSGrupAno=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("ACTSGRUPANO",gx.O.A2226ACTSGrupAno,2,".")},c2v:function(){this.val()!==undefined&&(gx.O.A2226ACTSGrupAno=this.val())},val:function(){return gx.fn.getDecimalValue("ACTSGRUPANO",",",".")},nac:gx.falseFn};n[44]={id:44,lvl:196,type:"int",len:5,dec:0,sign:!1,pic:"ZZZZ9",ro:1,isacc:1,grid:43,gxgrid:this.Grid1Container,fnc:this.Valid_Actssgrupcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTSSGRUPCOD",gxz:"Z2115ACTSSGrupCod",gxold:"O2115ACTSSGrupCod",gxvar:"A2115ACTSSGrupCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A2115ACTSSGrupCod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z2115ACTSSGrupCod=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("ACTSSGRUPCOD",n||gx.fn.currentGridRowImpl(43),gx.O.A2115ACTSSGrupCod,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A2115ACTSSGrupCod=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("ACTSSGRUPCOD",n||gx.fn.currentGridRowImpl(43),",")},nac:gx.falseFn};n[45]={id:45,lvl:196,type:"svchar",len:100,dec:0,sign:!1,ro:0,isacc:1,grid:43,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTSSGRUPDSC",gxz:"Z2230ACTSSGrupDsc",gxold:"O2230ACTSSGrupDsc",gxvar:"A2230ACTSSGrupDsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A2230ACTSSGrupDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z2230ACTSSGrupDsc=n)},v2c:function(n){gx.fn.setGridControlValue("ACTSSGRUPDSC",n||gx.fn.currentGridRowImpl(43),gx.O.A2230ACTSSGrupDsc,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A2230ACTSSGrupDsc=this.val(n))},val:function(n){return gx.fn.getGridControlValue("ACTSSGRUPDSC",n||gx.fn.currentGridRowImpl(43))},nac:gx.falseFn};n[46]={id:46,lvl:196,type:"decimal",len:6,dec:2,sign:!1,pic:"ZZ9.99",ro:0,isacc:1,grid:43,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTSSGRUPPOR",gxz:"Z2229ACTSSGrupPor",gxold:"O2229ACTSSGrupPor",gxvar:"A2229ACTSSGrupPor",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A2229ACTSSGrupPor=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z2229ACTSSGrupPor=gx.fn.toDecimalValue(n,",","."))},v2c:function(n){gx.fn.setGridDecimalValue("ACTSSGRUPPOR",n||gx.fn.currentGridRowImpl(43),gx.O.A2229ACTSSGrupPor,2,".")},c2v:function(n){this.val(n)!==undefined&&(gx.O.A2229ACTSSGrupPor=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("ACTSSGRUPPOR",n||gx.fn.currentGridRowImpl(43),",",".")},nac:gx.falseFn};n[49]={id:49,fld:"TEXTBLOCK3",format:0,grid:0,ctrltype:"textblock"};n[51]={id:51,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ACTSGRUPSTS",gxz:"Z2227ACTSGrupSts",gxold:"O2227ACTSGrupSts",gxvar:"A2227ACTSGrupSts",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.A2227ACTSGrupSts=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z2227ACTSGrupSts=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("ACTSGRUPSTS",gx.O.A2227ACTSGrupSts)},c2v:function(){this.val()!==undefined&&(gx.O.A2227ACTSGrupSts=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("ACTSGRUPSTS",",")},nac:gx.falseFn};this.A426ACTClaCod="";this.Z426ACTClaCod="";this.O426ACTClaCod="";this.A2103ACTGrupCod="";this.Z2103ACTGrupCod="";this.O2103ACTGrupCod="";this.A2114ACTSGrupCod="";this.Z2114ACTSGrupCod="";this.O2114ACTSGrupCod="";this.A2155ACTSGrupDsc="";this.Z2155ACTSGrupDsc="";this.O2155ACTSGrupDsc="";this.A2156ACTSGrupPor=0;this.Z2156ACTSGrupPor=0;this.O2156ACTSGrupPor=0;this.A2226ACTSGrupAno=0;this.Z2226ACTSGrupAno=0;this.O2226ACTSGrupAno=0;this.Z2115ACTSSGrupCod=0;this.O2115ACTSSGrupCod=0;this.Z2230ACTSSGrupDsc="";this.O2230ACTSSGrupDsc="";this.Z2229ACTSSGrupPor=0;this.O2229ACTSSGrupPor=0;this.A2227ACTSGrupSts=0;this.Z2227ACTSGrupSts=0;this.O2227ACTSGrupSts=0;this.A2115ACTSSGrupCod=0;this.A2229ACTSSGrupPor=0;this.A2230ACTSSGrupDsc="";this.A426ACTClaCod="";this.A2103ACTGrupCod="";this.A2114ACTSGrupCod="";this.A2155ACTSGrupDsc="";this.A2227ACTSGrupSts=0;this.A2156ACTSGrupPor=0;this.A2226ACTSGrupAno=0;this.A2228ACTSGrupTot=0;this.Events={e1171195_client:["ENTER",!0],e1271195_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0},{ctrl:"ACTCLACOD"},{av:"A426ACTClaCod",fld:"ACTCLACOD",pic:""},{ctrl:"ACTGRUPCOD"},{av:"A2103ACTGrupCod",fld:"ACTGRUPCOD",pic:""}],[{ctrl:"ACTCLACOD"},{av:"A426ACTClaCod",fld:"ACTCLACOD",pic:""},{ctrl:"ACTGRUPCOD"},{av:"A2103ACTGrupCod",fld:"ACTGRUPCOD",pic:""}]];this.EvtParms.REFRESH=[[{av:"A2228ACTSGrupTot",fld:"ACTSGRUPTOT",pic:"ZZZZ9"},{ctrl:"ACTCLACOD"},{av:"A426ACTClaCod",fld:"ACTCLACOD",pic:""},{ctrl:"ACTGRUPCOD"},{av:"A2103ACTGrupCod",fld:"ACTGRUPCOD",pic:""}],[{ctrl:"ACTCLACOD"},{av:"A426ACTClaCod",fld:"ACTCLACOD",pic:""},{ctrl:"ACTGRUPCOD"},{av:"A2103ACTGrupCod",fld:"ACTGRUPCOD",pic:""}]];this.EvtParms.VALID_ACTCLACOD=[[{ctrl:"ACTCLACOD"},{av:"A426ACTClaCod",fld:"ACTCLACOD",pic:""},{ctrl:"ACTGRUPCOD"},{av:"A2103ACTGrupCod",fld:"ACTGRUPCOD",pic:""}],[{ctrl:"ACTCLACOD"},{av:"A426ACTClaCod",fld:"ACTCLACOD",pic:""},{ctrl:"ACTGRUPCOD"},{av:"A2103ACTGrupCod",fld:"ACTGRUPCOD",pic:""}]];this.EvtParms.VALID_ACTGRUPCOD=[[{ctrl:"ACTCLACOD"},{av:"A426ACTClaCod",fld:"ACTCLACOD",pic:""},{ctrl:"ACTGRUPCOD"},{av:"A2103ACTGrupCod",fld:"ACTGRUPCOD",pic:""}],[{ctrl:"ACTCLACOD"},{av:"A426ACTClaCod",fld:"ACTCLACOD",pic:""},{ctrl:"ACTGRUPCOD"},{av:"A2103ACTGrupCod",fld:"ACTGRUPCOD",pic:""}]];this.EvtParms.VALID_ACTSGRUPCOD=[[{av:"A2228ACTSGrupTot",fld:"ACTSGRUPTOT",pic:"ZZZZ9"},{ctrl:"ACTSGRUPSTS"},{av:"A2227ACTSGrupSts",fld:"ACTSGRUPSTS",pic:"9"},{av:"A2114ACTSGrupCod",fld:"ACTSGRUPCOD",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{ctrl:"ACTCLACOD"},{av:"A426ACTClaCod",fld:"ACTCLACOD",pic:""},{ctrl:"ACTGRUPCOD"},{av:"A2103ACTGrupCod",fld:"ACTGRUPCOD",pic:""}],[{av:"A2155ACTSGrupDsc",fld:"ACTSGRUPDSC",pic:""},{ctrl:"ACTSGRUPSTS"},{av:"A2227ACTSGrupSts",fld:"ACTSGRUPSTS",pic:"9"},{av:"A2156ACTSGrupPor",fld:"ACTSGRUPPOR",pic:"ZZ9.99"},{av:"A2226ACTSGrupAno",fld:"ACTSGRUPANO",pic:"ZZ9.99"},{av:"A2228ACTSGrupTot",fld:"ACTSGRUPTOT",pic:"ZZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z426ACTClaCod"},{av:"Z2114ACTSGrupCod"},{av:"Z2155ACTSGrupDsc"},{av:"Z2227ACTSGrupSts"},{av:"Z2156ACTSGrupPor"},{av:"Z2226ACTSGrupAno"},{av:"Z2228ACTSGrupTot"},{av:"Z2103ACTGrupCod"},{av:'gx.fn.getCtrlProperty("IMAGE1","Enabled")',ctrl:"IMAGE1",prop:"Enabled"},{ctrl:"ACTCLACOD"},{av:"A426ACTClaCod",fld:"ACTCLACOD",pic:""},{ctrl:"ACTGRUPCOD"},{av:"A2103ACTGrupCod",fld:"ACTGRUPCOD",pic:""}]];this.EvtParms.VALID_ACTSSGRUPCOD=[[{ctrl:"ACTCLACOD"},{av:"A426ACTClaCod",fld:"ACTCLACOD",pic:""},{ctrl:"ACTGRUPCOD"},{av:"A2103ACTGrupCod",fld:"ACTGRUPCOD",pic:""}],[{ctrl:"ACTCLACOD"},{av:"A426ACTClaCod",fld:"ACTCLACOD",pic:""},{ctrl:"ACTGRUPCOD"},{av:"A2103ACTGrupCod",fld:"ACTGRUPCOD",pic:""}]];this.EnterCtrl=["IMAGE1"];this.setVCMap("A2228ACTSGrupTot","ACTSGRUPTOT",0,"int",5,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.actsubgrupo)})