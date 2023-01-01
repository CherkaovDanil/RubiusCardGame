using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace CardGame.Card
{
    public class CardFlipController
    {
        private readonly CardAnimationConfig _cardAnimationConfig;
       
        public CardFlipController(CardAnimationConfig cardAnimationConfig)
        {
            _cardAnimationConfig = cardAnimationConfig;
        }

        public async UniTask FlipCardAsync(CardView card, CardSide cardSide)
        {
            if (card.CardSide == cardSide)
            {
                return;
            }
            
            await FlipCard(card.transform, _cardAnimationConfig.Rotation);
            card.SetCardSide(cardSide);
            await FlipCard(card.transform, Vector3.zero);
        }
        private async UniTask FlipCard(Transform cardTransform, Vector3 rotationEndValue)
        {
            await cardTransform
                .DORotate(rotationEndValue, _cardAnimationConfig.Duration)
                .SetEase(_cardAnimationConfig.Ease)
                .AsyncWaitForCompletion();
        }
    }
}