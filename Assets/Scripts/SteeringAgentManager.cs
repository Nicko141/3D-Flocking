using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Steering
{
    public class SteeringAgentManager : MonoBehaviour
    {
        [SerializeField, Min(1f)] private float speed = 5;
        [SerializeField] private bool run = false;

        private SteeringAgent[] agents;

        private void Start()
        {
            agents = FindObjectsOfType<SteeringAgent>();
            foreach (SteeringAgent agent in agents)
            {
                agent.transform.parent = transform;
                agent.Initialise(speed);
            }
        }
        private void Update()
        {
            foreach (SteeringAgent agent in agents)
            {
                if (run)
                {
                    agent.UpdateAgent();
                }
            }
        }
    }
}

