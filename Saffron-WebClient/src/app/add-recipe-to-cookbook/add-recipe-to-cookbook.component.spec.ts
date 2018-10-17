import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddRecipeToCookbookComponent } from './add-recipe-to-cookbook.component';

describe('AddRecipeToCookbookComponent', () => {
  let component: AddRecipeToCookbookComponent;
  let fixture: ComponentFixture<AddRecipeToCookbookComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddRecipeToCookbookComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddRecipeToCookbookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
