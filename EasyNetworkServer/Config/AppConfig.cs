﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyNetworkServer.Config
{
    class AppConfig
    {
        public string Lang { get; set; } = "zh-cn";
        public static readonly string SavePath = $"{AppDomain.CurrentDomain.BaseDirectory}AppConfig.json";
    }
}
