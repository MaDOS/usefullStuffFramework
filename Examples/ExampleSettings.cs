using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using usefullStuff.Settings;
using usefullStuff.Serialization;

namespace usefullStuff.Examples
{
    [Serializable]
    public class ExampleSettings
    {
        int data;
        string moreData;

        public int Data
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
            }
        }

        public string MoreData
        {
            get
            {
                return moreData;
            }

            set
            {
                moreData = value;
            }
        }
    }

    public class ExampleSettingsManager : SettingsManager
    {
        protected override event SavingInitiatedEventHandler SavingInitiated;
        protected override event SavingDoneEventHandler SavingDone;
        protected override event LoadingInitiatedEventHandler LoadingInitiated;
        protected override event LoadingDoneEventHandler LoadingDone;
        
        private ExampleSettings settings;

        public ExampleSettings Settings
        {
            get
            {
                return settings;
            }

            set
            {
                settings = value;
            }
        }

        public ExampleSettingsManager()
        { }

        public override void Load(FileInfo file)
        {
            FileInfo dummyFileInfo = new FileInfo("C:\blub.bin");
            
            LoadingInitiated(new LoadingEventArgs() { File = dummyFileInfo });

            this.Settings = Serializer.DeserializeFromBinary<ExampleSettings>(dummyFileInfo);

            LoadingDone(new LoadingEventArgs() { File = dummyFileInfo });
        }

        public override void Save(FileInfo file)
        {
            FileInfo dummyFileInfo = new FileInfo("C:\blub.bin");

            SavingInitiated(new SavingEventArgs() { File = dummyFileInfo });

            Serializer.SerializeAsBinary<ExampleSettings>(this.settings, dummyFileInfo);

            SavingDone(new SavingEventArgs() { File = dummyFileInfo });
        }
    }
}
