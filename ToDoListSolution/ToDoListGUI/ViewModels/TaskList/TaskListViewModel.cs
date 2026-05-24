using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using ToDoListBL.Domain;
using ToDoListBL.Messages;
using ToDoListBL.Services;
using ToDoListGUI.Commands;
using ToDoListGUI.Pages;
using ToDoListGUI.Services;
using ToDoListGUI.Strategies.TaskFiltering;
using ToDoListGUI.Strategies.TaskSorting;

namespace ToDoListGUI.ViewModels.TaskList
{
    public class TaskListViewModel : BaseViewModel
    {
        NavigationService _navigation;
        ToDoService _toDoService;
        IFilterStrategy _currentFilter;
        IComparer<TaskViewModel> _currentSorter;
        public TaskListViewModel(ToDoService toDoService, NavigationService navigationService, MessageService messageService)
        {
            _allTasks = toDoService.GetTasks()
                                .Select(todo => new TaskViewModel(todo, toDoService))
                                .ToList();
            VisibleTasks = new ObservableCollection<TaskViewModel>(_allTasks);
            _navigation = navigationService;
            _toDoService = toDoService;

            _currentFilter = new NoFilterStrategy();
            _currentSorter = new NoSortingStrategy();

            NewTaskCommand = new AsyncCommand(OnNewTask);
            ShowUsersCommand = new AsyncCommand(OnShowUsers);

            NoFilterCommand = new Command(() => SortAndFilter(new NoFilterStrategy(), new NoSortingStrategy()));
            ShowUnfinishedCommand = new Command(() => SortAndFilter(new UnfinishedFilterStrategy(), new NoSortingStrategy()));
            SortMostRecentCommand = new Command(() => SortAndFilter(new NoFilterStrategy(), new RecencySortStrategy()));

            messageService.Register<NewTaskMessage>(this, (o, message) => OnTaskAdded(message.NewTask));
            messageService.Register<TaskUpdatedMessage>(this, (o, message) => OnTaskUpdated(message.UpdatedTask));

        }
        private List<TaskViewModel> _allTasks;
        public ObservableCollection<TaskViewModel> VisibleTasks
        {
            get => Get<ObservableCollection<TaskViewModel>>();
            set => Set(value);
        }
        public TaskViewModel SelectedTask
        {
            get => Get<TaskViewModel>();
            set
            {
                Set(value);
                if (SelectedTask != null)
                {
                    OnTaskClicked(value).ConfigureAwait(false);
                    SelectedTask = null;
                }
            }
        }
        public ICommand NewTaskCommand { get; init; }
        public ICommand ShowUsersCommand { get; init; }
        public ICommand NoFilterCommand { get; init; }
        public ICommand ShowUnfinishedCommand { get; init; }
        public ICommand SortMostRecentCommand { get; init; }

        public async Task OnNewTask()
        {
            await _navigation.GoToAsync<TaskDetailPage>();
        }
        public async Task OnShowUsers()
        {
            await _navigation.GoToAsync<UserListPage>();
        }
        public async Task OnTaskClicked(TaskViewModel task)
        {
            await _navigation.EditTaskPage(task.Id);
        }

        public void OnTaskUpdated(Todo task)
        {
            TaskViewModel taskVM = _allTasks.First<TaskViewModel>(vm => task.Id == vm.Id);

            if(taskVM != null)
            {
                taskVM.Title = task.Title;
                taskVM.Description = task.Description;
                taskVM.IsCompleted = task.IsCompleted;
                taskVM.LastModifiedDate = task.LastModifiedDate;
            }
        }

        public void OnTaskAdded(Todo task)
        {
            TaskViewModel addedTask = new TaskViewModel(task, _toDoService);
            _allTasks.Add(addedTask);
            if (_currentFilter.PassesFilter(addedTask))
            {
                VisibleTasks.Add(addedTask);
                if(_currentSorter != null)
                {
                    var currentList = VisibleTasks.ToList();
                    currentList.Sort(_currentSorter);
                    VisibleTasks = new ObservableCollection<TaskViewModel>(currentList);
                }
            }
        }

        public void SortAndFilter(IFilterStrategy filterStrategy, IComparer<TaskViewModel> sortingStrategy)
        {
            List<TaskViewModel> filteredList = filterStrategy.Filter(_allTasks);

            filteredList.Sort(sortingStrategy);
            VisibleTasks = new ObservableCollection<TaskViewModel>(filteredList);
            _currentFilter = filterStrategy;
            _currentSorter = sortingStrategy;
        }
    }
}
