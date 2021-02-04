using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Video : MonoBehaviour
{
    public VideoPlayer VideoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        VideoPlayer.loopPointReached += LoadScene;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            VideoPlayer.Stop();
            SceneManager.LoadScene("SampleScene");
        }
    }

    void LoadScene(VideoPlayer vp)
    {
        SceneManager.LoadScene("SampleScene");
    }
}
