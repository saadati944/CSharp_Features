namespace csharpExpert.features
{
    public class AnonymousTypes : IFeature
    {
        public void ShowFeature()
        {
            "Anonymous Types".WriteLine();
            var person =
                new
                {
                    FirstName = "ali",
                    LastName = "saadati",
                    Age = 20
                };
            
            "person is :".WriteLine();
            person.WriteLine();
            "person type :".WriteLine();
            person.GetType().WriteLine();
            
            "\nyou can even use switch case with these types".WriteLine();
            "for example result of this switch case :".WriteLine();
            ("switch (person)\n" +
             "{\n" +
             "    case {FirstName:\"ali\"}:\n" +
             "        \"ok\".WriteLine();\n" +
             "    break;\n" +
             "}").WriteLine();
            "is :".WriteLine();
            switch (person)
            {
                case {FirstName:"ali"}:
                    "ok".WriteLine();
                    break;
            }
        }
    }
}