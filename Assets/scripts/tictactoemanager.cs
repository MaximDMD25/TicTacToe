using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TicTacToeManager : MonoBehaviour
{
    int currentPlayer = 0;
    int clicks = 0;
    bool gameended = false;
    public TextMeshProUGUI playertext;
    public TextMeshProUGUI[] fieldButtons;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playertext.text = "Spieler X";
    }

    public void OnButtonClickedInManager(FieldButton fieldButton)
    {
        //Debug.Log("JUHU ICH WURDE IM MANAGER GEKLICKT!!!11");
        if (gameended)
            return;
        clicks++;
        fieldButton.SetField(currentPlayer);

        currentPlayer = currentPlayer == 1 ? 0 : 1;

        

        if (currentPlayer == 0)

            playertext.text = "Spieler X";

        else
            playertext.text = "Spieler 0";

        checkwinningconditions();
        
    }

    public void checkwinningconditions()
    {
        
        //if (fieldButtons[0].text == fieldButtons[1].text && fieldButtons[0].text == fieldButtons[3].text)
        if (fieldButtons[0].text != string.Empty && fieldButtons[0].text.Equals(fieldButtons[1].text) && fieldButtons[0].text.Equals(fieldButtons[2].text))
            winner();
        if (fieldButtons[3].text != string.Empty && fieldButtons[3].text.Equals(fieldButtons[4].text) && fieldButtons[3].text.Equals(fieldButtons[5].text))
            winner();
        if (fieldButtons[6].text != string.Empty && fieldButtons[6].text.Equals(fieldButtons[7].text) && fieldButtons[6].text.Equals(fieldButtons[8].text))
            winner();
        if (fieldButtons[0].text != string.Empty && fieldButtons[0].text.Equals(fieldButtons[4].text) && fieldButtons[0].text.Equals(fieldButtons[8].text))
            winner();
        if (fieldButtons[2].text != string.Empty && fieldButtons[2].text.Equals(fieldButtons[4].text) && fieldButtons[2].text.Equals(fieldButtons[6].text))
            winner();
        if (fieldButtons[0].text != string.Empty && fieldButtons[0].text.Equals(fieldButtons[1].text) && fieldButtons[0].text.Equals(fieldButtons[2].text))
            winner();
        if (fieldButtons[0].text != string.Empty && fieldButtons[0].text.Equals(fieldButtons[3].text) && fieldButtons[0].text.Equals(fieldButtons[6].text))
            winner();
        if (fieldButtons[1].text != string.Empty && fieldButtons[1].text.Equals(fieldButtons[4].text) && fieldButtons[1].text.Equals(fieldButtons[7].text))
            winner();
        if (fieldButtons[2].text != string.Empty && fieldButtons[2].text.Equals(fieldButtons[5].text) && fieldButtons[2].text.Equals(fieldButtons[8].text))
            winner();
        if (clicks == 9)
            nowinner();
        else
            return;

    }
    private void winner()
    {
        gameended = true;
        if (currentPlayer == 1)

            playertext.text = "Spieler X hat gewonnen";

        else
            playertext.text = "Spieler 0 hat gewonnen";
    }
    private void nowinner()
    {
        playertext.text = "Unentschieden";
    }
        
}