using System.Collections.Generic;
using System.Threading;
using CardGame.Card.Configs;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CardGame.Card.Controllers
{
    public class CardController
    {
        private readonly CardsConfig _cardsConfig;
        private readonly CardFactory _cardFactory;
        private readonly DownloadImageController _downloadImageController;

        private List<CardView> _cards = new List<CardView>();
        private LoadType _loadType = LoadType.AllAtOnce;
        private CancellationTokenSource _cancellationToken;

        public CardController(
            CardsConfig cardsConfig,
            CardFactory cardFactory,
            DownloadImageController downloadImageController)
        {
            _cardsConfig = cardsConfig;
            _cardFactory = cardFactory;
            _downloadImageController = downloadImageController;
        }
        
        public void SpawnAllCards(Transform transform)
        {
            var countCards = _cardsConfig.CountCard;
            var model = _cardsConfig.Get(0).Value;
            var protocol = new CardViewProtocol(
                model.Name,
                model.Discription,
                model.FrontSprite,
                model.BackSprite,
                transform);

            for (int i = 0; i < countCards; i++)
            {
                _cards.Add(_cardFactory.Create(protocol));
            }
        }

        public async UniTask StartDownload()
        {
            _cancellationToken = new CancellationTokenSource();
            
            var cancel = await _downloadImageController
                .DownloadImageAsync(
                                _cards, 
                                _loadType, 
                                _cancellationToken.Token)
                .SuppressCancellationThrow();
            
            if (cancel)
            {
                Debug.Log("The operation was canceled.");
            }
        }

        public void ChangeDownloadType(int value)
        {
            switch (value)
            {
                case 0:
                    _loadType = LoadType.AllAtOnce;
                    break;
                case 1:
                    _loadType = LoadType.OneByOne;
                    break;
                case 2:
                    _loadType = LoadType.WhenImageReady;
                    break;
            }
        }

        public void CancelDownload()
        {
            if (_cancellationToken != null)
            {
                _cancellationToken?.Cancel();
            }
        }
    }
}