using ToDoListBL.Services;
using ToDoListGUI.Services;
using ToDoListGUI.ViewModels.UserList;

namespace ToDoListGUI.Pages;

public partial class UserListPage : ContentPage
{
	public UserListPage(ToDoService toDoService, NavigationService navigationService, MessageService messageService)
	{
		InitializeComponent();
		BindingContext = new UserListViewModel(toDoService, navigationService, messageService);
	}
}