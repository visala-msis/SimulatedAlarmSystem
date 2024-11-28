import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlarmListComponent } from './alarm-list.component';

describe('AlarmListComponent', () => {
  let component: AlarmListComponent;
  let fixture: ComponentFixture<AlarmListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AlarmListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AlarmListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
