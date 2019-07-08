using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Greyman;

public class DemoScriptVRBothEyes : MonoBehaviour {
    public OffScreenIndicator[] offScreenIndicators;


    //public OffScreenIndicator offScrIndicatorLeft;
    //public OffScreenIndicator offScrIndicatorRight;

    //public float offsetMultiplier = 0f;
    //foreach(FixedTarget target in )

	// Use this for initialization
	void Start () {
        for(int i = 0; i < offScreenIndicators.Length; i++)
        {
            foreach (FixedTarget target in offScreenIndicators[i].targets)
            {
                offScreenIndicators[i].AddIndicator(target.target, target.indicatorID, offScreenIndicators[i].eyeLayer);
            }
        }
		//foreach(FixedTarget target in offScrIndicatorLeft.targets)
  //      {
  //          offScrIndicatorLeft.AddIndicator(target.target, target.indicatorID, offScrIndicatorLeft.eyeLayer);
  //      }

        //foreach (FixedTarget target in offScrIndicatorRight.targets)
        //{
        //    offScrIndicatorRight.AddIndicator(target.target, target.indicatorID, offScrIndicatorRight.eyeLayer);
        //}
    }

    public void AddTarget()
    {
        GameObject cubeToInstantiate = GameObject.Find("Cube");
        GameObject newCube = GameObject.Instantiate(cubeToInstantiate);
        newCube.name = "AddedCube";
        //position it at random place
        newCube.transform.localPosition = new Vector3(Random.Range(-50, 50), 1, Random.Range(-50, 50));
        //add the ArrowIndicatorStuff
        for (int i = 0; i < offScreenIndicators.Length; i++)
        {
            foreach (FixedTarget target in offScreenIndicators[i].targets)
            {
                offScreenIndicators[i].AddIndicator(newCube.transform, Random.Range(0, offScreenIndicators[i].indicators.Length), offScreenIndicators[i].eyeLayer);
            }
        }
        
        //offScrIndicatorLeft.AddIndicator(newCube.transform, Random.Range(0, offScrIndicatorLeft.indicators.Length), offScrIndicatorLeft.eyeLayer);
        //offScrIndicatorRight.AddIndicator(newCube.transform, Random.Range(0, offScrIndicatorRight.indicators.Length), offScrIndicatorRight.eyeLayer);

    }

    public void RemoveTarget()
    {
        GameObject cubeToRemove = GameObject.Find("AddedCube");
        if (cubeToRemove)
        {
            for (int i = 0; i < offScreenIndicators.Length; i++)
            {
                foreach (FixedTarget target in offScreenIndicators[i].targets)
                {
                    offScreenIndicators[i].RemoveIndicator(cubeToRemove.transform);
                }
            }
            //offScrIndicatorLeft.RemoveIndicator(cubeToRemove.transform);
            //offScrIndicatorRight.RemoveIndicator(cubeToRemove.transform);
            GameObject.Destroy(cubeToRemove);
        }
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyUp(KeyCode.E))
        {
            AddTarget();
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            RemoveTarget();
        }

        //if (Input.GetKeyUp(KeyCode.UpArrow))
        //{
        //    if (offsetMultiplier < 0f)
        //    {
        //        offsetMultiplier = 0f;
        //    }
        //    else
        //    {
        //        offsetMultiplier += 0.1f;
        //    }
        //    offScrIndicatorLeft.OffsetMultiplier = offsetMultiplier;

        //}

        //if (Input.GetKeyUp(KeyCode.DownArrow))
        //{
        //    if (offsetMultiplier < 0f)
        //    {
        //        offsetMultiplier = 0f;
        //    }
        //    else
        //    {
        //        offsetMultiplier -= 0.1f;
        //    }
        //    offScrIndicatorLeft.OffsetMultiplier = offsetMultiplier;
        //}
    }
}
