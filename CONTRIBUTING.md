# Minimal Code Quality Guidelines

### What is this?
These are some minimal guideliness that pull requests should follow. These are not absolute, but please try do follow this as best you can.

### Naming
* Variables should have descriptive names. Names should not be too short. For example, a variable representing discounted price may be called `discountedPrice` and not `dp`. Names should not be too long either, for example `amountThatWillBeDiscountedFromBill` is too much.

* As per C# Conventions, method names should be in Pascal Case, which means the first letter of every word should be capitalized.

* Interface names should begin with 'I'.

<code>
public int ApplyDiscount()
</code>

* Names be some sort of action. So the in the form "verb-noun" is acceptable. For example
`GetAllBooks()` is better than `AllBooks`

* Properties should have their first letter capitalized.

### Comments

* It would be great to have functions, classes and properties have minimal XML documentation. XML Documentation is written just above the function, class or property and can be auto generated with three slashes(/). For example

<code>
/// <summary>
/// Calcuate the total value of all the products
/// </summary>
/// <param name="products">The list of products</param>
/// <returns type="decimal">Total bill amount after discount</returns>
public decimal ValueProducts(IEnumerable<Product> products)
{

}
</code>

* The code may also have comments where the steps become too complicated or it may need explaining.

### Length

* Try to keep the functions short. If the function is more than 15 lines long, perhaps try splitting into smaller functions. More small functions is *much* better than fewer big functions. The same goes for classes.

### Interfaces

* Each class must have an associated public interface, that it implements. 

### Commits

* Please include a small, one line description of your commit, followed by a more detailed explaination uner it. Be as descriptive as you can.

