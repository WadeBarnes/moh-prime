using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Prime.HttpClients;

namespace Prime.Services
{
    public class DocumentService : BaseService, IDocumentService
    {
        private readonly IAgreementService _agreementService;
        private readonly ISiteService _siteService;
        private readonly IDocumentManagerClient _documentManagerClient;

        public DocumentService(
            ApiDbContext context,
            IHttpContextAccessor httpContext,
            IAgreementService agreementService,
            ISiteService siteService,
            IDocumentManagerClient documentManagerClient)
            : base(context, httpContext)
        {
            _agreementService = agreementService;
            _siteService = siteService;
            _documentManagerClient = documentManagerClient;
        }

        public async Task<string> GetDownloadTokenForBusinessLicenceDocument(int siteId)
        {
            var licence = await _siteService.GetLatestBusinessLicenceAsync(siteId);
            return await _documentManagerClient.CreateDownloadTokenAsync(licence.BusinessLicenceDocument.DocumentGuid);
        }

        public async Task<string> GetDownloadTokenForSignedAgreementDocument(int agreementId)
        {
            var signedAgreement = await _agreementService.GetSignedAgreementDocumentAsync(agreementId);
            if (signedAgreement == null)
            {
                return null;
            }

            return await _documentManagerClient.CreateDownloadTokenAsync(signedAgreement.DocumentGuid);
        }

        public async Task<string> GetDownloadTokenForSelfDeclarationDocument(int selfDeclarationDocumentId)
        {
            var selfDeclarationDocument = await _context.SelfDeclarationDocuments
                .Where(sa => sa.Id == selfDeclarationDocumentId).SingleAsync();
            return await _documentManagerClient.CreateDownloadTokenAsync(selfDeclarationDocument.DocumentGuid);
        }

        public async Task<string> GetDownloadTokenForIdentificationDocument(int identificationDocumentId)
        {
            var identificationDocument = await _context.IdentificationDocuments
                .Where(sa => sa.Id == identificationDocumentId).SingleAsync();
            return await _documentManagerClient.CreateDownloadTokenAsync(identificationDocument.DocumentGuid);
        }

        public async Task<string> GetDownloadTokenForEnrolleeAdjudicationDocument(int enrolleeAdjudicationDocumentId)
        {
            var document = await _context.EnrolleeAdjudicationDocuments
                .Where(sa => sa.Id == enrolleeAdjudicationDocumentId).SingleAsync();
            return await _documentManagerClient.CreateDownloadTokenAsync(document.DocumentGuid);
        }

        public async Task<string> GetDownloadTokenForSiteAdjudicationDocument(int siteAdjudicationDocumentId)
        {
            var document = await _context.SiteAdjudicationDocuments
                .Where(sa => sa.Id == siteAdjudicationDocumentId).SingleAsync();
            return await _documentManagerClient.CreateDownloadTokenAsync(document.DocumentGuid);
        }

        public async Task<string> FinalizeDocumentUpload(Guid documentGuid, string filePath)
        {
            return await _documentManagerClient.FinalizeUploadAsync(documentGuid, filePath);
        }
    }
}
