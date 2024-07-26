namespace thesis_exercise.common
{
    public class Constant
    {
        
    }

    public static class UserErrorMessage
    {
        public const string UpdateError = "Cannot update information, please try again.";
        public const string SaveUpdateDbError = "Cannot save or update information, please try again.";
        public const string ErrorDatabaseSaving = "There was an error saving information, please try again.";
        public const string RequestError = "There was an error, please try again.";
    }

    public static class LoggerErrorMessage
    {
        public const string UpdateError = "Cannot update entity, DbUpdateConcurrencyException.";
        public const string SaveUpdateDbError = "Cannot save or update entity into the database. DbUpdateException";
        public const string ErrorDatabaseSaving = "There was an error saving entity into the database.";
        public const string RequestError = "There was a general error catched by general exception, see details in logger.";
    }
}
