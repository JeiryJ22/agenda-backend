import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface Persona {
  idPersona: number;
  nombre: string;
  apellido: string;
  cedula: string;
  direccion: string;
  correos: string[];
}

@Injectable({
  providedIn: 'root'
})
export class PersonaService {

  private apiUrl = "https://localhost:7071/agenda/personas";

  constructor(private http: HttpClient) { }

  getPersonas(): Observable<Persona[]> {
    return this.http.get<Persona[]>(this.apiUrl)
  }

  addPersona(persona: Persona): Observable<Persona> {
    return this.http.post<Persona>(this.apiUrl, persona);
  }

  deletePersona(id:number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`)
  }
}
