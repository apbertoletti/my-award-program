namespace MyAwardProgram.Api.Contracts.V1
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

        public static class Address
        {
            public const string BaseRoute = BaseApi + "/address";

            public const string Register = BaseRoute + "/register";
        }

        public static class Movement
        {
            public const string BaseRoute = BaseApi + "/movement";

            public const string GetExtract = BaseRoute + "/extract"; ///{userId:int}/{startDate:dateTime}/{endDate:dateTime}/{movementType:int?}";
        }
    }
}
