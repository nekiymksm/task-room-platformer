namespace _project.Scripts.Configs.Base
{
    public interface IGuidable<in T>
    {
        public void Guide(T config);
    }
}