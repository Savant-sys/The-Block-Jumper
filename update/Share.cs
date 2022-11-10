using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Share : MonoBehaviour
{
    private string shareMessage;

    public void ShareButton()
    {
        int score = 10; // Temporary Score before added score
        shareMessage = "I can't believe I climbed " + score.ToString() + " feet in BlockJumper!";
        StartCoroutine(TakeScreenshotAndShare());
    }
    private IEnumerator TakeScreenshotAndShare()
    {
        yield return new WaitForEndOfFrame();

        Texture2D screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenshot.Apply();

        Destroy(screenshot);

        new NativeShare().AddFile(filePath)
            .SetSubject("Block Jumper").SetText(shareMessage))
            .Share();

    }
}
