using Search;
using UnityEngine;

namespace Game
{
    public class ZombieComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _aliveView;

        [SerializeField] private GameObject _diedView;

        [SerializeField] private float _speed = 2f;
        [SerializeField] private float _awareSpeed = 5f;

        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private ZombieBot _zombieBot;

        [SerializeField] private Vector3[] _deltaPath;
        

        private int _currentPoint = 0;
        private Vector3 _initPosition;

        private void Awake()
        {
            _initPosition = transform.position;
        }

        private void OnEnable()
        {
            SetState(true);
        }

        private void Update()
        {
            if (_zombieBot == null || !IsAlive)
                return;
            if (!_zombieBot.IsAware)
            {
                IdleMove();
            }
            else
            {
                BotMove();
            }
        }

        private void IdleMove()
        {
            if (_deltaPath == null || _deltaPath.Length < 2)
                return;

            var direction = _initPosition + _deltaPath[_currentPoint] - transform.position;
            _rigidbody.velocity = IsAlive ? direction.normalized * _speed : Vector3.zero;

            if (direction.magnitude <= 0.1f)
            {
                _currentPoint = (_currentPoint + 1) % _deltaPath.Length;
            }
        }

        private void BotMove()
        {
            var (moveDirection, viewDirection, shoot) = _zombieBot.CurrentInput();

            _rigidbody.velocity = moveDirection.normalized * _awareSpeed;
            transform.rotation = viewDirection;
        }

        public void SetState(bool alive)
        {
            _aliveView.SetActive(alive);
            _diedView.SetActive(!alive);
        }

        public bool IsAlive => _aliveView.activeInHierarchy;
    }
}