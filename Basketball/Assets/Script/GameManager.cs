using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Canvas Oparation")]
    [SerializeField] Image[] MissionImage;
    [SerializeField] Sprite DefaultImage;
    [SerializeField] GameObject[] GeneralPanel;
    [Header("Level Oparation")]
    [SerializeField] GameObject Platform;
    [SerializeField] int Target;
    [SerializeField] GameObject BasketballHoop;
    [SerializeField] GameObject HoopFeature;
    [SerializeField] GameObject[] BasketFeaturePoint;
    int CurrentBall;

    [Header("Sound And Effect Oparation")]
    [SerializeField] ParticleSystem[] Effects;
    [SerializeField] AudioSource[] Sounds;

    [Header("Technical Operations")]
    [SerializeField] GameObject[] BorderPoint;  
    [SerializeField] GameObject[] PlatformPoint;
    float FingerPozX;
    float distanceLeft;
    float distanceRight;
    void Start()
    {
         distanceLeft = -Vector3.Distance(BorderPoint[0].transform.position, PlatformPoint[0].transform.position);
         distanceRight = Vector3.Distance(BorderPoint[1].transform.position, PlatformPoint[1].transform.position);
        Time.timeScale = 1;
        SetMisson();
        Invoke("SetFeature", 3f);
    }
    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 TouchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        FingerPozX = TouchPosition.x - Platform.transform.position.x;
                        break;
                    case TouchPhase.Moved:
                        if (TouchPosition.x - FingerPozX > distanceLeft && TouchPosition.x - FingerPozX < distanceRight)
                        {                         
                          Platform.transform.position = Vector3.Lerp(Platform.transform.position, new Vector3(TouchPosition.x - FingerPozX, Platform.transform.position.y,
                          Platform.transform.position.z), 5f);
                        }
                        break;
                }
            }
        }
    }

    public void Result(Vector3 Pos)
    {
        CurrentBall++;
        VoiceAndEffect(Pos, 0);
        MissionImage[CurrentBall - 1].GetComponent<Image>().sprite = DefaultImage;
        if (CurrentBall == Target)
        {
            Sounds[2].Play();
            GeneralPanel[1].SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void Lose()
    {
        Sounds[3].Play();
        GeneralPanel[2].SetActive(true);
        Time.timeScale = 0;
    }
    public void ChangeScaleHoop(Vector3 Pos)
    {
        VoiceAndEffect(Pos, 1);
        BasketballHoop.transform.localScale = new Vector3(55f, 55f, 55f);
    }
    public void ButtonOperation(string Value)
    {
        switch (Value)
        {
            case "Pause":
                Time.timeScale = 0;
                GeneralPanel[0].SetActive(true);
                break;
            case "Continue":
                Time.timeScale = 1;
                GeneralPanel[0].SetActive(false);
                break;
            case "Restart":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
            case "BackMenu":
                SceneManager.LoadScene(0);
                break;

        }
    }
    void SetFeature()
    {
        int Value = Random.Range(0, BasketFeaturePoint.Length);
        HoopFeature.transform.position = BasketFeaturePoint[Value].transform.position;
        HoopFeature.SetActive(true);
    }
    void SetMisson()
    {
        for (int i = 0; i < Target; i++)
        {
            MissionImage[i].gameObject.SetActive(true);
        }
    }
    void VoiceAndEffect(Vector3 Pos, int value)
    {
        Effects[value].transform.position = Pos;
        Effects[value].gameObject.SetActive(true);
        Sounds[value].Play();
    }
}
