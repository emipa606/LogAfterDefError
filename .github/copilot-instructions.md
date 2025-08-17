# GitHub Copilot Instructions for "Log After Def Error (Continued)"

## Mod Overview and Purpose
"Log After Def Error (Continued)" is an updated version of the original mod created by ordpuss. The primary purpose of the mod is to assist RimWorld mod developers by providing more detailed logging information whenever there are errors during the parsing of XML files into C# objects. In vanilla RimWorld, parsing exceptions provide minimal information, making it difficult to pinpoint the exact location and cause of XML errors. This mod enhances error logs by including the name of the definition, the mod name, the path to the XML, and the specific XML file involved, which facilitates quicker debugging and resolution of parsing issues.

## Key Features and Systems
- **Enhanced Error Logging:** Automatically logs detailed information about XML parsing errors, including the structure: `defName:modName/pathToXml/xmlFile.xml`.
- **Debugging Support:** Helps modders trace and resolve XML errors that occur during the loading of mods, reducing debugging time.
- **User-Friendly Interface:** Integrates with RimWorld's existing logging systems to blend seamlessly into the modding workflow.

## Coding Patterns and Conventions
- **C# Access Modifiers:** The mod features classes with internal access modifiers to encapsulate functionality.
- **Modular Code Structure:** The code is organized into distinct files and classes (e.g., `Harmony.cs` and `LogAfterDefError.cs`) to maintain clarity and separation of concerns.
- **Consistent Naming Patterns:** Classes and methods use PascalCase naming, following C# conventions for readability and consistency.

## XML Integration
- The mod interacts with XML files, commonly used in RimWorld for defining various game elements. These files are parsed into C# objects.
- Handles errors that occur during this parsing process and logs extensive information for mod developers to diagnose issues efficiently.

## Harmony Patching
- Harmony, a method-patching library used in RimWorld modding, is a key aspect of this mod's functionality.
- **File:** `Harmony.cs`
  - Contains the static class `HarmonyPatches`, which includes patches for methods related to XML loading, such as `Verse__DirectXmlLoader__DefFromNode`.
- The mod applies Harmony patches to RimWorld's direct XML loader, capturing and augmenting the error logs when a definition parsing error occurs.

## Suggestions for Copilot
To maximize the utility of GitHub Copilot in this project:
- **Utilize Copilot for Error Handling Enhancements:** Leverage Copilot to suggest more robust error handling and logging mechanisms that can extract even more useful data from exceptions.
- **Prompt for Helper Method Generation:** Ask Copilot to generate helper methods for common tasks, such as parsing paths or formatting log entries for better readability.
- **Seek XML Parsing Improvements:** Use Copilot to explore additional ways to validate XML against expected schemas or data structures pre-parsing, helping to prevent errors proactively.

By following these instructions and leveraging GitHub Copilot's capabilities, mod developers can maintain high code quality and efficiently address XML parsing errors in their RimWorld mods.
