using System.Collections;
using UnityEngine;
using UnityEngine.Jobs;

public class CreateIndicators : MonoBehaviour
{
    public GameObject HourIndicatorPrefab;
    public GameObject MinuteIndicatorPrefab;


    // Use this for initialization
    private void Awake()
    {
        StartCoroutine(InitializeIndicators());
    }

    // Using Coroutine so that indicators are created over time
    private IEnumerator InitializeIndicators()
    {
        for (int i = 1; i <= Clock.MinutesPerCircle; i++)
        {
            transform.SetYRotation(Clock.DegreesPerMinute * i);
           
            GameObject indicatorPrefab = i % 5 == 0 ? HourIndicatorPrefab : MinuteIndicatorPrefab;
            
            //! Need to set worldPositionStays to true so that the child will rotate with the parent
            Instantiate(indicatorPrefab, transform, true);
            yield return new WaitForSeconds(0.05f);
            
        }
    }
}