using System;
using CardGame.Command;

namespace CardGame.UI
{
    public class UIServiceInitCommand : Command.Command
    {
        private readonly IUIService _uiService;

        private const string WindowsSource = "UIWindows";
        
        public UIServiceInitCommand(IUIService uiService)
        {
            _uiService = uiService;
        }

        public override CommandResult Execute()
        {
            _uiService.LoadWindows(WindowsSource);
            _uiService.InitWindows();

            Done?.Invoke(this, EventArgs.Empty);
            return base.Execute(); 
        }
    }
}