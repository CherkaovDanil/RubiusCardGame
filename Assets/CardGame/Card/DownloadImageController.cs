using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

namespace CardGame.Card
{
    public class DownloadImageController
    {
        private readonly DownloadCardsSettings _downloadCardsSettings;
        private readonly CardFlipController _cardFlipController;
        private readonly ImageDownloader _imageDownloader;

        private string URL;
        
        public DownloadImageController(
            DownloadCardsSettings downloadCardsSettings,
            CardFlipController cardFlipController,
            ImageDownloader imageDownloader)
        {
            _downloadCardsSettings = downloadCardsSettings;
            _cardFlipController = cardFlipController;
            _imageDownloader = imageDownloader;

            URL = _downloadCardsSettings.URl;
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
                    var downloadImageTask = _imageDownloader.DownloadImageAsync(URL, cancellationToken);

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
                    var downloadImageTask = _imageDownloader.DownloadImageAsync(URL, cancellationToken);

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
                    var downloadImageTask = _imageDownloader.DownloadImageAsync(URL, cancellationToken);

                    await _cardFlipController.FlipCardAsync(card, CardSide.Back);
                    card.SetArt(await downloadImageTask);
                });
            await UniTask.WhenAll(downloadAndFlipBack);
            await UniTask.WhenAll(cards.Select(card =>
                _cardFlipController.FlipCardAsync(card, CardSide.Front)));
        }
    }
}