using UnityEngine;
using System.Collections.Generic;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    [SerializeField] private List<float> EdgeOfArena = new List<float>();
    void Update()
    {
        CheckMove();
    }
    public void CheckMove() {
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.z < EdgeOfArena[0] - 0.1f)
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.DownArrow) && transform.position.z > EdgeOfArena[1] + 0.1f)
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < EdgeOfArena[2] - 0.1f)
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > EdgeOfArena[3] + 0.1f)
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }
}
