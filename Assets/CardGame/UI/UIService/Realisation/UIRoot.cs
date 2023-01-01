using UnityEngine;

namespace CardGame.UI.Realisation
{
    public class UIRoot : MonoBehaviour, IUIRoot
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private Camera camera;
        [SerializeField] private Transform initContainer;
        [SerializeField] private Transform poolContainer;

        public Canvas Canvas
        {
            get => canvas;
            set => canvas = value;
        }
        
        public Camera Camera
        {
            get => camera;
            set => camera = value;
        }

        public Transform Container => initContainer;

        public Transform PoolContainer => poolContainer;
    }
}