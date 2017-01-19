using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(AudioSource))]

public class PlayVideo : MonoBehaviour {

    public MovieTexture movie;

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
        Debug.Log("Movie ended");
        SceneManager.LoadScene("ProvaCombattimento");
    }

}
