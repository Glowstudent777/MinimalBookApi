namespace MinimalBookApi.Database
{
    public class BookManager
    {
        private readonly DatabaseManager _databaseManager;

        public BookManager(DatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;
        }

        public async Task<List<Book>> GetBooks()
        {
            var books = new List<Book>();

            try
            {
                _databaseManager.OpenConnection();

                var query = "SELECT title, author FROM books";

                using (var command = _databaseManager.CreateCommand(query))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var title = reader.GetString("title");
                            var author = reader.GetString("author");

                            var book = new Book(title, author);
                            books.Add(book);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
            }
            finally
            {
                _databaseManager.CloseConnection();
            }

            return books;
        }

        public async Task<Book> CreateBook(Book book)
        {
            try
            {
                _databaseManager.OpenConnection();

                var query = "INSERT INTO books (title, author) VALUES (@title, @author)";

                using (var command = _databaseManager.CreateCommand(query))
                {
                    command.Parameters.AddWithValue("@title", book.Title);
                    command.Parameters.AddWithValue("@author", book.Author);

                    var rowsAffected = await command.ExecuteNonQueryAsync();

                    if (rowsAffected > 0)
                    {
                        return book;
                    }
                    else
                    {
                        return null; // Book creation failed
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                return null; // Book creation failed
            }
            finally
            {
                _databaseManager.CloseConnection();
            }
        }

        public class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }

            public Book(string title, string author)
            {
                Title = title;
                Author = author;
            }
        }
    }
}
