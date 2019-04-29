using UnityEngine;

public class TradingPlatform : MonoBehaviour
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
    }
}
