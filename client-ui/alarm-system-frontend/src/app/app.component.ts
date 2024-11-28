import { Component, HostBinding, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AlarmListComponent } from './components/alarm-list/alarm-list.component';
import { UserComponent } from './user/user.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, AlarmListComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  @HostBinding('class.dark-mode') isDarkMode = false; // Bind class dynamically for dark mode

  title = 'alarm-system-frontend';

  ngOnInit(): void {
    // Load dark mode preference from local storage
    const storedPreference = localStorage.getItem('isDarkMode');
    this.isDarkMode = storedPreference === 'true';
  }

  toggleDarkMode(): void {
    this.isDarkMode = !this.isDarkMode; // Toggle the dark mode flag
    localStorage.setItem('isDarkMode', this.isDarkMode.toString()); // Save preference
  }
}
