#region

using System;
using System.Windows.Input;

#endregion

namespace Shariando.Gui.WP7.Helpers
{
    /// <summary>
    /// An implementation of the ICommand interface.
    /// </summary>
    /// <remarks></remarks>
    public class Command : ICommand
    {
        #region Declarations

        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        /// <remarks></remarks>
        public event EventHandler CanExecuteChanged;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        /// <param name="execute">The execute.</param>
        /// <param name="canExecute">Whether the execute can be executed.</param>
        /// <remarks></remarks>
        public Command(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        /// <param name="execute">The execute.</param>
        /// <remarks></remarks>
        public Command(Action<object> execute)
        {
            _execute = execute;
        }

        #endregion

        #region Other

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to null.</param>
        /// <remarks></remarks>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        /// <remarks></remarks>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        #endregion

        /// <summary>
        /// Raises the can execute changed event.
        /// </summary>
        /// <remarks></remarks>
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null) CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}