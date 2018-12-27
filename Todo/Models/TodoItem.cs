using Iridium.DB;
using Todo.Models;

namespace Todo
{
    [Table.Name("TodoItems")]
	public class TodoItem
	{
        [Column.PrimaryKey(AutoIncrement = true)]
        public int ID { get; set; }
		public string Name { get; set; }
		public string Notes { get; set; }
		public bool Done { get; set; }

        [Relation.OneToOne] 
        public ChildItem Children { get; set; }
    }
}

