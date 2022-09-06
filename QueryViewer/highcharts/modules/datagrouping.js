/*
 Highstock JS v9.0.1 (2021-02-15)

 Data grouping module

 (c) 2010-2021 Torstein Hnsi

 License: www.highcharts.com/license
*/
(function(d){"object"===typeof module&&module.exports?(d["default"]=d,module.exports=d):"function"===typeof define&&define.amd?define("highcharts/modules/datagrouping",["highcharts"],function(l){d(l);d.Highcharts=l;return d}):d("undefined"!==typeof Highcharts?Highcharts:void 0)})(function(d){function l(d,l,x,D){d.hasOwnProperty(l)||(d[l]=D.apply(null,x))}d=d?d._modules:{};l(d,"Extensions/DataGrouping.js",[d["Core/Axis/Axis.js"],d["Core/Axis/DateTimeAxis.js"],d["Core/Globals.js"],d["Core/Options.js"],
d["Core/Series/Point.js"],d["Core/Series/Series.js"],d["Core/Tooltip.js"],d["Core/Utilities.js"]],function(d,l,x,D,K,E,L,f){var v=E.prototype,z=f.addEvent,B=f.arrayMax,M=f.arrayMin,N=f.correctFloat,F=f.defined,O=f.error,P=f.extend,Q=f.format,y=f.isNumber,G=f.merge,H=f.pick;"";var g=x.approximations={sum:function(a){var c=a.length;if(!c&&a.hasNulls)var b=null;else if(c)for(b=0;c--;)b+=a[c];return b},average:function(a){var c=a.length;a=g.sum(a);y(a)&&c&&(a=N(a/c));return a},averages:function(){var a=
[];[].forEach.call(arguments,function(c){a.push(g.average(c))});return"undefined"===typeof a[0]?void 0:a},open:function(a){return a.length?a[0]:a.hasNulls?null:void 0},high:function(a){return a.length?B(a):a.hasNulls?null:void 0},low:function(a){return a.length?M(a):a.hasNulls?null:void 0},close:function(a){return a.length?a[a.length-1]:a.hasNulls?null:void 0},ohlc:function(a,c,b,w){a=g.open(a);c=g.high(c);b=g.low(b);w=g.close(w);if(y(a)||y(c)||y(b)||y(w))return[a,c,b,w]},range:function(a,c){a=g.low(a);
c=g.high(c);if(y(a)||y(c))return[a,c];if(null===a&&null===c)return null}};f=function(a,c,b,w){var e=this,d=e.data,u=e.options&&e.options.data,m=[],n=[],f=[],p=a.length,q=!!c,r=[],h=e.pointArrayMap,l=h&&h.length,v=["x"].concat(h||["y"]),x=0,z=0,t;w="function"===typeof w?w:g[w]?g[w]:g[e.getDGApproximation&&e.getDGApproximation()||"average"];l?h.forEach(function(){r.push([])}):r.push([]);var A=l||1;for(t=0;t<=p&&!(a[t]>=b[0]);t++);for(t;t<=p;t++){for(;"undefined"!==typeof b[x+1]&&a[t]>=b[x+1]||t===p;){var k=
b[x];e.dataGroupInfo={start:e.cropStart+z,length:r[0].length};var C=w.apply(e,r);e.pointClass&&!F(e.dataGroupInfo.options)&&(e.dataGroupInfo.options=G(e.pointClass.prototype.optionsToObject.call({series:e},e.options.data[e.cropStart+z])),v.forEach(function(a){delete e.dataGroupInfo.options[a]}));"undefined"!==typeof C&&(m.push(k),n.push(C),f.push(e.dataGroupInfo));z=t;for(k=0;k<A;k++)r[k].length=0,r[k].hasNulls=!1;x+=1;if(t===p)break}if(t===p)break;if(h)for(k=e.cropStart+t,C=d&&d[k]||e.pointClass.prototype.applyOptions.apply({series:e},
[u[k]]),k=0;k<l;k++){var B=C[h[k]];y(B)?r[k].push(B):null===B&&(r[k].hasNulls=!0)}else k=q?c[t]:null,y(k)?r[0].push(k):null===k&&(r[0].hasNulls=!0)}return{groupedXData:m,groupedYData:n,groupMap:f}};var I={approximations:g,groupData:f},R=v.processData,S=v.generatePoints,A={groupPixelWidth:2,dateTimeLabelFormats:{millisecond:["%A, %b %e, %H:%M:%S.%L","%A, %b %e, %H:%M:%S.%L","-%H:%M:%S.%L"],second:["%A, %b %e, %H:%M:%S","%A, %b %e, %H:%M:%S","-%H:%M:%S"],minute:["%A, %b %e, %H:%M","%A, %b %e, %H:%M",
"-%H:%M"],hour:["%A, %b %e, %H:%M","%A, %b %e, %H:%M","-%H:%M"],day:["%A, %b %e, %Y","%A, %b %e","-%A, %b %e, %Y"],week:["Week from %A, %b %e, %Y","%A, %b %e","-%A, %b %e, %Y"],month:["%B %Y","%B","-%B %Y"],year:["%Y","%Y","-%Y"]}},J={line:{},spline:{},area:{},areaspline:{},arearange:{},column:{groupPixelWidth:10},columnrange:{groupPixelWidth:10},candlestick:{groupPixelWidth:10},ohlc:{groupPixelWidth:5}},T=x.defaultDataGroupingUnits=[["millisecond",[1,2,5,10,20,25,50,100,200,500]],["second",[1,2,
5,10,15,30]],["minute",[1,2,5,10,15,30]],["hour",[1,2,3,4,6,8,12]],["day",[1]],["week",[1]],["month",[1,3,6]],["year",null]];v.getDGApproximation=function(){return this.is("arearange")?"range":this.is("ohlc")?"ohlc":this.is("column")?"sum":"average"};v.groupData=f;v.processData=function(){var a=this.chart,c=this.options.dataGrouping,b=!1!==this.allowDG&&c&&H(c.enabled,a.options.isStock),d=this.visible||!a.options.chart.ignoreHiddenSeries,e,f=this.currentDataGrouping,u=!1;this.forceCrop=b;this.groupPixelWidth=
null;this.hasProcessed=!0;b&&!this.requireSorting&&(this.requireSorting=u=!0);b=!1===R.apply(this,arguments)||!b;u&&(this.requireSorting=!1);if(!b){this.destroyGroupedData();b=c.groupAll?this.xData:this.processedXData;var m=c.groupAll?this.yData:this.processedYData,n=a.plotSizeX;a=this.xAxis;var g=a.options.ordinal,p=this.groupPixelWidth=a.getGroupPixelWidth&&a.getGroupPixelWidth();if(p){this.isDirty=e=!0;this.points=null;u=a.getExtremes();var q=u.min;u=u.max;g=g&&a.ordinal&&a.ordinal.getGroupIntervalFactor(q,
u,this)||1;p=p*(u-q)/n*g;n=a.getTimeTicks(l.AdditionsClass.prototype.normalizeTimeTickInterval(p,c.units||T),Math.min(q,b[0]),Math.max(u,b[b.length-1]),a.options.startOfWeek,b,this.closestPointRange);m=v.groupData.apply(this,[b,m,n,c.approximation]);b=m.groupedXData;g=m.groupedYData;var r=0;if(c.smoothed&&b.length){var h=b.length-1;for(b[h]=Math.min(b[h],u);h--&&0<h;)b[h]+=p/2;b[0]=Math.max(b[0],q)}for(h=1;h<n.length;h++)n.info.segmentStarts&&-1!==n.info.segmentStarts.indexOf(h)||(r=Math.max(n[h]-
n[h-1],r));q=n.info;q.gapSize=r;this.closestPointRange=n.info.totalRange;this.groupMap=m.groupMap;if(F(b[0])&&b[0]<a.min&&d){if(!F(a.options.min)&&a.min<=a.dataMin||a.min===a.dataMin)a.min=Math.min(b[0],a.min);a.dataMin=Math.min(b[0],a.dataMin)}c.groupAll&&(c=this.cropData(b,g,a.min,a.max,1),b=c.xData,g=c.yData);this.processedXData=b;this.processedYData=g}else this.groupMap=null;this.hasGroupedData=e;this.currentDataGrouping=q;this.preventGraphAnimation=(f&&f.totalRange)!==(q&&q.totalRange)}};v.destroyGroupedData=
function(){this.groupedData&&(this.groupedData.forEach(function(a,c){a&&(this.groupedData[c]=a.destroy?a.destroy():null)},this),this.groupedData.length=0)};v.generatePoints=function(){S.apply(this);this.destroyGroupedData();this.groupedData=this.hasGroupedData?this.points:null};z(K,"update",function(){if(this.dataGroup)return O(24,!1,this.series.chart),!1});z(L,"headerFormatter",function(a){var c=this.chart,b=c.time,d=a.labelConfig,e=d.series,f=e.tooltipOptions,g=e.options.dataGrouping,m=f.xDateFormat,
n=e.xAxis,l=f[(a.isFooter?"footer":"header")+"Format"];if(n&&"datetime"===n.options.type&&g&&y(d.key)){var p=e.currentDataGrouping;g=g.dateTimeLabelFormats||A.dateTimeLabelFormats;if(p)if(f=g[p.unitName],1===p.count)m=f[0];else{m=f[1];var q=f[2]}else!m&&g&&(m=this.getXDateFormat(d,f,n));m=b.dateFormat(m,d.key);q&&(m+=b.dateFormat(q,d.key+p.totalRange-1));e.chart.styledMode&&(l=this.styledModeFormat(l));a.text=Q(l,{point:P(d.point,{key:m}),series:e},c);a.preventDefault()}});z(E,"destroy",v.destroyGroupedData);
z(E,"afterSetOptions",function(a){a=a.options;var c=this.type,b=this.chart.options.plotOptions,d=D.defaultOptions.plotOptions[c].dataGrouping,e=this.useCommonDataGrouping&&A;if(J[c]||e)d||(d=G(A,J[c])),a.dataGrouping=G(e,d,b.series&&b.series.dataGrouping,b[c].dataGrouping,this.userOptions.dataGrouping)});z(d,"afterSetScale",function(){this.series.forEach(function(a){a.hasProcessed=!1})});d.prototype.getGroupPixelWidth=function(){var a=this.series,c=a.length,b,d=0,e=!1,f;for(b=c;b--;)(f=a[b].options.dataGrouping)&&
(d=Math.max(d,H(f.groupPixelWidth,A.groupPixelWidth)));for(b=c;b--;)(f=a[b].options.dataGrouping)&&a[b].hasProcessed&&(c=(a[b].processedXData||a[b].data).length,a[b].groupPixelWidth||c>this.chart.plotSizeX/d||c&&f.forced)&&(e=!0);return e?d:0};d.prototype.setDataGrouping=function(a,c){var b;c=H(c,!0);a||(a={forced:!1,units:null});if(this instanceof d)for(b=this.series.length;b--;)this.series[b].update({dataGrouping:a},!1);else this.chart.options.series.forEach(function(b){b.dataGrouping=a},!1);this.ordinal&&
(this.ordinal.slope=void 0);c&&this.chart.redraw()};x.dataGrouping=I;"";return I});l(d,"masters/modules/datagrouping.src.js",[d["Extensions/DataGrouping.js"]],function(d){return d})});
//# sourceMappingURL=datagrouping.js.map