import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Subscription } from 'rxjs';
import { auditResponse } from 'src/Models/auditResponse';
import { tokenGetter } from '../app.module';
import { AMSService } from '../service/AMS.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  private statusSubscription : Subscription;


  constructor(private jwtHelper: JwtHelperService,private router : Router, private service : AMSService) { }
  
  apiResponse:auditResponse[]=[];
  gcount:number=0;
  acount:number=0;
  rcount:number=0;
  username:string='';

  ngOnInit(): void {
        this.username = localStorage.getItem("email").split('@')[0];
        this.service.homeDetails(+localStorage.getItem("id")).subscribe({next:
          (data)=>{
          this.apiResponse=data["result"];
          this.gcount = this.apiResponse.filter(a=>a.projectExecutionStatus=="GREEN").length;
          this.rcount=this.apiResponse.filter(a=>a.projectExecutionStatus=="RED").length;
          this.acount=this.apiResponse.filter(a=>a.projectExecutionStatus=="AMBER").length;
          },
          error:(err:HttpErrorResponse)=>{
            this.service.setFailure("AuditAssist",err.message);
          }});
  }

  getDetails(value:string){
    this.service.setStatus(value);
    this.router.navigate(["rag"]);
  }


  // isUserAuthenticated = (): boolean => {
  //   const token = localStorage.getItem("jwt");
  //    if (token && !this.jwtHelper.isTokenExpired(token)){
  //     return true;
  //    }
  //   return false;
  // }

  // logOut = () => {
  //   localStorage.removeItem("jwt");
  //   this.router.navigate(["/"]);
  // }

}
