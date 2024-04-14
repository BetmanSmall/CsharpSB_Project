using System.Text;

namespace CsharpSB_Project.Practice7.Data;
public class Repository {
    private const string FileName = "Repository.csv";
    private Dictionary<string, Worker> _workersDictionary;
    private List<Worker> _workersList = null;
    // private Worker[] _workersArray;

    public Worker[] GetAllWorkers() {
        Console.WriteLine($"Repository::GetAllWorkers(); -- _workersList:{_workersList}");
        if (_workersList == null) {
            LoadWorkers();
            Console.WriteLine($"Repository::GetAllWorkers(); -- _workersList:{_workersList}");
        }
        return _workersList?.ToArray();
    }

    public Worker GetWorkerById(string id) {
        Console.WriteLine($"Repository::GetWorkerById(); -- _workersDictionary:{_workersDictionary}");
        if (_workersDictionary == null) {
            LoadWorkers();
            Console.WriteLine($"Repository::GetWorkerById(); -- _workersDictionary:{_workersDictionary}");
        }
        if (_workersDictionary != null && _workersDictionary.ContainsKey(id)) {
            return _workersDictionary[id];
        }
        return null;
    }

    public bool DeleteWorker(string id) {
        Console.WriteLine($"Repository::DeleteWorker(); -- _workersDictionary:{_workersDictionary}");
        if (_workersDictionary == null) {
            LoadWorkers();
            Console.WriteLine($"Repository::DeleteWorker(); -- _workersDictionary:{_workersDictionary}");
        }
        if (_workersDictionary != null && _workersDictionary.ContainsKey(id)) {
            _workersDictionary.Remove(id);
            WriteToFile();
            return true;
        }
        return false;
    }

    public void AddWorker(Worker worker) {
        Console.WriteLine($"Repository::AddWorker(); -- _workersDictionary:{_workersDictionary}");
        if (_workersDictionary == null) {
            LoadWorkers();
            Console.WriteLine($"Repository::AddWorker(); -- _workersDictionary:{_workersDictionary}");
        }
        if (_workersDictionary != null) {
            worker.Id = Guid.NewGuid().ToString();
            _workersDictionary.Add(worker.Id, worker);
            WriteToFile();
        }
    }

    public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo) {
        Console.WriteLine($"Repository::GetWorkersBetweenTwoDates(); -- _workersDictionary:{_workersDictionary}");
        if (_workersDictionary == null) {
            LoadWorkers();
            Console.WriteLine($"Repository::GetWorkersBetweenTwoDates(); -- _workersDictionary:{_workersDictionary}");
        }
        if (_workersDictionary != null) {
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
            _workersList = new List<Worker>();
            string line;
            // Console.WriteLine($"ID\t DateTime\t FullName\t Age\t Height\t Birthday\t Place of Birth");
            while ((line = streamReader.ReadLine()) != null) {
                string[] strings = line.Split("#");
                Worker worker = new Worker(strings);
                _workersList.Add(worker);
                _workersDictionary.Add(worker.Id, worker);
            }
            // _workersArray = _workersList.ToArray();
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