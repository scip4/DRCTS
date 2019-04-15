$(document).ready(function () {
    
  
    var bootstrapButton = $.fn.button.noConflict() // return $.fn.button to previously assigned value
    $.fn.bootstrapBtn = bootstrapButton            // give $().bootstrapBtn the Bootstrap functionalit
    $('#AddForm').bind('invalid-form.validate', function (error, element) {
            showValidationSummaryDialog();
    });
    $('#emm').bind('click', function (event) {
        $('#dialog').css('left', event.pageX);      // <<< use pageX and pageY
        $('#dialog').css('top', event.pageY);
        $('#dialog').css('display', 'inline');
        $("#dialog").css("position", "absolute");  // <<< also make it absolute!
    });
    if ($('.validation-summary-errors').length > 1) {
        showValidationSummaryDialog();
    }
   // $('#DRCStatus').val("New1");
    $('#OC').val("O");
    $('#avg').hide();
   // alert($('#TFToday').val() + "batt " + $('#error1').length);
    if ($('#avg').val() == "0") {
        $('#avg').hide();
    } else {
        $('#avg').show();
    }
    if ($("#Purchasing option:selected").val() == "PR") {
       // alert("PR");
        $("#npr").show();
        //$("#pra").show();
    } else {
        $("#npr").hide();
        //$("#pra").hide();
    }
    $('#avg').show();
    
    //alert("updated");
    $(":input[data-inputmask-mask]").inputmask();
    $(":input[data-inputmask-alias]").inputmask();
    $(":input[data-inputmask-regex]").inputmask("Regex");
    $("#EmployeePhone").inputmask({ "mask": "(999) 999-9999" }); //specifying options
    $("#SupervisorPhone").inputmask({ "mask": "(999) 999-9999" }); //specifying options
    $("#Amount").inputmask("currency", { radixPoint: '.' });
    $("#DateRequestReceived").inputmask({
        alias: "mm/dd/yyyy",
        placeholder: "mm/dd/yyyy",
    });
    $("#COWADate").inputmask({
        alias: "mm/dd/yyyy",
        placeholder: "mm/dd/yyyy hh:mm:ss xm",
    });
    $("#DateFulfilled").inputmask({
        alias: "mm/dd/yyyy",
        placeholder: "mm/dd/yyyy hh:mm:ss xm",
    });
    $("#DateRequestReceivede").inputmask('datetime', {
        mask: "2/1/y h:s:s t\m",
        alias: "mm/dd/yyyy",
        placeholder: "mm/dd/yyyy hh:mm:ss xm",
        separator: '/',
        hourFormat: "12"
    });
    $("#DateRequestReceivedh").val($("#DateRequestReceived").val());
    $("#DateRequestReceived").on('change paste', function () {
        //alert("test");
        //statusCheck();
    });
    $.getJSON('../api/Employee', function (data) {
       
        //clear the current content of the select
        $('#Categories').empty();
        /*data = data.sort(function (a, b) {
            return (a['EmployeeLastName'] > b['EmployeeLastName']);
            alert(a['EmployeeLastName']);
        });*/
        function GetSortOrder(prop) {
            return function (a, b) {
                if (a[prop] > b[prop]) {
                    return 1;
                } else if (a[prop] < b[prop]) {
                    return -1;
                }
                return 0;
            }
        }
       /* data.sort(function (a, b) {
            return a.EmployeeLastName.localeCompare(b.EmployeeLastName);
        });
        */
        data.sort(GetSortOrder("EmployeeLastName"));
        //iterate over the data and append a select option
        $.each(data, function (i, item) {
            $('#Categories').append('<option value="' + item.ID + '">'
                + item.EmployeeLastName + ',' + item.EmployeeFirstName + ': ' + item.EmployeeEmail + '</option>');
        })
    });
    $("#search").click(function () {
        $("#dialog").dialog({
            modal: true,
            closeOnEscape: true//,
            /* buttons: {
                 Ok: function () {
                     $(this).dialog("close");
                 }
             }*/
        });

    });
    $('#dialog').on('shown', function () {
        $('body').on('wheel.modal mousewheel.modal', function () { return false; });
    }).on('hidden', function () {
        $('body').off('wheel.modal mousewheel.modal');
    });
    $("#Categories").keydown(function (event) {
        if (event.keyCode == 13) {
            // do something here
            // getNames();
            //  alert("You Pres Enter");
            $.getJSON('../api/Employee/' + $(this).val(), function (data) {

                //clear the current content of the select
                // $('#Categories').empty();

                //iterate over the data and append a select option
                $.each(data, function (i, item) {

                    $("#EmployeeLastName").val(item.EmployeeLastName);
                    $("#EmployeeFirstName").val(item.EmployeeFirstName);
                    $("#EmployeeEmail").val(item.EmployeeEmail);
                })
            });
            $("#dialog").dialog("close");
        }
    });
      $("#Categories").on("change", function () {
        //alert($(this).val());
        //getNames();
        $.getJSON('../api/Employee/' + $(this).val(), function (data) {

            //clear the current content of the select
            // $('#Categories').empty();

            //iterate over the data and append a select option
            $.each(data, function (i, item) {

                $("#EmployeeLastName").val(item.EmployeeLastName);
                $("#EmployeeFirstName").val(item.EmployeeFirstName);
                $("#EmployeeEmail").val(item.EmployeeEmail);
            })
        });
       // $("#dialog").dialog("close");
    });
    
    
    $("#rSubmit").keydown(function (event) {
        if (event.keyCode == 13) {
            // do something here
            //alert("You Pres Enter");
            $("#AddForm").submit();
        }
    });






  
    $("#search").keydown(function (event) {
        if (event.keyCode == 13) {
            // do something here
            $("#dialog").dialog({
                modal: true,
                closeOnEscape: true//,
                /* buttons: {
                     Ok: function () {
                         $(this).dialog("close");
                     }
                 }*/
            });
        }
    });

    $("#rSubmit").keydown(function (event) {
        if (event.keyCode == 13) {
            // do something here
            // alert("You Pres Enter");
            $("#AddForm").submit();
        }
    });
    $("#DateRequestReceived").on('change paste', function () {
         //alert($("#DateRequestReceived").val());
        statusCheck();
        var year = new Date($("#DateRequestReceived").val());
        //var qtrR = year.getFullYear() + "-" + getQuarter(e.date);
        var qtrR = getFYQ($("#DateRequestReceived").val());

        var chan = $("#DateRequestReceived").val();
        $('#QuarterReceived').val(qtrR);
        $("#DateRequestReceivedh").val(chan);
        //alert(year.getFullYear());
    });
    $("#COWADate").on('change paste', function () {
        //alert("test");
        statusCheck();
    });
    $("#DateFulfilled").on('change paste', function () {

        statusCheck();
    });

    var options = {
        url: "../api/Employee",

        getValue: "EmployeeLastName",

        template: {
            type: "custom",
            method: function (value, item) {
                return item.EmployeeLastName + "," + item.EmployeeFirstName + " - " + item.EmployeeEmail;
            }
        },

        list: {
            maxNumberOfElements: 10,
            match: {
                enabled: true
            },
            onClickEvent: function () {

                var value1 = $("#EmployeeLastName").getSelectedItemData().EmployeeFirstName;
                var value2 = $("#EmployeeLastName").getSelectedItemData().EmployeeEmail;
                var value3 = $("#EmployeeLastName").getSelectedItemData().EmployeeID;
                $("#EmployeeFirstName").val(value1).trigger("change");
                $("#EmployeeEmail").val(value2).trigger("change");
                $("#EmployeeID").val(value3).trigger("change");
            }
        }
    };
    var options1 = {
        url: "../api/Employee",

        getValue: "EmployeeFirstName",

        template: {
            type: "custom",
            method: function (value, item) {
                return item.EmployeeLastName + "," + item.EmployeeFirstName + " - " + item.EmployeeEmail;
            }
        },

        list: {
            maxNumberOfElements: 10,
            match: {
                enabled: true
            },
            onClickEvent: function () {

                var value1 = $("#EmployeeFirstName").getSelectedItemData().EmployeeLastName;
                var value2 = $("#EmployeeFirstName").getSelectedItemData().EmployeeEmail;
                var value3 = $("#EmployeeFirstName").getSelectedItemData().EmployeeID;
                $("#EmployeeLastName").val(value1).trigger("change");
                $("#EmployeeEmail").val(value2).trigger("change");
                $("#EmployeeID").val(value3).trigger("change");

            }
        }
    };
    $("#EmployeeFirstName").easyAutocomplete(options1);
    $("#EmployeeLastName").easyAutocomplete(options);

    $(function () {

        if ($('#DRCStatus').val() == '') {
            $('#DRCStatus').val("New");
        }
        $('#OC').val("O");
       
        /*$('#datetimepicker6').datetimepicker({
            format: 'MM/DD/YYYY',
            allowInputToggle: true
        });
        $('#datetimepicker7').datetimepicker({
            format: 'MM/DD/YYYY',
            allowInputToggle: true,
            useCurrent: false //Important! See issue #1075
        });
        $('#datetimepicker8').datetimepicker({
            format: 'MM/DD/YYYY',
            allowInputToggle: true,
            useCurrent: false //Important! See issue #1075
        });
        
        $("#datetimepicker6").on("dp.change", function (e) {
            $('#datetimepicker7').data("DateTimePicker").minDate(e.date);
            $('#datetimepicker8').data("DateTimePicker").minDate(e.date);
            statusCheck();
            var year = new Date(e.date);
            //var qtrR = year.getFullYear() + "-" + getQuarter(e.date);
            var qtrR = getFYQ(e.date);
            $('#QuarterReceived').val(qtrR);
            //alert(year.getFullYear());

            
        });
        
        $("#datetimepicker7").on("dp.change", function (e) {
            $('#datetimepicker6').data("DateTimePicker").maxDate(e.date);
            statusCheck();
        });
        $("#datetimepicker8").on("dp.change", function (e) {
            $('#datetimepicker6').data("DateTimePicker").maxDate(e.date);
            statusCheck();
        });*/
        //$("#pr").hide();
    });



    $('#AnalystAssigned').on("change", function () {
        //  alert(33);
        // if ($("#AnalystAssigned option:selected").val().length > 1) {
        statusCheck();
        // } 
    })

    $('#DRCRequestType').on("change", function () {
        // alert($('#DRCRequestType').val());
        if ($('#DRCRequestType').val() == "RA") {
            $('#avg').show();
            var d1 = moment($("#DateRequestReceived").val()).format("YYYY-MM-DD");
            var d2 = moment($('#DateFulfilled').val()).format("YYYY-MM-DD");
            //alert(d1);
            $('#TFToday').val(workingDaysBetweenDates(d1, d2));

        } else {
            //$('#TFToday').val("");
            $('#avg').hide();
        }
    })
    $('#Purchasing').on("change", function () {

        if ($("#Purchasing option:selected").val() == "PR") {
            $("#npr").show();
            //$("#pra").show();
        } else {
            $("#npr").hide();
            //$("#pra").hide();
        }
    })
    $("#test").hide();





});
function eSearch() {
    $("#dialog").dialog({
        modal: true,
        closeOnEscape: true//,
        /* buttons: {
             Ok: function () {
                 $(this).dialog("close");
             }
         }*/
    });
};





