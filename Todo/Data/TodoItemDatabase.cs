using Iridium.DB;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Todo
{
	public class TodoItemDatabase: StorageContext
    {
        public IAsyncDataSet<TodoItem> Items { get; set; }        

        protected TodoItemDatabase(IDataProvider dataProvider):base(dataProvider)
		{
            Items = AsyncDataSet<TodoItem>();
        }

        public static TodoItemDatabase Create(IDataProvider dataProvider)
        {
            var dbContext = new TodoItemDatabase(dataProvider);
            dbContext.CreateTable<TodoItem>();
            return dbContext;
        }

        public async Task<List<TodoItem>> GetItemsAsync()
		{
			return await Items.ToList();
		}		

		public async Task<TodoItem> GetItemAsync(int id)
		{
			return await Items.Where(i => i.ID == id).FirstOrDefault();
		}

		public async Task<bool> SaveItemAsync(TodoItem item)
		{
			if (item.ID != 0)
			{
				return await Items.Update(item);
			}
			else
            {
				return await Items.Insert(item);
			}
		}

		public async Task<bool> DeleteItemAsync(TodoItem item)
		{
			return await Items.Delete(item);
		}
	}
}

