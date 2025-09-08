import { Component } from '@angular/core';

import { CardBodyComponent, CardComponent, CardHeaderComponent, ColComponent, RowComponent } from '@coreui/angular';

@Component({
  selector: 'app-tarefas',
  imports: [RowComponent, ColComponent,  CardComponent, CardHeaderComponent, CardBodyComponent],
  templateUrl: './tarefas.component.html',
  styleUrl: './tarefas.component.scss'
})
export class TarefasComponent {}
