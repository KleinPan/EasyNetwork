using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using HandyControl.Tools.Extension;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using EasyNetworkServer.ViewModels.Basics;

namespace EasyNetworkServer.ViewModels.Dialogs
{


    public class ResultDialogViewModel : ViewModelBase, IDialogResultable<DialogResult>
    {
        public ReactiveCommand<Unit, Unit> CloseCmd { get; set; }
        public ReactiveCommand<Unit, Unit> YesCommand { get; set; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; set; }

        public ResultDialogViewModel()
        {
            CloseCmd = ReactiveCommand.Create(CloseEvent);
            YesCommand = ReactiveCommand.Create(YesEvent);
            CancelCommand = ReactiveCommand.Create(CancelEvent);
        }

        private void CancelEvent()
        {
            Result = DialogResult.Cancel;
            CloseEvent();
        }

        private void YesEvent()
        {
            Result = DialogResult.Yes;
            CloseEvent();

        }

        private void CloseEvent()
        {
            CloseAction?.Invoke();
        }

        public Action CloseAction { get; set; }

        [Reactive] public string Header { get; set; }
        [Reactive] public DialogResult Result { get; set; }

        //[Reactive] public string Message { get; set; }
    }
}
