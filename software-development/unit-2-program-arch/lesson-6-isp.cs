using System;
using System.Collections.Generic;

public class Program
{
    public void Main()
    {
        var resources = new List<IResource>()
        {
            new ApplicationSettings(),
            new UserSettings(),
            new StaticSettings()
        };

        foreach(var resource in resources)
        {
            IReadableResource readable = resource as IReadableResource;
            if(readable != null) readable.Read();
        }

        // program code

        foreach(var resource in resources)
        {
            IWriteableResource writeable = resource as IWriteableResource;
            if (writeable != null) writeable.Write();
        }
	}
}

public interface IResource
{
}

public interface IReadableResource : IResource
{
    string Read();
}

public interface IWriteableResource : IResource
{
    void Write();
}

public class ApplicationSettings : IReadableResource, IWriteableResource
{
}

public class UserSettings : IReadableResource, IWriteableResource
{
}

public class StaticSettings : IReadableResource
{
    public string Load()
    {
        return "";
    }
}