using UnityEngine;

/// <summary> Class <c>GameStats</c> GameStat tracking  </summary>
public class GameStats : MonoBehaviour
{
    public DaysOfTheWeek dayTracker;

    public EmotionStats emotionTracker;

    void Start()
    {
        dayTracker = new DaysOfTheWeek();
        emotionTracker = new EmotionStats();
    }

    /// <summary> Inner class <c>EmotionStats</c> Logic for tracking how emotion changes through the week </summary>
    public class EmotionStats
    {
        public int relationshipToFamily;
        public int relationshipToWork;
        public int motivation;
        public int mentalstress;

        public EmotionStats()
        {
            relationshipToFamily = 50;
            relationshipToWork = 50;
            motivation = 100;
            mentalstress = 0;//each day go down in multiples of 5 (days of the week)
        }
    }

    /// <summary> Inner class <c>DaysOfTheWeek</c> Handle different formatting for outputting dates</summary>
    public class DaysOfTheWeek
    {
        int currentDay; 
        string thoughtOfTheDay;
        string date;

        public DaysOfTheWeek()
        {
            currentDay = 1;
        }

        public void SetDay(int day) => currentDay = day;

        public int GetDay() => currentDay;

        /// <summary> Method <c>GetThoughtOfTheDay</c> Get though relative to the day (used in post screen)</summary>
        public string GetThoughtOfTheDay()
        {
            switch (currentDay)
            {
                case 1:
                    thoughtOfTheDay = "I've always hated Mondays";
                    break;

                case 2:
                    thoughtOfTheDay = "Atleast it's not Monday";
                    break;

                case 3:
                    thoughtOfTheDay = "Is this week over yet?";
                    break;

                case 4:
                    thoughtOfTheDay = "I wish it was friday";
                    break;

                case 5:
                    thoughtOfTheDay = "Thank god, the end of the week";
                    break; 
            }

            return thoughtOfTheDay;
        }

        /// <summary> Class <c>GetDateOfDayInComputer</c> Translate day index to story date </summary>
        public string GetDateOfDayInComputer()
        {
            switch (currentDay) {

                case 1:
                    date = "June 2nd 1997(Monday)";
                    break;

                case 2:
                    date = "June 3rd 1997(Tuesday)";
                    break;

                case 3:
                    date = "June 4th 1997(Wednesday)";
                    break;

                case 4:
                    date = "June 5th 1997(Thursday)";
                    break;

                case 5:
                    date = "June 6th 1997(Friday)";
                    break; 

            }

            return date;
        }


        /// <summary> Method <c>GetDateOfDayInStandard</c> Translation of date for computer UI  </summary>
        public string GetDateOfDayInStandard()
        {
            switch (currentDay)
            {

                case 1:
                    date = "Monday, June 2nd 1997";
                    break;

                case 2:
                    date = "Tuesday, June 3rd 1997";
                    break;

                case 3:
                    date = "Wednesday, June 4th 1997";
                    break;

                case 4:
                    date = "Thursday, June 5th 1997";
                    break;

                case 5:
                    date = "Friday, June 6th 1997";
                    break;

            }

            return date;
        }
    }
}
