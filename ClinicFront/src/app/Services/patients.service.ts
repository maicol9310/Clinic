import { Injectable } from '@angular/core';

import {HttpClient} from '@angular/common/http';
import { environment } from 'src/environment/environment';
import {Observable} from 'rxjs';
import { Patients } from '../Interfaces/patients';

@Injectable({
  providedIn: 'root'
})
export class PatientsService {

  private endpoint:string = environment.endPoint;
  private apiUrl:string = this.endpoint + "patients/getPatients"

  constructor(private http:HttpClient) { }

  getList():Observable<Patients[]>{
    return this.http.get<Patients[]>(`${this.apiUrl}`);
  }
}
