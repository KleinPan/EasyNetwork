﻿using ReactiveUI;

namespace EasyNetworkServer.ViewModels.Basics
{
    public class ViewModelBase : ReactiveObject
    {
        public virtual void Init()
        {
            //InitCommand();
            //InitData();
            //InitBindings();

            //InitOthers();
        }

        /// <summary>
        /// 需最后初始化
        /// </summary>
        public virtual void InitBindings()
        {
        }

        public virtual void InitCommand()
        {
        }
        public virtual void InitData()
        {
        }
        public virtual void InitOthers()
        {
        }
        public virtual void InitValidator()
        {
        }

    }
}