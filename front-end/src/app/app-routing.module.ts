import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonasListComponent } from './persona/components/personas-list/personas-list.component';
import { AddPersonasComponent } from './persona/components/add-personas/add-personas.component';
import { PersonasInfoComponent } from './persona/components/personas-info/personas-info.component';

const routes: Routes = [
  {path: 'personas', component: PersonasListComponent },
  {path: 'personas/agregar', component: AddPersonasComponent },
  {path: 'personas/info/:id', component: PersonasInfoComponent },
  {path: '', redirectTo: '/personas', pathMatch: 'full'},
  {path: '**', redirectTo: '/personas'},
] ;

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
