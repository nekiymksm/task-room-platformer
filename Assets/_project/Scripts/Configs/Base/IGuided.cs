namespace _project.Scripts.Configs.Base
{
    public interface IGuided<in T>
    {
        public void Guide(T config);
    }
}