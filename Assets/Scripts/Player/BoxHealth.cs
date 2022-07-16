using UnityEngine;

public class BoxHealth : MonoBehaviour {
    public float RecoverHealthAmount;
    private void OnCollisionEnter(Collision collision) 
    {
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth != null) 
        {
            playerHealth.RecoverHealth(RecoverHealthAmount);

            Destroy(gameObject);
        }
    }
}
