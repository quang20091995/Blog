import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginModelView } from '../modelview/LoginModelView';
import { LoginService } from './login.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
    username: string;
    password: string;
    formLogin: FormGroup;

    constructor(private fb: FormBuilder, private loginService: LoginService, private route: Router) {

    }
    
    ngOnInit() {
        this.formLogin = this.fb.group({
            username: ['', Validators.compose([Validators.required, Validators.minLength(1)])],
            password: ['', Validators.compose([Validators.required, Validators.minLength(1)])]
        });
    }

    onSubmit() {
        this.username = this.formLogin.get('username').value;
        this.password = this.formLogin.get('password').value;
        console.log(this.username + this.password);

        this.loginService.login(this.username, this.password).subscribe(result => {
            let token = (<any>result).token;
            console.log(token);
            console.log(result.userRole);
            console.log("User Logged In Successfully");
            this.route.navigateByUrl('/home');
        },
        error => {
            console.log("Loi");
        })
    }
}
