gx.evt.autoSkip=!1;gx.define("cbplancuenta",!1,function(){this.ServerClass="cbplancuenta";this.PackageName="GeneXus.Programs";this.ServerFullClass="cbplancuenta.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.A2098CueDscCompleto=gx.fn.getControlValue("CUEDSCCOMPLETO");this.A113CueCierre=gx.fn.getControlValue("CUECIERRE");this.A858CueCierreDsc=gx.fn.getControlValue("CUECIERREDSC")};this.Valid_Cuecod=function(){return this.validSrvEvt("Valid_Cuecod",0).then(function(n){return n}.closure(this))};this.Valid_Cuedsc=function(){return this.validCliEvt("Valid_Cuedsc",0,function(){try{var n=gx.util.balloon.getNew("CUEDSC");this.AnyError=0;try{this.A2098CueDscCompleto=gx.text.trim(this.A91CueCod)+" - "+gx.text.trim(this.A860CueDsc)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Cuegasdebe=function(){return this.validSrvEvt("Valid_Cuegasdebe",0).then(function(n){return n}.closure(this))};this.Valid_Cuegashaber=function(){return this.validSrvEvt("Valid_Cuegashaber",0).then(function(n){return n}.closure(this))};this.Valid_Cuemondebe=function(){return this.validSrvEvt("Valid_Cuemondebe",0).then(function(n){return n}.closure(this))};this.Valid_Cuemonhaber=function(){return this.validSrvEvt("Valid_Cuemonhaber",0).then(function(n){return n}.closure(this))};this.Valid_Tipacod=function(){return this.validSrvEvt("Valid_Tipacod",0).then(function(n){return n}.closure(this))};this.e111v64_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e121v64_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,5,6,7,8,9,15,18,20,21,24,26,29,31,34,36,39,41,44,46,49,51,54,56,59,61,64,66,69,71,74,76,79,81,84,86,89,91,94,96,99,101,104,106,109,110,111,112,113];this.GXLastCtrlId=113;n[2]={id:2,fld:"TABLE1",grid:0};n[5]={id:5,fld:"BTN_FIRST",grid:0,evt:"e131v64_client",std:"FIRST"};n[6]={id:6,fld:"BTN_PREVIOUS",grid:0,evt:"e141v64_client",std:"PREVIOUS"};n[7]={id:7,fld:"BTN_NEXT",grid:0,evt:"e151v64_client",std:"NEXT"};n[8]={id:8,fld:"BTN_LAST",grid:0,evt:"e161v64_client",std:"LAST"};n[9]={id:9,fld:"BTN_SELECT",grid:0,evt:"e171v64_client",std:"SELECT"};n[15]={id:15,fld:"TABLE2",grid:0};n[18]={id:18,fld:"TEXTBLOCK1",format:0,grid:0,ctrltype:"textblock"};n[20]={id:20,lvl:0,type:"char",len:15,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cuecod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUECOD",gxz:"Z91CueCod",gxold:"O91CueCod",gxvar:"A91CueCod",ucs:[],op:[96,91,61,56,101,106,86,81,76,71,66,51,46,41,36,31,26],ip:[96,91,61,56,101,106,86,81,76,71,66,51,46,41,36,31,26,20],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A91CueCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z91CueCod=n)},v2c:function(){gx.fn.setControlValue("CUECOD",gx.O.A91CueCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A91CueCod=this.val())},val:function(){return gx.fn.getControlValue("CUECOD")},nac:gx.falseFn};n[21]={id:21,fld:"BTN_GET",grid:0,evt:"e181v64_client",std:"GET"};n[24]={id:24,fld:"TEXTBLOCK2",format:0,grid:0,ctrltype:"textblock"};n[26]={id:26,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cuedsc,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUEDSC",gxz:"Z860CueDsc",gxold:"O860CueDsc",gxvar:"A860CueDsc",ucs:[],op:[],ip:[26,20],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A860CueDsc=n)},v2z:function(n){n!==undefined&&(gx.O.Z860CueDsc=n)},v2c:function(){gx.fn.setControlValue("CUEDSC",gx.O.A860CueDsc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A860CueDsc=this.val())},val:function(){return gx.fn.getControlValue("CUEDSC")},nac:gx.falseFn};n[29]={id:29,fld:"TEXTBLOCK3",format:0,grid:0,ctrltype:"textblock"};n[31]={id:31,lvl:0,type:"char",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUEABR",gxz:"Z857CueAbr",gxold:"O857CueAbr",gxvar:"A857CueAbr",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A857CueAbr=n)},v2z:function(n){n!==undefined&&(gx.O.Z857CueAbr=n)},v2c:function(){gx.fn.setControlValue("CUEABR",gx.O.A857CueAbr,0)},c2v:function(){this.val()!==undefined&&(gx.O.A857CueAbr=this.val())},val:function(){return gx.fn.getControlValue("CUEABR")},nac:gx.falseFn};n[34]={id:34,fld:"TEXTBLOCK4",format:0,grid:0,ctrltype:"textblock"};n[36]={id:36,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUEMOV",gxz:"Z867CueMov",gxold:"O867CueMov",gxvar:"A867CueMov",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A867CueMov=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z867CueMov=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("CUEMOV",gx.O.A867CueMov,0)},c2v:function(){this.val()!==undefined&&(gx.O.A867CueMov=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CUEMOV",",")},nac:gx.falseFn};n[39]={id:39,fld:"TEXTBLOCK5",format:0,grid:0,ctrltype:"textblock"};n[41]={id:41,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUEMON",gxz:"Z864CueMon",gxold:"O864CueMon",gxvar:"A864CueMon",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A864CueMon=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z864CueMon=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("CUEMON",gx.O.A864CueMon,0)},c2v:function(){this.val()!==undefined&&(gx.O.A864CueMon=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CUEMON",",")},nac:gx.falseFn};n[44]={id:44,fld:"TEXTBLOCK6",format:0,grid:0,ctrltype:"textblock"};n[46]={id:46,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUECOS",gxz:"Z859CueCos",gxold:"O859CueCos",gxvar:"A859CueCos",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A859CueCos=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z859CueCos=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("CUECOS",gx.O.A859CueCos,0)},c2v:function(){this.val()!==undefined&&(gx.O.A859CueCos=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CUECOS",",")},nac:gx.falseFn};n[49]={id:49,fld:"TEXTBLOCK7",format:0,grid:0,ctrltype:"textblock"};n[51]={id:51,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUESTS",gxz:"Z873CueSts",gxold:"O873CueSts",gxvar:"A873CueSts",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.A873CueSts=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z873CueSts=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("CUESTS",gx.O.A873CueSts)},c2v:function(){this.val()!==undefined&&(gx.O.A873CueSts=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CUESTS",",")},nac:gx.falseFn};n[54]={id:54,fld:"TEXTBLOCK8",format:0,grid:0,ctrltype:"textblock"};n[56]={id:56,lvl:0,type:"char",len:15,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cuegasdebe,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUEGASDEBE",gxz:"Z109CueGasDebe",gxold:"O109CueGasDebe",gxvar:"A109CueGasDebe",ucs:[],op:[],ip:[56],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A109CueGasDebe=n)},v2z:function(n){n!==undefined&&(gx.O.Z109CueGasDebe=n)},v2c:function(){gx.fn.setControlValue("CUEGASDEBE",gx.O.A109CueGasDebe,0)},c2v:function(){this.val()!==undefined&&(gx.O.A109CueGasDebe=this.val())},val:function(){return gx.fn.getControlValue("CUEGASDEBE")},nac:gx.falseFn};n[59]={id:59,fld:"TEXTBLOCK9",format:0,grid:0,ctrltype:"textblock"};n[61]={id:61,lvl:0,type:"char",len:15,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cuegashaber,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUEGASHABER",gxz:"Z110CueGasHaber",gxold:"O110CueGasHaber",gxvar:"A110CueGasHaber",ucs:[],op:[],ip:[61],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A110CueGasHaber=n)},v2z:function(n){n!==undefined&&(gx.O.Z110CueGasHaber=n)},v2c:function(){gx.fn.setControlValue("CUEGASHABER",gx.O.A110CueGasHaber,0)},c2v:function(){this.val()!==undefined&&(gx.O.A110CueGasHaber=this.val())},val:function(){return gx.fn.getControlValue("CUEGASHABER")},nac:gx.falseFn};n[64]={id:64,fld:"TEXTBLOCK10",format:0,grid:0,ctrltype:"textblock"};n[66]={id:66,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUEREF1",gxz:"Z868CueRef1",gxold:"O868CueRef1",gxvar:"A868CueRef1",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A868CueRef1=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z868CueRef1=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("CUEREF1",gx.O.A868CueRef1,0)},c2v:function(){this.val()!==undefined&&(gx.O.A868CueRef1=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CUEREF1",",")},nac:gx.falseFn};n[69]={id:69,fld:"TEXTBLOCK11",format:0,grid:0,ctrltype:"textblock"};n[71]={id:71,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUEREF2",gxz:"Z869CueRef2",gxold:"O869CueRef2",gxvar:"A869CueRef2",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A869CueRef2=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z869CueRef2=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("CUEREF2",gx.O.A869CueRef2,0)},c2v:function(){this.val()!==undefined&&(gx.O.A869CueRef2=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CUEREF2",",")},nac:gx.falseFn};n[74]={id:74,fld:"TEXTBLOCK12",format:0,grid:0,ctrltype:"textblock"};n[76]={id:76,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUEREF3",gxz:"Z870CueRef3",gxold:"O870CueRef3",gxvar:"A870CueRef3",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A870CueRef3=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z870CueRef3=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("CUEREF3",gx.O.A870CueRef3,0)},c2v:function(){this.val()!==undefined&&(gx.O.A870CueRef3=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CUEREF3",",")},nac:gx.falseFn};n[79]={id:79,fld:"TEXTBLOCK13",format:0,grid:0,ctrltype:"textblock"};n[81]={id:81,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUEREF4",gxz:"Z871CueRef4",gxold:"O871CueRef4",gxvar:"A871CueRef4",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.A871CueRef4=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z871CueRef4=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("CUEREF4",gx.O.A871CueRef4)},c2v:function(){this.val()!==undefined&&(gx.O.A871CueRef4=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CUEREF4",",")},nac:gx.falseFn};n[84]={id:84,fld:"TEXTBLOCK14",format:0,grid:0,ctrltype:"textblock"};n[86]={id:86,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUEREF5",gxz:"Z872CueRef5",gxold:"O872CueRef5",gxvar:"A872CueRef5",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A872CueRef5=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z872CueRef5=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("CUEREF5",gx.O.A872CueRef5,0)},c2v:function(){this.val()!==undefined&&(gx.O.A872CueRef5=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CUEREF5",",")},nac:gx.falseFn};n[89]={id:89,fld:"TEXTBLOCK15",format:0,grid:0,ctrltype:"textblock"};n[91]={id:91,lvl:0,type:"char",len:15,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cuemondebe,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUEMONDEBE",gxz:"Z111CueMonDebe",gxold:"O111CueMonDebe",gxvar:"A111CueMonDebe",ucs:[],op:[],ip:[91],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A111CueMonDebe=n)},v2z:function(n){n!==undefined&&(gx.O.Z111CueMonDebe=n)},v2c:function(){gx.fn.setControlValue("CUEMONDEBE",gx.O.A111CueMonDebe,0)},c2v:function(){this.val()!==undefined&&(gx.O.A111CueMonDebe=this.val())},val:function(){return gx.fn.getControlValue("CUEMONDEBE")},nac:gx.falseFn};n[94]={id:94,fld:"TEXTBLOCK16",format:0,grid:0,ctrltype:"textblock"};n[96]={id:96,lvl:0,type:"char",len:15,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cuemonhaber,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUEMONHABER",gxz:"Z112CueMonHaber",gxold:"O112CueMonHaber",gxvar:"A112CueMonHaber",ucs:[],op:[],ip:[96],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A112CueMonHaber=n)},v2z:function(n){n!==undefined&&(gx.O.Z112CueMonHaber=n)},v2c:function(){gx.fn.setControlValue("CUEMONHABER",gx.O.A112CueMonHaber,0)},c2v:function(){this.val()!==undefined&&(gx.O.A112CueMonHaber=this.val())},val:function(){return gx.fn.getControlValue("CUEMONHABER")},nac:gx.falseFn};n[99]={id:99,fld:"TEXTBLOCK17",format:0,grid:0,ctrltype:"textblock"};n[101]={id:101,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Tipacod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TIPACOD",gxz:"Z70TipACod",gxold:"O70TipACod",gxvar:"A70TipACod",ucs:[],op:[],ip:[101],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A70TipACod=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z70TipACod=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("TIPACOD",gx.O.A70TipACod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A70TipACod=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("TIPACOD",",")},nac:gx.falseFn};n[104]={id:104,fld:"TEXTBLOCK18",format:0,grid:0,ctrltype:"textblock"};n[106]={id:106,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUEGRUPDOC",gxz:"Z863CueGrupDoc",gxold:"O863CueGrupDoc",gxvar:"A863CueGrupDoc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A863CueGrupDoc=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z863CueGrupDoc=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("CUEGRUPDOC",gx.O.A863CueGrupDoc,0)},c2v:function(){this.val()!==undefined&&(gx.O.A863CueGrupDoc=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CUEGRUPDOC",",")},nac:gx.falseFn};n[109]={id:109,fld:"BTN_ENTER",grid:0,evt:"e111v64_client",std:"ENTER"};n[110]={id:110,fld:"BTN_CHECK",grid:0,evt:"e191v64_client",std:"CHECK"};n[111]={id:111,fld:"BTN_CANCEL",grid:0,evt:"e121v64_client"};n[112]={id:112,fld:"BTN_DELETE",grid:0,evt:"e201v64_client",std:"DELETE"};n[113]={id:113,fld:"BTN_HELP",grid:0,evt:"e211v64_client"};this.A91CueCod="";this.Z91CueCod="";this.O91CueCod="";this.A860CueDsc="";this.Z860CueDsc="";this.O860CueDsc="";this.A857CueAbr="";this.Z857CueAbr="";this.O857CueAbr="";this.A867CueMov=0;this.Z867CueMov=0;this.O867CueMov=0;this.A864CueMon=0;this.Z864CueMon=0;this.O864CueMon=0;this.A859CueCos=0;this.Z859CueCos=0;this.O859CueCos=0;this.A873CueSts=0;this.Z873CueSts=0;this.O873CueSts=0;this.A109CueGasDebe="";this.Z109CueGasDebe="";this.O109CueGasDebe="";this.A110CueGasHaber="";this.Z110CueGasHaber="";this.O110CueGasHaber="";this.A868CueRef1=0;this.Z868CueRef1=0;this.O868CueRef1=0;this.A869CueRef2=0;this.Z869CueRef2=0;this.O869CueRef2=0;this.A870CueRef3=0;this.Z870CueRef3=0;this.O870CueRef3=0;this.A871CueRef4=0;this.Z871CueRef4=0;this.O871CueRef4=0;this.A872CueRef5=0;this.Z872CueRef5=0;this.O872CueRef5=0;this.A111CueMonDebe="";this.Z111CueMonDebe="";this.O111CueMonDebe="";this.A112CueMonHaber="";this.Z112CueMonHaber="";this.O112CueMonHaber="";this.A70TipACod=0;this.Z70TipACod=0;this.O70TipACod=0;this.A863CueGrupDoc=0;this.Z863CueGrupDoc=0;this.O863CueGrupDoc=0;this.A91CueCod="";this.A2098CueDscCompleto="";this.A860CueDsc="";this.A857CueAbr="";this.A867CueMov=0;this.A864CueMon=0;this.A859CueCos=0;this.A873CueSts=0;this.A109CueGasDebe="";this.A110CueGasHaber="";this.A868CueRef1=0;this.A869CueRef2=0;this.A870CueRef3=0;this.A871CueRef4=0;this.A872CueRef5=0;this.A111CueMonDebe="";this.A112CueMonHaber="";this.A70TipACod=0;this.A863CueGrupDoc=0;this.A113CueCierre="";this.A858CueCierreDsc="";this.Events={e111v64_client:["ENTER",!0],e121v64_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[{av:"A113CueCierre",fld:"CUECIERRE",pic:""}],[]];this.EvtParms.VALID_CUECOD=[[{ctrl:"CUEREF4"},{av:"A871CueRef4",fld:"CUEREF4",pic:"9"},{ctrl:"CUESTS"},{av:"A873CueSts",fld:"CUESTS",pic:"9"},{av:"A91CueCod",fld:"CUECOD",pic:""},{av:"A113CueCierre",fld:"CUECIERRE",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A860CueDsc",fld:"CUEDSC",pic:""},{av:"A857CueAbr",fld:"CUEABR",pic:""},{av:"A867CueMov",fld:"CUEMOV",pic:"9"},{av:"A864CueMon",fld:"CUEMON",pic:"9"},{av:"A859CueCos",fld:"CUECOS",pic:"9"},{ctrl:"CUESTS"},{av:"A873CueSts",fld:"CUESTS",pic:"9"},{av:"A109CueGasDebe",fld:"CUEGASDEBE",pic:""},{av:"A110CueGasHaber",fld:"CUEGASHABER",pic:""},{av:"A868CueRef1",fld:"CUEREF1",pic:"9"},{av:"A869CueRef2",fld:"CUEREF2",pic:"9"},{av:"A870CueRef3",fld:"CUEREF3",pic:"9"},{ctrl:"CUEREF4"},{av:"A871CueRef4",fld:"CUEREF4",pic:"9"},{av:"A872CueRef5",fld:"CUEREF5",pic:"9"},{av:"A111CueMonDebe",fld:"CUEMONDEBE",pic:""},{av:"A112CueMonHaber",fld:"CUEMONHABER",pic:""},{av:"A70TipACod",fld:"TIPACOD",pic:"ZZZZZ9"},{av:"A863CueGrupDoc",fld:"CUEGRUPDOC",pic:"9"},{av:"A113CueCierre",fld:"CUECIERRE",pic:""},{av:"A858CueCierreDsc",fld:"CUECIERREDSC",pic:""},{av:"A2098CueDscCompleto",fld:"CUEDSCCOMPLETO",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z91CueCod"},{av:"Z860CueDsc"},{av:"Z857CueAbr"},{av:"Z867CueMov"},{av:"Z864CueMon"},{av:"Z859CueCos"},{av:"Z873CueSts"},{av:"Z109CueGasDebe"},{av:"Z110CueGasHaber"},{av:"Z868CueRef1"},{av:"Z869CueRef2"},{av:"Z870CueRef3"},{av:"Z871CueRef4"},{av:"Z872CueRef5"},{av:"Z111CueMonDebe"},{av:"Z112CueMonHaber"},{av:"Z70TipACod"},{av:"Z863CueGrupDoc"},{av:"Z113CueCierre"},{av:"Z858CueCierreDsc"},{av:"Z2098CueDscCompleto"},{ctrl:"BTN_GET",prop:"Enabled"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"},{ctrl:"BTN_CHECK",prop:"Enabled"}]];this.EvtParms.VALID_CUEDSC=[[{av:"A860CueDsc",fld:"CUEDSC",pic:""},{av:"A91CueCod",fld:"CUECOD",pic:""}],[]];this.EvtParms.VALID_CUEGASDEBE=[[{av:"A109CueGasDebe",fld:"CUEGASDEBE",pic:""}],[]];this.EvtParms.VALID_CUEGASHABER=[[{av:"A110CueGasHaber",fld:"CUEGASHABER",pic:""}],[]];this.EvtParms.VALID_CUEMONDEBE=[[{av:"A111CueMonDebe",fld:"CUEMONDEBE",pic:""}],[]];this.EvtParms.VALID_CUEMONHABER=[[{av:"A112CueMonHaber",fld:"CUEMONHABER",pic:""}],[]];this.EvtParms.VALID_TIPACOD=[[{av:"A70TipACod",fld:"TIPACOD",pic:"ZZZZZ9"}],[]];this.EnterCtrl=["BTN_ENTER"];this.CheckCtrl=["BTN_CHECK"];this.setVCMap("A2098CueDscCompleto","CUEDSCCOMPLETO",0,"char",100,0);this.setVCMap("A113CueCierre","CUECIERRE",0,"char",15,0);this.setVCMap("A858CueCierreDsc","CUECIERREDSC",0,"char",100,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.cbplancuenta)})