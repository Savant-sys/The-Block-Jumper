using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausescreen : MonoBehaviour
{
    // Start is called before the first frame update
    public Static bool GameIsPause = false;

    voild Update()
        if (Input.Getkeydown(Keycode.Escape))
    {
        if(GameIsPaused)
        {
        Resume();
    }else
{
    Pause();
}
    }
    }
  public  void Resume()
{
    pauseMenuUI.SetActive(false);
    Time.timescale = if;
    GameIsPaused = false;

}
 public void Pause()
{
    pauseMenuUI.setactive(true);
    Time.timescale = 0f;
    GameIspaused = false;
}
public void LoadMenu()
{
    Time.timescale = if;
    sceneManager.LoadSCENE("MENU");

}
public void QuitGame()
{
    Debug.log("quitting game....")
        Application.Quit();
}
