using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace FifaRating
{
    /// <summary>
    ///     This class allows delegating the commanding logic to methods passed as parameters,
    ///     and enables a View to bind commands to objects that are not part of the element tree.
    /// </summary>
    public class DelegateCommand : ICommand
    {
        #region Constructors

        /// <summary>
        ///     Constructor
        /// </summary>
        public DelegateCommand(Action executeMethod)
            : this(executeMethod, null, false)
        {
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        public DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod)
            : this(executeMethod, canExecuteMethod, false)
        {
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        public DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod, bool isAutomaticRequeryDisabled)
        {
            if (executeMethod == null)
            {
                throw new ArgumentNullException("executeMethod");
            }

            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
            _isAutomaticRequeryDisabled = isAutomaticRequeryDisabled;

            this.RaiseCanExecuteChanged();
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Method to determine if the command can be executed
        /// </summary>
        public bool CanExecute()
        {
            if (_canExecuteMethod != null)
            {
                return _canExecuteMethod();
            }
            return true;
        }

        /// <summary>
        ///     Execution of the command
        /// </summary>
        public void Execute()
        {
            if (_executeMethod != null)
            {
                _executeMethod();
            }
        }

        /// <summary>
        ///     Property to enable or disable CommandManager's automatic requery on this command
        /// </summary>
        public bool IsAutomaticRequeryDisabled
        {
            get
            {
                return _isAutomaticRequeryDisabled;
            }
            set
            {
                if (_isAutomaticRequeryDisabled != value)
                {
                    if (value)
                    {
                        CommandManagerHelper.RemoveHandlersFromRequerySuggested(_canExecuteChangedHandlers);
                    }
                    else
                    {
                        CommandManagerHelper.AddHandlersToRequerySuggested(_canExecuteChangedHandlers);
                    }
                    _isAutomaticRequeryDisabled = value;
                }
            }
        }

        /// <summary>
        ///     Raises the CanExecuteChaged event
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            OnCanExecuteChanged();
        }

        /// <summary>
        ///     Protected virtual method to raise CanExecuteChanged event
        /// </summary>
        protected virtual void OnCanExecuteChanged()
        {
            CommandManagerHelper.CallWeakReferenceHandlers(_canExecuteChangedHandlers);
        }

        #endregion

        #region ICommand Members

        /// <summary>
        ///     ICommand.CanExecuteChanged implementation
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (!_isAutomaticRequeryDisabled)
                {
                    CommandManager.RequerySuggested += value;
                }
                CommandManagerHelper.AddWeakReferenceHandler(ref _canExecuteChangedHandlers, value, 2);
            }
            remove
            {
                if (!_isAutomaticRequeryDisabled)
                {
                    CommandManager.RequerySuggested -= value;
                }
                CommandManagerHelper.RemoveWeakReferenceHandler(_canExecuteChangedHandlers, value);
            }
        }

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }

        void ICommand.Execute(object parameter)
        {
            Execute();
        }

        #endregion

        #region Data

        private readonly Action _executeMethod = null;
        private readonly Func<bool> _canExecuteMethod = null;
        private bool _isAutomaticRequeryDisabled = false;
        private List<WeakReference> _canExecuteChangedHandlers;

        #endregion
    }

    /// <summary>
    ///     This class allows delegating the commanding logic to methods passed as parameters,
    ///     and enables a View to bind commands to objects that are not part of the element tree.
    /// </summary>
    /// <typeparam name="T">Type of the parameter passed to the delegates</typeparam>
    public class DelegateCommand<T> : ICommand
    {
        #region Constructors

        /// <summary>
        ///     Constructor
        /// </summary>
        public DelegateCommand(Action<T> executeMethod)
            : this(executeMethod, null, false)
        {
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        public DelegateCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
            : this(executeMethod, canExecuteMethod, false)
        {
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        public DelegateCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod, bool isAutomaticRequeryDisabled)
        {
            if (executeMethod == null)
            {
                throw new ArgumentNullException("executeMethod");
            }

            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
            _isAutomaticRequeryDisabled = isAutomaticRequeryDisabled;
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Method to determine if the command can be executed
        /// </summary>
        public bool CanExecute(T parameter)
        {
            if (_canExecuteMethod != null)
            {
                return _canExecuteMethod(parameter);
            }
            return true;
        }

        /// <summary>
        ///     Execution of the command
        /// </summary>
        public void Execute(T parameter)
        {
            if (_executeMethod != null)
            {
                _executeMethod(parameter);
            }
        }

        /// <summary>
        ///     Raises the CanExecuteChaged event
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            OnCanExecuteChanged();
        }

        /// <summary>
        ///     Protected virtual method to raise CanExecuteChanged event
        /// </summary>
        protected virtual void OnCanExecuteChanged()
        {
            CommandManagerHelper.CallWeakReferenceHandlers(_canExecuteChangedHandlers);
        }

        /// <summary>
        ///     Property to enable or disable CommandManager's automatic requery on this command
        /// </summary>
        public bool IsAutomaticRequeryDisabled
        {
            get
            {
                return _isAutomaticRequeryDisabled;
            }
            set
            {
                if (_isAutomaticRequeryDisabled != value)
                {
                    if (value)
                    {
                        CommandManagerHelper.RemoveHandlersFromRequerySuggested(_canExecuteChangedHandlers);
                    }
                    else
                    {
                        CommandManagerHelper.AddHandlersToRequerySuggested(_canExecuteChangedHandlers);
                    }
                    _isAutomaticRequeryDisabled = value;
                }
            }
        }

        #endregion

        #region ICommand Members

        /// <summary>
        ///     ICommand.CanExecuteChanged implementation
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (!_isAutomaticRequeryDisabled)
                {
                    CommandManager.RequerySuggested += value;
                }
                CommandManagerHelper.AddWeakReferenceHandler(ref _canExecuteChangedHandlers, value, 2);
            }
            remove
            {
                if (!_isAutomaticRequeryDisabled)
                {
                    CommandManager.RequerySuggested -= value;
                }
                CommandManagerHelper.RemoveWeakReferenceHandler(_canExecuteChangedHandlers, value);
            }
        }

        bool ICommand.CanExecute(object parameter)
        {
            // if T is of value type and the parameter is not
            // set yet, then return false if CanExecute delegate
            // exists, else return true
            if (parameter == null &&
                typeof(T).IsValueType)
            {
                return (_canExecuteMethod == null);
            }
            return CanExecute((T)parameter);
        }

        void ICommand.Execute(object parameter)
        {
            Execute((T)parameter);
        }

        #endregion

        #region Data

        private readonly Action<T> _executeMethod = null;
        private readonly Func<T, bool> _canExecuteMethod = null;
        private bool _isAutomaticRequeryDisabled = false;
        private List<WeakReference> _canExecuteChangedHandlers;

        #endregion
    }

    /// <summary>
    ///     This class contains methods for the CommandManager that help avoid memory leaks by
    ///     using weak references.
    /// </summary>
    internal class CommandManagerHelper
    {
        internal static void CallWeakReferenceHandlers(List<WeakReference> handlers)
        {
            if (handlers != null)
            {
                // Take a snapshot of the handlers before we call out to them since the handlers
                // could cause the array to me modified while we are reading it.

                EventHandler[] callees = new EventHandler[handlers.Count];
                int count = 0;

                for (int i = handlers.Count - 1; i >= 0; i--)
                {
                    WeakReference reference = handlers[i];
                    EventHandler handler = reference.Target as EventHandler;
                    if (handler == null)
                    {
                        // Clean up old handlers that have been collected
                        handlers.RemoveAt(i);
                    }
                    else
                    {
                        callees[count] = handler;
                        count++;
                    }
                }

                // Call the handlers that we snapshotted
                for (int i = 0; i < count; i++)
                {
                    EventHandler handler = callees[i];
                    handler(null, EventArgs.Empty);
                }
            }
        }

        internal static void AddHandlersToRequerySuggested(List<WeakReference> handlers)
        {
            if (handlers != null)
            {
                foreach (WeakReference handlerRef in handlers)
                {
                    EventHandler handler = handlerRef.Target as EventHandler;
                    if (handler != null)
                    {
                        CommandManager.RequerySuggested += handler;
                    }
                }
            }
        }

        internal static void RemoveHandlersFromRequerySuggested(List<WeakReference> handlers)
        {
            if (handlers != null)
            {
                foreach (WeakReference handlerRef in handlers)
                {
                    EventHandler handler = handlerRef.Target as EventHandler;
                    if (handler != null)
                    {
                        CommandManager.RequerySuggested -= handler;
                    }
                }
            }
        }

        internal static void AddWeakReferenceHandler(ref List<WeakReference> handlers, EventHandler handler)
        {
            AddWeakReferenceHandler(ref handlers, handler, -1);
        }

        internal static void AddWeakReferenceHandler(ref List<WeakReference> handlers, EventHandler handler, int defaultListSize)
        {
            if (handlers == null)
            {
                handlers = (defaultListSize > 0 ? new List<WeakReference>(defaultListSize) : new List<WeakReference>());
            }

            handlers.Add(new WeakReference(handler));
        }

        internal static void RemoveWeakReferenceHandler(List<WeakReference> handlers, EventHandler handler)
        {
            if (handlers != null)
            {
                for (int i = handlers.Count - 1; i >= 0; i--)
                {
                    WeakReference reference = handlers[i];
                    EventHandler existingHandler = reference.Target as EventHandler;
                    if ((existingHandler == null) || (existingHandler == handler))
                    {
                        // Clean up old handlers that have been collected
                        // in addition to the handler that is to be removed.
                        handlers.RemoveAt(i);
                    }
                }
            }
        }
    }


    public static class DelegateCommandExtensions
    {
        /// <summary>
        /// Makes DelegateCommnand listen on PropertyChanged events of some object,
        /// so that DelegateCommnand can update its IsEnabled property.
        /// </summary>
        public static DelegateCommand ListenOn<ObservedType, PropertyType>
            (this DelegateCommand delegateCommand,
            ObservedType observedObject,
            Expression<Func<ObservedType, PropertyType>> propertyExpression,
            Dispatcher dispatcher)
            where ObservedType : INotifyPropertyChanged
        {
            //string propertyName = observedObject.GetPropertyName(propertyExpression);
            string propertyName = NotifyPropertyChangedBaseExtensions.GetPropertyName(propertyExpression);

            observedObject.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == propertyName)
                {
                    if (dispatcher != null)
                    {
                        ThreadTools.RunInDispatcher(dispatcher, delegateCommand.RaiseCanExecuteChanged);
                    }
                    else
                    {
                        delegateCommand.RaiseCanExecuteChanged();
                    }
                }
            };

            return delegateCommand; //chain calling
        }

        /// <summary>
        /// Makes DelegateCommnand listen on PropertyChanged events of some object,
        /// so that DelegateCommnand can update its IsEnabled property.
        /// </summary>
        public static DelegateCommand<T> ListenOn<T, ObservedType, PropertyType>
            (this DelegateCommand<T> delegateCommand,
            ObservedType observedObject,
            Expression<Func<ObservedType, PropertyType>> propertyExpression,
            Dispatcher dispatcher)
            where ObservedType : INotifyPropertyChanged
        {
            //string propertyName = observedObject.GetPropertyName(propertyExpression);
            string propertyName = NotifyPropertyChangedBaseExtensions.GetPropertyName(propertyExpression);

            observedObject.PropertyChanged += (object sender, PropertyChangedEventArgs e) =>
            {
                if (e.PropertyName == propertyName)
                {
                    if (dispatcher != null)
                    {
                        ThreadTools.RunInDispatcher(dispatcher, delegateCommand.RaiseCanExecuteChanged);
                    }
                    else
                    {
                        delegateCommand.RaiseCanExecuteChanged();
                    }
                }
            };

            return delegateCommand; //chain calling
        }
    }

    /// <summary>
    /// <see cref="http://dotnet.dzone.com/news/silverlightwpf-implementing"/>
    /// </summary>
    public static class NotifyPropertyChangedBaseExtensions
    {
        /// <summary>
        /// Raises PropertyChanged event.
        /// To use: call the extension method with this: this.OnPropertyChanged(n => n.Title);
        /// </summary>
        /// <typeparam name="T">Property owner</typeparam>
        /// <typeparam name="TProperty">Type of property</typeparam>
        /// <param name="observableBase"></param>
        /// <param name="expression">Property expression like 'n => n.Property'</param>
        public static void OnPropertyChanged<T, TProperty>(this T observableBase, Expression<Func<T, TProperty>> expression) where T : INotifyPropertyChangedWithRaise
        {
            observableBase.OnPropertyChanged(GetPropertyName<T, TProperty>(expression));
        }

        public static string GetPropertyName<T, TProperty>(Expression<Func<T, TProperty>> expression) where T : INotifyPropertyChanged
        {
            if (expression == null)
                throw new ArgumentNullException("expression");

            var lambda = expression as LambdaExpression;
            MemberExpression memberExpression;
            if (lambda.Body is UnaryExpression)
            {
                var unaryExpression = lambda.Body as UnaryExpression;
                memberExpression = unaryExpression.Operand as MemberExpression;
            }
            else
            {
                memberExpression = lambda.Body as MemberExpression;
            }

            if (memberExpression == null)
                throw new ArgumentException("Please provide a lambda expression like 'n => n.PropertyName'");

            MemberInfo memberInfo = memberExpression.Member;

            if (String.IsNullOrEmpty(memberInfo.Name))
                throw new ArgumentException("'expression' did not provide a property name.");

            return memberInfo.Name;
        }
    }

    public interface INotifyPropertyChangedWithRaise : INotifyPropertyChanged
    {
        void OnPropertyChanged(string propertyName);
    }

    public class ThreadTools
    {
        public static void RunInDispatcher(Dispatcher dispatcher, Action action)
        {
            RunInDispatcher(dispatcher, DispatcherPriority.Normal, action);
        }

        public static void RunInDispatcher(Dispatcher dispatcher, DispatcherPriority priority, Action action)
        {
            if (action == null) { return; }

            if (dispatcher.CheckAccess())
            {
                // we are already on thread associated with the dispatcher -> just call action
                try
                {
                    action();
                }
                catch (Exception)
                {
                    //Log error here!
                }
            }
            else
            {
                // we are on different thread, invoke action on dispatcher's thread
                dispatcher.BeginInvoke(
                    priority,
                    (Action)(
                    () =>
                    {
                        try
                        {
                            action();
                        }
                        catch (Exception)
                        {
                            //Log error here!
                        }
                    })
                );
            }
        }
    }



        //public class DelegateCommand : ICommand
        //{

        //    public Predicate<object> CanExecuteDelegate { get; set; }

        //    private List<INotifyPropertyChanged> _propertiesToListenTo;
        //    private readonly List<WeakReference> _controlEventList;

        //    public DelegateCommand()
        //    {
        //        _controlEventList = new List<WeakReference>();
        //    }

        //    public List<INotifyPropertyChanged> PropertiesToListenTo
        //    {
        //        get { return _propertiesToListenTo; }
        //        set
        //        {
        //            _propertiesToListenTo = value;
        //        }
        //    }

        //    private Action<object> _executeDelegate;

        //    public Action<object> ExecuteDelegate
        //    {
        //        get { return _executeDelegate; }
        //        set
        //        {
        //            _param => value;
        //            ListenForNotificationFrom((INotifyPropertyChanged)_executeDelegate.Target);
        //        }
        //    }

        //    //public static ICommand Create(Action<object> exec)
        //    //{
        //    //    return new SimpleCommand{ param => exec };
        //    //}



        //    #region ICommand Members


        //    public bool CanExecute(object parameter)
        //    {
        //        if (CanExecuteDelegate != null)
        //            return CanExecuteDelegate(parameter);
        //        return true; // if there is no can execute default to true
        //    }

        //    public event EventHandler CanExecuteChanged
        //    {
        //        add
        //        {
        //            CommandManager.RequerySuggested += value;
        //            _controlEventList.Add(new WeakReference(value));
        //        }
        //        remove
        //        {
        //            CommandManager.RequerySuggested -= value;
        //            _controlEventList.Remove(_controlEventList.Find(r => ((EventHandler)r.Target) == value));
        //        }
        //    }

        //    public void Execute(object parameter)
        //    {
        //        if (ExecuteDelegate != null)
        //            ExecuteDelegate(parameter);
        //    }
        //    #endregion

        //    public void RaiseCanExecuteChanged()
        //    {
        //        if (_controlEventList != null && _controlEventList.Count > 0)
        //        {
        //            _controlEventList.ForEach(ce =>
        //            {
        //                if (ce.Target != null)
        //                        ((EventHandler)(ce.Target)).Invoke(null, EventArgs.Empty);

        //            });
        //        }
        //    }



        //    public DelegateCommand ListenOn<TObservedType, TPropertyType>(TObservedType viewModel, Expression<Func<TObservedType, TPropertyType>> propertyExpression) where TObservedType : INotifyPropertyChanged
        //    {
        //        string propertyName = GetPropertyName(propertyExpression);
        //        viewModel.PropertyChanged += (PropertyChangedEventHandler)((sender, e) =>
        //        {
        //            if (e.PropertyName == propertyName) RaiseCanExecuteChanged();
        //        });
        //        return this;
        //    }

        //    public void ListenForNotificationFrom<TObservedType>(TObservedType viewModel) where TObservedType : INotifyPropertyChanged
        //    {                
                
        //        viewModel.PropertyChanged += (PropertyChangedEventHandler)((sender, e) =>
        //        {
        //            //if(PropertiesToListenTo != null &&  PropertiesToListenTo.IndexOf(e.PropertyName)>=0)
        //            RaiseCanExecuteChanged();
        //        });
        //    }

        //    private string GetPropertyName<T, TProperty>(Expression<Func<T, TProperty>> expression) where T : INotifyPropertyChanged
        //    {
        //        var lambda = expression as LambdaExpression;
        //        MemberInfo memberInfo = GetmemberExpression(lambda).Member;
        //        return memberInfo.Name;
        //    }

        //    private MemberExpression GetmemberExpression(LambdaExpression lambda)
        //    {
        //        MemberExpression memberExpression;
                
        //        if (lambda.Body is UnaryExpression)
        //            memberExpression = (lambda.Body as UnaryExpression).Operand as MemberExpression;
        //        else
        //            memberExpression = lambda.Body as MemberExpression;
        //        return memberExpression;
        //    }

        //}
}
