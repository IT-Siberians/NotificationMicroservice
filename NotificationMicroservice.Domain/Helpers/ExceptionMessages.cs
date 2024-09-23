namespace NotificationMicroservice.Domain.Helpers
{
    public static class ExceptionMessages
    {
        public const string ERROR_ID = "Identifier cannot be empty.";
        public const string ERROR_DIRECTION = "Direction cannot be empty.";
        public const string ERROR_DIRECTION_LENGTH = "Direction cannot be longer than the maximum '{0}' allowed value.";
        public const string ERROR_TEXT = "Message text cannot be empty.";
        public const string ERROR_LANG_CODE_LENGTH = "Language code not match the encoding. Language code length contains '{0}' characters.";
        public const string ERROR_LANG_CODE = "Language code cannot be empty.";
        public const string ERROR_TEMPLATE = "Template cannot be empty.";
        public const string ERROR_TYPE_NAME = "Type Name cannot be empty.";
        public const string ERROR_TYPE_NAME_LENGTH = "The length of the message type name is invalid. It should be between '{0}' and '{1}' characters long.";
        public const string ERROR_TEMPLATE_LENGTH = "The length of the message template is invalid. It should be between '{0}' and '{1}' characters long.";
        public const string ERROR_EMAIL = "Email is not valid. Value is '{0}'.";
        public const string NAME_EMPTY_STRING_ERROR = "{0} cannot null or empty.";
        public const string NAME_LENGTH_ERROR = "The {0} is longer than the allowed length of the {0}. It should be between '{1}' and '{2}' characters long. Current value '{3}'";
    }
}
