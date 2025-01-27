import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import 'rxjs/add/operator/map'
import { tap } from 'rxjs/operators';


import {Globals} from '../../../globals'

export interface Credentials {
  // Customize received credentials here
  username: string;
  token: string;
}

export interface LoginContext {
  username: string;
  password: string;
  remember?: boolean;
}

const credentialsKey = 'credentials';

/**
 * Provides a base for authentication workflow.
 * The Credentials interface as well as login/logout methods should be replaced with proper implementation.
 */
@Injectable()
export class AuthenticationService {
  public url: string;
  private _credentials: Credentials | null;

  constructor(
    private http: HttpClient,
    private globals: Globals
  ) {
    const savedCredentials = sessionStorage.getItem(credentialsKey) || localStorage.getItem(credentialsKey);
    if (savedCredentials) {
      this._credentials = JSON.parse(savedCredentials);
    }
    this.url = globals.API;
  }

  /**
   * Authenticates the user.
   * @param {LoginContext} context The login parameters.
   * @return {Observable<Credentials>} The user credentials.
   */
  login(context: LoginContext) {
    

    // Replace by proper authentication call
    var data
    = {
    //   // username: context.username,
    //   // token: '123456',
    //   // message: "ss"
    };

   
    let headers = new HttpHeaders().set('Content-Type','application/x-www-form-urlencoded');
    
    let body = new URLSearchParams();
    body.set('Username', context.username);
    body.set('Password', context.password);
         
    // var x = this.http.post(this.url+'Account/Login', body, {headers: headers});


    // this.setCredentials(data, context.remember);    
  

    // this.http.post<any>('/Account/Login', body.toString(), {headers: headers})        
    // .map(      
    //   response => response
    // )
    // .pipe(
    //   tap(data => {
    //     this.setCredentials(data, context.remember);       
    //   })    
    // );
   
    // let local = JSON.parse(localStorage.getItem('credentials'));
    
    // let ssesion = JSON.parse(sessionStorage.getItem('credentials'));
    

    return this.http.post<any>('/Account/Login', body.toString(), {headers: headers})        
    .map(      
      response => response
    )
    .pipe(
      tap(data => {
        this.setCredentials(data, context.remember);       
      })    
    );

    // .subscribe(
    //     res => {
    //           data = res;
    //           //this.loginResponse = res.json() as LoginResponse[];
    //           //console.log(this.loginResponse);
    //           console.log(res);
    //       },
    //       err => {
    //           data = err;
    //           console.log("Error al intentar logear");
                            
    //       }
    //  );


     //data;
  }

  /**
   * Logs out the user and clear credentials.
   * @return {Observable<boolean>} True if the user was logged out successfully.
   */
  logout(): Observable<boolean> {
    // Customize credentials invalidation here
    this.setCredentials();
    return of(true);
  }

  /**
   * Checks is the user is authenticated.
   * @return {boolean} True if the user is authenticated.
   */
  isAuthenticated(): boolean {
    return !!this.credentials;
  }

  /**
   * Gets the user credentials.
   * @return {Credentials} The user credentials or null if the user is not authenticated.
   */
  get credentials(): Credentials | null {
    return this._credentials;
  }
 
  /**
   * Sets the user credentials.
   * The credentials may be persisted across sessions by setting the `remember` parameter to true.
   * Otherwise, the credentials are only persisted for the current session.
   * @param {Credentials=} credentials The user credentials.
   * @param {boolean=} remember True to remember credentials across sessions.
   */
  private setCredentials(credentials?: Credentials, remember?: boolean) {
    this._credentials = credentials || null;

    if (credentials) {
      const storage = remember ? localStorage : sessionStorage;
      
      if(remember)
      {
        localStorage.setItem('credentials', JSON.stringify(credentials));
      }
      sessionStorage.setItem('credentials', JSON.stringify(credentials));

      //storage.setItem(credentialsKey, JSON.stringify(credentials));
    } else {
      sessionStorage.removeItem(credentialsKey);
      localStorage.removeItem(credentialsKey);
    }
  }

}
