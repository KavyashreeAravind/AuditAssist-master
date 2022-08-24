import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RagDetailsComponent } from './rag-details.component';

describe('RagDetailsComponent', () => {
  let component: RagDetailsComponent;
  let fixture: ComponentFixture<RagDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RagDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RagDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
