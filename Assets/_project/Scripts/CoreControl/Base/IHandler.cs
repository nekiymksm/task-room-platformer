namespace _project.Scripts.CoreControl.Base
{
    public interface IHandler
    {
        public void Init(HandlersContainer handlersContainer);

        public void Run();
    }
}