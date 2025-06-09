using UnityEngine;
using TMPro;
using System.Collections;

public class KeypadController : MonoBehaviour
{
    public TMP_Text inputText;
    public string correctCode = "1234";
    public GameObject keypadUI;
    public GameObject doorToOpen;

    private string currentInput = "";
    private bool isProcessing = false;

    public void ButtonPressed(string number)
    {
        if (currentInput.Length < 6 && !isProcessing)
        {
            currentInput += number;
            inputText.text = currentInput;
        }
    }

    public void ClearInput()
    {
        currentInput = "";
        inputText.text = "";
    }

    public void EnterCode()
    {
        if (!isProcessing)
        {
            StartCoroutine(ProcessCode());
        }
    }

    private IEnumerator ProcessCode()
    {
        isProcessing = true;

        if (currentInput == correctCode)
        {
            inputText.text = "Kode Benar!";
            Debug.Log("Kode benar!");

            if (doorToOpen != null)
            {
                doorToOpen.SetActive(false);
            }

            yield return new WaitForSeconds(1f);
            CloseKeypad(); // Ini akan reset juga
        }
        else
        {
            inputText.text = "Kode Salah!";
            Debug.Log("Kode salah!");

            yield return new WaitForSeconds(1f);
            ClearInput(); // Kosongkan input dan text
            isProcessing = false; // Aktifkan input lagi setelah selesai
        }
    }

    public void CloseKeypad()
    {
        ClearInput(); // reset input saat ditutup
        keypadUI.SetActive(false);
        Time.timeScale = 1f;
        isProcessing = false; // jaga-jaga supaya benar-benar bisa input lagi
    }
}
