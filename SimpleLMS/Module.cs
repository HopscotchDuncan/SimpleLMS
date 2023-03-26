namespace SimpleLMS
{
    public class Module
    {
        public int ID { get; set; }
        public string Name { get; set; }
        //relationships
        public Course Course { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
    }
}
