import { Component } from '@angular/core';
import { NgFor } from '@angular/common';
import { AjaxService } from '../../../services/ajax.service'

import {
  CardBodyComponent,
  CardComponent,
  CardHeaderComponent,
  ColComponent,
  RowComponent,
  ButtonDirective,
  ColDirective,
  FormControlDirective,
  FormDirective,
  FormLabelDirective,
  GutterDirective,
  RowDirective,
  BorderDirective,
  CardTextDirective,
  CardTitleDirective,
  ModalBodyComponent,
  ModalComponent,
  ModalHeaderComponent,
  ModalTitleDirective,
  ModalToggleDirective

} from '@coreui/angular';

import { DocsComponentsComponent } from '@docs-components/public-api';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-tarefas',
  imports: [
    RowComponent,
    ColComponent,
    CardComponent,
    CardHeaderComponent,
    CardBodyComponent,
    DocsComponentsComponent,
    ButtonDirective,
    ColDirective,
    FormControlDirective,
    FormDirective,
    FormLabelDirective,
    GutterDirective,
    RowDirective,
    BorderDirective,
    CardTextDirective,
    CardTitleDirective,
    NgFor,
    ModalBodyComponent,
    ModalComponent,
    ModalHeaderComponent,
    ModalTitleDirective,
    ModalToggleDirective,
    FormsModule
  ],
  templateUrl: './tarefas.component.html',
  styleUrl: './tarefas.component.scss'
})
export class TarefasComponent {
  tarefa = {
    titulo: '',
    descricaoBreve: '',
    descricaoLonga: ''
  };
  icon = "cil-plus";
  colors = [
    { color: 'primary', textColor: 'primary' },
    { color: 'secondary', textColor: 'secondary' },
    { color: 'success', textColor: 'success' },
    { color: 'danger', textColor: 'danger' },
    { color: 'warning', textColor: 'warning' },
    { color: 'info', textColor: 'info' },
    { color: 'light', textColor: '' },
    { color: 'dark', textColor: '' }
  ];

  constructor(private ajax: AjaxService) { }

  cadastrar() {
    console.log(this.tarefa); // Aqui você pega os dados do formulário
    // this.ajax.post("", {});
  }
}
