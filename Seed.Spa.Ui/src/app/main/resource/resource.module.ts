import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';

import { ModalModule } from 'ngx-bootstrap/modal';

import { ResourceComponent } from './resource.component';

import { ResourceFieldCreateComponent } from './resource-field-create/resource-field-create.component';
import { ResourceFieldEditComponent } from './resource-field-edit/resource-field-edit.component';

import { ResourceContainerCreateComponent } from './resource-container-create/resource-container-create.component';
import { ResourceContainerEditComponent } from './resource-container-edit/resource-container-edit.component';

import { ResourceRoutingModule } from './resource.routing.module';

import { ResourceService } from './resource.service';
import { ResourceServiceFields } from './resource.service.fields';

import { ApiService } from '../../common/services/api.service';
import { CommonSharedModule } from '../../common/common-shared.module';


@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ModalModule.forRoot(),
        CommonSharedModule,
        ResourceRoutingModule,

    ],
    declarations: [
        ResourceComponent,
        ResourceFieldCreateComponent,
        ResourceFieldEditComponent,
        ResourceContainerCreateComponent,
        ResourceContainerEditComponent
    ],
    providers: [ResourceService,ResourceServiceFields, ApiService],
	exports: [ResourceComponent]
})
export class ResourceModule {


}
