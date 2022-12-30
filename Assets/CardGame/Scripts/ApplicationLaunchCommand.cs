using CardGame.Command;
using CardGame.UI;
using Zenject;

namespace CardGame.Scripts
{
    public class ApplicationLaunchCommand : Command.Command
    {
        private readonly IUIService _uiService;
        private readonly IInstantiator _instantiator;

        public ApplicationLaunchCommand(
            IUIService uiService,
            IInstantiator instantiator)
        {
            _uiService = uiService;
            _instantiator = instantiator;
        }
        
        public override CommandResult Execute()
        {
            _instantiator.InstantiatePrefabResourceForComponent<LiteSceneObject>("LiteSceneObject");
            
            _instantiator.InstantiatePrefabResourceForComponent<MainCamera>("MainCamera");
            
            _instantiator.InstantiatePrefabResourceForComponent<EventSystem>("EventSystem");
            
            _uiService.Show<UIMainGameWindow>();
            
            return base.Execute();
        }
    }
}