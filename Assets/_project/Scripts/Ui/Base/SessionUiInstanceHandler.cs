using _project.Scripts.Configs;
using _project.Scripts.CoreControl.Base;
using _project.Scripts.Ui.Session;
using UnityEngine;

namespace _project.Scripts.Ui.Base
{
    public class SessionUiInstanceHandler : InstanceHandler<SessionUiHandler>
    {
        protected override SessionUiHandler Create() 
            => Object.Instantiate(ConfigsCollection.GetConfig<UiConfig>().SessionUiHandlerPrefab);
    }
}