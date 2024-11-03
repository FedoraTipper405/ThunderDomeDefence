using UnityEngine;

public class InputController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created 
    [SerializeField] PlayerController playerController;
    void Start()
    {
        GameControls gameControls = new GameControls();
        gameControls.Mouse.MousePosition.performed += (var) => playerController.HandleMousePos(var.ReadValue<Vector2>());
        gameControls.Mouse.MouseLeftClick.performed += (var) => playerController.HandleMouseClicked();
        gameControls.Mouse.MouseLeftClick.canceled += (var) => playerController.HandleMouseReleased();
        gameControls.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
