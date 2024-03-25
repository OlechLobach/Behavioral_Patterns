using CommandPattern;

namespace MainProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Editor editor = new Editor();

            ICommand addCommand = new AddTextCommand(editor, "Hello");
            ICommand deleteCommand = new DeleteTextCommand(editor, "Hello");
            ICommand selectCommand = new SelectTextCommand(editor, "World");

            editor.ExecuteCommand(addCommand);
            editor.ExecuteCommand(deleteCommand);
            editor.ExecuteCommand(selectCommand);

            editor.UndoCommand(selectCommand);
            editor.UndoCommand(deleteCommand);
            editor.UndoCommand(addCommand);
        }
    }
}




