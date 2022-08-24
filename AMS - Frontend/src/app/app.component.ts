import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent{
  
  title = 'AuditManagementSystem';
  // private jwtHelper: JwtHelperService;
  // private router : Router;

  // isUserAuthenticated = (): boolean => {
  //   const token = localStorage.getItem("jwt");
  //    if (token && !this.jwtHelper.isTokenExpired(token)){
  //     return true;
  //    }
  //   return false;
  // }

  // logOut = () => {
  //   localStorage.removeItem("jwt");
  //   localStorage.removeItem("refreshToken");
  //   localStorage.removeItem("id");
  //   this.router.navigate(["/"]);

  }
