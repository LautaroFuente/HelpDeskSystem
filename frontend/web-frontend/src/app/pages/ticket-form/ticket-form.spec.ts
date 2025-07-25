import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TicketForm } from './ticket-form';
import { ReactiveFormsModule } from '@angular/forms';
import { By } from '@angular/platform-browser';
import { HttpClientTestingModule } from '@angular/common/http/testing';


describe('TicketFormComponent', () => {
  let component: TicketForm;
  let fixture: ComponentFixture<TicketForm>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReactiveFormsModule, TicketForm, HttpClientTestingModule],
    }).compileComponents();

    fixture = TestBed.createComponent(TicketForm);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should render form with all fields', () => {
    const compiled = fixture.nativeElement as HTMLElement;

    expect(compiled.querySelector('input[formControlName="title"]')).toBeTruthy();
    expect(compiled.querySelector('input[formControlName="description"]')).toBeTruthy();
    expect(compiled.querySelector('button')).toBeTruthy();
  });

  it('should show error if send empty', () => {
    const button = fixture.debugElement.query(By.css('button'));
    button.nativeElement.click();
    fixture.detectChanges();

    const errors = fixture.debugElement.queryAll(By.css('.error'));
    expect(errors.length).toBeGreaterThan(0);
  });

  it('should emit submit event if form is valid', () => {
    spyOn(component, 'onSubmit');

    const titleInput = fixture.debugElement.query(By.css('input[formControlName="title"]')).nativeElement;
    const descInput = fixture.debugElement.query(By.css('input[formControlName="description"]')).nativeElement;

    titleInput.value = 'Título válido';
    titleInput.dispatchEvent(new Event('input'));

    descInput.value = 'Descripción válida';
    descInput.dispatchEvent(new Event('input'));

    fixture.detectChanges();

    const button = fixture.debugElement.query(By.css('button'));
    button.nativeElement.click();

    expect(component.onSubmit).toHaveBeenCalled();
  });
});

