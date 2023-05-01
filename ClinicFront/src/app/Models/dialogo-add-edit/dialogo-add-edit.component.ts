import { Component, OnInit } from '@angular/core';

import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {MatDialogRef} from "@angular/material/dialog";

import {MatSnackBar} from "@angular/material/snack-bar";

import {MAT_DATE_FORMATS} from "@angular/material/core";
import * as moment from 'moment';

import { Sex } from 'src/app/Interfaces/Sex';
import { Doctor } from 'src/app/Interfaces/Doctor';
import { TipoPeople } from 'src/app/Interfaces/TipoPeople';
import { PeopleService } from 'src/app/Services/people.service';

export const MY_DATE_FORMATS = {
  parse:{
    dateInput: 'YYYY/MM/DD',
  },
  display:{
    dateInput: 'YYYY/MM/DD',
    monthYearLAbel: 'YYYY MMMMM',
    dateA11yLabel:'LL',
    monthYearA11yLabel: 'YYYY MMMMM'
  }
}

@Component({
  selector: 'app-dialogo-add-edit',
  templateUrl: './dialogo-add-edit.component.html',
  styleUrls: ['./dialogo-add-edit.component.css'],
  providers:[{provide: MAT_DATE_FORMATS, useValue: MY_DATE_FORMATS}]
})
export class DialogoAddEditComponent implements OnInit {

  formPeople: FormGroup;
  tituloAccion: string = "Nuevo";
  botonAccion: string = "Guardar";
  listaDoctors: Doctor[] = [];
  listaSex: Sex[] = [];
  listaTipoPersona: TipoPeople[] = [];

  constructor(
    private dialogoReferencia: MatDialogRef<DialogoAddEditComponent>,
    private fb: FormBuilder,
    private _snackBar: MatSnackBar,
    private _peopleService: PeopleService,
  ){

    this.formPeople = this.fb.group({
      NMid:['',Validators.required],
      CDdocumento:['',Validators.required],
      DSnombres:['',Validators.required],
      DSapellidos:['',Validators.required],
      FEnacimiento:['',Validators.required],
      CDtipo:['',Validators.required],
      CDgenero:['',Validators.required],
      FEregistro:['',Validators.required],
      FEbaja:['',Validators.required],
      CDusuario:['',Validators.required],
      DSdireccion:['',Validators.required],
      DSphoto:['',Validators.required],
      CDtelefono_fijo:['',Validators.required],
      CDtelefono_movil:['',Validators.required],
      DSemail:['',Validators.required],
      DMid_medicotra:['',Validators.required],
      DSeps:['',Validators.required],
      DSarl:['',Validators.required],
      DScondicion:['',Validators.required],
    })

    this._peopleService.getDoctor().subscribe({
      next:(data)=>{
        this.listaDoctors = data;
      },error:(e)=>{}  
    })

    this._peopleService.getSex().subscribe({
      next:(data)=>{
        this.listaSex = data;
      },error:(e)=>{}  
    })

    this._peopleService.getTipoPleople().subscribe({
      next:(data)=>{
        this.listaTipoPersona = data;
      },error:(e)=>{}  
    })
  }
  

  openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action,{
      horizontalPosition:"end",
      verticalPosition:"top",
      duration: 3000
    });
  }

  addEditPeople(){
    console.log(this.formPeople)
    console.log(this.formPeople.value)
  }

  ngOnInit(): void {
    
  }
}
