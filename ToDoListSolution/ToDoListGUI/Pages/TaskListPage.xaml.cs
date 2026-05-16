using ToDoListBL.Interfaces;
using ToDoListBL.Services;

namespace ToDoListGUI.Pages
{
    public partial class TaskListPage : ContentPage
    {
        
        public TaskListPage(ToDoService toDoService)
        {
            InitializeComponent();
        }

    }
}
