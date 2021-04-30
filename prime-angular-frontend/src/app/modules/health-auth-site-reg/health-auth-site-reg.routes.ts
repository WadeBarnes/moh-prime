export class HealthAuthSiteRegRoutes {
  public static LOGIN_PAGE = 'health-authority';

  public static MODULE_PATH = 'health-authority-site-registration';
  public static COLLECTION_NOTICE = 'collection-notice';

  public static SITE_MANAGEMENT = 'site-management';
  public static AUTHORIZED_USER = 'authorized-user';
  public static VENDOR = 'vendor';
  public static HEALTH_AUTH_CARE_SETTING = 'health-auth-care-setting';
  public static SITE_INFORMATION = 'site-information';
  public static SITE_ADDRESS = 'site-address';
  public static HOURS_OPERATION = 'hours-operation';
  public static REMOTE_USERS = 'remote-users';
  public static ADMINISTRATOR = 'site-administrator';
  public static PRIVACY_OFFICER = 'privacy-officer';
  public static TECHNICAL_SUPPORT = 'technical-support';
  public static SITE_OVERVIEW = 'site-overview';

  public static routePath(route: string): string {
    return `/${ HealthAuthSiteRegRoutes.MODULE_PATH }/${ route }`;
  }

  // Used to indicate the routes and order of registration for sites
  public static siteRegistrationRouteOrder(): string[] {
    return [
      this.VENDOR,
      this.HEALTH_AUTH_CARE_SETTING,
      this.SITE_INFORMATION,
      this.SITE_ADDRESS,
      this.HOURS_OPERATION,
      this.REMOTE_USERS,
      this.ADMINISTRATOR,
      this.PRIVACY_OFFICER,
      this.TECHNICAL_SUPPORT
    ];
  }
}