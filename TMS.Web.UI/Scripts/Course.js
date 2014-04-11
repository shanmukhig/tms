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

$('#courseTopicForm').validate({
  rules: {
    Title: { required: true },
    DurationInHours: { range: [1, 9999] },
  },
  messages: {
    Title: { required: 'Title required.' },
    DurationInHours: { range: "Duration must be greater than 0." },
  },
  showErrors: se,
  submitHandler: function (form) {
    $('#ct').modal('hide');
    var s = $.validator.format('<li class="list-group-item"><div class="row"><div class="col-md-4"><strong>Title: </strong>{0}</div><div class="col-md-3"><strong>Duration: </strong>{1} hours</div><div class="col-md-4"><strong>Description: </strong>{2}</div><div class="col-md-1"><span class="btn btn-xs btn-danger btn-outline pull-right"><i class="glyphicon glyphicon-remove"></i></span></div></div></li>', $('#topicTitle').val(), $('#DurationInHours').val(), $('#topicDescription').val());
    $(s).appendTo('ul#ulCourseDetails');
  }
});

$('#courseCreateForm').validate({
  rules: {
    Title: { required: true },
    DurationInDays: { range: [1, 9999] },
    Price: { range: [1, 9999] },
  },
  messages: {
    Title: { required: 'Title required.' },
    DurationInDays: { range: "Duration must be between greater than 0." },
    Price: { range: 'Price must be between greater than 0.' },
  },
  showErrors: se,
  submitHandler: function (form) {
    var btn = $('#btnSave');
    btn.html('<i class="fa fa-spinner fa-spin text-warning"></i>');
    btn.attr('disabled', true);

    var course= {
      
    }

    return false;
  }
});