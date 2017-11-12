using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{ 
    public class EnemySpaceShip : SpaceShipBase
    {
        [SerializeField]
        private float _reachedDistance = 0.5f;

        private GameObject[] _movementTargets;

        private int _currentMovementTargetIndex = 0;

        [SerializeField]
        private int chanceToSpawn;

        [SerializeField]
        private GameObject powerUpPrefab;


        public Transform CurrentMovementTarget
        {
            get
            {
                return _movementTargets[_currentMovementTargetIndex].transform;
            }
        }

        public override Type UnitType
        {
            get { return Type.Enemy; }
        }

        protected override void Update()
        {
            base.Update();

            Shoot();
        }

        //public void CheckIfSpawn()
        //{
        //    Health health = GetComponent<Health>();
        //    PowerUpSpawner powerUpSpawner = GetComponentInChildren<PowerUpSpawner>();

        //    if (health.IsDead)
        //    {
        //        int i = Random.Range(1, 100);

        //        if (i < powerUpSpawner.chanceToSpawn)
        //        {
        //            powerUpSpawner.Spawn();
        //        }
        //    }
        //}


        protected override void Die()
        {
            base.Die();

            int i = Random.Range(0, 100);

            if(i < chanceToSpawn)
            {
                SpawnPowerUp();
            }


        }

        public void SpawnPowerUp()
        {
            powerUpPrefab = Instantiate(powerUpPrefab, transform.position, transform.rotation);

        }

        public void SetMovementTargets(GameObject[] movementTargets)
        {
            _movementTargets = movementTargets;
            _currentMovementTargetIndex = 0;
        }

        protected override void Move()
        {
            if(_movementTargets == null || _movementTargets.Length == 0)
            {
                return;
            }

            UpdateMovementTarget();
            Vector3 direction = (CurrentMovementTarget.position - transform.position).normalized;
            transform.Translate(direction * Speed * Time.deltaTime);
        }

        private void UpdateMovementTarget()
        {
            if(Vector3.Distance(transform.position, CurrentMovementTarget.position) < _reachedDistance)
            {
                if(_currentMovementTargetIndex >= _movementTargets.Length - 1)
                {
                    _currentMovementTargetIndex = 0;
                }
                else
                {
                    _currentMovementTargetIndex++;
                }
            }
        }
    }
}

