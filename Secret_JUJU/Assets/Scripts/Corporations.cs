using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class Corporations
{
    public List<Corporation> corporations;

    public Corporations(int maxCount) 
    {
        corporations = new List<Corporation>(maxCount);

        InitializeCorporations();
    }

    private void InitializeCorporations()
    {
        corporations.Add(new Corporation());
    }
}
