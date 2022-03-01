import { Component } from '@angular/core';
import { Employee } from './model/employee';
import { EmployeeService } from './service/employee.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Fronend-Thales';
  employees: Employee[] = [];
  id: string;
  constructor(private service: EmployeeService){
  }

  loadAll() {
    this.service.findAll().subscribe(data => {
      if (data.code==200) {
        this.employees=data.data;
      }     
    },
    error => {      
      console.log(error.error);
    } );   
  }

  loadById(id:string) {
    this.service.findById(id).subscribe(data => {
      if (data.code==200) {
        this.employees=[];
        this.employees.push(data.data);
      }     
    },
    error => {      
      console.log(error.error);
    } ); 
  }

  search(){
    console.log('busqueda '+this.id);
    if (this.id=='' || this.id==undefined)
      this.loadAll();    
    else 
      this.loadById(this.id);
  }

}
