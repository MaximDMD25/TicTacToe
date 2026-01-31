using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TicTacToeManager : MonoBehaviour
{
    int currentPlayer = 0;
    int clicks = 0;
    bool gameended = false;
    public TextMeshProUGUI playerText;
    public TextMeshProUGUI[] fieldButtons;
    private AudioSource audioSource;
    public AudioClip winClip;

    void Start()
    {
        playerText.text = "Spieler X";
        audioSource = GetComponent<AudioSource>();
    }

    public void OnButtonClickedInManager(FieldButton fieldButton)
    {
        if (gameended)
            return;
        clicks++;
        fieldButton.SetField(currentPlayer);

        currentPlayer = currentPlayer == 1 ? 0 : 1;



        if (currentPlayer == 0)

            playerText.text = "Spieler X";

        else
            playerText.text = "Spieler 0";

        CheckWinningConditions();

    }

    public void CheckWinningConditions()
    {

        if (fieldButtons[0].text != string.Empty && fieldButtons[0].text.Equals(fieldButtons[1].text) && fieldButtons[0].text.Equals(fieldButtons[2].text))
        {
            Winner();
            WinnerButtons(fieldButtons[0], fieldButtons[1], fieldButtons[2]);
        }

        else if(fieldButtons[3].text != string.Empty && fieldButtons[3].text.Equals(fieldButtons[4].text) && fieldButtons[3].text.Equals(fieldButtons[5].text))
        {
            Winner();
            WinnerButtons(fieldButtons[3], fieldButtons[4], fieldButtons[5]);
        }
        else if(fieldButtons[6].text != string.Empty && fieldButtons[6].text.Equals(fieldButtons[7].text) && fieldButtons[6].text.Equals(fieldButtons[8].text))
        {
            Winner();
            WinnerButtons(fieldButtons[6], fieldButtons[7], fieldButtons[8]);
        }
        else if(fieldButtons[0].text != string.Empty && fieldButtons[0].text.Equals(fieldButtons[4].text) && fieldButtons[0].text.Equals(fieldButtons[8].text))
        {
            Winner();
            WinnerButtons(fieldButtons[0], fieldButtons[4], fieldButtons[8]);
        }
        else if(fieldButtons[2].text != string.Empty && fieldButtons[2].text.Equals(fieldButtons[4].text) && fieldButtons[2].text.Equals(fieldButtons[6].text))
        {
            Winner();
            WinnerButtons(fieldButtons[2], fieldButtons[4], fieldButtons[6]);
        }
        else if(fieldButtons[0].text != string.Empty && fieldButtons[0].text.Equals(fieldButtons[1].text) && fieldButtons[0].text.Equals(fieldButtons[2].text))
        {
            Winner();
            WinnerButtons(fieldButtons[0], fieldButtons[1], fieldButtons[2]);
        }
        else if(fieldButtons[0].text != string.Empty && fieldButtons[0].text.Equals(fieldButtons[3].text) && fieldButtons[0].text.Equals(fieldButtons[6].text))
        {
            Winner();
            WinnerButtons(fieldButtons[0], fieldButtons[4], fieldButtons[6]);
        }
        else if(fieldButtons[1].text != string.Empty && fieldButtons[1].text.Equals(fieldButtons[4].text) && fieldButtons[1].text.Equals(fieldButtons[7].text))
        {
            Winner();
            WinnerButtons(fieldButtons[1], fieldButtons[4], fieldButtons[7]);
        }
        else if(fieldButtons[2].text != string.Empty && fieldButtons[2].text.Equals(fieldButtons[5].text) && fieldButtons[2].text.Equals(fieldButtons[8].text))
        {
            Winner();
            WinnerButtons(fieldButtons[2], fieldButtons[5], fieldButtons[8]);
        }
        else if(clicks == 9)
        {
            NoWinner();
        }
        else
            return;

    }

    private void WinnerButtons(TextMeshProUGUI textMeshProUGUI1, TextMeshProUGUI textMeshProUGUI2, TextMeshProUGUI textMeshProUGUI3)
    {
        textMeshProUGUI1.color = Color.red;
        textMeshProUGUI1.transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 1, 2, 1);
        textMeshProUGUI1.transform.DOShakeScale(4f, 2, 2);

        textMeshProUGUI2.color = Color.red;
        textMeshProUGUI2.transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 1, 2, 1);
        textMeshProUGUI2.transform.DOShakeScale(4f, 2, 2);

        textMeshProUGUI3.color = Color.red;
        textMeshProUGUI3.transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 1, 2, 1);
        textMeshProUGUI3.transform.DOShakeScale(4f, 2, 2);


    }

    private void Winner()
    {
        gameended = true;
        audioSource.PlayOneShot(winClip, 1f);
        if (currentPlayer == 1)

            playerText.text = "Spieler X hat gewonnen";

        else
            playerText.text = "Spieler 0 hat gewonnen";
        playerText.transform.DOShakeScale(5f,2,3);
        playerText.transform.DOShakePosition(5, 2,3);
    }
 
    
    
    private void NoWinner()
    {
        playerText.text = "Unentschieden";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}