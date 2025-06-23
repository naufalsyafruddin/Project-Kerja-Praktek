using UnityEngine;
using UnityEngine.UI;

public class MusicToggle : MonoBehaviour
{
    public AudioSource lobbyMusic;      // drag AudioSource musik ke sini
    public Sprite musicOnSprite;        // ikon saat musik menyala
    public Sprite musicOffSprite;       // ikon saat musik mati
    public Image toggleButtonImage;     // Image komponen dari tombol

    private bool isMusicOn = true;

    void Start()
    {
        // Musik mulai menyala saat scene dibuka
        if (lobbyMusic != null)
            lobbyMusic.Play();

        UpdateIcon();
    }

    public void ToggleMusic()
    {
        isMusicOn = !isMusicOn;

        if (lobbyMusic != null)
        {
            if (isMusicOn)
                lobbyMusic.Play();
            else
                lobbyMusic.Pause();
        }

        UpdateIcon();
    }

    private void UpdateIcon()
    {
        if (toggleButtonImage != null)
        {
            toggleButtonImage.sprite = isMusicOn ? musicOnSprite : musicOffSprite;
        }
    }
}
