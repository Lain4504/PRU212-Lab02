using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float floatDelay = 2f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] GameManager gameManager;

    bool hasCrashed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground" && hasCrashed == false || collision.CompareTag("FallZone"))
        {
            hasCrashed = true;
            crashEffect.Play();
            GetComponent<AudioSource>().Play();
            FindFirstObjectByType<PlayerController>().DisableController();
            if (gameManager != null)
            {
                Invoke("ShowGameOver", floatDelay);
            }
            else
            {
                Invoke("ReloadLevel", floatDelay);
            }
        }
    }
    void ShowGameOver()
    {
        gameManager.GameOver();
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
