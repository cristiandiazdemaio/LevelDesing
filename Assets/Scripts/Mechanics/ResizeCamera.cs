using Cinemachine;
using Platformer.Gameplay;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    public class ResizeCamera : MonoBehaviour
    {
        public float new_size;
        public float time_resize;
        public bool change_size = false;
        public CinemachineVirtualCamera camera_player;
        void OnTriggerEnter2D(Collider2D collider)
        {
            var p = collider.gameObject.GetComponent<PlayerController>();
            if (p != null)
            {
                change_size = true;
                StartCoroutine(Resize(time_resize));
            }
        }
        IEnumerator Resize(float time)
        {
            while (change_size)
            {
                camera_player.m_Lens.OrthographicSize = Mathf.Lerp(camera_player.m_Lens.OrthographicSize, new_size, time);
                yield return new WaitForSeconds(time);
                if (camera_player.m_Lens.OrthographicSize == new_size)
                {
                    change_size = false;
                }
            }

        }
    }
}