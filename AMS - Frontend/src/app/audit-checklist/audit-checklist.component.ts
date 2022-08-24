import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Subscription } from 'rxjs';
import { auditDetails } from 'src/Models/auditDetails';
import { auditResponse } from 'src/Models/auditResponse';
import { questionResponse } from 'src/Models/questionResponse';
import { AuditTypeComponent } from '../audit-type/audit-type.component';
import { AMSService } from '../service/AMS.service';


@Component({
  selector: 'app-audit-checklist',
  templateUrl: './audit-checklist.component.html',
  styleUrls: ['./audit-checklist.component.css']
})
export class AuditChecklistComponent implements OnInit {

  constructor(private jwtHelper : JwtHelperService,private service : AMSService, private router:Router) {
    this.details = {
      Auditid : 0,
      ProjectName : null,
      ProjectManagerName : null,
      ApplicationOwnerName : null,
      AuditType : null,
      CountOfNos : 0,
      AuditDate : new Date(),
      ProjectExecutionStatus : null,
      RemedialActionDuration : null,
      Userid : parseInt(localStorage.getItem("id"))
    }  
  }  
  private qnListSubscription: Subscription;
  private auditTypeSubscription : Subscription;
  //questions array
  auditQuestions:string[]=[];
  //radio response array
  checkresponse:string[]=[];
  //API response
  apiResponse:auditResponse;
  //data to be sent to GetSeverityDetailsAPI
  details:auditDetails;

  ngOnInit(): void { 
    this.qnListSubscription= this.service.getQns().subscribe(qns => this.auditQuestions = qns); 
    this.auditTypeSubscription= this.service.getAuditType().subscribe(type => this.details.AuditType = type);
  }

 getSeverity = (showQuestionsForm: NgForm) => {
    if (showQuestionsForm.valid) {
      this.service.setSuccess('Data Submitted successfully!'+
      'Please visit VIEW STATUS for more details.','AuditAssist');
      for(let i=0;i<this.checkresponse.length;i++){
        if(this.checkresponse[i]=="1")
        this.details.CountOfNos++;
      }  

  this.service.getSeverityDetails(this.details).subscribe({next:
        (data:auditResponse) => {this.apiResponse = data;
        this.service.setSeverity(this.apiResponse);
      },
      error:(err:HttpErrorResponse) => {this.service.setFailure("AuditAssist",err.message)}});
    }  
  }
}
