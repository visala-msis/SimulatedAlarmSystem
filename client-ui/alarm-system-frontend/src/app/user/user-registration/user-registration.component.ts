import { Component } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { CommonModule } from '@angular/common';
import { UserService } from '../../services/user.service';
import { UserDetails } from '../../common/UserDetails';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { FormsModule } from '@angular/forms';
@Component({
  
  standalone: true,
  imports: [CommonModule, MatTableModule, MatCheckboxModule, FormsModule],
  templateUrl: './user-registration.component.html',
  styleUrl: './user-registration.component.scss'
})
export class UserRegistrationComponent {
  // displayedColumns: string[] = ['timestamp', 'type', 'status', 'description'];
  dataSource: any[] = [];

  
  

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.userService.getUsers().subscribe(data => {
      console.log(data);
      this.dataSource = data;
    });
  }

 
  

}

