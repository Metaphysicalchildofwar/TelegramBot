using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;

namespace ParseVkMemes
{
    /// <summary>
    /// Вход в ВК.
    /// </summary>
    public static class Authorization
    {
        public delegate void Mess(string mes);
        public static event Mess Err;
        public static VkApi api;
        public static Settings Scope = Settings.All;

        public static VkApi LogIn()
        {
            try
            {
                api = new VkApi();
                api.Authorize(new ApiAuthParams()
                {
                    ApplicationId = ulong.Parse(ConfigurationManager.AppSettings.Get("AppId")),
                    Login = ConfigurationManager.AppSettings.Get("LoginVk"),
                    Password = ConfigurationManager.AppSettings.Get("PassVk"),
                    //AccessToken = AccessToken,
                    Settings = Scope,
                    UserId = long.Parse(ConfigurationManager.AppSettings.Get("UserId"))
                });

                Err?.Invoke("Вход в ВК выполнен");
                return api;
            }
            catch (Exception ex)
            {
                Err?.Invoke("Вход не выполнен" + '\n' + ex.Message);
                return null;
            }

        }
    }
}
