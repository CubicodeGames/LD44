using UnityEngine;

public class Pickup : MonoBehaviour
{
    public string pickupName;

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((pickupName == "Heart" && other.tag == "Coin") ||
            (pickupName == "Coin" && other.tag == "Heart"))
        {
            Character c = other.GetComponent<Character>();
            c.Pickup();

            Destroy(gameObject);
        }
        else if (pickupName == "Key")
        {
            Character c = other.GetComponent<Character>();
            c.PickupKey();

            Destroy(gameObject);
        }
    }
}
