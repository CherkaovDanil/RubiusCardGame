using CardGame;
using UnityEngine;

public class MainCamera : SceneObject
{
    public Camera Camera => camera;

    [SerializeField] private Camera camera;
}
