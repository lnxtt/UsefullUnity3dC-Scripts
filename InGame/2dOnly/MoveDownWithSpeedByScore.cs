using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CustomMath.ExpressionParser;	// My expression parser

public class MoveDownWithSpeedByScore : MonoBehaviour {

	Text ScoreLabel;
	public string SpeedFunction;
	private float speed;
	ExpressionParser equationParser = new ExpressionParser();	// You will need a Expression parser script!!!

	void Start () {
		ScoreLabel = GameObject.Find("ScoreLabel").GetComponent<Text>();
		int currentScore = int.Parse (ScoreLabel.text);
		string equation = SpeedFunction.Replace ("x", currentScore.ToString ());
		speed = (float)equationParser.Evaluate(equation);
	}

	void Update () {
		transform.Translate(Vector3.down * speed * Time.deltaTime);
	}
}
