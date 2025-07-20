import { Component, Input } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-input-form',
  imports: [MatFormFieldModule, MatInputModule, ReactiveFormsModule],
  templateUrl: './input-form.html',
  styleUrl: './input-form.css',
})
export class InputForm {
  @Input() label!: string;
  @Input() id!: string;
  @Input() formName!: string;
  @Input() group!: FormGroup;

  get control(): FormControl {
    return this.group.get(this.formName) as FormControl;
  }
}
