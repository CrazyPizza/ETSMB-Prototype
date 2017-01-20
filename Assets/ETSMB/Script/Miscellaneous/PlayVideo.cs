using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(AudioSource))]

public class PlayVideo : MonoBehaviour {

    public MovieTexture movie;
    public string nextScene;

	void Start () {
        GetComponent<RawImage>().texture = movie as MovieTexture;
        movie.Play();
        StartCoroutine("waitForMovieEnd");
    }

    IEnumerator waitForMovieEnd() {
        while (movie.isPlaying) {
            yield return new WaitForEndOfFrame();
        }
        onMovieEnded();
    }

    void onMovieEnded() {
        SceneManager.LoadScene(nextScene);
    }

}
