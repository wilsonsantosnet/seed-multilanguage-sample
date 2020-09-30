import { Injectable } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

import { ServiceBase } from '../../common/services/service.base';

@Injectable()
export class ResourceServiceFields extends ServiceBase {


	constructor() {
		super()
	}

	getKey() {
		return "Resource";
	}

	getFormControls(moreFormControls? : any) {
		var formControls = Object.assign({
      group : new FormControl(),
      culture : new FormControl(),
      key : new FormControl(),
      value : new FormControl(),
      resourceId : new FormControl(),
		},moreFormControls || {});
		return formControls;
	}

	getFormFields(moreFormControls?: any) {
		return new FormGroup(this.getFormControls(moreFormControls));
	}

	getInfosFields(moreInfosFields? : any, useMoreInfosFields = false) {
		var defaultInfosFields = {
      group: { label: 'group', type: 'string', isKey: false, list:true  ,  },
      culture: { label: 'culture', type: 'string', isKey: false, list:true  ,  },
      key: { label: 'key', type: 'string', isKey: false, list:true  ,  },
      value: { label: 'value', type: 'string', isKey: false, list:true  ,  },
      resourceId: { label: 'resourceId', type: 'int', isKey: true, list:false  ,  },
		};
		return this.mergeInfoFields(defaultInfosFields, moreInfosFields, useMoreInfosFields);
	}

}
