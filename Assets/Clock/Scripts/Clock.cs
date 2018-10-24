using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public const int HoursPerCircle = 12;
    public const int DegreesPerHour = 360 / HoursPerCircle;
    public const int MinutesPerCircle = 60;
    public const int DegreesPerMinute = 360 / MinutesPerCircle;
    public const int SecondsPerCircle = 60;
    public const int DegreesPerSecond = 360 / SecondsPerCircle;

    public Transform hoursTransform, minutesTransform, secondsTransform;
    public bool isContinuous;

   // Update is called once per frame
    private void Update()
    {
        UpdateTime();
    }

    private void UpdateTime()
    {
        // TimeOfDay allow fraction of hours, minutes, seconds to be calculated
        TimeSpan time = DateTime.Now.TimeOfDay;
        float hours = (float) time.TotalHours;
        float minutes = (float) time.TotalMinutes;
        float seconds = (float) time.TotalSeconds;
        if (!isContinuous)
        {
            hours = (int) hours;
            minutes = (int) minutes;
            seconds = (int) seconds;
        }

        hoursTransform.SetYRotation(hours * DegreesPerHour);
        minutesTransform.SetYRotation(minutes * DegreesPerMinute);
        secondsTransform.SetYRotation(seconds * DegreesPerSecond);
    }
}