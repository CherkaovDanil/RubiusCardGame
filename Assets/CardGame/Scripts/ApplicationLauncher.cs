using CardGame.UI;
using Zenject;

namespace CardGame.Scripts
{
    public class ApplicationLauncher
    {
        public ApplicationLauncher(IInstantiator instantiator)
        {
            instantiator.Instantiate<UIServiceInitCommand>().Execute();

            instantiator.Instantiate<ApplicationLaunchCommand>().Execute();
        }
    }
}