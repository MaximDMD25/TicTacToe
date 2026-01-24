using TMPro;
using UnityEngine;

public class FieldButton : MonoBehaviour
{
    private TicTacToeManager ticTacToeManager;
    private bool hasbeenclicked = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ticTacToeManager = FindFirstObjectByType<TicTacToeManager>();
    }

    public void OnButtonClicked()
    {
        if (hasbeenclicked)
            return;
        ticTacToeManager.OnButtonClickedInManager(this);
        hasbeenclicked = true;
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