using System;

namespace CardGame.Command
{
    public interface ICommand
    {
        EventHandler Done { get; set; }
            
        CommandResult Execute();
        
        void Cancel();
    }
}