namespace hm03_11
{
    class Person
    {
        public string? Surname { get; set; }
        public string? Name { get; set; }

        public override string ToString()
        {
            return string.Concat(Name, " ", Surname);
        }
    }
}
