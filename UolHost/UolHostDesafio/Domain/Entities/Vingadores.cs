namespace Domain.Entities
{
    public class Vingadores
    {
        public class Root
        {
            public List<Vingador> vingadores { get; set; }
        }

        public class Vingador
        {
            public Vingador(string codinome)
            {
                this.codinome = codinome;
            }

            public string codinome { get; set; }
        }

    }
}
