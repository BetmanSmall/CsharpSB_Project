using System.Text;

namespace CsharpSB_Project.Practice7.Data;
public class Repository {
    private const string FileName = "Repository.csv";
    private Dictionary<string, Worker> _workersDictionary;

    public Worker[] GetAllWorkers() {
        if (LoadWorkers()) {
            return _workersDictionary.Values.ToArray();
        }
        return null;
    }

    public Worker GetWorkerById(string id) {
        if (LoadWorkers()) {
            if (_workersDictionary.ContainsKey(id)) {
                return _workersDictionary[id];
            }
        }
        return null;
    }

    public bool DeleteWorker(string id) {
        if (LoadWorkers()) {
            if (_workersDictionary.ContainsKey(id)) {
                _workersDictionary.Remove(id);
                WriteToFile();
                return true;
            }
        }
        return false;
    }

    public void AddWorker(Worker worker) {
        if (LoadWorkers()) {
            worker.Id = Guid.NewGuid().ToString();
            _workersDictionary.Add(worker.Id, worker);
            WriteToFile();
        }
    }

    public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo) {
        if (LoadWorkers()) {
            List<Worker> outWorkers = new List<Worker>();
            foreach (Worker worker in _workersDictionary.Values) {
                if (dateFrom < worker.CreatedDateTime && worker.CreatedDateTime < dateTo) {
                    outWorkers.Add(worker);
                }
            }
            return outWorkers.ToArray();
        }
        return null;
    }

    private bool LoadWorkers() {
        if (!File.Exists(FileName)) {
            Console.WriteLine("Справочник отсутствует!");
            return false;
        }
        using (StreamReader streamReader = new StreamReader(FileName, Encoding.UTF8)) {
            _workersDictionary = new Dictionary<string, Worker>();
            string line;
            while ((line = streamReader.ReadLine()) != null) {
                string[] strings = line.Split("#");
                Worker worker = new Worker(strings);
                _workersDictionary.Add(worker.Id, worker);
            }
            return true;
        }
    }

    private void WriteToFile() {
        using (StreamWriter streamWriter = new StreamWriter(FileName, false, Encoding.UTF8)) {
            foreach (Worker worker in _workersDictionary.Values) {
                streamWriter.WriteLine(worker.GetLineWriteToFile());
            }
        }
    }
}