using UnityEngine;

/// <summary> Class <c>MainMenuFunctionality</c> UI Main Menu Logic </summary>
public class MainMenuFunctionality : MonoBehaviour
{
    [SerializeField] Canvas openingScene = default;
    [SerializeField] GameConfig config = default;

    void Start() => config.ChangeCursorBackToOrignalCursor();   
    
    public void StartGame()
    {
        //launch game
        config.ChangeCursorToHandSymbol();
        openingScene.gameObject.SetActive(true);
        gameObject.SetActive(false);            
    }

    public void EndGame() => Application.Quit();
}
