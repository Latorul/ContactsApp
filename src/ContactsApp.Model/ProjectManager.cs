namespace ContactsApp.Model;

/// <summary>
/// Класс для работы с файлами.
/// </summary>
public static class ProjectManager
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
    /// Загружает из файла список контактов в <see cref="Project"/>.
    /// </summary>
    public static Project LoadProject()
    {
        try
        {
            using FileStream fileStream = File.OpenRead(FilePath);
            var project = JsonSerializer.Deserialize<Project>(fileStream);
            fileStream.Close();

            project ??= new Project();
            return project;
        }
        catch
        {
            return new Project();
        }
    }

    /// <summary>
    /// Сохраняет все контакты из <see cref="Project"/> в файл.
    /// </summary>
    /// <param name="project">Сохраняемый проект.</param>
    public static void SaveProject(Project project)
    {
        try
        {
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }

            File.WriteAllText(FilePath, JsonSerializer.Serialize(project));
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    /// <summary>
    /// Сохраняет все контакты из <see cref="Project"/> в файл.
    /// </summary>
    /// <param name="project">Сохраняемый проект.</param>
    /// <param name="folderPath">Директория, в которой будет лежать файл с сохранением.</param>
    /// <param name="filePath">Путь к файлу с сохранением.</param>
    public static void SaveProject(Project project, string folderPath, string filePath)
    {
        try
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            File.WriteAllText(filePath, JsonSerializer.Serialize(project));
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}