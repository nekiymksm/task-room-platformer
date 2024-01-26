using System.Collections.Generic;
using _project.Scripts.CoreControl.Base;
using _project.Scripts.Features.StateObserving.Base;

namespace _project.Scripts.Features.StateObserving
{
    public class GameStateHandler : IHandler
    {
        private List<IStateObservable> _observers;

        public GameStateKind CurrentGameState { get; private set; }

        public void Init(HandlersContainer handlersContainer)
        {
            _observers = new List<IStateObservable>();
        }

        public void Run()
        {
        }
        
        public void AddObserver(IStateObservable observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IStateObservable observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers(GameStateKind state)
        {
            foreach (var observer in _observers)
            {
                observer.Notify(state);
            }
        }
    }
}