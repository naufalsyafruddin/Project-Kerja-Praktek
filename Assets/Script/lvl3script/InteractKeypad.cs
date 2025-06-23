using UnityEngine;
using TMPro;
using System.Collections;

public class PuzzleKeypadController : MonoBehaviour
{
    [Header("UI References")]
    public GameObject keypadUI;
    public TMP_Text inputDisplay;
    public TMP_Text feedbackDisplay;

    [Header("Kode Puzzle")]
    public string correctCode = "1234";
    private string currentInput = "";
    private bool isInteracting = false;
    private bool isProcessing = false;

    [Header("Zona Next Level")]
    public NextLevelZone nextLevelZone;

    private bool isPlayerInRange = false; // ← Tambahan

    void Update()
    {
        // Hanya bisa berinteraksi jika player di dekat puzzle
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E) && !isInteracting)
        {
            OpenKeypad();
        }
    }

    public void AddNumber(string number)
    {
        if (isProcessing || currentInput.Length >= 9) return;

        currentInput += number;
        inputDisplay.text = currentInput;
    }

    public void ClearInput()
    {
        currentInput = "";
        inputDisplay.text = "";
        feedbackDisplay.text = "";
    }

    public void SubmitCode()
    {
        if (isProcessing) return;
        StartCoroutine(CheckCode());
    }

    IEnumerator CheckCode()
    {
        isProcessing = true;

        if (currentInput == correctCode)
        {
            feedbackDisplay.text = "Kode Benar";
            Debug.Log("Kode benar! Mengaktifkan zona...");

            if (nextLevelZone != null)
            {
                nextLevelZone.EnableNextZone();
            }
            else
            {
                Debug.LogWarning("nextLevelZone belum di-assign!");
            }

            yield return new WaitForSeconds(1f);
            CloseKeypad();
        }
        else
        {
            feedbackDisplay.text = "Kode Salah";
            yield return new WaitForSeconds(1f);
            ClearInput();
        }

        isProcessing = false;
    }

    public void OpenKeypad()
    {
        isInteracting = true;
        keypadUI.SetActive(true);
        ClearInput();
    }

    public void CloseKeypad()
    {
        isInteracting = false;
        keypadUI.SetActive(false);
    }

    // ← Tambahkan trigger untuk area interaksi
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}
