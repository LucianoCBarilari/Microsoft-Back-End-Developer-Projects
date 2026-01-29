# Foundations-of-Coding-Back-End-by-Microsoft


# Project Objectives

- Create a console application to manage inventory.
- Allow users to manage product stock efficiently.
- Provide functionality to add, sell, restock, view all, and remove products.

---

# Project Requirements

## Functional Requirements

- The system allows users to add new products.
- The system allows users to sell products and update stock.
- The system allows users to restock products.
- The system allows users to view all products and their stock levels.
- The system allows users to remove products from the inventory.

## Non-Functional Requirements

- The application must be a console-based application.
- The project must be developed using C# and .NET.
- The system must run on .NET 10.
- The user interface must be menu-driven.
- The application must be simple and easy to use.

---

# Design Declarations

## Product Class

**Attributes:**
- Price (decimal)
- Name (string)
- Quantity (integer)

**Access Modifiers:**
- All attributes are public.

---

# Program Methods (Program.cs)

**Note:**  
All methods are implemented as **static methods** inside `Program.cs` to allow direct access from the `Main` method without creating class instances.

**Static Methods:**
- AddProduct
- UpdateProduct
- ViewAllProducts
- RemoveProduct

---

# Method Descriptions (Design Logic)

## AddProduct (static)

- Create a new Product instance.
- Display: "Enter Name:"
- Assign input to `NewProduct.Name` using `Console.ReadLine().Trim().ToLower()`.
- Validate the name using Regex.
- Display: "Enter Price:"
- Convert input to decimal and assign to `NewProduct.Price`.
- Display: "Enter Quantity:"
- Convert input to integer and assign to `NewProduct.Quantity`.
- Add `NewProduct` to the `ProductsDetails` list.
- Return `true` if the operation is successful.

---

## UpdateProduct(string NameOfProduct) (static)

- Find the product in `ProductsDetails` using the product name.
- If the product is not found:
  - Print "Product not found."
  - Return `false`
- Display: "Enter new name (or press Enter to keep current):"
- If a new name is entered, update the product name.
- Display: "Enter new price:" and update the price.
- Display: "Enter new quantity:" and update the quantity.
- Print "Update successful!"
- Return `true`

---

## RemoveProduct(string NameOfProduct) (static)

- Search for the product in `ProductsDetails`.
- If the product is not found:
  - Print "Product not found."
  - Return `false`
- Remove the product from the list.
- Print "Product removed successfully."
- Return `true`

---

## ViewAllProducts (static)

- If `ProductsDetails` is empty:
  - Print "Inventory is empty."
  - End method
- Print "Current Inventory:"
- Print a separator line.
- For each product in `ProductsDetails`, display:
  - Name
  - Price
  - Stock quantity
- Print a closing separator line.

---

# Program Structure (program.cs)

**START PROGRAM**

- Declare a list to store products:
  - `List<Product> ProductsDetails = new();`

- Declare a list of strings called `MenuOptions`
- Add the following options to the list:
  - 1. Add New Product
  - 2. Update a Product
  - 3. View All Products
  - 4. Remove a Product
  - ESC. Exit Program

- Start an infinite loop (`while true`)
  - Clear the console
  - Print "Inventory Management System"
  - Print a separator line

  - For each option in `MenuOptions`
    - Print the option
  - End for

  - Print "Select an option:"
  - Read the key pressed from the keyboard

  - If the pressed key is Escape
    - End the program
  - End if

  - Use a switch statement based on the pressed key:
    - Case "1": Call `AddProduct`
    - Case "2": Call `UpdateProduct`
    - Case "3": Call `ViewAllProducts`
    - Case "4": Call `RemoveProduct`
    - Default: Print "Invalid option. Please try again."
  - End switch

  - Print "Press any key to continue..."
  - Wait for user input

- End while

**END PROGRAM**
