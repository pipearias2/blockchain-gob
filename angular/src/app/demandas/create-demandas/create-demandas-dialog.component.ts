import {
  Component,
  Injector,
  OnInit,
  EventEmitter,
  Output,
} from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
  DemandasServiceProxy,
  DemandasDto,
  RoleDto,
  CreateDemandasDto,
  PermissionDto,
  PermissionDtoListResultDto
} from '@shared/service-proxies/service-proxies';
import { forEach as _forEach, map as _map } from 'lodash-es';

@Component({
  templateUrl: 'create-demandas-dialog.component.html'
})
export class CreateDemandasDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  demandas = new DemandasDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _demandasService: DemandasServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
  }

  save(): void {
    this.saving = true;

    const demanda = new CreateDemandasDto();
    demanda.init(this.demandas);
    
    this._demandasService
      .create(demanda)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      });
  }
}
