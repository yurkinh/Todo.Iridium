using Iridium.DB;

namespace Todo.Models
{
    [Table.Name("ChildItems")]
    public class ChildItem
    {
        [Column.PrimaryKey(AutoIncrement = true)]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ParentID { get; set; }
       
    }
}
