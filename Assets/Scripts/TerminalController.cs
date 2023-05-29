using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using TechTweaking.Bluetooth;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TerminalController : MonoBehaviour
{

	public Text devicNameText;
	public Text status;
	public ScrollTerminalUI readDataText;
	
	public GameObject InfoCanvas;
	public GameObject ImageCanvas;
	private  BluetoothDevice device;
	public Text dataToSend;

	public int check;
	public bool answer = false;
	public string[] lines;
	public int[] index = new int[] { 1, 2, 3, 4, 5, 6, 7 };
	private ChangeNote changeNote;

	void Awake ()
	{
		ImageCanvas.SetActive(false);
		BluetoothAdapter.askEnableBluetooth ();
		BluetoothAdapter.OnDeviceOFF += HandleOnDeviceOff;
		BluetoothAdapter.OnDevicePicked += HandleOnDevicePicked;
		changeNote = GetComponent<ChangeNote>();

	}
	
	void HandleOnDeviceOff (BluetoothDevice dev)
	{
		if (!string.IsNullOrEmpty (dev.Name))
			status.text = "Couldn't connect to " + dev.Name + ", device might be OFF";
		else if (!string.IsNullOrEmpty (dev.MacAddress)) {
			status.text = "Couldn't connect to " + dev.MacAddress + ", device might be OFF";
		} 
	}

	void HandleOnDevicePicked (BluetoothDevice device)
	{
		this.device = device;
		device.ReadingCoroutine = ManageConnection;
	}

	public void showDevices ()
	{
		BluetoothAdapter.showDevices ();
	}
	
	public void connect ()
	{
		if (device != null) {
			device.connect ();
			status.text = "Trying to connect...";
		}
	}
	
	public void disconnect ()
	{
		if (device != null)
			device.close ();
	}

	public void send ()
	{		
		if (device != null && !string.IsNullOrEmpty (dataToSend.text)) {
			device.send (System.Text.Encoding.ASCII.GetBytes (dataToSend.text + (char)10));
		}
	}

	IEnumerator  ManageConnection (BluetoothDevice device)
	{
		InfoCanvas.SetActive (false);
		ImageCanvas.SetActive(true);
		
		StartCoroutine("load");


		while (device.IsReading) 
		{
			Debug.Log("Reading");
			byte [] msg = device.read ();

			if (msg != null)
			{	
				string content = System.Text.ASCIIEncoding.ASCII.GetString (msg);
				string [] lines = content.Split(new char[]{'\n','\r'});

				int.TryParse(lines[0], out int answer);

				ChangeNote.DoCheck(check, answer);
				Debug.Log("answer: " + answer);
			}
			yield return null;
		}
	}

	void OnDestroy ()
	{
		BluetoothAdapter.OnDevicePicked -= HandleOnDevicePicked; 
		BluetoothAdapter.OnDeviceOFF -= HandleOnDeviceOff;
	}

	IEnumerator load()
    {
		Debug.Log("Start load");
		for (int i = 0; i < 7; i++)
        {
			check = changeNote.DoChange();
			Debug.Log("check: " + check);
			yield return new WaitForSeconds(3);
		}
	}


}
