import {ChangeDetectorRef, Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';


import { AlertInfo } from 'src/app/utilities/Models/AlertInfo.model';
import { AlertServiceService } from '../Services/alert-service.service';
import { AlertInfoType } from './alertInfoType.enum';



@Component({
  selector: 'app-alert-info',
  templateUrl: './alert-info.component.html',
  styleUrls: ['./alert-info.component.css']
})
export class AlertInfoComponent implements OnInit {


  public alertInfo?:AlertInfo;
  

  constructor(private alertServiceService:AlertServiceService, private changeDetectorRef: ChangeDetectorRef){
  }

  
  ngOnInit(): void {

      this.alertServiceService.alertInfo$.subscribe(value=>{
        this.alertInfo = value;
      })

  }

  getAlertType(alertInfoType:AlertInfoType):string{
      return AlertInfoType[alertInfoType];
  }

}
