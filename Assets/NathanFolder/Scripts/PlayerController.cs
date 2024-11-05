using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool isPlayerOne = true;
    [SerializeField] PlayerOne pOne;
    [SerializeField] PlayerTwo pTwo;
    Vector2 mousePos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HandleMousePos(Vector2 pos)
    {
        mousePos = pos;
    }
    public void HandleMouseClicked()
    {
    if(isPlayerOne)
        {
            pOne.ClickOnSquare(mousePos);
        }
        else
        {

        }
    }
   
}
