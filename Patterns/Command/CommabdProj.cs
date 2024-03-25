using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    public class AddTextCommand : ICommand
    {
        private readonly Editor _editor;
        private readonly string _text;

        public AddTextCommand(Editor editor, string text)
        {
            _editor = editor;
            _text = text;
        }

        public void Execute()
        {
            _editor.AddText(_text);
        }

        public void Undo()
        {
            _editor.DeleteText(_text);
        }
    }

    public class DeleteTextCommand : ICommand
    {
        private readonly Editor _editor;
        private readonly string _text;

        public DeleteTextCommand(Editor editor, string text)
        {
            _editor = editor;
            _text = text;
        }

        public void Execute()
        {
            _editor.DeleteText(_text);
        }

        public void Undo()
        {
            _editor.AddText(_text);
        }
    }

    public class SelectTextCommand : ICommand
    {
        private readonly Editor _editor;
        private readonly string _text;

        public SelectTextCommand(Editor editor, string text)
        {
            _editor = editor;
            _text = text;
        }

        public void Execute()
        {
            _editor.SelectText(_text);
        }

        public void Undo()
        {
            _editor.DeselectText(_text);
        }
    }

    public class Editor
    {
        private readonly List<string> _text = new List<string>();
        private readonly List<string> _selectedText = new List<string>();

        public void AddText(string text)
        {
            _text.Add(text);
            Console.WriteLine($"Added text: {text}");
        }

        public void DeleteText(string text)
        {
            _text.Remove(text);
            Console.WriteLine($"Deleted text: {text}");
        }

        public void SelectText(string text)
        {
            _selectedText.Add(text);
            Console.WriteLine($"Selected text: {text}");
        }

        public void DeselectText(string text)
        {
            _selectedText.Remove(text);
            Console.WriteLine($"Deselected text: {text}");
        }

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
        }

        public void UndoCommand(ICommand command)
        {
            command.Undo();
        }
    }
}
