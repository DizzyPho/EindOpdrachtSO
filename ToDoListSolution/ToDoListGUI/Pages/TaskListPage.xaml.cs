using ToDoListBL.Interfaces;
using ToDoListBL.Services;
using ToDoListGUI.Services;
using ToDoListGUI.ViewModels.TaskList;

namespace ToDoListGUI.Pages
{
    public partial class TaskListPage : ContentPage
    {
        
        public TaskListPage(ToDoService toDoService, NavigationService navigation)
        {
            InitializeComponent();
            BindingContext = new TaskListViewModel(toDoService, navigation);
        }

    }
}
