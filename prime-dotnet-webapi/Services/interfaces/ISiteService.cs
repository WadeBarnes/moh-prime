using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Prime.Models;
using Prime.ViewModels;
using System.Security.Claims;
namespace Prime.Services
{
    public interface ISiteService
    {
        Task<IEnumerable<CommunitySite>> GetSitesAsync(int? organizationId = null);
        Task<CommunitySite> GetSiteAsync(int siteId);
        Task<int> CreateSiteAsync(int organizationId);
        Task<int> UpdateSiteAsync(int siteId, SiteUpdateModel updatedSite);
        Task<int> UpdateCompletedAsync(int siteId, bool completed);
        Task<CommunitySite> UpdateSiteAdjudicator(int siteId, int? adminId = null);
        Task<CommunitySite> UpdatePecCode(int siteId, string pecCode);
        Task DeleteSiteAsync(int siteId);
        Task<CommunitySite> ApproveSite(int siteId);
        Task<CommunitySite> DeclineSite(int siteId);
        Task<CommunitySite> UnrejectSite(int siteId);
        Task<CommunitySite> EnableEditingSite(int siteId);
        Task<CommunitySite> SubmitRegistrationAsync(int siteId);
        Task<CommunitySite> GetSiteNoTrackingAsync(int siteId);
        Task<IEnumerable<BusinessEvent>> GetSiteBusinessEvents(int siteId);
        Task<BusinessLicence> AddBusinessLicenceAsync(int siteId, BusinessLicence businessLicence, Guid documentGuid);
        Task<BusinessLicence> UpdateBusinessLicenceAsync(int siteId, BusinessLicence updateBusinessLicence);
        Task<BusinessLicence> GetBusinessLicenceAsync(int siteId);
        Task<BusinessLicenceDocument> AddOrReplaceBusinessLicenceDocumentAsync(int businessLicenceId, Guid documentGuid);
        Task DeleteBusinessLicenceDocumentAsync(int siteId);
        Task<SiteAdjudicationDocument> AddSiteAdjudicationDocumentAsync(int siteId, Guid documentGuid, int adminId);
        Task<IEnumerable<SiteAdjudicationDocument>> GetSiteAdjudicationDocumentsAsync(int siteId);
        Task<SiteRegistrationNote> CreateSiteRegistrationNoteAsync(int siteId, string note, int adminId);
        Task<IEnumerable<RemoteAccessSearchViewModel>> GetRemoteUserInfoAsync(IEnumerable<CertSearchViewModel> certs);
        Task<IEnumerable<SiteRegistrationNoteViewModel>> GetSiteRegistrationNotesAsync(CommunitySite site);
        Task<IEnumerable<BusinessEvent>> GetSiteBusinessEventsAsync(int siteId, IEnumerable<int> businessEventTypeCodes);
        Task<SiteAdjudicationDocument> GetSiteAdjudicationDocumentAsync(int documentId);
        Task DeleteSiteAdjudicationDocumentAsync(int documentId);
        Task<SiteNotification> CreateSiteNotificationAsync(int siteRegistrationNoteId, int adminId, int assineeId);
        Task RemoveSiteNotificationAsync(int siteNotificationId);
        Task<IEnumerable<SiteRegistrationNoteViewModel>> GetNotificationsAsync(int siteId, int adminId);
        Task<SiteNotification> GetSiteNotificationAsync(int siteNotificationId);
        Task RemoveNotificationsAsync(int siteId);
        Task<SiteRegistrationNoteViewModel> GetSiteRegistrationNoteAsync(int siteId, int siteRegistrationNoteId);
        Task<IEnumerable<int>> GetNotifiedSiteIdsForAdminAsync(ClaimsPrincipal user);
    }
}
