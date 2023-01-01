using UnityEngine;

namespace CardGame.SceneObjects
{
    public class MainCamera : SceneObject
    {
        public Camera Camera => camera;

        [SerializeField] private Camera camera;
    }
}
