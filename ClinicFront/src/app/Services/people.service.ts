import { Injectable } from '@angular/core';

import {HttpClient} from '@angular/common/http';
import { environment } from 'src/environment/environment';
import {Observable} from 'rxjs';
import {People} from '../Interfaces/People';
import { Sex } from '../Interfaces/Sex';
import { TipoPeople } from '../Interfaces/TipoPeople';
import { Doctor } from '../Interfaces/Doctor';

@Injectable({
  providedIn: 'root'
})
export class PeopleService {

  private endpoint:string = environment.endPoint;
  private apiUrl:string = this.endpoint + "people/"
  private Url:string = this.endpoint + "masters/"

  constructor(private http:HttpClient) { }

  getSex():Observable<Sex[]>{
    return this.http.get<Sex[]>(`${this.Url}getSex`);
  }

  getTipoPleople():Observable<TipoPeople[]>{
    return this.http.get<TipoPeople[]>(`${this.Url}getTypePeople`);
  }

  getDoctor():Observable<Doctor[]>{
    return this.http.get<Doctor[]>(`${this.apiUrl}getDoctors`);
  }

  add(modelo:People):Observable<People>{
    return this.http.post<People>(`${this.apiUrl}createUpdate`,modelo)
  }

}
