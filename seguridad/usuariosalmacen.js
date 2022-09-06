gx.evt.autoSkip = false;
gx.define('seguridad.usuariosalmacen', true, function (CmpContext) {
   this.ServerClass =  "seguridad.usuariosalmacen" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.ServerFullClass =  "seguridad.usuariosalmacen.aspx" ;
   this.setObjectType("web");
   this.setCmpContext(CmpContext);
   this.ReadonlyForm = true;
   this.hasEnterEvent = true;
   this.skipOnEnter = false;
   this.autoRefresh = true;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
      this.AV20AddedKeyList=gx.fn.getControlValue("vADDEDKEYLIST") ;
      this.AV22AddedDscList=gx.fn.getControlValue("vADDEDDSCLIST") ;
      this.AV21NotAddedKeyList=gx.fn.getControlValue("vNOTADDEDKEYLIST") ;
      this.AV23NotAddedDscList=gx.fn.getControlValue("vNOTADDEDDSCLIST") ;
      this.AV16AddedKeyListXml=gx.fn.getControlValue("vADDEDKEYLISTXML") ;
      this.AV18AddedDscListXml=gx.fn.getControlValue("vADDEDDSCLISTXML") ;
      this.AV17NotAddedKeyListXml=gx.fn.getControlValue("vNOTADDEDKEYLISTXML") ;
      this.AV19NotAddedDscListXml=gx.fn.getControlValue("vNOTADDEDDSCLISTXML") ;
      this.A348UsuCod=gx.fn.getControlValue("USUCOD") ;
      this.A349UsuAlmCod=gx.fn.getIntegerValue("USUALMCOD",',') ;
      this.AV11SGUSUARIOALMACEN=gx.fn.getControlValue("vSGUSUARIOALMACEN") ;
      this.AV8UsuAlmCod=gx.fn.getIntegerValue("vUSUALMCOD",',') ;
   };
   this.e130g2_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e140g2_client=function()
   {
      return this.executeServerEvent("'DISASSOCIATE SELECTED'", true, null, false, false);
   };
   this.e150g2_client=function()
   {
      return this.executeServerEvent("'ASSOCIATE SELECTED'", true, null, false, false);
   };
   this.e160g2_client=function()
   {
      return this.executeServerEvent("'ASSOCIATE ALL'", true, null, false, false);
   };
   this.e170g2_client=function()
   {
      return this.executeServerEvent("'DISASSOCIATE ALL'", true, null, false, false);
   };
   this.e180g2_client=function()
   {
      return this.executeServerEvent("VASSOCIATEDRECORDS.DBLCLICK", true, null, false, true);
   };
   this.e190g2_client=function()
   {
      return this.executeServerEvent("VNOTASSOCIATEDRECORDS.DBLCLICK", true, null, false, true);
   };
   this.e210g1_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56];
   this.GXLastCtrlId =56;
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"LAYOUTMAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"TABLEMAIN",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[11]={ id: 11, fld:"",grid:0};
   GXValidFnc[12]={ id: 12, fld:"TABLAMENSAJE",grid:0};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"",grid:0};
   GXValidFnc[15]={ id: 15, fld:"TXTCONTACMSJ", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[16]={ id: 16, fld:"",grid:0};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"TABLACONTENIDO",grid:0};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"",grid:0};
   GXValidFnc[21]={ id: 21, fld:"TABLENOTASSOCIATED",grid:0};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   GXValidFnc[23]={ id: 23, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"NOTASSOCIATEDRECORDSTITLE", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[26]={ id: 26, fld:"",grid:0};
   GXValidFnc[27]={ id: 27, fld:"",grid:0};
   GXValidFnc[28]={ id:28 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNOTASSOCIATEDRECORDS",gxz:"ZV25NotAssociatedRecords",gxold:"OV25NotAssociatedRecords",gxvar:"AV25NotAssociatedRecords",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"listbx",v2v:function(Value){if(Value!==undefined)gx.O.AV25NotAssociatedRecords=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV25NotAssociatedRecords=gx.num.intval(Value)},v2c:function(){gx.fn.setComboBoxValue("vNOTASSOCIATEDRECORDS",gx.O.AV25NotAssociatedRecords)},c2v:function(){if(this.val()!==undefined)gx.O.AV25NotAssociatedRecords=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("vNOTASSOCIATEDRECORDS",',')},nac:gx.falseFn,triggersEvt:"e190g2_client"};
   GXValidFnc[29]={ id: 29, fld:"",grid:0};
   GXValidFnc[30]={ id: 30, fld:"UNNAMEDTABLEASSOCIATIONBUTTONS",grid:0};
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   GXValidFnc[32]={ id: 32, fld:"",grid:0};
   GXValidFnc[33]={ id: 33, fld:"",grid:0};
   GXValidFnc[34]={ id: 34, fld:"IMAGEASSOCIATEALL",grid:0,evt:"e160g2_client"};
   GXValidFnc[35]={ id: 35, fld:"",grid:0};
   GXValidFnc[36]={ id: 36, fld:"IMAGEASSOCIATESELECTED",grid:0,evt:"e150g2_client"};
   GXValidFnc[37]={ id: 37, fld:"",grid:0};
   GXValidFnc[38]={ id: 38, fld:"IMAGEDISASSOCIATESELECTED",grid:0,evt:"e140g2_client"};
   GXValidFnc[39]={ id: 39, fld:"",grid:0};
   GXValidFnc[40]={ id: 40, fld:"IMAGEDISASSOCIATEALL",grid:0,evt:"e170g2_client"};
   GXValidFnc[41]={ id: 41, fld:"",grid:0};
   GXValidFnc[42]={ id: 42, fld:"TABLEASSOCIATED",grid:0};
   GXValidFnc[43]={ id: 43, fld:"",grid:0};
   GXValidFnc[44]={ id: 44, fld:"",grid:0};
   GXValidFnc[45]={ id: 45, fld:"ASSOCIATEDRECORDSTITLE", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[46]={ id: 46, fld:"",grid:0};
   GXValidFnc[47]={ id: 47, fld:"",grid:0};
   GXValidFnc[48]={ id: 48, fld:"",grid:0};
   GXValidFnc[49]={ id:49 ,lvl:0,type:"int",len:6,dec:0,sign:false,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vASSOCIATEDRECORDS",gxz:"ZV24AssociatedRecords",gxold:"OV24AssociatedRecords",gxvar:"AV24AssociatedRecords",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"listbx",v2v:function(Value){if(Value!==undefined)gx.O.AV24AssociatedRecords=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV24AssociatedRecords=gx.num.intval(Value)},v2c:function(){gx.fn.setComboBoxValue("vASSOCIATEDRECORDS",gx.O.AV24AssociatedRecords)},c2v:function(){if(this.val()!==undefined)gx.O.AV24AssociatedRecords=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("vASSOCIATEDRECORDS",',')},nac:gx.falseFn,triggersEvt:"e180g2_client"};
   GXValidFnc[50]={ id: 50, fld:"",grid:0};
   GXValidFnc[51]={ id: 51, fld:"",grid:0};
   GXValidFnc[52]={ id: 52, fld:"",grid:0};
   GXValidFnc[53]={ id: 53, fld:"",grid:0};
   GXValidFnc[54]={ id: 54, fld:"BTNCONFIRM",grid:0,evt:"e130g2_client",std:"ENTER"};
   GXValidFnc[55]={ id: 55, fld:"",grid:0};
   GXValidFnc[56]={ id: 56, fld:"BTNCANCEL",grid:0,evt:"e210g1_client"};
   this.AV25NotAssociatedRecords = 0 ;
   this.ZV25NotAssociatedRecords = 0 ;
   this.OV25NotAssociatedRecords = 0 ;
   this.AV24AssociatedRecords = 0 ;
   this.ZV24AssociatedRecords = 0 ;
   this.OV24AssociatedRecords = 0 ;
   this.AV25NotAssociatedRecords = 0 ;
   this.AV24AssociatedRecords = 0 ;
   this.AV7UsuCod = "" ;
   this.A349UsuAlmCod = 0 ;
   this.A348UsuCod = "" ;
   this.A63AlmCod = 0 ;
   this.A436AlmDsc = "" ;
   this.AV20AddedKeyList = [ ] ;
   this.AV22AddedDscList = [ ] ;
   this.AV21NotAddedKeyList = [ ] ;
   this.AV23NotAddedDscList = [ ] ;
   this.AV16AddedKeyListXml = "" ;
   this.AV18AddedDscListXml = "" ;
   this.AV17NotAddedKeyListXml = "" ;
   this.AV19NotAddedDscListXml = "" ;
   this.AV11SGUSUARIOALMACEN = {UsuCod:"",UsuAlmCod:0,UsuAlmDsc:"",UsuAlmSts:0,Mode:"",Initialized:0,UsuCod_Z:"",UsuAlmCod_Z:0,UsuAlmDsc_Z:"",UsuAlmSts_Z:0} ;
   this.AV8UsuAlmCod = 0 ;
   this.addEventHandler("dblclick", "vASSOCIATEDRECORDS", this.e180g2_client);
   this.addEventHandler("dblclick", "vNOTASSOCIATEDRECORDS", this.e190g2_client);
   this.Events = {"e130g2_client": ["ENTER", true] ,"e140g2_client": ["'DISASSOCIATE SELECTED'", true] ,"e150g2_client": ["'ASSOCIATE SELECTED'", true] ,"e160g2_client": ["'ASSOCIATE ALL'", true] ,"e170g2_client": ["'DISASSOCIATE ALL'", true] ,"e180g2_client": ["VASSOCIATEDRECORDS.DBLCLICK", true] ,"e190g2_client": ["VNOTASSOCIATEDRECORDS.DBLCLICK", true] ,"e210g1_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[{av:'AV20AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV22AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV21NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV23NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV16AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV18AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV17NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV19NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''}],[{ctrl:'vASSOCIATEDRECORDS'},{av:'AV24AssociatedRecords',fld:'vASSOCIATEDRECORDS',pic:'ZZZZZ9'},{ctrl:'vNOTASSOCIATEDRECORDS'},{av:'AV25NotAssociatedRecords',fld:'vNOTASSOCIATEDRECORDS',pic:'ZZZZZ9'},{av:'AV8UsuAlmCod',fld:'vUSUALMCOD',pic:'ZZZZZ9'},{av:'AV22AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV20AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV21NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV23NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''}]];
   this.EvtParms["ENTER"] = [[{av:'AV20AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'A348UsuCod',fld:'USUCOD',pic:''},{av:'AV7UsuCod',fld:'vUSUCOD',pic:''},{av:'A349UsuAlmCod',fld:'USUALMCOD',pic:'ZZZZZ9'},{av:'AV21NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV16AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV18AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV17NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV19NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''},{av:'AV11SGUSUARIOALMACEN',fld:'vSGUSUARIOALMACEN',pic:''},{av:'AV8UsuAlmCod',fld:'vUSUALMCOD',pic:'ZZZZZ9'}],[{av:'AV8UsuAlmCod',fld:'vUSUALMCOD',pic:'ZZZZZ9'},{av:'AV11SGUSUARIOALMACEN',fld:'vSGUSUARIOALMACEN',pic:''},{av:'AV22AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV20AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV21NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV23NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''}]];
   this.EvtParms["'DISASSOCIATE SELECTED'"] = [[{av:'AV20AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{ctrl:'vASSOCIATEDRECORDS'},{av:'AV24AssociatedRecords',fld:'vASSOCIATEDRECORDS',pic:'ZZZZZ9'},{av:'AV22AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV23NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV21NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV16AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV18AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV17NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV19NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''}],[{av:'AV8UsuAlmCod',fld:'vUSUALMCOD',pic:'ZZZZZ9'},{av:'AV21NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV23NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV20AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV22AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV16AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV18AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV17NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV19NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''},{ctrl:'vASSOCIATEDRECORDS'},{av:'AV24AssociatedRecords',fld:'vASSOCIATEDRECORDS',pic:'ZZZZZ9'},{ctrl:'vNOTASSOCIATEDRECORDS'},{av:'AV25NotAssociatedRecords',fld:'vNOTASSOCIATEDRECORDS',pic:'ZZZZZ9'}]];
   this.EvtParms["'ASSOCIATE SELECTED'"] = [[{av:'AV21NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{ctrl:'vNOTASSOCIATEDRECORDS'},{av:'AV25NotAssociatedRecords',fld:'vNOTASSOCIATEDRECORDS',pic:'ZZZZZ9'},{av:'AV23NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV22AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV20AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV16AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV18AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV17NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV19NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''}],[{av:'AV8UsuAlmCod',fld:'vUSUALMCOD',pic:'ZZZZZ9'},{av:'AV20AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV22AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV21NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV23NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV16AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV18AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV17NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV19NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''},{ctrl:'vASSOCIATEDRECORDS'},{av:'AV24AssociatedRecords',fld:'vASSOCIATEDRECORDS',pic:'ZZZZZ9'},{ctrl:'vNOTASSOCIATEDRECORDS'},{av:'AV25NotAssociatedRecords',fld:'vNOTASSOCIATEDRECORDS',pic:'ZZZZZ9'}]];
   this.EvtParms["'ASSOCIATE ALL'"] = [[{av:'AV21NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV23NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV22AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV20AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV16AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV18AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV17NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV19NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''}],[{av:'AV8UsuAlmCod',fld:'vUSUALMCOD',pic:'ZZZZZ9'},{av:'AV20AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV22AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV21NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV23NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{ctrl:'vASSOCIATEDRECORDS'},{av:'AV24AssociatedRecords',fld:'vASSOCIATEDRECORDS',pic:'ZZZZZ9'},{ctrl:'vNOTASSOCIATEDRECORDS'},{av:'AV25NotAssociatedRecords',fld:'vNOTASSOCIATEDRECORDS',pic:'ZZZZZ9'},{av:'AV16AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV18AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV17NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV19NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''}]];
   this.EvtParms["'DISASSOCIATE ALL'"] = [[{av:'AV20AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV22AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV21NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV23NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV16AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV18AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV17NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV19NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''}],[{av:'AV21NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV23NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV22AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV20AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV8UsuAlmCod',fld:'vUSUALMCOD',pic:'ZZZZZ9'},{av:'AV16AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV18AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV17NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV19NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''},{ctrl:'vASSOCIATEDRECORDS'},{av:'AV24AssociatedRecords',fld:'vASSOCIATEDRECORDS',pic:'ZZZZZ9'},{ctrl:'vNOTASSOCIATEDRECORDS'},{av:'AV25NotAssociatedRecords',fld:'vNOTASSOCIATEDRECORDS',pic:'ZZZZZ9'}]];
   this.EvtParms["VASSOCIATEDRECORDS.DBLCLICK"] = [[{av:'AV20AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{ctrl:'vASSOCIATEDRECORDS'},{av:'AV24AssociatedRecords',fld:'vASSOCIATEDRECORDS',pic:'ZZZZZ9'},{av:'AV22AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV23NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV21NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV16AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV18AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV17NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV19NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''}],[{av:'AV8UsuAlmCod',fld:'vUSUALMCOD',pic:'ZZZZZ9'},{av:'AV21NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV23NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV20AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV22AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV16AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV18AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV17NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV19NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''},{ctrl:'vASSOCIATEDRECORDS'},{av:'AV24AssociatedRecords',fld:'vASSOCIATEDRECORDS',pic:'ZZZZZ9'},{ctrl:'vNOTASSOCIATEDRECORDS'},{av:'AV25NotAssociatedRecords',fld:'vNOTASSOCIATEDRECORDS',pic:'ZZZZZ9'}]];
   this.EvtParms["VNOTASSOCIATEDRECORDS.DBLCLICK"] = [[{av:'AV21NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{ctrl:'vNOTASSOCIATEDRECORDS'},{av:'AV25NotAssociatedRecords',fld:'vNOTASSOCIATEDRECORDS',pic:'ZZZZZ9'},{av:'AV23NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV22AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV20AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV16AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV18AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV17NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV19NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''}],[{av:'AV8UsuAlmCod',fld:'vUSUALMCOD',pic:'ZZZZZ9'},{av:'AV20AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV22AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV21NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV23NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV16AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV18AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV17NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV19NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''},{ctrl:'vASSOCIATEDRECORDS'},{av:'AV24AssociatedRecords',fld:'vASSOCIATEDRECORDS',pic:'ZZZZZ9'},{ctrl:'vNOTASSOCIATEDRECORDS'},{av:'AV25NotAssociatedRecords',fld:'vNOTASSOCIATEDRECORDS',pic:'ZZZZZ9'}]];
   this.EnterCtrl = ["BTNCONFIRM"];
   this.setVCMap("AV7UsuCod", "vUSUCOD", 0, "char", 10, 0);
   this.setVCMap("AV20AddedKeyList", "vADDEDKEYLIST", 0, "Collint", 0, 0);
   this.setVCMap("AV22AddedDscList", "vADDEDDSCLIST", 0, "Collsvchar", 0, 0);
   this.setVCMap("AV21NotAddedKeyList", "vNOTADDEDKEYLIST", 0, "Collint", 0, 0);
   this.setVCMap("AV23NotAddedDscList", "vNOTADDEDDSCLIST", 0, "Collsvchar", 0, 0);
   this.setVCMap("AV16AddedKeyListXml", "vADDEDKEYLISTXML", 0, "vchar", 2097152, 0);
   this.setVCMap("AV18AddedDscListXml", "vADDEDDSCLISTXML", 0, "vchar", 2097152, 0);
   this.setVCMap("AV17NotAddedKeyListXml", "vNOTADDEDKEYLISTXML", 0, "vchar", 2097152, 0);
   this.setVCMap("AV19NotAddedDscListXml", "vNOTADDEDDSCLISTXML", 0, "vchar", 2097152, 0);
   this.setVCMap("A348UsuCod", "USUCOD", 0, "char", 10, 0);
   this.setVCMap("A349UsuAlmCod", "USUALMCOD", 0, "int", 6, 0);
   this.setVCMap("AV11SGUSUARIOALMACEN", "vSGUSUARIOALMACEN", 0, "SGUSUARIOALMACEN", 0, 0);
   this.setVCMap("AV8UsuAlmCod", "vUSUALMCOD", 0, "int", 6, 0);
   this.Initialize( );
});
