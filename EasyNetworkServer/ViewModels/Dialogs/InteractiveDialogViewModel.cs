using System;
using System.Reactive;

using HandyControl.Tools.Extension;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace EasyNetworkServer.ViewModels.Dialogs
{
    public class InteractiveDialogViewModel : ReactiveObject, IDialogResultable<string>
    {
        public ReactiveCommand<Unit, Unit> CloseCmd { get; set; }

        public InteractiveDialogViewModel()
        {
            CloseCmd = ReactiveCommand.Create(CloseEvent);
        }

        private void CloseEvent()
        {
            CloseAction?.Invoke();
        }

        public Action CloseAction { get; set; }

        [Reactive] public string Result { get; set; }

        [Reactive] public string Message { get; set; }
    }
}