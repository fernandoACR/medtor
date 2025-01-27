import { Component, OnInit } from '@angular/core';
import { Router,ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { finalize } from 'rxjs/operators';

import { environment } from '@env/environment';
import { Logger, I18nService, AuthenticationService } from '@app/core';


const log = new Logger('Login');

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  version: string = environment.version;
  error: string;
  loginForm: FormGroup;
  isLoading = false;
  model: any = {};
  loading = false;
  returnUrl: string;
  authenticationFlag: boolean = true;

  constructor(private router: Router,
              private route: ActivatedRoute,
              private formBuilder: FormBuilder,
              private i18nService: I18nService,
              private authenticationService: AuthenticationService) {
    this.createForm();
  }

  ngOnInit() { 
      // reset login status
      this.authenticationService.logout(); 
      // get return url from route parameters or default to '/'
      this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
      let currentUser = JSON.parse(localStorage.getItem('credentials'));
      
  }

  login() {
    this.isLoading = true;
    this.authenticationService.login(this.loginForm.value)
    .pipe(finalize(() => {
        this.loginForm.markAsPristine();
        this.isLoading = false;
      }))
    .subscribe(      
      (jsonData) => {         
        console.log(jsonData);
        this.router.navigate([this.returnUrl]);
      },
      // The 2nd callback handles errors.
      (err) =>
      {
        this.authenticationFlag = false;
        console.log(err);
      },
      // The 3rd callback handles the "complete" event.
      () => console.log("observable complete")
    );



    
      // .pipe(finalize(() => {
      //   this.loginForm.markAsPristine();
      //   this.isLoading = false;
      // }))
      // .subscribe(credentials => {
      //   log.debug(`${credentials.username} successfully logged in`);
      //   this.router.navigate(['/'], { replaceUrl: true });
      // }, error => {
      //   log.debug(`Login error: ${error}`);
      //   this.error = error;
      // });
  }

  setLanguage(language: string) {
    this.i18nService.language = language;
  }

  get currentLanguage(): string {
    return this.i18nService.language;
  }

  get languages(): string[] {
    return this.i18nService.supportedLanguages;
  }

  private createForm() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
      remember: true
    });
  }

}
