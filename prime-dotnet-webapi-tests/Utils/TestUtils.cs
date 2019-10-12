using System.Security.Claims;
using System.Linq;
using Bogus;
using Prime.Models;
using Prime;
using Prime.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;
using PrimeTests.Utils.Auth;

namespace PrimeTests.Utils
{
    public class TestUtils
    {
        public static Faker<PhysicalAddress> PhysicalAddressFaker = new Faker<PhysicalAddress>()
                                .RuleFor(a => a.Country, f => f.Address.Country())
                                .RuleFor(a => a.Province, f => f.Address.StateAbbr())
                                .RuleFor(a => a.Street, f => f.Address.StreetName())
                                .RuleFor(a => a.City, f => f.Address.City())
                                .RuleFor(a => a.Postal, f => f.Address.ZipCode())
                                ;

        public static Faker<MailingAddress> MailingAddressFaker = new Faker<MailingAddress>()
                                .RuleFor(a => a.Country, f => f.Address.Country())
                                .RuleFor(a => a.Province, f => f.Address.StateAbbr())
                                .RuleFor(a => a.Street, f => f.Address.StreetName())
                                .RuleFor(a => a.City, f => f.Address.City())
                                .RuleFor(a => a.Postal, f => f.Address.ZipCode())
                                ;

        public static Faker<Enrollee> EnrolleeFaker = new Faker<Enrollee>()
                                .RuleFor(e => e.UserId, f => f.Random.Word())
                                .RuleFor(e => e.FirstName, f => f.Name.FirstName())
                                .RuleFor(e => e.MiddleName, f => f.Name.FirstName())
                                .RuleFor(e => e.LastName, f => f.Name.LastName())
                                .RuleFor(e => e.DateOfBirth, f => f.Date.Past(20))
                                .RuleFor(e => e.PhysicalAddress, f => PhysicalAddressFaker.Generate())
                                .RuleFor(e => e.MailingAddress, f => MailingAddressFaker.Generate())
                                ;

        public static Faker<Certification> CertificationFaker = new Faker<Certification>()
                                .RuleFor(c => c.CollegeCode, f => f.Random.Short(1, 5))
                                .RuleFor(c => c.LicenseNumber, f => f.Random.Word())
                                .RuleFor(c => c.LicenseCode, f => f.Random.Short(1, 4))
                                .RuleFor(c => c.RenewalDate, f => f.Date.Past(20))
                                .RuleFor(c => c.PracticeCode, f => f.Random.Short(1, 4))
                                ;

        public static Faker<Job> JobFaker = new Faker<Job>()
                                .RuleFor(j => j.Title, f => f.Random.Word())
                                ;

        public static Faker<Organization> OrganizationFaker = new Faker<Organization>()
                                .RuleFor(o => o.Name, f => f.Random.Word())
                                .RuleFor(o => o.OrganizationTypeCode, f => f.Random.Short(1, 2))
                                .RuleFor(o => o.City, f => f.Address.City())
                                .RuleFor(o => o.StartDate, f => f.Date.Future(2))
                                ;

        public static Faker<Enrolment> EnrolmentFaker = new Faker<Enrolment>()
                                    .RuleFor(e => e.Enrollee, f => EnrolleeFaker.Generate())
                                    .RuleFor(e => e.AppliedDate, f => new DateTime())
                                    .RuleFor(e => e.HasCertification, f => f.Random.Bool())
                                    .RuleFor(e => e.Certifications, f => CertificationFaker.Generate(2))
                                    .RuleFor(e => e.IsDeviceProvider, f => f.Random.Bool())
                                    .RuleFor(e => e.DeviceProviderNumber, f => f.Random.Word())
                                    .RuleFor(e => e.IsInsulinPumpProvider, f => f.Random.Bool())
                                    .RuleFor(e => e.IsAccessingPharmaNetOnBehalfOf, f => f.Random.Bool())
                                    .RuleFor(e => e.Jobs, f => JobFaker.Generate(2))
                                    .RuleFor(e => e.HasConviction, f => f.Random.Bool())
                                    .RuleFor(e => e.HasConvictionDetails, f => f.Lorem.Paragraphs(2))
                                    .RuleFor(e => e.HasRegistrationSuspended, f => f.Random.Bool())
                                    .RuleFor(e => e.HasRegistrationSuspendedDetails, f => f.Lorem.Paragraphs(2))
                                    .RuleFor(e => e.HasDisciplinaryAction, f => f.Random.Bool())
                                    .RuleFor(e => e.HasDisciplinaryActionDetails, f => f.Lorem.Paragraphs(2))
                                    .RuleFor(e => e.HasPharmaNetSuspended, f => f.Random.Bool())
                                    .RuleFor(e => e.HasPharmaNetSuspendedDetails, f => f.Lorem.Paragraphs(2))
                                    .RuleFor(e => e.Organizations, f => OrganizationFaker.Generate(2))
                                    ;

