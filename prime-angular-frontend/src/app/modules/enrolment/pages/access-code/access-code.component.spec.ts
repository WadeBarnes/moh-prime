import { waitForAsync, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';

import { KeycloakService } from 'keycloak-angular';

import { MockAuthService } from 'test/mocks/mock-auth.service';

import { AccessCodeComponent } from './access-code.component';
import { APP_CONFIG, APP_DI_CONFIG } from 'app/app-config.module';
import { NgxMaterialModule } from '@lib/modules/ngx-material/ngx-material.module';
import { AuthService } from '@auth/shared/services/auth.service';
import { ConfigService } from '@config/config.service';
import { MockConfigService } from 'test/mocks/mock-config.service';
import { SharedModule } from '@shared/shared.module';

describe('AccessCodeComponent', () => {
  let component: AccessCodeComponent;
  let fixture: ComponentFixture<AccessCodeComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      imports: [
        BrowserAnimationsModule,
        RouterTestingModule,
        HttpClientTestingModule,
        ReactiveFormsModule,
        NgxMaterialModule,
        SharedModule
      ],
      declarations: [],
      providers: [
        {
          provide: APP_CONFIG,
          useValue: APP_DI_CONFIG
        },
        {
          provide: AuthService,
          useClass: MockAuthService
        },
        {
          provide: ConfigService,
          useClass: MockConfigService
        },
        KeycloakService
      ]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccessCodeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
