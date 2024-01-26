namespace _project.Scripts.Features.StateObserving.Base
{
    public interface IStateObservable
    {
        public void Notify(GameStateKind stateKind);
    }
}