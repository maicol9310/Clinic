import { Component, OnInit, Inject } from '@angular/core';

import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {MatDialogRef, MAT_DIALOG_DATA} from "@angular/material/dialog";

import {MatSnackBar} from "@angular/material/snack-bar";

import {MAT_DATE_FORMATS} from "@angular/material/core";
import * as moment from 'moment';

import { Sex } from 'src/app/Interfaces/Sex';
import { Doctor } from 'src/app/Interfaces/Doctor';
import { People } from 'src/app/Interfaces/People';
import { TipoPeople } from 'src/app/Interfaces/TipoPeople';
import { PeopleService } from 'src/app/Services/people.service';
import { Patients } from 'src/app/Interfaces/patients';

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
    @Inject (MAT_DIALOG_DATA) public dataPeople:People
  ){

    this.formPeople = this.fb.group({
      nMid:['',Validators.required],
      cDdocumento:['',Validators.required],
      dSnombres:['',Validators.required],
      dSapellidos:['',Validators.required],
      fEnacimiento:['',Validators.required],
      cDtipo:['',Validators.required],
      cDgenero:['',Validators.required],
      fEregistro:['',Validators.required],
      fEbaja:['',Validators.required],
      cDusuario:['',Validators.required],
      dSdireccion:['',Validators.required],
      dSphoto:['',Validators.required],
      cDtelefono_fijo:['',Validators.required],
      cDtelefono_movil:['',Validators.required],
      dSemail:['',Validators.required],
      dMid_medicotra:[''],
      dSeps:[''],
      dSarl:[''],
      dScondicion:[''],
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
    const modelo: People = {
      nMid:this.formPeople.value.nMid,
      cDdocumento:this.formPeople.value.cDdocumento,
      dSnombres:this.formPeople.value.dSnombres,
      dSapellidos:this.formPeople.value.dSapellidos,
      fEnacimiento:moment(this.formPeople.value.fEnacimiento).format("YYYY-MM-DD"),
      cDtipo:this.formPeople.value.cDtipo,
      cDgenero:this.formPeople.value.cDgenero,
      fEregistro:moment(this.formPeople.value.fEregistro).format("YYYY-MM-DD"),
      fEbaja:moment(this.formPeople.value.fEbaja).format("YYYY-MM-DD"),
      cDusuario:this.formPeople.value.cDusuario,
      dSdireccion:this.formPeople.value.dSdireccion,
      dSphoto:this.formPeople.value.dSphoto,
      cDtelefono_fijo:this.formPeople.value.cDtelefono_fijo,
      cDtelefono_movil:this.formPeople.value.cDtelefono_movil,
      dSemail:this.formPeople.value.dSemail,
      dMid_medicotra:this.formPeople.value.dMid_medicotra,
      dSeps:this.formPeople.value.dSeps,
      dSarl:this.formPeople.value.dSarl,
      dScondicion:this.formPeople.value.dScondicion
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
    if(this.dataPeople){
      this.formPeople.patchValue({
        nMid:this.dataPeople.nMid,
        cDdocumento:this.dataPeople.cDdocumento,
        dSnombres:this.dataPeople.dSnombres,
        dSapellidos:this.dataPeople.dSapellidos,
        fEnacimiento:moment(this.dataPeople.fEnacimiento, "YYYY-MM-DD"),
        cDtipo:this.dataPeople.cDtipo,
        cDgenero:this.dataPeople.cDgenero,
        fEregistro:moment(this.dataPeople.fEregistro, "YYYY-MM-DD"),
        fEbaja:moment(this.dataPeople.fEbaja, "YYYY-MM-DD"),
        cDusuario:this.dataPeople.cDusuario,
        dSdireccion:this.dataPeople.dSdireccion,
        dSphoto:this.dataPeople.dSphoto,
        cDtelefono_fijo:this.dataPeople.cDtelefono_fijo,
        cDtelefono_movil:this.dataPeople.cDtelefono_movil,
        dSemail:this.dataPeople.dSemail,
        dMid_medicotra:this.dataPeople.dMid_medicotra,
        dSeps:this.dataPeople.dSeps,
        dSarl:this.dataPeople.dSarl,
        dScondicion:this.dataPeople.dScondicion
      })
    }
  }
}
