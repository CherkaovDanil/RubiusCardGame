using System;

namespace CardGame.Command
{
    public abstract class Command : ICommand, IDisposable
    {
        public EventHandler Done { get; set; }
        
        public virtual CommandResult Execute()
        {
            return new CommandResult();
        }

        public virtual void Cancel(){ }

        public void Dispose() { }
    }
}