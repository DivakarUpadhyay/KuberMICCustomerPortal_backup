$(document).on("click", ".open-EditNotesDialog", function () {
    const account = $(this).data('account');
    const recid = $(this).data('recid');
    var loanNotes = $($(this).data('loannotes')).html();
    $(".modal-header #accountID").text(account);
    $(".modal-body #recID").val(recid);
    $(".modal-body #quillEditor .ql-editor").html(loanNotes);
});

$("#LoanNotesForm #editSubmitButton_temp").on("click", function () {
    const recID = $("#recID").val();
    const loanNotes = $('.modal-body #quillEditor .ql-editor').html();
    $.ajax(
        {
            type: 'POST',
            dataType: 'JSON',
            url: '/Loans?handler=SaveNotes',
            data: { recID: recID, loanNotes: loanNotes },
            headers:
            {
                "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
            },
            success:
                function (response) {
                    $("#message").html(response.message);
                },
            error:
                function (response) {
                    $("#message").html(response.message);
                }
        });

    $('#message').show(100)
    $('#message').delay(5000).hide(100);
});
