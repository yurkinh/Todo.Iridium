using Iridium.DB;

namespace Todo
{
	public class TodoItem
	{
        [Column.PrimaryKey(AutoIncrement = true)]
        public int ID { get; set; }
		public string Name { get; set; }
		public string Notes { get; set; }
		public bool Done { get; set; }
	}
}

