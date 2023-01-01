using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CardGame.Card.Configs;
using Cysharp.Threading.Tasks;

namespace CardGame.Card.Controllers
{
    public class DownloadImageController
    {
        private readonly DownloadCardsSettingsConfig _downloadCardsSettingsConfig;
        private readonly CardFlipController _cardFlipController;
        private readonly ImageDownloaderController _imageDownloaderController;

        private string URL;
        
        public DownloadImageController(
            DownloadCardsSettingsConfig downloadCardsSettingsConfig,
            CardFlipController cardFlipController,
            ImageDownloaderController imageDownloaderController)
        {
            _downloadCardsSettingsConfig = downloadCardsSettingsConfig;
            _cardFlipController = cardFlipController;
            _imageDownloaderController = imageDownloaderController;

            URL = _downloadCardsSettingsConfig.URl;
        }

        public async UniTask DownloadImageAsync(List<CardView> cards,LoadType loadType,  CancellationToken cancellationToken)
        {
            switch (loadType)
            {
                case LoadType.AllAtOnce:
                    await AllAtOnce(cards, cancellationToken);
                    break;

                case LoadType.OneByOne:
                    await OneByOne(cards, cancellationToken);
                    break;

                case LoadType.WhenImageReady:
                    await WhenImageReady(cards, cancellationToken);
                    break;
            }
        }

        private async Task WhenImageReady(List<CardView> cards, CancellationToken cancellationToken)
        {
            await UniTask.WhenAll(cards.Select(
                async card =>
                {
                    var downloadImageTask = _imageDownloaderController.DownloadImageAsync(URL, cancellationToken);

                    await _cardFlipController.FlipCardAsync(card, CardSide.Back);
                    card.SetArt(await downloadImageTask);
                    await _cardFlipController.FlipCardAsync(card, CardSide.Front);
                }));
        }

        private async Task OneByOne(List<CardView> cards, CancellationToken cancellationToken)
        {
            await UniTask.WhenAll(cards.Select(
                async card =>
                {
                    var downloadImageTask = _imageDownloaderController.DownloadImageAsync(URL, cancellationToken);

                    await _cardFlipController.FlipCardAsync(card, CardSide.Back);
                    card.SetArt(await downloadImageTask);
                }));
            foreach (var card in cards)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await _cardFlipController.FlipCardAsync(card, CardSide.Front);
            }
        }

        private async Task AllAtOnce(List<CardView> cards, CancellationToken cancellationToken)
        {
            var downloadAndFlipBack = cards.Select(
                async card =>
                {
                    var downloadImageTask = _imageDownloaderController.DownloadImageAsync(URL, cancellationToken);

                    await _cardFlipController.FlipCardAsync(card, CardSide.Back);
                    card.SetArt(await downloadImageTask);
                });
            await UniTask.WhenAll(downloadAndFlipBack);
            await UniTask.WhenAll(cards.Select(card =>
                _cardFlipController.FlipCardAsync(card, CardSide.Front)));
        }
    }
}