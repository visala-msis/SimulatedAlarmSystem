import { Component } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { CommonModule } from '@angular/common';
import { AlarmService } from '../../services/alarm.service';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-alarm-list',
  standalone: true,
  imports: [CommonModule, MatTableModule, MatCheckboxModule, FormsModule],
  templateUrl: './alarm-list.component.html',
  styleUrl: './alarm-list.component.scss'
})
export class AlarmListComponent {
  // displayedColumns: string[] = ['timestamp', 'type', 'status', 'description'];
  dataSource: any[] = [];

  allColumns = [
    { label: 'Timestamp', field: 'timestamp', visible: true },
    { label: 'Type', field: 'type', visible: true },
    { label: 'Status', field: 'status', visible: true },
    { label: 'Description', field: 'description', visible: true },
  ];

  constructor(private alarmService: AlarmService) { }

  ngOnInit(): void {
    this.alarmService.getAlarms().subscribe(data => {
      console.log(data);
      this.dataSource = data;
    });
  }

  get displayedColumns(): string[] {
    return this.allColumns.filter(col => col.visible).map(col => col.field);
  }

}
