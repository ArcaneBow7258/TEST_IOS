using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
/*
    Draggable and interactive.

*/
public enum Slot_Type{
    main,
    equip,
    hotbar
}

public class Inventory_Slot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    private Color trans = new Color(1,1,1,0.6f);

    [Header("Item Information")]
    public Item item;
    public int stack;
    public Slot_Type type;
    [Header("Display")]
    public RectTransform slot;
    public RectTransform slot_item;
    public Image slot_item_image;
    public TMP_Text stack_text;
    public void Awake(){
        validate();
    }
    public void OnBeginDrag(PointerEventData eventData)
    { 
        if(item == null || !UI_Manager.Instance.UI_Inventory.activeSelf) return;
        //slot_item.get.blocksRaycasts = false;
        slot_item_image.color = trans;
        //First parent is hotbar/panel, next up is InventoryGroup OR cnvas.
        //need to render it above everything
        slot_item_image.transform.SetParent(transform.parent.transform.parent);
        slot_item_image.transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(item == null || !UI_Manager.Instance.UI_Inventory.activeSelf) return;
        slot_item.position += new Vector3(eventData.delta.x , eventData.delta.y, 0);
    }
    public void OnEndDrag(PointerEventData eventData)
    {

        //cg.blocksRaycasts = true;
        slot_item_image.transform.SetParent(transform);
        slot_item.localPosition = Vector3.zero;
        slot_item_image.color = Color.white;
        if(item == null) return;
        //LayoutRebuilder.MarkLayoutForRebuild(transform.parent.GetComponent<RectTransform>());
    }
    public void OnDrop(PointerEventData eventData)
    {
        if(!UI_Manager.Instance.UI_Inventory.activeSelf) return;
        //Finish dragging image, put ack in hiearchy, bit redudant
        slot_item_image.transform.SetParent(transform);
        //Verify we were dragging something
        if(eventData.pointerDrag != null){
            Inventory_Slot donator =  eventData.pointerDrag.GetComponent<Inventory_Slot>();
            //Drop logic:
            if(donator == this){

            }else if(item == null || donator.item != item){
                //Swapping logic
                (donator.item, item) = (item, donator.item);
                (donator.stack, stack) = (stack, donator.stack);
                (donator.slot_item_image.sprite, slot_item_image.sprite) = (slot_item_image.sprite, donator.slot_item_image.sprite);

            }else if(donator.item == item){
                stack += donator.stack ;
                if(stack <= item.stack_size){
                    donator.stack = 0;
                    donator.item = null;
                    slot_item_image.sprite = null;
                }else{
                    donator.stack =stack -  item.stack_size ;
                    stack = item.stack_size;
                }
            }
            donator.slot_item_image.color = Color.white;
            donator.slot_item.localPosition = Vector3.zero;

            donator.validate();
            validate();
        }
    }

    public void validate(){
        if(item == null){
            stack = 0;   
            slot_item_image.gameObject.SetActive(false);
            stack_text.gameObject.SetActive(false);
        }else if(stack == 0){
            item = null;
            slot_item_image.gameObject.SetActive(false);
            stack_text.gameObject.SetActive(false);
        }else{
            slot_item_image.sprite = item.inventory_image;
            slot_item_image.gameObject.SetActive(true);
            stack_text.gameObject.SetActive(true);
            stack_text.text = (item.stack_size > 0)  ? stack.ToString() : null;
        }
        
        
    }

}
