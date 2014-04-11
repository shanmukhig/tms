var date = new Date();
date.setDate(date.getDate() - 1);

var endDate = new Date();
endDate.setFullYear(endDate.getFullYear() + 1);

function setDateParams(controlName, pickTime) {
  var format = pickTime == true ? "dddd MMMM, DD YYYY HH:mm" : "dddd MMMM, DD YYYY";
  $(controlName).datetimepicker({
    format: format,
    keyboardNavigation: true,
    lanugage: 'en',
    pickTime: pickTime,
    minDate: date,
    maxDate: endDate,
    todayHighlight: true,
    sideBySide: pickTime ? true : false,
    show: true,
    defaultDate: '',
    autoclose: true
  });
}

var se = function (errorMap, errorList) {
  $.each(this.successList, function (index, value) {
    $(value).popover('hide');
    $(value).closest('div.row').removeClass('has-warning').addClass('has-success');
  });
  $.each(errorList, function (index, value) {
    $(value.element).popover({
      animation: true,
      trigger: 'manual',
      placement: 'left',
      content: $.validator.format('<span class="text-warning"><i class="glyphicon glyphicon glyphicon-exclamation-sign"></i>{0}</span>', value.message),
      html: true,
      container: $('#courseCreateForm').children().css('modal-body'),
    });
    $(value.element).popover('show');
    $(value.element).closest('div.row').addClass('has-warning').removeClass('has-success');
  });
};

function submitConfirm(controlName, text, action) {
  $(controlName).confirmation({
    'animation': true,
    'container': 'body',
    'title': text,
    'btnOkLabel': '<i class="glyphicon glyphicon-ok"></i>',
    'btnCancelLabel': '<i class="glyphicon glyphicon-remove"></i>',
    'singleton': true,
    'popout' : true,
    'placement': 'bottom',
    'btnCancelClass': 'btn btn-outline btn-warning btn-xs',
    'btnOkClass': 'btn btn-outline btn-info btn-xs',
    'onConfirm': function () {
      $(controlName).confirmation('hide');
      action();
    },
    'onCancel': function () {
      $(controlName).confirmation('hide');
    }
  });
}

(function($) {
  $.fn.pascalCaseToPrettyString = function(s) {
    return s.replace(/([A-Z])/g, function($1) { return " " + $1; });
  }
  $.fn.stringToTitleCase = function(s) {
    return s.replace(/\w+/g, function(w) { return w[0].toUpperCase() + w.slice(1).toLowerCase(); });
  }
});

$('body').delegate('ul li span i.glyphicon-remove', 'click', function () {
  var li = $(this).closest('li');
  li.fadeOut('slow', function () { li.remove(); });
});

$('body').delegate('tr td span i.glyphicon-remove', 'click', function (e) {

  $($($(e.target).parent('td')[0]).parent('tr').next()).slideToggle();

  //var tr = $(this);
  //tr.fadeOut('slow', function () { tr.remove(); });
});

$('body').delegate('i.glyphicon-chevron-down.pull-right', 'click', function (e) {
  $(e.target).toggleClass('glyphicon-chevron-down glyphicon-chevron-up');
  var f = true;
  $($($(e.target).parent().get(0)).parent().get(0)).children().get().forEach(function (entry) {
    if (f) {
      f = !f;
      return;
    }
    $(entry).slideToggle('slow');
  });
});

$('body').delegate('i.glyphicon-chevron-up.pull-right', 'click', function (e) {
  $(e.target).toggleClass('glyphicon-chevron-up glyphicon-chevron-down');
  var f = true;
  $($($(e.target).parent().get(0)).parent().get(0)).children().get().forEach(function (entry) {
    if (f) {
      f = !f;
      return;
    }
    $(entry).slideToggle('slow');
  });
});

$('body').delegate('td i.fa-plus-square', 'click', function (e) {
  $(e.target).toggleClass('fa-minus-square fa-plus-square');
  $($($(e.target).parent('td')[0]).parent('tr').next()).slideToggle();
});

$('body').delegate('td i.fa-minus-square', 'click', function (e) {
  $(e.target).toggleClass('fa-plus-square fa-minus-square ');
  $($($(e.target).parent('td')[0]).parent('tr').next()).slideToggle();
});

$('#bt').on('show.bs.modal', function() {
  $('#BestTimeToContact').val('');
});

$(document).ready(function() {
  setDateParams('#datetimepicker3', false);
  setDateParams('#datetimepicker4', true);
  setDateParams('#datetimepicker5', true);

  $('#BestTimeSave').on('click', function() {
    $('#bestTimetoContactForm').submit();
  });

  $('#ServiceRequiredSave').on('click', function() {
    $('#courseRequiredForm').submit();
  });

  $('#communicationDetailSave').on('click', function() {
    $('#communicationDetailForm').submit();
  });
});