using CardGame.Command;
using CardGame.UI;

namespace CardGame.Scripts
{
    public class ApplicationLaunchCommand : Command.Command
    {
        private readonly IUIService _uiService;

        public ApplicationLaunchCommand(
            IUIService uiService)
        {
            _uiService = uiService;
        }
        
        public override CommandResult Execute()
        {
            _uiService.Show<UIMainGameWindow>();
            
            return base.Execute();
        }
    }
}