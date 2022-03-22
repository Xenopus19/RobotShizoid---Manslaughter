using UnityEngine;

public class ButtonState : MonoBehaviour {
    public Animator _animator;
    public GameObject image;
    void Start() => _animator = GetComponent<Animator>();
    public void StartAnimation() => _animator.SetBool("IsPointerEnter", true);
    public void FinishAnmation() => _animator.SetBool("IsPointerEnter", false);
    public void SetTransform() {
        if (gameObject.tag == "Blood") {
            float rand = Random.Range(-100, 100);
            image.transform.localPosition = new Vector3(rand, image.transform.localPosition.y, 0f);
        }
    }
}
