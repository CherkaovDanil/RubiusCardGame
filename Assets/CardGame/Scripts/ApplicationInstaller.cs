using Zenject;

namespace CardGame.Artwork
{
    public class ApplicationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            PackageInstaller.Install(Container);


            Container
                .Bind<ApplicationLauncher>()
                .AsSingle()
                .NonLazy();
        }
    }
}