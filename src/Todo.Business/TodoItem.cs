namespace Todo.Business
{
    public class TodoItem
    {
        public TodoItem()
        {
        }

        public TodoItem(string name, bool isComplete)
        {
            Name = name;
            IsComplete = isComplete;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public string Secret { get; set; }

        public void Update(TodoItem todoItem)
        {
            Name = todoItem.Name;
            IsComplete = todoItem.IsComplete;
        }
    }
}
