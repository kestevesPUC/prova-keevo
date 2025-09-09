import { Component, OnInit, ViewChild } from '@angular/core';
import { NgFor } from '@angular/common';
import { AjaxService } from '../../../services/ajax.service'
import Swal from 'sweetalert2';
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
  tarefas: any[] = [];

  constructor(private ajax: AjaxService) { }

  ngOnInit(): void {
    this.readAll();
  }

  async create() {
    let result = await this.ajax.post(this.url, this.tarefa);

    if (result.success) {
      this.fecharModal();
      Swal.fire('Sucesso!', result.message, 'success');
      this.readAll();
    } else {

      Swal.fire('Erro!', result.message, 'error');
    }

  }

  /**
   *     { color: 'primary', textColor: 'primary' },
    { color: 'secondary', textColor: 'secondary' },
    { color: 'success', textColor: 'success' },
    { color: 'danger', textColor: 'danger' },
    { color: 'warning', textColor: 'warning' },
    { color: 'info', textColor: 'info' },
    { color: 'light', textColor: '' },
    { color: 'dark', textColor: '' }
   */

  async readAll() {
    let result = await this.ajax.get(this.url);
    let dados = result.data || [];
    let arr: any[] = [];
    dados.forEach((t: any)  => {
      if (t.dataCriacao) {
        const dataCriacao = new Date(t.dataCriacao);
        const agora = new Date();
        const diffMs = agora.getTime() - dataCriacao.getTime();
        const diffHoras = diffMs / (1000 * 60 * 60);
        if (diffHoras > 24) {
          t.color = 'danger';
          t.textColor = 'danger';
        } else {
          t.color = 'secondary';
          t.textColor = 'secondary';
        }

        arr.push(t);
      }
    });
    this.tarefas = arr;
  }

  fecharModal() {
    this.modalXl.visible = false;
  }
}
