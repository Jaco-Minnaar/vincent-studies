using TodoApp;

var todos = ReadTodosFromFile();

if (todos is null) {
    return 1;
}

var running = true;
var newId = 0;

while (running) {
    Console.Write(" > ");
    var input = Console.ReadLine();

    switch (input) {
        case "q": 
            Console.WriteLine("Goodbye!");
            running = false;
            break;
        case "read": 
            PrintTodos();
            break;
        case "create":
            CreateTodo();
            break;
        case var s when s?.StartsWith("done") == true: 
            MarkTodoDone(s);
            break;
        case var s: 
            Console.WriteLine("[{0}] is not a valid command!", s);
            break;
    }
}

return 0;

void PrintTodos() {
    foreach (var todo in todos.OrderBy(t => t.Priority))  {
        Console.WriteLine("{0}: {1} [{2}]", todo.Id, todo.Text, todo.IsDone ? "Done" : "Not Done");
    }
}

void CreateTodo() {
    Console.WriteLine();
    Console.Write(" Text:  ");
    var text = Console.ReadLine();

    if (string.IsNullOrEmpty(text)) {
        Console.WriteLine("Todo text is invalid!");
        return;
    }

    Console.Write(" Priority:  ");
    var priorityStr = Console.ReadLine();

    if (!int.TryParse(priorityStr, out var priority)) {
        Console.WriteLine("{0} is not a valid priority!", priorityStr);
        return;
    }

    var newTodo = new Todo(newId, priority, text, false);
    
    todos.Add(newTodo);
    
    newId++;

    WriteTodosToFile();
}

void MarkTodoDone(string input) {
    var parts = input.Split(' ');
    if (parts.Length != 2) {
        Console.WriteLine("Invalid input for [done] command.");
        return;
    }

    if (!int.TryParse(parts[1], out var todoId )) {
        Console.WriteLine("{0} is not a valid todo ID!", parts[1]);
        return;
    }

    var todo = todos.FirstOrDefault(t => t.Id == todoId);

    if (todo is null) {
        Console.WriteLine("Could not find a Todo with ID [{0}]", todoId);
        return;
    }
    
    todo.IsDone = true;

    WriteTodosToFile();
}

void WriteTodosToFile() {
    using var file = File.Open("todos.csv", FileMode.Create);
    using var buffer = new StreamWriter(file);

    foreach (var todo in todos) {
        buffer.WriteLine("{0},{1},{2},{3}", todo.Id, todo.Priority, todo.Text, todo.IsDone);
    }
    
    
}

List<Todo>? ReadTodosFromFile() {
    using var file = File.OpenRead("todos.csv");
    using var reader = new StreamReader(file);
    List<Todo> todos = [];

    while (reader.ReadLine() is string line) {
        var parts = line.Split(',');
        
        if (parts.Length != 4) {
            Console.WriteLine("File corrupted");
            return null;
        }
        
        if (!int.TryParse(parts[0], out var todoId) || !int.TryParse(parts[1], out var priority) || !bool.TryParse(parts[3], out var isDone)) {
            Console.WriteLine("File corrupted");
            return null;
        }

        var todo = new Todo(todoId, priority, parts[2], isDone);
        todos.Add(todo);
    }
    
    return todos;
}


