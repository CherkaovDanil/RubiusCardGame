using DG.Tweening;
using UnityEngine;

namespace CardGame.Card
{
    [CreateAssetMenu(fileName = "CardsAnimationConfig", menuName = "Cards/CardsAnimationConfig", order = 1)]
    public class CardAnimationConfig : ScriptableObject
    {        
        public float Speed => speed;
        public Ease Ease => ease;
        public Vector3 Rotation => rotation;
        
        [SerializeField] private float speed;
        [SerializeField] private Ease ease;
        [SerializeField] private Vector3 rotation;
    }
}