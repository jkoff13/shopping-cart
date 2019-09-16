using System.Collections.Generic;
using ShoppingCart.Commands;
using ShoppingCart.Models;

namespace ShoppingCart
{
    public class UndoRedoStack
    {
        private readonly ShoppingCartModel _shoppingCartModel;
        private readonly Stack<ICommand> _undo;
        private readonly Stack<ICommand> _redo;

        public UndoRedoStack()
        {
            _shoppingCartModel = new ShoppingCartModel();
            _undo = new Stack<ICommand>();
            _redo = new Stack<ICommand>();
        }

        public void Do(ICommand cmd)
        {
            cmd.Do(_shoppingCartModel);
            _undo.Push(cmd);
            _redo.Clear();
        }
        
        public void Undo()
        {
            if (_undo.Count > 0)
            {
                var cmd = _undo.Pop();
                cmd.Undo( _shoppingCartModel);
                _redo.Push(cmd);
            }
        }
        
        public void Redo()
        {
            if (_redo.Count > 0)
            {
                var cmd = _redo.Pop();
                cmd.Do(_shoppingCartModel);
                _undo.Push(cmd);
            }
        }

        public ShoppingCartModel GetCart()
        {
            return _shoppingCartModel;
        }
    }
}