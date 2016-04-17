using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace usefullStuff.Settings
{
    public abstract class SettingsManager
    {
        public delegate void SavingInitiatedEventHandler(SavingEventArgs e);
        public delegate void SavingDoneEventHandler(SavingEventArgs e);

        public delegate void LoadingInitiatedEventHandler(LoadingEventArgs e);
        public delegate void LoadingDoneEventHandler(LoadingEventArgs e);

        protected abstract event SavingInitiatedEventHandler SavingInitiated;
        protected abstract event SavingDoneEventHandler SavingDone;
        protected abstract event LoadingInitiatedEventHandler LoadingInitiated;
        protected abstract event LoadingDoneEventHandler LoadingDone;

        public abstract void Save(FileInfo file);

        public abstract void Load(FileInfo file);
    }

    public class LoadingEventArgs : EventArgs
    {
        FileInfo file;

        public FileInfo File
        {
            get
            {
                return file;
            }

            set
            {
                file = value;
            }
        }
    }

    public class SavingEventArgs : EventArgs
    {
        FileInfo file;

        public FileInfo File
        {
            get
            {
                return file;
            }

            set
            {
                file = value;
            }
        }
    }
}
