using UnityEngine;

public class InputController : MonoBehaviour
{

    [SerializeField] private PlayerController playerController;
    private GameControls gameControls;

    private void Awake() => gameControls = new GameControls();

    void OnEnable()
    {
        gameControls.Mouse.MousePosition.performed += (var) => playerController.HandleMousePos(var.ReadValue<Vector2>());
        gameControls.Mouse.MouseLeftClick.performed += (var) => playerController.HandleMouseClicked();
        gameControls.Enable();
    }
    void OnDisable()
    {

        gameControls.Mouse.MousePosition.performed -= (var) => playerController.HandleMousePos(var.ReadValue<Vector2>());
        gameControls.Mouse.MouseLeftClick.performed -= (var) => playerController.HandleMouseClicked();
        gameControls.Disable();
    }

}
