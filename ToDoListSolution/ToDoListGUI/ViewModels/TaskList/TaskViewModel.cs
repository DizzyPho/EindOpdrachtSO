using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using ToDoListBL.Domain;
using ToDoListBL.Services;

namespace ToDoListGUI.ViewModels.TaskList
{
    public class TaskViewModel : BaseViewModel
    {
        ToDoService _toDoService;
        private bool IsInitPhase { get; init; } = true;
        public TaskViewModel(Todo todo, ToDoService service)
        {
            _toDoService = service;
            Todo = todo;
            Title = todo.Title;
            Description = todo.Description;
            IsCompleted = todo.IsCompleted;
            IsInitPhase = false;
        }

        public bool IsCompleted
        {
            get => Get<bool>();
            set 
            {    
                Set(value);
                UpdateTaskCompleted(value);
            }
        }
        private Todo Todo { get; init; }
        public string Title { get; set; } 
        public string Description { get; set; }

        private void UpdateTaskCompleted(bool value)
        {
            if(!IsInitPhase)
            {
                Todo.IsCompleted = value;
                _toDoService.UpdateTask(Todo);
            }
        }
    }
}
