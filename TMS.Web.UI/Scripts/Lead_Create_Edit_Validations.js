$('#courseRequiredForm').validate({
  //onkeyup: false,
  //onfocusout: false,
  rules: {
    CourseName: { required: true },
    ServiceRequired: { required: true },
    AmountQuoted: { required: true, number: true }
  },
  messages: {
    CourseName: { required: 'Course Name required.' },
    ServiceRequired: { required: 'Service required.' },
    AmountQuoted: { required: 'Amount quoted required.', number: 'Amount quoted must be a valid number.' }
  },
  showErrors: function (errorMap, errorList) {
    $.each(this.successList, function (index, value) {
      $(value).popover('hide');
      $(value).closest('div').removeClass('has-error').addClass('has-success');
    });
    $.each(errorList, function (index, value) {
      $(value.element).popover({
        animation: true,
        trigger: 'manual',
        placement: 'right auto',
        content: '<span class="text-danger"><i class="glyphicon glyphicon glyphicon-exclamation-sign"></i> ' + value.message + '</span>', //value.message,
        html: true,
        container: $('#courseRequiredForm').children().css('modal-body'),
      });
      $(value.element).popover('show');
      $(value.element).closest('div').addClass('has-error').removeClass('has-success');
    });
  },
  submitHandler: function (form) {
    var sel = $('#CourseName').find('option:selected');
    $('<li class="list-group-item"><input type="hidden" value="' + sel.val() + '" /><strong>Name: </strong>' + sel.text().split(', ')[0].split(' - ')[1] + ', <strong>Service Required: </strong> ' + pascalCaseToPrettyString($('#ServiceRequired').find('option:selected').text()) + ', <strong>Amount Quoted: </strong>' + $('#AmountQuoted').val() + '<span class="btn btn-xs btn-danger btn-outline pull-right"><i class="glyphicon glyphicon-remove"></i></span></li>')
      .appendTo('ul#courseRequired');
    $('#sr').modal('hide');
    //$('#sr').remove();
    //return true;
    //alert("Course is a valid form!");
    //return false;
  }
});

$('#communicationDetailForm').validate({
  rules: {
    CommunicationType: { required: true },
    Uri: { required: true },
  },
  messages: {
    CommunicationType: { required: 'Communication type required.' },
    Uri: { required: 'ID required.' },
  },
  showErrors: function (errorMap, errorList) {
    $.each(this.successList, function (index, value) {
      $(value).popover('hide');
      $(value).closest('div').removeClass('has-error').addClass('has-success');
    });
    $.each(errorList, function (index, value) {
      $(value.element).popover({
        animation: true,
        trigger: 'manual',
        placement: 'right auto',
        content: '<span class="text-danger"><i class="glyphicon glyphicon glyphicon-exclamation-sign"></i> ' + value.message + '</span>', //value.message,
        html: true,
        container: $('#courseRequiredForm').children().css('modal-body'),
      });
      $(value.element).popover('show');
      $(value.element).closest('div').addClass('has-error').removeClass('has-success');
    });
  },
  submitHandler: function (form) {
    $('<li class="list-group-item"><strong>' + $('#CommunicationType option:selected').text() + ': </strong>' + $('#Uri').val() + '<span class="btn btn-xs btn-danger btn-outline pull-right"><i class="glyphicon glyphicon-remove"></i></span></li>')
      .appendTo('ul#communicationDetail');
    $('#cd').modal('hide');
    $('#cd').removeData();
    //$('.modal fade').remove();
    //$('.modal-backdrop').remove();
    //$('body').removeClass("modal-open");
  }
});


$('#leadCreateForm').validate({
  rules: {
    Salutation: { required: true },
    FirstName: { required: true, minlength: 5 },
    LastName: { required: true, minlength: 5 },
    LeadType: { required: true },
    LeadSource: { required: true },
    ClientStatus: { required: true },
    PreferredCommunicationType: { required: true },
    Status: { required: true },
    City: { required: true, minlength: 5 },
    Country: { required: true },
    BestTimeToContact: { required: true }
    //DemoDateTime: { required: true },
    //ExpectedDateOfJoin: { required: true },
    //CommunicationType: { required: true },
    //Uri: { required: true, minlength: 5 }
  },
  messages: {
    Salutation: { required: 'Salutation requried.' },
    FirstName: { required: 'First Name required.', minlength: 'First name must be at least 5 characters long.' },
    LastName: { required: 'Last Name required.', minlength: 'last name must be at least 5 characters long.' },
    LeadType: { required: 'Lead Type required.' },
    LeadSource: { required: 'Lead Source required.' },
    ClientStatus: { required: 'Client Status required.' },
    PreferredCommunicationType: { required: 'Preferred Comm. Type required.' },
    Status: { required: 'Status required.' },
    //DemoDateTime: { required: 'Demo date time required.' },
    //ExpectedDateOfJoin: { required: 'Expected Date of Join required.' },
    City: { required: 'City required.', minlength: 'City must be at least 5 characters long.' },
    Country: { required: 'Country required.', minlength: 'Country must be at least 5 characters long.' },
    BestTimeToContact: { required: 'Best time to contact requied' }
    //CommunicationType: { required: 'Communicate Type required.' },
    //Uri: { required: 'ID required.', minlength: 'ID must be at least 5 charaters long.' }
  },
  showErrors: function(errorMap, errorList) {
    $.each(this.successList, function(index, value) {
      $(value).popover('hide');
      $(value).closest('div').removeClass('has-error').addClass('has-success');
    });
    $.each(errorList, function(index, value) {
      $(value.element).popover({
        animation: true,
        trigger: 'manual',
        placement: 'left auto',
        content: '<span class="text-danger"><i class="glyphicon glyphicon glyphicon-exclamation-sign"></i> ' + value.message + '</span>', //value.message,
        html: true,
        container: 'body',
      });
      $(value.element).popover('show');
      $(value.element).closest('div').addClass('has-error').removeClass('has-success');
    });
  },
  submitHandler: function(form) {
    alert("Lead Create is a valid form!");
    return false;
  }
});

//showErrors: function(errorMap, errorList) {
//  $.each(this.validElements(), function (index, element) {
//    var $element = $(element).closest('div');
//    $element.data('title', '').removeClass('has-warning').addClass('has-success').tooltip('destroy');
//  });
//  $.each(errorList, function(index, error) {
//    var $element = $(error.element).closest('div');
//    $element.tooltip('destroy').data('title', error.message).addClass('has-warning').removeClass('has-success').tooltip();
//  });
//},