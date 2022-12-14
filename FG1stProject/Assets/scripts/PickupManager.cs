
using UnityEngine;

public class PickupManager : MonoBehaviour
{
   public static PickupManager instance;
   [SerializeField] GameObject pickupPrefab;
   private void Awake()
   {
      if (instance == null)
      {
         instance = this;
      }
      else
      {
         Destroy(gameObject);
      }
   }
   public static PickupManager GetInstance()
   {
      return instance;
   }
   
   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space))
      {
         GameObject newPickup = Instantiate(pickupPrefab);  // spawn when it reaches x turns (ask turn manager)
         newPickup.transform.position = new Vector3(Random.Range(0f,5f), 1f, Random.Range(0f, 5f));
      }
   }
}
