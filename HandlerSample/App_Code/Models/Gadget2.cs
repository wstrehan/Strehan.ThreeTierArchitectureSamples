public class Gadget2 : Gadget
{
    public Gadget2(Gadget gadget)
    {
        //Use reflection go copy all of the fields from the Gadget Object to the Gadget2 object
        foreach (var prop in gadget.GetType().GetProperties())
        {
            this.GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(gadget, null), null);
        }

        //Format date on the Server instead of in the javascript
        this.UpdateDateTimeString = gadget.UpdatedDateTime.ToString();
    }

    //Javascript will use this instead of the UpdateDateTime 
    public string UpdateDateTimeString { get; set; }
}