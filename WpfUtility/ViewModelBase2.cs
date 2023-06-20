using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfUtility
{
    /// <summary>INotifyPropertyChanged の実装を提供する ViewModel の基本実装。</summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>プロパティ値を変更するときに発生します。  </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>ViewModelBase クラスの新しいインスタンスを初期化します。</summary>
        public ViewModelBase() { }

        /// <summary>この ViewModelBase の任意のプロパティで有効な値が更新されたときに呼び出されます。変更された特定の依存プロパティは、イベント データで報告されます。  </summary>
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
