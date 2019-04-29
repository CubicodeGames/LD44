using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool BothIn
    {
        get
        {
            return _isHeartIn && _isCoinIn;
        }
    }

    private bool _isHeartIn = false;
    private bool _isCoinIn = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Heart")
        {
            _isHeartIn = true;
        }
        else if (other.tag == "Coin")
        {
            _isCoinIn = true;
        }

        Debug.Log($"Both in: {BothIn}");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Heart")
        {
            _isHeartIn = false;
        }
        else if (other.tag == "Coin")
        {
            _isCoinIn = false;
        }

        Debug.Log($"Both in: {BothIn}");
    }
}
