using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class LeaderBoard : MonoBehaviour
{
    public Transform HSContainer;
    public Transform HSTemplate;
    public float templateHeight = 50f;

    private List<HSEntry> HSEntryList;
    private List<Transform> HSEntryTransList;
    public int totalScore;

    public void Update()
    {
        totalScore = ((int)PlayerPrefs.GetFloat("Scores") + (int)PlayerPrefs.GetFloat("TotalScore"));
    }

    private void Awake()
    {      
        totalScore = ((int)PlayerPrefs.GetFloat("Scores") + (int)PlayerPrefs.GetFloat("TotalScore"));
        HSTemplate.gameObject.SetActive(false);

        HSEntryList = new List<HSEntry>()
            { new HSEntry { score = totalScore, name = "YOU"},
             new HSEntry { score = Random.Range(0, 1000), name = RandomNameGen()},
                  new HSEntry { score = Random.Range(0, 1000), name = RandomNameGen()},
                       new HSEntry { score = Random.Range(0, 1000), name = RandomNameGen()},
                            new HSEntry { score = Random.Range(0, 1000), name = RandomNameGen()},
                                 new HSEntry { score = Random.Range(0, 1000), name = RandomNameGen()},
                                      new HSEntry { score = Random.Range(0, 1000), name = RandomNameGen()},
                                           new HSEntry { score = Random.Range(0, 1000), name = RandomNameGen()},
                                                new HSEntry { score = Random.Range(0, 1000), name = RandomNameGen()},
                                                     new HSEntry { score = Random.Range(0, 1000), name = RandomNameGen()},
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

    private string RandomNameGen()
    {
        int _stringLength = UnityEngine.Random.Range(2, 5);
        string randomString = "";
        string[] characters = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        for (int i = 0; i < _stringLength; i++)
        {
            randomString = randomString + characters[UnityEngine.Random.Range(0, characters.Length)];
        }
       return randomString;
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

        int score = HSEntry.score;
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
        public int score;
       
        public string name;
    }
}
