using UnityEngine;
using TMPro;

public class SkorManager : MonoBehaviour
{
    public static SkorManager instance;
    public TextMeshProUGUI textSkor;

    // Pastikan tulisannya 'public int skor', bukan 'private int skor'
    public int skor = 0;

    void Awake()
    {
        instance = this;
    }

    public void TambahSkor(int nilai)
    {
        skor += nilai;
        textSkor.text = skor.ToString();
    }
}