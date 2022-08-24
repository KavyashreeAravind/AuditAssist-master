import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { loginCredentials } from 'src/Models/loginCredentials';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { loginResponse } from '../../Models/loginResponse';
import { questionResponse } from 'src/Models/questionResponse';
import { auditDetails } from 'src/Models/auditDetails';
import { auditResponse } from 'src/Models/auditResponse';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class AMSService {

  constructor(private http : HttpClient, private toastr:ToastrService) { }

  authreq:string = 'http://40.74.176.99/api/Login/AuthenicateUser';

  homereq:string = 'http://20.225.38.26/api/Home/GetAuditByUserId/';

  qnreq:string = 'http://20.88.195.248/api/AuditCheckList/';

  severityreq:string = 'http://20.236.170.8/api/AuditSeverity';

  private id = new Subject<number>();
  private rag = new BehaviorSubject<string>("");
  private qns = new Subject<string[]>();
  private auditType = new Subject<string>();  
  private auditDetails = new BehaviorSubject<auditResponse>({auditid : 0,
    projectName : null,
    projectManagerName : null,
    applicationOwnerName : null,
    auditType : null,
    auditDate : new Date(),
    projectExecutionStatus : null,
    remedialActionDuration : null,
    userid : parseInt(localStorage.getItem("id")),
    userdetail:null
  });
  private ragDetail = new Subject<auditResponse[]>();

  authToken(login:loginCredentials):Observable<any>{
    return this.http.post<loginResponse>(this.authreq,login, {
        headers: new HttpHeaders({
        'Content-Type' : 'application/json;charset=UTF-8',
        })
    })
  }

  homeDetails(id:number):Observable<any>{
    let header = new HttpHeaders().set(
      "Authorization",
       "Bearer "+ localStorage.getItem("jwt")
    );
    return this.http.get(this.homereq+id, {
      headers : header
    });
  }

  getQuestions(auditType:string):Observable<any>{
    let header = new HttpHeaders().set(
      "Authorization",
       "Bearer "+ localStorage.getItem("jwt")
    );
    return this.http.get<any>(this.qnreq + auditType, {headers:header});
  }

  getSeverityDetails(details:auditDetails):Observable<auditResponse>{
    return this.http.post<auditResponse>(this.severityreq,details, {
      headers: new HttpHeaders({
        'Content-Type' : 'application/json;charset=UTF-8',
        'Authorization' : 'Bearer '+ localStorage.getItem("jwt")
        })
    });
  }

  setStatus(value:string){
    this.rag.next(value);
  }

  getStatus():Observable<any>{
    return this.rag.asObservable();
  } 

  setQns(value:string[]) {      
    this.qns.next(value);
  }  
  
  getQns():Observable<any>{  
    return this.qns.asObservable();
  }  

  setAuditType(type:string){
     this.auditType.next(type);
  }

  getAuditType():Observable<any>{
    return this.auditType.asObservable();
  }

  setSeverity(details:auditResponse){
     this.auditDetails.next(details);
  }

  getSeverity():Observable<any>{
     return this.auditDetails.asObservable();
  }

  setSuccess(message:string,title:string){
    this.toastr.success(message,title);
  }

  setFailure(message:string,title:string){
    this.toastr.error(message,title);
  }
}
