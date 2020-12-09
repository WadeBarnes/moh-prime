using System.Security.Claims;
using System.Collections.Generic;
using Newtonsoft.Json;

using Prime.Auth;
using Prime.Models;
using Prime.Infrastructure;

namespace Prime.ViewModels
{
    public class EnrolleeUpdateModel
    {
        public string PreferredFirstName { get; set; }

        public string PreferredMiddleName { get; set; }

        public string PreferredLastName { get; set; }

        public MailingAddress MailingAddress { get; set; }

        public string Email { get; set; }

        public string SmsPhone { get; set; }

        public string Phone { get; set; }

        public string PhoneExtension { get; set; }

        public ICollection<Certification> Certifications { get; set; }

        public ICollection<Job> Jobs { get; set; }

        public ICollection<EnrolleeRemoteUser> EnrolleeRemoteUsers { get; set; }

        public ICollection<RemoteAccessSite> RemoteAccessSites { get; set; }

        public ICollection<RemoteAccessLocation> RemoteAccessLocations { get; set; }

        public ICollection<EnrolleeCareSetting> EnrolleeCareSettings { get; set; }

        public ICollection<OboSite> OboSites { get; set; }

        [JsonConverter(typeof(EmptyStringToNullJsonConverter))]
        public string DeviceProviderNumber { get; set; }

        public bool? IsInsulinPumpProvider { get; set; }

        public ICollection<SelfDeclaration> SelfDeclarations { get; set; }

        // These properties are set by the backend from the JWT token; we cannot trust these properties from the frontend
        [JsonIgnore]
        public int IdentityAssuranceLevel { get; set; }

        [JsonIgnore]
        public string IdentityProvider { get; set; }

        public void SetTokenProperties(ClaimsPrincipal user)
        {
            IdentityProvider = user.FindFirstValue(Claims.IdentityProvider);
            IdentityAssuranceLevel = user.GetIdentityAssuranceLevel();
        }
    }
}
