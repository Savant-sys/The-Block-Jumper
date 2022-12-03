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
    sceneManager.LoadSCENE("MENU");

}
public void QuitGame()
{
    Debug.log("quitting game....")
}
    private void start()
{
    Play("Maintheme");
}
public void Play(string sound)
{
    sound s = Array.Find(sounds, item => itme.name == sound);
    if(s==null)
    {
        Debug.loginWarning("sound:" + name + "not found");
        return;
    }
    s.source.volume = s.volume*(if +UnityEgine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f)) ;
    s.source.pitch = s.volume * (if +UnityEgine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f)) ;
     
    if(PauseMenu.GameIsPaused)
    {

    }