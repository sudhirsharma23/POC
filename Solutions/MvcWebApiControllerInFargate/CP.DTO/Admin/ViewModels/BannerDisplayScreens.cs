using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.Admin.ViewModels
{
    public class BannerDisplayScreens
    {
        public int ScreenId { get; set; }

        public string MfaScreenName { get; set; }

        public bool EnableBannerMessage { get; set; }

        public string BannerMessage { get; set; }
    }
}
