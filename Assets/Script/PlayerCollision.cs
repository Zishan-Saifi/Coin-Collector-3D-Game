using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Jab Player Coin ko touch karega
        if (other.CompareTag("Coin"))
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.AddScore(); // Score 1 badhayega
            }
            
            Destroy(other.gameObject); // Coin ko scene se hata/gayab kar dega
        }
        // Jab Player Enemy ko touch karega
        else if (other.CompareTag("Enemy"))
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.TriggerGameOver(); // Game Over screen dikhayega
            }
        }
    }
}

