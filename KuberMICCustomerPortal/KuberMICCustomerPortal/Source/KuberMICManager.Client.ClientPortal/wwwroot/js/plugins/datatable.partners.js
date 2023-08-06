/**
 *
 * Partners
 *
 * Pages.Partners page content scripts. Initialized from scripts.js file.
 *
 *
 */

class Partners extends DataTablePluginBase {
    _createInstance() {
        const _this = this;
        this._staticHeight = 50;
        this._datatable = jQuery('#datatableBoxed').DataTable({
            buttons: [
                'excel',
                {
                    extend: 'excel',
                    exportOptions: {
                        columns: ':not(.notexport)'
                    }
                }],
            responsive: true,
            pagingType: 'full_numbers', // First, Previous, Page Numbers, Next, Last
            info: true, // was false....true no change
            order: [], // Clearing default order
            sDom: '<"row"<"col-sm-12"<"table-container"<"card"<"card-body half-padding"t>>>>><"row"<"col-12 mt-3"p>>', // Hiding all other dom elements except table and pagination
            columns: [{ data: 'AchServiceStatus' }, { data: 'Account' }, { data: 'FullName', width: '100px' }, { data: 'Pool', width: '80px' }, { data: 'TrusteeAccountType' }, { data: 'AccountType' }, { data: 'TotalShares' }, { data: 'TotalInvestmentAmount' }, { data: 'address' }, { data: 'Edit' }, { data: 'Certificates' }],
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
            columnDefs: [
                {
                    targets: 10,
                    visible: false,
                    searchable: true,
                },
            ],
        });
    }
}