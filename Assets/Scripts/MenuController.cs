using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
//using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    public Image SettingImage;
    public Image BestScoreImage;
    public Text scoreText;
    public float bestScore;
    public Image CreditImage;
    public AudioSource myAudio;
    public Slider VolumeSlider;
    public Image VolumeImage;

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        bestScore = PlayerPrefs.GetFloat("MyScore");
        scoreText.text = bestScore.ToString();
        myAudio.volume = VolumeSlider.value;
    }

    public void Setting()
    {
        SettingImage.gameObject.SetActive(true);

    }

    public void Exit()
    {
        SettingImage.gameObject.SetActive(false);

    }

    public void BestScore()
    {
        BestScoreImage.gameObject.SetActive(true);

    }


    public void ExitBestScore()
    {
        BestScoreImage.gameObject.SetActive(false);

    }

    public void Credit()
    {
        CreditImage.gameObject.SetActive(true);

    }
    public void Volume()
    {
        VolumeImage.gameObject.SetActive(true);

    }


    public void ExitCredit()
    {
        CreditImage.gameObject.SetActive(false);

    }

    public void ExitVolume()
    {
        VolumeImage.gameObject.SetActive(false);

    }

    public void QuitGame()
    {
        Application.Quit();

    }

    public void PlayGame()
    {
        SceneManager.LoadScene (1);

    }








}
