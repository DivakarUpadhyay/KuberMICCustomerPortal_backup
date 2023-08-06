using KuberMICManager.Core.Domain.Framework;
using System;

namespace KuberMICManager.Core.Domain.ViewModels
{
    public class PaginationViewModel
    {
        public IPaginated Paginated { get; set; }

        /// <summary>
        /// Set the number of pages to display on the screen
        /// </summary>
        public int MaxPagesToDisplay { get; set; }

        /// <summary>
        /// Calcuates which page to stop displaying at  PageIndex to DisplayUpToPageIndex
        /// </summary>
        public int DisplayUpToPageIndex
        {
            get
            {
                return Paginated.PageIndex + Math.Min(MaxPagesToDisplay, (int)(Paginated.TotalCount / Paginated.PageSize) - Paginated.PageIndex);

            }
        }
    }
}