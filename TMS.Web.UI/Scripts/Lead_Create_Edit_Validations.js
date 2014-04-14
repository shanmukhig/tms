$('#bestTimetoContactForm').validate({
  rules: {
    BestTimeToContact: {required : true}
  },
  messages: {
    BestTimeToContact: { required: 'Best time to Contact required.' }
  },
  showErrors: ScriptEngine,
  submitHandler: function (form) {
    $('#bt').modal('hide');
    var sel = $('#BestTimeToContact').val();
    if (sel == '')
      return;
    $('<li class="list-group-item">' + sel + '<span class="btn btn-xs btn-danger btn-outline pull-right"><i class="glyphicon glyphicon-remove"></i></span></li>')
      .appendTo('ul#bestTimetoContact');
  }
});

$('#courseRequiredForm').validate({
  rules: {
    CourseId: { required: true },
    ServiceRequired: { required: true },
    AmountQuoted: { required: true, alphanumeric: true }
  },
  messages: {
    CourseId: { required: 'Course Title required.' },
    ServiceRequired: { required: 'Service required.' },
    AmountQuoted: { required: 'Amount quoted required.', alphanumeric: 'Amount quoted must be a positive number.' }
  },
  showErrors: se,
  submitHandler: function (form) {
    var sel = $('#CourseId').find('option:selected');
    if (sel.text() == 'Select One...')
      return;
    var txt = sel.val() + ',' + $('#ServiceRequired').find('option:selected').val() + ',' + $('#AmountQuoted').val();
    $('<li class="list-group-item"><div class="row"><div class="col-md-11"><input type="hidden" value="' + txt + '" /><strong>Title: </strong>' + sel.text().split(', ')[0].split(' - ')[1] + ', <strong>Service Required: </strong>' + $('#ServiceRequired').find('option:selected').text().pascalCaseToPrettyString() + ', <strong>Amount Quoted: </strong>' + $('#AmountQuoted').val() + '</div><div class="col-md-1"><span class="btn btn-xs btn-danger btn-outline pull-right"><i class="glyphicon glyphicon-remove"></i></span></div></div></li>').appendTo('ul#courseRequired');
    $('#sr').modal('hide');
  }
});

jQuery.validator.addMethod("alphanumeric", function (value, element) {
  return this.optional(element) || /^\d+$/i.test(value);
}, "Letters, numbers, and underscores only please");

$('#communicationDetailForm').validate({
  rules: {
    CommunicationType: { required: true },
    Uri: { required: true },
  },
  messages: {
    CommunicationType: { required: 'Communication type required.' },
    Uri: { required: 'ID required.' },
  },
  showErrors: se,
  submitHandler: function (form) {
    var sel = $('#CommunicationType option:selected').val();
    if (sel == '')
      return;
    $('<li class="list-group-item"><strong>' + sel.pascalCaseToPrettyString() + ': </strong>' + $('#Uri').val() + '<span class="btn btn-xs btn-danger btn-outline pull-right"><i class="glyphicon glyphicon-remove"></i></span></li>')
      .appendTo('ul#communicationDetail');
    $('#cd').modal('hide');
  }
});

jQuery.validator.addMethod("ulValdator", function (value, element) {
  return $.map($("#bestTimetoContact li"), function (i) { if ($(i).index() > 1) return new moment($(i).text(), 'dddd MMMM, DD YYYY HH:mm'); }).length > 0;
}, "xyz");

$('#leadCreateForm').validate({
  rules: {
    Salutation: { required: true },
    FirstName: { required: true },
    LastName: { required: true },
    LeadType: { required: true },
    LeadSource: { required: true },
    ClientStatus: { required: true },
    PreferredCommunicationType: { required: true },
    Status: { required: true },
    City: { required: true },
    Country: { required: true },
    bestTimetoContact: { ulValdator: true }
  },
  messages: {
    Salutation: { required: 'Salutation requried.' },
    FirstName: { required: 'First Title required.' },
    LastName: { required: 'Last Title required.' },
    LeadType: { required: 'Lead Type required.' },
    LeadSource: { required: 'Lead Source required.' },
    ClientStatus: { required: 'Client Status required.' },
    PreferredCommunicationType: { required: 'Preferred Comm. Type required.' },
    Status: { required: 'Status required.' },
    City: { required: 'City required.' },
    Country: { required: 'Country required.' },
    bestTimetoContact: { ulValdator: 'Best time to contact should contain at least one item.' }
  },
  showErrors: se,
  submitHandler: function (form) {
    var btn = $('#btnSave');
    btn.html('<i class="fa fa-spinner fa-spin"></i>');
    btn.attr('disabled', true);

    var lead = {
      BestTimeToContact: $.map($("#bestTimetoContact li"), function (i) { if ($(i).index() > 1) return new moment($(i).text(), 'dddd MMMM, DD YYYY HH:mm'); }),
      City: $('#City').val(),
      ClientStatus: $('#ClientStatus').val(),
      CommunicationDetails : $.map($("#communicationDetail li"), function(i) {if ($(i).index() > 1) {var a = $(i).text().split(':');return { CommunicationType: a[0], Uri: a[1] };}}),
      Country: $('#Country').val(),
      Courses: $.map($("#courseRequired li").find('input'), function(i) { var a = $(i).val().split(','); return { CourseId: a[0], AmountQuoted: a[2], ServiceRequired: a[1] }; }),
      DemoDateTime: new moment($('#DemoDateTime').val(), 'dddd MMMM, DD YYYY HH:mm'),
      Description: 'Enquiring for a course',
      ExpectedDateOfJoin: new moment($('#ExpectedDateOfJoin').val(), 'dddd MMMM, DD YYYY'),
      FirstName: $('#FirstName').val(),
      LastName: $('#LastName').val(),
      LeadSource: $('#LeadSource').val(),
      LeadType: $('#LeadType').val(),
      PreferredCommunicationType: $('#PreferredCommunicationType').val(),
      ReferredBy: $('#ReferredBy').val(),
      Salutation: $('#Salutation').val(),
      Status: $('#Status').val(),
    };
    if ($('#leadCreateForm').attr('leadId') != undefined)
      lead.Id = $('#leadCreateForm').attr('leadId');

    $.ajax({
      type: 'POST',
      contentType: 'application/json',
      url: $('#leadCreateForm').attr('action'),
      data: JSON.stringify(lead),
      success: function(data) {
        var uri = $('#leadCreateForm').attr('action').split('/');
        window.location = window.location.protocol + '//' + window.location.host + '/' + uri[1] + '/' + uri[2];
      },
      failure: function(result) {
        alert(result);
      }
    });
  }
});