function showValidationSummaryDialog() {
    $('#ValidationSummary').html($('#error1').html());

    $('#ValidationSummary').dialog({
        title: 'Error: Incorrect Data Submitted',
        modal: true,
        resizable: false,
                width: 400
    });
};

function clearEM() {
    $("#EmployeeLastName").val('');
    $("#EmployeeFirstName").val('');
    $("#EmployeeEmail").val('');
}
function statusCheck() {

    if ($("#AnalystAssigned option:selected").val().length > 1) {

        if ($('#DateFulfilled').val().length == 0) {

            if ($('#COWADate').val().length == 0) {
                $('#DRCStatus').val("Open");
                $('#OC').val("O");
            } else {
                $('#DRCStatus').val("Other");
                $('#OC').val("O");
            }

        } else {
            $('#DRCStatus').val("Fulfilled");
            $('#OC').val("C");
        }
    } else {
        $('#DRCStatus').val("New");
    }
    if ($('#DateFulfilled').val().length > 0) {
        $('#DateCompleted').val($('#DateFulfilled').val());

    } else if (($('#DateFulfilled').val().length == 0) && ($('#COWADate').val().length > 0)) {
        $('#DateCompleted').val($('#COWADate').val());
    } else {
        $('#DateCompleted').val("");
    }

};

