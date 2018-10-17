import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BrowseCookbookComponent } from './browse-cookbook.component';

describe('BrowseCookbookComponent', () => {
  let component: BrowseCookbookComponent;
  let fixture: ComponentFixture<BrowseCookbookComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BrowseCookbookComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BrowseCookbookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
