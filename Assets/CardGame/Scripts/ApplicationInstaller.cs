using Zenject;

namespace CardGame.Scripts
{
    public class ApplicationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            PackageInstaller.Install(Container);
            
            CardInstaller.Install(Container);

            Container
                .Bind<ApplicationLauncher>()
                .AsSingle()
                .NonLazy();
        }
    }
}