function parseDate(input) {
    // Transform date from text to date
    var parts = input.match(/(\d+)/g);
    // new Date(year, month [, date [, hours[, minutes[, seconds[, ms]]]]])
    return new Date(parts[0], parts[1] - 1, parts[2]); // months are 0-based
};
function getFYQ(d) {
    d = new Date(d);
    var y;
    var m = Math.floor(d.getMonth() / 3) + 2;
    var q = m > 4 ? m - 4 : m;
    if (q == 1) {
        y = d.getFullYear() + 1;
    } else {
        y = d.getFullYear();
    }
    var qtrFY = y + "-" + q;
    return qtrFY;
};

function getQuarter(d) {
    d = new Date(d);
    var m = Math.floor(d.getMonth() / 3) + 2;
    return m > 4 ? m - 4 : m;
};
function workingDaysBetweenDates(d0, d1) {
    var holidays = JSON.parse($('#Holidays').val());
    //var holidays = ['2017-05-03', '2017-05-05'];
    var startDate = parseDate(d0);
    var endDate = parseDate(d1);
    // Validate input
    if (endDate < startDate) {
        return 0;
    }
    console.log("3 " + holidays[1]);
    console.log("cr " + startDate);
    // Calculate days between dates
    var millisecondsPerDay = 86400 * 1000; // Day in milliseconds
    startDate.setHours(0, 0, 0, 1);  // Start just after midnight
    endDate.setHours(23, 59, 59, 999);  // End just before midnight
    var diff = endDate - startDate;  // Milliseconds between datetime objects    
    var days = Math.ceil(diff / millisecondsPerDay);

    // Subtract two weekend days for every week in between
    var weeks = Math.floor(days / 7);
    days -= weeks * 2;

    // Handle special cases
    var startDay = startDate.getDay();
    var endDay = endDate.getDay();

    // Remove weekend not previously removed.   
    if (startDay - endDay > 1) {
        days -= 2;
    }
    // Remove start day if span starts on Sunday but ends before Saturday
    if (startDay == 0 && endDay != 6) {
        days--;
    }
    // Remove end day if span ends on Saturday but starts after Sunday
    if (endDay == 6 && startDay != 0) {
        days--;
    }
    /* Here is the code */
    for (var i in holidays) {
        if ((holidays[i] >= d0) && (holidays[i] <= d1)) {
            days--;
        }
    }
    return days;
};
function mpop() {
    // alert("test");
    $("#dialog").dialog({
        
        modal: true,
        resizable: false,
        position: {
            my: 'center',
            at: 'top',
            of: '#emm'
        },
        buttons: {
            'Clear Fields': function() {
                clearEM();
                $(this).dialog("close");
            },
            Ok: function () {
                width: 550,
                $(this).dialog("close"); //closing on Ok click
                //var e = $.Event('keypress');
                ///e.which = 13; // Character 'A'
                //$(this).trigger(e);
            }
        }
    });
};




