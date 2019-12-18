using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject leftArrow;
    [SerializeField] GameObject rightArrow;
    [SerializeField] Element leftHandItem;
    [SerializeField] Element rightHandItem;
    [SerializeField] GameObject itemsPosParent;
    [SerializeField] GameObject popUp;
    [SerializeField] TextMeshProUGUI popUpInfo;
    [SerializeField] TextMeshProUGUI popUpTitle;
    [SerializeField] Image popUImage;
    private Element[] itemPlaceholders; //The static item placeholders on the scroll
    private Element grabbedItem = null;
    [SerializeField] Element movingElement;
    private List<string> discoveredItems;
    private int pageIndex = 0;
    private int points = 0;
    private Element currentDiscovery;
   // private string currentDiscovery;
   // private string currentDiscoveryInfo;
    private bool isInteractable = true;
    [SerializeField] ParticleSystem inventingParticle;
    [SerializeField] ParticleSystem leftSnapParticle;
    [SerializeField] ParticleSystem rightSnapParticle;
    // [SerializeField] ParticleSystem leftInventingParticle;
    //  [SerializeField] ParticleSystem rightInventingParticle;
    private Coroutine inventingRoutine = null;
    private GameState gameState;
    private ItemState itemState;
    private Coroutine PopItemRoutine = null;
    private GameObject lastHand;
  //  private int showItemsStartIndex;
  //  private int showItemsEndIndex;

    private enum ItemState
    {
        shouldBeInvented,
        alreadyInvented,
        cantBeInvented
    }

    public enum GameState
    {
        matching,
        inventing,
        popup
    }

    void Start()
    {
        discoveredItems = new List<string> { "Air", "Earth", "Fire", "Water", "Lava", "Mud", "Rain", "Lake", "Pressure", "Energy", "Hell",};
        itemPlaceholders = itemsPosParent.GetComponentsInChildren<Element>();
        HideItems();
       // showItemsStartIndex = 0;
       // showItemsEndIndex = discoveredItems.Count - 1;
        ShowFoundItems(/*showItemsStartIndex, showItemsEndIndex*/); //Load from user defaults!!!!!!!!
        ShowArrows();
        movingElement.gameObject.SetActive(false);
        leftHandItem.GetComponent<SpriteRenderer>().enabled = false;
        rightHandItem.GetComponent<SpriteRenderer>().enabled = false;
    }

    void Update()
    {
        if (/*isInteractable && */ gameState == GameState.matching)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Item"))
                {
                    OnItemClicked(hit.collider.gameObject);
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Hand"))
                {
                    ClickedHandItem(hit.collider.gameObject);
                }
            }

            if (Input.GetMouseButton(0))
            {
                if (grabbedItem != null && movingElement != null)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                    Vector2 mousePosition = Input.mousePosition;
                    mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

                    if (hit /*.collider*/ != null /* && hit.collider.gameObject.layer == LayerMask.NameToLayer("RaycastLayer")*/)
                    {
                        MoveElement(mousePosition);
                    }
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (grabbedItem != null) //If player is holding an element
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit2D hitHand = Physics2D.Raycast(ray.origin, ray.direction, 10.0f, 1 << LayerMask.NameToLayer("Hand"));

                    if (hitHand.collider != null /* && hit.collider.gameObject.layer == LayerMask.NameToLayer("Hand")*/)
                    {
                        OnItemReleased(hitHand.collider);
                    }
                   /* else if (hitSelf.collider != null && hitSelf.collider.gameObject.GetComponent<Element>().GetText() == grabbedItem.GetText())
                    {
                        Debug.Log("RELEASED ON SELF");
                        currentDiscovery = grabbedItem;
                                currentDiscovery = grabbedItem;
                                PopUp();
                    } */
                    else
                    {
                        Debug.Log("released wherever");
                        movingElement.gameObject.SetActive(false);
                    }
                    movingElement.gameObject.SetActive(false);
                    grabbedItem = null;
                }
            }
        }

        if (gameState == GameState.popup)
        {
            if (Input.GetMouseButtonDown(0))
            {
                HidePopUp();
            }
        }
    }

    private void ClickedHandItem(GameObject hit)
    {
        if (hit.GetComponent<SpriteRenderer>().enabled)
        {
            hit.GetComponent<SpriteRenderer>().enabled = false;
            AudioManager.PlayAudio(AudioManager.instance.pop);
            hit.GetComponent<Element>().SetText("Itemname");
        }
    }

    private void OnItemClicked(GameObject hit)
    {
        Debug.Log("Clicked " + hit.GetComponent<Element>().GetText());
        grabbedItem = hit.GetComponent<Element>();
        movingElement.gameObject.SetActive(true);
        movingElement.SetSprite(grabbedItem.GetSprite());
        movingElement.SetText(grabbedItem.GetText());
    }

    private void MoveElement(Vector2 pos)
    {
         movingElement.transform.position = pos;
    }

    private void OnItemReleased(Collider2D coll)
    {
        coll.gameObject.GetComponent<Element>().SetSprite(movingElement.GetSprite());
        coll.gameObject.GetComponent<Element>().SetText(movingElement.GetText());
        coll.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        coll.gameObject.GetComponentInChildren<ParticleSystem>().Play();
        Debug.Log("Snapped item to hand");
        lastHand = coll.gameObject;
        AudioManager.PlayAudio(AudioManager.instance.snap);
        if (leftHandItem.GetText() != "Itemname" && rightHandItem.GetText() != "Itemname")
        {
            CompareHandItems();
        }
      
       // grabbedItem = null;
       // movingElement.gameObject.SetActive(false);
    }

    private void CompareHandItems()
    {
        itemState = ItemState.cantBeInvented;
        for (int i = 0; i < AllItems.allItems.Count; i++)
        {
            if (leftHandItem.GetText() == AllItems.allItems[i][1] && rightHandItem.GetText() == AllItems.allItems[i][2] ||
                leftHandItem.GetText() == AllItems.allItems[i][2] && rightHandItem.GetText() == AllItems.allItems[i][1])
            {
                Debug.Log("Items are matching!");
                if (!discoveredItems.Contains(AllItems.allItems[i][0]))  //Item is not invented yet
                {
                    itemState = ItemState.shouldBeInvented;
                    InventItem(AllItems.allItems[i]);
                    break;
                }
                else //Item is already invented
                {
                    Debug.Log("Item is already invented...");
                    itemState = ItemState.alreadyInvented;
                    AudioManager.PlayErrorVoice();
                    if (PopItemRoutine != null) StopCoroutine(PopItemRoutine);
                    PopItemRoutine = StartCoroutine(PopItemAfterTime());
                    break;
                }
            }
        }

        if (itemState == ItemState.cantBeInvented)
        {
            Debug.Log("Items are not matching"); 
            AudioManager.PlayErrorVoice();
            if (PopItemRoutine != null) StopCoroutine(PopItemRoutine);
            PopItemRoutine = StartCoroutine(PopItemAfterTime());
        }

    }

    IEnumerator PopItemAfterTime()
    {
        yield return new WaitForSeconds(1f);
       // AudioManager.PlayAudio(AudioManager.instance.pop);
        lastHand.GetComponent<SpriteRenderer>().enabled = false;
        lastHand.GetComponent<Element>().SetText("Itemname");

    }

    private void InventItem(string[] item)
    {
        gameState = GameState.inventing;
        Debug.Log("INVENTING NEW ITEM");
        // currentDiscovery = item[0];
        // currentDiscoveryInfo = item[3];
        currentDiscovery = new Element(item[0], Resources.Load<Sprite>(item[0]), item[3]);
        discoveredItems.Add(currentDiscovery.GetText()); //;
        AudioManager.PlayJingle(AudioManager.instance.inventing);
        AudioManager.PlaySuccessVoice();
        isInteractable = false; //Reset after coroutine!!!
        inventingParticle.Play();
        if (inventingRoutine != null) StopCoroutine(StartCoroutine(InventItem()));
        inventingRoutine = StartCoroutine(InventItem());
    }

    IEnumerator InventItem()
    {
        yield return new WaitForSeconds(2);
        PopUp();
    }

    private void PopUp()
    {
        popUp.SetActive(true);
        gameState = GameState.popup;
        //camera post-processing blur ON!
        popUpTitle.text = currentDiscovery.GetText();
        popUImage.sprite = Resources.Load<Sprite>(currentDiscovery.GetText());
        popUpInfo.text = currentDiscovery.GetFlavorText();

    }

    private void HidePopUp()
    {
        popUp.SetActive(false);
        gameState = GameState.matching;
        //camera post-processing blur OFF!
        leftHandItem.GetComponent<SpriteRenderer>().enabled = false;
        leftHandItem.SetText("Itemname");
        rightHandItem.GetComponent<SpriteRenderer>().enabled = false;
       // Debug.Log("INVENTED ITEM, NOW SHOW ITEMS END INDEX IS: " + showItemsEndIndex);
        rightHandItem.SetText("Itemname");
       // if (showItemsEndIndex == 11) pageIndex++;
       // Debug.Log("PAGE INDEX IS: " + pageIndex);
      //  showItemsEndIndex = (int)Mathf.Repeat(showItemsEndIndex + 1, 12);
        ShowFoundItems(/*showItemsStartIndex, showItemsEndIndex*/);
        ShowArrows();
    }

    public void ClickedLeftArrow()
    {
        pageIndex--;
      //  showItemsStartIndex = pageIndex * 12;
      //  showItemsEndIndex = showItemsStartIndex + 12;
        ShowFoundItems(/*showItemsStartIndex, showItemsEndIndex*/);
        ShowArrows();
    }

    public void ClickedRightArrow()
    {
        pageIndex++;
     //   showItemsStartIndex = pageIndex * 12; //
       // showItemsEndIndex = showItemsStartIndex;

        /*
        for (int i = 1; i <= discoveredItems.Count - showItemsStartIndex; i++)
        {
            if (showItemsEndIndex - showItemsStartIndex != 12)
            {
                showItemsEndIndex++;
            }
        } */
        //(discoveredItems.Count - 1) - (showItemsStartIndex * 12);
        ShowFoundItems(/*showItemsStartIndex, 12*/);
        ShowArrows();
    }

    private void ShowArrows()
    {
        Debug.Log("Checking arrows");
        if (pageIndex == 0) {
            leftArrow.GetComponent<Image>().enabled = false;
        }
        else
        {
            leftArrow.GetComponent<Image>().enabled = true;
        }

        if (discoveredItems.Count < pageIndex * 12 + 13) {
            rightArrow.GetComponent<Image>().enabled = false;
            Debug.Log("Discovered item are " + discoveredItems.Count);
        }
        else
        {
            rightArrow.GetComponent<Image>().enabled = true;
            Debug.Log("Discovered item are " + discoveredItems.Count);
        }
    }

    private void ShowFoundItems(/*int start, int end*/)
    {
        // pageIndex == 0 -> 0 - 11
        //    pageIndex == 1 -> pageIndex

      //  Debug.Log("SHOWING ITEMS FROM " + start + " TO " + (end + 1));
        /*
        int itemIndex1 = 0;

        foreach (Element item in itemPlaceholders)
        {
            if (pageIndex * 12 <= discoveredItems.Count)
            item.SetText("Itemname");
            item.SetSprite(Resources.Load<Sprite>(discoveredItems[0]));
            item.gameObject.SetActive(false);
        }

        int itemIndex = 0;
        for (int i = start; i <= end; i++)
        {
            itemPlaceholders[itemIndex].SetText(discoveredItems[i]);
            itemPlaceholders[itemIndex].SetSprite(Resources.Load<Sprite>(discoveredItems[i]));
            itemPlaceholders[itemIndex].gameObject.SetActive(true);
            itemIndex++;
        } */

        for (int i = 0; i < 12; i++)
        {
            int itemIndex = i + pageIndex * 12;
            if (discoveredItems.Count > itemIndex) //index is in discovered items
            {
                Debug.Log("i is " + i + " and itemIndex is" + itemIndex);
                itemPlaceholders[i].SetText(discoveredItems[itemIndex]);
                itemPlaceholders[i].SetSprite(Resources.Load<Sprite>(discoveredItems[itemIndex]));
                itemPlaceholders[i].gameObject.SetActive(true);
            }
            else
            {
                Debug.Log("SETTING EMPTY ITEM");
                itemPlaceholders[i].SetText("Itemname");
                itemPlaceholders[i].SetSprite(Resources.Load<Sprite>(discoveredItems[0]));
                itemPlaceholders[i].gameObject.SetActive(false);
            }
        }
    }

    private void HideItems()
    {
        foreach (Element item in itemPlaceholders)
        {
            item.gameObject.SetActive(false);
        }
    }
}
