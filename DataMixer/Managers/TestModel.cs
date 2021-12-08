namespace DataMixer.Managers
{
    public class TestModel : AuthModel
    {
        public string? TestPropA { get; set; }
        public string? TestPropB { get; set; }

        public override string ToString()
        {
            return string.Join("\n", new string[]
            {
                TestPropA!,
                TestPropB!
            });
        }
    }
}