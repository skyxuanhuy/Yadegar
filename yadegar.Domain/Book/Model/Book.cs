using yadegar.Domain.Enum;
using yadegar.Domain.Model;

namespace yadegar.Domain.Book.Model;

public class Book
{
    public long Id { get; private set; }
    public string Title { get; private set; }
    public long Isbn { get; private set; }
    public Author Author { get; private set; }
    public Publisher Publisher { get; private set; }
    public Translator Translator { get; private set; }
    public SortedSet<Genre> Genre { get; private set; }
    public DateOnly? PurchaseDate { get; private set; }
    public bool HasRead { get; private set; }
    public DateTime? DeletedAt { get; private set; }

    private Book()
    {
        Genre = new SortedSet<Genre>();
    }


    public class Builder
    {
        private readonly Book _book = new Book();

        public Builder WithId(long id)
        {
            _book.Id = id;
            return this;
        }

        public Builder WithTitle(string title)
        {
            _book.Title = title;
            return this;
        }

        public Builder WithIsbn(long isbn)
        {
            _book.Isbn = isbn;
            return this;
        }

        public Builder WithAuthor(Author author)
        {
            _book.Author = author;
            return this;
        }

        public Builder WithPublisher(Publisher publisher)
        {
            _book.Publisher = publisher;
            return this;
        }

        public Builder WithTranslator(Translator translator)
        {
            _book.Translator = translator;
            return this;
        }

        public Builder WithGenre(Genre genre)
        {
            _book.Genre.Add(genre);
            return this;
        }

        public Builder WithGenres(IEnumerable<Genre> genres)
        {
            if (genres != null)
            {
                foreach (var genre in genres)
                {
                    _book.Genre.Add(genre);
                }
            }
            return this;
        }

        public Builder WithPurchaseDate(DateOnly purchaseDate)
        {
            _book.PurchaseDate = purchaseDate;
            return this;
        }

        public Builder HasBeenRead(bool hasRead = true)
        {
            _book.HasRead = hasRead;
            return this;
        }

        public Builder MarkAsDeleted(DateTime deletedAt)
        {
            _book.DeletedAt = deletedAt;
            return this;
        }

        public Book Build()
        {
            // You can add validation logic here before returning the book
            if (string.IsNullOrEmpty(_book.Title))
                throw new InvalidOperationException("Book must have a title");

            return _book;
        }
    }

    // Static factory method to create a new builder
    public static Builder CreateBuilder() => new Builder();

}