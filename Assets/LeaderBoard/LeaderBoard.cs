using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using static UnityEngine.EventSystems.EventTrigger;

public class LeaderBoard : MonoBehaviour
{
    public Transform HSContainer;
    public Transform HSTemplate;
    public float templateHeight = 50f;

    private List<HSEntry> HSEntryList;
    private List<Transform> HSEntryTransList;
    public float totalScore;

    public ScoreSystem scoreSystem;
    public List<string> names = new List<string>();

    private void Awake()
    {
        totalScore = scoreSystem.TotalScore;
        HSTemplate.gameObject.SetActive(false);
        names.Add("Shania");
        names.Add("Jayden");
        names.Add("Olivia");
        names.Add("Paige");
        names.Add("Myles");
        names.Add("Mykah");
        names.Add("Nia");
        names.Add("Destiny");
        names.Add("Luis");
        names.Add("Reason");
        names.Add("Marton");
        names.Add("Abi");
        names.Add("Iman");
        names.Add("L'shea");

        HSEntryList = new List<HSEntry>()
            { new HSEntry { score = totalScore, name = "YOU"},
             new HSEntry { score = Random.Range(0, 200), name = RandomNameGen()},
                  new HSEntry { score = Random.Range(0, 200), name = RandomNameGen()},
                       new HSEntry { score = Random.Range(0, 200), name = RandomNameGen()},
                            new HSEntry { score = Random.Range(0, 200), name = RandomNameGen()},
                                 new HSEntry { score = Random.Range(0, 200), name = RandomNameGen()},
                                      new HSEntry { score = Random.Range(0, 200), name = RandomNameGen()},
                                           new HSEntry { score = Random.Range(0, 200), name = RandomNameGen()},
                                                new HSEntry { score = Random.Range(0, 200), name = RandomNameGen()},
                                                     new HSEntry { score = Random.Range(0, 200), name = RandomNameGen()},
            };

        /*        for (int i = 0; i < 10; i++)
                {
                    Transform scoreTransform = Instantiate(HSTemplate, HSContainer);
                    RectTransform scoreRectTrans = scoreTransform.GetComponent<RectTransform>();
                    scoreRectTrans.anchoredPosition = new Vector2(0, -templateHeight * i);
                    scoreTransform.gameObject.SetActive(true);

                    int rank = i + 1;
                    string rankString;
                    switch (rank)
                    {
                        default:
                            rankString = rank + "TH"; break;

                        case 1: rankString = "1ST"; break;
                        case 2: rankString = "2ND"; break;
                        case 3: rankString = "3RD"; break;
                    }

                    scoreTransform.Find("RankTMP").GetComponent<TextMeshProUGUI>().text = rankString;

                    int score = Random.Range(0, 1000);
                    scoreTransform.Find("NameTMP").GetComponent<TextMeshProUGUI>().text = score.ToString();

                    string name = "Name";
                    scoreTransform.Find("ScoreTMP").GetComponent<TextMeshProUGUI>().text = name;
                }*/

        for (int i = 0; i < HSEntryList.Count; i++)
        {
            for (int j = 1 + i; j < HSEntryList.Count; j++)
            {
                if (HSEntryList[j].score > HSEntryList[i].score)
                {
                    HSEntry tmp = HSEntryList[i];
                    HSEntryList[i] = HSEntryList[j];
                    HSEntryList[j] = tmp;
                }
            }
        }

        HSEntryTransList = new List<Transform>();
        foreach (HSEntry hsentry in HSEntryList)
        {
            CreatedHSTrans(hsentry, HSContainer, HSEntryTransList);
        }

        HighScores highScores = new HighScores { HSEntryList = HSEntryList};
        string json = JsonUtility.ToJson(highScores);
        PlayerPrefs.SetString("LeaderBoardTable", json);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("LeaderBoardTable"));
    }

    private string RandomWordGen()
    {
        int _stringLength = UnityEngine.Random.Range(2, 5);
        string randomString = "";
        string[] characters = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "v", "w", "y", "z" };
        for (int i = 0; i < _stringLength; i++)
        {
            randomString = randomString + characters[UnityEngine.Random.Range(0, characters.Length)];
        }
       return randomString;
    }


    private string RandomNameGen()
    {       
        int index = Random.Range(0, names.Count);
        string randomName = names[index];
        names.RemoveAt(index);
        return randomName;
    }

    private void CreatedHSTrans(HSEntry HSEntry, Transform container, List<Transform> transformList)
    {
        Transform scoreTransform = Instantiate(HSTemplate,container);
        RectTransform scoreRectTrans = scoreTransform.GetComponent<RectTransform>();
        scoreRectTrans.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        scoreTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;

            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        scoreTransform.Find("RankTMP").GetComponent<TextMeshProUGUI>().text = rankString;

        float score = HSEntry.score;
        scoreTransform.Find("NameTMP").GetComponent<TextMeshProUGUI>().text = score.ToString();

        string name = HSEntry.name;
        scoreTransform.Find("ScoreTMP").GetComponent<TextMeshProUGUI>().text = name;

        transformList.Add(scoreTransform);
    }

    private void AddHSEntry(int score, string name)
    {
        HSEntry hSEntry = new HSEntry { score = score, name = name };

        string jsonString = PlayerPrefs.GetString("LeaderBoardTable");
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);

        highScores.HSEntryList.Add(hSEntry);

        string json = JsonUtility.ToJson(highScores);
       PlayerPrefs.SetString("LeaderBoardTable", json);
        PlayerPrefs.Save();
    }

    private class HighScores
    {
        public List<HSEntry> HSEntryList;
    }

    [System.Serializable]
    private class HSEntry
    {
        public float score;
       
        public string name;
    }
}
