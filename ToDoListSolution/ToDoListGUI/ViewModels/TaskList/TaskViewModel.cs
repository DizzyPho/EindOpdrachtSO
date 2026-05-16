using System;
using System.Collections.Generic;
using System.Text;
using ToDoListBL.Domain;

namespace ToDoListGUI.ViewModels.TaskList
{
    public class TaskViewModel : BaseViewModel
    {
        public TaskViewModel(Todo todo)
        {
            Id = todo.Id;
            Title = todo.Title;
            Description = todo.Description;
            IsCompleted = todo.IsCompleted;
        }

        public bool IsCompleted
        {
            get => Get<bool>();
            set => Set(value);
        }
        public int Id { get; init; }
        public string Title { get; set; } 
        public string Description { get; set; }
    }
}
