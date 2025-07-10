using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distanceToPoint;
    [SerializeField] private Transform[] _points;

    private float DistanceToTarget
    {
        get => Vector3.Distance(transform.position, _points[_currentIndex].position);
    }

    private int _currentIndex = 0;

    /// <summary>
    /// It is triggered when an enemy is spawned.
    /// </summary>
    /// <param name="points"></param>
    public void Init(Transform[] points)
    {
        _points = points;
    }

    private void Update()
    {
        Vector3 targetPosition = new Vector3(_points[_currentIndex].position.x, transform.position.y, _points[_currentIndex].position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * _speed);

        if (DistanceToTarget <= _distanceToPoint)
        {
            if (_currentIndex == _points.Length - 1)
            {
                Destroy(this.gameObject);

                return;
            }

            _currentIndex++;
        }
    }
}
