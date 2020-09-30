//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { ResourceService } from '../resource.service';

@Component({
    selector: 'app-resource-container-create',
    templateUrl: './resource-container-create.component.html',
    styleUrls: ['./resource-container-create.component.css'],
})
export class ResourceContainerCreateComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private resourceService: ResourceService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.resourceService.initVM();
    }

    ngOnInit() {

       
    }

}
