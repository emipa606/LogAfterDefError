# Copilot Instructions for Log After Def Error (Continued) Mod

## Mod Overview and Purpose
The **Log After Def Error (Continued)** mod aims to enhance the debugging and error-tracing experience in RimWorld modding by providing detailed logging information whenever an XML parsing error is encountered. This helps mod developers quickly identify and resolve issues related to XML to C# data translation by printing the complete definition details involved in the error.

## Key Features and Systems
- **Enhanced Logging**: Captures and logs details related to XML parsing errors, which aids in identifying the problematic def and its location.
- **Localization of Errors**: Provides a structured info output detailing `defName`, `modName`, path, and the XML file where the error occurred.
- **Integration with RimWorld Modding Environment**: Designed to work seamlessly with the RimWorld environment, ensuring compatibility and improved error-reporting.

## Coding Patterns and Conventions
- **C# Best Practices**: Utilize clear and concise naming conventions for classes, methods, and members. Consider using PascalCasing for types and method names, and camelCasing for member variables.
- **Error Handling**: Implement robust error handling around XML parsing operations to provide meaningful logging and maintain mod stability.
- **Comments and Documentation**: Include comments and XML documentation to clarify complex logic and enhance code readability.

## XML Integration
- Create XML files that declare the dependencies and the metadata required by the mod.
- Ensure that XML parsers properly convert XML data into C# objects, adding necessary validation checks to handle inconsistencies.

## Harmony Patching
- **Patch Target Methods**: Use Harmony to target specific methods in the XML parsing process where errors are likely to occur. For this mod, methods such as `Prefix` and `Postfix` in `DirectXmlLoader_DefFromNode` are patched.
- **Implementing Harmony**: Ensure that Harmony patches are well-defined and perform additional logging around method calls to capture useful debugging information.
- **Dependency Management**: Manage dependencies such as `brrainz.harmony` efficiently to ensure compatibility with other mods and maintain performance.

## Suggestions for Copilot
1. **Code Suggestions**: Use Copilot to suggest error-handling mechanisms and provide alternative methods for XML parsing and data validation.
2. **Logging Enhancements**: Generate ideas for enhancing logging outputs, such as incorporating additional context information or formatting options.
3. **Optimization Patterns**: Leverage Copilot's ability to suggest optimization techniques in parsing and data transformation processes, ensuring the mod performs well without unnecessary overhead.
4. **Best Practices Check**: Use Copilot to validate coding practices and conventions, ensuring a consistent and maintainable codebase.
5. **Troubleshooting Assistance**: Implement Copilot suggestions for common troubleshooting patterns that may help in debugging the mod further.

---

By following these instructions, Copilot can provide enhanced support for developers maintaining and extending the `Log After Def Error (Continued)` mod, resulting in a more productive and efficient modding experience.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

