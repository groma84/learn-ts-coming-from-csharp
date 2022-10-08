import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public readonly todos: string[] = [];
  public readonly todo = new FormControl('');

  public save(): void {
    if (this.todo.value) {
      this.todos.push(this.todo.value);
      this.todo.setValue('');
    }
  }
}
