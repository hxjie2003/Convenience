using System;
using ETong.Web;

namespace ETong.Services.Menus
{
    public class MenuService
    {
        private readonly string _menuApiServerAddress;

        public MenuService(string menuApiServerAddress)
        {
            if (menuApiServerAddress == null)
                throw new ArgumentNullException("menuApiServerAddress");
            _menuApiServerAddress = menuApiServerAddress.TrimEnd('/');
        }

        public MenuGroup GetTopMenu(string etmCode)
        {
            var url = _menuApiServerAddress + "/Api/Menu";
            return WebApiHelper.Get<MenuGroup>(url,
                new {menutype = "TopMenu", etmid = etmCode ?? ""}
                );
        }
    }
}