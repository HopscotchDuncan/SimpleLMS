namespace SimpleLMS
{
    public class Course
    {
        public int? ID { get; set; }

        public string Name { get; set; }
        //relationship
        public ICollection<Module> Modules { get; set; }
    }
}
