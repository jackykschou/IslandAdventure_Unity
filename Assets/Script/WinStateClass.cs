[System.Serializable]

//class for keeping the down states for the targets
public class WinStateClass
{
	public WinStateClass()
	{
		states[0] = false;
		states[1] = false;
		states[2] = false;
	}
	
	public bool checkState()
	{
		return  states[0] && states[1] && states[2];
	}
	
	public bool[] states = new bool[3];
}