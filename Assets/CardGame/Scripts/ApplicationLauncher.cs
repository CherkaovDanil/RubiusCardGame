using CardGame.Scripts;
using CardGame.UI;
using Zenject;

namespace CardGame.Artwork
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