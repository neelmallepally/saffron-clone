import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageCookbookComponent } from './manage-cookbook.component';

describe('ManageCookbookComponent', () => {
  let component: ManageCookbookComponent;
  let fixture: ComponentFixture<ManageCookbookComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManageCookbookComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManageCookbookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
