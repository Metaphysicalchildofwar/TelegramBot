using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;

namespace ParseVkMemes
{
    public static class Methods
    {
        public static IEnumerable<VkNet.Model.User> GettingFriends(VkApi api)
        {
            return api.Friends.Get(new VkNet.Model.RequestParams.FriendsGetParams
            {
                UserId = api.UserId,
                Fields = ProfileFields.All
            });
        }

        public static IEnumerable<VkNet.Model.Attachments.Photo> GettingPhotos(VkApi api)
        {
            return api.Photo.Get(new VkNet.Model.RequestParams.PhotoGetParams
            {
                OwnerId = Methods.GettingFriends(api).Where((x) => x.FirstName == "Алексей" && x.LastName == "Васильев").FirstOrDefault().Id,
                AlbumId = PhotoAlbumType.Saved,
                Count = 1000

            });
        }
    }
}
