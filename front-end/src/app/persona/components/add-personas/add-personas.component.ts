import { Component } from '@angular/core';
import { Persona, PersonaService } from '../../../services/persona.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-personas',
  templateUrl: './add-personas.component.html',
  styleUrls: ['./add-personas.component.css']
})
export class AddPersonasComponent {

  public nombre: string = '';
  public apellido: string = '';
  public cedula: string = '';
  public direccion: string = '';
  public correos: string[] = [''];

  constructor(
    private personaService: PersonaService,
    private router: Router
  ) {}

  addCorreo():void {
    this.correos.push('');
  }

  deleteCorreo(idx:number):void {
    if (this.correos.length > 1) {
      this.correos.splice(idx,1)
    }
  }

  onSubmit():void {
    const persona = {
      idPersona: 0,
      nombre: this.nombre,
      apellido: this.apellido,
      cedula: this.cedula,
      direccion: this.direccion,
      correos: this.correos
    };

    this.personaService.addPersona(persona).subscribe(() => {
      this.router.navigate(["/personas"]);
    })
  }

}
