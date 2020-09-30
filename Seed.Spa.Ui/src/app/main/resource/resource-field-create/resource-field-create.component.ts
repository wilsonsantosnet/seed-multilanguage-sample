import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { ResourceService } from '../resource.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GlobalService, NotificationParameters } from '../../../global.service';

@Component({
    selector: 'app-resource-field-create',
    templateUrl: './resource-field-create.component.html',
    styleUrls: ['./resource-field-create.component.css']
})
export class ResourceFieldCreateComponent implements OnInit {

   @Input() vm: ViewModel<any>;

   constructor(private resourceService: ResourceService, private ref: ChangeDetectorRef) { }

   ngOnInit() {}


    ngOnChanges() {
       this.ref.detectChanges()
    }

    onSaveEnd(model: any) {
       
    }

    onBackEnd(model: any) {
       
    }

   


}
