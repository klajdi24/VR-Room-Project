using UnityEngine;

public class MoveTracker : MonoBehaviour
{
    public static bool moveMade = false;

    public void RegisterMove()
    {
        if (!moveMade)
        {
            moveMade = true;
            Debug.Log("You made the winning move!");
            // You can trigger win UI or animations here.
        }
    }
}
