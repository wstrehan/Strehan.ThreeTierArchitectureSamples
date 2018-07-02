using System;

public class Gadget : GadgetInsertData
{
    public int GadgetId { get; set; }
    public string ColorName { get; set; }
    public string SizeName { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }
}