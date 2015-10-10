using System.ComponentModel;

namespace Gss.Entities
{
    public class BaseInfo : INotifyPropertyChanged
    {
        #region --- 通知属性改变事件接口---

        /// <summary>
        /// PropertyChanged event of the INotifyPropertyChanged.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raise the PropertyChanged event.
        /// </summary>
        /// <param name="name">name of the property has been changed</param>
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
