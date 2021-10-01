public class Plant
{
    // Properties = Species, Common name, Family, Order
    private string[] properties = new string[4];

    public Plant(string species, string commonName, string family, string order)
    {
        properties[0] = species;
        properties[1] = commonName;
        properties[2] = family;
        properties[3] = order;
    }

    public string GetSpecies()
    {
        return properties[0];
    }
    public string GetCommonName()
    {
        return properties[1];
    }
    public string GetFamily()
    {
        return properties[2];
    }
    public string GetOrder()
    {
        return properties[3];
    }
    public string GetByID(int id)
    {
        return properties[id];
    }
    public int GetPropertiesLength()
    {
        return properties.Length;
    }
}
