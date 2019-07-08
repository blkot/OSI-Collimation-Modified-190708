using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Greyman
{
    public class OffScreenIndicatorManagerVRDoubleEyes : OffScreenIndicatorManager
    {
        private GameObject indicatorsParentObj;
        public float cameraDistance = 5;
        public float radius = 2;
        public float indicatorScale = 0.1f;
        public float indicatorOffsetMultiplr = 0f;

        public GameObject CanvasL = null;
        public GameObject CanvasR = null;
        //public Eyes eye;
        //public Camera eyeCamera;
        //public LayerMask eyeLayer;

        // Use this for initialization
        void Start()
        {
            
        }

        

        public override void SetCamera(Camera cam)
        {
            eyeCamera = cam;
            //throw new System.NotImplementedException();
        }

        public override void SetRaycastRoot(GameObject root)
        {
            RaycastRoot = root;
            //throw new System.NotImplementedException();
        }

        public void CreateIndicatorsParent()
        {
            
            indicatorsParentObj = new GameObject();
            //indicatorsParentObj.transform.SetParent(eyeCamera.transform);
            indicatorsParentObj.transform.SetParent(RaycastRoot.transform);
            indicatorsParentObj.transform.localPosition = new Vector3(0, 0, cameraDistance);
            indicatorsParentObj.transform.localScale = new Vector3(1f, 1f, 1f);
            indicatorsParentObj.transform.localEulerAngles = new Vector3(0, 0, 0);
            indicatorsParentObj.name = "IndicatorsParentObj";
        }

        void LateUpdate()
        {
            for(int i = 0; i < arrowIndicators.Count; i++)
            {
                UpdateIndicatorPosition(arrowIndicators[i], indicatorOffsetMultiplr, i);
                arrowIndicators[i].UpdateEffects();
            }
        }

        public override void AddIndicator(Transform target, int indicatorID, string eye)
        {
            if (indicatorID >= indicators.Length)
            {
                Debug.LogError("Indicator ID not valid. Check Off Screen Indicator Indicators list.");
                return;
            }

            if (!ExistsIndicator(target))
            {
                ArrowIndicatorVRDoubleEyes newArrowIndicator = new ArrowIndicatorVRDoubleEyes();
                newArrowIndicator.target = target;
                newArrowIndicator.indicator = indicators[indicatorID];
                newArrowIndicator.indicatorID = indicatorID;
                //Debug.Log(newArrowIndicator.indicator.targetOffset);
                newArrowIndicator.arrow = new GameObject();
                newArrowIndicator.arrow.transform.SetParent(indicatorsParentObj.transform);
                newArrowIndicator.arrow.name = "indicator" + target.name;
                newArrowIndicator.VR_scale = new Vector3(indicatorScale, indicatorScale, indicatorScale);
                newArrowIndicator.arrow.transform.localScale = newArrowIndicator.VR_scale;
                //newArrowIndicator.arrow.transform.localEulerAngles = new Vector3(0, 45, 0);

                newArrowIndicator.arrow.layer = LayerMask.NameToLayer(eye);

                //newArrowIndicator.arrow.layer=
                newArrowIndicator.arrow.AddComponent<SpriteRenderer>();
                newArrowIndicator.arrow.GetComponent<SpriteRenderer>().sprite = newArrowIndicator.indicator.offScreenSprite;
                newArrowIndicator.arrow.GetComponent<SpriteRenderer>().color = newArrowIndicator.indicator.offScreenColor;
                if (!newArrowIndicator.indicator.showOffScreen)
                {
                    newArrowIndicator.arrow.SetActive(false);
                }
                newArrowIndicator.onScreen = false;
                arrowIndicators.Add(newArrowIndicator);



                switch (eye)
                {
                    case "LeftEye":
                        GameObject cl = Instantiate(CanvasL, newArrowIndicator.arrow.transform);
                        //cl.transform.localPosition = Vector3.zero;
                        cl.GetComponent<TextUIName>().GetName(target.gameObject);
                        break;
                    //return;
                    case "RightEye":
                        GameObject cr = Instantiate(CanvasR, newArrowIndicator.arrow.transform);
                        //cr.transform.localPosition = Vector3.zero;
                        cr.GetComponent<TextUIName>().GetName(target.gameObject);
                        break;
                }




                //AddInfoText(target, newArrowIndicator.arrow.transform, eye);
            }
            else
            {
                Debug.LogWarning("Target already added: " + target.name);
            }




            




            //throw new System.NotImplementedException();
        }


        //public void AddInfoText(Transform target, Transform indicator, string _eye)
        //{
        //    switch (_eye)
        //    {
        //        case "LeftEye":
        //            GameObject cl = Instantiate(CanvasL, indicator);
        //            cl.transform.localPosition = Vector3.zero;
        //            cl.GetComponent<TextUIName>().GetName(target.name);
        //            break;
        //            //return;
        //        case "RightEye":
        //            GameObject cr = Instantiate(CanvasR, indicator);
        //            cr.transform.localPosition = Vector3.zero;
        //            cr.GetComponent<TextUIName>().GetName(target.name);
        //            break;
        //    }
        //    //(GameObject)Instantiate()
        //}




        public override void RemoveIndicator(Transform target)
        {
            if (ExistsIndicator(target))
            {
                ArrowIndicator oldArrowTarget = arrowIndicators.Find(x => x.target == target);
                int id = arrowIndicators.FindIndex(x => x.target == target);
                arrowIndicators.RemoveAt(id);
                GameObject.Destroy(oldArrowTarget.arrow);
                ArrowIndicator.Destroy(oldArrowTarget);
            }
            


            //throw new System.NotImplementedException();
        }

        //public override void AddInfo(ArrowIndicatorVRDoubleEyes arrowIndicatorsVRDoubleEyes, Transform target, Transform parentFrame, int infoID, string eye)
        //{
        //    if (infoID >= targetInfos.Length)
        //    {
        //        Debug.LogError("TargetInfo ID not valid. Check Off Screen Indicator TargetInfo list.");
        //        return;
        //    }



        //    //if (!ExistsIndicator(target))
        //    //{
        //    //    ArrowIndicatorVRDoubleEyes newArrowIndicator = new ArrowIndicatorVRDoubleEyes();
        //    //    newArrowIndicator.target = target;
        //    //    //newArrowIndicator.indicator = indicators[indicatorID];
        //    //    newArrowIndicator.indicatorID = indicatorID;
        //    //    //Debug.Log(newArrowIndicator.indicator.targetOffset);
        //    //    newArrowIndicator.arrow = new GameObject();
        //    //    newArrowIndicator.arrow.transform.SetParent(indicatorsParentObj.transform);
        //    //    newArrowIndicator.arrow.name = "indicator" + target.name;
        //    //    newArrowIndicator.VR_scale = new Vector3(indicatorScale, indicatorScale, indicatorScale);
        //    //    newArrowIndicator.arrow.transform.localScale = newArrowIndicator.VR_scale;

        //    //    newArrowIndicator.arrow.layer = LayerMask.NameToLayer(eye);

        //    //    //newArrowIndicator.arrow.layer=
        //    //    newArrowIndicator.arrow.AddComponent<SpriteRenderer>();
        //    //    newArrowIndicator.arrow.GetComponent<SpriteRenderer>().sprite = newArrowIndicator.indicator.offScreenSprite;
        //    //    newArrowIndicator.arrow.GetComponent<SpriteRenderer>().color = newArrowIndicator.indicator.offScreenColor;
        //    //    if (!newArrowIndicator.indicator.showOffScreen)
        //    //    {
        //    //        newArrowIndicator.arrow.SetActive(false);
        //    //    }
        //    //    newArrowIndicator.onScreen = false;
        //    //    arrowIndicators.Add(newArrowIndicator);
        //    //}
        //    //else
        //    //{
        //    //    Debug.LogWarning("Target already added: " + target.name);
        //    //}

        //    throw new System.NotImplementedException();
        //}


        protected override void UpdateIndicatorPosition(ArrowIndicator arrowIndicator, float multiplr, int id = 0)
        {
            Vector3 pCam = RaycastRoot.transform.position;
            Vector3 pPlane = indicatorsParentObj.transform.position;
            Ray zRay = new Ray(pPlane, pCam - pPlane);
            pPlane = zRay.GetPoint(-0.001f * id);
            Plane plane = new Plane(Vector3.Normalize(pCam - pPlane), pPlane);


            //Vector3 pTarget = arrowIndicator.target.transform.position+arrowIndicator.indicator.targetOffset;
            Vector3 pTarget = arrowIndicator.target.transform.position;
            Ray rToTarget = new Ray(pCam, pTarget - pCam);
            Vector3 hitPoint;


            //DISTANCE
            float distance; 




            if(plane.Raycast(rToTarget,out distance))
            {
                hitPoint = rToTarget.GetPoint(distance);
                if (Vector3.Distance(pPlane, hitPoint) > radius)
                {
                    arrowIndicator.onScreen = false;
                    Ray rToArrow = new Ray(pPlane, hitPoint - pPlane);
                    arrowIndicator.arrow.transform.position = rToArrow.GetPoint(radius);

                }
                else
                {
                    arrowIndicator.onScreen = true;
                    //float disoffset;
                    //disoffset = 1f - (2.000f / distance);
                    //arrowIndicator.arrow.transform.position = hitPoint;
                    //arrowIndicator.arrow.transform.position = hitPoint + arrowIndicator.indicator.targetOffset;

                    //arrowIndicator.arrow.transform.position = hitPoint + arrowIndicator.indicator.targetOffset * disoffset * eyeCamera.stereoSeparation;
                    arrowIndicator.arrow.transform.position = hitPoint + arrowIndicator.indicator.targetOffset * distance * 0.005f;
                }

                Vector3 plPlane = indicatorsParentObj.transform.localPosition;
                Vector3 plHitPoint = arrowIndicator.arrow.transform.localPosition;
                float angle = (90 - RaycastRoot.transform.localEulerAngles.z) * Mathf.Deg2Rad;

                if ((arrowIndicator.onScreen && arrowIndicator.indicator.onScreenRotates) || (!arrowIndicator.onScreen && arrowIndicator.indicator.offScreenRotates))
                {
                    angle = Mathf.Atan2(plHitPoint.y - plPlane.y, plHitPoint.x - plPlane.x);

                }
                arrowIndicator.arrow.transform.localEulerAngles = new Vector3(0, 0, angle * Mathf.Rad2Deg - 90);

                //Debug some lines
                if (enableDebug)
                {
                    Utils.DrawPlane(Vector3.Normalize(pCam - pPlane), pPlane, radius);
                    Debug.DrawRay(rToTarget.origin, rToTarget.direction);
                    Debug.DrawLine(pCam, hitPoint, Color.white);
                    Debug.DrawLine(hitPoint, pPlane, Color.magenta);
                    Debug.DrawLine(RaycastRoot.transform.position, pTarget);
                }


                //check DISTANCE

                
            }
            else
            {
                rToTarget = new Ray(pTarget, pCam - pTarget);
                if (plane.Raycast(rToTarget, out distance))
                {
                    hitPoint = rToTarget.GetPoint(distance);
                    Ray rToArrow = new Ray(pPlane, hitPoint - pPlane);
                    arrowIndicator.arrow.transform.position = rToArrow.GetPoint(-radius);
                    arrowIndicator.onScreen = false;

                    Vector3 plPlane = indicatorsParentObj.transform.localPosition;
                    Vector3 plHitPoint = arrowIndicator.arrow.transform.localPosition;
                    float angle = (90 - RaycastRoot.transform.localEulerAngles.z) * Mathf.Deg2Rad;
                    if (arrowIndicator.indicator.offScreenRotates)
                    {
                        angle = Mathf.Atan2(plHitPoint.y - plPlane.y, plHitPoint.x - plPlane.x);
                    }
                    arrowIndicator.arrow.transform.localEulerAngles = new Vector3(0, 0, angle * Mathf.Rad2Deg - 90);
                }
                else
                {
                    //target-cast is parallel to the plane, using the last indicator position is fine.
                }
            }




            //throw new System.NotImplementedException();
        }

        protected override void UpdateTextInfo()
        {


            throw new System.NotImplementedException();
        }
    }
}