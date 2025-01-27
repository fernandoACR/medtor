import { Component, OnInit } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Orden } from '../../entites/Entity.Orden';

@Component({
  selector: 'app-orden',
  templateUrl: 'orden.getall.component.html',
  styleUrls: ['./orden.component.scss']
})
export class OrdenGetAllComponent implements OnInit {

  quote: string;
  isLoading: boolean;
  public ordenes: Orden[];

  constructor(
    private http: HttpClient    
  ) {

    let headers = new HttpHeaders().set('Content-Type','application/x-www-form-urlencoded');
    
    http.get<any>('/Orden/GetAllOrdenes', {headers: headers})        
    .subscribe(result => {
      this.ordenes = result as Orden[];
      this.ordenes.forEach(orden => {
        orden.Entregado = orden.FechaEntrega ? true : false;        
        
        
      });
      console.log(this.ordenes);
     }, 
     error => console.error(error)); 
    
    


   }

  ngOnInit() {
    this.isLoading = true;
    
  }

}
