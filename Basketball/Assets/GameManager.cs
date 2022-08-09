using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Platform;
    [SerializeField] int Target;
    [SerializeField] Image[] MissionImage;
    [SerializeField] Sprite DefaultImage;
    int CurrentBall;

    void Start()
    {
        SetMisson();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
           Platform.transform.position= Vector3.Lerp(Platform.transform.position, new Vector3(Platform.transform.position.x + -0.5f, Platform.transform.position.y, Platform.transform.position.z), 0.05f);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Platform.transform.position = Vector3.Lerp(Platform.transform.position, new Vector3(Platform.transform.position.x + 0.5f, Platform.transform.position.y, Platform.transform.position.z), 0.05f);

        }
    }

    public void Result()
    {
        CurrentBall++;
        MissionImage[CurrentBall - 1].GetComponent<Image>().sprite = DefaultImage;
        if (CurrentBall==Target)
        {
            Debug.Log("Win");
        }
    }
    void SetMisson()
    {
        for (int i = 0; i < Target; i++)
        {
            MissionImage[i].gameObject.SetActive(true);
        }
    }
}
