using UnityEngine;

public class PointsGiver : MonoBehaviour
{
    [SerializeField]
    private int pointsToReward;

    public void RewardPoints()
    {
        GameLogic.GetInstance().ReceivePoints(pointsToReward);
    }
}
