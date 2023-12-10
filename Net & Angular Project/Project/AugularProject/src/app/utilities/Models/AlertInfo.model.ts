import { AlertInfoType } from "../alert-info/alertInfoType.enum";

export interface AlertInfo{
    iSvisible:boolean,
    message:string,
    alertType:AlertInfoType

}