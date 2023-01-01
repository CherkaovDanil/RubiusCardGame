using CardGame.Card;
using CardGame.Card.Configs;
using CardGame.Card.Controllers;
using Zenject;

namespace CardGame.Scripts
{
    public class CardInstaller : Installer<CardInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<CardController>()
                .AsSingle();
            
            Container
                .Bind<DownloadImageController>()
                .AsSingle();
            
            Container
                .Bind<ImageDownloaderController>()
                .AsSingle();
            
            Container
                .Bind<CardFlipController>()
                .AsSingle();
            
            Container
                .Bind<DownloadCardsSettingsConfig>()
                .FromScriptableObjectResource("DownloadCardsSettings")
                .AsSingle();
            
            Container
                .Bind<CardsConfig>()
                .FromScriptableObjectResource("CardsConfig")
                .AsSingle();
            
            Container
                .Bind<CardAnimationConfig>()
                .FromScriptableObjectResource("CardsAnimationConfig")
                .AsSingle();

            Container
                .BindFactory<CardViewProtocol, CardView, CardFactory>()
                .FromComponentInNewPrefabResource("Card")
                .AsSingle();
        }
    }
}