import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { questionResponse } from 'src/Models/questionResponse';
import { AMSService } from '../service/AMS.service';

@Component({
  selector: 'app-audit-type',
  templateUrl: './audit-type.component.html',
  styleUrls: ['./audit-type.component.css']
})
export class AuditTypeComponent implements OnInit {

  constructor(private jwtHelper:JwtHelperService,private router : Router,private service:AMSService) { }

  ngOnInit(): void {
  }

  auditType:string;
  auditQuestions:string[]=[];

  questions = (auditTypeForm: NgForm) => {
    if (auditTypeForm.valid) {
      this.service.getQuestions(this.auditType).subscribe({next:
        (data) => {this.auditQuestions=data;
        this.service.setQns(this.auditQuestions);
        this.service.setAuditType(this.auditType);
      },
      error:(err:HttpErrorResponse)=>{
        this.service.setFailure("AuditAssist",err.message);
      }});
      this.router.navigate(["auditChecklist"]);
    }
  }
}
