using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    private static GameLogic _instance;

    public static GameLogic GetInstance()
    {
        return _instance;
    }

    [FormerlySerializedAs("PointsText")] [SerializeField]
    private Text pointsText;

    private void Awake()
    {
        _instance = this;
    }

    private int _totalPoints;

    public void ReceivePoints(int pointsToReceive)
    {
        _totalPoints += pointsToReceive;
        pointsText.text = "Points: " + _totalPoints.ToString();
    }
}
