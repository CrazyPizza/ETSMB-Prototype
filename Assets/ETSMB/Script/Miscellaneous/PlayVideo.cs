using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(AudioSource))]

public class PlayVideo : MonoBehaviour {

    public MovieTexture movie;
    private AudioSource audio;

	void Start () {
        GetComponent<RawImage>().texture = movie as MovieTexture;
        audio = GetComponent<AudioSource>();
        audio.clip = movie.audioClip;
        movie.Play();
        audio.Play();
        StartCoroutine("waitForMovieEnd");
    }

    IEnumerator waitForMovieEnd() {
        while(movie.isPlaying) {
            yield return new WaitForEndOfFrame();
        }
        onMovieEnded();
    }

    void onMovieEnded() {
        Debug.Log("Movie ended");
        SceneManager.LoadScene("ProvaCombattimento");
    }

}
