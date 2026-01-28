using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using Unity.VisualScripting;// Required when using Event data.


public class FieldButton : MonoBehaviour, IPointerEnterHandler
{
    private TicTacToeManager ticTacToeManager;
    private bool hasbeenclicked = false;
    private Button button;
    private AudioSource audioSource;
    public AudioClip hoverClip;
    public AudioClip pressedClip;
    public AudioClip disabledClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ticTacToeManager = FindFirstObjectByType<TicTacToeManager>();
        button = GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hasbeenclicked)
            return;
        audioSource.PlayOneShot(hoverClip, 0.6f);
        
    }

    public void OnButtonClicked()
    {
        if (hasbeenclicked)
        {
            audioSource.PlayOneShot(disabledClip, 1f);
            return;
        }
        
        audioSource.PlayOneShot(pressedClip, 1f);
        ticTacToeManager.OnButtonClickedInManager(this);
        transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 1, 2, 1);
        transform.DOPunchRotation(new Vector3(15, 15,15), 1, 5, 2);
        hasbeenclicked = true;
        //button.enabled = false;
    }

    public void SetField(int currentPlayer)
    {
        GetComponentInChildren<TextMeshProUGUI>().text = currentPlayer == 0 ? "X" : "O";

        // Die obere Zeile verwendet den sog. ternary operator und erwirkt
        // exakt das gleiche Ergebnis wie die unteren 13 Zeilen, nur kürzer

        //TextMeshProUGUI textField = GetComponentInChildren<TextMeshProUGUI>();

        //string symbol;
        //if(currentPlayer == 0)
        //{
        //    symbol = "X";
        //}
        //else
        //{
        //    symbol ="O";
        //}

        //textField.text = symbol;
    }
}