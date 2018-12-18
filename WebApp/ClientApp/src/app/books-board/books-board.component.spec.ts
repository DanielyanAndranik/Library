import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BooksBoardComponent } from './books-board.component';

describe('BooksBoardComponent', () => {
  let component: BooksBoardComponent;
  let fixture: ComponentFixture<BooksBoardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BooksBoardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BooksBoardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
