import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { ResourceService } from '../resource.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
    selector: 'app-resource-field-edit',
    templateUrl: './resource-field-edit.component.html',
    styleUrls: ['./resource-field-edit.component.css']
})
export class ResourceFieldEditComponent implements OnInit {

    @Input() vm: ViewModel<any>


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
