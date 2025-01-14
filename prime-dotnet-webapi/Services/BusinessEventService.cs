using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Prime.Models;

namespace Prime.Services
{
    public class BusinessEventService : BaseService, IBusinessEventService
    {
        private readonly IAdminService _adminService;

        public BusinessEventService(ApiDbContext context, IHttpContextAccessor httpContext,
            IAdminService adminService)
            : base(context, httpContext)
        {
            _adminService = adminService;
        }

        public async Task<BusinessEvent> CreateStatusChangeEventAsync(int enrolleeId, string description)
        {
            var businessEvent = await CreateBusinessEvent(BusinessEventType.STATUS_CHANGE_CODE, enrolleeId, description);
            _context.BusinessEvents.Add(businessEvent);
            var created = await _context.SaveChangesAsync();

            if (created < 1)
            {
                throw new InvalidOperationException("Could not create status change business event.");
            }

            return businessEvent;
        }

        public async Task<BusinessEvent> CreateEmailEventAsync(int enrolleeId, string description)
        {
            var businessEvent = await CreateBusinessEvent(BusinessEventType.EMAIL_CODE, enrolleeId, description);
            _context.BusinessEvents.Add(businessEvent);
            var created = await _context.SaveChangesAsync();

            if (created < 1)
            {
                throw new InvalidOperationException("Could not create email business event.");
            }

            return businessEvent;
        }

        public async Task<BusinessEvent> CreateNoteEventAsync(int enrolleeId, string description)
        {
            var businessEvent = await CreateBusinessEvent(BusinessEventType.NOTE_CODE, enrolleeId, description);
            _context.BusinessEvents.Add(businessEvent);
            var created = await _context.SaveChangesAsync();

            if (created < 1)
            {
                throw new InvalidOperationException("Could not create note business event.");
            }

            return businessEvent;
        }

        public async Task<BusinessEvent> CreateAdminActionEventAsync(int enrolleeId, string description)
        {
            var businessEvent = await CreateBusinessEvent(BusinessEventType.ADMIN_ACTION_CODE, enrolleeId, description);
            _context.BusinessEvents.Add(businessEvent);
            var created = await _context.SaveChangesAsync();

            if (created < 1)
            {
                throw new InvalidOperationException("Could not create admin action business event.");
            }

            return businessEvent;
        }

        public async Task<BusinessEvent> CreateAdminViewEventAsync(int enrolleeId, string description)
        {
            var businessEvent = await CreateBusinessEvent(BusinessEventType.ADMIN_VIEW_CODE, enrolleeId, description);
            _context.BusinessEvents.Add(businessEvent);
            var created = await _context.SaveChangesAsync();

            if (created < 1)
            {
                throw new InvalidOperationException("Could not create admin view business event.");
            }

            return businessEvent;
        }

        public async Task<BusinessEvent> CreateEnrolleeEventAsync(int enrolleeId, string description)
        {
            var businessEvent = await CreateBusinessEvent(BusinessEventType.ENROLLEE_CODE, enrolleeId, description);
            _context.BusinessEvents.Add(businessEvent);
            var created = await _context.SaveChangesAsync();

            if (created < 1)
            {
                throw new InvalidOperationException("Could not create enrollee business event.");
            }

            return businessEvent;
        }

        public async Task<BusinessEvent> CreateSiteEventAsync(int siteId, int partyId, string description)
        {
            var businessEvent = await CreateSiteBusinessEvent(BusinessEventType.SITE_CODE, siteId, partyId, description);
            _context.BusinessEvents.Add(businessEvent);
            var created = await _context.SaveChangesAsync();

            if (created < 1)
            {
                throw new InvalidOperationException("Could not create site business event.");
            }

            return businessEvent;
        }

        public async Task<BusinessEvent> CreateOrganizationEventAsync(int organizationId, int partyId, string description)
        {
            var userId = _httpContext.HttpContext.User.GetPrimeUserId();
            Admin admin = await _adminService.GetAdminAsync(userId);
            int? adminId = admin?.Id;

            var businessEvent = new BusinessEvent
            {
                PartyId = partyId,
                OrganizationId = organizationId,
                AdminId = adminId,
                BusinessEventTypeCode = BusinessEventType.ORGANIZATION_CODE,
                Description = description,
                EventDate = DateTimeOffset.Now
            };

            _context.BusinessEvents.Add(businessEvent);
            var created = await _context.SaveChangesAsync();

            if (created < 1)
            {
                throw new InvalidOperationException("Could not create organization business event.");
            }

            return businessEvent;
        }

        public async Task<BusinessEvent> CreatePharmanetApiCallEventAsync(int enrolleeId, string licencePrefix, string licenceNumber, string description)
        {
            var businessEvent = await CreateBusinessEvent(BusinessEventType.PHARMANET_API_CALL_CODE, enrolleeId,
                $"Called Pharmanet API with licence prefix {licencePrefix} and licence number {licenceNumber}:  {description}");
            _context.BusinessEvents.Add(businessEvent);
            var created = await _context.SaveChangesAsync();

            if (created < 1)
            {
                throw new InvalidOperationException("Could not create Pharmanet API call event.");
            }

            return businessEvent;
        }

        private async Task<BusinessEvent> CreateBusinessEvent(int BusinessEventTypeCode, int enrolleeId, string description)
        {
            var userId = _httpContext.HttpContext.User.GetPrimeUserId();
            Admin admin = await _adminService.GetAdminAsync(userId);
            int? adminId = admin?.Id;

            var businessEvent = new BusinessEvent
            {
                EnrolleeId = enrolleeId,
                AdminId = adminId,
                BusinessEventTypeCode = BusinessEventTypeCode,
                Description = description,
                EventDate = DateTimeOffset.Now
            };

            return businessEvent;
        }

        private async Task<BusinessEvent> CreateSiteBusinessEvent(int BusinessEventTypeCode, int siteId, int partyId, string description)
        {
            var userId = _httpContext.HttpContext.User.GetPrimeUserId();
            Admin admin = await _adminService.GetAdminAsync(userId);
            int? adminId = admin?.Id;

            var businessEvent = new BusinessEvent
            {
                PartyId = partyId,
                SiteId = siteId,
                AdminId = adminId,
                BusinessEventTypeCode = BusinessEventTypeCode,
                Description = description,
                EventDate = DateTimeOffset.Now
            };

            return businessEvent;
        }
    }
}
