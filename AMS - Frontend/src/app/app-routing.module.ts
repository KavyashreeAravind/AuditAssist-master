import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/guards/auth.guard';
import { AuditChecklistComponent } from './audit-checklist/audit-checklist.component';
import { AuditSeverityComponent } from './audit-severity/audit-severity.component';
import { AuditTypeComponent } from './audit-type/audit-type.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RagDetailsComponent } from './rag-details/rag-details.component';

const routes: Routes = [
  {path:"",component:HomeComponent,canActivate:[AuthGuard] },
  {path:"login",component:LoginComponent},
  {path:"auditType",component:AuditTypeComponent, canActivate:[AuthGuard]},
  {path:"auditChecklist",component:AuditChecklistComponent, canActivate:[AuthGuard]},
  {path:"auditSeverity",component:AuditSeverityComponent, canActivate:[AuthGuard]},
  {path:"rag",component:RagDetailsComponent, canActivate:[AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
