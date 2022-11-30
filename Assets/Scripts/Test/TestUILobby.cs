using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RoomInfoTest
{
    public string Name;
    public int IdRoom;
}
public class TestUILobby : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Temple;
    public Transform Content;
    public Button CreateRoomBtn;
    public InputField RoomName;

    void Start()
    {
        var roominfo = new List<RoomInfoTest>();
        roominfo.Add(new RoomInfoTest { Name = "phong 1", IdRoom = 1 }) ;
        SpawnRoom(roominfo);
        CreateRoom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnRoom(List<RoomInfoTest> RoomInfos)
    {
   
        
        var obj = Instantiate(Temple, Content);
        obj.SetActive(true);
        obj.transform.GetChild(1).GetComponent<Text>().text = " 1";
        obj.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate
        {

        });
    }

    public void CreateRoom()
    {
        CreateRoomBtn.GetComponent<Button>().onClick.AddListener(delegate
        {
            var obj = Instantiate(Temple, Content);
            obj.SetActive(true);
            obj.transform.GetChild(1).GetComponent<Text>().text = RoomName.text;
            obj.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate
            {

            });
        });
    }
}

