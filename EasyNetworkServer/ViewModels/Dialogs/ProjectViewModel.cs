using System;
using System.Collections.ObjectModel;
using System.Reactive;

using DynamicData;
using HandyControl.Tools.Extension;
using Microsoft.AppCenter.Utils.Files;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using EasyNetworkServer.Config;
using EasyNetworkServer.Models;
using EasyNetworkServer.Tools.Helper;
using EasyNetworkServer.ViewModels.Basics;
using EasyNetworkServer.Views;

namespace EasyNetworkServer.ViewModels.Dialogs
{
    public class ProjectViewModel : ViewModelBase, IDialogResultable<string>
    {
        [Reactive]
        public ObservableCollection<ProjectModel> ProjctList { get; set; }

        [Reactive]
        public ProjectModel SelectedProject { get; set; }


        public MainViewModel mainViewModel { get; set; }


        #region Command
        public ReactiveCommand<Unit, Unit> CloseCmd { get; set; }

        public ReactiveCommand<object, Unit> OpenProjectCmd { get; set; }
        public ReactiveCommand<Unit, Unit> DeleteProjectCmd { get; set; }

        #endregion


        public Action CloseAction { get; set; }

        [Reactive] public string Header { get; set; }
        [Reactive] public string Result { get; set; }

        public ProjectViewModel()
        {

            Init();
        }

        public override void Init()
        {
            base.Init();
            InitCommand();

            GetLocalProjects();
        }

        private void GetLocalProjects()
        {
            var list = IOHelper.Instance.ReadProjectListFromLocal();

            ProjctList = new ObservableCollection<ProjectModel>();
            ProjctList.AddRange(list);

            //foreach (var item in list)
            //{
            //    ProjctList.Add(item);
            //}
        }

        public override void InitCommand()
        {
            base.InitCommand();
            OpenProjectCmd = ReactiveCommand.Create<object>(OpenProject);

            DeleteProjectCmd = ReactiveCommand.Create(DeleteProject);
            CloseCmd = ReactiveCommand.Create(CloseEvent);
        }
        private void CloseEvent()
        {
            CloseAction?.Invoke();
        }

        private async void DeleteProject()
        {
            if (SelectedProject == null)
            {
                return;
            }

            var res = await DialogHelper.Instance.ShowResultDialog("确认删除所选项目?");

            if (res == System.Windows.Forms.DialogResult.Yes)
            {
                string configPath = PathConfig.projectPath + "\\" + SelectedProject.Name;
                System.IO.Directory.Delete(configPath, true);

                GetLocalProjects();

            }

        }

        private void OpenProject(object obj)
        {
            if (SelectedProject == null)
            {
                return;
            }

            //var configs = IOHelper.Instance.ReadProjectContentFromLocal(SelectedProject.Name);

            //if (configs == null || configs.GatewayConfigModel == null)
            //{
            //    return;
            //}

            //mainViewModel.ProjectName = SelectedProject.Name;
            //mainViewModel.InitFrameWork();
            //mainViewModel.InitProject(configs);


            Result = SelectedProject.Name;
            CloseEvent();
        }
    }
}