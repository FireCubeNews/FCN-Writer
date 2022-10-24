using System;
using System.Collections.Generic;
using System.Text;

namespace FCN.Core.Helpers
{
    public class UriHelper
    {
        public static Uri CreatePostUri = new Uri("https://fcn.technobiscuit.uk/api/v1/posts/create");
        public static Uri GetUserMeUri = new Uri("https://fcn.technobiscuit.uk/api/v1/users/me");
        public static Uri GetPostsUri = new Uri("https://fcn.technobiscuit.uk/api/v1/posts/mine");
        public static Uri GetPostUri = new Uri("https://fcn.technobiscuit.uk/api/v1/posts/");
    }
}
