using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public Text textField;
    public Texture2D cursorTexture;
    private int playerScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorTexture, new Vector2(32, 32), CursorMode.ForceSoftware);
    }

    public void addScore(int score)
    {
        playerScore += score;
        textField.text = "Score: " + playerScore.ToString();
    }
}
