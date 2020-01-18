using Xyz.Web.Framework.Models;
using Xyz.Web.Platform;

namespace Xyz.Web.Framework.Business
{
    public interface ILogoManagementBL
    {
        LogoDAL GetCompanyLogoHeightAndWidth(IDFSessionInfo sessionInfo);
    }
}