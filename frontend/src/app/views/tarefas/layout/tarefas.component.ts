import { Component, OnInit, ViewChild } from '@angular/core';
import { NgFor } from '@angular/common';
import { AjaxService } from '../../../services/ajax.service'
import Swal from 'sweetalert2';
import { IconModule } from '@coreui/icons-angular';
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
    FormsModule,
    IconModule
  ],
  templateUrl: './tarefas.component.html',
  styleUrl: './tarefas.component.scss'
})
export class TarefasComponent implements OnInit {

  formatarDataBR(data: string | Date): string {
    if (!data) return '';
    const d = new Date(data);
    if (isNaN(d.getTime())) return '';
    const dia = d.getDate().toString().padStart(2, '0');
    const mes = (d.getMonth() + 1).toString().padStart(2, '0');
    const ano = d.getFullYear();
    const hora = d.getHours().toString().padStart(2, '0');
    const min = d.getMinutes().toString().padStart(2, '0');
    return `${dia}/${mes}/${ano} ${hora}:${min}`;
  }

  @ViewChild('modalXl') modalXl!: ModalComponent;

  url = `http://localhost:5235/api/tarefa`;

  tarefa = {
    id: 0,
    titulo: "",
    descBreve: "",
    descDetalhada: "",
    statusId: 1,
    dataCriacao: new Date(),
    dataAtualizacao: new Date(),
  }

  icon = "cil-plus";
  tarefas: any[] = [];

  constructor(private ajax: AjaxService) { }

  ngOnInit(): void {
    this.readAll();
  }

  abrirModalVisualizar(tarefaSelecionada: any) {
    this.tarefa = { ...tarefaSelecionada }; // Clona os dados da tarefa clicada
    this.modalXl.visible = true;
  }

  async create() {
    this.tarefa = {
      id: 0,
      titulo: "",
      descBreve: "",
      descDetalhada: "",
      statusId: 1,
      dataCriacao: new Date(),
      dataAtualizacao: new Date(),
    }
    let result = await this.ajax.post(this.url, this.tarefa);

    if (result.success) {
      this.fecharModal();
      Swal.fire('Sucesso!', result.message, 'success');
      this.readAll();
    } else {

      Swal.fire('Erro!', result.message, 'error');
    }

  }


  async readAll() {
    let result = await this.ajax.get(this.url);
    let dados = result.data || [];
    let arr: any[] = [];

    dados.forEach((t: any) => {
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

  async update(id: number) {
    console.log(this.tarefa);
    
    const confirm = await Swal.fire({
      title: `Deseja realmente alterar a tarefa #${id}?`,
      text: 'Esta ação não poderá ser desfeita!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Sim, atualizar!',
      cancelButtonText: 'Cancelar'
    });

    if (confirm.isConfirmed) {
      let result = await this.ajax.put(`${this.url}/${id}`, this.tarefa);
      if (result.success) {
        Swal.fire('Sucesso!', result.message, 'success');
        this.readAll();
        this.fecharModal();
      } else {

        Swal.fire('Erro!', result.message, 'error');
      }
    }
  }

  async delete(id: number) {
    const confirm = await Swal.fire({
      title: `Deseja realmente deletar a tarefa #${id}?`,
      text: 'Esta ação não poderá ser desfeita!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Sim, deletar!',
      cancelButtonText: 'Cancelar'
    });

    if (confirm.isConfirmed) {
      let result = await this.ajax.delete(this.url, id);

      if (result.success) {
        Swal.fire('Sucesso!', result.message, 'success');
        this.readAll();
        this.fecharModal();
      } else {

        Swal.fire('Erro!', result.message, 'error');
      }
    }
  }

  fecharModal() {
    this.modalXl.visible = false;
  }
}
