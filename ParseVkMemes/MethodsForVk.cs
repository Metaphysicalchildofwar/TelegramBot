using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;

namespace ParseVkMemes
{
    /// <summary>
    /// Класс методов обращения к ВК.
    /// </summary>
    public static class MethodsForVk
    {
        /// <summary>
        /// Поиск друзей.
        /// </summary>
        public static IEnumerable<VkNet.Model.User> GettingFriends(VkApi api)
        {
            return api.Friends.Get(new VkNet.Model.RequestParams.FriendsGetParams
            {
                UserId = api.UserId,
                Fields = ProfileFields.All
            });
        }

        /// <summary>
        /// Поиск сохраненных фото
        /// В данном варианте поиск у Алексея Васильева.
        /// </summary>
        public static IEnumerable<VkNet.Model.Attachments.Photo> GettingPhotos(VkApi api)
        {
            return api.Photo.Get(new VkNet.Model.RequestParams.PhotoGetParams
            {
                OwnerId = MethodsForVk.GettingFriends(api).Where((x) => x.FirstName == "Алексей" && x.LastName == "Васильев").FirstOrDefault().Id,
                AlbumId = PhotoAlbumType.Saved,
                Count = 1000

            });
        }
    }
}
