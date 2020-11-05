using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentValidation;
using One.Core.Helper;
using EasyNetworkServer.Models;
using EasyNetworkServer.Models.Common;

namespace EasyNetworkServer.Validator
{

    public class NetPortInfoModelValidator : AbstractValidator<NetPortInfoModel>
    {
        public NetPortInfoModelValidator()
        {

            //this.CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.IPAddress).Must(ValidIP).WithMessage("IP地址不合法");
            RuleFor(x => x.NetMask).Must(ValidIP).WithMessage("掩码地址不合法");
            RuleFor(x => x.NetGateWayAddress).Must(ValidIP).WithMessage("网关地址不合法");

        }

        private bool ValidIP(string ip)
        {
            return !string.IsNullOrEmpty(ip) && Regex.IsMatch(ip, RegexHelper.IPv4AddressRegex);
        }
    }
}
