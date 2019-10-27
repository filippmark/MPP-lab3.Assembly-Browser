namespace Model
{
    public class Field
    {
        public string TypeWithName { get; set; }

        public Field(string typeWithName)
        {
            TypeWithName = typeWithName;
        }
    }
}
