namespace Blog.Domain.Base
{
    public static partial class AppData 
    {
        public static string NotFoundException => "Entity \"{0}\" ({1}) not found.";
        public static string AlreadyExists => "Entity \"{0}\" ({1}) is already exists.";
        public static string AccessDenied => "Access Denied to perform the operation \"{0}\"";
    }
}
