using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreRegulator : MonoBehaviour {

    private GameObject scoreText;

    private int score;

	void Start () {

        score = 0;

        this.scoreText = GameObject.Find("ScoreText");
        this.scoreText.GetComponent<Text>().text = "Score: " + score; 
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "SmallStarTag")
        {
            score += 10;
        }
        else if (collision.collider.tag == "LargeStarTag")
        {
            score += 30;
        }
        else if (collision.collider.tag == "SmallCloudTag")
        {
            score += 50;
        }
        else if (collision.collider.tag == "LargeCloudTag")
        {
            score += 100;
        }

        this.scoreText.GetComponent<Text>().text = "Score: " + score;
    }
}
