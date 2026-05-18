using ToDoListBL.Services;
using ToDoListGUI.Services;
using ToDoListGUI.ViewModels.UserList;

namespace ToDoListGUI.Pages;

public partial class UserListPage : ContentPage
{
	public UserListPage(ToDoService toDoService, NavigationService navigationService)
	{
		InitializeComponent();
		BindingContext = new UserListViewModel(toDoService, navigationService);
	}
}