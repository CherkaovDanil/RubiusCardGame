using CardGame.UI;
using Zenject;

namespace CardGame.Artwork
{
    public class PackageInstaller : Installer<PackageInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IUIRoot>()
                .To<UIRoot>()
                .FromComponentInNewPrefabResource("UIWindows/UIRoot")
                .AsSingle();
            
            Container
                .Bind<IUIService>()
                .To<UIService>()
                .AsSingle();
        }
    }
}