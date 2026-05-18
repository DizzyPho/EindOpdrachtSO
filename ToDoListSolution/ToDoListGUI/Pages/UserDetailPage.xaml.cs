using ToDoListGUI.ViewModels;
using ToDoListGUI.ViewModels.UserDetail;

namespace ToDoListGUI.Pages;

public partial class UserDetailPage : ContentPage, IQueryAttributable
{
	public UserDetailPage()
	{
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if(query.TryGetValue("id", out object oId) && oId is string id)
        {
            BindingContext = new UserDetailViewModel(id);
        }
        else
        {
            BindingContext = new UserDetailViewModel();
        }
    }
}