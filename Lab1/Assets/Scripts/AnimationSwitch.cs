using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSwitch : MonoBehaviour
{
    private Animator mAnimator;
    public ImageDistance imgDistance;
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if(mAnimator != null && imgDistance!=null)
        {
            float distance = imgDistance.distance;

            if (distance < 0.25f)
                mAnimator.SetTrigger("attackTrigger");
            else
                mAnimator.SetTrigger("idleTrigger");
        }
    }
}
