using CardGame.Command;
using CardGame.UI;
using Zenject;

namespace CardGame.Scripts
{
    public class ApplicationLaunchCommand : Command.Command
    {
        private readonly IUIService _uiService;
        private readonly IInstantiator _instantiator;
        private readonly IUIRoot _uiRoot;

        public ApplicationLaunchCommand(
            IUIService uiService,
            IInstantiator instantiator,
            IUIRoot uiRoot)
        {
            _uiService = uiService;
            _instantiator = instantiator;
            _uiRoot = uiRoot;
        }
        
        public override CommandResult Execute()
        {
            _instantiator.InstantiatePrefabResourceForComponent<LiteSceneObject>("LiteSceneObject");
            
            var camera =  _instantiator.InstantiatePrefabResourceForComponent<MainCamera>("MainCamera").Camera;
            
            _instantiator.InstantiatePrefabResourceForComponent<EventSystem>("EventSystem");

            _uiRoot.Camera = camera;
            
            _uiService.Show<UIMainGameWindow>();
            
            return base.Execute();
        }
    }
}