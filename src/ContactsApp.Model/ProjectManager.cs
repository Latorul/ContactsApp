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
    /// Полный путь к файлу.
    /// </summary>
    public static string FilePath { get; set; } =
        $"{AppData}\\IvanovAA\\ContactsApp\\ContactsApp.notes";


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
            var folder = Path.GetDirectoryName(FilePath);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            File.WriteAllText(FilePath, JsonSerializer.Serialize(project));
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}