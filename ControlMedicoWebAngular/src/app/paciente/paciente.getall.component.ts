import { Component, OnInit } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Paciente } from '../../entites/Entity.Paciente';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-orden',
  templateUrl: 'paciente.getall.component.html',
  styleUrls: ['./paciente.component.scss']
})
export class PacienteGetAllComponent implements OnInit {

  closeResult: string;
  quote: string;
  isLoading: boolean;
  loginForm: FormGroup;
  public pacientes: Paciente[];

  constructor(
    private http: HttpClient  ,
    private modalService: NgbModal  
  ) {

    let headers = new HttpHeaders().set('Content-Type','application/x-www-form-urlencoded');
    
    http.get<any>('/Paciente/GetAllPacientes', {headers: headers})        
    .subscribe(result => {
      this.pacientes = result as Paciente[];   
      //console.log(this.pacientes);   
     }, 
     error => console.error(error));     
   }

   open(content: any) {    
    this.modalService.open(content, { size: 'lg' }).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      //this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });

  }
  AgregarPaciente() {
    this.isLoading = true;
    this.AddPaciente(this.loginForm.value)
    .pipe(finalize(() => {
        this.loginForm.markAsPristine();
        this.isLoading = false;
      }))
    .subscribe(      
      (jsonData) => {         
        console.log(jsonData);
        //this.router.navigate([this.returnUrl]);
      },
      // The 2nd callback handles errors.
      (err) =>
      {
        //this.authenticationFlag = false;
        console.log(err);
      },
      // The 3rd callback handles the "complete" event.
      () => console.log("observable complete")
    );  
  }
  private AddPaciente(Paciente: PacienteModel) 
  { 
    let headers = new HttpHeaders().set('Content-Type','application/x-www-form-urlencoded');    
    return this.http.post<any>('/Paciente/AddPaciente', Paciente.toString(), {headers: headers})        
    .map(      
      response => response
    )
    .pipe(     
    );

  }

  //Coment Back
  // private getDismissReason(reason: any): string {
  //   if (reason === ModalDismissReasons.ESC) {
  //     return 'by pressing ESC';
  //   } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
  //     return 'by clicking on a backdrop';
  //   } else {
  //     return  `with: ${reason}`;
  //   }
  // }

  ngOnInit() {
    this.isLoading = true;
    
  }

  
}
export interface PacienteModel {
  Nombre: string;
  Telefono: string;
  EstadoCivil: string;
  Identificacion: string;
  Activo: boolean;
}