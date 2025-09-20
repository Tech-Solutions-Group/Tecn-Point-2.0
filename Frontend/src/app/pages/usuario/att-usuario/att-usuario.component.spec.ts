import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AttUsuarioComponent } from './att-usuario.component';

describe('AttUsuarioComponent', () => {
  let component: AttUsuarioComponent;
  let fixture: ComponentFixture<AttUsuarioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AttUsuarioComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AttUsuarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
