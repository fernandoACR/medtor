import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent,HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { AuthenticationService } from './authentication.service';
import { Observable } from "rxjs/Observable";
import { Credentials } from './authentication.service';
import 'rxjs/add/observable/fromPromise';

@Injectable()
export class ApiInterceptor implements HttpInterceptor {
  constructor(private authService: AuthenticationService) {}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
      const url = 'http://localhost:37393';
      req = req.clone({
        url: url + req.url
      });
      //return next.handle(req);
      return Observable.fromPromise(this.handleAccess(req, next));
    }

    private async handleAccess(request: HttpRequest<any>, next: HttpHandler):Promise<HttpEvent<any>> {
    
    
      //const token = JSON.parse(localStorage.getItem('credentials')).access_token;

      const token = localStorage.getItem('credentials') ? JSON.parse(localStorage.getItem('credentials')).access_token : null;
    
      let changedRequest = request;
      // HttpHeader object immutable - copy values
      const headerSettings: {[name: string]: string | string[]; } = {};

      for (const key of request.headers.keys()) {
          headerSettings[key] = request.headers.getAll(key);
      }
      if (token) {
          headerSettings['Authorization'] = 'Bearer ' + token;
      }
      //headerSettings['Content-Type'] = 'application/json';
      const newHeader = new HttpHeaders(headerSettings);

      changedRequest = request.clone({ headers: newHeader});
      return next.handle(changedRequest).toPromise();
   
      
      
       
    }
    
  }
