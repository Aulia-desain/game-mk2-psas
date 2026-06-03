using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class Carakter_1 : MonoBehaviour
{
    [Header("Pengaturan Pergerakan")]
    public float speed = 8f;
    public float jumpForce = 30f;
    public float fallMultiplier = 3f;

    [Header("Pengaturan UI Menang & Skor")]
    public TextMeshProUGUI skorTextDiAtas;
    public GameObject winPanel;
    public TextMeshProUGUI winSkorText;
    public TextMeshProUGUI winNyawaText;

    [Header("Pengaturan UI Nyawa / Hati")]
    public GameObject hati1; GameObject hati2; GameObject hati3;

    [Header("Pengaturan UI Kalah")]
    public GameObject losePanel;

    [Header("Pengaturan Sprite Pintu Terbuka")]
    public Sprite gambarPintuTerbuka;

    private static int sisaNyawa = 3;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private int jumlahBunga = 0;
    private bool bisaBergerak = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        if (winPanel != null) winPanel.SetActive(false);
        if (losePanel != null) losePanel.SetActive(false);
        if (skorTextDiAtas != null) skorTextDiAtas.gameObject.SetActive(true);
        UpdateTampilanUI();
    }

    void Update()
    {
        if (!bisaBergerak) return;
        float move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);
        if (move != 0) transform.position += new Vector3(move * speed * Time.deltaTime, 0, 0);
        if (move > 0) sprite.flipX = false; else if (move < 0) sprite.flipX = true;

        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        if (rb.linearVelocity.y < -0.1f) rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bunga"))
        {
            jumlahBunga++; UpdateTampilanUI(); Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Kunci"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Kaktus") && bisaBergerak)
        {
            sisaNyawa--;
            if (sisaNyawa <= 0)
            {
                bisaBergerak = false; rb.linearVelocity = Vector2.zero; UpdateTampilanUI(); if (losePanel != null) losePanel.SetActive(true);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        // --- BYPASS MODE: NABRAK PINTU LANGSUNG MENANG TANPA SYARAT KUNCI! ---
        if (other.gameObject.CompareTag("Pintu"))
        {
            bisaBergerak = false;
            rb.linearVelocity = Vector2.zero;

            SpriteRenderer pintuSprite = other.gameObject.GetComponent<SpriteRenderer>();
            if (pintuSprite != null && gambarPintuTerbuka != null) pintuSprite.sprite = gambarPintuTerbuka;

            StartCoroutine(TampilkanWinPanel());
        }
    }

    IEnumerator TampilkanWinPanel()
    {
        yield return new WaitForSeconds(0.4f);
        if (winPanel != null)
        {
            winPanel.SetActive(true);
            if (skorTextDiAtas != null) skorTextDiAtas.gameObject.SetActive(false);
            if (winSkorText != null) winSkorText.text = "Flower Skor : " + jumlahBunga;
            if (winNyawaText != null) winNyawaText.text = "Sisa Nyawa : " + sisaNyawa;
        }
    }

    void UpdateTampilanUI()
    {
        if (skorTextDiAtas != null) skorTextDiAtas.text = jumlahBunga.ToString();
        if (hati1 != null) hati1.SetActive(sisaNyawa >= 1);
        if (hati2 != null) hati2.SetActive(sisaNyawa >= 2);
        if (hati3 != null) hati3.SetActive(sisaNyawa >= 3);
    }

    public void MuatUlangLevel() { sisaNyawa = 3; SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
    public void BalikKeRumah(string namaSceneBeranda) { sisaNyawa = 3; SceneManager.LoadScene(namaSceneBeranda); }
    public void LanjutLevelBerikutnya(string namaLevelTujuan) { sisaNyawa = 3; SceneManager.LoadScene(namaLevelTujuan); }
}