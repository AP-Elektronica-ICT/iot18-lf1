import { Component, OnInit, Input, HostBinding } from '@angular/core';
import { Notification } from 'src/models/Notification';
import { NgbPopover } from '@ng-bootstrap/ng-bootstrap';
import { NotificationsService } from 'src/providers/notifications/notifications.service';

@Component({
    selector: 'app-notification',
    templateUrl: './notification.component.html',
    styleUrls: ['./notification.component.scss']
})
export class NotificationComponent implements OnInit {

    @Input() notification: Notification;
    @Input() popover: NgbPopover;

    private loadingRemoval: boolean = false;

    constructor(private notificationService: NotificationsService) { 
    }

    ngOnInit() {

    }

    private remove() {
        this.loadingRemoval = true;
        let notificationElement = document.getElementById('notification' + this.notification.Id);

        if (notificationElement)
            notificationElement.classList.add("disabled-notification");

        this.notificationService.remove(this.notification).subscribe(() => {
            this.popover.open();
            setTimeout(() => {
                this.popover.open();
            });
        });

    }


}