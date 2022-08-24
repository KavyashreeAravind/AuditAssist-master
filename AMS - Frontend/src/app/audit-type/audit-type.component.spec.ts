import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuditTypeComponent } from './audit-type.component';

describe('AuditTypeComponent', () => {
  let component: AuditTypeComponent;
  let fixture: ComponentFixture<AuditTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AuditTypeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AuditTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
