using UnityEngine;

public class Coin : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0f, 100f, 0f) * Time.deltaTime);
    }
}