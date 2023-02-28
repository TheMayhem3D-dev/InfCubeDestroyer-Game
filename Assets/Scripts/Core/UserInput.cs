using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

namespace Core
{
    public class UserInput : MonoBehaviour
    {
        [SerializeField] private Shooter shooter;

        // Update is called once per frame
        void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                shooter.Fire();
            }
        }
    }
}