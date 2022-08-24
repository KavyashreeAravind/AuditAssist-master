import { loginResponse } from "./loginResponse";

export interface auditResponse{
    auditid? : number;
    projectName : string;
    projectManagerName : string;
    applicationOwnerName : string;
    auditType : string;
    auditDate : Date;
    projectExecutionStatus? : string;
    remedialActionDuration : string;
    userid? : number;
    userdetail? : loginResponse;
}