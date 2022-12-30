using UnityEngine;

namespace CardGame.Card
{
    public readonly struct CardViewProtocol
    {
        public readonly string Name;
        public readonly string Discription;
        public readonly Sprite FrontSprite;
        public readonly Sprite BackSprite;
    
        public CardViewProtocol(
            string name,
            string discription,
            Sprite faceSprite,
            Sprite backSprite)
        {
            Name = name;
            Discription = discription;
            FrontSprite = faceSprite;
            BackSprite = backSprite;
        }
    }
}