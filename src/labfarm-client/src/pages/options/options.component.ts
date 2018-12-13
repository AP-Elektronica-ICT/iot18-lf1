import { Component, OnInit } from '@angular/core';
import { PushNotificationsService } from 'src/providers/push-notifications/push-notifications.service';
import { CookieService } from 'ngx-cookie-service';
import { AuthenticationService } from 'src/providers/authentication/authentication.service';

@Component({
    selector: 'app-options',
    templateUrl: './options.component.html',
    styleUrls: ['./options.component.scss']
})
export class OptionsComponent implements OnInit {

    private notificationTitle: string = "Browser Push Notifications!";

    private preferences_lf123: boolean = false;
    private preferences_lf124: boolean = false;

    private cookieValue = "UNKNOWN";

    constructor(private notificationService: PushNotificationsService, private cookieService: CookieService, private authService: AuthenticationService) {
        this.cookieService.set('Test', 'HELLO WORLD!');
    }

    ngOnInit() {
        this.cookieValue = this.cookieService.get('Test');
    }

    notify() {
        let data: Array<any> = [];
        data.push({
            'title': 'Lab farm warning!',
            'alertContent': 'Be wary, the light intensity level of Labfarm 123 is low!'
        });

        this.notificationService.generateNotification(data);
    }

    toggleNotifications(event) {
        this.notificationService.requestPermission();
    }

    savePreferences() {
        this.notify();
    }

}