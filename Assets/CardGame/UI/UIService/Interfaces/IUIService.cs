using UnityEngine;
using System;

namespace CardGame.UI
{
    public interface IUIService
    {
        T Show<T>(Transform transform = null) where T : UIWindow;

        void Hide<T>(Action onEnd = null) where T : UIWindow;

        T Get<T>() where T : UIWindow;

        void InitWindows(Transform poolDeactiveContiner = null);

        void LoadWindows(string source);
    }
}