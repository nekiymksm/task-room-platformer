namespace _project.Scripts.CoreControl.Handlers.Base
{
    public interface IHandler
    {
        public void Init(HandlersContainer handlersContainer);

        public void Run();
    }
}