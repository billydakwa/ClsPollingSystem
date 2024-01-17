import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewPollResultsComponent } from './view-poll-results.component';

describe('ViewPollResultsComponent', () => {
  let component: ViewPollResultsComponent;
  let fixture: ComponentFixture<ViewPollResultsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewPollResultsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewPollResultsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
