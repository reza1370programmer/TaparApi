
using Microsoft.AspNetCore.Mvc;
using Tapar.Core.Common.Api;
using Tapar.Core.Contracts.Interfaces;
using Tapar.Data.Entities;
using Wangkanai.Detection.Models;
using Wangkanai.Detection.Services;

namespace TaparApi.Controllers
{

    public class UserAgentController : BaseController
    {
        public IRepository<Tapar.Data.Entities.UserAgent> Repository { get; set; }
        public IDetectionService detectionService { get; }

        public UserAgentController(IRepository<Tapar.Data.Entities.UserAgent> repository, IDetectionService detectionService)
        {
            Repository = repository;
            this.detectionService = detectionService;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> AddUserAgentInformation(CancellationToken cancellationToken)
        {
            var user_agent = new Tapar.Data.Entities.UserAgent();
            user_agent.EnteranceDate = DateTime.Now;
            switch (detectionService.Browser.Name)
            {
                case Browser.Safari:
                    user_agent.BrowserName = "Safari";
                    break;
                case Browser.Chrome:
                    user_agent.BrowserName = "Chrome";
                    break;
                case Browser.Edge:
                    user_agent.BrowserName = "Edge";
                    break;
                case Browser.Opera:
                    user_agent.BrowserName = "Opera";
                    break;
                case Browser.Firefox:
                    user_agent.BrowserName = "Firefox";
                    break;
                case Browser.Others:
                    user_agent.BrowserName = "Others";
                    break;
            }
            HttpContext.Request.Headers.TryGetValue("Referer", out var refererHeader);
            user_agent.Referer = refererHeader;
            switch (detectionService.Device.Type)
            {
                case Device.Mobile:
                    user_agent.DeviceType = "Mobile";
                    break;
                case Device.Desktop:
                    user_agent.DeviceType = "Desktop";
                    break;
            }
            await Repository.AddAsync(user_agent, cancellationToken);
            return Ok();

        }
    }
}
