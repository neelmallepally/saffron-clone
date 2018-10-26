import { sandboxOf } from 'angular-playground';
import { ManageCookbookComponent } from './manage-cookbook.component';

export default sandboxOf(ManageCookbookComponent)
  .add('default', {
    template: `<app-manage-cookbook></app-manage-cookbook>`
  });
