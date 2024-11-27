using LibraryManagementAPI.Models;

public class AudioBook
{
    public int AudioBookID { get; set; }
    public int ItemID { get; set; }
    public string? Publisher { get; set; }
    public string? ISBN { get; set; }

    public LibraryItem LibraryItem { get; set; }
}
