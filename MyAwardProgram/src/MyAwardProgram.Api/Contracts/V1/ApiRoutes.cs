﻿namespace MyAwardProgram.Api.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string RootApi = "api";

        public const string VersionApi = "v1";

        public const string BaseApi = RootApi + "/" + VersionApi;
        
        public static class User
        {
            public const string BaseRoute = BaseApi + "/user";

            public const string Login = BaseRoute + "/login";

            public const string Register = BaseRoute + "/register";
        }
    }
}
