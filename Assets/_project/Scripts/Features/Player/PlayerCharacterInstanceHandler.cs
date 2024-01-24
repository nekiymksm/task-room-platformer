using _project.Scripts.Configs;
using _project.Scripts.CoreControl.Base;

namespace _project.Scripts.Features.Player
{
    public class PlayerCharacterInstanceHandler : InstanceHandler<PlayerCharacterInstance>
    {
        protected override PlayerCharacterInstance Create() 
            => ConfigsCollection.GetConfig<PlayerCharacterConfig>().Create();
    }
}