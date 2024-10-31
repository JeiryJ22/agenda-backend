import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonasInfoComponent } from './personas-info.component';

describe('PersonasInfoComponent', () => {
  let component: PersonasInfoComponent;
  let fixture: ComponentFixture<PersonasInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PersonasInfoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PersonasInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
