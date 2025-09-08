import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: '',
        loadComponent: () => import('./layout/tarefas.component').then(m => m.TarefasComponent),
        data: { title: 'Lista de Tarefas' }
    },
    {
        path: '',
        redirectTo: 'tarefas',
        pathMatch: 'full'
    }
]