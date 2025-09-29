﻿namespace ToDo
{
    public class ToDoService
    {
        private IToDoItemRepository _repository;
        public ToDoService(IToDoItemRepository repository) 
        {
            _repository = repository;
        }

        public void CreateNewToDoItem(ToDoItem newToDoItem) 
        {
            if (newToDoItem.Due < DateTime.Now)
                throw new InvalidOperationException("Cannot create a todo-item thats already due!");

            if (ValidateToDoItem(newToDoItem))
            {
                _repository.Insert(newToDoItem);
            }
        }

        public ICollection<ToDoItem> GetAll() 
        {
            return _repository.GetAll();
        }

        public bool ValidateToDoItem(ToDoItem toDoItem) 
        {
            if (string.IsNullOrWhiteSpace(toDoItem.Title))
                throw new InvalidOperationException("Todo-items require a title.");

            if (string.IsNullOrWhiteSpace(toDoItem.AssignedTo))
                throw new InvalidOperationException("Todo-items need to be assigned to someone.");

            return true;
        }
    }
}
