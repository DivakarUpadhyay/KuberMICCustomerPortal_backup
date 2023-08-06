/**
 *
 * Loan History
 *
 * Pages.Loan.History page content scripts. Initialized from scripts.js file.
 *
 *
 */

class LoanHistory extends DataTablePluginBase {
    _createInstance() {
        const _this = this;
        this._datatable = jQuery('#datatableBoxed_History').DataTable({
            buttons: ['copy', 'excel', 'csv', 'print'],
            responsive: true,
            pagingType: 'full_numbers', // First, Previous, Page Numbers, Next, Last
            info: true, // was false....true no change
            order: [], // Clearing default order
            sDom: '<"row"<"col-sm-12"<"table-container"<"card"<"card-body half-padding"t>>>>><"row"<"col-12 mt-3"p>>', // Hiding all other dom elements except table and pagination
            columns: [{ data: 'Date Received' }, { data: 'Date Due' }, { data: 'Reference' }, { data: 'Ach' }, { data: 'Payment Code' }, { data: 'Total Amount Recevied' }, { data: 'Applied To Interest' }, { data: 'Applied to Principal' }, { data: 'Applied To Charges Principal' }, { data: 'Applied To Lender Fee' }, { data: 'Applied To Unpaid Interest' }, {data: 'Loan Balance'}],
            paging: true,
            pageLength: 25,
            language: {
                info: "Showing _START_ to _END_ of _TOTAL_ Entries", // not working
                infoEmpty: "No Records Available", // not working
                paginate: {
                    first: '<i class="cs-arrow-double-left"></i>',
                    previous: '<i class="cs-chevron-left"></i>',
                    next: '<i class="cs-chevron-right"></i>',
                    last: '<i class="cs-arrow-double-right"></i>',
                },
            },
            initComplete: function (settings, json) {
                _this._setInlineHeight();
            },
            drawCallback: function (settings) {
                _this._setInlineHeight();
            },
            columnDefs: [],
            

        });
    }

}