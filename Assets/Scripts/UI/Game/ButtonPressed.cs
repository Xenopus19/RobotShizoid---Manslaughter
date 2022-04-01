using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    [SerializeField] private MoveType buttonMoveType;
    private PlayerMovement Movement;
    private MoveType moveType = MoveType.Stand;

    private static MoveType PressedButtonMoveType;

    private void Start() {
        Movement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    public void OnPointerDown(PointerEventData eventData) {
        PressedButtonMoveType = buttonMoveType;
        moveType = buttonMoveType;
    }

    public void OnPointerUp(PointerEventData eventData) {
        PressedButtonMoveType = buttonMoveType;
        moveType = MoveType.Stand;
    }

    private void Update() {
        if (buttonMoveType == PressedButtonMoveType && buttonMoveType != MoveType.Stand)
            Movement.Move(moveType);
    }
}