using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculator
{
    /// <summary>Execute および CanExecute コールバックがデリゲートによって処理される ICommand の実装。</summary>
    public class DelegateCommand : ICommand
    {
        /// <summary>コマンドの実行時に実行するアクション。</summary>
        private readonly Action _execute;

        /// <summary>このコマンドが実行可能かどうかを評価する関数。 このパラメーターが null の場合、コマンドは常に実行可能です。</summary>
        private readonly Func<bool> _canExecute;

        /// <summary>コマンドを実行するかどうかに影響するような変更があった場合に発生します。</summary>
        public event EventHandler? CanExecuteChanged
        {
            add    { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>DelegateCommand クラスの新しいインスタンスを初期化します。 このコンストラクターを使用して DelegateCommand を初期化すると、常に実行できるコマンドが生成されます。</summary>
        /// <param name="execute">コマンドの実行時に実行するアクション。</param>
        public DelegateCommand(Action execute)
        {
            _execute = execute;
            _canExecute = () => { return true; };
        }

        /// <summary>DelegateCommand クラスの新しいインスタンスを初期化します。</summary>
        /// <param name="execute">コマンドの実行時に実行するアクション。</param>
        /// <param name="canExecute">このコマンドが実行可能かどうかを評価する関数。 このパラメーターが null の場合、コマンドは常に実行可能です。</param>
        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>コマンドを実行します。</summary>
        /// <param name="parameter">実行デリゲートに渡すパラメーター (コンストラクターで指定)。</param>
        public void Execute(object? parameter)
        {
            _execute?.Invoke();
        }

        /// <summary>このコマンドが実行可能かどうかを示す値を取得します。</summary>
        /// <param name="parameter">コンストラクターで指定された canExecute デリゲートに渡すパラメーター。</param>
        /// <returns>コマンドが実行可能な場合、または初期化中に指定された canExecute が null の場合は True。</returns>
        public bool CanExecute(object? parameter)
        {
            return _canExecute?.Invoke() ?? true;
        }

    }
}
