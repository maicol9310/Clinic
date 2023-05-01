import { Component, OnInit } from '@angular/core';

import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {MatDialogRef} from "@angular/material/dialog";

import {MatSnackBar} from "@angular/material/snack-bar";

import {MAT_DATE_FORMATS} from "@angular/material/core";
import * as moment from 'moment';

import { Sex } from 'src/app/Interfaces/Sex';
import { Doctor } from 'src/app/Interfaces/Doctor';
import { People } from 'src/app/Interfaces/People';
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
      DMid_medicotra:[''],
      DSeps:[''],
      DSarl:[''],
      DScondicion:[''],
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
    console.log(this.formPeople.value)
    const modelo: People = {
      NMid:0,
      CDdocumento:this.formPeople.value.CDdocumento,
      DSnombres:this.formPeople.value.DSnombres,
      DSapellidos:this.formPeople.value.DSapellidos,
      FEnacimiento:moment(this.formPeople.value.FEnacimiento).format("YYYY/MM/DD"),
      CDtipo:this.formPeople.value.CDtipo,
      CDgenero:this.formPeople.value.CDgenero,
      FEregistro:moment(this.formPeople.value.FEregistro).format("YYYY/MM/DD"),
      FEbaja:moment(this.formPeople.value.FEbaja).format("YYYY/MM/DD"),
      CDusuario:this.formPeople.value.CDusuario,
      DSdireccion:this.formPeople.value.DSdireccion,
      DSphoto:this.formPeople.value.DSphoto,
      CDtelefono_fijo:this.formPeople.value.CDtelefono_fijo,
      CDtelefono_movil:this.formPeople.value.CDtelefono_movil,
      DSemail:this.formPeople.value.DSemail,
      DMid_medicotra:this.formPeople.value.DMid_medicotra,
      DSeps:this.formPeople.value.DSeps,
      DSarl:this.formPeople.value.DSarl,
      DScondicion:this.formPeople.value.DScondicion
    }

    this._peopleService.add(modelo).subscribe({
      next:(data)=>{
        this.openSnackBar("Persona fue creada","Listo");
        this.dialogoReferencia.close("Creado");
      },error:(e)=>{
        this.openSnackBar("No se pudo crear","Error")
      },
    })
  }

  ngOnInit(): void {
    
  }
}
