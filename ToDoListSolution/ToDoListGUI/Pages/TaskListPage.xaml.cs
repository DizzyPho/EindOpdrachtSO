using ToDoListBL.Interfaces;
using ToDoListBL.Services;
using ToDoListGUI.ViewModels.TaskList;

namespace ToDoListGUI.Pages
{
    public partial class TaskListPage : ContentPage
    {
        
        public TaskListPage(ToDoService toDoService)
        {
            InitializeComponent();
            BindingContext = new TaskListViewModel(toDoService);
        }

    }
}
