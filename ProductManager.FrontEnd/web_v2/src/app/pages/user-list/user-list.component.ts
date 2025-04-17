import { Component, OnInit } from '@angular/core';
import { TableModule } from 'primeng/table';
import { TagModule } from 'primeng/tag';
import { RatingModule } from 'primeng/rating';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { User } from '../../models';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-user-list',
  imports: [TableModule, TagModule, RatingModule, ButtonModule, CommonModule],
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.css'
})
export class UserListComponent {
  users!: User[];

  constructor(private userService: UserService) {}

  ngOnInit() {
      this.userService.getUsers().then((data) => {
          this.users = data;
      });
  }

  getStatusTag(user: User) {
      return user.isActive ? 'success' : 'danger';
  }
}
