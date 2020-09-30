//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { ResourceService } from '../resource.service';

@Component({
    selector: 'app-resource-container-edit',
    templateUrl: './resource-container-edit.component.html',
    styleUrls: ['./resource-container-edit.component.css'],
})
export class ResourceContainerEditComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private resourceService: ResourceService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.resourceService.initVM();
    }

    ngOnInit() {

       
    }

}
