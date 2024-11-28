import { Component } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { CommonModule } from '@angular/common';
import { UserService } from '../../app/services/user.service';
import { User } from '../../app/common/UserDetails';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-user',
  standalone: true,
  imports: [CommonModule, MatTableModule, MatCheckboxModule, FormsModule],
  templateUrl: './user.component.html',
  styleUrl: './user.component.scss'
})
export class UserComponent {
  // displayedColumns: string[] = ['timestamp', 'type', 'status', 'description'];
user!: User;
  
  dataSource: any[] = [];

  constructor(private userService: UserService) { }
  onSubmit() {

    this.userService.Login(this.user).subscribe(data => {
      if(data !== null && data == true)
      {
        console.log(data);
        this.dataSource = data;
        alert(`Logged in as ${this.user.UserName}`);
      }
      else
      alert(`invalid credentials`);


    });

  }
}