using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomInfo
{
    public int roomID;
    public string name; 
}


public class LobbyController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Template;
    public Transform Content;
    public InputField RoomNameInput;
    public InputField PasswordInput;
    public int click = 2;

    void Start()
    {
        var RoomInfos = new  List<RoomInfo>();
        RoomInfos.Add(new RoomInfo { name = "Phong 1", roomID = 1});
        RoomInfos.Add(new RoomInfo { name = "Phong 2", roomID = 2 });
        SpawnRoom(RoomInfos);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnRoom(List<RoomInfo> roomInfos)
    {
        foreach(var roomInfo in roomInfos)
        {
            var obj = Instantiate(Template, Content);
            obj.SetActive(true);
            obj.transform.GetChild(0).GetComponent<Text>().text = " ID: " + roomInfo.roomID + " - " + roomInfo.name;
            obj.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() => JoinRoom(roomInfo.roomID));
        }
    }
    void JoinRoom(int RoomID)
    {
        Debug.Log("Join room" + RoomID);
    }
    public void CreateRoomBtn()
    {
        click += 1;
        Debug.Log("Tao phong:" + RoomNameInput.text + "------ Mat khau:" + PasswordInput.text);
     
        var obj = Instantiate(Template, Content);
        obj.SetActive(true);
        obj.transform.GetChild(0).GetComponent<Text>().text = " ID: "  + click + " - " + RoomNameInput.text;
        obj.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() => JoinRoom(click));

    }
}
