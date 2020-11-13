export interface Configuration {
  practices: PracticeConfig[];
  colleges: CollegeConfig[];
  countries: Config<string>[];
  jobNames: Config<number>[];
  licenses: LicenseWeightedConfig[];
  careSettings: Config<number>[];
  provinces: ProvinceConfig[];
  statuses: Config<number>[];
  privilegeGroups: PrivilegeGroupConfig[];
  privilegeTypes: Config<number>[];
  statusReasons: Config<number>[];
  vendors: VendorConfig[];
}

export class Config<T> {
  code: T;
  name: string;

  constructor(code: T, name: string) {
    this.code = code;
    this.name = name;
  }
}

export interface LicenseConfig extends Config<number> {
  collegeLicenses: AssociatedCollegeConfig[];
}

export interface LicenseWeightedConfig extends LicenseConfig {
  weight: number;
  licensedToProvideCare: boolean;
  namedInImReg: boolean;
}

export interface PracticeConfig extends Config<number> {
  collegePractices: AssociatedCollegeConfig[];
}

export interface ProvinceConfig extends Config<string> {
  countryCode: string;
}

export interface AssociatedCollegeConfig {
  collegeCode: number;
  [key: string]: number;
}

export interface CollegeConfig extends LicenseConfig, PracticeConfig {
  prefix: string;
}

export interface PrivilegeGroupConfig extends Config<number> {
  privilegeTypeCode: number;
}

export interface VendorConfig extends Config<number> {
  careSettingCode: number;
  careSetting: Config<number>;
}
