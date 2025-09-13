using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    public class MoveSpawnPoint : MonoBehaviour
    {
        public Vector3 new_position;
        public bool has_been_used = false;
        public GameObject spawn_position;
        void OnTriggerEnter2D(Collider2D collider)
        {
            var p = collider.gameObject.GetComponent<PlayerController>();
            if (p != null && has_been_used == false)
            {
                spawn_position.transform.position = new_position;
            }
        }
    }
}