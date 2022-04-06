using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;

namespace AddressApp.BaseClasses
{
    public class CommonComponent : ComponentBase
    {
        [Inject]
        public ISnackbar Snackbar { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        private IJSRuntime _jScript { get; set; }

        public async void ConsoleInfo<T>(T item)
        {
            await _jScript.InvokeVoidAsync("console.info", item);
        }
        public async void Alert(string message)
        {
            await _jScript.InvokeVoidAsync("alert", message);
        }

        public void ShowSnackbarError(List<string> errors)
        {
            Snackbar.Configuration.MaxDisplayedSnackbars = errors.Count;
            foreach(var error in errors)
            {
                Snackbar.Add($"Error {error}", Severity.Error);
            }
        }
        public void ShowSnackbarSuccess(string message)
        {
            Snackbar.Configuration.MaxDisplayedSnackbars = 1;
            Snackbar.Add($"{message}", Severity.Success);
        }
    }
}
