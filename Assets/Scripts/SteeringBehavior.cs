using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Steering
{
    public abstract class SteeringBehavior : ScriptableObject
    {
       public void UpdateAgent(SteeringAgent _agent)
        {
            Vector3 force = Calculate(_agent).normalized;
            _agent.UpdateCurrentForce(force);

            Quaternion rotation = Quaternion.Slerp(_agent.Rotation, Quaternion.LookRotation(_agent.CurrentForce != Vector3.zero ? _agent.CurrentForce : Vector3.one), Time.deltaTime);
            Vector3 movement = (_agent.Forward + force * _agent.Speed) * Time.deltaTime;
            Vector3 position = Vector3.SmoothDamp(_agent.Position, movement + _agent.Position, ref _agent.velocity, _agent.MovementSmoothing);
            _agent.SetPosandRot(position, rotation);
        }

        protected abstract Vector3 Calculate(SteeringAgent _agent);
    }
}

