using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviour
{
    #region Panels
    public GameObject gameObject_panel_firstPanel;
    #endregion

    #region Buttons
    public GameObject gameObject_button_pause;
    public GameObject gameObject_button_characterJump;
    //public Button button_resume;
    #endregion

    #region Scripts
    public CharacterControler script_CharacterControler; 
    #endregion

    // Buttons Click
    #region ButtonClicks
    public void restartGameScene()
    {
        gameObject_panel_firstPanel.SetActive(true);
        gameObject_button_pause.SetActive(false);
    }
    public void pauseGame()
    {
        Debug.Log("Paused");
        gameObject_button_pause.SetActive(false);
        gameObject_panel_firstPanel.SetActive(true);
        script_CharacterControler.de_run();
    }

    public void resumeGame()
    {
        gameObject_panel_firstPanel.SetActive(false);
        gameObject_button_pause.SetActive(true);
        gameObject_button_characterJump.SetActive(true);
        script_CharacterControler.run();
        // Resume Game
    }

    public void playGame()
    {
        gameObject_panel_firstPanel.SetActive(false);
        gameObject_button_pause.SetActive(true);
        gameObject_button_characterJump.SetActive(true);
        script_CharacterControler.run();
        // Play Game
    }
    #endregion
}
