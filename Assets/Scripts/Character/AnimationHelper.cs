using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationHelper : MonoBehaviour
{
    public UnityEvent onTrigger, onAttackPerformed;
    public void TriggerEvent()
    {
        onTrigger?.Invoke();
    }
    public void TriggerAttack()
    {
        onAttackPerformed?.Invoke();
    }

}
