using System;
using System.Collections.Generic;
using UnityEngine;

namespace CardGame.Card
{
    [Serializable]
    public struct CardModel
    {
        public int ID;        
        public string Name;
        public string Discription;
        public Sprite FaceSprite;
        public Sprite BackSprite;        
    }
    
    [CreateAssetMenu(fileName = "CardsConfig", menuName = "Cards/CardsConfig", order = 0)]
    public class CardConfig : ScriptableObject
    {
        [SerializeField] private CardModel[] cardModels;
        
        private Dictionary<int, CardModel> _dict;
        
        private bool _dictionaryIsInited;
        
        public CardModel? Get(int id)
        {
            if(!_dictionaryIsInited)
            {
                Init();
            }
            
            if(_dict.ContainsKey(id))
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
            _dictionaryIsInited = true;
        }
    }
}