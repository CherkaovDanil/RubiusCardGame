using System;
using System.Collections.Generic;
using UnityEngine;

namespace CardGame.Card.Configs
{
    [Serializable]
    public struct CardModel
    {
        public int ID;        
        public string Name;
        public string Discription;
        public Sprite FrontSprite;
        public Sprite BackSprite;
    }
    
    [CreateAssetMenu(fileName = "CardsConfig", menuName = "Cards/CardsConfig", order = 0)]
    public class CardsConfig : ScriptableObject
    {
        public int CountCard => countCard;
        
        [SerializeField] private CardModel[] cardModels;
        [SerializeField] private int countCard;

        private Dictionary<int, CardModel> _dict;
        
        [NonSerialized] private bool _isInited;

        public CardModel? Get(int id)
        {
            if(!_isInited)
            {
                Init();
            }
            
            if( _dict.ContainsKey(id))
            {
                return _dict[id];
            }

            Debug.LogError($"Model with id {id} not found, returned null");
            return null;
        }
        
        private void Init()
        {
            
            _dict = new Dictionary<int, CardModel>();
            foreach (var model in cardModels)
            {
                _dict.Add(model.ID, model);
            }
            _isInited = true;
        }
    }
}