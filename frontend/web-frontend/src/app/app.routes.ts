import { Routes } from '@angular/router';
import { TicketForm } from './pages/ticket-form/ticket-form';

export const routes: Routes = [
  { path: 'crear-ticket', component: TicketForm },
  { path: '**', redirectTo: 'crear-ticket' },
];
