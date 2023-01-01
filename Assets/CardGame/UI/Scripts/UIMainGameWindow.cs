using CardGame.Card;
using CardGame.UI;
using Cysharp.Threading.Tasks;
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

    private CardController _cardController;

    [Inject]
    private void Inject(CardController cardController)
    {
       _cardController = cardController;
    }
    
    public override void Show()
    {
        dropdown.onValueChanged.AddListener(DropdownChange); 
        loadButton.onClick.AddListener(LoadButtonClick);
        cancelButton.onClick.AddListener(CancelButtonClick);
        
        _cardController.SpawnAllCards(cardContainer);
    }

    public override void Hide()
    {
        dropdown.onValueChanged.RemoveListener(DropdownChange); 
        loadButton.onClick.RemoveListener(LoadButtonClick);
        cancelButton.onClick.RemoveListener(CancelButtonClick);
    }

    private void LoadButtonClick()
    {
        LoadImage();
    }

    private async UniTask LoadImage()
    {
        SetInteractable(false);
        await _cardController.StartDownload();
        SetInteractable(true);
    }
    
    private void CancelButtonClick()
    {
        _cardController.CancelDownload();
    }

    private void DropdownChange(int value)
    {
        _cardController.ChangeDownloadType(value);
    }

    private void SetInteractable(bool value)
    {
        dropdown.interactable = value;
        loadButton.interactable = value;
        cancelButton.interactable = !value;
    }
}
