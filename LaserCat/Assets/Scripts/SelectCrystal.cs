using UnityEngine;

public class SelectCrystal : Singleton<SelectCrystal>
{
    private GameObject selectedMirror;
    private int raycastMask;
    private int clicksCount = 0;

    private void Start()
    {
        raycastMask = 1<<LayerMask.NameToLayer("Raycast Only");
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000, raycastMask))
            {
                if (hit.collider.gameObject.tag == "Mirror" || hit.collider.gameObject.tag == "MirrorRed")
                {
                    clicksCount++;
                    if (clicksCount == 1)
                    {
                        selectedMirror = hit.collider.gameObject;
                        hit.collider.GetComponent<Crystal>().isRotating = true;
                    }
                    else
                    {
                        clicksCount = 0;
                        selectedMirror.GetComponent<Crystal>().isRotating = false;
                        selectedMirror = null;
                    }
                }
            }
        }
    }
}