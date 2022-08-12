using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Feature : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Time;
    [SerializeField] private int Duration;
    IEnumerator Start()
    {
        Time.text = Duration.ToString();
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Duration--;
            Time.text = Duration.ToString();
            if (Duration == 0)
            {
                gameObject.SetActive(false);
                break;
            }
        }
       
    }  

}
