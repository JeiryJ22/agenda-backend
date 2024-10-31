import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PersonasListComponent } from './components/personas-list/personas-list.component';
import { AddPersonasComponent } from './components/add-personas/add-personas.component';
import { PersonasInfoComponent } from './components/personas-info/personas-info.component';
import { MaterialModule } from '../material/material.module';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    PersonasListComponent,
    AddPersonasComponent,
    PersonasInfoComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    FormsModule,
  ],
  exports: [
    PersonasListComponent,
    AddPersonasComponent,
    PersonasInfoComponent
  ]
})
export class PersonaModule { }
