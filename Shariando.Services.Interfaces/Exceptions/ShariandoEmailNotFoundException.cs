namespace Shariando.Services.Interfaces.Exceptions
{
    public class ShariandoEmailNotFoundException : ShariandoException
    {
        #region Overrides of ShariandoException

        public override string ErrorMessage
        {
            get
            {
                return
                    "Ihre Email Adresse wurde nicht gefunden. Bitte überprüfen Sie Ihre Email Adresse oder registrieren Sie sich unter https://shariando.com.";
            }
        }

        #endregion
    }
}