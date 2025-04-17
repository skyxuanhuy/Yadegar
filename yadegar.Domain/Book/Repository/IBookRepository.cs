/*
 Interface for repository operations related to storing and retrieving each user's books.
 Defines methods for querying books by various criteria such as title, author, and genre.
*/
using yadegar.Domain.Enum;
using yadegar.Domain.Model;

namespace yadegar.Domain.Book.Repository;

public interface IBookRepository
{
    // ============== BOOK FINDING LOGIC ==============

    /// <summary>
    /// Finds a book by its unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the book</param>
    /// <returns>The book if found; otherwise null</returns>
    Task<Model.Book?> FindBookById(long id);

    /// <summary>
    /// Retrieves all books matching the specified title
    /// </summary>
    /// <param name="title">The title to search for</param>
    /// <returns>A list of books with matching titles</returns>
    Task<IReadOnlyList<Model.Book?>> FindAllBooksByTitle(string title);

    /// <summary>
    /// Retrieves all books by the specified author
    /// </summary>
    /// <param name="author">The author to search for</param>
    /// <returns>A list of books by the specified author</returns>
    Task<IReadOnlyList<Model.Book?>> FindAllBooksByAuthor(Author author);

    /// <summary>
    /// Finds all books that contain the specified genre
    /// </summary>
    /// <param name="genre">The genre to search for</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A list of books containing the specified genre</returns>
    Task<IReadOnlyList<Model.Book?>> FindSingleGenreBooks(Genre genre, CancellationToken ct = default);

    /// <summary>
    /// Finds all books that match any of the specified genres
    /// </summary>
    /// <param name="genres">Collection of genres to search for</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A list of books matching any of the specified genres</returns>
    Task<IReadOnlyList<Model.Book?>> FindMultipleGenresBooks(IEnumerable<Genre> genres, CancellationToken ct = default);

    // ============== BOOK MANAGEMENT OPERATIONS ==============

    /// <summary>
    /// Updates the title of an existing book
    /// </summary>
    /// <param name="oldTitle">Current title of the book</param>
    /// <param name="newTitle">New title to update to</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>The updated book entity</returns>
    Task<Model.Book> UpdateBookTitle(string oldTitle, string newTitle, CancellationToken ct = default);

    /// <summary>
    /// Updates the genres associated with a book
    /// </summary>
    /// <param name="bookTitle">Title of the book to update</param>
    /// <param name="genres">New set of genres to assign</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>The updated book entity</returns>
    Task<Model.Book> UpdateBookGenres(string bookTitle, SortedSet<Genre> genres, CancellationToken ct = default);

    /// <summary>
    /// Updates the author of a book
    /// </summary>
    /// <param name="bookTitle">Title of the book to update</param>
    /// <param name="author">New author information</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>The updated book entity</returns>
    Task<Model.Book> UpdateBookAuthor(string bookTitle, Author author, CancellationToken ct = default);

    /// <summary>
    /// Updates the publisher of a book
    /// </summary>
    /// <param name="bookTitle">Title of the book to update</param>
    /// <param name="publisher">New publisher information</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>The updated book entity</returns>
    Task<Model.Book> UpdateBookPublisher(string bookTitle, Publisher publisher, CancellationToken ct = default);

    /// <summary>
    /// Saves a new book to the repository
    /// </summary>
    /// <param name="book">The book entity to save</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>The saved book entity with generated ID</returns>
    Task<Model.Book> SaveBook(Model.Book book, CancellationToken ct = default);
}