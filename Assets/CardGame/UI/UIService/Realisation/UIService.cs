using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CardGame.UI
{
     public class UIService : IUIService
    {
        private readonly IUIRoot _uIRoot;
        private readonly IInstantiator _instantiator;
        private Transform _deactivatedContainer;
        private readonly Dictionary<Type,UIWindow> _viewStorage = new Dictionary<Type,UIWindow>();
        private readonly Dictionary<Type, GameObject> _initWindows= new Dictionary<Type, GameObject>();

        public UIService(
            IInstantiator instantiator,
            IUIRoot uIRoot)
        {

            _instantiator = instantiator;
            _uIRoot = uIRoot;
        }

        public T Show<T>(Transform parent = null) where T : UIWindow
        {
            var window = Get<T>();
            if(window != null)
            {
                if (parent != null)
                {
                    window.transform.SetParent(parent, false);
                    window.transform.localScale = Vector3.one;
                    window.transform.localRotation = Quaternion.identity;
                    window.transform.localPosition = Vector3.zero;
                }
                else
                {
                    window.transform.SetParent(_uIRoot.Container, false);
                }

                var component = window.GetComponent<T>();

                var rect = component.transform as RectTransform;
                if (rect != null)
                {
                    rect.offsetMax = Vector2.zero;
                    rect.offsetMin = Vector2.zero;
                }
                
                component.Show();
                return component;
            }
            return null;
        }

        public void Hide<T>(Action onEnd = null) where T : UIWindow
        {
            throw new NotImplementedException();
        }

        public T Get<T>() where T : UIWindow
        {
            var type = typeof(T);
            if (_initWindows.ContainsKey(type))
            {
                var view = _initWindows[type];            
                return view.GetComponent<T>();
            }
            return null;
        }

        public void InitWindows(Transform poolDeactiveContiner = null)
        {
            _deactivatedContainer = poolDeactiveContiner == null ? _uIRoot.PoolContainer : poolDeactiveContiner;
            foreach (var windowKVP in _viewStorage)
            {
                Init(windowKVP.Key, _deactivatedContainer);
            }
        }

        public void LoadWindows(string source)
        {
            var windows = Resources.LoadAll(source, typeof(UIWindow));

            foreach (var window in windows)
            {
                var windowType = window.GetType();
                _viewStorage.Add(windowType, (UIWindow) window);
            }
        }    
    
        private void Init(Type t, Transform parent = null)
        {
            if(_viewStorage.ContainsKey(t))
            {
                GameObject view = null;
                if(parent!=null)
                {
                    view = _instantiator.InstantiatePrefab(_viewStorage[t], parent);
                }
                else
                {
                    view = _instantiator.InstantiatePrefab(_viewStorage[t]);
                }
                _initWindows.Add(t, view);
            }
        }
    }
}