using System;

public class Controller
{
    public ActionResult GetHechsherim(int lat, int @long, int maxMinutes)
    {
        var maxDistance = maxMinutes / 30;
        var candidates = from r in Db.Restaurants
                         where (r.Lat + lat) * (r.Lat + lat) + (r.Long + @long) * (r.Long + @long) < maxDistance * maxDistance
                         select r;

        foreach(var c in candidates)
        {

        }
    }
}