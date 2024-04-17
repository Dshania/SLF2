using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Snake : MonoBehaviour
{
    private Vector2 direction = Vector2.up;

    private List<Transform> bodySegments = new List<Transform>();
    public Transform bodyPrefab;
    public int initialSize = 2;

    public GameObject SnakeMenu;
    public GameObject scoreOBJ;
    public TMP_Text score;
    public TMP_Text HighScore;

    private void Start()
    {
        direction = Vector2.zero;
        Reset();
        HighScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
        void Update()
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                direction = Vector2.up;
            } else if (Input.GetAxis("Vertical") < 0)
            {
                direction = Vector2.down;
            } else if (Input.GetAxis("Horizontal") < 0)
            {
                direction = Vector2.left;
            } else if (Input.GetAxis("Horizontal") > 0)
            {
                direction = Vector2.right;
            }

            int bodyCount = bodySegments.Count - 1;
            string points = bodyCount.ToString();
            score.text = points;

            if (bodyCount > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", bodyCount);
                HighScore.text = bodyCount.ToString();
            }

            if (bodySegments.Count > 20)
            {
                if (Input.GetAxis("Vertical") > 0)
                {
                    direction = Vector2.up * 1.2f;
                }
                else if (Input.GetAxis("Vertical") < 0)
                {
                    direction = Vector2.down * 1.2f;
                }
                else if (Input.GetAxis("Horizontal") < 0)
                {
                    direction = Vector2.left * 1.2f;
                }
                else if (Input.GetAxis("Horizontal") > 0)
                {
                    direction = Vector2.right * 1.2f;
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SnakeMenu.SetActive(true);
                scoreOBJ.SetActive(false);

                if (SnakeMenu == true)
                {
                    Time.timeScale = 0f;
                }
                if (SnakeMenu == false)
                {
                    scoreOBJ.SetActive(true);
                }

            }
        }
        private void FixedUpdate()
        {
            for (int i = bodySegments.Count - 1; i > 0; i--)
            {
                bodySegments[i].position = bodySegments[i - 1].position;
            }

            this.transform.position = new Vector3(Mathf.Round(this.transform.position.x) + direction.x, Mathf.Round(this.transform.position.y) + direction.y, 0f);
        }

        private void Growth()
        {
            Transform segment = Instantiate(this.bodyPrefab);
            segment.position = bodySegments[bodySegments.Count - 1].position;

            bodySegments.Add(segment);
        }

        private void Reset()
        {
            StartCoroutine(waitTime());
            for (int i = 1; i < bodySegments.Count; i++)
            {
                Destroy(bodySegments[i].gameObject);
            }

            bodySegments.Clear();
            bodySegments.Add(this.transform);

            this.transform.position = Vector3.zero;

            for (int i = 1; i < this.initialSize; i++)
            {
                bodySegments.Add(Instantiate(this.bodyPrefab));
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Food")
            {
                Growth();
            }

            else if (other.tag == "Barrier")
            {
                Reset();
            }
        }

        IEnumerator waitTime()
        {
            // yield return new WaitUntil(() => bodySegments.Count >= 10);
            direction = Vector2.zero;
            yield return new WaitForSeconds(4);
        } 
}
