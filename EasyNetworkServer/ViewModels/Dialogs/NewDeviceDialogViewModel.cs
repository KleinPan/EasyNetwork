using System;
using System.Collections.ObjectModel;
using System.Reactive;

using DynamicData;

using HandyControl.Tools.Extension;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using EasyNetworkServer.Tools.Helper;

namespace EasyNetworkServer.ViewModels.Dialogs
{
    public class NewDevice : ReactiveObject
    {
        [Reactive] public string DeviceName { get; set; }
        [Reactive] public string SelectedTemplate { get; set; }
    }

    public class NewDeviceDialogViewModel : ReactiveObject, IDialogResultable<NewDevice>
    {
        public ObservableCollection<string> TemplateList { get; set; } = new ObservableCollection<string>();
        public ReactiveCommand<Unit, Unit> CloseCmd { get; set; }

        public NewDeviceDialogViewModel()
        {
            CloseCmd = ReactiveCommand.Create(CloseEvent);
            TemplateList.AddRange(IOHelper.Instance.ReadFileListFromLocal());
        }

        private void CloseEvent()
        {
            CloseAction?.Invoke();
        }

        public Action CloseAction { get; set; }

        [Reactive] public NewDevice Result { get; set; } = new NewDevice();

        [Reactive] public string Message { get; set; }
    }
}