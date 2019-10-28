namespace Model
{
    public class Field
    {
        public string TypeWithName { get; private set; }

        public Field(string typeWithName)
        {
            TypeWithName = typeWithName;
        }

    }
}
