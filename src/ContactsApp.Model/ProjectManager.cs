namespace ContactsApp.Model;

/// <summary>
/// Класс для работы с файлами.
/// </summary>
public class ProjectManager
{
    /// <summary>
    /// Путь к каталогу AppData.
    /// </summary>
    private static readonly string AppData =
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

    /// <summary>
    /// Путь к каталогу для сохранения контакта.
    /// </summary>
    private static readonly string FolderPath = $"{AppData}\\IvanovAA\\ContactsApp";
    
    /// <summary>
    /// Полный путь к файлу.
    /// </summary>
    private static readonly string FilePath = $"{FolderPath}\\{FileName}";
    
    /// <summary>
    /// Название файла.
    /// </summary>
    private const string FileName = "ContactsApp.notes";


    /// <summary>
    /// Сохраняет все контакты из <see cref="Project"/> в файл.
    /// </summary>
    public void SaveProject(Project project)
    {
        try
        {
            if (Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }

            File.WriteAllText(FilePath, JsonSerializer.Serialize(project));
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    /// <summary>
    /// Загружает из файла список контактов в <see cref="Project"/>.
    /// </summary>
    public Project LoadProject()
    {
        try
        {
            if (!Directory.Exists(FolderPath))
            {
                throw new DirectoryNotFoundException(FolderPath);
            }

            if (!File.Exists(FilePath))
            {
                throw new FileNotFoundException(FilePath);
            }

            using FileStream fileStream = File.OpenRead(FilePath);
            Project? project = JsonSerializer.Deserialize<Project>(fileStream);
            fileStream.Close();

            project ??= new Project();
            return project;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}