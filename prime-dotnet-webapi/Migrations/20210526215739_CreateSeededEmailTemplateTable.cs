﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Prime.Migrations
{
    public partial class CreateSeededEmailTemplateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedUserId = table.Column<Guid>(nullable: false),
                    CreatedTimeStamp = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedUserId = table.Column<Guid>(nullable: false),
                    UpdatedTimeStamp = table.Column<DateTimeOffset>(nullable: false),
                    Template = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(nullable: false),
                    EmailType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplate", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EmailTemplate",
                columns: new[] { "Id", "CreatedTimeStamp", "CreatedUserId", "EmailType", "ModifiedDate", "Template", "UpdatedTimeStamp", "UpdatedUserId" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), 1, new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), "<p> Your PRIME application status has changed since you last viewed it. Please click <a href=\"@Model.Url\">here</a> to log into PRIME and view your status. </p>", new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000") },
                    { 2, new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), 2, new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), "<style> .underline { text-decoration: underline; } .list-item-mb { margin-bottom: 0.75rem; } </style>To: Clinic Manager (person responsible for coordinating PharmaNet access):<br><br>@Model.EnrolleeFullName has been approved for Private Community Health Practice Access to PharmaNet.<br><br> <strong> To set up their access, you must forward this PRIME Enrolment Confirmation and the information specified below to your <span class=\"underline\">PharmaNet Software Vendor</span>. </strong> <br><br> <ol> <li class=\"list-item-mb\"> Name of medical clinic: </li> <li class=\"list-item-mb\"> Clinic address: </li> <li class=\"list-item-mb\"> Pharmacy equivalency code (PEC): <i>This is your PharmaNet site ID; ask your vendor if you don’t know it:</i> </li> <li class=\"list-item-mb\"> For <strong> physicians, pharmacists, and nurse practitioners:</strong> <br><br> College name and College ID of this user <em>(leave blank if this user is not a physician, pharmacist or nurse practitioner)</em> </li> <li class=\"list-item-mb\"> For users who work <strong>On Behalf Of</strong> a physician, pharmacist, or nurse practitioner: <br><br> College name(s) and College ID(s) of the physicians, pharmacists or nurse practitioners who this user will access PharmaNet on behalf of: <em>(leave this blank if this user is a pharmacist, nurse practitioner or physician)</em> </li> </ol> <a href=\"@Model.TokenUrl\">@Model.TokenUrl</a> <br> <strong>This link will expire after @Model.ExpiresInDays days.</strong> <br><br> Thank you,<br><br> PRIME<br><br> 1-844-397-7463<br><br> <a href='mailto:PRIMEsupport@gov.bc.ca' target='_top'>PRIMEsupport@gov.bc.ca</a>", new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000") },
                    { 3, new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), 3, new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), "To: Whom it may concern, <br> <br> @Model.EnrolleeFullName has been approved for <strong>Community Pharmacy Access to PharmaNet.</strong> They can now be set up with their PharmaNet Access account in your local software. You must include their <strong>Global PharmaNet ID (GPID)</strong> on their account profile. You can access their GPID via this link below. <br> <br> <a href=\"@Model.TokenUrl\">@Model.TokenUrl</a> <br> <strong>This link will expire after @Model.ExpiresInDays days</strong>. <br> <br> Thank you.", new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000") },
                    { 4, new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), 4, new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), "To: PharmNet Access administrator <br> <br> @Model.EnrolleeFullName has been approved for <strong>Health Authority Access to PharmaNet.</strong> <br> They can now be set up with their PharmaNet Access account in your local software. You must include their <strong>Global PharmaNet ID (GPID)</strong> on their account profile. <br> You can access their GPID via this link here. <br> <a href=\"@Model.TokenUrl\">@Model.TokenUrl</a> <br> <strong>This link will expire after @Model.ExpiresInDays days</strong>.", new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000") },
                    { 5, new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), 5, new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), "The Ministry of Health has been notified that you require Remote Access at <br> Organization Name: @Model.OrganizationName <br> Site Address: @Model.SiteStreetAddress, @Model.SiteCity <br> <br> To complete your approval for Remote Access, please ensure you have indicated you require Remote Access on your profile at <a href=\"@Model.PrimeUrl\">@Model.PrimeUrl</a>.", new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000") },
                    { 6, new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), 6, new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), "@{ var pecText = string.IsNullOrWhiteSpace(Model.SitePec) ? \"Not Assigned\" : Model.SitePec; } <p> Notification: The list of Remote Practitioners at @Model.SiteStreetAddress of @Model.OrganizationName (PEC: @pecText) has been updated. The Remote Practitioners at this site are: </p> <h2 class=\"mb-2\">Remote Users</h2> @foreach (var name in Model.RemoteUserNames) { <div class=\"ml-2 mb-2\"> <h5>Name</h5> <span class=\"ml-2\">@name</span> </div> } <h2 class=\"mb-2\">Site Information</h2> <p> See the attached registration and organization agreement for more information. @if (!string.IsNullOrWhiteSpace(Model.DocumentUrl)) { @(\"To access the Business Licence, click this\") <a href=\"@Model.DocumentUrl\" target=\"_blank\">link</a>@(\".\") } </p>", new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000") },
                    { 7, new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), 7, new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), "<p>@Model.DoingBusinessAs with PEC/SiteID @Model.Pec has been approved by the Ministry of Health for PharmaNet access. Please notify the PharmaNet software vendor for this site and complete any remaining tasks to activate the site.</p><p>Thank you.</p><p>PRIME Support Team.</p>", new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000") },
                    { 8, new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), 8, new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), "@{ var renewalDate = Model.RenewalDate.Date.ToShortDateString(); } Dear @Model.EnrolleeName, <br> <br> Your enrolment for PharmaNet access will expire on @renewalDate. In order to continue to use PharmaNet, you must renew your enrolment information. <br> Click here to visit PRIME. <a href=\"@Model.PrimeUrl\">@Model.PrimeUrl</a>", new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000") },
                    { 9, new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), 9, new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), "<p> A user has uploaded business licence to their PharmaNet site registration. @if (!string.IsNullOrWhiteSpace(Model.Url)) { @(\"To access the Business Licence, click this\") <a href=\"@Model.Url\" target=\"_blank\">link</a>@(\".\") } </p>", new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000") },
                    { 10, new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), 10, new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), "Dear @Model.EnrolleeName, <br> <br> Your enrolment has not been renewed. PRIME will be notifying your PharmaNet software vendor to deactivate your account.", new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000") },
                    { 11, new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), 11, new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), "<p> Your site registration has been approved. The site must now be set up and activated in PharmaNet. Your PharmaNet software vendor will be notified when the site has been activated, and you will hear from them when you can start to use PharmaNet. </p> <p> Individuals who will be accessing PharmaNet at your site should enrol in PRIME now if they have not already done so. For more information, please visit <a href=\"https://www.gov.bc.ca/pharmanet/PRIME\" target=\"_blank\">https://www.gov.bc.ca/pharmanet/PRIME</a>. [for private community practice only: If you have registered any physicians or nurse practitioners for remote access to PharmaNet, they must enroll in PRIME before they use remote access, which they can do here: <a href=\"https://pharmanetenrolment.gov.bc.ca\" target=\"_blank\">https://pharmanetenrolment.gov.bc.ca</a>. You must not permit remote use of PharmaNet until these users are approved in PRIME.] </p> <p> If you have any questions or concerns, please phone 1-844-397-7463 or email <a href=\"mailto:PRIMEsupport@gov.bc.ca\" target=\"_top\">PRIMESupport@gov.bc.ca</a>. </p> <p> Thank you. </p>", new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000") },
                    { 12, new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), 12, new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), "<p> The site you registered in PRIME, @Model.DoingBusinessAs, has been approved by the Ministry of Health. Your SiteID is @Model.Pec. </p> <p> Health Insurance BC has been notified of the site’s approval and will contact your software vendor. Your vendor will complete any remaining setup for your site and may contact you or the PharmaNet Administrator at your site. </p> <p> If you need to update any information in PRIME regarding your site, you may log in at any time using your mobile BC Services Card. If you have any questions or concerns, please phone 1-844-397-7463 or email PRIMESupport@gov.bc.ca. </p> <p> Thank you. </p>", new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000") },
                    { 13, new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), 13, new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), "<p> A new PharmaNet site registration has been received. See the attached registration and organization agreement for more information. @if (!string.IsNullOrWhiteSpace(Model.Url)) { @(\"To access the Business Licence, click this\") <a href=\"@Model.Url\" target=\"_blank\">link</a>@(\".\") } </p>", new DateTimeOffset(new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmailTemplate_EmailType",
                table: "EmailTemplate",
                column: "EmailType",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailTemplate");
        }
    }
}