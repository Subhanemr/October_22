using _22_10_23.Exseptions;
using _22_10_23.Metods;

namespace _22_10_23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task 1

            //Task 1

            List<ProgramLanguage> prLanguages = new List<ProgramLanguage>
            {
                new ProgramLanguage { Name = "Fortran", Year = 1957 },
                new ProgramLanguage { Name = "LISP", Year = 1958 },
                new ProgramLanguage { Name = "Visual Basic.NET", Year = 2000 },
                new ProgramLanguage { Name = "COBOL ", Year = 1959 },
                new ProgramLanguage { Name = "ALGOL", Year = 1958 },
                new ProgramLanguage { Name = "APT", Year = 1960 },
                new ProgramLanguage { Name = "C# ", Year = 2000 },
                new ProgramLanguage { Name = "BASIC", Year = 1964 },
                new ProgramLanguage { Name = "PL/I", Year = 1964 },
                new ProgramLanguage { Name = "Simula", Year = 1967 },
                new ProgramLanguage { Name = "C", Year = 1972 },
                new ProgramLanguage { Name = "Prolog", Year = 1972 },
                new ProgramLanguage { Name = "JavaScript", Year = 1995 },
                new ProgramLanguage { Name = "Pascal", Year = 1970 },
                new ProgramLanguage { Name = "Smalltalk", Year = 1972 },
                new ProgramLanguage { Name = "Kotlin", Year = 2011 },
                new ProgramLanguage { Name = "C++", Year = 1983 },
                new ProgramLanguage { Name = "Ada", Year = 1983 },
                new ProgramLanguage { Name = "Objective-C", Year = 1983 },
                new ProgramLanguage { Name = "Perl", Year = 1987 },
                new ProgramLanguage { Name = "Python", Year = 1989 },
                new ProgramLanguage { Name = "Haskell", Year = 1990 },
                new ProgramLanguage { Name = "Java", Year = 1995 },
                new ProgramLanguage { Name = "PHP ", Year = 1995 },
                new ProgramLanguage { Name = "Rust", Year = 2010 },
                new ProgramLanguage { Name = "Swift", Year = 2014 },
                new ProgramLanguage { Name = "Go", Year = 2007 }
            };
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("UnSorted List:");
            ShowList(prLanguages);
            SortedList(prLanguages);
            //prLanguages.Sort(CompareByYear); //Bu ikinci Sortlamagin ikinci usuludur
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Sorted List:");
            ShowList(prLanguages);

            #endregion

            #region Task 3

            //Task 3

            List<Library> libraries = new List<Library>();
            List<Category> categories = new List<Category>();
            List<Book> books = new List<Book>();

            while (true)
            {
                Console.WriteLine("=======");
                Console.WriteLine(" Menu");
                Console.WriteLine("=======");
                Console.WriteLine("[1] Create a new library");
                Console.WriteLine("[2] Create a new catagory");
                Console.WriteLine("[3] Create a new book");
                Console.WriteLine("[4] Enter the library");
                Console.WriteLine("[5] exit");
                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    try
                    {
                        switch (choice)
                        {
                            case 1:
                                string splitedLibraryName = "";
                                Console.Write("Enter the name of the library: ");
                                string libraryName = Console.ReadLine();
                                string[] libraryNameSplit = libraryName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                                foreach (var word in libraryNameSplit)
                                {
                                    splitedLibraryName += Capitalize(word);
                                }
                                libraries.Add(new Library(splitedLibraryName));
                                Console.WriteLine("Library created.");
                                break;
                            case 2:
                                string splitedCategoryName = "";
                                Console.Write("Enter the name of the category: ");
                                string categoryName = Console.ReadLine();
                                string[] categoryNameSplit = categoryName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                                foreach (var word in categoryNameSplit)
                                {
                                    splitedCategoryName += Capitalize(word);
                                }
                                categories.Add(new Category(splitedCategoryName));
                                Console.WriteLine("Category created.");
                                break;
                            case 3:
                                string splitedBookName = "";
                                Console.Write("Enter the name of the book: ");
                                string bookName = Console.ReadLine();
                                string[] bookNameSplit = bookName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                                foreach (var word in bookNameSplit)
                                {
                                    splitedBookName += Capitalize(word);
                                }
                                string splitedAuthorName = "";
                                Console.Write("Enter the author of the book: ");
                                string authorName = Console.ReadLine();
                                string[] authorNameSplit = authorName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                                foreach (var word in authorNameSplit)
                                {
                                    splitedBookName += Capitalize(word);
                                }
                                Console.WriteLine("Select a category for the book:");
                                for (int i = 0; i < categories.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {categories[i].Name}");
                                }

                                int categoryChoice;
                                if (int.TryParse(Console.ReadLine(), out categoryChoice) && categoryChoice >= 1 && categoryChoice <= categories.Count)
                                {
                                    Category selectedCategory = categories[categoryChoice - 1];
                                    Book newBook = new Book(splitedBookName, splitedAuthorName, selectedCategory);
                                    books.Add(newBook);
                                    Console.WriteLine("Book created.");
                                }
                                else
                                {
                                    throw new CategoryNotFoundException("Invalid category selection.");
                                }
                                break;
                            case 4:
                                Console.WriteLine("Select a library:");
                                for (int i = 0; i < libraries.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {libraries[i].Name}");
                                }

                                int libraryChoice;
                                if (int.TryParse(Console.ReadLine(), out libraryChoice) && libraryChoice >= 1 && libraryChoice <= libraries.Count)
                                {
                                    Library selectedLibrary = libraries[libraryChoice - 1];
                                    LibraryMenu(selectedLibrary, books);
                                }
                                else
                                {
                                    throw new LibraryNotFoundException("Library not found.");
                                }

                                break;
                            case 5:
                                Environment.Exit(0);
                                break;
                            default:
                                throw new WrongInputException("Invalid choice.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }

            #endregion
        }

        #region Task 1 Metods

        //Task 1 Metods
        public static int CompareByYear(ProgramLanguage x, ProgramLanguage y)
        {
            return x.Year.CompareTo(y.Year);
        }
        public static void ShowList(List<ProgramLanguage> prLanguages)
        {
            foreach (var prLanguage in prLanguages)
            {
                Console.WriteLine($"Name: {prLanguage.Name}, Year: {prLanguage.Year}");
            }
        }
        static void SortedList(List<ProgramLanguage> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0; j < list.Count - i - 1; j++)
                {
                    if (list[j].Year > list[j + 1].Year)
                    {
                        var temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
        }

        #endregion

        #region Task 3 Metods

        //Task 3 Metods
        static string Capitalize(string word)
        {
            char[] chars = word.ToLower().ToCharArray();
            chars[0] = char.ToUpper(chars[0]);

            return new string(chars);
        }
        static void LibraryMenu(Library library, List<Book> books)
        {
            while (true)
            {
                Console.WriteLine($"Library Menu for {library.Name}:");
                Console.WriteLine("1. Add book");
                Console.WriteLine("2. Show books");
                Console.WriteLine("3. Exit Library");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    try
                    {
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("Select a book to add to the library:");
                                for (int i = 0; i < books.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {books[i].Name} by {books[i].Author}");
                                }

                                int bookChoice;
                                if (int.TryParse(Console.ReadLine(), out bookChoice) && bookChoice >= 1 && bookChoice <= books.Count)
                                {
                                    Book selectedBook = books[bookChoice - 1];
                                    library.AddBook(selectedBook);
                                }
                                else
                                {
                                    throw new BookNotFoundException("Book not found.");
                                }
                                break;
                            case 2:
                                library.ListAllBooks();
                                break;
                            case 3:
                                return;
                            default:
                                throw new WrongInputException("Invalid choice.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }


        #endregion
    }
}