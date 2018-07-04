Chatty Code

// calculate the Handwavium Amount
// take the speed (a) times the distance (c)
// add the fudge factor (3)
// and divide by the radius (r) plus 2 just for fun
var result = a * c + 3 / (2 + r);

const int FUDGE_FACTOR = 3;
const int JUST_FOR_FUN = 2;

/**
 * The Handwavium Amount is a fake idea we made up in class
 * @param 
 */
public int CalculateHandwavium(int speed, int distance, int radius) {
	var iota = speed * distance;
	var fudge = iota + FUDGE_FACTOR;
	var gimmel = JUST_FOR_FUN + radius;

	var handwaviumAmount = fudge / gimmel;
	return handwaviumAmount;
}







Long Method

var handwavium = CalculateHandwavium()
// calculate handwavium
.....

var withXFactor = handwavium.ApplyXFactor()
// apply x factor
......

// send update to server
......







Unsafe Conditions - if / while
if(user.AdminAccessAuthorized()) {

}

public bool AdminAccessAuthorized() {
	var isAdmin = IsInRole("admin");
	var authedWithoutAdmin = IsAuthenticated && Environment.DoNotRequireAmdin;

	return isAdmin || authedWithoutAdmin;
}




You Gave Code A Bad Name
Hungarian / Apps Hungarian / short variable names / long names / NOT Hungarian

var authorName = "author name";
var ixBook = 7;

class Connection {
	void Open()
	void Close()
}



Bad Shalom Bayis (Too Many Arguments)
public int Distance(int x1, int x2, int y1, int y2, int z1, int z2) {
}





Primitive Obsession
string addrLine1
string addrLine2
string city
string state





Feature Envy
public class PointController : Controller {
	public int Distance(Point a, Point b){
		return Math.Sqrt(Math.Pow(a.X+b.X,2) + Math.Pow(a.Y+b.Y, 2));
	}
}

class Point {
  public int X;
  public int Y;
  public int Z;

  public int DistanceTo(Point other) {
    return Math.Sqrt(Math.Pow(this.X + other.X,2) + Math.Pow(this.Y + other.Y, 2));
  }
}







WET code - Write Everything Twice (opp of DRY)
MOIST code - in btwn WET and DRY

if IsWin((1,2),1,0)
if IsWin((2,2),1,0)

bool IsWin(origin, offsetx, offsety) {
  return Board[origin.x,originy] == Board[origin.x-offsetx,origin.y-offsety] == Board[origin.x+offsetx,origin.y+offsety];
}






Overcrowding (Large Class) (god class)




Indecent exposure





Dead Code