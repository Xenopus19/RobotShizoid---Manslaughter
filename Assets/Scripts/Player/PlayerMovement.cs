using UnityEngine;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public bool IsWalking = false;
    [SerializeField] private List<float> EdgeOfArena = new List<float>();

    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioSource;

    public void Move(MoveType moveType = MoveType.Stand)
    {
        if (moveType == MoveType.Up && transform.localPosition.z < EdgeOfArena[0] - 0.1f)
            Walk(Vector3.forward, "IsUp");
        if (moveType == MoveType.Down && transform.localPosition.z > EdgeOfArena[1] + 0.1f)
            Walk(Vector3.back, "IsDown");
        if (moveType == MoveType.Right && transform.localPosition.x < EdgeOfArena[2] - 0.1f)
            Walk(Vector3.right, "IsRight");
        if (moveType == MoveType.Left && transform.localPosition.x > EdgeOfArena[3] + 0.1f)
            Walk(Vector3.left, "IsLeft");

        if (moveType == MoveType.Stand) Stand();
    }

    private void Walk(Vector3 direction, string anim)
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
        IsWalking = true;
        _animator.SetBool(anim, true);
        if (!_audioSource.isPlaying)
            _audioSource.Play();
    }

    private void Stand()
    {
        _animator.SetBool("IsUp", false);
        _animator.SetBool("IsDown", false);
        _animator.SetBool("IsRight", false);
        _animator.SetBool("IsLeft", false);
        if (_audioSource.isPlaying)
            _audioSource.Stop();
    }
}
public enum MoveType
{
    Up,
    Down,
    Right,
    Left,
    Stand
}