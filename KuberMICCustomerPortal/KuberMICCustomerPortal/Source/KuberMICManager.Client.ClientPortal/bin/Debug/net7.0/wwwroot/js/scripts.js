/**
 *
 * Scripts
 *
 * Initialization of the template base and page scripts.
 *
 *
 */

 class Scripts {
  constructor() {
    this._initSettings();
    this._initVariables();
    this._addListeners();
    this._init();
  }

  // Showing the template after waiting for a bit so that the css variables are all set
  // Initialization of the common scripts and page specific ones
  _init() {
    setTimeout(() => {
      document.documentElement.setAttribute('data-show', 'true');
      document.body.classList.remove('spinner');
      this._initBase();
      this._initCommon();
      this._initForms();
      this._initPages();
      this._initPlugins();
    }, 100);
  }

  // Base scripts initialization
  _initBase() {
    // Navigation
    if (typeof Nav !== 'undefined') {
      const nav = new Nav(document.getElementById('nav'));
    }

    // Search implementation
    if (typeof Search !== 'undefined') {
      const search = new Search();
    }

    // AcornIcons initialization
    if (typeof AcornIcons !== 'undefined') {
      new AcornIcons().replace();
    }
  }

  // Common plugins and overrides initialization
  _initCommon() {
    // common.js initialization
    if (typeof Common !== 'undefined') {
      let common = new Common();
    }
  }

  // Form and form controls pages initialization
   _initForms() {
    // controls.datepicker.js initialization
    if (typeof DatePickerControls !== 'undefined') {
        const datePickerControls = new DatePickerControls();
    }
    // controls.editor.js initialization
    if (typeof EditorControls !== 'undefined') {
        const editorControls = new EditorControls();
    }
  }

  // Pages initialization
  _initPages() {
    // horizontal.js initialization
    if (typeof HorizontalPage !== 'undefined') {
      const horizontalPage = new HorizontalPage();
    }

    // vertical.js initialization
    if (typeof VerticalPage !== 'undefined') {
      const verticalPage = new VerticalPage();
    }
  }

  // Plugin pages initialization
  _initPlugins() {
      // datatable.PostalCodes.js initialization
      if (typeof PostalCodes !== 'undefined') {
          const postalCodes = new PostalCodes();
      }

      // datatable.eventlog.js initialization
      if (typeof EventLogs !== 'undefined') {
          const eventLogs = new EventLogs();
      }
      
      // datatable.liens.js initialization
      if (typeof Liens !== 'undefined') {
          const liens = new Liens();
      }
      // datatable.UniqueActiveInvestors.js initialization
      if (typeof UniqueActiveInvestors !== 'undefined') {
          const uniqueActiveInvestors = new UniqueActiveInvestors();
      }

      // datatable.siteoptions.js initialization
      if (typeof SiteOptions !== 'undefined') {
          const siteOptions = new SiteOptions();
      }

      // datatable.loanvalidation.js initialization
      if (typeof LoanValidation !== 'undefined') {
          const loanValidation = new LoanValidation();
      }

      // datatable.loan.history.js initialization
      if (typeof LoanHistory !== 'undefined') {
          const loanHistory = new LoanHistory();
      }

      // datatable.Loan.modifiedproperties.js initialization
      if (typeof LoanModifiedProperties !== 'undefined') {
          const loanModifiedProperties = new LoanModifiedProperties();
      }

      // datatable.partners.js initialization
      if (typeof Partners !== 'undefined') {
          const partners = new Partners();
      }

      // datatable.partner.history.js initialization
      if (typeof PartnerHistory !== 'undefined') {
          const partnerHistory = new PartnerHistory();
      }

      // datatable.partner.transactions.js initialization
      if (typeof PartnerTransactions !== 'undefined') {
          const partnerTransactions = new PartnerTransactions();
      }

      // datatable.attachments.js initialization
      if (typeof Attachments !== 'undefined') {
          const attachments = new Attachments();
      }
  }

  // Settings initialization
  _initSettings() {
    if (typeof Settings !== 'undefined') {
      const settings = new Settings({attributes: {placement: 'horizontal', color: 'light-blue' }, showSettings: true, storagePrefix: 'acorn-starter-project-'});
    }
  }

  // Variables initialization of Globals.js file which contains valus from css
  _initVariables() {
    if (typeof Variables !== 'undefined') {
      const variables = new Variables();
    }
  }

  // Listeners of menu and layout changes which fires a resize event
  _addListeners() {
    document.documentElement.addEventListener(Globals.menuPlacementChange, (event) => {
      setTimeout(() => {
        window.dispatchEvent(new Event('resize'));
      }, 25);
    });

    document.documentElement.addEventListener(Globals.layoutChange, (event) => {
      setTimeout(() => {
        window.dispatchEvent(new Event('resize'));
      }, 25);
    });

    document.documentElement.addEventListener(Globals.menuBehaviourChange, (event) => {
      setTimeout(() => {
        window.dispatchEvent(new Event('resize'));
      }, 25);
    });
  }
}

// Shows the template after initialization of the settings, nav, variables and common plugins.
(function () {
  window.addEventListener('DOMContentLoaded', () => {
    // Initializing of the Scripts
    if (typeof Scripts !== 'undefined') {
      const scripts = new Scripts();
    }
  });
})();

// Disabling dropzone auto discover before DOMContentLoaded
(function () {
  if (typeof Dropzone !== 'undefined') {
    Dropzone.autoDiscover = false;
  }
})();

// Hide status message after 5 seconds
$(function () {
    $('#message').delay(5000).hide(100);
});
