var date = new Date();
date.setDate(date.getDate() - 1);

var endDate = new Date();
endDate.setFullYear(endDate.getFullYear() + 1);

function setDateParams(controlName, pickTime) {
  //alert('params');
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
    defaultDate: ''
  });
}

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
    'onConfirm': action,
    'onCancel': function () {
      $(controlName).confirmation('hide');
    }
  });
}

function pascalCaseToPrettyString(s) {
  return s.replace(/([A-Z])/g, function ($1) { return " " + $1; });
}

$('body').delegate('ul li span i.glyphicon-remove', 'click', function () {
  var li = $(this).closest('li');
  li.fadeOut('slow', function () { li.remove(); });
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


//$('#bt').on('click', function() {
//  BootstrapDialog.show({
//    onshow: function(dialogRef) {
//      $('body').delegate('span i.glyphicon-calendar', 'click', function() {
//        setDateParams('#datetimepicker', true);
//        $('#datetimepicker').data('DateTimePicker').show();
//      });
//    },
//    title: 'Best Time to Contact',
//    message: '<div class="input-group date" id="datetimepicker"><input id="validate" class="form-control" readonly="true" type="text"></input><span class="input-group-addon btn-outline btn-primary"><i class="glyphicon glyphicon-calendar"></i></span></div>',
//    buttons: [
//      {
//        id: 'btn-ok',
//        icon: 'glyphicon glyphicon-check',
//        label: 'OK',
//        cssClass: 'btn-primary',
//        autospin: false,
//        autodestroy: true,
//        action: function (dialogRef) {

//          var inp = $('#validate');
//          if (inp.val() != '') {
//            $('#datetimepicker').removeClass('has-error');
//            $('#validate').popover('hide');
//            $('<li class="list-group-item">' + $('#datetimepicker').data('date') + '<span class="btn btn-xs btn-danger btn-outline pull-right"><i class="glyphicon glyphicon-remove"></i></span></li>')
//              .appendTo('ul#bestTimetoContact');
//            dialogRef.close();
//          }
//          $('#validate').popover({
//            animation: true,
//            trigger: 'manual',
//            placement: 'right auto',
//            content: '<span class="text-danger"><i class="glyphicon glyphicon glyphicon-exclamation-sign"></i> ' + 'Date is required.' + '</span>', //value.message,
//            html: true,
//            container: $('#validate').closest('div'),
//          });
//          $('#datetimepicker').addClass('has-error');
//          $('#validate').popover('show');
//        }
//      }
//    ]
//  });
//});

//phone, mobile regex
//skypeid regex
//twitter username regex
//text '/^[a-z][a-z0-9\.,\-_]{5,31}$/i'
///email - ^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/

//$('body').delegate('#CommunicationType', 'change', function () {
//  //alert('icon');
//  var sel = $('#CommunicationType').val();
//  var $i = $('#brandicon');
//  //alert($i.length);
//  //alert(sel);
//  $i.attr('class', '');
//  var cls = 'fa fa-question fa-lg';
//  //alert(sel == 'Email');
//  if (sel == 'Email')
//    cls = 'fa fa-envelope fa-lg';
//  if (sel == 'Skype')
//    cls = 'fa fa-skype fa-lg';
//  if (sel == 'Phone')
//    cls = 'fa fa-phone fa-lg';
//  if (sel == 'Mobile')
//    cls = 'fa fa-mobile fa-lg';
//  if (sel == 'Twitter')
//    cls = 'fa fa-twitter fa-lg';
//  if (sel == 'Facebook')
//    cls = 'fa fa-facebook fa-lg';
//  if (sel == 'LinkedIn')
//    cls = 'fa fa-linkedin fa-lg';
//  $i.addClass(cls);
//});

//$('body').delegate('#commdetails', 'submit', function () {
//  alert($('#CommunicationType').length);
//  $('#commdetails').validate({
//    debug: true,
//    rules : {
//      CommunicationType: { required: true },
//      Uri: { required: true, minlength: 5 }
//    },
//    messages: {
//      CommunicationType: { required: 'Communicate Type required.' },
//      Uri: { required: 'ID required.', minlength: 'ID must be at least 5 charaters long.' }
//    },
//    showErrors: function (errorMap, errorList) {
//      alert('invalid');
//    }
//  });
//});

//$('#cd').on('click', function () {
//  BootstrapDialog.show({
//    onshow: function (dialogRef) {
//      $('body').delegate('span i.glyphicon-calendar', 'click', function () {
//        setDateParams('#datetimepicker', true);
//        $('#datetimepicker').data('DateTimePicker').show();
//      });
//    },
//    title: 'Communication Details',
//    message: '<div><label for="CommunicationType">CommunicationType</label><select class="form-control" id="CommunicationType" name="CommunicationType"><option value="">Select One...</option><option value="Email">Email</option><option value="Phone">Phone</option><option value="Mobile">Mobile</option><option value="Skype">Skype</option><option value="Twitter">Twitter</option><option value="Facebook">Facebook</option><option value="LinkedIn">Linked In</option></select><br><label for="Uri">ID</label><div class="input-group"><span class="input-group-addon"><i id="brandicon" class="fa fa-question fa-lg"></i></span><input class="form-control" id="Uri" name="Uri" type="text" /></div></div>',
//    buttons: [
//      {
//        id: 'btn-ok',
//        icon: 'glyphicon glyphicon-check',
//        label: 'OK',
//        cssClass: 'btn-primary',
//        autospin: false,
//        autodestroy: true,
//        action: function (dialogRef) {

//          var inp = $('#CommunicationType');
//          if (inp.val() != '') {
//            $('#datetimepicker').removeClass('has-error');
//            $('#validate').popover('hide');
//            $('<li class="list-group-item">' + $('#datetimepicker').data('date') + '<span class="btn btn-xs btn-danger btn-outline pull-right"><i class="glyphicon glyphicon-remove"></i></span></li>')
//              .appendTo('ul#bestTimetoContact');
//            dialogRef.close();
//          }
//          $('#CommunicationType').popover({
//            animation: true,
//            trigger: 'manual',
//            placement: 'right auto',
//            content: '<span class="text-danger"><i class="glyphicon glyphicon glyphicon-exclamation-sign"></i> ' + 'Communication Type is required.' + '</span>', //value.message,
//            html: true,
//            container: $('#CommunicationType').closest('div'),
//          });
//          $('#datetimepicker').addClass('has-error');
//          $('#validate').popover('show');

//          //alert($('#commdetails').length);
//          //$('#commdetails').submit();

//          //$('<li class="list-group-item"><strong>' + $('#CommunicationType option:selected').text() + ': </strong>' + $('#Uri').val() + '<span class="btn btn-xs btn-danger btn-outline pull-right"><i class="glyphicon glyphicon-remove"></i></span></li>')
//          //  .appendTo('ul#communicationDetail');
//          //alert($('#cmbCommunicationType').val());

//          //var cmb = $('#cmbCommunicationType');

//          //if (cmb.val() == '') {

//          //}

//          //var inp = $('#validate');
//          //if (inp.val() != '') {
//          //  $('#datetimepicker').removeClass('has-error');
//          //  $('#validate').popover('hide');
//          //  //$('<li class="list-group-item">' + $('#datetimepicker').data('date') + '<span class="btn btn-xs btn-danger btn-outline pull-right"><i class="glyphicon glyphicon-remove"></i></span></li>')
//          //  //  .appendTo('ul#bestTimetoContact');
//            dialogRef.close();
//          //}
//          //$('#validate').popover({
//          //  animation: true,
//          //  trigger: 'manual',
//          //  placement: 'right auto',
//          //  content: '<span class="text-danger"><i class="glyphicon glyphicon glyphicon-exclamation-sign"></i> ' + 'Date is required.' + '</span>', //value.message,
//          //  html: true,
//          //  container: $('#validate').closest('div'),
//          //});
//          //$('#datetimepicker').addClass('has-error');
//          //$('#validate').popover('show');
//        }
//      }
//    ]
//  });
//});

$('#bt').on('shown.bs.modal', function() {
  $('#BestTimeToContact').val('');
});

$(document).ready(function () {
  setDateParams('#datetimepicker3', false);
  setDateParams('#datetimepicker4', true);
  setDateParams('#datetimepicker5', true);

  $('#BestTimeSave').on('click', function () {
    if ($('#BestTimeToContact').val() == '') {
      $('form').validate();
      return;
    }
      
    $('#bt').modal('hide');
    $('<li class="list-group-item">' + $('#BestTimeToContact').val() + '<span class="btn btn-xs btn-danger btn-outline pull-right"><i class="glyphicon glyphicon-remove"></i></span></li>')
.appendTo('ul#bestTimetoContact');
  });

  $('#ServiceRequiredSave').on('click', function () {
    //alert($('#ServiceRequiredSave').closest('form').length);
    $('#ServiceRequiredSave').closest('form').submit();
    //alert(isValid);
    //$('#sr').modal('hide');
    //$('<li class="list-group-item"><input type="hidden" value="' + $('#course').find('option:selected').val() + '" /><strong>Name: </strong>' + $('#course').find('option:selected').text().split(', ')[0].split(' - ')[1] + ', <strong>Service Required: </strong> ' + pascalCaseToPrettyString($('#serviceRequired').find('option:selected').text()) + ', <strong>Amount Quoted: </strong>' + $('#amountQuoted').val() + '<span class="btn btn-xs btn-danger btn-outline pull-right"><i class="glyphicon glyphicon-remove"></i></span></li>')
    //  .appendTo('ul#courseRequired');
  });

  $('#communicationDetailSave').on('click', function () {
    $('#communicationDetailSave').closest('form').submit();
    //$('#cd').modal('hide');
    //$('<li class="list-group-item"><strong>' + $('#cmbCommunicationType option:selected').text() + ': </strong>' + $('#txtUri').val() + '<span class="btn btn-xs btn-danger btn-outline pull-right"><i class="glyphicon glyphicon-remove"></i></span></li>')
    //  .appendTo('ul#communicationDetail');
  });
});

//$('#myModal').on('show.bs.modal', function (e) {
//  if (!data) return e.preventDefault() // stops modal from being shown
//})