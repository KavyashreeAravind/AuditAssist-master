import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuditSeverityComponent } from './audit-severity.component';

describe('AuditSeverityComponent', () => {
  let component: AuditSeverityComponent;
  let fixture: ComponentFixture<AuditSeverityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AuditSeverityComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AuditSeverityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
