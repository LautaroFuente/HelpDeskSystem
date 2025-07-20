import { Component, inject, OnDestroy, OnInit } from '@angular/core';
import { InputForm } from './components/input-form/input-form';
import { ButtonSubmit } from './components/button-submit/button-submit';
import { Title } from './components/title/title';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  FormsModule,
  Validators,
} from '@angular/forms';
import { Subject, takeUntil } from 'rxjs';
import { TicketService } from '../../services/ticket-service';

@Component({
  selector: 'app-ticket-form',
  imports: [InputForm, ButtonSubmit, Title, ReactiveFormsModule, FormsModule],
  templateUrl: './ticket-form.html',
  styleUrl: './ticket-form.css',
})
export class TicketForm implements OnInit, OnDestroy {
  formTicket!: FormGroup;
  title: string = '';
  description: string = '';

  private unsubscribe$ = new Subject<void>();
  private fb = inject(FormBuilder);
  private ticketService = inject(TicketService);

  ngOnInit() {
    this.formTicket = this.fb.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
    });
  }

  onSubmit() {
    if (this.formTicket.valid) {
      const { title, description } = this.formTicket.value;
      this.ticketService
        .saveTicket(title, description)
        .pipe(takeUntil(this.unsubscribe$))
        .subscribe(
          (response) => {
            console.log('Ticket guardado', response);
          },
          (error) => {
            console.log(`Error al enviar`, error);
          }
        );
    } else {
      console.log('Formulario no válido');
    }
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }
}
