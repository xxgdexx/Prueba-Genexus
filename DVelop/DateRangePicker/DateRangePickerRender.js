﻿function WWP_DateRangePicker_UC(n){this.attachedCtrlId;this.Width;this.Height;this.gxOptions;this.gxStartDate;this.gxEndDate;this.dateRange;this.autoUpdateInput;this.show=function(){};this.Initialize=function(t,i){this.gxOptions=this.gxOptions||{};this.gxStartDate&&this.gxStartDate.HasDatePart&&(this.gxOptions.StartDate=this.gxStartDate.Value);this.gxEndDate&&this.gxEndDate.HasDatePart&&(this.gxOptions.EndDate=this.gxEndDate.Value);this.gxOptions=n.extend(i||{},this.gxOptions);this.dateRange=new WWP_DateRangePicker(t,this.gxOptions,this.dateRangeChangedHandler.closure(this));this.attachedCtrl=n("#"+t);this.autoUpdateInput=this.gxOptions&&this.gxOptions.Advanced&&this.gxOptions.Advanced.AutoUpdateInput;this.updateElement(this.gxStartDate,this.gxEndDate)};this.Attach=function(n){this.Initialize(n,wwpDateRangedefaultOptions)};this.getPickerBoundedControl=function(){return n(this.attachedCtrl).data("daterangepicker")};this.updateElement=function(t,i){if(t=t||this.gxStartDate,i=i||this.gxEndDate,this.autoUpdateInput){var r=this.getPickerBoundedControl();!t||!i||gx.date.isNullDate(t)||gx.date.isNullDate(i)?(n(this.attachedCtrl).val(""),r.setStartDate(new Date),r.setEndDate(new Date)):(r.setStartDate(this.gxStartDate.Value),r.setEndDate(this.gxEndDate.Value),r.updateElement(t&&i))}};this.dateRangeChangedHandler=function(n,t,i){this.gxStartDate=this.resolveReturnDate(n);this.gxEndDate=this.resolveReturnDate(t);this.updateElement(this.gxStartDate,this.gxEndDate,i);var r=this.DateRangeChanged;r&&r(this.gxStartDate,this.gxEndDate,i)};this.setDateRangePickerStartDate=function(t){this.gxStartDate=this.resolveReturnDate(t);this.dateRange&&(gx.date.isNullDate(this.gxStartDate)?(this.dateRange.setStartDate(moment().startOf("day")),n(this.attachedCtrl).val("")):(this.dateRange.setStartDate(this.gxStartDate.Value),this.updateElement()))};this.setDateRangePickerEndDate=function(t){this.gxEndDate=this.resolveReturnDate(t);this.dateRange&&(gx.date.isNullDate(this.gxEndDate)?(this.dateRange.setEndDate(moment().endOf("day")),n(this.attachedCtrl).val("")):(this.dateRange.setStartDate(this.gxEndDate.Value),this.updateElement()))};this.setDateRangePickerOptions=function(n){this.gxOptions=n};this.getDateRangePickerStartDate=function(){var n=this.resolveReturnDate(this.gxStartDate);return this.ParentObject.isTransaction()?n.getStringWithFmt("Y4MD"):n};this.getDateRangePickerEndDate=function(){var n=this.resolveReturnDate(this.gxEndDate);return this.ParentObject.isTransaction()?n.getStringWithFmt("Y4MD"):n};this.resolveReturnDate=function(n){if(n){var t=new gx.date.gxdate(n,"Y4MD");return gx.date.isNullDate(t)||(t.HasTimePart=!0,t.HasDatePart=!0),t}return gx.date.nullDate()};this.getDateRangePickerOptions=function(){return this.gxOptions}}var wwpDateRangedefaultOptions={Advanced:{AutoUpdateInput:!0}},gxDateToDateConvert=function(n){var t=new gx.date.gxdate(n,"Y4MD");return t.HasDatePart?t.Value:null};$(window).one('load',function(){WWP_VV([['WWP.DateRangePicker','14.3']]);});