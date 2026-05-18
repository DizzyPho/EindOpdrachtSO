using ToDoListBL.Services;
using ToDoListGUI.Services;
using ToDoListGUI.ViewModels;
using ToDoListGUI.ViewModels.UserDetail;

namespace ToDoListGUI.Pages;

public partial class UserDetailPage : ContentPage
{

	public UserDetailPage(ToDoService toDoService, NavigationService navigationService, UserDetailViewModel vm)
	{
        InitializeComponent();
        BindingContext = vm;
    }


}