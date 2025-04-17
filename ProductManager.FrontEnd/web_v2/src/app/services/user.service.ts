import { Injectable } from '@angular/core';
import { User } from '../models';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  getUsers(): Promise<User[]> {
    return Promise.resolve([
      {
      id: 1,
      username: 'nguyenvana',
      email: 'nguyenvana@example.com',
      firstName: 'Nguyen Van',
      lastName: 'A',
      isActive: false,
      createdAt: new Date(),
      updatedAt: new Date()
      },
      {
      id: 2,
      username: 'tranthib',
      email: 'tranthib@example.com',
      firstName: 'Tran Thi',
      lastName: 'B',
      isActive: true,
      createdAt: new Date(),
      updatedAt: new Date()
      },
      {
      id: 3,
      username: 'phamvanh',
      email: 'phamvanh@example.com',
      firstName: 'Pham Van',
      lastName: 'H',
      isActive: true,
      createdAt: new Date(),
      updatedAt: new Date()
      },
      {
      id: 4,
      username: 'lethic',
      email: 'lethic@example.com',
      firstName: 'Le Thi',
      lastName: 'C',
      isActive: true,
      createdAt: new Date(),
      updatedAt: new Date()
      },
      {
      id: 5,
      username: 'nguyenminhd',
      email: 'nguyenminhd@example.com',
      firstName: 'Nguyen Minh',
      lastName: 'D',
      isActive: false,
      createdAt: new Date(),
      updatedAt: new Date()
      },
      {
      id: 6,
      username: 'hoangthie',
      email: 'hoangthie@example.com',
      firstName: 'Hoang Thi',
      lastName: 'E',
      isActive: false,
      createdAt: new Date(),
      updatedAt: new Date()
      },
      {
      id: 7,
      username: 'dangvanf',
      email: 'dangvanf@example.com',
      firstName: 'Dang Van',
      lastName: 'F',
      isActive: true,
      createdAt: new Date(),
      updatedAt: new Date()
      },
      {
      id: 8,
      username: 'phamthig',
      email: 'phamthig@example.com',
      firstName: 'Pham Thi',
      lastName: 'G',
      isActive: true,
      createdAt: new Date(),
      updatedAt: new Date()
      },
      {
      id: 9,
      username: 'tranvanh',
      email: 'tranvanh@example.com',
      firstName: 'Tran Van',
      lastName: 'H',
      isActive: true,
      createdAt: new Date(),
      updatedAt: new Date()
      },
      {
      id: 10,
      username: 'lethii',
      email: 'lethii@example.com',
      firstName: 'Le Thi',
      lastName: 'I',
      isActive: false,
      createdAt: new Date(),
      updatedAt: new Date()
      }
    ]);
  }
}
