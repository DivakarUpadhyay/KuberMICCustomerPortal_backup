using KuberMICManager.Core.Domain.Entities.Application;
using KuberMICManager.Core.Domain.Entities.Identity;
using KuberMICManager.Core.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using static KuberMICManager.Core.Domain.Entities.Application.Common;

namespace KuberMICManager.Client.WebUI.Pages.Tools.EventLogs
{
    [Authorize(Policy = "ViewEventLogs")]
    public class IndexModel : PageModel
    {
        private IUserLogRepository _userLogRepository;
        private UserManager<ApplicationUser> _userManager;

        public IndexModel(IUserLogRepository userLogRepository,
                          UserManager<ApplicationUser> userManager)
        {
            _userLogRepository = userLogRepository;
            _userManager = userManager;
        }

        public string queryString { get; set; }
        public AreaType? areaType { get; set; }
        public EventType? eventType { get; set; }

        public IEnumerable<UserLog> eventLogs { get; set; }

        public async Task OnGetAsync()
        {
            eventLogs = await _userLogRepository.FindAllAsync();

            var user = await _userManager.GetUserAsync(User);

            await _userLogRepository.LogEvent(
                        AreaType.Administrative,
                        EventType.GetLogs,
                        user.UserName,
                        "[Get] Event Logs",
                        ResultType.Success
                    );
        }

        public async Task<IActionResult> OnPostSearchAsync(string query, AreaType? areaType = null, EventType ? eventType = null)
        {
            queryString = query?.Trim();

            if (areaType != null)
            {
                this.areaType = areaType;
            }

            if (eventType != null)
            {
                this.eventType = eventType;
            }

            eventLogs = await _userLogRepository.GetLogs(query, areaType, eventType);

            var user = await _userManager.GetUserAsync(User);

            await _userLogRepository.LogEvent(
                        AreaType.Administrative,
                        EventType.GetLogs,
                        user.UserName,
                        $"[Get] Event Logs - Search: {query}, AreaType: {areaType}, EventType: {eventType}",
                        ResultType.Success
                    );

            return Page();
        }
    }
}