        public static int? CreateEnrolment(ApiDbContext apiDbContext)
        {
            return new DefaultEnrolmentService(apiDbContext).CreateEnrolmentAsync(TestUtils.EnrolmentFaker.Generate()).Result;
        }

        public static Enrolment GetEnrolmentById(ApiDbContext apiDbContext, int enrolmentId)
        {
            return new DefaultEnrolmentService(apiDbContext).GetEnrolmentAsync(enrolmentId).Result;
        }

        public static void InitializeDbForTests(ApiDbContext db)
        {
            // db.Enrolments.AddRange(EnrolmentFaker.Generate(5));

            db.AddRange(new College { Code = 1, Name = "College of Physicians and Surgeons of BC (CPSBC)", Prefix = "91" });
            db.AddRange(new College { Code = 2, Name = "College of Pharmacists of BC (CPBC)", Prefix = "P1" });
            db.AddRange(new College { Code = 3, Name = "College of Registered Nurses of BC (CRNBC)", Prefix = "96" });
            db.AddRange(new College { Code = 4, Name = "None", Prefix = null });

            db.AddRange(new License { Code = 1, Name = "Full - General" });
            db.AddRange(new License { Code = 2, Name = "Full - Pharmacist" });
            db.AddRange(new License { Code = 3, Name = "Full - Specialty" });
            db.AddRange(new License { Code = 4, Name = "Registered Nurse" });
            db.AddRange(new License { Code = 5, Name = "Temporary Registered Nurse"});

            db.AddRange(new CollegeLicense { CollegeCode = 1, LicenseCode = 2 });
            db.AddRange(new CollegeLicense { CollegeCode = 1, LicenseCode = 3 });
            db.AddRange(new CollegeLicense { CollegeCode = 2, LicenseCode = 4 });
            db.AddRange(new CollegeLicense { CollegeCode = 2, LicenseCode = 5 });
            db.AddRange(new CollegeLicense { CollegeCode = 3, LicenseCode = 1 });
            db.AddRange(new CollegeLicense { CollegeCode = 3, LicenseCode = 5 });

            db.AddRange(new Practice { Code = 1, Name = "Remote Practice" });
            db.AddRange(new Practice { Code = 2, Name = "Reproductive Care" });
            db.AddRange(new Practice { Code = 3, Name = "Sexually Transmitted Infections (STI)" });
            db.AddRange(new Practice { Code = 4, Name = "None" });

            db.AddRange(new JobName { Code = 1, Name = "Medical Office Assistant" });
            db.AddRange(new JobName { Code = 2, Name = "Midwife" });
            db.AddRange(new JobName { Code = 3, Name = "Nurse (not nurse practitioner)" });
            db.AddRange(new JobName { Code = 4, Name = "Pharmacy Assistant" });
            db.AddRange(new JobName { Code = 5, Name = "Pharmacy Technician" });
            db.AddRange(new JobName { Code = 6, Name = "Registration Clerk" });
            db.AddRange(new JobName { Code = 7, Name = "Ward Clerk" });
            db.AddRange(new JobName { Code = 8, Name = "Other" });

            db.AddRange(new OrganizationName { Code = 1, Name = "Vancouver Island Health" });
            db.AddRange(new OrganizationName { Code = 2, Name = "Shoppers Drug Mart" });

            db.AddRange(new OrganizationType { Code = 1, Name = "Health Authority" });
            db.AddRange(new OrganizationType { Code = 2, Name = "Pharmacy" });

            db.SaveChanges();
        }

        public static void ReinitializeDbForTests(ApiDbContext db)
        {
            // db.Enrolments.RemoveRange(db.Enrolments);
            InitializeDbForTests(db);
        }

        public static async Task<string> GetBodyFromResponse(HttpResponseMessage response)
        {
            return await response.Content.ReadAsStringAsync();
        }

        public static T DeserializeBody<T>(string body)
        {
            return JsonConvert.DeserializeObject<T>(body);
        }

        public static async Task<T> DeserializeResponse<T>(HttpResponseMessage response)
        {
            return DeserializeBody<T>(await GetBodyFromResponse(response));
        }

        public static void DetachAllEntities(ApiDbContext _dbContext)
        {
            var changedEntriesCopy = _dbContext.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted ||
                            e.State == EntityState.Unchanged)
                .ToList();

            foreach (var entry in changedEntriesCopy)
            {
                entry.State = EntityState.Detached;
            }
        }

        public static BearerTokenBuilder TokenBuilder()
        {
            return new BearerTokenBuilder()
                        .ForAudience(TestAuthorizationConstants.Audience)
                        .IssuedBy(TestAuthorizationConstants.Issuer)
                        .WithSigningCertificate(EmbeddedResourceReader.GetCertificate(TestAuthorizationConstants.CertificatePassword));
        }

    }
}
