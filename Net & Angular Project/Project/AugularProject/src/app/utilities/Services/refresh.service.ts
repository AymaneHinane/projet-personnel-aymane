import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RefreshService {

  private refreshSubject = new Subject<void>();

  refreshChildComponents() {
    this.refreshSubject.next();
  }

  getRefreshObservable() {
    return this.refreshSubject.asObservable();
  }
  
}
