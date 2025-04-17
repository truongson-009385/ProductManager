import { Routes } from '@angular/router';
import { MainLayoutComponent } from './layouts/main-layout/main-layout.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { ProductListComponent } from './pages/product-list/product-list.component';
import { ProductCreateComponent } from './pages/product-create/product-create.component';
import { UserListComponent } from './pages/user-list/user-list.component';

export const routes: Routes = [
  {
    path: '',
    component: MainLayoutComponent,
    children: [
      {
        path: '',
        component: DashboardComponent,
      }
    ]
  },
  {
    path: 'products',
    component: MainLayoutComponent,
    children: [
      {
        path: '',
        component: ProductListComponent,
      },
      {
        path: 'create',
        component: ProductCreateComponent,
      }
    ]
  },
  {
    path: 'list-users',
    component: MainLayoutComponent,
    children: [
      {
        path: '',
        component: UserListComponent,
      },
    ]
  }
];
