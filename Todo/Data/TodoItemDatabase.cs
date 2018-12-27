using Iridium.DB;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Models;

namespace Todo
{
	public class TodoItemDatabase: StorageContext
    {
        public IAsyncDataSet<TodoItem> Items { get; set; }
        public IAsyncDataSet<ChildItem> ChildItems { get; set; }

        protected TodoItemDatabase(IDataProvider dataProvider):base(dataProvider)
		{
            Items = AsyncDataSet<TodoItem>(); 
            ChildItems = AsyncDataSet<ChildItem>();
        }

        public static TodoItemDatabase Create(IDataProvider dataProvider)
        {
            var dbContext = new TodoItemDatabase(dataProvider);
            dbContext.CreateTable<TodoItem>();
            dbContext.CreateTable<ChildItem>();
            return dbContext;
        }

        public async Task<List<TodoItem>> GetItemsAsync()
		{            
            return await Items.ToList();
		}		

		public async Task<TodoItem> GetItemAsync(int id)
		{
            var test = await Items.WithRelations(i => i.ID == id).FirstOrDefault();
            return await Items.WithRelations(i => i.ID == id).FirstOrDefault();
		}

		public async Task<bool> SaveItemAsync(TodoItem item)
		{
			if (item.ID != 0)
			{
				return await Items.Update(item, p => p.Children);
			}
			else
            {
				return await Items.Insert(item,p=>p.Children);
			}
		}

		public async Task<bool> DeleteItemAsync(TodoItem item)
		{
			return await Items.Delete(item);
		}
       
    }
}

