using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using Unity.VisualScripting;// Required when using Event data.


public class FieldButton : MonoBehaviour, IPointerEnterHandler
{
    private TicTacToeManager ticTacToeManager;
    private bool hasBeenClicked = false;
    private AudioSource audioSource;
    public AudioClip hoverClip;
    public AudioClip pressedClip;
    public AudioClip disabledClip;

    void Start()
    {
        ticTacToeManager = FindFirstObjectByType<TicTacToeManager>();
        audioSource = GetComponent<AudioSource>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hasBeenClicked)
            return;
        audioSource.PlayOneShot(hoverClip, 0.6f);
        
    }

    public void OnButtonClicked()
    {
        if (hasBeenClicked)
        {
            audioSource.PlayOneShot(disabledClip, 1f);
            return;
        }
        
        audioSource.PlayOneShot(pressedClip, 1f);
        ticTacToeManager.OnButtonClickedInManager(this);
        transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 1, 2, 1);
        transform.DOPunchRotation(new Vector3(15, 15,15), 1, 5, 2);
        hasBeenClicked = true;
    }

    public void SetField(int currentPlayer)
    {
        GetComponentInChildren<TextMeshProUGUI>().text = currentPlayer == 0 ? "X" : "O";
    }
}