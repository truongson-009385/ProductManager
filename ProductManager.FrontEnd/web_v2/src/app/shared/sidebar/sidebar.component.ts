import { Component } from '@angular/core';
import { MenuItem, MessageService } from 'primeng/api';
import { PanelMenu } from 'primeng/panelmenu';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css',
  standalone: true,
  imports: [
    PanelMenu,
    RouterLink
  ],
  providers: [MessageService]
})
export class SidebarComponent {
  items!: MenuItem[];

  constructor(private router: Router) { }

  ngOnInit() {
    this.items = [
      {
        label: 'Dashboard',
        icon: 'pi pi-objects-column',
        command: () => {
          this.router.navigate(['/']);
        }
      },
      {
        label: 'Account',
        icon: 'pi pi-user',
        items: [
          {
            label: 'List users',
            icon: 'pi pi-users',
            route: '/list-users'
          },
          {
            label: 'Create new user',
            icon: 'pi pi-user-plus',
            route: ''
          },
          {
            label: 'Profile',
            icon: 'pi pi-user-edit',
            route: ''
          },
          {
            label: 'Change password',
            icon: 'pi pi-pencil',
            route: ''
          },
          {
            label: 'Settings',
            icon: 'pi pi-cog',
            route: ''
          }
        ]
      },
      {
        label: 'Product',
        icon: 'pi pi-inbox',
        items: [
          {
            label: 'List products',
            icon: 'pi pi-list',
            route: '/products'
          },
          {
            label: 'Create new product',
            icon: 'pi pi-file-plus',
            route: '/products/create'
          }
        ]
      },

    ];
  }
}
