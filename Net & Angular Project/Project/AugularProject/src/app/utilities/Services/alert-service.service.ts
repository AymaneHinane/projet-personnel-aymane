import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { AlertInfoType } from '../alert-info/alertInfoType.enum';
import { AlertInfo } from '../Models/AlertInfo.model';




@Injectable({
  providedIn: 'root'
})

export class AlertServiceService {



  private alertInfoSubject = new BehaviorSubject<AlertInfo>({iSvisible:false,message:'',alertType:AlertInfoType.primary});
  public alertInfo$ = this.alertInfoSubject.asObservable();

  constructor() { }

  showAlertInfo(value:AlertInfo){

    this.alertInfoSubject.next(value);

   
    setTimeout(() => {
      this.alertInfoSubject.next({...this.alertInfoSubject.value,iSvisible:false});
    }, 6000); 
  }
   
}
