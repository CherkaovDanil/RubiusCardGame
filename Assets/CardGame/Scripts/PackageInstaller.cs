using CardGame.UI;
using CardGame.UI.Realisation;
using Zenject;

namespace CardGame.Scripts
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