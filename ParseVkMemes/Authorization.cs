using System;
using System.Collections.Generic;
using System.Text;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;

namespace ParseVkMemes
{
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
                    ApplicationId = 7911557,
                    Login = "orlovaleksey5@gmail.com",
                    Password = "1337Alex1488",
                    //AccessToken = AccessToken,
                    Settings = Scope,
                    UserId = 297701190
                });

                Err?.Invoke("Вход выполнен");
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
