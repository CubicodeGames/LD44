using UnityEngine;

public class Ground : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Heart" || other.tag == "Coin")
        {
            GameManager.Instance.GameOver(string.Empty);
        }
    }
}
