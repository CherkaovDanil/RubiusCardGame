using CardGame.Card;
using Zenject;

namespace CardGame.Scripts
{
    public class CardInstaller : Installer<CardInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<DownloadCardsSettings>()
                .FromScriptableObjectResource("DownloadCardsSettings")
                .AsSingle();
            
            Container
                .Bind<CardsConfig>()
                .FromScriptableObjectResource("CardsConfig")
                .AsSingle();
            
            Container
                .Bind<CardAnimationConfig>()
                .FromScriptableObjectResource("CardAnimationConfig")
                .AsSingle();

            Container
                .BindFactory<CardViewProtocol, CardView, CardFactory>()
                .FromComponentInNewPrefabResource("Card")
                .AsSingle();
        }
    }
}