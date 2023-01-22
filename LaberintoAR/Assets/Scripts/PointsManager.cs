using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtPoints;
    private float points = 0;
    void Start()
    {
        txtPoints.text = "Points: 0";
    }

    public void addPoints(float num) {
        points += num;
        txtPoints.text = "Points: " + points;
    }
}
