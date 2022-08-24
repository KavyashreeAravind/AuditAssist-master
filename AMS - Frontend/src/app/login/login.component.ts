import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { loginCredentials } from 'src/Models/loginCredentials';
import { Observable } from 'rxjs';
import { loginResponse } from '../../Models/loginResponse';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { AMSService } from '../service/AMS.service';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  cred : loginCredentials = {
    Email:'',
    Password:''
  }
  
  response : loginResponse = new loginResponse();
  invalidLogin : boolean = false;

  // @ViewChild('loginForm') loginForm: NgForm;

  constructor(private jwtHelper: JwtHelperService,private service : AMSService, private router : Router) { }

  ngOnInit(): void {}

  isUserAuthenticated = (): boolean => {
    const token = localStorage.getItem("jwt");
     if (token && !this.jwtHelper.isTokenExpired(token)){
      return true;
     }
    return false;
  }

  logOut = () => {
    localStorage.removeItem("jwt");
    localStorage.removeItem("id");
    this.router.navigate(["/"]);

  }
  
  login = ( form: NgForm) => {
    if (form.valid) {
      this.service.authToken(this.cred).subscribe({
        next: (response: loginResponse) => {
          const jwt = response.accessToken;
          localStorage.setItem("jwt", jwt); 
          const id = response.userId;
          localStorage.setItem("id",id.toString());
          localStorage.setItem("email",response.email);
          this.invalidLogin = false; 
          this.router.navigate(["/"]);
        },
        error: (err: HttpErrorResponse) => {
          this.service.setFailure("AuditAssist",err.message);
          this.invalidLogin = true;
          localStorage.removeItem("jwt");
          localStorage.removeItem("id");
        }
      })
    }
  }
}

