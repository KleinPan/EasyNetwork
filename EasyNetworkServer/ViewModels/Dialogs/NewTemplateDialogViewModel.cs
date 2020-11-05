using System;
using System.Reactive;

using HandyControl.Tools.Extension;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using EasyNetworkServer.Data;

namespace EasyNetworkServer.ViewModels.Dialogs
{
    public class NewTemplate : ReactiveObject
    {
        [Reactive] public string Name { get; set; }
        // [Reactive] public DownProtocolType SelectedDownProtocolType { get; set; }
    }

    public class NewTemplateDialogViewModel : ReactiveObject, IDialogResultable<NewTemplate>
    {
        public ReactiveCommand<Unit, Unit> CloseCmd { get; set; }

        public NewTemplateDialogViewModel()
        {
            CloseCmd = ReactiveCommand.Create(CloseEvent);


            this.WhenAnyValue(x => x.Result.Name).Subscribe(x =>
            {
                Console.WriteLine(x);
            });

        }

        private void CloseEvent()
        {
            CloseAction?.Invoke();
        }

        public Action CloseAction { get; set; }

        [Reactive] public NewTemplate Result { get; set; } = new NewTemplate();

        [Reactive] public string Message { get; set; }
    }
}