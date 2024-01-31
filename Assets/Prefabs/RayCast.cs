using UnityEngine;
using UnityEngine.XR;

public class RayCast : MonoBehaviour
{
    public int Raydist = 3;
    public GameObject cursor;
    public GameObject cursor2;
    




    private void Start()
    {
        

    }

    void Update()
    {
        var tempTex = Camera.main.targetTexture;
        Camera.main.targetTexture = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        cursor2.SetActive(false);
        
       
        if (Input.GetMouseButtonDown(1))
        {
            
            
            
        }

        if (Physics.Raycast(ray, out hit, Raydist))
        {
            InteractableItem interactableItem = hit.collider.gameObject.GetComponent<InteractableItem>();
            
            
            if (interactableItem != null)
            {
                cursor2.SetActive(true);
                cursor.SetActive(false);
            }
            else
            {
                cursor2.SetActive(false);
                cursor.SetActive(true);
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (interactableItem != null)
                {
                    interactableItem.Clicked();
                                            


                }
            }
            

        }
        else
        {
            cursor.SetActive(true);
            cursor2.SetActive(false);
        }

        Camera.main.targetTexture = tempTex;
    }
}
