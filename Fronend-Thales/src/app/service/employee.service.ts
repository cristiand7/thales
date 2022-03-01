import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from '../model/employee';
import { ResponseBase } from '../model/reponse-base';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private URL_EMPLOYEES: string='https://localhost:7236/api/v1/employees';  

  constructor(private http: HttpClient) { }

  findAll(): Observable<ResponseBase<Employee[]>> {
    return this.http.get<ResponseBase<Employee[]>>(this.URL_EMPLOYEES);

  }

  findById(id:string): Observable<ResponseBase<Employee>> {
    return this.http.get<ResponseBase<Employee>>(this.URL_EMPLOYEES+'/'+id);

  }
}
