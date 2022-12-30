using CardGame.Card;
using CardGame.Scripts;
using CardGame.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIMainGameWindow : UIWindow
{
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private Button loadButton;
    [SerializeField] private Button cancelButton;
    
    [SerializeField] private Transform cardContainer;

    private IInstantiator _instantiator; 
    [Inject]
    private void Inject(IInstantiator instantiator)
    {
        _instantiator = instantiator;
    }
    
    public override void Show()
    {
        var command =  _instantiator.Instantiate<tempCommand>();
        command.Execute();
    }

    public override void Hide()
    {
       
    }
}
