namespace LibraryManagementAPI.Models
{
    public class LibraryItem
    {
        public int ItemID { get; set; } 
        public string Title { get; set; }
        public string Author { get; set; }
        public string ItemType { get; set; } 
        public bool IsBorrowed { get; set; } = false;
        public string? Borrower { get; set; }
        public DateTime? BorrowedDate { get; set; }
    }

}