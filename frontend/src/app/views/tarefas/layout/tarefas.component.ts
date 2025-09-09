import { Component, OnInit, ViewChild } from '@angular/core';
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
export class TarefasComponent implements OnInit {

  @ViewChild('modalXl') modalXl!: ModalComponent;

  url = `http://localhost:5235/api/tarefa`;

  tarefa = {
    titulo: "",
    descBreve: "",
    descDetalhada: "",
    statusId: 1
  }

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

  ngOnInit(): void {
    this.read();
  }

  async create() {
    console.log(this.tarefa); // Aqui você pega os dados do formulário
    let result = await this.ajax.post(this.url, this.tarefa);

    console.log(result);

  }

  async read() {
    // let result = await this.ajax.get(this.url, {});
    console.log("aqui");
  }
}
