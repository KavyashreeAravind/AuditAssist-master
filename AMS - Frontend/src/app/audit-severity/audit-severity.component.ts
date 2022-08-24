import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Subscription } from 'rxjs';
import { auditDetails } from 'src/Models/auditDetails';
import { auditResponse } from 'src/Models/auditResponse';
import { AMSService } from '../service/AMS.service';

@Component({
  selector: 'app-audit-severity',
  templateUrl: './audit-severity.component.html',
  styleUrls: ['./audit-severity.component.css']
})
export class AuditSeverityComponent implements OnInit {

  constructor(private jwtHelper:JwtHelperService,private service:AMSService,private router : Router) { }   

  private auditSubscription: Subscription;
  apiResponse:auditResponse;
  isPageLoaded:boolean=false;

  ngOnInit(): void { 
    this.auditSubscription = this.service.getSeverity().subscribe({next:(details:auditResponse) => {
      this.apiResponse = details;
      this.isPageLoaded=true;
      },
      error:(err:HttpErrorResponse)=>{
        this.service.setFailure("AuditAssist",err.message);
      }});
   }  

  
   
  isRed():boolean{return this.apiResponse?.projectExecutionStatus == "RED"}
  isAmber():boolean{return this.apiResponse?.projectExecutionStatus == "AMBER"}
  isGreen():boolean{return this.apiResponse?.projectExecutionStatus == "GREEN"}

}

