import { ComponentFixture, TestBed } from '@angular/core/testing';
import { InputForm } from './input-form';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

describe('InputForm', () => {
  let component: InputForm;
  let fixture: ComponentFixture<InputForm>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        InputForm,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatInputModule,
      ],
    }).compileComponents();

    fixture = TestBed.createComponent(InputForm);
    component = fixture.componentInstance;

    // Configuramos el form group correctamente
    const form = new FormGroup({
      fieldInput: new FormControl('default value'),
    });

    component.group = form;
    component.formName = 'fieldInput';
    component.label = 'Test Label';
    component.id = 'test-id';

    fixture.detectChanges();
  });

  it('should render input with correct value', () => {
    const input = fixture.nativeElement.querySelector('input');
    expect(input.value).toBe('default value');
  });
});
