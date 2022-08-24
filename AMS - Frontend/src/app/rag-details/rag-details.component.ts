import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Subscription } from 'rxjs';
import { auditResponse } from 'src/Models/auditResponse';
import { AMSService } from '../service/AMS.service';

@Component({
  selector: 'app-rag-details',
  templateUrl: './rag-details.component.html',
  styleUrls: ['./rag-details.component.css']
})
export class RagDetailsComponent implements OnInit {

  constructor(private service:AMSService) {  }

  private statusSubscription : Subscription;
  apiResponse:auditResponse[]=[];
  status:string;
  dataSource: MatTableDataSource<auditResponse>;
  @ViewChild(MatPaginator, {static: true}) public paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;
  displayedColumns: string[] = ['#','projectName', 'applicationOwnerName', 'auditDate', 'auditType', 'remedialActionDuration'];

ngOnInit(): void {

    this.statusSubscription = this.service.getStatus().subscribe(data=>this.status = data);
      
        this.service.homeDetails(+localStorage.getItem("id")).subscribe({
        next: (d : any) => {
        this.apiResponse=d["result"];
        this.apiResponse=this.apiResponse.filter(a=>a.projectExecutionStatus===this.status);
        this.dataSource = new MatTableDataSource(this.apiResponse);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
        },
        error:(err:HttpErrorResponse)=>{this.service.setFailure("AuditAssist",err.message)}});   
        
        
  }

  isRed():boolean{return this.status == "RED"}
  isAmber():boolean{return this.status == "AMBER"}
  isGreen():boolean{return this.status == "GREEN"}

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) 
      this.dataSource.paginator.firstPage();    
  }
}
