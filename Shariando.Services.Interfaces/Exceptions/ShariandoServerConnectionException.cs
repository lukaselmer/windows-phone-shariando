namespace Shariando.Services.Interfaces.Exceptions
{
    public class ShariandoServerConnectionException : ShariandoException
    {
        #region Overrides of ShariandoException

        public override string ErrorMessage
        {
            get { return "Es konnte leider keine Verbindung zu https://shariando.com hergestellt werden. Bitte �berpr�fen Sie Ihre Interneverbindung."; }
        }

        #endregion
    }
}