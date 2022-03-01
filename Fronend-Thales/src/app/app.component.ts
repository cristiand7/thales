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
  showError: boolean = false;
  constructor(private service: EmployeeService){
  }

  loadAll() {
    this.service.findAll().subscribe(data => {
      if (data.code==200) {
        this.employees=data.data;
      }  else 
      this.showError=true;   
    },
    error => {      
      this.showError=true;
      console.log(error.error);
    } );   
  }

  loadById(id:string) {
    this.service.findById(id).subscribe(data => {
      if (data.code==200) {
        this.employees=[];
        this.employees.push(data.data);
      } 
      else this.showError=true;
    },
    error => {      
      console.log(error.error);
      this.showError=true;
    } ); 
  }

  search(){
    console.log('busqueda '+this.id);
    this.showError=false;
    if (this.id=='' || this.id==undefined)
      this.loadAll();    
    else 
      this.loadById(this.id);
  }

}
