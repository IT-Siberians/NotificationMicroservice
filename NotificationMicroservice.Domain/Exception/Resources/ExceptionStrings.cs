namespace NotificationMicroservice.Domain.Exception.Resources
{
    public class ExceptionStrings
    {
        public const string ERROR_ID = $"Identifier cannot be empty.";
        public const string ERROR_DIRECTION = $"Direction cannot be empty.";
        public const string ERROR_DIRECTION_LENG = $"Direction cannot be longer than the maximum allowed value.";
        public const string ERROR_TEXT = $"Message text cannot be empty.";
        public const string ERROR_LANG_CODE_LENG = $"Language code not match the encoding.";
        public const string ERROR_LANG_CODE = $"Language code cannot be empty.";
        public const string ERROR_TEMPLATE = $"Template cannot be empty.";
        public const string ERROR_USERNAME = $"UserName cannot be longer than the maximum allowed value.";
        public const string ERROR_TYPE_NAME = $"Type Name cannot be empty.";
        public const string ERROR_TYPE_NAME_LENG = $"Type Name cannot be longer than the maximum allowed value.";
    }
}
