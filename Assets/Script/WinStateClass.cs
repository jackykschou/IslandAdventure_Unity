[System.Serializable]

//class for keeping the down states for the targets
public class WinStateClass
{
	public WinStateClass()
	{
		T1Down = false;
		T2Down = false;
		T3Down = false;
	}
	
	public bool checkState()
	{
		return T1Down && T2Down && T3Down;
	}
	
	public bool T1Down;
	public bool T2Down;
	public bool T3Down;
}