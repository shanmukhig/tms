$('body').delegate('ul li span i.fa-times', 'click', function () {
  var li = $(this).closest('li');
  li.fadeOut('slow', function () { li.remove(); });
});

$('body').delegate('tr td span i.fa-times', 'click', function (e) {
  $($($(e.target).parent('td')[0]).parent('tr').next()).slideToggle();
});

$('body').delegate('i.fa-chevron-down.pull-right', 'click', function (e) {
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

$('body').delegate('i.fa-chevron-up.pull-right', 'click', function (e) {
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

$('span i.fa-search').click(function () {
    window.location = $(this).attr('data-url').replace('%7BsearchFields%7D', $('.selectpicker').val()).replace('%7BsearchString%7D', $('#txtSearch').val());;
  });