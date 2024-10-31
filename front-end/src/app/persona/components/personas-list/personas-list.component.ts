import { Component, OnInit } from '@angular/core';
import { Persona, PersonaService } from '../../../services/persona.service';

@Component({
  selector: 'app-personas-list',
  templateUrl: './personas-list.component.html',
  styleUrl: './personas-list.component.css'
})
export class PersonasListComponent implements OnInit {
  personas: Persona[] = [];

  constructor(private personaService: PersonaService) {}

  ngOnInit(): void {
    this.personaService.getPersonas().subscribe(data => {
      this.personas = data;
    })
  }

  eliminarPersona(id:number):void {
    this.personaService.deletePersona(id).subscribe(() => {
      this.personas = this.personas.filter(persona => persona.idPersona !== id)
    })
  }

}
