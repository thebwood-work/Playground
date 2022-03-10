using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace AddressApp.BaseClasses
{
    public class CommonComponent : ComponentBase
    {
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
    }
}
