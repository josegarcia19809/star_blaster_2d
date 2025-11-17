using UnityEngine;

public class PathFinding : MonoBehaviour
{
    private EnemySpawner _enemySpawner;
    WaveConfigSO waveConfig;
    Transform[] waypoints;
    int waypointIndex = 0;

    void Start()
    {
        _enemySpawner = FindFirstObjectByType<EnemySpawner>();
        waveConfig = _enemySpawner.GetCurrentWave();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waveConfig.GetStartingWaypoint().position;
    }

    void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        if (waypointIndex < waypoints.Length)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float moveDelta = waveConfig.GetEnemyMoveSpeed() * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveDelta);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}