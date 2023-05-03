import {AfterViewInit, Component, ViewChild, OnInit} from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';

import { Patients } from './Interfaces/patients';
import {PatientsService} from './Services/patients.service';

import {MatDialog} from '@angular/material/dialog';
import { DialogoAddEditComponent } from './Models/dialogo-add-edit/dialogo-add-edit.component';
import { People } from './Interfaces/People';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements AfterViewInit, OnInit {

  displayedColumns: string[] = ['nmid_persona','cddocumento','dsnombres',
  'dsapellidos','fenacimiento','cdgenero','dsnombresDoctor','dseps','dsarl','feregistro',
  'febaja','cdusuario','dsdireccion','dsphoto','cdtelefono_fijo','cdtelefono_movil',
  'dsemail','dscondicion','Acciones'];

  dataSource = new MatTableDataSource<Patients>();
  ocultarColumna = true;
  constructor(private _patientsService:PatientsService,
  public dialog: MatDialog){}

  ngOnInit(): void {
    this.showPatients();
  }

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  showPatients(){
    this._patientsService.getList().subscribe({
      next:(dataResponse) => {
        this.dataSource.data = dataResponse;
      },error:(e) =>{}
    })
  }

  openDialog() {
    this.dialog.open(DialogoAddEditComponent,{
      disableClose:true,
      width:"350px"
    }).afterClosed().subscribe(resuelto =>{
      if(resuelto === "Creado"){
        this.showPatients();
      }
    })
  }

  openEditDialog(dataPeople:People) {
    this.dialog.open(DialogoAddEditComponent,{
      disableClose:true,
      width:"350px",
      data:dataPeople
    }).afterClosed().subscribe(resuelto =>{
      if(resuelto === "Editado"){
        this.showPatients();
      }
    })
  }
}