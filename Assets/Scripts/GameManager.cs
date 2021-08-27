using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Google.Play.Review;
using TMPro;

public class GameManager : MonoBehaviour
{
    public  GameObject GameOver;
    public  GameObject Play;
    public GameObject Pause;
    public GameObject ScorePanel;
    private ReviewManager _reviewManager;
    private PlayReviewInfo _playReviewInfo;

    public GameObject[] BlueGO;
    public GameObject[] OrangeGO;
    //To instantiate squate and circle
    public float startWait;
    public float spawnWait;
    //which GO to Instantiate
    GameObject Blue, Orange;

    //spawn point spawn randomly X pos
    float[] XPosition = new float[2] { 1.25f, 3.9f };


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    public void Jugar()
    {
        Play.SetActive(false);
        ScorePanel.SetActive(true);
        Time.timeScale = 1;
        StartCoroutine(SpawnObjects());
    }

    public void Perdiste()
    {
        Time.timeScale = 0;

        ScorePanel.SetActive(false);
        GameOver.SetActive(true);

        if (MaxSdk.IsInterstitialReady("add235ecc4719cb0"))
        {
            MaxSdk.ShowInterstitial("add235ecc4719cb0");
        }
        PlayServices.AddScoreToLeaderBoard();
        
    }

    public void Retry()
    {
        GameOver.SetActive(false);
        SceneManager.LoadScene(0);
        Jugar();
    }

    public void Home()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RateUs()
    {
        // Application.OpenURL("https//:google.com");
        StartCoroutine(RequestReview());

    }

    public void Pausa()
    {
        Time.timeScale = 0;
        ScorePanel.SetActive(false);
        Pause.SetActive(true);
    }

    public void Reanudar()
    {
        ScorePanel.SetActive(true);
        Pause.SetActive(false);
        Time.timeScale = 1;
    }

    public void AddScore()
    {
        Score.score++;
    }

    public void Compartir()
    {

    }

    IEnumerator RequestReview()
    {
        _reviewManager = new ReviewManager();

        var requestFlowOperation = _reviewManager.RequestReviewFlow();
        yield return requestFlowOperation;
        if (requestFlowOperation.Error != ReviewErrorCode.NoError)
        {
            // Log error. For example, using requestFlowOperation.Error.ToString().
            yield break;
        }
        _playReviewInfo = requestFlowOperation.GetResult();

        //Launch In-App Review 

        var launchFlowOperation = _reviewManager.LaunchReviewFlow(_playReviewInfo);
        yield return launchFlowOperation;
        _playReviewInfo = null; // Reset the object
        if (launchFlowOperation.Error != ReviewErrorCode.NoError)
        {
            // Log error. For example, using requestFlowOperation.Error.ToString().
            yield break;
        }
        // The flow has finished. The API does not indicate whether the user
        // reviewed or not, or even whether the review dialog was shown. Thus, no
        // matter the result, we continue our app flow.
    }

    IEnumerator SpawnObjects()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < 50; i++)
            {
                //choosing Xpos
                float OrangeXpos = XPosition[Random.Range(0, XPosition.Length)];
                //setting position
                Vector3 OrangePos = new Vector3(OrangeXpos, 10, 0);
                //choosing between square or circle
                Orange = OrangeGO[Random.Range(0, OrangeGO.Length)] as GameObject;
                //Instantiate now
                Instantiate(Orange, OrangePos, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);

                //choosing Xpos
                float BlueXpos = -XPosition[Random.Range(0, XPosition.Length)];
                //setting position
                Vector3 BluePos = new Vector3(BlueXpos, 10, 0);
                //choosing between square or circle
                Blue = BlueGO[Random.Range(0, BlueGO.Length)] as GameObject;
                //Instantiate now
                Instantiate(Blue, BluePos, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }

        }
    }

}
