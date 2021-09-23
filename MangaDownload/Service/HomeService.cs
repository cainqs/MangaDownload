using MangaDownload.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangaDownload.Service
{
    public class HomeService
    {
        public async static Task<BaiduUserInfo> GetBaiduUserInfo(string token)
        {
            BaiduUserInfo ret = new();

            var ui = await BaiduOauthService.GetUserInfo(token);
            var quota = await BaiduOauthService.Quota(token);

            if (ui != null && quota != null)
            {
                ret.AvatarUrl = ui.avatar_url;
                ret.FreeSpace = quota.free;
                ret.NetDiskName = ui.netdisk_name;
                ret.TotalSpace = quota.total;
                ret.UsedSpace = quota.used;
                ret.VipType = Enum.GetName(typeof(BaiduVipTypeEnum), ui.vip_type);
            }

            return ret;
        }
    }
}
