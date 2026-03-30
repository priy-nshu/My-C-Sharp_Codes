using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Standard
{
    public string StandardName { get; set; }
    public string StandardDescription { get; set; }
    public int StandardID { get; set; }



    public List<Standard> CreateStandards()
    {
        return new List<Standard>()
    {
        new Standard(){StandardID=1,StandardName="2A",StandardDescription="This is standard 2"},
        new Standard(){StandardID=2,StandardName="1A",StandardDescription="This is standard 1"},
        new Standard(){StandardID=3,StandardName="3A",StandardDescription="This is standard 3"},
        new Standard(){StandardID=4,StandardName="3A",StandardDescription="This is standard 2"},
        new Standard(){StandardID=5,StandardName="3A",StandardDescription="This is standard 2"},
        new Standard(){StandardID=6,StandardName="4A",StandardDescription="This is standard 2"},
        new Standard(){StandardID=7,StandardName="5C",StandardDescription="This is standard 2"},
        new Standard(){StandardID=8,StandardName="6B",StandardDescription="This is standard 2"},
    };
    }
}