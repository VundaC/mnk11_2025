using CommunityToolkit.Mvvm.Input;
using Playground.Models;

namespace Playground.PageModels;

public interface IProjectTaskPageModel
{
	IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
	bool IsBusy { get; }
}