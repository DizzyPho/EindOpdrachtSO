using ToDoListBL.Services;
using ToDoListGUI.Services;
using ToDoListGUI.ViewModels.TaskDetail;

namespace ToDoListGUI.Pages;

public partial class TaskDetailPage : ContentPage
{
	public TaskDetailPage(ToDoService toDoService, NavigationService navigationService, MessageService messageService)
    {
		InitializeComponent();
		BindingContext = new TaskDetailViewModel(toDoService, navigationService, messageService);
	}
}