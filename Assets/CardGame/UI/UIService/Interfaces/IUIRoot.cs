using UnityEngine;

namespace CardGame.UI
{
    public interface IUIRoot
    {
        Canvas Canvas { get; set; }

        Camera Camera { get; set; }

        Transform Container { get; }
        Transform PoolContainer { get; }
    }
}