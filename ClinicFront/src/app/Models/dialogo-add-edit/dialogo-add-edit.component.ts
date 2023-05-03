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
    console.log(this.dataPeople)
    this.formPeople = this.fb.group({
      nmid:['',Validators.required],
      nmid_persona:['',Validators.required],
      cddocumento:['',Validators.required],
      dsnombres:['',Validators.required],
      dsapellidos:['',Validators.required],
      fenacimiento:['',Validators.required],
      cdtipo:['',Validators.required],
      cdgenero:['',Validators.required],
      feregistro:['',Validators.required],
      febaja:['',Validators.required],
      cdusuario:['',Validators.required],
      dsdireccion:['',Validators.required],
      dsphoto:['',Validators.required],
      cdtelefono_fijo:['',Validators.required],
      cdtelefono_movil:['',Validators.required],
      dsemail:['',Validators.required],
      nmid_medicotra:[''],
      dseps:[''],
      dsarl:[''],
      dscondicion:[''],
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
      nmid:this.formPeople.value.nmid,
      nmid_persona:this.formPeople.value.nmid_persona,
      cddocumento:this.formPeople.value.cddocumento,
      dsnombres:this.formPeople.value.dsnombres,
      dsapellidos:this.formPeople.value.dsapellidos,
      fenacimiento:moment(this.formPeople.value.fenacimiento).format("YYYY-MM-DD"),
      cdtipo:this.formPeople.value.cdtipo,
      cdgenero:this.formPeople.value.cdgenero,
      feregistro:moment(this.formPeople.value.feregistro).format("YYYY-MM-DD"),
      febaja:moment(this.formPeople.value.febaja).format("YYYY-MM-DD"),
      cdusuario:this.formPeople.value.cdusuario,
      dsdireccion:this.formPeople.value.dsdireccion,
      dsphoto:this.formPeople.value.dsphoto,
      cdtelefono_fijo:this.formPeople.value.cdtelefono_fijo,
      cdtelefono_movil:this.formPeople.value.cdtelefono_movil,
      dsemail:this.formPeople.value.dsemail,
      nmid_medicotra:this.formPeople.value.nmid_medicotra,
      dseps:this.formPeople.value.dseps,
      dsarl:this.formPeople.value.dsarl,
      dscondicion:this.formPeople.value.dscondicion
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
      console.log(this.formPeople.value)
      this.formPeople.patchValue({
        nmid:this.dataPeople.nmid_persona,
        cddocumento:this.dataPeople.cddocumento,
        dsnombres:this.dataPeople.dsnombres,
        dsapellidos:this.dataPeople.dsapellidos,
        fenacimiento:moment(this.dataPeople.fenacimiento, "YYYY-MM-DD"),
        cdtipo:this.dataPeople.cdtipo,
        cdgenero:this.dataPeople.cdgenero,
        feregistro:moment(this.dataPeople.feregistro, "YYYY-MM-DD"),
        febaja:moment(this.dataPeople.febaja, "YYYY-MM-DD"),
        cdusuario:this.dataPeople.cdusuario,
        dsdireccion:this.dataPeople.dsdireccion,
        dsphoto:this.dataPeople.dsphoto,
        cdtelefono_fijo:this.dataPeople.cdtelefono_fijo,
        cdtelefono_movil:this.dataPeople.cdtelefono_movil,
        dsemail:this.dataPeople.dsemail,
        nmid_medicotra:this.dataPeople.nmid_medicotra,
        dseps:this.dataPeople.dseps,
        dsarl:this.dataPeople.dsarl,
        dscondicion:this.dataPeople.dscondicion
      })
    }
  }
}
