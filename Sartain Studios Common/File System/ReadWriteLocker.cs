using System.IO;
using System.Threading;

namespace Sartain_Studios_Common.File_System
{
    public class ReadWriteLocker
    {
        private static ReaderWriterLockSlim _readWriteLock = new ReaderWriterLockSlim();

        public void WriteToFileThreadSafe(string path, string content)
        {
            _readWriteLock.EnterWriteLock();
            try
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(content);
                    sw.Close();
                }
            }
            finally
            {
                _readWriteLock.ExitWriteLock();
            }
        }
    }
}