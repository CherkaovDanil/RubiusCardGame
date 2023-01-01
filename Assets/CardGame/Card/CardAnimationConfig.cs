using DG.Tweening;
using UnityEngine;

namespace CardGame.Card
{
    [CreateAssetMenu(fileName = "CardsAnimationConfig", menuName = "Cards/CardsAnimationConfig", order = 1)]
    public class CardAnimationConfig : ScriptableObject
    {        
        public float Duration => duration;
        public Ease Ease => ease;
        public Vector3 Rotation => rotation;
        
        [SerializeField] private float duration;
        [SerializeField] private Ease ease;
        [SerializeField] private Vector3 rotation;
    }
}