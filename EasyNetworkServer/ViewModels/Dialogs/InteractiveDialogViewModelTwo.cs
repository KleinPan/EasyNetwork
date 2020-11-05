using System;
using System.Reactive;

using HandyControl.Tools.Extension;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace EasyNetworkServer.ViewModels.Dialogs
{

    public class ResultTTwo : ReactiveObject
    {
        [Reactive] public string Result1 { get; set; }
        [Reactive] public string Result2 { get; set; }

    }
    public class InteractiveDialogViewModelTwo : ReactiveObject, IDialogResultable<ResultTTwo>
    {
        public ReactiveCommand<Unit, Unit> CloseCmd { get; set; }

        public InteractiveDialogViewModelTwo()
        {
            CloseCmd = ReactiveCommand.Create(CloseEvent);
        }

        private void CloseEvent()
        {
            CloseAction?.Invoke();
        }

        public Action CloseAction { get; set; }

        [Reactive] public ResultTTwo Result { get; set; } = new ResultTTwo();

        [Reactive] public string Message1 { get; set; }
        [Reactive] public string Message2 { get; set; }
    }
}